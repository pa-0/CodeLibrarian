unit uMainForm;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, FileUtil, Forms, Controls, Graphics, Dialogs, ComCtrls,
  ExtCtrls, SynEdit, SynHighlighterPas, ActnList, StdActns, Menus,
  GpStructuredStorage;

type

  { TMainFrm }

  TMainFrm = class(TForm)
    aclMain          : TActionList;
    actEditCopy      : TEditCopy;
    actEditCut       : TEditCut;
    actEditPaste     : TEditPaste;
    actEditUndo      : TEditUndo;
    actFileExit      : TFileExit;
    actFileOpen      : TFileOpen;
    actFolderRootNew : TAction;
    actFolderNew     : TAction;
    actDelete        : TAction;
    actExpandAll     : TAction;
    actCollapseAll   : TAction;
    actCompact       : TAction;
    actSnippetNew    : TAction;
    actSnippetSave   : TAction;
    actFileNew       : TFileOpen;
    actFileImport    : TFileOpen;
    imlMain          : TImageList;
    MenuItem2        : TMenuItem;
    mniDelete        : TMenuItem;
    mniSepItem       : TMenuItem;
    mniSepItem6      : TMenuItem;
    mniFolderNew     : TMenuItem;
    mniFolderRootNew : TMenuItem;
    mniSnippetNew    : TMenuItem;
    mniEditNew       : TMenuItem;
    mnuMain          : TMainMenu;
    MenuItem1        : TMenuItem;
    mniFileOpen      : TMenuItem;
    mniExit          : TMenuItem;
    mniSepItem2      : TMenuItem;
    miCompact        : TMenuItem;
    mniSepItem1      : TMenuItem;
    mniNew           : TMenuItem;
    mnuFile          : TMenuItem;
    mnuEditUndo      : TMenuItem;
    mnuEditPaste     : TMenuItem;
    mnuEditCut       : TMenuItem;
    mnuEditCopy      : TMenuItem;
    mnuEdit          : TMenuItem;
    Splitter1        : TSplitter;
    StatusBar1       : TStatusBar;
    snEditor         : TSynEdit;
    shlPascal        : TSynFreePascalSyn;
    ToolBar1         : TToolBar;
    btnFileOpen      : TToolButton;
    btnExpandAll     : TToolButton;
    btnCollapseAll   : TToolButton;
    btnSnippetNew    : TToolButton;
    btnFolderRootNew : TToolButton;
    btnFolderNew     : TToolButton;
    ToolButton1      : TToolButton;
    ToolButton4      : TToolButton;
    btnEditCopy      : TToolButton;
    btnEditCut       : TToolButton;
    btnEditPaste     : TToolButton;
    btnEditUndo      : TToolButton;
    ToolButton9      : TToolButton;
    tvData           : TTreeView;
    procedure actCollapseAllExecute   (Sender : TObject);
    procedure actCompactExecute       (Sender : TObject);
    procedure actCompactUpdate        (Sender : TObject);
    procedure actDeleteExecute        (Sender : TObject);
    procedure actDeleteUpdate         (Sender : TObject);
    procedure actEditUndoExecute      (Sender : TObject);
    procedure actEditUndoUpdate       (Sender : TObject);
    procedure actExpandAllExecute     (Sender : TObject);
    procedure actFileImportAccept     (Sender : TObject);
    procedure actFileNewAccept        (Sender : TObject);
    procedure actFileOpenAccept       (Sender : TObject);
    procedure actFolderNewExecute     (Sender : TObject);
    procedure actFolderRootNewExecute (Sender : TObject);
    procedure actSnippetNewExecute    (Sender : TObject);
    procedure actSnippetSaveExecute   (Sender : TObject);
    procedure actSnippetSaveUpdate    (Sender : TObject);
    procedure FormClose(Sender : TObject; var CloseAction : TCloseAction);
    procedure snEditorExit            (Sender : TObject);
    procedure tvDataChange            (Sender : TObject; Node : TTreeNode);
    procedure tvDataChanging          (Sender : TObject; Node : TTreeNode;
                                       var AllowChange : Boolean);
    procedure tvDataEdited            (Sender : TObject; Node : TTreeNode; var S : string);
  private
    { private declarations }

    FAutoExpandNodes : Boolean;
    FCodeLib         : IGpStructuredStorage;

    function GetNodePath (aNode:TTreeNode)                                             : String;
    function IsFolder    (aNode:TTreeNode)                                             : Boolean;
    function IsFile      (aNode:TTreeNode)                                             : Boolean;
    function UniqueName  (aPath:string;Folder:Boolean)                                 : string;
    function NewNode     (const aParent:TTreeNode; aText:String; Folder:Boolean = True): TTreeNode;
    procedure SetAutoExpandNodes (aValue      : Boolean);
    procedure ValidateName       (aObjectName : string);
    procedure ValidateFileName   (aName       : string);
    procedure SaveData           (const aNode:TTreeNode);
    procedure LoadCodeLib;
  public
    { public declarations }
    constructor Create(TheOwner : TComponent); override;

    procedure OpenLibrary   (aName       : string);
    procedure ImportLib     (const aFileName:string; const aRootFolder : string = '');
    //when true it opens all tree nodes when opening a library.
    property AutoExpandNodes : Boolean read FAutoExpandNodes write SetAutoExpandNodes;
  end;

