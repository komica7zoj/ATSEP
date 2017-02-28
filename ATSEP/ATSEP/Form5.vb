
Public Class Form5
    Dim ds As DataSet
    Dim list As DataTable
    Dim type As Integer = 0
    Dim rowIndex As Integer = 0
    Public isclose As Boolean = True
    'Dim f As Form
    Public dec As String
    Public cri As String
    Public typename As String
    Public Sub New(Optional ByVal ID As String = "", Optional ByVal key As String = "", Optional ByRef ds As DataSet = Nothing, Optional ByVal staffid As String = "", Optional ByVal ownsystemid As String = "")
        InitializeComponent()
        Me.ds = ds
        Label1.Text = ID.Substring(2, ID.Length - 2)
        type = key
        '  MessageBox.Show(ID + key(0))
        Dim list As DataTable = New DataTable()
        list.Columns.AddRange(New DataColumn(3) {New DataColumn(), New DataColumn("Completed Equipment Rating Training (L1/L2)"), New DataColumn("CLASS"), New DataColumn("LV")})
        For Each dr As DataRow In ds.Tables("[S2_SYS_SAMPLE]").Rows
            'MessageBox.Show(dr("SYSTEMID"))
            ' If dr("SYSTEMID") = ownsystemid Then
            '   MessageBox.Show(ownsystemid + "," + staffid)
            If dr("SYSTEMID").Equals(ownsystemid) Then
                Dim dr2 As DataRow = list.NewRow
                dr2(0) = dr("ObjectID")
                dr2(1) = dr("DESCRIPTION")
                dr2(2) = dr("CLASS")
                dr2(3) = dr("LV")

                list.Rows.Add(dr2)

            End If
            'End If


        Next
        DataGridView1.DataSource = list
        Me.list = list
        'DataGridView1.Columns(2).Visible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridView1.Columns(0).Visible = False
    End Sub

    Private Sub GO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GO.Click
        dec = DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(1).Value
        cri = DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(2).Value
        typename = Label1.Text
        Me.Close()
    End Sub

    Private Sub DataGridView1_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.UserAddedRow
        Dim dr As DataRow = ds.Tables("[S2_SYS_SAMPLE]").NewRow()
        dr("ObjectID") = Convert.ToInt32(ds.Tables("[S2_SYS_SAMPLE]").Rows(ds.Tables("[S2_SYS_SAMPLE]").Rows.Count - 1)("ObjectID")) + 1
        'dr("TYPE") = type
        Dim dr2 As DataRow = list.NewRow()

        Try

            DataGridView1.Rows(e.Row.Index - 1).Cells(0).Value = dr("ObjectID").ToString()

        Catch ex As Exception

        End Try
        ds.Tables("[S2_SYS_SAMPLE]").Rows.Add(dr)
    End Sub

    Private Sub DataGridView1_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow
        Dim key(0) As Object
        key(0) = e.Row.Cells(0).Value
        ds.Tables("[S2_SYS_SAMPLE]").Rows.Find(key).Delete()
        list.Rows(e.Row.Index).Delete()
    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Dim key(0) As Object
        key(0) = list.Rows(e.RowIndex)(0)
        ds.Tables("[S2_SYS_SAMPLE]").Rows.Find(key)(1) = type
        ds.Tables("[S2_SYS_SAMPLE]").Rows.Find(key)(2) = list.Rows(e.RowIndex)(0)
        ds.Tables("[S2_SYS_SAMPLE]").Rows.Find(key)(3) = list.Rows(e.RowIndex)(1)
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
        If e.ClickedItem.Tag.Equals("add") Then

            Dim dr As DataRow = ds.Tables("[S2_SYS_SAMPLE]").NewRow()
            dr("ObjectID") = Convert.ToInt32(ds.Tables("[S2_SYS_SAMPLE]").Rows(ds.Tables("[S2_SYS_SAMPLE]").Rows.Count - 1)("ObjectID")) + 1

            ds.Tables("[S2_SYS_SAMPLE]").Rows.Add(dr)

            Dim dr2 As DataRow = list.NewRow()
            dr2(0) = dr("ObjectID")
            list.Rows.InsertAt(dr2, rowIndex + 1)

        ElseIf e.ClickedItem.Tag.Equals("del") Then

            Dim key(0) As Object
            key(0) = list.Rows(rowIndex)(0).ToString()
            ds.Tables("[S2_SYS_SAMPLE]").Rows.Find(key).Delete()
            list.Rows(rowIndex).Delete()
            ds.Tables("[S2_SYS_SAMPLE]").AcceptChanges() 'after delete'
        ElseIf DataGridView1.CurrentCell.IsInEditMode Then
            MessageBox.Show("You Are Under the Edit Mode")
        Else
            isclose = False
            dec = DataGridView1.Rows(rowIndex).Cells(1).Value
            cri = DataGridView1.Rows(rowIndex).Cells(2).Value
            typename = Label1.Text
            Me.Close()
        End If


    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick

    End Sub
End Class