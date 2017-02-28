Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class ReportviewerPage

    Private Sub ReportviewerPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_PrintingBegin(ByVal sender As System.Object, ByVal e As Microsoft.Reporting.WinForms.ReportPrintEventArgs) Handles ReportViewer1.PrintingBegin

    End Sub


    Private Sub ReportViewer1_ReportExport(sender As System.Object, e As Microsoft.Reporting.WinForms.ReportExportEventArgs) Handles ReportViewer1.ReportExport
        MessageBox.Show(e.Extension.Name)
        e.Cancel = True
 Dim warn As Warning()
        Dim streamids As String()
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty
        Dim byteviewer As Byte()
        Dim deviceinfo As String = "<DeviceInfo><OutputFormat>PDF</OutputFormat><PageWidth>8.5in</PageWidth><PageHeight>11in</PageHeight><MarginTop>0in</MarginTop><MarginLeft>0in</MarginLeft><MarginRight>0in</MarginRight><MarginBottom>0in</MarginBottom></DeviceInfo>"

        Try
            byteviewer = ReportViewer1.LocalReport.Render("PDF", deviceinfo, mimeType, encoding, extension, streamids, warn)
            '   Response.Buffer = True
            Dim fs As New FileStream("c:\temp\myReport.pdf", FileMode.Create)
            fs.Write(byteviewer, 0, byteviewer.Length)
            fs.Close()
        Catch err As Exception
            Dim str As String = err.Message
        End Try
    End Sub
End Class