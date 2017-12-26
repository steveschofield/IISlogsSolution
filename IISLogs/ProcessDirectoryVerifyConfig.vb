Imports System.IO

Public Class IISLogsVerifyConfig
    Inherits IISLogsd.IISLogsStartModule

    'This builds an arrayList of Monitored and Specific Directories, returns to calling function Main()
    Private Shared m_arrMonitoredDir As New ArrayList

    Public Shared Function VerifyConfigMain() As ArrayList
        Try
            'this is the core functionality of IISLogs subroutine
            MonitoredDirectories(m_MonitoredEntireDirectories)

            'This is an add-on to the core functionlity to monitor specific directories
            MonitoredSpecificDirectories(m_MonitoredSpecificDirectories)

            'Determine if the administrator configured to monitored a central directory
            If m_blnMonitorZipFilePath = True Then
                MonitorZipFilePath(m_strZipFilePath)
            End If

            Return m_arrMonitoredDir
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsVerifyConfig.Main")
        End Try
    End Function

    Private Shared Sub MonitoredDirectories(ByVal strPath As String)
        Dim di As DirectoryInfo
        Dim strDirName As String
        Dim arrSplit As String() = Nothing
        Try
            arrSplit = strPath.Split(CType(m_delimiter, Char))
            If strPath.Length > 0 Then
                For Each strDirName In arrSplit
                    di = New DirectoryInfo(strDirName)
                    RecursiveDirLookup(di, 0)
                Next
            End If
        Catch exp As Exception
            ErrorHandler(exp, "MonitoredDirectories:" & strPath)
        End Try
    End Sub

    Private Shared Sub MonitoredSpecificDirectories(ByVal strPath As String)
        Dim strName As String
        Dim arrSplit As String() = Nothing

        Try
            'Process MonitoredSpecificDirectories configuration key
            arrSplit = strPath.Split(CType(m_delimiter, Char))

            If strPath.Length > 0 Then
                For Each strName In arrSplit
                    'This try statement is to catch directories we might not have access to or problems with the path
                    'This will insure all itesm in the arrSpecificSplit array are processed
                    Try
                        If Directory.Exists(strName) = True Then
                            m_arrMonitoredDir.Add(strName)
                        End If
                    Catch exp As Exception
                        ErrorHandler(exp, "IISLogsVerifyConfig.MonitoredDirectories.arrSpecificSplitForLoop:" & strPath)
                    End Try
                Next
            End If
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsVerifyConfig.MonitoredSpecificDirectories:" & strPath)
        End Try
    End Sub

    Private Shared Sub MonitorZipFilePath(ByVal strZipFilePath As String)
        Dim di As DirectoryInfo
        Try
            di = New DirectoryInfo(strZipFilePath)
            RecursiveDirLookup(di, 0)
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsVerifyConfig.MonitoredDirectories. Recursive function ")
        End Try
    End Sub

    Private Shared Sub RecursiveDirLookup(ByVal theDir As DirectoryInfo, ByVal nLevel As Integer)
        Dim x As Integer
        Dim subDirectories As DirectoryInfo()

        Try
            subDirectories = theDir.GetDirectories()
            For x = 0 To subDirectories.Length - 1
                'This Try statement is here to insure all sub-directories are tried
                Try
                    If m_ConsoleWriteLineToScreen = True Then
                        Console.WriteLine(subDirectories(x).FullName)
                    End If

                    'Check to see if any .log files are in the directory count
                    'arrLog = subDirectories(x).GetFiles("*.log")

                    'Check to see if any .ZIP files are in the directory count
                    'arrZip = subDirectories(x).GetFiles("*.zip")

                    'If arrLog.Length > 0 Or arrZip.Length > 0 Then
                    m_arrMonitoredDir.Add(subDirectories(x).FullName)
                    'End If

                    'Call itself
                    RecursiveDirLookup(subDirectories(x), nLevel + 0)
                Catch exp As Exception
                    ErrorHandler(exp, "IISLogsVerifyConfig.RecursiveDirLookup ForLoop")
                End Try
            Next
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsVerifyConfig.RecursiveDirLookup")
        End Try
    End Sub

End Class