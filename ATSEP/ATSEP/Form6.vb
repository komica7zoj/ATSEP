Imports System.Data.OleDb
Imports System.Windows.Forms
Public Class Form6

    Public dateinfo As DateTimePicker
    Public hasvalue As Boolean = False
    Public isnothing As Boolean = False
    Public Sub New(Optional ByVal dt As DateTime = Nothing)
        InitializeComponent()
        If dt <> Nothing Then
            DateTimePicker1.Value = dt

        End If


    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        hasvalue = True
        dateinfo = DateTimePicker1
        Me.Close()
    End Sub

    Private Sub Form6_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not hasvalue Then
            dateinfo = Nothing
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        hasvalue = True
        isnothing = True
        Me.Close()
    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

