Imports System.DirectoryServices
Imports System.Windows.Forms
Imports Microsoft.Web.Administration

Public Class EasyConfigFrm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents CancelBTN As System.Windows.Forms.Button
    Friend WithEvents SelectBTN As System.Windows.Forms.Button
    Friend WithEvents CheckAll_BTN As System.Windows.Forms.Button
    Friend WithEvents UnCheck_BTN As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.CancelBTN = New System.Windows.Forms.Button()
        Me.SelectBTN = New System.Windows.Forms.Button()
        Me.CheckAll_BTN = New System.Windows.Forms.Button()
        Me.UnCheck_BTN = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(496, 232)
        Me.DataGrid1.TabIndex = 0
        '
        'CancelBTN
        '
        Me.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBTN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelBTN.Location = New System.Drawing.Point(424, 248)
        Me.CancelBTN.Name = "CancelBTN"
        Me.CancelBTN.Size = New System.Drawing.Size(75, 23)
        Me.CancelBTN.TabIndex = 1
        Me.CancelBTN.Text = "&Cancel"
        Me.ToolTip1.SetToolTip(Me.CancelBTN, "Click to cancel selections")
        '
        'SelectBTN
        '
        Me.SelectBTN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectBTN.Location = New System.Drawing.Point(336, 248)
        Me.SelectBTN.Name = "SelectBTN"
        Me.SelectBTN.Size = New System.Drawing.Size(75, 23)
        Me.SelectBTN.TabIndex = 2
        Me.SelectBTN.Text = "&Save"
        Me.ToolTip1.SetToolTip(Me.SelectBTN, "Click to save current selection")
        '
        'CheckAll_BTN
        '
        Me.CheckAll_BTN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckAll_BTN.Location = New System.Drawing.Point(8, 248)
        Me.CheckAll_BTN.Name = "CheckAll_BTN"
        Me.CheckAll_BTN.Size = New System.Drawing.Size(80, 23)
        Me.CheckAll_BTN.TabIndex = 3
        Me.CheckAll_BTN.Text = "&Check All"
        Me.ToolTip1.SetToolTip(Me.CheckAll_BTN, "Click to select all rows")
        '
        'UnCheck_BTN
        '
        Me.UnCheck_BTN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnCheck_BTN.Location = New System.Drawing.Point(96, 248)
        Me.UnCheck_BTN.Name = "UnCheck_BTN"
        Me.UnCheck_BTN.Size = New System.Drawing.Size(80, 23)
        Me.UnCheck_BTN.TabIndex = 4
        Me.UnCheck_BTN.Text = "&UnCheck All"
        Me.ToolTip1.SetToolTip(Me.UnCheck_BTN, "Click to un-select all rows")
        '
        'EasyConfigFrm
        '
        Me.AcceptButton = Me.SelectBTN
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.CancelBTN
        Me.ClientSize = New System.Drawing.Size(512, 273)
        Me.Controls.Add(Me.UnCheck_BTN)
        Me.Controls.Add(Me.CheckAll_BTN)
        Me.Controls.Add(Me.SelectBTN)
        Me.Controls.Add(Me.CancelBTN)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EasyConfigFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Easy Configuration Screen"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public DirectoryListing As String = ""

    'Adding MWA (Microsoft.Web.Administration Options)
    Public m_OSVersion As Integer = CType(Mid(Environment.OSVersion.Version.ToString, 1, 1), Int16)


    Private Sub EasyConfigFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetupGrid()

        SetData("w3svc")

        If m_OSVersion < 6 Then

            SetData("MSFTPSVC")
            SetData("SMTPSVC")
            SetData("NNTPSVC")

        End If

        Dim CM As CurrencyManager = CType(Me.BindingContext(Me.DataGrid1.DataSource), CurrencyManager)
        CType(CM.List, DataView).AllowNew = False
        CType(CM.List, DataView).AllowDelete = False

        If Not DirectoryListing Is Nothing Then
            Dim A() As String = DirectoryListing.Split(",")
            For Each str As String In A
                For Each DR As DataRow In CType(Me.DataGrid1.DataSource, DataTable).Rows
                    If DR.Item("Directory").ToString.ToLower.Trim = str.ToLower.Trim Then
                        DR.Item("select") = True
                    End If
                Next
            Next
        End If

        CType(Me.DataGrid1.DataSource, DataTable).AcceptChanges()
    End Sub

    Private Sub SetData(ByVal SvcType As String)

        Try

            If m_OSVersion < 6 Then

                Dim EN As DirectoryEntry = New DirectoryServices.DirectoryEntry("IIS://LOCALHOST/" & SvcType)

                For Each Entry As DirectoryEntry In EN.Children
                    If IsNumeric(Entry.Name) = True Then
                        Dim DR As DataRow = CType(Me.DataGrid1.DataSource, DataTable).NewRow
                        With DR
                            .Item("Select") = 0
                            .Item("Directory") = Entry.Properties.Item("LogFileDirectory").Value

                            Select Case SvcType.Trim.ToLower
                                Case "w3svc"
                                    .Item("Type") = "WWW"
                                    .Item("Directory") &= "\w3svc" & Entry.Name
                                Case "msftpsvc"
                                    .Item("Type") = "FTP"
                                    .Item("Directory") &= "\msftpsvc" & Entry.Name
                                Case "smtpsvc"
                                    .Item("Type") = "SMTP"
                                    .Item("Directory") &= "\smtpsvc" & Entry.Name
                                Case "nntpsvc"
                                    .Item("Type") = "NNTP"
                                    .Item("Directory") &= "\nntpsvc" & Entry.Name
                            End Select
                            .Item("ID") = Entry.Name
                            .Item("Name") = Entry.Properties.Item("ServerComment").Value

                        End With
                        CType(Me.DataGrid1.DataSource, DataTable).Rows.Add(DR)
                    End If
                Next

            Else

                Dim sm As New ServerManager
                Dim LogFilePath1 As String = ""
                Dim LogFilePath2 As String = ""

                For Each s As Site In sm.Sites

                    Dim DR As DataRow = CType(Me.DataGrid1.DataSource, DataTable).NewRow

                    With DR
                        .Item("Select") = 0
                        LogFilePath1 = s.LogFile.Directory.ToLower()

                        If Mid(LogFilePath1, 1, 13) = "%systemdrive%" Then
                            LogFilePath1 = SanitizeLogFilePath(LogFilePath1)
                        End If

                        LogFilePath2 = LogFilePath1 & "\w3svc" & s.Id
                        .Item("Directory") = LogFilePath2
                        .Item("Type") = "www"
                        .Item("ID") = s.Id
                        .Item("Name") = s.Name
                    End With
                    CType(Me.DataGrid1.DataSource, DataTable).Rows.Add(DR)

                Next

            End If

        Catch ex As Exception
            'Select Case SvcType.Trim.ToLower
            '    Case "w3svc"
            '        MsgBox("No WWW Sites found", MsgBoxStyle.Information, "Not Found")
            '    Case "msftpsvc"
            '        MsgBox("No FTP Sites found", MsgBoxStyle.Information, "Not Found")
            '    Case "smtpsvc"
            '        MsgBox("No SMTP Sites found", MsgBoxStyle.Information, "Not Found")
            '    Case "nntpsvc"
            '        MsgBox("No NNTP Sites found", MsgBoxStyle.Information, "Not Found")
            'End Select
        End Try
    End Sub

    Private Shared Function SanitizeLogFilePath(LogFilePath1 As String) As String
        Dim value1 As String = ""
        Dim SystemDrive As String = Environment.GetEnvironmentVariable("SystemDrive")
        value1 = Replace(LogFilePath1, "%systemdrive%", SystemDrive)
        Return value1
    End Function

    Private Sub SetupGrid()
        Dim DT As New DataTable("LogDirectories")
        DT.Columns.Add(New DataColumn("Directory"))
        DT.Columns.Add(New DataColumn("Type"))
        DT.Columns.Add(New DataColumn("Select", GetType(Boolean)))
        DT.Columns.Add(New DataColumn("ID", GetType(Integer)))
        DT.Columns.Add(New DataColumn("Name"))

        Me.DataGrid1.DataSource = DT

        Dim TS As New DataGridTableStyle
        TS.MappingName = "LogDirectories"

        Dim DGC1 As New DataGridTextBoxColumn
        DGC1.MappingName = "Name"
        DGC1.HeaderText = "Name"
        DGC1.Width = 200
        DGC1.ReadOnly = True
        TS.GridColumnStyles.Add(DGC1)

        Dim DGC2 As New DataGridTextBoxColumn
        DGC2.MappingName = "Type"
        DGC2.HeaderText = "Type"
        DGC2.Width = 100
        DGC2.ReadOnly = True
        TS.GridColumnStyles.Add(DGC2)

        Dim DGC3 As New DataGridBoolColumn
        DGC3.MappingName = "Select"
        DGC3.Width = 25
        DGC3.AllowNull = False
        DGC3.Alignment = HorizontalAlignment.Center
        TS.GridColumnStyles.Add(DGC3)

        Me.DataGrid1.TableStyles.Add(TS)
    End Sub

    Private Sub CheckAll_BTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAll_BTN.Click
        SetColumns(True)
    End Sub

    Private Sub SetColumns(ByVal Selected As Boolean)
        Dim CM As CurrencyManager = CType(Me.BindingContext(Me.DataGrid1.DataSource), CurrencyManager)
        For X As Integer = 0 To CM.Count - 1
            CM.Position = X
            CType(CM.Current, DataRowView).Item("Select") = Selected
        Next
    End Sub

    Private Sub UnCheck_BTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnCheck_BTN.Click
        SetColumns(False)
    End Sub

    Private Sub CancelBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBTN.Click
        If Not CType(Me.DataGrid1.DataSource, DataTable).GetChanges Is Nothing Then
            Dim DR As DialogResult = MessageBox.Show("Save Selection?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
            If DR = Windows.Forms.DialogResult.Yes Then
                Me.SelectBTN_Click(sender, e)
                Me.Close()
            ElseIf DR = Windows.Forms.DialogResult.No Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End If
    End Sub

    Private Sub EasyConfigFrm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Me.DialogResult <> Windows.Forms.DialogResult.OK Then
            If Me.DialogResult <> Windows.Forms.DialogResult.Cancel Then
                Dim DR As DialogResult = MessageBox.Show("Save Selection?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
                If DR = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = True
                    Me.SelectBTN_Click(sender, e)
                ElseIf DR = Windows.Forms.DialogResult.Cancel Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub SelectBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectBTN.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
