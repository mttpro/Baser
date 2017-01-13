Imports System.Windows.Forms
Imports Microsoft.VisualBasic.Devices

Public Class Dialog4
    Dim page As Integer
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'next button
        Button2.Enabled = True
        page += 1
        If page = 2 And My.Settings.language = 1 Then
            GroupBox1.Text = "Creating a simple Form:"
            Label1.Text = "Step two: I add some controls to the workspace."
            Panel1.BackgroundImage = My.Resources.step_two
        ElseIf page = 3 And My.Settings.language = 1 Then
            GroupBox1.Text = "Creating a simple Form:"
            Label1.Text = "Step three: I assign the final positions."
            Panel1.BackgroundImage = My.Resources.step_three
        ElseIf page = 4 And My.Settings.language = 1 Then
            GroupBox1.Text = "Creating a simple Form:"
            Label1.Text = "Final step: I save my Form to use it later."
            Panel1.BackgroundImage = My.Resources.step_four
        ElseIf page = 5 And My.Settings.language = 1 Then
            'step_five
            GroupBox1.Text = "Using MySQL:"
            Label1.Text = "Step one: I specify data in MySQL->Credentials menu and create my Worktable."
            Panel1.BackgroundImage = My.Resources.step_five
        ElseIf page = 6 And My.Settings.language = 1 Then
            GroupBox1.Text = "Using MySQL:"
            Label1.Text = "Step two: I create a simple form to export."
            Panel1.BackgroundImage = My.Resources.step_six
        ElseIf page = 7 And My.Settings.language = 1 Then
            Button1.Enabled = False
            GroupBox1.Text = "Using MySQL:"
            Label1.Text = "Final step: I export. If i set everything correctly in Credentials menu it should be done."
            Panel1.BackgroundImage = My.Resources.step_seven
        End If


        If page = 2 And My.Settings.language = 2 Then
            GroupBox1.Text = "Példa űrlap készítés:"
            Label1.Text = "Második lépés: Hozzáadok pár elemet a munkaterületre."
            Panel1.BackgroundImage = My.Resources.step_two
        ElseIf page = 3 And My.Settings.language = 2 Then
            GroupBox1.Text = "Példa űrlap készítés:"
            Label1.Text = "Harmadik lépés: Elvégzem a végső igazításokat."
            Panel1.BackgroundImage = My.Resources.step_three
        ElseIf page = 4 And My.Settings.language = 2 Then
            GroupBox1.Text = "Példa űrlap készítés:"
            Label1.Text = "Utolsó lépés: Elmentem az űrlapot késöbbi használatra"
            Panel1.BackgroundImage = My.Resources.step_four
        ElseIf page = 5 And My.Settings.language = 2 Then
            GroupBox1.Text = "MySQL használata:"
            Label1.Text = "Első lépés: A MySQL->Credentials menüben beírom az adatbázis elérési adatait."
            Panel1.BackgroundImage = My.Resources.step_five
        ElseIf page = 6 And My.Settings.language = 2 Then
            GroupBox1.Text = "MySQL használata:"
            Label1.Text = "Második lépés: Készítek egy szimpla űrlapot exportáláshoz."
            Panel1.BackgroundImage = My.Resources.step_six
        ElseIf page = 7 And My.Settings.language = 2 Then
            Button1.Enabled = False
            GroupBox1.Text = "MySQL használata:"
            Label1.Text = "Utolsó lépés: MySQL->Export parancsal exportálok az adatbázisomba."
            Panel1.BackgroundImage = My.Resources.step_seven
        End If
    End Sub

    Private Sub Dialog4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.BackgroundImage = My.Resources.step_one
        If My.Settings.language = 1 Then
            GroupBox1.Text = "Creating a simple Form:"
            Label1.Text = "Step one: I set up a work directory and filename."
        ElseIf My.Settings.language = 2 Then
            GroupBox1.Text = "Példa űrlap készítés:"
            Label1.Text = "Első lépés: Beállítom a munkakönyvtárat és a fájlnevet."
        End If
        Button2.Enabled = False
        page = 1
        Button1.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'back button
        Button1.Enabled = True
        page -= 1
        If page = 1 And My.Settings.language = 1 Then
            Button2.Enabled = False
            GroupBox1.Text = "Creating a simple Form:"
            Label1.Text = "Step one: I set up a work directory and filename."
            Panel1.BackgroundImage = My.Resources.step_one
        ElseIf page = 2 And My.Settings.language = 1 Then
            GroupBox1.Text = "Creating a simple Form:"
            Label1.Text = "Step two: I add some controls to the workspace."
            Panel1.BackgroundImage = My.Resources.step_two
        ElseIf page = 3 And My.Settings.language = 1 Then
            GroupBox1.Text = "Creating a simple Form:"
            Label1.Text = "Step three: I assign the final positions."
            Panel1.BackgroundImage = My.Resources.step_three
        ElseIf page = 4 And My.Settings.language = 1 Then
            GroupBox1.Text = "Creating a simple Form:"
            Label1.Text = "Final step: I save my Form to use it later."
            Panel1.BackgroundImage = My.Resources.step_four
        ElseIf page = 5 And My.Settings.language = 1 Then
            'step_five
            GroupBox1.Text = "Using MySQL:"
            Label1.Text = "Step one: I specify data in MySQL->Credentials menu and create my Worktable."
            Panel1.BackgroundImage = My.Resources.step_five
        ElseIf page = 6 And My.Settings.language = 1 Then
            GroupBox1.Text = "Using MySQL:"
            Label1.Text = "Step two: I create a simple form to export."
            Panel1.BackgroundImage = My.Resources.step_six
        ElseIf page = 7 And My.Settings.language = 1 Then
            'Button1.Enabled = False
            GroupBox1.Text = "Using MySQL:"
            Label1.Text = "Final step: I export. If i set everything correctly in Credentials menu it should be done."
            Panel1.BackgroundImage = My.Resources.step_seven
        End If

        If page = 1 And My.Settings.language = 2 Then
            Button2.Enabled = False
            GroupBox1.Text = "Példa űrlap készítés:"
            Label1.Text = "Első lépés: Beállítom a munkakönyvtárat és a fájlnevet."
            Panel1.BackgroundImage = My.Resources.step_one
        ElseIf page = 2 And My.Settings.language = 2 Then
            GroupBox1.Text = "Példa űrlap készítés:"
            Label1.Text = "Második lépés: Hozzáadok pár elemet a munkaterületre."
            Panel1.BackgroundImage = My.Resources.step_two
        ElseIf page = 3 And My.Settings.language = 2 Then
            GroupBox1.Text = "Példa űrlap készítés:"
            Label1.Text = "Harmadik lépés: Elvégzem a végső igazításokat."
            Panel1.BackgroundImage = My.Resources.step_three
        ElseIf page = 4 And My.Settings.language = 2 Then
            GroupBox1.Text = "Példa űrlap készítés:"
            Label1.Text = "Utolsó lépés: Elmentem az űrlapot késöbbi használatra"
            Panel1.BackgroundImage = My.Resources.step_four
        ElseIf page = 5 And My.Settings.language = 2 Then
            GroupBox1.Text = "MySQL használata:"
            Label1.Text = "Első lépés: A MySQL->Credentials menüben beírom az adatbázis elérési adatait."
            Panel1.BackgroundImage = My.Resources.step_five
        ElseIf page = 6 And My.Settings.language = 2 Then
            GroupBox1.Text = "MySQL használata:"
            Label1.Text = "Második lépés: Készítek egy szimpla űrlapot exportáláshoz."
            Panel1.BackgroundImage = My.Resources.step_six
        ElseIf page = 7 And My.Settings.language = 2 Then
            'Button1.Enabled = False
            GroupBox1.Text = "MySQL használata:"
            Label1.Text = "Utolsó lépés: MySQL->Export parancsal exportálok az adatbázisomba."
            Panel1.BackgroundImage = My.Resources.step_seven
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'donate button
        Try
            Button3.Cursor = Cursors.WaitCursor
            Process.Start("https://www.paypal.me/BaserDonation")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")
        Finally
            Button3.Cursor = Cursors.Default
        End Try

        'Mouse.OverrideCursor = Nothing

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'email button
        Try
            Process.Start(String.Format("mailto:{0}", "chad23@sigaint.org"))
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
