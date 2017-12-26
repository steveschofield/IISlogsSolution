Imports System.IO
Imports Xceed.Zip

Public Class IISLogsPerDirectory
    Inherits IISLogsd.IISLogsStartModule
    
#Region " Variables"

    '############################################################
    'Anything with m_ is inherited from the Start Module, everything else starts with c_ (class level)
    'This includes
    '1) Detail logging variables
    '2) Write to console 
    '3) Machine / Computer name variable 
    '4) Compression, Delete files agreements variables
    '############################################################

    'Global variables
    Private Shared c_arrMonitoredDir As New ArrayList
    Private Shared c_blnZipResult As Boolean
    Private Shared c_strZipFileName As String

    'Variables from Per Directory XML file
    'This matches the layout of the XML file output
    Private Shared c_strDirectoryName As String
    Private Shared c_blnZipFile As Boolean
    Private Shared c_intZipRetentionPeriod As Integer
    Private Shared c_blnDeleteOriginalFile As Boolean
    Private Shared c_blnDeleteFile As Boolean
    Private Shared c_intDeleteRetentionPeriod As Integer
    Private Shared c_blnRecursive As Boolean
    Private Shared c_blnProcessRootFolderRecursive As Boolean
    Private Shared c_strZipFilePath As String
    Private Shared c_strIncludeComputerName As Boolean
    Private Shared c_ProcessUnknownExtensions As Boolean
    Private Shared c_blnProcessTXT As Boolean
    Private Shared c_blnProcessBAK As Boolean
    Private Shared c_blnProcessDAT As Boolean
    Private Shared c_blnProcessXML As Boolean
    'Start of not displayed in IISLogsGUI
    Private Shared c_strNamingConvention As String
    Private Shared c_strDelimiter As String
    'End of not displayed in IISLogsGUI
    Private Shared c_blnProcessEXE As Boolean
    Private Shared c_blnProcessMSP As Boolean
    Private Shared c_blnProcessDLL As Boolean
    Private Shared c_blnProcessINI As Boolean
    Private Shared c_blnProcessCFG As Boolean
    Private Shared c_blnProcessTMP As Boolean

    '.NET 4.0 specfic
    Private Shared c_intLogsDWM As Integer
    Private Shared c_PreserveDirPath As Boolean

#End Region

#Region " Get XML file and Build Directory info"

    Public Shared Sub IISLogsPerDirectoryMain(ByVal fn As String)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Try
            'Production path
            ds.ReadXml(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) & "\" & fn)

            'Used for debugging purposes only
            'ds.ReadXml("C:\Program Files (x86)\IISLogsEXE4\IISLogsPerDirectory.xml")

            dt = ds.Tables(0)

            For Each dr In dt.Rows
                Try
                    Dim sn As String = dr.Item("DirectoryName").ToString()
                    If System.IO.Directory.Exists(dr.Item("DirectoryName").ToString()) = True Then
                        'Load the Config per directory
                        LoadPerDirectoryConfig(dr)

                        'Build Directory List per Directory
                        BuildDirectoryList(CType(dr.Item("DirectoryName"), String))

                        'Process Directory
                        FilesMain(c_arrMonitoredDir)

                        'Clear the Config per directory
                        'This has to be done to ensure each directory is handled separately
                        ClearPerDirectoryConfig()
                    End If

                Catch ex As Exception
                    ErrorHandler(ex, "ReadFileName")
                End Try
            Next

            ds.Dispose()
            dt.Dispose()
        Catch ex As Exception
            ErrorHandler(ex, "Trying to Read XML file in Per Directory Function")
        End Try
    End Sub

    Private Shared Sub BuildDirectoryList(ByVal strPath As String)
        Dim di As DirectoryInfo
        Try

            If c_blnRecursive = False Then
                c_arrMonitoredDir.Add(strPath)
            Else
                If c_blnProcessRootFolderRecursive = True Then
                    c_arrMonitoredDir.Add(strPath)
                End If
                di = New DirectoryInfo(strPath)
                RecursiveDirLookup(di, 0)
            End If
        Catch exp As Exception
            ErrorHandler(exp, "BuildDirectoryList")
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

                    'If arrLog.Length > 0 Or arrZip.Length > 0 Then
                    c_arrMonitoredDir.Add(subDirectories(x).FullName)
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

#End Region

