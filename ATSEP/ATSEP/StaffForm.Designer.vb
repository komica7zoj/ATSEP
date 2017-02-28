<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StaffForm
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
        Me.components = New System.ComponentModel.Container()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.StaffName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StaffNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Certtype = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Grade = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Unit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SE = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowNCertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowSCertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowDCertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gradeComboBox = New System.Windows.Forms.ComboBox()
        Me.ESComboBox = New System.Windows.Forms.ComboBox()
        Me.unitComboBox = New System.Windows.Forms.ComboBox()
        Me.searchTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Search = New System.Windows.Forms.Label()
        Me.Cert = New System.Windows.Forms.Label()
        Me.certComboBox = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.printButton = New System.Windows.Forms.Button()
        Me.printcertButton = New System.Windows.Forms.Button()
        Me.printallButton = New System.Windows.Forms.Button()
        Me.StaffNameCheckBox = New System.Windows.Forms.CheckBox()
        Me.StaffNumberCheckBox = New System.Windows.Forms.CheckBox()
        Me.CertTypeCheckBox = New System.Windows.Forms.CheckBox()
        Me.GradeCheckBox = New System.Windows.Forms.CheckBox()
        Me.UnitCheckBox = New System.Windows.Forms.CheckBox()
        Me.SystemCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.applycertButton = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.StaffName, Me.StaffNo, Me.Certtype, Me.Grade, Me.Unit, Me.SE, Me.ColumnHeader1})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(12, 107)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1245, 328)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'StaffName
        '
        Me.StaffName.Text = "Staff Name"
        Me.StaffName.Width = 171
        '
        'StaffNo
        '
        Me.StaffNo.Text = "Staff Number"
        Me.StaffNo.Width = 193
        '
        'Certtype
        '
        Me.Certtype.Text = "Cert Type"
        Me.Certtype.Width = 161
        '
        'Grade
        '
        Me.Grade.Text = "Grade"
        Me.Grade.Width = 181
        '
        'Unit
        '
        Me.Unit.Text = "Unit"
        Me.Unit.Width = 146
        '
        'SE
        '
        Me.SE.Text = "System / Equipment Rating"
        Me.SE.Width = 488
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestToolStripMenuItem, Me.ShowNCertToolStripMenuItem, Me.ShowSCertToolStripMenuItem, Me.ShowDCertToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(143, 92)
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.TestToolStripMenuItem.Text = "show C cert"
        '
        'ShowNCertToolStripMenuItem
        '
        Me.ShowNCertToolStripMenuItem.Name = "ShowNCertToolStripMenuItem"
        Me.ShowNCertToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ShowNCertToolStripMenuItem.Text = "show N cert"
        '
        'ShowSCertToolStripMenuItem
        '
        Me.ShowSCertToolStripMenuItem.Name = "ShowSCertToolStripMenuItem"
        Me.ShowSCertToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ShowSCertToolStripMenuItem.Text = "show S cert"
        '
        'ShowDCertToolStripMenuItem
        '
        Me.ShowDCertToolStripMenuItem.Name = "ShowDCertToolStripMenuItem"
        Me.ShowDCertToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ShowDCertToolStripMenuItem.Text = "show D cert"
        '
        'gradeComboBox
        '
        Me.gradeComboBox.FormattingEnabled = True
        Me.gradeComboBox.Items.AddRange(New Object() {"---All---", "TO", "STO", "AE", "E", "SE", "Orther"})
        Me.gradeComboBox.Location = New System.Drawing.Point(584, 80)
        Me.gradeComboBox.Name = "gradeComboBox"
        Me.gradeComboBox.Size = New System.Drawing.Size(121, 22)
        Me.gradeComboBox.TabIndex = 1
        Me.gradeComboBox.Text = "---All---"
        '
        'ESComboBox
        '
        Me.ESComboBox.FormattingEnabled = True
        Me.ESComboBox.Items.AddRange(New Object() {"---All---"})
        Me.ESComboBox.Location = New System.Drawing.Point(1043, 80)
        Me.ESComboBox.Name = "ESComboBox"
        Me.ESComboBox.Size = New System.Drawing.Size(121, 22)
        Me.ESComboBox.TabIndex = 2
        Me.ESComboBox.Text = "---All---"
        '
        'unitComboBox
        '
        Me.unitComboBox.FormattingEnabled = True
        Me.unitComboBox.Items.AddRange(New Object() {"---All---", "Sof", "Nav", "Com", "Ops", "Rad", "Sys", "Proj", "Trn"})
        Me.unitComboBox.Location = New System.Drawing.Point(753, 79)
        Me.unitComboBox.Name = "unitComboBox"
        Me.unitComboBox.Size = New System.Drawing.Size(121, 22)
        Me.unitComboBox.TabIndex = 3
        Me.unitComboBox.Text = "---All---"
        '
        'searchTextBox
        '
        Me.searchTextBox.Location = New System.Drawing.Point(61, 79)
        Me.searchTextBox.Name = "searchTextBox"
        Me.searchTextBox.Size = New System.Drawing.Size(174, 22)
        Me.searchTextBox.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(724, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Unit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(545, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 14)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Rank"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(922, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 14)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Eqipment / System"
        '
        'Search
        '
        Me.Search.AutoSize = True
        Me.Search.Location = New System.Drawing.Point(12, 83)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(43, 14)
        Me.Search.TabIndex = 8
        Me.Search.Text = "Search"
        '
        'Cert
        '
        Me.Cert.AutoSize = True
        Me.Cert.Location = New System.Drawing.Point(386, 84)
        Me.Cert.Name = "Cert"
        Me.Cert.Size = New System.Drawing.Size(55, 14)
        Me.Cert.TabIndex = 9
        Me.Cert.Text = "Cert Type"
        '
        'certComboBox
        '
        Me.certComboBox.FormattingEnabled = True
        Me.certComboBox.Items.AddRange(New Object() {"---All---", "C", "N", "S", "D"})
        Me.certComboBox.Location = New System.Drawing.Point(445, 80)
        Me.certComboBox.Name = "certComboBox"
        Me.certComboBox.Size = New System.Drawing.Size(95, 22)
        Me.certComboBox.TabIndex = 10
        Me.certComboBox.Text = "---All---"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(26, 458)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 29)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Label4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(82, 458)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(182, 29)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "staffs were found"
        '
        'printButton
        '
        Me.printButton.Location = New System.Drawing.Point(849, 449)
        Me.printButton.Name = "printButton"
        Me.printButton.Size = New System.Drawing.Size(117, 23)
        Me.printButton.TabIndex = 13
        Me.printButton.Text = "Print the layout"
        Me.printButton.UseVisualStyleBackColor = True
        '
        'printcertButton
        '
        Me.printcertButton.Location = New System.Drawing.Point(991, 449)
        Me.printcertButton.Name = "printcertButton"
        Me.printcertButton.Size = New System.Drawing.Size(158, 23)
        Me.printcertButton.TabIndex = 14
        Me.printcertButton.Text = "Print selected cert"
        Me.printcertButton.UseVisualStyleBackColor = True
        '
        'printallButton
        '
        Me.printallButton.Location = New System.Drawing.Point(991, 478)
        Me.printallButton.Name = "printallButton"
        Me.printallButton.Size = New System.Drawing.Size(187, 23)
        Me.printallButton.TabIndex = 15
        Me.printallButton.Text = "Print all cert(if not printed)"
        Me.printallButton.UseVisualStyleBackColor = True
        '
        'StaffNameCheckBox
        '
        Me.StaffNameCheckBox.AutoSize = True
        Me.StaffNameCheckBox.Checked = True
        Me.StaffNameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StaffNameCheckBox.Enabled = False
        Me.StaffNameCheckBox.Location = New System.Drawing.Point(792, 12)
        Me.StaffNameCheckBox.Name = "StaffNameCheckBox"
        Me.StaffNameCheckBox.Size = New System.Drawing.Size(117, 18)
        Me.StaffNameCheckBox.TabIndex = 22
        Me.StaffNameCheckBox.Text = "Show Staff Name"
        Me.StaffNameCheckBox.UseVisualStyleBackColor = True
        '
        'StaffNumberCheckBox
        '
        Me.StaffNumberCheckBox.AutoSize = True
        Me.StaffNumberCheckBox.Checked = True
        Me.StaffNumberCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StaffNumberCheckBox.Enabled = False
        Me.StaffNumberCheckBox.Location = New System.Drawing.Point(792, 36)
        Me.StaffNumberCheckBox.Name = "StaffNumberCheckBox"
        Me.StaffNumberCheckBox.Size = New System.Drawing.Size(128, 18)
        Me.StaffNumberCheckBox.TabIndex = 23
        Me.StaffNumberCheckBox.Text = "Show Staff Number"
        Me.StaffNumberCheckBox.UseVisualStyleBackColor = True
        '
        'CertTypeCheckBox
        '
        Me.CertTypeCheckBox.AutoSize = True
        Me.CertTypeCheckBox.Checked = True
        Me.CertTypeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CertTypeCheckBox.Location = New System.Drawing.Point(925, 12)
        Me.CertTypeCheckBox.Name = "CertTypeCheckBox"
        Me.CertTypeCheckBox.Size = New System.Drawing.Size(106, 18)
        Me.CertTypeCheckBox.TabIndex = 24
        Me.CertTypeCheckBox.Text = "Show Cert Type"
        Me.CertTypeCheckBox.UseVisualStyleBackColor = True
        '
        'GradeCheckBox
        '
        Me.GradeCheckBox.AutoSize = True
        Me.GradeCheckBox.Checked = True
        Me.GradeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.GradeCheckBox.Location = New System.Drawing.Point(925, 36)
        Me.GradeCheckBox.Name = "GradeCheckBox"
        Me.GradeCheckBox.Size = New System.Drawing.Size(91, 18)
        Me.GradeCheckBox.TabIndex = 25
        Me.GradeCheckBox.Text = "Show Grade"
        Me.GradeCheckBox.UseVisualStyleBackColor = True
        '
        'UnitCheckBox
        '
        Me.UnitCheckBox.AutoSize = True
        Me.UnitCheckBox.Checked = True
        Me.UnitCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UnitCheckBox.Location = New System.Drawing.Point(1043, 12)
        Me.UnitCheckBox.Name = "UnitCheckBox"
        Me.UnitCheckBox.Size = New System.Drawing.Size(81, 18)
        Me.UnitCheckBox.TabIndex = 26
        Me.UnitCheckBox.Text = "Show Unit"
        Me.UnitCheckBox.UseVisualStyleBackColor = True
        '
        'SystemCheckBox
        '
        Me.SystemCheckBox.AutoSize = True
        Me.SystemCheckBox.Checked = True
        Me.SystemCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SystemCheckBox.Location = New System.Drawing.Point(1043, 36)
        Me.SystemCheckBox.Name = "SystemCheckBox"
        Me.SystemCheckBox.Size = New System.Drawing.Size(153, 18)
        Me.SystemCheckBox.TabIndex = 27
        Me.SystemCheckBox.Text = "Show Eqipment/System"
        Me.SystemCheckBox.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(314, 458)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 29)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(373, 458)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(194, 29)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "certs were created"
        '
        'applycertButton
        '
        Me.applycertButton.Location = New System.Drawing.Point(849, 478)
        Me.applycertButton.Name = "applycertButton"
        Me.applycertButton.Size = New System.Drawing.Size(117, 23)
        Me.applycertButton.TabIndex = 31
        Me.applycertButton.Text = "Apply the cert"
        Me.applycertButton.UseVisualStyleBackColor = True
        '
        'StaffForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1269, 507)
        Me.Controls.Add(Me.applycertButton)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.SystemCheckBox)
        Me.Controls.Add(Me.UnitCheckBox)
        Me.Controls.Add(Me.GradeCheckBox)
        Me.Controls.Add(Me.CertTypeCheckBox)
        Me.Controls.Add(Me.StaffNumberCheckBox)
        Me.Controls.Add(Me.StaffNameCheckBox)
        Me.Controls.Add(Me.printallButton)
        Me.Controls.Add(Me.printcertButton)
        Me.Controls.Add(Me.printButton)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.certComboBox)
        Me.Controls.Add(Me.Cert)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.searchTextBox)
        Me.Controls.Add(Me.unitComboBox)
        Me.Controls.Add(Me.ESComboBox)
        Me.Controls.Add(Me.gradeComboBox)
        Me.Controls.Add(Me.ListView1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Name = "StaffForm"
        Me.Text = "StaffForm"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents gradeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ESComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents unitComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents searchTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Search As System.Windows.Forms.Label
    Friend WithEvents StaffName As System.Windows.Forms.ColumnHeader
    Friend WithEvents StaffNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Grade As System.Windows.Forms.ColumnHeader
    Friend WithEvents Unit As System.Windows.Forms.ColumnHeader
    Friend WithEvents SE As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Cert As System.Windows.Forms.Label
    Friend WithEvents certComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents printButton As System.Windows.Forms.Button
    Friend WithEvents printcertButton As System.Windows.Forms.Button
    Friend WithEvents printallButton As System.Windows.Forms.Button
    Friend WithEvents Certtype As System.Windows.Forms.ColumnHeader
    Friend WithEvents StaffNameCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents StaffNumberCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CertTypeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GradeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents UnitCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SystemCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowNCertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowSCertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowDCertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents applycertButton As System.Windows.Forms.Button
End Class
