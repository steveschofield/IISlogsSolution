Public Class WizardForm
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents NextBtn As System.Windows.Forms.Button
    Friend WithEvents BackBtn As System.Windows.Forms.Button
    Friend WithEvents CancelBTN As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents WizardText As System.Windows.Forms.Label
    Friend WithEvents FinishedTxt As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WizardForm))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.NextBtn = New System.Windows.Forms.Button
        Me.BackBtn = New System.Windows.Forms.Button
        Me.CancelBTN = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.WizardText = New System.Windows.Forms.Label
        Me.FinishedTxt = New System.Windows.Forms.RichTextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(184, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(470, 270)
        Me.Panel1.TabIndex = 0
        '
        'NextBtn
        '
        Me.NextBtn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NextBtn.Location = New System.Drawing.Point(576, 344)
        Me.NextBtn.Name = "NextBtn"
        Me.NextBtn.Size = New System.Drawing.Size(75, 23)
        Me.NextBtn.TabIndex = 1
        Me.NextBtn.Text = "&Next"
        '
        'BackBtn
        '
        Me.BackBtn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BackBtn.Location = New System.Drawing.Point(488, 344)
        Me.BackBtn.Name = "BackBtn"
        Me.BackBtn.Size = New System.Drawing.Size(75, 23)
        Me.BackBtn.TabIndex = 2
        Me.BackBtn.Text = "&Back"
        '
        'CancelBTN
        '
        Me.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBTN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelBTN.Location = New System.Drawing.Point(400, 344)
        Me.CancelBTN.Name = "CancelBTN"
        Me.CancelBTN.Size = New System.Drawing.Size(75, 23)
        Me.CancelBTN.TabIndex = 3
        Me.CancelBTN.Text = "&Cancel"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 56)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 312)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'WizardText
        '
        Me.WizardText.BackColor = System.Drawing.SystemColors.Window
        Me.WizardText.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WizardText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.WizardText.Location = New System.Drawing.Point(8, 16)
        Me.WizardText.Name = "WizardText"
        Me.WizardText.Size = New System.Drawing.Size(643, 37)
        Me.WizardText.TabIndex = 6
        Me.WizardText.Text = "Test"
        Me.WizardText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FinishedTxt
        '
        Me.FinishedTxt.Location = New System.Drawing.Point(184, 64)
        Me.FinishedTxt.Name = "FinishedTxt"
        Me.FinishedTxt.Size = New System.Drawing.Size(456, 264)
        Me.FinishedTxt.TabIndex = 0
        Me.FinishedTxt.Text = ""
        Me.FinishedTxt.Visible = False
        '
        'WizardForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.CancelBTN
        Me.ClientSize = New System.Drawing.Size(658, 375)
        Me.Controls.Add(Me.FinishedTxt)
        Me.Controls.Add(Me.WizardText)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CancelBTN)
        Me.Controls.Add(Me.BackBtn)
        Me.Controls.Add(Me.NextBtn)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WizardForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IIS Logs Wizard"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private CurrentParentTab As TabPage
    Private LastPNL As Panel
    Private LastDocStyle As New DockStyle

    Private Sub NextBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextBtn.Click
        If Me.NextBtn.Text.Trim.ToLower = "finished" Then
            With CType(Me.Owner, MainForm)
                If .ValidateData = True Then
                    .SaveMnuI_Click(Me, New EventArgs)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    'Dim Reg As Microsoft.Win32.RegistryKey
                    'Reg = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\IISLOGS")
                    'If Not Reg Is Nothing Then
                    '    Reg.SetValue("Installed", True)
                    'End If
                    CreateQuickWizardVerifyFile()
                    Me.Close()
                End If
            End With
        Else
            Me.SetNextPanel()
        End If
    End Sub

    Function CreateQuickWizardVerifyFile() As Boolean
        Try
            If System.IO.File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) & "\Logs\QS\QuickWizardComplete.txt") = False Then
                Dim fs As System.IO.FileStream
                fs = System.IO.File.Create(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) & "\Logs\QS\QuickWizardComplete.txt")
                fs.Close()
                System.Threading.Thread.Sleep(100)

                '// create a writer and open the file
                Dim tw As System.IO.TextWriter = New System.IO.StreamWriter(System.IO.File.Create(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) & "\Logs\QS\QuickWizardComplete.txt"))
                tw.WriteLine("Quick Wizard has been run at least once")
                tw.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("An Error happened trying to create Quick Wizard file.  Please check permissions on IISlogs install folder")
        End Try
        
    End Function

    Private Sub BackBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackBtn.Click
        Me.SetBackPanel()
    End Sub

    Private Sub CancelBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBTN.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub WizardForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetNextPanel()
        Me.FinishedTxt.Size = Me.Panel1.Size
        Me.FinishedTxt.Location = Me.Panel1.Location
        If IO.File.Exists(Application.StartupPath & "\SetupFinished.rtf") = True Then
            Me.FinishedTxt.LoadFile(Application.StartupPath & "\SetupFinished.rtf")
        End If
        Me.FinishedTxt.ReadOnly = True
    End Sub

    Private Sub WizardForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Me.Panel1.Controls.Count > 0 Then
            Me.CurrentParentTab.Controls.Add(Me.Panel1.Controls(0))
        End If
    End Sub

    Private Sub SetNextPanel()
        With CType(Me.Owner, MainForm)
            If Me.Panel1.Controls.Count > 0 Then
                If Not Me.CurrentParentTab Is Nothing Then
                    Me.LastPNL.Dock = Me.LastDocStyle
                    Me.CurrentParentTab.Controls.Add(Me.Panel1.Controls.Item(0))
                End If
            End If
            If Me.CurrentParentTab Is Nothing Then
                Me.BackBtn.Enabled = False
                Me.CurrentParentTab = .Tab_SpecificDIR
                Me.Panel1.Controls.Add(.PNL_SpecificDirectories)
                .PNL_SpecificDirectories.Show()
                .EasyConfig_BTN_Click(Me, New EventArgs)
            ElseIf Me.CurrentParentTab Is .Tab_SpecificDIR Then
                Me.BackBtn.Enabled = True
                Me.CurrentParentTab = .Tab_StandardSettings
                Me.Panel1.Controls.Add(.PNL_ZipSettings)
            ElseIf Me.CurrentParentTab Is .Tab_StandardSettings Then
                If Me.LastPNL Is .PNL_ZipSettings Then
                    Me.Panel1.Controls.Add(.PNL_DeleteSettings)
                Else
                    Me.CurrentParentTab = .Tab_FileNaming
                    Me.Panel1.Controls.Add(.PNL_FileNamingOptions)
                End If
            ElseIf Me.CurrentParentTab Is .Tab_FileNaming Then
                Me.CurrentParentTab = .Tab_DeleteDIR
                Me.Panel1.Controls.Add(.PNL_DeleteDirSettings)
            ElseIf Me.CurrentParentTab Is .Tab_DeleteDIR Then
                Me.CurrentParentTab = .Tab_SMTPConfig
                Me.Panel1.Controls.Add(.PNL_SMTPSettings)
            ElseIf Me.CurrentParentTab Is .Tab_SMTPConfig Then
                Me.CurrentParentTab = .Tab_MailSettings
                Me.Panel1.Controls.Add(.PNL_MailSettings)
            ElseIf Me.CurrentParentTab Is .Tab_MailSettings Then
                Me.CurrentParentTab = .Tab_LogSettings
                Me.Panel1.Controls.Add(.PNL_LogSettings)
                .PNL_LogSettings.Show()
            ElseIf Me.CurrentParentTab Is .Tab_LogSettings Then
                Me.NextBtn.Text = "Finished"
                Me.CurrentParentTab = Nothing
                Me.FinishedTxt.Visible = True
            End If
        End With
        If Not Me.CurrentParentTab Is Nothing Then
            Me.LastPNL = Me.Panel1.Controls.Item(0)
            Me.LastDocStyle = Me.LastPNL.Dock
            Me.LastPNL.Dock = DockStyle.Fill
        End If
        setText()
    End Sub

    Private Sub SetBackPanel()
        With CType(Me.Owner, MainForm)
            If Me.Panel1.Controls.Count > 0 Then
                If Not Me.CurrentParentTab Is Nothing Then
                    Me.LastPNL.Dock = Me.LastDocStyle
                    Me.CurrentParentTab.Controls.Add(Me.Panel1.Controls.Item(0))
                End If
            End If
            If Me.CurrentParentTab Is .Tab_StandardSettings Then
                If Me.LastPNL Is .PNL_ZipSettings Then
                    Me.BackBtn.Enabled = False
                    Me.CurrentParentTab = .Tab_SpecificDIR
                    Me.Panel1.Controls.Add(.PNL_SpecificDirectories)
                Else
                    Me.CurrentParentTab = .Tab_StandardSettings
                    Me.Panel1.Controls.Add(.PNL_ZipSettings)
                End If
            ElseIf Me.CurrentParentTab Is .Tab_FileNaming Then
                Me.CurrentParentTab = .Tab_StandardSettings
                Me.Panel1.Controls.Add(.PNL_DeleteSettings)
            ElseIf Me.CurrentParentTab Is .Tab_DeleteDIR Then
                Me.CurrentParentTab = .Tab_FileNaming
                Me.Panel1.Controls.Add(.PNL_FileNamingOptions)
            ElseIf Me.CurrentParentTab Is .Tab_SMTPConfig Then
                Me.CurrentParentTab = .Tab_DeleteDIR
                Me.Panel1.Controls.Add(.PNL_DeleteDirSettings)
            ElseIf Me.CurrentParentTab Is .Tab_MailSettings Then
                Me.CurrentParentTab = .Tab_SMTPConfig
                Me.Panel1.Controls.Add(.PNL_SMTPSettings)
            ElseIf Me.CurrentParentTab Is .Tab_LogSettings Then
                Me.CurrentParentTab = .Tab_MailSettings
                Me.Panel1.Controls.Add(.PNL_MailSettings)
            ElseIf Me.CurrentParentTab Is Nothing Then
                Me.NextBtn.Text = "Next"
                Me.FinishedTxt.Visible = False
                Me.CurrentParentTab = .Tab_LogSettings
                Me.Panel1.Controls.Add(.PNL_LogSettings)
            End If
        End With
        If Not Me.CurrentParentTab Is Nothing Then
            Me.LastPNL = Me.Panel1.Controls.Item(0)
            Me.LastDocStyle = Me.LastPNL.Dock
            Me.LastPNL.Dock = DockStyle.Fill
        End If
        setText()
    End Sub

    Private Sub setText()
        Dim Msg As String = ""
        With CType(Me.Owner, MainForm)
            If Me.LastPNL Is Nothing Then
                Msg = "To Save Changes, Please Click Finished"
            ElseIf Me.LastPNL Is .PNL_SpecificDirectories Then
                Msg = "Configure Specific Directories to Monitor"
            ElseIf Me.LastPNL Is .PNL_ZipSettings Then
                Msg = "Configure Zip Archive Retention Policy"
            ElseIf Me.LastPNL Is .PNL_SMTPSettings Then
                Msg = "Configure SMTP Log Directories"
            ElseIf Me.LastPNL Is .PNL_MailSettings Then
                Msg = "Setup Report Mail Settings"
            ElseIf Me.LastPNL Is .PNL_LogSettings Then
                Msg = "Setup Log Settings Path and Service Interval"
            ElseIf Me.LastPNL Is .PNL_FileNamingOptions Then
                Msg = "Setup File Naming Options"
            ElseIf Me.LastPNL Is .PNL_DeleteSettings Then
                Msg = "Configure Delete Feature Retention Policy"
            ElseIf Me.LastPNL Is .PNL_AdvancedDIR Then
                Msg = "Configure Advanced Directory Monitoring"
            ElseIf Me.LastPNL Is .PNL_DeleteDirSettings Then
                Msg = "Configure Delete ONLY Directories Feature"
            End If
        End With
        Me.WizardText.Text = Msg
    End Sub
End Class
