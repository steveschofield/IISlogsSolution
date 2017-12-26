Imports System.IO
Imports System.Text

Public Class IISLogsDeleteDir
    Inherits IISLogsd.IISLogsStartModule

    Public Shared Sub DeleteDirMain(ByVal strDirName As String)
        Dim split As String() = Nothing
        Dim strName As String

        Try
            split = strDirName.Split(CType(m_delimiter, Char))
            For Each strName In split
                Try
                    'Verify Directory exists before processing it
                    'Even though directory is configured to be monitored 
                    If Directory.Exists(strName) = True Then
                        If m_ConsoleWriteLineToScreen = True Then
                            Console.WriteLine("Starting: " & strName)
                        End If

                        ProcessDirectory(strName, IISLogsUtils.GetListOfFiles(strName))
                    End If
                Catch exp As Exception
                    ErrorHandler(exp, "IISLogsDeleteDir.Main ForLoop")
                End Try
            Next
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsDeleteDir.Main")
        End Try
    End Sub

    Private Shared Function ProcessDirectory(ByVal strDirName As String, ByVal v_arrFiles As FileInfo()) As String
        Dim strFileStatus As String
        Dim intX As Integer = 0

        'All of these DIM'd variables for tracking ONLY
        '*********************************************
        Dim Space5 As String = Space(5)
        Dim Space10 As String = Space(10)
        Dim Space20 As String = Space(20)

        Dim sb As New StringBuilder
        Dim dtStartTime As DateTime
        Dim dtFinishTime As DateTime
        Dim dtStartFile As DateTime
        Dim dtFinishFile As DateTime
        Dim x As Integer = 0
        Dim intCounter As Integer = 0
        Dim strStatus As String
        '*********************************************

        Try
            'Record Start Time
            dtStartTime = System.DateTime.Now()

            For x = 0 To UBound(v_arrFiles)
                'This Try statement assures all files in v_arrFiles array get processed
                Try
                    'This is the core logic used in this function
                    strFileStatus = DetermineFileStatus(v_arrFiles(x))

                    'Build a string of all the file information if configured to
                    If m_DetailFileLogging = True Then
                        intCounter = intCounter - 1
                        sb.Append(IISLogsTracking.detailLoggingInfo(v_arrFiles(x), strDirName, dtStartFile, dtFinishFile, strFileStatus, intCounter))
                    End If

                    'Process the second half of the logic
                    'Deletes file its 
                    If strFileStatus = "DELETEFILE" Then
                        'Does a check to verify correct extension
                        strStatus = IISLogsUtils.VerifyFileExtension(v_arrFiles(x))
                        If strStatus = "YES" Then
                            File.Delete(v_arrFiles(x).FullName)
                            intX = intX + 1
                        End If
                    End If

                Catch exp As Exception
                    ErrorHandler(exp, "IISLogsDeleteDir.ProcessDirectory")
                End Try
            Next

            'Record Finish Time
            dtFinishTime = System.DateTime.Now()

            'Log detail data for all files in this directory
            IISLogsTracking.deleteData(strDirName, intX, dtStartTime, dtFinishTime)

            'Log Detail Data, if configured
            If m_DetailFileLogging = True And sb.Length > 0 Then
                IISLogsTracking.detailData(sb.ToString())
            End If

        Catch exp As Exception
            ErrorHandler(exp, "IISLogsDeleteDir.ProcessDirectory")
        End Try
    End Function

    Private Shared Function DetermineFileStatus(ByVal fi As FileInfo) As String
        Dim lngFileAge As Long
        Dim strResult As String = ""

        Try
            Select Case m_DelOnlySpecificAttribute
                Case "LastWriteTime"
                    lngFileAge = DateDiff(DateInterval.Hour, fi.LastWriteTime, System.DateTime.Now)

                    If lngFileAge > m_lngdelOnlyRetentionPeriod And m_DeletePolicyAgreement = True Then
                        strResult = "DELETEFILE"
                    Else
                        strResult = "DONOTHING"
                    End If
                Case "FileName"
                    If ConvertFileNameToDate(fi.Name) = True Then
                        strResult = "DELETEFILE"
                    Else
                        strResult = "DONOTHING"
                    End If
            End Select

            Return strResult
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsDeleteDir.DetermineFileStatus")
        End Try
    End Function

    Private Shared Function ConvertFileNameToDate(ByVal strFileName As String) As Boolean
        Dim lngFileAge As Long
        Dim strFileDate As String

        Try
            strFileDate = Mid(strFileName, 5, 2) & "/" & Mid(strFileName, 7, 2) & "/" & Mid(strFileName, 3, 2)
            lngFileAge = DateDiff(DateInterval.Hour, CType(strFileDate, Date), System.DateTime.Now)

            If lngFileAge > m_lngdelOnlyRetentionPeriod And m_DeletePolicyAgreement = True Then
                Return True
            Else
                Return False
            End If
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsDeleteDir.ConvertFileNameToDate")
        End Try
    End Function
End Class