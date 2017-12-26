Imports System.IO

Public Class IISLogsUtils
    Inherits IISLogsd.IISLogsStartModule

    Public Shared Sub WriteToEventLog(ByVal strMessage As String)
        Dim LogName As String
        Dim Message As String
        Dim Log As New EventLog

        Try
            LogName = "Application"
            Message = "Message: " & strMessage

            If (Not EventLog.SourceExists(LogName)) Then
                EventLog.CreateEventSource(LogName, LogName)
            End If

            Log.Source = LogName
            Log.WriteEntry(Message)
            Log.Close()
            Log.Dispose()
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsUtils.WriteToEventLog")
        End Try
    End Sub

    Public Shared Function GetFileAgeByDay(ByVal fileDate As DateTime) As Long
        Dim lngfileAge As Long
        lngfileAge = DateDiff(DateInterval.Day, fileDate, System.DateTime.Now())
        Return lngfileAge
    End Function

    Public Shared Function DetermineDirectorySize(ByVal strPath As String) As Long
        Dim v_arrFiles As FileInfo()
        Dim _lngTotalBytes As Long = 0
        Dim x As Integer = 0

        Try
            v_arrFiles = GetListOfFiles(strPath)

            For x = 0 To UBound(v_arrFiles)
                Try
                    _lngTotalBytes = _lngTotalBytes + v_arrFiles(x).Length
                Catch exp As Exception
                    ErrorHandler(exp, "IISLogsUtils.DetermineDirectorySize")
                End Try
            Next

            Return _lngTotalBytes
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsUtils.DetermineDirectorySize")
        End Try
    End Function

    Public Shared Function GetListOfFiles(ByVal strPath As String) As FileInfo()
        Dim di As DirectoryInfo
        Dim v_arrfiles As FileInfo()

        Try
            di = New DirectoryInfo(strPath)
            v_arrfiles = di.GetFiles()

            Return v_arrfiles
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsUtils.GetListOfFiles")
        End Try
    End Function

    Public Shared Function VerifyFileExtension(ByVal objFI As System.IO.FileInfo) As String
        Dim strResult As String
        Dim strLocalVariable As String
        Dim strDirName As String

        strLocalVariable = LCase(Trim(objFI.Extension.ToString()))
        strDirName = LCase(Trim(objFI.DirectoryName.ToString()))

        If m_strWinDir.Length = 0 Then
            m_strWinDir = "c:\windows"
        End If

        Select Case strDirName
            Case m_strWinDir, m_strWinDir & "\winsxs", m_strWinDir & "\assembly", m_strWinDir & "\inf", m_strWinDir & "\addins", m_strWinDir & "\application compatibility scripts", m_strWinDir & "\application compatibility scripts\install", m_strWinDir & "\application compatibility scripts\install\template", m_strWinDir & "\application compatibility scripts\logon", m_strWinDir & "\application compatibility scripts\logon\template", m_strWinDir & "\application compatibility scripts\uninstall", m_strWinDir & "\apppatch", m_strWinDir & "\apppatch\custom", m_strWinDir & "\cache", m_strWinDir & "\cache\adobe reader 6.0.1", m_strWinDir & "\cluster", m_strWinDir & "\config", m_strWinDir & "\connection wizard", m_strWinDir & "\cursors", m_strWinDir & "\debug", m_strWinDir & "\debug\usermode", m_strWinDir & "\debug\wpd", m_strWinDir & "\downloaded installations", m_strWinDir & "\downloaded installations\{28117458-acc7-4c67-8ed6-f6e56b1943e7}", m_strWinDir & "\downloaded installations\{6d288451-08a7-4a2d-9bba-6f0b88a8751c}", m_strWinDir & "\downloaded program files", m_strWinDir & "\driver cache", m_strWinDir & "\driver cache\i386", m_strWinDir & "\fonts"
                strResult = "PROTECTED_SYSTEM_FOLDER"
                Return strResult
            Case m_strWinDir & "\help", m_strWinDir & "\help\iishelp", m_strWinDir & "\help\iishelp\common", m_strWinDir & "\help\iishelp\iis", m_strWinDir & "\help\iishelp\iis\winhelp", m_strWinDir & "\help\mail", m_strWinDir & "\help\mmc", m_strWinDir & "\help\mmc\htm", m_strWinDir & "\help\mmc\misc", m_strWinDir & "\help\news", m_strWinDir & "\help\sms", m_strWinDir & "\help\sms\00000409", m_strWinDir & "\help\sms\00000409\sms.srv", m_strWinDir & "\help\sms\00000409\sms.srv\htm", m_strWinDir & "\help\tours", m_strWinDir & "\iis temporary compressed files", m_strWinDir & "\ime", m_strWinDir & "\ime\chsime", m_strWinDir & "\ime\chsime\applets", m_strWinDir & "\ime\chtime", m_strWinDir & "\ime\chtime\applets", m_strWinDir & "\ime\imejp", m_strWinDir & "\ime\imejp\applets", m_strWinDir & "\ime\imejp98", m_strWinDir & "\ime\imjp8_1", m_strWinDir & "\ime\imjp8_1\applets", m_strWinDir & "\ime\imjp8_1\dicts", m_strWinDir & "\ime\imkr6_1", m_strWinDir & "\ime\imkr6_1\applets", m_strWinDir & "\ime\imkr6_1\dicts", m_strWinDir & "\ime\shared", m_strWinDir & "\ime\shared\res", m_strWinDir & "\installer", m_strWinDir & "\java", m_strWinDir & "\java\classes", m_strWinDir & "\java\trustlib", m_strWinDir & "\media", m_strWinDir & "\microsoft.net", m_strWinDir & "\microsoft.net\authman", m_strWinDir & "\microsoft.net\authman\1.2", m_strWinDir & "\microsoft.net\framework", m_strWinDir & "\microsoft.net\framework\1033", m_strWinDir & "\microsoft.net\framework\v1.0.3705", m_strWinDir & "\microsoft.net\framework\v1.1.4322", m_strWinDir & "\microsoft.net\framework\v1.1.4322\1033", m_strWinDir & "\microsoft.net\framework\v1.1.4322\asp.netclientfiles", m_strWinDir & "\microsoft.net\framework\v1.1.4322\config", m_strWinDir & "\microsoft.net\framework\v1.1.4322\mui", m_strWinDir & "\microsoft.net\framework\v1.1.4322\mui\0409", m_strWinDir & "\microsoft.net\framework\v1.1.4322\temporary asp.net files", m_strWinDir & "\microsoft.net\framework\v2.0.50727", m_strWinDir & "\microsoft.net\framework\v2.0.50727\1033", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netclientfiles", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netclientfiles\crystalreportwebformviewer3", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netclientfiles\crystalreportwebformviewer3\css", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netclientfiles\crystalreportwebformviewer3\html", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netclientfiles\crystalreportwebformviewer3\images", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netclientfiles\crystalreportwebformviewer3\images\toolbar", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netclientfiles\crystalreportwebformviewer3\images\tree", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netclientfiles\crystalreportwebformviewer3\js", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\appconfig", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\appconfig\app_localresources", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\app_code", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\app_data", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\app_globalresources", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\app_localresources", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\images", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\providers", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\providers\app_localresources", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\security", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\security\app_localresources", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\security\permissions", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\security\permissions\app_localresources", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\security\roles", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\security\roles\app_localresources", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\security\users", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\security\users\app_localresources", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\security\wizard", m_strWinDir & "\microsoft.net\framework\v2.0.50727\asp.netwebadminfiles\security\wizard\app_localresources", m_strWinDir & "\microsoft.net\framework\v2.0.50727\config", m_strWinDir & "\microsoft.net\framework\v2.0.50727\config\browsers", m_strWinDir & "\microsoft.net\framework\v2.0.50727\microsoft .net framework 2.0", m_strWinDir & "\microsoft.net\framework\v2.0.50727\microsoft visual j# 2.0 redistributable package", m_strWinDir & "\microsoft.net\framework\v2.0.50727\msbuild", m_strWinDir & "\microsoft.net\framework\v2.0.50727\mui", m_strWinDir & "\microsoft.net\framework\v2.0.50727\mui\0409", m_strWinDir & "\microsoft.net\framework\v2.0.50727\redistlist", m_strWinDir & "\microsoft.net\framework\v2.0.50727\temporary asp.net files", m_strWinDir & "\microsoft.net\framework\vjsharp", m_strWinDir & "\msagent", m_strWinDir & "\msagent\chars", m_strWinDir & "\msagent\intl", m_strWinDir & "\msapps", m_strWinDir & "\msapps\msinfo", m_strWinDir & "\mui"
                strResult = "PROTECTED_SYSTEM_FOLDER"
                Return strResult
            Case m_strWinDir & "\nview", m_strWinDir & "\offline web pages", m_strWinDir & "\pchealth", m_strWinDir & "\pchealth\errorrep", m_strWinDir & "\pchealth\errorrep\qheadles", m_strWinDir & "\pchealth\errorrep\qsignoff", m_strWinDir & "\pchealth\errorrep\userdumps", m_strWinDir & "\pchealth\helpctr", m_strWinDir & "\pchealth\helpctr\batch", m_strWinDir & "\pchealth\helpctr\binaries", m_strWinDir & "\pchealth\helpctr\config", m_strWinDir & "\pchealth\helpctr\config\cache", m_strWinDir & "\pchealth\helpctr\config\checkpoint", m_strWinDir & "\pchealth\helpctr\config\news", m_strWinDir & "\pchealth\helpctr\database", m_strWinDir & "\pchealth\helpctr\datacoll", m_strWinDir & "\pchealth\helpctr\helpfiles", m_strWinDir & "\pchealth\helpctr\indices", m_strWinDir & "\pchealth\helpctr\installedskus", m_strWinDir & "\pchealth\helpctr\logs", m_strWinDir & "\pchealth\helpctr\offlinecache", m_strWinDir & "\pchealth\helpctr\offlinecache\server_32#0409", m_strWinDir & "\pchealth\helpctr\packagestore", m_strWinDir & "\pchealth\helpctr\system", m_strWinDir & "\pchealth\helpctr\system\blurbs", m_strWinDir & "\pchealth\helpctr\system\compatctr", m_strWinDir & "\pchealth\helpctr\system\css", m_strWinDir & "\pchealth\helpctr\system\dfs", m_strWinDir & "\pchealth\helpctr\system\dialogs", m_strWinDir & "\pchealth\helpctr\system\dvdupgrd", m_strWinDir & "\pchealth\helpctr\system\errmsg", m_strWinDir & "\pchealth\helpctr\system\errors", m_strWinDir & "\pchealth\helpctr\system\images", m_strWinDir & "\pchealth\helpctr\system\images\16x16", m_strWinDir & "\pchealth\helpctr\system\images\24x24", m_strWinDir & "\pchealth\helpctr\system\images\32x32", m_strWinDir & "\pchealth\helpctr\system\images\48x48", m_strWinDir & "\pchealth\helpctr\system\images\centers", m_strWinDir & "\pchealth\helpctr\system\images\expando", m_strWinDir & "\pchealth\helpctr\system\netdiag", m_strWinDir & "\pchealth\helpctr\system\panels", m_strWinDir & "\pchealth\helpctr\system\panels\subpanels", m_strWinDir & "\pchealth\helpctr\system\rc", m_strWinDir & "\pchealth\helpctr\system\remote assistance", m_strWinDir & "\pchealth\helpctr\system\remote assistance\common", m_strWinDir & "\pchealth\helpctr\system\remote assistance\css", m_strWinDir & "\pchealth\helpctr\system\remote assistance\interaction", m_strWinDir & "\pchealth\helpctr\system\remote assistance\interaction\client", m_strWinDir & "\pchealth\helpctr\system\remote assistance\interaction\common", m_strWinDir & "\pchealth\helpctr\system\remote assistance\interaction\server", m_strWinDir & "\pchealth\helpctr\system\scripts", m_strWinDir & "\pchealth\helpctr\system\sysinfo", m_strWinDir & "\pchealth\helpctr\system\sysinfo\graphics", m_strWinDir & "\pchealth\helpctr\system\sysinfo\graphics\33x16pie", m_strWinDir & "\pchealth\helpctr\system\sysinfo\graphics\47x24pie", m_strWinDir & "\pchealth\helpctr\system\updatectr", m_strWinDir & "\pchealth\helpctr\system_oem", m_strWinDir & "\pchealth\helpctr\temp", m_strWinDir & "\pchealth\helpctr\vendors", m_strWinDir & "\pchealth\helpctr\vendors\cn=microsoft corporation,l=redmond,s=washington,c=us", m_strWinDir & "\pchealth\helpctr\vendors\cn=microsoft corporation,l=redmond,s=washington,c=us\config", m_strWinDir & "\pchealth\helpctr\vendors\cn=microsoft corporation,l=redmond,s=washington,c=us\remote assistance", m_strWinDir & "\pchealth\helpctr\vendors\cn=microsoft corporation,l=redmond,s=washington,c=us\remote assistance\common", m_strWinDir & "\pchealth\helpctr\vendors\cn=microsoft corporation,l=redmond,s=washington,c=us\remote assistance\css", m_strWinDir & "\pchealth\helpctr\vendors\cn=microsoft corporation,l=redmond,s=washington,c=us\remote assistance\escalation", m_strWinDir & "\pchealth\helpctr\vendors\cn=microsoft corporation,l=redmond,s=washington,c=us\remote assistance\escalation\common", m_strWinDir & "\pchealth\helpctr\vendors\cn=microsoft corporation,l=redmond,s=washington,c=us\remote assistance\escalation\email", m_strWinDir & "\pchealth\helpctr\vendors\cn=microsoft corporation,l=redmond,s=washington,c=us\remote assistance\escalation\unsolicited", m_strWinDir & "\pchealth\uploadlb", m_strWinDir & "\pchealth\uploadlb\binaries", m_strWinDir & "\pchealth\uploadlb\config", m_strWinDir & "\pif", m_strWinDir & "\prefetch", m_strWinDir & "\provisioning", m_strWinDir & "\provisioning\schemas", m_strWinDir & "\pss"
                strResult = "PROTECTED_SYSTEM_FOLDER"
                Return strResult
            Case m_strWinDir & "\registeredpackages", m_strWinDir & "\registration", m_strWinDir & "\registration\crmlog", m_strWinDir & "\repair", m_strWinDir & "\resources", m_strWinDir & "\resources\themes", m_strWinDir & "\resources\themes\luna", m_strWinDir & "\resources\themes\luna\shell", m_strWinDir & "\resources\themes\luna\shell\homestead", m_strWinDir & "\resources\themes\luna\shell\metallic", m_strWinDir & "\resources\themes\luna\shell\normalcolor", m_strWinDir & "\schcache", m_strWinDir & "\security", m_strWinDir & "\security\database", m_strWinDir & "\security\logs", m_strWinDir & "\security\templates", m_strWinDir & "\security\templates\policies", m_strWinDir & "\servicepackfiles", m_strWinDir & "\servicepackfiles\i386", m_strWinDir & "\servicepackfiles\i386\lang", m_strWinDir & "\servicepackfiles\servicepackcache", m_strWinDir & "\servicepackfiles\servicepackcache\i386", m_strWinDir & "\shellnew", m_strWinDir & "\softwaredistribution", m_strWinDir & "\softwaredistribution\authcabs", m_strWinDir & "\softwaredistribution\authcabs\7971f918-a847-4430-9279-4a52d1efe18d", m_strWinDir & "\softwaredistribution\datastore", m_strWinDir & "\softwaredistribution\datastore\logs", m_strWinDir & "\softwaredistribution\download", m_strWinDir & "\softwaredistribution\eventcache", m_strWinDir & "\softwaredistribution\selfupdate", m_strWinDir & "\softwaredistribution\selfupdate\default", m_strWinDir & "\softwaredistribution\selfupdate\registered", m_strWinDir & "\softwaredistribution\websetup", m_strWinDir & "\softwaredistribution\wuredir", m_strWinDir & "\softwaredistribution\wuredir\7971f918-a847-4430-9279-4a52d1efe18d", m_strWinDir & "\softwaredistribution\wuredir\9482f4b4-e343-43b6-b170-9a65bc822c77", m_strWinDir & "\srchasst", m_strWinDir & "\srchasst\chars", m_strWinDir & "\srchasst\mui", m_strWinDir & "\srchasst\mui\0409", m_strWinDir & "\sun", m_strWinDir & "\sun\java", m_strWinDir & "\sun\java\deployment", m_strWinDir & "\symbols", m_strWinDir & "\symbols\dll"
                strResult = "PROTECTED_SYSTEM_FOLDER"
                Return strResult
            Case m_strWinDir & "\system", m_strWinDir & "\system32", m_strWinDir & "\system32\1025", m_strWinDir & "\system32\1028", m_strWinDir & "\system32\1031", m_strWinDir & "\system32\1033", m_strWinDir & "\system32\1037", m_strWinDir & "\system32\1041", m_strWinDir & "\system32\1042", m_strWinDir & "\system32\1054", m_strWinDir & "\system32\2052", m_strWinDir & "\system32\3076", m_strWinDir & "\system32\3com_dmi", m_strWinDir & "\system32\administration", m_strWinDir & "\system32\administration\images", m_strWinDir & "\system32\appmgmt", m_strWinDir & "\system32\appmgmt\machine", m_strWinDir & "\system32\appmgmt\s-1-5-21-2364807359-3422780413-305424318-500", m_strWinDir & "\system32\cache", m_strWinDir & "\system32\catroot", m_strWinDir & "\system32\catroot\{127d0a1d-4ef2-11d1-8608-00c04fc295ee}", m_strWinDir & "\system32\catroot\{f750e6c3-38ee-11d1-85e5-00c04fc295ee}", m_strWinDir & "\system32\catroot2", m_strWinDir & "\system32\catroot2\{127d0a1d-4ef2-11d1-8608-00c04fc295ee}", m_strWinDir & "\system32\catroot2\{f750e6c3-38ee-11d1-85e5-00c04fc295ee}", m_strWinDir & "\system32\certsrv", m_strWinDir & "\system32\certsrv\certcontrol", m_strWinDir & "\system32\certsrv\certcontrol\ia64", m_strWinDir & "\system32\certsrv\certcontrol\w2k", m_strWinDir & "\system32\certsrv\certcontrol\x86", m_strWinDir & "\system32\clients", m_strWinDir & "\system32\clients\faxclient", m_strWinDir & "\system32\clients\faxclient\drivers", m_strWinDir & "\system32\clients\faxclient\drivers\nt4", m_strWinDir & "\system32\clients\faxclient\drivers\w9x", m_strWinDir & "\system32\clients\faxclient\prgfiles", m_strWinDir & "\system32\clients\faxclient\prgfiles\msfax", m_strWinDir & "\system32\clients\faxclient\prgfiles\msfax\bin", m_strWinDir & "\system32\clients\faxclient\prgfiles\msfax\bin9x", m_strWinDir & "\system32\clients\faxclient\system", m_strWinDir & "\system32\clients\faxclient\system\w98", m_strWinDir & "\system32\clients\faxclient\system32", m_strWinDir & "\system32\clients\tsclient", m_strWinDir & "\system32\clients\tsclient\win32", m_strWinDir & "\system32\clients\twclient", m_strWinDir & "\system32\clients\twclient\amd64", m_strWinDir & "\system32\clients\twclient\ia64", m_strWinDir & "\system32\clients\twclient\x86", m_strWinDir & "\system32\com", m_strWinDir & "\system32\config", m_strWinDir & "\system32\config\systemprofile", m_strWinDir & "\system32\dhcp", m_strWinDir & "\system32\dllcache", m_strWinDir & "\system32\dns", m_strWinDir & "\system32\dns\backup", m_strWinDir & "\system32\dns\samples", m_strWinDir & "\system32\drivers", m_strWinDir & "\system32\drivers\disdn", m_strWinDir & "\system32\drivers\etc", m_strWinDir & "\system32\export", m_strWinDir & "\system32\grouppolicy", m_strWinDir & "\system32\grouppolicy\adm", m_strWinDir & "\system32\grouppolicy\machine", m_strWinDir & "\system32\grouppolicy\machine\scripts", m_strWinDir & "\system32\grouppolicy\machine\scripts\shutdown", m_strWinDir & "\system32\grouppolicy\machine\scripts\startup", m_strWinDir & "\system32\grouppolicy\user", m_strWinDir & "\system32\ias", m_strWinDir & "\system32\icsxml", m_strWinDir & "\system32\ime", m_strWinDir & "\system32\ime\cintlgnt", m_strWinDir & "\system32\ime\pintlgnt", m_strWinDir & "\system32\ime\tintlgnt", m_strWinDir & "\system32\inetsrv", m_strWinDir & "\system32\inetsrv\asp compiled templates", m_strWinDir & "\system32\inetsrv\history", m_strWinDir & "\system32\inetsrv\iisadmpwd", m_strWinDir & "\system32\inetsrv\metaback", m_strWinDir & "\system32\macromed", m_strWinDir & "\system32\macromed\common", m_strWinDir & "\system32\macromed\director", m_strWinDir & "\system32\macromed\flash", m_strWinDir & "\system32\macromed\shockwave 10", m_strWinDir & "\system32\macromed\shockwave 10\xtras", m_strWinDir & "\system32\macromed\update", m_strWinDir & "\system32\microsoft", m_strWinDir & "\system32\microsoft\protect", m_strWinDir & "\system32\microsoft\protect\s-1-5-18", m_strWinDir & "\system32\microsoft\protect\s-1-5-18\user", m_strWinDir & "\system32\microsoft\protect\s-1-5-20", m_strWinDir & "\system32\microsoftpassport", m_strWinDir & "\system32\msdtc", m_strWinDir & "\system32\msdtc\trace", m_strWinDir & "\system32\mui", m_strWinDir & "\system32\mui\0009", m_strWinDir & "\system32\mui\0401", m_strWinDir & "\system32\mui\0404", m_strWinDir & "\system32\mui\0405", m_strWinDir & "\system32\mui\0406", m_strWinDir & "\system32\mui\0407", m_strWinDir & "\system32\mui\0408", m_strWinDir & "\system32\mui\0409", m_strWinDir & "\system32\mui\040b", m_strWinDir & "\system32\mui\040c", m_strWinDir & "\system32\mui\040d", m_strWinDir & "\system32\mui\040e", m_strWinDir & "\system32\mui\0410", m_strWinDir & "\system32\mui\0411", m_strWinDir & "\system32\mui\0412", m_strWinDir & "\system32\mui\0413", m_strWinDir & "\system32\mui\0414", m_strWinDir & "\system32\mui\0415", m_strWinDir & "\system32\mui\0416", m_strWinDir & "\system32\mui\0419", m_strWinDir & "\system32\mui\041d", m_strWinDir & "\system32\mui\041f", m_strWinDir & "\system32\mui\0804", m_strWinDir & "\system32\mui\0816", m_strWinDir & "\system32\mui\0c0a", m_strWinDir & "\system32\mui\dispspec", m_strWinDir & "\system32\netmon", m_strWinDir & "\system32\netmon\captures", m_strWinDir & "\system32\netmon\parsers", m_strWinDir & "\system32\npp", m_strWinDir & "\system32\ntmsdata", m_strWinDir & "\system32\oobe", m_strWinDir & "\system32\oobe\actsetup", m_strWinDir & "\system32\oobe\error", m_strWinDir & "\system32\oobe\html", m_strWinDir & "\system32\oobe\html\ispsgnup", m_strWinDir & "\system32\oobe\html\mouse", m_strWinDir & "\system32\oobe\html\oemcust", m_strWinDir & "\system32\oobe\html\oemhw", m_strWinDir & "\system32\oobe\html\oemreg", m_strWinDir & "\system32\oobe\images", m_strWinDir & "\system32\oobe\regerror", m_strWinDir & "\system32\oobe\sample", m_strWinDir & "\system32\oobe\setup", m_strWinDir & "\system32\pop3server", m_strWinDir & "\system32\ras", m_strWinDir & "\system32\reinstallbackups", m_strWinDir & "\system32\reinstallbackups\0001", m_strWinDir & "\system32\reinstallbackups\0001\driverfiles", m_strWinDir & "\system32\reinstallbackups\0001\driverfiles\i386", m_strWinDir & "\system32\reinstallbackups\0002", m_strWinDir & "\system32\reinstallbackups\0002\driverfiles", m_strWinDir & "\system32\reinstallbackups\0002\driverfiles\i386", m_strWinDir & "\system32\reminst", m_strWinDir & "\system32\rpcproxy", m_strWinDir & "\system32\serverappliance", m_strWinDir & "\system32\serverappliance\mui", m_strWinDir & "\system32\serverappliance\mui\0409", m_strWinDir & "\system32\serverappliance\web", m_strWinDir & "\system32\serverappliance\web\admin", m_strWinDir & "\system32\serverappliance\web\admin\help", m_strWinDir & "\system32\serverappliance\web\admin\help\0409", m_strWinDir & "\system32\setup", m_strWinDir & "\system32\shellext", m_strWinDir & "\system32\softwaredistribution", m_strWinDir & "\system32\softwaredistribution\setup", m_strWinDir & "\system32\softwaredistribution\setup\servicestartup", m_strWinDir & "\system32\softwaredistribution\setup\servicestartup\wuapi.dll", m_strWinDir & "\system32\softwaredistribution\setup\servicestartup\wuapi.dll\5.8.0.2469", m_strWinDir & "\system32\softwaredistribution\setup\servicestartup\wups.dll", m_strWinDir & "\system32\softwaredistribution\setup\servicestartup\wups.dll\5.8.0.2469", m_strWinDir & "\system32\softwaredistribution\setup\servicestartup\wups2.dll", m_strWinDir & "\system32\softwaredistribution\setup\servicestartup\wups2.dll\5.8.0.2469", m_strWinDir & "\system32\spool", m_strWinDir & "\system32\spool\drivers", m_strWinDir & "\system32\spool\drivers\color", m_strWinDir & "\system32\spool\drivers\w32x86", m_strWinDir & "\system32\spool\drivers\w32x86\3", m_strWinDir & "\system32\spool\drivers\w32x86\3\temp", m_strWinDir & "\system32\spool\drivers\w32x86\hpdeskjet_38404c1e", m_strWinDir & "\system32\spool\drivers\win40", m_strWinDir & "\system32\spool\printers", m_strWinDir & "\system32\spool\prtprocs", m_strWinDir & "\system32\spool\prtprocs\w32x86", m_strWinDir & "\system32\wbem", m_strWinDir & "\system32\wbem\adstatus", m_strWinDir & "\system32\wbem\autorecover", m_strWinDir & "\system32\wbem\logs", m_strWinDir & "\system32\wbem\mof", m_strWinDir & "\system32\wbem\mof\bad", m_strWinDir & "\system32\wbem\mof\good", m_strWinDir & "\system32\wbem\performance", m_strWinDir & "\system32\wbem\repository", m_strWinDir & "\system32\wbem\repository\fs", m_strWinDir & "\system32\wbem\snmp", m_strWinDir & "\system32\wbem\xml", m_strWinDir & "\system32\windows media", m_strWinDir & "\system32\windows media\server", m_strWinDir & "\system32\windows media\server\admin", m_strWinDir & "\system32\windows media\server\admin\mmc", m_strWinDir & "\system32\windows media\server\admin\web", m_strWinDir & "\system32\wins", m_strWinDir & "\tapi", m_strWinDir & "\tasks", m_strWinDir & "\twain_32", m_strWinDir & "\web", m_strWinDir & "\web\printers", m_strWinDir & "\web\printers\images", m_strWinDir & "\web\printers\prtcabs", m_strWinDir & "\web\wallpaper"
                strResult = "PROTECTED_SYSTEM_FOLDER"
                Return strResult
        End Select

        Select Case strLocalVariable

            Case ".log", ".zip", ".bdr", ".bdp", ".bad"
                strResult = "YES"
                Return strResult
            Case ".txt"
                strResult = "DONOTHING"

                If m_blnProcessTXT = True Then
                    strResult = "YES"
                End If

                Return strResult
            Case ".bak"
                strResult = "DONOTHING"

                If m_blnProcessBAK = True Then
                    strResult = "YES"
                End If

                Return strResult
            Case ".dat"
                strResult = "DONOTHING"

                If m_blnProcessDAT = True Then
                    strResult = "YES"
                End If

                Return strResult
            Case ".xml"
                strResult = "DONOTHING"

                If m_blnProcessXML = True Then
                    strResult = "YES"
                End If

                Return strResult

            Case ".adr", ".bat", ".c", ".cab", ".cat", ".chk", ".chm", ".cfg", ".cmd", ".com", ".dbx", ".dit", ".dll", ".dns", ".dxt", ".edb", ".evt", ".exe", ".gpd", ".h", ".hlp", ".ini", ".inf", ".ldf", ".lnk", ".man", ".mbx", ".mdf", ".mfl", ".mof", ".msc", ".mui", ".mum", ".ntds", ".ndf", ".pif", ".pdb", ".pnf", ".policy", ".ppd", ".pst", ".scr", ".sys", ".tlb", ".vxd", ".vmm", ".vm"
                strResult = "PROTECTED_SYSTEMFILE_EXTENSION"
                Return strResult
            Case ".bmp", ".dib", ".eps", ".gif", ".ico", ".jpg", ".jpeg", ".jpe", ".jfif", ".png", ".psd", ".pdd", ".pcx", ".pdp", ".pct", ".pict", ".pxr", ".raw", ".rle", ".tif", ".tiff", ".tga", ".vda", ".icb", ".vst"
                strResult = "PROTECTED_IMAGEFILE_EXTENSION"
                Return strResult
            Case ".wav", ".snd", ".au", ".aif", ".aifc", ".wma", ".cda", ".asx", ".wax", ".m3u", ".wvx", ".wmx", ".mid", ".rmi", ".midi", ".mpeg", ".mpg", ".mp3", ".avi", ".wmv", ".asf", ".wm", ".wma", ".wmv"
                strResult = "PROTECTED_SOUNDFILE_EXTENSION"
                Return strResult
            Case ".css", ".asa", ".asax", ".asbx", ".ascx", ".ashx", ".asix", ".asmx", ".asp", ".aspq", ".aspx", ".axd", ".browser", ".cd", ".cdx", ".cer", ".compiled", ".config", ".cs", ".cshtm", ".cshtml", ".csproj", ".dsdgm", ".dsprototype", ".htw", ".html", ".htm", ".ida", ".idc", ".idq", ".jsl", ".ldb", ",licx", ".lsad", ".master", ".mdb", ".msgx", ".rem", ".resources", ".resx", ".sdm", ".sdmDocument", ".shtm", ".shtml", ".sitemap", ".skin", ".soap", ".ssdgm", ".ssmap", ".stm", ".svc", ".vb", ".vbproj", ".vbhtm", ".vbhtml", ".vjsproj", ".vsdisco", ".webinfo", ".wsdl", ".jar", ".class", ".pl", ".cgi", ".jsp", ".application", ".cfm", ".php", ".ph3", ".pl", ".xoml", ".xamlx"
                strResult = "PROTECTED_WEBFILE_EXTENSION"
                Return strResult
            Case ".cs", ".js", ".vbs", ".wsh", ".bat", ".cmd"
                strResult = "PROTECTED_SCRIPTFILE_EXTENSION"
                Return strResult
            Case ".adp", ".doc", ".mdb", ".ldb", ".xls", ".ppt", ".vsd", ".vss", ".docx", ".pptx", ".xlsx", ".accdb"
                strResult = "PROTECTED_MSOFFICEFILE_EXTENSION"
                Return strResult
            Case Else
                strResult = "DONOTHING"
                Return strResult
        End Select

    End Function

    Public Shared Function VerifyDeletePolicyAgreement() As String
        Try
            If m_DeletePolicyAgreementSigned = True And File.Exists(m_LogDirectoryPath & "PolicyAgreements\DeletePolicyAgreement.txt") = True Then
                m_DeletePolicyAgreement = True
            Else
                m_DeletePolicyAgreement = False
                WriteToEventLog("The Delete Policy Agreement isn't signed, files can't be deleted until the the IISLogs Delete Policy Agreement is read and agreed upon and signed and/or typed name in agreement and/or DeleteOriginalFile is also turned on.  Please refer to IISLogs Help in IISLogsGUI for further details")
                IISLogsTracking.errorData("VerifyDeletePolicyAgreement", "The Delete Policy Agreement isn't signed, files can't be deleted until the the IISLogs Delete Policy Agreement is read and agreed upon and signed and/or typed name in agreement and/or DeleteOriginalFile is also turned on.  Please refer to IISLogs Help in IISLogsGUI for further details", "N/A", "N/A")
            End If
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsUtil.VerifyDeletePolicyAgreement")
        End Try
    End Function

    Public Shared Function VerifyFileCompressionPolicyAgreement() As String
        Try
            If m_FileCompressionPolicyAgreementSigned = True And File.Exists(m_LogDirectoryPath & "PolicyAgreements\FileCompressionPolicyAgreement.txt") = True Then
                m_FileCompressionPolicyAgreement = True
            Else
                m_FileCompressionPolicyAgreement = False
                WriteToEventLog("The File Compression Policy Agreement isn't signed, files can't be compressed until the IISLogs file compression policy agreement is read and agreed upon and signed and/or typed name in agreement.  Please refer to IISLogs Help in IISLogsGUI for further details")
                IISLogsTracking.errorData("VerifyFileCompressionPolicyAgreement", "The File Compression Policy Agreement isn't signed, files can't be compressed until the IISLogs file compression policy agreement is read and agreed upon and signed and/or typed name in agreement.  Please refer to IISLogs Help in IISLogsGUI for further details", "N/A", "N/A")
            End If
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsUtil.VerifyDeletePolicyAgreement")
        End Try
    End Function

    Public Shared Function GetConfigFileName() As String
        Try
            Return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) & "\" & System.Reflection.Assembly.GetEntryAssembly.GetName.Name.ToString & ".exe.config"
        Catch exp As Exception
            ErrorHandler(exp, "DynamicallyAddFiles.GetConfigFileName")
        End Try
    End Function

    Public Shared Sub SaveConfigData(ByVal ConfigFileName As String, ByVal KeyName As String, ByVal KeyValue As String)
        Try
            Dim AppRW As New AppConfigReadWriteClass.ReadWrite
            AppRW.LoadConfigSource(ConfigFileName)
            AppRW.setSetting(KeyName, KeyValue)
            AppRW.SaveConfigSource(ConfigFileName)
        Catch exp As Exception
            ErrorHandler(exp, "NOTHING")
        End Try
    End Sub

    Public Shared Sub CreateBaseFolderStructure()

        If Directory.Exists(m_LogDirectoryPath & "pk") = False Then
            Directory.CreateDirectory(m_LogDirectoryPath & "pk")
        End If

        If Directory.Exists(m_LogDirectoryPath & "ArchiveLogs") = False Then
            Directory.CreateDirectory(m_LogDirectoryPath & "ArchiveLogs")
        End If

        If Directory.Exists(m_LogDirectoryPath & "PolicyAgreements") = False Then
            Directory.CreateDirectory(m_LogDirectoryPath & "PolicyAgreements")
        End If
    End Sub

#Region " IISLogs 4.0 utils"

    
#End Region

End Class