#Region " Process Directories"

    Private Shared Sub FilesMain(ByVal arrDirList As ArrayList)
        Dim strName As String
        Try
            For Each strName In arrDirList
                'This try statement is to insure all values in the arrDirList arrayList is tried
                Try
                    If m_ConsoleWriteLineToScreen = True Then
                        Console.WriteLine("Starting: " & strName)
                    End If

                    If System.IO.Directory.Exists(strName) = True Then
                        ProcessDirectory(strName)
                    End If
                Catch exp As Exception
                    ErrorHandler(exp, "Main ForLoop arrDirList")
                End Try
            Next
        Catch exp As Exception
            ErrorHandler(exp, "Main ForLoop arrDirList")
        End Try
    End Sub

    Private Shared Function ProcessDirectory(ByVal strDirName As String) As Long
        Dim v_arrFiles As FileInfo()
        Dim strFileStatus As String

        'All of these DIM'd variables for tracking ONLY
        '*********************************************
        Dim Space5 As String = Space(5)
        Dim Space10 As String = Space(10)
        Dim Space20 As String = Space(20)

        Dim sb As New System.Text.StringBuilder
        Dim lngBeforeTotalBytes As Long = 0
        Dim lngAfterTotalBytes As Long = 0
        Dim dtStartTime As DateTime
        Dim dtFinishTime As DateTime
        Dim dtStartFile As DateTime
        Dim dtFinishFile As DateTime
        Dim x As Integer = 0
        Dim intCounter As Integer = 0
        Dim intTotalNumberFiles As Integer = 0
        Dim intTotalNumberFilesChanged As Integer = 0
        '*********************************************

        Try
            'Get List of Files in the particular directory
            v_arrFiles = IISLogsUtils.GetListOfFiles(strDirName)

            'Determine Directory Size Before processing
            lngBeforeTotalBytes = IISLogsUtils.DetermineDirectorySize(strDirName)

            'Record Start Time
            dtStartTime = System.DateTime.Now()

            'Counter used to determine if a newline is created or not.
            intCounter = UBound(v_arrFiles) + 1

            'Capture # of files before starting to loop,
            'Only used below for tracking/reporting purposes
            intTotalNumberFiles = UBound(v_arrFiles) + 1

            For x = 0 To UBound(v_arrFiles)
                'This try statement is to insure all values in the v_arrGetFiles arrayList is tried
                Try

                    If m_ConsoleWriteLineToScreen = True Then
                        Console.WriteLine(Space5 & v_arrFiles(x).Name)
                    End If

                    'Performance stat capture when the file gets started process
                    dtStartFile = System.DateTime.Now()

                    'This is the core logic of IISLogs, it process each file either to ZIP and/or Delete
                    'This processes the file calling the ProcessFilesActions.vb file functions
                    strFileStatus = FilesActionsMain(v_arrFiles(x))

                    'Performance stat capture when the file gets started finished
                    dtFinishFile = System.DateTime.Now()

                    If strFileStatus = "ZIPFILE" Or strFileStatus = "DELETEFILE" Then
                        intTotalNumberFilesChanged = intTotalNumberFilesChanged + 1
                    End If

                    'Build a string of all the file information if configured to
                    If m_DetailFileLogging = True Then
                        intCounter = intCounter - 1
                        sb.Append(IISLogsTracking.detailLoggingInfo(v_arrFiles(x), strDirName, dtStartFile, dtFinishFile, strFileStatus, intCounter))
                    End If
                Catch exp As Exception
                    ErrorHandler(exp, "IISLogFiles.ProcessDirectory ForLoop v_arrGetFiles")
                End Try
            Next

            'Record Finish Time
            dtFinishTime = System.DateTime.Now()

            'Determine Directory size after processing
            lngAfterTotalBytes = IISLogsUtils.DetermineDirectorySize(strDirName)

            'Logs Summary information only
            If m_SummaryFileLogging = True Then
                IISLogsTracking.summaryData(strDirName, intTotalNumberFiles, intTotalNumberFilesChanged, lngBeforeTotalBytes, lngAfterTotalBytes, dtStartTime, dtFinishTime)
            End If

            'Log detail data if configured.
            If m_DetailFileLogging = True And sb.Length > 0 Then
                IISLogsTracking.detailData(sb.ToString())
            End If
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsFiles.ProcessDirectory")
        End Try
    End Function

#End Region

