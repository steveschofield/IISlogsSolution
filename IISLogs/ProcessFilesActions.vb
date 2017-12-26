Imports System.IO
Imports System.Text

Public Class IISLogsFilesActions
    Inherits IISLogsd.IISLogsStartModule

    Public Shared Function FilesActionsMain(ByVal fi As FileInfo) As String
        Dim strResult As String
        Dim strStatus As String

        Try
            strStatus = IISLogsUtils.VerifyFileExtension(fi)

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
            strZipFile = m_blnZipFile
            strDeleteFile = m_blnDeleteFile
            lngZipRetentionPeriod = m_lngZipRetentionPeriod
            lngDeleteRetentionPeriod = m_lngDeleteRetentionPeriod

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
        'Dim strPath1 As String
        'Dim fn As String
        Dim objIISLogsZip As CompressFile

        Try
            Select Case UCase(strResult)
                Case "ZIPFILE"

                    '#########################################
                    '#OLD METHOD OF COMPRESSING
                    '#########################################
                    ''Call IISLogsQuickZip class, this uses the Xceed.Zip component ZIP file locally
                    'objIISLogsZip = New IISLogsQuickZip.CompressFile(fi)

                    ''The looks at the result returned when file is zipped
                    ''If True will be processed either locally or moved remotely
                    'If objIISLogsZip.ZipResult = True Then
                    'If LCase(m_strZipFilePath) <> "local" Then

                    ''This pieces together the directory path where the file is being moved too.
                    'strPath1 = m_strZipFilePath & m_ComputerName & "\" & Mid(fi.DirectoryName, InStr(fi.DirectoryName, "\")).ToLower

                    ''Creates Destination Directory, if doesn't exist
                    ''The Try/Catch block is here to insure it the Path exists and can be moved their
                    ''If it doesn't the ZIP file is left in local directory
                    'Try
                    'If Directory.Exists(strPath1) = False Then
                    'Directory.CreateDirectory(strPath1)
                    'End If
                    ''Return file name property
                    'fn = objIISLogsZip.ZipFileName

                    ''Move file to remote location
                    'File.Move(fi.DirectoryName & "\" & fn, strPath1 & "\" & fn)
                    'Catch exp As Exception
                    'ErrorHandler(exp, "doFileMoveZipFile")
                    'End Try
                    'End If
                    '#########################################
                    '#OLD METHOD OF COMPRESSING
                    '#########################################

                    'Call IISLogsQuickZip class, this uses the Xceed.Zip component ZIP file locally
                    objIISLogsZip = New CompressFile(fi, m_strZipFilePath)

                    'This HAS set to true in-order to enforce original files aren't deleted
                    If m_blnDeleteOriginalFile = True And m_DeletePolicyAgreement = True Then
                        File.Delete(fi.FullName)
                    End If

                    'The looks at the result returned when file is zipped
                    'If True will be processed either locally or moved remotely
                    If objIISLogsZip.ZipResult = True Then
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
End Class