Sub SaveSheetNamesToArray()
    Dim ws As Worksheet
    Dim sheetNames() As String
    Dim nameToMatch As String
    Dim arrIndex As Integer
    
    nameToMatch = "Prefix" ' Change "Prefix" to the desired starting name
    
    ' Loop through all worksheets
    For Each ws In ThisWorkbook.Worksheets
        ' Check if the sheet name starts with the specified prefix
        If Left(ws.Name, Len(nameToMatch)) = nameToMatch Then
            ' Increase the size of the array and store the sheet name
            ReDim Preserve sheetNames(arrIndex)
            sheetNames(arrIndex) = ws.Name
            arrIndex = arrIndex + 1
        End If
    Next ws
    
    ' Display the sheet names in the Immediate window (for testing purposes)
    For arrIndex = LBound(sheetNames) To UBound(sheetNames)
        Debug.Print sheetNames(arrIndex)
    Next arrIndex
    
    ' Optional: Save the sheet names to a text file
    SaveArrayToFile sheetNames, "C:\Path\To\Output\File.txt" ' Change the file path as needed
End Sub

Sub SaveArrayToFile(arr() As String, filePath As String)
    Dim fileNum As Integer
    Dim i As Integer
    
    fileNum = FreeFile
    
    ' Open the file for writing
    Open filePath For Output As fileNum
    
    ' Write each element of the array to the file
    For i = LBound(arr) To UBound(arr)
        Print #fileNum, arr(i)
    Next i
    
    ' Close the file
    Close fileNum
End Sub
In this example, the macro searches for worksheets whose names start with a specific prefix (in this case, "Prefix"). It loops through all the worksheets in the workbook, checks if the name starts with the specified prefix, and if it does, it adds the sheet name to the sheetNames array.

You can modify the nameToMatch variable to change the desired starting name. After collecting the sheet names, the macro displays them in the Immediate window for testing purposes. Additionally, the SaveArrayToFile subroutine can be used to save the sheet names to a text file by providing the array and the file path.

Make sure to adjust the file path in the SaveArrayToFile subroutine to match your desired output file location.