#Region " Process files"

    Private Shared Function FilesActionsMain(ByVal fi As FileInfo) As String
        Dim strResult As String
        Dim strStatus As String

        Try
            strStatus = VerifyFileExtensionPerDirectory(fi)

            If strStatus = "YES" Then
                strResult = DetermineFileStatus(fi)
            Else
                strResult = strStatus
            End If

            Return strResult
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsFilesActions.Main")
        End Try
    End Function

    Private Shared Function DetermineFileStatus(ByVal fi As FileInfo) As String
        Dim strZipFile As Boolean
        Dim strDeleteFile As Boolean
        Dim lngZipRetentionPeriod As Long
        Dim lngDeleteRetentionPeriod As Long
        Dim strResult As String
        Dim lngFileAge As Long
        Dim dtTodayDate As DateTime

        Try
            strResult = "DONOTHING"
            strZipFile = c_blnZipFile
            strDeleteFile = c_blnDeleteFile
            lngZipRetentionPeriod = c_intZipRetentionPeriod
            lngDeleteRetentionPeriod = c_intDeleteRetentionPeriod

            dtTodayDate = System.DateTime.Now
            lngFileAge = DateDiff(DateInterval.Hour, fi.LastWriteTime, dtTodayDate)

            'Condition one - can't zip an already zipped file
            If Not fi.Extension.ToLower = ".zip" Then
                'Condition two - both configuration Zip and Zip Retention Period not Zero Days
                If strZipFile = True And Not lngZipRetentionPeriod = 0 Then
                    'Condition three - testing to insure file age is great than configured lngZipRetentionPeriod
                    If lngFileAge > lngZipRetentionPeriod Then
                        'Condition four - insures Zip Retention Period is lower than delete retentionPeriod unless
                        'the DeleteRetentenion period is ZERO.  Zero DeleteRetentionPeriod means its not enabled.
                        If lngZipRetentionPeriod < lngDeleteRetentionPeriod Or lngDeleteRetentionPeriod = 0 Then
                            'This is the last check before allowing a file to be compressed
                            If m_FileCompressionPolicyAgreement = True Then
                                strResult = "ZIPFILE"
                            End If
                        End If
                    End If
                End If
            End If

            'Condition one - both configuration Delete and Delete Retention Period not Zero Days
            If strDeleteFile = True And Not lngDeleteRetentionPeriod = 0 Then
                'Condition two - both the file age has to be greater than
                'What the configuration file says
                If lngFileAge > lngDeleteRetentionPeriod Then
                    'Condition three - This is a logic condition, at no time can the Delete Time 
                    'Be shorter than the zip retention period however ONLY in the case of the zip retentionperiod
                    'being zero because its not being used.  If this wasn't there it would be impossible
                    'To zip a file that is older so its more of a pre-caution than anything
                    If lngDeleteRetentionPeriod > lngZipRetentionPeriod Or lngZipRetentionPeriod = 0 Then
                        'This is the last check before allowing a file to be deleted
                        If m_DeletePolicyAgreement = True Then
                            strResult = "DELETEFILE"
                        End If
                    End If
                End If
            End If

            If Not strResult = "DONOTHING" Then
                strResult = doFile(fi, strResult)
            End If

            Return strResult
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsFilesActions.DetermineFileStatus")
        End Try
    End Function

    Private Shared Function doFile(ByVal fi As FileInfo, ByVal strResult As String) As String
        Try
            Select Case UCase(strResult)
                Case "ZIPFILE"
                    'Call IISLogsQuickZip class, this uses the Xceed.Zip component ZIP file locally
                    CompressFile(fi, c_strZipFilePath)

                    'This HAS set to true in-order to enforce original files aren't deleted
                    If c_blnDeleteOriginalFile = True And m_DeletePolicyAgreement = True Then
                        File.Delete(fi.FullName)
                    End If

                    'The looks at the result returned when file is zipped
                    'If True will be processed either locally or moved remotely
                    If c_blnZipResult = True Then
                        Return "ZIPFILE"
                    Else
                        Return "ZIPFILEEXISTS"
                    End If
                Case "DELETEFILE"
                    If File.Exists(fi.FullName) = True Then
                        File.Delete(fi.FullName)
                        Return "DELETEFILE"
                    End If
                Case Else
                    Return "DONOTHING"
            End Select
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsFilesActions.doFile")
        End Try
    End Function

