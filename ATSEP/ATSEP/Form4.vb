Public Class Form4

    Dim ds As DataSet
    Dim list As DataTable
    Dim type As Integer = 0
    Dim rowIndex As Integer = 0
    '  Dim f As Form

    Public dec As String
    Public cri As String
    Public typename As String
    Public typeid As String
    Public endedit As Boolean = False
    Public isclose As Boolean = True
    Public Sub New(Optional ByVal ID As String = "", Optional ByVal key As String = "", Optional ByRef ds As DataSet = Nothing)
        InitializeComponent()
        Me.ds = ds
        Label1.Text = ID.Split(".")(1)
        type = key
        '  MessageBox.Show(ID + key(0))
        Dim list As DataTable = New DataTable()
        list.Columns.AddRange(New DataColumn(3) {New DataColumn(), New DataColumn(), New DataColumn(), New DataColumn()})
        For Each dr As DataRow In ds.Tables("[SAMPLE_QUESTION]").Rows
            If dr("TYPE") = key Then
                Dim dr2 As DataRow = list.NewRow
                dr2(0) = dr("DESCRIPTION")
                dr2(1) = dr("CRITERIA")
                dr2(2) = dr("ObjectID")
                dr2(3) = key
                list.Rows.Add(dr2)
            End If
        Next
        DataGridView1.DataSource = list
        Me.list = list
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).Visible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

    End Sub

    Private Sub GO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dec = DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(0).Value
        cri = DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(1).Value
        typename = Label1.Text
        Me.Close()
    End Sub
    Private Sub DataGridView1_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow
        Dim key(0) As Object
        key(0) = e.Row.Cells(2).Value
        ds.Tables("[SAMPLE_QUESTION]").Rows.Find(key).Delete()
        list.Rows(e.Row.Index).Delete()
    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Dim key(0) As Object
        key(0) = list.Rows(e.RowIndex)(2)
        ds.Tables("[SAMPLE_QUESTION]").Rows.Find(key)(1) = type
        ds.Tables("[SAMPLE_QUESTION]").Rows.Find(key)(2) = list.Rows(e.RowIndex)(0)
        ds.Tables("[SAMPLE_QUESTION]").Rows.Find(key)(3) = list.Rows(e.RowIndex)(1)
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick

        If e.Button = MouseButtons.Right Then

        Else
            DataGridView1.ContextMenuStrip = funContextMenuStrip
            DataGridView1.ContextMenuStrip.Show(MousePosition)
            rowIndex = e.RowIndex
        End If

    End Sub

    Private Sub funContextMenuStrip_Closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles funContextMenuStrip.Closing
        DataGridView1.ContextMenuStrip = Nothing
        DataGridView1.ContextMenu = Nothing
    End Sub

    Private Sub funContextMenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles funContextMenuStrip.ItemClicked
        If e.ClickedItem.Name = funContextMenuStrip.Items(0).Name Then

            Dim dr As DataRow = ds.Tables("[SAMPLE_QUESTION]").NewRow()
            dr("ObjectID") = Convert.ToInt32(ds.Tables("[SAMPLE_QUESTION]").Rows(ds.Tables("[SAMPLE_QUESTION]").Rows.Count - 1)("ObjectID")) + 1
            dr("TYPE") = type
            dr("DESCRIPTION") = ""
            dr("CRITERIA") = ""
            ds.Tables("[SAMPLE_QUESTION]").Rows.Add(dr)

            Dim dr2 As DataRow = list.NewRow()
            dr2(2) = dr("ObjectID")

            dr2(0) = ""
            dr2(1) = ""
            list.Rows.InsertAt(dr2, rowIndex + 1)
            funContextMenuStrip.Items(1).Enabled = True
            funContextMenuStrip.Items(2).Enabled = True
        ElseIf e.ClickedItem.Name = funContextMenuStrip.Items(1).Name Then
            Dim key(0) As Object
            key(0) = DataGridView1.Rows(rowIndex).Cells(2).Value
            ds.Tables("[SAMPLE_QUESTION]").Rows.Find(key).Delete()
            list.Rows(rowIndex).Delete()
        ElseIf DataGridView1.CurrentCell.IsInEditMode Then
            MessageBox.Show("You Are Under the Edit Mode")
        Else
            dec = DataGridView1.Rows(rowIndex).Cells(0).Value
            cri = DataGridView1.Rows(rowIndex).Cells(1).Value
            typename = Label1.Text
            typeid = type
            endedit = True
            isclose = False
            Me.Close()
        End If
    End Sub



    Private Sub DataGridView1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If DataGridView1.RowCount = 0 Then
            funContextMenuStrip.Items(1).Enabled = False
            funContextMenuStrip.Items(2).Enabled = False
            DataGridView1.ContextMenuStrip = funContextMenuStrip
            DataGridView1.ContextMenuStrip.Show(MousePosition)
            rowIndex = -1
        End If
    End Sub
End Class