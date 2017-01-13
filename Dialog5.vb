Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Dialog5

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Close()
        My.Settings.databaseMYSQL = TextBox1.Text
        My.Settings.serverMYSQL = TextBox2.Text
        My.Settings.usernameMYSQL = TextBox3.Text
        My.Settings.passwordMYSQL = TextBox4.Text
        My.Settings.worktableMYSQL = TextBox5.Text
    End Sub

    Private Sub Dialog5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.databaseMYSQL 'Database name
        TextBox2.Text = My.Settings.serverMYSQL 'Server
        TextBox3.Text = My.Settings.usernameMYSQL 'Username
        TextBox4.Text = My.Settings.passwordMYSQL 'Password
        TextBox5.Text = My.Settings.worktableMYSQL 'Worktable
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'clear button
        TextBox1.Text = Nothing 'Database name
        TextBox2.Text = Nothing 'Server
        TextBox3.Text = Nothing 'Username
        TextBox4.Text = Nothing 'Password
        TextBox5.Text = Nothing 'Worktable

        My.Settings.databaseMYSQL = Nothing 'Database name
        My.Settings.serverMYSQL = Nothing 'Server
        My.Settings.usernameMYSQL = Nothing 'Username
        My.Settings.passwordMYSQL = Nothing 'Password
        My.Settings.worktableMYSQL = Nothing 'Worktable
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        My.Settings.databaseMYSQL = TextBox1.Text
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        My.Settings.serverMYSQL = TextBox2.Text
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        My.Settings.usernameMYSQL = TextBox3.Text
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        My.Settings.passwordMYSQL = TextBox4.Text
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        My.Settings.worktableMYSQL = TextBox5.Text
    End Sub

    Public dbconn As New MySqlConnection
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'create table gomb
        'CREATE TABLE  `test`.`worktable` (`xmlname` VARCHAR( 200 ) NOT NULL ,`data` TEXT NOT NULL ,`screwname` TEXT NOT NULL ,`screw` TEXT NOT NULL ,PRIMARY KEY (  `xmlname` )) ENGINE = MYISAM
        '1235
        If TextBox1.TextLength > 0 And TextBox2.TextLength > 0 And TextBox3.TextLength > 0 And TextBox5.TextLength > 0 Then
            Try
                dbconn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=true", My.Settings.serverMYSQL, My.Settings.usernameMYSQL, My.Settings.passwordMYSQL, My.Settings.databaseMYSQL)
                dbconn.Open()
                dbcomm = New MySqlCommand("CREATE TABLE  `" + My.Settings.databaseMYSQL + "`.`" + My.Settings.worktableMYSQL + "` (`xmlname` VARCHAR( 200 ) NOT NULL ,`data` TEXT NOT NULL ,`screwname` TEXT NOT NULL ,`screw` TEXT NOT NULL ,PRIMARY KEY (  `xmlname` )) ENGINE = MYISAM", dbconn)
                dbread = dbcomm.ExecuteReader()
                dbread.Close()
                dbconn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                dbread.Close()
                dbconn.Close()
            Finally
                MsgBox("Table created.", MsgBoxStyle.Information, "Success")
            End Try
        Else
            MsgBox("Can't create table with the supplied data!", MsgBoxStyle.Critical, "Error")
        End If

    End Sub
End Class
