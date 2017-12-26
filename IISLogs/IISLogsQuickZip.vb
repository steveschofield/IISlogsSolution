Imports Xceed.Zip
Imports Xceed.Zip.Sfx
Imports System.Text
Imports System.IO

Public Class CompressFile
    Inherits IISLogsd.IISLogsStartModule

    Private Shared m_ZipResult As Boolean
    Private Shared m_ZipFileName As String
    Private Shared m_DirectoryName As String

    Sub New(ByVal fi As FileInfo, ByVal ZipFilePath As String)

        Try
            '.NET 2.3 License Key
            Xceed.Zip.Licenser.LicenseKey = "ZIN23-XUH3U-YARMD-W42A"

            'Get FileName 
            m_ZipFileName = GetZipFileName(fi, m_LogsDWM)

            'Get Target Directory Name
            m_DirectoryName = GetTargetDirectoryName(fi, ZipFilePath)

            If m_PreserveDirPath = True And ZipFilePath <> "local" Then
                m_DirectoryName = AddMachineNameAndLogFilePath(fi, m_DirectoryName)
            End If

            'Begin Code using QuickZip Class
            QuickZip.Zip(m_DirectoryName & m_ZipFileName & ".zip", False, False, False, fi.FullName)
            m_ZipResult = True
        Catch ex As Exception
            m_ZipResult = False
            Throw New Exception("File could not be compressed", ex)
        End Try
    End Sub

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
        retvalue = CheckEndSlash(targetDirName & m_ComputerName & Mid(fi.DirectoryName, InStr(fi.DirectoryName, "\")).ToLower)
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

                If m_Naming = "Default" Then

                    Return objFileName.Name

                Else

                    Dim intX As Integer
                    Dim arrSplit() As String
                    Dim sb As New Text.StringBuilder
                    arrSplit = m_Naming.Split(CChar(m_delimiter))

                    'Appends the first TEXTBOX on it.
                    sb.Append(arrSplit(0).ToString)
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
                        End Select
                    Next

                    'Appends last text box
                    sb.Append(arrSplit(4).ToString())
                    Return sb.ToString()

                End If
            Case 2 'Weekly
                FirstDayOfYear = CType("01/01/" & objFileName.LastWriteTimeUtc.Year.ToString(), DateTime)
                FileWeekOfYear = DateDiff(DateInterval.WeekOfYear, FirstDayOfYear, objFileName.LastWriteTimeUtc, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)

                If m_Naming = "Default" Then

                    FileMonth = Format(objFileName.LastWriteTimeUtc.ToString("MMMM"))
                    FileYear = Format(objFileName.LastWriteTimeUtc.ToString("yy"))
                    Return FileWeekOfYear & FileMonth & FileYear

                Else

                    Dim intX As Integer
                    Dim arrSplit() As String
                    Dim sb As New Text.StringBuilder
                    arrSplit = m_Naming.Split(CChar(m_delimiter))

                    'Append week of Year on the beginning of filename
                    sb.Append(FileWeekOfYear.ToString())

                    'Appends the first TEXTBOX on it.
                    sb.Append(arrSplit(0).ToString)
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
                        End Select
                    Next

                    'Appends last text box
                    sb.Append(arrSplit(4).ToString)
                    Return sb.ToString()

                End If

            Case 3 'Monthly
                If m_Naming = "Default" Then

                    FileMonth = Format(objFileName.LastWriteTimeUtc.ToString("MMMM"))
                    FileYear = Format(objFileName.LastWriteTimeUtc.ToString("yy"))
                    Return FileMonth.Trim & FileYear.Trim

                Else

                    Dim intX As Integer
                    Dim arrSplit() As String
                    Dim sb As New Text.StringBuilder
                    arrSplit = m_Naming.Split(CChar(m_delimiter))

                    'Appends the first TEXTBOX on it.
                    sb.Append(arrSplit(0).ToString)
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
                        End Select
                    Next
                    'Appends last text box
                    sb.Append(arrSplit(4).ToString)
                    Return sb.ToString()

                End If

            Case Else

                If m_Naming = "Default" Then

                    Return objFileName.Name

                Else

                    Dim intX As Integer
                    Dim arrSplit() As String
                    Dim sb As New Text.StringBuilder
                    arrSplit = m_Naming.Split(CChar(m_delimiter))

                    'Appends first TEXTBOX on filename
                    sb.Append(arrSplit(0).ToString)

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
                        End Select
                    Next

                    'Appends last TEXTBOX on filename
                    sb.Append(arrSplit(4).ToString())
                    Return sb.ToString()

                End If

        End Select

    End Function

    Public Property ZipResult() As Boolean
        Get
            ' The Get property procedure is called when the value
            'of a property is retrieved. 
            Return m_ZipResult
        End Get
        Set(ByVal Value As Boolean)
            'The Set property procedure is called when the value 
            'of a property is modified. 
            'The value to be assigned is passed in the argument to Set. 
            m_ZipResult = Value
        End Set
    End Property

    Public Property ZipFileName() As String
        Get
            ' The Get property procedure is called when the value
            'of a property is retrieved. 
            Return m_ZipFileName
        End Get
        Set(ByVal Value As String)
            'The Set property procedure is called when the value 
            'of a property is modified. 
            'The value to be assigned is passed in the argument to Set. 
            m_ZipFileName = Value
        End Set
    End Property

    Private Shared Function CheckEndSlash(ByVal directoryName As String) As String
        If Right(directoryName, 1) = "\" Then
            Return directoryName
        Else
            Return directoryName & "\"
        End If
    End Function

End Class