var
  MainFrm : TMainFrm;

implementation
uses strutils, variants;
{$R *.lfm}

resourcestring
  FolderPrefix          = 'Folder ';
  FilePrefix            = 'Snippet ';
  rsclbUniqueNameFailed = 'Unable to find unique Name';
  rsInvalidName         = 'Invalid Object name <%S>';


const
  cCodeLibPathSep     = '/';
  tpSnippet           = 1;
  tpFolder            = 2;
  idxFolderNormal     = 9;
  idxFolderSelected   = 9;
  idxSnippetNormal    = 11;
  idxSnippetSelected  = 11;

function addSlash(aItem:string):string;
begin
  if aItem[Length(aItem)] <> cCodeLibPathSep then Result := aItem + cCodeLibPathSep else Result := aItem;
end;

function MakeFileName(const FolderName, FileName: string): string;
begin
  Result := FolderName;
  if Result = '' then
    Result := cCodeLibPathSep
  else
    Result := AddSlash(Result);
  if FileName <> '' then
  begin
    if FileName[1] = cCodeLibPathSep then
      Result := Result + Copy(FileName, 2, 9999999)
    else
      Result := Result + FileName;
  end;
end;
{ TMainFrm }

procedure TMainFrm.actFileOpenAccept(Sender : TObject);
var
  vFName : String;
begin
  vFName := actFileOpen.Dialog.FileName;
  if FCodeLib.IsStructuredStorage(vFName) then OpenLibrary(vFName);
end;

procedure TMainFrm.actFolderNewExecute(Sender : TObject);
var
  vNode : TTreeNode;
  vPath : string;
  vName : string;
begin
  vNode := tvData.Selected;
  while IsFile(vNode) and (vNode<>nil) do
    vNode := vNode.Parent;
  vPath := GetNodePath(vNode);
  vName := UniqueName(GetNodePath(vNode), True);
  ValidateFileName(vName);
  ValidateName(vPath + vName);
  FCodeLib.CreateFolder(vPath + vName);
  tvData.Items.BeginUpdate;
  try
    tvData.Selected := Nil;
    vNode := NewNode(vNode, vName);
    tvData.Selected := vNode;
  finally
    tvData.items.EndUpdate;
  end;
end;

procedure TMainFrm.actFolderRootNewExecute(Sender : TObject);
var
  vNode : TTreeNode;
  vName : string;
  vPath : string;
begin
  vPath := GetNodePath(nil);
  vName := UniqueName(vPath, True);
  ValidateFileName(vName);
  ValidateName(vPath + vName);
  FCodeLib.CreateFolder(vPath+vName);
  vNode := NewNode(nil, vName);
  tvData.Selected := vNode;
end;

procedure TMainFrm.actSnippetNewExecute(Sender : TObject);
var
  vNode : TTreeNode;
  vPath : string;
  vName : string;
  vStrm : TStream;
begin
  vNode := tvData.Selected;
  while (vNode <> nil) and (not IsFolder(vNode)) do
    vNode := vNode.Parent;
  vPath := GetNodePath(vNode);
  vName := UniqueName(vPath, False);
  vStrm := FCodeLib.OpenFile(vPath+vName, fmCreate);
  vStrm.Free;
  vNode := NewNode(vNode,vName, False);
  tvData.Selected := vNode;
