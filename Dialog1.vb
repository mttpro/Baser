Imports System.Windows.Forms
Imports System.Text.RegularExpressions

Public Class Dialog1
    Private Function txalign(ByVal txtalign As String) As String
        Dim output As Integer
        If txtalign = "Left" Or txtalign = "Bal" Then
            output = 0
        ElseIf txtalign = "Right" Or txtalign = "Jobb" Then
            output = 1
        ElseIf txtalign = "Center" Or txtalign = "Közép" Then
            output = 2
        End If
        Return output
    End Function
    Private Function txborderstyle(ByVal txbrdstyle As String) As String
        Dim output As Integer
        If txbrdstyle = "None" Then
            output = 0
        ElseIf txbrdstyle = "FixedSingle" Then
            output = 1
        ElseIf txbrdstyle = "Fixed3D" Then
            output = 2
        End If
        Return output
    End Function
    Private Function txscrolls(ByVal scrlls As Boolean) As String
        Dim output As Integer
        If scrlls = True Then
            output = 3
        ElseIf scrlls = False Then
            output = 0
        End If
        Return output
    End Function
    Private Function txmultiline(ByVal txmulti As Boolean) As String
        Dim output As Integer
        If txmulti = True Then
            output = 1
        ElseIf txmulti = False Then
            output = 0
        End If
        Return output
    End Function

    Private Sub Main_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

    End Sub
    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'fontbtn.Font = Button2.Font
        'locwith.Value = 30
        'locheight.Value = 30
        ComboBox1.Items.Clear()
        If Form1.EnglishToolStripMenuItem.Checked = True Then
            ComboBox1.Items.Add("Left")
            ComboBox1.Items.Add("Center")
            ComboBox1.Items.Add("Right")
        ElseIf Form1.MagyarToolStripMenuItem.Checked = True Then
            ComboBox1.Items.Add("Bal")
            ComboBox1.Items.Add("Közép")
            ComboBox1.Items.Add("Jobb")
        End If
        sizewith.Value = 30
        sizeheight.Value = 30
        CheckBox4.Checked = False
        multilinecheck.Checked = False
        scrollbarcheck.Checked = False
        TextBox2.Multiline = False
        TextBox2.ScrollBars = ScrollBars.None
        TextBox2.TextAlign = HorizontalAlignment.Left
        TextBox2.Font = Label1.Font
        PictureBox1.BackgroundImage = Nothing
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        'Panel1.BackColor = Color.Black
        Panel2.BackColor = Form1.Panel1.BackColor
        TextBox2.ForeColor = Panel1.BackColor
        TextBox2.BackColor = Panel2.BackColor
        NumericUpDown1.Value = Class1.chkindex + Class1.radioindex + Class1.pictrindex + Class1.labelindex + Class1.txtindex
        'index = 0
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        'index = 0
        NumericUpDown1.Value = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'add button
        TextBox1.Focus()
        TextBox1.SelectAll()
        If CheckBox3.Checked = True Then
            NumericUpDown1.Value += 1
        End If
        If CheckBox1.Checked = True Then
            locwith.Value += autowith.Value
        End If
        If CheckBox2.Checked = True Then
            locheight.Value += autoheight.Value
        End If
        If Me.Text = "Add new checkbox" Or Me.Text = "Jelölőnégyzet hozzáadása" Then
            Class1.chkindex += 1
            Dim chkbox As New CheckBox
            chkbox.Name = "checkbox" + Class1.chkindex.ToString
            chkbox.AutoSize = True
            chkbox.Location = New System.Drawing.Point(locheight.Value, locwith.Value)
            chkbox.Text = TextBox1.Text
            chkbox.Font = fontbtn.Font
            chkbox.ForeColor = Panel1.BackColor
            chkbox.BackColor = Panel2.BackColor
            chkbox.TabIndex = NumericUpDown1.Value
            chkbox.Tag = "0"
            'chkbox.Enabled = True
            'chkbox.DataBindings.Add(New Binding("Value", ds, "customers.CustToOrders.OrderDate"))
            AddHandler chkbox.Click, AddressOf Form1.test
            AddHandler chkbox.MouseDown, AddressOf Form1.test2
            AddHandler chkbox.MouseUp, AddressOf Form1.test3
            AddHandler chkbox.MouseMove, AddressOf Form1.test4
            AddHandler chkbox.KeyDown, AddressOf Form1.test5
            AddHandler chkbox.CheckedChanged, AddressOf Form1.test6
            AddHandler chkbox.GotFocus, AddressOf Form1.test8
            Form1.Panel1.Controls.Add(chkbox)
            'chkbox.Refresh()
            'My.Settings.checkboxs = String.Join("|", New String() {chkbox.Name, chkbox.Location.X.ToString, chkbox.Location.Y.ToString, chkbox.Text, chkbox.Font.Name, chkbox.Font.Size.ToString, chkbox.Font.Style.ToString, chkbox.ForeColor.ToArgb.ToString, chkbox.BackColor.ToArgb.ToString})
            'My.Settings.Save()
        End If

        If Me.Text = "Add new radiobutton" Or Me.Text = "Választógomb hozzáadása" Then
            Class1.radioindex += 1
            Dim radiobtn As New RadioButton
            radiobtn.Name = "radiobutton" + Class1.radioindex.ToString
            radiobtn.AutoSize = True
            radiobtn.Location = New System.Drawing.Point(locheight.Value, locwith.Value)
            radiobtn.Text = TextBox1.Text
            radiobtn.Font = fontbtn.Font
            radiobtn.ForeColor = Panel1.BackColor
            radiobtn.BackColor = Panel2.BackColor
            radiobtn.TabIndex = NumericUpDown1.Value
            radiobtn.Tag = "False"
            AddHandler radiobtn.Click, AddressOf Form1.test
            AddHandler radiobtn.MouseDown, AddressOf Form1.test2
            AddHandler radiobtn.MouseUp, AddressOf Form1.test3
            AddHandler radiobtn.MouseMove, AddressOf Form1.test4
            AddHandler radiobtn.KeyDown, AddressOf Form1.test5
            AddHandler radiobtn.CheckedChanged, AddressOf Form1.test6
            'AddHandler radiobtn.GotFocus, AddressOf Form1.test8
            'AddHandler radiobtn.ParentChanged, AddressOf Form1.test7
            Form1.Panel1.Controls.Add(radiobtn)
        End If

        If Me.Text = "Add new picturebox" Or Me.Text = "Kép hozzáadása" Then
            Class1.pictrindex += 1
            Dim img As New Panel
            img.Name = "img" + Class1.pictrindex.ToString
            img.BackgroundImage = PictureBox1.BackgroundImage
            img.BackColor = Panel2.BackColor
            img.Location = New System.Drawing.Point(locheight.Value, locwith.Value)
            img.Tag = PictureBox1.Tag
            If sizeheight.Value = 0 And sizewith.Value = 0 Then
                img.AutoSize = True
            Else
                img.Size = New System.Drawing.Size(sizeheight.Value, sizewith.Value)
                img.AutoSize = False
            End If
            If ComboBox2.Text = "" Then
                img.BackgroundImageLayout = ImageLayout.Stretch
            ElseIf ComboBox2.Text = "Tile" Then
                img.BackgroundImageLayout = ImageLayout.Tile
            ElseIf ComboBox2.Text = "Stretch" Then
                img.BackgroundImageLayout = ImageLayout.Stretch
            ElseIf ComboBox2.Text = "Zoom" Then
                img.BackgroundImageLayout = ImageLayout.Zoom
            ElseIf ComboBox2.Text = "Center" Then
                img.BackgroundImageLayout = ImageLayout.Center
            End If
            AddHandler img.Click, AddressOf Form1.test
            AddHandler img.MouseDown, AddressOf Form1.test2
            AddHandler img.MouseUp, AddressOf Form1.test3
            AddHandler img.MouseMove, AddressOf Form1.test4
            AddHandler img.KeyDown, AddressOf Form1.test5
            Form1.Panel1.Controls.Add(img)
        End If

        If Me.Text = "Add new textbox" Or Me.Text = "Szövegdoboz hozzáadása" Then
            Class1.txtindex += 1
            'Class1.txtmultistring += "|" + "textbox" + Class1.txtindex.ToString
            Dim txt As New TextBox
            txt.Name = "textbox" + Class1.txtindex.ToString
            'txt.Name = Class1.txtmultistring.Split("|"c)
            txt.Text = Nothing
            txt.Font = fontbtn.Font
            txt.ForeColor = Panel1.BackColor
            txt.BackColor = Panel2.BackColor
            txt.Location = New System.Drawing.Point(locheight.Value, locwith.Value)
            txt.TabIndex = NumericUpDown1.Value
            txt.TextAlign = TextBox2.TextAlign
            txt.BorderStyle = TextBox2.BorderStyle
            txt.Tag = txalign(TextBox2.TextAlign.ToString) + "|" + txborderstyle(TextBox2.BorderStyle.ToString) + "|" + txscrolls(scrollbarcheck.Checked) + "|" + txmultiline(multilinecheck.Checked)
            If multilinecheck.Checked = False And sizewith.Value = 0 Then
                txt.Multiline = False
                txt.AutoSize = True
            ElseIf multilinecheck.Checked = True Then
                txt.Multiline = True
                txt.Size = New System.Drawing.Size(sizewith.Value, sizeheight.Value)
                txt.AutoSize = False
            ElseIf multilinecheck.Checked = False And sizewith.Value > 0 Then
                txt.Multiline = False
                txt.AutoSize = True
                txt.Size += New System.Drawing.Size(sizewith.Value, sizeheight.Value)
            End If
            If scrollbarcheck.Checked = True Then
                txt.ScrollBars = ScrollBars.Both
            Else
                txt.ScrollBars = ScrollBars.None
            End If
            AddHandler txt.Click, AddressOf Form1.test
            AddHandler txt.MouseDown, AddressOf Form1.test2
            AddHandler txt.MouseUp, AddressOf Form1.test3
            AddHandler txt.MouseMove, AddressOf Form1.test4
            AddHandler txt.KeyDown, AddressOf Form1.test5
            AddHandler txt.GotFocus, AddressOf Form1.test8
            Form1.Panel1.Controls.Add(txt)
        End If

        If Me.Text = "Add new label" Or Me.Text = "Címke hozzáadása" Then
            Class1.labelindex += 1
            Dim lbl As New Label
            lbl.Name = "label" + Class1.labelindex.ToString
            lbl.AutoSize = True
            'lbl.Size = New System.Drawing.Size(sizeheight.Value, sizewith.Value)
            lbl.Location = New System.Drawing.Point(locheight.Value, locwith.Value) 'set your location
            lbl.Text = TextBox1.Text
            lbl.Font = fontbtn.Font
            lbl.ForeColor = Panel1.BackColor
            lbl.BackColor = Panel2.BackColor
            lbl.Tag = "not"
            AddHandler lbl.Click, AddressOf Form1.test
            AddHandler lbl.MouseDown, AddressOf Form1.test2
            AddHandler lbl.MouseUp, AddressOf Form1.test3
            AddHandler lbl.MouseMove, AddressOf Form1.test4
            AddHandler lbl.KeyDown, AddressOf Form1.test5
            'set your name
            Form1.Panel1.Controls.Add(lbl)
            'add your new control to your forms control collection
        End If
    End Sub

    Private Sub fontbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fontbtn.Click
        If FontDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            fontbtn.Font = FontDialog1.Font
            TextBox2.Font = FontDialog1.Font
        End If
    End Sub

    Private Sub colorbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles colorbtn.Click
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Panel1.BackColor = ColorDialog1.Color
            TextBox2.ForeColor = ColorDialog1.Color
        End If
    End Sub

    Private Shared Function Num(ByVal value As String) As Integer
        Dim returnVal As String = String.Empty
        Dim collection As MatchCollection = Regex.Matches(value, "\d+")
        For Each m As Match In collection
            returnVal += m.ToString()
        Next
        Return Convert.ToInt32(returnVal)
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Panel2.BackColor = ColorDialog1.Color
            TextBox2.BackColor = ColorDialog1.Color
        End If
        If Panel2.BackColor = Form1.Panel1.BackColor Then
            Return
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            autowith.Enabled = True
        Else
            autowith.Enabled = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            autoheight.Enabled = True
        Else
            autoheight.Enabled = False
        End If
    End Sub

    Private Sub multilinecheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles multilinecheck.CheckedChanged
        If multilinecheck.Checked = True And Me.Text = "Add new textbox" Or "Szövegdoboz hozzáadása" Then
            scrollbarcheck.Enabled = True
            sizeheight.Enabled = True
            sizewith.Enabled = True
            TextBox2.Multiline = True
            TextBox2.Height += 20
        ElseIf multilinecheck.Checked = False And Me.Text = "Add new textbox" Or "Szövegdoboz hozzáadása" Then
            scrollbarcheck.Enabled = False
            sizeheight.Enabled = False
            sizewith.Enabled = False
            TextBox2.Height -= 20
            TextBox2.Multiline = False
        End If
    End Sub

    Private Sub loadimg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadimg.Click
        If Form1.openimage.ShowDialog = Windows.Forms.DialogResult.OK And Form1.openimage.FileName IsNot Nothing Then
            TextBox1.Text = Form1.openimage.FileName
            PictureBox1.BackgroundImage = Image.FromFile(Form1.openimage.FileName)
            If ComboBox2.Text = "" Then
                PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
            ElseIf ComboBox2.Text = "Tile" Then
                PictureBox1.BackgroundImageLayout = ImageLayout.Tile
            ElseIf ComboBox2.Text = "Stretch" Then
                PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
            ElseIf ComboBox2.Text = "Zoom" Then
                PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
            ElseIf ComboBox2.Text = "Center" Then
                PictureBox1.BackgroundImageLayout = ImageLayout.Center
            End If
            imgflip = 0
            PictureBox1.Tag = Form1.openimage.FileName
            sizewith.Value = PictureBox1.BackgroundImage.PhysicalDimension.Height
            sizeh = PictureBox1.BackgroundImage.PhysicalDimension.Height
            sizeheight.Value = PictureBox1.BackgroundImage.PhysicalDimension.Width
            sizew = PictureBox1.BackgroundImage.PhysicalDimension.Width
            Button1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            Panel2.BackColor = Color.Transparent
            Button3.Enabled = False
        Else
            Panel2.BackColor = Form1.Panel1.BackColor
            Button3.Enabled = True
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Left" Or "Bal" Then
            TextBox2.TextAlign = HorizontalAlignment.Left
        ElseIf ComboBox1.SelectedItem = "Center" Or "Közép" Then
            TextBox2.TextAlign = HorizontalAlignment.Center
        ElseIf ComboBox1.SelectedItem = "Right" Or "Jobb" Then
            TextBox2.TextAlign = HorizontalAlignment.Right
        End If
    End Sub

    Private Sub scrollbarcheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrollbarcheck.CheckedChanged
        If scrollbarcheck.Checked = True Then
            TextBox2.ScrollBars = ScrollBars.Both
        Else
            TextBox2.ScrollBars = ScrollBars.None
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.SelectedItem = "Fixed3D" Then
            TextBox2.BorderStyle = BorderStyle.Fixed3D
        ElseIf ComboBox3.SelectedItem = "FixedSingle" Then
            TextBox2.BorderStyle = BorderStyle.FixedSingle
        ElseIf ComboBox3.SelectedItem = "None" Then
            TextBox2.BorderStyle = BorderStyle.None
        End If
    End Sub
    Dim imgflip As Integer
    Dim sizeh As Integer
    Dim sizew As Integer
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'hátra forgatás
        If PictureBox1.BackgroundImage IsNot Nothing Then
            If imgflip = 0 Then
                imgflip = 3
            Else
                imgflip -= 1
            End If

            Dim img As Image = Image.FromFile(Form1.openimage.FileName)

            If imgflip = 0 Then
                Try
                    'sizew = sizeheight.Value
                    'sizeh = sizewith.Value
                    sizew = PictureBox1.BackgroundImage.PhysicalDimension.Width
                    sizeh = PictureBox1.BackgroundImage.PhysicalDimension.Height
                    img.RotateFlip(RotateFlipType.RotateNoneFlipNone)
                Finally
                    sizeheight.Value = sizeh
                    sizewith.Value = sizew
                    PictureBox1.BackgroundImage = img
                End Try
            ElseIf imgflip = 1 Then
                Try
                    sizew = sizeheight.Value
                    sizeh = sizewith.Value
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone)
                Finally
                    sizeheight.Value = sizeh
                    sizewith.Value = sizew
                    PictureBox1.BackgroundImage = img
                End Try
            ElseIf imgflip = 2 Then
                Try
                    sizew = PictureBox1.BackgroundImage.PhysicalDimension.Width
                    sizeh = PictureBox1.BackgroundImage.PhysicalDimension.Height
                    img.RotateFlip(RotateFlipType.Rotate180FlipNone)
                Finally
                    sizeheight.Value = sizeh
                    sizewith.Value = sizew
                    PictureBox1.BackgroundImage = img
                End Try
            ElseIf imgflip = 3 Then
                Try
                    sizew = sizeheight.Value
                    sizeh = sizewith.Value
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone)
                Finally
                    sizeheight.Value = sizeh
                    sizewith.Value = sizew
                    PictureBox1.BackgroundImage = img
                End Try
            End If
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'előre forgatás
        If PictureBox1.BackgroundImage IsNot Nothing Then
            If imgflip = 3 Then
                imgflip = 0
            Else
                imgflip += 1
            End If

            Dim img As Image = Image.FromFile(Form1.openimage.FileName)

            If imgflip = 0 Then
                Try
                    sizew = PictureBox1.BackgroundImage.PhysicalDimension.Width
                    sizeh = PictureBox1.BackgroundImage.PhysicalDimension.Height
                    img.RotateFlip(RotateFlipType.RotateNoneFlipNone)
                Finally
                    sizeheight.Value = sizeh
                    sizewith.Value = sizew
                    PictureBox1.BackgroundImage = img
                End Try
            ElseIf imgflip = 1 Then
                Try
                    sizew = sizeheight.Value
                    sizeh = sizewith.Value
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone)
                Finally
                    sizeheight.Value = sizeh
                    sizewith.Value = sizew
                    PictureBox1.BackgroundImage = img
                End Try
            ElseIf imgflip = 2 Then
                Try
                    sizew = PictureBox1.BackgroundImage.PhysicalDimension.Width
                    sizeh = PictureBox1.BackgroundImage.PhysicalDimension.Height
                    img.RotateFlip(RotateFlipType.Rotate180FlipNone)
                Finally
                    sizeheight.Value = sizeh
                    sizewith.Value = sizew
                    PictureBox1.BackgroundImage = img
                End Try
            ElseIf imgflip = 3 Then
                Try
                    sizew = sizeheight.Value
                    sizeh = sizewith.Value
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone)
                Finally
                    sizeheight.Value = sizeh
                    sizewith.Value = sizew
                    PictureBox1.BackgroundImage = img
                End Try
            End If
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "" Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        ElseIf ComboBox2.Text = "Tile" Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Tile
        ElseIf ComboBox2.Text = "Stretch" Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        ElseIf ComboBox2.Text = "Zoom" Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        ElseIf ComboBox2.Text = "Center" Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Center
        End If
    End Sub
End Class
