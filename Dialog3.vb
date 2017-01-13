Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO

Public Class Dialog3
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
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Close()
    End Sub

    Private Sub Dialog3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
        TextBox5.Text = Nothing
        TextBox6.Text = Nothing
        TextBox7.Text = Nothing
        TextBox8.Text = Nothing
        OpenFileDialog1.InitialDirectory = My.Settings.quicksavefolder
        SaveFileDialog1.InitialDirectory = My.Settings.quicksavefolder
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'encrypt open
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'encrypt save
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox3.Text = SaveFileDialog1.FileName
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'clear
        TextBox1.Text = Nothing 'open
        TextBox2.Text = Nothing 'view
        TextBox3.Text = Nothing 'save path (encrypt)
        TextBox4.Text = Nothing 'password
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'clear
        TextBox5.Text = Nothing 'password
        TextBox6.Text = Nothing 'save path (decrypt)
        TextBox7.Text = Nothing 'view
        TextBox8.Text = Nothing 'open
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'encrypt button
        If TextBox1.TextLength > 0 And TextBox4.TextLength > 0 And TextBox3.TextLength > 0 Then
            TextBox2.Text = Encrypt(File.ReadAllText(TextBox1.Text), TextBox4.Text)
            File.WriteAllText(TextBox3.Text, TextBox2.Text)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'decrypt button
        If TextBox5.TextLength > 0 And TextBox6.TextLength > 0 And TextBox8.TextLength > 0 Then
            TextBox7.Text = Decrypt(File.ReadAllText(TextBox8.Text), TextBox5.Text)
            File.WriteAllText(TextBox6.Text, TextBox7.Text)
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'decrypt open
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox8.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'decrypt save
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox6.Text = SaveFileDialog1.FileName
        End If
    End Sub
End Class
