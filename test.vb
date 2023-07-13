
Sub CopySheetFromCloudDriveToLocal()
    ' Source file path on the cloud drive
    Dim sourceFilePath As String
    sourceFilePath = "https://onedrive.live.com/.../SourceFile.xlsx"
    
    ' Source sheet name
    Dim sourceSheetName As String
    sourceSheetName = "Sheet1"
    
    ' Destination file path (local)
    Dim destinationFilePath As String
    destinationFilePath = "C:\DestinationFile.xlsx"
    
    ' Destination sheet name
    Dim destinationSheetName As String
    destinationSheetName = "CopiedSheet"
    
    ' Create a new instance of Excel
    Dim excelApp As Object
    Set excelApp = CreateObject("Excel.Application")
    
    ' Open the source file
    Dim sourceWorkbook As Object
    Set sourceWorkbook = excelApp.Workbooks.Open(sourceFilePath)
    
    ' Copy the sheet to a new workbook
    sourceWorkbook.Sheets(sourceSheetName).Copy
    
    ' Close the source workbook without saving
    sourceWorkbook.Close False
    
    ' Activate the destination workbook
    Dim destinationWorkbook As Object
    Set destinationWorkbook = excelApp.Workbooks.Open(destinationFilePath)
    destinationWorkbook.Activate
    
    ' Paste the copied sheet into the destination workbook
    excelApp.ActiveSheet.Paste Destination:=destinationWorkbook.Sheets(destinationSheetName).Range("A1")
    
    ' Save and close the destination workbook
    destinationWorkbook.Save
    destinationWorkbook.Close
    
    ' Close Excel
    excelApp.Quit
    
    ' Release the objects from memory
    Set sourceWorkbook = Nothing
    Set destinationWorkbook = Nothing
    Set excelApp = Nothing
    
    ' Display a message
    MsgBox "Sheet copied successfully!"
End Sub

Sub CopySheetFromCloudDriveToLocal()
    ' Source file path on the cloud drive
    Dim sourceFilePath As String
    sourceFilePath = "https://onedrive.live.com/.../SourceFile.xlsx"
    
    ' Source sheet name
    Dim sourceSheetName As String
    sourceSheetName = "Sheet1"
    
    ' Destination file path (local)
    Dim destinationFilePath As String
    destinationFilePath = "C:\DestinationFile.xlsx"
    
    ' Destination sheet name
    Dim destinationSheetName As String
    destinationSheetName = "CopiedSheet"
    
    ' Create a new instance of Excel
    Dim excelApp As Object
    Set excelApp = CreateObject("Excel.Application")
    
    ' Open the source file
    Dim sourceWorkbook As Object
    Set sourceWorkbook = excelApp.Workbooks.Open(sourceFilePath)
    
    ' Print all sheets in the source workbook
    Dim sourceSheet As Object
    For Each sourceSheet In sourceWorkbook.Sheets
        sourceSheet.PrintOut
    Next sourceSheet
    
    ' Copy the sheet to a new workbook
    sourceWorkbook.Sheets(sourceSheetName).Copy
    
    ' Close the source workbook without saving
    sourceWorkbook.Close False
    
    ' Activate the destination workbook
    Dim destinationWorkbook As Object
    Set destinationWorkbook = excelApp.Workbooks.Open(destinationFilePath)
    destinationWorkbook.Activate
    
    ' Paste the copied sheet into the destination workbook
    excelApp.ActiveSheet.Paste Destination:=destinationWorkbook.Sheets(destinationSheetName).Range("A1")
    
    ' Save and close the destination workbook
    destinationWorkbook.Save
    destinationWorkbook.Close
    
    ' Close Excel
    excelApp.Quit
    
    ' Release the objects from memory
    Set sourceWorkbook = Nothing
    Set destinationWorkbook = Nothing
    Set excelApp = Nothing
    
    ' Display a message
    MsgBox "Sheet copied successfully and printed!"
End Sub






