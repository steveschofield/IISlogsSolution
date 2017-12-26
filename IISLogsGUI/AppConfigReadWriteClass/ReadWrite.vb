Imports System.IO
Imports System.Xml

Public Class ReadWrite
    Inherits ComponentModel.Component

    Private configSource As XmlDocument
    Private xPathTemplate As String = "//configuration/appSettings/add[@key='{0}']"
    Private WithEvents configWatcher As FileSystemWatcher
    Private _FileName As String

    Public Property AppConfigFIle() As String
        Get
            Return Me._FileName
        End Get
        Set(ByVal Value As String)
            Me._FileName = Value
        End Set
    End Property

    'Private Sub onChanged(ByVal source As Object, ByVal e As FileSystemEventArgs)
    '    RemoveHandler configWatcher.Changed, AddressOf onChanged
    '    LoadConfigSource()
    'End Sub

    Public Function GetSetting(ByVal key As String) As Object
        '--> Read Settings via xpath Query from Config File
        Dim xpath As String = String.Format(xPathTemplate, key)
        If Not configSource Is Nothing Then
            Dim nodes As XmlNodeList = configSource.SelectNodes(xpath)
            If nodes.Count <= 0 Then
                Return String.Empty
            End If
            If nodes.Count > 1 Then Throw New Exception("Double input in Settingsfile")
            Dim addvalue As String = nodes(0).Attributes("value").InnerText
            Return addvalue
        End If
        Return Nothing
    End Function

    Public Sub setSetting(ByVal key As String, ByVal value As String)
        '--> Write setting to config file
        '--> config is automaticallly reloaded via configwatcher
        Dim xPath As String = String.Format(xPathTemplate, key)
        Dim nodes As XmlNodeList = configSource.SelectNodes(xPath)
        If nodes.Count > 1 Then Throw New Exception("Double input in Settingsfile")

        If nodes.Count <= 0 Then
            Dim keyattrib As XmlAttribute = configSource.CreateAttribute("key")
            keyattrib.InnerText = key
            Dim valAttrib As XmlAttribute = configSource.CreateAttribute("value")
            valAttrib.InnerText = value
            Dim node As XmlNode = configSource.CreateElement("add")
            node.Attributes.Append(keyattrib)
            node.Attributes.Append(valAttrib)

            Dim Appsettings As XmlNode = configSource.GetElementsByTagName("appSettings")(0)
            Appsettings.AppendChild(node)
        Else
            nodes(0).Attributes("value").InnerText = value
        End If
    End Sub

    Public Sub Close()
        configSource = Nothing
    End Sub

    Public Sub SaveConfigSource()
        configSource.Save(Me._FileName)
    End Sub

    Public Sub SaveConfigSource(ByVal configFileName As String)
        configSource.Save(Me._FileName)
    End Sub

    Public Sub LoadConfigSource()
        If Me._FileName Is Nothing Then

            Dim dllPath As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim filename As String

#If DEBUG Then
            '--> if debug app.config file is not in bin folder
            Dim strTemp As String = Path.GetDirectoryName(dllPath)
            strTemp = strTemp.Substring(1, strTemp.Length - 1)
            strTemp = strTemp.Substring(1, strTemp.LastIndexOf("\"))
            filename = strTemp & "App.config"
#Else
    '--> if run then app.config file in bin folder
    '--> get the name of the calling assembly and built the path of the config file in release mode
    filename = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) & "\" & System.Reflection.Assembly.GetEntryAssembly.GetName.Name.ToString & ".exe.config"
#End If
            Me._FileName = filename
        End If

        configSource = New XmlDocument

        Dim cstream As Stream = Nothing

        Try
            cstream = File.OpenRead(_FileName)
            configSource.Load(cstream)
        Catch ex As FileNotFoundException
            Throw ex
        Catch exc As Exception
            Throw exc
        Finally
            If Not cstream Is Nothing Then
                cstream.Close()
                cstream = Nothing
            End If
        End Try
    End Sub


    Public Sub LoadConfigSource(ByVal configFileName As String)
        If Me._FileName Is Nothing Then

            Dim dllPath As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim filename As String

            filename = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) & "\" & System.Reflection.Assembly.GetEntryAssembly.GetName.Name.ToString & ".exe.config"

            Me._FileName = filename
        End If

        configSource = New XmlDocument

        Dim cstream As Stream = Nothing

        Try
            cstream = File.OpenRead(_FileName)
            configSource.Load(cstream)
        Catch ex As FileNotFoundException
            Throw ex
        Catch exc As Exception
            Throw exc
        Finally
            If Not cstream Is Nothing Then
                cstream.Close()
                cstream = Nothing
            End If
        End Try
    End Sub
End Class
