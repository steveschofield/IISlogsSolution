Public Class IISLogsMainPrograms
    Inherits IISLogsd.IISLogsStartModule

    Function MainPrograms() As Boolean
        '**************************************
        'Purpose: Start the program off
        'Inputs: Pulls values from configuration files on what directorys to monitor
        'Outputs: N/A
        '**************************************
        Dim arrDirList As ArrayList
        'IISLogs 2.0 feature
        'Dim objDelete As New IISLogsDeleteDir

        Try
            'Determine if Logs are ready to be turned over to new files
            If m_LogDirectoryPath = "" Then
                m_LogDirectoryPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) & "\logs\"
                IISLogsUtils.SaveConfigData(IISLogsUtils.GetConfigFileName(), "LogDirectoryPath", m_LogDirectoryPath)
            End If

            'Create Base folder structure below the 'Logs' folder
            IISLogsUtils.CreateBaseFolderStructure()

            'Sets the primary key for the detail logging.
            IISLogsTracking.SetLogPrimaryKey()

            'Determine Logging files and clean up archives
            If m_SummaryFileLogging = True Or m_DetailFileLogging = True Then
                Try
                    IISLogsTracking.DetermineLoggingFilesAge(m_fileLoggingAge)
                Catch ex As Exception
                    IISLogsUtils.WriteToEventLog("Error Handling archiving of detail log files. Error Message: " & ex.ToString())
                End Try
            End If

            'Determines if File Agreements have been signed
            If m_TurnOffFileCompressionPolicyAgreementSigned = True Then
                m_FileCompressionPolicyAgreement = True
            Else
                IISLogsUtils.VerifyFileCompressionPolicyAgreement()
            End If

            If m_TurnOffDeletePolicyAgreementSigned = True Then
                m_DeletePolicyAgreement = True
            Else
                IISLogsUtils.VerifyDeletePolicyAgreement()
            End If

            'Auto Save Option
            If m_AutoAddMonitoredSpecificDirectories = True Then
                IISLogsDynamicallyAddLogDirectoryValues.MainBegin()
            End If

            'Starts the entire process, Calls ProcessDirectoryVerifyConfig.vb 
            arrDirList = IISLogsVerifyConfig.VerifyConfigMain

            'Loop through all directories being monitored if arrDirList quantity is greater than zero
            If arrDirList.Count > 0 Then
                IISLogsFiles.FilesMain(arrDirList)
            End If

            'IISLogs 2.0 feature
            'Process Delete directories ONLY feature
            If m_processdelOnlySpecificDirectories = True Then
                IISLogsDeleteDir.DeleteDirMain(m_delOnlySpecificDirectories)
            End If

            'Process SMTP directories if configured to do so
            If m_processSmtpSVCDirectories = True Then
                IISLogsSMTPSvcDir.SMTPSvcDirMain(m_smtpSVCDirectories)
            End If

            'Process ZIP and/or Delete directories with a specific timeframe. 
            'This imports a separate XML file.  
            If m_ZipPerDirectoryEnable = True Then
                IISLogsPerDirectory.IISLogsPerDirectoryMain(m_ZipPerDirectoryXMLFile)
            End If

            'Send an email report of files changed
            If m_SendMailReport = True And m_SummaryFileLogging = True Then
                IISLogsMail.MailReport()
            End If

            arrDirList.Clear()
            Return True
        Catch exp As Exception
            ErrorHandler(exp, "Main()")
            Return False
        End Try
    End Function
End Class