end;

procedure TMainFrm.actFileNewAccept(Sender : TObject);
begin
  FCodeLib.Initialize(actFileNew.Dialog.FileName, fmCreate);
  LoadCodeLib;
end;

procedure TMainFrm.actExpandAllExecute(Sender : TObject);
var
  vNode: TTreeNode;
begin
  vNode := tvData.Items.GetFirstNode;
  while vNode <> nil do begin
    vNode.Expand(True);
    vNode := vNode.GetNextSibling;
  end;
end;

procedure TMainFrm.actFileImportAccept(Sender : TObject);
var
  vFName : string;
begin
  vFName := actFileImport.Dialog.FileName;
  vFName := ExtractFileNameOnly(vFName);
  ImportLib(actFileImport.Dialog.FileName, cCodeLibPathSep + vFName);
end;

procedure TMainFrm.actCollapseAllExecute(Sender : TObject);
var
  vNode: TTreeNode;
begin
  vNode := tvData.Items.GetFirstNode;
  while vNode <> nil do begin
    vNode.Collapse(True);
    vNode := vNode.GetNextSibling;
  end;
end;

procedure TMainFrm.actCompactExecute(Sender : TObject);
begin
  if Assigned(FCodeLib) and FCodeLib.IsInitialized then FCodeLib.Compact;
end;

procedure TMainFrm.actCompactUpdate(Sender : TObject);
begin
  actCompact.Enabled := (FCodeLib <> nil) and FCodeLib.IsInitialized;
end;

procedure TMainFrm.actDeleteExecute(Sender : TObject);
var
  vPath   : string;
  vName   : string;
  vNode   : TTreeNode;
  vChoice : Integer;
begin
  if tvData.Selected <> nil then begin
    vPath := GetNodePath(tvData.Selected);
    ValidateName(vPath);
    vChoice := MessageDlg('Delete ' + IfThen(IsFolder(tvData.Selected),Trim(FolderPrefix), Trim(FilePrefix)),
                          'Are you sure you want to delete ' + tvData.Selected.Text +' ?',
                          mtConfirmation,mbYesNoCancel, 0);
    if vChoice in [mrNo, mrCancel] then begin
      Exit;
    end;
    FCodeLib.Delete(vPath);
    vNode := tvData.Selected;
    tvData.Selected := vNode.GetPrevVisible;
    if tvData.Selected = nil then tvData.Selected := vNode.GetNextVisible;
    vNode.Delete;
  end;
end;

procedure TMainFrm.actDeleteUpdate(Sender : TObject);
begin
  actDelete.Enabled := tvData.Selected <> nil;
end;

procedure TMainFrm.actEditUndoExecute(Sender : TObject);
begin
  if snEditor.CanUndo then snEditor.Undo;
end;

procedure TMainFrm.actEditUndoUpdate(Sender : TObject);
begin
  actEditUndo.Enabled := snEditor.CanUndo;
end;

procedure TMainFrm.actSnippetSaveExecute(Sender : TObject);
begin
  if snEditor.Modified then SaveData(tvData.Selected);
end;

procedure TMainFrm.actSnippetSaveUpdate(Sender : TObject);
begin
  actSnippetSave.Enabled := snEditor.Modified;
end;

procedure TMainFrm.FormClose(Sender : TObject; var CloseAction : TCloseAction);
begin
  if snEditor.Modified then SaveData(tvData.Selected);
end;

procedure TMainFrm.snEditorExit(Sender : TObject);
begin
  if snEditor.Modified then SaveData(tvData.Selected);
end;

procedure TMainFrm.tvDataChange(Sender : TObject; Node : TTreeNode);
var
  vFile : String;
  vStrm : TStream;
begin
  if IsFile(Node) then begin
    vFile := GetNodePath(Node);
    vStrm := FCodeLib.OpenFile(vFile,fmOpenReadWrite);
    try
      snEditor.Lines.LoadFromStream(vStrm)
    finally
      vStrm.Free;
    end;
  end;// else snEditor.ClearAll;
end;

procedure TMainFrm.tvDataChanging(Sender : TObject; Node : TTreeNode;
  var AllowChange : Boolean);
begin
  if snEditor.Modified then begin
    SaveData(Node);
  end;
