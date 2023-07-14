Sub InsertRowWithFormatting(rowNumber As Integer)
    Dim currentRow As Range
    Dim newRow As Range
    
    ' Select the specified row
    Rows(rowNumber).Select
    
    ' Store the currently selected row
    Set currentRow = Selection.EntireRow
    
    ' Insert a new row above the current row
    currentRow.Insert Shift:=xlShiftDown
    
    ' Set the new row as the inserted row
    Set newRow = currentRow.Offset(-1)
    
    ' Copy the formatting from the current row to the new row
    currentRow.Copy
    newRow.PasteSpecial Paste:=xlPasteFormats
    
    ' Clear the clipboard
    Application.CutCopyMode = False
End Sub
