Sub UpdateSheetDynamicSource()
    Dim sourceWorkbook As Workbook
    Dim sourceSheet As Worksheet
    Dim destinationSheet As Worksheet
    Dim destinationRange As Range
    Dim lookupValue As String
    Dim lookupRange As Range
    Dim sourceRow As Long
    
    ' Set the SharePoint URL and file path (replace with your SharePoint URL and file path)
    Dim SharePointURL As String
    Dim SharePointFilePath As String
    SharePointURL = "https://your-sharepoint-url.com"
    SharePointFilePath = "/sites/your-site/documents/SourceExcelFile.xlsx"
    
    ' Set the destination workbook and sheet (replace with your actual workbook and sheet names)
    Set destinationSheet = ThisWorkbook.Sheets("DestinationSheetName")
    
    ' Set the destination range where you want to update the data in the destination sheet
    Set destinationRange = destinationSheet.Range("A2") ' Replace with your actual range
    
    ' Set the lookup value to search in the destination sheet (replace with your actual lookup value)
    lookupValue = destinationSheet.Range("A2").Value ' Replace with your actual cell reference
    
    ' Open the source workbook from SharePoint
    Set sourceWorkbook = Workbooks.Open(SharePointURL & SharePointFilePath)
    
    ' Set the source sheet (replace "SourceSheetName" with your actual sheet name)
    Set sourceSheet = sourceWorkbook.Sheets("SourceSheetName")
    
    ' Find the row number in the source sheet that matches the lookup value
    Set lookupRange = sourceSheet.Range("A:A") ' Assuming the lookup column is column A, adjust as needed
    sourceRow = Application.Match(lookupValue, lookupRange, 0)
    
    ' Check if the lookup value was found in the source sheet
    If Not IsError(sourceRow) Then
        ' Copy the specified columns from the source sheet to the destination range
        sourceSheet.Range("B" & sourceRow & ":E" & sourceRow).Copy destinationRange
        
        MsgBox "Data copied successfully!"
    Else
        MsgBox "Lookup value not found in the source sheet. Update operation cancelled."
    End If
    
    ' Close the source workbook without saving changes
    sourceWorkbook.Close SaveChanges:=False
End Sub