end;

procedure TMainFrm.tvDataEdited(Sender : TObject; Node : TTreeNode;
  var S : string);
var
  vTmp : string;
begin
  if CompareText(S, Node.Text) = 0 then Exit;
  vTmp := GetNodePath(Node.Parent);
  if FCodeLib.FileExists(vTmp+Node.Text) then begin
    FCodeLib.Move(vTmp+Node.Text, vTmp+S);
  end;
  if FCodeLib.FolderExists(vTmp+Node.Text) then begin
    FCodeLib.Move(vTmp+Node.Text, vTmp+S);
  end;
end;


function TMainFrm.GetNodePath(aNode : TTreeNode) : String;
var
  vNode : TTreeNode;
begin
  Result := '/';
  if not Assigned(aNode)then Exit;
  vNode := aNode;
  While vNode <> nil do begin
    Result :=  '/' + vNode.Text + Result;
    vNode  := vNode.Parent;
  end;
  if Integer(aNode.Data) = tpSnippet then SetLength(Result, Length(Result) - 1);
end;

function TMainFrm.IsFolder(aNode : TTreeNode) : Boolean;
begin
  if Assigned(aNode) then Result := Integer(aNode.Data) = tpFolder
  else Result := False;
end;

function TMainFrm.IsFile(aNode : TTreeNode) : Boolean;
begin
  if Assigned(aNode) then
   Result := Integer(aNode.Data) = tpSnippet
  else Result:= False;
end;

procedure TMainFrm.SetAutoExpandNodes(aValue : Boolean);
begin
  if FAutoExpandNodes = aValue then Exit;
  FAutoExpandNodes := aValue;
end;

function TMainFrm.UniqueName(aPath : String; Folder : Boolean) : string;
var
  vCnt : Cardinal = 0;
  vTmp : string   = '';
begin
  Result := IfThen(Folder, FolderPrefix, FilePrefix);
  While True do begin
    inc(vCnt);
    vTmp := Result + IntToStr(vCnt);
    if not (FCodeLib.FolderExists(aPath + vTmp) or FCodeLib.FileExists(aPath + vTmp)) then begin
      Result := vTmp;
      Exit;
    end;
    if vCnt = 0 then raise Exception.Create(rsclbUniqueNameFailed); //searched all the range of uint32 and hit 0 again.
  end;
end;

function IfThen(aCondition : Boolean; const TrueResult : Pointer; const FalseResult : Pointer = nil) : Pointer; overload;
begin
  if aCondition then Result := TrueResult else Result := FalseResult;
end;

function IfThen(aCondition : Boolean; const TrueResult : Integer; const FalseResult : Integer = 0) : Integer; overload;
begin
  if aCondition then Result := TrueResult else Result := FalseResult;
end;

function TMainFrm.NewNode(const aParent : TTreeNode; aText : String;
  Folder : Boolean) : TTreeNode;
begin
  Result               := tvData.Items.AddChild(aParent, aText);
  Result.Data          := IfThen(Folder, Pointer(tpFolder), Pointer(tpSnippet) );
  Result.ImageIndex    := IfThen(Folder, idxFolderNormal,   idxSnippetNormal   );
  Result.SelectedIndex := IfThen(Folder, idxFolderSelected, idxSnippetSelected );
end;

procedure TMainFrm.ValidateName(aObjectName : String);
begin
  if (aObjectName ='') or (aObjectName[1] <> cCodeLibPathSep) then
    raise Exception.CreateFmt(rsInvalidName, [aObjectName]);
end;

