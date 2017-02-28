Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class Form3
    Dim cm As OleDbCommand
    Dim cn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Dim dr As DataRow
    Dim item As ListViewItem
    Dim add As Boolean = False
    Public systeminfo As DataTable
    Public relation As DataTable
    Public staffinfo As DataTable
    Public report As DataTable
    Public staffid As Integer
    Public systemid() As String
    Public endedit As Boolean = False


    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim key() As Object = New Object(0) {""}
        For Each dr As DataRow In systeminfo.Rows
            ComboBox1.Items.Add(dr("SYSTEMID").ToString() + "." + dr("SYSTEMNAME").ToString())

        Next

        For Each s As String In systemid
            key = New Object(0) {""}
            key(0) = s.Split(",")(0)

            ListView1.Items.Add(New ListViewItem(New String(5) {systeminfo.Rows.Find(key)("SYSTEMNAME").ToString(), systeminfo.Rows.Find(key)("SYSTEMID").ToString(), systeminfo.Rows.Find(key)("IS_MULTILV").ToString(), systeminfo.Rows.Find(key)("UNIT").ToString(), s.Split(",")(1), s.Split(",")(2)}))


        Next
        ListView1.Columns(2).Width = 0
        ListView1.Columns(3).Width = 0
        ListView1.Columns(4).Width = 0
        ListView1.Columns(5).Width = 0
    End Sub

    Private Sub GO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form1.name3 = ListView1.SelectedItems(0).SubItems(0).Text
        Form1.ownsystemid = ListView1.SelectedItems(0).SubItems(1).Text
        Form1.ismultlv = ListView1.SelectedItems(0).SubItems(2).Text
        Form1.systemunit = ListView1.SelectedItems(0).SubItems(3).Text
        Form1.ownLV = ListView1.SelectedItems(0).SubItems(4).Text
        Form1.relationid = ListView1.SelectedItems(0).SubItems(5).Text

        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim foundItem As ListViewItem = ListView1.FindItemWithText(TextBox1.Text, True, 0, True)
        If (foundItem IsNot Nothing) Then
            ' MessageBox.Show(foundItem.Text)

            ListView1.TopItem = foundItem
            ListView1.HideSelection = False
            foundItem.Selected = True
            foundItem.Checked = True

            ' MessageBox.Show(ListView1.TopItem.Text)
        End If

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Form1.name3 = ListView1.SelectedItems(0).SubItems(0).Text
        Form1.ownsystemid = ListView1.SelectedItems(0).SubItems(1).Text
        Form1.ismultlv = ListView1.SelectedItems(0).SubItems(2).Text
        Form1.systemunit = ListView1.SelectedItems(0).SubItems(3).Text
        Form1.ownLV = ListView1.SelectedItems(0).SubItems(4).Text
        Form1.relationid = ListView1.SelectedItems(0).SubItems(5).Text

        endedit = True
        Me.Close()

    End Sub

    Private Sub adddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adddButton.Click
        TextBox1.Enabled = False
        cancel.Enabled = True
        adddButton.Enabled = False
        deldButton.Enabled = False
        ListView1.Enabled = False
        saveButton.Enabled = True
        ComboBox1.Enabled = True
        add = True
    End Sub

    Private Sub deldButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deldButton.Click

        '   ListView1.SelectedItems(0).SubItems(0).Text
    End Sub

    Private Sub saveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveButton.Click
        If add Then
            Dim dr As DataRow = relation.NewRow()
            dr(1) = ComboBox1.Text.Split(".")(0)
            dr(0) = staffid
            dr(3) = (Convert.ToInt32(relation.Rows(relation.Rows.Count - 1)(3)) + 1).ToString()
            dr(4) = "False"
            relation.Rows.Add(dr)

            dr = report.NewRow()
            dr(1) = Format((Convert.ToInt32(report.Rows(report.Rows.Count - 1)(1)) + 1), "0000").ToString()
            dr(2) = ComboBox1.Text.Split(".")(0)
            dr(3) = staffid
            dr(4) = "False"
            dr(5) = ""
            dr(6) = ""
            report.Rows.Add(dr)

            staffinfo.Rows.Find(New Object(0) {staffid})(5) = staffinfo.Rows.Find(New Object(0) {staffid})(5) + 1

        Else

        End If
        ListView1.Items.Add(New ListViewItem(New String(1) {ComboBox1.Text.Split(".")(1), ComboBox1.Text.Split(".")(0)}))
        TextBox1.Enabled = True

        adddButton.Enabled = True
        deldButton.Enabled = True
        ListView1.Enabled = True
        saveButton.Enabled = False
        ComboBox1.Enabled = False
        cancel.Enabled = False
    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click

    End Sub
End Class