#End Region

#Region " Load and Clear Config per row"

    Private Shared Sub LoadPerDirectoryConfig(ByVal dr As DataRow)
        c_strDirectoryName = dr.Item("DirectoryName").ToString()
        c_blnZipFile = CType(dr.Item("ZipFile"), Boolean)
        c_intZipRetentionPeriod = CType(dr.Item("ZipRetentionPeriod"), Integer)
        c_blnDeleteOriginalFile = CType(dr.Item("DeleteOriginalFile"), Boolean)
        c_blnDeleteFile = CType(dr.Item("DeleteFile"), Boolean)
        c_intDeleteRetentionPeriod = CType(dr.Item("DeleteRetentionPeriod"), Integer)
        c_blnRecursive = CType(dr.Item("Recursive"), Boolean)
        c_blnProcessRootFolderRecursive = CType(dr.Item("ProcessRootFolderRecursive"), Boolean)
        c_strZipFilePath = CType(dr.Item("ZipFilePath"), String)
        c_strIncludeComputerName = CType(dr.Item("IncludeComputerName"), Boolean)
        c_ProcessUnknownExtensions = CType(dr.Item("ProcessUnknownExtensions"), Boolean)
        c_blnProcessTXT = CType(dr.Item("ProcessTXT"), Boolean)
        c_blnProcessBAK = CType(dr.Item("ProcessBAK"), Boolean)
        c_blnProcessDAT = CType(dr.Item("ProcessDAT"), Boolean)
        c_blnProcessXML = CType(dr.Item("ProcessXML"), Boolean)
        c_strNamingConvention = dr.Item("NamingConvention").ToString
        c_strDelimiter = dr.Item("Delimiter").ToString
        c_blnProcessEXE = CType(dr.Item("ProcessEXE"), Boolean)
        c_blnProcessMSP = CType(dr.Item("ProcessMSP"), Boolean)
        c_blnProcessDLL = CType(dr.Item("ProcessDLL"), Boolean)
        c_blnProcessINI = CType(dr.Item("ProcessINI"), Boolean)
        c_blnProcessCFG = CType(dr.Item("ProcessCFG"), Boolean)
        c_blnProcessTMP = CType(dr.Item("ProcessTMP"), Boolean)

        'IISLogs 4.0 specific
        c_intLogsDWM = CType(dr.Item("LogsDWM"), Integer)
        c_PreserveDirPath = CType(dr.Item("PreserveDirPath"), Boolean)

        c_arrMonitoredDir.Clear()
    End Sub

    Private Shared Sub ClearPerDirectoryConfig()
        c_strDirectoryName = Nothing
        c_blnZipFile = False
        c_intZipRetentionPeriod = 0
        c_blnDeleteOriginalFile = False
        c_blnDeleteFile = False
        c_intDeleteRetentionPeriod = 0
        c_blnRecursive = False
        c_blnProcessRootFolderRecursive = False
        c_strZipFilePath = Nothing
        c_strIncludeComputerName = False
        c_ProcessUnknownExtensions = False
        c_blnProcessTXT = False
        c_blnProcessBAK = False
        c_blnProcessDAT = False
        c_blnProcessXML = False
        c_strNamingConvention = ""
        c_blnProcessEXE = False
        c_blnProcessMSP = False
        c_blnProcessDLL = False
        c_blnProcessINI = False
        c_blnProcessCFG = False
        c_blnProcessTMP = False
        c_intLogsDWM = 0
        c_PreserveDirPath = False

        c_arrMonitoredDir.Clear()
    End Sub

#End Region

