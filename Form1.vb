Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports System.Text
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient

Public Class Form1
    Private _getControlValues As String

    Private Property GetControlValues(ByVal form1 As Form1, ByVal p2 As Object) As String
        Get
            Return _getControlValues
        End Get
        Set(ByVal value As String)
            _getControlValues = value
        End Set
    End Property

    Private Property mExludeControlSettings As Object

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'MsgBox("kilépés")
        If Me.Text = "Baser v1.0" And Panel1.Controls.Count > 0 Then
            If MsgBox("Would you like to save?", MsgBoxStyle.YesNo, "Baser") = MsgBoxResult.Yes Then
                SaveToolStripMenuItem1.PerformClick()
            End If
        End If
        'My.Settings.formloc = Me.Location
        'My.Settings.Save()
    End Sub

    Private Sub Main_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        'fogalmam sincs ez mit csinal
    End Sub

    Private Sub BackColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackColorToolStripMenuItem.Click
        ColorDialog1.Color = Panel1.BackColor
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Panel1.BackColor = ColorDialog1.Color
            My.Settings.panelbackcolor = ColorDialog1.Color
        End If
    End Sub

    Private Sub LoadImageFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadImageFileToolStripMenuItem.Click
        If openimage.ShowDialog = Windows.Forms.DialogResult.OK Then
            Panel1.BackgroundImage = Image.FromFile(openimage.FileName)
            imgflip = 0
            'Panel1.Tag = openimage.FileName
            My.Settings.backgroundimg = openimage.FileName
        End If
    End Sub

    Private Sub TileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileToolStripMenuItem.Click
        Panel1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.backimglayout = "1"
    End Sub

    Private Sub CenterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CenterToolStripMenuItem.Click
        Panel1.BackgroundImageLayout = ImageLayout.Center
        My.Settings.backimglayout = "2"
    End Sub

    Private Sub StretchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StretchToolStripMenuItem.Click
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        My.Settings.backimglayout = "3"
    End Sub

    Private Sub ZoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomToolStripMenuItem.Click
        Panel1.BackgroundImageLayout = ImageLayout.Zoom
        My.Settings.backimglayout = "4"
    End Sub

    Private Sub TextBoxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxToolStripMenuItem.Click
        If EnglishToolStripMenuItem.Checked = True Then
            Dialog1.Text = "Add new textbox"
            Dialog1.TextBox1.Text = ""
            Dialog1.TextBox2.Text = "example"
            Dialog1.CheckBox3.Text = "Auto Increase"
            Dialog1.CheckBox2.Text = "Auto Increase"
            Dialog1.CheckBox1.Text = "Auto Increase"
            Dialog1.Label2.Text = "Size (pixel):"
            Dialog1.Label4.Text = "Location:"
            Dialog1.Label6.Text = "Text align:"
            Dialog1.Label8.Text = "Border style:"
            Dialog1.fontbtn.Text = "Font"
            Dialog1.colorbtn.Text = "Color"
            Dialog1.multilinecheck.Text = "Multiline"
            Dialog1.scrollbarcheck.Text = "Scrollbar"
            Dialog1.Button3.Text = "Back color"
            Dialog1.CheckBox4.Text = "Transparent"
            Dialog1.Label7.Text = "Image layout:"
            Dialog1.loadimg.Text = "Load image..."
            Dialog1.Button1.Text = "Add"
        ElseIf MagyarToolStripMenuItem.Checked = True Then
            Dialog1.Text = "Szövegdoboz hozzáadása"
            Dialog1.TextBox1.Text = ""
            Dialog1.TextBox2.Text = "példa"
            Dialog1.CheckBox3.Text = "Auto. növekedés"
            Dialog1.CheckBox2.Text = "Auto. növekedés"
            Dialog1.CheckBox1.Text = "Auto. növekedés"
            Dialog1.Label2.Text = "Méret (pixel):"
            Dialog1.Label4.Text = "Hely:"
            Dialog1.Label6.Text = "Igazítás:"
            Dialog1.Label8.Text = "Keret stílus:"
            Dialog1.fontbtn.Text = "Betűtípus"
            Dialog1.colorbtn.Text = "Szín"
            Dialog1.multilinecheck.Text = "Többsoros"
            Dialog1.scrollbarcheck.Text = "Görgetősáv"
            Dialog1.Button3.Text = "Háttérszín"
            Dialog1.CheckBox4.Text = "Átlátszó"
            Dialog1.Label7.Text = "Kép elrendezés:"
            Dialog1.loadimg.Text = "Kép betöltése..."
            Dialog1.Button1.Text = "Hozzáad"
        End If

        Dialog1.Button1.Enabled = True
        Dialog1.TextBox2.ForeColor = Dialog1.Panel1.BackColor
        Dialog1.TextBox2.BackColor = Dialog1.Panel2.BackColor
        Dialog1.NumericUpDown1.Enabled = True
        Dialog1.sizeheight.Enabled = False
        Dialog1.sizewith.Enabled = True
        Dialog1.ComboBox1.Enabled = True
        Dialog1.CheckBox3.Enabled = True
        Dialog1.TextBox1.Enabled = False
        Dialog1.PictureBox1.Enabled = False
        Dialog1.loadimg.Enabled = False
        Dialog1.fontbtn.Enabled = True
        Dialog1.colorbtn.Enabled = True
        Dialog1.ComboBox2.Enabled = False
        Dialog1.CheckBox4.Enabled = False
        Dialog1.multilinecheck.Enabled = True
        Dialog1.ComboBox3.Enabled = True
        Dialog1.TextBox2.Visible = True
        Dialog1.scrollbarcheck.Enabled = True
        Dialog1.multilinecheck.Enabled = True
        Dialog1.Button4.Enabled = False
        Dialog1.Button5.Enabled = False
        Dialog1.ShowDialog()
    End Sub

    Private Sub PictureBoxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxToolStripMenuItem.Click
        If EnglishToolStripMenuItem.Checked = True Then
            Dialog1.Text = "Add new picturebox"
            Dialog1.TextBox1.Text = "none"
            Dialog1.TextBox2.Text = "example"
            Dialog1.CheckBox3.Text = "Auto Increase"
            Dialog1.CheckBox2.Text = "Auto Increase"
            Dialog1.CheckBox1.Text = "Auto Increase"
            Dialog1.Label2.Text = "Size (pixel):"
            Dialog1.Label4.Text = "Location:"
            Dialog1.Label6.Text = "Text align:"
            Dialog1.Label8.Text = "Border style:"
            Dialog1.fontbtn.Text = "Font"
            Dialog1.colorbtn.Text = "Color"
            Dialog1.multilinecheck.Text = "Multiline"
            Dialog1.scrollbarcheck.Text = "Scrollbar"
            Dialog1.Button3.Text = "Back color"
            Dialog1.CheckBox4.Text = "Transparent"
            Dialog1.Label7.Text = "Image layout:"
            Dialog1.loadimg.Text = "Load image..."
            Dialog1.Button1.Text = "Add"
        ElseIf MagyarToolStripMenuItem.Checked = True Then
            Dialog1.Text = "Kép hozzáadása"
            Dialog1.TextBox1.Text = "semmi"
            Dialog1.TextBox2.Text = "példa"
            Dialog1.CheckBox3.Text = "Auto. növekedés"
            Dialog1.CheckBox2.Text = "Auto. növekedés"
            Dialog1.CheckBox1.Text = "Auto. növekedés"
            Dialog1.Label2.Text = "Méret (pixel):"
            Dialog1.Label4.Text = "Hely:"
            Dialog1.Label6.Text = "Igazítás:"
            Dialog1.Label8.Text = "Keret stílus:"
            Dialog1.fontbtn.Text = "Betűtípus"
            Dialog1.colorbtn.Text = "Szín"
            Dialog1.multilinecheck.Text = "Többsoros"
            Dialog1.scrollbarcheck.Text = "Görgetősáv"
            Dialog1.Button3.Text = "Háttérszín"
            Dialog1.CheckBox4.Text = "Átlátszó"
            Dialog1.Label7.Text = "Kép elrendezés:"
            Dialog1.loadimg.Text = "Kép betöltése..."
            Dialog1.Button1.Text = "Hozzáad"
        End If

        Dialog1.Button1.Enabled = False
        Dialog1.TextBox1.Enabled = False
        Dialog1.NumericUpDown1.Enabled = False
        Dialog1.sizeheight.Enabled = True
        Dialog1.sizewith.Enabled = True
        Dialog1.ComboBox1.Enabled = False
        Dialog1.CheckBox3.Enabled = True
        Dialog1.PictureBox1.Enabled = True
        Dialog1.loadimg.Enabled = True
        Dialog1.fontbtn.Enabled = False
        Dialog1.colorbtn.Enabled = False
        Dialog1.ComboBox2.Enabled = True
        Dialog1.CheckBox4.Enabled = True
        Dialog1.multilinecheck.Enabled = False
        Dialog1.ComboBox3.Enabled = False
        Dialog1.TextBox2.Visible = False
        Dialog1.scrollbarcheck.Enabled = False
        Dialog1.multilinecheck.Enabled = False
        Dialog1.Button4.Enabled = True
        Dialog1.Button5.Enabled = True
        Dialog1.ShowDialog()
    End Sub

    Private Sub RadioButtonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonToolStripMenuItem.Click
        If EnglishToolStripMenuItem.Checked = True Then
            Dialog1.Text = "Add new radiobutton"
            Dialog1.TextBox1.Text = "RadioButton text"
            Dialog1.TextBox2.Text = "example"
            Dialog1.CheckBox3.Text = "Auto Increase"
            Dialog1.CheckBox2.Text = "Auto Increase"
            Dialog1.CheckBox1.Text = "Auto Increase"
            Dialog1.Label2.Text = "Size (pixel):"
            Dialog1.Label4.Text = "Location:"
            Dialog1.Label6.Text = "Text align:"
            Dialog1.Label8.Text = "Border style:"
            Dialog1.fontbtn.Text = "Font"
            Dialog1.colorbtn.Text = "Color"
            Dialog1.multilinecheck.Text = "Multiline"
            Dialog1.scrollbarcheck.Text = "Scrollbar"
            Dialog1.Button3.Text = "Back color"
            Dialog1.CheckBox4.Text = "Transparent"
            Dialog1.Label7.Text = "Image layout:"
            Dialog1.loadimg.Text = "Load image..."
            Dialog1.Button1.Text = "Add"
        ElseIf MagyarToolStripMenuItem.Checked = True Then
            Dialog1.Text = "Választógomb hozzáadása"
            Dialog1.TextBox1.Text = "Választógomb szöveg"
            Dialog1.TextBox2.Text = "példa"
            Dialog1.CheckBox3.Text = "Auto. növekedés"
            Dialog1.CheckBox2.Text = "Auto. növekedés"
            Dialog1.CheckBox1.Text = "Auto. növekedés"
            Dialog1.Label2.Text = "Méret (pixel):"
            Dialog1.Label4.Text = "Hely:"
            Dialog1.Label6.Text = "Igazítás:"
            Dialog1.Label8.Text = "Keret stílus:"
            Dialog1.fontbtn.Text = "Betűtípus"
            Dialog1.colorbtn.Text = "Szín"
            Dialog1.multilinecheck.Text = "Többsoros"
            Dialog1.scrollbarcheck.Text = "Görgetősáv"
            Dialog1.Button3.Text = "Háttérszín"
            Dialog1.CheckBox4.Text = "Átlátszó"
            Dialog1.Label7.Text = "Kép elrendezés:"
            Dialog1.loadimg.Text = "Kép betöltése..."
            Dialog1.Button1.Text = "Hozzáad"
        End If

        Dialog1.Button1.Enabled = True
        Dialog1.NumericUpDown1.Enabled = True
        Dialog1.sizeheight.Enabled = False
        Dialog1.sizewith.Enabled = False
        Dialog1.ComboBox1.Enabled = False
        Dialog1.TextBox1.Enabled = True
        Dialog1.PictureBox1.Enabled = False
        Dialog1.loadimg.Enabled = False
        Dialog1.fontbtn.Enabled = True
        Dialog1.colorbtn.Enabled = True
        Dialog1.ComboBox2.Enabled = False
        Dialog1.CheckBox4.Enabled = True
        Dialog1.multilinecheck.Enabled = False
        Dialog1.ComboBox3.Enabled = False
        Dialog1.TextBox2.Visible = False
        Dialog1.scrollbarcheck.Enabled = False
        Dialog1.multilinecheck.Enabled = False
        Dialog1.Button4.Enabled = False
        Dialog1.Button5.Enabled = False
        Dialog1.ShowDialog()
    End Sub

    Private Sub CheckBoxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxToolStripMenuItem.Click
        If EnglishToolStripMenuItem.Checked = True Then
            Dialog1.Text = "Add new checkbox"
            Dialog1.TextBox1.Text = "CheckBox text"
            Dialog1.TextBox2.Text = "example"
            Dialog1.CheckBox3.Text = "Auto Increase"
            Dialog1.CheckBox2.Text = "Auto Increase"
            Dialog1.CheckBox1.Text = "Auto Increase"
            Dialog1.Label2.Text = "Size (pixel):"
            Dialog1.Label4.Text = "Location:"
            Dialog1.Label6.Text = "Text align:"
            Dialog1.Label8.Text = "Border style:"
            Dialog1.fontbtn.Text = "Font"
            Dialog1.colorbtn.Text = "Color"
            Dialog1.multilinecheck.Text = "Multiline"
            Dialog1.scrollbarcheck.Text = "Scrollbar"
            Dialog1.Button3.Text = "Back color"
            Dialog1.CheckBox4.Text = "Transparent"
            Dialog1.Label7.Text = "Image layout:"
            Dialog1.loadimg.Text = "Load image..."
            Dialog1.Button1.Text = "Add"
        ElseIf MagyarToolStripMenuItem.Checked = True Then
            Dialog1.Text = "Jelölőnégyzet hozzáadása"
            Dialog1.TextBox1.Text = "Jelölőnégyzet szöveg"
            Dialog1.TextBox2.Text = "példa"
            Dialog1.CheckBox3.Text = "Auto. növekedés"
            Dialog1.CheckBox2.Text = "Auto. növekedés"
            Dialog1.CheckBox1.Text = "Auto. növekedés"
            Dialog1.Label2.Text = "Méret (pixel):"
            Dialog1.Label4.Text = "Hely:"
            Dialog1.Label6.Text = "Igazítás:"
            Dialog1.Label8.Text = "Keret stílus:"
            Dialog1.fontbtn.Text = "Betűtípus"
            Dialog1.colorbtn.Text = "Szín"
            Dialog1.multilinecheck.Text = "Többsoros"
            Dialog1.scrollbarcheck.Text = "Görgetősáv"
            Dialog1.Button3.Text = "Háttérszín"
            Dialog1.CheckBox4.Text = "Átlátszó"
            Dialog1.Label7.Text = "Kép elrendezés:"
            Dialog1.loadimg.Text = "Kép betöltése..."
            Dialog1.Button1.Text = "Hozzáad"
        End If

        Dialog1.Button1.Enabled = True
        Dialog1.NumericUpDown1.Enabled = True
        Dialog1.sizeheight.Enabled = False
        Dialog1.sizewith.Enabled = False
        Dialog1.ComboBox1.Enabled = False
        Dialog1.TextBox1.Enabled = True
        Dialog1.PictureBox1.Enabled = False
        Dialog1.loadimg.Enabled = False
        Dialog1.fontbtn.Enabled = True
        Dialog1.colorbtn.Enabled = True
        Dialog1.ComboBox2.Enabled = False
        Dialog1.CheckBox4.Enabled = True
        Dialog1.multilinecheck.Enabled = False
        Dialog1.ComboBox3.Enabled = False
        Dialog1.TextBox2.Visible = False
        Dialog1.scrollbarcheck.Enabled = False
        Dialog1.multilinecheck.Enabled = False
        Dialog1.Button4.Enabled = False
        Dialog1.Button5.Enabled = False
        Dialog1.ShowDialog()
    End Sub

    Private Sub LabelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelToolStripMenuItem.Click
        If EnglishToolStripMenuItem.Checked = True Then
            Dialog1.Text = "Add new label"
            Dialog1.TextBox1.Text = "Label text"
            Dialog1.TextBox2.Text = "example"
            Dialog1.CheckBox3.Text = "Auto Increase"
            Dialog1.CheckBox2.Text = "Auto Increase"
            Dialog1.CheckBox1.Text = "Auto Increase"
            Dialog1.Label2.Text = "Size (pixel):"
            Dialog1.Label4.Text = "Location:"
            Dialog1.Label6.Text = "Text align:"
            Dialog1.Label8.Text = "Border style:"
            Dialog1.fontbtn.Text = "Font"
            Dialog1.colorbtn.Text = "Color"
            Dialog1.multilinecheck.Text = "Multiline"
            Dialog1.scrollbarcheck.Text = "Scrollbar"
            Dialog1.Button3.Text = "Back color"
            Dialog1.CheckBox4.Text = "Transparent"
            Dialog1.Label7.Text = "Image layout:"
            Dialog1.loadimg.Text = "Load image..."
            Dialog1.Button1.Text = "Add"
        ElseIf MagyarToolStripMenuItem.Checked = True Then
            Dialog1.Text = "Címke hozzáadása"
            Dialog1.TextBox1.Text = "Címke szöveg"
            Dialog1.TextBox2.Text = "példa"
            Dialog1.CheckBox3.Text = "Auto. növekedés"
            Dialog1.CheckBox2.Text = "Auto. növekedés"
            Dialog1.CheckBox1.Text = "Auto. növekedés"
            Dialog1.Label2.Text = "Méret (pixel):"
            Dialog1.Label4.Text = "Hely:"
            Dialog1.Label6.Text = "Igazítás:"
            Dialog1.Label8.Text = "Keret stílus:"
            Dialog1.fontbtn.Text = "Betűtípus"
            Dialog1.colorbtn.Text = "Szín"
            Dialog1.multilinecheck.Text = "Többsoros"
            Dialog1.scrollbarcheck.Text = "Görgetősáv"
            Dialog1.Button3.Text = "Háttérszín"
            Dialog1.CheckBox4.Text = "Átlátszó"
            Dialog1.Label7.Text = "Kép elrendezés:"
            Dialog1.loadimg.Text = "Kép betöltése..."
            Dialog1.Button1.Text = "Hozzáad"
        End If

        Dialog1.Button1.Enabled = True
        Dialog1.NumericUpDown1.Enabled = False
        Dialog1.sizeheight.Enabled = False
        Dialog1.sizewith.Enabled = False
        Dialog1.ComboBox1.Enabled = False
        Dialog1.TextBox1.Enabled = True
        Dialog1.PictureBox1.Enabled = False
        Dialog1.loadimg.Enabled = False
        Dialog1.fontbtn.Enabled = True
        Dialog1.colorbtn.Enabled = True
        Dialog1.ComboBox2.Enabled = False
        Dialog1.CheckBox4.Enabled = True
        Dialog1.ComboBox3.Enabled = False
        Dialog1.TextBox2.Visible = False
        Dialog1.scrollbarcheck.Enabled = False
        Dialog1.multilinecheck.Enabled = False
        Dialog1.Button4.Enabled = False
        Dialog1.Button5.Enabled = False
        Dialog1.ShowDialog()
    End Sub

    Private Shared Function Num(ByVal value As String) As Integer
        Dim returnVal As String = String.Empty
        Dim collection As MatchCollection = Regex.Matches(value, "\d+")
        For Each m As Match In collection
            returnVal += m.ToString()
        Next
        Return Convert.ToInt32(returnVal)
    End Function

    Private Sub SaveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem1.Click
        'If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        'File.WriteAllText(SaveFileDialog1.FileName, String.Join("|", New String() {TextBox1.Text, TextBox2.Text, TextBox3.Text}))
        'End If
        'If File.Exists()
        If Me.Text.Length = 10 Then
            If Dialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
                If Dialog2.CheckBox3.Checked = True And My.Computer.FileSystem.FileExists(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml") = True Then
                    My.Computer.FileSystem.DeleteFile(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml")
                    My.Computer.FileSystem.DeleteFile(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + "_screw" + ".bin")
                    Try
                        dowrite(Panel1)
                        ds.WriteXml(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml")
                        File.WriteAllText(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + "_screw" + ".bin", String.Join("|", New String() {Class1.chkindex, Class1.radioindex, Class1.pictrindex, Class1.txtindex, Class1.labelindex}))
                    Finally
                        My.Settings.savedocindex += 1
                        ds.Tables(0).Rows.Clear()
                        ds.Clear()
                        MsgBox("Document saved: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml" + ", Screw: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + "_screw" + ".bin", MsgBoxStyle.Information, "Document saved")
                        Me.Text = "Baser v1.0 - " + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml"
                    End Try

                ElseIf Dialog2.CheckBox3.Checked = False And My.Computer.FileSystem.FileExists(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml") = True Then
                    My.Computer.FileSystem.DeleteFile(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml")
                    My.Computer.FileSystem.DeleteFile(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + "_screw" + ".bin")
                    Try
                        dowrite(Panel1)
                        ds.WriteXml(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml")
                        File.WriteAllText(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + "_screw" + ".bin", String.Join("|", New String() {Class1.chkindex, Class1.radioindex, Class1.pictrindex, Class1.txtindex, Class1.labelindex}))
                    Finally
                        ds.Tables(0).Rows.Clear()
                        ds.Clear()
                        MsgBox("Document saved: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml" + ", Screw: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + "_screw" + ".bin", MsgBoxStyle.Information, "Document saved")
                        Me.Text = "Baser v1.0 - " + Dialog2.TextBox2.Text + ".xml"
                    End Try

                ElseIf Dialog2.CheckBox3.Checked = True And My.Computer.FileSystem.FileExists(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml") = False Then
                    Try
                        dowrite(Panel1)
                        ds.WriteXml(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml")
                        File.WriteAllText(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + "_screw" + ".bin", String.Join("|", New String() {Class1.chkindex, Class1.radioindex, Class1.pictrindex, Class1.txtindex, Class1.labelindex}))
                    Finally
                        My.Settings.savedocindex += 1
                        ds.Tables(0).Rows.Clear()
                        ds.Clear()
                        MsgBox("Document saved: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml" + ", Screw: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + "_screw" + ".bin", MsgBoxStyle.Information, "Document saved")
                        Me.Text = "Baser v1.0 - " + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml"
                    End Try

                ElseIf Dialog2.CheckBox3.Checked = False And My.Computer.FileSystem.FileExists(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml") = False Then
                    Try
                        dowrite(Panel1)
                        ds.WriteXml(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml")
                        File.WriteAllText(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + "_screw" + ".bin", String.Join("|", New String() {Class1.chkindex, Class1.radioindex, Class1.pictrindex, Class1.txtindex, Class1.labelindex}))
                    Finally
                        ds.Tables(0).Rows.Clear()
                        ds.Clear()
                        MsgBox("Document saved: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml" + ", Screw: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + "_screw" + ".bin", MsgBoxStyle.Information, "Document saved")
                        Me.Text = "Baser v1.0 - " + Dialog2.TextBox2.Text + ".xml"
                    End Try
                End If
            End If
        ElseIf Me.Text.Length > 10 Then
            ds.Tables(0).Rows.Clear()
            ds.Clear()
            If Dialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
                If Dialog2.CheckBox3.Checked = True And My.Computer.FileSystem.FileExists(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml") = True Then
                    My.Computer.FileSystem.DeleteFile(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml")
                    My.Computer.FileSystem.DeleteFile(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + "_screw" + ".bin")
                    Try
                        dowrite(Panel1)
                        ds.WriteXml(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml")
                        File.WriteAllText(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + "_screw" + ".bin", String.Join("|", New String() {Class1.chkindex, Class1.radioindex, Class1.pictrindex, Class1.txtindex, Class1.labelindex}))
                    Finally
                        My.Settings.savedocindex += 1
                        ds.Tables(0).Rows.Clear()
                        ds.Clear()
                        MsgBox("Document saved: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml" + ", Screw: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + "_screw" + ".bin", MsgBoxStyle.Information, "Document saved")
                        Me.Text = "Baser v1.0 - " + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml"
                    End Try

                ElseIf Dialog2.CheckBox3.Checked = False And My.Computer.FileSystem.FileExists(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml") = True Then
                    My.Computer.FileSystem.DeleteFile(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml")
                    My.Computer.FileSystem.DeleteFile(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + "_screw" + ".bin")
                    Try
                        dowrite(Panel1)
                        ds.WriteXml(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml")
                        File.WriteAllText(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + "_screw" + ".bin", String.Join("|", New String() {Class1.chkindex, Class1.radioindex, Class1.pictrindex, Class1.txtindex, Class1.labelindex}))
                    Finally
                        ds.Tables(0).Rows.Clear()
                        ds.Clear()
                        MsgBox("Document saved: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml" + ", Screw: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + "_screw" + ".bin", MsgBoxStyle.Information, "Document saved")
                        Me.Text = "Baser v1.0 - " + Dialog2.TextBox2.Text + ".xml"
                    End Try

                ElseIf Dialog2.CheckBox3.Checked = True And My.Computer.FileSystem.FileExists(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml") = False Then
                    Try
                        dowrite(Panel1)
                        ds.WriteXml(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml")
                        File.WriteAllText(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + "_screw" + ".bin", String.Join("|", New String() {Class1.chkindex, Class1.radioindex, Class1.pictrindex, Class1.txtindex, Class1.labelindex}))
                    Finally
                        My.Settings.savedocindex += 1
                        ds.Tables(0).Rows.Clear()
                        ds.Clear()
                        MsgBox("Document saved: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml" + ", Screw: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + "_screw" + ".bin", MsgBoxStyle.Information, "Document saved")
                        Me.Text = "Baser v1.0 - " + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + ".xml"
                    End Try

                ElseIf Dialog2.CheckBox3.Checked = False And My.Computer.FileSystem.FileExists(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml") = False Then
                    Try
                        dowrite(Panel1)
                        ds.WriteXml(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml")
                        File.WriteAllText(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + "_screw" + ".bin", String.Join("|", New String() {Class1.chkindex, Class1.radioindex, Class1.pictrindex, Class1.txtindex, Class1.labelindex}))
                    Finally
                        ds.Tables(0).Rows.Clear()
                        ds.Clear()
                        MsgBox("Document saved: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml" + ", Screw: " + My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + "_screw" + ".bin", MsgBoxStyle.Information, "Document saved")
                        Me.Text = "Baser v1.0 - " + Dialog2.TextBox2.Text + ".xml"
                    End Try
                End If
            End If
        End If

        'For i As Integer = 1 To Class1.chkindex
        'Debug.Write(i.ToString)
        'File.WriteAllText("C:\Data.txt", String.Join("|", New String() {TextBox1.Text, TextBox2.Text, TextBox3.Text}))
        'My.Computer.FileSystem.WriteAllText()
        'Next
    End Sub

    Private Sub LoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK And OpenFileDialog1.FileName.Length > 0 Then
            Panel1.Controls.Clear()
            filename = OpenFileDialog1.FileName
            screwname = OpenFileDialog1.FileName.Remove(OpenFileDialog1.FileName.Length - 4)
            Me.Text = "Baser v1.0 - " + OpenFileDialog1.SafeFileName
            Timer1.Start()
                Dim values() As String = File.ReadAllText(screwname + "_screw" + ".bin").Split("|"c)
                Class1.chkindex = values(0)
                Class1.radioindex = values(1)
                Class1.pictrindex = values(2)
                Class1.txtindex = values(3)
                Class1.labelindex = values(4)
        End If
    End Sub

    'TextBox1.Text = Button1.Font.ToHfont
    'Dim vas As Integer
    'vas = Button1.Font.ToHfont
    'Label1.Font = Drawing.Font.FromHfont(vas)
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        dt.Columns.Add("Name")
        dt.Columns.Add("Text")
        dt.Columns.Add("Height")
        dt.Columns.Add("Width")
        dt.Columns.Add("locheight")
        dt.Columns.Add("locwidth")
        dt.Columns.Add("tabindex")
        dt.Columns.Add("forecolor")
        dt.Columns.Add("backcolor")
        dt.Columns.Add("tag")
        dt.Columns.Add("imglayout")
        dt.Columns.Add("fontname")
        dt.Columns.Add("fontsize")
        dt.Columns.Add("bold")
        dt.Columns.Add("gdiverticalfont")
        dt.Columns.Add("gdicharset")
        dt.Columns.Add("italic")
        dt.Columns.Add("strikeout")
        dt.Columns.Add("underline")
        'If My.Settings.backimglayout = 0 Then
        'My.Settings.backimglayout = 3
        'End If
        If My.Settings.language = 1 Then
            EnglishToolStripMenuItem.Checked = True
            MagyarToolStripMenuItem.Checked = False

            HelpToolStripMenuItem.Text = "Help"
            ViewHelpToolStripMenuItem.Text = "View help"
            LanguageToolStripMenuItem.Text = "Language"

            PrintToolStripMenuItem.Text = "Print"
            PrintToolStripMenuItem1.Text = "Print..."
            PreviewToolStripMenuItem.Text = "Preview"
            PageSetupToolStripMenuItem.Text = "Page setup..."

            LoadToolStripMenuItem.Text = "Load Document"
            SaveToolStripMenuItem1.Text = "Save Document"

            EditToolStripMenuItem.Text = "Edit"
            AddToolStripMenuItem.Text = "Add"
            EditModeToolStripMenuItem.Text = "Tools"
            EnableMoveToolStripMenuItem.Text = "Free move"
            BackColorToolStripMenuItem.Text = "Back color..."
            BackgroundImageToolStripMenuItem.Text = "Background Image"
            PropertiesToolStripMenuItem.Text = "Properties..."
            LoadImageFileToolStripMenuItem.Text = "Load image file..."
            ImageLayeoutToolStripMenuItem.Text = "Image layeout"
            RotateToolStripMenuItem.Text = "Rotate right ->"
            RotateToolStripMenuItem1.Text = "Rotate left <-"
            ClearToolStripMenuItem.Text = "Clear"
            EreaserToolStripMenuItem.Text = "Ereaser"
            VerticalMoveToolStripMenuItem.Text = "Vertical move"
            HorizontalMoveToolStripMenuItem.Text = "Horizontal move"
            StepToolStripMenuItem.Text = "Step"
            ResizeToolStripMenuItem.Text = "Resize"

            LabelToolStripMenuItem.Text = "Label"
            TextBoxToolStripMenuItem.Text = "TextBox"
            PictureBoxToolStripMenuItem.Text = "PictureBox"
            RadioButtonToolStripMenuItem.Text = "RadioButton"
            CheckBoxToolStripMenuItem.Text = "CheckBox"

            FileToolStripMenuItem.Text = "File"
            NewProfileToolStripMenuItem.Text = "New..."
            EncryptDecryptToolStripMenuItem.Text = "Encrypt/Decrypt"
            SaveAsImageToolStripMenuItem.Text = "Save as Image..."
            ExitToolStripMenuItem.Text = "Exit"
        ElseIf My.Settings.language = 2 Then
            EnglishToolStripMenuItem.Checked = False
            MagyarToolStripMenuItem.Checked = True

            HelpToolStripMenuItem.Text = "Segítség"
            ViewHelpToolStripMenuItem.Text = "Segítség megtekintése"
            LanguageToolStripMenuItem.Text = "Nyelv"

            PrintToolStripMenuItem.Text = "Nyomtatás"
            PrintToolStripMenuItem1.Text = "Nyomtatás..."
            PreviewToolStripMenuItem.Text = "Előnézet"
            PageSetupToolStripMenuItem.Text = "Lap beállítás..."

            LoadToolStripMenuItem.Text = "Megnyitás"
            SaveToolStripMenuItem1.Text = "Mentés"

            EditToolStripMenuItem.Text = "Szerkesztés"
            AddToolStripMenuItem.Text = "Hozzáad"
            EditModeToolStripMenuItem.Text = "Eszközök"
            EnableMoveToolStripMenuItem.Text = "Szabad mozgatás"
            BackColorToolStripMenuItem.Text = "Háttérszín..."
            BackgroundImageToolStripMenuItem.Text = "Háttérkép"
            PropertiesToolStripMenuItem.Text = "Tulajdonságok..."
            LoadImageFileToolStripMenuItem.Text = "Kép betöltése..."
            ImageLayeoutToolStripMenuItem.Text = "Kép elrendezése"
            RotateToolStripMenuItem.Text = "Elforgatás jobbra ->"
            RotateToolStripMenuItem1.Text = "Elforgatás balra <-"
            ClearToolStripMenuItem.Text = "Visszaállít"
            EreaserToolStripMenuItem.Text = "Radír"
            VerticalMoveToolStripMenuItem.Text = "Függőleges mozgás"
            HorizontalMoveToolStripMenuItem.Text = "Vízszintes mozgás"
            StepToolStripMenuItem.Text = "Léptetés"
            ResizeToolStripMenuItem.Text = "Újraméretezés"

            LabelToolStripMenuItem.Text = "Címke"
            TextBoxToolStripMenuItem.Text = "Szövegdoboz"
            PictureBoxToolStripMenuItem.Text = "Kép"
            RadioButtonToolStripMenuItem.Text = "Választógomb"
            CheckBoxToolStripMenuItem.Text = "Jelölőnégyzet"

            FileToolStripMenuItem.Text = "Fájl"
            NewProfileToolStripMenuItem.Text = "Új..."
            EncryptDecryptToolStripMenuItem.Text = "Titkosítás"
            SaveAsImageToolStripMenuItem.Text = "Mentés Képként..."
            ExitToolStripMenuItem.Text = "Kilépés"
        End If
        'Dialog1.Label1.Font.un
        If My.Settings.backgroundimg.Length > 0 Then
            Panel1.BackgroundImage = Image.FromFile(My.Settings.backgroundimg)
            Panel1.BackgroundImageLayout = My.Settings.backimglayout
        End If
        'dt.Columns.Add("font")
        'index of controls as integer
        'dt.Columns.Add("labelindex")
        'dt.Columns.Add("chkindex")
        'dt.Columns.Add("radioindex")
        'dt.Columns.Add("pictrindex")
        'dt.Columns.Add("txtindex")
        Panel1.BackColor = My.Settings.panelbackcolor
        SaveFileDialog1.InitialDirectory = My.Settings.quicksavefolder
        OpenFileDialog1.InitialDirectory = My.Settings.quicksavefolder
        openimage.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        Me.Size = My.Settings.formsize
        'Me.Location = My.Settings.formloc
    End Sub

    Private ds As New DataSet

    Private Sub dowrite(ByVal parentCtr As Control)
        Dim ctr As Control
        For Each ctr In parentCtr.Controls
            Dim dr As DataRow = ds.Tables(0).NewRow
            dr("Name") = ctr.Name
            dr("Text") = ctr.Text
            dr("Height") = ctr.Height
            dr("Width") = ctr.Width
            dr("locheight") = ctr.Top
            dr("locwidth") = ctr.Left
            dr("tabindex") = ctr.TabIndex
            dr("forecolor") = ctr.ForeColor.ToArgb
            dr("backcolor") = ctr.BackColor.ToArgb
            dr("tag") = ctr.Tag
            dr("imglayout") = ctr.BackgroundImageLayout
            dr("fontname") = ctr.Font.Name 'string
            dr("fontsize") = ctr.Font.Size 'single
            dr("bold") = ctr.Font.Bold 'boolean1
            dr("gdiverticalfont") = ctr.Font.GdiVerticalFont 'boolean
            dr("gdicharset") = ctr.Font.GdiCharSet 'byte
            dr("italic") = ctr.Font.Italic 'boolean2
            dr("strikeout") = ctr.Font.Strikeout 'boolean3
            dr("underline") = ctr.Font.Underline 'boolean4
            'dr("font") = ctr.Font.ToString
            'dr("chkindex") = Class1.chkindex
            'dr("radioindex") = Class1.radioindex
            'dr("pictrindex") = Class1.pictrindex
            'dr("txtindex") = Class1.txtindex
            ds.Tables(0).Rows.Add(dr)
            'ds.Tables(1).Rows.Add(dr)
            dowrite(ctr)
        Next
    End Sub

    Public Sub DoRead(ByVal parentCtr As Control, ByVal dv As DataView)
        'Dim values() As String = File.ReadAllText(screwname + "_screw" + ".bin").Split("|"c)
        'Class1.chkindex = values(0)
        'Class1.radioindex = values(1)
        'Class1.pictrindex = values(2)
        'Class1.txtindex = values(3)
        'Class1.labelindex = values(4)
        'Dim valamiamerika As String

        'valamiamerika = mastertag.Item(1)
        Dim ctr As Control
        For Each ctr In parentCtr.Controls
            Dim i As Integer = dv.Find(ctr.Name)
            ctr.Text = CStr(dv(i)("Text"))
            ctr.Height = CInt(dv(i)("Height"))
            ctr.Width = CInt(dv(i)("Width"))
            ctr.Top = CInt(dv(i)("locheight"))
            ctr.Left = CInt(dv(i)("locwidth"))
            ctr.TabIndex = CInt(dv(i)("tabindex"))
            ctr.ForeColor = Color.FromArgb(CInt(dv(i)("forecolor")))
            ctr.BackColor = Color.FromArgb(CInt(dv(i)("backcolor")))
            ctr.Tag = CStr(dv(i)("tag"))
            If CStr(dv(i)("tag")).Length > 7 Then
                ctr.BackgroundImage = Image.FromFile(CStr(dv(i)("tag")))
                ctr.Tag = CStr(dv(i)("tag"))
                ctr.BackgroundImageLayout = imglayout(CStr(dv(i)("imglayout")))
            ElseIf CStr(dv(i)("tag")).Length = 7 Then
                ctr.Tag = CStr(dv(i)("tag"))
                ctr.Focus()
            ElseIf CStr(dv(i)("tag")).Length = 1 Then
                ctr.Tag = CStr(dv(i)("tag"))
                ctr.Focus()
            ElseIf CStr(dv(i)("tag")).Length = 4 Or 5 Then
                ctr.Enabled = True
            End If
            ctr.Font = New Font(CStr(dv(i)("fontname")), CSng(dv(i)("fontsize")), fontstyler(CBool(dv(i)("bold")), CBool(dv(i)("italic")), CBool(dv(i)("underline")), CBool(dv(i)("strikeout"))), GraphicsUnit.Point, CByte(dv(i)("gdicharset")), CBool(dv(i)("gdiverticalfont")))
            'ctr.Enabled = True
            'ctr.Font = CType(converter.ConvertFromString(CStr(dv(i)("font"))), Font)
            'Class1.labelindex = CInt(dv(i)("labelindex"))
            'Class1.chkindex = CInt(dv(i)("chkindex"))
            'Class1.radioindex = CInt(dv(i)("radioindex"))
            'Class1.pictrindex = CInt(dv(i)("pictrindex"))
            'Class1.txtindex = CInt(dv(i)("txtindex"))
            DoRead(ctr, dv)
        Next
    End Sub

    Private Function imglayout(ByVal layoutstring As String) As Integer
        Dim layouti As Integer
        If layoutstring = "Tile" Then
            layouti = 1
        ElseIf layoutstring = "Center" Then
            layouti = 2
        ElseIf layoutstring = "Stretch" Then
            layouti = 3
        ElseIf layoutstring = "Zoom" Then
            layouti = 4
        End If
        Return layouti
    End Function

    Private Function fontstyler(ByVal bold As Boolean, ByVal italic As Boolean, ByVal underline As Boolean, ByVal strikeout As Boolean) As FontStyle
        Dim returnstyle As FontStyle
        If bold = False And italic = False And underline = False And strikeout = True Then '1
            returnstyle = FontStyle.Strikeout
        ElseIf bold = False And italic = False And underline = True And strikeout = False Then '2
            returnstyle = FontStyle.Underline
        ElseIf bold = False And italic = False And underline = True And strikeout = True Then '3
            returnstyle = FontStyle.Underline + FontStyle.Strikeout
        ElseIf bold = False And italic = False And underline = False And strikeout = False Then '4
            returnstyle = FontStyle.Regular
        ElseIf bold = False And italic = True And underline = False And strikeout = True Then '5
            returnstyle = FontStyle.Italic + FontStyle.Strikeout
        ElseIf bold = False And italic = True And underline = True And strikeout = False Then '6
            returnstyle = FontStyle.Italic + FontStyle.Underline
        ElseIf bold = False And italic = True And underline = True And strikeout = True Then '7
            returnstyle = FontStyle.Italic + FontStyle.Strikeout + FontStyle.Underline
        ElseIf bold = False And italic = True And underline = False And strikeout = False Then '8
            returnstyle = FontStyle.Italic
        ElseIf bold = True And italic = False And underline = False And strikeout = True Then '9
            returnstyle = FontStyle.Bold + FontStyle.Strikeout
        ElseIf bold = True And italic = False And underline = True And strikeout = False Then '10
            returnstyle = FontStyle.Bold + FontStyle.Underline
        ElseIf bold = True And italic = False And underline = True And strikeout = True Then '11
            returnstyle = FontStyle.Bold + FontStyle.Underline + FontStyle.Strikeout
        ElseIf bold = True And italic = False And underline = False And strikeout = False Then '12
            returnstyle = FontStyle.Bold
        ElseIf bold = True And italic = True And underline = False And strikeout = True Then '13
            returnstyle = FontStyle.Bold + FontStyle.Italic + FontStyle.Strikeout
        ElseIf bold = True And italic = True And underline = True And strikeout = False Then '14
            returnstyle = FontStyle.Bold + FontStyle.Italic + FontStyle.Underline
        ElseIf bold = True And italic = True And underline = True And strikeout = True Then '15
            returnstyle = FontStyle.Bold + FontStyle.Italic + FontStyle.Underline + FontStyle.Strikeout
        ElseIf bold = True And italic = True And underline = False And strikeout = False Then '16
            returnstyle = FontStyle.Bold + FontStyle.Italic
        End If
        Return returnstyle
    End Function
    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Click
        ToolStripStatusLabel1.Text = "Control name: Workspace" + " ,Image layout: " + sender.BackgroundImageLayout.ToString + " ,Size: " + sender.size.ToString
    End Sub

    Shared Sub test(ByVal sender As Object, ByVal e As EventArgs)
        'ez a radír GOMB
        'set focus to sender, that is Label.
        If sender.tag = "True" Or "False" Then
            'RemoveHandler sender.paint, AddressOf Form1.test7
        Else
            sender.focus()
        End If

        Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Location: " + sender.location.ToString + ", Font: " + sender.font.name + " " + sender.font.size.ToString + ", Style: " + sender.font.style.ToString
        Form1.ToolStripStatusLabel1.ForeColor = sender.forecolor
        If Form1.EreaserToolStripMenuItem.Checked = True Then
            'If sender.name.Contains("checkbox") = True Then
            'Num(sender.name)
            If sender.name.Contains("label") And Num(sender.name) = Class1.labelindex Then
                Class1.labelindex -= 1
                sender.dispose()
            ElseIf sender.name.Contains("label") And Num(sender.name) < Class1.labelindex Then
                MsgBox("Error! You cannot erease control with lower index than current! Try ereaser on: label" + Class1.labelindex.ToString, MsgBoxStyle.Critical, "Ereaser Error")
            End If

            If sender.name.ToString.Contains("textbox") And Num(sender.name) = Class1.txtindex Then
                Class1.txtindex -= 1
                sender.dispose()
            ElseIf sender.name.ToString.Contains("textbox") And Num(sender.name) < Class1.txtindex Then
                MsgBox("Error! You cannot erease control with lower index than current! Try ereaser on: textbox" + Class1.txtindex.ToString, MsgBoxStyle.Critical, "Ereaser Error")
            End If

            If sender.name.ToString.Contains("img") And Num(sender.name) = Class1.pictrindex Then
                Class1.pictrindex -= 1
                sender.dispose()
            ElseIf sender.name.ToString.Contains("img") And Num(sender.name) < Class1.pictrindex Then
                MsgBox("Error! You cannot erease control with lower index than current! Try ereaser on: img" + Class1.pictrindex.ToString, MsgBoxStyle.Critical, "Ereaser Error")
            End If

            If sender.name.ToString.Contains("radiobutton") And Num(sender.name) = Class1.radioindex Then
                Class1.radioindex -= 1
                sender.dispose()
            ElseIf sender.name.ToString.Contains("radiobutton") And Num(sender.name) < Class1.radioindex Then
                MsgBox("Error! You cannot erease control with lower index than current! Try ereaser on: radiobutton" + Class1.radioindex.ToString, MsgBoxStyle.Critical, "Ereaser Error")
            End If

            If sender.name.ToString.Contains("checkbox") And Num(sender.name) = Class1.chkindex Then
                Class1.chkindex -= 1
                sender.dispose()
            ElseIf sender.name.ToString.Contains("checkbox") And Num(sender.name) < Class1.chkindex Then
                MsgBox("Error! You cannot erease control with lower index than current! Try ereaser on: checkbox" + Class1.chkindex.ToString, MsgBoxStyle.Critical, "Ereaser Error")
            End If
        End If
    End Sub

    Shared Sub test2(ByVal sender As Object, ByVal e As MouseEventArgs)

        Class1.startx = MousePosition.X
        Class1.starty = MousePosition.Y
        Class1.mdown = True
        Class1.valx = False
        Class1.valy = False
        Try
            sender.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
    End Sub

    Shared Sub test3(ByVal sender As Object, ByVal e As MouseEventArgs)
        Class1.mdown = False
        Class1.valx = False
        Class1.valy = False
        Try
            sender.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
    End Sub

    Shared Sub test4(ByVal sender As Object, ByVal e As MouseEventArgs)
        If Class1.mdown = True Then
            Class1.endx = (MousePosition.X - Form1.Left)
            Class1.endy = (MousePosition.Y - Form1.Top)
        End If
        If Class1.valy = False Then
            Class1.starty = Class1.endy - sender.top
            Class1.valy = True
        End If
        If Class1.valx = False Then
            Class1.startx = Class1.endx - sender.left
            Class1.valx = True
        End If

        'If Class1.mdown = True And Dialog2.NumericUpDown1.Value > 0 Then
        'sender.top += Dialog2.NumericUpDown1.Value
        'End If
        Try
            'code...
            If Form1.EnableMoveToolStripMenuItem.Checked = True And sender.focused = True And Form1.EnableMoveToolStripMenuItem.CheckState = 1 Then
                sender.Cursor = Cursors.SizeAll
                sender.left = Class1.endx - Class1.startx
                sender.top = Class1.endy - Class1.starty
                Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + "Location: " + sender.location.ToString
            End If
            If Form1.VerticalMoveToolStripMenuItem.Checked = True And sender.focused = True And Form1.VerticalMoveToolStripMenuItem.CheckState = 1 Then
                sender.Cursor = Cursors.SizeNS
                sender.top = Class1.endy - Class1.starty
                Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + "Location: " + sender.location.ToString
            End If
            If Form1.HorizontalMoveToolStripMenuItem.Checked = True And sender.focused = True And Form1.HorizontalMoveToolStripMenuItem.CheckState = 1 Then
                sender.Cursor = Cursors.SizeWE
                sender.left = Class1.endx - Class1.startx
                Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + "Location: " + sender.location.ToString
            End If

        Catch ex As Exception
            'sender.Cursor = Cursors.Default
        End Try
    End Sub
    Shared Sub test5(ByVal sender As Object, ByVal e As KeyEventArgs)

        If e.KeyCode = Keys.Down And Form1.ResizeToolStripMenuItem.Checked = True Then
            sender.Height += My.Settings.verticalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Size: " + sender.size.ToString
        End If
        If e.KeyCode = Keys.Up And Form1.ResizeToolStripMenuItem.Checked = True Then
            sender.Height -= My.Settings.verticalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Size: " + sender.size.ToString
        End If
        If e.KeyCode = Keys.Right And Form1.ResizeToolStripMenuItem.Checked = True Then
            sender.Width += My.Settings.horizontalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Size: " + sender.size.ToString
        End If
        If e.KeyCode = Keys.Left And Form1.ResizeToolStripMenuItem.Checked = True Then
            sender.Width -= My.Settings.horizontalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Size: " + sender.size.ToString
        End If

        If e.KeyCode = Keys.Up And Form1.StepToolStripMenuItem.Checked = True Then
            sender.Top -= My.Settings.verticalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Location: " + sender.location.ToString
        ElseIf e.KeyCode = Keys.W And Form1.StepToolStripMenuItem.Checked = True And sender.Name.Contains("checkbox") = True Then
            sender.Top -= My.Settings.verticalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Location: " + sender.location.ToString
        ElseIf e.KeyCode = Keys.W And Form1.StepToolStripMenuItem.Checked = True And sender.Name.Contains("radiobutton") = True Then
            sender.Top -= My.Settings.verticalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Location: " + sender.location.ToString
        End If

        If e.KeyCode = Keys.Down And Form1.StepToolStripMenuItem.Checked = True Then
            sender.Top += My.Settings.verticalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Location: " + sender.location.ToString
        ElseIf e.KeyCode = Keys.S And Form1.StepToolStripMenuItem.Checked = True And sender.Name.Contains("checkbox") = True Then
            sender.Top += My.Settings.verticalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Location: " + sender.location.ToString
        ElseIf e.KeyCode = Keys.S And Form1.StepToolStripMenuItem.Checked = True And sender.Name.Contains("radiobutton") = True Then
            sender.Top += My.Settings.verticalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Location: " + sender.location.ToString
        End If

        If e.KeyCode = Keys.Left And Form1.StepToolStripMenuItem.Checked = True Then
            sender.Left -= My.Settings.horizontalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Location: " + sender.location.ToString
        ElseIf e.KeyCode = Keys.A And Form1.StepToolStripMenuItem.Checked = True And sender.Name.Contains("checkbox") = True Then
            sender.Left -= My.Settings.horizontalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Location: " + sender.location.ToString
        ElseIf e.KeyCode = Keys.A And Form1.StepToolStripMenuItem.Checked = True And sender.Name.Contains("radiobutton") = True Then
            sender.Left -= My.Settings.horizontalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Location: " + sender.location.ToString
        End If
        If e.KeyCode = Keys.Right And Form1.StepToolStripMenuItem.Checked = True Then
            sender.Left += My.Settings.horizontalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Location: " + sender.location.ToString
        ElseIf e.KeyCode = Keys.D And Form1.StepToolStripMenuItem.Checked = True And sender.Name.Contains("checkbox") = True Then
            sender.Left += My.Settings.horizontalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Location: " + sender.location.ToString
        ElseIf e.KeyCode = Keys.D And Form1.StepToolStripMenuItem.Checked = True And sender.Name.Contains("radiobutton") = True Then
            sender.Left += My.Settings.horizontalstep
            Form1.ToolStripStatusLabel1.Text = "Control name: " + sender.name + ", Location: " + sender.location.ToString
        End If

    End Sub
    Shared Sub test6(ByVal sender As Object, ByVal e As EventArgs)
        If sender.Checked = True And sender.Tag.Length = 1 Then
            sender.Tag = "1"
        ElseIf sender.Checked = False And sender.Tag.Length = 1 Then
            sender.Tag = "0"
        ElseIf sender.checked = True And sender.Tag = "False" Then
            sender.Tag = "True"
        ElseIf sender.checked = False And sender.Tag = "True" Then
            sender.Tag = "False"
        End If
    End Sub

    Shared Sub test7(ByVal sender As Object, ByVal e As PaintEventArgs)
        Dim radibutton As RadioButton = CType(sender, RadioButton)
        If sender.tag = "True" Then
            sender.checked = True
            RemoveHandler radibutton.Paint, AddressOf test7
        ElseIf sender.tag = "False" Then
            sender.checked = False
            RemoveHandler radibutton.Paint, AddressOf test7
        End If
    End Sub

    Public Event AnEvent()
    Sub CauseTheEvent()
        ' Raise an event. 
        RaiseEvent AnEvent()
    End Sub

    Shared Sub test8(ByVal sender As Object, ByVal e As EventArgs)
        If CStr(sender.tag).Length = 1 Then
            sender.checked = CBool(sender.tag)
        End If
        If CStr(sender.tag).Length = 7 Then
            Dim values() As String = CStr(sender.tag).Split("|"c)
            sender.TextAlign = Num(values(0))
            sender.BorderStyle = Num(values(1))
            sender.ScrollBars = Num(values(2))
            sender.Multiline = Num(values(3))
        End If
    End Sub

    Private Sub NewProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewProfileToolStripMenuItem.Click
        If Me.Text = "Baser v1.0" And Panel1.Controls.Count > 0 Then
            If MsgBox("Would you like to save?", MsgBoxStyle.YesNo, "Baser") = MsgBoxResult.Yes Then
                SaveToolStripMenuItem1.PerformClick()
            End If
        End If
        Panel1.Controls.Clear()
        Class1.chkindex = 0
        Class1.radioindex = 0
        Class1.pictrindex = 0
        Class1.txtindex = 0
        Class1.labelindex = 0
        ds.Tables(0).Rows.Clear()
        ds.Clear()
        Me.Text = "Baser v1.0"
        'Panel1.BackColor = Me.BackColor
        'Panel1.BackgroundImage = Nothing
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        Dialog2.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'Dim startPosition As Integer = (page - 1) * PrintDocument1.DefaultPageSettings.Bounds.Height + 5
        'TODO - Change Panel1 to the name of your panel
        Dim b As New Bitmap(Panel1.Width, Panel1.Height)
        Panel1.DrawToBitmap(b, Panel1.ClientRectangle)
        e.Graphics.DrawImage(b, New Point(0, 0))

    End Sub

    Private Sub PreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewToolStripMenuItem.Click
        'PrintDocument1.DefaultPageSettings.PaperSize = New PaperSize("Custom", 850, 1100)
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem1.Click
        'GridPanelDetails.VerticalScroll.Value = 0
        'PrintDocument1.DefaultPageSettings.PaperSize = New PaperSize("Custom", 850, 1100)
        'PrintDocument1.Print()
        PrintDialog1.ShowDialog()
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageSetupToolStripMenuItem.Click
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        Panel1.BackgroundImage = Nothing
        'Panel1.Tag = Nothing
        My.Settings.backgroundimg = Nothing
        My.Settings.backimglayout = "3"
    End Sub

    Private Sub LoadProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub Panel1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.MouseHover
        Try
            If EreaserToolStripMenuItem.Checked = True And EreaserToolStripMenuItem.CheckState = 1 Then
                Panel1.Cursor = Cursors.No
            Else
                Panel1.Cursor = Cursors.Default
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub VerticalStepToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EnableMoveToolStripMenuItem.Checked = False
        VerticalMoveToolStripMenuItem.Checked = False
        HorizontalMoveToolStripMenuItem.Checked = False
        EreaserToolStripMenuItem.Checked = False
        ResizeToolStripMenuItem.Checked = False
        StepToolStripMenuItem.Checked = False
    End Sub

    Private Sub HorizontalStepToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EnableMoveToolStripMenuItem.Checked = False
        VerticalMoveToolStripMenuItem.Checked = False
        HorizontalMoveToolStripMenuItem.Checked = False
        EreaserToolStripMenuItem.Checked = False
        ResizeToolStripMenuItem.Checked = False
        StepToolStripMenuItem.Checked = False
    End Sub

    Private Sub ResizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResizeToolStripMenuItem.Click
        EnableMoveToolStripMenuItem.Checked = False
        VerticalMoveToolStripMenuItem.Checked = False
        HorizontalMoveToolStripMenuItem.Checked = False
        EreaserToolStripMenuItem.Checked = False
        StepToolStripMenuItem.Checked = False
    End Sub

    Private Sub EreaserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EreaserToolStripMenuItem.Click
        EnableMoveToolStripMenuItem.Checked = False
        VerticalMoveToolStripMenuItem.Checked = False
        HorizontalMoveToolStripMenuItem.Checked = False
        ResizeToolStripMenuItem.Checked = False
        StepToolStripMenuItem.Checked = False
    End Sub

    Private Sub EnableMoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableMoveToolStripMenuItem.Click
        EreaserToolStripMenuItem.Checked = False
        VerticalMoveToolStripMenuItem.Checked = False
        HorizontalMoveToolStripMenuItem.Checked = False
        ResizeToolStripMenuItem.Checked = False
        StepToolStripMenuItem.Checked = False
    End Sub

    Private Sub VerticalMoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalMoveToolStripMenuItem.Click
        EnableMoveToolStripMenuItem.Checked = False
        HorizontalMoveToolStripMenuItem.Checked = False
        EreaserToolStripMenuItem.Checked = False
        ResizeToolStripMenuItem.Checked = False
        StepToolStripMenuItem.Checked = False
    End Sub

    Private Sub HorizontalMoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalMoveToolStripMenuItem.Click
        EnableMoveToolStripMenuItem.Checked = False
        VerticalMoveToolStripMenuItem.Checked = False
        EreaserToolStripMenuItem.Checked = False
        ResizeToolStripMenuItem.Checked = False
        StepToolStripMenuItem.Checked = False
    End Sub

    Private Sub StepToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StepToolStripMenuItem.Click
        EreaserToolStripMenuItem.Checked = False
        VerticalMoveToolStripMenuItem.Checked = False
        HorizontalMoveToolStripMenuItem.Checked = False
        ResizeToolStripMenuItem.Checked = False
        EnableMoveToolStripMenuItem.Checked = False
    End Sub

    Private Sub Form1_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        My.Settings.formsize = Me.Size
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ToolStripStatusLabel1.Text = Me.Size.ToString
    End Sub
    Public filename As String
    Dim screwname As String
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Dim mytemp() As String = My.Settings.checkboxs.Split("|"c)
        'Dim chkbox As New CheckBox
        'chkbox.Name = mytemp(0)
        'chkbox.Location = New System.Drawing.Point(Num(mytemp(1)), Num(mytemp(2)))
        'chkbox.Text = mytemp(3)
        'Me.Controls.Add(chkbox)
        Panel1.Refresh()
        ToolStripProgressBar1.Visible = True
        ToolStripProgressBar1.Value += 10
        If ToolStripProgressBar1.Value = 100 Then
            ToolStripProgressBar1.Visible = False
            ToolStripProgressBar1.Value -= 100
            Timer1.Stop()
        End If

        If Class1.chkindex > 0 And ToolStripProgressBar1.Value = 20 Then 'PRÓBA
            'ds.Tables(0).Columns.Item(4)
            'MŰKÖDIK GECIIII
            For i As Integer = 1 To Class1.chkindex
                'ds.ReadXml(filename)
                'ds.Tables(0).DefaultView.Sort = "Name"
                'DoRead(Panel1, ds.Tables(0).DefaultView)
                Dim chkbox As New CheckBox
                chkbox.Name = "checkbox" + i.ToString
                chkbox.AutoSize = True
                chkbox.Location = New System.Drawing.Point(1, 1)
                chkbox.Text = ""
                'chkbox.Checked = CBool(chkbox.Tag)
                'chkbox.Font = fontbtn.Font
                'chkbox.ForeColor = Panel1.BackColor
                'chkbox.BackColor = Panel2.BackColor
                'chkbox.TabIndex = NumericUpDown1.Value
                AddHandler chkbox.Click, AddressOf Form1.test
                AddHandler chkbox.MouseDown, AddressOf Form1.test2
                AddHandler chkbox.MouseUp, AddressOf Form1.test3
                AddHandler chkbox.MouseMove, AddressOf Form1.test4
                AddHandler chkbox.KeyDown, AddressOf Form1.test5
                AddHandler chkbox.CheckedChanged, AddressOf Form1.test6
                AddHandler chkbox.GotFocus, AddressOf Form1.test8
                Panel1.Controls.Add(chkbox)
                'chkbox.Refresh()
            Next
            ds.ReadXml(filename)
            ds.Tables(0).DefaultView.Sort = "Name"
            DoRead(Panel1, ds.Tables(0).DefaultView)
            'Panel1.Refresh()
        End If

        If Class1.radioindex > 0 And ToolStripProgressBar1.Value = 40 Then 'PRÓBA
                For i2 As Integer = 1 To Class1.radioindex
                    'ds.ReadXml(filename)
                    'ds.Tables(0).DefaultView.Sort = "Name"
                    'DoRead(Panel1, ds.Tables(0).DefaultView)
                    Dim radiobtn As New RadioButton
                    radiobtn.Name = "radiobutton" + i2.ToString
                    radiobtn.AutoSize = True
                    radiobtn.Location = New System.Drawing.Point(1, 1)
                    radiobtn.Text = ""
                    'radiobtn.Checked = CBool(radiobtn.Tag)
                    'radiobtn.Font = fontbtn.Font
                    'radiobtn.ForeColor = Panel1.BackColor
                    'radiobtn.BackColor = Panel2.BackColor
                    'radiobtn.TabIndex = NumericUpDown1.Value
                    AddHandler radiobtn.Click, AddressOf Form1.test
                    AddHandler radiobtn.MouseDown, AddressOf Form1.test2
                    AddHandler radiobtn.MouseUp, AddressOf Form1.test3
                    AddHandler radiobtn.MouseMove, AddressOf Form1.test4
                    AddHandler radiobtn.KeyDown, AddressOf Form1.test5
                    AddHandler radiobtn.CheckedChanged, AddressOf Form1.test6
                    'AddHandler radiobtn.GotFocus, AddressOf Form1.test8
                    AddHandler radiobtn.Paint, AddressOf Form1.test7
                    Panel1.Controls.Add(radiobtn)
                Next
                ds.ReadXml(filename)
                ds.Tables(0).DefaultView.Sort = "Name"
                DoRead(Panel1, ds.Tables(0).DefaultView)
        End If

        If Class1.pictrindex > 0 And ToolStripProgressBar1.Value = 60 Then
            For i3 As Integer = 1 To Class1.pictrindex
                'ds.ReadXml(filename)
                'ds.Tables(0).DefaultView.Sort = "Name"
                'DoRead(Panel1, ds.Tables(0).DefaultView)
                Dim img As New Panel
                img.Name = "img" + i3.ToString
                'img.BackgroundImage = PictureBox1.BackgroundImage
                img.Location = New System.Drawing.Point(1, 1)
                img.Size = New System.Drawing.Size(32, 32)
                '     If ComboBox2.Text = "" Then
                '        img.BackgroundImageLayout = ImageLayout.Stretch
                '   ElseIf ComboBox2.Text = "Tile" Then
                '      img.BackgroundImageLayout = ImageLayout.Tile
                'ElseIf ComboBox2.Text = "Stretch" Then
                img.BackgroundImageLayout = ImageLayout.Stretch
                ' ElseIf ComboBox2.Text = "Zoom" Then
                '  img.BackgroundImageLayout = ImageLayout.Zoom
                'ElseIf ComboBox2.Text = "Center" Then
                'img.BackgroundImageLayout = ImageLayout.Center
                'End If
                AddHandler img.Click, AddressOf Form1.test
                AddHandler img.MouseDown, AddressOf Form1.test2
                AddHandler img.MouseUp, AddressOf Form1.test3
                AddHandler img.MouseMove, AddressOf Form1.test4
                AddHandler img.KeyDown, AddressOf Form1.test5
                Panel1.Controls.Add(img)
            Next
            ds.ReadXml(filename)
            ds.Tables(0).DefaultView.Sort = "Name"
            DoRead(Panel1, ds.Tables(0).DefaultView)
            'Panel1.Refresh()
        End If
        If Class1.txtindex > 0 And ToolStripProgressBar1.Value = 80 Then
            For i4 As Integer = 1 To Class1.txtindex
                'ds.ReadXml(filename)
                'ds.Tables(0).DefaultView.Sort = "Name"
                'DoRead(Panel1, ds.Tables(0).DefaultView)
                Dim txt As New TextBox
                txt.Name = "textbox" + i4.ToString
                'txt.Name = Class1.txtmultistring.Split("|"c)
                txt.Text = ""
                'txt.Font = fontbtn.Font
                'txt.ForeColor = Panel1.BackColor
                'txt.BackColor = Panel2.BackColor
                'txt.Location = New System.Drawing.Point(1, 1)
                'txt.Size = New System.Drawing.Size(32, 32)
                'txt.TabIndex = NumericUpDown1.Value
                '  If ComboBox1.Text = "" Then
                '     txt.TextAlign = HorizontalAlignment.Left
                '  ElseIf ComboBox1.Text = "Left" Then
                '     txt.TextAlign = HorizontalAlignment.Left
                ' ElseIf ComboBox1.Text = "Center" Then
                '    txt.TextAlign = HorizontalAlignment.Center
                '  ElseIf ComboBox1.Text = "Right" Then
                '    txt.TextAlign = HorizontalAlignment.Right
                ' End If
                'If multilinecheck.Checked = False Then
                'txt.Multiline = False
                'txt.AutoSize = True
                '        Else
                '          txt.Multiline = True
                'txt.Size = New System.Drawing.Size(sizeheight.Value, sizewith.Value)
                ' txt.AutoSize = False
                '  End If
                ' If scrollbarcheck.Checked = True Then
                'txt.ScrollBars = ScrollBars.Both
                '   Else
                '   txt.ScrollBars = ScrollBars.None
                '   End If
                'txt.Focus()
                AddHandler txt.Click, AddressOf Form1.test
                AddHandler txt.MouseDown, AddressOf Form1.test2
                AddHandler txt.MouseUp, AddressOf Form1.test3
                AddHandler txt.MouseMove, AddressOf Form1.test4
                AddHandler txt.KeyDown, AddressOf Form1.test5
                AddHandler txt.GotFocus, AddressOf Form1.test8
                Panel1.Controls.Add(txt)
            Next
            ds.ReadXml(filename)
            ds.Tables(0).DefaultView.Sort = "Name"
            DoRead(Panel1, ds.Tables(0).DefaultView)
            'Panel1.Refresh()
        End If
        If Class1.labelindex > 0 And ToolStripProgressBar1.Value = 90 Then
            For i5 As Integer = 1 To Class1.labelindex
                'ds.ReadXml(filename)
                'ds.Tables(0).DefaultView.Sort = "Name"
                'DoRead(Panel1, ds.Tables(0).DefaultView)
                Dim lbl As New Label
                lbl.Name = "label" + i5.ToString
                lbl.AutoSize = True
                'lbl.Size = New System.Drawing.Size(sizeheight.Value, sizewith.Value)
                lbl.Location = New System.Drawing.Point(1, 1) 'set your location
                lbl.Text = ""
                'lbl.Font = fontbtn.Font
                'lbl.ForeColor = Panel1.BackColor
                'lbl.BackColor = Panel2.BackColor
                AddHandler lbl.Click, AddressOf Form1.test
                AddHandler lbl.MouseDown, AddressOf Form1.test2
                AddHandler lbl.MouseUp, AddressOf Form1.test3
                AddHandler lbl.MouseMove, AddressOf Form1.test4
                AddHandler lbl.KeyDown, AddressOf Form1.test5
                'set your name
                Panel1.Controls.Add(lbl)
                'add your new control to your forms control collection
            Next
            ds.ReadXml(filename)
            ds.Tables(0).DefaultView.Sort = "Name"
            DoRead(Panel1, ds.Tables(0).DefaultView)
            'Panel1.Refresh()
        End If

        'If MsgBox("You can't open Form while there are still controls on the workspace. Would you like to clear up these controls?", MsgBoxStyle.OkCancel, "Panel is still busy") = MsgBoxResult.Ok Then
        'Panel1.Controls.Clear()
        'Class1.chkindex = 0
        'Class1.radioindex = 0
        'Class1.pictrindex = 0
        'Class1.txtindex = 0
        'Class1.labelindex = 0
        'End If

    End Sub

    Private Sub EncryptDecryptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EncryptDecryptToolStripMenuItem.Click
        Dialog3.ShowDialog()
    End Sub

    Private Sub CredentialsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CredentialsToolStripMenuItem.Click
        Dialog5.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Public dbconn As New MySqlConnection
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    'Public dbda As MySqlDataAdapter
    Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem.Click
        If Dialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim xmldata As String
            'Mysql export gomb
            Dim connectstring As String = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=true", My.Settings.serverMYSQL, My.Settings.usernameMYSQL, My.Settings.passwordMYSQL, My.Settings.databaseMYSQL)
            If Dialog2.CheckBox3.Checked = False Then
                If My.Settings.serverMYSQL.Length > 0 And My.Settings.usernameMYSQL.Length > 0 And My.Settings.databaseMYSQL.Length > 0 Then
                    Try
                        dowrite(Panel1)
                        ds.WriteXml(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml")
                        xmldata = File.ReadAllText(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml")
                        'If Not dbconn Is Nothing Then dbconn.Close()
                        dbconn.ConnectionString = connectstring
                        dbconn.Open()
                        dbcomm = New MySqlCommand("INSERT INTO `" + My.Settings.worktableMYSQL + "` (xmlname,data,screwname,screw) VALUES (@xmlname,@data,@screwname,@screw)", dbconn)
                        dbcomm.Parameters.AddWithValue("@xmlname", Dialog2.TextBox2.Text)
                        dbcomm.Parameters.AddWithValue("@data", xmldata)
                        dbcomm.Parameters.AddWithValue("@screwname", Dialog2.TextBox2.Text + "_screw")
                        dbcomm.Parameters.AddWithValue("@screw", String.Join("|", New String() {Class1.chkindex, Class1.radioindex, Class1.pictrindex, Class1.txtindex, Class1.labelindex}))
                        dbread = dbcomm.ExecuteReader()
                        dbread.Close()
                        dbconn.Close()
                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")
                    Finally
                        ds.Clear()
                        xmldata = Nothing
                        File.Delete(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml")
                        MsgBox("Form name: " + Dialog2.TextBox2.Text + " exported to: " + My.Settings.databaseMYSQL + "." + My.Settings.worktableMYSQL, MsgBoxStyle.Information, "Success!")
                    End Try
                Else
                    MsgBox("Export failed! Specify data in Credentials menu.", MsgBoxStyle.Critical, "Error")
                End If
            Else
                If My.Settings.serverMYSQL.Length > 0 And My.Settings.usernameMYSQL.Length > 0 And My.Settings.databaseMYSQL.Length > 0 Then
                    Try
                        dowrite(Panel1)
                        ds.WriteXml(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml")
                        xmldata = File.ReadAllText(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml")
                        'If Not dbconn Is Nothing Then dbconn.Close()
                        dbconn.ConnectionString = connectstring
                        dbconn.Open()
                        dbcomm = New MySqlCommand("INSERT INTO `" + My.Settings.worktableMYSQL + "` (xmlname,data,screwname,screw) VALUES (@xmlname,@data,@screwname,@screw)", dbconn)
                        dbcomm.Parameters.AddWithValue("@xmlname", Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString)
                        dbcomm.Parameters.AddWithValue("@data", xmldata)
                        dbcomm.Parameters.AddWithValue("@screwname", Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + "_screw")
                        dbcomm.Parameters.AddWithValue("@screw", String.Join("|", New String() {Class1.chkindex, Class1.radioindex, Class1.pictrindex, Class1.txtindex, Class1.labelindex}))
                        dbread = dbcomm.ExecuteReader()
                        dbread.Close()
                        dbconn.Close()
                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")
                    Finally
                        ds.Clear()
                        xmldata = Nothing
                        File.Delete(My.Settings.quicksavefolder + "\" + Dialog2.TextBox2.Text + ".xml")
                        My.Settings.savedocindex += 1
                        MsgBox("Form name: " + Dialog2.TextBox2.Text + My.Settings.savedocindex.ToString + " exported to: " + My.Settings.databaseMYSQL + "." + My.Settings.worktableMYSQL, MsgBoxStyle.Information, "Success!")
                    End Try
                Else
                    MsgBox("Export failed! Specify data in Credentials menu.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        End If
    End Sub

    Private Sub ImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripMenuItem.Click
        'Mysql import gomb
        Dialog6.ShowDialog()

    End Sub

    Private Sub ViewHelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewHelpToolStripMenuItem.Click
        Dialog4.ShowDialog()
    End Sub

    Private Sub EnglishToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishToolStripMenuItem.Click
        EnglishToolStripMenuItem.Checked = True
        MagyarToolStripMenuItem.Checked = False
        My.Settings.language = 1

        HelpToolStripMenuItem.Text = "Help"
        ViewHelpToolStripMenuItem.Text = "View help"
        LanguageToolStripMenuItem.Text = "Language"

        PrintToolStripMenuItem.Text = "Print"
        PrintToolStripMenuItem1.Text = "Print..."
        PreviewToolStripMenuItem.Text = "Preview"
        PageSetupToolStripMenuItem.Text = "Page setup..."

        LoadToolStripMenuItem.Text = "Load Document"
        SaveToolStripMenuItem1.Text = "Save Document"

        EditToolStripMenuItem.Text = "Edit"
        AddToolStripMenuItem.Text = "Add"
        EditModeToolStripMenuItem.Text = "Tools"
        EnableMoveToolStripMenuItem.Text = "Free move"
        BackColorToolStripMenuItem.Text = "Back color..."
        BackgroundImageToolStripMenuItem.Text = "Background Image"
        PropertiesToolStripMenuItem.Text = "Properties..."
        LoadImageFileToolStripMenuItem.Text = "Load image file..."
        ImageLayeoutToolStripMenuItem.Text = "Image layeout"
        RotateToolStripMenuItem.Text = "Rotate right ->"
        RotateToolStripMenuItem1.Text = "Rotate left <-"
        ClearToolStripMenuItem.Text = "Clear"
        EreaserToolStripMenuItem.Text = "Ereaser"
        VerticalMoveToolStripMenuItem.Text = "Vertical move"
        HorizontalMoveToolStripMenuItem.Text = "Horizontal move"
        StepToolStripMenuItem.Text = "Step"
        ResizeToolStripMenuItem.Text = "Resize"

        LabelToolStripMenuItem.Text = "Label"
        TextBoxToolStripMenuItem.Text = "TextBox"
        PictureBoxToolStripMenuItem.Text = "PictureBox"
        RadioButtonToolStripMenuItem.Text = "RadioButton"
        CheckBoxToolStripMenuItem.Text = "CheckBox"

        FileToolStripMenuItem.Text = "File"
        NewProfileToolStripMenuItem.Text = "New..."
        EncryptDecryptToolStripMenuItem.Text = "Encrypt/Decrypt"
        SaveAsImageToolStripMenuItem.Text = "Save as Image..."
        ExitToolStripMenuItem.Text = "Exit"
    End Sub

    Private Sub MagyarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MagyarToolStripMenuItem.Click
        MagyarToolStripMenuItem.Checked = True
        EnglishToolStripMenuItem.Checked = False
        My.Settings.language = 2

        HelpToolStripMenuItem.Text = "Segítség"
        ViewHelpToolStripMenuItem.Text = "Segítség megtekintése"
        LanguageToolStripMenuItem.Text = "Nyelv"

        PrintToolStripMenuItem.Text = "Nyomtatás"
        PrintToolStripMenuItem1.Text = "Nyomtatás..."
        PreviewToolStripMenuItem.Text = "Előnézet"
        PageSetupToolStripMenuItem.Text = "Lap beállítás..."

        LoadToolStripMenuItem.Text = "Megnyitás"
        SaveToolStripMenuItem1.Text = "Mentés"

        EditToolStripMenuItem.Text = "Szerkesztés"
        AddToolStripMenuItem.Text = "Hozzáad"
        EditModeToolStripMenuItem.Text = "Eszközök"
        EnableMoveToolStripMenuItem.Text = "Szabad mozgatás"
        BackColorToolStripMenuItem.Text = "Háttérszín..."
        BackgroundImageToolStripMenuItem.Text = "Háttérkép"
        PropertiesToolStripMenuItem.Text = "Tulajdonságok..."
        LoadImageFileToolStripMenuItem.Text = "Kép betöltése..."
        ImageLayeoutToolStripMenuItem.Text = "Kép elrendezése"
        RotateToolStripMenuItem.Text = "Elforgatás jobbra ->"
        RotateToolStripMenuItem1.Text = "Elforgatás balra <-"
        ClearToolStripMenuItem.Text = "Visszaállít"
        EreaserToolStripMenuItem.Text = "Radír"
        VerticalMoveToolStripMenuItem.Text = "Függőleges mozgás"
        HorizontalMoveToolStripMenuItem.Text = "Vízszintes mozgás"
        StepToolStripMenuItem.Text = "Léptetés"
        ResizeToolStripMenuItem.Text = "Újraméretezés"

        LabelToolStripMenuItem.Text = "Címke"
        TextBoxToolStripMenuItem.Text = "Szövegdoboz"
        PictureBoxToolStripMenuItem.Text = "Kép"
        RadioButtonToolStripMenuItem.Text = "Választógomb"
        CheckBoxToolStripMenuItem.Text = "Jelölőnégyzet"

        FileToolStripMenuItem.Text = "Fájl"
        NewProfileToolStripMenuItem.Text = "Új..."
        EncryptDecryptToolStripMenuItem.Text = "Titkosítás"
        SaveAsImageToolStripMenuItem.Text = "Mentés Képként..."
        ExitToolStripMenuItem.Text = "Kilépés"
    End Sub

    Private Sub SaveAsImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsImageToolStripMenuItem.Click
        If saveimg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim b As New Bitmap(Panel1.Width, Panel1.Height)
            Panel1.DrawToBitmap(b, Panel1.ClientRectangle)
            If saveimg.FilterIndex = 1 Then
                b.Save(saveimg.FileName, System.Drawing.Imaging.ImageFormat.Png)
            ElseIf saveimg.FilterIndex = 2 Then
                b.Save(saveimg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
            ElseIf saveimg.FilterIndex = 3 Then
                b.Save(saveimg.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
            End If
        End If
    End Sub

    Dim imgflip As Integer
    Private Sub RotateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotateToolStripMenuItem.Click
        'előre forgatás
        If Panel1.BackgroundImage IsNot Nothing Then
            If imgflip = 3 Then
                imgflip = 0
            Else
                imgflip += 1
            End If

            Dim img As Image = Image.FromFile(My.Settings.backgroundimg)

            If imgflip = 0 Then
                Try
                    img.RotateFlip(RotateFlipType.RotateNoneFlipNone)
                Finally
                    Panel1.BackgroundImage = img
                End Try
            ElseIf imgflip = 1 Then
                Try
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone)
                Finally
                    Panel1.BackgroundImage = img
                End Try
            ElseIf imgflip = 2 Then
                Try
                    img.RotateFlip(RotateFlipType.Rotate180FlipNone)
                Finally
                    Panel1.BackgroundImage = img
                End Try
            ElseIf imgflip = 3 Then
                Try
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone)
                Finally
                    Panel1.BackgroundImage = img
                End Try
            End If
        End If
    End Sub

    Private Sub RotateToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotateToolStripMenuItem1.Click
        'hátra forgatás
        If Panel1.BackgroundImage IsNot Nothing Then
            If imgflip = 0 Then
                imgflip = 3
            Else
                imgflip -= 1
            End If

            Dim img As Image = Image.FromFile(My.Settings.backgroundimg)

            If imgflip = 0 Then
                Try
                    img.RotateFlip(RotateFlipType.RotateNoneFlipNone)
                Finally
                    Panel1.BackgroundImage = img
                End Try
            ElseIf imgflip = 1 Then

                Try
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone)
                Finally
                    Panel1.BackgroundImage = img
                End Try
            ElseIf imgflip = 2 Then
                Try
                    img.RotateFlip(RotateFlipType.Rotate180FlipNone)
                Finally
                    Panel1.BackgroundImage = img
                End Try
            ElseIf imgflip = 3 Then
                Try
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone)
                Finally
                    Panel1.BackgroundImage = img
                End Try
            End If
        End If

    End Sub
End Class
