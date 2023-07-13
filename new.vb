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
    
    ' Loop through each cell in the lookup range
    Dim lookupCell As Range
    Dim rowToCopy As Range
    Dim destinationColumnIndex As Integer
    destinationColumnIndex = 1 ' Adjust the column index where you want to paste the data
    
    For Each lookupCell In lookupRange
        ' Apply AutoFilter to the source sheet
        sourceSheet.AutoFilterMode = False
        sourceSheet.Range("A1").AutoFilter Field:=1, Criteria1:=lookupCell.Value
        
        ' Find the first visible cell in the filtered range
        On Error Resume Next
        Set rowToCopy = sourceSheet.Columns(1).SpecialCells(xlCellTypeVisible).Offset(1).Resize(1).EntireRow
        On Error GoTo 0
        
        ' If a matching row is found, copy the corresponding columns to the destination sheet
        If Not rowToCopy Is Nothing Then
            Dim cell As Range
            For Each cell In rowToCopy.Cells
                destinationSheet.Cells(lookupCell.Row, destinationColumnIndex).Value = cell.Value
                destinationColumnIndex = destinationColumnIndex + 1
            Next cell
        End If
        
        ' Turn off AutoFilter
        sourceSheet.AutoFilterMode = False
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
