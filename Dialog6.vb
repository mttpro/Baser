Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Dialog6

    Private Sub Dialog6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = Nothing
        TextBox2.Text = My.Settings.quicksavefolder
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Form1.quicksavefolder.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.quicksavefolder = Form1.quicksavefolder.SelectedPath
            'Form1.SaveFileDialog1.InitialDirectory = My.Settings.quicksavefolder
            'Form1.OpenFileDialog1.InitialDirectory = My.Settings.quicksavefolder
            TextBox2.Text = My.Settings.quicksavefolder
        End If
    End Sub

    Public dbconn As New MySqlConnection
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'import button final
        Dim xmlname As String
        Dim xmldata As String
        Dim screwname As String
        Dim screw As String
        Dim connectstring As String = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=true", My.Settings.serverMYSQL, My.Settings.usernameMYSQL, My.Settings.passwordMYSQL, My.Settings.databaseMYSQL)
        If TextBox1.TextLength > 0 And TextBox2.TextLength > 0 And My.Settings.serverMYSQL.Length > 0 And My.Settings.usernameMYSQL.Length > 0 And My.Settings.databaseMYSQL.Length > 0 Then
            Try

                'ezek itt a server elérés adatok kapcsolat nyitáshoz
                dbconn.ConnectionString = connectstring
                dbconn.Open()
                'ez itt a command amit végre hajtatok a reader parancsal.
                'dbcomm = New MySqlCommand("INSERT INTO `markactest`.`user` (un,up,upn,uf,at,urt) VALUES (@username,@cup,@cupn,@cuf,@cue,@cat)", dbconn)
                dbcomm = New MySqlCommand("SELECT * FROM " + My.Settings.worktableMYSQL + " WHERE xmlname = @xmlname", dbconn)
                dbcomm.Parameters.AddWithValue("@xmlname", TextBox1.Text)
                dbread = dbcomm.ExecuteReader()
                'dbread.Read()
                dbread.Read()
                xmlname = dbread("xmlname")
                dbread.Read()
                xmldata = dbread("data")
                dbread.Read()
                screwname = dbread("screwname")
                dbread.Read()
                screw = dbread("screw")
                dbread.Read()

                File.WriteAllText(TextBox2.Text + "\" + xmlname + ".xml", xmldata)
                File.WriteAllText(TextBox2.Text + "\" + screwname + ".bin", screw)

                Form1.filename = TextBox2.Text + "\" + TextBox1.Text + ".xml"

                Dim values() As String = screw.Split("|"c)
                Class1.chkindex = values(0)
                Class1.radioindex = values(1)
                Class1.pictrindex = values(2)
                Class1.txtindex = values(3)
                Class1.labelindex = values(4)
                'xmlname = dbread("xmlname")
                'un = dbread("un")
                'dbread.Read()
                'xmldata = dbread("data")
                'cup = dbread("up")
                'dbread.Read()
                Form1.Text = "Baser v1.0 - " + TextBox1.Text + ".xml"
                'cupn = dbread("upn")
                'dbread.Read()
                'screw = dbread("screw")
                'uf = dbread("uf")

                dbread.Close()
                dbconn.Close()
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")
                dbread.Close()
                dbconn.Close()
            Finally
                dbread.Close()
                dbconn.Close()
                'Form1.filename = TextBox2.Text + xmlname + ".xml"
                'filename = OpenFileDialog1.FileName
                'screwname = OpenFileDialog1.FileName.Remove(OpenFileDialog1.FileName.Length - 4)
                'Me.Text = "Baser v1.0 - " + OpenFileDialog1.SafeFileName
                Form1.Timer1.Start()


                Me.Close()
                'xmlname = Nothing
                'xmldata = Nothing
                'screwname = Nothing
                'screw = Nothing
            End Try
        Else
            MsgBox("Import failed. Supply more data!", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim connectstring As String = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=true", My.Settings.serverMYSQL, My.Settings.usernameMYSQL, My.Settings.passwordMYSQL, My.Settings.databaseMYSQL)
            dbconn.ConnectionString = connectstring
            dbconn.Open()
            'ez itt a command amit végre hajtatok a reader parancsal.
            'dbcomm = New MySqlCommand("INSERT INTO `markactest`.`user` (un,up,upn,uf,at,urt) VALUES (@username,@cup,@cupn,@cuf,@cue,@cat)", dbconn)
            dbcomm = New MySqlCommand("DELETE FROM `" + My.Settings.worktableMYSQL + "` WHERE `xmlname` = @xmlname", dbconn)
            dbcomm.Parameters.AddWithValue("@xmlname", TextBox1.Text)
            dbread = dbcomm.ExecuteReader()
            dbread.Close()
            dbconn.Close()
        Catch ex As Exception
            MsgBox("Delete failed. " + ex.ToString, MsgBoxStyle.Critical, "Error")
        Finally
            MsgBox(TextBox1.Text + " removed from table: " + My.Settings.worktableMYSQL, MsgBoxStyle.Information, "Success")
        End Try
    End Sub
End Class
