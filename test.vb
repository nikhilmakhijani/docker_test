Sub LookupOneDriveAndCopyColumnsToLocal()
    ' Source file path (OneDrive)
    Dim sourceFilePath As String
    sourceFilePath = "https://onedrive.live.com/.../SourceFile.xlsx"
    
    ' Source sheet name
    Dim sourceSheetName As String
    sourceSheetName = "Sheet1"
    
    ' Lookup range in the current workbook
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
    
    ' Open the source file (OneDrive)
    Dim sourceWorkbook As Object
    Set sourceWorkbook = excelApp.Workbooks.Open(sourceFilePath)
    
    ' Get the source sheet
    Dim sourceSheet As Object
    Set sourceSheet = sourceWorkbook.Sheets(sourceSheetName)
    
    ' Get the destination workbook (local)
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
            Dim sourceData As Range
            Set sourceData = rowToCopy.EntireRow.Resize(, 2) ' Adjust the number of columns to copy
            
            Dim destinationCell As Range
            Set destinationCell = destinationSheet.Cells(lookupCell.Row, destinationColumnIndex)
            
            destinationCell.Resize(, 2).Value = sourceData.Value ' Adjust the number of columns to paste
        End If
    Next lookupCell
    
    ' Save and close the destination workbook (local)
    destinationWorkbook.Save
    destinationWorkbook.Close
    
    ' Close the source workbook (OneDrive) without saving
    sourceWorkbook.Close False
    
