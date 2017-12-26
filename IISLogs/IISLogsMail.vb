Imports OpenSmtp.Mail
Imports System.IO
Imports System.Text

Public Class IISLogsMail
    Inherits IISLogsd.IISLogsStartModule

    Public Shared Sub MailReport()
        Dim sb As New StringBuilder
        Dim fileName As String

        Dim dt As New DataTable
        Dim dr As DataRow

        Dim numOfDirectories As Integer
        Dim TotalNumberFiles As Integer = 0
        Dim TotalNumberFilesChanged As Integer = 0
        Dim sizeofdirBefore As Double = 0
        Dim sizeofdirAfter As Double = 0
        Dim TimeStarted As String
        Dim TimeFinished As String

        Try
            fileName = m_LogDirectoryPath & m_summaryLogFileName & ".txt"
            dt = CSV2DataTable(fileName, m_delimiter)
            sb.Append("Here is a daily IISLogs report for computer: " & m_ComputerName & vbNewLine & vbNewLine)

            numOfDirectories = dt.Rows.Count()

            TimeStarted = CType(dt.Rows(0).Item("TimeStarted"), String)
            TimeFinished = CType(dt.Rows(numOfDirectories - 1).Item("TimeFinished"), String)

            For Each dr In dt.Rows
                TotalNumberFiles = TotalNumberFiles + CType(dr.Item("TotalNumberFiles"), Integer)
                TotalNumberFilesChanged = TotalNumberFilesChanged + CType(dr.Item("totalNumberFilesChanged"), Integer)
                sizeofdirBefore = sizeofdirBefore + CType(dr.Item("SizeBeforeProcessing"), Double)
                sizeofdirAfter = sizeofdirAfter + CType(dr.Item("SizeAfterProcesing"), Double)
            Next

            sb.Append("Number of Directories Processed: " & Format(numOfDirectories, "N0") & vbNewLine)
            sb.Append("Total Number Files: " & TotalNumberFiles & vbNewLine)
            sb.Append("Total Number Files Changed: " & Format(TotalNumberFilesChanged, "N0") & vbNewLine)
            sb.Append("Size Before Processing: " & Format(Math.Round(sizeofdirBefore / 1024, 0), "N0") & " KB" & vbNewLine)
            sb.Append("Size After Procesing: " & Format(Math.Round(sizeofdirAfter / 1024, 0), "N0") & " KB" & vbNewLine)
            sb.Append("Start Time: " & TimeStarted & vbNewLine)
            sb.Append("Finish Time: " & TimeFinished)

            SendMail(sb.ToString())
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsMail.MailReport")
        End Try
    End Sub

    Private Shared Function CSV2DataTable(ByVal filename As String, ByVal sepChar As String) As DataTable
        Dim reader As StreamReader
        Dim table As New DataTable
        Dim colAdded As Boolean = False
        Dim line As String

        Try
            ' open a reader for the input file, and read line by line
            reader = New StreamReader(filename)
            Do While reader.Peek() >= 0
                ' read a line and split it into tokens, divided by the specified 
                ' separators
                line = reader.ReadLine()
                If Left(line, 1) <> "#" Then
                    Dim tokens As String() = RegularExpressions.Regex.Split _
                        (line, sepChar)
                    ' add the columns if this is the first line
                    If Not colAdded Then
                        For Each token As String In tokens
                            table.Columns.Add(token)
                        Next
                        colAdded = True
                    Else
                        If CType(tokens(0), Double) = m_LogPrimaryKey Then
                            'Changed on 9/12/2004 by Steve Schofield
                            'Added primary key to allow for multiple runs of the log files on one day
                            'and will ONLY report on this run.
                            'If tokens(1) = System.DateTime.Now.ToShortDateString() Then
                            Dim row As DataRow = table.NewRow() ' create a new empty row
                            ' fill the new row with the token extracted from the current 
                            ' line
                            For i As Integer = 0 To table.Columns.Count - 1
                                row(i) = tokens(i)
                            Next
                            ' add the row to the DataTable
                            table.Rows.Add(row)
                        End If
                    End If
                End If
            Loop

            Return table
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
    End Function

    Private Shared Sub SendMail(ByVal strBody As String)
        Dim strFrom As EmailAddress
        Dim strTo As EmailAddress
        Dim strMsg As MailMessage
        Dim objSMTP As Smtp

        Try
            strFrom = New EmailAddress(m_sFrom, "IISLogs")
            strTo = New EmailAddress(m_sTo)

            strMsg = New MailMessage(strFrom, strTo)
            strMsg.Subject = m_strSubject & " : " & m_ComputerName & " : " & System.DateTime.Now.ToShortDateString
            strMsg.Body = strBody

            Select Case LTrim(RTrim(m_strMailServer))
                Case "localhost"
                    If m_EnableMailAuth = True Then
                        objSMTP = New Smtp(m_strMailServer, DecodePWD(m_strUID), DecodePWD(m_strPWD), m_strMailPort)
                    Else
                        objSMTP = New Smtp(m_strMailServer, m_strMailPort)
                    End If
                Case Else
                    If m_EnableMailAuth = True Then
                        objSMTP = New Smtp(m_strMailServer, DecodePWD(m_strUID), DecodePWD(m_strPWD), m_strMailPort)
                    Else
                        objSMTP = New Smtp(m_strMailServer, m_strMailPort)
                    End If
            End Select
            objSMTP.SendMail(strMsg)
        Catch exp As Exception
            ErrorHandler(exp, "IISLogsMail.SendMail")
        End Try
    End Sub

    Private Shared Function DecodePWD(ByVal strPWD As String) As String
        Dim objUTF8 As System.Text.UTF8Encoding
        Dim retValue As String
        Try
            objUTF8 = New System.Text.UTF8Encoding
            retValue = objUTF8.GetString(Convert.FromBase64String(strPWD))
            Return retValue
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Return Nothing
    End Function
End Class
