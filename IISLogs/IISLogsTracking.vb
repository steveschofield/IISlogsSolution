Imports System.IO
Imports System.Text

Public Class IISLogsTracking
    Inherits IISLogsd.IISLogsStartModule

    Private Shared ep As String = m_delimiter

    Public Shared Sub detailData(ByVal strInfo As String)
        Try
            IISLogsTracking.Log(strInfo, logType.detailLog)
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsTracking.LogDetailData")
        End Try
    End Sub

    Public Shared Sub errorData(ByVal strFunctionName As String, ByVal strMessage As String, ByVal strSource As String, ByVal strStackTrace As String)
        Dim sb As New StringBuilder

        Try
            sb.Append(m_LogPrimaryKey & ep)
            sb.Append(System.DateTime.Now.ToShortDateString() & ep)
            sb.Append(strFunctionName & ep)
            sb.Append(strMessage & ep)
            sb.Append(strSource & ep)
            sb.Append(strStackTrace & ep)
            sb.Append(m_ComputerName)
            IISLogsTracking.Log(sb.ToString(), logType.errorLog)
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsTracking.ErrorData")
        End Try
    End Sub

    Public Shared Sub deleteData(ByVal strDirName As String, ByVal intX As Integer, ByVal dtStartime As DateTime, ByVal dtFinishTime As DateTime)
        Dim sb As New StringBuilder

        Try
            sb.Append(m_LogPrimaryKey & ep)
            sb.Append(System.DateTime.Now.ToShortDateString() & ep)
            sb.Append(strDirName & ep)
            sb.Append(intX & ep)
            sb.Append(dtStartime & ep)
            sb.Append(dtFinishTime & ep)
            sb.Append(m_ComputerName)
            IISLogsTracking.Log(sb.ToString(), logType.deleteLog)
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsTracking.smtpData")
        End Try
    End Sub

    Public Shared Sub summaryData(ByVal strDirName As String, ByVal intTotalNumberFiles As Integer, ByVal intTotalNumberFilesChanged As Integer, ByVal lngBeforeTotalBytes As Long, ByVal lngAfterTotalBytes As Long, ByVal dtStartTime As DateTime, ByVal dtFinishTime As DateTime)
        Dim sb As New StringBuilder

        Try
            sb.Append(m_LogPrimaryKey & ep)
            sb.Append(System.DateTime.Now.ToShortDateString() & ep)
            sb.Append(strDirName & ep)
            sb.Append(intTotalNumberFiles & ep)
            sb.Append(intTotalNumberFilesChanged & ep)
            sb.Append(lngBeforeTotalBytes & ep)
            sb.Append(lngAfterTotalBytes & ep)
            sb.Append(dtStartTime & ep)
            sb.Append(dtFinishTime & ep)
            sb.Append(m_ComputerName)
            IISLogsTracking.Log(sb.ToString(), logType.summaryLog)
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsTracking.summaryData")
        End Try
    End Sub

    Public Shared Function detailLoggingInfo(ByVal v_arrFile As FileInfo, ByVal strDirName As String, ByVal dtStartFile As DateTime, ByVal dtFinishFile As DateTime, ByVal strFileStatus As String, ByVal intCounter As Integer) As String
        Dim sb As New System.Text.StringBuilder
        Dim nl As String = vbNewLine

        Try
            sb.Append(m_LogPrimaryKey & ep)
            sb.Append(System.DateTime.Now.ToShortDateString() & ep)
            sb.Append(strDirName & ep)
            sb.Append(v_arrFile.Name & ep)
            sb.Append(v_arrFile.CreationTime & ep)
            sb.Append(v_arrFile.DirectoryName & ep)
            sb.Append(v_arrFile.Extension & ep)
            sb.Append(v_arrFile.FullName & ep)
            sb.Append(v_arrFile.LastWriteTime & ep)
            sb.Append(v_arrFile.Length & ep)
            sb.Append(dtStartFile & ep)
            sb.Append(dtFinishFile & ep)
            sb.Append(strFileStatus & ep)
            sb.Append(m_ComputerName)

            If intCounter <> 0 Then
                sb.Append(nl)
            End If

            Return sb.ToString()
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsUtils.detailLoggingInfo")
        End Try
    End Function

    Public Shared Function detailDeleteLoggingInfo(ByVal v_arrFile As FileInfo, ByVal strDirName As String, ByVal dtStartFile As DateTime, ByVal dtFinishFile As DateTime, ByVal strFileStatus As String, ByVal intCounter As Integer) As String
        Dim sb As New System.Text.StringBuilder

        Try
            sb.Append(m_LogPrimaryKey & ep)
            sb.Append(System.DateTime.Now.ToShortDateString() & ep)
            sb.Append(strDirName & ep)
            sb.Append(v_arrFile.Name & ep)
            sb.Append(v_arrFile.CreationTime & ep)
            sb.Append(v_arrFile.DirectoryName & ep)
            sb.Append(v_arrFile.Extension & ep)
            sb.Append(v_arrFile.FullName & ep)
            sb.Append(v_arrFile.LastWriteTime & ep)
            sb.Append(v_arrFile.Length & ep)
            sb.Append(dtStartFile & ep)
            sb.Append(dtFinishFile & ep)
            sb.Append(strFileStatus & ep)
            sb.Append(m_ComputerName)
            IISLogsTracking.Log(sb.ToString(), logType.detailLog)
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsUtils.detailLoggingInfo")
        End Try
    End Function

    Public Shared Sub SetLogPrimaryKey()
        Dim fs As FileStream
        Dim sw As StreamWriter
        Dim fn As String
        Dim sr As StreamReader
        Dim line As String
        Dim value As Double

        Try
            fn = m_LogDirectoryPath & "pk/logpk.txt"

            If File.Exists(fn) = False Then
                fs = System.IO.File.Create(fn)
                fs.Close()
                System.Threading.Thread.Sleep(100)
                value = 1
            Else
                sr = New StreamReader(fn)
                line = RTrim(LTrim(sr.ReadLine()))
                If line = "" Then
                    line = "1"
                End If
                value = CDbl(line) + 1
                sr.Close()
                File.Delete(fn)
                fs = System.IO.File.Create(fn)
                fs.Close()
                System.Threading.Thread.Sleep(100)
            End If

            sw = File.AppendText(fn)
            sw.WriteLine(value)
            sw.Flush()
            sw.Close()
            m_LogPrimaryKey = value
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsTracking.LogPrimaryKey")
        End Try
    End Sub

    Public Shared Sub DetermineLoggingFilesAge(ByVal lngfileLoggingAge As Long)
        Dim x As Integer
        Dim v_arrFiles As FileInfo()
        Dim fi As FileInfo
        'Dim lngFileAge As Long
        Dim path As String

        Try
            'clean up old archive logs.
            CleanUpArchiveLogs(m_purgeArchiveLogsAge)

            'Return a list of log files
            v_arrFiles = IISLogsUtils.GetListOfFiles(m_LogDirectoryPath)

            For x = 0 To UBound(v_arrFiles)
                Try
                    fi = New FileInfo(v_arrFiles(x).FullName)
                    'lngFileAge = DateDiff(DateInterval.Day, fi.CreationTime, System.DateTime.Now())

                    If IISLogsUtils.GetFileAgeByDay(fi.CreationTime) >= lngfileLoggingAge Then
                        path = m_LogDirectoryPath & "ArchiveLogs\" & v_arrFiles(x).Name & "." & System.String.Format("{0:MMddyyyy}", System.DateTime.Now)

                        ' Ensure that the target does not exist.
                        File.Delete(path)

                        ' Copy the file.
                        File.Move(v_arrFiles(x).FullName, path)
                    End If
                Catch exp As Exception
                    ErrorHandler(exp, "IISLogsTracking.DetermineLoggingFilesAge")
                End Try
            Next

        Catch exp As Exception
            ErrorHandler(exp, "IISLogsTracking.DetermineLoggingFilesAge")
        End Try
    End Sub

    '***************************************************************************
    'Purpose: General purpose logging of activities to a text file
    'Inputs: Message of what type of logging and logging type (Normal or Error)
    'Returns: N/A
    '****************************************************************************

    Private Shared Sub CleanUpArchiveLogs(ByVal lngAge As Long)
        Dim x As Integer
        Dim v_arrFiles As FileInfo()
        Dim lngFileAge As Long

        Try
            v_arrFiles = IISLogsUtils.GetListOfFiles(m_LogDirectoryPath & "ArchiveLogs")
            For x = 0 To UBound(v_arrFiles)
                Try
                    lngFileAge = IISLogsUtils.GetFileAgeByDay(v_arrFiles(x).LastWriteTime)
                    If lngFileAge > lngAge Then
                        File.Delete(v_arrFiles(x).FullName)
                    End If
                Catch exp As Exception
                    ErrorHandler(exp, "IISLogsTracking.CleanUpArchiveLogs")
                End Try
            Next
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsTracking.CleanUpArchiveLogs")
        End Try
    End Sub

    '***************************************************************************
    'Purpose: General purpose logging of activities to a text file
    'Inputs: Message of what type of logging and logging type (Normal or Error)
    'Returns: N/A
    '****************************************************************************

    Private Shared Sub Log(ByVal strTrackingMessage As String, ByVal strLogType As logType)
        Dim sw As StreamWriter
        Dim strFileInfo As String

        Try
            'Sub Routine to log information passed in
            strFileInfo = GetDirLogInfo(CType(strLogType, Integer))

            sw = File.AppendText(strFileInfo)
            sw.WriteLine(strTrackingMessage)
            sw.Flush()
            sw.Close()
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsTracking.Log")
        End Try
    End Sub

    '***************************************************************************
    'Purpose: Reads configuration file to insure directories, logging text files
    '   exist
    'Inputs: LogType
    'Returns: Path to Directory and Log file to the Log function to write 
    '   Logging information   
    '***************************************************************************

    Private Shared Function GetDirLogInfo(ByVal lngLogType As Integer) As String
        Dim strDirPath As String
        Dim strfileName As String
        Dim strDate As String
        Dim fs As FileStream
        Dim sw As StreamWriter
        Dim strLogFullName As String

        Try
            'Statement determines if this is an errorType logging function
            'Or normal logging, all logging except errors go to a single log
            strDirPath = m_LogDirectoryPath
            strDate = Month(Now()) & Day(Now()) & Year(Now())

            Select Case lngLogType
                Case 1
                    strfileName = m_deleteLogFileName & ".txt"
                Case 2
                    strfileName = m_detailLogFileName & ".txt"
                Case 3
                    strfileName = m_errorLogFileName & ".txt"
                Case 4
                    strfileName = m_summaryLogFileName & ".txt"
                Case Else
                    strfileName = m_detailLogFileName & ".txt"
            End Select

            'Insures the directory where logging is taking place exists
            'This has to be a directory off the root of C:\
            If Directory.Exists(strDirPath) = False Then
                Directory.CreateDirectory(strDirPath)
            End If

            'Sets the Directory Path and Log filename into one variable
            strLogFullName = strDirPath & strfileName

            'Insures the logging file where information is being held exists
            'This code will create a blank file
            If Not File.Exists(strLogFullName) Then
                fs = System.IO.File.Create(strLogFullName)
                fs.Close()

                'sleep for 10 milliseconds to allow OperatingSystem to release threads on file
                Threading.Thread.Sleep(100)

                'Append header to file
                sw = File.AppendText(strLogFullName)
                sw.WriteLine(BuildLogHeader(lngLogType))
                sw.Flush()
                sw.Close()
            End If

            Return strLogFullName
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsTracking.GetDirLogInfo")
        End Try
    End Function

    Private Shared Function BuildLogHeader(ByVal v_intLogType As Integer) As String
        Dim sb As New StringBuilder
        Dim strHL4 As String = ""

        Try
            Select Case v_intLogType
                Case 1
                    strHL4 = m_deleteLogFileNameFields
                Case 2
                    strHL4 = m_detailLogFileNameFields
                Case 3
                    strHL4 = m_errorLogFileNameFields
                Case 4
                    strHL4 = m_summaryLogFileNameFields
            End Select

            sb.Append(m_strHL1 & vbNewLine)
            sb.Append(m_strHL2 & vbNewLine)
            sb.Append(m_strHL3 & System.DateTime.Now() & vbNewLine)
            sb.Append(strHL4)

            Return sb.ToString()
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsTracking.buildLogHeader")
        End Try
    End Function

    Private Enum logType
        deleteLog = 1
        detailLog = 2
        errorLog = 3
        summaryLog = 4
    End Enum
End Class