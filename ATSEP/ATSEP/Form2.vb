Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class Form2
    Dim cm As OleDbCommand
    Dim cn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Dim dr As DataRow
    Dim rowindex As Integer = 0
    Dim mofd As Boolean = False
    Dim add As Boolean = False
    Dim staffid() As String
    Dim item As ListViewItem

    Public staffinfo As DataTable



    Private Sub GO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ListView1.SelectedItems.Count <> 0 Then
            Form1.name2 = ListView1.SelectedItems(0).SubItems(1).Text
            Form1.staffnub = ListView1.SelectedItems(0).SubItems(0).Text
            Form1.grade = ListView1.SelectedItems(0).SubItems(2).Text
            Form1.staffid = ListView1.SelectedItems(0).SubItems(4).Text
            Form1.syscount = ListView1.SelectedItems(0).SubItems(5).Text

            Me.Close()
        End If
    End Sub



    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        For Each dr As DataRow In staffinfo.Rows
            ListView1.Items.Add(New ListViewItem(New String(9) {dr("STAFFNO_").ToString(), dr("STAFFNAME").ToString(), dr("GRADE").ToString(), dr("UNIT").ToString(), dr("STAFFID").ToString(), dr("SYSCOUNT").ToString(), dr("CERT_C").ToString(), dr("CERT_N").ToString(), dr("CERT_S").ToString(), dr("CERT_D").ToString()}))

        Next
        ListView1.Columns(9).Width = 0
        ListView1.Columns(8).Width = 0
        ListView1.Columns(7).Width = 0
        ListView1.Columns(6).Width = 0

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged


        Dim foundItem As ListViewItem = ListView1.FindItemWithText(TextBox1.Text, True, 0, True)
        If (foundItem IsNot Nothing) Then
            ListView1.TopItem = foundItem
            ListView1.HideSelection = False
            foundItem.Selected = True
            foundItem.Checked = True
        End If
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Form1.name2 = ListView1.SelectedItems(0).SubItems(1).Text
        Form1.staffnub = ListView1.SelectedItems(0).SubItems(0).Text
        Form1.grade = ListView1.SelectedItems(0).SubItems(2).Text
        Form1.staffid = ListView1.SelectedItems(0).SubItems(4).Text
        Form1.syscount = ListView1.SelectedItems(0).SubItems(5).Text
        Form1.cert = ListView1.SelectedItems(0).SubItems(6).Text + "," + ListView1.SelectedItems(0).SubItems(7).Text + "," + ListView1.SelectedItems(0).SubItems(8).Text + "," + ListView1.SelectedItems(0).SubItems(9).Text
        Me.Close()

    End Sub

    Private Sub adddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adddButton.Click
        RemoveHandler ListView1.DoubleClick, AddressOf ListView1_DoubleClick
        ListView1.Enabled = False
        GO.Enabled = False
        mofdButton.Enabled = False
        TextBox1.Enabled = False
        saveButton.Enabled = True
        adddButton.Enabled = False
        staffnoTextBox.Enabled = True
        staffnameTextBox.Enabled = True
        gradeTextBox.Enabled = True
        unitTextBox.Enabled = True
        add = True
        cancelButtons.Enabled = True
    End Sub

    Private Sub mofdButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mofdButton.Click
        RemoveHandler ListView1.DoubleClick, AddressOf ListView1_DoubleClick
        TextBox1.Enabled = False
        GO.Enabled = False
        adddButton.Enabled = False
        saveButton.Enabled = True
        mofdButton.Enabled = False
        mofd = True
        staffnoTextBox.Enabled = True
        staffnameTextBox.Enabled = True
        gradeTextBox.Enabled = True
        unitTextBox.Enabled = True
        cancelButtons.Enabled = True
        If (ListView1.SelectedItems.Count <> 0) Then
            staffnoTextBox.Text = ListView1.SelectedItems(0).SubItems(0).Text
            staffnameTextBox.Text = ListView1.SelectedItems(0).SubItems(1).Text
            gradeTextBox.Text = ListView1.SelectedItems(0).SubItems(2).Text
            unitTextBox.Text = ListView1.SelectedItems(0).SubItems(3).Text
            rowindex = ListView1.SelectedItems(0).Index
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If mofd And ListView1.SelectedItems.Count <> 0 Then
            staffnoTextBox.Text = ListView1.SelectedItems(0).SubItems(0).Text
            staffnameTextBox.Text = ListView1.SelectedItems(0).SubItems(1).Text
            gradeTextBox.Text = ListView1.SelectedItems(0).SubItems(2).Text
            unitTextBox.Text = ListView1.SelectedItems(0).SubItems(3).Text
            rowindex = ListView1.SelectedItems(0).Index
        End If
    End Sub

    Private Sub saveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveButton.Click
        AddHandler ListView1.DoubleClick, AddressOf ListView1_DoubleClick
        TextBox1.Enabled = True
        GO.Enabled = True
        adddButton.Enabled = True
        mofdButton.Enabled = True
        saveButton.Enabled = False
        ListView1.Enabled = True


        If mofd And ListView1.SelectedItems.Count <> 0 Then
            Dim key() As Object = New Object(0) {}
            key(0) = ListView1.Items(rowindex).SubItems(4).Text
            staffinfo.Rows.Find(key)(1) = staffnoTextBox.Text
            staffinfo.Rows.Find(key)(2) = staffnameTextBox.Text
            staffinfo.Rows.Find(key)(3) = gradeTextBox.Text
            staffinfo.Rows.Find(key)(5) = unitTextBox.Text
            ListView1.Items(rowindex).SubItems(0).Text = staffnoTextBox.Text
            ListView1.Items(rowindex).SubItems(1).Text = staffnameTextBox.Text
            ListView1.Items(rowindex).SubItems(2).Text = gradeTextBox.Text
            ListView1.Items(rowindex).SubItems(3).Text = unitTextBox.Text
        ElseIf add Then
            Dim dr As DataRow = staffinfo.NewRow()
            dr(0) = (staffinfo.Rows(staffinfo.Rows.Count - 1)(0)) + 1
            dr(1) = staffnoTextBox.Text
            dr(2) = staffnameTextBox.Text
            dr(3) = gradeTextBox.Text
            dr(4) = 1
            dr(5) = unitTextBox.Text
            dr(6) = 0
            ListView1.Items.Add(New ListViewItem(New String(5) {dr("STAFFNAME").ToString(), dr("STAFFNO_").ToString(), dr("GRADE").ToString(), dr("UNIT").ToString(), dr("STAFFID").ToString(), dr("SYSCOUNT").ToString()}))
            staffinfo.Rows.Add(dr)


        End If
        staffnoTextBox.Enabled = False
        staffnameTextBox.Enabled = False
        gradeTextBox.Enabled = False
        unitTextBox.Enabled = False
        staffnameTextBox.Clear()
        staffnoTextBox.Clear()
        gradeTextBox.Clear()
        unitTextBox.Clear()
        mofd = False
        add = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        For Each row As ListViewItem In ListView1.Items
            ListView1.Items.Remove(row)
        Next
        If ComboBox1.SelectedIndex = 0 Then
             For Each dr As DataRow In staffinfo.Rows
                ListView1.Items.Add(New ListViewItem(New String(9) {dr("STAFFNO_").ToString(), dr("STAFFNAME").ToString(), dr("GRADE").ToString(), dr("UNIT").ToString(), dr("STAFFID").ToString(), dr("SYSCOUNT").ToString(), dr("CERT_C").ToString(), dr("CERT_N").ToString(), dr("CERT_S").ToString(), dr("CERT_D").ToString()}))

            Next
        Else

            For Each dr As DataRow In staffinfo.Rows

                If ComboBox1.Text.Equals(dr("UNIT").ToString()) Then
                    ListView1.Items.Add(New ListViewItem(New String(9) {dr("STAFFNO_").ToString(), dr("STAFFNAME").ToString(), dr("GRADE").ToString(), dr("UNIT").ToString(), dr("STAFFID").ToString(), dr("SYSCOUNT").ToString(), dr("CERT_C").ToString(), dr("CERT_N").ToString(), dr("CERT_S").ToString(), dr("CERT_D").ToString()}))
                End If
            Next
        End If
    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButtons.Click
        AddHandler ListView1.DoubleClick, AddressOf ListView1_DoubleClick
        TextBox1.Enabled = True
        GO.Enabled = True
        adddButton.Enabled = True
        mofdButton.Enabled = True
        saveButton.Enabled = False
        ListView1.Enabled = True
        staffnoTextBox.Enabled = False
        staffnameTextBox.Enabled = False
        gradeTextBox.Enabled = False
        unitTextBox.Enabled = False
        staffnameTextBox.Clear()
        staffnoTextBox.Clear()
        gradeTextBox.Clear()
        unitTextBox.Clear()
        mofd = False
        add = False
        cancelButtons.Enabled = False
    End Sub

    Private Sub deleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleButton.Click
        If ListView1.SelectedItems.Count = 1 Then

            If MessageBox.Show("dele?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                staffinfo.Rows.Find(New Object(0) {ListView1.SelectedItems(0).SubItems(4).Text}).Delete()
                ListView1.SelectedItems(0).Remove()
            End If
        End If
    End Sub
End Class