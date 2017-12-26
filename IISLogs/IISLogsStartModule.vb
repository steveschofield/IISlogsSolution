Imports System.Configuration
Imports IISLogsd
Imports IISLogsl

Public Class IISLogsStartModule
    Implements IDisposable
    Public Shared m_DetailFileLogging As Boolean
    Public Shared m_delimiter As String
    Public Shared m_lngDeleteRetentionPeriod As Long
    Public Shared m_lngdelOnlyRetentionPeriod As Long
    Public Shared m_lngSMTPDelRetentionPeriod As Long
    Public Shared m_processdelOnlySpecificDirectories As Boolean
    Public Shared m_delOnlySpecificDirectories As String
    Public Shared m_processSmtpSVCDirectories As Boolean
    Public Shared m_smtpSVCDirectories As String
    Public Shared m_SendMailReport As Boolean
    Public Shared m_MonitoredEntireDirectories As String
    Public Shared m_MonitoredSpecificDirectories As String
    Public Shared m_blnMonitorZipFilePath As Boolean
    Public Shared m_strZipFilePath As String
    Public Shared m_blnZipFile As Boolean
    Public Shared m_blnDeleteFile As Boolean
    Public Shared m_lngZipRetentionPeriod As Long
    Public Shared m_LogDirectoryPath As String
    Public Shared m_deleteLogFileName As String
    Public Shared m_detailLogFileName As String
    Public Shared m_errorLogFileName As String
    Public Shared m_summaryLogFileName As String
    Public Shared m_ConsoleWriteLineToScreen As Boolean
    Public Shared m_fileLoggingAge As Long
    Public Shared m_purgeArchiveLogsAge As Long
    Public Shared m_strMailServer As String
    Public Shared m_strMailPort As Integer
    Public Shared m_strUID As String
    Public Shared m_strPWD As String
    Public Shared m_sFrom As String
    Public Shared m_sTo As String
    Public Shared m_strSubject As String
    Public Shared m_strHL1 As String
    Public Shared m_strHL2 As String
    Public Shared m_strHL3 As String
    Public Shared m_deleteLogFileNameFields As String
    Public Shared m_detailLogFileNameFields As String
    Public Shared m_errorLogFileNameFields As String
    Public Shared m_summaryLogFileNameFields As String
    Public Shared m_compressionLevel As String
    Public Shared m_LogPrimaryKey As Double
    Public Shared m_ComputerName As String
    Public Shared m_blnDeleteOriginalFile As Boolean
    Public Shared m_DeletePolicyAgreement As Boolean
    Public Shared m_TurnOffDeletePolicyAgreementSigned As Boolean
    Public Shared m_DeletePolicyAgreementSigned As Boolean
    Public Shared m_DelOnlySpecificAttribute As String
    Public Shared m_FileCompressionPolicyAgreement As Boolean
    Public Shared m_TurnOffFileCompressionPolicyAgreementSigned As Boolean
    Public Shared m_FileCompressionPolicyAgreementSigned As Boolean
    Public Shared m_UseEventLog As Boolean
    Public Shared m_EnableMailAuth As Boolean
    Public Shared m_blnProcessTXT As Boolean
    Public Shared m_blnProcessBAK As Boolean
    Public Shared m_blnProcessDAT As Boolean
    Public Shared m_blnProcessXML As Boolean
    Public Shared m_SummaryFileLogging As Boolean
    Public Shared m_CustomExtensions As String
    Public Shared m_AutoAddMonitoredSpecificDirectories As Boolean
    Public Shared m_AutoAddMonitoredSpecificDirectories_w3svc As Boolean
    Public Shared m_AutoAddMonitoredSpecificDirectories_msftpsvc As Boolean
    Public Shared m_AutoAddMonitoredSpecificDirectories_smtpsvc As Boolean
    Public Shared m_ZipPerDirectoryXMLFile As String
    Public Shared m_ZipPerDirectoryEnable As Boolean
    Public Shared m_strWinDir As String = LCase(System.Environment.GetEnvironmentVariable("windir").ToString())

    '.NET 4.0 variables
    Public Shared m_PreserveDirPath As Boolean
    Public Shared m_Naming As String
    Public Shared m_LogsDWM As Integer

    'Adding MWA (Microsoft.Web.Administration Options)
    Public Shared m_OSVersion As Integer
    Public Shared m_SystemDrive As String
    Public Shared m_UseMetabaseRoleService As Boolean

    Private Function CheckLicense(ByVal LicenseFolderPath As String) As Boolean

        Dim tracking As New IISLogsTracking
        Dim lic As New IISLogsLicense

        'Get Executing path
        lic.LicenseFolderPath = LicenseFolderPath

        'Get executing path and set to lic.xml file
        lic.LicenseFilePath = LicenseFolderPath & "\lic.xml"

        'Main entry point to the CheckLicense object
        lic.CheckLicenseFile()

        Try
            If lic.IsFullVersionLicense = True Then

                IISLogsTracking.errorData("CheckLicense", "Using full version license.", "N/A", "N/A")

                Return True

            Else

                If lic.EvalDaysLeft <= 30 Then
                    IISLogsTracking.errorData("CheckLicense", "Number of evaluation days used:" & lic.EvalDaysLeft, "N/A", "N/A")

                    Return True

                Else

                    IISLogsTracking.errorData("MainStart", "Thank you for trying IISLogs.  The evaluation period has ended, please visit http://www.iislogs.com to order.  If you have further questions, please contact info@iislogs.com." & lic.EvalDaysLeft, "N/A", "N/A")

                    Return False

                End If
            End If
        Catch ex As Exception

            IISLogsTracking.errorData("MainStart", "Problem with license file verification, number of evaluation days left:" & lic.EvalDaysLeft & ":" & "License Evaluation:" & lic.IsFullVersionLicense, "N/A", "N/A")

            Return False

        End Try
    End Function

    Private Function GetCallingAssemblyDirPath() As String
        Dim a As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly.Location)
        Return a & "\Logs\License\"
    End Function

    Public Function MainStart() As Boolean
        Dim blnResult As Boolean

        Try
            'Start the whole process
            Dim runIISLogs As Boolean = False
            Dim objIISLogs As New IISLogsMainPrograms

            'Load configuration file values to module level variables
            'Needs to load all defaults for logging
            LoadConfig()

            Dim LicenseFolderPath As String = GetCallingAssemblyDirPath()

            runIISLogs = CheckLicense(LicenseFolderPath)

            If runIISLogs = True Then

                'Start the whole process
                blnResult = objIISLogs.MainPrograms()
                IISLogsTracking.errorData("MainStart", "IISLogs ran without any issues", "N/A", "N/A")

                'Clear all configuration module level variables
                ClearConfig()
                Return blnResult

            Else

                IISLogsTracking.errorData("MainStart", "Issue with License file", "N/A", "N/A")

            End If

            'Clear all configuration module level variables
            ClearConfig()

        Catch exp As Exception
            ErrorHandler(exp, "Main()")
            blnResult = False
        End Try

        Return blnResult

    End Function

    Public Shared Sub LoadConfig()
        Try
            'Set Global setting for all Configuration Settings
            m_DetailFileLogging = CType(ConfigurationManager.AppSettings("DetailFileLogging"), Boolean)
            m_delimiter = ConfigurationManager.AppSettings("Delimiter")
            m_lngDeleteRetentionPeriod = CType(ConfigurationManager.AppSettings("DeleteRetentionPeriod"), Long)
            m_lngdelOnlyRetentionPeriod = CType(ConfigurationManager.AppSettings("DelOnlySpecificRetentionPeriod"), Long)
            m_lngSMTPDelRetentionPeriod = CType(ConfigurationManager.AppSettings("SmtpDeleteRetentionPeriod"), Long)
            m_processdelOnlySpecificDirectories = CType(ConfigurationManager.AppSettings("ProcessdelOnlySpecificDirectories"), Boolean)
            m_delOnlySpecificDirectories = ConfigurationManager.AppSettings("DelOnlySpecificDirectories")
            m_DelOnlySpecificAttribute = ConfigurationManager.AppSettings("DelOnlySpecificAttribute")
            m_processSmtpSVCDirectories = CType(ConfigurationManager.AppSettings("ProcessSmtpSVCDirectories"), Boolean)
            m_smtpSVCDirectories = ConfigurationManager.AppSettings("SmtpSVCDirectories")
            m_SendMailReport = CType(ConfigurationManager.AppSettings("SendMailReport"), Boolean)
            m_MonitoredEntireDirectories = LCase(ConfigurationManager.AppSettings("MonitoredEntireDirectories"))
            m_MonitoredSpecificDirectories = LCase(ConfigurationManager.AppSettings("MonitoredSpecificDirectories"))
            m_blnMonitorZipFilePath = CType(ConfigurationManager.AppSettings("MonitorZipFilePath"), Boolean)
            m_strZipFilePath = ConfigurationManager.AppSettings("ZipFilePath")
            m_blnZipFile = CType(ConfigurationManager.AppSettings("ZipFile"), Boolean)
            m_blnDeleteFile = CType(ConfigurationManager.AppSettings("DeleteFile"), Boolean)
            m_lngZipRetentionPeriod = CType(ConfigurationManager.AppSettings("ZipRetentionPeriod"), Long)

            If ConfigurationManager.AppSettings("LogDirectoryPath") = "" Then
                m_LogDirectoryPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) & "\logs\"
                IISLogsUtils.SaveConfigData(IISLogsUtils.GetConfigFileName(), "LogDirectoryPath", m_LogDirectoryPath)
            Else
                m_LogDirectoryPath = ConfigurationManager.AppSettings("LogDirectoryPath")
            End If

            m_summaryLogFileName = ConfigurationManager.AppSettings("SummaryLogFileName")
            m_deleteLogFileName = ConfigurationManager.AppSettings("DeleteLogFileName")
            m_detailLogFileName = ConfigurationManager.AppSettings("DetailLogFileName")
            m_errorLogFileName = ConfigurationManager.AppSettings("ErrorLogFileName")
            m_summaryLogFileName = ConfigurationManager.AppSettings("SummaryLogFileName")
            m_ConsoleWriteLineToScreen = CType(ConfigurationManager.AppSettings("ConsoleWriteLineToScreen"), Boolean)
            m_fileLoggingAge = CType(ConfigurationManager.AppSettings("FileLoggingAge"), Long)
            m_purgeArchiveLogsAge = CType(ConfigurationManager.AppSettings("purgeArchiveLogsAge"), Long)

            m_strMailServer = LCase(System.Configuration.ConfigurationManager.AppSettings("mailServer"))
            m_strMailPort = CType(System.Configuration.ConfigurationManager.AppSettings("mailPort"), Integer)
            m_strUID = System.Configuration.ConfigurationManager.AppSettings("mailUID")
            m_strPWD = System.Configuration.ConfigurationManager.AppSettings("mailPWD")
            m_sFrom = System.Configuration.ConfigurationManager.AppSettings("from")
            m_sTo = System.Configuration.ConfigurationManager.AppSettings("to")
            m_strSubject = System.Configuration.ConfigurationManager.AppSettings("mailSubject")
            m_EnableMailAuth = CType(System.Configuration.ConfigurationManager.AppSettings("EnableMailAuth"), Boolean)
            m_strHL1 = System.Configuration.ConfigurationManager.AppSettings("LogHeaderLine1")
            m_strHL2 = System.Configuration.ConfigurationManager.AppSettings("LogHeaderLine2")
            m_strHL3 = System.Configuration.ConfigurationManager.AppSettings("LogHeaderLine3") & System.DateTime.Now()

            m_deleteLogFileNameFields = System.Configuration.ConfigurationManager.AppSettings("DeleteLogFileNameFields")
            m_detailLogFileNameFields = System.Configuration.ConfigurationManager.AppSettings("DetailLogFileNameFields")
            m_errorLogFileNameFields = System.Configuration.ConfigurationManager.AppSettings("ErrorLogFileNameFields")
            m_summaryLogFileNameFields = System.Configuration.ConfigurationManager.AppSettings("SummaryLogFileNameFields")
            m_compressionLevel = CType(ConfigurationManager.AppSettings("CompressionLevel"), String)
            m_LogPrimaryKey = 0
            m_ComputerName = System.Environment.GetEnvironmentVariable("ComputerName").ToString()
            m_blnDeleteOriginalFile = CType(System.Configuration.ConfigurationManager.AppSettings("DeleteOriginalFile"), Boolean)
            m_DeletePolicyAgreementSigned = CType(System.Configuration.ConfigurationManager.AppSettings("DeletePolicyAgreementSigned"), Boolean)
            m_FileCompressionPolicyAgreementSigned = CType(System.Configuration.ConfigurationManager.AppSettings("FileCompressionPolicyAgreementSigned"), Boolean)
            m_TurnOffDeletePolicyAgreementSigned = CType(System.Configuration.ConfigurationManager.AppSettings("TurnOffDeletePolicyAgreementSigned"), Boolean)
            m_TurnOffFileCompressionPolicyAgreementSigned = CType(System.Configuration.ConfigurationManager.AppSettings("TurnOffFileCompressionPolicyAgreementSigned"), Boolean)
            m_UseEventLog = CType(System.Configuration.ConfigurationManager.AppSettings("UseEventLog"), Boolean)
            m_blnProcessTXT = CType(System.Configuration.ConfigurationManager.AppSettings("ProcessTXT"), Boolean)
            m_blnProcessBAK = CType(System.Configuration.ConfigurationManager.AppSettings("ProcessBAK"), Boolean)
            m_blnProcessDAT = CType(System.Configuration.ConfigurationManager.AppSettings("ProcessDAT"), Boolean)
            m_blnProcessXML = CType(System.Configuration.ConfigurationManager.AppSettings("ProcessXML"), Boolean)
            m_SummaryFileLogging = CType(System.Configuration.ConfigurationManager.AppSettings("SummaryFileLogging"), Boolean)
            m_CustomExtensions = System.Configuration.ConfigurationManager.AppSettings("CustomExtensions")
            m_AutoAddMonitoredSpecificDirectories = CType(System.Configuration.ConfigurationManager.AppSettings("AutoAddMonitoredSpecificDirectories"), Boolean)
            m_AutoAddMonitoredSpecificDirectories_w3svc = CType(System.Configuration.ConfigurationManager.AppSettings("AutoAddMonitoredSpecificDirectories_w3svc"), Boolean)
            m_AutoAddMonitoredSpecificDirectories_msftpsvc = CType(System.Configuration.ConfigurationManager.AppSettings("AutoAddMonitoredSpecificDirectories_msftpsvc"), Boolean)
            m_AutoAddMonitoredSpecificDirectories_smtpsvc = CType(System.Configuration.ConfigurationManager.AppSettings("AutoAddMonitoredSpecificDirectories_smtpsvc"), Boolean)
            m_ZipPerDirectoryXMLFile = System.Configuration.ConfigurationManager.AppSettings("ZipPerDirectoryXMLFile")
            m_ZipPerDirectoryEnable = CType(System.Configuration.ConfigurationManager.AppSettings("ZipPerDirectoryEnable"), Boolean)

            '.NET 4.0 specific configuration, these are not in IISLogsGUI 2.0
            m_PreserveDirPath = CType(System.Configuration.ConfigurationManager.AppSettings("PreserveDirPath"), Boolean)
            m_Naming = System.Configuration.ConfigurationManager.AppSettings("Naming")
            m_LogsDWM = CType(System.Configuration.ConfigurationManager.AppSettings("LogsDWM"), Integer)

            'Adding MWA (Microsoft.Web.Administration Options)
            m_OSVersion = CType(Mid(Environment.OSVersion.Version.ToString, 1, 1), Int16)
            m_SystemDrive = Environment.GetEnvironmentVariable("SystemDrive")
            m_UseMetabaseRoleService = CType(System.Configuration.ConfigurationManager.AppSettings("UseMetabaseRoleService"), Boolean)

        Catch exp As Exception
            ErrorHandler(exp, "IISLogsStartModule")
        End Try
    End Sub

    Public Sub ClearConfig()
        m_delimiter = ""
        m_lngDeleteRetentionPeriod = 0
        m_lngdelOnlyRetentionPeriod = 0
        m_lngSMTPDelRetentionPeriod = 0
        m_delOnlySpecificDirectories = ""
        m_processSmtpSVCDirectories = False
        m_processdelOnlySpecificDirectories = False
        m_smtpSVCDirectories = ""
        m_SendMailReport = False
        m_MonitoredEntireDirectories = ""
        m_MonitoredSpecificDirectories = ""
        m_blnMonitorZipFilePath = False
        m_strZipFilePath = ""
        m_blnZipFile = False
        m_blnDeleteFile = False
        m_lngZipRetentionPeriod = 0
        m_LogDirectoryPath = ""
        m_deleteLogFileName = ""
        m_detailLogFileName = ""
        m_errorLogFileName = ""
        m_summaryLogFileName = ""
        m_ConsoleWriteLineToScreen = True
        m_fileLoggingAge = 0
        m_purgeArchiveLogsAge = 0
        m_strMailServer = ""
        m_strMailPort = 0
        m_strUID = ""
        m_strPWD = ""
        m_sFrom = ""
        m_sTo = ""
        m_strSubject = ""
        m_strHL1 = ""
        m_strHL2 = ""
        m_strHL3 = ""
        m_deleteLogFileNameFields = ""
        m_detailLogFileNameFields = ""
        m_errorLogFileNameFields = ""
        m_summaryLogFileNameFields = ""
        m_LogPrimaryKey = 0
        m_ComputerName = ""
        m_blnDeleteOriginalFile = False
        m_DeletePolicyAgreement = False
        m_DeletePolicyAgreementSigned = False
        m_FileCompressionPolicyAgreement = False
        m_FileCompressionPolicyAgreementSigned = False
        m_UseEventLog = True
        m_Naming = ""
        m_LogsDWM = 1
        m_PreserveDirPath = True
        m_OSVersion = 0
    End Sub

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Me.Dispose()
        GC.SuppressFinalize(Me)
        System.Configuration.ConfigurationManager.AppSettings.Clear()
    End Sub

    '***************************************************************************
    'Purpose: Error Handler for all functions
    'Inputs: exception variable type and what function the error caused the error
    'Returns: N/A
    '****************************************************************************
    Public Shared Sub ErrorHandler(ByVal exp As Exception, ByVal functionName As String)
        Try
            'Format the message to an output file that CAN be imported to the db
            IISLogsTracking.errorData(functionName, exp.Message.ToString(), exp.Source.ToString(), exp.StackTrace.ToString())

            If m_UseEventLog = True Then
                IISLogsUtils.WriteToEventLog(exp.Message.ToString() & functionName)
            End If
        Catch f As Exception
            IISLogsUtils.WriteToEventLog(exp.Message.ToString() & functionName)
        End Try
    End Sub

End Class