procedure TMainFrm.ValidateFileName(aName : string);
begin
  if (Pos('/',aName) > 0) then raise Exception.Create('</> is an invalid character');
  if (Pos('\',aName) > 0) then raise Exception.Create('<\> is an invalid character');
  if aName = '' then raise Exception.Create('Name must be at least 1 character long');
end;

procedure TMainFrm.OpenLibrary(aName : String);
begin
  FCodeLib := Nil;
  FCodeLib := CreateStorage;
  FCodeLib.Initialize(aName, fmOpenReadWrite or fmShareExclusive);
  LoadCodeLib;
end;

procedure TMainFrm.SaveData(const aNode : TTreeNode);
var
  vFname : String  = '';
  vStrm  : TStream = nil;
begin
  if not IsFile(aNode) then Exit;
  ValidateFileName(aNode.Text);
  vFName := GetNodePath(aNode);
  ValidateName(vFname);
  if not FCodeLib.FileExists(vFname) then vStrm := FCodeLib.OpenFile(vFname, fmCreate)
  else vStrm := FCodeLib.OpenFile(vFname, fmOpenReadWrite);
  try
    snEditor.Lines.SaveToStream(vStrm);
  finally
    vStrm.Free;
  end;
end;


constructor TMainFrm.Create(TheOwner : TComponent);
begin
  inherited Create(TheOwner);
  FCodeLib := CreateStorage;
end;

procedure TMainFrm.LoadCodeLib;
  procedure LoadNodeFolder(aNode:TTreeNode);
  var
    vNode           : TTreeNode;
    vFolders,vFiles : TStringList;
    vCnt            : Integer;
    vPath           : string;
  begin
    vFolders := TStringList.Create;
    vFiles   := TStringList.Create;
    try
      vPath := GetNodePath(aNode);
      FCodeLib.FolderNames(vPath, vFolders);
      for vCnt := 0 to vFolders.Count -1 do begin
        vNode := NewNode(aNode, vFolders[vCnt]);
        LoadNodeFolder(vNode);
      end;
      FCodeLib.FileNames(vPath, VFiles);
      for vCnt := 0 to vFiles.Count -1 do begin
        vNode := NewNode(aNode, vFiles[vCnt], False);
      end;
    finally
      vFolders.Free;
      VFiles.Free;
    end;
  end;

begin
  tvData.Items.BeginUpdate;
  try
    tvData.Items.Clear;
    tvData.SortType := stNone;
    LoadNodeFolder(nil);
    tvData.Selected := nil;
  finally
    tvData.SortType := stText;
    tvData.Items.EndUpdate;
  end;
end;

procedure TMainFrm.ImportLib(const aFileName : string; const aRootFolder : string);
const
  cDelim = cCodeLibPathSep;
  function InclPathDel(inStr:String):string;
  begin
    Result:=inStr;
    if Result[Length(Result)] <> cDelim then Result := Result + cDelim;
  end;

var
  vFromLib, vToLib : IGpStructuredStorage;
  vBckCurs         : TCursor;
  procedure ImportFolder(aSourceFolder, aDestFolder:string);
  var
    vFolders, vFiles : TStringList;
    vFrom,    vTo    : TStream;
    vCnt             : Integer;
    vNewFolder       : string;
  begin
    vFolders := TStringList.Create;
    vFiles   := TStringList.Create;
    try
      aSourceFolder := InclPathDel(aSourceFolder);
      vFromLib.FolderNames(aSourceFolder, vFolders);
      for vCnt := 0 to vFolders.Count -1 do begin
        vNewFolder := InclPathDel(aDestFolder) + vFolders[vCnt];
        vToLib.CreateFolder(vNewFolder);
        ImportFolder(aSourceFolder + vFolders[vCnt] +cDelim, vNewFolder);
      end;
      vFromLib.FileNames(aSourceFolder, vFiles);
      aDestFolder := InclPathDel(aDestFolder);
      for vCnt := 0 to vFiles.Count -1 do begin
        vFrom      := vFromLib.OpenFile(aSourceFolder+vFiles[vCnt], fmOpenReadWrite);
        vTo        := vToLib.OpenFile(aDestFolder+vFiles[vCnt], fmCreate);
        try
          vTo.CopyFrom(vFrom, 0);
        finally
          vFrom.Free;
          vTo.Free;
        end;
      end;
    finally
      vFolders.Free;
      vFiles.Free;
    end;
  end;

begin
  Enabled := False;
  vBckCurs := Screen.Cursor;
  Screen.Cursor := crHourGlass;
  try
    vFromLib := CreateStorage;
    vFromLib.Initialize(aFileName, fmOpenReadWrite or fmShareExclusive);
    vToLib := FCodeLib;
    if vToLib.FolderExists(aRootFolder) then
      raise Exception.CreateFmt('Folder %S already exists in code library',[aRootFolder]);
    ImportFolder('/', aRootFolder);
    LoadCodeLib;
  finally
    Screen.Cursor := vBckCurs;
    Enabled := True;
  end;
end;

end.

