Public Class PDFviewer

    Sub PDFviewer()

    End Sub

    Private Sub AxAcroPDF1_MouseCaptureChanged(sender As System.Object, e As System.EventArgs) Handles AxAcroPDF1.MouseCaptureChanged
        MessageBox.Show("test")
    End Sub
End Class