Imports System.Data.OleDb
Imports System.Windows.Forms
Public Class Form1
    Dim cm As OleDbCommand
    Dim cn As OleDbConnection
    Dim da(19) As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim tp(8) As TabPage
    Dim dv As DataView
    Dim tpgostructuie(8) As Integer
    Dim tpbackstructuie(8) As Integer
    Dim isgojti As Boolean = False
    Dim isaojti As Boolean = False
    Dim isae As Boolean = False
    Dim isca As Boolean = False
    Dim owncert As String = ""
    Dim rtb(13) As RichTextBox
    Dim chb(13) As CheckBox
    Public cert As String = ""
    Public systemunit As String
    Private rowIndex As Integer = 0
    Dim dt(19) As DataTable
    Dim systemid() As String
    Dim tablename(19) As String
    Dim isnewrow As Boolean = False
    Dim reportnum As String = ""
    Dim certname As String = ""
    Dim s2ObjectId As String = ""
    Dim owns2k4ObjectId As String = ""
    Public ismultlv As Boolean = False
    Public ownsystemid As String = ""
    Public name2 As String = ""
    Public name3 As String = ""
    Public staffnub As String = ""
    Public grade As String = ""
    Public staffid As String = ""
    Public syscount As Integer
    Public s2icao As String = ""
    Public s2sys As String = ""
    Public s3dec As String = ""
    Public s3cri As String = ""
    Public s3type As String = ""
    Public s4dec As String = ""
    Public s4cri As String = ""
    Public s4type As String = ""
    Public s5dec As String = ""
    Public s5cri As String = ""
    Public s5type As String = ""
    Public userP As String = ""
    Public userName As String = ""
    Public OJTISys As String = ""
    Public userclose As Boolean = True
    Public ownLV As String = ""
    Public relationid As String = ""
    Public isreportcomplete As Boolean = False



    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            '           MapNetworkDriver.MapNetworkDrive("\\10.100.50.113\", "T", False, "mcchow", "hau314")
        Catch ex As Exception
            '          MessageBox.Show(ex.Message)
        End Try
        '   Dim di As IO.DirectoryInfo = New IO.DirectoryInfo("\\10.100.50.113\softwareunit\temp\")
        '    di.GetFiles("ATSEP_DB.mdb")
        Me.Hide()
        Dim login As loginform = New loginform
        login.ShowDialog()
        If userclose Then
            Me.Close()
        End If

        If userP.Equals("3") Then
            isgojti = True
        End If
        If userP.Equals("4") Then
            isae = True
            viewstaffButton.Enabled = True
            completedButton.Enabled = True
            ENDORSEDbutton.Enabled = True
        End If
        If userP.Equals("2") Then
            isca = True
            signButton.Enabled = True
        End If
        If userP.Equals("5") Then
            isca = True
            isae = True
            isgojti = True
            viewstaffButton.Enabled = True
            completedButton.Enabled = True
            print.Enabled = True

        End If
        'setting the sequence of the section page. 2, 5, 3, 4, 1

        Dim cs As String = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.100.50.225\caelan_2\Temp\ATSEP_DB.accdb;Jet OLEDB:Engine Type=5")
        Dim key() As DataColumn
        cn = New OleDbConnection(cs)

        da(0) = New OleDbDataAdapter("select * from [S1_COM_VERIF]", cn)
        da(0).Fill(ds, "[S1_COM_VERIF]")
        tablename(0) = "[S1_COM_VERIF]"
        key = New DataColumn(0) {New DataColumn()}
        key(0) = ds.Tables("[S1_COM_VERIF]").Columns("ObjectID")
        ds.Tables("[S1_COM_VERIF]").PrimaryKey = key

        ''''
        da(1) = New OleDbDataAdapter("select * from [S1_DESC]", cn)
        da(1).Fill(ds, "[S1_DESC]")
        tablename(1) = "[S1_DESC]"

        da(2) = New OleDbDataAdapter("select * from [S3_COMMENTS]", cn)
        da(2).Fill(ds, "[S3_COMMENTS]")
        key = New DataColumn(0) {New DataColumn()}
        key(0) = ds.Tables("[S3_COMMENTS]").Columns("ObjectID")
        ds.Tables("[S3_COMMENTS]").PrimaryKey = key
        tablename(2) = "[S3_COMMENTS]"

        da(3) = New OleDbDataAdapter("select * from [S5_DESC]", cn)
        da(3).Fill(ds, "[S5_DESC]")
        key = New DataColumn(0) {New DataColumn()}
        key(0) = ds.Tables("[S5_DESC]").Columns("ObjectID")
        ds.Tables("[S5_DESC]").PrimaryKey = key
        tablename(3) = "[S5_DESC]"

        da(4) = New OleDbDataAdapter("select * from [S4_GUIDELINE]", cn)
        da(4).Fill(ds, "[S4_GUIDELINE]")
        key = New DataColumn(0) {New DataColumn()}
        key(0) = ds.Tables("[S4_GUIDELINE]").Columns("ObjectID")
        ds.Tables("[S4_GUIDELINE]").PrimaryKey = key
        tablename(4) = "[S4_GUIDELINE]"

        da(5) = New OleDbDataAdapter("select * from [S4_DESC]", cn)
        da(5).Fill(ds, "[S4_DESC]")
        key = New DataColumn(0) {New DataColumn()}
        key(0) = ds.Tables("[S4_DESC]").Columns("ObjectID")
        ds.Tables("[S4_DESC]").PrimaryKey = key
        tablename(5) = "[S4_DESC]"

        da(6) = New OleDbDataAdapter("select * from [S5_DESC]", cn)
        da(6).Fill(ds, "[S5_DESC]")
        tablename(6) = "[S5_DESC]"
        key = New DataColumn(0) {New DataColumn()}
        key(0) = ds.Tables("[S5_DESC]").Columns("ObjectID")
        ds.Tables("[S5_DESC]").PrimaryKey = key


        da(7) = New OleDbDataAdapter("select * from [S5_OJTI]", cn)
        da(7).Fill(ds, "[S5_OJTI]")
        tablename(7) = "[S5_OJTI]"
        key = New DataColumn(0) {New DataColumn()}
        key(0) = ds.Tables("[S5_OJTI]").Columns("ObjectID")
        ds.Tables("[S5_OJTI]").PrimaryKey = key


        da(8) = New OleDbDataAdapter("select * from [S6_REVIEW]", cn)
        da(8).Fill(ds, "[S6_REVIEW]")
        tablename(8) = "[S6_REVIEW]"



        da(9) = New OleDbDataAdapter("select * from [STAFF_INFO]", cn)
        da(9).Fill(ds, "[STAFF_INFO]")
        key = New DataColumn(0) {New DataColumn}
        key(0) = ds.Tables("[STAFF_INFO]").Columns("STAFFID")
        ds.Tables("[STAFF_INFO]").PrimaryKey = key
        tablename(9) = "[STAFF_INFO]"


        da(10) = New OleDbDataAdapter("select * from [SYSTEM_INFO]", cn)
        da(10).Fill(ds, "[SYSTEM_INFO]")
        key = New DataColumn(0) {New DataColumn}
        key(0) = ds.Tables("[SYSTEM_INFO]").Columns("SYSTEMID")
        ds.Tables("[SYSTEM_INFO]").PrimaryKey = key
        tablename(10) = "[SYSTEM_INFO]"

        da(11) = New OleDbDataAdapter("select * from [RELATION]", cn)
        da(11).Fill(ds, "[RELATION]")
        tablename(11) = "[RELATION]"
        key = New DataColumn(0) {New DataColumn}
        key(0) = ds.Tables("[RELATION]").Columns("ObjectId")
        ds.Tables("[RELATION]").PrimaryKey = key
        tablename(11) = "[RELATION]"

        da(12) = New OleDbDataAdapter("select * from [SAMPLE_QUESTION]", cn)
        da(12).Fill(ds, "[SAMPLE_QUESTION]")
        key = New DataColumn(0) {New DataColumn}
        key(0) = ds.Tables("[SAMPLE_QUESTION]").Columns("ObjectID")
        ds.Tables("[SAMPLE_QUESTION]").PrimaryKey = key
        tablename(12) = "[SAMPLE_QUESTION]"

        da(13) = New OleDbDataAdapter("select * from [S2_ICAO]", cn)
        da(13).Fill(ds, "[S2_ICAO]")
        key = New DataColumn(0) {New DataColumn}
        key(0) = ds.Tables("[S2_ICAO]").Columns("ObjectID")
        ds.Tables("[S2_ICAO]").PrimaryKey = key
        tablename(13) = "[S2_ICAO]"

        da(14) = New OleDbDataAdapter("select * from [S2_SYS2]", cn)
        da(14).Fill(ds, "[S2_SYS2]")
        key(0) = ds.Tables("[S2_SYS2]").Columns("ObjectID")
        ds.Tables("[S2_SYS2]").PrimaryKey = key
        tablename(14) = "[S2_SYS2]"

        da(15) = New OleDbDataAdapter("select * from [S2_SYS_SAMPLE]", cn)
        da(15).Fill(ds, "[S2_SYS_SAMPLE]")
        key(0) = ds.Tables("[S2_SYS_SAMPLE]").Columns("ObjectID")
        ds.Tables("[S2_SYS_SAMPLE]").PrimaryKey = key
        tablename(15) = "[S2_SYS_SAMPLE]"

        da(16) = New OleDbDataAdapter("select * from [CA_INFO]", cn)
        da(16).Fill(ds, "[CA_INFO]")
        key(0) = ds.Tables("[CA_INFO]").Columns("ObjectID")
        ds.Tables("[CA_INFO]").PrimaryKey = key
        tablename(16) = "[CA_INFO]"

        da(17) = New OleDbDataAdapter("select * from [CA_STAFF]", cn)
        da(17).Fill(ds, "[CA_STAFF]")
        key(0) = ds.Tables("[CA_STAFF]").Columns("ObjectID")
        ds.Tables("[CA_STAFF]").PrimaryKey = key
        tablename(17) = "[CA_STAFF]"

        da(19) = New OleDbDataAdapter("select * from [CERT]", cn)
        da(19).Fill(ds, "[CERT]")
        key(0) = ds.Tables("[CERT]").Columns("CERT_NO")
        ds.Tables("[CERT]").PrimaryKey = key
        tablename(19) = "[CERT]"

        da(18) = New OleDbDataAdapter("select * from [REPORT]", cn)
        da(18).Fill(ds, "[REPORT]")
        key(0) = ds.Tables("[REPORT]").Columns("S2ObjectId")
        ds.Tables("[REPORT]").PrimaryKey = key
        tablename(18) = "[REPORT]"
        TabControl1.TabPages.Remove(S1TabPage)
        TabControl1.TabPages.Remove(S2TabPage)
        TabControl1.TabPages.Remove(S3TabPage)
        TabControl1.TabPages.Remove(S4TabPage)
        TabControl1.TabPages.Remove(S5TabPage)
        TabControl1.Visible = False
        Me.WindowState = FormWindowState.Maximized
        Me.Show()
        ' Dim pdfv As PDFviewer = New PDFviewer()
        ' pdfv.AxAcroPDF1.LoadFile("C:\Users\SAMSUNG\Desktop\Report5.pdf")
        ' pdfv.ShowDialog()

    End Sub

    'Find Name button
    Private Sub FIND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIND.Click
        Try
            Dim f2 As Form2 = New Form2()
            f2.staffinfo = (ds.Tables("[STAFF_INFO]"))
            f2.ShowDialog()
            StaffNoTextBox.Text = staffnub
            NameTextBox.Text = name2
            TextBox4.Text = grade
            TextBox2.Text = name2

        Catch
        End Try
    End Sub
    'Find System button
    Private Sub FIND2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIND2.Click
        Dim i As Integer = 0
        ReDim systemid(syscount - 1)
        TabControl1.TabPages.Remove(S1TabPage)
        TabControl1.TabPages.Remove(S2TabPage)
        TabControl1.TabPages.Remove(S3TabPage)
        TabControl1.TabPages.Remove(S5TabPage)
        Dim f3 As Form3 = New Form3()
        For Each dr As DataRow In ds.Tables("[RELATION]").Rows
            If dr("STAFFID").ToString() = staffid Then

                systemid(i) = dr("SYSTEMID").ToString() + "," + dr("LV") + "," + dr("ObjectiD").ToString()
                i = i + 1
            End If

        Next

        'form 3

        f3.systeminfo = ds.Tables("[SYSTEM_INFO]")
        f3.relation = ds.Tables("[RELATION]")
        ReDim f3.systemid(systemid.Length)
        f3.systemid = systemid
        f3.staffid = staffid
        f3.report = ds.Tables("[REPORT]")
        f3.staffinfo = ds.Tables("[STAFF_INFO]")
        f3.ShowDialog()
        Dim tu As TableUpdate = New TableUpdate()
        tu.update(cn, da(11), ds, tablename(11))
        tu.update(cn, da(18), ds, tablename(18))
        tu.update(cn, da(9), ds, tablename(9))
        If Not f3.endedit Then
            Return
        End If
        Dim name() As String
        If Not ismultlv Then
            name = New String(8) {"Safety and Precaution", "System Knowledge", "Instrumentation", "System Monitoring", "Preventive Maintenance", "System Health", "System Diagnosis", "Documentation", "Communication"}
        Else
            name = New String(15) {"Safety and Precaution", "System Knowledge", "Contingency/Backup", "Circuitry Understanding", "Conversant Detailed", "Approprite Test Instruments", "Specialized Tools", "Data Interpretaion", "Tuning/Adjustment", "Advanced System Command", "Level Of Conversant", "Interpretation Messages", "Fault Techniques", "Work Efficiency", "Report Writing Skill", "Paties Concerned"}

        End If

        tpgostructuie(2) = 5
        tpgostructuie(5) = 3
        tpgostructuie(3) = 4
        tpgostructuie(4) = 1

        tpbackstructuie(1) = 4
        tpbackstructuie(4) = 3
        tpbackstructuie(3) = 5
        tpbackstructuie(5) = 2

        tp(0) = S1TabPage
        tp(1) = S2TabPage
        tp(2) = S3TabPage
        tp(3) = S4TabPage
        tp(4) = S5TabPage


        If userP.Equals("3") Then
            For Each s As String In OJTISys.Split(",")
                If s = ownsystemid Then
                    isaojti = True
                End If
            Next
        End If
        owncert = "NO"
        For Each s As String In cert.Split(",")
            Try
                If s.Substring(0, 1).Equals(systemunit) Then
                    owncert = s
                End If
            Catch ex As Exception
            End Try
        Next

        SYSTextBox.Text = name3
        TabControl1.Visible = True

        TabControl1.TabPages.Add(S1TabPage)
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''initialize S4
        dt(1) = New DataTable()
        dt(1).Columns.AddRange(New DataColumn(8) {New DataColumn(S3Grid1.Columns(0).HeaderText),
                                                  New DataColumn(S3Grid1.Columns(1).HeaderText),
                                                  New DataColumn(S3Grid1.Columns(2).HeaderText),
                                                  New DataColumn(S3Grid1.Columns(3).HeaderText),
                                                  New DataColumn("CA Comments/Remarks"),
                                                  New DataColumn(S3Grid1.Columns(5).HeaderText),
                                                  New DataColumn(S3Grid1.Columns(6).HeaderText),
                                                  New DataColumn(),
                                                 New DataColumn()})

        Dim name1() As String = New String(8) {"Safety and Precaution", "System Knowledge", "Instrumentation", "System Monitoring", "Preventive Maintenance", "System Health", "System Diagnosis", "Documentation", "Communication"}

        For Each dr As DataRow In ds.Tables("[S4_DESC]").Rows
            Dim drRow As DataRow = dt(1).NewRow()
            If (dr("SYSTEMID").ToString() = ownsystemid) Then
                drRow(1) = name(dr("TYPE") - 1)
                drRow(0) = "C" + dr("TYPE")
                drRow(2) = dr("DESCRIPTION")
                drRow(3) = dr("CRITERIA")
                drRow(4) = ""
                drRow(5) = dr("SYSTEMID")
                drRow(6) = dr("ObjectID")
                drRow(8) = dr("TYPE")

                dt(1).Rows.Add(drRow)
            End If
        Next
        Dim dc1 As DataColumn() = New DataColumn(0) {New DataColumn()}
        dc1(0) = dt(1).Columns(6)
        dt(1).PrimaryKey = dc1
        Try
            For Each dr As DataRow In ds.Tables("[S4_GUIDELINE]").Rows

                dt(1).Rows.Find(New Object(0) {dr("DESCID")})(4) = dr("GUIDELINE")
                dt(1).Rows.Find(New Object(0) {dr("DESCID")})(7) = dr("ObjectID")
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        dv = New DataView(dt(1))
        dv.Sort = dt(1).Columns(8).ColumnName + " ASC"
        TabControl1.TabPages.Add(S4TabPage)
        dt(1) = dv.ToTable()
        dt(1).AcceptChanges()
        DataGridView2.Columns.Clear()
        DataGridView2.DataSource = dt(1)
        DataGridView2.Columns(5).Visible = False
        DataGridView2.Columns(6).Visible = False
        DataGridView2.Columns(7).Visible = False
        DataGridView2.Columns(8).Visible = False
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        TabControl1.SelectedTab = S4TabPage


        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''initialize S5
        dt(2) = New DataTable()
        dt(2).Columns.AddRange(New DataColumn(8) {
                                                  New DataColumn("Number"),
                                                  New DataColumn("Competence Type"),
                                                  New DataColumn("Competence Description"),
                                                  New DataColumn("Performance Criteria"),
                                                  New DataColumn("OJTI Comments/Remarks"),
                                                  New DataColumn(S3Grid1.Columns(5).HeaderText),
                                                  New DataColumn(S3Grid1.Columns(6).HeaderText),
                                                  New DataColumn(),
                                                 New DataColumn()
                                                 })
        dt(2).Columns(8).DataType = GetType(Integer)
        Dim name2() As String = New String(8) {"Safety and Precaution", "System Knowledge", "Instrumentation", "System Monitoring", "Preventive Maintenance", "System Health", "System Diagnosis", "Documentation", "Communication"}

        For Each dr As DataRow In ds.Tables("[S5_DESC]").Rows
            Dim drRow As DataRow = dt(2).NewRow()
            If (dr("SYSTEMID").ToString() = ownsystemid) Then
                drRow(1) = name(dr("TYPE") - 1)
                drRow(0) = "C" + dr("TYPE")
                drRow(2) = dr("DESCRIPTION")
                drRow(3) = dr("CRITERIA")
                drRow(4) = ""
                drRow(5) = dr("SYSTEMID")
                drRow(6) = dr("ObjectID")
                drRow(8) = dr("TYPE")
                dt(2).Rows.Add(drRow)
            End If
        Next

        Dim dc2 As DataColumn() = New DataColumn(0) {New DataColumn()}
        dc2(0) = dt(2).Columns(6)
        dt(2).PrimaryKey = dc2
        Try
            For Each dr As DataRow In ds.Tables("[S5_OJTI]").Rows
                If dr("STAFFID") = staffid Then
                    dt(2).Rows.Find(New Object(0) {dr("DESCID")})(4) = dr("COMMENTS")
                    dt(2).Rows.Find(New Object(0) {dr("DESCID")})(7) = dr("ObjectID")
                End If

            Next
            'Dim now As Integer = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        dv = New DataView(dt(2))
        dv.Sort = dt(2).Columns(8).ColumnName + " ASC"
        dt(2) = dv.ToTable()
        dt(2).AcceptChanges()
        TabControl1.TabPages.Add(S5TabPage)
        'DataGridView3.Sort(DataGridView3.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        S5Grid1.Columns.Clear()
        S5Grid1.DataSource = dt(2)
        S5Grid1.Columns(5).Visible = False
        S5Grid1.Columns(6).Visible = False
        S5Grid1.Columns(7).Visible = False
        S5Grid1.Columns(8).Visible = False
        S5Grid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        S5Grid1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        S5Grid1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        TabControl1.SelectedTab = S5TabPage
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        'initialize(S3)
        '     Try

        '     Catch
        '  
        '   End Try
        dt(0) = dt(2).Clone()


        For Each dr As DataRow In dt(2).Rows
            dt(0).ImportRow(dr)
        Next
        dc2 = New DataColumn(0) {New DataColumn()}
        dc2(0) = dt(2).Columns(6)
        dt(2).PrimaryKey = dc2
        Dim dc As DataColumn() = New DataColumn(0) {New DataColumn()}
        dc(0) = dt(0).Columns(6)
        dt(0).PrimaryKey = dc
        Try
            For Each dr As DataRow In ds.Tables("[S3_COMMENTS]").Rows
                If dr("STAFFID") = staffid Then
                    dt(0).Rows.Find(New Object(0) {dr("DESCID")})(4) = dr("COMMENTS")
                    dt(0).Rows.Find(New Object(0) {dr("DESCID")})(7) = dr("ObjectID")
                End If
            Next
            'Dim now As Integer = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        dv = New DataView(dt(0))
        dv.Sort = dt(0).Columns(8).ColumnName + " ASC"
        dt(0) = dv.ToTable()
        dt(0).AcceptChanges()
        TabControl1.TabPages.Add(S3TabPage)
        S3Grid1.Columns.Clear()
        S3Grid1.DataSource = dt(0)

        S3Grid1.Columns(5).Visible = False
        S3Grid1.Columns(6).Visible = False
        S3Grid1.Columns(7).Visible = False
        S3Grid1.Columns(8).Visible = False
        S3Grid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        S3Grid1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        S3Grid1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        TabControl1.SelectedTab = S3TabPage
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''initialize S2_ICAO
        dt(3) = New DataTable()
        dt(3).Columns.AddRange(New DataColumn(7) {
                                                 New DataColumn("ObjectID"),
                                                 New DataColumn("TYPE"),
                                                 New DataColumn("ICAO Number"),
                                                 New DataColumn("Completed Training Description"),
                                                 New DataColumn("(Y/N)"),
                                                 New DataColumn("CLASS"),
                                                 New DataColumn("DATE"),
                                             New DataColumn()})
        dt(3).Columns(4).DataType = GetType(Boolean)

        'New DataColumn(DataGridView9.Columns(5).HeaderText),
        'New DataColumn(DataGridView9.Columns(6).HeaderText)})

        Dim nameS2_ICAO() As String = New String(3) {"Completed Basic Training", "Completed Qualification Training", "Completed System Safety Training", "Completed Equipment Rating Training (L1/L2)"}

        For Each dr As DataRow In ds.Tables("[S2_ICAO]").Rows
            Dim drRow As DataRow = dt(3).NewRow()
            'If (dr("SYSTEMID").ToString() = ownsystemid) Then
            'drRow(2) = dr("DESCRIPTION")
            'drRow(3) = dr("CRITERIA")
            drRow(0) = dr("ObjectID")
            drRow(1) = dr("TYPE")
            drRow(2) = dr("ICAO_NO_")
            drRow(3) = dr("DESCRIPTION")
            'drRow(5) = dr("SYSTEMID")
            dt(3).Rows.Add(drRow)
            ' End If
        Next
        Dim key(0) As DataColumn
        key(0) = dt(3).Columns(2)
        dt(3).PrimaryKey = key
        TabControl1.TabPages.Add(S2TabPage)
        S2Grid.Columns.Clear()
        S2Grid.DataSource = dt(3)

        S2Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        S2Grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        S2Grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        For Each ii As DataGridViewColumn In S2Grid.Columns
            ii.SortMode = False
        Next
        dv = New DataView(dt(3))
        dv.Sort = dt(3).Columns(0).ColumnName + " DESC"
        S2Grid.Sort(S2Grid.Columns(0), System.ComponentModel.ListSortDirection.Descending)

        TabControl1.SelectedTab = S2TabPage
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''initialize S2_SYS
        dt(4) = New DataTable()

        dt(4).Columns.AddRange(New DataColumn(6) {New DataColumn("ObjectID"),
                                                 New DataColumn("TYPE"),
                                                 New DataColumn("Description"),
                                                 New DataColumn("(Y/N)"),
                                                 New DataColumn("CLASS"),
                                                 New DataColumn("DATE"),
        New DataColumn("Level")
                                                 })
        dt(4).Columns(0).ColumnName = "objectid"
        dt(4).Columns(3).DataType = GetType(Boolean) ' change column type to boolean'
        'dt(4).Columns(6).DataType = GetType(DataGridViewComboBoxColumn)

        'Dim nameS2_SYS() As String = New String(3) {"Completed Basic Training", "Completed Qualification Training", "Completed System Safety Training", "Completed Equipment Rating Training (L1/L2)"}
        Dim keys() As Object = New Object(0) {New Object()}

        dc = New DataColumn(0) {New DataColumn()}
        dc(0) = dt(3).Columns(2)
        dt(3).PrimaryKey = dc
        dc = New DataColumn(0) {New DataColumn()}
        dc(0) = dt(4).Columns(0)
        dt(4).PrimaryKey = dc
        For Each dr As DataRow In ds.Tables("[S2_SYS2]").Rows
            If dr("SYSTEMID").ToString() = ownsystemid And Not dr("IS_ICAO") And dr("STAFFID") = staffid Then
                Dim drRow As DataRow = dt(4).NewRow
                drRow(0) = dr("ObjectID")
                drRow(1) = "Equipment Course"
                drRow(2) = dr("ICAO_NO_SYS_DESCRIPTION")
                drRow(3) = dr("VERIFIED").ToString()
                drRow(4) = dr("CLASS_NAME_NO")
                drRow(5) = dr("DATE_")
                drRow(6) = dr("LEVEL_")
                dt(4).Rows.Add(drRow)
            ElseIf dr("IS_ICAO") Then
                If dr("SYSTEMID").ToString() = ownsystemid And dr("STAFFID") = staffid Then
                    keys(0) = dr(2).ToString()
                    dt(3).Rows.Find(keys)(4) = dr("VERIFIED").ToString()
                    dt(3).Rows.Find(keys)(5) = dr("CLASS_NAME_NO")
                    dt(3).Rows.Find(keys)(6) = dr("DATE_")
                    dt(3).Rows.Find(keys)(7) = dr("ObjectID")
                End If
            End If
        Next

        S2GridK4.Columns.Clear()
        S2GridK4.DataSource = dt(4)
        Dim dgc As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        Dim combdt As DataTable = New DataTable()
        combdt.Columns.Add(New DataColumn("value"))
        combdt.Columns.Add(New DataColumn("test"))
        combdt.Rows.Add("1", "N/A")
        combdt.Rows.Add("2", "Level 1")
        combdt.Rows.Add("3", "Level 2")
        combdt.Rows.Add("4", "Full Level")
        dgc.Name = "level"
        dgc.DisplayMember = "test"
        dgc.ValueMember = "value"
        ' dgc.DataSource = combdt

        S2GridK4.Columns(0).Visible = False
        S2GridK4.Columns(6).Visible = False
        S2GridK4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        S2GridK4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        S2GridK4.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        For Each ii As DataGridViewColumn In S2GridK4.Columns
            ii.SortMode = False
        Next
        dv = New DataView(dt(4))
        dv.Sort = dt(4).Columns(0).ColumnName + " DESC"
        'S2GridK4.Sort(S2GridK4.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        dgc.Items.AddRange("N/A", "Level 1", "Level 2", "Full Level")
        S2GridK4.Columns.Add(dgc)
        For Each dgr As DataGridViewRow In S2GridK4.Rows
            Dim cb As DataGridViewComboBoxCell = dgr.Cells(7)

            Select Case dgr.Cells(6).Value
                Case "N/A"
                    cb.Value = dgc.Items.Item(0)
                Case "Level 1"
                    cb.Value = dgc.Items.Item(1)
                Case "Level 2"
                    cb.Value = dgc.Items.Item(2)
                Case "Full Level"
                    cb.Value = dgc.Items.Item(3)

            End Select
        Next
        SaveDataBase.Enabled = True

        TabControl1.Visible = True
        TabControl1.SelectedTab = S2TabPage
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        'dt(5) = New DataTable()
        'dt(5).Columns.AddRange(New DataColumn(7) {New DataColumn("ObjectID"),
        '                                         New DataColumn("SYSTEMID"),
        '                                        New DataColumn("STAFFID"),
        '                                       New DataColumn("TYPE"),
        '                                      New DataColumn("1st Quarterly"),
        '                                     New DataColumn("2nd Quarterly"),
        '                                    New DataColumn("Final"),
        '                                   New DataColumn("DATE")
        '                                 })
        '
        '
        'For Each dr As DataRow In ds.Tables("[S6_REVIEW]").Rows
        '   Dim drRow As DataRow = dt(5).NewRow()
        '  If (dr("SYSTEMID").ToString() = ownsystemid) Then
        'drRow(2) = dr("1st Quarterly")
        'drRow(3) = dr("2nd Quarterly")
        'drRow(0) = name(dr("TYPE") - 1)
        'drRow(1) = "?"
        'drRow(6) = dr("ObjectID")
        'drRow(5) = dr("SYSTEMID")
        'drRow(4) = dr("Final")

        'dt(5).Rows.Add(drRow)
        '   End If
        'Next
        '
        'Dim dc3 As DataColumn() = New DataColumn(0) {New DataColumn()}
        'dc3(0) = dt(5).Columns(6)
        'dt(5).PrimaryKey = dc3
        'Try
        'For Each dr As DataRow In ds.Tables("[S6_REVIEW]").Rows

        'dt(5).Rows.Find(New Object(0) {dr("DESCID")})(4) = dr("COMMENTS")
        'dt(5).Rows.Find(New Object(0) {dr("DESCID")})(7) = dr("ObjectID")
        'Next
        'Dim now As Integer = 0
        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'End Try
        'DataGridView4.Columns.Clear()
        'DataGridView4.DataSource = dt(5)
        'DataGridView4.Columns(5).Visible = False
        'DataGridView4.Columns(6).Visible = False
        ' DataGridView4.Columns(7).Visible = False
        'DataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'DataGridView4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        'DataGridView4.DefaultCellStyle.WrapMode = DataGridViewTriState.True



        'For Each ii As DataGridViewColumn In DataGridView3.Columns
        'ii.SortMode = False
        'Next
        'dv = New DataView(dt(5))
        'dv.Sort = dt(5).Columns(0).ColumnName + " DESC"
        'DataGridView4.Sort(DataGridView4.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        'TabControl1.SelectedTab = TabPage6
        ''
        ''
        ''
        ''
        ''
        ''
        ''
        TabControl1.TabPages.Remove(S1TabPage)
        TabControl1.TabPages.Remove(S3TabPage)
        TabControl1.TabPages.Remove(S4TabPage)
        TabControl1.TabPages.Remove(S5TabPage)


        S2Grid.Columns(0).Visible = False
        S2Grid.Columns(7).Visible = False

        For Each ii As DataGridViewColumn In S3Grid1.Columns
            ii.SortMode = False
        Next
        For Each ii As DataGridViewColumn In DataGridView2.Columns
            ii.SortMode = False
        Next
        For Each ii As DataGridViewColumn In S5Grid1.Columns
            ii.SortMode = False
        Next

        Select Case cert.Substring(0, 1)
            Case "C"
                certname = "Communication"
            Case "N"
                certname = "Navigation"
            Case "S"
                certname = "Surveillance"
            Case "D"
                certname = "Data Processing"
        End Select




        If owncert.Equals("NO") Then
        Else
            If isae And Not ds.Tables("[CERT]").Rows.Find(New Object(0) {owncert})(4) And Not CA1TextBox.Text.Equals("") And Not CA2TextBox.Text.Equals("") Then
                appoveCertButton.Enabled = True

            End If

            If isae And ds.Tables("[CERT]").Rows.Find(New Object(0) {owncert})(4) Then
                print.Enabled = True
            End If
        End If

        ' MessageBox.Show(ismultlv.ToString())
        S5fullLVContextMenuStrip.Items(1).Enabled = True
        S5fullLVContextMenuStrip.Items(2).Enabled = True
        S5fullLVContextMenuStrip.Items(3).Enabled = True
        S5fullLVContextMenuStrip.Items(4).Enabled = True
        S5fullLVContextMenuStrip.Items(5).Enabled = True
        S5fullLVContextMenuStrip.Items(6).Enabled = True
        S5fullLVContextMenuStrip.Items(7).Enabled = True
        S5fullLVContextMenuStrip.Items(8).Enabled = True
        S5fullLVContextMenuStrip.Items(9).Enabled = True
        S5fullLVContextMenuStrip.Items(10).Enabled = True

        S5muitiLVContextMenuStrip.Items(1).Enabled = True
        S5muitiLVContextMenuStrip.Items(2).Enabled = True
        S5muitiLVContextMenuStrip.Items(3).Enabled = True
        S5muitiLVContextMenuStrip.Items(4).Enabled = True
        S5muitiLVContextMenuStrip.Items(5).Enabled = True
        S5muitiLVContextMenuStrip.Items(6).Enabled = True
        S5muitiLVContextMenuStrip.Items(7).Enabled = True
        S5muitiLVContextMenuStrip.Items(8).Enabled = True
        S5muitiLVContextMenuStrip.Items(9).Enabled = True
        S5muitiLVContextMenuStrip.Items(10).Enabled = True
        S5muitiLVContextMenuStrip.Items(11).Enabled = True
        S5muitiLVContextMenuStrip.Items(12).Enabled = True
        S5muitiLVContextMenuStrip.Items(13).Enabled = True
        S5muitiLVContextMenuStrip.Items(14).Enabled = True
        S5muitiLVContextMenuStrip.Items(15).Enabled = True
        S5muitiLVContextMenuStrip.Items(16).Enabled = True
        S5muitiLVContextMenuStrip.Items(17).Enabled = True

    End Sub


    Private Sub SaveDataBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDataBase.Click

        Dim tu As TableUpdate = New TableUpdate()
        Dim i As Integer = 0
        For Each at As OleDbDataAdapter In da
            tu.update(cn, at, ds, tablename(i))
            i = i + 1
        Next
        SaveDataBase.Enabled = False
    End Sub


    'S3 cell end edit
    Private Sub DataGridView1_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles S3Grid1.CellEndEdit
        ' MessageBox.Show("change")

        Dim key(0) As Object
        Dim key2(0) As Object
        key(0) = S3Grid1.Rows(e.RowIndex).Cells(6).Value
        key2(0) = S3Grid1.Rows(e.RowIndex).Cells(7).Value
        Try
            ds.Tables("[S3_COMMENTS]").Rows.Find(key2)("COMMENTS") = S3Grid1.Rows(e.RowIndex).Cells(4).Value

        Catch
            Dim dr As DataRow = ds.Tables("[S3_COMMENTS]").NewRow()
            dr(0) = ds.Tables("[S3_COMMENTS]").Rows(ds.Tables("[S3_COMMENTS]").Rows.Count - 1)(0) + 1
            dr(1) = S3Grid1.Rows(e.RowIndex).Cells(8).Value.ToString()
            dr(2) = ownsystemid
            dr(3) = staffid
            dr(4) = S3Grid1.Rows(e.RowIndex).Cells(4).Value
            dr(5) = ""
            dr(6) = "0"
            dr(7) = S3Grid1.Rows(e.RowIndex).Cells(0).Value
            ds.Tables("[S3_COMMENTS]").Rows.Add(dr)
        End Try

        SaveDataBase.Enabled = True
    End Sub

    'S3 row head mouse click
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles S3Grid1.RowHeaderMouseClick
        If e.Button = MouseButtons.Right Then

        Else
            S3Grid1.ContextMenuStrip = S5fullLVContextMenuStrip
            S3Grid1.ContextMenuStrip.Show(MousePosition)
            rowIndex = e.RowIndex
        End If
    End Sub


    'S2 function item click
    Private Sub S2_ICAO_funContextMenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles S2_ICAO_funContextMenuStrip.ItemClicked

        Dim key(0) As Object
        Dim f5 As Form5
        Select Case e.ClickedItem.Tag
            Case "add"
            Case "del"
                key(0) = S2Grid.Rows(rowIndex).Cells(0).Value
                'MessageBox.Show(key(0).ToString())
                ds.Tables("[S2_ICAO]").Rows.Find(key).Delete()
                ds.Tables("[S2_SYS]").Rows.Find(key).Delete()
                dt(3).Rows(rowIndex).Delete()
            Case Else
                da(15) = New OleDbDataAdapter("select * from [S2_ICAO]", cn)
                da(15).Fill(ds, "[S2_ICAO]")
                key = New DataColumn(0) {New DataColumn}
                key(0) = ds.Tables("[S2_ICAO]").Columns("ObjectID")
                ds.Tables("[S2_ICAO]").PrimaryKey = key
                f5 = New Form5(e.ClickedItem.Text, e.ClickedItem.Tag, ds, ownsystemid, staffid)
                f5.ShowDialog()
                dt(3).Rows(rowIndex)(2) = f5.dec
                dt(3).Rows(rowIndex)(3) = f5.cri
                dt(3).Rows(rowIndex)(0) = f5.typename
        End Select

        SaveDataBase.Enabled = True
    End Sub

    Private Sub ToolStripMenuItem23_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStripMenuItem23.DropDownItemClicked

        Dim key(0) As Object
        Dim f5 As Form5
        da(15) = New OleDbDataAdapter("select * from [S2_ICAO]", cn)
        da(15).Fill(ds, "[S2_ICAO]")

        key = New DataColumn(0) {New DataColumn}
        key(0) = ds.Tables("[S2_ICAO]").Columns("ObjectID")
        ds.Tables("[S2_ICAO]").PrimaryKey = key
        f5 = New Form5(e.ClickedItem.Text, e.ClickedItem.Tag, ds, ownsystemid, staffid)

        f5.ShowDialog()
        Dim dr As DataRow = dt(3).NewRow()
        dt(3).Rows(rowIndex)(2) = f5.dec
        dt(3).Rows(rowIndex)(3) = f5.cri
        dt(3).Rows(rowIndex)(0) = f5.typename
    End Sub
    'S4 function item click
    Private Sub S4funContextMenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles S4funContextMenuStrip.ItemClicked
        Dim key(0) As Object
        Dim key2(0) As Object
        Dim f4 As Form4
        Select Case e.ClickedItem.Tag
            Case "add"

            Case "del"

                key(0) = DataGridView2.Rows(rowIndex).Cells(6).Value
                key2(0) = DataGridView2.Rows(rowIndex).Cells(7).Value
                ds.Tables("[S4_DESC]").Rows.Find(key).Delete()
                ds.Tables("[S4_GUIDELINE]").Rows.Find(key2).Delete()
                dt(1).Rows(rowIndex).Delete()
                ds.Tables("[S4_GUIDELINE]").AcceptChanges()
                ds.Tables("[S4_DESC]").AcceptChanges()

            Case Else
                da(14) = New OleDbDataAdapter("select * from [SAMPLE_QUESTION]", cn)
                da(14).Fill(ds, "[SAMPLE_QUESTION]")

                key = New DataColumn(0) {New DataColumn}
                key(0) = ds.Tables("[SAMPLE_QUESTION]").Columns("ObjectID")
                ds.Tables("[SAMPLE_QUESTION]").PrimaryKey = key
                f4 = New Form4(e.ClickedItem.Text, e.ClickedItem.Tag, ds)

                f4.ShowDialog()
                dt(1).Rows(rowIndex)(2) = f4.dec
                dt(1).Rows(rowIndex)(3) = f4.cri
                dt(1).Rows(rowIndex)(1) = f4.typename
                dt(1).Rows(rowIndex)(8) = f4.typeid
                dt(1).Rows(rowIndex)(0) = "C" + e.ClickedItem.Text.Substring(7, 1)

        End Select
        dv = New DataView(dt(1))
        dv.Sort = dt(1).Columns(8).ColumnName + " ASC"
        dt(1) = dv.ToTable()
        dt(1).AcceptChanges()
        DataGridView2.Update()
        DataGridView2.DataSource = dt(1)
        SaveDataBase.Enabled = True
    End Sub
    'S4 dropdown click
    Private Sub ToolStripMenuItem1_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStripMenuItem1.DropDownItemClicked
        Dim key(0) As Object
        Dim f4 As Form4

        f4 = New Form4(e.ClickedItem.Text, e.ClickedItem.Tag, ds)
        If rowIndex = -1 Then
            S4funContextMenuStrip.Items(1).Enabled = True
            S4funContextMenuStrip.Items(2).Enabled = True
            S4funContextMenuStrip.Items(3).Enabled = True
            S4funContextMenuStrip.Items(4).Enabled = True
            S4funContextMenuStrip.Items(5).Enabled = True
            S4funContextMenuStrip.Items(6).Enabled = True
            S4funContextMenuStrip.Items(7).Enabled = True
            S4funContextMenuStrip.Items(8).Enabled = True
            S4funContextMenuStrip.Items(9).Enabled = True
            S4funContextMenuStrip.Items(10).Enabled = True

        End If
        f4.ShowDialog()
        If Not f4.endedit Then


        Else
            Dim dr As DataRow = ds.Tables("[S4_DESC]").NewRow()
            If ds.Tables("[S4_DESC]").Rows.Count = 0 Then
                dr("ObjectID") = 1
            Else
                dr("ObjectID") = Convert.ToInt32(ds.Tables("[S4_DESC]").Rows(ds.Tables("[S4_DESC]").Rows.Count - 1)("ObjectID")) + 1
            End If

            dr("SUB_TYPE") = rowIndex + 1
            dr("TYPE") = e.ClickedItem.Tag
            dr("LV") = 1
            ds.Tables("[S4_DESC]").Rows.Add(dr)

            Dim drr As DataRow = ds.Tables("[S4_GUIDELINE]").NewRow()
            If ds.Tables("[S4_GUIDELINE]").Rows.Count = 0 Then
                drr("ObjectID") = 1
            Else
                drr("ObjectID") = Convert.ToInt32(ds.Tables("[S4_GUIDELINE]").Rows(ds.Tables("[S4_GUIDELINE]").Rows.Count - 1)("ObjectID")) + 1
            End If
            drr("TYPE") = e.ClickedItem.Tag
            drr("SYSTEMID") = ownsystemid
            drr("STAFFID") = staffid
            drr("SUB_TYPE") = dr("SUB_TYPE")
            drr("DESCID") = dr("ObjectID")
            drr("DESCID") = Convert.ToInt32(ds.Tables("[S4_DESC]").Rows(ds.Tables("[S4_DESC]").Rows.Count - 1)("ObjectID")) + 1
            drr("LV") = 1
            ds.Tables("[S4_GUIDELINE]").Rows.Add(drr)

            da(14) = New OleDbDataAdapter("select * from [SAMPLE_QUESTION]", cn)
            da(14).Fill(ds, "[SAMPLE_QUESTION]")

            key = New DataColumn(0) {New DataColumn}
            key(0) = ds.Tables("[SAMPLE_QUESTION]").Columns("ObjectID")
            ds.Tables("[SAMPLE_QUESTION]").PrimaryKey = key

            Dim dr2 As DataRow = dt(1).NewRow()
            dr2(6) = dr("ObjectID")
            dr2(7) = drr("ObjectID")
            dt(1).Rows.InsertAt(dr2, rowIndex + 1)
            dt(1).Rows(rowIndex + 1)(2) = f4.dec
            dt(1).Rows(rowIndex + 1)(3) = f4.cri
            dt(1).Rows(rowIndex + 1)(1) = f4.typename
            dt(1).Rows(rowIndex + 1)(8) = f4.typeid
            dt(1).Rows(rowIndex + 1)(0) = "C" + e.ClickedItem.Text.Split(".")(0)
            dt(1).Rows(rowIndex + 1)(4) = ""
            dv = New DataView(dt(1))
            dv.Sort = dt(1).Columns(8).ColumnName + " ASC"
            dt(1) = dv.ToTable()
            dt(1).AcceptChanges()
            DataGridView2.Update()
            DataGridView2.DataSource = dt(1)
            SaveDataBase.Enabled = True

        End If


    End Sub


    'S5 function item click
    Private Sub S5funContextMenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles S5muitiLVContextMenuStrip.ItemClicked
        Dim key(0) As Object
        Dim key2(0) As Object
        Dim f4 As Form4
        Select Case e.ClickedItem.Tag
            Case "add"

            Case "del"

                key(0) = S5Grid1.Rows(rowIndex).Cells(6).Value
                key2(0) = S5Grid1.Rows(rowIndex).Cells(7).Value
                ds.Tables("[S5_DESC]").Rows.Find(key).Delete()
                ds.Tables("[S5_OJTI]").Rows.Find(key2).Delete()
                dt(2).Rows(rowIndex).Delete()
                ds.Tables("[S5_OJTI]").AcceptChanges()
                ds.Tables("[S5_DESC]").AcceptChanges()

            Case Else
                da(14) = New OleDbDataAdapter("select * from [SAMPLE_QUESTION]", cn)
                da(14).Fill(ds, "[SAMPLE_QUESTION]")

                key = New DataColumn(0) {New DataColumn}
                key(0) = ds.Tables("[SAMPLE_QUESTION]").Columns("ObjectID")
                ds.Tables("[SAMPLE_QUESTION]").PrimaryKey = key
                f4 = New Form4(e.ClickedItem.Text, e.ClickedItem.Tag, ds)

                f4.ShowDialog()
                If f4.isclose Then
                    Return
                Else
                    dt(2).Rows(rowIndex)(2) = f4.dec
                    dt(2).Rows(rowIndex)(3) = f4.cri
                    dt(2).Rows(rowIndex)(1) = f4.typename
                    dt(2).Rows(rowIndex)(8) = f4.typeid
                    ' dt(2).Rows(rowIndex)(0) = "C" + e.ClickedItem.Text.Substring(7, 1)
                    dt(2).Rows(rowIndex)(0) = "C" + e.ClickedItem.Tag
                End If
        End Select
        dv = New DataView(dt(2))
        dv.Sort = dt(2).Columns(8).ColumnName + " ASC"
        dt(2) = dv.ToTable()
        dt(2).AcceptChanges()
        S5Grid1.Update()

        S5Grid1.DataSource = dt(2)
        SaveDataBase.Enabled = True

    End Sub

    'S5 dropdown click
    Private Sub ToolStripMenuItem12_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStripMenuItem12.DropDownItemClicked
        Dim key(0) As Object
        Dim f4 As Form4

        f4 = New Form4(e.ClickedItem.Text, e.ClickedItem.Tag, ds)
        If rowIndex = -1 Then
            If ismultlv Then
                S5muitiLVContextMenuStrip.Items(1).Enabled = True
                S5muitiLVContextMenuStrip.Items(2).Enabled = True
                S5muitiLVContextMenuStrip.Items(3).Enabled = True
                S5muitiLVContextMenuStrip.Items(4).Enabled = True
                S5muitiLVContextMenuStrip.Items(5).Enabled = True
                S5muitiLVContextMenuStrip.Items(6).Enabled = True
                S5muitiLVContextMenuStrip.Items(7).Enabled = True
                S5muitiLVContextMenuStrip.Items(8).Enabled = True
                S5muitiLVContextMenuStrip.Items(9).Enabled = True
                S5muitiLVContextMenuStrip.Items(10).Enabled = True
                S5muitiLVContextMenuStrip.Items(11).Enabled = True
                S5muitiLVContextMenuStrip.Items(12).Enabled = True
                S5muitiLVContextMenuStrip.Items(13).Enabled = True
                S5muitiLVContextMenuStrip.Items(14).Enabled = True
                S5muitiLVContextMenuStrip.Items(15).Enabled = True
                S5muitiLVContextMenuStrip.Items(16).Enabled = True
                S5muitiLVContextMenuStrip.Items(17).Enabled = True

            Else
                S5fullLVContextMenuStrip.Items(1).Enabled = True
                S5fullLVContextMenuStrip.Items(2).Enabled = True
                S5fullLVContextMenuStrip.Items(3).Enabled = True
                S5fullLVContextMenuStrip.Items(4).Enabled = True
                S5fullLVContextMenuStrip.Items(5).Enabled = True
                S5fullLVContextMenuStrip.Items(6).Enabled = True
                S5fullLVContextMenuStrip.Items(7).Enabled = True
                S5fullLVContextMenuStrip.Items(8).Enabled = True
                S5fullLVContextMenuStrip.Items(9).Enabled = True
                S5fullLVContextMenuStrip.Items(10).Enabled = True
            End If

        End If
        f4.ShowDialog()

        If Not f4.endedit Then

        Else
            Dim dr As DataRow = ds.Tables("[S5_DESC]").NewRow()
            If ds.Tables("[S5_DESC]").Rows.Count = 0 Then
                dr("ObjectID") = 1
            Else
                dr("ObjectID") = Convert.ToInt32(ds.Tables("[S5_DESC]").Rows(ds.Tables("[S5_DESC]").Rows.Count - 1)("ObjectID")) + 1
            End If

            dr("SUB_TYPE") = rowIndex + 1
            dr("TYPE") = e.ClickedItem.Tag
            dr("LV") = 1
            ds.Tables("[S5_DESC]").Rows.Add(dr)

            Dim drr As DataRow = ds.Tables("[S5_OJTI]").NewRow()
            If ds.Tables("[S5_OJTI]").Rows.Count = 0 Then
                drr("ObjectID") = 1
            Else
                drr("ObjectID") = Convert.ToInt32(ds.Tables("[S5_OJTI]").Rows(ds.Tables("[S5_OJTI]").Rows.Count - 1)("ObjectID")) + 1
            End If

            drr("TYPE") = e.ClickedItem.Tag
            drr("SYSTEMID") = ownsystemid
            drr("STAFFID") = staffid
            drr("SUB_TYPE") = dr("SUB_TYPE")
            drr("DESCID") = Convert.ToInt32(ds.Tables("[S5_DESC]").Rows(ds.Tables("[S5_DESC]").Rows.Count - 1)("ObjectID")) + 1
            drr("LV") = 1
            ds.Tables("[S5_OJTI]").Rows.Add(drr)
            da(14) = New OleDbDataAdapter("select * from [SAMPLE_QUESTION]", cn)
            da(14).Fill(ds, "[SAMPLE_QUESTION]")

            key = New DataColumn(0) {New DataColumn}
            key(0) = ds.Tables("[SAMPLE_QUESTION]").Columns("ObjectID")
            ds.Tables("[SAMPLE_QUESTION]").PrimaryKey = key

            Dim dr2 As DataRow = dt(2).NewRow()
            dr2(6) = dr("ObjectID")
            dr2(7) = drr("ObjectID")
            dt(2).Rows.InsertAt(dr2, rowIndex + 1)

            dt(2).Rows(rowIndex + 1)(2) = f4.dec
            dt(2).Rows(rowIndex + 1)(3) = f4.cri
            dt(2).Rows(rowIndex + 1)(1) = f4.typename
            dt(2).Rows(rowIndex + 1)(8) = f4.typeid
            dt(2).Rows(rowIndex + 1)(0) = "C" + e.ClickedItem.Text.Split(".")(0)
            dt(2).Rows(rowIndex + 1)(4) = ""
            dv = New DataView(dt(2))
            dv.Sort = dt(2).Columns(8).ColumnName + " ASC"
            dt(2) = dv.ToTable()
            dt(2).AcceptChanges()
            S5Grid1.Update()
            S5Grid1.DataSource = dt(2)
            SaveDataBase.Enabled = True


        End If

    End Sub


    'S4 row header mouse click
    Private Sub DataGridView2_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.RowHeaderMouseClick

        If e.Button = MouseButtons.Right Then

        Else
            DataGridView2.ContextMenuStrip = S4funContextMenuStrip
            DataGridView2.ContextMenuStrip.Show(MousePosition)
            rowIndex = e.RowIndex
        End If
    End Sub



    'S5 row header mouse click
    Private Sub DataGridView3_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles S5Grid1.RowHeaderMouseClick
        If e.Button = MouseButtons.Right And isaojti Then

        Else
            If ismultlv Then
                S5Grid1.ContextMenuStrip = S5muitiLVContextMenuStrip
                S5Grid1.ContextMenuStrip.Show(MousePosition)
            Else
                S5Grid1.ContextMenuStrip = S5fullLVContextMenuStrip
                S5Grid1.ContextMenuStrip.Show(MousePosition)
            End If
            rowIndex = e.RowIndex
        End If
    End Sub

    'Print Certificate button
    Private Sub print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles print.Click
        ' MessageBox.Show(ds.Tables("[CERT]").Rows.Find(New Object(0) {owncert.Substring(1, 4)})(1))
        Dim reportlist As List(Of REPORT) = New List(Of REPORT)
        reportlist.Add(New REPORT() With { _
        .CERT_NO_ = "C" + ds.Tables("[CERT]").Rows.Find(New Object(0) {owncert})(1) + owncert, _
        .CREATDATE = "test", _
        .LV = "test", _
        .STAFFNAME = NameTextBox.Text, _
        .STAFFNO_ = StaffNoTextBox.Text, _
        .SYSTEMNAME = certname _
                   })


        Dim rvp As ReportviewerPage = New ReportviewerPage()
        rvp.ReportViewer1.LocalReport.DataSources.Clear()
        rvp.ReportViewer1.LocalReport.ReportEmbeddedResource = "ATSEP.Report5.rdlc"
        rvp.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("REPORT", reportlist))
        rvp.ReportViewer1.LocalReport.Refresh()
        rvp.ReportViewer1.RefreshReport()
        rvp.Show()

    End Sub

    Private Sub DataGridView5_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles S2GridK4.RowHeaderMouseClick
        S2_SYS_funContextMenuStrip.Items(0).Enabled = True
        S2_SYS_funContextMenuStrip.Items(1).Enabled = True
        S2_SYS_funContextMenuStrip.Items(2).Enabled = True
        S2_SYS_funContextMenuStrip.Items(3).Enabled = True

        If e.Button = MouseButtons.Right Then

        ElseIf isae And isca Then
            S2GridK4.EndEdit()
            S2GridK4.ContextMenuStrip = S2_SYS_funContextMenuStrip
            S2GridK4.ContextMenuStrip.Show(MousePosition)
            rowIndex = e.RowIndex
        Else
            S2_SYS_funContextMenuStrip.Items(0).Enabled = False
            S2_SYS_funContextMenuStrip.Items(1).Enabled = False
            S2_SYS_funContextMenuStrip.Items(3).Enabled = False
            S2GridK4.ContextMenuStrip = S2_SYS_funContextMenuStrip
            S2GridK4.ContextMenuStrip.Show(MousePosition)
            rowIndex = e.RowIndex
        End If
    End Sub



    Private Sub DataGridView9_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles S2Grid.CellEndEdit
        ' MessageBox.Show("change")

        Dim key(0) As Object
        Dim key2(0) As Object
        key(0) = S2Grid.Rows(e.RowIndex).Cells(7).Value
        ' key2(0) = DataGridView9.Rows(e.RowIndex).Cells(7).Value
        'If DataGridView9.Rows(e.RowIndex).Cells(4).Value Then
        Try
            ds.Tables("[S2_SYS2]").Rows.Find(key)("ICAO_NO_SYS_DESCRIPTION") = S2Grid.Rows(e.RowIndex).Cells(2).Value
            If S2Grid.Rows(e.RowIndex).Cells(5).Value.Equals("") Then
                ds.Tables("[S2_SYS2]").Rows.Find(key)("CLASS_NAME_NO") = " "
            Else


                ds.Tables("[S2_SYS2]").Rows.Find(key)("CLASS_NAME_NO") = S2Grid.Rows(e.RowIndex).Cells(5).Value
            End If
            ds.Tables("[S2_SYS2]").Rows.Find(key)("VERIFIED") = S2Grid.Rows(e.RowIndex).Cells(4).Value
            ds.Tables("[S2_SYS2]").Rows.Find(key)("DATE_") = S2Grid.Rows(e.RowIndex).Cells(6).Value
            ' ds.Tables("[S2_SYS2]").Rows.Find(key)("LEVEL_") = S2Grid.Rows(e.RowIndex).Cells(7).Value
        Catch
            Dim dr As DataRow = ds.Tables("[S2_SYS2]").NewRow()
            dr(0) = ds.Tables("[S2_SYS2]").Rows(ds.Tables("[S2_SYS2]").Rows.Count - 1)(0) + 1
            S2Grid.Rows(e.RowIndex).Cells(7).Value = ds.Tables("[S2_SYS2]").Rows(ds.Tables("[S2_SYS2]").Rows.Count - 1)(0) + 1
            dr(1) = ownsystemid
            dr(2) = S2Grid.Rows(e.RowIndex).Cells(2).Value
            dr(3) = ""
            dr(4) = True
            dr(5) = False
            dr(6) = staffid
            dr(7) = ""
            dr(8) = "Level 1"
            ds.Tables("[S2_SYS2]").Rows.Add(dr)
        End Try
        SaveDataBase.Enabled = True

    End Sub




    Private Sub S2_SYS_funContextMenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles S2_SYS_funContextMenuStrip.ItemClicked

        Dim key(0) As Object
        Dim f5 As Form5
        Select Case e.ClickedItem.Tag
            Case "add"

            Case "del"
                If S2GridK4.Rows.Count = 0 Then
                    Return
                End If
                key(0) = S2GridK4.Rows(rowIndex).Cells(0).Value

                ds.Tables("[S2_SYS2]").Rows.Find(key).Delete()
                ds.Tables("[REPORT]").Rows.Find(key).Delete()
                dt(4).Rows(rowIndex).Delete()
                Dim tu As TableUpdate = New TableUpdate()
                tu.update(cn, da(14), ds, tablename(14))
                da(14).Fill(ds, "[S2_SYS2]")
            Case "select"

                ''
                ''
                ''
                ''
                ''
                ''
                ''
                ''
                ''
                ''
                ''
                ''
                'initialize the Comment rich text box of S1

                rtb(0) = RichTextBox1
                rtb(1) = RichTextBox2
                rtb(2) = RichTextBox3
                rtb(3) = RichTextBox4
                rtb(4) = RichTextBox5
                rtb(5) = RichTextBox6
                rtb(6) = RichTextBox7
                rtb(7) = RichTextBox8
                rtb(8) = RichTextBox9
                rtb(9) = RichTextBox10
                rtb(10) = RichTextBox11
                rtb(11) = RichTextBox12
                rtb(12) = RichTextBox13
                rtb(13) = RichTextBox14

                'initialize the check box of S1

                chb(0) = CheckBox1
                chb(1) = CheckBox2
                chb(2) = CheckBox3
                chb(3) = CheckBox4
                chb(4) = CheckBox5
                chb(5) = CheckBox6
                chb(6) = CheckBox7
                chb(7) = CheckBox8
                chb(8) = CheckBox9
                chb(9) = CheckBox10
                chb(10) = CheckBox11
                chb(11) = CheckBox12
                chb(12) = CheckBox13
                chb(13) = CheckBox14

                For Each dr As DataRow In ds.Tables("[S1_COM_VERIF]").Rows
                    If s2ObjectId.Equals(dr("S2ObjectID")) Then
                        rtb(Convert.ToInt32(dr("TYPE")) - 1).Text = dr("COMMENTS").ToString()
                        chb(Convert.ToInt32(dr("TYPE")) - 1).Checked = Convert.ToBoolean(dr("VERIFIED"))
                        rtb(Convert.ToInt32(dr("TYPE")) - 1).Tag = dr(0)
                        chb(Convert.ToInt32(dr("TYPE")) - 1).Tag = dr(0)
                    End If
                Next
                ''
                ''
                ''
                ''
                ''
                ''
                ''
                ''
                ''
                ''initialize S5

                Dim name() As String
                Dim level As String = ""
                Dim num As Integer = 0
                If S2GridK4.Rows.Count = 0 Then
                    Return
                End If
                owns2k4ObjectId = S2GridK4.Rows(rowIndex).Cells(0).Value
                If S2GridK4.Rows(rowIndex).Cells(7).Value.Equals("Level 1") Then
                    ismultlv = False
                    ownLV = 1
                    level = "1"
                    num = 9
                    name = New String(8) {"Safety and Precaution", "System Knowledge", "Instrumentation", "System Monitoring", "Preventive Maintenance", "System Health", "System Diagnosis", "Documentation", "Communication"}
                Else
                    If S2GridK4.Rows(rowIndex).Cells(7).Value.Equals("Level 2") Then
                        ownLV = 2
                    Else
                        ownLV = 3
                    End If
                    level = "2"
                    ismultlv = True
                    num = 16
                    name = New String(15) {"Safety and Precaution", "System Knowledge", "Contingency/Backup", "Circuitry Understanding", "Conversant Detailed", "Approprite Test Instruments", "Specialized Tools", "Data Interpretaion", "Tuning/Adjustment", "Advanced System Command", "Level Of Conversant", "Interpretation Messages", "Fault Techniques", "Work Efficiency", "Report Writing Skill", "Paties Concerned"}
                End If
                If ds.Tables("[REPORT]").Rows.Find(New Object(0) {owns2k4ObjectId})(2) Then
                    completedButton.Enabled = False
                End If
                dt(2) = New DataTable()
                dt(2).Columns.AddRange(New DataColumn(8) {
                                                          New DataColumn("Number"),
                                                          New DataColumn("Competence Type"),
                                                          New DataColumn("Competence Description"),
                                                          New DataColumn("Performance Criteria"),
                                                          New DataColumn("OJTI Comments/Remarks"),
                                                          New DataColumn(S3Grid1.Columns(5).HeaderText),
                                                          New DataColumn(S3Grid1.Columns(6).HeaderText),
                                                          New DataColumn(),
                                                         New DataColumn()
                                                         })
                dt(2).Columns(8).DataType = GetType(Integer)
                Dim name2() As String = New String(8) {"Safety and Precaution", "System Knowledge", "Instrumentation", "System Monitoring", "Preventive Maintenance", "System Health", "System Diagnosis", "Documentation", "Communication"}

                For Each dr As DataRow In ds.Tables("[S5_DESC]").Rows
                    Dim drRow As DataRow = dt(2).NewRow()
                    If (dr("SYSTEMID").ToString() = ownsystemid And Convert.ToInt32(dr("TYPE")) <= num And dr("LV") = level) Then
                        drRow(1) = name(dr("TYPE") - 1)
                        drRow(0) = "C" + dr("TYPE")
                        drRow(2) = dr("DESCRIPTION")
                        drRow(3) = dr("CRITERIA")
                        drRow(4) = ""
                        drRow(5) = dr("SYSTEMID")
                        drRow(6) = dr("ObjectID")
                        drRow(8) = dr("TYPE")
                        dt(2).Rows.Add(drRow)
                    End If
                Next

                Dim dc2 As DataColumn() = New DataColumn(0) {New DataColumn()}
                dc2(0) = dt(2).Columns(6)
                dt(2).PrimaryKey = dc2

                For Each dr As DataRow In ds.Tables("[S5_OJTI]").Rows
                    If dr("STAFFID") = staffid Then
                        Try
                            dt(2).Rows.Find(New Object(0) {dr("DESCID")})(4) = dr("COMMENTS")
                            dt(2).Rows.Find(New Object(0) {dr("DESCID")})(7) = dr("ObjectID")
                        Catch ex As Exception
                            ' MessageBox.Show(ex.Message)
                        End Try
                    End If

                Next
                'Dim now As Integer = 0


                dv = New DataView(dt(2))
                dv.Sort = dt(2).Columns(8).ColumnName + " ASC"
                dt(2) = dv.ToTable()
                dt(2).AcceptChanges()
                TabControl1.TabPages.Add(S5TabPage)
                'DataGridView3.Sort(DataGridView3.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                S5Grid1.Columns.Clear()
                S5Grid1.DataSource = dt(2)
                S5Grid1.Columns(5).Visible = False
                S5Grid1.Columns(6).Visible = False
                S5Grid1.Columns(7).Visible = False
                S5Grid1.Columns(8).Visible = False
                S5Grid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                S5Grid1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                S5Grid1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                TabControl1.TabPages.Remove(TabControl1.SelectedTab)
                PreviewButton.Enabled = True
                TabControl1.SelectedTab = S5TabPage
                NextButton.Enabled = True

                reportnum = ds.Tables("[REPORT]").Rows.Find(New Object(0) {dt(4).Rows(rowIndex)(0)})(1)


                s2ObjectId = dt(4).Rows(rowIndex)(0)
                Try
                    CA1TextBox.Text = ds.Tables("[REPORT]").Rows.Find(New Object(0) {dt(4).Rows(rowIndex)(0)})(3)
                    CA2TextBox.Text = ds.Tables("[REPORT]").Rows.Find(New Object(0) {dt(4).Rows(rowIndex)(0)})(4)
                    AEtextbox.Text = ds.Tables("[REPORT]").Rows.Find(New Object(0) {dt(4).Rows(rowIndex)(0)})(5)
                Catch

                End Try
                If isca And (Not CA1TextBox.Text.Equals("") Or Not CA2TextBox.Text.Equals("")) Then

                    signButton.Enabled = True
                End If

                Dim tu As TableUpdate = New TableUpdate()

                tu.update(cn, da(14), ds, tablename(14))
                tu.update(cn, da(15), ds, tablename(15))
                tu.update(cn, da(18), ds, tablename(18))


            Case Else
                If S2GridK4.Rows.Count = 0 Then
                    Return
                End If
                da(14) = New OleDbDataAdapter("select * from [S2_SYS2]", cn)
                da(14).Fill(ds, "[S2_SYS2]")

                key = New DataColumn(0) {New DataColumn}
                key(0) = ds.Tables("[S2_SYS2]").Columns("ObjectID")
                ds.Tables("[S2_SYS2]").PrimaryKey = key
                f5 = New Form5(e.ClickedItem.Text, e.ClickedItem.Tag, ds, staffid, ownsystemid)

                f5.ShowDialog()
                If f5.isclose Then
                    Return
                End If
                Try

                    dt(4).Rows(rowIndex)(2) = f5.dec
                    dt(4).Rows(rowIndex)(4) = f5.cri
                    dt(4).Rows(rowIndex)(1) = f5.typename

                Catch ex As Exception
                    MessageBox.Show(ex.Message)

                End Try
        End Select
        SaveDataBase.Enabled = True

    End Sub

    Private Sub ToolStripMenuItem29_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStripMenuItem29.DropDownItemClicked
        Dim key(0) As Object
        Dim f5 As Form5
        da(16) = New OleDbDataAdapter("select * from [S2_SYS2]", cn)
        da(16).Fill(ds, "[S2_SYS2]")
        Dim drr As DataRow = ds.Tables("[S2_SYS2]").NewRow()
        drr("ObjectID") = Convert.ToInt32(ds.Tables("[S2_SYS2]").Rows(ds.Tables("[S2_SYS2]").Rows.Count - 1)("ObjectID")) + 1
        drr("STAFFID") = staffid
        key = New DataColumn(0) {New DataColumn}
        key(0) = ds.Tables("[S2_SYS2]").Columns("ObjectID")
        ds.Tables("[S2_SYS2]").PrimaryKey = key
        Dim dr As DataRow = dt(4).NewRow()
        f5 = New Form5(e.ClickedItem.Text, e.ClickedItem.Tag, ds, staffid, ownsystemid
                      )

        f5.ShowDialog()
        If f5.isclose Then
            Return
        End If


        dr(2) = f5.dec
        dr(4) = f5.cri
        dr(1) = f5.typename
        dr(5) = ""


        drr(1) = ownsystemid
        drr(2) = dr(2)
        drr(3) = dr(5)
        drr(4) = False
        drr(5) = False
        drr(7) = " "
        drr(8) = ""
        If Not dr(2).ToString().Equals("") Then

            ds.Tables("[S2_SYS2]").Rows.Add(drr)

            Dim tu As TableUpdate = New TableUpdate()
            tu.update(cn, da(14), ds, tablename(14))
            da(14).Fill(ds, "[S2_SYS2]")
            '  da(14).
            dr(0) = ds.Tables("[S2_SYS2]").Rows(ds.Tables("[S2_SYS2]").Rows.Count - 1)(0)
            owns2k4ObjectId = dr(0)
            dt(4).Rows.InsertAt(dr, rowIndex + 1)
            Dim dr2 As DataRow = ds.Tables("[REPORT]").NewRow()
            dr2(0) = ds.Tables("[REPORT]").Rows(ds.Tables("[REPORT]").Rows.Count - 1)(0) + 1
            dr2(1) = Format(ds.Tables("[REPORT]").Rows(ds.Tables("[REPORT]").Rows.Count - 1)(1) + 1, "0000")
            dr2(2) = False
            dr2(3) = ""
            dr2(4) = ""
            dr2(5) = ""
            dr2(6) = ds.Tables("[S2_SYS2]").Rows(ds.Tables("[S2_SYS2]").Rows.Count - 1)(0)
            ds.Tables("[REPORT]").Rows.Add(dr2)
            '   ds.Tables("[REPORT]").Rows.Add(dr2)
            tu.update(cn, da(18), ds, tablename(18))
            da(18).Fill(ds, tablename(18))
        End If
       
        SaveDataBase.Enabled = True
    End Sub




    Private Sub DataGridView5_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles S2GridK4.CellEndEdit
        Dim key(0) As Object
        Dim key2(0) As Object

        key(0) = S2GridK4.Rows(e.RowIndex).Cells("objectid").Value
        ' key2(0) = DataGridView9.Rows(e.RowIndex).Cells(7).Value
        'If DataGridView9.Rows(e.RowIndex).Cells(4).Value Then
        ds.Tables("[S2_SYS2]").Rows.Find(key)("ICAO_NO_SYS_DESCRIPTION") = S2GridK4.Rows(e.RowIndex).Cells(2).Value
        ds.Tables("[S2_SYS2]").Rows.Find(key)("CLASS_NAME_NO") = S2GridK4.Rows(e.RowIndex).Cells(4).Value
        ds.Tables("[S2_SYS2]").Rows.Find(key)("VERIFIED") = S2GridK4.Rows(e.RowIndex).Cells(3).Value
        ds.Tables("[S2_SYS2]").Rows.Find(key)("DATE_") = S2GridK4.Rows(e.RowIndex).Cells(5).Value
        SaveDataBase.Enabled = True

        ds.Tables("[S2_SYS2]").Rows.Find(key)("LEVEL_") = S2GridK4.Rows(e.RowIndex).Cells(7).Value
        ' MessageBox.Show(ds.Tables("[S2_SYS2]").Rows.Find(key)("LEVEL_"))
    End Sub

    Private Sub AddToolStripMenuItem_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles AddToolStripMenuItem.DropDownItemClicked
        Dim key(0) As Object
        Dim f4 As Form4

        f4 = New Form4(e.ClickedItem.Text, e.ClickedItem.Tag, ds)
        If rowIndex = -1 Then
            S5fullLVContextMenuStrip.Items(1).Enabled = True
            S5fullLVContextMenuStrip.Items(2).Enabled = True
            S5fullLVContextMenuStrip.Items(3).Enabled = True
            S5fullLVContextMenuStrip.Items(4).Enabled = True
            S5fullLVContextMenuStrip.Items(5).Enabled = True
            S5fullLVContextMenuStrip.Items(6).Enabled = True
            S5fullLVContextMenuStrip.Items(7).Enabled = True
            S5fullLVContextMenuStrip.Items(8).Enabled = True
            S5fullLVContextMenuStrip.Items(9).Enabled = True
            S5fullLVContextMenuStrip.Items(10).Enabled = True

        End If
        f4.ShowDialog()
        If Not f4.endedit Then



        Else
            


            'drr("ObjectID") = Convert.ToInt32(ds.Tables("[S5_OJTI]").Rows(ds.Tables("[S5_OJTI]").Rows.Count - 1)("ObjectID")) + 1
            Dim dr As DataRow = ds.Tables("[S5_DESC]").NewRow()
            If ds.Tables("[S5_DESC]").Rows.Count = 0 Then
                dr("ObjectID") = 1
            Else
                dr("ObjectID") = Convert.ToInt32(ds.Tables("[S5_DESC]").Rows(ds.Tables("[S5_DESC]").Rows.Count - 1)("ObjectID")) + 1
            End If

            dr("SUB_TYPE") = rowIndex + 1
            dr("TYPE") = e.ClickedItem.Tag
            dr("LV") = 1
            dr("DESCRIPTION") = f4.dec
            dr("CRITERIA") = f4.cri
            dr("SYSTEMID") = ownsystemid
            ds.Tables("[S5_DESC]").Rows.Add(dr)
            Dim tu As TableUpdate = New TableUpdate()
            tu.update(cn, da(6), ds, tablename(6))
            da(6).Fill(ds, tablename(6))

            Dim drr As DataRow = ds.Tables("[S5_OJTI]").NewRow()
            If ds.Tables("[S5_OJTI]").Rows.Count = 0 Then
                drr("ObjectID") = 1
            Else

                drr("ObjectID") = Convert.ToInt32(ds.Tables("[S5_OJTI]").Rows(ds.Tables("[S5_OJTI]").Rows.Count - 1)("ObjectID")) + 1
            End If
            drr("TYPE") = e.ClickedItem.Tag
            drr("SYSTEMID") = ownsystemid
            drr("STAFFID") = staffid
            drr("SUB_TYPE") = dr("SUB_TYPE")
            drr("DESCID") = ds.Tables(tablename(6)).Rows(ds.Tables(tablename(6)).Rows.Count - 1)("ObjectID")
            drr("LV") = 1
            drr("COMMENTS") = ""
            ds.Tables("[S5_OJTI]").Rows.Add(drr)



            da(14) = New OleDbDataAdapter("select * from [SAMPLE_QUESTION]", cn)
            da(14).Fill(ds, "[SAMPLE_QUESTION]")

            key = New DataColumn(0) {New DataColumn}
            key(0) = ds.Tables("[SAMPLE_QUESTION]").Columns("ObjectID")
            ds.Tables("[SAMPLE_QUESTION]").PrimaryKey = key
            Dim dr2 As DataRow = dt(2).NewRow()
            dr2(6) = dr("ObjectID")
            dr2(7) = drr("ObjectID")
            dt(2).Rows.InsertAt(dr2, rowIndex + 1)
            dt(2).Rows(rowIndex + 1)(2) = f4.dec
            dt(2).Rows(rowIndex + 1)(3) = f4.cri
            dt(2).Rows(rowIndex + 1)(1) = f4.typename
            dt(2).Rows(rowIndex + 1)(8) = f4.typeid
            dt(2).Rows(rowIndex + 1)(0) = "C" + e.ClickedItem.Text.Split(".")(0)
            dt(2).Rows(rowIndex + 1)(4) = ""

           

            dv = New DataView(dt(2))
            dv.Sort = dt(2).Columns(8).ColumnName + " ASC"
            dt(2) = dv.ToTable()
            dt(2).AcceptChanges()
            S3Grid1.Update()
            S3Grid1.DataSource = dt(2)
            SaveDataBase.Enabled = True





        End If

    End Sub

    Private Sub S3funContextMenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles S5fullLVContextMenuStrip.ItemClicked
        Dim key(0) As Object
        Dim key2(0) As Object
        Dim f4 As Form4
        Select Case e.ClickedItem.Tag
            Case "add"

            Case "del"

                key(0) = S5Grid1.Rows(rowIndex).Cells(6).Value
                key2(0) = S5Grid1.Rows(rowIndex).Cells(7).Value
                ds.Tables("[S5_DESC]").Rows.Find(key).Delete()
                ds.Tables("[S5_OJTI]").Rows.Find(key2).Delete()

                dt(2).Rows(rowIndex).Delete()
            Case Else
                da(14) = New OleDbDataAdapter("select * from [SAMPLE_QUESTION]", cn)
                da(14).Fill(ds, "[SAMPLE_QUESTION]")

                key = New DataColumn(0) {New DataColumn}
                key(0) = ds.Tables("[SAMPLE_QUESTION]").Columns("ObjectID")
                ds.Tables("[SAMPLE_QUESTION]").PrimaryKey = key
                f4 = New Form4(e.ClickedItem.Text, e.ClickedItem.Tag, ds)

                f4.ShowDialog()
                If Not f4.endedit Then
                    Return
                End If
                dt(2).Rows(rowIndex)(2) = f4.dec
                dt(2).Rows(rowIndex)(3) = f4.cri
                dt(2).Rows(rowIndex)(1) = f4.typename
                dt(2).Rows(rowIndex)(8) = f4.typeid
                dt(2).Rows(rowIndex)(0) = "C" + e.ClickedItem.Tag

        End Select
        dv = New DataView(dt(2))
        dv.Sort = dt(2).Columns(8).ColumnName + " ASC"
        dt(2) = dv.ToTable()
        dt(2).AcceptChanges()
        S5Grid1.Update()

        S5Grid1.DataSource = dt(2)
        SaveDataBase.Enabled = True
    End Sub

    Private Sub S3funContextMenuStrip_Closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles S5fullLVContextMenuStrip.Closing
        S5Grid1.ContextMenuStrip = Nothing
        S5Grid1.ContextMenu = Nothing
    End Sub

    Private Sub DataGridView1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles S3Grid1.MouseClick
        If S3Grid1.Rows.Count = 0 Then
            S5fullLVContextMenuStrip.Items(1).Enabled = False
            S5fullLVContextMenuStrip.Items(2).Enabled = False
            S5fullLVContextMenuStrip.Items(3).Enabled = False
            S5fullLVContextMenuStrip.Items(4).Enabled = False
            S5fullLVContextMenuStrip.Items(5).Enabled = False
            S5fullLVContextMenuStrip.Items(6).Enabled = False
            S5fullLVContextMenuStrip.Items(7).Enabled = False
            S5fullLVContextMenuStrip.Items(8).Enabled = False
            S5fullLVContextMenuStrip.Items(9).Enabled = False
            S5fullLVContextMenuStrip.Items(10).Enabled = False




            S5fullLVContextMenuStrip.Items(2).Enabled = False
            S3Grid1.ContextMenuStrip = S5fullLVContextMenuStrip
            S3Grid1.ContextMenuStrip.Show(MousePosition)
            rowIndex = -1
        End If
    End Sub


    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click
        Dim index As Integer = TabControl1.SelectedTab.Tag
        PreviewButton.Enabled = True
        Select Case TabControl1.SelectedTab.Text

            Case S1TabPage.Text
                Dim tu As TableUpdate = New TableUpdate()

                tu.update(cn, da(0), ds, tablename(0))
                tu.update(cn, da(1), ds, tablename(1))

            Case S2TabPage.Text
                Dim tu As TableUpdate = New TableUpdate()

                tu.update(cn, da(14), ds, tablename(14))
                tu.update(cn, da(15), ds, tablename(15))
            Case S3TabPage.Text
                Dim tu As TableUpdate = New TableUpdate()

                tu.update(cn, da(2), ds, tablename(2))
            Case S4TabPage.Text
                Dim tu As TableUpdate = New TableUpdate()

                tu.update(cn, da(4), ds, tablename(4))
                tu.update(cn, da(5), ds, tablename(5))
            Case S5TabPage.Text
                Dim tu As TableUpdate = New TableUpdate()

                tu.update(cn, da(6), ds, tablename(6))
                tu.update(cn, da(7), ds, tablename(7))

                tu.update(cn, da(18), ds, tablename(18))
                tu.update(cn, da(8), ds, tablename(8))

        End Select
        If tpgostructuie(index) = 3 Then
            If ds.Tables("[REPORT]").Rows.Find(New Object(0) {s2ObjectId})("APPROVED") Then

                ''
                ''
                ''
                ''
                ''
                ''
                ''
                ''
                ''
                ''
                'initialize(S3)
                '  Try

                '   Catch

                '   End Try
                dt(0) = dt(2).Clone()


                For Each dr As DataRow In dt(2).Rows
                    dr(4) = ""
                    dr(7) = ""
                    dt(0).ImportRow(dr)
                Next

                Dim dc2 As DataColumn() = New DataColumn(0) {New DataColumn()}
                dc2(0) = dt(2).Columns(6)
                dt(2).PrimaryKey = dc2
                Dim dc As DataColumn() = New DataColumn(0) {New DataColumn()}
                dc(0) = dt(0).Columns(6)
                dt(0).PrimaryKey = dc

                For Each dr As DataRow In ds.Tables("[S3_COMMENTS]").Rows
                    If dr("STAFFID") = staffid Then
                        Try
                            dt(0).Rows.Find(New Object(0) {dr("DESCID")})(4) = dr("COMMENTS")
                            dt(0).Rows.Find(New Object(0) {dr("DESCID")})(7) = dr("ObjectID")
                        Catch ex As Exception
                            '  MessageBox.Show(ex.Message)
                        End Try
                    End If
                Next
                'Dim now As Integer = 0


                dv = New DataView(dt(0))
                dv.Sort = dt(0).Columns(8).ColumnName + " ASC"
                dt(0) = dv.ToTable()
                dt(0).AcceptChanges()
                TabControl1.TabPages.Add(S3TabPage)
                S3Grid1.Columns.Clear()
                S3Grid1.DataSource = dt(0)

                S3Grid1.Columns(5).Visible = False
                S3Grid1.Columns(6).Visible = False
                S3Grid1.Columns(7).Visible = False
                S3Grid1.Columns(8).Visible = False
                S3Grid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                S3Grid1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                S3Grid1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                TabControl1.TabPages.Remove(TabControl1.SelectedTab)

                If tpgostructuie(index) = 1 Then
                    NextButton.Enabled = False
                End If
                PreviewButton.Enabled = True
            Else
                MessageBox.Show("Not appoved!")
            End If

        Else
            TabControl1.TabPages.Remove(TabControl1.SelectedTab)
            TabControl1.TabPages.Add((tp(tpgostructuie(index) - 1)))
            If tpgostructuie(index) = 1 Or tpgostructuie(index) = 2 Then

                NextButton.Enabled = False
            End If


            PreviewButton.Enabled = True
        End If

        


    End Sub

    Private Sub PreviewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewButton.Click
        Dim index As Integer = TabControl1.SelectedTab.Tag
        NextButton.Enabled = True
        Select Case TabControl1.SelectedTab.Text

            Case S1TabPage.Text
                Dim tu As TableUpdate = New TableUpdate()

                tu.update(cn, da(0), ds, tablename(0))
                tu.update(cn, da(1), ds, tablename(1))

            Case S2TabPage.Text
                Dim tu As TableUpdate = New TableUpdate()

                tu.update(cn, da(15), ds, tablename(15))
                tu.update(cn, da(16), ds, tablename(16))

            Case S3TabPage.Text
                Dim tu As TableUpdate = New TableUpdate()

                tu.update(cn, da(2), ds, tablename(2))
                tu.update(cn, da(3), ds, tablename(3))
            Case S4TabPage.Text
                Dim tu As TableUpdate = New TableUpdate()

                tu.update(cn, da(4), ds, tablename(4))
                tu.update(cn, da(5), ds, tablename(5))
            Case S5TabPage.Text
                Dim tu As TableUpdate = New TableUpdate()

                tu.update(cn, da(6), ds, tablename(6))
                tu.update(cn, da(7), ds, tablename(7))
                completedButton.Enabled = True

        End Select
        TabControl1.TabPages.Remove(TabControl1.SelectedTab)
        TabControl1.TabPages.Add((tp(tpbackstructuie(index) - 1)))
        If tpbackstructuie(index) = 2 Then

            PreviewButton.Enabled = False
            NextButton.Enabled = False

            ''
            ''
            ''
            ''
            ''
            ''
            ''
            ''
            ''
            ''
            ''
            ''
            ''initialize S2_SYS
            dt(4) = New DataTable()

            dt(4).Columns.AddRange(New DataColumn(6) {New DataColumn("ObjectID"),
                                                     New DataColumn("TYPE"),
                                                     New DataColumn("Description"),
                                                     New DataColumn("(Y/N)"),
                                                     New DataColumn("CLASS"),
                                                     New DataColumn("DATE"),
            New DataColumn("Level")
                                                     })
            dt(4).Columns(0).ColumnName = "objectid"
            dt(4).Columns(3).DataType = GetType(Boolean) ' change column type to boolean'
            'dt(4).Columns(6).DataType = GetType(DataGridViewComboBoxColumn)

            'Dim nameS2_SYS() As String = New String(3) {"Completed Basic Training", "Completed Qualification Training", "Completed System Safety Training", "Completed Equipment Rating Training (L1/L2)"}
            Dim keys() As Object = New Object(0) {New Object()}

            Dim dc As DataColumn() = New DataColumn(0) {New DataColumn()}
            dc(0) = dt(3).Columns(2)
            dt(3).PrimaryKey = dc
            dc = New DataColumn(0) {New DataColumn()}
            dc(0) = dt(4).Columns(0)
            dt(4).PrimaryKey = dc
            For Each dr As DataRow In ds.Tables("[S2_SYS2]").Rows
                If dr("SYSTEMID").ToString() = ownsystemid And Not dr("IS_ICAO") And dr("STAFFID") = staffid Then
                    Dim drRow As DataRow = dt(4).NewRow
                    drRow(0) = dr("ObjectID")
                    drRow(1) = "Equipment Course"
                    drRow(2) = dr("ICAO_NO_SYS_DESCRIPTION")
                    Try
                        drRow(3) = dr("VERIFIED").ToString()
                    Catch ex As Exception
                        drRow(3) = False
                    End Try

                    drRow(4) = dr("CLASS_NAME_NO")
                    drRow(5) = dr("DATE_")
                    drRow(6) = dr("LEVEL_")
                    dt(4).Rows.Add(drRow)
                ElseIf dr("IS_ICAO") Then
                    If dr("SYSTEMID").ToString() = ownsystemid And dr("STAFFID") = staffid Then
                        keys(0) = dr(2).ToString()
                        dt(3).Rows.Find(keys)(4) = dr("VERIFIED").ToString()
                        dt(3).Rows.Find(keys)(5) = dr("CLASS_NAME_NO")
                        dt(3).Rows.Find(keys)(6) = dr("DATE_")
                        dt(3).Rows.Find(keys)(7) = dr("ObjectID")
                    End If
                End If
            Next

            S2GridK4.Columns.Clear()
            S2GridK4.DataSource = dt(4)
            Dim dgc As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
            Dim combdt As DataTable = New DataTable()
            combdt.Columns.Add(New DataColumn("value"))
            combdt.Columns.Add(New DataColumn("test"))
            combdt.Rows.Add("1", "N/A")
            combdt.Rows.Add("2", "Level 1")
            combdt.Rows.Add("3", "Level 2")
            combdt.Rows.Add("4", "Full Level")
            dgc.Name = "level"
            dgc.DisplayMember = "test"
            dgc.ValueMember = "value"
            ' dgc.DataSource = combdt

            S2GridK4.Columns(0).Visible = False
            S2GridK4.Columns(6).Visible = False
            S2GridK4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            S2GridK4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            S2GridK4.DefaultCellStyle.WrapMode = DataGridViewTriState.True

            For Each ii As DataGridViewColumn In S2GridK4.Columns
                ii.SortMode = False
            Next
            dv = New DataView(dt(4))
            dv.Sort = dt(4).Columns(0).ColumnName + " DESC"
            'S2GridK4.Sort(S2GridK4.Columns(0), System.ComponentModel.ListSortDirection.Descending)
            dgc.Items.AddRange("N/A", "Level 1", "Level 2", "Full Level")
            S2GridK4.Columns.Add(dgc)
            For Each dgr As DataGridViewRow In S2GridK4.Rows
                Dim cb As DataGridViewComboBoxCell = dgr.Cells(7)

                Select Case dgr.Cells(6).Value
                    Case "N/A"
                        cb.Value = dgc.Items.Item(0)
                    Case "Level 1"
                        cb.Value = dgc.Items.Item(1)
                    Case "Level 2"
                        cb.Value = dgc.Items.Item(2)
                    Case "Full Level"
                        cb.Value = dgc.Items.Item(3)

                End Select
            Next
            SaveDataBase.Enabled = True

            TabControl1.Visible = True
            TabControl1.SelectedTab = S2TabPage

           

        End If

    End Sub


    Private Sub DataGridView3_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles S5Grid1.CellEndEdit
        Dim key(0) As Object
        Dim key2(0) As Object
        key(0) = S5Grid1.Rows(e.RowIndex).Cells(6).Value
        key2(0) = S5Grid1.Rows(e.RowIndex).Cells(7).Value
        Try
            ds.Tables("[S5_OJTI]").Rows.Find(key2)("COMMENTS") = S5Grid1.Rows(e.RowIndex).Cells(4).Value

        Catch
            Dim dr As DataRow = ds.Tables("[S5_OJTI]").NewRow()
            dr("DESCID") = S5Grid1.Rows(e.RowIndex).Cells(0).Value
            dr(0) = ds.Tables("[S5_OJTI]").Rows(ds.Tables("[S5_OJTI]").Rows.Count - 1)(0) + 1
            dr(1) = S5Grid1.Rows(e.RowIndex).Cells(8).Value.ToString()
            dr(2) = ownsystemid
            dr(3) = staffid
            dr(4) = S5Grid1.Rows(e.RowIndex).Cells(4).Value
            dr(5) = ""
            dr(6) = "0"
            ds.Tables("[S5_OJTI]").Rows.Add(dr)
        End Try
        ds.Tables("[S5_DESC]").Rows.Find(key)("DESCRIPTION") = S5Grid1.Rows(e.RowIndex).Cells(2).Value
        ds.Tables("[S5_DESC]").Rows.Find(key)("CRITERIA") = S5Grid1.Rows(e.RowIndex).Cells(3).Value
        ds.Tables("[S5_DESC]").Rows.Find(key)("SYSTEMID") = ownsystemid
        SaveDataBase.Enabled = True
    End Sub

    Private Sub DataGridView3_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles S5Grid1.MouseClick
        If S5Grid1.Rows.Count = 0 Then
            'S5Grid1.ContextMenuStrip.Items(1).Enabled = False
            If ismultlv Then
                S5muitiLVContextMenuStrip.Items(1).Enabled = False
                S5muitiLVContextMenuStrip.Items(2).Enabled = False
                S5muitiLVContextMenuStrip.Items(3).Enabled = False
                S5muitiLVContextMenuStrip.Items(4).Enabled = False
                S5muitiLVContextMenuStrip.Items(5).Enabled = False
                S5muitiLVContextMenuStrip.Items(6).Enabled = False
                S5muitiLVContextMenuStrip.Items(7).Enabled = False
                S5muitiLVContextMenuStrip.Items(8).Enabled = False
                S5muitiLVContextMenuStrip.Items(9).Enabled = False
                S5muitiLVContextMenuStrip.Items(10).Enabled = False
                S5muitiLVContextMenuStrip.Items(11).Enabled = False
                S5muitiLVContextMenuStrip.Items(12).Enabled = False
                S5muitiLVContextMenuStrip.Items(13).Enabled = False
                S5muitiLVContextMenuStrip.Items(14).Enabled = False
                S5muitiLVContextMenuStrip.Items(15).Enabled = False
                S5muitiLVContextMenuStrip.Items(16).Enabled = False
                S5muitiLVContextMenuStrip.Items(17).Enabled = False
                S5Grid1.ContextMenuStrip = S5muitiLVContextMenuStrip
            Else
                S5fullLVContextMenuStrip.Items(1).Enabled = False
                S5fullLVContextMenuStrip.Items(2).Enabled = False
                S5fullLVContextMenuStrip.Items(3).Enabled = False
                S5fullLVContextMenuStrip.Items(4).Enabled = False
                S5fullLVContextMenuStrip.Items(5).Enabled = False
                S5fullLVContextMenuStrip.Items(6).Enabled = False
                S5fullLVContextMenuStrip.Items(7).Enabled = False
                S5fullLVContextMenuStrip.Items(8).Enabled = False
                S5fullLVContextMenuStrip.Items(9).Enabled = False
                S5fullLVContextMenuStrip.Items(10).Enabled = False
                S5Grid1.ContextMenuStrip = S5fullLVContextMenuStrip
            End If

            S5Grid1.ContextMenuStrip.Show(MousePosition)
            rowIndex = -1
        End If
    End Sub



    Private Sub S5funContextMenuStrip_Closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles S5muitiLVContextMenuStrip.Closing
        S5Grid1.ContextMenuStrip = Nothing
        S5Grid1.ContextMenu = Nothing
    End Sub


    Private Sub DataGridView2_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellEndEdit
        Dim key(0) As Object
        Dim key2(0) As Object
        key(0) = DataGridView2.Rows(e.RowIndex).Cells(6).Value
        key2(0) = DataGridView2.Rows(e.RowIndex).Cells(7).Value
        Try
            ds.Tables("[S4_GUIDELINE]").Rows.Find(key2)("GUIDELINE") = DataGridView2.Rows(e.RowIndex).Cells(4).Value

        Catch
        End Try
        ds.Tables("[S4_DESC]").Rows.Find(key)("DESCRIPTION") = DataGridView2.Rows(e.RowIndex).Cells(2).Value
        ds.Tables("[S4_DESC]").Rows.Find(key)("CRITERIA") = DataGridView2.Rows(e.RowIndex).Cells(3).Value
        ds.Tables("[S4_DESC]").Rows.Find(key)("SYSTEMID") = ownsystemid
        SaveDataBase.Enabled = True
    End Sub

    Private Sub DataGridView2_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        If DataGridView2.Rows.Count = 0 Then
            S4funContextMenuStrip.Items(1).Enabled = False
            S4funContextMenuStrip.Items(2).Enabled = False
            S4funContextMenuStrip.Items(3).Enabled = False
            S4funContextMenuStrip.Items(4).Enabled = False
            S4funContextMenuStrip.Items(5).Enabled = False
            S4funContextMenuStrip.Items(6).Enabled = False
            S4funContextMenuStrip.Items(7).Enabled = False
            S4funContextMenuStrip.Items(8).Enabled = False
            S4funContextMenuStrip.Items(9).Enabled = False
            S4funContextMenuStrip.Items(10).Enabled = False




            S4funContextMenuStrip.Items(2).Enabled = False
            DataGridView2.ContextMenuStrip = S4funContextMenuStrip
            DataGridView2.ContextMenuStrip.Show(MousePosition)
            rowIndex = -1
        End If
    End Sub


    Private Sub DataGridView9_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles S2Grid.CellDoubleClick


        If e.ColumnIndex = 6 Then
            If Not S2Grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.Equals("") And Not S2Grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.Equals(DBNull.Value) Then
                Dim f6 As Form6 = New Form6(Convert.ToDateTime(S2Grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value))
                f6.ShowDialog()
                If f6.hasvalue Then
                    If Not f6.isnothing Then
                        S2Grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = f6.dateinfo.Value.ToString("dd/MM/yyyy")
                    Else
                        S2Grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
                    End If
                End If
            Else
                Dim f6 As Form6 = New Form6
                f6.ShowDialog()
                If f6.hasvalue Then
                    If Not f6.isnothing Then
                        S2Grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = f6.dateinfo.Value.ToString("dd/MM/yyyy")
                    Else
                        S2Grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
                    End If
                End If
            End If
            Dim key(0) As Object
            key(0) = S2Grid.Rows(e.RowIndex).Cells(7).Value
            ds.Tables("[S2_SYS2]").Rows.Find(key)("DATE_") = S2Grid.Rows(e.RowIndex).Cells(6).Value
            SaveDataBase.Enabled = True
        End If


    End Sub

    Private Sub DataGridView9_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles S2Grid.CellBeginEdit
        If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 6 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub DataGridView5_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles S2GridK4.CellBeginEdit
        If e.ColumnIndex = 5 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub DataGridView5_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles S2GridK4.CellDoubleClick
        If e.ColumnIndex = 5 Then
            If Not S2GridK4.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.Equals("") And Not S2GridK4.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.Equals(DBNull.Value) Then
                Dim f6 As Form6 = New Form6(Convert.ToDateTime(S2GridK4.Rows(e.RowIndex).Cells(e.ColumnIndex).Value))
                f6.ShowDialog()
                If f6.hasvalue Then
                    If Not f6.isnothing Then
                        S2GridK4.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = f6.dateinfo.Value.ToString("dd/MM/yyyy")


                    Else
                        S2GridK4.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""

                    End If
                End If
            Else
                Dim f6 As Form6 = New Form6
                f6.ShowDialog()
                If f6.hasvalue Then
                    If Not f6.isnothing Then
                        S2GridK4.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = f6.dateinfo.Value.ToString("dd/MM/yyyy")

                    Else
                        S2GridK4.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
                    End If
                End If
            End If
            ds.Tables("[S2_SYS2]").Rows.Find(New Object(0) {S2GridK4.Rows(e.RowIndex).Cells(0).Value})("DATE_") = S2GridK4.Rows(e.RowIndex).Cells(5).Value
            SaveDataBase.Enabled = True
        End If
    End Sub

    'Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
    'FIND2.Enabled = True
    'End Sub
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StaffNoTextBox.TextChanged
        FIND2.Enabled = True
    End Sub

    Private Sub S2_SYS_funContextMenuStrip_Closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles S2_SYS_funContextMenuStrip.Closing
        S2GridK4.ContextMenuStrip = Nothing
        S2GridK4.ContextMenu = Nothing
    End Sub

    Private Sub S2_ICAO_funContextMenuStrip_Closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles S2_ICAO_funContextMenuStrip.Closing
        S2Grid.ContextMenuStrip = Nothing
        S2Grid.ContextMenu = Nothing
    End Sub

    Private Sub S4funContextMenuStrip_Closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles S4funContextMenuStrip.Closing
        DataGridView2.ContextMenuStrip = Nothing
        DataGridView2.ContextMenu = Nothing
    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim reportlist As List(Of S3ReportClass) = New List(Of S3ReportClass)
        Dim typechk As String = ""

        Dim c1 As String
        Dim c2 As String
        Dim c3 As String
        Dim c4 As String
        Dim c5 As String
        Dim c6 As String
        Dim c7 As String
        Dim c8 As String
        Dim c9 As String

        If ismultlv Then
            c3 = "C3:Knowledge on contingency/back up measures"
            c4 = "C4:Circuitry Understanding"
            c5 = "C5:Conversant with detailed measurement setup"
            c6 = "C6:Proficiency in the use of appropriate test intstruments"
            c7 = "C7:Proficiency in the use of specialized tools"
            c8 = "C8:Measurement data interpretion"
            c9 = "C9:Tuning/adjustment techiques"
        Else
            c3 = "C3 Instrumentation Competence: Proficiency in the use of appropriate test instruments"
            c4 = "C4 System Monitoring Competence: Measurement"
            c5 = "C5 Preventive Maintenance Competence: Level of conversant with the operation, maintenance and service restoration procedures"
            c6 = "C6 System Health Competence: Interpretation of system warning/alert messages"
            c7 = "C7 System Diagnosis Competence: System level fault finding/diagnosis techniques"
            c8 = "C8 Documentation Competence: Logbook, DCA133, TEMR and Maintenance Report writing skill"
            c9 = "C9 Communication Competence: Liaison skills with the parties concerned"
        End If

        For Each dr As DataGridViewRow In S3Grid1.Rows
            If dr.Cells(8).Value.ToString().Equals(typechk) Then
            Else

                Select Case dr.Cells(8).Value
                    Case 1
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                        .Head_ = "C1 Safety & Precaution Competence: Awareness of safety and preventive measures", _
.Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum _
                       })
                    Case 2
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = "C2 System Knowledge Competence: Understanding on system/equipment configuration, schematic diagrams and technical operation knowledge"
})
                    Case 3
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = c3
})
                    Case 4
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = c4
})
                    Case 5
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = c5
})
                    Case 6
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = c6
})
                    Case 7
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = c7
})
                    Case 8
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = c8
})
                    Case 9
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = c9
})
                    Case 10
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = "C10: Skilled use of advanced system command, if any"
})
                    Case 11
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = "C11: Level of conversant with the operation, maintenance and service restoration procedures"
})
                    Case 12
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = "C12: Interpetation of system warning/alert messages"
})
                    Case 13
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = "C13: System level fault finding/diagnosis techniques"
})
                    Case 14
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = "C14: Ability of work efficiency"
})
                    Case 15
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = "C15: Logbook, DCA133, TEMR and Maintenance Report writing skill"
})
                    Case 16
                        reportlist.Add(New S3ReportClass() With { _
                .Comm_ = "CA Comments/Remarks", _
                .Crit_ = "Performance Criteria", _
                .Desc_ = "Compentence Description", _
                .TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
                .Title_ = NameTextBox.Text, _
                .System_ = SYSTextBox.Text, _
                .Rowshow_ = True, _
                .Serial_ = systemunit + Format(Convert.ToInt32(ownsystemid), "000") + ownLV + reportnum, _
.Head_ = "C16: Liaison skills with parties concerned"
})
                    Case Else

                End Select
            End If
            reportlist.Add(New S3ReportClass() With { _
.Comm_ = dr.Cells(4).Value, _
.Crit_ = dr.Cells(3).Value, _
.Desc_ = dr.Cells(2).Value, _
.TYPE_ = "C" + dr.Cells(8).Value.ToString(), _
.Title_ = NameTextBox.Text, _
.Rowshow_ = False, _
.System_ = SYSTextBox.Text _
       })

            typechk = dr.Cells(8).Value

        Next

        Dim rvp As ReportviewerPage = New ReportviewerPage()
        rvp.ReportViewer1.LocalReport.DataSources.Clear()
        rvp.ReportViewer1.LocalReport.ReportEmbeddedResource = "ATSEP.Report2.rdlc"
        rvp.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("S3Report", reportlist))
        rvp.ReportViewer1.LocalReport.Refresh()
        rvp.ReportViewer1.RefreshReport()
        rvp.ShowDialog()
    End Sub


    Private Sub DataGridView1_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles S3Grid1.CellBeginEdit
        If Not isca Then
            e.Cancel = True
        End If
    End Sub




    Private Sub S5Grid1_CellBeginEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles S5Grid1.CellBeginEdit
        If isgojti And e.ColumnIndex = 4 Then

        ElseIf isaojti Then

        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub viewstaffButton_Click(sender As System.Object, e As System.EventArgs) Handles viewstaffButton.Click
        Dim staffform As StaffForm = New StaffForm(ds.Tables("[STAFF_INFO]"), ds.Tables("[RELATION]"), ds.Tables("[SYSTEM_INFO]"), ds.Tables("[CERT]"), owncert)
        staffform.ShowDialog()
    End Sub


    Private Sub S2GridK4_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles S2GridK4.MouseClick
        If S2GridK4.RowCount = 0 Then
            If e.Button = MouseButtons.Right Then

            ElseIf isca And isae Then
                S2_SYS_funContextMenuStrip.Items(0).Enabled = True
                S2_SYS_funContextMenuStrip.Items(1).Enabled = True
                S2_SYS_funContextMenuStrip.Items(2).Enabled = True
                S2_SYS_funContextMenuStrip.Items(3).Enabled = True
                S2GridK4.ContextMenuStrip = S2_SYS_funContextMenuStrip
                S2GridK4.ContextMenuStrip.Show(MousePosition)
                rowIndex = 0
            Else
                S2_SYS_funContextMenuStrip.Items(0).Enabled = False
                S2_SYS_funContextMenuStrip.Items(1).Enabled = False
                S2_SYS_funContextMenuStrip.Items(2).Enabled = False
                S2_SYS_funContextMenuStrip.Items(3).Enabled = False
                S2GridK4.ContextMenuStrip = S2_SYS_funContextMenuStrip
                S2GridK4.ContextMenuStrip.Show(MousePosition)
            End If
        End If
    End Sub





    Private Sub completedButton_Click(sender As System.Object, e As System.EventArgs) Handles completedButton.Click

        ds.Tables("[REPORT]").Rows.Find(New Object(0) {s2ObjectId})("APPROVED") = True
        completedButton.Enabled = False
    End Sub

    Private Sub signButton_Click(sender As System.Object, e As System.EventArgs) Handles signButton.Click
        If MessageBox.Show("Ensure?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If ds.Tables("[REPORT]").Rows.Find(New Object(0) {s2ObjectId})(5) = "" Then
                ds.Tables("[REPORT]").Rows.Find(New Object(0) {s2ObjectId})(5) = userName
                CA1TextBox.Text = userName
            Else
                ds.Tables("[REPORT]").Rows.Find(New Object(0) {s2ObjectId})(6) = userName
                CA2TextBox.Text = userName
                Dim tu As TableUpdate = New TableUpdate()
                tu.update(cn, da(18), ds, tablename(18))
                If isae Then
                    appoveCertButton.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub appoveCertButton_Click(sender As System.Object, e As System.EventArgs) Handles appoveCertButton.Click

        If MessageBox.Show("Appoved?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


            If owncert.Equals("NO") Then
                Dim dr As DataRow = ds.Tables("[CERT]").NewRow()
                dr(0) = Format((ds.Tables("[CERT]")(ds.Tables("[CERT]").Rows.Count - 1)(0) + 1), "0000")
                dr(1) = "C"
                dr(2) = Date.Now.ToString("dd/MM/yyyy")
                dr(4) = False
                owncert = systemunit + dr(0)
                Select Case systemunit
                    Case "C"
                        ds.Tables("[STAFF_INFO]").Rows.Find(New Object(0) {staffid})(7) = "C" + dr(0)
                    Case "N"
                        ds.Tables("[STAFF_INFO]").Rows.Find(New Object(0) {staffid})(8) = "N" + dr(0)
                    Case "S"
                        ds.Tables("[STAFF_INFO]").Rows.Find(New Object(0) {staffid})(9) = "S" + dr(0)
                    Case "D"
                        ds.Tables("[STAFF_INFO]").Rows.Find(New Object(0) {staffid})(10) = "D" + dr(0)
                End Select
                ds.Tables("[CERT]").Rows.Add(dr)
            End If
            ds.Tables("[CERT]").Rows.Find(New Object(0) {owncert.Substring(1, 4)})(4) = True

            Dim tu As TableUpdate = New TableUpdate()
            tu.update(cn, da(19), ds, tablename(19))
            tu.update(cn, da(9), ds, tablename(9))
            print.Enabled = True
            appoveCertButton.Enabled = False
        End If

    End Sub

    Private Sub ENDORSEDbutton_Click(sender As System.Object, e As System.EventArgs) Handles ENDORSEDbutton.Click
        If MessageBox.Show("Ensure?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            AEtextbox.Text = userName
            ds.Tables("[REPORT]").Rows.Find(New Object(0) {s2ObjectId})(7) = userName
            Dim tu As TableUpdate = New TableUpdate()
            tu.update(cn, da(18), ds, tablename(18))
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles RichTextBox1.TextChanged, RichTextBox9.TextChanged, RichTextBox8.TextChanged, RichTextBox7.TextChanged, RichTextBox6.TextChanged, RichTextBox5.TextChanged, RichTextBox4.TextChanged, RichTextBox3.TextChanged, RichTextBox2.TextChanged, RichTextBox14.TextChanged, RichTextBox13.TextChanged, RichTextBox12.TextChanged, RichTextBox11.TextChanged, RichTextBox10.TextChanged
        Dim i As Integer = 0
        For Each rich As RichTextBox In rtb
            Try
                ds.Tables("[S1_COM_VERIF]").Rows.Find(New Object() {rich.Tag})("COMMENTS") = rich.Text
            Catch ex As Exception
                Dim dr As DataRow = ds.Tables("[S1_COM_VERIF]").NewRow()
                dr(0) = ds.Tables("[S1_COM_VERIF]").Rows(ds.Tables("[S1_COM_VERIF]").Rows.Count - 1)(0) + 1
                dr(1) = ownsystemid
                dr(2) = staffid
                dr(3) = rich.Text
                dr(4) = i + 1
                dr(5) = chb(i).Checked
                dr(6) = s2ObjectId
            End Try
            i = i + 1
        Next


    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged, CheckBox9.CheckedChanged, CheckBox8.CheckedChanged, CheckBox7.CheckedChanged, CheckBox6.CheckedChanged, CheckBox5.CheckedChanged, CheckBox4.CheckedChanged, CheckBox3.CheckedChanged, CheckBox2.CheckedChanged, CheckBox14.CheckedChanged, CheckBox13.CheckedChanged, CheckBox12.CheckedChanged, CheckBox11.CheckedChanged, CheckBox10.CheckedChanged
        Dim i As Integer = 0
        For Each check As CheckBox In chb
            Try
                ds.Tables("[S1_COM_VERIF]").Rows.Find(New Object() {check.Tag})("COMMENTS") = check.Text
            Catch ex As Exception
                Dim dr As DataRow = ds.Tables("[S1_COM_VERIF]").NewRow()
                dr(0) = ds.Tables("[S1_COM_VERIF]").Rows(ds.Tables("[S1_COM_VERIF]").Rows.Count - 1)(0) + 1
                dr(1) = ownsystemid
                dr(2) = staffid
                dr(3) = rtb(i).Text
                dr(4) = i + 1
                dr(5) = check.Checked
                dr(6) = s2ObjectId
            End Try
            i = i + 1
        Next
    End Sub
End Class
