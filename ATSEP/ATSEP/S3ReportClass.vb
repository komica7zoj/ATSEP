Public Class S3ReportClass
    Private _Head As String
    Private _TYPE As String
    Private _Desc As String
    Private _Crit As String
    Private _Comm As String
    Private _Title As String
    Private _System As String
    Private _Serial As String
    Private _Rowshow As Boolean = True


    Property Rowshow_ As Boolean
        Get
            Return _Rowshow
        End Get
        Set(ByVal value As Boolean)
            _Rowshow = value
        End Set
    End Property
    Property Serial_ As String
        Get
            Return _Serial
        End Get
        Set(ByVal value As String)
            _Serial = value
        End Set
    End Property
    Property Head_ As String
        Get
            Return _Head
        End Get
        Set(ByVal value As String)
            _Head = value
        End Set
    End Property

    Property System_ As String
        Get
            Return _System
        End Get
        Set(ByVal value As String)
            _System = value
        End Set
    End Property
    Property Title_ As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
        End Set
    End Property

    Property Desc_ As String
        Get
            Return _Desc
        End Get
        Set(ByVal value As String)
            _Desc = value
        End Set
    End Property
    Property TYPE_ As String
        Get
            Return _TYPE
        End Get
        Set(ByVal value As String)
            _TYPE = value
        End Set
    End Property
    Property Crit_ As String
        Get
            Return _Crit
        End Get
        Set(ByVal value As String)
            _Crit = value
        End Set
    End Property
    Property Comm_ As String
        Get
            Return _Comm
        End Get
        Set(ByVal value As String)
            _Comm = value
        End Set
    End Property


End Class
