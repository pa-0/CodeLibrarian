GpStructuredStorage file
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   �     >                             
                                                                                 !       "   #   $   %   &   '   (   )                               2           5                                   >           A                                                                           T                                   ]       ^   _   `                                                               q       r   s               x           {       |   }                       �                                                           �           �       �   �               �       �   �   �       �       �               �       �       �   �   �   �   �               �       �               �       �   �   �   �   �   �       �                                   �       �       �       �   �       �                                                                            �                                   �       �                       �                                 �H o d g e   P o d g e       �  �H o d g e   P o d g e          	�V C L   -   L C L    �   �   	�V C L   -   L C L    �      
�A l g o r i t h m s        
�A l g o r i t h m s         �A p p l i c a t i o n   L e v e l   C o d e      V  �A p p l i c a t i o n   L e v e l   C o d e      '   �1 . F r e e   P a s c a l    X  B   �2 . G I T    c  f   �L i n u x   I n c a n t a t i o n s      0   �3 . L C L      ^   �W i n d o w s        �F i r e b i r d   S Q L   s e r v e r      �  
�A R i t h m e t i c    �  �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       �D a t a b a s e       �  �D a t a b a s e          �G r a p h i c s       x  �G r a p h i c s          �H a r d w a r e   S t u f f    6   �  �H a r d w a r e   S t u f f    7      �S t r a i g h t   P a s c a l    D   �  �S t r a i g h t   P a s c a l    E       
�D e l p h i   I D E    c   R   
�D e l p h i   I D E    d      �W i n d o w s    g   f   �W i n d o w s    h                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         Topic   Hodge Podge                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         Changing the DBNavigator Glyphs       �   Changing the DBNavigator Glyphs   	   A   # Changing the DBNavigator Glyphs (2)       0  # Changing the DBNavigator Glyphs (2)      E    Data-Aware TDateTimePicker       p   Data-Aware TDateTimePicker      <   ( Graying Out Disabled Data Aware Controls       �
  ( Graying Out Disabled Data Aware Controls      J   " Handling EDBEngineError Exceptions       =  " Handling EDBEngineError Exceptions      D                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              Topic   Database                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           {If you want to change the glyphs on TDBNavigator you must create a new
 component which uses a modified resource file.  The steps are :

 1) copy the file DBCtrls.res to MyDBNavigator.res
 2) change the glyphs in your file 
 3) create a new component TMyDBNavigator as follows:}

Unit MyDBNavigator; 

Interface 

Uses 
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms,Dialogs, 
  ExtCtrls, DBCtrls; 

Type 
  TMyDBNavigator = Class(TDBNavigator) 
    Procedure InitMyButtons; 
  Public 
    Constructor Create(AOwner: TComponent); Override; 
  End; 

Procedure Register; 

Implementation 

{$R *.RES} 

Var 
  BtnTypeName: Array[TNavigateBtn] Of PChar = ('FIRST','PRIOR','NEXT','LAST',
                                               'INSERT','DELETE','EDIT',
                                               'POST','CANCEL','REFRESH'); 

Constructor TMyDBNavigator.Create(AOwner: TComponent); 
Begin 
  Inherited Create(AOwner); 
  InitMyButtons; 
End; 

Procedure TMy   Topic   Changing the DBNavigator Glyphs   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   DBNavigator.InitMyButtons; 
Var 
  Index: TNavigateBtn; 
  ResName: String; 
Begin 
  For Index := Low(Buttons) To High(Buttons) Do Begin 
    FmtStr(ResName, 'dbn_%s', [BtnTypeName[Index]]); 
    Buttons[Index].Glyph.LoadFromResourceName(HInstance, ResName); 
  End; 
End; 

Procedure Register; 
Begin 
  RegisterComponents('My Components', [TMyDBNavigator]); 
End; 

End. 

{Code written by Frank}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
{Just surface the Buttons (protected) array of DbNavigator in a derived
 DbNav component}

type
  TMyDbNav = class (TDbNavigator)
  protected
    function  GetNavButtons (i : TNavigateBtn) : TNavButton;
  public
    property NavButtons [i : TNavigateBtn] : TNavButton read GetNavButtons;
  end;

function  TMyDbNav.GetNavButtons (i : TNavigateBtn) : TNavButton;
begin
  Result := Buttons [i];
end;

{To change the glyph of, say the "Last" button}
  MyDBNav1.NavButtons [nbLast].Glyph.LoadFromFile('myglyph.bmp');

{code written by Binh Ly}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   Topic#   Changing the DBNavigator Glyphs (2)   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               {A Data Aware Time Picker Component}

unit uTFDIDateTime;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ComCtrls, dbCtrls, db, ToolWin, Menus,StdCtrls,extctrls;

type
  TFDIDateTime = class(TDateTimePicker)
  private
    FDataLink: TFieldDataLink;
    FFieldName : String;
    function GetDataField: string;
    function GetDataSource: TDataSource;
    function GetField: TField;
    function GetReadOnly: Boolean;
    procedure SetReadOnly(Value: Boolean);
    procedure SetDataField(const Value: string);
    procedure SetDataSource(Value: TDataSource);
    procedure UpdateData(Sender: TObject);
    procedure EditData(Sender: Tobject);
    procedure DataChange(Sender: TObject);
    procedure WMCut(var Message: TMessage); message WM_CUT;
    procedure WMPaste(var Message: TMessage); message WM_PASTE;
  public
    constructor Create( AOwner : TComponent ); override;
    destructor Destroy; override;
    property Field: TField read GetFie   Topic   Data-Aware TDateTimePicker   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ld;
  published
    property DataField: string read GetDataField write SetDataField;
    property DataSource: TDataSource read GetDataSource write SetDataSource;
    property ReadAccess: Boolean read GetReadOnly write SetReadOnly;
    property TabOrder;
  End;

procedure Register;

implementation

constructor TFDIDateTime.Create( AOwner : TComponent );
begin
  inherited;
  FDataLink := TFieldDataLink.Create();
  FDataLink.OnDataChange := DataChange;
  FDataLink.OnUpdateData := UpdateData;
  Self.OnCloseUp := UpdateData;
  Self.OnDropDown := EditData;
  self.OnChange := UpdateData;
End;

destructor TFDIDateTime.Destroy;
Begin
  inherited;
  FDataLink.Free;
  FDataLink := nil;
end;

procedure TFDIDateTime.EditData;
begin
  FDatalink.Edit;
end;

function TFDIDateTime.GetReadOnly: Boolean;
begin
  Result := FDataLink.ReadOnly;
end;

procedure TFDIDateTime.SetReadOnly(Value: Boolean);
begin
  FDataLink.ReadOnly := Value;
end;

function TFDIDateTime.GetDataSource: TDataSource;
begin
  Result := FDataLink.DataSource;
end;

procedure TFDIDateTime.DataChange(Sender: TObject);
begin
  if (FDataLink.Field <> nil) then Begin
    if Self.Kind = dtkDate Then Begin
      If (FDataLink.Field.Value = Null) Then
        self.checked := False
      Else Begin
        self.checked := True;
        self.date := StrToDateTime(FDataLink.Field.Text);
      End;
    End; 
  End;
End;

procedure TFDIDateTime.WMPaste(var Message: TMessage);
begin
  FDataLink.Edit;
end;

procedure TFDIDateTime.WMCut(var Message: TMessage);
begin
  FDataLink.Edit;
end;

procedure TFDIDateTime.SetDataSource(Value: TDataSource);
begin
  FDataLink.DataSource := Value;
  if Value <> nil then 
    Value.FreeNotification(Self);
end;

function TFDIDateTime.GetDataField: string;
begin
  Result := FDataLink.FieldName;
end;

procedure TFDIDateTime.SetDataField(const Value: string);
begin
  FDataLink.FieldName := Value;
end;

function TFDIDateTime.GetField: TField;
begin
  Result := FDataLink.Field;
end;

procedure TFDIDateTime.UpdateData(Sender: TObject);
begin
  FFieldname := self.DataField;
  If (self.Kind = dtkDate) Then
    FDataLink.DataSet.FieldByName(FFieldname).asDateTime := self.Date;
End;

procedure Register;
begin
  RegisterComponents('Stupid Samples', [TFDIDateTime]);
end;

end.

{Code written by Will Wilson}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                {Most data aware components are capable of visually showing that they 
 are disabled (by changing the text color to gray) or enabled (by setting 
 the color to a user-defined windows text color).  Some data aware
 controls such as TDBGrid, TDBRichEdit (in Delphi 3.0) and also TDBEdit 
 (when connected to a numeric or date field) do not display this behavior.

  The code below uses RTTI (Run Time Type Information) to extract
property information and use that information to set the font color to 
gray if the control is disabled. If the control is enabled, the text
color is set to the standard windows text color.
 
  What follows is the step by step creation of a simple example which 
consists of a TForm with a TButton and a TDBRichEdit that
demonstrates this behavior.

  1.  Select File|New Application from the Delphi menu bar.
  2.  Drop a  TDataSource, a TTable, a TButton and a TDBEdit 
      onto the form.
  3.  Set the DatabaseName property of the table to 'DBDEMOS'.
  4.  Set the TableNa   Topic(   Graying Out Disabled Data Aware Controls   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          me property of the table to 'ORDERS.DB'.
  5.  Set the DataSet property of the datasource to 'Table1'.
  6.  Set the DataSource property of the DBEdit to 'DataSource1'.
  7.  Set the DataField property of the DBEdit to 'CustNo'.   
  8.  Set the Active property of the DBEdit to 'False'. 
  9.  Add 'TypInfo' to the uses clause of the form.
 
Below is the actual procedure to put in the implementation
section of your unit:}

// This procedure will either set the text color of a
// dataware control to gray or the user defined color
// constant in clInfoText. 
procedure SetDBControlColor(aControl: TControl);
var
  FontPropInfo: PPropInfo;
begin
  // Check to see if the control is a dataware control
   if (GetPropInfo(aControl.ClassInfo, 'DataSource') <> nil) then begin
     // Extract the front property
     FontPropInfo:= GetPropInfo(aControl.ClassInfo, 'Font');
     // Check if the control is enabled/disabled
     if (aControl.Enabled = false) then
       // If disabled, set the font color to gray
       TFont(GetOrdProp(aControl, FontPropInfo)).Color:= clGrayText
     else
       // If enabled, set the font color to clInfoText
       TFont(GetOrdProp(aControl, FontPropInfo)).Color:= clInfoText;
    end;
end;

{The code for the buttonclick event handler should contain:}

//  This code will cycle through the Controls array and call
//  SetDbControlColor for each control on your form 
//  making sure the font text color is set to what it 
//  should be.

procedure TForm1.Button1Click(Sender: TObject);
var
  i: integer;
begin
  // Loop through the control array
  for i:= 0 to ControlCount-1 do
      SetDBControlColor(Controls[i]);
end;
                                                                                                                                                                                                                                                                                                                                                        {Information that describes the conditions of a database engine error can
be obtained for use by an application through the use of an EDBEngineError
exception. EDBEngineError exceptions are handled in an application through
the use of a try..except construct. When an EDBEngineError exception
occurs, a EDBEngineError object would be created and various fields in that
EDBEngineError object would be used to programmatically determine what
went wrong and thus what needs to be done to correct the situation. Also,
more than one error message may be generated for a given exception. This
requires iterating through the multiple error messages to get needed info-
rmation.

The fields that are most pertinent to this context are:

   ErrorCount: type Integer; indicates the number of errors that are in
     the Errors property; counting begins at zero.

   Errors: type TDBError; a set of record-like structures that contain
     information about each specific error generated; each record is
     accessed   Topic"   Handling EDBEngineError Exceptions   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 via an index number of type Integer.

   Errors.ErrorCode: type DBIResult; indicating the BDE error code for the
     error in the current Errors record.

   Errors.Category: type Byte; category of the error referenced by the
     ErrorCode field.

   Errors.SubCode: type Byte; subcode for the value of ErrorCode.

   Errors.NativeError: type LongInt; remote error code returned from the
     server; if zero, the error is not a server error; SQL statement
     return codes appear in this field.

   Errors.Message: type TMessageStr; if the error is a server error, the
     server message for the error in the current Errors record; if not a
     server error, a BDE error message.

In a try..except construct, the EDBEngineError object is created directly
in the except section of the construct. Once created, fields may be
accessed normally, or the object may be passed to another procedure for
inspection of the errors. Passing the EDBEngineError object to a special-
ized procedure is preferred for an application to make the process more
modular, reducing the amount of repeated code for parsing the object for
error information. Alternately, a custom component could be created to
serve this purpose, providing a set of functionality that is easily trans-
ported across applications. The example below only demonstrates creating
the DBEngineError object, passing it to a procedure, and parsing the
object to extract error information.

In a try..except construct, the DBEngineError can be created with syntax
such as that below}

  procedure TForm1.Button1Click(Sender: TObject);
  var
    i: Integer;
  begin
    if Edit1.Text > ' ' then begin
      Table1.FieldByName('Number').AsInteger := StrToInt(Edit1.Text);
      try
        Table1.Post;
      except on E: EDBEngineError do
        ShowError(E);
      end;
    end;
  end;

{In this procedure, an attempt is made to change the value of a field in a
table and then call the Post method of the corresponding TTable component.
Only the attempt to post the change is being trapped in the try..except
construct. If an EDBEngineError occurs, the except section of the con-
struct is executed, which creates the EDBEngineError object (E) and then
passes it to the procedure ShowError. Note that only an EDBEngineError
exception is being accounted for in this construct. In a real-world sit-
uation, this would likely be accompanied by checking for other types of
exceptions.

The procedure ShowError takes the EDBEngineError, passed as a parameter,
and queries the object for contained errors. In this example, information
about the errors are displayed in a TMemo component. Alternately, the
extracted values may never be displayed, but instead used as the basis for
logic branching so the application can react to the errors. The first step
in doing this is to establish the number of errors that actually occurred.
This is the purpose of the ErrorCount property. This property supplies a
value of type Integer that may be used to build a for loop to iterate
through the errors contained in the object. Once the number of errors
actually contained in the object is known, a loop can be used to visit
each existing error (each represented by an Errors property record) and
extract information about each error to be inserted into the TMemo component}

  procedure TForm1.ShowError(AExc: EDBEngineError);
  var
    i: Integer;
  begin
    Memo1.Lines.Clear;
    Memo1.Lines.Add('Number of errors: ' + IntToStr(AExc.ErrorCount));
    Memo1.Lines.Add('');
    {Iterate through the Errors records}
    for i := 0 to AExc.ErrorCount - 1 do begin
      Memo1.Lines.Add('Message: ' + AExc.Errors[i].Message);
      Memo1.Lines.Add('   Category: ' +
        IntToStr(AExc.Errors[i].Category));
      Memo1.Lines.Add('   Error Code: ' +
        IntToStr(AExc.Errors[i].ErrorCode));
      Memo1.Lines.Add('   SubCode: ' +
        IntToStr(AExc.Errors[i].SubCode));
      Memo1.Lines.Add('   Native Error: ' +
        IntToStr(AExc.Errors[i].NativeError));
      Memo1.Lines.Add('');
    end;
  end;

{Borland TI}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   �R o t a t i n g   a   B i t m a p        f&  �R o t a t i n g   a   B i t m a p        3   �R o t a t i n g   F o n t s     *   0  �R o t a t i n g   F o n t s    +   0   '�L o a d i n g   a   J P G   f r o m   a   P a r a d o x   B l o b   F i e l d     ,     '�L o a d i n g   a   J P G   f r o m   a   P a r a d o x   B l o b   F i e l d    -   I   �F a s t   A c c e s s   t o   C a n v a s   P i x e l s     .     �F a s t   A c c e s s   t o   C a n v a s   P i x e l s    /   >    �C a p t u r i n g   t h e   S c r e e n   t o   a   B i t m a p     0   �   �C a p t u r i n g   t h e   S c r e e n   t o   a   B i t m a p    1   B   (�L o a d i n g   a   B i t m a p - P a l l e t t e   F r o m   R e s o u r c e s     3   �  (�L o a d i n g   a   B i t m a p - P a l l e t t e   F r o m   R e s o u r c e s    4   J   �G a u s i a n   B l u r       o                                                                                                                                               Topic   Graphics                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           unit RotateBitmap;

//  Rotating Bitmaps  (from Martin Lord <martinlord@eurobell.co.uk>)
//
// The code snippet "Rotating a Bitmap" gives a general purpose routine
//  to rotate bitmaps.  The routine takes about 60 millisecs for
//  48x48 bitmaps on a Pentium 120MHz
//
//  Trig formulae have been  simplified using ....
//
//        cos(angle+alpha)=cos(angle)cos(alpha)-sin(angle)sin(alpha),
//        sin(angle+alpha)= etc ,
//        Radius*cos(alpha)=x  and  Radius*sin(alpha)=y
//
// When the same bitmap has to be rotated repeatedly by arbitary angles
// - splitting out the code which fills the X,Y-arrays into a separate
//   initialisation procedure would give a further speed gain
//
// Note that rotating a rectangle can "lose" the corners and this
// procedure uses the topleft pixel to "fill in" the corners.

interface

uses
  Windows, Graphics, Math, SysUtils;

function BmpRotate(var Src, Dst: tbitmap; angle: Extended): Boolean;

implementation

function BmpRotate(var Src, Ds   Topic   Rotating a Bitmap   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 t: tbitmap; angle: Extended): Boolean;
var
  c1x, c1y, c2x, c2y: Integer;
  p1x, p1y, p2x, p2y: Integer;
  j, k, n: Integer;
  sinAngle, cosAngle: Single;
  P, P2: PByteArray;
  X: array of array of Byte;
  Y: array of array of array of Byte; // pf 15,24
  b, bit, mask: Byte;
  top_left1, top_left2, top_left3: Byte;
  ////   The following builds up source pixel arrays for each format
  ////   if you are rotating the same bitmap thru arbitary angles
  ////   making this block a separate procedure called once only
  ////   will give a further speed improvement
  //******************* getpf1bitX *************************
  procedure getpf1bitX;
  var
    nhBytes: Integer;
    p2x, p2y: Integer;
  begin
    SetLength(X, (Src.Width div 8), Src.Height);
    nhBytes := (Src.Width div 8); // Number of bytes to contain Src.width bits
    if (Src.Width mod 8) > 0 then
      Inc(nhBytes);
    for p2y := 0 to Src.Height - 1 do
    begin
      P := Src.Scanline[p2y];
      p2x := 0;
      while p2x < nhBytes do
      begin
        b := p[p2x];
        x[p2x, p2y] := b;
        Inc(p2x);
      end;
    end;
    top_left1 := (X[0, 0] shr 7) shl 7; // Use topleft pixel for points rotated "into" Dst
  end;

  //******************* getpf4bitX *************************
  procedure getpf4bitX;
  var
    p2y: Integer;
  begin
    SetLength(X, Src.Width + 1, Src.Height);
    for p2y := 0 to Src.Height - 1 do
    begin
      P := Src.Scanline[p2y];
      k := 0;
      j := 0;
      while j < Src.Width do
      begin
        b := p[k]; // Unpack pixels (4bits per pixel)
        x[j, p2y] := (b shr 4);
        Inc(j);
        x[j, p2y] := (b and $0F);
        Inc(j);
        Inc(k);
      end;
    end;
    top_left1 := X[0, 0]; // Use topleft pixel for points rotated "into" Dst
  end;

  //******************* getpf8bitX *************************
  procedure getpf8bitX;
  var
    p2y: Integer;
  begin
    SetLength(X, Src.Width, Src.Height);
    for p2y := 0 to Src.Height - 1 do
    begin
      P := Src.Scanline[p2y];
      j := 0;
      while j < Src.Width do
      begin // 1 byte per pixel
        b := p[j];
        x[j, p2y] := b;
        Inc(j);
      end;
    end;
    top_left1 := X[0, 0]; // Use topleft pixel for points rotated "into" Dst

  end;

  //******************* getpf15bitX *************************
  procedure getpf15bitX;
  var
    p2y: Integer;
  begin
    SetLength(Y, 2, Src.Width, Src.Height);
    for p2y := 0 to Src.Height - 1 do
    begin
      P := Src.Scanline[p2y];
      k := 0;
      j := 0;
      while j < Src.Width do
      begin
        b := p[k];
        Y[0, j, p2y] := b;
        b := p[k + 1];
        Y[1, j, p2y] := b;
        Inc(j);
        Inc(k, 2);
      end;
    end;
    top_left1 := Y[0, 0, 0]; // Use topleft pixel for points rotated "into" Dst
    top_left2 := Y[1, 0, 0];
  end;

  //*********** getpf24bitX *************************
  procedure getpf24bitX;
  var
    p2y: Integer;
  begin
    SetLength(Y, 3, Src.Width, Src.Height);
    for p2y := 0 to Src.Height - 1 do
    begin
      P := Src.Scanline[p2y];
      k := 0;
      j := 0;
      while j < Src.Width do
      begin
        b := p[k];
        Y[0, j, p2y] := b;
        b := p[k + 1];
        Y[1, j, p2y] := b;
        b := p[k + 2];
        Y[2, j, p2y] := b;
        Inc(j);
        Inc(k, 3);
      end;
    end;
    top_left1 := Y[0, 0, 0]; // Use topleft pixel for points rotated "into" Dst
    top_left2 := Y[1, 0, 0];
    top_left3 := Y[2, 0, 0];
  end;

begin
  Result := False; // Check pixelformats....
  if (Src.pixelformat <> Dst.pixelformat) then Exit;
  Result := True;
  Dst.Canvas.Pen.Color := clBlack;
  Dst.Canvas.Brush.Color := clBlack;
  Dst.Canvas.FillRect(Dst.Canvas.ClipRect);

  // Angle in radians
  sinAngle := sin(angle);
  cosAngle := cos(angle);

  // Calculate the central points
  c1x := Src.Width div 2;
  c1y := Src.Height div 2;
  c2x := Dst.Width div 2;
  c2y := Dst.Height div 2;

  // Build up pixel arrays (X or Y)
  case Src.pixelformat of
    pf1bit: getpf1bitX;
    pf4bit: getpf4bitX;
    pf8bit: getpf8bitX;
    pf15bit: getpf15bitX;
    pf24bit: getpf24bitX;
  end;

  // Do the rotation
  case Dst.pixelformat of
    //////////////////////////pf1bit////////////////////////
    pf1bit:
      for p2y := 0 to Src.Height - 1 do
      begin
        P2 := Dst.Scanline[p2y];
        for p2x := 0 to Src.Width - 1 do
        begin
          p1x := c1x + round((p2x - c2x) * cosAngle - (p2y - c2y) * sinAngle);
          p1y := c1y + round((p2x - c2x) * sinAngle + (p2y - c2y) * cosAngle);
          if (p1x < 0) or (p1x >= Dst.Width)
            or (p1y >= Dst.Height) or (p1y < 0) then // Point rotated from outside of bitmap - set source bit to top left
            bit := top_left1
          else
          begin // Find the byte for the p1x point
            n := (p1x div 8);
            b := x[n, p1y]; // Contains the required bit
            mask := (1 shl (7 - (p1x mod 8))); // Mask for the source bit
            bit := mask and b; // Get the source bit
            bit := bit shl (((c1x + p1x) mod 8)); // Shift source bit to leftmost
          end;
          n := (p2x div 8);
          b := p2[n]; // Contains  the destination bit
          mask := 1 shl (7 - (p2x mod 8)); // Mask for the destination bit
          b := b and (not mask); // Clear the destination bit
          bit := bit shr ((p2x mod 8)); // Shift the source bit to the destination position
          p2[n] := b or bit; // Set it in the byte
        end;
      end;

    ////////////////////pf4bit/////////////////////////
    pf4bit:
      for p2y := 0 to Dst.Height - 1 do
      begin
        P2 := Dst.Scanline[p2y];
        k := 0;
        p2x := 0;
        while p2x < Dst.Width do
        begin
          // Get the source coords (p1x,p1y)...
          // ....corresponding to destination (p2x,p2y)
          p1y := c1y + round((p2x - c2x) * sinAngle + (p2y - c2y) * cosAngle);
          p1x := c1x + round((p2x - c2x) * cosAngle - (p2y - c2y) * sinAngle);
          if (p1x < 0) or (p1y < 0)
            or (p1x >= Src.Width) or (p1y >= Src.Height) then
            b := top_left1 // Src out of range use top_left
          else
            b := x[p1x, p1y]; // Source pixel
          if (p2x and 1) = 0 then
            p2[k] := Byte(b shl 4) // Pack pixel 4bits into the Dst byte
          else
          begin
            p2[k] := p2[k] or b;
            Inc(k);
          end;
          Inc(p2x);
        end;
      end;

    ///////////////////////pf8bit//////////////
    pf8bit:
      for p2y := 0 to Dst.Height - 1 do
      begin
        P2 := Dst.Scanline[p2y];
        p2x := 0;
        while p2x < Dst.Width do
        begin
          // Get the source coords (p1x,p1y)...
          // ....corresponding to destination (p2x,p2y)
          p1y := c1y + round((p2x - c2x) * sinAngle + (p2y - c2y) * cosAngle);
          p1x := c1x + round((p2x - c2x) * cosAngle - (p2y - c2y) * sinAngle);
          if (p1x < 0) or (p1y < 0)
            or (p1x >= Src.Width) or (p1y >= Src.Height) then
            b := top_left1 // Out of range
          else
            b := x[p1x, p1y]; // Source pixell
          p2[p2x] := b;
          Inc(p2x);
        end;
      end; // pf8bit

    //////////////////////////////////pf15bit,pf24bit
    pf15bit, pf24bit:
      for p2y := 0 to Dst.Height - 1 do
      begin
        P2 := Dst.Scanline[p2y];
        k := 0;
        p2x := 0;
        while p2x < Dst.Width do
        begin
          // Get the source coords (p1x,p1y)...
          // ....corresponding to destination (p2x,p2y)
          p1y := c1y + round((p2x - c2x) * sinAngle + (p2y - c2y) * cosAngle);
          p1x := c1x + round((p2x - c2x) * cosAngle - (p2y - c2y) * sinAngle);
          if (p1x < 0) or (p1y < 0) or (p1x >= Src.Width) or (p1y >= Src.Height) then
          begin // Out of range
            p2[k] := top_left1;
            p2[k + 1] := top_left2;
            Inc(k, 2);
            if Src.pixelformat = pf24bit then
            begin
              p2[k] := top_left3;
              Inc(k);
            end;
          end
          else
          begin
            p2[k] := y[0, p1x, p1y]; // Source pixell
            p2[k + 1] := y[1, p1x, p1y];
            Inc(k, 2);
            if Src.pixelformat = pf24bit then
            begin
              P2[k] := y[2, p1x, p1y];
              Inc(k);
            end
          end;
          Inc(p2x);
        end;
      end;
  end; // case

  Finalize(x);
  Finalize(y);
end;

end.

                                                                                                                                                                                                                                                                                                                                                                                                                          {Rotating fonts is a straight forward process, so long as the Windows font 
 mapper can supply a rotated font based on the font you request. Using a\
 TrueType font virtually guarantees success.
  
 Here is an example of creating a font that is rotated 45 degrees:}

procedure TForm1.Button1Click(Sender: TObject);
var
  lf : TLogFont;
  tf : TFont;
begin
  with Form1.Canvas do begin
    Font.Name := 'Arial';
    Font.Size := 24;
    tf := TFont.Create;
    try
      tf.Assign(Font);
      GetObject(tf.Handle, sizeof(lf), @lf);
      lf.lfEscapement := 450;
      lf.lfOrientation := 450;
      tf.Handle := CreateFontIndirect(lf);
      Font.Assign(tf);
    finally
      tf.Free;
    end;
    TextOut(20, Height div 2, 'Rotated Text!');
  end;
end;

{found on the Borland Forums}
                                                                                                                                                                                                                   Topic   Rotating Fonts   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    {Here's an example that displays a Jpeg image that is stored in
a paradox blob field:}

  procedure LoadJPGFromBlob;
  var
    aJpeg  : TJPEGImage;
    aStream: TMemoryStream;
  begin
    try
      aJpeg   := TJPEGImage.Create;
      aStream := TMemoryStream.Create;
      tabJDataTheData.SaveToStream(aStream);
      aStream.Seek(0,soFromBeginning);
      aJpeg.LoadFromStream(aStream);
      Image2.Picture.Assign(aJpeg);
    finally
      aJpeg.Free;
      aStream.Free;
    end;
  end;

{coded by Bill}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  Topic'   Loading a JPG from a Paradox Blob Field   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           {here is my solution for !Fast! accessing pixels on a bitmap by setting
RGB-Values for each pixel:}

{1) use TBitmap
2) load a 24Bit-Bitmap into it (loadfromfile / loadfromstream)
3) now you can use the scanline-property of D3 to access a whole pixel-line
4) the RGB-Values can be set by a loop:}

    P := Bitmap.Scanline[y];
    x := 0;
    while x <= Bitmap.width*3 -1 do
    begin
      P[x] := 200; //Blue
      P[x+1] := 200; //Green
      P[x+2] := 200; //Red
      inc(x,3)
    end;

{coded by Boris Nienke}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            Topic   Fast Access to Canvas Pixels   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      procedure ScreenShot(x, y, Width, Height: Integer; bm: TBitMap);
var
  dc: HDC;
  lpPal: PLOGPALETTE;
begin
  // Test width and height
  if ((Width <= 0) or (Height <= 0)) then
    Exit;
  bm.Width := Width;
  bm.Height := Height;
  // Get the screen dc
  dc := GetDc(0);
  if (dc = 0) then
    Exit;
  // Do we have a palette device?
  if (GetDeviceCaps(dc, RASTERCAPS) and RC_PALETTE = RC_PALETTE) then
  begin
    // Allocate memory for a logical palette
    GetMem(lpPal, sizeof(TLOGPALETTE) + (255 * sizeof(TPALETTEENTRY)));
    // Zero it out to be neat
    FillChar(lpPal^, sizeof(TLOGPALETTE) + (255 * sizeof(TPALETTEENTRY)), #0);
    // Fill in the palette version
    lpPal^.palVersion := $300;
    // Grab the system palette entries
    lpPal^.palNumEntries :=
        GetSystemPaletteEntries(dc, 0, 256, lpPal^.palPalEntry);
    if (lpPal^.PalNumEntries <> 0) then
      bm.Palette := CreatePalette(lpPal^);
    FreeMem(lpPal, sizeof(TLOGPALETTE) +
      (255 * sizeof(TPALETTEENTRY)   Topic    Capturing the Screen to a Bitmap   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ));
  end;
  // Copy from the screen to the bitmap
  BitBlt(bm.Canvas.Handle, 0, 0, Width, Height, Dc, x, y, SRCCOPY);
  // Release the screen dc
  ReleaseDc(0, dc);
end;

{ Originally from Joe C. Hecht }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        {If 256 color bitmaps are in the resource file, assigning the handle
doesn't assign the palette. Thus, the 256 color bitmaps will end up
dithered. I use the following function to load bitmaps from resource
files}

function LoadBitmapFromResource(inst: THandle;
                                resnum: Word;
                                outBmp: TBitmap): Boolean;
var
  HResInfo: THandle;
  BMF: TBitmapFileHeader;
  MemHandle: THandle;
  Stream: TMemoryStream;
  ResPtr: PByte;
  ResSize: Longint;
begin
  result := false;
  BMF.bfType := $4D42;
  HResInfo := FindResource(inst,MakeIntResource(resnum),RT_Bitmap);
  if hResInfo = 0 then
    exit;
  ResSize := SizeofResource(inst, HResInfo);
  MemHandle := LoadResource(inst, HResinfo);
  if MemHandle = 0 then
    exit;
  try
    ResPtr := LockResource(MemHandle);
    Stream := TMemoryStream.Create;
    try
      Stream.SetSize(ResSize + SizeOf(BMF));
      Stream.Write(BMF, SizeOf(BMF));
      Stream.Write(ResPtr^, ResSize);
      St   Topic(   Loading a Bitmap-Pallette From Resources   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ream.Seek(0, 0);
      outBmp.LoadFromStream(Stream);
      result := true;
    finally
      Stream.Free;
    end;
  finally
    FreeResource(MemHandle);
  end;
end;

{coded by Marc Batchelor}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   Finding out the CPU Speed    8   �   Finding out the CPU Speed   9   ;   " Silently Checking the Floppy Drive    :   G  " Silently Checking the Floppy Drive   ;   D   " Reading the Hard Drive Volume Name    <   �  " Reading the Hard Drive Volume Name   =   D   ! Dialing a Phone Number using TAPI    ?   �  ! Dialing a Phone Number using TAPI   @   C    Detecting Drive Types    B   A   Detecting Drive Types   C   7                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    Topic   Hardware Stuff                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     program CpuSpeed; 

uses SysUtils, Windows, Dialogs;

function GetCpuSpeed: Comp;
var
  t: DWORD;
  mhi, mlo, nhi, nlo: DWORD;
  t0, t1, chi, clo, shr32: Comp;
begin
  shr32 := 65536; 
  shr32 := shr32 * 65536;

  t := GetTickCount; 
  while t = GetTickCount do begin end;
  asm
    DB 0FH
    DB 031H
    mov mhi,edx
    mov mlo,eax
  end;

  while GetTickCount < (t + 1000) do begin end;
  asm
    DB 0FH
    DB 031H
    mov nhi,edx
    mov nlo,eax
  end;

  chi := mhi; if mhi < 0 then chi := chi + shr32;
  clo := mlo; if mlo < 0 then clo := clo + shr32;

  t0 := chi * shr32 + clo;

  chi := nhi; if nhi < 0 then chi := chi + shr32;
  clo := nlo; if nlo < 0 then clo := clo + shr32;

  t1 := chi * shr32 + clo;

  Result := (t1 - t0) / 1E6;
end;

begin
  MessageDlg(Format('%.1f MHz', [GetCpuSpeed]), mtConfirmation, [mbOk], 0);
end.

{coded by Tony Olekshy}
                                                                                                                   Topic   Finding out the CPU Speed   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         {With this method you can check a drive and fail with out
 prompting the user with the BUMB (Big Ugly Message Box)}

var
  ErrorMode : Word;
begin
  ErrorMode := SetErrorMode(SEM_FAILCRITICALERRORS);
  try
    { Check for drive here }
  finally
    SetErrorMode(ErrorMode);
  end;
end;

{coded by Rick Rogers}

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            Topic"   Silently Checking the Floppy Drive   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                

type
  MIDPtr = ^MIDRec;
  MIDRec = Record
    InfoLevel: word;
    SerialNum: LongInt;
    VolLabel: Packed Array [0..10] of Char;
    FileSysType: Packed Array [0..7] of Char;
  end;

var
  Info: MIDRec;

function GetDriveSerialNum(MID: MIDPtr; drive: Word): Boolean; assembler;
asm
  push  DS    { Just for safety, I dont think its really needed }
  mov   ax,440Dh { Function Get Media ID }
  mov   bx,drive    { drive no (0-Default, 1-A ...) }
  mov   cx,0866h  { category and minor code }
  lds   dx,MID      { Load pointeraddr. }
  call  DOS3Call   { Supposed to be faster than INT 21H }
  jc    @@err
  mov   al,1           { No carry so return TRUE }
  jmp   @@ok
 @@err:
  mov   al,0           { Carry set so return FALSE }
 @@ok:
  pop   DS            { Restore DS, were not supposed to change it }
end;

{To read the Serial Number}
function ReadSerial:string;
begin
  if GetDriveSerialNum(@info,0) then 
    Result := IntToStr(info.SerialNum);
end;

{To read the Vol Label}   Topic"   Reading the Hard Drive Volume Name   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
function ReadVol:string;
begin
  if GetDriveSerialNum(@info,0) then 
    Result := StrPas(Info.VolLabel);
end;

{found by Brian}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       {declares for simple tapi}
  TAPIMAXDESTADDRESSSIZE  = 80;
  TAPIMAXAPPNAMESIZE      = 40;
  TAPIMAXCALLEDPARTYSIZE  = 40;
  TAPIMAXCOMMENTSIZE      = 80;

function tapiRequestMakeCall      ; external 'Tapi32.dll';

Function  DialPhone (PhoneNbr, CalledParty, Comment : String) : Boolean;
Var 
  MyPhoneNbr : Pchar;
  MyAppName : Pchar;
  MyCalledParty : Pchar;
  MyComment : Pchar;
Begin
  Result := false;
  If (length(PhoneNbr) > TAPIMAXDESTADDRESSSIZE) or
     (length(CalledParty) > TAPIMAXCALLEDPARTYSIZE) or
     (length(Comment) > TAPIMAXCOMMENTSIZE) then 
    exit;

  myPhoneNbr := StrAlloc(TAPIMAXDESTADDRESSSIZE);
  MyAppName := StrAlloc(TAPIMAXAPPNAMESIZE);
  MyCalledParty := StrAlloc(TAPIMAXCALLEDPARTYSIZE);
  MyComment := StrAlloc(TAPIMAXCOMMENTSIZE);
  try
    StrPCopy(MyPhoneNbr, PhoneNbr);
    StrPCopy(MyCalledParty, CalledParty);
    StrPCopy(MyComment, Comment);
    StrPCopy(MyAppName, 'Whatever');
    Result := tapiRequestMakeCall(MyPhoneNbr, MyAppName, 
             Topic!   Dialing a Phone Number using TAPI   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         MyCalledParty,MyComment) = 0;
  finally
    StrDispose(MyPhoneNbr);
    StrDispose(MyAppName);
    StrDispose(MyCalledParty);
    StrDispose(MyComment);
  end;
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           procedure TForm1.Button1Click(Sender: TObject);
var
  Drive: Char;
  DriveLetter: String[4];
begin
  for Drive := 'A' to 'Z' do
  begin
    DriveLetter := Drive + ':\';
    case GetDriveType(PChar(Drive + ':\')) of
      DRIVE_REMOVABLE:
        Memo1.Lines.Add(DriveLetter + '     Floppy Drive');
      DRIVE_FIXED:
        Memo1.Lines.Add(DriveLetter + '     Fixed Drive');
      DRIVE_REMOTE:
        Memo1.Lines.Add(DriveLetter + '     Network Drive');
      DRIVE_CDROM:
        Memo1.Lines.Add(DriveLetter + '     CD-ROM Drive');
    end;
  end;
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                  Topic   Detecting Drive Types   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             �U s i n g   T y p I n f o   a n d   R T T I     F   W  �U s i n g   T y p I n f o   a n d   R T T I    G   8   �S t a r t i n g   a n   E x t e r n a l   P r o g r a m     H   ?   �S t a r t i n g   a n   E x t e r n a l   P r o g r a m    I   >   �D y n a m i c   A r r a y s     J   �  �D y n a m i c   A r r a y s    K   0   �D i r e c t   M e m o r y   A c c e s s     L   �  �D i r e c t   M e m o r y   A c c e s s    M   6   !�C h e c k i n g   t h e   S t a t e   o f   T o g g l e   K e y s     N   D  !�C h e c k i n g   t h e   S t a t e   o f   T o g g l e   K e y s    O   C   �C l i p p e r   S t y l e   I I F     P   ?  �C l i p p e r   S t y l e   I I F    Q   3   �P a t h   a n d   F i l e n a m e   T r i c k s     R   �  �P a t h   a n d   F i l e n a m e   T r i c k s    S   :   �S t r i n g   M a n i p u l a t i o n s    U   >  �S t r i n g   M a n i p u l a t i o n s    V   %                                                                                              Topic   Straight Pascal                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    {Here is an example of how to access a components published property
 using the published properties name}
 
function  GetSuggestion(AComponent: TComponent;
                        var Caption : string): boolean;
var
  PropInfo : PPropInfo;
begin
  Result := false ;
  Caption := '' ;
  PropInfo := GetPropInfo(AComponent.ClassInfo, 'Caption');
  If ( PropInfo = NIL ) or 
     not ( PropInfo.PropType^.Kind in 
           [ tkString, tkLString, tkWString ] ) then
    exit ;
  Caption := GetStrProp( AComponent, PropInfo ) ;
  Result := true ;
end;

{coded by Mike Scott (TeamB)}                                                                                                                                                                                                                                                                                                                                                                                                                                            Topic   Using TypInfo and RTTI   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            ExecuteFile('C:\WINDOWS\EXPLORER.EXE', '/e, D:\','',SW_SHOW);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    Topic   Starting an External Program   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      {To get a dynamically sized array in pascal, declare a type of that array
at its maximum size.  Then, your array will be a pointer to this type
and you can reallocate how much memory it uses at any time.

For example: }

Type
  PDynamicArray = ^TDynamicArray;
  TDynamicArray = array[0..MaxListSize - 1] of Integer;  
var
  DynamicArray : PDynamicArray;
begin
  GetMem(DynamicArray, (DesiredSize) * SizeOf(Integer));
  //When accessing items in the array, you must first dereference the pointer
  DynamicArray^[0] := 3;
end;
  
{To resize the array you allocate a new array at the new size, then 'move'
 items from the old to the new.  (The easiest way to do this is to use the
 move command}
                                                                                                                                                                                                                                                                                                                          Topic   Dynamic Arrays   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    {How can I (using Delphi 1.0) access memory directly? I have to}
{access an expansion card which read memory $C800 - $C9FF. I}
{understood that accessing this memory under protected mode is
{done via selectors.}

  Device_Selector:=AllocSelector(DSeg);            
  SetSelectorBase(Device_Selector,BaseMem shl 4);   
  SetSelectorLimit(Device_Selector,SizeInBytes); 
  DevicePoint:=Ptr(Device_Selector,0);        

{Code written by Victor}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               Topic   Direct Memory Access   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              {A very simple function that returns the toggle status of key. You pass the
 key (VK_NUMLOCK, VK_INSERT, etc.) and the it returns whether the key is
 toggled on or off.}

function GetToggleState(Key: integer): boolean;
begin
  Result := Odd(GetKeyState(Key));
end;
                        
{donated by Erik Berry}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               Topic!   Checking the State of Toggle Keys   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 function IIF(Condition: Boolean; X, Y: Variant): Variant;

// Note that both variants are fullty evaluated for every call
// to IIF, so it is best to make them quick calculations
function IIF(Condition: Boolean; X, Y: Variant): Variant;
begin
  if Condition then
    Result := X
  else
    Result := Y;
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    Topic   Clipper Style IIF   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 // From Carl Dippel <carl@imcnyc.com>
uses ShellApi;

// Returns the number of backslashes in a path
function BackSlashes(Path: string): Integer;
var
  i: Integer;
begin
  Result := 0;
  for i := 1 to Length(Path) do
    Result := Result + Ord(path[i] = '\');
end;

// Returns true if the path is a network resource i.e. \\machine\resource
function NetResource(path:string):Boolean;
begin
  Result:=(Copy(path,1,2)='\\') and (BackSlashes(path)=3)
end;

function Expand(Path: string): string;
var
  Info: TSHFileInfo;
begin
  Result := ExtractFileDir(Path);    // remove last element if there is one
  if Result = path then              // reached root: recurision is complete
    Delete(Result, Length(Result), 1)// remove that irksome backslash
  else if NetResource(Path) then     // network resources cannot be expanded
    Result := Path                   // recursion is complete
  else if SHGetFileInfo(PChar(Path), 0, Info, SizeOf(Info), SHGFI_DISPLAYNAME) = 1 then
    Result := Expand(R   Topic   Path and Filename Tricks   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          esult) + '\' + Info.szDisplayName // recursively expand the rest
  else
    raise Exception.CreateFmt('%s is not a valid path', [Path])  { woops }
end;

function LongPath(Path: string): string;
{ changes an 8.3 \path\filename like "c:\progra~1\test.doc" }
{ to a long \path\filename like "c:\program files\test.doc" }
begin
  // expand absolute path from possible relative one
  Result := Expand(ExpandFilename(uppercase(path)));
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  String to Enumerated Conversion    W   U   String to Enumerated Conversion   X   A    Fixing capitalization    Y      Fixing capitalization   Z   7   " A Delphi Version of the C sscanf()    [   �  " A Delphi Version of the C sscanf()   \   D    Fast String Scan    a   h   Fast String Scan   b   2                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          Topic   String Manipulations                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               {for enumerated types you can indeed convert between string name and ordinal
 value at runtime using functions from the TypInfo unit.}

theStringname := GetEnumName(Typeinfo(TAlignment),Ord(label1.Alignment));
  
label1.Alignment := TAlignment(GetEnumValue(TypeInfo(TAlignment),theStringname));

{code written by Peter Below (TeamB) }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              Topic   String to Enumerated Conversion   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   {You can switch the delimeters to be punctuation marks if that is more
 appropriate to your needs.}

procedure Recapitalize(var s: String);
var
  delimiter : Boolean;
  i : LongInt;
begin
  delimiter := True;
  for i := 1 to Length(s) do
    if s[i] in [' ', #9, '\'] then
       delimiter := True
    else if delimiter then begin
       if s[i] in ['a'..'z'] then
         s[i] := Chr(Ord(s[i]) - 32);
       delimiter := False;
    end else if s[i] in ['A'..'Z'] then
      s[i] := Chr(Ord(s[i]) + 32);
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  Topic   Fixing capitalization   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             {This code will be commented / cleaned up in the next release

 Sscanf parses an input string. The parameters ...
    s - input string to parse
    fmt - 'C' scanf-like format string to control parsing
      %d - convert a Long Integer
      %f - convert an Extended Float
      %s - convert a string (delimited by spaces)
      other char - increment s pointer past "other char"
      space - does nothing
    Pointers - array of pointers to have values assigned

    result - number of variables actually assigned

    for example with ...
      Sscanf('Name. Bill   Time. 7:32.77   Age. 8',
             '. %s . %d:%f . %d', [@Name, @hrs, @min, @age]);
    an extended has to have a delim beyond the last digit: 32.77;
        otherwise the last digit is stripped

    You get ...
      Name = Bill  hrs = 7  min = 32.77  age = 8                
          
procedure usescan;
var Name: shortstring; hrs, age: longint; min: extended;
  nargs, j: integer;
begin
  nargs := Sscanf('Name. Bill  x T   Topic"   A Delphi Version of the C sscanf()   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                ime. 7:32.775 8.',
    '. %s . %d:%f %d', [@Name, @hrs, @min, @age]);
  if nargs >= 1 then ShowMessage(Format('The name is %s ', [Name]));
  if nargs >= 2 then ShowMessage(Format('the hours are %d ', [hrs]));
  if nargs >= 3 then ShowMessage(Format('the minutes are %.5f ', [min]));
  if nargs >= 4 then ShowMessage(Format(' The age is %d ', [age]));
end;

          }

unit Scanf;

interface
uses 
  SysUtils;

type
  EFormatError = class(ExCeption);
  
function Sscanf(const s: string; const fmt : string;
                const Pointers : array of Pointer) : Integer;

implementation

function Sscanf(const s: string; const fmt : string;
                const Pointers : array of Pointer) : Integer;
var
  i,j,n,m : integer;
  s1 : shortstring;
  L : LongInt;
  X : Extended;

  function GetInt : Integer;
  begin
    s1 := '';
    while (n <= length(s)) and (s[n] = ' ') do 
      inc(n);
    while (n <= length(s)) and (s[n] in ['0'..'9', '+', '-']) do begin
      s1 := s1+s[n];
      inc(n);
    end;
    Result := Length(s1);
  end;

  function GetFloat : Integer;
  begin
    s1 := '';
    while (n <= length(s)) and (s[n] = ' ') do 
      inc(n);
    while (n <= length(s)) and //jd >= rather than >
          (s[n] in ['0'..'9', '+', '-', '.', 'e', 'E']) do begin
      s1 := s1+s[n];
      inc(n);
    end;
    Result := Length(s1);
  end;

  function GetString : Integer;
  begin
    s1 := '';
    while (n <= length(s)) and (s[n] = ' ') do 
      inc(n);
    while (n <= length(s)) and (s[n] <> ' ') do begin
      s1 := s1+s[n];
      inc(n);
    end;
    Result := Length(s1);
  end;

  function ScanStr(c : Char) : Boolean;
  begin
    while (n <= length(s)) and (s[n] <> c) do 
      inc(n);
    inc(n);

    result := (n <= length(s));
  end;

  function GetFmt : Integer;
  begin
    Result := -1;

    while (TRUE) do begin
      while (fmt[m] = ' ') and (Length(fmt) > m) do 
        inc(m);
      if (m >= Length(fmt)) then 
        break;
      if (fmt[m] = '%') then begin
        inc(m);
        case fmt[m] of
          'd': Result := vtInteger;
          'f': Result := vtExtended;
          's': Result := vtString;
        end;
        inc(m);
        break;
      end;
      if (ScanStr(fmt[m]) = False) then 
        break;
      inc(m);
    end;
  end;

begin
  n := 1;
  m := 1;
  Result := 0;

  for i := 0 to High(Pointers) do begin
    j := GetFmt;

    case j of
      vtInteger : begin
        if GetInt > 0 then begin
          L := StrToInt(s1);
          Move(L, Pointers[i]^, SizeOf(LongInt));
          inc(Result);
        end else 
          break;
      end;

      vtExtended : begin
        if GetFloat > 0 then begin
          X := StrToFloat(s1);
          Move(X, Pointers[i]^, SizeOf(Extended));
          inc(Result);
        end else 
          break;
      end;

      vtString : begin
        if GetString > 0 then begin
          Move(s1, Pointers[i]^, Length(s1)+1);
          inc(Result);
        end else 
          break;
      end;
      
      else  {case}
        break;
    end; {case}
  end;
end;

end.
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  {Although StrScan is in Assembler, this is faster, about 40%}

function ScanStr(ToScan: PChar; Sign: Char):PChar;
begin
  Result:= nil;
  if ToScan <> nil then
    while (ToScan^ <> #0) do begin
      if ToScan^ = Sign then begin
        Result:= ToScan;
        break;
       end;
     inc(ToScan);
    end;
end;

{donated by Martin Waldenburg}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           Topic   Fast String Scan   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   Viewing the IDE CPU Window    e   |   Viewing the IDE CPU Window   f   <                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      Topic
   Delphi IDE                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         {Curious as to how Gerald enabled the CPU window in Delphi?  He
 simply addded the following registry string key with a value of '1'
 
HKEY_CURRENT_USER\Software\Borland\Delphi\3.0\Debugging

The CPU window is useful for seeing the assembly equivalents of code,
but was not completely coded by Borland and by default pops up on some
errors when you really don't want it.}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       Topic   Viewing the IDE CPU Window   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         Windows API   i   h   Windows API   j       Shell Stuff   �   &   Shell Stuff   �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     Topic   Windows                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             ScreenSaver Active Check    k   I    ScreenSaver Active Check   l   :   ( Reading the Binary Type of an Executable    m     ( Reading the Binary Type of an Executable   n   J    Intellimouse Specifications    o      Intellimouse Specifications   p   =    Finding Out the Default Browser    t   A   Finding Out the Default Browser   u   A   + Converting Between Long and Short Filenames    v     + Converting Between Long and Short Filenames   w   M    BrowseForFolder Wrapper    y   �   BrowseForFolder Wrapper   z   9    Is a Mouse Present?    ~   �    Is a Mouse Present?      5    Fake the PrintScrn Key    �   �   Fake the PrintScrn Key   �   8    Administrator Rights under NT    �   �   Administrator Rights under NT   �   ?   % Using SetForegroundWindow under Win98    �   �  % Using SetForegroundWindow under Win98   �   G                                                                                                                                                                Topic   Windows API                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        SystemsParametersInfo( SPI_GETSCREENSAVEACTIVE, 0, @aBoolVariable, 0 );
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          Topic   ScreenSaver Active Check   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          {The function call GetBinaryType is in Windows.pas
function GetBinaryType(lpApplicationName: PChar; var lpBinaryType: DWORD): BOOL; stdcall;

Below is an example of how to use it}

Var 
  Filename, S: String;
  BinaryType: DWORD;
begin   
  Filename := 'whatever';
  If GetBinaryType(Pchar(Filename), Binarytype) Then 
    Case BinaryType of
      SCS_32BIT_BINARY: S:= 'Win32 executable';
      SCS_DOS_BINARY  : S:= 'DOS executable';
      SCS_WOW_BINARY  : S:= 'Win16 executable';
      SCS_PIF_BINARY  : S:= 'PIF file';
      SCS_POSIX_BINARY: S:= 'POSIX executable';
      SCS_OS216_BINARY: S:= 'OS/2 16 bit executable'
    Else
      S:= 'unknown executable'
    End
Else
  S:= 'File is not an executable';
end;

{Found on the Borland Forums}                                                                                                                                                                                                                                                              Topic(   Reading the Binary Type of an Executable   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          #if(_WIN32_WINNT >= 0x0400) 
#define WM_MOUSEWHEEL                   0x020A 
#endif 
#if (_WIN32_WINNT < 0x0400) 
#define WM_MOUSELAST                    0x0209 
#else 
#define WM_MOUSELAST                    0x020A 
#endif 
 
#if(_WIN32_WINNT >= 0x0400) 
#define WHEEL_DELTA                     120     /* Value for rolling one detent */ 
#endif
#if(_WIN32_WINNT >= 0x0400) 
#define WHEEL_PAGESCROLL                (UINT_MAX) /* Scroll one page */ 
#endif
 
#define WM_PARENTNOTIFY                 0x0210 
#define MENULOOP_WINDOW                 0 
#define MENULOOP_POPUP                  1 
#define WM_ENTERMENULOOP                0x0211 

#define MOUSEEVENTF_WHEEL       0x0800 /* wheel button rolled */ 


procedure tmditted.applicationonmessage(var Msg: TMsg; var Handled: Boolean);
begin 
  if (msg.message = 52294) and (MDIchildcount > 0) then //Kollar rullknappen pO en microsoft intellimouse
    case msg.wparam of
      -120 : activemdichild.activecontrol.perform (em_linescroll,0,-1);   Topic   Intellimouse Specifications   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
       120 : activemdichild.activecontrol.perform (em_linescroll,0,1);
    end;
end;

(*
WM_MOUSEWHEEL

The WM_MOUSEWHEEL message is sent to the focus window when the mouse wheel is
rotated. The DefWindowProc function propagates the message to the windows parent.
There should be no internal forwarding of the message, since DefWindowProc
propagates it up the parent chain until it finds a window that processes it.

WM_MOUSEWHEEL
fwKeys = LOWORD(wParam);    // key flags
zDelta = (short) HIWORD(wParam);    // wheel rotation
xPos = (short) LOWORD(lParam);    // horizontal position of pointer
yPos = (short) HIWORD(lParam);    // vertical position of pointer

Parameters

fwKeys 
  Value of the low-order word of wParam. Indicates whether various virtual keys
  are down. This parameter can be any combination of the following values:

      Value        Description
      MK_CONTROL   Set if the CTRL key is down.
      MK_LBUTTON   Set if the left mouse button is down.
      MK_MBUTTON   Set if the middle mouse button is down.
      MK_RBUTTON   Set if the right mouse button is down.
      MK_SHIFT     Set if the SHIFT key is down.



zDelta 
     The value of the high-order word of wParam. Indicates the distance that the
     wheel is rotated, expressed in multiples or divisions of WHEEL_DELTA, which is
     120. A positive value indicates that the wheel was rotated forward, away from
     the user; a negative value indicates that the wheel was rotated backward,
     toward the user.
xPos 
     Value of the low-order word of lParam. Specifies the x-coordinate of the pointer,
     relative to the upper-left corner of the screen.
yPos 
     Value of the high-order word of lParam. Specifies the y-coordinate of the pointer,
     relative to the upper-left corner of the screen. 

Remarks

The zDelta parameter will be a multiple of WHEEL_DELTA, which is set at 120. This is
the threshold for action to be taken, and one such action (for example, scrolling one
increment) should occur for each delta.

The delta was set to 120 to allow Microsoft or other vendors to build finer-resolution
wheels in the future, including perhaps a freely-rotating wheel with no notches. The
expectation is that such a device would send more messages per rotation, but with a
smaller value in each message. To support this possibility, you should either add the
incoming delta values until WHEEL_DELTA is reached (so for a given delta-rotation you
get the same response), or scroll partial lines in response to the more frequent
messages. You could also choose your scroll granularity and accumulate deltas until it
is reached.

QuickInfo

  Windows NT: Use version 4.0 and later. Implemented as ANSI and Unicode messages. 
  Header: Declared in winuser.h.
*)                                                                                                                                                                                                                                                          {Finding out the default browser}
 
Function FindClassAssignment(const fname:String):String; 
// turn shell open command for given file name 
var 
  ini : TRegIniFile; 
begin 
  ini := TRegIniFile.Create(''); 
  try 
    ini.RootKey := HKEY_CLASSES_ROOT; 
    ini.OpenKey('',FALSE); 
    Result := ini.readString(ExtractFileExt(Fname),'',''); 
    if result <> '' then begin 
      ini.OpenKey(result+'\shell\open\command',FALSE); 
      Result := ini.readString('','',''); 
    end; 
  finally 
    ini.Free; 
  end; 
end; 
 
{coded by Hector Santos}
 
                                                                                                                                                                                                                                                                                                                                                                                                                                                                  Topic   Finding Out the Default Browser   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   unit LFN_ALT;

interface

// This unit provides two functions that convert
// filenames from the long format to the 8.3
// format, and from the 8.3 format to the long
// format.

function AlternateToLFN(alternateName: String): String;
function LFNToAlternate(LongName: String): String;

implementation

uses Windows;

function AlternateToLFN(alternateName: String): String;
var 
  temp: TWIN32FindData;
  searchHandle: THandle;
begin
  searchHandle := FindFirstFile(PChar(alternateName), temp);
  if searchHandle <> ERROR_INVALID_HANDLE then
    result := String(temp.cFileName)
  else
    result := '';
  Windows.FindClose(searchHandle);
end;

function LFNToAlternate(LongName: String): String;
var 
  temp: TWIN32FindData;
  searchHandle: THandle;
begin
  searchHandle := FindFirstFile(PChar(LongName), temp);
  if searchHandle <> ERROR_INVALID_HANDLE then
    result := String(temp.cALternateFileName)
  else
    result := '';
  Windows.FindClose(searchHandle);
end;

end.

{Fo   Topic+   Converting Between Long and Short Filenames   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       und on the Borland Forums}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      {The following unit wraps the API browse window which has filters for
 Folders, Computers and Printers

Usage would be
  myString := BrowseForFolder('Select something', 
                              [boFolders,boComputers,boPrinters]);


{+------------------------------------------------------------
 | Unit ShBrowse
 |
 | Version: 1.0  Created: 05.09.1997, 12:21:00
 |               Last Modified: 05.09.1997, 12:21:00
 | Author : P. Below
 | Project: Delphi 32 examples
 | Description:
 |   This unit provides a wrapper for the Win95/NT 4.0 
 |   ShBrowseForFolder API function.
 +------------------------------------------------------------}
Unit ShBrowse;

Interface

Type
  TBrowseOption= (boFolders, boComputers, boPrinters );
  TBrowseOptions = Set of TBrowseOption;

Function BrowseForFolder(Const prompt: String; options: TBrowseOptions): String;

Implementation

Uses Windows, SysUtils, Ole2, ShlObj;

Procedure FreePidl( pidl: PItemIDList );
  Var
    allocator: IMalloc;
  B   Topic   BrowseForFolder Wrapper   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           egin
    If Succeeded(SHGetMalloc(allocator)) Then Begin
      allocator.Free(pidl);
      allocator.Release;
    End;
  End;

{+------------------------------------------------------------
 | Function BrowseForFolder
 |
 | Parameters:
 |  prompt : text that should appear above the list of folders
 |  options: defines what should be offered in the list as 
 |           selectable. Other items will appear in the list but
 |           selecting them will not enable the OK button.
 | Returns:
 |  The name of the selected folder, printer etc., if successful,
 |  otherwise an empty string.
 | Call method:
 |  static
 | Description:
 |  This function is a rather thin wrapper around the SHBrowseForFolder
 |  API function. It displays the standard Explorer dialog for 
 |  selecting folders and other stuff.
 | Error Conditions:
 |  Errors will cause the returned string to be empty.
 |
 |Created: 05.09.1997 12:22:49 by P. Below
 +------------------------------------------------------------}
Function BrowseForFolder(Const prompt: String; options: TBrowseOptions):String;
  Const { Translates our options to BIF_ constants. }
    OpValues : Array [TBrowseOption] of UINT =
      ( BIF_RETURNONLYFSDIRS, BIF_BROWSEFORCOMPUTER,BIF_BROWSEFORPRINTER);
  Var
    bi: TBrowseInfo;
    nameBuf: Array [0..MAX_PATH] of Char;
    pidl: pItemIDList;
    index: TBrowseOption;
  Begin
    Result := EmptyStr;
    With bi Do Begin
      hwndOwner:= GetActiveWindow;
      pidlRoot:= Nil;
      pszDisplayName:= @namebuf;
      namebuf[0]:= #0;
      lpszTitle:= PChar( prompt );
      ulFlags:= 0;
      For index := Low(index) To High(index) Do
        If index In options Then
          ulFlags := ulFlags or OpValues[index];
      lpfn:= Nil;
      lParam:= 0;
      iImage:= 0;
    End;
    pidl := ShBrowseForFolder( bi );
    If pidl <> Nil Then Begin
      If SHGetPathFromIDList(pidl, namebuf) Then
        Result := StrPas(namebuf);
      FreePidl( pidl );
    End Else { No idea if this makes sense, probably not <g>. }
      Result := StrPas(bi.pszDisplayName);
  End;

end.

{Code written by Peter Below (TeamB)}


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     // See if a mouse is available on the machine
function IsMouseThere: Boolean;
begin
  Result := (GetSystemMetrics(SM_MOUSEPRESENT) <> 0);
end;

// From Roy Lavers
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         Topic   Is a Mouse Present?   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               // Fake a press of the PrintScrn key
procedure PrintScreen;
begin
  keybd_event(VK_MENU,     MapVirtualkey(VK_MENU, 0 ),   0, 0);
  keybd_event(VK_SNAPSHOT, MapVirtualKey(VK_SNAPSHOT, 0), 0, 0);
  keybd_event(VK_SNAPSHOT, MapVirtualKey(VK_SNAPSHOT, 0), KEYEVENTF_KEYUP, 0);
  keybd_event(VK_MENU,     MapVirtualkey(VK_MENU, 0), KEYEVENTF_KEYUP, 0);
end;

// From Roy Lavers
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   Topic   Fake the PrintScrn Key   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            // Determine whether the current user has admin rights under NT
--------------------------
const
  SECURITY_NT_AUTHORITY: TSIDIdentifierAuthority = (Value: (0, 0, 0, 0, 0, 5));

const
  SECURITY_BUILTIN_DOMAIN_RID = $00000020;
  DOMAIN_ALIAS_RID_ADMINS     = $00000220;

function IsAdmin: Boolean;
var
  hAccessToken: THandle;
  ptgGroups: PTokenGroups;
  dwInfoBufferSize: DWORD;
  psidAdministrators: PSID;
  x: Integer;
  bSuccess: BOOL;
begin
  Result := False;

  bSuccess := OpenThreadToken( GetCurrentThread, TOKEN_QUERY, True, hAccessToken );

  if not bSuccess then
    if ( GetLastError = ERROR_NO_TOKEN ) then
      bSuccess := OpenProcessToken( GetCurrentProcess, TOKEN_QUERY, hAccessToken);

  if bSuccess then
  begin
    GetMem(ptgGroups, 1024);

    bSuccess :=
       GetTokenInformation( hAccessToken,
                            TokenGroups,
                            ptgGroups,
                            1024,
                            dwInfoBufferSize );

       Topic   Administrator Rights under NT   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     CloseHandle(hAccessToken);

    if bSuccess then
    begin
      AllocateAndInitializeSid( SECURITY_NT_AUTHORITY,
                                2,
                                SECURITY_BUILTIN_DOMAIN_RID,
                                DOMAIN_ALIAS_RID_ADMINS,
                                0, 0, 0, 0, 0, 0,
                                psidAdministrators );

      {$R-}
      for x := 0 to ptgGroups.GroupCount - 1 do
        if EqualSid(psidAdministrators, ptgGroups.Groups[x].Sid) then
        begin
          Result := True;
          Break;
        end;
      {$R+}

      FreeSid(psidAdministrators);
    end;

    FreeMem(ptgGroups);
  end;
end;

// From Roy Lavers
                                                                                                                                                                                                                                                                                                                      // WIN98.  Microsoft kindly disabled SetForegroundWindow in Win98.  This is
// a workaround function:
function ForceForegroundWindow(hWnd: THandle): Boolean;
const
     SPI_GETFOREGROUNDLOCKTIMEOUT = $2000;
     SPI_SETFOREGROUNDLOCKTIMEOUT = $2001;
var
   Timeout: DWORD;
begin
  if (( Win32Platform = VER_PLATFORM_WIN32_NT) and (Win32MajorVersion > 4 )) or
      ((Win32Platform =VER_PLATFORM_WIN32_WINDOWS) and ((Win32MajorVersion > 4 ) or
      ((Win32MajorVersion = 4) and (Win32MinorVersion > 0)))) then
  begin
    SystemParametersInfo(SPI_GETFOREGROUNDLOCKTIMEOUT, 0, @Timeout, 0);
    SystemParametersInfo(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, TObject(0), SPIF_SENDCHANGE);
    Result := SetForegroundWindow(hWnd);
    SystemParametersInfo(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, TObject(Timeout), SPIF_SENDCHANGE);
  end
  else
    Result := SetForegroundWindow(hWnd);
end;

// From Roy Lavers (from a newsgroup posting)
                                                                                     Topic%   Using SetForegroundWindow under Win98   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              Getting the TaskBar Handle    �   v    Getting the TaskBar Handle   �   <   " Seperate Taskbar Buttons for Forms    �   w  " Seperate Taskbar Buttons for Forms   �   D    Hiding a Form from the TaskBar    �   �   Hiding a Form from the TaskBar   �   @    Hide or Show the TaskBar    �   �   Hide or Show the TaskBar   �   :   $ Using Windows95 Shell File Functions    �   �  $ Using Windows95 Shell File Functions   �   F   ' Getting File Information from the Shell    �   �  ' Getting File Information from the Shell   �   I   ! Deleting Files to the Recycle Bin    �   l  ! Deleting Files to the Recycle Bin   �   C     Creating and Resolving Shortcuts    �   M    Creating and Resolving Shortcuts   �   B    Creating Desktop Icons    �   �
   Creating Desktop Icons   �   8                                                                                                                                                                                                                                  Topic   Shell Stuff                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        {How to obtain Windows Taskbar handle}

  hTaskbar := FindWindow('Shell_TrayWnd', Nil ); 

{Peter Below (TeamB)}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             Topic   Getting the TaskBar Handle   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        {To show other forms of a project in the Windows task bar try overriding
 the following method to each form you want visible :}

Procedure TForm1.CreateParams(Var params: TCreateParams );
Begin
  inherited;
  Params.WndParent := GetDesktopWindow;
  params.exstyle := params.exstyle and not WS_EX_TOOLWINDOW or WS_EX_APPWINDOW;
end;

{coded by Peter Below (TeamB)}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            Topic"   Seperate Taskbar Buttons for Forms   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                {To hide a form from showing up in the Win 95 task bar

Make your DPR look like this --}

program TrayProj;

uses
  Forms,
  ...
  
{$R *.RES}

begin
  Application.ShowMainForm := False;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.

{and/or your Main form's FormCreate look like this --}

procedure TForm1.FormCreate(Sender: TObject);
begin
  ShowWindow( Application.Handle, SW_HIDE );
  SetWindowLong( Application.Handle, GWL_EXSTYLE,
                 GetWindowLong(Application.Handle, GWL_EXSTYLE) or
                 WS_EX_TOOLWINDOW and not WS_EX_APPWINDOW);
  ShowWindow( Application.Handle, SW_SHOW );
end;

{both may be redundant, but it gets the job done}

{Found on the borland forums}                                                                                                                                                                                                                                                                                          Topic   Hiding a Form from the TaskBar   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    {To hide or show the Windows 95 taskbar programmatically from your Delphi
 application call one of these functions}

procedure hideTaskbar; 
var 
  wndHandle : THandle; 
  wndClass : array[0..50] of Char; 
begin 
  StrPCopy(@wndClass[0], 'Shell_TrayWnd'); 
  wndHandle := FindWindow(@wndClass[0], nil); 
  ShowWindow(wndHandle, SW_HIDE); // This hides the taskbar 
end; 

procedure showTaskbar; 
var
  wndHandle : THandle; 
  wndClass : array[0..50] of Char; 
begin 
 StrPCopy(@wndClass[0], 'Shell_TrayWnd'); 
 wndHandle := FindWindow(@wndClass[0], nil); 
 ShowWindow(wndHandle, SW_RESTORE); // This restores the taskbar 
end;
                                                                                                                                                                                                                                                                                                                                                                                          Topic   Hide or Show the TaskBar   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          uses shellapi; // don't forget

procedure shelloperate (a:integer;b,c:tstrings); // does the a-specified shell-file-operation
{ a can be fo_move, fo_delete, fo_copy or fo_rename
  b are the source-filenames
  c are the destination-filenames}
var 
  shfileopstruct : tshfileopstruct;
  fname,dest : string;
  ct : integer;
begin
  // let us create the source-filename
  // all filenames in one string, divided by a #0 and on the end another #0, too
  fname := '';
  if b.count > 0 then 
    for ct := 0 to pred(b.count) do 
      fname := fname+b[ct]+#0;
  fname := fname+#0;

  // get the destination filenasme
  dest := getcurrentdir; // default
  if a= fo_rename then 
    dest:=inputbox ('rename file','enter new filename',fname);

  fillchar(shfileopstruct,sizeof(tshfileopstruct),0);
  with shfileopstruct do begin
    wnd      := form1.handle;      // set this to the calling window's handle
    wfunc    := a;                 // here set the desired shell-function
    pfrom    := pchar(fn   Topic$   Using Windows95 Shell File Functions   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ame);      // these are the source-filenames
    pto      := pchar(dest); // destination
    //fflags     // these are flags for the shelloperation (look to the help)
    //fanyoperationsaborted   // is true if user cancelled the operation
    //hnamemappings    // filemapping-pointer
    //lpszprogresstitle       // if no dialog-boxes (fflags) then show this string (?)
  end;

  // and now do the operation
  shfileoperation(shfileopstruct);
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  {How to receive shell information about a file}

uses shellapi; //that unit is necessary

procedure getshellinfo(a:tfilename;var name,typ:string;var icon:ticon;var attr:integer);
var 
  info : tshfileinfo;
begin
     // get shell-info about the specified file (in "a")
     {parameters :
          name : receives the explorer-style filename (e.g. without extension)
          typ  : receives the explorer-style typename of the file (e.g. "anwendung" for an exe in german win95)
          icon : will content the icon which is shown in the explorer for that file (this is slower than extracticon !!!!)
          attr : gets the explorer-attributes of the file, these are (ripped from win32-help):
               sfgao_cancopy the specified file objects or folders can be copied (same value as the dropeffect_copy flag).
               sfgao_candelete the specified file objects or folders can be deleted.
               sfgao_canlink it is possible to create shortcuts for the specified file objects or folde   Topic'   Getting File Information from the Shell   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           rs (same value as the dropeffect_link flag).
               sfgao_canmove the specified file objects or folders can be moved (same value as the dropeffect_move flag).
               sfgao_canrename the specified file objects or folders can be renamed.
               sfgao_capabilitymask mask for the capability flags.
               sfgao_droptarget the specified file objects or folders are drop targets.
               sfgao_haspropsheet the specified file objects or folders have property sheets.

               a file object's display attributes may include zero or more of the following values:

               sfgao_displayattrmask mask for the display attributes.
               sfgao_ghosted the specified file objects or folders should be displayed using a ghosted icon.
               sfgao_link the specified file objects are shortcuts.
               sfgao_readonly the specified file objects or folders are read-only.
               sfgao_share the specified folders are shared.

               a file object's contents flags may include zero or more of the following values:

               sfgao_contentsmask mask for the contents attributes.
               sfgao_hassubfolder the specified folders have subfolders (and are, therefore, expandable in the left pane of windows explorer).

               a file object may have zero or more of the following miscellaneous attributes:

               sfgao_filesystem the specified folders or file objects are part of the file system (that is, they are files, directories, or root directories).
               sfgao_filesysancestor the specified folders contain one or more file system folders.
               sfgao_folder the specified items are folders.
               sfgao_removable the specified file objects or folders are on removable media.
               sfgao_validate validate cached information.}


     fillchar(info,sizeof(tshfileinfo),0);
     shgetfileinfo(pchar(a),0,info,sizeof(info),shgfi_displayname or shgfi_typename or
     shgfi_icon or shgfi_attributes);
     with info do begin
          name := szdisplayname;
          typ  := sztypename;
          icon.handle := hicon;
          attr        := dwattributes;
     end;
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  {example of use
   ToRecycle('c:\Yow.txt', Handle);}

uses ShellAPI;

procedure ToRecycle(aFileName: String; hnd: THandle);
var
  SHF: TSHFileOpStruct;
begin
  with SHF do begin
    Wnd := Hnd;
    wFunc := FO_DELETE;
    pFrom := PChar(aFileName);
    fFlags := FOF_ALLOWUNDO;
  end;
  SHFileOperation(SHF);
end;

{by Xavier Pacheco (TeamB)}

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       Topic!   Deleting Files to the Recycle Bin   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 (*The CreateLink function in the following example creates a shortcut.
The parameters include a pointer to the name of the file to link to,
a pointer to the name of the shortcut that you are creating, and a

pointer to the description of the link. The description consists of
the string, "Shortcut to filename," where filename is the name of the
file to link to.

Because CreateLink calls the CoCreateInstance function, it is assumed
that the CoInitialize function has already been called. CreateLink
uses the IPersistFile interface to save the shortcut and the IShellLink
interface to store the filename and description.

 CreateLink - uses the shell's IShellLink and IPersistFile interfaces
 to create and store a shortcut to the specified object.  Returns the
 result of calling the member functions of the interfaces.

 lpszPathObj  - address of a buffer containing the path of the object
 lpszPathLink - address of a buffer containing the path where the
                shell link is to be stored
 l   Topic    Creating and Resolving Shortcuts   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  pszDesc     - address of a buffer containing the description of the
                shell link*)

unit ShellUtl;

interface

uses Windows,Ole2;

function CreateLink(lpszPathObj,lpszPathLink,lpszDesc:String):HResult;
function ResolveIt(Wnd:HWND; lpszLinkFile:String):String;

implementation

uses SysUtils, ShellAPI, ShellObj;

function CreateLink(lpszPathObj,lpszPathLink,lpszDesc:string):HResult;

var
  hRes: HRESULT;
  psl: IShellLink;
  ppf: IPersistFile;
  wsz: PWideChar;

begin
    GetMem(wsz,MAX_PATH*2);
    try
    { Get a pointer to the IShellLink interface. }
    hres := CoCreateInstance(CLSID_ShellLink, nil,
                            CLSCTX_INPROC_SERVER, IID_IShellLink, psl);
    if SUCCEEDED(hres) then
       begin
       { Set the path to the shortcut target, and add the description.  }
       psl.SetPath(@lpszPathObj[1]);
       psl.SetDescription(@lpszDesc[1]);

       { Query IShellLink for the IPersistFile interface for saving the 
         shortcut in persistent storage. }
       if SUCCEEDED(psl.QueryInterface(IID_IPersistFile,ppf)) then
         begin
         { Ensure that the string is ANSI. }
         MultiByteToWideChar(CP_ACP, 0, @lpszPathLink[1],-1,wsz,MAX_PATH);
         { Save the link by calling IPersistFile::Save. }
         hres := ppf.Save(wsz,TRUE);
         ppf.Release;
         end;
       psl.Release;

       end;
    Result := hres;
 finally
    FreeMem(wsz,MAX_PATH*2);
    end;
end;


function ResolveIt(Wnd:HWND; lpszLinkFile:String):String;
var
  hres:HRESULT;
  psl:IShellLink;
  szGotPath: array[0..MAX_PATH-1] of char;
  szDescription: array[0..MAX_PATH-1] of char;
  wfd: TWin32FindData;
  ppf: IPersistFile;
  wsz: array[0..MAX_PATH-1] of WideChar;

begin
  Result := ''; { assume failure  }
  { Get a pointer to the IShellLink interface. }
  hres := CoCreateInstance(CLSID_ShellLink, nil,
          CLSCTX_INPROC_SERVER, IID_IShellLink, psl);
  if (SUCCEEDED(hres)) then begin
    { Get a pointer to the IPersistFile interface. }
    hres := psl.QueryInterface(IID_IPersistFile,ppf);
    if (SUCCEEDED(hres)) then begin
      { Ensure that the string is Unicode. }
      MultiByteToWideChar(CP_ACP, 0, @lpszLinkFile[1], -1, wsz, MAX_PATH);
      { Load the shortcut. }
      hres := ppf.Load(wsz, STGM_READ);
      if (SUCCEEDED(hres)) then begin
        { Resolve the link. }
        hres := psl.Resolve(wnd,SLR_ANY_MATCH);
        if (SUCCEEDED(hres)) then begin
          { Get the path to the link target. }
          hres := psl.GetPath(szGotPath,MAX_PATH,wfd,SLGP_SHORTPATH);
          if not SUCCEEDED(hres) then 
            exit;
          { Get the description of the target. }
          hres := psl.GetDescription(szDescription, MAX_PATH);
          if not SUCCEEDED(hres) then 
            exit;
          Result := StrPas(szGotPath)+'|'+StrPas(szDescription);
        end;
      end;
      { Release the pointer to the IPersistFile interface. }
      ppf.Release;
    end;
    { Release the pointer to the IShellLink interface. }
    psl.Release;
  end;
end;

end.
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   {how to create an Icon for an application on a Windows desktop}

Yep try this code... Hope this helps...

Uses
{$IFDEF  VER90} OleAuto, {$ENDIF}
{$IFDEF VER100} ComObj,{$ENDIF}
  ShlObj; //ShellCom in early versions of Delphi

{----------------------------------------------------------------------------
  _SHORTCUTS_
  Create a Windows Shortcut
----------------------------------------------------------------------------}
procedure _CreateShellLink(sDesc,sLinkToFilename,sStartIn,sArguments,
                           sIconPath,sLinkName: String;
                           iIconIndex: Integer);
var
  sl:  IShellLink;
  ppf: IPersistFile;
  wcLinkName: array[0..Max_Path] of WideChar;
begin
  OleCheck(CoInitialize(Nil));
  OleCheck(
{$IFDEF VER90}  CoCreateInstance(OLE2.TGUID(CLSID_ShellLink), nil,
            CLSCTX_INPROC_SERVER, OLE2.TGUID(IID_IShellLink), sl)); {$ENDIF}
{$IFDEF VER100} CoCreateInstance(OLE2.TGUID(CLSID_ShellLink), nil,
            CLSCTX_INPROC_SERVER, OLE2.TGUID(IID   Topic   Creating Desktop Icons   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            _IShellLinkA), sl));{$ENDIF}
  OleCheck(
{$IFDEF VER90}  sl.QueryInterface(OLE2.TGUID(IID_IPersistFile), ppf));{$ENDIF}
{$IFDEF VER100}  sl.QueryInterface(System.TGUID(IID_IPersistFile), ppf));{$ENDIF}
  OleCheck(sl.SetDescription(PChar(sDesc)));
  OleCheck(sl.SetPath(PChar(sLinkToFilename)));
  OleCheck(sl.SetWorkingDirectory(PChar(sStartIn)));
  OleCheck(sl.SetArguments(PChar(sArguments)));
  OleCheck(sl.SetIconLocation(PChar(sIconPath), iIconIndex));
  MultiByteToWideChar(CP_ACP, 0, PChar(sLinkName), -1, wcLinkName, MAX_PATH);
  OleCheck(ppf.Save(wcLinkName, true));
  CoUninitialize;
end; {_CreateShellLink}


procedure GetFolderPath(var sPath: String; iFolder: Integer);
var
  iID: PItemIDList;
  szPath: PChar;
begin
  sPath := '';  //error
  szPath := StrAlloc( MAX_PATH );
  if SHGetSpecialFolderLocation(Application.handle, iFolder, iID) = NOERROR
then
  begin
    SHgetPathFromIDList(iID, szPath);
    sPath := szPath;
  end
end;

{
  Call this to create a file shortcut (ShellLink)
    filename: Full path to file to link to
    Location: see help on SHGetSpecialFolderLocation()
      CSIDL_DESKTOP, CSIDL_PROGRAMS, CSIDL_STARTMENU
  filename: Target Filename to Link to
  LinkName: Name that will appear under the link icon eg. 'Shortcut to XXXX'
  Arguments: Command line auguments
}
procedure CreateShellLink(filename, LinkName, Arguments: String;  Location:
Word);
var sDesktopPath, sLinkPath: String;
begin
  GetFolderPath(sDesktopPath, Location);
  sLinkPath := sDesktopPath + '\' + LinkName + '.lnk';
  _CreateShellLink('', filename, ExtractFilePath(filename), Arguments, filename, sLinkPath, 0);
end;
                                                                                                                                                                                                                                                                                                                                                                                      �C o m p o n e n t   E n h a n c e m e n t s    �   R	  �C o m p o n e n t   E n h a n c e m e n t s    �   '   �F o r m   L e v e l   S t u f f    �   J  �F o r m   L e v e l   S t u f f    �   !   �V i r t u a l T r e e V i e w    	  <                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         Topic   VCL                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                �T r e e   S t r u c t u r e   t o   T e x t     �   �  �T r e e   S t r u c t u r e   t o   T e x t    �   8   �T o o l T i p   F o n t   H i n t   P r o p e r t i e s     �   I  �T o o l T i p   F o n t   H i n t   P r o p e r t i e s    �   >   �D r a g g i n g   C o n t r o l s   a t   R u n t i m e     �   L  �D r a g g i n g   C o n t r o l s   a t   R u n t i m e    �   >   �T r a n s p a r e n t   C a n v a s   T e x t     �     �T r a n s p a r e n t   C a n v a s   T e x t    �   9   %�S t o r i n g   C o m p o n e n t   S t a t e s   t o   I N I   F i l e s     �   f  %�S t o r i n g   C o m p o n e n t   S t a t e s   t o   I N I   F i l e s    �   G   "�L i s t v i e w   S o r t i n g   v i a   C o l u m n   C l i c k s     �   �  "�L i s t v i e w   S o r t i n g   v i a   C o l u m n   C l i c k s    �   D   �M e m o   P r i n t i n g     �   <  �M e m o   P r i n t i n g    �   /   �R i c h E d i t   F l i c k e r   R e d u c t i o n     �   �   �R i c h E d i t   F    Topic   Component Enhancements                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             unit Tree2Text;

interface

uses Classes, ComCtrls, Outline;

{
  Generic tree to text conversion. Use non-proportional font (ie. Terminal,
  for IBM character set).

  Supplied, for you convenience, with TreeView and Outline functions (which
  also act as examples for adapting to your own favourite tree component).

  Can be fitted out to other trees by deriving five method node wrapper
  from TttTreeNode (see below).

  Componentising what should boil down to a single procedure call, would be
  overkill.

  Version .1 - Feb 2000

  Written by Greg Lorriman <greg@lorriman.demon.co.uk> in feb 2000
}

type
  TttEnumCharacterSet = (csDownLine, csSiblingJoin, csEndPoint);
  TttCharacterSet = array[Low(TttEnumCharacterSet)..High(TttEnumCharacterSet)] of string;

 // Node wrapper: Do not free real node in your implementation.
 // Create a private field to hold ref to real node
 // and write appropriate constructor. Create in "get" methods.
 // See supplied examples for TTreeNode and    Topic   Tree Structure to Text   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            TOutlineNode
  TttTreeNode = class
  public
    function HasNextSibling: Boolean; virtual; abstract;
    function GetNextSibling: TttTreeNode; virtual; abstract;
    function HasChildren: Boolean; virtual; abstract;
    function GetFirstChild: TttTreeNode; virtual; abstract;
    function GetText: string; virtual; abstract;
  end;

// Generic - you can call this via a wrapper class, see examples below
procedure Tree2Strings(Node: TttTreeNode; Strings: TStrings; charSet: TttCharacterSet);

procedure Tree2StringsTreeView(Node: TTreeNode; Strings: TStrings; CharSet: TttCharacterSet);

// Due to TOutlineNode limitations TOutline object also needs to be supplied
procedure Tree2StringsOutline(Node: TOutlineNode; Outline: TOutline; Strings: TStrings; CharSet: TttCharacterSet);

// This lot aids code-insight as well as source readability.
// Switch between character sets, or supply your own.
// These include spacing (#32) as it seems to look better.
const
  IBMcharset: TttCharacterSet = (#179#32, #195#32, #192#32);
  ASCIIcharset1: TttCharacterSet = ('| ', '\- ', '\- ');
  ASCIIcharset2: TttCharacterSet = ('| ', '\_ ', '\_ ');
  ASCIIcharset3: TttCharacterSet = ('| ', '+ ', '- ');

implementation

type
  TTreeViewNode = class(TttTreeNode)
  private
    FNode: TTreeNode;
  public
    constructor Create(Node: TTreeNode);
    function HasNextSibling: Boolean; override;
    function GetNextSibling: TttTreeNode; override;
    function HasChildren: Boolean; override;
    function GetFirstChild: TttTreeNode; override;
    function GetText: string; override;
  end;

  TOutlineTreeNode = class(TttTreeNode)
  private
    FNode: TOutlineNode;
    FOutline: TOutline;
  public
    constructor Create(Outline: TOutline; Node: TOutlineNode);
    function HasNextSibling: Boolean; override;
    function GetNextSibling: TttTreeNode; override;
    function HasChildren: Boolean; override;
    function GetFirstChild: TttTreeNode; override;
    function GetText: string; override;
  end;

procedure tree2stringsTreeView(Node: TTreeNode; Strings: TStrings; CharSet: TttCharacterSet);
begin
  Tree2Strings(TTreeViewNode.Create(Node), Strings, CharSet);
end;

procedure tree2StringsOutline(Node: TOutlineNode; Outline: TOutline; Strings: TStrings; charSet: TttCharacterSet);
begin
  Tree2Strings(TOutlineTreeNode.Create(Outline, Node), Strings, CharSet);
end;

procedure Tree2StringsRecurse(Node: TttTreeNode; Strings: TStrings; CharSet: TttCharacterSet; NodesToDo: Tlist; Depth: Integer); forward;

procedure PrintTreeLevel(Node: TttTreeNode; Strings: TStrings; CharSet: TttCharacterSet; NodesToDo: Tlist; Depth: Integer);
var
  s, str: string;
  i: Integer;
begin
  for i := 0 to Depth - 1 do
  begin
    if NodesToDo[i] <> nil then
      s := CharSet[csDownline]
    else
      s := #32;
    str := str + s;
  end;
  if Node.HasNextSibling then
    str := str + CharSet[csSiblingJoin] + Node.GetText
  else
    str := str + CharSet[csEndPoint] + Node.GetText;
  Strings.Add(str);
end;

procedure updateToDoList(Node: TttTreeNode; nodesToDo: Tlist; depth: Integer);
begin
  NodesToDo.Count := Depth + 1;
  if Node.HasNextSibling then
    NodesToDo[Depth] := Pointer(1)
  else
    NodesToDo[Depth] := nil;
end;

// Contortion in here (sibling) needed to support auto-release of node wrappers
procedure RecurseChildren(Node: TttTreeNode; Strings: TStrings; CharSet: TttCharacterSet; nodesToDo: Tlist; depth: Integer);
var
  Child, Sibling: TttTreeNode;
  i: Integer;
begin
  if Node.HasChildren then
  begin
    Child := Node.GetFirstChild;
    repeat
      if Child.HasNextSibling then
        Sibling := Child.GetNextSibling
      else
        Sibling := nil;
      Tree2StringsRecurse(Child, Strings, CharSet, NodesToDo, Depth + 1);
      Child := Sibling;
    until Child = nil;
  end;
end;

procedure tree2stringsRecurse(Node: TttTreeNode; Strings: TStrings; charSet: TttCharacterSet; nodesToDo: Tlist; depth: Integer);
begin
  PrintTreeLevel(Node, Strings, CharSet, NodesToDo, Depth);
  UpDateToDoList(Node, NodesToDo, Depth);
  RecurseChildren(Node, Strings, CharSet, NodesToDo, Depth);
   // Freeing the wrapper, not the real node.
  Node.Free;
end;

procedure tree2strings(Node: TttTreeNode; Strings: TStrings; CharSet: TttCharacterSet);
var
  NodesToDo: TList;
begin
  NodesToDo := TList.Create;
  try
    NodesTodo.Count := 0;
    Tree2StringsRecurse(Node, Strings, CharSet, NodesToDo, 0);
  finally
    NodesToDo.Free;
  end;
end;

{ TTreeViewNode }

constructor TTreeViewNode.Create(Node: TTreeNode);
begin
  FNode := Node;
end;

function TTreeViewNode.getFirstChild: TttTreeNode;
begin
  Result := TTreeViewNode.Create(FNode.GetFirstChild);
end;

function TTreeViewNode.getNextSibling: TttTreeNode;
begin
  Result := TTreeViewNode.Create(FNode.GetNextSibling);
end;

function TTreeViewNode.GetText: string;
begin
  Result := FNode.Text;
end;

function TTreeViewNode.HasChildren: Boolean;
begin
  Result := FNode.HasChildren;
end;

function TTreeViewNode.HasNextSibling: Boolean;
begin
  Result := FNode.GetNextsibling <> nil;
end;

{ TOutlineTreeNode }

constructor TOutlineTreeNode.Create(Outline: TOutline; Node: TOutlineNode);
begin
  FNode := Node;
  FOutline := Outline;
end;

function TOutlineTreeNode.GetFirstChild: TttTreeNode;
begin
  Result := TOutlineTreeNode.Create(FOutline, FOutline.Items[Fnode.getFirstChild]);
end;

function TOutlineTreeNode.GetNextSibling: TttTreeNode;
begin
  Result := TOutlineTreeNode.Create(FOutline, FOutline.Items[Fnode.Parent.getNextChild(Fnode.Index)]);
end;

function TOutlineTreeNode.GetText: string;
begin
  Result := FNode.Text;
end;

function TOutlineTreeNode.HasChildren: Boolean;
begin
  Result := FNode.HasItems;
end;

function TOutlineTreeNode.HasNextSibling: Boolean;
begin
  if FNode.Parent = nil then
    Result := False
  else
    Result := Fnode.Parent.GetNextChild(Fnode.Index) <> -1;
end;

end.

                                                                     {Why Borland did not make the hintwindow font public is one of the great 
 mysteries of all time.}

Type
  TMyHintWindow = Class (THintWindow)
    Constructor Create (AOwner: TComponent); override;
  end;

Constructor TMyHintWindow.Create (AOwner: TComponent); 
begin
  Inherited Create (AOwner);
  Canvas.Font.Name := 'Courier New';
  Canvas.Font.Size := 72;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Application.ShowHint := false;
  HintWindowClass := TMyHintWindow;
  Application.ShowHint := True;
end;

{written by Scott Samet / TeamB}


                                                                                                                                                                                                                                                                                                                                                                                                                                                          Topic   ToolTip Font Hint Properties   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      {Here is a way to set up a form to support dragging components around
 on it at run time.  Each control that you want to move in this fashion
 should have its mouse down, mouse move, and mouse up events set to
 ControlMouseDown, ControlMouseMove and ControlMouseUp, respectively}

unit DragAroundControlsExample;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms,Dialogs,
  StdCtrls, ExtCtrls, ComCtrls, DBTables, DB;

type
  TForm1 = class(TForm)
    procedure ControlMouseDown(Sender: TObject; Button: TMouseButton;
                               Shift: TShiftState; X, Y: Integer);
    procedure ControlMouseMove(Sender: TObject; Shift: TShiftState; 
                               X,Y: Integer);
    procedure ControlMouseUp(Sender: TObject; Button: TMouseButton;
                             Shift: TShiftState; X, Y: Integer);
  private
    { Private declarations }
    downX, downY: Integer;
    dragging: Boolean;
  public
    { Public declarations }
  end   Topic   Dragging Controls at Runtime   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ;

var
  Form1: TForm1;

implementation

{$R *.DFM}

Type
  TCracker = Class(TControl);
  { Needed since TControl.MouseCapture is protected 
    by declaring a descendant class we can typecast the control
    to this and access its protected methods with in this unit.}

{ Control event handlers are attached to both memo and image mouse
  events. }
procedure TForm1.ControlMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  downX:= X;
  downY:= Y;
  dragging := True;
  TCracker(Sender).MouseCapture := True;
end;

procedure TForm1.ControlMouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  If dragging Then with Sender As TControl Do Begin
    Left := X-downX+Left;
    Top  := Y-downY+Top;
  End;
end;

procedure TForm1.ControlMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  If dragging then Begin
    dragging := False;
    TCracker(Sender).MouseCapture := False;
  End;
end;

initialization
end.


{code written by Peter Below (TeamB)}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    {The following snippet has text drawn as opaque and transparent}

procedure TForm1.Button1Click(Sender: TObject);
var
  OldBkMode : integer;
begin
  with Form1.Canvas do begin
    Brush.Color := clRed;
    FillRect(Rect(0, 0, 100, 100));
    Brush.Color := clBlue;
    TextOut(10, 20, 'Not Transparent!');
    OldBkMode := SetBkMode(Handle, TRANSPARENT); // returns what bkmode was
    TextOut(10, 50, 'Transparent!');
    SetBkMode(Handle, OldBkMode); // restores what bkmode was
  end;
end;

{Code written by Joe C. Hecht}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      Topic   Transparent Canvas Text   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           {**************************************************************
 *  TExtIniF extends Delphi's TIniFile to simplify saving a   *
 *  components state to an INI-File. After creation you can   *
 *  register any number of components and save and retrieve   *
 *  their settings with just one call to StoreObjectStates.   *
 *                                                            *
 **************************************************************}

unit extINIF;

interface

uses
  {unfortunately we need to include a units of classes
    that we want to be able to store}
  IniFiles, Classes, Forms, StdCtrls, FileCtrl, Menus,
  SysUtils, TabNotBK;

type
  EExtIniFError = class(Exception);
  TExtIniF = class(TIniFile)
  private
    {store all objects states before TExtIniF is destroyed}
    FAutoStore: boolean;
    {list of all registered objects}
    FRegObjects: TStringList;
    {Name of [section] where values are stored}
    FIniSection: String;
  public
    constructor create(IniFNa   Topic%   Storing Component States to INI Files   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             me: TFileName);
    destructor destroy; override;
    {find the ini section for a registered object}
    function GetIniSection(obj: TObject): string;
    {Add a component to the list of objects}
    procedure RegisterObject(obj: TObject; INISection: string);
    {Remove a component to the list of objects}
    procedure UnRegisterObject(obj: TObject; INISection: string);
    {Retrieve the setting of a single Object}
    procedure ReStoreObjectState(obj: TObject; INISection: string);
    {Restore states of all registered objects}
    procedure RestoreObjectStates;
    {Restore states of all registered objects}
    procedure StoreObjectState(obj: TObject; INISection: string);
    {Store state of a single object}
    procedure StoreObjectStates;
    {Store states of all registered objects}
  published
    property AutoStore: boolean read FAutoStore write FAutoStore;
    property IniSection: string read FIniSection write FIniSection;
  end;

implementation

function ExtractFileBaseName(FullName: string): string;
{return the whole path without the extension}
var
  endPos: integer;
begin
  result := FullName;
  endPos := length(result);
  repeat
    dec(endPos);
  until result[endPos] = '.';
  delete(result,endPos,maxInt);
end;

constructor TExtIniF.create(IniFName: TFileName);
begin
  {if you don't pass your own name for the ini-File, it will be the name
   of your exe-file with the extension '*.INI'}
  if (IniFName = '') then
    IniFName:= ExtractFileBaseName(application.exename)+'.ini';
  inherited create(IniFName);
  FRegObjects:= TStringList.Create;
  FIniSection:= 'Options';
end;

destructor TExtIniF.Destroy;
begin
  {If AutoStore is set, values are stored
   before TExtIniF-Object is destroyed}
  if FAutoStore then StoreObjectStates;
  FRegObjects.destroy;
  inherited destroy;
end;

{ find the section string to a registered object
   if not registered or section string is empty
   return default value}
function TExtIniF.GetIniSection(obj: TObject): string;
var
  index: integer;
begin
  index:= FRegObjects.indexOfObject(obj);
  if ( index > -1 ) then
    begin
      result:= FRegObjects.strings[index];
      if result = '' then
        result:= FIniSection;
    end
  else
    result:= FIniSection;
end; {GetIniSection}

{ Add an object to the list of monitored objects. If you pass an empty string
   for INISection, the default value will apply and no name will be stored}
procedure TExtIniF.RegisterObject(obj: TObject; INISection: string);
begin
  {check if object is already registered}
  if (FRegObjects.indexOfObject(obj) = -1) then
    FRegObjects.addObject(INISection,obj);
end;

{ Remove an object from the list of monitored objects.}
procedure TExtIniF.UnRegisterObject(obj: TObject; INISection: string);
var
  index: integer;
begin
  index:= FRegObjects.indexOfObject(obj);
  if (index > -1) then 
    FRegObjects.delete(index);
end;

{ Restores the name of an object from the INI-File
   Note: When there is no entry in the INI-File, the object's value
          is not changed.}
procedure TExtIniF.ReStoreObjectState(obj: TObject; INISection: string);
var
  strBuf: string;
begin
  if ( INISection = '' ) then INISection:= FIniSection;
  {the next lines check for the type of object and
   restore whatever property we would like to store of that object
   if you make changes here you will need to make changes in
   StoreObjectState as well!!!}
  if (obj.classInfo <> nil ) then 
    begin
      if (obj is TCheckBox) then with (obj as TCheckBox) do 
        {Checkboxes: restore checked state}
        checked:= ReadBool(INISection,Name,checked)
      else if (obj is TEdit) then with (obj as TEdit) do 
        {Editfield: restore text}
        text:= ReadString(INISection,Name,text)
      else if (obj is TMenuItem) then with (obj as TMenuItem) do 
        {Menuitem: restore checked state}
        checked:= ReadBool(INISection,Name,checked)
      else if (obj is TTabbedNoteBook) then with (obj as TTabbedNoteBook) do
        {Notebook: restore open Tab}
        pageIndex:= ReadInteger(INISection,Name,pageIndex)
      else if (obj is TDriveComboBox) then with (obj as TDriveComboBox) do begin    
         {DriveCombo: restore selected drive}
         strBuf := ReadString(INISection,Name,Drive);
         Drive := strBuf[1];
      end else if (obj is TDirectoryListBox) then with (obj as TDirectoryListBox) do
        {DirectoryList: restore current directory}
        Directory:= ReadString(INISection,Name,Directory);
    end
  else
    raise EExtIniFError.create('This object is not supported!');
end;

{ Restores the state of all registered objects from the INI-File}
procedure TExtIniF.RestoreObjectStates;
var
  objNo: integer;
begin
  {iterate through all registered objects}
  for objNo:= 0 to FRegObjects.count - 1 do
    ReStoreObjectState(FRegObjects.objects[objNo],FRegObjects.strings[objNo]);
end;

{ Stores the state of an object to the INI-File}
procedure TExtIniF.StoreObjectState(obj: TObject; INISection: string);
var
  strBuf: string;
begin
  if ( INISection = '' ) then INISection:= FIniSection;
  {the next lines check for the type of object and
   store whatever property we would like to store of that object
   if you make changes here you will need to make changes in
   ReStoreObjectState as well!!!}
  if (obj.classInfo <> nil ) then begin
    if (obj is TCheckBox) then with (obj as TCheckBox) do
      {Checkboxes: store checked state}
      writeBool(INISection,Name,checked)
    else if (obj is TEdit) then with (obj as TEdit) do
      {Editfield: store text}
      writeString(INISection,Name,text)
    else if (obj is TMenuItem) then with (obj as TMenuItem) do
      {Menuitem: restore checked state}
      writeBool(INISection,Name,checked)
    else if (obj is TTabbedNoteBook) then with (obj as TTabbedNoteBook) do
      {Notebook: restore open Tab}
      writeInteger(INISection,Name,pageIndex)
    else if (obj is TDriveComboBox) then with (obj as TDriveComboBox) do
      {DriveCombo: restore selected drive}
      writeString(INISection,Name,Drive)
    else if (obj is TDirectoryListBox) then with (obj as TDirectoryListBox) do
      {DirectoryList: restore current directory}
      writeString(INISection,Name,Directory)
    else
      raise EExtIniFError.create('This object is not supported!');
  end;
end;

{ Stores the state of all registered objects to the INI-File}
procedure TExtIniF.StoreObjectStates;
var
  objNo: integer;
begin
  for objNo:= 0 to FRegObjects.count - 1 do
    StoreObjectState(FRegObjects.objects[objNo],FRegObjects.strings[objNo]);
end;

end.                                                                                                                                                                                                                                                                                                                                                                                                                          {To enable list view column sorting simply override the list view column click
 procedure with this method.  This algorithm will invert sort a column if you
 click on it twice.  If you don't like that, then remove references to lastix}

procedure TForm1.ListView1ColumnClick(sender: tobject; column: tlistcolumn);
const 
  asc : boolean = true;
  lastix : integer = -1;

  function customsortproc(item1, item2: tlistitem; paramsort: integer): integer; stdcall;
  var 
    sr1,sr2 : string;
  begin
    // get the strings to compare (depending on lastix)
    if lastix = 0 then begin
      sr1 := item1.caption;
      sr2 := item2.caption
    end else begin
      sr1:= item1.subitems[lastix-1];
      sr2:= item2.subitems[lastix-1];
    end;
    // now compare the strings
    result := lstrcmp(pchar(sr1),pchar(sr2));
    // if we are not ascending, invert the result
    if not asc then 
      result := -result;
  end;

begin
  // compare the column-index with the last one, if not the same,    Topic"   Listview Sorting via Column Clicks   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                set asc 
  // (ascending sorting) to true
  if column.index <> lastix then 
    asc := true
  else 
    asc := not asc;
  lastix := column.index;

 // now sort the items
 listview1.customsort(@customsortproc,0);
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            uses printers;

procedure TForm1.PrintIt(Sender: TObject);
var
  PrintBuf: TextFile;
begin
  AssignPrn(PrintBuf);
  Rewrite(PrintBuf);
  try
    for i := 0 to Memo1.Lines.Count-1 do
      WriteLn(PrintBuf, Memo1.Lines[i]);
  finally
    CloseFile(PrintBuf);
  end;
end;

{Found on the Borland Forums}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       Topic   Memo Printing   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     {Try locking the window update before changing the color}

LockWindowUpdate(RichEdit1.Handle);
try
  {Do Color stuff}
finally
  LockWindowUpdate(0);
end;

{code by Rick Seiden}

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      Topic   RichEdit Flicker Reduction   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        {Add the following method to your component}
procedure CMDesignHitTest(var Message: TCMDesignHitTest); message CM_DESIGNHITTEST;

{The implemenation should look like this : }
procedure TMyButton.CMDesignHitTest(var Message: TCMDesignHitTest);
begin
  Message.Result := 0;
end;

{Code written by Dan}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             Topic,   Making a Component Responsive at Design-Time   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      {A Page Control component that uses accelerator keys}

unit accel;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms,
  Dialogs, ComCtrls;

type
  TAccelPageCtrl = class(TPageControl)
  private
    { Private declarations }
    procedure CMDialogChar(var Msg: TCMDialogChar); message CM_DIALOGCHAR;
  end;

procedure Register;

implementation

procedure TAccelPageCtrl.CMDialogChar(var Msg: TCMDialogChar);
var
  I: Integer;
begin
  inherited; //call the inherited message handler.
  //Now with our own component, start at Page 1 (Item 0) and work to the end.
  for I := 0 to PageCount - 1 do begin
    //If accelerator key in caption matches page then change the page and
    // break out of the loop.  
    if (IsAccel(Msg.CharCode, Pages[I].Caption) AND CanChange(I)) then begin
      Msg.Result := 1; //you can set this to anything, but by convention it's 1
      ActivePage := Pages[I];
      Change;
      Break;
    end;
  end;
  
end;

procedur   Topic   Page Control Accellerator Keys   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    e Register;
begin
  RegisterComponents('Samples', [TAccelPageCtrl]);
end;

end.

{As you can see from the above. all that's required to add accelerator
key response is a simple message handler procedure. The message we're
interested in is CM_DialogChar, a Delphi custom message type
encapsulated by TCMDialogChar, which is a wrapper type for the
Windows WM_SYSCHAR message. WM_SYSCHAR is the Windows message that is
used to trap accelerator keys; you can find a good discussion of it in
the online help. The most important thing to note is what happens when
the TAccelPageCtrl component detects that a CM_DialogChar message has
fired. 

Take a look at the CMDialogChar procedure, and note that all that's
going in the code is a simple for loop that starts at the first page
of the descendant object and goes to the last page, unless the key that
was pressed happened to be an accelerator key. We can easily determine
if a key is an accelerator key with the IsAccel function, which takes
the key code pressed and a string (we passed the Caption property of
the current TabSheet). IsAccel searches through the string and looks
for a matching accelerator key. If it finds one, it returns True. If
so, we set the message result value and change the page of
TAccelPageCtrl to the page where the accelerator was found by setting
the ActivePage property and calling the inherited Change procedure from
TPageControl. 

I haven't used TPageControl since I created this component because of
how easy TAccelPageCtrl makes switching from TabSheet to TabSheet.
It's far easier to do a Alt-<key> combination than use the mouse when
you're at the keyboard. Play around with this and you'll be convinced
not to use the standard VCL TPageControl.}                                                                                                                                                                                                                                                                                            {I have done it. The main code fragments you are interested in are below.
The thing that makes the difference is intercepting the WM_MOVE message,
and calling the function InvalidateFrame. By the way - I copied
InvalidateFrame from the CONTROLS.PAS unit - unfortunately, it is
private to TWinControl :-(  }

------------------------------------------------------------------------

... other stuff snipped ...

type
  TBackgroundStyle = (bsOpaque, bsTransparent);

  TCustomButtonPanel = class(TScrollBox)
    private
      FCanvas: TCanvas;  { Need a Canvas }
    protected
      procedure WMSize(var Message: TWMSize); message WM_SIZE;
      procedure WMPaint(var Message: TWMPaint); message WM_PAINT;
      procedure WMMove(var Message: TWMMove); message WM_MOVE;
      procedure CreateParams(var Params: TCreateParams); override;
      procedure PaintWindow(DC: HDC); override;
      procedure Paint; virtual;
      procedure InvalidateFrame;
      property BackgroundStyle:  TBackgroundStyle
     Topic   Creating Transparent Controls   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               read FBackgroundStyle
            write SetBackgroundStyle
            default bsOpaque;
      ... other stuff snipped ...
    public
      constructor Create(AOwner: TComponent); override;
      property Canvas: TCanvas read FCanvas;
      ... other stuff snipped ...
  end;

... other code and stuff snipped ...

implementation

constructor TCustomButtonPanel.Create(AOwner: TComponent);
begin
  FBackgroundStyle := bsOpaque;
  inherited Create(AOwner);
  ControlStyle := [csAcceptsControls, csCaptureMouse, csClickEvents,
                   csSetCaption, csOpaque, csDoubleClicks];
  FCanvas := TControlCanvas.Create;
  TControlCanvas(FCanvas).Control := Self;
end;

procedure TCustomButtonPanel.SetBackgroundStyle(Value:TBackgroundStyle);
begin
  { BackgroundStyle Set Property Handler }
  if Value <> FBackgroundStyle then begin
    FBackgroundStyle := Value;
    RecreateWnd;
  end;
end;

procedure TCustomButtonPanel.CreateParams(var Params: TCreateParams);
begin
  inherited CreateParams(Params);
  with Params do begin
    if FBackgroundStyle = bsOpaque then
      ExStyle := ExStyle and not Ws_Ex_Transparent
    else
      ExStyle := ExStyle or Ws_Ex_Transparent;
  end;
end;

procedure TCustomButtonPanel.PaintWindow(DC: HDC);
begin
  { Setup the canvas and call the Paint routine }
  FCanvas.Handle := DC;
  try
    Paint;
  finally
    FCanvas.Handle := 0;
  end;
end;

procedure TCustomButtonPanel.Paint;
var
  theRect: TRect;
begin
  with canvas do
    brush.Color := Self.Color;
    theRect := GetClientRect;
    if FBackgroundStyle = bsOpaque then
      FillRect(theRect);
  ... other code and stuff snipped ...
  end;
end;

procedure TCustomButtonPanel.InvalidateFrame;
var
  R: TRect;
begin
  { Handle invalidation after move in designer }
  R := BoundsRect;
  InflateRect(R, 1, 1);
  InvalidateRect(Parent.Handle, @R, True);
end;

procedure TCustomButtonPanel.WMMove(var Message: TWMMove);
begin
  if (csDesigning in ComponentState) then
    InvalidateFrame;
  inherited;
end;

... other code and stuff snipped ...

{Found in the Borland Forums}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           {Menus, as implemented by the Windows API, do not take focus the same way as 
controls do. When a menu is activated Windows takes over and starts an 
internal message loop that does not return control to your app until the 
menu is closed one way or another.

To remote-control a menu you fake keystrokes: F10 to activate the main 
menu, then the shortcut letter of the main menu item to select and open, 
then key downs to move the hilight bar to the menu item you want to select. 

Example to select the "Copy" entry if the standard "Edit" menu:}

procedure PostVKey(hWindow: HWND; key: Word);
begin
  if iswindow(hWindow) then begin
    PostMessage(hWindow, WM_KEYDOWN, key, MakeLong(0, MapVirtualKey(key, 0)));
    PostMessage(hWindow, WM_KEYUP, key, MakeLong(1, MapVirtualKey(key, 0) or $C000));
  end;
end;

procedure TForm1.FakeIt(Sender: TObject);
var
  i: Integer;
begin
  PostVKey(Handle, VK_F10);
  PostMessage(Handle, WM_CHAR, Ord('e'), 0);
  for i:= 1 To 3 Do
    PostVKey(Handle, VK_D   Topic$   Opening - Manipulating Menus in Code   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              l i c k e r   R e d u c t i o n    �   <   ,�M a k i n g   a   C o m p o n e n t   R e s p o n s i v e   a t   D e s i g n - T i m e     �   6  ,�M a k i n g   a   C o m p o n e n t   R e s p o n s i v e   a t   D e s i g n - T i m e    �   N   �P a g e   C o n t r o l   A c c e l l e r a t o r   K e y s     �   �
  �P a g e   C o n t r o l   A c c e l l e r a t o r   K e y s    �   @   �C r e a t i n g   T r a n s p a r e n t   C o n t r o l s     �   u  �C r e a t i n g   T r a n s p a r e n t   C o n t r o l s    �   ?   $�O p e n i n g   -   M a n i p u l a t i n g   M e n u s   i n   C o d e     �   6  $�O p e n i n g   -   M a n i p u l a t i n g   M e n u s   i n   C o d e    �   F   �S t a t u s   B a r   -   C o m p o n e n t s   i n     �   �  �S t a t u s   B a r   -   C o m p o n e n t s   i n    �   <   $�C h e c k i n g   f o r   I n t e r s e c t i n g   C o m p o n e n t s     �   :  $�C h e c k i n g   f o r   I n t e r s e c t i n g   C o m p o n e n t s    �   F   �M e m OWN);
end;

{Code written by Peter Below (TeamB)}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
// Another alternative would be to use this TStatusbar decendant which
// accepts any control.

unit NewStatusBar;

interface

uses
  Classes, Windows, Controls, Comctrls;

type
  TACStatusBar = class(TStatusBar)
  private
    { Private declarations }
  protected
    { Protected declarations }
  public
    { Public declarations }
   constructor Create(aOwner: TComponent); override;
  published
    { Published declarations }
  end;

procedure Register;

implementation

constructor TACStatusBar.Create(aOwner: TComponent);
begin
  inherited Create(aOwner);
  ControlStyle := ControlStyle + [csAcceptsControls];
end;  

procedure Register;
begin
  RegisterComponents('Samples', [TACStatusBar]);
end;

end.
                                                                                                                                                                                                                                                                                      Topic   Status Bar - Components in   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        {I think this should do the trick, it uses screen coordinates to avoid 
the problem (checking controls with distinct parents) you noted.}

function DoTheyIntersect(a,b :TControl) : boolean;
var
  ra, rb, dud : TRect;
begin
  ra.TopLeft := a.Parent.ClientToScreen(a.BoundsRect.TopLeft);
  ra.BottomRight := a.Parent.ClientToScreen(a.BoundsRect.BottomRight);
  rb.TopLeft := b.Parent.ClientToScreen(b.BoundsRect.TopLeft);
  rb.BottomRight := b.Parent.ClientToScreen(b.BoundsRect.BottomRight);
  
  Result := IntersectRect(dud, ra,rb);
end;

{Chris Hill}

                                                                                                                                                                                                                                                                                                                                                                                                                                                                         Topic$   Checking for Intersecting Components   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              {This line of code scrolls the caret into view}

 memo.Perform(EM_SCROLLCARET, 0, 0 );
 
{Code written by Peter Below (TeamB)}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               Topic   Memo Auto-Scrolling   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               if getfocus<>0 then SendMessage(GetFocus, EM_UNDO, 0, 0);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        Topic   Edit Control Undo   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 {To add a horizontal scroll bar to a list box use the following line of code}

sendmessage(ListBox.Handle, LB_SetHorizontalExtent, PixelWidth , 0);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            Topic   Listbox Horizontal Scroll Bar   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      Simulating a Tab    �   &    Simulating a Tab   �   2    Stopping Flicker Problems    �   ,   Stopping Flicker Problems   �   ;   ' Restoring Focus to the Previous Control    �   �  ' Restoring Focus to the Previous Control   �   I   " Putting a Bitmap in the Background    �   �  " Putting a Bitmap in the Background   �   D    Trapping a Minimize Action    �   �   Trapping a Minimize Action   �   <    Trapping the Tab Key    �   �   Trapping the Tab Key   �   6   ' Intercepting Component to Form Messages    �   �  ' Intercepting Component to Form Messages   �   I    Restricting Window Sizes    �   7   Restricting Window Sizes   �   :   ! Moving Forms Without the Titlebar    �   e  ! Moving Forms Without the Titlebar   �   C    Making a Form Non-Moveable    �   #   Making a Form Non-Moveable   �   <    Making a "Transparent" Form    �   �   Making a "Transparent" Form   �   =   $ Determining a Form's ScrollBar Width    �   /   $ Determining a Form's ScrollBar Width   �   F    Topic   Form Level Stuff                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   SelectNext(ActiveControl,True,True);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             Topic   Simulating a Tab   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  {This technique is useful for eliminating flicker problems caused by full
 erases when the redraw will completely cover the 'damaged' area, thus 
 making the full erase unnecessary
 
 Essentially, we intercept the erase command then say we handled it with
 out doing anything.  This can be refined to only 'handle' certain portions
 of the screen on a use by use basis}

Procedure TForm1.WMEraseBkGnd(Var Msg:TMessage); 
Begin
  Msg.Result:= 1; { Do nothing, but mark the message as being handled}
End;

{This technique was posted by Andrew}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       Topic   Stopping Flicker Problems   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         {This code shows how to return focus to a control after some event has
changed it.  If you want to click on some button, then return focus to
the previously selected control, you can probably use a speed button
instead of a button, since the speed button won't steal focus.  If this
doesn't work, try the following code.

This involves using the Screen.OnActiveControlChange event, as 
illustrated in the following code example.}

unit Unit1;

interface

uses
  SysUtils, WinTypes, WinProcs, Messages, Classes, Graphics, Controls,
  Forms, Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    ListBox1: TListBox;
    ButtonPrint: TButton;
    Memo1: TMemo;
    procedure FormCreate(Sender: TObject);
    procedure ButtonPrintClick(Sender: TObject);
  private
    FPreviousControl : TWinControl;
    FCurrentControl : TWinControl;
  public
    procedure FocusPreviousControl;
    procedure ActiveControlChangeHandler(Sender: TObject);
    property PreviousControl: TWinControl read FPreviousCont   Topic'   Restoring Focus to the Previous Control   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           rol;
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}

procedure TForm1.FocusPreviousControl;
begin
  if (FPreviousControl <> nil) then 
    FPreviousControl.SetFocus;
end;

procedure TForm1.ActiveControlChangeHandler(Sender: TObject);
begin
  { This event fires AFTER the active control is changed }
  if (ActiveControl is TWinControl) then begin
    FPreviousControl := FCurrentControl;
    FCurrentControl := ActiveControl;
  end;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Screen.OnActiveControlChange := ActiveControlChangeHandler;
end;

procedure TForm1.ButtonPrintClick(Sender: TObject);
begin
  { Print stuff here }
  FocusPreviousControl;
end;

end.

{coded by Rick Rogers (TeamB)}                                                                                                                                                                                                                                                                               {To place a bitmap in the background of a form

  1) Place the bitmap in a resource file. (Your forms, the applications, 
     or your own).  Make sure that however you do it the resource file
     is linked into your form.
  2) Create a TBitmap variable in the private section of the form.     
  3) Override the OnCreate, OnDestroy and OnPaint methods of the form}
  
procedure TForm1.FormCreate(Sender: TObject);
begin
  BackgroundBitmap := TBitmap.Create;
  BackgroundBitmap.LoadFromResourceName(hInstance,'MYBITMAP');
end;
 
procedure TForm1.FormDestroy(Sender: TObject);
begin
  BackgroundBitmap.Free;
end;
 
procedure TForm1.FormPaint(Sender: TObject);
begin
  Canvas.Draw(0,0,BackgroundBitmap);
end;                                                                                                                                                                                                                                                                                                          Topic"   Putting a Bitmap in the Background   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                {add a handler for the message WM_SYSCOMMAND to your window. Look for 
the case (msg.CmdType and $FFF0) = SC_MINIMIZE and do not call inherited 
for this case, instead return msg.result := 0. Call inherited for all other 
cases.}

procedure WMSYSCOMMAND(msg : TMessage); message WM_SYSCOMMAND;
begin
  if msg.CmdType and $FFF0 = SC_MINIMIZE) then
    msg.result := 0
  else
    inherited;
end;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               Topic   Trapping a Minimize Action   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        {This technique may be helpful to you if you want the tab to 
 move columns with in a stringgrid, etc. instead of performing
 its default action}
 
unit TrappingTabs;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, Grids;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Button1: TButton;
    procedure FormKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);
  private
    { Private declarations }
    procedure WMGetDlgCode(var msgIn: TWMGetDlgCode); message WM_GETDLGCODE;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}

procedure TForm1.WMGetDlgCode;
begin
   inherited;
   msgIn.Result := msgIn.Result or DLGC_WANTTAB;
end;

procedure TForm1.FormKeyDown(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  if Key = VK_TAB then
     ShowMessage('Tab');
end;

end.
                                                                                 Topic   Trapping the Tab Key   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              unit FTSubCls;
{How to intercept messages that a form gets from one of it's components} 
interface

uses
SysUtils, WinTypes, WinProcs, Messages, Classes, Controls, Forms;

type

  TFTSubclassWnd = class(TComponent)
  private
    FNewWndProcPtr : TFarProc;
    FOldWndProcPtr : TFarProc;
    FWindowHandle : HWnd;
  protected
    { Virtual methods for descendants }
    procedure NewWndProc(var Message: TMessage); virtual; abstract;
    procedure AssignHandle; virtual;
    { Component methods }
    procedure ReplaceWndProc;
    procedure RestoreWndProc;
    procedure CallOldWndProc(var Message: TMessage);
    { Protected properties }
    property NewWndProcPtr: TFarProc read FNewWndProcPtr;
    property OldWndProcPtr: TFarProc read FOldWndProcPtr;
    property WindowHandle: HWnd read FWindowHandle;
  public
    { Construction/destruction }
    constructor Create(AOwner: TComponent); override;
    destructor Destroy; override;
  end;

implementation

constructor TFTSubclassWnd.Cre   Topic'   Intercepting Component to Form Messages   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ate(AOwner: TComponent);
begin
  inherited Create(AOwner);
  if not (AOwner is TForm) then 
    raise Exception.Create('Owner must be form');
  AssignHandle;
  ReplaceWndProc;
end;

destructor TFTSubclassWnd.Destroy;
begin
  RestoreWndProc;
  inherited Destroy;
end;

procedure TFTSubclassWnd.CallOldWndProc(var Message: TMessage);
begin
  with Message do
    Result := CallWindowProc(FOldWndProcPtr, FWindowHandle, Msg, wParam, lParam);
end;

procedure TFTSubclassWnd.AssignHandle;
begin
  with (Owner as TForm) do begin
    { Ensure the window handle has been allocated }
    HandleNeeded;
    { Assign window handle (with special processing for MDI parent forms }
    if (FormStyle = fsMDIForm) then 
      FWindowHandle := ClientHandle
    else 
      FWindowHandle := Handle;
  end;
end;

procedure TFTSubclassWnd.ReplaceWndProc;
begin
  { Save pointer to old WndProc }
  FOldWndProcPtr := Pointer(GetWindowLong(FWindowHandle, GWL_WNDPROC));
  { Create pointer to NewWndProc }
  FNewWndProcPtr := MakeObjectInstance(NewWndProc);
  if (FNewWndProcPtr = nil) then
    raise EOutOfResources.Create('Cannot allocate WndProc handle');
  { Subclass window by setting GWL_WNDPROC to NewWndProc }
  SetWindowLong(FWindowHandle, GWL_WNDPROC, LongInt(FNewWndProcPtr));
end;

procedure TFTSubclassWnd.RestoreWndProc;
begin
  SetWindowLong(FWindowHandle, GWL_WNDPROC, LongInt(FOldWndProcPtr));
  if FNewWndProcPtr <> nil then 
    FreeObjectInstance(FNewWndProcPtr);
end;

end.

(*
You'll need to descend any components which need to "listen" to the form's
messages from the TSubclassWnd component. In your descendant component, you'll
need to override the NewWndProc procedure, and provide a message handler that
looks for messages of interest. For example, your procedure will look something
like this: 
  Procedure TMaleyComponent.NewWndProc(var Message: TMessage);
  begin
    if (Message.Msg = WM_SIZE) then { Do something };
  end;
*)

{This code was written by Rick Rogers}
      {In your form, override the WM_GETMINMAXINFO method with a call
to the following code}

procedure TForm1.WMGETMINMAXINFO( var message: TMessage );
var
  mStruct: PMinMaxInfo;
begin
  mStruct := PMinMaxInfo(message.lParam);
  mStruct.ptMinTrackSize.x := 480;
  mStruct.ptMinTrackSize.y := 350;
// ptMaxSize.x:=800;      {Width of form when maximized}
// ptMaxSize.y:=600;      {Height of form when maximized}
// ptMaxPosition.x:=0;    {Form.Left when maximized}
// ptMaxPosition.y:=0;    {Form.Top when maximized}
// ptMinTrackSize.x:=400; {min width you can achieve with mouse}
// ptMinTrackSize.y:=200; {min height you can achieve with mouse}
// ptMaxTrackSize.x:=750; {max width you can achieve with mouse}
// ptMaxTrackSize.y:=550; {max height you can achieve with mouse}
  message.Result := 0;
end;
                                                                                                                                                                                                            Topic   Restricting Window Sizes   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          {subject : moving forms (and other twincontrols) without using the caption-bar}

procedure twincontrol.formmousedown(sender: tobject; button: tmousebutton;
                                    shift: tshiftstate; x, y: integer);
const
  sc_dragmove = $f012;
begin
  releasecapture;
  twincontrol(sender).perform(wm_syscommand,sc_dragmove, 0);
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              Topic!   Moving Forms Without the Titlebar   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 {Here is how to keep the window from moving:

First, obviously you are going to want to make the borderstyle something
like bsDialog, so that the window cant be resized.
Next, add the following declaration to your form class:
}
procedure PosChanging(var Msg: TWmWindowPosChanging); message WM_WINDOWPOSCHANGING;

// Finally, implement the procedure like:

procedure TMyForm.PosChanging(var Msg: TWmWindowPosChanging);
begin
   Msg.WindowPos.x := Left;
   Msg.WindowPos.y := Top;
   Msg.Result := 0;
end;

{Thats it. Easy as can be.The only problem with this is that you cant move
the form if you want your code to. To get around this, just set up a
Boolean variable called PosLocked, set it to true when you want to lock the
forms position, and to false when you need to move the form (when your
done, remember to set it back to true). Then to implement the proc above,
just make it}

if PosLocked then begin
   Msg.WindowPos.x := Left;
   Msg.WindowPos.y := Top;
   Msg.Result := 0;
end else inh   Topic   Making a Form Non-Moveable   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        erited;

{coded by Ron Frazier}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             {Add a button to a form and try this:}

procedure TForm1.FormCreate(Sender: TObject);
var
  FullRgn, ClientRgn, ButtonRgn: THandle;
  Margin, X, Y: Integer;
begin
  Margin := (Width - ClientWidth) div 2;
  FullRgn := CreateRectRgn(0, 0, Width, Height);
  X := Margin;
  Y := Height - ClientHeight - Margin;
  ClientRgn := CreateRectRgn(X, Y, X + ClientWidth, Y + ClientHeight);
  CombineRgn(FullRgn, FullRgn, ClientRgn, RGN_DIFF);
  X := X + Button1.Left;
  Y := Y + Button1.Top;
  ButtonRgn := CreateRectRgn(X, Y, X + Button1.Width, Y + Button1.Height);
  CombineRgn(FullRgn, FullRgn, ButtonRgn, RGN_OR);
  SetWindowRgn(Handle, FullRgn, True);
end;
                                                                                                                                                                                                                                                                                                                                                                      Topic   Making a "Transparent" Form   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       ScrollSize := GetSystemMetrics(SM_CXVSCROLL);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    Topic$   Determining a Form's ScrollBar Width   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 Creating a TForm Descendant      T   Creating a TForm Descendant     =    Creating a Floating Window    
  y   Creating a Floating Window     <    Adding a Caption Button      Y   Adding a Caption Button     9    Posting Keystrokes from Threads      )   Posting Keystrokes from Threads     A                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           {This explains how to set up a new form descendant which will have editable
 properties via the object inspector}
 

{In Delphi 3.0 there is a new approach which you can use that I will try
to briefly describe.  The idea is to use a custom module to create a new
form class that has new properties etc.  This can be done by registering a
classtype with the IDE by calling RegisterCustomModule (in the expert API).
 With a custom module you can add your own new properties to forms which
will appear in the object inspector.  The mechanism to get this to work is
as follows: 

- Create a unit that declares your new form class descending from TCustomForm
- Create an expert that will generate a new instance of the above class in
  the IDE
- Install the expert in the IDE by including the expert unit below in a new
  package and simply install the package.

Once you have followed these steps you will have a new item on the Form
page of the File|New dialog which will be your new form class.

The new f            	                                                                      =                                 '          *      +  ,      /                                  8      9                                        E      F  G  H  I  J  K              P      Q  R  S  T  U  V  W              [  \  ]  ^  _      d  `  a      e  f  g  h  i  j  k  l  m  n  o  p  q  r  s  t  u  v  w  x  y  z  {  |  }  ~    �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �                Topic   Creating a TForm Descendant   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       orm class unit:}
>>>> Begin unit <<<<<<
unit myForm;

interface

uses Messages, Windows, SysUtils, Classes, Controls, Forms;

type
  TMyForm = class(TCustomForm)
  private
    FNewProp: String;  
  protected
  public
  published
    property NewProp: String read FNewProp write FNewProp;  // ex. of a new form property
    property ActiveControl;
    property Align;
    property AutoScroll;
    property BorderStyle;
    property BorderIcons;
    property Caption stored True;
    property ClientHeight;
    property ClientWidth;
    property Color;
    property DragCursor;
    property DragMode;
    property Enabled;
    property Font;
    property Height stored True;
    property HorzScrollBar;
    property KeyPreview;
    property ParentColor;
    property ParentCtl3D;
    property ParentFont;
    property ParentShowHint;
    property PixelsPerInch;
    property PopupMenu;
    property PrintScale;
    property Scaled;
    property ShowHint;
    property TabStop;
    property VertScrollBar;
    property Width stored True;
    property OnActivate;
    property OnClick;
    property OnClose;
    property OnCloseQuery;
    property OnCreate;
    property OnDblClick;
    property OnDestroy;
    property OnDeactivate;
    property OnDragDrop;
    property OnDragOver;
    property OnHide;
    property OnHelp;
    property OnKeyDown;
    property OnKeyPress;
    property OnKeyUp;
    property OnMouseDown;
    property OnMouseMove;
    property OnMouseUp;
    property OnPaint;
    property OnResize;
    property OnShow;
  end;

implementation

end.
>>>>  end unit <<<<

{Here is the expert necessary to create instances of this class from the IDE:}
>>>> begin expert <<<<
unit newmod;

interface

procedure Register;

implementation

uses Windows, SysUtils, Classes, Controls, Forms, ExptIntf, ToolIntf,
VirtIntf,
  IStreams, DsgnIntf, MyForm;

type
  TMyFormExpert = class(TIExpert)
    function GetName: string; override;
    function GetComment: string; override;
    function GetGlyph: HICON; override;
    function GetStyle: TExpertStyle; override;
    function GetState: TExpertState; override;
    function GetIDString: string; override;
    function GetAuthor: string; override;
    function GetPage: string; override;
    function GetMenuText: string; override;
    procedure Execute; override;
  end;

{ TMyFormExpert }

function TMyFormExpert.GetName: string;
begin
  Result := 'My Form';
end;

function TMyFormExpert.GetComment: string;
begin
  Result := 'Custom form';
end;

function TMyFormExpert.GetGlyph: HICON;
begin
  Result := LoadIcon(HInstance, '');
end;

function TMyFormExpert.GetStyle: TExpertStyle;
begin
  Result := esForm;
end;

function TMyFormExpert.GetState: TExpertState;
begin
  Result := [esEnabled];
end;

function TMyFormExpert.GetIDString: string;
begin
  Result := 'MyForm.Expert';
end;

function TMyFormExpert.GetAuthor: string;
begin
  Result := 'Borland';
end;

function TMyFormExpert.GetPage: string;
begin
  Result := 'Forms';
end;

function TMyFormExpert.GetMenuText: string;
begin
  Result := '';
end;

const
  FormUnitSource =
    'unit %0:s;'#13#10 +
    #13#10 +
    'interface'#13#10 +
    #13#10 +
    'uses Windows, SysUtils, Messages, Classes, Graphics, Controls,'#13#10 +
    '  StdCtrls, ExtCtrls, MyForm;'#13#10 +
    #13#10 +
    'type'#13#10 +
    '  T%1:s = class(TMyForm)'#13#10 +
    '  private'#13#10 +
    '    { Private declarations }'#13#10 +
    '  public'#13#10 +
    '    { Public declarations }'#13#10 +
    '  end;'#13#10 +
    #13#10 +
    'var'#13#10 +
    '  %1:s: T%1:s;'#13#10 +
    #13#10 +
    'implementation'#13#10 +
    #13#10 +
    '{$R *.DFM}'#13#10 +
    #13#10 +
    'end.'#13#10;

  FormDfmSource = 'object %s: T%0:s end';

procedure TMyFormExpert.Execute;
var
  UnitIdent, Filename: string;
  FormName: string;
  CodeStream: TIStream;
  DFMStream: TIStream;
  DFMString, DFMVCLStream: TStream;
begin
  if not ToolServices.GetNewModuleName(UnitIdent, FileName) then Exit;
  FormName := 'MyForm' + Copy(UnitIdent, 5, 255);
  CodeStream :=
TIStreamAdapter.Create(TStringStream.Create(Format(FormUnitSource,
    [UnitIdent, FormName])), True);
  try
    CodeStream.AddRef;
    DFMString := TStringStream.Create(Format(FormDfmSource, [FormName]));
    try
      DFMVCLStream := TMemoryStream.Create;
      try
        ObjectTextToResource(DFMString, DFMVCLStream);
        DFMVCLStream.Position := 0;
      except
        DFMVCLStream.Free;
      end;
      DFMStream := TIStreamAdapter.Create(DFMVCLStream, True);
      try
        DFMStream.AddRef;
        ToolServices.CreateModuleEx(FileName, FormName, 'TMyForm', '',
          CodeStream, DFMStream, [cmAddToProject, cmShowSource, cmShowForm,
            cmUnNamed, cmMarkModified]);
      finally
        DFMStream.Free;
      end;
    finally
      DFMString.Free;
    end;
  finally
    CodeStream.Free;
  end;
end;

procedure Register;
begin
  RegisterCustomModule(TMyForm, TCustomModule);
  RegisterLibraryExpert(TMyFormExpert.Create);
end;

end.
>>>> end expert <<<<

{To get the expert installed you have to add the unit to a package and
install the package.  Once this is complete your new form class will be
available from the File|New dialog.}

{coded by Steven Trefethen}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            If you want the window to stay on top of ALL windows, then
you can just set the form's style to fsStayOnTop.  If you have
a specific window you want to stay on top of, then you need
override the TForm.CreateParams method.  After calling the
inherited method, set the Param.ParentWnd to the handle
of the window you wish to float above.  

{found on the Borland Forums}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          Topic   Creating a Floating Window   Language   N                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        {
Handle message WM_NCPAINT. Call inherited to allow the normal caption to be
drawn, then add your stuff. A good function for drawing buttons (here or
anywhere) is DrawFrameControl.

Handle message WM_NCHITTEST. When the mouse is over your button, don't pass
to inherited. This prevents Windows from thinking your button is a part of
the normal caption and from allowing the window to be dragged at that
point.

Handle the WM_NC mouse mesages (LButtonDown, LButtonUp, etc). Redraw the
button as pushed on mouse down, redraw as not pushed and do your stuff when
mouse up.
}
{by timjd}

                                                                                                                                                                                                                                                                                                                                                                                                                                          Topic   Adding a Caption Button   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           {************************************************************
 * Procedure PostKeyEx
 *
 * Parameters:
 *  hWindow: target window to be send the keystroke
 *  key    : virtual keycode of the key to send. For printable
 *           keys this is simply the ANSI code (Ord(character)).
 *  shift  : state of the modifier keys. This is a set, so you
 *           can set several of these keys (shift, control, alt,
 *           mouse buttons) in tandem. The TShiftState type is 
 *           declared in the Classes Unit.
 *  specialkey: normally this should be False. Set it to True to 
 *           specify a key on the numeric keypad, for example. 
 *           If this parameter is true, bit 24 of the lparam for
 *           the posted WM_KEY* messages will be set. 
 * Description:
 *  This procedure sets up Windows key state array to correctly
 *  reflect the requested pattern of modifier keys and then posts
 *  a WM_KEYDOWN/WM_KEYUP message pair to the target window. Then
 *  Application.ProcessMe   Topic   Posting Keystrokes from Threads   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   ssages is called to process the messages
 *  before the keyboard state is restored.
 * Error Conditions:
 *  May fail due to lack of memory for the two key state buffers.
 *  Will raise an exception in this case.
 * NOTE:
 *  Setting the keyboard state will not work across applications 
 *  running in different memory spaces on Win32 unless AttachThreadInput
 *  is used to connect to the target thread first.
 *Created: 02/21/96 16:39:00 by P. Below
 ************************************************************}
Procedure PostKeyEx( hWindow: HWnd; key: Word; Const shift: TShiftState;
                     specialkey: Boolean );
Type
  TBuffers = Array [0..1] of TKeyboardState;
Var
  pKeyBuffers : ^TBuffers;
  lparam: LongInt;
Begin
  (* check if the target window exists *)
  If IsWindow(hWindow) Then Begin
    (* set local variables to default values *)
    pKeyBuffers := Nil;
    lparam := MakeLong(0, MapVirtualKey(key, 0));

    (* modify lparam if special key requested *)
    If specialkey Then
      lparam := lparam or $1000000;

    (* allocate space for the key state buffers *)
    New(pKeyBuffers);
    try
      (* Fill buffer 1 with current state so we can later restore it.  
         Null out buffer 0 to get a "no key pressed" state. *)
      GetKeyboardState( pKeyBuffers^[1] );
      FillChar(pKeyBuffers^[0], Sizeof(TKeyboardState), 0);

      (* set the requested modifier keys to "down" state in the buffer *)
      If ssShift In shift Then
        pKeyBuffers^[0][VK_SHIFT] := $80;
      If ssAlt In shift Then Begin
        (* Alt needs special treatment since a bit in lparam needs also be set *)
        pKeyBuffers^[0][VK_MENU] := $80;
        lparam := lparam or $20000000;
      End;
      If ssCtrl In shift Then
        pKeyBuffers^[0][VK_CONTROL] := $80;
      If ssLeft In shift Then
        pKeyBuffers^[0][VK_LBUTTON] := $80;
      If ssRight In shift Then
        pKeyBuffers^[0][VK_RBUTTON] := $80;
      If ssMiddle In shift Then
        pKeyBuffers^[0][VK_MBUTTON] := $80;

      (* make out new key state array the active key state map *)
      SetKeyboardState( pKeyBuffers^[0] );

      (* post the key messages *)
      If ssAlt In Shift Then Begin
        PostMessage( hWindow, WM_SYSKEYDOWN, key, lparam);
        PostMessage( hWindow, WM_SYSKEYUP, key, lparam or $C0000000);
      End
      Else Begin
        PostMessage( hWindow, WM_KEYDOWN, key, lparam);
        PostMessage( hWindow, WM_KEYUP, key, lparam or $C0000000);
      End;
      (* process the messages *)
      Application.ProcessMessages;

      (* restore the old key state map *)
      SetKeyboardState( pKeyBuffers^[1] );
    finally
      (* free the memory for the key state buffers *)
      If pKeyBuffers <> Nil Then
        Dispose( pKeyBuffers );
    End; { If }
  End;
End; { PostKeyEx }

{The keyboard state manipulating stuff will only work if you use 
AttachThreadInput on the target thread but it should not be necessary for 
pure Alt-key combinations anyway.}

{written by Peter Below (TeamB)}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       �C a l c u l a t i n g   t h e   W e e k   N u m b e r       �  �C a l c u l a t i n g   t h e   W e e k   N u m b e r      =   �F i n d i n g   E a s t e r   i n   a   G i v e n   Y e a r       o  �F i n d i n g   E a s t e r   i n   a   G i v e n   Y e a r      @   �B i t w i s e   O p e r a t i o n s       d  �B i t w i s e   O p e r a t i o n s      ~   �G r a p h i c s    0  �   	�M e t a p h o n e     �  �  	�M e t a p h o n e    �  .   �C o m b i n a t i o n     �  �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   Topic
   Algorithms                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         {Calculate a week-of-the-year index (0-51) for a given date.
 Week 0 is the week containing the first Sunday of the year.}

function  WeekNum(const TDT:TDateTime) : Word;
var
  Y,M,D:Word;
  dtTmp:TDateTime;
begin
  DecodeDate(TDT,Y,M,D);
  dtTmp:=EnCodeDate(Y,1,1);
  Result:=(Trunc(TDT-dtTmp)+(DayOfWeek(dtTmp)-1)) DIV 7;
  if Result=0 then 
    Result:=51 
  else 
    Result:=Result-1;
end;

{code written by Ernie Deel, EFD Systems}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           Topic   Calculating the Week Number   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       function GetEaster(Year: Integer): TDate;
var
  y, m, d: Word;
  G, I, J, C, H, L: Integer;
  E: TDate;
begin
  G := Year mod 19;
  C := year div 100;
  H := (C - C div 4 - (8*C+13) div 25 + 19*G + 15) mod 30;
  I := H - (H div 28)*(1 - (H div 28)*(29 div (H + 1))*((21 - G) div 11));
  J := (Year + Year div 4 + I + 2 - C + C div 4) mod 7;
  L := I - J;
  m := 3 + (L + 40) div 44;
  d := L + 28 - 31*(m div 4);
  y := Year;
  // E is the date of the full moon
  E := EncodeDate(y, m, d);
  // Find next sunday
  while DayOfWeek(E) > 1 do
    E := E + 1;
  Result := E;
end;

{ From Yorai Aminov }
                                                                                                                                                                                                                                                                                                                                                                                                                    Topic   Finding Easter in a Given Year   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    unit Bitwise;

interface
  function IsBitSet(const val: longint; const TheBit: byte): boolean;
  function BitOn(const val: longint; const TheBit: byte): LongInt;
  function BitOff(const val: longint; const TheBit: byte): LongInt;
  function BitToggle(const val: longint; const TheBit: byte): LongInt;

implementation

function IsBitSet(const val: longint; const TheBit: byte): boolean;
begin
  result := (val and (1 shl TheBit)) <> 0;
end;

function BitOn(const val: longint; const TheBit: byte): LongInt;
begin
  result := val or (1 shl TheBit);
end;

function BitOff(const val: longint; const TheBit: byte): LongInt;
begin
  result := val and ((1 shl TheBit) xor $FFFFFFFF);
end;

function BitToggle(const val: longint; const TheBit: byte): LongInt;
begin
  result := val xor (1 shl TheBit);
end;

end.

{code found in a Borland TI}
                                                                                                                                                              �T o p i c   �B i t w i s e   O p e r a t i o n s   �L a n g u a g e   �P   �H i g h l i g h t e r   �s h l S Q L    �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  #�G e t t i n g   P r o g r a m   V e r s i o n   I n f o r m a t i o n       C  #�G e t t i n g   P r o g r a m   V e r s i o n   I n f o r m a t i o n      E   �D i s a b l i n g   S y s t e m   K e y s     !    �D i s a b l i n g   S y s t e m   K e y s    "  7   �U s i n g   t h e   R u n O n c e   R e g i s t r y   K e y     #  m  �U s i n g   t h e   R u n O n c e   R e g i s t r y   K e y    $  @   #�T r a p p i n g   A p p l i c a t i o n   G l o b a l   H o t K e y s     %    #�T r a p p i n g   A p p l i c a t i o n   G l o b a l   H o t K e y s    &  E   $�S e n d i n g   K e y s t r o k e s   t o   a n   A p p l i c a t i o n     (  ]  $�S e n d i n g   K e y s t r o k e s   t o   a n   A p p l i c a t i o n    )  F   /�P r e v e n t i n g   M u l t i p l e   I n s t a n c e s   o f   a n   A p p l i c a t i o n     -    /�P r e v e n t i n g   M u l t i p l e   I n s t a n c e s   o f   a n   A p p l i c a t i o n    .  Q   �R e m o v e   A p p   f r o m   T a s    Topic   Application Level Code                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             {This sample project demonstrates how to get at the version info
in executables.

 In a new project, drop a TMemo and a TButton on the form (make
 sure they're called Memo1 and Button1). Double click on Button1.
 Now you can go ahead and directly replace the code for the
 Button1Click procedure (see below).

--------------------------
The Button1Click procedure
--------------------------
}
procedure TForm1.Button1Click(Sender: TObject);
const
  InfoNum = 10;
  InfoStr : array [1..InfoNum] of String =
    ('CompanyName', 'FileDescription', 'FileVersion', 'InternalName',
     'LegalCopyright', 'LegalTradeMarks', 'OriginalFilename',
     'ProductName', 'ProductVersion', 'Comments');
var
  S         : String;
  n, Len, i : Integer;
  Buf       : PChar;
  Value     : PChar;
begin
  S := Application.ExeName;
  n := GetFileVersionInfoSize(PChar(S),n);
  if n > 0 then begin
    Buf := AllocMem(n);
    Memo1.Lines.Add('FileVersionInfoSize='+IntToStr(n));
    GetFileVersionInfo(PChar(S),0,   Topic#   Getting Program Version Information   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               n,Buf);
    for i:=1 to InfoNum do
      if VerQueryValue(Buf,PChar('StringFileInfo\040904E4\'+
                                 InfoStr[i]),Pointer(Value),Len) then
        Memo1.Lines.Add(InfoStr[i]+'='+Value);
    FreeMem(Buf,n);
  end else
    Memo1.Lines.Add('No FileVersionInfo found');
end;

{Borland TI}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             procedure TurnSysKeysOff;
var
  Dummy : LongInt;
begin
  SystemParamersInfo(97, Word (True), @Dummy, 0);
end;

procedure TurnSysKeysOn;
var
  Dummy : LongInt;
begin
  SystemParamersInfo(97, Word (False), @Dummy, 0);
end;

{Tips from Meikel Weber}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             Topic   Disabling System Keys   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             {Under Win32, unless you are running from a removable drive, you cannot delete
a running executable. You can have Windows delete the executable the next time
Windows is run by adding an entry to the RunOnce key in the Window registry under:

 HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\RunOnce

You can name the key anything you like, and specify a command line to
another executable or to a dos command made passed to command.com.}

uses
  Registry;

procedure TForm1.Button1Click(Sender: TObject);
var
  reg: TRegistry;
begin
  reg := TRegistry.Create;
  reg.RootKey := HKEY_LOCAL_MACHINE;
  reg.LazyWrite := false;
  reg.OpenKey('Software\Microsoft\Windows\CurrentVersion\RunOnce',
              false);
  reg.WriteString('Delete Me!','command.com /c del FILENAME.EXT');
  reg.CloseKey;
  reg.free;
end;

{coded by Joe C. Hecht}
                                                                                                                                                      Topic   Using the RunOnce Registry Key   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    {To capture the escape key across an entire application, try}

 unit EscapeKey;

 interface

 uses
   SysUtils, WinTypes, WinProcs, Messages, Classes, Graphics, Controls,
   Forms, Dialogs, StdCtrls;

 type
   TFrmEscapeKey = class(TForm)
     Edit1: TEdit;
     Edit2: TEdit;
     Edit3: TEdit;
     Edit4: TEdit;
     Memo1: TMemo;
     Button1: TButton;
     procedure FormCreate(Sender: TObject);
   private { Private-Deklarationen }
     procedure AppMessage(var Msg: TMsg; var Handled: Boolean);
   public { Public-Deklarationen }
   end;

 var
   FrmEscapeKey: TFrmEscapeKey;

 implementation

 {$R *.DFM}

 procedure TFrmEscapeKey.AppMessage(var Msg: TMsg; var Handled: Boolean);
 begin
   if Msg.Message = WM_KEYDOWN then
     if Msg.wParam = VK_ESCAPE then begin
       Application.Terminate;
       Handled := true
     end;
 end;

 procedure TFrmEscapeKey.FormCreate(Sender: TObject);
 begin
   Application.OnMessage := AppMessage;
 end;

 end.

{Ralph (TeamB)}

   Topic#   Trapping Application Global HotKeys   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              {************************************************************
 * Procedure PostKeyEx
 *
 * Parameters:
 *  hWindow: target window to be sent the keystroke
 *  key    : virtual keycode of the key to send. For printable
 *           keys this is simply the ANSI code (Ord(character)).
 *  shift  : state of the modifier keys. This is a set, so you
 *           can set several of these keys (shift, control, alt,
 *           mouse buttons) in tandem. The TShiftState type is 
 *           declared in the Classes Unit.
 *  specialkey: normally this should be False. Set it to True to 
 *           specify a key on the numeric keypad, for example. 
 *           If this parameter is true, bit 24 of the lparam for
 *           the posted WM_KEY* messages will be set. 
 * Description:
 *  This procedure sets up Windows key state array to correctly
 *  reflect the requested pattern of modifier keys and then posts
 *  a WM_KEYDOWN/WM_KEYUP message pair to the target window. Then
 *  Application.ProcessMe   Topic$   Sending Keystrokes to an Application   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ssages is called to process the messages
 *  before the keyboard state is restored.
 * Error Conditions:
 *  May fail due to lack of memory for the two key state buffers.
 *  Will raise an exception in this case.
 * NOTE:
 *  Setting the keyboard state will not work across applications 
 *  running in different memory spaces on Windows NT! The routine
 *  has not been tested on Windows 95!
 *
 *Created: 02/21/96 16:39:00 by P. Below
 ************************************************************}
Procedure PostKeyEx( hWindow: HWnd; key: Word; Const shift: TShiftState;
                     specialkey: Boolean );
Type
  TBuffers = Array [0..1] of TKeyboardState;
Var
  pKeyBuffers : ^TBuffers;
  lparam: LongInt;
Begin
  (* check if the target window exists *)
  If IsWindow(hWindow) Then Begin
    (* set local variables to default values *)
    pKeyBuffers := Nil;
    lparam := MakeLong(0, VKKeyScan(key));

    (* modify lparam if special key requested *)
    If specialkey Then
      lparam := lparam or $1000000;

    (* allocate space for the key state buffers *)
    New(pKeyBuffers);
    try
      (* Fill buffer 1 with current state so we can later restore it.  
         Null out buffer 0 to get a "no key pressed" state. *)
      GetKeyboardState( pKeyBuffers^[1] );
      FillChar(pKeyBuffers^[0], Sizeof(TKeyboardState), 0);

      (* set the requested modifier keys to "down" state in the buffer *)
      If ssShift In shift Then
        pKeyBuffers^[0][VK_SHIFT] := $80;
      If ssAlt In shift Then Begin
        (* Alt needs special treatment since a bit in lparam needs also be set *)
        pKeyBuffers^[0][VK_MENU] := $80;
        lparam := lparam or $20000000;
      End;
      If ssCtrl In shift Then
        pKeyBuffers^[0][VK_CONTROL] := $80;
      If ssLeft In shift Then
        pKeyBuffers^[0][VK_LBUTTON] := $80;
      If ssRight In shift Then
        pKeyBuffers^[0][VK_RBUTTON] := $80;
      If ssMiddle In shift Then
        pKeyBuffers^[0][VK_MBUTTON] := $80;

      (* make out new key state array the active key state map *)
      SetKeyboardState( pKeyBuffers^[0] );

      (* post the key messages *)
      If ssAlt In Shift Then Begin
        PostMessage( hWindow, WM_SYSKEYDOWN, key, lparam);
        PostMessage( hWindow, WM_SYSKEYUP, key, lparam or $C0000000);
      End
      Else Begin
        PostMessage( hWindow, WM_KEYDOWN, key, lparam);
        PostMessage( hWindow, WM_KEYUP, key, lparam or $C0000000);
      End;
      (* process the messages *)
      Application.ProcessMessages;

      (* restore the old key state map *)
      SetKeyboardState( pKeyBuffers^[1] );
    finally
      (* free the memory for the key state buffers *)
      If pKeyBuffers <> Nil Then
        Dispose( pKeyBuffers );
    End; { If }
  End;
End; { PostKeyEx }

{coded by Peter Below (TeamB) }
                                                                                                                                                                   {there are several approaches to preventing multiple instances of an
 application.  The one I favour is the following: make sure your main
 form has a unique name that is unlikely to crop up an any other
 application. Then on your projects DPR file, before any of your
 forms is created, you do a }

  If FindWindow( Pchar(TMyMainform.Classname), Nil ) Then
    Exit;
    
{This prevents the second instance from ever coming up. If you have the 
additional goal of activating the first instance, use a slightly different 
approach:}

  hPrevWindow := FindWindow( Pchar(TMyMainform.Classname), Nil );
  If hPrevWindow <> 0 Then Begin
    PostMessage( hPrevWindow, UM_ACTIVATEFIRSTINSTANCE, 0, 0 );
    Exit;
  End;  
  
{UM_ACTIVATEFIRSTINSTANCE is a constant (WM_USER + something) you define in 
the interface section of your main forms unit. The main form also gets a 
handler for this message:}

  private
    Procedure UMActivateFirstInstance( Var msg: TMessage );
      message UM_ACTIVATEFIRSTI   Topic/   Preventing Multiple Instances of an Application   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   NSTANCE;
      
{implemented as}

 Procedure TMyMainform.UMActivateFirstInstance( Var msg: TMessage );
 Begin
   If IsIconic(Application.Handle) Then
     Application.restore;
   BringTofront;  
 End;  
 
{That's all there is to it. }

{Peter Below (TeamB)}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                procedure TForm1.FormCreate(Sender: TObject);
begin
  ShowWindow(Application.Handle, SW_HIDE);
  SetWindowLong(Application.Handle, GWL_EXSTYLE,
                etWindowLong(Application.Handle, GWL_EXSTYLE) or
                WS_EX_TOOLWINDOW );
  ShowWindow( Application.Handle, SW_SHOW );
end;
{submitted by Deepak Shenoy}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      Topic   Remove App from Task Bar   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          uses shellapi ; // don't forget

function getnumoficons(a:tfilename):integer;
begin
  // get the count of icons in the in "a" specified file
  result := extracticon(hinstance,pchar(a),-1);
end;

function getfileicon(a:tfilename;index:integer):integer;
begin
  // get the index'st icon from the given filename
  result := -1;
  if getnumoficons(a) > index then // check range
   result := extracticon(hinstance,pchar(a),index);
end;

// extracts a file-icon to a tbitmap (allows stretching, a ticon cannot be drawn stretched)
procedure getbitmapfromfileicon(a:tfilename;index:integer;var bmp:tbitmap);
var icon : ticon;
 ix   : integer;
begin
     ix:= getfileicon(a,index);
  if ix > -1 then try
  icon := ticon.create;
  icon.handle := ix;
  bmp.width := icon.width;
  bmp.height := icon.height;
  bmp.canvas.draw(0,0,icon);
  finally
    icon.free;
  end;
end;
                                                                                                                                    Topic   Extracting an Icon from a File   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    procedure GetBuildInfo(var V1, V2, V3, V4: Word);
var
  VerInfoSize: DWORD;
  VerInfo: Pointer;
  VerValueSize: DWORD;
  VerValue: PVSFixedFileInfo;
  Dummy: DWORD;
begin
  VerInfoSize := GetFileVersionInfoSize(PChar(ParamStr(0)), Dummy);
  if VerInfoSize = 0 then begin
    Dummy := GetLastError;
    ShowMessage(IntToStr(Dummy));
  end; {if}
  GetMem(VerInfo, VerInfoSize);
  GetFileVersionInfo(PChar(ParamStr(0)), 0, VerInfoSize, VerInfo);
  VerQueryValue(VerInfo, '\', Pointer(VerValue), VerValueSize);
  with VerValue^ do begin
    V1 := dwFileVersionMS shr 16;
    V2 := dwFileVersionMS and $FFFF;
    V3 := dwFileVersionLS shr 16;
    V4 := dwFileVersionLS and $FFFF;
  end;
  FreeMem(VerInfo, VerInfoSize);
end;

{coded by Steve Schafer (TeamB)}                                                                                                                                                                                                                                                         Topic$   Extracting Version Build Information   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              {ShellExecute spawns a process asynchronously.  It's as designed that your app
doesn't "wait on" the ShellExecute call for the called app to terminate.

Here's a 32-bit version of "WinExecAndWait":}

function WinExecAndWait32(FileName: string; Visibility: integer): integer;
 { returns -1 if the Exec failed, otherwise returns the process' exit
   code when the process terminates }
var
  zAppName: array[0..512] of char;
  zCurDir: array[0..255] of char;
  WorkDir: string;
  StartupInfo: TStartupInfo;
  ProcessInfo: TProcessInformation;
begin
  StrPCopy(zAppName, FileName);
  GetDir(0, WorkDir);
  StrPCopy(zCurDir, WorkDir);
  FillChar(StartupInfo, Sizeof(StartupInfo), #0);
  StartupInfo.cb := Sizeof(StartupInfo);
  StartupInfo.dwFlags := STARTF_USESHOWWINDOW;
  StartupInfo.wShowWindow := Visibility;
  if not CreateProcess(nil,
    zAppName, { pointer to command line string }
    nil, { pointer to process security attributes }
    nil, { pointer to thread security attributes }
    False   Topic)   Execute a Program and Wait for Completion   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         , { handle inheritance flag }
    CREATE_NEW_CONSOLE or { creation flags }
    NORMAL_PRIORITY_CLASS,
    nil, { pointer to new environment block }
    nil, { pointer to current directory name }
    StartupInfo, { pointer to STARTUPINFO }
    ProcessInfo) then { pointer to PROCESS_INF }
    Result := -1
  else
  begin
    WaitforSingleObject(ProcessInfo.hProcess, INFINITE);
    GetExitCodeProcess(ProcessInfo.hProcess, Result);
    CloseHandle(ProcessInfo.hProcess);
    CloseHandle(ProcessInfo.hThread);
  end;
end;

{OR}

function WinExecAndWait32(FileName: string; Visibility: integer): integer;
 { returns -1 if the Exec failed, otherwise returns the process' exit
   code when the process terminates }
var
  zAppName: array[0..512] of char;
  lpCommandLine: array[0..512] of char;
  zCurDir: array[0..255] of char;
  WorkDir: string;
  StartupInfo: TStartupInfo;
  ProcessInfo: TProcessInformation;
begin
  StrPCopy(zAppName, '');
  StrPCopy(lpCommandLine, FileName);
  GetDir(0, WorkDir);
  StrPCopy(zCurDir, WorkDir);
  FillChar(StartupInfo, Sizeof(StartupInfo), #0);
  StartupInfo.cb := Sizeof(StartupInfo);

  StartupInfo.dwFlags := STARTF_USESHOWWINDOW;
  StartupInfo.wShowWindow := Visibility;
  if not CreateProcess(
    nil, { pointer to command line string }
    lpCommandLine,
    nil, { pointer to process security attributes }
    nil, { pointer to thread security attributes}
    False, { handle inheritance flag }
    CREATE_NEW_CONSOLE or { creation flags }
    NORMAL_PRIORITY_CLASS,
    nil, { pointer to new environment block}
    nil, { pointer to current directory name }
    StartupInfo, { pointer to STARTUPINFO }
    ProcessInfo) then Result := -1 { pointer to PROCESS_INF }
  else begin
    WaitforSingleObject(ProcessInfo.hProcess, INFINITE);
    GetExitCodeProcess(ProcessInfo.hProcess, Result);
    CloseHandle(ProcessInfo.hProcess);
    CloseHandle(ProcessInfo.hThread);
  end;
end;                                                                         {To display a help file in an application }

procedure TMainForm.References1Click(Sender: TObject);
begin
  Application.HelpContext(11);
end;

{or}

procedure TMainForm.Helpwiththisprogram1Click(Sender: TObject);
begin
    Application.HelpCommand(HELP_CONTENTS,0);
end;

{The first calls a specific help context, the second, the contents
page. Please read the online help for full details on these 2 methods.}

{coded by Steve F (Team B)}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          Topic   Displaying a Help File   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            {Save this in Minimal.DPR, open with Delphi, & pick Run button.  I've
only tested this with D2, so if it doesn't work in D3 do let us know.}

    program Minimal; {$APPTYPE CONSOLE}

    procedure Main;
    begin
      WriteLn('Hello, World');
      ReadLn;
    end;
    
    begin 
      Main; 
    end.

{coded by Tony Olekshy}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      k   B a r     0  M  �R e m o v e   A p p   f r o m   T a s k   B a r    1  :   �E x t r a c t i n g   a n   I c o n   f r o m   a   F i l e     2    �E x t r a c t i n g   a n   I c o n   f r o m   a   F i l e    3  @   $�E x t r a c t i n g   V e r s i o n   B u i l d   I n f o r m a t i o n     4  
  $�E x t r a c t i n g   V e r s i o n   B u i l d   I n f o r m a t i o n    5  F   )�E x e c u t e   a   P r o g r a m   a n d   W a i t   f o r   C o m p l e t i o n     6  �  )�E x e c u t e   a   P r o g r a m   a n d   W a i t   f o r   C o m p l e t i o n    7  K   �D i s p l a y i n g   a   H e l p   F i l e     :  �  �D i s p l a y i n g   a   H e l p   F i l e    ;  8   �C r e a t i n g   a   C o n s o l e   A p p l i c a t i o n     <  Z  �C r e a t i n g   a   C o n s o l e   A p p l i c a t i o n    >  @   +�C o n t r o l l i n g   t h e   S i z e   o f   A n o t h e r   A p p l i c a t i o n     ?  )  +�C o n t r o l l i n g   t h e   S i z e   o f   A n o t h e r    Topic   Creating a Console Application   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    {the following code places notepad directly underneath the running
application:}

var
  hw: HWND;
  wp: TWindowPlacement;
begin
  hw := FindWindow('Notepad', nil);
  if hw <> 0 then
    GetWindowPlacement(Handle, @wp);
  SetWindowPlacement(hw, @wp);
end;

{Xavier Pacheco (TeamB)}

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          Topic+   Controlling the Size of Another Application   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        Setting a Windows System Hook    C  7   Setting a Windows System Hook   D  ?    Setting a Window Hook    L  �   Setting a Window Hook   M  7    Setting up a Keyboard Hook    N  D"   Setting up a Keyboard Hook   O  <                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          Topic   Hooks                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              {A DLL is necessary for a system hook.  The sample code below, 
was found somewhere in dejanews.  The first file shows the code
for a simple hook that would be placed in the dll.  Next, a unit
is shown  that provides basic interface to import the dll  The
remaining comments are from the original author}

{This is the core of the system and task hook.  Some notes:             
                                                                         
  1)  You will definitely want to give the file a more descriptive name  
      to avoid possible collisions with other DLL names.                 
  2)  Edit the MouseHookCallBack function to do what you need when a     
      mouse message is received.  If you are hooking something other     
      mouse messages, see the SetWindowsHookEx topic in the help for the 
      proper WH_xxxx constant, and any notes about the particular type   
      of hook.                                                           
  3)  If an application that uses the    Topic   Setting a Windows System Hook   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     DLL crashes while the hook is      
      installed, all manner of wierd things can happen, depending on the 
      sort of thing you are doing in the callback.  The best suggestion  
      is to use a utility that displays loaded DLLs and forcibly unload  
      the DLL.  You could also write a simple app that checks to see if  
      the DLL is loaded, and if so, call FreeModule until it returns 0.  
  4)  If you make changes to the DLL but the changes don't seem to be    
      working, you may have the DLL already loaded in memory.  Remember, 
      loading a DLL that is already in memory just increments a usage    
      count in Windows and uses the already loaded copy.                 
  5)  Remember when you are hooking in at the *system* level, your       
      callback function is being called for everything in the OS.  Try   
      to keep the processing in the callback as tight and fast as you    
      possibly can.                                                      
  6)  Be careful of the uses clause.  If you include stuff like Dialogs, 
      you will end up linking in a lot of the VCL, and have a DLL that   
      comes out compiled to around 250k.  You would probably be better   
      served using WM_USER messages to communicate with the application. 
  7)  I have successfully hooked mouse messages without the use of a     
      DLL, but many of the hooks say they require the callback to be in  
      a DLL, so I am hesitant to include this method.  It certainly      
      makes the build/test cycle *much* easier, but since it is not      
      "sanctioned" by MS, I would stay away from it and discourage it.}

library HookDLL;

uses WinTypes, WinProcs, Messages;
var
  HookCount: integer;
  HookHandle: HHook;

{$IFDEF WIN32}
function MouseHookCallBack(Code: integer; Msg: WPARAM; 
                           MouseHook: LPARAM): LRESULT; stdcall;
{$ELSE}
function MouseHookCallBack(Code: integer; Msg: word; 
                           MouseHook: longint): longint; export;
{$ENDIF}
begin
  { If the value of Code is less than 0, we are not allowed to do anything 
    except pass it on to the next hook procedure immediately. }
  if Code >= 0 then begin
    { This example does nothing except beep when the right mouse button is pressed. }
    if Msg = WM_RBUTTONDOWN then
      MessageBeep(1);

    { If you handled the situation, and don't want Windows to process the 
      message, do *NOT* execute the next line.  Be very sure this is what 
      want, though.  If you don't pass on stuff like WM_MOUSEMOVE, you    
      will NOT like the results you get.                                  }
    Result := CallNextHookEx(HookHandle, Code, Msg, MouseHook);
  end else
    Result := CallNextHookEx(HookHandle, Code, Msg, MouseHook);
end;

{ Call InstallHook to set the hook. }
function InstallHook(SystemHook: boolean; TaskHandle: THandle) : boolean; export;
{This is really silly, but that's the way it goes.  The only way to get the  
 module handle, *not* instance, is from the filename.  The Microsoft example
 just hard-codes the DLL filename.  I think this is a little bit better. }
  function GetModuleHandleFromInstance: THandle;
  var
    s: array[0..512] of char;
  begin
    { Find the DLL filename from the instance value. }
    GetModuleFileName(hInstance, s, sizeof(s)-1);
    { Find the handle from the filename. }
    Result := GetModuleHandle(s);
  end;
begin
 { Technically, this procedure could do nothing but call SetWindowsHookEx(), 
   but it is probably better to be sure about things, and not set the hook    
   more than once.  You definitely don't want your callback being called more 
   than once per message, do you?                                             }
  Result := TRUE;
  if HookCount = 0 then begin
    if SystemHook then
      HookHandle := SetWindowsHookEx(WH_MOUSE, MouseHookCallBack,HInstance, 0)
    else
    { See the Microsoft KnowledgeBase, PSS ID Number: Q92659, for a discussion of 
      the Windows bug that requires GetModuleHandle() to be used.                 }
      HookHandle := SetWindowsHookEx(WH_MOUSE, MouseHookCallBack,
                                     GetModuleHandleFromInstance,TaskHandle);
    if HookHandle <> 0 then
      inc(HookCount)
    else
      Result := FALSE;
  end else
    inc(HookCount);
end;

{ Call RemoveHook to remove the system hook. }
function RemoveHook: boolean; export;
begin
  { See if our reference count is down to 0, and if so then unhook. }
  Result := FALSE;
  if HookCount < 1 then exit;
  Result := TRUE;
  dec(HookCount);
  if HookCount = 0 then
    Result := UnhookWindowsHookEx(HookHandle);
end;

{ Have we hooked into the system? }
function IsHookSet: boolean; export;
begin
  Result := (HookCount > 0) and (HookHandle <> 0);
end;

exports
  InstallHook,
  RemoveHook,
  IsHookSet,
  MouseHookCallBack;

{ Initialize DLL data. }
begin
  HookCount := 0;
  HookHandle := 0;
end.

(* Then have this importation unit: *)

{ This is a simple DLL import unit to give us access to the functions in
  the HOOKDLL.PAS file.  This is the unit your project will use.}
unit Hookunit;

interface

uses WinTypes;

function InstallSystemHook: boolean;
function InstallTaskHook: boolean;
function RemoveHook: boolean;
function IsHookSet: boolean;
{ Do not use InstallHook directly.  Use InstallSystemHook or InstallTaskHook. }
function InstallHook(SystemHook: boolean; TaskHandle: THandle): boolean;

implementation

uses WinProcs;

const
  HOOK_DLL = 'HOOKDLL.DLL';

function InstallHook(SystemHook: boolean; 
                     TaskHandle: THandle): boolean; external HOOK_DLL;
function RemoveHook: boolean; external HOOK_DLL;
function IsHookSet: boolean; external HOOK_DLL;

function InstallSystemHook: boolean;
begin
  InstallHook(TRUE, 0);
end;

function InstallTaskHook: boolean;
begin
  InstallHook(FALSE,
              {$IFDEF WIN32}
                GetCurrentThreadID
              {$ELSE}
                GetCurrentTask
              {$ENDIF}
             ); 
end;

end.
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         {This code is a bit specific, but shows the ideas of finding a
 window handle and hooking a procedure into it }

procedure SetMessageTrappingHook; stdcall;
var
  TheHandle : HWND;
  TheThread : DWORD;
begin
  TheHandle := FindWindow('Whatever',NIL);
  if TheHandle <> 0 then begin
    TheThread := GetWindowThreadProcessId(TheHandle,NIL);
    HookProcHandle := SetWindowsHookEx(WH_CALLWNDPROC,@CallWndProc,
                                       HInstance,TheThread);
    if HookProcHandle <> 0 then
       NewMessages:=0;
    else
      ShowMessage('Setting Hook Failed.');
  end else
    showmessage('Icon Author is not currently running.');
end;

{Code provided by Michael}                                                                                                                                                                                                                                                                                                                                          Topic   Setting a Window Hook   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             {Hooking the keyboard}

library Sendkey;

uses
 SysUtils, WinTypes, WinProcs, Messages, Classes, KeyDefs;

type
  { Error codes }
  TSendKeyError = (sk_None, sk_FailSetHook, sk_InvalidToken, sk_UnknownError);

  { exceptions }
  ESendKeyError = class(Exception);
  ESetHookError = class(ESendKeyError);
  EInvalidToken = class(ESendKeyError);

  { a TList descendant that know how to dispose of its contents }
  TMessageList = class(TList)
  public
    destructor Destroy; override;
  end;

destructor TMessageList.Destroy;
var
  i: longint;
begin
  { deallocate all the message records before discarding the list }
  for i := 0 to Count - 1 do
    Dispose(PEventMsg(Items[i]));
  inherited Destroy;
end;

var
  { variables global to the DLL }
  MsgCount: word;
  MessageBuffer: TEventMsg;
  HookHandle: hHook;
  Playing: Boolean;
  MessageList: TMessageList;
  AltPressed, ControlPressed, ShiftPressed: Boolean;
  NextSpecialKey: TKeyString;

function MakeWord(L, H: Byte): Word;
   Topic   Setting up a Keyboard Hook   Language   P                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        { macro creates a word from low and high bytes }
inline(
  $5A/            { pop dx }
  $58/            { pop ax }
  $8A/$E2);       { mov ah, dl }

procedure StopPlayback;
{ Unhook the hook, and clean up }
begin
  { if Hook is currently active, then unplug it }
  if Playing then
    UnhookWindowsHookEx(HookHandle);
  MessageList.Free;
  Playing := False;
end;

function Play(Code: integer; wParam: word; lParam: Longint): Longint; export;
{This is the JournalPlayback callback function.  It is called by Windows
 when Windows polls for hardware events.  The code parameter indicates what 
 to do. }
begin
  case Code of

    hc_Skip: begin
    { hc_Skip means to pull the next message out of our list. If we 
      are at the end of the list, it's okay to unhook the JournalPlayback 
      hook from here. }
      { increment message counter }
      inc(MsgCount);
      { check to see if all messages have been played }
      if MsgCount >= MessageList.Count then
        StopPlayback
      else
      { copy next message from list into buffer }
      MessageBuffer := TEventMsg(MessageList.Items[MsgCount]^);
      Result := 0;
    end;

    hc_GetNext: begin
    { hc_GetNext means to fill the wParam and lParam with the proper 
      values so that the message can be played back.  DO NOT unhook 
      hook from within here.  Return value indicates how much time until 
      Windows should playback message.  We'll return 0 so that it's 
      processed right away. }
      { move message in buffer to message queue }
      PEventMsg(lParam)^ := MessageBuffer;
      Result := 0  { process immediately }
    end

    else
      { if Code isn't hc_Skip or hc_GetNext, then call next hook in chain }
      Result := CallNextHookEx(HookHandle, Code, wParam, lParam);
  end;
end;

procedure StartPlayback;
{ Initializes globals and sets the hook }
begin
  { grab first message from list and place in buffer in case we 
    get a hc_GetNext before and hc_Skip }
  MessageBuffer := TEventMsg(MessageList.Items[0]^);
  { initialize message count and play indicator }
  MsgCount := 0;
  { initialize Alt, Control, and Shift key flags }
  AltPressed := False;
  ControlPressed := False;
  ShiftPressed := False;
  { set the hook! }
  HookHandle := SetWindowsHookEx(wh_JournalPlayback, Play, hInstance, 0);
  if HookHandle = 0 then
    raise ESetHookError.Create('Couldn''t set hook')
  else
    Playing := True;
end;

procedure MakeMessage(vKey: byte; M: word);
{ procedure builds a TEventMsg record that emulates a keystroke and 
  adds it to message list }
var
  E: PEventMsg;
begin
  New(E);                                 { allocate a message record }
  with E^ do begin
    Message := M;                         { set message field }
    { high byte of ParamL is the vk code, low byte is the scan code }
    ParamL := MakeWord(vKey, MapVirtualKey(vKey, 0));
    ParamH := 1;                          { repeat count is 1 }
    Time := GetTickCount;                 { set time }
  end;
  MessageList.Add(E);
end;

procedure KeyDown(vKey: byte);
{ Generates KeyDownMessage }
begin
  { don't generate a "sys" key if the control key is pressed (Windows quirk) }
  if (AltPressed and (not ControlPressed) and (vKey in [Ord('A')..Ord('Z')])) or
     (vKey = vk_Menu) then
    MakeMessage(vKey, wm_SysKeyDown)
  else
    MakeMessage(vKey, wm_KeyDown);
end;

procedure KeyUp(vKey: byte);
{ Generates KeyUp message }
begin
  { don't generate a "sys" key if the control key is pressed (Windows quirk) }
  if AltPressed and (not ControlPressed) and (vKey in [Ord('A')..Ord('Z')]) then
    MakeMessage(vKey, wm_SysKeyUp)
  else
    MakeMessage(vKey, wm_KeyUp);
end;

procedure SimKeyPresses(VKeyCode: Word);
{ This function simulates keypresses for the given key, taking into 
  account the current state of Alt, Control, and Shift keys }
begin
  { press Alt key if flag has been set }
  if AltPressed then
    KeyDown(vk_Menu);
  { press Control key if flag has been set }
  if ControlPressed then
    KeyDown(vk_Control);
  { if shift is pressed, or shifted key and control is not pressed... }
  if (((Hi(VKeyCode) and 1) <> 0) and (not ControlPressed)) or ShiftPressed then
    KeyDown(vk_Shift);    { ...press shift }
  KeyDown(Lo(VKeyCode));  { press key down }
  KeyUp(Lo(VKeyCode));    { release key }
  { if shift is pressed, or shifted key and control is not pressed... }
  if (((Hi(VKeyCode) and 1) <> 0) and (not ControlPressed)) or ShiftPressed then
    KeyUp(vk_Shift);      { ...release shift }
  { if shift flag is set, reset flag }
  if ShiftPressed then begin
    ShiftPressed := False;
  end;
  { Release Control key if flag has been set, reset flag }
  if ControlPressed then begin
    KeyUp(vk_Control);
    ControlPressed := False;
  end;
  { Release Alt key if flag has been set, reset flag }
  if AltPressed then begin
    KeyUp(vk_Menu);
    AltPressed := False;
  end;
end;

procedure ProcessKey(S: String);
{ This function parses each character in the string to create the message list }
var
  KeyCode: word;
  Key: byte;
  index: integer;
  Token: TKeyString;
begin
  index := 1;
  repeat
    case S[index] of

      KeyGroupOpen : begin
      { It's the beginning of a special token! }
        Token := '';
        inc(index);
        while S[index] <> KeyGroupClose do begin
          { add to Token until the end token symbol is encountered }
          Token := Token + S[index];
          inc(index);
          { check to make sure the token's not too long }
          if (Length(Token) = 7) and (S[index] <> KeyGroupClose) then
            raise EInvalidToken.Create('No closing brace');
        end;
        { look for token in array, Key parameter will 
          contain vk code if successful }
        if not FindKeyInArray(Token, Key) then
          raise EInvalidToken.Create('Invalid token');
        { simulate keypress sequence }
        SimKeyPresses(MakeWord(Key, 0));
      end;

      AltKey : AltPressed := True; { set Alt flag }
      ControlKey : ControlPressed := True; { set Alt flag }

      ShiftKey : ShiftPressed := True; { set Alt flag }

      else begin
        {A normal character was pressed convert character into 
         a word where the high byte contains the shift state
         and the low byte contains the vk code }
        KeyCode := vkKeyScan(MakeWord(Byte(S[index]), 0));
        { simulate keypress sequence }
        SimKeyPresses(KeyCode);
      end;
    end;
    inc(index);
  until index > Length(S);
end;

function SendKeys(S: String): TSendKeyError; export;
{This is the one entry point.  Based on the string passed in the S  
 parameter, this function creates a list of keyup/keydown messages, 
 sets a JournalPlayback hook, and replays the keystroke messages.}
var
  i: byte;
begin
  try
    Result := sk_None;                   { assume success }
    MessageList := TMessageList.Create;  { create list of messages }
    ProcessKey(S);                       { create messages from string}
    StartPlayback;                       { set hook and play back messages }
  except
    { if an exception occurs, return an error code, and clean up }
    on E:ESendKeyError do begin
      MessageList.Free;
      if E is ESetHookError then
        Result := sk_FailSetHook
      else if E is EInvalidToken then
        Result := sk_InvalidToken;
    end else
      {Catch-all exception handler ensures than an exception 
       doesn't walk up into application stack }
      Result := sk_UnknownError;
  end;
end;

exports
  SendKeys index 1;

begin
end
                                                                                                                                                                                                                                                                                                                                                                                                                                                            �F P C    Y     �F i n d I n P r o c e s s e s       �
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  �D e f i n e s     Z  �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      Possible defines when compiling using FPC

         Define 	                Description
         --------------------------------------------------------------------------------
         FPC_LINK_DYNAMIC 	Defined when the output will be linked dynamically.
	                        This is defined when using the -XD compiler switch.
         FPC_LINK_STATIC 	Defined when the output will be linked statically.
	                        This is the default mode.
         FPC_LINK_SMART 	Defined when the output will be smartlinked.
	                        This is defined when using the -XX compiler switch.
         FPC_PROFILE 	        Defined when profiling code is added to program.
	                        This is defined when using the -pg compiler switch.
         FPC_CROSSCOMPILING	Defined when the target OS/CPU
	                        is different from the source OS/CPU.
         FPC 	                Always defined for Free Pascal.
         VER2 	                Always defined for Free Pascal version 2.x.x.
         VER2_0 	        Always defined for Free Pascal version 2.0.x.
         VER2_2 	        Always defined for Free Pascal version 2.2.x.
         FPC_VERSION 	        Contains the major version number from FPC.
         FPC_RELEASE 	        Contains the minor version number from FPC.
         FPC_PATCH 	        Contains the third part of the version number from FPC.
         FPC_FULLVERSION 	Contains the entire version number from FPC as a single
	                        number which can be used for comparing. For FPC 2.2.4 it
                                will contain 20204.
         ENDIAN_LITTLE 	        Defined when the Free Pascal target is a
                                little-endian processor (80x86, Alpha, ARM).
         ENDIAN_BIG 	        Defined when the Free Pascal target is a
                                big-endian processor (680x0, PowerPC, SPARC, MIPS).
         FPC_DELPHI 	        Free Pascal is in Delphi mode, either using compiler
                                switch -MDelphi or using the $MODE DELPHI directive.
         FPC_OBJFPC 	        Free Pascal is in OBJFPC mode, either using compiler
                                switch -Mobjfpc or using the $MODE OBJFPC directive.
         FPC_TP 	        Free Pascal is in Turbo Pascal mode, either using
                                compiler switch -Mtp or using the $MODE TP directive.
         FPC_GPC 	        Free Pascal is in GNU Pascal mode, either using compiler
                                switch -SP or using the $MODE GPC directive.

Possible CPU defines when compiling using FPC

        Define 	        When defined?
        ---------------------------------------------------------------------
        CPU86 	        target is an Intel 80x86 or compatible.
        CPU87 	        target is an Intel 80x86 or compatible.
        CPU386 	        target is an Intel 80386 or later.
        CPUI386 	target is an Intel 80386 or later.
        CPU68K 	        target is a Motorola 680x0 or compatible.
        CPUM68K 	target is a Motorola 680x0 or compatible.
        CPUM68020 	target is a Motorola 68020 or later.
        CPU68 	        target is a Motorola 680x0 or compatible.
        CPUSPARC32 	target is a SPARC v7 or compatible.
        CPUSPARC 	target is a SPARC v7 or compatible.
        CPUALPHA 	target is an Alpha AXP or compatible.
        CPUPOWERPC 	target is a 32-bit or 64-bit PowerPC or compatible.
        CPUPOWERPC32	target is a 32-bit PowerPC or compatible.
        CPUPOWERPC64	target is a 64-bit PowerPC or compatible.
        CPUX86_64 	target is a AMD64 or Intel 64-bit processor.
        CPUAMD64 	target is a AMD64 or Intel 64-bit processor.
        CPUIA64 	target is a Intel itanium 64-bit processor.
        CPUARM 	        target is an ARM 32-bit processor.
        CPUAVR 	        target is an AVR 16-bit processor.
        CPU16 	        target is a 16-bit CPU.
        CPU32 	        target is a 32-bit CPU.
        CPU64 	        target is a 64-bit CPU.

Possible FPU defines when compiling using FPC

        Define 	        When defined?
        ---------------------------------------------------------------------
        FPUSOFT 	Software emulation of FPU (all types).
        FPUSSE64 	SSE64 FPU on Intel I386 and higher, AMD64.
        FPUSSE 	        SSE instructions on Intel I386 and higher.
        FPUSSE2 	SSE 2 instructions on Intel I386 and higher.
        FPUSSE3 	SSE 3 instructions on Intel I386 and higher, AMD64.
        FPULIBGCC 	GCC library FPU emulation on ARM and M68K.
        FPU68881 	68881 on M68K.
        FPUFPA 	        FPA on ARM.
        FPUFPA10 	FPA 10 on ARM.
        FPUFPA11 	FPA 11 on ARM.
        FPUVFP 	        VFP on ARM.
        FPUX87 	        X87 FPU on Intel I386 and higher.
        FPUITANIUM 	On Intel Itanium.
        FPUSTANDARD	On PowerPC (32/64 bit).
        FPUHARD 	On Sparc.

        Target operating 	          Defines
        system
        ---------------------------------------------------------------------
        linux 	                          LINUX, UNIX
        freebsd 	                  FREEBSD, BSD, UNIX
        netbsd 	                          NETBSD, BSD, UNIX
        sunos 	                          SUNOS, SOLARIS, UNIX
        go32v2 	                          GO32V2, DPMI
        os2 	                          OS2
        emx 	                          OS2, EMX
        Windows (all) 	                  WINDOWS
        Windows 32-bit 	                  WIN32, MSWINDOWS
        Windows 64-bit 	                  WIN64, MSWINDOWS
        Windows (winCE) 	          WINCE, UNDER_CE, UNICODE
        Classic Amiga 	                  AMIGA
        Atari TOS 	                  ATARI
        Classic Macintosh 	          MAC
        PalmOS 	                          PALMOS
        BeOS 	                          BEOS, UNIX
        QNX RTP 	                  QNX, UNIX
        Mac OS X 	                  BSD, DARWIN, UNIX
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          �S e t u p   G i t   f o r   S o u r c e F o r g e       �  �A p p l y   P a t c h                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
                                                                   !  "  #  $  %  &  '  (  )  *  +  ,  -  .  /  0  1  2  3  4  5  6  7  8  9  :  ;  <  =  >  ?  @  A  B  C  D  E  F  G  H  I  J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z  [  \  ]  ^  _  `  a  b  c  d  e  f  g  h  i  j  k  l  m  n  o  p  q  r  s  t  u  v  w  x  y  z  {  |  }  ~    �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �               First time using Git

cd myproject
git init
# add all your files.  Use can use specific filenames or directories instead of '.'
git add .
git commit -a -m 'Initial commit'
git remote add origin ssh://evosi@git.code.sf.net/p/codelibrarian/code
git push origin master
git branch --set-upstream master origin/master  # so 'git pull' will work later

Existing repository using Git

cd myproject
git remote add origin ssh://evosi@git.code.sf.net/p/codelibrarian/code
git push origin master
git branch --set-upstream master origin/master  # so 'git pull' will work later

First time using Git

cd myproject
git init
# add all your files.  Use can use specific filenames or directories instead of '.'
git add .
git commit -a -m 'Initial commit'
git remote add origin ssh://evosi@git.code.sf.net/p/evsdotparser/code
git push origin master
git branch --set-upstream master origin/master  # so 'git pull' will work later

Existing repository using Git

cd myproject
git remote add origin ssh://evosi@gigit apply [PatchFileName]
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     �F r e e B S D   M a k e   c l i                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            make -DBATCH install clean
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    �M u l t i   C o l u m n   C o m b o B o x     	  ^  �S c r e e n   S h o t       �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      unit Unit1;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, FileUtil, Forms, Controls, Graphics, Dialogs, StdCtrls, types;

type

  { TForm1 }

  TForm1 = class(TForm)
    ComboBox1 : TComboBox;
    procedure ComboBox1DrawItem(Control : TWinControl; Index : Integer;
      ARect : TRect; State : TOwnerDrawState);
    procedure FormCreate(Sender : TObject);
  private
    { private declarations }
  public
    { public declarations }
  end;

var
  Form1 : TForm1;

implementation

{$R *.lfm}

{ TForm1 }

procedure TForm1.ComboBox1DrawItem(Control : TWinControl; Index : Integer;
  ARect : TRect; State : TOwnerDrawState);
var
  vPos  : Integer;
  vRect : TRect;
  vStr1, vStr2  : string;
begin
  ///
  vRect := ARect;
  vPos := Pos('|',ComboBox1.Items[Index]);
  if vPos>0 then begin
    vStr1 := Copy(ComboBox1.Items[Index],1,vPos-1);
    vStr2 := Copy(ComboBox1.Items[Index],vPos+1,Length(ComboBox1.Items[Index]));
  end else begin
    vStr1 := ComboBox1.Items[Index];
    vStr2 := '';
  end;
  ComboBox1.Canvas.FillRect(vRect);
  vRect.Left := vRect.Left + 3;
  combobox1.Canvas.TextRect(Rect(vRect.Left,vRect.Top,vRect.Left+70,vRect.Bottom),vRect.Left,vRect.Top,vStr1);
  if vStr2 <> '' then begin
    vRect.Left := vRect.Left+73;
    combobox1.Canvas.TextRect(vRect, vRect.Left,vRect.Top,vStr2);
  end;
end;

procedure TForm1.FormCreate(Sender : TObject);
begin
  ComboBox1.Style := csOwnerDrawFixed;
  ComboBox1.Items.Add('01.1 | 01.2');
  ComboBox1.Items.Add('02.1 | 02.2');
  ComboBox1.Items.Add('03.1 | 03.2');
  ComboBox1.Items.Add('04.1 | 04.2');
  ComboBox1.Items.Add('05.1 | 05.2');
  ComboBox1.Items.Add('06.1 | 06.2');
  ComboBox1.Items.Add('07.1 | 07.2');
  ComboBox1.Items.Add('08.1 | 08.2');
  ComboBox1.Items.Add('09.1 | 09.2');
  ComboBox1.Items.Add('10.1 | 10.2');
end;

end.

                                                                                                                                                                  {
Do not forget to set toAutoDeleteMoveNodes to False in TreeOptions.AutoOptions
The following events implementation will allow you to drag a single node and
re arange its position.
}

procedure TForm1.vt1DragAllowed(Sender: TBaseVirtualTree; Node: PVirtualNode; Column: TColumnIndex;
  var Allowed: Boolean);
begin
  Allowed := True;
end;

procedure TForm1.vt1DragOver(Sender: TBaseVirtualTree; Source: TObject; Shift: TShiftState;
  State: TDragState; Pt: TPoint; Mode: TDropMode; var Effect: Integer; var Accept: Boolean);
begin
  Accept := (Source = Sender);
end;

procedure TForm1.vt1DragDrop(Sender: TBaseVirtualTree; Source: TObject; DataObject: IDataObject;
  Formats: TFormatArray; Shift: TShiftState; Pt: TPoint; var Effect: Integer; Mode: TDropMode);
var
  pSource, pTarget: PVirtualNode;
  attMode: TVTNodeAttachMode;
begin
  pSource := TVirtualStringTree(Source).FocusedNode;
  pTarget := Sender.DropTargetNode;

  case Mode of
    dmNowhere: attMode := amNoWhere;
    dmAbove: attMode := amInsertBefore;
    dmOnNode, dmBelow: attMode := amInsertAfter;
  end;

  Sender.MoveTo(pSource, pTarget, attMode, False);

end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                procedure UpdateAlphaWindow(Wnd: HWND; Image: TGraphic;
  Canvas: TCanvas; Opacity: Byte = $FF);
var
  Blend: TBlendFunction;
  Rect: TRect;
  P1, P2: TPoint;
  S: TSize;
  DC: HDC;
begin
  if Image.Height = 0 then Exit;
  SetWindowLong(Wnd, GWL_EXSTYLE,
    GetWindowLong(Wnd, GWL_EXSTYLE) or WS_EX_LAYERED);
  GetWindowRect(Wnd, Rect);
  P1.X := Rect.Left;
  P1.Y := Rect.Top;
  with Blend do
  begin
    BlendOp := AC_SRC_OVER;
    BlendFlags := 0;
    SourceConstantAlpha := Opacity;
    AlphaFormat := AC_SRC_ALPHA;
  end;
  DC := GetDC(0);
  P2 := Point(0, 0);
  S.cx := Image.Width;
  S.cy := Image.Height;
  UpdateLayeredWindow(Wnd, DC, @P1, @S, Canvas.Handle,
    @P2, 0, @Blend, ULW_ALPHA);
  ReleaseDC(0, DC);
end;
Bit: byte): LongInt;
begin
  result := val xor (1 shl TheBit);
end;

end.

{code found in a Borland TI}
                                                                                                                                                            unit GBlur3;

interface

uses Windows, Graphics;

type
    PRGBTriple = ^TRGBTriple;
    TRGBTriple = packed record
      b, g, r: byte; //easier to type than rgbtBlue...
    end;

    PRow = ^TRow;
    TRow = array[0..1000000] of TRGBTriple;

    PPRows = ^TPRows;
    TPRows = array[0..1000000] of PRow;


const MaxKernelSize = 100;

type
  TKernelSize = 1..MaxKernelSize;

  TKernel = record
    Size: TKernelSize;
    Weights: array[-MaxKernelSize..MaxKernelSize] of single;
  end;
>
> //the idea is that when using a TKernel you ignore the Weights
> //except for Weights in the range -Size..Size.
>
procedure GBlur(theBitmap: TBitmap; radius: double);

implementation

uses
  SysUtils;

procedure MakeGaussianKernel(var K: TKernel; radius: double;
 MaxData, DataGranularity: double);
// makes K into a gaussian kernel with standard deviation = radius.
// for the current application you set MaxData = 255,
// DataGranularity = 1. Now the procedure sets the value of
// K.Size so that when we use K we will ignore the Weights
// that are so small they can't possibly matter. (Small Size
// is good because the execution time is going to be
// propertional to K.Size.)
var
  j: integer;
  temp, delta: double;
  KernelSize: TKernelSize;
begin
  for j:= Low(K.Weights) to High(K.Weights) do
  begin
    temp:= j/radius;
    K.Weights[j]:= exp(- temp*temp/2);
  end;

  // now divide by constant so sum(Weights) = 1:

  temp:= 0;
  for j:= Low(K.Weights) to High(K.Weights) do
    temp:= temp + K.Weights[j];

  for j:= Low(K.Weights) to High(K.Weights) do
    K.Weights[j]:= K.Weights[j] / temp;


  // now discard (or rather mark as ignorable by setting Size)
  // the entries that are too small to matter -
  // this is important, otherwise a blur with a small radius
  // will take as long as with a large radius...
  KernelSize:= MaxKernelSize;
  delta:= DataGranularity / (2*MaxData);
  temp:= 0;
  while (temp < delta) and (KernelSize > 1) do
  begin
    temp:= procedure SaveScreenShot(const aFilename:string);
var
  ScreenDC: HDC;
  SaveBitmap: TBitmap;
begin
  SaveBitmap := TBitmap.Create;
  try
    SaveBitmap.SetSize(Screen.Width, Screen.Height);
    ScreenDC := GetDC(0);
    try
      SaveBitmap.LoadFromDevice(ScreenDC);
    finally
      ReleaseDC(0, ScreenDC);
    end;
    SaveBitmap.SaveToFile(aFilename);
  finally
    SaveBitmap.Free;
  end;
end;

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           function QueryFullProcessImageName(hProcess: HANDLE; dwFlags: DWORD; var lpExeName: LPTSTR;
var lpdwSize: LPDWORD): BOOL; stdcall; external 'KERNEL32.dll';

//...

  function FindInProcesses(const PName: String): DWord;
  const ListSize = 1024;
  var
     PIDList: array[1..Listsize] of DWORD;
     cbNeeded, cbProcesses: DWORD;
     I: integer;
     hProcess: HWND;
     hMod: HMODULE;
     CurrentProcName: PChar;
     GotName: Boolean;
     STR_SIZE: DWORD;
  begin
       // Enumerate all processes on the system
       EnumProcesses(@PIDList, ListSize, cbNeeded);
       cbProcesses:= cbNeeded div SizeOf(DWORD);
       Writeln('cbProcesses is ' + IntToStr(cbProcesses));
       Result:= 0;
       for i:= 1 to cbProcesses do
       begin
            Write('Process ID ' + IntToStr(PIDList[i]) + ' is ');
            hProcess:= OpenProcess(PROCESS_QUERY_INFORMATION or PROCESS_VM_READ, FALSE, PIDList[i]);
            EnumProcessModules(hProcess, @hMod, SizeOf(hMod), cbNeeded);
            GetMem(CurrentProcName, 512);
            STR_SIZE:= 512;
            GotName:= QueryFullProcessImageName(hProcess, 0, CurrentProcName, @STR_SIZE);
            If CurrentProcName = '' then
               Writeln('Failed to get a process name')
            else
               Writeln(Trim(CurrentProcName) + '. ');
            CloseHandle(hProcess);
            If UpperCase(CurrentProcName) = UpperCase(PName) then
            { Found the name. Set Result to the PID of process found }
                 Result:= PIDList[i];
            FreeMem(CurrentProcName, 512);
       end; // For
  end; // FindInProcesses


  function FindInProcesses(const PName: String): DWord;
  var
     i: integer;
     CPID: DWORD;
     CProcName: Array[0..259] of Char;
     S: HANDLE;
     PE: TProcessEntry32;
  begin
       Result:= 0;
       CProcName:= '';
       // Create snapshot
       S:= CreateToolHelp32Snapshot(TH32CS_SNAPALL, 0);
       // Set size before use
       PE.DWSize:= SizeOf(PE);
       I:= 1;
       If Process32First(S, PE) then
       repeat
             CProcName:= PE.szExeFile;
             CPID:= PE.th32ProcessID;
             If CProcName = '' then
                Writeln(IntToStr(i) + ' - (' + IntToStr(CPID) + ') Failed to get a process name')
             else
                 Writeln(IntToStr(i) + ' - (' + IntToStr(CPID) + ') ' + Trim(CProcName) + '. ');
             Inc(i);
             If UpperCase(CProcName) = UpperCase(PName) then
                { Found the name. Set Result to the PID of process found }
                Result:= CPID;
       until not Process32Next(S, PE);
       CloseHandle(S);
  end; // FindInProcesses
                                                                                                                                                                                                                                                                                                                                                              �G e t   p r o c e s s   f u l l   p a t h       *  �I s   W i n d o w s   F i r e w a l l   A c t i v e       �   *�A d d   -   R e m o v e   E x c e p t i o n   T o   W i n d o w s   F i r e W a l l       �  '�A d d i n g   C u s t o m   f o l d e r s   t o   t h e   p l a c e s   b a r       G  =�D W O R D   v a l u e s   o f   s t a n d a r d   f o l d e r s   w h e n   a d d e d   t o   t h e   P l a c e s   B a r       �  "�L a y e r e d   w i n d o w s   w i t h   a l p h a   s h a d o w s       �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                function EnableDebugPrivileges: THandle;
var
  lpLuid               : TOKEN_PRIVILEGES;
  OldlpLuid            : TOKEN_PRIVILEGES;
  ReturnLength         : DWORD;
begin
  if OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES or TOKEN_QUERY, Result) then begin
    if not LookupPrivilegeValue(nil, 'SeDebugPrivilege', lpLuid.Privileges[0].Luid) then
      RaiseLastOSError
    else
    begin
      lpLuid.PrivilegeCount := 1;
      lpLuid.Privileges[0].Attributes  := SE_PRIVILEGE_ENABLED;
      ReturnLength := 0;
      OldlpLuid    := lpLuid;
      //Set the SeDebugPrivilege privilege
      if not AdjustTokenPrivileges(Result, False, lpLuid, SizeOf(OldlpLuid), OldlpLuid, ReturnLength) then
        RaiseLastOSError;
    end;
  end else
    RaiseLastOSError;
end;

function GetProcFullPathVista(ProcessId: Cardinal): string;
var
  ProcessIdInfo: SYSTEM_PROCESS_ID_INFORMATION;
begin
  Result := '';

  SetLength(Result, MAX_PATH);

  ProcessIdInfo.ProcessId := ProcessId;
  ProcessIdInfo.ImageName.Length := 0;
  ProcessIdInfo.ImageName.MaximumLength := MAX_PATH;
  ProcessIdInfo.ImageName.Buffer := @Result[1];

  NtQuerySystemInformation(88, @ProcessIdInfo, SizeOf(SYSTEM_PROCESS_ID_INFORMATION), nil);

  SetLength(Result, ProcessIdInfo.ImageName.Length div 2);
  Result := DevicePathToWin32Path(Result);
end;

function GetProcFullPathXP(ProcessId: Cardinal): string;
var
  ProcessName: array[0..MAX_PATH - 1] of WideChar;
  ProcessHandle: THandle;
  TokenHandle: THandle;
begin
  Result := '';
  TokenHandle := EnableDebugPrivileges;
  try
    ProcessHandle := OpenProcess(PROCESS_QUERY_INFORMATION, false, ProcessId);
    if (ProcessHandle = 0) or (ProcessHandle = INVALID_HANDLE_VALUE) then Exit;
    try
      if NtQueryInformationProcess(ProcessHandle, 27, @ProcessName[0], MAX_PATH, nil) = NT_STATUS_SUCCESS then
         Result := DevicePathToWin32Path(PUNICODE_STRING(@ProcessName[0])^.Buffer);
    finally
      CloseHandle(ProcessHandle);
    end;
  finally
    CloseHandle(TokenHandle);
  end;
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      o   A u t o - S c r o l l i n g     �   �   �M e m o   A u t o - S c r o l l i n g    �   5   �E d i t   C o n t r o l   U n d o     �   ;   �E d i t   C o n t r o l   U n d o    �   3   �L i s t b o x   H o r i z o n t a l   S c r o l l   B a r     �   �   �L i s t b o x   H o r i z o n t a l   S c r o l l   B a r    �   ?                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   uses activex, comobj;
....

function WindowsFirewallActive:Boolean;
var
  fwMAnager:OleVariant;
begin
  fwManager := CreateOLEObject('hnetcfg.fwmgr');
  Result := fwManager.LocalPolicy.CurrentProfile.FirewallEnabled;
end;


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    {
  AUTHOR : d4nn13 From lazarus forums.
}
uses  ComObj, ActiveX;

//...

const
  NET_FW_PROFILE2_DOMAIN  = 1;
  NET_FW_PROFILE2_PRIVATE = 2;
  NET_FW_PROFILE2_PUBLIC  = 4;
  NET_FW_IP_PROTOCOL_TCP = 6;
  NET_FW_IP_PROTOCOL_UDP = 17;
  NET_FW_ACTION_ALLOW    = 1;

//...

procedure AddProgramExceptionToFireWall(Const wsCaption, wsDescription, wsExecutable: WideString; iProtocol, iProfile:Integer);
var
  fwPolicy2                :  OleVariant;
  RulesObject              :  OleVariant;
  NewRule                  :  OleVariant;
begin
  fwPolicy2                := CreateOleObject('HNetCfg.FwPolicy2');
  RulesObject              := fwPolicy2.Rules;
  NewRule                  := CreateOleObject('HNetCfg.FWRule');
  NewRule.Name             := wsCaption;
  NewRule.Description      := wsDescription;
  NewRule.Applicationname  := wsExecutable;
  NewRule.Protocol         := iProtocol;
  NewRule.Enabled          := TRUE;
  NewRule.Profiles         := iProfile;
  NewRule.Action           := NET_FW_ACTION_ALLOW;
  RulesObject.Add(NewRule);
end;

procedure RemoveExceptionFromFW(Const exCaption: WideString);
var
  fwPolicy2      : OleVariant;
begin
  fwPolicy2      := CreateOleObject('HNetCfg.FwPolicy2');
  fwPolicy2.Rules.Remove(exCaption);
end;

Sample


  AddProgramExceptionToFireWall( Application.Title,Application.Title, Application.ExeName, NET_FW_IP_PROTOCOL_TCP, NET_FW_PROFILE2_DOMAIN or NET_FW_PROFILE2_PRIVATE or NET_FW_PROFILE2_PUBLIC);

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                temp + 2 * K.Weights[KernelSize];
    dec(KernelSize);
  end;

  K.Size:= KernelSize;

  // now just to be correct go back and jiggle again so the
  // sum of the entries we'll be using is exactly 1:
  temp:= 0;

  for j:= -K.Size to K.Size do
    temp:= temp + K.Weights[j];
  for j:= -K.Size to K.Size do
    K.Weights[j]:= K.Weights[j] / temp;
end;

  function TrimIntL(Lower, theInteger: integer): integer;
  begin
    result:= theInteger;
    if Lower > theInteger then
      result:= Lower;
  end;
  function TrimIntH(Upper, theInteger: integer): integer;
  begin
    result:= theInteger;
    if theInteger > Upper then
      result:= Upper;
  end;

procedure BlurRow(var theRow: array of TRGBTriple; const K: TKernel;
P: PRow);
var
  j, n: integer;
  tr, tg, tb: double; //tempRed, etc
  w: double;
begin
  for j:= 0 to K.Size-1 do
  begin
    tb:= 0;
    tg:= 0;
    tr:= 0;
    for n:= -K.Size to K.Size do
    begin
      w:= K.Weights[n];
      // the TrimInt keeps us                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         ,                                                     -  '                                              3  4  5  6  7  8  9  :  ;  <  =  >  ?  @  A  B  C  D  E  F  G  H  I  J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z  [  \  ]  ^  _  `  a  b  c  d  e  f  g  h  i  j  k  l  m  n  o  p  q  r  s  t  u  v  w  x  y  z  {  |  }  ~    �  �      �  �  �      �  �      �  �  �      �  �  �                                  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �                 from running off the edge of the row...
      with theRow[TrimIntL(0, j + n)] do
      begin
        tb:= tb + w * b;
        tg:= tg + w * g;
        tr:= tr + w * r;
      end;
    end;
    with P[j] do
    begin
      b:= round(tb);
      g:= round(tg);
      r:= round(tr);
    end;
  end;

  for j:= K.Size to High(theRow)-K.Size-1 do
  begin
    tb:= 0;
    tg:= 0;
    tr:= 0;
    for n:= -K.Size to K.Size do
    begin
      w:= K.Weights[n];
      with theRow[j + n] do
      begin
        tb:= tb + w * b;
        tg:= tg + w * g;
        tr:= tr + w * r;
      end;
    end;
    with P[j] do
    begin
      b:= round(tb);
      g:= round(tg);
      r:= round(tr);
    end;
  end;

  for j:= High(theRow)-K.Size to High(theRow) do
  begin
    tb:= 0;
    tg:= 0;
    tr:= 0;
    for n:= -K.Size to K.Size do
    begin
      w:= K.Weights[n];
      // the TrimInt keeps us from running off the edge of the row...
      with theRow[TrimIntH(High(theRow), j + n)] do
      begin
        tb:= tb + w * b;
        tg:= tg + w * g;
        tr:= tr + w * r;
      end;
    end;
    with P[j] do
    begin
      b:= round(tb);
      g:= round(tg);
      r:= round(tr);
    end;
  end;

  Move(P[0], theRow[0], (High(theRow) + 1) * Sizeof(TRGBTriple));
end;

procedure GBlur(theBitmap: TBitmap; radius: double);
var
  Row, Col: integer;
  theRows: PPRows;
  K: TKernel;
  ACol: PRow;
  P:PRow;
begin
  theBitmap.PixelFormat:= pf24Bit;
  {
  if (theBitmap.HandleType <> bmDIB) or (theBitmap.PixelFormat <>
pf24Bit) then
    raise exception.Create('GBlur only works for 24-bit bitmaps');
  }
  MakeGaussianKernel(K, radius, 255, 1);
  GetMem(theRows, theBitmap.Height * SizeOf(PRow));
  GetMem(ACol, theBitmap.Height * SizeOf(TRGBTriple));

  // record the location of the bitmap data:
  for Row:= 0 to theBitmap.Height - 1 do
    theRows[Row]:= theBitmap.Scanline[Row];

  // blur each row:
  P:= AllocMem(theBitmap.Width*SizeOf(TRGBTriple));
  for Row:= 0 to theBitmap.Height - 1 do
    BlurRow(Slice(theRows[Row]^, theBitmap.Width), K, P);


  //now blur each column
  ReAllocMem(P, theBitmap.Height*SizeOf(TRGBTriple));
  for Col:= 0 to theBitmap.Width - 1 do
  begin
    // - first read the column into a TRow:
    for Row:= 0 to theBitmap.Height - 1 do
      ACol[Row]:= theRows[Row][Col];

    BlurRow(Slice(ACol^, theBitmap.Height), K, P);

    //now put that row, um, column back into the data:
    for Row:= 0 to theBitmap.Height - 1 do
      theRows[Row][Col]:= ACol[Row];
  end;
  FreeMem(theRows);
  FreeMem(ACol);
  ReAllocMem(P, 0);
end;
end.
                                                                                                                                                                                                                                                                                                                                                                                                                   A p p l i c a t i o n    @  M   �H o o k s    A  �   �H o o k s    B                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 �H o w   T o   F i l t e r   a   t r e e     
    �M e r g e d   C o l u m n s         �S o r t i n g   M u l t i p l e   C o l u m n s       �  �P a i n t   a   P r o g r e s s B a r   o n   a   c e l l       V	  #�A r r a n g e   n o d e s   t h r o u g h   d r a g   a n d   d r o p       �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        procedure TfrmSelNode.FilterNodes(const Text : string; SearchType : TSearchType);
var
  Node : PVirtualNode;
  Data : PPWCTreeNode;
begin
  Screen.Cursor := crHourGlass;
  treeAccounts.BeginUpdate;
  Node := treeAccounts.GetFirst;
  while Node <> nil do
  begin
    Data := treeAccounts.GetNodeData(Node);
    if not MatchStr(Data^.Caption, Text, False) then
      Node.States := Node.States - [vsVisible]
    else
      Node.States := Node.States + [vsVisible];
    Node := treeAccounts.GetNext(Node);
  end;
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           Set the toAutoSpanColumns to true at the TreeOptions\AutoOptions it will
automatically expand the cell to cover all the columns to the right that have no
text. I have no idea how it works for previous collumns though I guess that it
will not bother with them.
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
type
  PRecord = ^TRecord;
  TRecord = record
    ID: integer;
    Text_1: string;
    Text_2: string;
    Text_3: string;
    Date: TDateTime;
  end;

...

var Sorting_Columns: array of TColumnIndex;

...

procedure TForm1.VirtualStringTree1CompareNodes(Sender: TBaseVirtualTree;
  Node1, Node2: PVirtualNode; Column: TColumnIndex; var Result: Integer);
var Actual_Index: integer;
    Data_1: PRecord;
    Data_2: PRecord;

begin
  if Length(Sorting_Columns) > 0 then
    begin
      Data_1 := VirtualStringTree1.GetNodeData(Node1);
      Data_2 := VirtualStringTree1.GetNodeData(Node2);

      if Assigned(Data_1) and Assigned(Data_2) then
        for Actual_Index := High(Sorting_Columns) downto 0 do
          case Sorting_Columns[Actual_Index] of
            0: Result := Result + Data_1^.ID - Data_2^.ID;
            1: Result := Result + CompareStr(Data_1^.Text_1, Data_2^.Text_1);
            2: Result := Result + CompareStr(Data_1^.Text_2, Data_2^.Text_2);
            3: Result := Result + CompareStr(Data_1^.Text_3, Data_2^.Text_3);
            4: Result := Result + CompareDateTime(Data_1^.Date, Data_2^.Date);
          end;

      if Result <> 0 then
        Break;
    end;
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
e following “DWORD” values can be used to add standard folders to the Places Bar.
00 – Desktop
01 – Internet Explorer
02 – Start Menu\Programs
03 – My Computer\Control Panel
04 – My Computer\Printers
05 – My Documents
06 – Favorites
07 – Start Menu\Programs\Startup
08 – \Recent
09 – \SendTo
0a – \Recycle Bin
0b – \Start Menu
0c – - logical “My Documents” desktop icon
0d – My Music
0e – My Videos
10 – \Desktop
11 – My Computer
12 – My Network Places
13 – \NetHood
14 – WINDOWS\Fonts
15 – Templates
16 – All Users\Start Menu
17 – All Users\Programs
18 – All Users\Start Menu
19 – All Users\Desktop
1a – \Application Data
1b – \PrintHood
1c – \Local Settings\Application Data 	1d – - Nonlocalized startup
1e – - Nonlocalized common startup
1f – Favorites
20 – Temporary Internet Files
21 – Cookies
22 – History
23 – All Users\Application Data
24 – WINDOWS directory
25 – System32 directory
26 – Program files
27 – My Pictures
28 – USERPROFILE
29 – - x86 system directory on RISC
2a – - x86 C:\Program Files on RISC
2b – C:\Program Files\Common
2c – - x86 Program Files\Common on RISC
2d – All Users\Templates
2e – All Users\Documents
2f – All Users\Start Menu\Programs\Administrative Tools
30 – - \Start Menu\Programs\Administrative Tools
31 – Network and Dial-up Connections
35 – All Users\My Music
36 – All Users\My Pictures
37 – All Users\My Video
38 – Resource Directory
39 – Localized Resource Directory
3a – Links to All Users OEM specific apps
3b – USERPROFILE\Local Settings\Application Data\Microsoft\CD Burning
                                                                                                                                                                                                                                                                                                                                                            Navigate to the following key:
HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\comdlg32\Placesbar
The comdlg32 and Placesbar keys may not exist. If not, you need to create them.
For example, to create the comdlg32 key, right-click the Policies key and select
New | Key.
You can add up to 5 places as string values name place0 through 4 and defining
the path to open on data of each value.

The following “DWORD” values can be used to add standard folders to the Places Bar.
00 – Desktop
01 – Internet Explorer
02 – Start Menu\Programs
03 – My Computer\Control Panel
04 – My Computer\Printers
05 – My Documents
06 – Favorites
07 – Start Menu\Programs\Startup
08 – \Recent
09 – \SendTo
0a – \Recycle Bin
0b – \Start Menu
0c – - logical “My Documents” desktop icon
0d – My Music
0e – My Videos
10 – \Desktop
11 – My Computer
12 – My Network Places
13 – \NetHood
14 – WINDOWS\Fonts
15 – Templates
16 – All Users\Start Menu
17 – All Users\Programs
18 – All Users\Start Menu
19 – All Users\Desktop
1a – \Application Data
1b – \PrintHood
1c – \Local Settings\Application Data 	1d – - Nonlocalized startup
1e – - Nonlocalized common startup
1f – Favorites
20 – Temporary Internet Files
21 – Cookies
22 – History
23 – All Users\Application Data
24 – WINDOWS directory
25 – System32 directory
26 – Program files
27 – My Pictures
28 – USERPROFILE
29 – - x86 system directory on RISC
2a – - x86 C:\Program Files on RISC
2b – C:\Program Files\Common
2c – - x86 Program Files\Common on RISC
2d – All Users\Templates
2e – All Users\Documents
2f – All Users\Start Menu\Programs\Administrative Tools
30 – - \Start Menu\Programs\Administrative Tools
31 – Network and Dial-up Connections
35 – All Users\My Music
36 – All Users\My Pictures
37 – All Users\My Video
38 – Resource Directory
39 – Localized Resource Directory
3a – Links to All Users OEM specific apps
3b – USERPROFILE\Local Settings\Application Data\Microsoft\CD Burning
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         procedure TCompanyFilesForm.upload_gridAfterCellPaint(Sender: TBaseVirtualTree;
 TargetCanvas: TCanvas; Node: PVirtualNode; Column: TColumnIndex;
 const CellRect: TRect);
Var
    Ptxt : String;
    R : Trect;
    P : int64;
    data : PUploadGridData;
    Arect:trect;
    BckPen:TPen;
    BckBrush : TBrush;
begin
     if node = nil then exit;
     if Column < 2 then
        exit;
  BckPen := Tpen.Create;
  BckBrush := TBrush.Create;
  try
     BckPen.assign(TargetCanvas.Pen);
     BckBrush.Assign(TargetCanvas.Brush);
     arect:=CellRect;
     data := upload_grid.GetNodeData(Node);
     if data^.progress > 0 then
        with TargetCanvas do
             begin
                  R := CellRect;
                  Inc(R.Left,1);
                  Inc(R.Top,1);
                  Dec(R.Right,1);
                  Dec(R.Bottom,1);
                  // draw a rectangle in the box
                  Pen.Color   := clgreen;
                  Pen.Width   := 1;
                  Rectangle(R.Left,R.Top,R.Right,R.Bottom);
                  Rectangle(R.Left+1,R.Top+1,R.Right-1,R.Bottom-1);
                  // draw the progess indicator
                  If data^.Progress < 0 then data^.Progress := 0;
                  If data^.Progress > 100 then data^.Progress := 100;
                  R.Right := CellRect.Left+Trunc((CellRect.Right - CellRect.Left - 1) * data^.Progress/100)-1;
                  Ptxt := formatfloat('0 %',data^.Progress);
                  Brush.Color := clblue;
                  Brush.Style := bsSolid;
                  P := R.Left+2+Trunc((CellRect.Right - CellRect.Left - 1) *  data^.Progress/100)-1;
                  FillRect(R.Left+2,R.Top+2, P ,R.Bottom-2);
                  Brush.Color := clblue;
                  FillRect(P+1, R.Top+2, R.Right, R.Bottom-2);
                  // Color and other text atributes
                  If (upload_grid.SelectedCount > 0) and (upload_grid.Selected[Node]) then
                   Font.Color := ClWhite
                  else
                   Font.Color := clBlack;
                  Brush.Style := Bsclear;
                  Drawtext(TargetCanvas.Handle, Pchar(Ptxt), Length(Ptxt), aRect,DT_CENTER Or DT_VCENTER Or DT_SINGLELINE);
             end;
  finally
    TargetCanvas.Pen.Assign(BckPen);
    TargetCanvas.Brush.Assign(BckBrush);
  end;
end;

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          t.code.sf.net/p/evsdotparser/code
git push origin master
git branch --set-upstream master origin/master  # so 'git pull' will work later


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                �R e t r e i v e   a l l   t h e   t a b l e s       h   �R e t r i e v e   a l l   t h e   V i e w s       ;   �R e t r i e v e   a l l   t h e   u s e r s       7   �R e t r i e v e   a l l   t h e   I n d i c e s       �   �R e t r i e v e   I n d e x   D e t a i l s       �  �R e t r i e v e   C o n s t r a i n t s       �   �R e t r e i v e   T a b l e   F i e l d s       �  �R e t r i e v e   F i e l d   D e t a i l s       l  �R e t r i e v e   G e n e r a t o r s     !  M   �R e t r i e v e   T r i g g e r s     "  �   �R e t r i e v e   F u n c t i o n s     #  8   �R e t r i e v e   S t o r e d   P r o c e d u r e s     $     �R e t r e i v e   f o r e i g n   k e y s     %  #  �R e t r i e v e   C o n s t r a i n   d e t a i l s     &  �  �R e t r i e v e   t r i g g e r   d e t a i l s     (  -  �R e t r i e v e   V i e w   d e t a i l s     )  �  �R e t r i e v e   V i e w   d e f i n i t i o n     *  �   �R e t r i e v e   S e r v e r   D e t a SELECT RDB$RELATION_NAME
  FROM RDB$RELATIONS
 WHERE RDB$SYSTEM_FLAG=0
   AND RDB$VIEW_BLR IS NULL;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        SELECT DISTINCT RDB$VIEW_NAME
  FROM RDB$VIEW_RELATIONS;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     SELECT DISTINCT RDB$USER
  FROM RDB$USER_PRIVILEGES;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         SELECT RDB$INDEX_NAME
  FROM RDB$INDICES
 WHERE RDB$RELATION_NAME='TEST2'
   AND RDB$UNIQUE_FLAG IS NULL
   AND RDB$FOREIGN_KEY IS NULL;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  SELECT RDB$INDEX_SEGMENTS.RDB$FIELD_NAME AS field_name,
          RDB$INDICES.RDB$DESCRIPTION AS description,
          (RDB$INDEX_SEGMENTS.RDB$FIELD_POSITION + 1) AS field_position
     FROM RDB$INDEX_SEGMENTS
LEFT JOIN RDB$INDICES ON RDB$INDICES.RDB$INDEX_NAME = RDB$INDEX_SEGMENTS.RDB$INDEX_NAME
LEFT JOIN RDB$RELATION_CONSTRAINTS ON RDB$RELATION_CONSTRAINTS.RDB$INDEX_NAME = RDB$INDEX_SEGMENTS.RDB$INDEX_NAME
    WHERE UPPER(RDB$INDICES.RDB$RELATION_NAME)='TEST2'         -- table name
      AND UPPER(RDB$INDICES.RDB$INDEX_NAME)='TEST2_FIELD5_IDX' -- index name
      AND RDB$RELATION_CONSTRAINTS.RDB$CONSTRAINT_TYPE IS NULL
 ORDER BY RDB$INDEX_SEGMENTS.RDB$FIELD_POSITION
                                                                                                                                                                                                                                                                                                                                                SELECT RDB$INDEX_NAME
  FROM RDB$INDICES
 WHERE RDB$RELATION_NAME='TEST2' -- table name
   AND (
       RDB$UNIQUE_FLAG IS NOT NULL
    OR RDB$FOREIGN_KEY IS NOT NULL
   );
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            SELECT RDB$FIELD_NAME
  FROM RDB$RELATION_FIELDS
 WHERE RDB$RELATION_NAME='TEST2';

 or

 SELECT RDB$FIELD_NAME AS field_name,
       RDB$FIELD_POSITION AS field_position,
       RDB$DESCRIPTION AS field_description,
       RDB$DEFAULT_VALUE AS field_default_value,
       RDB$NULL_FLAG AS field_not_null_constraint
  FROM RDB$RELATION_FIELDS
 WHERE RDB$RELATION_NAME='TEST2';
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          SELECT r.RDB$FIELD_NAME AS field_name,
        r.RDB$DESCRIPTION AS field_description,
        r.RDB$DEFAULT_VALUE AS field_default_value,
        r.RDB$NULL_FLAG AS field_not_null_constraint,
        f.RDB$FIELD_LENGTH AS field_length,
        f.RDB$FIELD_PRECISION AS field_precision,
        f.RDB$FIELD_SCALE AS field_scale,
        CASE f.RDB$FIELD_TYPE
          WHEN 261 THEN 'BLOB'
          WHEN 14 THEN 'CHAR'
          WHEN 40 THEN 'CSTRING'
          WHEN 11 THEN 'D_FLOAT'
          WHEN 27 THEN 'DOUBLE'
          WHEN 10 THEN 'FLOAT'
          WHEN 16 THEN 'INT64'
          WHEN 8 THEN 'INTEGER'
          WHEN 9 THEN 'QUAD'
          WHEN 7 THEN 'SMALLINT'
          WHEN 12 THEN 'DATE'
          WHEN 13 THEN 'TIME'
          WHEN 35 THEN 'TIMESTAMP'
          WHEN 37 THEN 'VARCHAR'
          ELSE 'UNKNOWN'
        END AS field_type,
        f.RDB$FIELD_SUB_TYPE AS field_subtype,
        coll.RDB$COLLATION_NAME AS field_collation,
        cset.RDB$CHARACTER_SET_NAME AS field_charset
   FROM RDB$RELATION_FIELDS r
   LEFT JOIN RDB$FIELDS f ON r.RDB$FIELD_SOURCE = f.RDB$FIELD_NAME
   LEFT JOIN RDB$COLLATIONS coll ON f.RDB$COLLATION_ID = coll.RDB$COLLATION_ID
   LEFT JOIN RDB$CHARACTER_SETS cset ON f.RDB$CHARACTER_SET_ID = cset.RDB$CHARACTER_SET_ID
  WHERE r.RDB$RELATION_NAME='TEST2'  -- table name
ORDER BY r.RDB$FIELD_POSITION;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    SELECT RDB$GENERATOR_NAME
  FROM RDB$GENERATORS
 WHERE RDB$SYSTEM_FLAG=0;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   SELECT * FROM RDB$TRIGGERS
 WHERE RDB$SYSTEM_FLAG=0;

 SELECT * FROM RDB$TRIGGERS
 WHERE RDB$SYSTEM_FLAG = 0
   AND RDB$RELATION_NAME='NEWTABLE';  -- table name
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         SELECT * FROM RDB$FUNCTIONS
 WHERE RDB$SYSTEM_FLAG=0;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        SELECT * FROM RDB$PROCEDURES;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 SELECT DISTINCT
          rc.RDB$CONSTRAINT_NAME AS "constraint_name",
          rc.RDB$RELATION_NAME AS "on table",
          d1.RDB$FIELD_NAME AS "on field",
          d2.RDB$DEPENDED_ON_NAME AS "references table",
          d2.RDB$FIELD_NAME AS "references field",
          refc.RDB$UPDATE_RULE AS "on update",
          refc.RDB$DELETE_RULE AS "on delete"
     FROM RDB$RELATION_CONSTRAINTS AS rc
LEFT JOIN RDB$REF_CONSTRAINTS refc ON rc.RDB$CONSTRAINT_NAME = refc.RDB$CONSTRAINT_NAME
LEFT JOIN RDB$DEPENDENCIES d1 ON d1.RDB$DEPENDED_ON_NAME = rc.RDB$RELATION_NAME
LEFT JOIN RDB$DEPENDENCIES d2 ON d1.RDB$DEPENDENT_NAME = d2.RDB$DEPENDENT_NAME
    WHERE rc.RDB$CONSTRAINT_TYPE = 'FOREIGN KEY'
      AND d1.RDB$DEPENDED_ON_NAME <> d2.RDB$DEPENDED_ON_NAME
      AND d1.RDB$FIELD_NAME <> d2.RDB$FIELD_NAME
      AND rc.RDB$RELATION_NAME = 'b'  -- table name

-- OR

select
	 rc.rdb$constraint_name AS fk_name
	, rcc.rdb$relation_name AS child_table
	, isc.rdb$field_name AS child_column
	, rcp.rdb$rSELECT rc.RDB$CONSTRAINT_NAME,
          s.RDB$FIELD_NAME AS field_name,
          rc.RDB$CONSTRAINT_TYPE AS constraint_type,
          i.RDB$DESCRIPTION AS description,
          rc.RDB$DEFERRABLE AS is_deferrable,
          rc.RDB$INITIALLY_DEFERRED AS is_deferred,
          refc.RDB$UPDATE_RULE AS on_update,
          refc.RDB$DELETE_RULE AS on_delete,
          refc.RDB$MATCH_OPTION AS match_type,
          i2.RDB$RELATION_NAME AS references_table,
          s2.RDB$FIELD_NAME AS references_field,
          (s.RDB$FIELD_POSITION + 1) AS field_position
     FROM RDB$INDEX_SEGMENTS s
LEFT JOIN RDB$INDICES i ON i.RDB$INDEX_NAME = s.RDB$INDEX_NAME
LEFT JOIN RDB$RELATION_CONSTRAINTS rc ON rc.RDB$INDEX_NAME = s.RDB$INDEX_NAME
LEFT JOIN RDB$REF_CONSTRAINTS refc ON rc.RDB$CONSTRAINT_NAME = refc.RDB$CONSTRAINT_NAME
LEFT JOIN RDB$RELATION_CONSTRAINTS rc2 ON rc2.RDB$CONSTRAINT_NAME = refc.RDB$CONST_NAME_UQ
LEFT JOIN RDB$INDICES i2 ON i2.RDB$INDEX_NAME = rc2.RDB$INDEX_NAME
LEFT JOIN RDB$INDEX_SEGMENTS s2 ON i2.RDB$INDEX_NAME = s2.RDB$INDEX_NAME
    WHERE i.RDB$RELATION_NAME='b'       -- table name
      AND rc.RDB$CONSTRAINT_NAME='FK_b' -- constraint name
      AND rc.RDB$CONSTRAINT_TYPE IS NOT NULL
 ORDER BY s.RDB$FIELD_POSITION
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                SELECT RDB$TRIGGER_NAME AS trigger_name,
       RDB$RELATION_NAME AS table_name,
       RDB$TRIGGER_SOURCE AS trigger_body,
       CASE RDB$TRIGGER_TYPE
        WHEN 1 THEN 'BEFORE'
        WHEN 2 THEN 'AFTER'
        WHEN 3 THEN 'BEFORE'
        WHEN 4 THEN 'AFTER'
        WHEN 5 THEN 'BEFORE'
        WHEN 6 THEN 'AFTER'
       END AS trigger_type,
       CASE RDB$TRIGGER_TYPE
        WHEN 1 THEN 'INSERT'
        WHEN 2 THEN 'INSERT'
        WHEN 3 THEN 'UPDATE'
        WHEN 4 THEN 'UPDATE'
        WHEN 5 THEN 'DELETE'
        WHEN 6 THEN 'DELETE'
       END AS trigger_event,
       CASE RDB$TRIGGER_INACTIVE
        WHEN 1 THEN 0 ELSE 1
       END AS trigger_enabled,
       RDB$DESCRIPTION AS trigger_comment
  FROM RDB$TRIGGERS
 WHERE UPPER(RDB$TRIGGER_NAME)='AUTOINCREMENTPK'
                                                                                                                                                                                                                   SELECT d.RDB$DEPENDENT_NAME AS view_name,
         r.RDB$FIELD_NAME AS field_name,
         d.RDB$DEPENDED_ON_NAME AS depended_on_table,
         d.RDB$FIELD_NAME AS depended_on_field
    FROM RDB$DEPENDENCIES d
    LEFT JOIN RDB$RELATION_FIELDS r ON d.RDB$DEPENDENT_NAME = r.RDB$RELATION_NAME
         AND d.RDB$FIELD_NAME = r.RDB$BASE_FIELD
   WHERE UPPER(d.RDB$DEPENDENT_NAME)='NUMBERSVIEW'
     AND r.RDB$SYSTEM_FLAG = 0
     AND d.RDB$DEPENDENT_TYPE = 1 --VIEW
ORDER BY r.RDB$FIELD_POSITION
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     SELECT RDB$VIEW_SOURCE
  FROM RDB$RELATIONS
 WHERE RDB$VIEW_SOURCE IS NOT NULL
   AND UPPER(RDB$RELATION_NAME) = 'NUMBERSVIEW';
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            SELECT RDB$GET_CONTEXT('SYSTEM', 'ENGINE_VERSION') AS engine_version,
       RDB$GET_CONTEXT('SYSTEM', 'NETWORK_PROTOCOL') AS protocol,
       RDB$GET_CONTEXT('SYSTEM', 'CLIENT_ADDRESS') AS address
  FROM RDB$DATABASE;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 i l s     +  �   �R e t r i e v e   a l l   c o l l a t i o n s       .  �   �R e t r i e v e   a l l   C h a r a c t e r   s e t s     /  ;   &�S c r i p t   t o   f i l l   a n   e m p t y   M S S Q L   d a t a b a s e     2  �>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   elation_name AS parent_table
	, isp.rdb$field_name AS parent_column
	, rc.rdb$update_rule AS update_rule
	, rc.rdb$delete_rule AS delete_rule
from rdb$ref_constraints AS rc
	inner join rdb$relation_constraints AS rcc
		on rc.rdb$constraint_name = rcc.rdb$constraint_name
	inner join rdb$index_segments AS isc
		on rcc.rdb$index_name = isc.rdb$index_name
	inner join rdb$relation_constraints AS rcp
		on rc.rdb$const_name_uq  = rcp.rdb$constraint_name
	inner join rdb$index_segments AS isp
		on rcp.rdb$index_name = isp.rdb$index_name
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             SELECT RDB$CHARACTER_SET_NAME, RDB$COLLATION_NAME
  FROM rdb$collations
    inner join rdb$character_sets on  rdb$collations.rdb$character_set_id = rdb$character_sets.rdb$character_set_id

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               SELECT RDB$CHARACTER_SET_NAME
FROM  rdb$character_sets

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     �R o t a t i o n   M a t r i x     1  �  �B g r a B i t m a p   L a n c z o s     �  �  �3 2 s t e p   a l i g n e d   r o t a t t i o n     �  p  )�R o t a t e   a   b i t m a p   a r o u n d   a n   a r b i t r a r y   p o i n t     �  �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      {(A=angle of rotation)
Counter clock wise rotation matrix.}
        __             __    __ __
 R(A)  | cos(A), -sin(A) |  |  X  |
       | sin(A), cos(A)  |  |  Y  |
        --             --    -- --

// Clock wise rotation matrix
        __             __    _   _
 R(A)  | cos(A),  sin(A) |  |  X  |
       | -sin(A), cos(A) |  |  Y  |
        --             --    -   -
{
clock or counter clock wise is axis dependand for example the above clock /
counter clock are correct only when the 0,0 point is on the  bottom left corner
of your screen if it is on top left corner then the clock/counter clock are
reversed.}

         __    __    _   _
 R(90)  | 0,  -1 |  |  X  |
        | 1,   0 |  |  Y  |
         --    --    -   -
          __    __    _   _
 R(180)  | -1,  0 |  |  X  |
         |  0, -1 |  |  Y  |
          --    --    -   -
          __   __    _   _
 R(270)  |  0, 1 |  |  X  |
         | -1, 0 |  |  Y  |
          --   --    -   -

                                     -- Fabrics V1.2
-- Creating a SQL database from scratch
USE Fabrics
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Fabrics]') AND type in (N'P', N'PC'))
    DROP PROCEDURE usp_Fabrics
GO
CREATE PROCEDURE [dbo].usp_Fabrics
    (@CreateClients INT = 2500,
    @CreateOrders INT = 5000)
AS
BEGIN
    SET NOCOUNT ON
    SET STATISTICS IO OFF

    DECLARE @TimeStarted AS DATETIME = GetDate()
    DECLARE @BulkInsertSize AS INT = 1000
    DECLARE @Randomizer AS INT = CHECKSUM(30052007) -- Using all the same seed, We try to get the same database for everybody

    IF OBJECT_ID('dbo.OrderLine') IS NOT NULL
        DROP TABLE OrderLine
    CREATE TABLE OrderLine(OrderId int NOT NULL, LineNumber int, ProductId int NOT NULL, Qty numeric(18, 3) NOT NULL, LineTotal numeric(18, 2) NOT NULL, CONSTRAINT pk_OrderId_LineNumber PRIMARY KEY CLUSTERED (OrderId ASC, LineNumber ASC))
    IF OBJECT_ID('dbo.Order') IS NOT NULL
        DROP TABLE [Order]
    IF OBJECT_ID('dbo.Product') IS NOT NULL
        DROP TABLE dbo.Product
    IF  OBJECT_ID('dbo.Client') IS NOT NULL
        DROP TABLE Client
    CREATE TABLE Client (ClientId INTEGER IDENTITY (1, 1) NOT NULL CONSTRAINT pk_ClientId PRIMARY KEY, FirstName varchar(40), MiddleName varchar(40), LastName varchar(40), Gender char(1), DateOfBirth datetime,
        CreditRating FLOAT, XCode CHAR(7), OccupationId INTEGER, TelephoneNumber VARCHAR(20), Street1 VARCHAR(100), Street2 VARCHAR(100), City varchar(100), ZipCode VARCHAR(15), Longitude FLOAT, Latitude FLOAT, Notes varchar(max))
    IF OBJECT_ID('dbo.Occupation') IS NOT NULL
        DROP TABLE Occupation
    CREATE TABLE Occupation (OccupationId INTEGER IDENTITY (1, 1) NOT NULL CONSTRAINT pk_OccupationId PRIMARY KEY, OccupationName varchar(60))

    DECLARE @tblCity TABLE (CityId [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY, Name varchar(40),StateCode CHAR(2), Longitude FLOAT, Latitude FLOAT, Popul INTEGER, Surface FLOAT)
    DECLARE @tblMaleFirstName TABLE (MaleFirstNameId [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY, Name varchar(40))
    DECLARE @tblFemaleFirstName TABLE (FemaleFirstNameId [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY, Name varchar(40))
    DECLARE @tblLastName TABLE (LastNameId [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY, Name varchar(40))
    DECLARE @tblTempClient TABLE (FirstName varchar(40), MiddleName varchar(40), LastName varchar(40), Gender char(1), DateOfBirth datetime,
        CreditRating FLOAT, XCode CHAR(7), OccupationId INTEGER, TelephoneNumber VARCHAR(20), Street1 VARCHAR(100), Street2 VARCHAR(100), City varchar(100), ZipCode VARCHAR(15), Longitude FLOAT, Latitude FLOAT, Notes varchar(max))

    DECLARE @tblStreetNames TABLE (StreetNamesId [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY, Name varchar(40))
    DECLARE @tblStreetTypes TABLE (StreetTypesId [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY, Name varchar(40))
    DECLARE @tblStreetZones TABLE (StreetZoneId [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY, Name varchar(40))

    -- rough copy from http://www.census.gov/genealogy/Names/
    INSERT INTO @tblMaleFirstName(Name) VALUES('James'),('John'),('Robert'),('Michael'),('William'),('David'),('Richard'),('Charles'),('Joseph'),('Thomas'),('Christopher'),('Daniel'),('Paul'),('Mark'),('Donald'),('George'),('Kenneth'),('Steven'),('Edward'),('Brian'),('Ronald'),('Anthony'),('Kevin'),('Jason'),('Matthew'),('Gary'),('Timothy'),('Jose'),('Larry'),('Jeffrey'),('Frank'),('Scott'),('Eric'),('Stephen'),('Andrew'),('Raymond'),('Gregory'),('Joshua'),('Jerry'),('Dennis'),('Walter'),('Patrick'),('Peter'),('Harold'),('Douglas'),('Henry'),('Carl'),('Arthur'),('Ryan'),('Roger'),('Joe'),('Juan'),('Jack'),('Albert'),('Jonathan'),('Justin'),('Terry'),('Gerald'),('Keith'),('Samuel'),('Willie'),('Ralph'),('Lawrence'),('Nicholas'),('Roy'),('Benjamin'),('Bruce'),('Brandon'),('Adam'),('Harry'),('Fred'),('Wayne'),('Billy'),('Steve'),('Louis'),('Jeremy'),('Aaron'),('Randy'),('Howard'),('Eugene'),('Carlos'),('Russell'),('Bobby'),('Victor'),('Martin'),('Ernest'),('Phillip'),('Todd'),('Jesse'),('Craig'),('Alan'),('Shawn'),('Clarence'),('Sean'),('Philip'),('Chris'),('Johnny'),('Earl'),('Jimmy'),('Antonio'),('Danny'),('Bryan'),('Tony'),('Luis'),('Mike'),('Stanley'),('Leonard'),('Nathan'),('Dale'),('Manuel'),('Rodney'),('Curtis'),('Norman'),('Allen'),('Marvin'),('Vincent'),('Glenn'),('Jeffery'),('Travis'),('Jeff'),('Chad'),('Jacob'),('Lee'),('Melvin'),('Alfred'),('Kyle'),('Francis'),('Bradley'),('Jesus'),('Herbert'),('Frederick'),('Ray'),('Joel'),('Edwin'),('Don'),('Eddie'),('Ricky'),('Troy'),('Randall'),('Barry'),('Alexander'),('Bernard'),('Mario'),('Leroy'),('Francisco'),('Marcus'),('Micheal'),('Theodore'),('Clifford'),('Miguel'),('Oscar'),('Jay'),('Jim'),('Tom'),('Calvin'),('Alex'),('Jon'),('Ronnie'),('Bill'),('Lloyd'),('Tommy'),('Leon'),('Derek'),('Warren'),('Darrell'),('Jerome'),('Floyd'),('Leo'),('Alvin'),('Tim'),('Wesley'),('Gordon'),('Dean'),('Greg'),('Jorge'),('Dustin'),('Pedro'),('Derrick'),('Dan'),('Lewis'),('Zachary'),('Corey'),('Herman'),('Maurice'),('Vernon'),('Roberto'),('Clyde'),('Glen'),('Hector'),('Shane'),('Ricardo'),('Sam'),('Rick'),('Lester'),('Brent'),('Ramon'),('Charlie'),('Tyler'),('Gilbert'),('Gene'),('Marc'),('Reginald'),('Ruben'),('Brett'),('Angel'),('Nathaniel'),('Rafael'),('Leslie'),('Edgar'),('Milton'),('Raul'),('Ben'),('Chester'),('Cecil'),('Duane'),('Franklin'),('Andre'),('Elmer'),('Brad'),('Gabriel'),('Ron'),('Mitchell'),('Roland'),('Arnold'),('Harvey'),('Jared'),('Adrian'),('Karl'),('Cory'),('Claude'),('Erik'),('Darryl'),('Jamie'),('Neil'),('Jessie'),('Christian'),('Javier'),('Fernando'),('Clinton'),('Ted'),('Mathew'),('Tyrone'),('Darren'),('Lonnie'),('Lance'),('Cody'),('Julio'),('Kelly'),('Kurt'),('Allan'),('Nelson'),('Guy'),('Clayton'),('Hugh'),('Max'),('Dwayne'),('Dwight'),('Armando'),('Felix'),('Jimmie'),('Everett'),('Jordan'),('Ian'),('Wallace'),('Ken'),('Bob'),('Jaime'),('Casey'),('Alfredo'),('Alberto'),('Dave'),('Ivan'),('Johnnie'),('Sidney'),('Byron'),('Julian'),('Isaac'),('Morris'),('Clifton'),('Willard'),('Daryl'),('Ross'),('Virgil'),('Andy'),('Marshall'),('Salvador'),('Perry'),('Kirk'),('Sergio'),('Marion'),('Tracy'),('Seth'),('Kent'),('Terrance'),('Rene'),('Eduardo'),('Terrence'),('Enrique'),('Freddie'),('Wade'),('Austin'),('Stuart'),('Fredrick'),('Arturo'),('Alejandro'),('Jackie'),('Joey'),('Nick'),('Luther'),('Wendell'),('Jeremiah'),('Evan'),('Julius'),('Dana'),('Donnie'),('Otis'),('Shannon'),('Trevor'),('Oliver'),('Luke'),('Homer'),('Gerard'),('Doug'),('Kenny'),('Hubert'),('Angelo'),('Shaun'),('Lyle'),('Matt'),('Lynn'),('Alfonso'),('Orlando'),('Rex'),('Carlton'),('Ernesto'),('Cameron'),('Neal'),('Pablo'),('Lorenzo'),('Omar'),('Wilbur'),('Blake'),('Grant'),('Horace'),('Roderick'),('Kerry'),('Abraham'),('Willis'),('Rickey'),('Jean'),('Ira'),('Andres'),('Cesar'),('Johnathan'),('Malcolm'),('Rudolph'),('Damon'),('Kelvin'),('Rudy'),('Preston'),('Alton'),('Archie'),('Marco'),('Wm'),('Pete'),('Randolph'),('Garry'),('Geoffrey'),('Jonathon'),('Felipe'),('Bennie'),('Gerardo'),('Ed'),('Dominic'),('Robin'),('Loren'),('Delbert'),('Colin'),('Guillermo'),('Earnest'),('Lucas'),('Benny'),('Noel'),('Spencer'),('Rodolfo'),('Myron'),('Edmund'),('Garrett'),('Salvatore'),('Cedric'),('Lowell'),('Gregg'),('Sherman'),('Wilson'),('Devin'),('Sylvester'),('Kim'),('Roosevelt'),('Israel'),('Jermaine'),('Forrest'),('Wilbert'),('Leland'),('Simon'),('Guadalupe'),('Clark'),('Irving'),('Carroll'),('Bryant'),('Owen'),('Rufus'),('Woodrow'),('Sammy'),('Kristopher'),('Mack'),('Levi'),('Marcos'),('Gustavo'),('Jake'),('Lionel'),('Marty'),('Taylor'),('Ellis'),('Dallas'),('Gilberto'),('Clint'),('Nicolas'),('Laurence'),('Ismael'),('Orville'),('Drew'),('Jody'),('Ervin'),('Dewey'),('Al'),('Wilfred'),('Josh'),('Hugo'),('Ignacio'),('Caleb'),('Tomas'),('Sheldon'),('Erick'),('Frankie'),('Stewart'),('Doyle'),('Darrel'),('Rogelio'),('Terence'),('Santiago'),('Alonzo'),('Elias'),('Bert'),('Elbert'),('Ramiro'),('Conrad'),('Pat'),('Noah'),('Grady'),('Phil'),('Cornelius'),('Lamar'),('Rolando'),('Clay'),('Percy'),('Dexter'),('Bradford'),('Merle'),('Darin'),('Amos'),('Terrell'),('Moses'),('Irvin'),('Saul'),('Roman'),('Darnell'),('Randal'),('Tommie'),('Timmy'),('Darrin'),('Winston'),('Brendan'),('Toby'),('Van'),('Abel'),('Dominick'),('Boyd'),('Courtney'),('Jan'),('Emilio'),('Elijah'),('Cary'),('Domingo'),('Santos'),('Aubrey'),('Emmett'),('Marlon'),('Emanuel'),('Jerald'),('Edmond'),('Emil'),('Dewayne'),('Will'),('Otto'),('Teddy'),('Reynaldo'),('Bret'),('Morgan'),('Jess'),('Trent'),('Humberto'),('Emmanuel'),('Stephan'),('Louie'),('Vicente'),('Lamont'),('Stacy'),('Garland'),('Miles'),('Micah'),('Efrain'),('Billie'),('Logan'),('Heath'),('Rodger'),('Harley'),('Demetrius'),('Ethan'),('Eldon'),('Rocky'),('Pierre'),('Junior'),('Freddy'),('Eli'),('Bryce'),('Antoine'),('Robbie'),('Kendall'),('Royce'),('Sterling'),('Mickey'),('Chase'),('Grover'),('Elton'),('Cleveland'),('Dylan'),('Chuck'),('Damian'),('Reuben'),('Stan'),('August'),('Leonardo'),('Jasper'),('Russel'),('Erwin'),('Benito'),('Hans'),('Monte'),('Blaine'),('Ernie'),('Curt'),('Quentin'),('Agustin'),('Murray'),('Jamal'),('Devon'),('Adolfo'),('Harrison'),('Tyson'),('Burton'),('Brady'),('Elliott'),('Wilfredo'),('Bart'),('Jarrod'),('Vance'),('Denis'),('Damien'),('Joaquin'),('Harlan'),('Desmond'),('Elliot'),('Darwin'),('Ashley'),('Gregorio'),('Buddy'),('Xavier'),('Kermit'),('Roscoe'),('Esteban'),('Anton'),('Solomon'),('Scotty'),('Norbert'),('Elvin'),('Williams'),('Nolan'),('Carey'),('Rod'),('Quinton'),('Hal'),('Brain'),('Rob'),('Elwood'),('Kendrick'),('Darius'),('Moises'),('Son'),('Marlin'),('Fidel'),('Thaddeus'),('Cliff'),('Marcel'),('Ali'),('Jackson'),('Raphael'),('Bryon'),('Armand'),('Alvaro'),('Jeffry'),('Dane'),('Joesph'),('Thurman'),('Ned'),('Sammie'),('Rusty'),('Michel'),('Monty'),('Rory'),('Fabian'),('Reggie'),('Mason'),('Graham'),('Kris'),('Isaiah'),('Vaughn'),('Gus'),('Avery'),('Loyd'),('Diego'),('Alexis'),('Adolph'),('Norris'),('Millard'),('Rocco'),('Gonzalo'),('Derick'),('Rodrigo'),('Gerry'),('Stacey'),('Carmen'),('Wiley'),('Rigoberto'),('Alphonso'),('Ty'),('Shelby'),('Rickie'),('Noe'),('Vern'),('Bobbie'),('Reed'),('Jefferson'),('Elvis'),('Bernardo'),('Mauricio'),('Hiram'),('Donovan'),('Basil'),('Riley'),('Ollie'),('Nickolas'),('Maynard'),('Scot'),('Vince'),('Quincy'),('Eddy'),('Sebastian'),('Federico'),('Ulysses'),('Heriberto'),('Donnell'),('Cole'),('Denny'),('Davis'),('Gavin'),('Emery'),('Ward'),('Romeo'),('Jayson'),('Dion'),('Dante'),('Clement'),('Coy'),('Odell'),('Maxwell'),('Jarvis'),('Bruno'),('Issac'),('Pascal')
    INSERT INTO @tblFemaleFirstName(Name) VALUES('Mary'),('Patricia'),('Linda'),('Barbara'),('Elizabeth'),('Jennifer'),('Maria'),('Susan'),('Margaret'),('Dorothy'),('Lisa'),('Nancy'),('Karen'),('Betty'),('Helen'),('Sandra'),('Donna'),('Carol'),('Ruth'),('Sharon'),('Michelle'),('Laura'),('Sarah'),('Kimberly'),('Deborah'),('Jessica'),('Shirley'),('Cynthia'),('Angela'),('Melissa'),('Brenda'),('Amy'),('Anna'),('Rebecca'),('Virginia'),('Kathleen'),('Pamela'),('Martha'),('Debra'),('Amanda'),('Stephanie'),('Carolyn'),('Christine'),('Marie'),('Janet'),('Catherine'),('Frances'),('Ann'),('Joyce'),('Diane'),('Alice'),('Julie'),('Heather'),('Teresa'),('Doris'),('Gloria'),('Evelyn'),('Jean'),('Cheryl'),('Mildred'),('Katherine'),('Joan'),('Ashley'),('Judith'),('Rose'),('Janice'),('Kelly'),('Nicole'),('Judy'),('Christina'),('Kathy'),('Theresa'),('Beverly'),('Denise'),('Tammy'),('Irene'),('Jane'),('Lori'),('Rachel'),('Marilyn'),('Andrea'),('Kathryn'),('Louise'),('Sara'),('Anne'),('Jacqueline'),('Wanda'),('Bonnie'),('Julia'),('Ruby'),('Lois'),('Tina'),('Phyllis'),('Norma'),('Paula'),('Diana'),('Annie'),('Lillian'),('Emily'),('Robin'),('Peggy'),('Crystal'),('Gladys'),('Rita'),('Dawn'),('Connie'),('Florence'),('Tracy'),('Edna'),('Tiffany'),('Carmen'),('Rosa'),('Cindy'),('Grace'),('Wendy'),('Victoria'),('Edith'),('Kim'),('Sherry'),('Sylvia'),('Josephine'),('Thelma'),('Shannon'),('Sheila'),('Ethel'),('Ellen'),('Elaine'),('Marjorie'),('Carrie'),('Charlotte'),('Monica'),('Esther'),('Pauline'),('Emma'),('Juanita'),('Anita'),('Rhonda'),('Hazel'),('Amber'),('Eva'),('Debbie'),('April'),('Leslie'),('Clara'),('Lucille'),('Jamie'),('Joanne'),('Eleanor'),('Valerie'),('Danielle'),('Megan'),('Alicia'),('Suzanne'),('Michele'),('Gail'),('Bertha'),('Darlene'),('Veronica'),('Jill'),('Erin'),('Geraldine'),('Lauren'),('Cathy'),('Joann'),('Lorraine'),('Lynn'),('Sally'),('Regina'),('Erica'),('Beatrice'),('Dolores'),('Bernice'),('Audrey'),('Yvonne'),('Annette'),('June'),('Samantha'),('Marion'),('Dana'),('Stacy'),('Ana'),('Renee'),('Ida'),('Vivian'),('Roberta'),('Holly'),('Brittany'),('Melanie'),('Loretta'),('Yolanda'),('Jeanette'),('Laurie'),('Katie'),('Kristen'),('Vanessa'),('Alma'),('Sue'),('Elsie'),('Beth'),('Jeanne'),('Vicki'),('Carla'),('Tara'),('Rosemary'),('Eileen'),('Terri'),('Gertrude'),('Lucy'),('Tonya'),('Ella'),('Stacey'),('Wilma'),('Gina'),('Kristin'),('Jessie'),('Natalie'),('Agnes'),('Vera'),('Willie'),('Charlene'),('Bessie'),('Delores'),('Melinda'),('Pearl'),('Arlene'),('Maureen'),('Colleen'),('Allison'),('Tamara'),('Joy'),('Georgia'),('Constance'),('Lillie'),('Claudia'),('Jackie'),('Marcia'),('Tanya'),('Nellie'),('Minnie'),('Marlene'),('Heidi'),('Glenda'),('Lydia'),('Viola'),('Courtney'),('Marian'),('Stella'),('Caroline'),('Dora'),('Jo'),('Vickie'),('Mattie'),('Terry'),('Maxine'),('Irma'),('Mabel'),('Marsha'),('Myrtle'),('Lena'),('Christy'),('Deanna'),('Patsy'),('Hilda'),('Gwendolyn'),('Jennie'),('Nora'),('Margie'),('Nina'),('Cassandra'),('Leah'),('Penny'),('Kay'),('Priscilla'),('Naomi'),('Carole'),('Brandy'),('Olga'),('Billie'),('Dianne'),('Tracey'),('Leona'),('Jenny'),('Felicia'),('Sonia'),('Miriam'),('Velma'),('Becky'),('Bobbie'),('Violet'),('Kristina'),('Toni'),('Misty'),('Mae'),('Shelly'),('Daisy'),('Ramona'),('Sherri'),('Erika'),('Katrina'),('Claire'),('Lindsey'),('Lindsay'),('Geneva'),('Guadalupe'),('Belinda'),('Margarita'),('Sheryl'),('Cora'),('Faye'),('Ada'),('Natasha'),('Sabrina'),('Isabel'),('Marguerite'),('Hattie'),('Harriet'),('Molly'),('Cecilia'),('Kristi'),('Brandi'),('Blanche'),('Sandy'),('Rosie'),('Joanna'),('Iris'),('Eunice'),('Angie'),('Inez'),('Lynda'),('Madeline'),('Amelia'),('Alberta'),('Genevieve'),('Monique'),('Jodi'),('Janie'),('Maggie'),('Kayla'),('Sonya'),('Jan'),('Lee'),('Kristine'),('Candace'),('Fannie'),('Maryann'),('Opal'),('Alison'),('Yvette'),('Melody'),('Luz'),('Susie'),('Olivia'),('Flora'),('Shelley'),('Kristy'),('Mamie'),('Lula'),('Lola'),('Verna'),('Beulah'),('Antoinette'),('Candice'),('Juana'),('Jeannette'),('Pam'),('Kelli'),('Hannah'),('Whitney'),('Bridget'),('Karla'),('Celia'),('Latoya'),('Patty'),('Shelia'),('Gayle'),('Della'),('Vicky'),('Lynne'),('Sheri'),('Marianne'),('Kara'),('Jacquelyn'),('Erma'),('Blanca'),('Myra'),('Leticia'),('Pat'),('Krista'),('Roxanne'),('Angelica'),('Johnnie'),('Robyn'),('Francis'),('Adrienne'),('Rosalie'),('Alexandra'),('Brooke'),('Bethany'),('Sadie'),('Bernadette'),('Traci'),('Jody'),('Kendra'),('Jasmine'),('Nichole'),('Rachael'),('Chelsea'),('Mable'),('Ernestine'),('Muriel'),('Marcella'),('Elena'),('Krystal'),('Angelina'),('Nadine'),('Kari'),('Estelle'),('Dianna'),('Paulette'),('Lora'),('Mona'),('Doreen'),('Rosemarie'),('Angel'),('Desiree'),('Antonia'),('Hope'),('Ginger'),('Janis'),('Betsy'),('Christie'),('Freda'),('Mercedes'),('Meredith'),('Lynette'),('Teri'),('Cristina'),('Eula'),('Leigh'),('Meghan'),('Sophia'),('Eloise'),('Rochelle'),('Gretchen'),('Cecelia'),('Raquel'),('Henrietta'),('Alyssa'),('Jana'),('Kelley'),('Gwen'),('Kerry'),('Jenna'),('Tricia'),('Laverne'),('Olive'),('Alexis'),('Tasha'),('Silvia'),('Elvira'),('Casey'),('Delia'),('Sophie'),('Kate'),('Patti'),('Lorena'),('Kellie'),('Sonja'),('Lila'),('Lana'),('Darla'),('May'),('Mindy'),('Essie'),('Mandy'),('Lorene'),('Elsa'),('Josefina'),('Jeannie'),('Miranda'),('Dixie'),('Lucia'),('Marta'),('Faith'),('Lela'),('Johanna'),('Shari'),('Camille'),('Tami'),('Shawna'),('Elisa'),('Ebony'),('Melba'),('Ora'),('Nettie'),('Tabitha'),('Ollie'),('Jaime'),('Winifred'),('Kristie'),('Marina'),('Alisha'),('Aimee'),('Rena'),('Myrna'),('Marla'),('Tammie'),('Latasha'),('Bonita'),('Patrice'),('Ronda'),('Sherrie'),('Addie'),('Francine'),('Deloris'),('Stacie'),('Adriana'),('Cheri'),('Shelby'),('Abigail'),('Celeste'),('Jewel'),('Cara'),('Adele'),('Rebekah'),('Lucinda'),('Dorthy'),('Chris'),('Effie'),('Trina'),('Reba'),('Shawn'),('Sallie'),('Aurora'),('Lenora'),('Etta'),('Lottie'),('Kerri'),('Trisha'),('Nikki'),('Estella'),('Francisca'),('Josie'),('Tracie'),('Marissa'),('Karin'),('Brittney'),('Janelle'),('Lourdes'),('Laurel'),('Helene'),('Fern'),('Elva'),('Corinne'),('Kelsey'),('Ina'),('Bettie'),('Elisabeth'),('Aida'),('Caitlin'),('Ingrid'),('Iva'),('Eugenia'),('Christa'),('Goldie'),('Cassie'),('Maude'),('Jenifer'),('Therese'),('Frankie'),('Dena'),('Lorna'),('Janette'),('Latonya'),('Candy'),('Morgan'),('Consuelo'),('Tamika'),('Rosetta'),('Debora'),('Cherie'),('Polly'),('Dina'),('Jewell'),('Fay'),('Jillian'),('Dorothea'),('Nell'),('Trudy'),('Esperanza'),('Patrica'),('Kimberley'),('Shanna'),('Helena'),('Carolina'),('Cleo'),('Stefanie'),('Rosario'),('Ola'),('Janine'),('Mollie'),('Lupe'),('Alisa'),('Lou'),('Maribel'),('Susanne'),('Bette'),('Susana'),('Elise'),('Cecile'),('Isabelle'),('Lesley'),('Jocelyn'),('Paige'),('Joni'),('Rachelle'),('Leola'),('Daphne'),('Alta'),('Ester'),('Petra'),('Graciela'),('Imogene'),('Jolene'),('Keisha'),('Lacey'),('Glenna'),('Gabriela'),('Keri'),('Ursula'),('Lizzie'),('Kirsten'),('Shana'),('Adeline'),('Mayra'),('Jayne'),('Jaclyn'),('Gracie'),('Sondra'),('Carmela'),('Marisa'),('Rosalind'),('Charity'),('Tonia'),('Beatriz'),('Marisol'),('Clarice'),('Jeanine'),('Sheena'),('Angeline'),('Frieda'),('Lily'),('Robbie'),('Shauna'),('Millie'),('Claudette'),('Cathleen'),('Angelia'),('Gabrielle'),('Autumn'),('Katharine'),('Summer'),('Jodie'),('Staci'),('Lea'),('Christi'),('Jimmie'),('Justine'),('Elma'),('Luella'),('Margret'),('Dominique'),('Socorro'),('Rene'),('Martina'),('Margo'),('Mavis'),('Callie'),('Bobbi'),('Maritza'),('Lucile'),('Leanne'),('Jeannine'),('Deana'),('Aileen'),('Lorie'),('Ladonna'),('Willa'),('Manuela'),('Gale'),('Selma'),('Dolly'),('Sybil'),('Abby'),('Lara'),('Dale'),('Ivy'),('Dee'),('Winnie'),('Leia')
    INSERT INTO @tblLastName(Name) VALUES('Smith'),('Johnson'),('Williams'),('Jones'),('Brown'),('Davis'),('Miller'),('Wilson'),('Moore'),('Taylor'),('Anderson'),('Thomas'),('Jackson'),('White'),('Harris'),('Martin'),('Thompson'),('Garcia'),('Martinez'),('Robinson'),('Clark'),('Rodriguez'),('Lewis'),('Lee'),('Walker'),('Hall'),('Allen'),('Young'),('Hernandez'),('King'),('Wright'),('Lopez'),('Hill'),('Scott'),('Green'),('Adams'),('Baker'),('Gonzalez'),('Nelson'),('Carter'),('Mitchell'),('Perez'),('Roberts'),('Turner'),('Phillips'),('Campbell'),('Parker'),('Evans'),('Edwards'),('Collins'),('Stewart'),('Sanchez'),('Morris'),('Rogers'),('Reed'),('Cook'),('Morgan'),('Bell'),('Murphy'),('Bailey'),('Rivera'),('Cooper'),('Richardson'),('Cox'),('Howard'),('Ward'),('Torres'),('Peterson'),('Gray'),('Ramirez'),('James'),('Watson'),('Brooks'),('Kelly'),('Sanders'),('Price'),('Bennett'),('Wood'),('Barnes'),('Ross'),('Henderson'),('Coleman'),('Jenkins'),('Perry'),('Powell'),('Long'),('Patterson'),('Hughes'),('Flores'),('Washington'),('Butler'),('Simmons'),('Foster'),('Gonzales'),('Bryant'),('Alexander'),('Russell'),('Griffin'),('Diaz'),('Hayes'),('Myers'),('Ford'),('Hamilton'),('Graham'),('Sullivan'),('Wallace'),('Woods'),('Cole'),('West'),('Jordan'),('Owens'),('Reynolds'),('Fisher'),('Ellis'),('Harrison'),('Gibson'),('Mcdonald'),('Cruz'),('Marshall'),('Ortiz'),('Gomez'),('Murray'),('Freeman'),('Wells'),('Webb'),('Simpson'),('Stevens'),('Tucker'),('Porter'),('Hunter'),('Hicks'),('Crawford'),('Henry'),('Boyd'),('Mason'),('Morales'),('Kennedy'),('Warren'),('Dixon'),('Ramos'),('Reyes'),('Burns'),('Gordon'),('Shaw'),('Holmes'),('Rice'),('Robertson'),('Hunt'),('Black'),('Daniels'),('Palmer'),('Mills'),('Nichols'),('Grant'),('Knight'),('Ferguson'),('Rose'),('Stone'),('Hawkins'),('Dunn'),('Perkins'),('Hudson'),('Spencer'),('Gardner'),('Stephens'),('Payne'),('Pierce'),('Berry'),('Matthews'),('Arnold'),('Wagner'),('Willis'),('Ray'),('Watkins'),('Olson'),('Carroll'),('Duncan'),('Snyder'),('Hart'),('Cunningham'),('Bradley'),('Lane'),('Andrews'),('Ruiz'),('Harper'),('Fox'),('Riley'),('Armstrong'),('Carpenter'),('Weaver'),('Greene'),('Lawrence'),('Elliott'),('Chavez'),('Sims'),('Austin'),('Peters'),('Kelley'),('Franklin'),('Lawson'),('Fields'),('Gutierrez'),('Ryan'),('Schmidt'),('Carr'),('Vasquez'),('Castillo'),('Wheeler'),('Chapman'),('Oliver'),('Montgomery'),('Richards'),('Williamson'),('Johnston'),('Banks'),('Meyer'),('Bishop'),('Mccoy'),('Howell'),('Alvarez'),('Morrison'),('Hansen'),('Fernandez'),('Garza'),('Harvey'),('Little'),('Burton'),('Stanley'),('Nguyen'),('George'),('Jacobs'),('Reid'),('Kim'),('Fuller'),('Lynch'),('Dean'),('Gilbert'),('Garrett'),('Romero'),('Welch'),('Larson'),('Frazier'),('Burke'),('Hanson'),('Day'),('Mendoza'),('Moreno'),('Bowman'),('Medina'),('Fowler'),('Brewer'),('Hoffman'),('Carlson'),('Silva'),('Pearson'),('Holland'),('Douglas'),('Fleming'),('Jensen'),('Vargas'),('Byrd'),('Davidson'),('Hopkins'),('May'),('Terry'),('Herrera'),('Wade'),('Soto'),('Walters'),('Curtis'),('Neal'),('Caldwell'),('Lowe'),('Jennings'),('Barnett'),('Graves'),('Jimenez'),('Horton'),('Shelton'),('Barrett'),('Obrien'),('Castro'),('Sutton'),('Gregory'),('Mckinney'),('Lucas'),('Miles'),('Craig'),('Rodriquez'),('Chambers'),('Holt'),('Lambert'),('Fletcher'),('Watts'),('Bates'),('Hale'),('Rhodes'),('Pena'),('Beck'),('Newman'),('Haynes'),('Mcdaniel'),('Mendez'),('Bush'),('Vaughn'),('Parks'),('Dawson'),('Santiago'),('Norris'),('Hardy'),('Love'),('Steele'),('Curry'),('Powers'),('Schultz'),('Barker'),('Guzman'),('Page'),('Munoz'),('Ball'),('Keller'),('Chandler'),('Weber'),('Leonard'),('Walsh'),('Lyons'),('Ramsey'),('Wolfe'),('Schneider'),('Mullins'),('Benson'),('Sharp'),('Bowen'),('Daniel'),('Barber'),('Cummings'),('Hines'),('Baldwin'),('Griffith'),('Valdez'),('Hubbard'),('Salazar'),('Reeves'),('Warner'),('Stevenson'),('Burgess'),('Santos'),('Tate'),('Cross'),('Garner'),('Mann'),('Mack'),('Moss'),('Thornton'),('Dennis'),('Mcgee'),('Farmer'),('Delgado'),('Aguilar'),('Vega'),('Glover'),('Manning'),('Cohen'),('Harmon'),('Rodgers'),('Robbins'),('Newton'),('Todd'),('Blair'),('Higgins'),('Ingram'),('Reese'),('Cannon'),('Strickland'),('Townsend'),('Potter'),('Goodwin'),('Walton'),('Rowe'),('Hampton'),('Ortega'),('Patton'),('Swanson'),('Joseph'),('Francis'),('Goodman'),('Maldonado'),('Yates'),('Becker'),('Erickson'),('Hodges'),('Rios'),('Conner'),('Adkins'),('Webster'),('Norman'),('Malone'),('Hammond'),('Flowers'),('Cobb'),('Moody'),('Quinn'),('Blake'),('Maxwell'),('Pope'),('Floyd'),('Osborne'),('Paul'),('Mccarthy'),('Guerrero'),('Lindsey'),('Estrada'),('Sandoval'),('Gibbs'),('Tyler'),('Gross'),('Fitzgerald'),('Stokes'),('Doyle'),('Sherman'),('Saunders'),('Wise'),('Colon'),('Gill'),('Alvarado'),('Greer'),('Padilla'),('Simon'),('Waters'),('Nunez'),('Ballard'),('Schwartz'),('Mcbride'),('Houston'),('Christensen'),('Klein'),('Pratt'),('Briggs'),('Parsons'),('Mclaughlin'),('Zimmerman'),('French'),('Buchanan'),('Moran'),('Copeland'),('Roy'),('Pittman'),('Brady'),('Mccormick'),('Holloway'),('Brock'),('Poole'),('Frank'),('Logan'),('Owen'),('Bass'),('Marsh'),('Drake'),('Wong'),('Jefferson'),('Park'),('Morton'),('Abbott'),('Sparks'),('Patrick'),('Norton'),('Huff'),('Clayton'),('Massey'),('Lloyd'),('Figueroa'),('Carson'),('Bowers'),('Roberson'),('Barton'),('Tran'),('Lamb'),('Harrington'),('Casey'),('Boone'),('Cortez'),('Clarke'),('Mathis'),('Singleton'),('Wilkins'),('Cain'),('Bryan'),('Underwood'),('Hogan'),('Mckenzie'),('Collier'),('Luna'),('Phelps'),('Mcguire'),('Allison'),('Bridges'),('Wilkerson'),('Nash'),('Summers'),('Atkins'),('Wilcox'),('Pitts'),('Conley'),('Marquez'),('Burnett'),('Richard'),('Cochran'),('Chase'),('Davenport'),('Hood'),('Gates'),('Clay'),('Ayala'),('Sawyer'),('Roman'),('Vazquez'),('Dickerson'),('Hodge'),('Acosta'),('Flynn'),('Espinoza'),('Nicholson'),('Monroe'),('Wolf'),('Morrow'),('Kirk'),('Randall'),('Anthony'),('Whitaker'),('Oconnor'),('Skinner'),('Ware'),('Molina'),('Kirby'),('Huffman'),('Bradford'),('Charles'),('Gilmore'),('Dominguez'),('Oneal'),('Bruce'),('Lang'),('Combs'),('Kramer'),('Heath'),('Hancock'),('Gallagher'),('Gaines'),('Shaffer'),('Short'),('Wiggins'),('Mathews'),('Mcclain'),('Fischer'),('Wall'),('Small'),('Melton'),('Hensley'),('Bond'),('Dyer'),('Cameron'),('Grimes'),('Contreras'),('Christian'),('Wyatt'),('Baxter'),('Snow'),('Mosley'),('Shepherd'),('Larsen'),('Hoover'),('Beasley'),('Glenn'),('Petersen'),('Whitehead'),('Meyers'),('Keith'),('Garrison'),('Vincent'),('Shields'),('Horn'),('Savage'),('Olsen'),('Schroeder')
    INSERT INTO @tblLastName(Name) VALUES('Hartman'),('Woodard'),('Mueller'),('Kemp'),('Deleon'),('Booth'),('Patel'),('Calhoun'),('Wiley'),('Eaton'),('Cline'),('Navarro'),('Harrell'),('Lester'),('Humphrey'),('Parrish'),('Duran'),('Hutchinson'),('Hess'),('Dorsey'),('Bullock'),('Robles'),('Beard'),('Dalton'),('Avila'),('Vance'),('Rich'),('Blackwell'),('York'),('Johns'),('Blankenship'),('Trevino'),('Salinas'),('Campos'),('Pruitt'),('Moses'),('Callahan'),('Golden'),('Montoya'),('Hardin'),('Guerra'),('Mcdowell'),('Carey'),('Stafford'),('Gallegos'),('Henson'),('Wilkinson'),('Booker'),('Merritt'),('Miranda'),('Atkinson'),('Orr'),('Decker'),('Hobbs'),('Preston'),('Tanner'),('Knox'),('Pacheco'),('Stephenson'),('Glass'),('Rojas'),('Serrano'),('Marks'),('Hickman'),('English'),('Sweeney'),('Strong'),('Prince'),('Mcclure'),('Conway'),('Walter'),('Roth'),('Maynard'),('Farrell'),('Lowery'),('Hurst'),('Nixon'),('Weiss'),('Trujillo'),('Ellison'),('Sloan'),('Juarez'),('Winters'),('Mclean'),('Randolph'),('Leon'),('Boyer'),('Villarreal'),('Mccall'),('Gentry'),('Carrillo'),('Kent'),('Ayers'),('Lara'),('Shannon'),('Sexton'),('Pace'),('Hull'),('Leblanc'),('Browning'),('Velasquez'),('Leach'),('Chang'),('House'),('Sellers'),('Herring'),('Noble'),('Foley'),('Bartlett'),('Mercado'),('Landry'),('Durham'),('Walls'),('Barr'),('Mckee'),('Bauer'),('Rivers'),('Everett'),('Bradshaw'),('Pugh'),('Velez'),('Rush'),('Estes'),('Dodson'),('Morse'),('Sheppard'),('Weeks'),('Camacho'),('Bean'),('Barron'),('Livingston'),('Middleton'),('Spears'),('Branch'),('Blevins'),('Chen'),('Kerr'),('Mcconnell'),('Hatfield'),('Harding'),('Ashley'),('Solis'),('Herman'),('Frost'),('Giles'),('Blackburn'),('William'),('Pennington'),('Woodward'),('Finley'),('Mcintosh'),('Koch'),('Best'),('Solomon'),('Mccullough'),('Dudley'),('Nolan'),('Blanchard'),('Rivas'),('Brennan'),('Mejia'),('Kane'),('Benton'),('Joyce'),('Buckley'),('Haley'),('Valentine'),('Maddox'),('Russo'),('Mcknight'),('Buck'),('Moon'),('Mcmillan'),('Crosby'),('Berg'),('Dotson'),('Mays'),('Roach'),('Church'),('Chan'),('Richmond'),('Meadows'),('Faulkner'),('Oneill'),('Knapp'),('Kline'),('Barry'),('Ochoa'),('Jacobson'),('Gay'),('Avery'),('Hendricks'),('Horne'),('Shepard'),('Hebert'),('Cherry'),('Cardenas'),('Mcintyre'),('Whitney'),('Waller'),('Holman'),('Donaldson'),('Cantu'),('Terrell'),('Morin'),('Gillespie'),('Fuentes'),('Tillman'),('Sanford'),('Bentley'),('Peck'),('Key'),('Salas'),('Rollins'),('Gamble'),('Dickson'),('Battle'),('Santana'),('Cabrera'),('Cervantes'),('Howe'),('Hinton'),('Hurley'),('Spence'),('Zamora'),('Yang'),('Mcneil'),('Suarez'),('Case'),('Petty'),('Gould'),('Mcfarland'),('Sampson'),('Carver'),('Bray'),('Rosario'),('Macdonald'),('Stout'),('Hester'),('Melendez'),('Dillon'),('Farley'),('Hopper'),('Galloway'),('Potts'),('Bernard'),('Joyner'),('Stein'),('Aguirre'),('Osborn'),('Mercer'),('Bender'),('Franco'),('Rowland'),('Sykes'),('Benjamin'),('Travis'),('Pickett'),('Crane'),('Sears'),('Mayo'),('Dunlap'),('Hayden'),('Wilder'),('Mckay'),('Coffey'),('Mccarty'),('Ewing'),('Cooley'),('Vaughan'),('Bonner'),('Cotton'),('Holder'),('Stark'),('Ferrell'),('Cantrell'),('Fulton'),('Lynn'),('Lott'),('Calderon'),('Rosa'),('Pollard'),('Hooper'),('Burch'),('Mullen'),('Fry'),('Riddle'),('Levy'),('David'),('Duke'),('Odonnell'),('Guy'),('Michael'),('Britt'),('Frederick'),('Daugherty'),('Berger'),('Dillard'),('Alston'),('Jarvis'),('Frye'),('Riggs'),('Chaney'),('Odom'),('Duffy'),('Fitzpatrick'),('Valenzuela'),('Merrill'),('Mayer'),('Alford'),('Mcpherson'),('Acevedo'),('Donovan'),('Barrera'),('Albert'),('Cote'),('Reilly'),('Compton'),('Raymond'),('Mooney'),('Mcgowan'),('Craft'),('Cleveland'),('Clemons'),('Wynn'),('Nielsen'),('Baird'),('Stanton'),('Snider'),('Rosales'),('Bright'),('Witt'),('Stuart'),('Hays'),('Holden'),('Rutledge'),('Kinney'),('Clements'),('Castaneda'),('Slater'),('Hahn'),('Emerson'),('Conrad'),('Burks'),('Delaney'),('Pate'),('Lancaster'),('Sweet'),('Justice'),('Tyson'),('Sharpe'),('Whitfield'),('Talley'),('Macias'),('Irwin'),('Burris'),('Ratliff'),('Mccray'),('Madden'),('Kaufman'),('Beach'),('Goff'),('Cash'),('Bolton'),('Mcfadden'),('Levine'),('Good'),('Byers'),('Kirkland'),('Kidd'),('Workman'),('Carney'),('Dale'),('Mcleod'),('Holcomb'),('England'),('Finch'),('Head'),('Burt'),('Hendrix'),('Sosa'),('Haney'),('Franks'),('Sargent'),('Nieves'),('Downs'),('Rasmussen'),('Bird'),('Hewitt'),('Lindsay'),('Le'),('Foreman'),('Valencia'),('Oneil'),('Delacruz'),('Vinson'),('Dejesus'),('Hyde'),('Forbes'),('Gilliam'),('Guthrie'),('Wooten'),('Huber'),('Barlow'),('Boyle'),('Mcmahon'),('Buckner'),('Rocha'),('Puckett'),('Langley'),('Knowles'),('Cooke'),('Velazquez'),('Whitley'),('Noel'),('Vang'),('Shea'),('Rouse'),('Hartley'),('Mayfield'),('Elder'),('Rankin'),('Hanna'),('Cowan'),('Lucero'),('Arroyo'),('Slaughter'),('Haas'),('Oconnell'),('Minor'),('Kendrick'),('Shirley'),('Kendall'),('Boucher'),('Archer'),('Boggs'),('Odell'),('Dougherty'),('Andersen'),('Newell'),('Crowe'),('Wang'),('Friedman'),('Bland'),('Swain'),('Holley'),('Felix'),('Pearce'),('Childs'),('Yarbrough'),('Galvan'),('Proctor'),('Meeks'),('Lozano'),('Mora'),('Rangel'),('Bacon'),('Villanueva'),('Schaefer'),('Rosado'),('Helms'),('Boyce'),('Goss'),('Stinson'),('Smart'),('Lake'),('Ibarra'),('Hutchins'),('Covington'),('Reyna'),('Gregg'),('Werner'),('Crowley'),('Hatcher'),('Mackey'),('Bunch'),('Womack'),('Polk'),('Jamison'),('Dodd'),('Childress'),('Childers'),('Camp'),('Villa'),('Dye'),('Springer'),('Mahoney'),('Dailey'),('Belcher'),('Lockhart'),('Griggs'),('Costa'),('Connor'),('Brandt'),('Winter'),('Walden'),('Moser'),('Tracy'),('Tatum'),('Mccann'),('Akers'),('Lutz'),('Pryor'),('Law'),('Orozco'),('Mcallister'),('Lugo'),('Davies'),('Shoemaker'),('Madison'),('Rutherford'),('Newsome'),('Magee'),('Chamberlain'),('Blanton'),('Simms'),('Godfrey'),('Flanagan'),('Crum'),('Cordova'),('Escobar'),('Downing'),('Sinclair'),('Donahue'),('Krueger'),('Mcginnis'),('Gore'),('Farris'),('Webber'),('Corbett'),('Andrade'),('Starr'),('Lyon'),('Yoder'),('Hastings'),('Mcgrath'),('Spivey'),('Krause'),('Harden'),('Crabtree'),('Kirkpatrick'),('Hollis'),('Brandon'),('Arrington'),('Ervin'),('Clifton'),('Ritter'),('Mcghee'),('Bolden'),('Maloney'),('Gagnon'),('Dunbar'),('Ponce'),('Pike'),('Mayes'),('Heard'),('Beatty'),('Mobley'),('Kimball'),('Butts'),('Montes'),('Herbert'),('Grady'),('Eldridge'),('Braun'),('Hamm'),('Gibbons'),('Seymour'),('Moyer'),('Manley'),('Herron'),('Plummer'),('Elmore'),('Cramer'),('Gary'),('Rucker'),('Hilton'),('Blue'),('Pierson'),('Fontenot'),('Field'),('Ganaye')
    INSERT INTO Occupation(OccupationName) VALUES('Actor'),('Actuary'),('Advertising'),('Advocate'),('Aeronautical Engineer'),('Aerospace Industry Trades'),('Agricultural Economist'),('Agricultural Engineer'),('Agricultural Extension Officer'),('Agricultural Inspector'),('Agricultural Technician'),('Agriculture'),('Agriculturist'),('Agronomist'),('Air Traffic Controller'),('Ambulance Emergency Care Worker'),('Animal Scientist'),('Anthropologist'),('Aquatic Scientist'),('Archaeologist'),('Architect'),('Architectural Technologist'),('Archivist'),('Area Manager'),('Armament Fitter'),('Armature Winder'),('Art Editor'),('Artist'),('Assayer Sampler'),('Assembly Line Worker'),('Assistant Draughtsman'),('Astronomer'),('Attorney'),('Auctioneer'),('Auditor'),('Automotive Body Repairer'),('Automotive Electrician'),('Automotive Mechinist'),('Automotive Trimmer'),('Babysitting Career'),('Banking Career'),('Beer Brewing'),('Biochemist'),('Biokineticist'),('Biologist'),('Biomedical Engineer'),('Biomedicaltechnologist'),('Blacksmith'),('Boilermaker'),('Bookbinder'),('Bookkeeper'),('Botanist'),('Branch Manager'),('Bricklayer'),('Bus Driver'),('Business Analyst'),('Business Economist'),('Butler'),('Cabin Attendant'),('Carpenter'),('Cartographer'),('Cashier'),('Ceramics Technologist'),('Chartered Accountant'),('Chartered Management Accountant'),('Chartered Secretary'),('Chemical Engineer'),('Chemist'),('Chiropractor'),('City Treasurer'),('Civil Engineer'),('Civil Investigator'),('Cleaner'),('Clergyman'),('Clerk'),('Clinical Engineering'),('Clinical Technologist'),('Clothing Designer'),('Clothing Manager'),('Coal Technologist'),('Cobbler'),('Committee Clerk'),('Computer Industry'),('Concrete Technician'),('Conservation And Wildlife'),('Construction Manager'),('Copy Writer'),('Correctional Services'),('Costume Designer'),('Crane Operator'),('Credit Controller'),('Crop Protection And Animal Health'),('Customer And Excise Officer'),('Customer Service Agent'),('Dancer'),('Data Capturer'),('Database Administrator'),('Dealer In Oriental Carpets'),('Decor Designer'),('Dental Assistant And Oral Hygienist'),('Dental Technician'),('Dental Therapist'),('Dentist'),('Detective'),('Diamond Cutting'),('Diesel Fitter'),('Diesel Loco Driver'),('Diesel Mechanic'),('Die-Sinker And Engraver'),('Dietician'),('Diver'),('Dj'),('Domestic Appliance Mechanician'),('Domestic Personnel'),('Domestic Radio And Television Mechanician'),('Domestic Worker'),('Draughtsman'),('Driver And Stacker'),('Earth Moving Equipment Mechanic'),('Ecologist'),('Economist Technician'),('Editor'),('Eeg Technician'),('Electrical And Electronic Engineer'),('Electrical Engineering Technician'),('Electrician'),('Electrician (Construction)'),('Engineering'),('Engineering Technician'),('Entomologist'),('Environmental Health Officer'),('Estate Agent'),('Explosive Expert'),('Explosive Technologist'),('Extractive Metallurgist'),('Farm Foreman'),('Farm Worker'),('Farmer'),('Fashion Buyer'),('Film And Production'),('Financial And Investment Manager'),('Fire-Fighter'),('Fireman At The Airport'),('Fitter And Turner'),('Flight Engineer'),('Florist'),('Food Scientist And Technologist'),('Footwear'),('Forester Service'),('Funeral Director'),('Furrier'),('Game Ranger'),('Gardener'),('Geneticist'),('Geographer'),('Geologist'),('Geotechnologist'),('Goldsmith And Jeweller'),('Grain Grader'),('Graphic Designer'),('Gravure Machine Minder'),('Hairdresser'),('Herpetologist'),('Home Economist'),('Homoeopath'),('Horticulturist'),('Hospital Porter'),('Hospitality Industry'),('Human Resource Manager'),('Hydrologist'),('Ichthyologist'),('Industrial Designer'),('Industrial Engineer'),('Industrial Engineering Technologist'),('Industrial Technician'),('Inspector'),('Instrument Maker'),('Insurance'),('Interior Designer'),('Interpreter'),('Inventory And Store Manager'),('Jeweler'),('Jockey'),('Joiner And Woodmachinist'),('Journalist'),('Knitter'),('Labourer'),('Land Surveyor'),('Landscape Architect'),('Law'),('Learner Official'),('Leather Chemist'),('Leather Worker'),('Lecturer'),('Librarian'),('Life-Guard'),('Lift Mechanic'),('Light Delivery Van Driver'),('Linesman'),('Locksmith'),('Machine Operator'),('Machine Worker'),('Magistrate'),('Mail Handler'),('Make-Up Artist'),('Management Consultant'),('Manager'),('Marine Biologist'),('Marketing'),('Marketing Manager'),('Materials Engineer'),('Mathematician'),('Matron'),('Meat Cutting Technician'),('Mechanical Engineer'),('Medical Doctor'),('Medical Orthotist Prosthetist'),('Medical Physicist'),('Merchandise Planner'),('Messenger'),('Meteorological Technician'),('Meteorologist'),('Meter-Reader'),('Microbiologist'),('Mine Surveyor'),('Miner'),('Mining Engineer'),('Model'),('Model Builder'),('Motor Mechanic'),('Musician'),('Nature Conservator'),('Navigating Officer'),('Navigator'),('Nuclear Scientist'),('Nursing'),('Nutritionist'),('Occupational Therapist'),('Oceanographer'),('Operations Researcher'),('Optical Dispenser'),('Optical Technician'),('Optometrist'),('Ornithologist'),('Paint Technician'),('Painter And Decorator'),('Paper Technologist'),('Patent Attorney'),('Personal Trainer'),('Personnel Consultant'),('Petroleum Technologist'),('Pharmacist'),('Pharmacist Assistant'),('Photographer'),('Physicist'),('Physiologist'),('Physiotherapist'),('Piano Tuner'),('Pilot'),('Plumber'),('Podiatrist'),('Police Officer'),('Post Office Clerk'),('Power Plant Operator'),('Private Secretary'),('Production Manager'),('Project Manager'),('Projectionist'),('Psychologist'),('Psychometrist'),('Public Relations Practitioner'),('Purchasing Manager'),('Quality Control Inspector'),('Quantity Surveyor'),('Radiation Protectionist'),('Radio'),('Radiographer'),('Receptionist'),('Recreation Manager'),('Rigger'),('Road Construction Plant Operator'),('Roofer'),('Rubber Technologist'),('Sales Representative'),('Salesperson'),('Saw Operator'),('Scale Fitter'),('Sea Transport Worker'),('Secretary'),('Security Officer'),('Sheetmetal Worker'),('Shop Assistant'),('Shopfitter'),('Singer'),('Social Worker'),('Sociologist'),('Soil Scientist'),('Speech And Language Therapist'),('Sport Manager'),('Spray Painter'),('Statistician'),('Swimming Pool Superintendent'),('Systems Analyst'),('Tailor'),('Taxidermist'),('Teacher'),('Technical Illustrator'),('Technical Writer'),('Teller'),('Terminologist'),('Textile Designer'),('Theatre Technology'),('Tourism Manager'),('Traffic Officer'),('Translator'),('Travel Agent'),('Typist'),('Valuer And Appraiser'),('Vehicle Driver'),('Veterinary Nurse'),('Veterinary Surgeon'),('Viticulturist'),('Watchmaker'),('Weather Observer'),('Weaver'),('Welder'),('Wood Scientist'),('Wood Technologist'),('Yard Official'),('Zoologist')
    -- names largely inspired from http://www.publiclibraries.com/
    INSERT INTO @tblStreetNames VALUES ('%sz% %nth% Street'),('P.O. Box %bn%'),('%sn% %sz% Route %rn%'),('%sz% %nth% Avenue'),('%sn% %sz% County Route %rn%'),('%sn% %sz% State Route %rn%'),('%sz% %nth%  Road'),('%sn% %sz% Church %st%'),('%sn% %sz% Maple %st%'),('%sn% %sz% Second %st%'),('%sn% %sz% Washington %st%'),('%sn% %sz% Third %st%'),('%sn% %sz% Elm %st%'),('%sn% %sz% Broadway'),('%sn% %sz% Genesee %st%'),('%sn% %sz% Central %st%'),('%sn% %sz% Fifth %st%'),('%sn% %sz% First %st%'),('%sn% %sz% State %st%'),('%sn% %sz% Broad %st%'),('%sn% %sz% Library %st%'),('%sn% %sz% Market %st%'),('%sn% %sz% School %st%'),('%sn% %sz% Oak %st%'),('%sn% %sz% Union %st%'),('%sn% %sz% Franklin %st%'),('%sn% %sz% Lake %st%'),('%sn% %sz% Village %st%'),('%sn% %sz% Canal %st%'),('%sn% %sz% Civic %st%'),('%sn% %sz% Grand %st%'),('%sn% %sz% Lincoln %st%'),('%sn% %sz% Morris %st%'),('%sn% %sz% River %st%'),('%sn% %sz% Front %st%'),('%sn% %sz% Northern %st%'),('%sn% %sz% Jefferson %st%'),('%sn% %sz% Pacific %st%'),('%sn% %sz% Richmond %st%'),('%sn% %sz% Seventh %st%'),('%sn% %sz% University %st%'),('%sn% %sz% Bedford %st%'),('%sn% %sz% Cedar %st%'),('%sn% %sz% Chapel %st%'),('%sn% %sz% Clinton %st%'),('%sn% %sz% Delaware %st%'),('%sn% %sz% Erie %st%'),('%sn% %sz% Fourth %st%'),('%sn% %sz% Harbor %st%'),('%sn% %sz% Hillside %st%'),('%sn% %sz% Hudson %st%'),('%sn% %sz% Lafayette %st%'),('%sn% %sz% Merrick %st%'),('%sn% %sz% Ocean %st%'),('%sn% %sz% Railroad %st%'),('%sn% %sz% Ridge %st%'),('%sn% %sz% Salina %st%'),('%sn% %sz% Barnes %st%'),('%sn% %sz% Chestnut %st%'),('%sn% %sz% Jackson %st%'),('%sn% %sz% Mission %st%'),('%sn% %sz% Orange %st%'),('%sn% %sz% Pearl %st%'),('%sn% %sz% Sixth %st%'),('%sn% %sz% Walnut %st%'),('%sn% %sz% Williams %st%'),('%sn% %sz% Academy %st%'),('%sn% %sz% Amsterdam %st%'),('%sn% %sz% Astoria %st%'),('%sn% %sz% Auburn %st%'),('%sn% %sz% Bell %st%'),('%sn% %sz% Buffalo %st%'),('%sn% %sz% Cayuga %st%'),('%sn% %sz% Colonial %st%'),('%sn% %sz% Elmwood %st%'),('%sn% %sz% Essex %st%'),('%sn% %sz% Ferry %st%'),('%sn% %sz% Forest %st%'),('%sn% %sz% Fulton %st%'),('%sn% %sz% Grand Army %st%'),('%sn% %sz% Greenwood %st%'),('%sn% %sz% Hempstead %st%'),('%sn% %sz% High %st%'),('%sn% %sz% Highland %st%'),('%sn% %sz% Jerusalem %st%'),('%sn% %sz% John %st%'),('%sn% %sz% Laurel %st%'),('%sn% %sz% Linden %st%'),('%sn% %sz% Madison %st%'),('%sn% %sz% Magnolia %st%'),('%sn% %sz% Metropolitan %st%'),('%sn% %sz% Miller %st%'),('%sn% %sz% Mohawk %st%'),('%sn% %sz% Monroe %st%'),('%sn% %sz% Montcalm %st%'),('%sn% %sz% Moorpark %st%'),('%sn% %sz% Mountain %st%'),('%sn% %sz% Nichols %st%'),('%sn% %sz% Ogden %st%'),('%sn% %sz% Old Post %st%'),('%sn% %sz% Rockaway %st%'),('%sn% %sz% Rockaway Beach %st%'),('%sn% %sz% Santa Monica %st%'),('%sn% %sz% Seneca %st%'),('%sn% %sz% Sullivan %st%'),('%sn% %sz% Utica %st%'),('%sn% %sz% Victory %st%'),('%sn% %sz% Vince Tofany %st%'),('%sn% %sz% Water %st%'),('%sn% %sz% Westchester %st%'),('%sn% %sz% Western %st%'),('%sn% %sz% Atlantic %st%'),('%sn% %sz% Bullis %st%'),('%sn% %sz% Caroline %st%'),('%sn% %sz% Centre %st%'),('%sn% %sz% Clark %st%'),('%sn% %sz% College %st%'),('%sn% %sz% Columbia %st%'),('%sn% %sz% Columbus %st%'),('%sn% %sz% Compton %st%'),('%sn% %sz% Cortland %st%'),('%sn% %sz% Crenshaw %st%'),('%sn% %sz% Day %st%'),('%sn% %sz% Division %st%'),('%sn% %sz% Fiske %st%'),('%sn% %sz% Garfield %st%'),('%sn% %sz% Hopkins %st%'),('%sn% %sz% Huntington Dr. %st%'),('%sn% %sz% James %st%'),('%sn% %sz% Jersey %st%'),('%sn% %sz% Kings %st%'),('%sn% %sz% Lawrence %st%'),('%sn% %sz% Leland %st%'),('%sn% %sz% Lexington %st%'),('%sn% %sz% Mariposa %st%'),('%sn% %sz% Middlefield %st%'),('%sn% %sz% Mill %st%'),('%sn% %sz% Montecito %st%'),('%sn% %sz% Ninth %st%'),('%sn% %sz% Noble %st%'),('%sn% %sz% Orchard %st%'),('%sn% %sz% Pike %st%'),('%sn% %sz% Powell %st%'),('%sn% %sz% Whitney %st%'),('%sn% %sz% Wildwood %st%'),('%sn% %sz% Woodrow %st%'),('%sn% %sz% Adam Clayton Powell, Jr. %st%'),('%sn% %sz% Adams %st%'),('%sn% %sz% Albany %st%'),('%sn% %sz% Albany Shaker %st%'),('%sn% %sz% Alder %st%'),('%sn% %sz% Aldrich %st%'),('%sn% %sz% Alma %st%'),('%sn% %sz% Almond %st%'),('%sn% %sz% Amboy %st%'),('%sn% %sz% American Legion %st%'),('%sn% %sz% Arkie Albanese %st%'),('%sn% %sz% Arlington %st%'),('%sn% %sz% Arnett %st%'),('%sn% %sz% Artesia %st%'),('%sn% %sz% Asch Loop %st%'),('%sn% %sz% Astor %st%'),('%sn% %sz% Avalon %st%'),('%sn% %sz% Avocado %st%'),('%sn% %sz% Bailey %st%'),('%sn% %sz% Baird %st%'),('%sn% %sz% Bank %st%'),('%sn% %sz% Banta Suite 200 %st%'),('%sn% %sz% Bartlett %st%'),('%sn% %sz% Barton %st%'),('%sn% %sz% Bayview %st%'),('%sn% %sz% Beach 54 %st%'),('%sn% %sz% Beaver Dam %st%'),('%sn% %sz% Bedell %st%'),('%sn% %sz% Belmont %st%'),('%sn% %sz% Bennett %st%'),('%sn% %sz% Blue Point %st%'),('%sn% %sz% Bluegrass %st%'),('%sn% %sz% Bona Venture %st%'),('%sn% %sz% Boon %st%'),('%sn% %sz% Boston Post %st%'),('%sn% %sz% Boston State %st%'),('%sn% %sz% Bowen %st%'),('%sn% %sz% Bradley %st%'),('%sn% %sz% Bridge %st%'),('%sn% %sz% Brown %st%'),('%sn% %sz% Bruce %st%'),('%sn% %sz% Brunswick %st%'),('%sn% %sz% Brutus %st%'),('%sn% %sz% Buckram %st%'),('%sn% %sz% Budd %st%'),('%sn% %sz% Bull %st%'),('%sn% %sz% Bungtown %st%'),('%sn% %sz% Busti-Sugar Grove %st%'),('%sn% %sz% Butternut %st%'),('%sn% %sz% Calkins %st%'),('%sn% %sz% Canada %st%'),('%sn% %sz% Carll %st%'),('%sn% %sz% Castle Hill %st%'),('%sn% %sz% Castleton %st%'),('%sn% %sz% Chenango %st%'),('%sn% %sz% Cherry %st%'),('%sn% %sz% Chili %st%'),('%sn% %sz% Church At. Rockaway %st%'),('%sn% %sz% City Island %st%'),('%sn% %sz% Civic Suite %st%'),('%sn% %sz% Clarke %st%'),('%sn% %sz% Clarkson Hamlin %st%'),('%sn% %sz% Classic %st%'),('%sn% %sz% Cleveland %st%'),('%sn% %sz% Clinton Union %st%'),('%sn% %sz% Closter %st%'),('%sn% %sz% Clover %st%'),('%sn% %sz% Clubhouse %st%'),('%sn% %sz% Clymer %st%'),('%sn% %sz% Cohen %st%'),('%sn% %sz% Collins %st%'),('%sn% %sz% Commercial %st%'),('%sn% %sz% Commonwealth %st%'),('%sn% %sz% Community %st%'),('%sn% %sz% Cook %st%'),('%sn% %sz% Cooper %st%'),('%sn% %sz% Coopers Farm %st%'),('%sn% %sz% Cragsmoor %st%'),('%sn% %sz% Craig %st%'),('%sn% %sz% Crane %st%'),('%sn% %sz% Creamery %st%'),('%sn% %sz% Crosby %st%'),('%sn% %sz% Cross Bay %st%'),('%sn% %sz% Croton %st%'),('%sn% %sz% Cuyler %st%'),('%sn% %sz% Dakota %st%'),('%sn% %sz% Davison %st%'),('%sn% %sz% Dayan %st%'),('%sn% %sz% Deauville %st%'),('%sn% %sz% Decatur %st%'),('%sn% %sz% Deer %st%'),('%sn% %sz% Depot %st%'),('%sn% %sz% Dewey %st%'),('%sn% %sz% Dillon %st%'),('%sn% %sz% Douglas %st%'),('%sn% %sz% Dove %st%'),('%sn% %sz% Dr. Samuel Mccree %st%'),('%sn% %sz% Draper %st%'),('%sn% %sz% Duanesburg %st%'),('%sn% %sz% Eames %st%'),('%sn% %sz% Eastern %st%'),('%sn% %sz% Eastwood %st%'),('%sn% %sz% Eighth %st%'),('%sn% %sz% El Camino Real %st%'),('%sn% %sz% Eldert %st%'),('%sn% %sz% Elizabeth %st%'),('%sn% %sz% Elmgrove %st%'),('%sn% %sz% Ely %st%'),('%sn% %sz% Emerald %st%'),('%sn% %sz% Falls %st%'),('%sn% %sz% Farmedge %st%'),('%sn% %sz% Farmers %st%'),('%sn% %sz% Florence %st%'),('%sn% %sz% Fluvanna %st%'),('%sn% %sz% Flywheel %st%'),('%sn% %sz% Foothill %st%'),('%sn% %sz% Fort Hill %st%'),('%sn% %sz% Francis Lewis %st%'),('%sn% %sz% Frankfort %st%'),('%sn% %sz% Freedom Plains %st%'),('%sn% %sz% Friendly %st%'),('%sn% %sz% Fruitvale %st%'),('%sn% %sz% Galena %st%'),('%sn% %sz% Gardiner %st%'),('%sn% %sz% George %st%'),('%sn% %sz% Gerritsen Bartlett %st%'),('%sn% %sz% Giffords %st%'),('%sn% %sz% Gilliland %st%'),('%sn% %sz% Glasgow %st%'),('%sn% %sz% Glebe %st%'),('%sn% %sz% Glen %st%'),('%sn% %sz% Glen Cove %st%'),('%sn% %sz% Glenn %st%'),('%sn% %sz% Glenridge %st%'),('%sn% %sz% Graham %st%'),('%sn% %sz% Grant %st%'),('%sn% %sz% Greeley %st%'),('%sn% %sz% Greenbush %st%'),('%sn% %sz% Greenpoint %st%'),('%sn% %sz% Gun Hill %st%'),('%sn% %sz% Guy R. Brewer %st%'),('%sn% %sz% Hamlin Clarkson %st%'),('%sn% %sz% Harlem %st%'),('%sn% %sz% Harris %st%'),('%sn% %sz% Harrisburg %st%'),('%sn% %sz% Harvard %st%'),('%sn% %sz% Haseco %st%'),('%sn% %sz% Hauppauge %st%'),('%sn% %sz% Hawley %st%'),('%sn% %sz% Hawthorne %st%'),('%sn% %sz% Helderberg %st%'),('%sn% %sz% Henrietta %st%'),('%sn% %sz% Henry %st%'),('%sn% %sz% Henry Johnson %st%'),('%sn% %sz% Hepburn %st%'),('%sn% %sz% Hertel %st%'),('%sn% %sz% Hicksville %st%'),('%sn% %sz% Higbie %st%'),('%sn% %sz% Hillsdale %st%'),('%sn% %sz% Holbrook %st%'),('%sn% %sz% Hollis %st%'),('%sn% %sz% Honeywell %st%'),('%sn% %sz% Horace Harding Expressway %st%'),('%sn% %sz% Houston %st%'),('%sn% %sz% Huguenot %st%'),('%sn% %sz% Idle Hour %st%'),('%sn% %sz% Imperial %st%'),('%sn% %sz% International %st%'),('%sn% %sz% Irving %st%'),('%sn% %sz% Ivory %st%'),('%sn% %sz% Jamestown %st%'),('%sn% %sz% Jericho %st%'),('%sn% %sz% Jewel %st%'),('%sn% %sz% Jillson %st%'),('%sn% %sz% John James Audubon %st%'),('%sn% %sz% Joseph %st%'),('%sn% %sz% Katonah %st%'),('%sn% %sz% Kelly %st%'),('%sn% %sz% Kentucky %st%'),('%sn% %sz% Kern %st%'),('%sn% %sz% Kings Ferry %st%'),('%sn% %sz% Kingsbridge %st%'),('%sn% %sz% Kingsbury %st%'),('%sn% %sz% Kirby %st%'),('%sn% %sz% Knower %st%'),('%sn% %sz% Knowledge %st%'),('%sn% %sz% Lake Shore %st%'),('%sn% %sz% Lakeshore %st%'),('%sn% %sz% Lakeville %st%'),('%sn% %sz% Larchmont %st%'),('%sn% %sz% Lawmar %st%'),('%sn% %sz% Lefferts %st%'),('%sn% %sz% Lehigh %st%'),('%sn% %sz% Leroy %st%'),('%sn% %sz% Lewis %st%'),('%sn% %sz% Liberty %st%'),('%sn% %sz% Liberty Rock %st%'),('%sn% %sz% Lilac %st%'),('%sn% %sz% Live Oak %st%'),('%sn% %sz% Lockport %st%'),('%sn% %sz% Long Beach %st%'),('%sn% %sz% Lorraine %st%'),('%sn% %sz% Los Alamos %st%'),('%sn% %sz% Losson %st%'),('%sn% %sz% Lowerre %st%'),('%sn% %sz% Lyell %st%'),('%sn% %sz% Lyons %st%'),('%sn% %sz% Madison 34th %st%'),('%sn% %sz% Malcolm X %st%'),('%sn% %sz% Mamaroneck %st%'),('%sn% %sz% Maples %st%'),('%sn% %sz% Marathon %st%'),('%sn% %sz% Marcellus %st%'),('%sn% %sz% Marconi %st%'),('%sn% %sz% Martin Luther King, Jr. %st%'),('%sn% %sz% Martine %st%'),('%sn% %sz% Mccoy %st%'),('%sn% %sz% Meadow %st%'),('%sn% %sz% Meadowbrook %st%'),('%sn% %sz% Mechanic %st%'),('%sn% %sz% Meridian %st%'),('%sn% %sz% Merritts %st%'),('%sn% %sz% Merry %st%'),('%sn% %sz% Middlery %st%'),('%sn% %sz% Middletown %st%'),('%sn% %sz% Miller Hill %st%'),('%sn% %sz% Millpond %st%'),('%sn% %sz% Milton %st%'),('%sn% %sz% Mitchell %st%'),('%sn% %sz% Moe %st%'),('%sn% %sz% Monell %st%'),('%sn% %sz% Montauk %st%'),('%sn% %sz% Montgomery %st%'),('%sn% %sz% Montrose %st%'),('%sn% %sz% Morrison %st%'),('%sn% %sz% Morton %st%'),('%sn% %sz% Mosholu %st%'),('%sn% %sz% Mother Gaston %st%'),('%sn% %sz% Mt. Baker %st%'),('%sn% %sz% Murray %st%'),('%sn% %sz% Naches %st%'),('%sn% %sz% Naples %st%'),('%sn% %sz% Nelson %st%'),('%sn% %sz% Nevada %st%'),('%sn% %sz% New Dorp %st%'),('%sn% %sz% New Hartford %st%'),('%sn% %sz% New Scotland %st%'),('%sn% %sz% Newbridge %st%'),('%sn% %sz% Newport %st%'),('%sn% %sz% Nicholas %st%'),('%sn% %sz% Nicolet %st%'),('%sn% %sz% Nostrand %st%'),('%sn% %sz% Nostrand Near %st%'),('%sn% %sz% Nott %st%'),('%sn% %sz% Oakridge %st%'),('%sn% %sz% Oakwood %st%'),('%sn% %sz% Oldry %st%'),('%sn% %sz% Onderdonk %st%'),('%sn% %sz% Oneida %st%'),('%sn% %sz% Oriental %st%'),('%sn% %sz% Oscawana Lake %st%'),('%sn% %sz% Osceola %st%'),('%sn% %sz% Oswego %st%'),('%sn% %sz% Overland %st%'),('%sn% %sz% Oyster Bay %st%'),('%sn% %sz% Packetts %st%'),('%sn% %sz% Palatine %st%'),('%sn% %sz% Paper Mill %st%'),('%sn% %sz% Parkview %st%'),('%sn% %sz% Pestle %st%'),('%sn% %sz% Peterboro %st%'),('%sn% %sz% Pidgeon Hill %st%'),('%sn% %sz% Pine %st%'),('%sn% %sz% Plank %st%'),('%sn% %sz% Pondfield %st%'),('%sn% %sz% Ponquogue %st%'),('%sn% %sz% Portage %st%'),('%sn% %sz% Porter %st%'),('%sn% %sz% Pratt %st%'),('%sn% %sz% Pritchard %st%'),('%sn% %sz% Proctor %st%'),('%sn% %sz% Prospect %st%'),('%sn% %sz% Public %st%'),('%sn% %sz% Public Works %st%'),('%sn% %sz% Purchase %st%'),('%sn% %sz% Quogue %st%'),('%sn% %sz% Rainier %st%'),('%sn% %sz% Ralph Near %st%'),('%sn% %sz% Ramapo %st%'),('%sn% %sz% Ransomville %st%'),('%sn% %sz% Read %st%'),('%sn% %sz% Riverside %st%'),('%sn% %sz% Robin %st%'),('%sn% %sz% Rock %st%'),('%sn% %sz% Rock City %st%'),('%sn% %sz% Roosevelt Av. %st%'),('%sn% %sz% Ross %st%'),('%sn% %sz% Sag Harbor %st%'),('%sn% %sz% Saint Edwards %st%'),('%sn% %sz% Salina %st%'),('%sn% %sz% San Vicente %st%'),('%sn% %sz% Sanford %st%'),('%sn% %sz% Santa Clara %st%'),('%sn% %sz% Santa Fe %st%'),('%sn% %sz% Schuyler %st%'),('%sn% %sz% Scofield %st%'),('%sn% %sz% Searingtown %st%'),('%sn% %sz% Seaview %st%'),('%sn% %sz% Sedgwick %st%'),('%sn% %sz% Sheridan %st%'),('%sn% %sz% Sherrill %st%'),('%sn% %sz% Silver Spur %st%'),('%sn% %sz% Sir Francis Drake %st%'),('%sn% %sz% Skillman %st%'),('%sn% %sz% Slauson %st%'),('%sn% %sz% Soundview %st%'),('%sn% %sz% Southern %st%'),('%sn% %sz% Sponable %st%'),('%sn% %sz% Spring %st%'),('%sn% %sz% Springfield %st%'),('%sn% %sz% Station %st%'),('%sn% %sz% Stevenson %st%'),('%sn% %sz% Stewart %st%'),('%sn% %sz% Stockton %st%'),('%sn% %sz% Strawtown %st%'),('%sn% %sz% Suite 2 %st%'),('%sn% %sz% Summit %st%'),('%sn% %sz% Sutphin %st%'),('%sn% %sz% Sutter %st%'),('%sn% %sz% Sybils %st%'),('%sn% %sz% Tarrytown %st%'),('%sn% %sz% Telephone %st%'),('%sn% %sz% Terryville %st%'),('%sn% %sz% Thomas %st%'),('%sn% %sz% Thomas %st%'),('%sn% %sz% Thomas Indian School %st%'),('%sn% %sz% Thompson %st%'),('%sn% %sz% Thomson %st%'),('%sn% %sz% Thornton %st%'),('%sn% %sz% Titicus %st%'),('%sn% %sz% Tonawanda %st%'),('%sn% %sz% Torrance %st%'),('%sn% %sz% Trenton Falls %st%'),('%sn% %sz% Truxtun %st%'),('%sn% %sz% Tulip %st%'),('%sn% %sz% Tunstead %st%'),('%sn% %sz% Ulster %st%'),('%sn% %sz% Uniondale %st%'),('%sn% %sz% Utica Near Tilden %st%'),('%sn% %sz% Vancouver %st%'),('%sn% %sz% Vanderbilt %st%'),('%sn% %sz% Vanowen %st%'),('%sn% %sz% Ventura %st%'),('%sn% %sz% Vernon %st%'),('%sn% %sz% Verona %st%'),('%sn% %sz% Vestal %st%'),('%sn% %sz% Veterans Memorial %st%'),('%sn% %sz% Victoria Pl. %st%'),('%sn% %sz% Vine %st%'),('%sn% %sz% Vleigh %st%'),('%sn% %sz% Walton %st%'),('%sn% %sz% Warner %st%'),('%sn% %sz% Washington %st%'),('%sn% %sz% Waterstone %st%'),('%sn% %sz% Waverly %st%'),('%sn% %sz% Webster %st%'),('%sn% %sz% Wellesley %st%'),('%sn% %sz% Wembley Dr. %st%'),('%sn% %sz% Wesley %st%'),('%sn% %sz% Whippoorwill %st%'),('%sn% %sz% Whitaker %st%'),('%sn% %sz% White %st%'),('%sn% %sz% Willets %st%'),('%sn% %sz% Willett %st%'),('%sn% %sz% William %st%'),('%sn% %sz% William Floyd %st%'),('%sn% %sz% Willis %st%'),('%sn% %sz% Winton %st%'),('%sn% %sz% Wolcott %st%'),('%sn% %sz% Woodbridge %st%'),('%sn% %sz% Woodfield %st%'),('%sn% %sz% Woodgate %st%'),('%sn% %sz% Woods %st%'),('%sn% %sz% York %st%'),('%sn% %sz% Young %st%')
    INSERT INTO @tblStreetTypes VALUES('Street'),('St.'),('Avenue'),('Ave.'),('Road'),('Blvd.'),('Rd.'),('Boulevard'),('Drive'),('Lane'),('St'),('Ave'),('Way'),('Place'),('Blvd'),('Rd'),('Parkway'),('Highway'),('Plaza'),('Turnpike'),('Extension'),('Square'),('Hwy'),('Hwy.'),('Trail'),('Circle'),('Court'),('Mall'),('Pkwy.'),('Center'),('Green'),('Landing'),('Park'),('Crossing')
    INSERT INTO @tblStreetZones VALUES(''),(''),(''),('North'),('South'),('East'),('West'),('Lower'),('Main'),('Old')
    -- http://www.realestate3d.com/gps/latlong.htm
    -- http://en.wikipedia.org/wiki/List_of_United_States_cities_by_population
    INSERT INTO @tblCity(Name, statecode, longitude, latitude, popul, surface) VALUES('New York', 'NY', '40.77', '73.98', '8175133', '302.6'),('Los Angeles', 'CA', '33.93', '118.4', '3792621', '468.7'),('Chicago', 'IL', '41.98', '87.9', '2695598', '227.6'),('Houston', 'TX', '29.97', '95.35', '2099451', '599.6'),('Philadelphia', 'PA', '39.88', '75.25', '1526006', '134.1'),('Phoenix', 'AZ', '33.43', '112.02', '1445632', '516.7'),('San Antonio', 'TX', '29.53', '98.47', '1327407', '460.9'),('San Diego', 'CA', '32.82', '117.17', '1307402', '325.2'),('Dallas', 'TX', '32.97', '97.03', '1197816', '340.5'),('San Jose', 'CA', '37.37', '121.92', '945942', '176.5'),('Jacksonville', 'NC', '34.82', '81.7', '821784', '747'),('Indianapolis', 'IN', '39.73', '86.27', '820445', '361.4'),('San Francisco', 'CA', '37.75', '122.68', '805235', '46.9'),('Austin', 'TX', '39.83', '117.13', '790390', '297.9'),('Columbus', 'OH', '41.45', '97.35', '787033', '217.2'),('Fort Worth', 'TX', '32.82', '97.35', '741206', '339.8'),('Charlotte', 'VA', '38.13', '80.93', '731424', '297.7'),('Detroit', 'MN', '46.82', '95.88', '713777', '138.8'),('El Paso', 'TX', '31.8', '106.4', '649121', '255.2'),('Memphis', 'TN', '35.35', '90', '646889', '315.1'),('Baltimore', 'MD', '39.33', '76.67', '620961', '80.9'),('Boston', 'MA', '42.37', '71.03', '617594', '48.3'),('Seattle', 'WA', '47.53', '122.3', '608660', '83.9'),('Washington', 'DC', '38.95', '77.46', '601723', '61'),('Nashville', 'TN', '36.12', '86.68', '601222', '475.1'),('Denver', 'CO', '39.75', '104.87', '600158', '153'),('Louisville', 'KY', '38.23', '85.73', '597337', '325.2'),('Milwaukee', 'WI', '43.12', '88.05', '594833', '96.1'),('Portland', 'OR', '45.6', '122.6', '583776', '133.4'),('Las Vegas', 'NV', '36.08', '115.17', '583756', '135.8'),('Albuquerque', 'NM', '35.05', '106.6', '545852', '187.7'),('Tucson', 'AZ', '32.12', '110.93', '520116', '226.7'),('Fresno', 'CA', '36.77', '119.72', '494665', '112'),('Sacramento', 'CA', '38.7', '121.6', '466488', '97.9'),('Long Beach', 'CA', '33.82', '118.15', '462257', '50.3'),('Kansas City', 'MO', '39.32', '94.72', '459787', '315'),('Atlanta', 'GA', '33.88', '84.52', '420003', '133.2'),('Omaha', 'NE', '41.3', '95.9', '408958', '127.1'),('Raleigh', 'NC', '35.87', '78.78', '403892', '142.9'),('Miami', 'FL', '25.92', '80.43', '399457', '35.9'),('Cleveland', 'OH', '41.57', '81.87', '396815', '77.7'),('Tulsa', 'OK', '36.2', '95.9', '391906', '196.8'),('Oakland', 'CA', '37.73', '122.22', '390724', '55.8'),('Minneapolis', 'MN', '45.07', '93.47', '382578', '54'),('Wichita', 'TX', '37.65', '98.5', '382368', '159.3'),('Bakersfield', 'CA', '35.43', '119.05', '347483', '142.2'),('New Orleans', 'LA', '30.03', '90.25', '343829', '169.4'),('Honolulu', 'HI', '21.35', '157.93', '337256', '60.5'),('Tampa', 'FL', '27.97', '82.53', '335709', '113.4'),('Aurora', 'OR', '45.25', '122.75', '325078', '154.7'),('Santa Ana', 'CA', '33.67', '117.88', '324528', '27.3'),('Pittsburgh', 'PA', '40.5', '80.22', '305704', '55.4'),('Riverside', 'CA', '33.95', '117.45', '303871', '81.1'),('Cincinnati', 'OH', '39.1', '84.67', '296943', '77.9'),('Lexington', 'KY', '38.05', '85', '295803', '283.6'),('Anchorage', 'AK', '61.22', '150.02', '291826', '1704.7'),('Stockton', 'CA', '37.9', '121.25', '291707', '61.7'),('Toledo', 'WA', '46.48', '122.8', '287208', '80.7'),('Saint Paul', 'MN', '44.93', '93.05', '285068', '52'),('Newark', 'NJ', '40.7', '74.17', '277140', '24.2'),('Greensboro', 'NC', '36.08', '79.95', '269666', '126.5'),('Buffalo', 'NY', '42.93', '78.73', '261310', '40.4'),('Lincoln', 'NE', '40.85', '96.75', '258379', '89.1'),('Fort Wayne', 'IN', '41', '85.2', '253691', '110.6'),('Norfolk', 'VA', '41.98', '97.43', '242803', '54.1'),('Orlando', 'FL', '28.55', '81.33', '238300', '102.4'),('Laredo', 'TX', '27.53', '99.47', '236091', '88.9'),('Madison', 'WI', '43.13', '89.33', '233209', '76.8'),('Winston-Salem', 'NC', '36.13', '80.23', '229617', '132.4'),('Lubbock', 'TX', '33.65', '101.82', '229573', '122.4'),('Baton Rouge', 'LA', '30.53', '91.15', '229493', '76.9'),('Reno', 'NV', '39.5', '119.78', '225221', '103'),('Chesapeake', 'VA', '37.5', '76.2', '222209', '340.8'),('Scottsdale', 'AZ', '33.62', '111.92', '217385', '183.9'),('Birmingham', 'AL', '33.57', '86.75', '212237', '146.1'),('Rochester', 'NY', '43.92', '92.5', '210565', '54.6'),('Spokane', 'WA', '47.67', '117.53', '208916', '59.2'),('Montgomery', 'AL', '32.3', '86.4', '205764', '159.6'),('Boise', 'ID', '43.57', '116.22', '205671', '79.4'),('Richmond', 'VA', '37.5', '77.33', '204214', '59.8'),('Des Moines', 'IA', '41.53', '93.65', '203433', '80.9'),('Modesto', 'CA', '37.63', '120.95', '201165', '36.9'),('Fayetteville', 'NC', '36', '94.17', '200654', '145.8'),('Shreveport', 'LA', '32.52', '93.82', '199311', '105.4'),('Akron', 'CO', '40.17', '103.22', '199110', '62'),('Tacoma', 'WA', '47.27', '122.58', '198397', '49.7'),('Oxnard', 'CA', '34.2', '119.2', '197899', '26.9'),('Augusta', 'ME', '44.32', '81.97', '195844', '302.5'),('Mobile', 'AL', '30.68', '88.25', '195111', '139.1'),('Little Rock', 'AR', '35.22', '92.38', '193524', '119.2'),('Amarillo', 'TX', '35.23', '101.7', '190695', '99.5'),('Grand Rapids', 'MN', '47.22', '93.52', '188040', '44.4'),('Tallahassee', 'FL', '30.38', '84.37', '181376', '100.2'),('Worcester', 'MA', '42.27', '71.87', '181045', '37.4'),('Newport News', 'VA', '37.13', '76.5', '180719', '68.7'),('Huntsville', 'AL', '34.65', '86.77', '180105', '209.1'),('Knoxville', 'TN', '35.82', '83.98', '178874', '98.5'),('Providence', 'RI', '41.73', '71.43', '178042', '18.4'),('Brownsville', 'TX', '25.9', '97.43', '175023', '132.3'),('Jackson', 'WY', '43.6', '110.73', '173514', '111'),('Santa Rosa', 'CA', '38.52', '122.82', '167815', '41.3'),('Chattanooga', 'TN', '35.03', '85.2', '167674', '137.2'),('Ontario', 'OR', '44.02', '117.62', '163924', '49.9'),('Springfield', 'MO', '39.85', '93.38', '159498', '81.7'),('Lancaster', 'PA', '40.13', '118.22', '156633', '94.3'),('Eugene', 'OR', '44.12', '123.22', '156185', '43.7'),('Salem', 'OR', '44.92', '123', '154637', '47.9'),('Peoria', 'IL', '40.67', '89.68', '154065', '174.4'),('Sioux Falls', 'SD', '43.58', '96.73', '153888', '73'),('Rockford', 'IL', '42.2', '89.1', '152871', '61.1'),('Palmdale', 'CA', '35.05', '118.13', '152750', '106'),('Corona', 'NM', '34.1', '105.68', '152374', '38.8'),('Salinas', 'CA', '36.67', '121.6', '150441', '23.2'),('Torrance', 'CA', '33.8', '118.33', '145438', '20.5'),('Syracuse', 'NY', '43.12', '76.12', '145170', '25'),('Bridgeport', 'CT', '41.17', '73.13', '144229', '16'),('Hayward', 'CA', '37.65', '122.12', '144186', '45.3'),('Dayton', 'OH', '39.9', '84.2', '141527', '55.7'),('Alexandria', 'MN', '45.87', '95.38', '139966', '15'),('Savannah', 'GA', '32.13', '81.2', '136286', '103.2'),('Fullerton', 'CA', '33.87', '117.97', '135161', '22.4'),('Clarksville', 'TN', '36.62', '87.42', '132929', '97.6'),('McAllen', 'TX', '26.18', '98.23', '129877', '48.3'),('New Haven', 'CT', '41.27', '72.9', '129779', '18.7'),('Columbia', 'SC', '38.82', '92.22', '129272', '132.2'),('Killeen', 'TX', '31.08', '97.68', '127921', '53.6'),('Topeka', 'KS', '39.07', '95.67', '127473', '60.2'),('Cedar Rapids', 'IA', '41.88', '91.7', '126326', '70.8'),('Olathe', 'KS', '38.85', '94.9', '125872', '59.7'),('Elizabeth', 'NC', '36.27', '76.18', '124969', '12.3'),('Waco', 'TX', '31.62', '97.22', '124805', '89'),('Hartford', 'CT', '41.73', '72.65', '124775', '17.4'),('Visalia', 'CA', '36.32', '119.4', '124442', '36.2'),('Gainesville', 'FL', '29.68', '82.27', '124354', '61.3'),('Concord', 'NH', '43.2', '122.05', '122067', '30.5'),('Miramar', 'CA', '32.87', '117.15', '122041', '29.5'),('Lafayette', 'LA', '30.2', '92', '120623', '49.2'),('Charleston', 'WV', '38.37', '81.6', '120083', '109'),('Beaumont', 'CA', '33.93', '116.95', '118296', '82.8'),('Allentown', 'PA', '40.65', '75.43', '118032', '17.5'),('Evansville', 'IN', '38.05', '87.53', '117429', '44.2'),('Abilene', 'TX', '32.42', '99.68', '117063', '106.8'),('Athens', 'OH', '39.21', '83.32', '115452', '116.4'),('Lansing', 'MI', '42.77', '84.6', '114297', '36'),('Ann Arbor', 'MI', '42.22', '83.75', '113934', '27.8'),('El Monte', 'CA', '34.08', '118.03', '113475', '9.6'),('Provo', 'UT', '40.22', '111.72', '112488', '41.7'),('Midland', 'TX', '31.95', '102.18', '111147', '72.1'),('Norman', 'OK', '35.23', '97.47', '110925', '178.8'),('Manchester', 'NH', '42.93', '71.43', '109565', '33.1'),('Pueblo', 'CO', '38.28', '104.52', '106595', '53.6'),('Wilmington', 'VT', '42.88', '77.92', '106476', '51.5'),('Fargo', 'ND', '46.9', '96.8', '105549', '48.8'),('Carlsbad', 'NM', '33.13', '117.28', '105328', '37.7'),('Fairfield', 'NJ', '40.87', '74.28', '105321', '37.4'),('Billings', 'MT', '45.8', '108.53', '104170', '43.4'),('Green Bay', 'WI', '44.48', '88.13', '104057', '45.5'),('Burbank', 'CA', '34.2', '118.37', '103340', '17.3'),('Flint', 'MI', '42.97', '83.75', '102434', '33.4'),('Erie', 'PA', '42.08', '80.18', '101786', '19.1'),('South Bend', 'IN', '41.7', '86.32', '101168', '41.5')

    DECLARE @tblLatinWords TABLE (LatinWordsId [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY, Name varchar(40))
    INSERT INTO @tblLatinWords VALUES ('ad'),('do'),('ea'),('et'),('eu'),('ex'),('id'),('in'),('ut'),('non'),('qui'),('sed'),('sit'),('est'),('duis'),('elit'),('enim'),('esse'),('amet'),('anim'),('aute'),('sunt'),('sint'),('quis'),('nisi'),('lorem'),('velit'),('nulla'),('dolor'),('culpa'),('magna'),('minim'),('ipsum'),('irure'),('exclamo'),('labore'),('mollit'),('dolore'),('cillum'),('aliqua'),('fugiat'),('tempor'),('veniam'),('ullamco'),('nostrud'),('officia'),('aliquip'),('commodo'),('eiusmod'),('laboris'),('laborum'),('deserunt'),('animus'), ('pariatur'),('proident'),('occaecat'),('prae'),('penitus'),('voluptate'),('misericordia'),('consequat'),('cupidatat'),('excepteur'),('incididunt'),('consectetur'),('adipisicing'),('numerus'),('exercitation'),('reprehenderit')
    DECLARE @tblColor TABLE (ColorId [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY, Name varchar(40))
    DECLARE @tblMoreColor TABLE (ColorId [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY, Name varchar(40))
    DECLARE @tblFabricType TABLE (FabricTypeId [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY, Name varchar(40))
    DECLARE @tblFabricExtra TABLE (FabricExtraId [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY, Name varchar(40))
    DECLARE @tblTempProduct TABLE (ProductId [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY, ProductName varchar(80))
    INSERT INTO @tblColor(name) VALUES ('white'),('cream'),('lemon'),('yellow'),('cerise'),('pink'),('lilac'),('purple'),('sky blue'),('turquoise'),('royal blue'),('navy'),('lime'),('grass'),('green'),('orange'),('rust'),('red'),('bordeaux'),('khakhi'),('beige'),('black'),('multicolor')
    INSERT INTO @tblFabricType(name) VALUES ('fleece fabric'),('sequin fabric'),('100% cotton jersey fabric'),('gingham fabric'),('polycotton fabric'),('polyester organza voile fabric'),('satin fabric'),('faux fur'),('calico'),('stretch fabric'),('felt fabric'),('velvet fabric'),('leatherette fabric'),('curtain lining'),('stretch wool suiting fabric'),('crushed velvet dress fabric'),('corduroy fabric')
    INSERT INTO @tblFabricExtra(name) VALUES ('mushrooms'),('ducks'),('flowers'),('circles'),('hearts'),('bicycles'),('bears'),('dots'),('squares'),('smurfs'),('mickeys'),('pearls')
    -- not used
    --INSERT INTO @tblMoreColor(name) VALUES ('alice blue'),('antique white'),('aquamarine'),('azure'),('beige'),('bisque'),('black'),('blanched almond'),('blue'),('blue violet'),('brown'),('burlywood'),('cadet blue'),('chartreuse'),('chocolate'),('coral'),('cornflower blue'),('cornsilk'),('cyan'),('dark goldenrod'),('dark green'),('dark khaki'),('dark olive green'),('dark orange'),('dark orchid'),('dark salmon'),('dark sea green'),('dark slate blue'),('dark slate gray'),('dark turquoise'),('dark violet'),('deep pink'),('deep sky blue'),('dim gray'),('dodger blue'),('firebrick'),('floral white'),('forest green'),('gainsboro'),('ghost white'),('gold'),('goldenrod'),('gray'),('green yellow'),('honeydew'),('hot pink'),('indian red'),('ivory'),('khaki'),('lavender'),('lavender blush'),('lawn green'),('lemon chiffon'),('light blue'),('light coral'),('light cyan'),('light goldenrod'),('light goldenrod yellow'),('light gray'),('light pink'),('light salmon'),('light sea green'),('light sky blue'),('light slate blue'),('light slate gray'),('light steel blue'),('light yellow'),('lime green'),('linen'),('maroon'),('medium aquamarine'),('medium blue'),('medium orchid'),('medium purple'),('medium sea green'),('medium slate blue'),('medium spring green'),('medium turquoise'),('medium violet red'),('midnight blue'),('mint cream'),('misty rose'),('moccasin'),('navajo white'),('navy'),('old lace'),('olive drab'),('orange'),('orange red'),('orchid'),('pale goldenrod'),('pale green'),('pale turquoise'),('pale violet red'),('papaya whip'),('peach puff'),('peru'),('pink'),('plum'),('powder blue'),('purple'),('red'),('rosy brown'),('royal blue'),('saddle brown'),('salmon'),('sandy brown'),('sea green'),('seashell'),('sienna'),('sky blue'),('slate blue'),('slate gray'),('snow'),('spring green'),('steel blue'),('tan'),('thistle'),('tomato'),('turquoise'),('violet'),('violet red'),('wheat'),('white'),('white smoke'),('yellow'),('yellow green')
    DECLARE @ProductName AS VARCHAR(80)
    DECLARE @ColorCount   AS INTEGER = (SELECT COUNT(*) FROM @tblColor)
    DECLARE @MoreColorCount   AS INTEGER = (SELECT COUNT(*) FROM @tblMoreColor)
    DECLARE @FabricTypeCount   AS INTEGER = (SELECT COUNT(*) FROM @tblFabricType)
    DECLARE @FabricExtraCount   AS INTEGER = (SELECT COUNT(*) FROM @tblFabricExtra)

    DECLARE @Color        AS VARCHAR(80)
    DECLARE @Color2       AS VARCHAR(80)
    DECLARE @MoreColor    AS VARCHAR(80)
    DECLARE @FabricType   AS VARCHAR(80)
    DECLARE @FabricExtra  AS VARCHAR(80)
    CREATE TABLE Product (ProductId INTEGER IDENTITY (1, 1) NOT NULL CONSTRAINT pk_ProductId PRIMARY KEY, ProductName varchar(80), Price SMALLMONEY, Active BIT, Stock NUMERIC(18,3))

    INSERT INTO Product(ProductName, Price, Active, Stock)
        SELECT UPPER(SUBSTRING(FullName,1,1))+SUBSTRING(FullName,2,255) [FullName],
        (50 + ABS(CHECKSUM([Fabric])) % 50 + CASE WHEN [Motif]='' THEN 0 ELSE 10 + ABS(CHECKSUM([Motif]) % 10) END) /10.0 [Price],
        1,
        FLOOR(RAND() * 200000)/100.0
        FROM
        (SELECT C.name + ' ' + F.NAME [FullName], F.NAME [Fabric],'' [Motif]
                FROM @tblColor C
                CROSS JOIN @tblFabricType F
            UNION ALL
                SELECT C.name + ' ' + F.NAME + ' with ' + C2.NAME + ' ' + E.NAME [FullName], F.Name [Fabric], e.Name [Motif]
                    FROM @tblColor C
                    CROSS JOIN @tblFabricType F
                    CROSS JOIN @tblColor C2
                    CROSS JOIN @tblFabricExtra E
                    WHERE C.NAME != C2.NAME
                    AND CHECKSUM(C.name + ' ' + F.NAME + ' with ' + C2.NAME + ' ' + E.NAME) % 100 = 0 -- take pseudo-random 1%
                    ) NAMES

    DECLARE @MaleFirstNameCount   AS INTEGER = (SELECT COUNT(*) FROM @tblMaleFirstName)
    DECLARE @FemaleFirstNameCount AS INTEGER = (SELECT COUNT(*) FROM @tblFemaleFirstName)
    DECLARE @LastNameCount        AS INTEGER = (SELECT COUNT(*) FROM @tblLastName)
    DECLARE @OccupationCount      AS INTEGER = (SELECT COUNT(*) FROM Occupation)

    DECLARE @StreetNamesCount AS INTEGER = (SELECT COUNT(*) FROM @tblStreetNames)
    DECLARE @StreetZonesCount AS INTEGER = (SELECT COUNT(*) FROM @tblStreetZones)
    DECLARE @tblStreetTypesCount AS INTEGER = (SELECT COUNT(*) FROM @tblStreetTypes)
    DECLARE @CityCount            AS INTEGER = (SELECT COUNT(*) FROM @tblCity)
    DECLARE @LatinWordsCount      AS INTEGER = (SELECT COUNT(*) FROM @tblLatinWords)
    DECLARE @FirstName            AS VARCHAR(255)
    DECLARE @MiddleName           AS VARCHAR(255)
    DECLARE @LastName             AS VARCHAR(255)


    DECLARE @DateOfBirth          AS DATETIME
    DECLARE @CreditRating         AS INTEGER
    DECLARE @Gender               AS CHAR
    DECLARE @Dummy                AS INTEGER = RAND(@Randomizer)
    DECLARE @XCode                AS CHAR(7)
    DECLARE @OccupationId         AS INTEGER

    DECLARE @TelephoneNumber      AS VARCHAR(20)

    DECLARE @CityId               AS INTEGER
    DECLARE @Street1              AS VARCHAR(100)
    DECLARE @Street2              AS VARCHAR(100)
    DECLARE @City                 AS VARCHAR(100)
    DECLARE @ZipCode              AS VARCHAR(15)
    DECLARE @Longitude            AS FLOAT
    DECLARE @Latitude             AS FLOAT

    DECLARE @Notes                AS VARCHAR(max)

    DECLARE @ClientId             AS INTEGER = 0
    DECLARE @Number                  AS INTEGER = 0
    WHILE @ClientId < @CreateClients
    BEGIN
        SET @ClientId = @ClientId + 1

        -- Name and personal info
        IF RAND() >= 0.5
            SELECT @FirstName = (SELECT Name FROM @tblMaleFirstName WHERE MaleFirstNameId = (FLOOR(POWER(RAND(),1.5) * @MaleFirstNameCount) + 1)),
                 @MiddleName = (SELECT Name FROM @tblMaleFirstName WHERE MaleFirstNameId = (FLOOR(POWER(RAND(),1.2) * @MaleFirstNameCount) + 1)),
                 @Gender = 'M'
        ELSE
            SELECT @FirstName = (SELECT Name FROM @tblFemaleFirstName WHERE FemaleFirstNameId = (FLOOR(POWER(RAND(),1.5) * @FemaleFirstNameCount) + 1)),
                @MiddleName = (SELECT Name FROM @tblFemaleFirstName WHERE FemaleFirstNameId = (FLOOR(POWER(RAND(),1.2) * @FemaleFirstNameCount) + 1)),
                @Gender = 'F'

        IF RAND()>0.9 SET @MiddleName = NULL     -- we clear the middle Name for 10% of the population
        SET @LastName = (SELECT Name FROM @tblLastName WHERE LastNameId = (FLOOR(POWER(RAND(),1.5) * @LastNameCount) + 1))

        SET @DateOfBirth = CONVERT(datetime, '1991-01-11', 126) - FLOOR(POWER(RAND(),1.5)* 365.0 * 80.0) -- clients are between 18 and 98 years old
        SET @xCode = CHAR(FLOOR(RAND() * 26)+65) + CHAR(FLOOR(RAND() * 26)+65) + CHAR(FLOOR(RAND() * 10)+48)
             + ' ' + CHAR(FLOOR(RAND() * 10)+48) + CHAR(FLOOR(RAND() * 26)+65) + CHAR(FLOOR(RAND() * 26)+65)
        SET @OccupationId = FLOOR(RAND() * @OccupationCount) + 1
        SET @CityId = (FLOOR(POWER(RAND(),1.5) * @CityCount) + 1)
        SET @CreditRating = FLOOR(POWER(RAND(), 1 + (ABS(CHECKSUM(@CityId)) % 7.0) * (@OccupationId / @OccupationCount)) * 10)

        -- Address
        SELECT @City = C.Name,
            @Longitude = C.longitude + RAND() - 0.5,
            @Latitude = C.latitude + RAND() * 2 - 1
            FROM @tblCity C  WHERE C.CityId = @CityId
        SET @Street1 = (SELECT Name FROM @tblStreetNames WHERE StreetNamesId = (FLOOR(POWER(RAND(),1.5) * @StreetNamesCount) + 1))

        IF CHARINDEX('%sn%',@Street1) > 0 SET @Street1 = REPLACE(@Street1,'%sn%', FLOOR(POWER(RAND(),1.5) * 5000 + 1))
        IF CHARINDEX('%sz%',@Street1) > 0 SET @Street1 = REPLACE(@Street1,'%sz%', (SELECT Name FROM @tblStreetZones WHERE StreetZoneId = (FLOOR(RAND()*  @StreetZonesCount) + 1)))
        IF CHARINDEX('%st%',@Street1) > 0 SET @Street1 = REPLACE(@Street1,'%st%', (SELECT Name FROM @tblStreetTypes WHERE StreetTypesId = (FLOOR(RAND()*  RAND() * @tblStreetTypesCount) + 1)))
        IF CHARINDEX('%nth%',@Street1) > 0
        BEGIN
            SET @Number = FLOOR(RAND()*RAND()*200)+1
            SELECT @Street1 = REPLACE(@Street1,'%nth%',
                CAST(@Number AS VARCHAR(255)) + CASE WHEN @Number IN (11,12,13) THEN 'th' ELSE CASE @Number % 10 WHEN 1 THEN 'st' WHEN 2 THEN 'nd' WHEN 3 THEN 'rd' ELSE 'th' END END)
        END
        IF CHARINDEX('%rn%',@Street1) > 0 SET @Street1 = REPLACE(@Street1,'%rn%', CAST(FLOOR(RAND() * 95 + 5) AS VARCHAR(255)))
        IF CHARINDEX('%bn%',@Street1) > 0 SET @Street1 = REPLACE(@Street1,'%bn%', CAST(FLOOR(RAND() * 1500 + 5) AS VARCHAR(255)))
        SET @Street1 = RTRIM(LTRIM(REPLACE(REPLACE(@Street1,'   ',' '),'  ',' ')))
        SET @Street2 = NULL
        SET @TelephoneNumber = (SELECT '(' + CAST(FLOOR(RAND()* 900)+100 AS VARCHAR(255)) +  ') ' + CAST(FLOOR(RAND()* 900)+100 AS VARCHAR(255)) + ' - ' + right('0000' + CAST(FLOOR(RAND()* 10000) AS VARCHAR(255)) , 4))
        SET @ZipCode = CAST((SELECT FLOOR(RAND()* 90000) + 10000) AS VARCHAR(255))
        IF (RAND()>0.5)
        BEGIN
            IF (RAND()>0.5)
                SET @Street2 = 'Flat ' + CAST(FLOOR(POWER(RAND(),1.5) * 25 + 1) AS VARCHAR(255))
            ELSE
            BEGIN
                SET @Number = FLOOR(RAND()*RAND()*15)+1
                SELECT @Street2 = CAST(@Number AS VARCHAR(255)) + CASE WHEN @Number IN (11,12,13) THEN 'th' ELSE CASE @Number % 10 WHEN 1 THEN 'st' WHEN 2 THEN 'nd' WHEN 3 THEN 'rd' ELSE 'th' END END
                    + ' Floor'
            END
        END

        -- notes

        DECLARE @Word AS VARCHAR(255)

        DECLARE @String        AS VARCHAR(MAX)
        DECLARE @StringLength  AS INT
        DECLARE @NotesLength   AS INT
        SET @NotesLength = FLOOR(POWER(RAND(),1.5) * 100) + 1
        SET @Notes = null
        WHILE @NotesLength > 0
        BEGIN
            SET @NotesLength = @NotesLength - 1
            SET @StringLength = FLOOR(POWER(RAND(),1.5) * 7) + 3
            SET @String = null
            WHILE @StringLength > 0
            BEGIN
                SET @StringLength = @StringLength - 1
                SELECT @Word = (SELECT Name FROM @tblLatinWords WHERE LatinWordsId = (FLOOR(POWER(RAND(),1.5) * @LatinWordsCount) + 1))
                SET @String = CASE WHEN @String IS NULL THEN UPPER(SUBSTRING(@Word,1,1)) + SUBSTRING(@Word,2,LEN(@Word)-1)
                    ELSE @String +' '+ @Word END
            END
            SET @String = @String + '.'
            SET @Notes = CASE WHEN @Notes IS NULL THEN @String
                ELSE @Notes + ' ' + @String END
        END
        INSERT INTO @tblTempClient    -- WITH (NOWAIT) doesn't seem to improve time
            (FirstName, MiddleName, LastName, DateOfBirth, Gender, CreditRating, XCode, OccupationId,
            TelephoneNumber, Street1, Street2, City, ZipCode, Longitude, Latitude, Notes)
            VALUES (@FirstName, @MiddleName,  @LastName,  @DateOfBirth, @Gender, @CreditRating, @XCode, @OccupationId,
            @TelephoneNumber, @Street1, @Street2, @City, @ZipCode, @Longitude, @Latitude, @Notes)

        IF (@ClientId % @BulkInsertSize = 0) OR (@ClientId = @CreateClients)
        BEGIN
            PRINT 'Creating Clients: ' + CAST((@ClientId * 100 / @CreateClients) AS VARCHAR) + '%                                                                                                                                                                                      '
            INSERT INTO Client SELECT * FROM @tblTempClient
            DELETE FROM @tblTempClient -- why can't we truncate temp-table?
        END
    END
    DECLARE @ProductCount         AS INTEGER = (SELECT COUNT(*) FROM Product)
    DECLARE @ClientCount          AS INTEGER = (SELECT COUNT(*) FROM Client)
    DECLARE @OrderId              AS INTEGER = 0
    DECLARE @LineTotal            AS NUMERIC(18,2)
    DECLARE @OrderTotal           AS NUMERIC(18,2)
    DECLARE @ProductId            AS INTEGER
    DECLARE @Qty                  AS NUMERIC(18,3)

    CREATE TABLE [Order] (OrderId INTEGER NOT NULL CONSTRAINT pkOrderId PRIMARY KEY, ClientId INT, OrderDate DATETIME,
        OrderTotal NUMERIC(18,2), OrderStatus CHAR)

    DECLARE @tblTempOrder TABLE (OrderId INT, ClientId INT, OrderDate DATETIME, OrderTotal NUMERIC(18,2), OrderStatus CHAR)
    DECLARE @tblTempOrderLine TABLE (OrderId INT, LineNumber INT, ProductId INT, Qty NUMERIC(18, 3), LineTotal NUMERIC(18,2))
    WHILE @OrderId < @CreateOrders
    BEGIN
        SET @OrderId = @OrderId + 1
        DECLARE @OrderDate AS DATETIME =  CONVERT(datetime, '2011-01-11', 126) -  FLOOR(3650.0 * (@CreateOrders - @OrderId) / @CreateOrders ) + 0.375 + 0.5 * (1 - POWER(RAND(),1.5));
        INSERT INTO @tblTempOrder(OrderId, ClientId, OrderDate, OrderStatus)
            VALUES(
            @OrderId,
            FLOOR(POWER(RAND(),1.5) * @ClientCount) + 1,
            @OrderDate,
            CASE
                WHEN @OrderDate > '1 June, 2011' AND RAND()> 0.5 THEN -- Recent orders
                    CASE FLOOR(RAND()*2)
                        WHEN 0 THEN 'O' -- Open
                        ELSE 'S' -- StandBy
                    END

                ELSE
                    CASE FLOOR(RAND()*10)
                        WHEN 0 THEN 'R' -- Refunded
                        WHEN 1 THEN 'C' -- Canceled
                        WHEN 2 THEN 'C' -- Canceled
                        ELSE 'P' -- Paid
                    END
            END
            )

        DECLARE @LineNumber AS INTEGER = 1 + FLOOR(POWER(RAND(),1.5) * 15)
        SET @OrderTotal = 0

        WHILE @LineNumber > 0
        BEGIN
            SET @ProductId = FLOOR(POWER(RAND(),1.5) * @ProductCount) + 1
            SET @Qty = FLOOR(RAND() * 20 + 1) * FLOOR(RAND() * 20 + 1) * 5.0 / POWER(10,FLOOR(RAND() * 3))
            SET @LineTotal = ROUND(@Qty * (SELECT Price FROM Product WHERE ProductId = @ProductId),2)
            SET @OrderTotal = @OrderTotal + @LineTotal

            INSERT INTO @tblTempOrderLine(OrderId, LineNumber, ProductId, Qty, LineTotal)
            VALUES(@OrderId,
                @LineNumber,
                @ProductId,
                @Qty,
                @LineTotal)
            SET @LineNumber = @LineNumber - 1
        END

        UPDATE @tblTempOrder SET OrderTotal = @OrderTotal WHERE OrderId = @OrderId

        IF (@OrderId % @BulkInsertSize = 0) OR (@OrderId = @CreateOrders)
        BEGIN
            PRINT 'Creating Orders: ' + CAST((@OrderId * 100 / @CreateOrders) AS VARCHAR) + '%                                                                                                                                                                                      '
            INSERT INTO [Order] SELECT * FROM @tblTempOrder
            DELETE FROM @tblTempOrder
            INSERT INTO [OrderLine] SELECT * FROM @tblTempOrderLine
            DELETE FROM @tblTempOrderLine
        END
    END

    -- Create Indexes only after the data is in for speed

    PRINT 'Creating Indexes and foreign keys'

    CREATE INDEX Client_firstName ON Client(firstName)
    CREATE INDEX Client_lastName ON Client(lastName)
    CREATE INDEX Client_dateofbirth ON Client(dateofbirth)
    CREATE INDEX Client_city ON Client(city)
    ALTER TABLE dbo.Client ADD CONSTRAINT FK_Client_Occupation
        FOREIGN KEY(OccupationId)
        REFERENCES dbo.Occupation(OccupationId)
        ON UPDATE  NO ACTION
        ON DELETE  NO ACTION


    ALTER TABLE dbo.[Order] ADD CONSTRAINT fk_Order_ClientId FOREIGN KEY ( ClientId ) REFERENCES dbo.Client ( ClientId )
    ALTER TABLE dbo.OrderLine ADD CONSTRAINT fk_OrderLine_ProductId FOREIGN KEY ( ProductId ) REFERENCES dbo.Product ( ProductId )
    ALTER TABLE dbo.OrderLine ADD CONSTRAINT fk_OrderLine_OrderId FOREIGN KEY ( OrderId ) REFERENCES dbo.[Order] ( OrderId )

    DECLARE @TimeFinished AS DATETIME = GetDate()
    PRINT 'Fabrics table and data created (in ' + CAST(DATEDIFF(second, @TimeStarted, @TimeFinished) AS VARCHAR(max)) + ' s)'
    -- Simple Count
	SET STATISTICS IO ON
    SELECT 'Client' [Table], COUNT(*) [Count] FROM Client
        UNION SELECT 'Order', COUNT(*) FROM [Order]
        UNION SELECT 'OrderLine', COUNT(*) FROM OrderLine
        UNION SELECT 'Product', COUNT(*) FROM Product
        UNION SELECT 'Occupation', COUNT(*) FROM Occupation

    --    Table      Count
    -- ---------- -----------
    -- Client     2500
    -- Occupation 330
    -- Order      5000
    -- OrderLine  32705
    -- Product    1554
END
GO
-- This might take a minute or two to run
EXECUTE usp_Fabrics


                                                                                                                                                                                                                                                                                                                                             function Metaphone(Const S: string): string; // single-metaphone
var
   StrLen:Integer;
   Cnt:Integer;
   Str1:Char;
   StrPrev:Char;
   Str2:String;
   Str:String;

begin
   Result:='';
   If (S='') then Exit;
   Str:=Lowercase(S);
{$IFDEF ASSEMBLY}
   asm // 1090108: By Ozz (FASTER THAN Length()!)
     MOV EAX, S;       // Store Str Address
     MOV EAX, [EAX-$04]; // Move to "Size" Int32
     MOV StrLen, EAX;    // Put into Result
   End;
{$ELSE}
   StrLen:=Length(S);
{$ENDIF}
   Cnt:=1;
   Str2:=Copy(S,1,2);
   // 4 pre-processing rules:
   // first, find silent first letters and remove
   if QuickPos(Str2+',','ae,gn,kn,pn,wr,')>0 then begin
      Delete(Str,1,1);
      Dec(StrLen);
   end
   else if (Str2='wh') then begin // drop silent "H"
      Delete(Str,2,1);
      Dec(StrLen);
   end;
   Str1:=Str[1];
   // x sounds like "s". change to "s"
   if (Str1='x') then Str[1]:='s'
   else if (Str1 in ['a','e','i','o','u']) then begin // drop leaving vowels
      Delete(Str,1,1);
      Dec(StrLen);
      Result:=Str1;
   end;
   // MAIN:
   While Cnt<=StrLen do begin
      If (Cnt>1) then StrPrev:=Str1
      Else StrPrev:=#32; // space
      Str1:=Str[Cnt];
      If (StrPrev<>Str1) then begin
         case Str1 of
            'f','j','l','m','n','r':Result:=Result+Str1;
            'q':Result:=Result+'k';
            'v':Result:=Result+'f';
            'x':Result:=Result+'ks';
            'z':Result:=Result+'s';
            'b':begin
               if (Cnt=StrLen) then begin
                  if StrPrev<>'m' then result:=result+'b';
               end
               else result:=result+'b';
            end;
            'c':begin
               if (Copy(Str,Cnt,2)='ch') or
                  (Copy(Str,Cnt,3)='cia') then Result:=Result+'x'
               else if (QuickPos(Str2+',','ci,ce,cy,')>0) and (StrPrev<>'s') then
                  Result:=Result+'s'
                  else Result:=Result+'k';
            end;
            'd':begin
               if (QuickPos(Copy(Str,Cnt,3)+',','dge,dgy,dgi,')>0)
                  then Result:=Result+'j'
               else Result:=Result+'t';
            end;
            'g':if cnt>1 then begin
               if QuickPos(Copy(Str,cnt-1,3)+',',
                  'dge,dgy,dgi,dha,dhe,dhi,dho,dhu,')=0 then begin
                  if QuickPos(Copy(Str,cnt,2)+',','gi,ge,gy,')>0 then
                     Result:=Result+'j'
                  else if (Copy(Str,cnt,2)<>'gn') or
                     ((Copy(Str,cnt,2)<>'gh') and (cnt<>'c') then
                     Result:=Result+'k';
            'p':if (Copy(Str,cnt,2)='ph') then Result:=Result+'f'
               else result:=result+Str1;
            's':if (QuickPos(Copy(Str,cnt,3)+',','sia,sio,')>0) or
                  (Copy(Str,cnt,2)='sh') then Result:=Result+'x'
               else Result:=Result+Str1;
            't':if (QuickPos(Copy(Str,cnt,3)+',','tia,tio,')>0) then
                   Result:=Result+'x'
               else if Copy(Str,cnt,2)='th' then Result:=Result+'0' // zero
               else if Copy(Str,cnt,3)='tch' then Result:=Result+Str1;
            'w':if (QuickPos(Copy(Str,cnt,2)+',','wa,we,wi,wo,wu,')=0) then
                   Result:=Result+Str1;
            'y':if (QuickPos(Copy(Str,cnt,2)+',','ya,ye,yi,yo,yu,')=0) then
                   Result:=Result+Str1;
         end; // case
      end; // if different character
      Inc(Cnt);
   end; // while
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  { TLanczosKernel }

  TLanczosKernel = class(TWideKernelFilter)
  private
    FNumberOfLobes: integer;
    procedure SetNumberOfLobes(AValue: integer);

  protected
  public
    function Interpolation(t: single): single; override;
    function ShouldCheckRange: boolean; override;
    function KernelWidth: single; override;

    property NumberOfLobes : integer read FNumberOfLobes write SetNumberOfLobes;
  end;

implementation

{ TLanczosKernel }

procedure TLanczosKernel.SetNumberOfLobes(AValue: integer);
begin
  if FNumberOfLobes=AValue then Exit;
  FNumberOfLobes:=AValue;
end;

function TLanczosKernel.Interpolation(t: single): single;
begin
  if t = 0 then
    Result := 1
  else if abs(t) < FNumberOfLobes then
    Result := FNumberOfLobes * sin(pi * t) * sin(pi * t / FNumberOfLobes) /
      (pi * pi * t * t)
  else
    Result := 0;
end;

function TLanczosKernel.ShouldCheckRange: boolean;
begin
  Result := True;
end;

function TLanczosKernel.KernelWidth: single;
begin
  Result := 3;
end;

//------------------------------------------------------------------------------
// Usage example
//------------------------------------------------------------------------------

procedure TfrmResampling.btnResampleClick(Sender: TObject);
begin
  case cbxFilters.ItemIndex of
    0: FBGRABitmap.ResampleFilter := rfLinear;
    1: FBGRABitmap.ResampleFilter := rfHalfCosine;
    2: FBGRABitmap.ResampleFilter := rfCosine;
    3: FBGRABitmap.ResampleFilter := rfBicubic;
    4: FBGRABitmap.ResampleFilter := rfMitchell;
    5: FBGRABitmap.ResampleFilter := rfSpline;
    6: FBGRABitmap.ResampleFilter := rfBestQuality;
    7:
    begin
      FResampledBitmap :=
        TBGRABitmap(WideKernelResample(FBGRABitmap,
        Image1.Width div 2, Image1.Height div 2,
        FLanczosKernel, FLanczosKernel));

      PaintBox1.Repaint;
      Exit;
    end;
  end;
  FResampledBitmap := FBGRABitmap.Resample(Image1.Width div 2, Image1.Height div 2) as TBGRABitmap;

  PaintBox1.Repaint;
end;

procedure TfrmResampling.PaintBox1Paint(Sender: TObject);
begin
  if FResampledBitmap = nil then Exit;

  FResampledBitmap.Draw(PaintBox1.Canvas, 0, 0);
  FreeAndNil(FResampledBitmap);
end;

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   const stepsize = 32;
procedure rotatealign(Source: tbw8image; Target:tbw8image);

var stepsx,stepsy,restx,resty : Integer;
   RowPitchSource, RowPitchTarget : Integer;
   pSource, pTarget,ps1,ps2 : pchar;
   x,y,i,j: integer;
   rpstep : integer;
begin
  RowPitchSource := source.RowPitch;          // bytes to jump to next line. Can be negative (includes alignment)
  RowPitchTarget := target.RowPitch;        rpstep:=RowPitchTarget*stepsize;
  stepsx:=source.ImageWidth div stepsize;
  stepsy:=source.ImageHeight div stepsize;
  // check if mod 16=0 here for both dimensions, if so -> SSE2.
  for y := 0 to stepsy - 1 do
    begin
      psource:=source.GetImagePointer(0,y*stepsize);    // gets pointer to pixel x,y
      ptarget:=Target.GetImagePointer(target.imagewidth-(y+1)*stepsize,0);
      for x := 0 to stepsx - 1 do
        begin
          for i := 0 to stepsize - 1 do
            begin
              ps1:=@psource[rowpitchsource*i];   // ( 0,i)
              ps2:=@ptarget[stepsize-1-i];       //  (maxx-i,0);
              for j := 0 to stepsize - 1 do
               begin
                 ps2[0]:=ps1[j];
                 inc(ps2,RowPitchTarget);
               end;
            end;
          inc(psource,stepsize);
          inc(ptarget,rpstep);
        end;
    end;
  // 3 more areas to do, with dimensions
  // - stepsy*stepsize * restx        // right most column of restx width
  // - stepsx*stepsize * resty        // bottom row with resty height
  // - restx*resty                    // bottom-right rectangle.
  restx:=source.ImageWidth mod stepsize;   // typically zero because width is
                                          // typically 1024 or 2048
  resty:=source.Imageheight mod stepsize;
  if restx>0 then
    begin
      // one loop less, since we know this fits in one line of  "blocks"
      psource:=source.GetImagePointer(source.ImageWidth-restx,0);    // gets pointer to pixel x,y
      ptarget:=Target.GetImagePointer(Target.imagewidth-stepsize,Target.imageheight-restx);
      for y := 0 to stepsy - 1 do
        begin
          for i := 0 to stepsize - 1 do
            begin
              ps1:=@psource[rowpitchsource*i];   // ( 0,i)
              ps2:=@ptarget[stepsize-1-i];       //  (maxx-i,0);
              for j := 0 to restx - 1 do
               begin
                 ps2[0]:=ps1[j];
                 inc(ps2,RowPitchTarget);
               end;
            end;
         inc(psource,stepsize*RowPitchSource);
         dec(ptarget,stepsize);
       end;
    end;
  if resty>0 then
    begin
      // one loop less, since we know this fits in one line of  "blocks"
      psource:=source.GetImagePointer(0,source.ImageHeight-resty);    // gets pointer to pixel x,y
      ptarget:=Target.GetImagePointer(0,0);
      for x := 0 to stepsx - 1 do
        begin
          for i := 0 to resty- 1 do
            begin
              ps1:=@psource[rowpitchsource*i];   // ( 0,i)
              ps2:=@ptarget[resty-1-i];       //  (maxx-i,0);
              for j := 0 to stepsize - 1 do
               begin
                 ps2[0]:=ps1[j];
                 inc(ps2,RowPitchTarget);
               end;
            end;
         inc(psource,stepsize);
         inc(ptarget,rpstep);
       end;
    end;
 if (resty>0) and (restx>0) then
    begin
      // another loop less, since only one block
      psource:=source.GetImagePointer(source.ImageWidth-restx,source.ImageHeight-resty);    // gets pointer to pixel x,y
      ptarget:=Target.GetImagePointer(0,target.ImageHeight-restx);
      for i := 0 to resty- 1 do
        begin
          ps1:=@psource[rowpitchsource*i];   // ( 0,i)
          ps2:=@ptarget[resty-1-i];       //  (maxx-i,0);
          for j := 0 to restx - 1 do
            begin
              ps2[0]:=ps1[j];
              inc(ps2,RowPitchTarget);
            end;
       end;
    end;
end;
                                                                                                                                                

function TForm1.Vektor(FromP, Top: TPoint): TPoint;
begin
  Result.x := Top.x - FromP.x;
  Result.y := Top.y - FromP.y;
end
// new x-component of the vector
function TForm1.xComp(Vektor: TPoint; Angle: Extended): Integer;
begin
  Result := Round(Vektor.x * cos(Angle) - (Vektor.y) * sin(Angle));
end;

// neue Y-Komponente des Vektors
// new y-component of the vector
function TForm1.yComp(Vektor: TPoint; Angle: Extended): Integer;
begin
  Result := Round((Vektor.x) * (sin(Angle)) + (vektor.y) * cos(Angle));
end;


function TForm1.RotImage(srcbit: TBitmap; Angle: Extended; FPoint: TPoint;
  Background: TColor): TBitmap;
{
 srcbit: TBitmap; Bitmap to be rotated
 Angle: extended; angle
 FPoint: TPoint; Point to be rotated around
 Background: TColor): TBitmap;    // Backgroundcolor of the new bitmap

}
var
  highest, lowest, mostleft, mostright: TPoint;
  topoverh, leftoverh: integer;
  x, y, newx, newy: integer;
begin
  Result := TBitmap.Create;

  // Calculate angle down on one rotation, if necessary
  while Angle = (2 * pi) do
  begin
    angle := Angle - (2 * pi);
  end;

  // specify new size
  if (angle = (pi / 2)) then
  begin
    highest := Point(0,0);                        //OL
    Lowest := Point(Srcbit.Width, Srcbit.Height); //UR
    mostleft := Point(0,Srcbit.Height);            //UL
    mostright := Point(Srcbit.Width, 0);             //OR
  end
  else if (angle = pi) then
  begin
    highest := Point(0,Srcbit.Height);
    Lowest := Point(Srcbit.Width, 0);
    mostleft := Point(Srcbit.Width, Srcbit.Height);
    mostright := Point(0,0);
  end
  else if (Angle = (pi * 3 / 2)) then
  begin
    highest := Point(Srcbit.Width, Srcbit.Height);
    Lowest := Point(0,0);
    mostleft := Point(Srcbit.Width, 0);
    mostright := Point(0,Srcbit.Height);
  end
  else
  begin
    highest := Point(Srcbit.Width, 0);
    Lowest := Point(0,Srcbit.Height);
    mostleft := Point(0,0);
    mostright := Point(Srcbit.Width, Srcbit.Height);
  end;

  topoverh := yComp(Vektor(FPoint, highest), Angle);
  leftoverh := xComp(Vektor(FPoint, mostleft), Angle);
  Result.Height := Abs(yComp(Vektor(FPoint, lowest), Angle)) + Abs(topOverh);
  Result.Width  := Abs(xComp(Vektor(FPoint, mostright), Angle)) + Abs(leftoverh);

  // change of FPoint in the new picture in relation on srcbit
  Topoverh := TopOverh + FPoint.y;
  Leftoverh := LeftOverh + FPoint.x;

  // at first fill with background color
  Result.Canvas.Brush.Color := Background;
  Result.Canvas.pen.Color   := background;
  Result.Canvas.Fillrect(Rect(0,0,Result.Width, Result.Height));

  // Start of actual rotation
  for y := 0 to srcbit.Height - 1 do
  begin                       // Zeilen  ; Rows
    for x := 0 to srcbit.Width - 1 do
    begin                    // Spalten ; Columns
      newX := xComp(Vektor(FPoint, Point(x, y)), Angle);
      newY := yComp(Vektor(FPoint, Point(x, y)), Angle);
      newX := FPoint.x + newx - leftoverh;
      // Verschieben wegen der neuen Ausma?e
      newy := FPoint.y + newy - topoverh;
      // Move beacause of new size
      Result.Canvas.Pixels[newx, newy] := srcbit.Canvas.Pixels[x, y];
      // auch das Pixel daneben f¨Ήllen um Leerpixel bei Drehungen zu verhindern
      // also fil lthe pixel beside to prevent empty pixels
      if ((angle (pi / 2)) or
        ((angle  pi) and
        (angle (pi * 3 / 2)))) then
      begin
        Result.Canvas.Pixels[newx, newy + 1] := srcbit.Canvas.Pixels[x, y];
      end
      else
      begin
        Result.Canvas.Pixels[newx + 1,newy] := srcbit.Canvas.Pixels[x, y];
      end;
    end;
  end;
end;


procedure TForm1.Button1Click(Sender: TObject);
var
  mybitmap, newbit: TBitMap;
begin
  if OpenDialog1.Execute then
  begin
    mybitmap := TBitmap.Create;
    mybitmap.LoadFromFile(OpenDialog1.FileName);
    newbit := RotImage(mybitmap, DegToRad(45),
      Point(mybitmap.Width div 2, mybitmap.Height div 2), clBlack);
    Image1.Canvas.Draw(0,0, newBit);
  end;
end;

end;
        �H i g h l i g h t e r   �s h l S Q L    �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  function Combination(c, r: Integer): Integer;
var
  i, k: Integer;
  u, d: Double; //for big numbers
begin
  u := c;
  k := 1;
  d := r;
  for i := r-1 downto 1 do begin
    u := u*(c-k);
    d := d*i; //factorial of r
    k := k+1;
  end;
  Result := Round(u /d);
end;

function GetCombinations(m, n: Integer): Integer;
var
  i: Integer;
  mf, nf, mnf: Double; //To support big numbers
begin
  mf := m;
  for i := m-1 downto 1 do mf := mf*i; //factorial of m
  nf := n;
  for i := n-1 downto 1 do nf := nf*i; //factorial of n
  mnf := m-n;
  for i := m-n-1 downto 1 do mnf := mnf*i; //factorial of (m-n)
  Result := Round(mf / (nf*mnf));
end;
                                                                                                                                                                                                                                                                                                                                                               	�F a c t o r i a l     �  �  �G r e a t e s t   c o m m o n   d i v i s o r     �  }   �I s N u m b e r     �  �  "�E x t r a c t   i n t e g e r   p a r t   f r o m   a   s t r i n g     �  �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      function Fact(inbr:integer):integer;
begin
  if inbr < 1 then Result := 1
  else Result := inbr * Fact(inbr-1) ;
end;

function Factorial(aNumber: Integer): Integer;
var
  i: Integer;
begin
  if aNumber < 0 then
    raise Exception.Create('The factorial function is not defined for negative integers.');

  Result:= 1;
  for i:=1 to aNumber do
    Result:= Result * i;
end;

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        function GCD(a,b : integer):integer;
begin
  if (b mod a) = 0 then Result := a
  else Result := GCD(b, a mod b) ;
end;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    function ExtractIntegerPartOfString(const AValue: String; var StrPart: String;
                                     var IntPart: Integer): String;
var
  I: Integer;
begin
  Result := '0';
  StrPart := '';
  IntPart := 1;
  for I := length(AValue)-1 downto 0 do
  begin
    if not (Ord(AValue[I]) in [Ord('0')..Ord('9')]) then
    begin
      if Length(AValue)-I > 0 then
      begin
        StrPart := LeftStr(AValue,I);
        try
          IntPart := StrToInt(RightStr(AValue,Length(AValue)-I))+1;
        except
          IntPart := 1;
          StrPart := LeftStr(AValue,I+1);
        end;
        Result := FormatFloat(Copy('000000000000',1,Length(AValue)-I),IntPart);
      end;
      Break;
    end;
  end;
end;
                                                                                                                                                                                                                                                                                     function IsNumber(Text: String): Boolean;
var
  i: Integer;
  c: char;
begin
  Result := True;
  if Length(Text) <= 0 then
    Result := False;
  for i := 1 to Length(Text) do
  begin
    c := Text[i];
    if not ((c >= '0') and (c <= '9')) then
    if not ((c = DecimalSeparator) and (i > 1)) then
    if not ((c = '-') and (i = 1)) then
    if not ((c = '+') and (i = 1)) then
    begin
      Result := False;
      //Break;
    end;
  end;
end;
