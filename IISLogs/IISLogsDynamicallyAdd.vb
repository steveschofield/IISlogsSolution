Imports System.DirectoryServices
Imports Microsoft.Web.Administration

Public Class IISLogsDynamicallyAddLogDirectoryValues
    Inherits IISLogsStartModule
    Private Shared arrDirList As New ArrayList
    Private Shared m_ConfigFileName As String = ""

    Public Shared Sub MainBegin()
        Dim strAnswer As String
        Try
            arrDirList.Clear()
            Dim objIISLogsUtils As New IISLogsUtils

            m_ConfigFileName = IISLogsUtils.GetConfigFileName()

            If m_MonitoredSpecificDirectories.Length > 0 Then
                BuildArrList(m_MonitoredSpecificDirectories)
            End If

            If m_AutoAddMonitoredSpecificDirectories_w3svc = True Then
                SetData("W3SVC")
            Else
                RemoveData("W3SVC")
            End If

            If m_OSVersion < 6 Then
                If m_AutoAddMonitoredSpecificDirectories_msftpsvc = True Then
                    SetData("MSFTPSVC")
                Else
                    RemoveData("MSFTPSVC")
                End If

                If m_AutoAddMonitoredSpecificDirectories_smtpsvc = True Then
                    SetData("SMTPSVC")
                Else
                    RemoveData("SMTPSVC")
                End If
            End If

            If arrDirList.Count > 0 Then
                strAnswer = BuildList()
                IISLogsUtils.SaveConfigData(m_ConfigFileName, "MonitoredSpecificDirectories", strAnswer)
                m_MonitoredSpecificDirectories = strAnswer
            End If

        Catch ex As Exception
            ErrorHandler(ex, "IISLogsDynamicallyAddStuff")
        End Try
    End Sub

    Public Sub New(ByVal configFileName As String, ByVal MonitoredSpecificDirectories As String, ByVal delimiter As String)
        Dim strAnswer As String
        Try
            Dim objIISLogsUtils As New IISLogsUtils
            m_ConfigFileName = configFileName

            m_MonitoredSpecificDirectories = MonitoredSpecificDirectories
            m_delimiter = delimiter

            If m_MonitoredSpecificDirectories.Length > 0 Then
                BuildArrList(m_MonitoredSpecificDirectories)
            End If

            If m_AutoAddMonitoredSpecificDirectories_w3svc = True Then
                SetData("W3SVC")
            Else
                RemoveData("W3SVC")
            End If

            'If m_AutoAddMonitoredSpecificDirectories_msftpsvc = True Then
            '    SetData("MSFTPSVC")
            'Else
            '    RemoveData("MSFTPSVC")
            'End If

            'If m_AutoAddMonitoredSpecificDirectories_smtpsvc = True Then
            '    SetData("SMTPSVC")
            'Else
            '    RemoveData("SMTPSVC")
            'End If

            If arrDirList.Count > 0 Then
                strAnswer = BuildList()
                IISLogsUtils.SaveConfigData(m_ConfigFileName, "MonitoredSpecificDirectories", strAnswer)
                m_MonitoredSpecificDirectories = strAnswer
            End If

        Catch ex As Exception
            ErrorHandler(ex, "IISLogsDynamicallyAddStuff")
        End Try
    End Sub

    Private Shared Sub BuildArrList(ByVal strPath As String)
        Dim strName As String
        Dim arrSplit As String() = Nothing

        'Process MonitoredSpecificDirectories configuration key
        arrSplit = strPath.Split(CType(m_delimiter, Char))

        If strPath.Length > 0 Then
            For Each strName In arrSplit
                arrDirList.Add(strName.ToLower)
            Next
        End If
    End Sub

    Private Shared Sub RemoveData(ByVal SvcType As String)

        Try
            'This uses a value in the from the OS, Windows 2003 will use the metabase, otherwise it'll use MWA
            If m_OSVersion < 6 Then

                Dim en As DirectoryEntry
                Dim strWebSiteName As String

                Try
                    en = New DirectoryServices.DirectoryEntry("IIS://LOCALHOST/" & SvcType)
                Catch ex As Exception
                    ErrorHandler(ex, "Can't access the metabase with Remove Data Function")
                End Try
                For Each Entry As DirectoryEntry In en.Children
                    If IsNumeric(Entry.Name) = True Then
                        strWebSiteName = CType(Entry.Properties.Item("LogFileDirectory").Value, String)
                        Select Case SvcType.Trim.ToLower
                            Case "w3svc"
                                RemoveFromArrayList(strWebSiteName & "\w3svc" & Entry.Name)
                            Case "msftpsvc"
                                RemoveFromArrayList(strWebSiteName & "\msftpsvc" & Entry.Name)
                            Case "smtpsvc"
                                RemoveFromArrayList(strWebSiteName & "\smtpsvc" & Entry.Name)
                        End Select
                    End If
                Next

            ElseIf m_UseMetabaseRoleService = True Then

                Dim en As DirectoryEntry
                Dim strWebSiteName As String

                Try
                    en = New DirectoryServices.DirectoryEntry("IIS://LOCALHOST/" & SvcType)
                Catch ex As Exception
                    ErrorHandler(ex, "Can't access the metabase with Remove Data Function")
                End Try
                For Each Entry As DirectoryEntry In en.Children
                    If IsNumeric(Entry.Name) = True Then
                        strWebSiteName = CType(Entry.Properties.Item("LogFileDirectory").Value, String)
                        Select Case SvcType.Trim.ToLower
                            Case "w3svc"
                                RemoveFromArrayList(strWebSiteName & "\w3svc" & Entry.Name)
                            Case "msftpsvc"
                                RemoveFromArrayList(strWebSiteName & "\msftpsvc" & Entry.Name)
                            Case "smtpsvc"
                                RemoveFromArrayList(strWebSiteName & "\smtpsvc" & Entry.Name)
                        End Select
                    End If
                Next

            Else

                Dim sm As New ServerManager
                Dim LogFilePath1 As String = ""
                Dim LogFilePath2 As String = ""

                For Each s As Site In sm.Sites

                    LogFilePath1 = s.LogFile.Directory.ToLower()

                    'Checks to see if the default path %SystemDrive%
                    If Left(LogFilePath1, 13) = "%systemdrive%" Then
                        LogFilePath1 = SanitizeLogFilePath(LogFilePath1)
                    End If

                    LogFilePath2 = LogFilePath1 & "\w3svc" & s.Id
                    RemoveFromArrayList(LogFilePath2)
                Next
                sm.Dispose()
            End If

        Catch ex As Exception
            ErrorHandler(ex, "SetData")
        End Try
    End Sub

    Public Shared Sub SetData(ByVal SvcType As String)
        Try
            If m_OSVersion < 6 Then

                Dim en As DirectoryEntry
                Dim strWebSiteName As String
                Dim Entry As DirectoryEntry

                Try
                    en = New DirectoryServices.DirectoryEntry("IIS://LOCALHOST/" & SvcType)
                Catch ex As Exception
                    ErrorHandler(ex, "Can't access the metabase within Set data function")
                End Try

                For Each Entry In en.Children
                    If IsNumeric(Entry.Name) = True Then
                        strWebSiteName = CType(Entry.Properties.Item("LogFileDirectory").Value, String)
                        Select Case SvcType.Trim.ToLower
                            Case "w3svc"
                                AddToArrayList(strWebSiteName & "\w3svc" & Entry.Name)
                            Case "msftpsvc"
                                AddToArrayList(strWebSiteName & "\msftpsvc" & Entry.Name)
                            Case "smtpsvc"
                                AddToArrayList(strWebSiteName & "\smtpsvc" & Entry.Name)
                        End Select
                    End If
                Next

            ElseIf m_UseMetabaseRoleService = True Then

                Dim en As DirectoryEntry
                Dim strWebSiteName As String
                Dim Entry As DirectoryEntry

                Try
                    en = New DirectoryServices.DirectoryEntry("IIS://LOCALHOST/" & SvcType)
                Catch ex As Exception
                    ErrorHandler(ex, "Can't access the metabase within Set data function")
                End Try

                For Each Entry In en.Children
                    If IsNumeric(Entry.Name) = True Then
                        strWebSiteName = CType(Entry.Properties.Item("LogFileDirectory").Value, String)
                        Select Case SvcType.Trim.ToLower
                            Case "w3svc"
                                AddToArrayList(strWebSiteName & "\w3svc" & Entry.Name)
                            Case "msftpsvc"
                                AddToArrayList(strWebSiteName & "\msftpsvc" & Entry.Name)
                            Case "smtpsvc"
                                AddToArrayList(strWebSiteName & "\smtpsvc" & Entry.Name)
                        End Select
                    End If
                Next

            Else

                Dim sm As New ServerManager
                Dim LogFilePath1 As String = ""
                Dim LogFilePath2 As String = ""

                For Each s As Site In sm.Sites

                    LogFilePath1 = s.LogFile.Directory.ToLower()

                    If Left(LogFilePath1, 13) = "%systemdrive%" Then
                        LogFilePath1 = SanitizeLogFilePath(LogFilePath1)
                    End If

                    LogFilePath2 = LogFilePath1 & "\w3svc" & s.Id
                    AddToArrayList(LogFilePath2)
                Next

                sm.Dispose()

            End If

        Catch ex As Exception
            ErrorHandler(ex, "SetData")
        End Try

    End Sub

    Private Shared Function SanitizeLogFilePath(LogFilePath1 As String) As String
        Dim value1 As String = ""
        value1 = Replace(LogFilePath1, "%systemdrive%", m_SystemDrive)
        Return value1
    End Function

    Private Shared Sub AddToArrayList(ByVal strWebSiteName As String)
        Dim value As String = strWebSiteName.ToLower
        If arrDirList.Contains(value) = False Then
            arrDirList.Add(value)
        End If
    End Sub

    Private Shared Sub RemoveFromArrayList(ByVal strWebSiteName As String)
        Dim value As String = strWebSiteName.ToLower
        If arrDirList.Contains(value) = True Then
            arrDirList.Remove(value)
        End If
    End Sub

    Private Shared Function BuildList() As String
        Dim objSB As New System.Text.StringBuilder
        Dim strFind As String = m_delimiter & m_delimiter
        Dim value As String

        If arrDirList.Count > 0 Then
            For Each value In arrDirList
                If value.Length > 0 Then
                    If Right(value, 1) = m_delimiter Then
                        objSB.Append(value)
                    Else
                        objSB.Append(value & m_delimiter)
                    End If
                End If
            Next
        End If

        Return Replace(objSB.ToString(), strFind, m_delimiter)
    End Function
End Class