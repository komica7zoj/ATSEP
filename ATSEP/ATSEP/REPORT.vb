Public Class REPORT




    Private _CERT_NO_ As String = "Empty"
    Private _STAFFNO_ As String = "Empty"
    Private _STAFFNAME As String = "Empty"
    Private _SYSTEMNAME As String = "Empty"
    Private _CREATDATE As String = "Empty"
    Private _LV As String = "Empty"
    Private _SIGN As Image
    Property SIGN_ As Image
        Get
            Return _SIGN
        End Get
        Set(ByVal value As Image)
            SIGN_ = value
        End Set
    End Property
    Property STAFFNO_ As String
        Get
            Return _STAFFNO_
        End Get
        Set(ByVal value As String)
            _STAFFNO_ = value
        End Set
    End Property
    Property CERT_NO_ As String
        Get
            Return _CERT_NO_
        End Get
        Set(ByVal value As String)
            _CERT_NO_ = value
        End Set
    End Property
    Property STAFFNAME As String
        Get
            Return _STAFFNAME
        End Get
        Set(ByVal value As String)
            _STAFFNAME = value
        End Set
    End Property
    Property SYSTEMNAME As String
        Get
            Return _SYSTEMNAME
        End Get
        Set(ByVal value As String)
            _SYSTEMNAME = value
        End Set
    End Property
    Property CREATDATE As String
        Get
            Return _CREATDATE
        End Get
        Set(ByVal value As String)
            _CREATDATE = value
        End Set
    End Property
    Property LV As String
        Get
            Return _LV
        End Get
        Set(ByVal value As String)
            _LV = value
        End Set
    End Property

    Public Sub REPORT()

    End Sub
End Class