#Region " Verify File Extensions"

    Private Shared Function VerifyFileExtensionPerDirectory(ByVal objFI As System.IO.FileInfo) As String
        Dim strResult As String
        Dim strLocalVariable As String
        Dim strDirName As String

        strLocalVariable = LCase(Trim(objFI.Extension.ToString()))
        strDirName = LCase(Trim(objFI.DirectoryName.ToString()))

        If m_strWinDir.Length = 0 Then
            m_strWinDir = "c:\windows"
        End If

        If CheckDirName(objFI) = True Then
            strResult = "PROTECTED_SYSTEM_FOLDER"
            Return strResult
        End If

        Select Case strLocalVariable
            Case ".log", ".zip", ".bdr", ".bdp", ".bad"
                strResult = "YES"
                Return strResult
            Case ".txt"
                strResult = "DONOTHING"

                If c_blnProcessTXT = True Then
                    strResult = "YES"
                End If

                Return strResult
            Case ".bak"
                strResult = "DONOTHING"

                If c_blnProcessBAK = True Then
                    strResult = "YES"
                End If

                Return strResult
            Case ".dat"
                strResult = "DONOTHING"

                If c_blnProcessDAT = True Then
                    strResult = "YES"
                End If

                Return strResult
            Case ".xml"
                strResult = "DONOTHING"

                If c_blnProcessXML = True Then
                    strResult = "YES"
                End If

                Return strResult
            Case ".exe"
                strResult = "DONOTHING"

                If c_blnProcessEXE = True Then
                    strResult = "YES"
                End If

                Return strResult
            Case ".msp"
                strResult = "DONOTHING"

                If c_blnProcessMSP = True Then
                    strResult = "YES"
                End If

                Return strResult
            Case ".dll"
                strResult = "DONOTHING"

                If c_blnProcessDLL = True Then
                    strResult = "YES"
                End If

                Return strResult
            Case ".ini"
                strResult = "DONOTHING"

                If c_blnProcessINI = True Then
                    strResult = "YES"
                End If

                Return strResult
            Case ".cfg"
                strResult = "DONOTHING"

                If c_blnProcessCFG = True Then
                    strResult = "YES"
                End If

                Return strResult
            Case ".tmp"
                strResult = "DONOTHING"

                If c_blnProcessTMP = True Then
                    strResult = "YES"
                End If

                Return strResult

            Case ".adr", ".c", ".cab", ".cat", ".chk", ".chm", ".cfg", ".cmd", ".com", ".dbx", ".dit", ".dll", ".dns", ".dxt", ".edb", ".evt", ".exe", ".gpd", ".h", ".hlp", ".ini", ".inf", ".ldf", ".lnk", ".man", ".mbx", ".mdf", ".mfl", ".mof", ".msc", ".mui", ".mum", ".ntds", ".ndf", ".pif", ".pdb", ".pnf", ".policy", ".ppd", ".pst", ".scr", ".sys", ".tlb", ".vxd", ".vmm", ".vm"
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
            Case ".cs", ".js", ".vbs", ".wsh", ".cmd"
                strResult = "PROTECTED_SCRIPTFILE_EXTENSION"
                Return strResult
            Case ".adp", ".doc", ".mdb", ".ldb", ".xls", ".ppt", ".vsd", ".vss", ".docx", ".pptx", ".xlsx", ".accdb"
                strResult = "PROTECTED_MSOFFICEFILE_EXTENSION"
                Return strResult
            Case Else
                If c_ProcessUnknownExtensions = True Then
                    strResult = "YES"
                    Return strResult
                Else
                    strResult = "DONOTHING"
                    Return strResult
                End If
        End Select

    End Function

    Private Shared Function CheckDirName(ByVal dirName As System.IO.FileInfo) As Boolean
        Dim root As String = dirName.Directory.Root.ToString.ToLower()
        Dim fullFileName As String = dirName.FullName.ToLower
        Dim result As Boolean

        Dim Dir1 As String = m_strWinDir & "\propatches"
        Dim Dir2 As String = m_strWinDir & "\temp"
        Dim Dir3 As String = m_strWinDir & "\system32\logfiles"

        Dim resultDir1 As String = Nothing
        Dim resultDir2 As String = Nothing
        Dim resultDir3 As String = Nothing
        Dim arrSplit As String() = Nothing

        arrSplit = fullFileName.Split(CType("\", Char))

        'Checks Dir1 and Dir2
        resultDir1 = root & arrSplit(1) & "\" & arrSplit(2) '

        'Checks Dir3
        'If the 
        If arrSplit.Length > 3 Then
            resultDir2 = root & arrSplit(1) & "\" & arrSplit(2) & "\" & arrSplit(3)
        End If

        If m_strWinDir = root & arrSplit(1) Then
            If Dir1 = resultDir1 Then
                result = False
            ElseIf Dir2 = resultDir1 Then
                result = False
            ElseIf Dir3 = resultDir2 Then
                result = False
            ElseIf m_strWinDir = root & arrSplit(1) Then
                result = True
            ElseIf m_strWinDir & "\" = root & arrSplit(1) & "\" Then
                result = True
            Else
                result = True
            End If
        End If

        Return result
    End Function

#End Region

#Region " QuickZip routines"

    Private Shared Function CompressFile(ByVal fi As FileInfo, ByVal ZipFilePath As String) As Boolean

        Try
            '.NET 2.3 License Key
            Xceed.Zip.Licenser.LicenseKey = "ZIN23-XUH3U-YARMD-W42A"

            'Get Zip FileName 
            c_strZipFileName = GetZipFileName(fi, c_intLogsDWM)

            'Get Target Directory Name
            c_strDirectoryName = GetTargetDirectoryName(fi, ZipFilePath)

            If c_PreserveDirPath = True And c_strZipFilePath <> "local" Then
                c_strDirectoryName = AddMachineNameAndLogFilePath(fi, c_strDirectoryName)
            End If

            'Begin Code using QuickZip Class
            QuickZip.Zip(c_strDirectoryName & c_strZipFileName & ".zip", False, False, False, fi.FullName)
            c_blnZipResult = True
            Return c_blnZipResult
        Catch ex As Exception
            c_blnZipResult = False
            Return c_blnZipResult
        End Try
    End Function

    Private Shared Function GetTargetDirectoryName(ByVal fileName As FileInfo, ByVal targetDirName As String) As String
        Select Case targetDirName
            Case Is <> "local"
                Return CheckEndSlash(targetDirName)
            Case "local"
                targetDirName = fileName.DirectoryName
                Return CheckEndSlash(fileName.DirectoryName())
            Case Else
                targetDirName = fileName.DirectoryName
                Return CheckEndSlash(fileName.DirectoryName())
        End Select
    End Function

    Private Shared Function AddMachineNameAndLogFilePath(ByVal fi As FileInfo, ByVal targetDirName As String) As String
        Dim retvalue As String = ""
        If c_strIncludeComputerName Then
            retvalue = CheckEndSlash(targetDirName & m_ComputerName & Mid(fi.DirectoryName, InStr(fi.DirectoryName, "\")).ToLower)
        Else
            retvalue = CheckEndSlash(targetDirName & Mid(fi.DirectoryName, InStr(fi.DirectoryName, "\")).ToLower)
        End If
        Return retvalue
    End Function

    Private Shared Function GetZipFileName(ByVal objFileName As FileInfo, ByVal MDPreference As Integer) As String
        Dim TodaysDateUTC As DateTime = System.DateTime.UtcNow
        Dim FileMonth As String
        Dim FileYear As String
        Dim FileWeekOfYear As Long
        Dim FirstDayOfYear As DateTime

        Select Case MDPreference

            Case 1 'Daily

                If c_strNamingConvention = "Default" Then

                    Return objFileName.Name

                Else

                    Dim intX As Integer
                    Dim arrSplit() As String
                    Dim sb As New Text.StringBuilder
                    arrSplit = c_strNamingConvention.Split(CChar(c_strDelimiter))

                    For intX = 0 To UBound(arrSplit) - 1
                        Select Case LTrim(RTrim(CType(arrSplit(intX), String)))
                            Case "%YY%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("yy"), String))
                            Case "%YYYY%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("yyyy"), String))
                            Case "%M%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("M"), String))
                            Case "%MM%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("MM"), String))
                            Case "%MMMM%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("MMMM"), String))
                            Case "%D%"
                                sb.Append(Day(CType(objFileName.LastWriteTimeUtc.ToString("d"), Date)))
                            Case "%DD%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("dd"), String))
                            Case "%DDDD%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("dddd d"), String))
							Case Else
								If arrSplit(intX).Length > 0 Then
									sb.Append(CType(arrSplit(intX).ToString(), String))
								End If
                        End Select
                    Next

                    Return sb.ToString()

                End If

            Case 2 'Weekly
                FirstDayOfYear = CType("01/01/" & objFileName.LastWriteTimeUtc.Year.ToString(), DateTime)
                FileWeekOfYear = DateDiff(DateInterval.WeekOfYear, FirstDayOfYear, objFileName.LastWriteTimeUtc, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)

                If c_strNamingConvention = "Default" Then

                    FileMonth = Format(objFileName.LastWriteTimeUtc.ToString("MMMM"))
                    FileYear = Format(objFileName.LastWriteTimeUtc.ToString("yy"))
                    Return FileWeekOfYear & FileMonth & FileYear

                Else

                    Dim intX As Integer
                    Dim arrSplit() As String
                    Dim sb As New Text.StringBuilder
                    arrSplit = c_strNamingConvention.Split(CChar(c_strDelimiter))

                    'Append week of Year on the beginning of filename
                    sb.Append(FileWeekOfYear.ToString())
                    For intX = 0 To UBound(arrSplit) - 1
                        Select Case LTrim(RTrim(CType(arrSplit(intX), String)))
                            Case "%YY%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("yy"), String))
                            Case "%YYYY%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("yyyy"), String))
                            Case "%M%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("M"), String))
                            Case "%MM%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("MM"), String))
                            Case "%MMMM%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("MMMM"), String))
							Case Else
								If arrSplit(intX).Length > 0 Then
									sb.Append(CType(arrSplit(intX).ToString(), String))
								End If
                        End Select
                    Next

                    Return sb.ToString()

                End If

            Case 3 'Monthly
                If c_strNamingConvention = "Default" Then

                    FileMonth = Format(objFileName.LastWriteTimeUtc.ToString("MMMM"))
                    FileYear = Format(objFileName.LastWriteTimeUtc.ToString("yy"))
                    Return FileMonth.Trim & FileYear.Trim

                Else

                    Dim intX As Integer
                    Dim arrSplit() As String
                    Dim sb As New Text.StringBuilder
                    arrSplit = c_strNamingConvention.Split(CChar(c_strDelimiter))
                    For intX = 0 To UBound(arrSplit) - 1
                        Select Case LTrim(RTrim(CType(arrSplit(intX), String)))
                            Case "%YY%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("yy"), String))
                            Case "%YYYY%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("yyyy"), String))
                            Case "%M%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("M"), String))
                            Case "%MM%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("MM"), String))
                            Case "%MMMM%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("MMMM"), String))
							Case Else
								If arrSplit(intX).Length > 0 Then
									sb.Append(CType(arrSplit(intX).ToString(), String))
								End If
                        End Select
                    Next

                    Return sb.ToString()

                End If

            Case Else

                If c_strNamingConvention = "Default" Then

                    Return objFileName.Name

                Else

                    Dim intX As Integer
                    Dim arrSplit() As String
                    Dim sb As New Text.StringBuilder
                    arrSplit = c_strNamingConvention.Split(CChar(c_strDelimiter))

                    For intX = 0 To UBound(arrSplit) - 1
                        Select Case LTrim(RTrim(CType(arrSplit(intX), String)))
                            Case "%YY%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("yy"), String))
                            Case "%YYYY%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("yyyy"), String))
                            Case "%M%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("M"), String))
                            Case "%MM%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("MM"), String))
                            Case "%MMMM%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("MMMM"), String))
                            Case "%D%"
                                sb.Append(Day(CType(objFileName.LastWriteTimeUtc.ToString("d"), Date)))
                            Case "%DD%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("dd"), String))
                            Case "%DDDD%"
                                sb.Append(CType(objFileName.LastWriteTimeUtc.ToString("dddd d"), String))
							Case Else
								If arrSplit(intX).Length > 0 Then
									sb.Append(CType(arrSplit(intX).ToString(), String))
								End If
                        End Select
                    Next

                    Return sb.ToString()

                End If

        End Select

    End Function

    Public Property ZipResult() As Boolean
        Get
            ' The Get property procedure is called when the value
            'of a property is retrieved. 
            Return c_blnZipResult
        End Get
        Set(ByVal Value As Boolean)
            'The Set property procedure is called when the value 
            'of a property is modified. 
            'The value to be assigned is passed in the argument to Set. 
            c_blnZipResult = Value
        End Set
    End Property

    Public Property ZipFileName() As String
        Get
            ' The Get property procedure is called when the value
            'of a property is retrieved. 
            Return c_strZipFileName
        End Get
        Set(ByVal Value As String)
            'The Set property procedure is called when the value 
            'of a property is modified. 
            'The value to be assigned is passed in the argument to Set. 
            c_strZipFileName = Value
        End Set
    End Property

    Private Shared Function CheckEndSlash(ByVal directoryName As String) As String
        If Right(directoryName, 1) = "\" Then
            Return directoryName
        Else
            Return directoryName & "\"
        End If
    End Function

#End Region

End Class