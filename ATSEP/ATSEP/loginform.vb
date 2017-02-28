Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class loginform
    Dim cm As OleDbCommand
    Dim cn As OleDbConnection
    Dim da(1) As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim tablename(1) As String
    Public staffid As String = ""
    Public staffnub As String = ""
    Public userP As String
    Public userName As String
    Public OJTISys As String
    Public ownform As Form1 = New Form1




    Private Sub loginform_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        '    Dim di As IO.DirectoryInfo = New IO.DirectoryInfo("\\10.100.50.113\softwareunit\temp\")
        '    di.GetFiles("ATSEP_DB.mdb")
        Dim cs As String = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.100.50.225\caelan_2\Temp\ATSEP_LOGIN.accdb;Jet OLEDB:Engine Type=5")
        Dim key() As DataColumn
        cn = New OleDbConnection(cs)


        Try
            da(0) = New OleDbDataAdapter("select * from [STAFF_INFO]", cn)
            da(0).Fill(ds, "[STAFF_INFO]")
            key = New DataColumn(0) {New DataColumn()}
            key(0) = ds.Tables("[STAFF_INFO]").Columns("ObjectID")
            ds.Tables("[STAFF_INFO]").PrimaryKey = key
            tablename(0) = "[STAFF_INFO]"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub


    Private Sub Login_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Login.Click

        For Each dr As DataRow In ds.Tables("[STAFF_INFO]").Rows
            If UID.Text.Equals(dr("STAFFNO_").ToString()) And PWD.Text.Equals(dr("PWD").ToString()) Then
                userP = dr("LV")
                userName = dr(2)
                If dr("LV").Equals("3") Then
                    OJTISys = dr("SYSTEM")
                End If
                Form1.userP = userP
                Form1.OJTISys = OJTISys
                Form1.userName = userName
                Form1.userclose = False
                Me.Close()


                Return

            End If
        Next

    End Sub


    Private Sub Login_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Login.KeyDown
        If e.KeyData = Keys.Enter Then
                   For Each dr As DataRow In ds.Tables("[STAFF_INFO]").Rows
                If UID.Text.Equals(dr("STAFFNO_").ToString()) And PWD.Text.Equals(dr("PWD").ToString()) Then
                    userP = dr("LV")
                    userName = dr(2)
                    If dr("LV").Equals("3") Then
                        OJTISys = dr("SYSTEM")
                    End If
                    Form1.userP = userP
                    Form1.OJTISys = OJTISys
                    Form1.userName = userName
                    Form1.userclose = False
                    Me.Close()


                    Return

                End If
            Next
        End If
    End Sub



    Private Sub PWD_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PWD.KeyDown
        If e.KeyData = Keys.Enter Then
                   For Each dr As DataRow In ds.Tables("[STAFF_INFO]").Rows
                If UID.Text.Equals(dr("STAFFNO_").ToString()) And PWD.Text.Equals(dr("PWD").ToString()) Then
                    userP = dr("LV")
                    userName = dr(2)
                    If dr("LV").Equals("3") Then
                        OJTISys = dr("SYSTEM")
                    End If
                    Form1.userP = userP
                    Form1.OJTISys = OJTISys
                    Form1.userName = userName
                    Form1.userclose = False
                    Me.Close()


                    Return

                End If
            Next
        End If
    End Sub

    Private Sub UID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UID.KeyDown
        If e.KeyData = Keys.Enter Then
                   For Each dr As DataRow In ds.Tables("[STAFF_INFO]").Rows
                If UID.Text.Equals(dr("STAFFNO_").ToString()) And PWD.Text.Equals(dr("PWD").ToString()) Then
                    userP = dr("LV")
                    userName = dr(2)
                    If dr("LV").Equals("3") Then
                        OJTISys = dr("SYSTEM")
                    End If
                    Form1.userP = userP
                    Form1.OJTISys = OJTISys
                    Form1.userName = userName
                    Form1.userclose = False
                    Me.Close()


                    Return

                End If
            Next
        End If
    End Sub

    Private Sub Cancel_Click(sender As System.Object, e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
End Class