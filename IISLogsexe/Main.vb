Imports IISLogsd

Module IISLogsModule
    Sub Main()
        Dim blnResult As Boolean
        Dim objStart As New IISLogsStartModule
        Try
            blnResult = objStart.MainStart()
        Catch ex As Exception
            IISLogsUtils.WriteToEventLog(ex.Message.ToString() & "- Please contact http://www.iislogs.com support for further assistance")
        End Try
    End Sub
End Module