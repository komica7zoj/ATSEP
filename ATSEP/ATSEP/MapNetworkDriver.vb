Imports System.Runtime.InteropServices

Public Class MapNetworkDriver
    'Constants
    Public Const NO_ERROR As UInteger = 0
    Public Const RESOURCETYPE_DISK As UInteger = 1

    ''' <summary>
    ''' Creates a connection to a network resource
    ''' </summary>
    ''' <param name="lpNetResource">A NETRESOURCE structure that specifies information about the network resource connection</param>
    ''' <param name="lpPassword">The password to use for the connection - leave blank to use current user credentials</param>
    ''' <param name="lpUserName">The username to use for the connection - leave blank to use current user credentials</param>
    ''' <param name="dwFlags">Bitmask that specifies connection options. For example, whether or not to make the connection persistent</param>
    <DllImportAttribute("mpr.dll", EntryPoint:="WNetAddConnection2W")> _
    Public Shared Function WNetAddConnection2(ByRef lpNetResource As NETRESOURCE, <InAttribute(), MarshalAsAttribute(UnmanagedType.LPWStr)> ByVal lpPassword As String, <InAttribute(), MarshalAsAttribute(UnmanagedType.LPWStr)> ByVal lpUserName As String, ByVal dwFlags As UInteger) As UInteger
    End Function

    ''' <summary>
    ''' Contains information about a network resource. Used by the WNetAddConnection2 method
    ''' </summary>
    <StructLayoutAttribute(LayoutKind.Sequential)> _
    Public Structure NETRESOURCE
        Public dwScope As UInteger
        Public dwType As UInteger
        Public dwDisplayType As UInteger
        Public dwUsage As UInteger
        <MarshalAsAttribute(UnmanagedType.LPWStr)> _
        Public lpLocalName As String
        <MarshalAsAttribute(UnmanagedType.LPWStr)> _
        Public lpRemoteName As String
        <MarshalAsAttribute(UnmanagedType.LPWStr)> _
        Public lpComment As String
        <MarshalAsAttribute(UnmanagedType.LPWStr)> _
        Public lpProvider As String
    End Structure


    ''' <summary>
    ''' Creates a network drive (aka mapped drive) using the specified drive letter, UNC path and optional credentials
    ''' </summary>
    ''' <param name="UncPath">The UNC path (\\servername\share) to map the drive letter to</param>
    ''' <param name="DriveLetter">The drive letter to use</param>
    ''' <param name="Persistent">False to have this drive removed when the user logs off. True to have the drive remembered. 
    ''' This option is the equivelant of the Reconnect At Logon checkbox shown when mapping a drive in Windows Exporer</param>
    ''' <param name="ConnectionUsername">The username to use for the connection - optional</param>
    ''' <param name="ConnectionPassword">The password to use for the connection - optional</param>
    Public Shared Sub MapNetworkDrive(ByVal UncPath As String, ByVal DriveLetter As Char, ByVal Persistent As Boolean, Optional ByVal ConnectionUsername As String = Nothing, Optional ByVal ConnectionPassword As String = Nothing)
        If String.IsNullOrEmpty(UncPath) Then
            Throw New ArgumentException("No UNC path specified", "UncPath")
        End If
        Dim DriveInfo As New NETRESOURCE
        With DriveInfo
            .dwType = RESOURCETYPE_DISK
            .lpLocalName = DriveLetter & ":"
            .lpRemoteName = UncPath
        End With
        Dim flags As UInteger = 0
        If Persistent Then
            flags = &H1
        End If
        Dim Result As UInteger = WNetAddConnection2(DriveInfo, ConnectionPassword, ConnectionUsername, flags)
        If Not Result = NO_ERROR Then
            Throw New System.ComponentModel.Win32Exception(CInt(Result))
        End If
    End Sub
End Class
