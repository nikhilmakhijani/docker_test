Sub CopyDataFromOneDrive()
    Dim sourcePath As String
    Dim sourceWorkbook As Workbook
    Dim destinationWorkbook As Workbook
    Dim sourceSheet As Worksheet
    Dim destinationSheet As Worksheet
    Dim sourceRange As Range
    Dim destinationRange As Range
    
    ' Set the path of the source workbook on OneDrive
    sourcePath = "https://onedrive.com/example/source.xlsx"
    
    ' Open the source workbook
    Set sourceWorkbook = Workbooks.Open(sourcePath)
    
    ' Set the source and destination sheets
    Set sourceSheet = sourceWorkbook.Worksheets("Sheet1") ' Replace "Sheet1" with the actual sheet name
    Set destinationWorkbook = ThisWorkbook ' Assumes the destination workbook is the workbook containing the macro
    Set destinationSheet = destinationWorkbook.Worksheets("Sheet2") ' Replace "Sheet2" with the actual sheet name
    
    ' Define the source and destination ranges to copy
    Set sourceRange = sourceSheet.Range("A1:D10") ' Replace with the desired range
    Set destinationRange = destinationSheet.Range("A1") ' Replace with the starting cell in the destination sheet
    
    ' Copy the data from source to destination
    sourceRange.Copy destinationRange
    
    ' Close the source workbook without saving changes
    sourceWorkbook.Close False
    
    ' Clear clipboard
    Application.CutCopyMode = False
    
    ' Inform the user that the data has been copied
    MsgBox "Data copied successfully!"
End Sub
