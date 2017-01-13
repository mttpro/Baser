Imports System.Windows.Forms
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Dialog2
    Private Shared Function Num(ByVal value As String) As Integer
        Dim returnVal As String = String.Empty
        Dim collection As MatchCollection = Regex.Matches(value, "\d+")
        For Each m As Match In collection
            returnVal += m.ToString()
        Next
        Return Convert.ToInt32(returnVal)
    End Function

    Private Function Encrypt(ByVal clearText As String, ByVal encryptkey As String) As String
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(encryptkey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function
    Private Function Decrypt(ByVal cipherText As String, ByVal encryptkey As String) As String
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(encryptkey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.Size = New Size(New Point(NumericUpDown4.Value, NumericUpDown5.Value))
        My.Settings.formsize = New Size(New Point(NumericUpDown4.Value, NumericUpDown5.Value))
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Dialog2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.language = 1 Then
            Me.Text = "Properties..."
            Label4.Text = "Save location:"
            Label2.Text = "Doc. name:"
            GroupBox2.Text = "Step/Resize value:"
            GroupBox1.Text = "Form size:"
            Label1.Text = "Vertical:"
            Label3.Text = "Horizontal:"
            Label5.Text = "Width:"
            Label6.Text = "Height:"
            CheckBox3.Text = "Auto increasing index"
        ElseIf My.Settings.language = 2 Then
            Me.Text = "Tulajdonságok..."
            Label4.Text = "Munkakönyvtár:"
            Label2.Text = "Fájlnév:"
            GroupBox2.Text = "Léptetési/Újraméretezési érték:"
            GroupBox1.Text = "Munkaterület méret:"
            Label1.Text = "Függőleges:"
            Label3.Text = "Vízszintes:"
            Label5.Text = "Szélesség:"
            Label6.Text = "Hosszúság:"
            CheckBox3.Text = "Auto. növekvő index"
        End If

        TextBox2.Focus()
        TextBox1.Text = My.Settings.quicksavefolder
        Form1.quicksavefolder.SelectedPath = My.Settings.quicksavefolder
        NumericUpDown1.Value = My.Settings.verticalstep
        NumericUpDown2.Value = My.Settings.horizontalstep
        NumericUpDown3.Value = My.Settings.savedocindex
        NumericUpDown4.Value = Form1.Size.Width
        NumericUpDown5.Value = Form1.Size.Height
    End Sub
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        My.Settings.verticalstep = NumericUpDown1.Value
    End Sub

    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown2.ValueChanged
        My.Settings.horizontalstep = NumericUpDown2.Value
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            NumericUpDown3.Enabled = True
            'TextBox2.Text = TextBox2.Text + NumericUpDown3.Value.ToString
        Else
            'TextBox2.Text = "Default Document"
            NumericUpDown3.Enabled = False
        End If
    End Sub

    Private Sub NumericUpDown3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown3.ValueChanged
        My.Settings.savedocindex = NumericUpDown3.Value
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Form1.quicksavefolder.SelectedPath = My.Settings.quicksavefolder
        If Form1.quicksavefolder.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.quicksavefolder = Form1.quicksavefolder.SelectedPath
            Form1.SaveFileDialog1.InitialDirectory = My.Settings.quicksavefolder
            Form1.OpenFileDialog1.InitialDirectory = My.Settings.quicksavefolder
            TextBox1.Text = My.Settings.quicksavefolder
        End If
    End Sub
End Class