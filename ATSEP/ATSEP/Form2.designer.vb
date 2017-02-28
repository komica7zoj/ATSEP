<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GO = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.adddButton = New System.Windows.Forms.Button()
        Me.staffnameTextBox = New System.Windows.Forms.TextBox()
        Me.gradeTextBox = New System.Windows.Forms.TextBox()
        Me.staffnoTextBox = New System.Windows.Forms.TextBox()
        Me.unitTextBox = New System.Windows.Forms.TextBox()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.mofdButton = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cancelButtons = New System.Windows.Forms.Button()
        Me.deleButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(29, 33)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 0
        '
        'GO
        '
        Me.GO.Location = New System.Drawing.Point(144, 33)
        Me.GO.Name = "GO"
        Me.GO.Size = New System.Drawing.Size(35, 21)
        Me.GO.TabIndex = 1
        Me.GO.Text = "GO"
        Me.GO.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(29, 92)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(772, 382)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "STAFF NO."
        Me.ColumnHeader1.Width = 142
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "STAFF NAME"
        Me.ColumnHeader2.Width = 204
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "GRADE"
        Me.ColumnHeader3.Width = 208
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "UNIT"
        Me.ColumnHeader4.Width = 214
        '
        'adddButton
        '
        Me.adddButton.Location = New System.Drawing.Point(807, 448)
        Me.adddButton.Name = "adddButton"
        Me.adddButton.Size = New System.Drawing.Size(75, 27)
        Me.adddButton.TabIndex = 4
        Me.adddButton.Text = "ADD"
        Me.adddButton.UseVisualStyleBackColor = True
        '
        'staffnameTextBox
        '
        Me.staffnameTextBox.Enabled = False
        Me.staffnameTextBox.Location = New System.Drawing.Point(189, 506)
        Me.staffnameTextBox.Name = "staffnameTextBox"
        Me.staffnameTextBox.Size = New System.Drawing.Size(191, 22)
        Me.staffnameTextBox.TabIndex = 5
        '
        'gradeTextBox
        '
        Me.gradeTextBox.Enabled = False
        Me.gradeTextBox.Location = New System.Drawing.Point(386, 506)
        Me.gradeTextBox.Name = "gradeTextBox"
        Me.gradeTextBox.Size = New System.Drawing.Size(199, 22)
        Me.gradeTextBox.TabIndex = 6
        '
        'staffnoTextBox
        '
        Me.staffnoTextBox.Enabled = False
        Me.staffnoTextBox.Location = New System.Drawing.Point(29, 506)
        Me.staffnoTextBox.Name = "staffnoTextBox"
        Me.staffnoTextBox.Size = New System.Drawing.Size(150, 22)
        Me.staffnoTextBox.TabIndex = 7
        '
        'unitTextBox
        '
        Me.unitTextBox.Enabled = False
        Me.unitTextBox.Location = New System.Drawing.Point(591, 506)
        Me.unitTextBox.Name = "unitTextBox"
        Me.unitTextBox.Size = New System.Drawing.Size(210, 22)
        Me.unitTextBox.TabIndex = 8
        '
        'saveButton
        '
        Me.saveButton.Enabled = False
        Me.saveButton.Location = New System.Drawing.Point(889, 448)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 27)
        Me.saveButton.TabIndex = 9
        Me.saveButton.Text = "SAVE"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'mofdButton
        '
        Me.mofdButton.Location = New System.Drawing.Point(807, 483)
        Me.mofdButton.Name = "mofdButton"
        Me.mofdButton.Size = New System.Drawing.Size(75, 27)
        Me.mofdButton.TabIndex = 10
        Me.mofdButton.Text = "MOFD"
        Me.mofdButton.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"------Show all------", "Com", "Nav", "Ops", "Rad", "Sof", "Sys", "Proj", "Trn"})
        Me.ComboBox1.Location = New System.Drawing.Point(242, 33)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 22)
        Me.ComboBox1.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(114, 570)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 14)
        Me.Label1.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(660, 485)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 14)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Unit"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(452, 485)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 14)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Grade"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(261, 483)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 14)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Staff Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 483)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 14)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Staff NO."
        '
        'cancelButtons
        '
        Me.cancelButtons.Enabled = False
        Me.cancelButtons.Location = New System.Drawing.Point(889, 483)
        Me.cancelButtons.Name = "cancelButtons"
        Me.cancelButtons.Size = New System.Drawing.Size(75, 27)
        Me.cancelButtons.TabIndex = 23
        Me.cancelButtons.Text = "Cancel"
        Me.cancelButtons.UseVisualStyleBackColor = True
        '
        'deleButton
        '
        Me.deleButton.Location = New System.Drawing.Point(807, 517)
        Me.deleButton.Name = "deleButton"
        Me.deleButton.Size = New System.Drawing.Size(75, 27)
        Me.deleButton.TabIndex = 24
        Me.deleButton.Text = "Dele"
        Me.deleButton.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 638)
        Me.Controls.Add(Me.deleButton)
        Me.Controls.Add(Me.cancelButtons)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.mofdButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.unitTextBox)
        Me.Controls.Add(Me.staffnoTextBox)
        Me.Controls.Add(Me.gradeTextBox)
        Me.Controls.Add(Me.staffnameTextBox)
        Me.Controls.Add(Me.adddButton)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.GO)
        Me.Controls.Add(Me.TextBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GO As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents adddButton As System.Windows.Forms.Button
    Friend WithEvents staffnameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents gradeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents staffnoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents unitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents saveButton As System.Windows.Forms.Button
    Friend WithEvents mofdButton As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cancelButtons As System.Windows.Forms.Button
    Friend WithEvents deleButton As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
End Class
