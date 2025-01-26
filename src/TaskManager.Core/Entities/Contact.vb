Public Class Contact
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _email As String
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _phone As String
    Public Property Phone() As String
        Get
            Return _phone
        End Get
        Set(ByVal value As String)
            _phone = value
        End Set
    End Property

    Private _active As Boolean = True 'The default value is active
    Public Property Active() As Boolean
        Get
            Return _active
        End Get
        Set(ByVal value As Boolean)
            _active = value
        End Set
    End Property

    ' Since SQLlite does not have a boolean type, I use additional property to convert the boolean active value to an integer
    Public Property ActiveStatusByNumber() As Integer
        Get
            Return If(_active, 1, 0)
        End Get
        Set(ByVal value As Integer)
            _active = value = 1
        End Set
    End Property
End Class