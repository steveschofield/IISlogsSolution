'Imports System.ServiceProcess
'Imports System.Config
'Imports System.IO
Imports IISLogsd
Imports System.Threading

Public Class IISLogsSVC
    Inherits System.ServiceProcess.ServiceBase

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()
        ' This call is required by the Component Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call
    End Sub

    'UserService overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' The main entry point for the process
    <MTAThread()> _
    Shared Sub Main()
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase
        Try
            ServicesToRun = New System.ServiceProcess.ServiceBase() {New IISLogsSVC}
            System.ServiceProcess.ServiceBase.Run(ServicesToRun)
        Catch ex As Exception
            IISLogsUtils.WriteToEventLog(ex.Message.ToString() & "- Please contact http://IISlogs.com support for further assistance")
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'IISLogsSVC
        '
        Me.ServiceName = "IISLogs4"

    End Sub

#End Region

    Protected Overrides Sub OnStart(ByVal args() As String)
        Dim t As New Thread(AddressOf IISLogsMain)
        t.Start()
    End Sub

    Protected Overrides Sub OnStop()

    End Sub

    Private Sub IISLogsMain()
        Dim lngResult As Integer
        Dim x As Integer
        Dim blnResult As Boolean
        Try
            x = 1
            Do While x = 1
                lngResult = getConfigTime()

                If lngResult = 888888 Then
                    IISLogsUtils.WriteToEventLog("IISLogs Had an Error with getConfigTime function. Please review your configuration")
                    Exit Try
                End If

                IISLogsUtils.WriteToEventLog("IISLogs will run next at :" & System.DateTime.Now.AddMilliseconds(lngResult) & " - - IISLogs will sleep for millseconds: " & lngResult & " or number of minutes: " & lngResult / 60000)
                Threading.Thread.Sleep(lngResult)
                blnResult = StartTheProgram()
                IISLogsUtils.WriteToEventLog("IISLogs run was : " & blnResult)
            Loop
        Catch exp As Exception
            IISLogsUtils.WriteToEventLog("IISLogs Had an Error. Please review your configuration:" & exp.Message.ToString())
        End Try
    End Sub

    'This function is for on-demand within IISLogsGUI
    Protected Overrides Sub OnCustomCommand(ByVal command As Integer)
        Select Case command
            Case 130
                Dim blnResult As Boolean
                blnResult = StartTheProgram()
                IISLogsUtils.WriteToEventLog("IISLogs run was : " & blnResult)
        End Select
    End Sub

    'This function is for on-demand within IISLogsGUI
    Function StartTheProgram() As Boolean
        Dim blnResult As Boolean
        Dim objIISLogs As New IISLogsStartModule
        ReloadConfig()
        blnResult = objIISLogs.MainStart()
        Return blnResult
    End Function

    'This function is for on-demand within IISLogsGUI
    Sub ReloadConfig()
        'This clears what variables were stored in memory and loads whatever is the latest in the iislogssvc.exe.config
        Configuration.ConfigurationManager.RefreshSection("appSettings")
    End Sub

    Function getConfigTime() As Integer
        Dim arrSplit As String()
        Dim arrConfigTime As String
        Dim x As Integer = 0
        Dim threadSleep As Long
        Dim configTime As Date
        Dim myTime As DateTime
        Dim arrList As New ArrayList
        Dim intResult As Long

        arrConfigTime = Configuration.ConfigurationManager.AppSettings("ServiceInterval")
        arrSplit = arrConfigTime.Split(CType(Configuration.ConfigurationManager.AppSettings("Delimiter"), Char))

        myTime = DateTime.UtcNow

        For x = 0 To UBound(arrSplit)
            configTime = System.Convert.ToDateTime(arrSplit(x)).ToUniversalTime

            'This is put there ONLY if the service finishes within one minute of processing all the directories
            intResult = DateDiff(DateInterval.Minute, myTime, configTime)

            If configTime < myTime Or intResult = 0 Then
                configTime = configTime.AddDays(1)
                threadSleep = DateDiff(DateInterval.Minute, myTime, configTime)
            ElseIf configTime > myTime Then
                threadSleep = DateDiff(DateInterval.Minute, myTime, configTime)
            Else
                'This is bogus value to prevent an end-less loop.
                Return 888888
            End If
            threadSleep = (threadSleep * 60000) + 60000
            arrList.Add(threadSleep)
        Next

        arrList.Sort()
        Return CType(arrList(0), Integer)
    End Function

#Region " OLD DATE TIME CODE"
    'Function getConfigTime() As Integer
    '    Dim arrSplit As String()
    '    Dim arrConfigTime As String
    '    Dim x As Integer
    '    Dim threadSleep As Long
    '    Dim configTime As Date
    '    Dim myTime As DateTime
    '    Dim arrList As New ArrayList
    '    Dim intResult As Long

    '    Try
    '        arrConfigTime = ConfigurationManager.AppSettings("ServiceInterval")
    '        arrSplit = arrConfigTime.Split(CType(ConfigurationManager.AppSettings("Delimiter"), Char))
    '        myTime = Get24hourTimeFormat(DateTime.Now)
    '        x = 0
    '        For x = 0 To UBound(arrSplit)
    '            configTime = Month(Now) & "/" & Day(Now) & "/" & Year(Now) & " " & arrSplit(x)

    '            'This is put there ONLY if the service finishes within one minute
    '            'of processing all the directories
    '            intResult = DateDiff(DateInterval.Minute, myTime, configTime)

    '            If configTime < myTime Or intResult = 0 Then
    '                configTime = configTime.AddDays(1)
    '                threadSleep = DateDiff(DateInterval.Minute, myTime, configTime)
    '            ElseIf configTime > myTime Then
    '                threadSleep = DateDiff(DateInterval.Minute, myTime, configTime)
    '            End If
    '            threadSleep = (threadSleep * 60000) + 60000
    '            arrList.Add(threadSleep)
    '        Next
    '        arrList.Sort()

    '        Return CType(arrList(0), Integer)
    '    Catch exp As Exception
    '        IISLogsUtils.WriteToEventLog(exp.Message.ToString() & "getConfigTime")
    '    End Try
    'End Function

    'Function Get24hourTimeFormat(ByVal dt As DateTime) As DateTime
    '    Return System.Convert.ToDateTime(Month(dt) & "/" & Day(dt) & "/" & Year(dt) & " " & Pad(Hour(dt)) & ":" & Pad(Minute(dt)) & ":" & Pad(Second(dt)))
    'End Function

    'Function Pad(ByVal str As String) As Integer
    '    Pad = Right("00" & str, 2)
    'End Function
#End Region

End Class