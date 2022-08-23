Imports MySql.Data.MySqlClient

Public Class _Default
    Inherits Page

    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim dr As MySqlDataReader
    Dim dt As New DataTable()
    Dim conString = "Server=127.0.0.1;Database=CRUDTutorial_DB;Uid=root;Pwd=;"
    Dim formatDate As String = "yyyy-MM-dd HH:mm:ss"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'ListProduct()
        loadUnit()
    End Sub

    Private Sub loadUnit()
        Try
            open()
            Dim dt As New DataTable
            Dim da As MySqlDataAdapter
            Dim sql As String = "SELECT * FROM unit;"

            da = New MySqlDataAdapter(sql, con)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                ddlUnit.DataMember = "unit"
                ddlUnit.DataTextField = "unit"
                ddlUnit.DataSource = dt
            End If

        Catch ex As Exception
        Finally
            close()
        End Try
    End Sub
    Private Sub loadstatus()

    End Sub
    Private Sub loadColor()

    End Sub

    Protected Sub btnInsertProduct_Click(sender As Object, e As EventArgs) Handles btnInsertProduct.Click
        'Atributos
        Dim ItemName As String = txtItemName.Text
        Dim Specification As String = txtSpeficitation.Text
        Dim Unit As String = ddlUnit.SelectedValue
        Dim Color As String = rblColor.SelectedValue
        Dim InsertDate As String = txtInserDate.Text & " " & txtInsertTime.Text
        'Dim InsertDateTime As DateTime= InsertDate.ToString(formatDate)
        Dim Opening As Double = txtOpeningQuantity.Text
        Dim Status As String = ""
        If (cbRegular.Checked = True And cbIrregular.Checked = False) Then
            Status = "Regular"
        ElseIf (cbRegular.Checked = False And cbIrregular.Checked = True) Then
            Status = "Irregular"
        End If

        Dim con As New MySqlConnection(conString)

        Dim query As String = "INSERT INTO
                        `productinfo_tab`
                       (`ItemName`,
                        `Specification`,
                        `Unit`, 
                        `Color`,
                        `InsertDate`,
                        `Opening`,
                        `Status`)
                      VALUES
                        ('" & ItemName & "',
                        '" & Specification & "',
                        '" & Unit & "',
                        '" & Color & "',
                        '" & InsertDate & "',
                        '" & Opening & "',
                        '" & Status & "');"
        cmd = New MySqlCommand(query, con)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            'MsgBox("Successfully Inserted!", MsgBoxStyle.Information, "Inserted")
        Catch ex As Exception
            MsgBox("Ops! Error to Insert new Products: " & ex.Message, MsgBoxStyle.Critical, "Error Inserted")
        Finally
            con.Close()
            con.Dispose()
            con.ClearAllPoolsAsync()
        End Try

        ListProduct()
    End Sub

    Protected Sub cbRegular_CheckedChanged(sender As Object, e As EventArgs) Handles cbRegular.CheckedChanged
        If (cbRegular.Checked = True) Then
            cbIrregular.Checked = False
        Else
            cbIrregular.Checked = True
        End If
    End Sub

    Protected Sub cbIrregular_CheckedChanged(sender As Object, e As EventArgs) Handles cbIrregular.CheckedChanged
        If (cbIrregular.Checked = True) Then
            cbRegular.Checked = False
        Else
            cbRegular.Checked = True
        End If
    End Sub

    Private Sub ListProduct()
        Dim con As New MySqlConnection(conString)
        Dim query As String = "SELECT * FROM `productinfo_tab`;"
        cmd = New MySqlCommand(query, con)
        Try
            con.Open()
            da = New MySqlDataAdapter(cmd)
            da.Fill(dt)
            gvProducts.DataSource = dt
            gvProducts.DataBind()
        Catch ex As Exception
            MsgBox("Ops! Error to Select All Products: " & ex.Message, MsgBoxStyle.Critical, "Error Select")

        Finally
            con.Close()
            con.Dispose()
            con.ClearAllPoolsAsync()

        End Try
    End Sub

    Protected Sub btnUpdateProduct_Click(sender As Object, e As EventArgs) Handles btnUpdateProduct.Click
        'Atributos
        Dim ItemName As String = txtItemName.Text
        Dim Specification As String = txtSpeficitation.Text
        Dim Unit As String = ddlUnit.SelectedValue
        Dim Color As String = rblColor.SelectedValue
        Dim InsertDate As String = txtInserDate.Text & " " & txtInsertTime.Text
        'Dim InsertDateTime As DateTime= InsertDate.ToString(formatDate)
        Dim Opening As Double = txtOpeningQuantity.Text
        Dim Status As String = ""
        If (cbRegular.Checked = True And cbIrregular.Checked = False) Then
            Status = "Regular"
        ElseIf (cbRegular.Checked = False And cbIrregular.Checked = True) Then
            Status = "Irregular"
        End If

        Dim con As New MySqlConnection(conString)

        Dim query As String = "UPDATE
                                `productinfo_tab`
                               SET
                                `ItemName` = '" & ItemName & "',
                                `Specification` = '" & Specification & "',
                                `Unit` = '" & Unit & "', 
                                `Color` = '" & Color & "',
                                `InsertDate` = '" & InsertDate & "',
                                `Opening` = '" & Opening & "',
                                `Status` = '" & Status & "'
                               WHERE ProductID = " & txtProductID.Text
        cmd = New MySqlCommand(query, con)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            'MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Updated")
        Catch ex As Exception
            MsgBox("Ops! Error to updated Products: " & ex.Message, MsgBoxStyle.Critical, "Error Updated")
        Finally
            con.Close()
            con.Dispose()
            con.ClearAllPoolsAsync()
        End Try

        ListProduct()
    End Sub

    Protected Sub btnDeleteProduct_Click(sender As Object, e As EventArgs) Handles btnDeleteProduct.Click
        Dim con As New MySqlConnection(conString)

        Dim query As String = "DELETE FROM `productinfo_tab` WHERE ProductID = " & txtProductID.Text
        cmd = New MySqlCommand(query, con)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            'MsgBox("Successfully Deleted!", MsgBoxStyle.Information, "Deleted")
        Catch ex As Exception
            MsgBox("Ops! Error to deleted Products: " & ex.Message, MsgBoxStyle.Critical, "Error Deleted")
        Finally
            con.Close()
            con.Dispose()
            con.ClearAllPoolsAsync()
        End Try

        ListProduct()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim queryWhere As String = ""
        If (txtProductID.Text <> "") Then
            queryWhere = " WHERE `ProductID` = " & txtProductID.Text
        End If

        Dim con As New MySqlConnection(conString)
        Dim query As String = "Select * FROM `productinfo_tab` " & queryWhere
        cmd = New MySqlCommand(query, con)
        Try
            con.Open()
            da = New MySqlDataAdapter(cmd)
            da.Fill(dt)
            gvProducts.DataSource = dt
            gvProducts.DataBind()
        Catch ex As Exception
            MsgBox("Ops! Error to Select All Products: " & ex.Message, MsgBoxStyle.Critical, "Error Select")

        Finally
            con.Close()
            con.Dispose()
            con.ClearAllPoolsAsync()

        End Try
    End Sub
End Class