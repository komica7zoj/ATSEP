Public Class StaffInfoClass
    Private _Staffname As String
    Private _Staffnumber As String
    Private _Cert As String
    Private _Grade As String
    Private _Unit As String
    Private _System As String
    Private _Staffnameshow As Boolean = True
    Private _Staffnumbershow As Boolean = True
    Private _Certshow As Boolean = True
    Private _Gradeshow As Boolean = True
    Private _Unitshow As Boolean = True
    Private _Systemshow As Boolean = True

    Property Systemshow_ As Boolean
        Get
            Return _Systemshow
        End Get
        Set(ByVal value As Boolean)
            _Systemshow = value
        End Set
    End Property
    Property Unitshow_ As Boolean
        Get
            Return _Unitshow
        End Get
        Set(ByVal value As Boolean)
            _Unitshow = value
        End Set
    End Property
    Property Gradeshow_ As Boolean
        Get
            Return _Gradeshow
        End Get
        Set(ByVal value As Boolean)
            _Gradeshow = value
        End Set
    End Property
    Property Certshow_ As Boolean
        Get
            Return _Certshow
        End Get
        Set(ByVal value As Boolean)
            _Certshow = value
        End Set
    End Property

    Property Staffnumbershow_ As Boolean
        Get
            Return _Staffnumbershow
        End Get
        Set(ByVal value As Boolean)
            _Staffnumbershow = value
        End Set
    End Property

    Property Staffnameshow_ As Boolean
        Get
            Return _Staffnameshow
        End Get
        Set(ByVal value As Boolean)
            _Staffnameshow = value
        End Set
    End Property
    Property Unit_ As String
        Get
            Return _Unit
        End Get
        Set(ByVal value As String)
            _Unit = value
        End Set
    End Property
    Property Grade_ As String
        Get
            Return _Grade
        End Get
        Set(ByVal value As String)
            _Grade = value
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
    Property Cert_ As String
        Get
            Return _Cert
        End Get
        Set(ByVal value As String)
            _Cert = value
        End Set
    End Property

    Property Staffnumber_ As String
        Get
            Return _Staffnumber
        End Get
        Set(ByVal value As String)
            _Staffnumber = value
        End Set
    End Property
    Property Staffname_ As String
        Get
            Return _Staffname
        End Get
        Set(ByVal value As String)
            _Staffname = value
        End Set
    End Property

End Class
