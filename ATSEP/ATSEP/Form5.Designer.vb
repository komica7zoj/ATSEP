<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GO = New System.Windows.Forms.Button()
        Me.funContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddNewRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleThisRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectThisRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.funContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(43, 86)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(772, 390)
        Me.DataGridView1.TabIndex = 52
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 24)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Label1"
        '
        'GO
        '
        Me.GO.Location = New System.Drawing.Point(437, 45)
        Me.GO.Name = "GO"
        Me.GO.Size = New System.Drawing.Size(35, 21)
        Me.GO.TabIndex = 47
        Me.GO.Text = "GO"
        Me.GO.UseVisualStyleBackColor = True
        '
        'funContextMenuStrip
        '
        Me.funContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewRowToolStripMenuItem, Me.DeleThisRowToolStripMenuItem, Me.SelectThisRowToolStripMenuItem})
        Me.funContextMenuStrip.Name = "funContextMenuStrip"
        Me.funContextMenuStrip.Size = New System.Drawing.Size(160, 70)
        '
        'AddNewRowToolStripMenuItem
        '
        Me.AddNewRowToolStripMenuItem.Name = "AddNewRowToolStripMenuItem"
        Me.AddNewRowToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AddNewRowToolStripMenuItem.Tag = "add"
        Me.AddNewRowToolStripMenuItem.Text = "Add new row"
        '
        'DeleThisRowToolStripMenuItem
        '
        Me.DeleThisRowToolStripMenuItem.Name = "DeleThisRowToolStripMenuItem"
        Me.DeleThisRowToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.DeleThisRowToolStripMenuItem.Tag = "del"
        Me.DeleThisRowToolStripMenuItem.Text = "Delete this row"
        '
        'SelectThisRowToolStripMenuItem
        '
        Me.SelectThisRowToolStripMenuItem.Name = "SelectThisRowToolStripMenuItem"
        Me.SelectThisRowToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SelectThisRowToolStripMenuItem.Tag = "select"
        Me.SelectThisRowToolStripMenuItem.Text = "Select this row"
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 626)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GO)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form5"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.funContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GO As System.Windows.Forms.Button
    Friend WithEvents funContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddNewRowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleThisRowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectThisRowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
