Sub CopyColumnsBasedOnMatchingRows()
    Dim reportWorkbook As Workbook
    Dim targetWorkbook As Workbook
    Dim reportSheet As Worksheet
    Dim targetSheet As Worksheet
    Dim searchRows() As Variant
    Dim searchRow As Variant
    Dim searchRange As Range
    Dim reportRow As Range
    Dim targetRow As Range

    ' Set the report workbook and sheet
    Set reportWorkbook = Workbooks("ReportWorkbook.xlsx")
    Set reportSheet = reportWorkbook.Sheets("ReportSheet")

    ' Set the target workbook and sheet
    Set targetWorkbook = ThisWorkbook ' or specify the target workbook here
    Set targetSheet = targetWorkbook.Sheets("TargetSheet")

    ' Define the rows to search for
    searchRows = Array(52, 54, 63, 65)

    ' Find and copy the columns based on the matching rows
    For Each searchRow In searchRows
        Set searchRange = reportSheet.Range("A:A").Find(searchRow, LookIn:=xlValues, LookAt:=xlWhole)
        If Not searchRange Is Nothing Then
            Set reportRow = reportSheet.Rows(searchRange.Row)
            Set targetRow = targetSheet.Rows(searchRange.Row)

            reportRow.Range("I:AD").Copy targetRow.Range("J:AE")
        End If
    Next searchRow

    ' Save and close the target workbook
    targetWorkbook.Save
    targetWorkbook.Close

    ' Clean up the objects
    Set reportRow = Nothing
    Set reportSheet = Nothing
    Set reportWorkbook = Nothing
    Set targetRow = Nothing
    Set targetSheet = Nothing
    Set targetWorkbook = Nothing

    MsgBox "Columns copied successfully!"
End Sub
