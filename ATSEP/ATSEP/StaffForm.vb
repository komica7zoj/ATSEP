Public Class StaffForm
    Dim staffdt As DataTable
    Dim relatdt As DataTable
    Dim systemdt As DataTable
    Dim certtable As DataTable
    Dim owncert As String
    Dim staffcert As String = ""
    Dim listwidth As String = 0
    Dim ishide As Boolean = False
    Dim printerdcert As String = ""
    Private ds As DataSet = New DataSet()
    Public Sub New(Optional ByVal staffinfo As DataTable = Nothing, Optional ByVal relation As DataTable = Nothing, Optional ByVal systeminfo As DataTable = Nothing, Optional ByVal cert As DataTable = Nothing, Optional ByVal ownc As String = Nothing)

        InitializeComponent()
        staffdt = staffinfo
        relatdt = relation
        systemdt = systeminfo
        certtable = cert
        owncert = ownc
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim systemname As String = ""

        For Each dr As DataRow In systeminfo.Rows
            systemname = systemname + dr("SYSTEMNAME") + ","
        Next

        ESComboBox.Items.AddRange(systemname.Split(","))
        For Each dr As DataRow In staffinfo.Rows
            If Not dr("CERT_C").Equals("L") Then
                staffcert = staffcert + "," + dr("CERT_C").ToString()
                j = j + 1
            End If
            If Not dr("CERT_N").Equals("L") Then
                staffcert = staffcert + "," + dr("CERT_N").ToString()
                j = j + 1
            End If
            If Not dr("CERT_S").Equals("L") Then
                staffcert = staffcert + "," + dr("CERT_S").ToString()
                j = j + 1
            End If
            If Not dr("CERT_D").Equals("L") Then
                staffcert = staffcert + "," + dr("CERT_D").ToString()
                j = j + 1
            End If
            printerdcert = printerdcert + staffcert
            staffcert = staffcert.Remove(0, 1)
            Dim system As String = ""
            For Each drr As DataRow In relation.Rows
                If drr("STAFFID").Equals(dr("STAFFID").ToString()) Then
                    system = system + "," + systeminfo.Rows.Find(New Object(0) {drr("SYSTEMID")})(1)
                End If
            Next
            system = system.Remove(0, 1)
            ListView1.Items.Add(New ListViewItem(New String(6) {dr("STAFFNAME").ToString(), dr("STAFFNO_").ToString(), staffcert, dr("GRADE").ToString(), dr("UNIT").ToString(), system, dr("STAFFID").ToString()}))
            i = i + 1

            staffcert = ""
        Next
        Label4.Text = "'" + i.ToString() + "'"
        Label6.Text = "'" + j.ToString() + "'"
        AddHandler ESComboBox.SelectedIndexChanged, AddressOf ESComboBox_SelectedIndexChanged
        AddHandler gradeComboBox.SelectedIndexChanged, AddressOf ESComboBox_SelectedIndexChanged
        AddHandler unitComboBox.SelectedIndexChanged, AddressOf ESComboBox_SelectedIndexChanged
        AddHandler certComboBox.SelectedIndexChanged, AddressOf ESComboBox_SelectedIndexChanged

        ListView1.Columns(6).Width = 0
        Try
            printerdcert = printerdcert.Remove(0, 1)
        Catch
        End Try

    End Sub


    Private Sub ESComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        For Each row As ListViewItem In ListView1.Items
            ListView1.Items.Remove(row)
        Next
        printerdcert = ""
        Dim i As Integer = 0
        Dim j As Integer = 0
        For Each dr As DataRow In staffdt.Rows
            If Not dr("CERT_C").Equals("L") Then
                staffcert = staffcert + "," + dr("CERT_C").ToString()

            End If
            If Not dr("CERT_N").Equals("L") Then
                staffcert = staffcert + "," + dr("CERT_N").ToString()

            End If
            If Not dr("CERT_S").Equals("L") Then
                staffcert = staffcert + "," + dr("CERT_S").ToString()

            End If
            If Not dr("CERT_D").Equals("L") Then
                staffcert = staffcert + "," + dr("CERT_D").ToString()

            End If

            staffcert = staffcert.Remove(0, 1)

            Dim system As String = ""
            Dim es As Boolean = False
            For Each drr As DataRow In relatdt.Rows
                If drr("STAFFID").Equals(dr("STAFFID").ToString()) Then
                    system = system + "," + systemdt.Rows.Find(New Object(0) {drr("SYSTEMID")})(1)
                End If
            Next
            system = system.Remove(0, 1)
            If (dr("GRADE").ToString().Equals(gradeComboBox.Text) Or gradeComboBox.Text.Equals("---All---")) And (dr("UNIT").ToString().Equals(unitComboBox.Text) Or unitComboBox.Text.Equals("---All---")) And (dr("CERT_C").ToString().Substring(0, 1).Equals(certComboBox.Text) Or dr("CERT_N").ToString().Substring(0, 1).Equals(certComboBox.Text) Or dr("CERT_S").ToString().Substring(0, 1).Equals(certComboBox.Text) Or dr("CERT_D").ToString().Substring(0, 1).Equals(certComboBox.Text) Or certComboBox.Text.Equals("---All---")) Then
                For Each s As String In system.Split(",")
                    If s.Equals(ESComboBox.Text) Or ESComboBox.Text.Equals("---All---") Then
                        ListView1.Items.Add(New ListViewItem(New String(6) {dr("STAFFNAME").ToString(), dr("STAFFNO_").ToString(), staffcert, dr("GRADE").ToString(), dr("UNIT").ToString(), system, dr("STAFFID").ToString()}))
                        i = i + 1
                        printerdcert = printerdcert + "," + staffcert
                        For Each ss As String In staffcert.Split(",")
                            j = j + 1
                        Next
                        Exit For
                    End If
                Next
            End If

            staffcert = ""
        Next
        Label4.Text = "'" + i.ToString() + "'"
        Label6.Text = "'" + j.ToString() + "'"
        Try
            printerdcert = printerdcert.Remove(0, 1)
        Catch
        End Try

    End Sub

    Private Sub searchTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles searchTextBox.TextChanged
        Dim foundItem As ListViewItem = ListView1.FindItemWithText(searchTextBox.Text, True, 0, True)
        If (foundItem IsNot Nothing) Then
            ListView1.TopItem = foundItem
            ListView1.HideSelection = False
            foundItem.Selected = True
            foundItem.Checked = True
        End If

    End Sub

    Private Sub printallButton_Click(sender As System.Object, e As System.EventArgs) Handles printallButton.Click
        Dim reportlist As List(Of REPORT) = New List(Of REPORT)
        Dim rvp As ReportviewerPage = New ReportviewerPage()
        Dim certname As String = ""
        rvp.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local

        rvp.ReportViewer1.LocalReport.DataSources.Clear()


        For Each dr As DataRow In certtable.Rows
            If Not dr(4) Then
                Select Case dr(7)
                    Case "C"
                        certname = "Communication"
                    Case "N"
                        certname = "Navigation"
                    Case "S"
                        certname = "Surveillance"
                    Case "D"
                        certname = "Data Processing"
                End Select
                reportlist.Add(New REPORT() With { _
                .CERT_NO_ = "C" + dr(1) + dr(0), _
                .CREATDATE = dr(2), _
                .LV = "test", _
                .STAFFNAME = dr(6), _
                .STAFFNO_ = dr(5), _
                .SYSTEMNAME = certname _
                           })


            End If
        Next

        rvp.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("REPORT", reportlist))
        rvp.ReportViewer1.LocalReport.ReportEmbeddedResource = "ATSEP.Report5.rdlc"


        rvp.ReportViewer1.LocalReport.Refresh()
        rvp.ReportViewer1.RefreshReport()


        rvp.Show()
        If MessageBox.Show("Ensure you have printed?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            For Each dr As DataRow In certtable.Rows
                If Not dr(4) Then
                    dr(4) = True
                End If

            Next
        End If
    End Sub


    Private Sub StaffNameCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs)

        ishide = True

        If Not StaffNameCheckBox.Checked Then
            ListView1.Columns(0).Width = 0
        Else
            ListView1.Columns(0).Width = Convert.ToInt32(listwidth.Split(",")(0))
        End If
        If Not CertTypeCheckBox.Checked Then
            ListView1.Columns(2).Width = 0
        Else
            ListView1.Columns(2).Width = Convert.ToInt32(listwidth.Split(",")(2))
        End If
        If Not UnitCheckBox.Checked Then
            ListView1.Columns(4).Width = 0
        Else
            ListView1.Columns(4).Width = Convert.ToInt32(listwidth.Split(",")(4))
        End If
        If Not SystemCheckBox.Checked Then
            ListView1.Columns(5).Width = 0
        Else
            ListView1.Columns(5).Width = Convert.ToInt32(listwidth.Split(",")(5))
        End If
        If Not StaffNumberCheckBox.Checked Then
            ListView1.Columns(1).Width = 0
        Else
            ListView1.Columns(1).Width = Convert.ToInt32(listwidth.Split(",")(1))
        End If
        If Not GradeCheckBox.Checked Then
            ListView1.Columns(3).Width = 0
        Else
            ListView1.Columns(3).Width = Convert.ToInt32(listwidth.Split(",")(3))
        End If
        ishide = False
    End Sub



    Private Sub ListView1_ColumnWidthChanging(sender As System.Object, e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles ListView1.ColumnWidthChanging
        If Not ishide Then
            e.Cancel = True
            e.NewWidth = Convert.ToInt32(listwidth.Split(",")(e.ColumnIndex))
            ishide = False
        End If

    End Sub

    Private Sub ListView1_ColumnWidthChanged(sender As System.Object, e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles ListView1.ColumnWidthChanged
        listwidth = listwidth + ListView1.Columns(e.ColumnIndex).Width.ToString() + ","
        If e.ColumnIndex = 6 Then
            RemoveHandler ListView1.ColumnWidthChanged, AddressOf ListView1_ColumnWidthChanged
            AddHandler StaffNameCheckBox.CheckedChanged, AddressOf StaffNameCheckBox_CheckedChanged
            AddHandler UnitCheckBox.CheckedChanged, AddressOf StaffNameCheckBox_CheckedChanged
            AddHandler SystemCheckBox.CheckedChanged, AddressOf StaffNameCheckBox_CheckedChanged
            AddHandler StaffNumberCheckBox.CheckedChanged, AddressOf StaffNameCheckBox_CheckedChanged
            AddHandler GradeCheckBox.CheckedChanged, AddressOf StaffNameCheckBox_CheckedChanged
            AddHandler CertTypeCheckBox.CheckedChanged, AddressOf StaffNameCheckBox_CheckedChanged

        End If
    End Sub

    Private Sub printButton_Click(sender As System.Object, e As System.EventArgs) Handles printButton.Click
        Dim reportlist As List(Of StaffInfoClass) = New List(Of StaffInfoClass)


        Dim rvp As ReportviewerPage = New ReportviewerPage()
        reportlist = New List(Of StaffInfoClass)

        rvp.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local


        rvp.ReportViewer1.LocalReport.DataSources.Clear()
        For Each dr As ListViewItem In ListView1.Items

            reportlist.Add(New StaffInfoClass() With { _
            .Cert_ = dr.SubItems(2).Text, _
            .Certshow_ = CertTypeCheckBox.Checked, _
            .Grade_ = dr.SubItems(3).Text, _
            .Gradeshow_ = GradeCheckBox.Checked, _
            .Staffnameshow_ = StaffNameCheckBox.Checked, _
            .Staffname_ = dr.SubItems(0).Text, _
            .Staffnumber_ = dr.SubItems(1).Text, _
            .Staffnumbershow_ = StaffNumberCheckBox.Checked, _
            .Unit_ = dr.SubItems(4).Text, _
            .Unitshow_ = UnitCheckBox.Checked, _
            .Systemshow_ = SystemCheckBox.Checked, _
            .System_ = dr.SubItems(5).Text _
                       })



        Next
        rvp.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("StaffInfo", reportlist))
        rvp.ReportViewer1.LocalReport.ReportEmbeddedResource = "ATSEP.Report3.rdlc"


        rvp.ReportViewer1.LocalReport.Refresh()
        rvp.ReportViewer1.RefreshReport()


        rvp.Show()

    End Sub

    Private Sub printcertButton_Click(sender As System.Object, e As System.EventArgs) Handles printcertButton.Click
        Dim certnumber As String = ""
        Dim certname As String = ""

        For Each row As ListViewItem In ListView1.Items
            If row.Selected Then
                If Not staffdt.Rows.Find(New Object(0) {row.SubItems(6).Text})(7).Equals("L") Then
                    certnumber = certnumber + "," + staffdt.Rows.Find(New Object(0) {row.SubItems(6).Text})(7)
                End If
                If Not staffdt.Rows.Find(New Object(0) {row.SubItems(6).Text})(8).Equals("L") Then
                    certnumber = certnumber + "," + staffdt.Rows.Find(New Object(0) {row.SubItems(6).Text})(8)
                End If
                If Not staffdt.Rows.Find(New Object(0) {row.SubItems(6).Text})(9).Equals("L") Then
                    certnumber = certnumber + "," + staffdt.Rows.Find(New Object(0) {row.SubItems(6).Text})(9)
                End If
                If Not staffdt.Rows.Find(New Object(0) {row.SubItems(6).Text})(10).Equals("L") Then
                    certnumber = certnumber + "," + staffdt.Rows.Find(New Object(0) {row.SubItems(6).Text})(10)
                End If
            End If
        Next
        If certnumber.Equals("") Then
            MessageBox.Show("you haven't select any staff")
            Return
        End If
        certnumber = certnumber.Remove(0, 1)

        Dim reportlist As List(Of REPORT) = New List(Of REPORT)


        Dim rvp As ReportviewerPage = New ReportviewerPage()

        rvp.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local


        rvp.ReportViewer1.LocalReport.DataSources.Clear()
        For Each s As String In certnumber.Split(",")

            Select Case certtable.Rows.Find(New Object(0) {s})(7)
                Case "C"
                    certname = "Communication"
                Case "N"
                    certname = "Navigation"
                Case "S"
                    certname = "Surveillance"
                Case "D"
                    certname = "Data Processing"
            End Select

            reportlist.Add(New REPORT() With { _
.CERT_NO_ = certtable.Rows.Find(New Object(0) {s})(1) + certtable.Rows.Find(New Object(0) {s})(0), _
.CREATDATE = certtable.Rows.Find(New Object(0) {s})(2), _
.LV = "test", _
.STAFFNAME = certtable.Rows.Find(New Object(0) {s})(6), _
.STAFFNO_ = certtable.Rows.Find(New Object(0) {s})(5), _
.SYSTEMNAME = certname _
           })
        Next
        rvp.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("REPORT", reportlist))
        rvp.ReportViewer1.LocalReport.ReportEmbeddedResource = "ATSEP.Report5.rdlc"


        rvp.ReportViewer1.LocalReport.Refresh()
        rvp.ReportViewer1.RefreshReport()


        rvp.Show()
    End Sub

    Private Sub ListView1_ItemSelectionChanged(sender As System.Object, e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged
        ContextMenuStrip1.Items(0).Enabled = False
        ContextMenuStrip1.Items(1).Enabled = False
        ContextMenuStrip1.Items(2).Enabled = False
        ContextMenuStrip1.Items(3).Enabled = False
        If ListView1.SelectedItems.Count <> 0 And ListView1.SelectedItems.Count = 1 Then
            For Each s As String In e.Item.SubItems(2).Text.Split(",")
                If s.Substring(0, 1).Equals("C") Then
                    ContextMenuStrip1.Items(0).Enabled = True
                    ContextMenuStrip1.Items(0).Tag = s
                End If
                If s.Substring(0, 1).Equals("N") Then
                    ContextMenuStrip1.Items(1).Enabled = True
                    ContextMenuStrip1.Items(1).Tag = s
                End If
                If s.Substring(0, 1).Equals("S") Then
                    ContextMenuStrip1.Items(2).Enabled = True
                    ContextMenuStrip1.Items(2).Tag = s
                End If
                If s.Substring(0, 1).Equals("D") Then
                    ContextMenuStrip1.Items(3).Enabled = True
                    ContextMenuStrip1.Items(3).Tag = s
                End If
            Next

        End If

    End Sub

    Private Sub ContextMenuStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        Dim pdfv As PDFviewer = New PDFviewer()
        pdfv.AxAcroPDF1.LoadFile("\\10.100.50.113\softwareunit\temp\ATSEP_2\CERT\" + e.ClickedItem.Tag + "Report.pdf")
        pdfv.ShowDialog()
    End Sub

    Private Sub applycertButton_Click(sender As System.Object, e As System.EventArgs) Handles applycertButton.Click
        If MessageBox.Show("Ensure?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim cs As String = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\10.100.50.113\softwareunit\temp\ATSEP_DB.mdb;Jet OLEDB:Engine Type=5")
            Dim cn As OleDb.OleDbConnection = New OleDb.OleDbConnection(cs)
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("select * from [CERT]", cn)
            da.Fill(ds, "[CERT]")
            Dim key() As DataColumn = New DataColumn() {ds.Tables("[CERT]").Columns("CERT_NO")}
            ds.Tables("[CERT]").PrimaryKey = key
            Try
                For Each s As String In printerdcert.Split(",")
                    If s.Substring(0, 1).Equals(certComboBox.Text) Or certComboBox.Text.Equals("---All---") Then
                        ds.Tables("[CERT]").Rows.Find(New Object(0) {s})(4) = True
                    End If
                Next
            Catch
                MessageBox.Show("No any cert can apply!")
            End Try
            Dim tu As TableUpdate = New TableUpdate()
            tu.update(cn, da, ds, "[CERT]")
        End If
    End Sub
End Class