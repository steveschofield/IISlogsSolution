Imports System.IO
Imports System.Text

Public Class IISLogsFiles
    Inherits IISLogsd.IISLogsStartModule

    Public Shared Sub FilesMain(ByVal arrDirList As ArrayList)
        Dim strName As String
        Try
            For Each strName In arrDirList
                'This try statement is to insure all values in the arrDirList arrayList is tried
                Try
                    'Verify Directory exists before processing it
                    'Even though directory is configured to be monitored 
                    'If Directory.Exists(strName) = True Then
                    If m_ConsoleWriteLineToScreen = True Then
                        Console.WriteLine("Starting: " & strName)
                    End If
                    ProcessDirectory(strName)
                    'End If
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

        Dim sb As New StringBuilder
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
                    strFileStatus = IISLogsFilesActions.FilesActionsMain(v_arrFiles(x))

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

End Class