Module Module1
    Dim inputStream As IO.StreamReader
    Dim outputStream As IO.StreamWriter
    Dim tipos As String()
    Sub Main()
        Inicio()
        Do Until inputStream.EndOfStream()
            Dim line As String() = inputStream.ReadLine().Split(vbTab)
            Dim newline As String() = line
            For j As Integer = 0 To UBound(line)
                Select Case j
                    Case 1
                        newline(1) = ConvertirEvento(line(1))
                        Exit Select
                    Case 2
                        newline(2) = ConvertirRonda(line(2))
                        Exit Select
                    Case 4
                        newline(4) = ConvertirTiempo(line(4))
                        Exit Select
                    Case 5
                        newline(5) = ConvertirTiempo(line(5))
                        Exit Select
                    Case 10
                        newline(10) = ConvertirTiempo(line(10))
                        Exit Select
                    Case 11
                        newline(11) = ConvertirTiempo(line(11))
                        Exit Select
                    Case 12
                        newline(12) = ConvertirTiempo(line(12))
                        Exit Select
                    Case 13
                        newline(13) = ConvertirTiempo(line(13))
                        Exit Select
                    Case 14
                        newline(14) = ConvertirTiempo(line(14))
                        Exit Select
                End Select
            Next
            outputStream.WriteLine(volverAUnir(newline))
        Loop
        Final()
    End Sub
    Function ConvertirTiempo(j As String) As String
        Dim k As Long = Convert.ToInt64(j)
        Dim cs As Char() = k.ToString("##:##:#0:00").ToCharArray()
        For i As Integer = 0 To UBound(cs)
            If cs(i) = ":" Then cs(i) = "" Else Exit For
        Next
        Dim x As New String(cs)
        Return StrReverse(Replace(StrReverse(x), ":", ".", , 1)).Replace(vbNullChar, "")
    End Function
    Function ConvertirRonda(x As String) As String
        Select Case x
            Case "1"
                Return "Primera"
            Case "2"
                Return "Segunda"
            Case "3"
                Return "Tercera"
            Case "f"
                Return "Final"
            Case "d"
                Return "Primera Combinada"
            Case "c"
                Return "Final Combinada"
            Case Else
                Return x
        End Select
    End Function
    Function ConvertirEvento(x As String) As String
        Select Case x
            Case "222"
                Return "2x2x2"
            Case "333"
                Return "Rubik's Cube"
            Case "444"
                Return "4x4x4"
            Case "555"
                Return "5x5x5"
            Case "666"
                Return "6x6x6"
            Case "777"
                Return "7x7x7"
            Case "333oh"
                Return "3x3x3 One Handed"
            Case "sq1"
                Return "Square-1"
            Case "pyram"
                Return "Pyraminx"
            Case "minx"
                Return "Megaminx"
            Case "clock"
                Return "Rubik's Clock"
            Case "333fm"
                Return "3x3x3 FMC"
            Case "333bf"
                Return "3x3x3 BLD"
            Case "444bf"
                Return "4x4x4 BLD"
            Case "magic"
                Return "Rubik's Magic"
            Case "mmagic"
                Return "Master Magic"
            Case "333mbf"
                Return "3x3x3 Multi-Blind"
            Case "333ft"
                Return "3x3x3 With Feet"
            Case "333mbo"
                Return "3x3x3 Multi-Blind Old Style"
            Case Else
                Return x
        End Select
    End Function
    Sub Inicio()
        If Not IO.File.Exists("in.tsv") Then
            Console.WriteLine("ERROR")
            Console.WriteLine("Archivo ""in.tsv"" no encontrado. Recuerde renombrar su archivo de entrada a ""in.tsv""")
            Console.WriteLine("Presione cualquier tecla para salir.")
            Console.ReadKey()
            End
        End If
        inputStream = New IO.StreamReader("in.tsv")
        outputStream = New IO.StreamWriter(New IO.FileStream("out.tsv", IO.FileMode.Create))
        tipos = inputStream.ReadLine().Split(vbTab)
        tipos(0) = "Competencia"
        tipos(1) = "Evento"
        tipos(2) = "Ronda"
        tipos(3) = "Posición"
        tipos(4) = "Single"
        tipos(5) = "Avg"
        tipos(6) = "Nombre"
        tipos(7) = "ID de competidor"
        tipos(8) = "País"
        tipos(9) = "Formato"
        tipos(10) = "Tiempo 1"
        tipos(11) = "Tiempo 2"
        tipos(12) = "Tiempo 3"
        tipos(13) = "Tiempo 4"
        tipos(14) = "Tiempo 5"
        tipos(15) = "Record (single)"
        tipos(16) = "Record (avg)"
        outputStream.WriteLine(volverAUnir(tipos))
    End Sub
    Function SearchInArray(x As String, arr As String()) As Integer
        For i As Integer = 0 To UBound(arr)
            If arr(i) = x Then Return i
        Next
        Return Nothing
    End Function
    Function volverAUnir(x As String()) As String
        Return String.Join(vbTab, x)
    End Function
    Sub Final()
        Console.WriteLine("Finalizado. Su archivo de salida es ""out.tsv"".")
        Console.Write("Presione cualquier tecla para salir...")
        Console.ReadKey()
        End
    End Sub
End Module