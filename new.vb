Sub LookupAndCopyColumnsFromOneDrive()
    ' Source file path (OneDrive)
    Dim sourceFilePath As String
    sourceFilePath = "https://onedrive.live.com/.../SourceFile.xlsx"
    
    ' Source sheet name
    Dim sourceSheetName As String
    sourceSheetName = "Sheet1"
    
    ' Lookup range in the source sheet
    Dim lookupRange As Range
    Set lookupRange = ThisWorkbook.Sheets("Sheet1").Range("A1:A10") ' Adjust the range as per your requirement
    
    ' Destination file path (local)
    Dim destinationFilePath As String
    destinationFilePath = "C:\DestinationFile.xlsx"
    
    ' Destination sheet name
    Dim destinationSheetName As String
    destinationSheetName = "Sheet1"
    
    ' Create a new instance of Excel
    Dim excelApp As Object
    Set excelApp = CreateObject("Excel.Application")
    
    ' Open the source file from OneDrive
    Dim sourceWorkbook As Object
    Set sourceWorkbook = excelApp.Workbooks.Open(sourceFilePath)
    
    ' Get the source sheet
    Dim sourceSheet As Object
    Set sourceSheet = sourceWorkbook.Sheets(sourceSheetName)
    
    ' Get the destination workbook
    Dim destinationWorkbook As Object
    Set destinationWorkbook = excelApp.Workbooks.Open(destinationFilePath)
    
    ' Get the destination sheet
    Dim destinationSheet As Object
    Set destinationSheet = destinationWorkbook.Sheets(destinationSheetName)
    
    ' Loop through each row in the lookup range
    Dim lookupCell As Range
    Dim rowToCopy As Range
    Dim destinationColumnIndex As Integer
    destinationColumnIndex = 1 ' Adjust the column index where you want to paste the data
    
    For Each lookupCell In lookupRange
        ' Find the corresponding row in the source sheet
        Set rowToCopy = sourceSheet.Range("A:A").Find(lookupCell.Value, LookIn:=xlValues, LookAt:=xlWhole)
        
        ' If a matching row is found, copy the corresponding columns to the destination sheet
        If Not rowToCopy Is Nothing Then
            rowToCopy.EntireRow.Copy
            destinationSheet.Cells(lookupCell.Row, destinationColumnIndex).PasteSpecial Paste:=xlPasteValues
        End If
    Next lookupCell
    
    ' Save and close the destination workbook
    destinationWorkbook.Save
    destinationWorkbook.Close
    
    ' Close the source workbook without saving
    sourceWorkbook.Close False
    
    ' Close Excel
    excelApp.Quit
    
    ' Release the objects from memory
    Set lookupRange = Nothing
    Set rowToCopy = Nothing
    Set sourceSheet = Nothing
    Set sourceWorkbook = Nothing
    Set destinationSheet = Nothing
    Set destinationWorkbook = Nothing
    Set excelApp = Nothing
    
    ' Display a message
    MsgBox "Data copied successfully!"
End Sub
