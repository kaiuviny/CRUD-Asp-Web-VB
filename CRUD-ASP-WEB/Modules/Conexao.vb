Imports MySql.Data.MySqlClient

Module Conexao
    Public con As New MySqlConnection("server=127.0.0.1;userid=root;password=;database=crudtutorial_db;port=3306")

    Public user As String
    Public jobUser As String
    Public nameUSer As String

    Sub open()
        If con.State = 0 Then
            con.Open()
        End If
    End Sub

    Sub close()
        If con.State = 1 Then
            con.Close()
        End If
    End Sub
End Module
