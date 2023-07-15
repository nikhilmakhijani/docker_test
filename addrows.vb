Sub insert()
Dim targetWorkbook As Workbook
Dim targetSheet As Worksheet
Dim iRow As Long
Dim iCount As Long
Dim i As Long

 Set targetWorkbook = ThisWorkbook ' or specify the target workbook here
 Set targetSheet = targetWorkbook.Sheets("Sheet1")
iCount = InputBox(Prompt:="How many rows you want to insert?")
For i = 1 To iCount
    Rows("3:3").Select
    Selection.Copy
    Rows("4:4").Select
    Selection.insert Shift:=xlDown
    
    Next i
End Sub
