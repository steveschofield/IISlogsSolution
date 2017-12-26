Public Class MainForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "
    Private chkbox As System.Windows.Forms.CheckBox

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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents OpenMnuI As System.Windows.Forms.MenuItem
    Friend WithEvents SaveMnuI As System.Windows.Forms.MenuItem
    Friend WithEvents ExitMnuI As System.Windows.Forms.MenuItem
    Friend WithEvents AboutMnuI As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents StartMnuI As System.Windows.Forms.MenuItem
    Friend WithEvents StopMnuI As System.Windows.Forms.MenuItem
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents ServiceController1 As System.ServiceProcess.ServiceController
    Friend WithEvents SMTPDG As System.Windows.Forms.DataGrid
    Friend WithEvents DeleteDG As System.Windows.Forms.DataGrid
    Friend WithEvents SerDG As System.Windows.Forms.DataGrid
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents SpecDG As System.Windows.Forms.DataGrid
    Friend WithEvents CHK_EnableDelete As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_EnableZip As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_MonitorZipDIR As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_EnableSMTP As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_EnableDeleteOnly As System.Windows.Forms.CheckBox
    Friend WithEvents LogDirBTN As System.Windows.Forms.Button
    Friend WithEvents LogDirPath_TXT As System.Windows.Forms.TextBox
    Friend WithEvents ZipFilePath_TXT As System.Windows.Forms.TextBox
    Friend WithEvents ZipFilePath_BTN As System.Windows.Forms.Button
    Friend WithEvents DeleteRetentionPeriod_TXT As System.Windows.Forms.TextBox
    Friend WithEvents ZipRetentionPeriod_Txt As System.Windows.Forms.TextBox
    Friend WithEvents STMPRetentionPeriod_TXT As System.Windows.Forms.TextBox
    Friend WithEvents DeleteOnlyRetentionPeriod_TXT As System.Windows.Forms.TextBox
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents HelpMnI As System.Windows.Forms.MenuItem
    Friend WithEvents SetupService_MnuI As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CHK_SendMailReport As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents MailServer_TXT As System.Windows.Forms.TextBox
    Friend WithEvents MailUID_TXT As System.Windows.Forms.TextBox
    Friend WithEvents MailFrom_TXT As System.Windows.Forms.TextBox
    Friend WithEvents MailPortNumber_NumUPDOWN As System.Windows.Forms.NumericUpDown
    Friend WithEvents MailTo_TXT As System.Windows.Forms.TextBox
    Friend WithEvents MailPWD_TXT As System.Windows.Forms.TextBox
    Friend WithEvents MailSubject_TXT As System.Windows.Forms.TextBox
    Friend WithEvents DataValidator1 As IISLogsGUI.DataValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents DIRDG As System.Windows.Forms.DataGrid
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ZipCompressionCB As System.Windows.Forms.ComboBox
    Friend WithEvents DeleteOrginalCHK As System.Windows.Forms.CheckBox
    Friend WithEvents EasyConfig_BTN As System.Windows.Forms.Button
    Friend WithEvents PNL_SpecificDirectories As System.Windows.Forms.Panel
    Friend WithEvents PNL_AdvancedDIR As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ToolBarButton7 As System.Windows.Forms.ToolBarButton
    Friend WithEvents WizardMnuI As System.Windows.Forms.MenuItem
    Friend WithEvents PNL_DeleteSettings As System.Windows.Forms.Panel
    Friend WithEvents PNL_ZipSettings As System.Windows.Forms.Panel
    Friend WithEvents PNL_LogSettings As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents PNL_SMTPSettings As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents PNL_DeleteDirSettings As System.Windows.Forms.Panel
    Friend WithEvents PNL_MailSettings As System.Windows.Forms.Panel
    Friend WithEvents PNL_FileNamingOptions As System.Windows.Forms.Panel
    Friend WithEvents Tab_SMTPConfig As System.Windows.Forms.TabPage
    Friend WithEvents Tab_DeleteDIR As System.Windows.Forms.TabPage
    Friend WithEvents Tab_StandardConfig As System.Windows.Forms.TabPage
    Friend WithEvents Tab_SpecificDIR As System.Windows.Forms.TabPage
    Friend WithEvents Tab_StandardSettings As System.Windows.Forms.TabPage
    Friend WithEvents Tab_AdvConfig As System.Windows.Forms.TabPage
    Friend WithEvents Tab_LogSettings As System.Windows.Forms.TabPage
    Friend WithEvents Tab_MailSettings As System.Windows.Forms.TabPage
    Friend WithEvents Tab_FileNaming As System.Windows.Forms.TabPage
    Friend WithEvents Rad_NameOptDefault As System.Windows.Forms.RadioButton
    Friend WithEvents Rad_NameOptCustom As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CustomGB As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents ZipPathOrg_RAD As System.Windows.Forms.RadioButton
    Friend WithEvents ZipPathCustom_RAD As System.Windows.Forms.RadioButton
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents CHK_EnableMailAuth As System.Windows.Forms.CheckBox
    Friend WithEvents PasswordEntryTxt2 As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TAB_AutoAddOptions As System.Windows.Forms.TabPage
    Friend WithEvents CHK_W3SVC_AutoAddOptions As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_MSFTPSVC_AutoAddOptions As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_SMTPSVC_AutoAddOptions As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtDelimiter As System.Windows.Forms.TextBox
    Friend WithEvents CHK_ProcessBAK As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_ProcessDAT As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_ProcessTXT As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_ProcessXML As System.Windows.Forms.CheckBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents ToolBarButton8 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton9 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents TAB_ZipDirectories As System.Windows.Forms.TabPage
    Friend WithEvents DataSet1 As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DC_DirectoryName As System.Data.DataColumn
    Friend WithEvents DC_ZipFile As System.Data.DataColumn
    Friend WithEvents DC_ZipRetentionPeriod As System.Data.DataColumn
    Friend WithEvents DeleteOriginalFile As System.Data.DataColumn
    Friend WithEvents DC_DeleteFile As System.Data.DataColumn
    Friend WithEvents DC_DeleteRetentionPeriod As System.Data.DataColumn
    Friend WithEvents DC_Recursive As System.Data.DataColumn
    Friend WithEvents DC_ProcessRootFolderRecursive As System.Data.DataColumn
    Friend WithEvents DC_ZipFilePath As System.Data.DataColumn
    Friend WithEvents DC_IncludeComputerName As System.Data.DataColumn
    Friend WithEvents DC_ProcessUnknownExtensions As System.Data.DataColumn
    Friend WithEvents DC_ProcessTXT As System.Data.DataColumn
    Friend WithEvents DC_ProcessBAK As System.Data.DataColumn
    Friend WithEvents DC_ProcessDAT As System.Data.DataColumn
    Friend WithEvents DC_ProcessXML As System.Data.DataColumn
    'Begin IISLogs 4.0 items.
    Friend WithEvents DC_LogsDWM As System.Data.DataColumn
    Friend WithEvents DC_PreserveDirPath As System.Data.DataColumn
    'Friend WithEvents DC_Naming As System.Data.DataColumn
    'End IISLogs 4.0 items
    Friend WithEvents PNL_ZipDirectories As System.Windows.Forms.Panel
    Friend WithEvents DG_ZipDirectories As IISGrid
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents PNLHeader As System.Windows.Forms.Panel
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents DataColumn9 As System.Data.DataColumn
    Friend WithEvents DataColumn10 As System.Data.DataColumn
    Friend WithEvents DataColumn11 As System.Data.DataColumn
    Friend WithEvents DataColumn12 As System.Data.DataColumn
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RDO_ZipFileStoragePreference3 As System.Windows.Forms.RadioButton
    Friend WithEvents RDO_ZipFileStoragePreference2 As System.Windows.Forms.RadioButton
    Friend WithEvents RDO_ZipFileStoragePreference1 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_EnablePerDirectory As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_UseMetabaseRoleService As System.Windows.Forms.CheckBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    'Friend WithEvents DataColumn13 As System.Data.DataColumn
    Friend WithEvents CHK_AutoAddOptions As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ZipFilePath_BTN = New System.Windows.Forms.Button()
        Me.LogDirBTN = New System.Windows.Forms.Button()
        Me.MailPortNumber_NumUPDOWN = New System.Windows.Forms.NumericUpDown()
        Me.EasyConfig_BTN = New System.Windows.Forms.Button()
        Me.MailFrom_TXT = New System.Windows.Forms.TextBox()
        Me.MailTo_TXT = New System.Windows.Forms.TextBox()
        Me.MailUID_TXT = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CHK_EnableDelete = New System.Windows.Forms.CheckBox()
        Me.CHK_EnableZip = New System.Windows.Forms.CheckBox()
        Me.Tab_SMTPConfig = New System.Windows.Forms.TabPage()
        Me.PNL_SMTPSettings = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CHK_EnableSMTP = New System.Windows.Forms.CheckBox()
        Me.SMTPDG = New System.Windows.Forms.DataGrid()
        Me.STMPRetentionPeriod_TXT = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Tab_DeleteDIR = New System.Windows.Forms.TabPage()
        Me.PNL_DeleteDirSettings = New System.Windows.Forms.Panel()
        Me.DeleteOnlyRetentionPeriod_TXT = New System.Windows.Forms.TextBox()
        Me.DeleteDG = New System.Windows.Forms.DataGrid()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.CHK_EnableDeleteOnly = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Tab_StandardConfig = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.Tab_SpecificDIR = New System.Windows.Forms.TabPage()
        Me.PNL_SpecificDirectories = New System.Windows.Forms.Panel()
        Me.SpecDG = New System.Windows.Forms.DataGrid()
        Me.Tab_StandardSettings = New System.Windows.Forms.TabPage()
        Me.PNL_DeleteSettings = New System.Windows.Forms.Panel()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DeleteRetentionPeriod_TXT = New System.Windows.Forms.TextBox()
        Me.PNL_ZipSettings = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CHK_MonitorZipDIR = New System.Windows.Forms.CheckBox()
        Me.ZipCompressionCB = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ZipFilePath_TXT = New System.Windows.Forms.TextBox()
        Me.ZipPathCustom_RAD = New System.Windows.Forms.RadioButton()
        Me.ZipPathOrg_RAD = New System.Windows.Forms.RadioButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DeleteOrginalCHK = New System.Windows.Forms.CheckBox()
        Me.ZipRetentionPeriod_Txt = New System.Windows.Forms.TextBox()
        Me.Tab_LogSettings = New System.Windows.Forms.TabPage()
        Me.PNL_LogSettings = New System.Windows.Forms.Panel()
        Me.LogDirPath_TXT = New System.Windows.Forms.TextBox()
        Me.SerDG = New System.Windows.Forms.DataGrid()
        Me.Tab_AdvConfig = New System.Windows.Forms.TabPage()
        Me.PNL_AdvancedDIR = New System.Windows.Forms.Panel()
        Me.DIRDG = New System.Windows.Forms.DataGrid()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Tab_MailSettings = New System.Windows.Forms.TabPage()
        Me.PNL_MailSettings = New System.Windows.Forms.Panel()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.PasswordEntryTxt2 = New System.Windows.Forms.TextBox()
        Me.CHK_EnableMailAuth = New System.Windows.Forms.CheckBox()
        Me.MailServer_TXT = New System.Windows.Forms.TextBox()
        Me.MailPWD_TXT = New System.Windows.Forms.TextBox()
        Me.MailSubject_TXT = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CHK_SendMailReport = New System.Windows.Forms.CheckBox()
        Me.Tab_FileNaming = New System.Windows.Forms.TabPage()
        Me.PNL_FileNamingOptions = New System.Windows.Forms.Panel()
        Me.CustomGB = New System.Windows.Forms.GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Rad_NameOptDefault = New System.Windows.Forms.RadioButton()
        Me.Rad_NameOptCustom = New System.Windows.Forms.RadioButton()
        Me.TAB_AutoAddOptions = New System.Windows.Forms.TabPage()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.CHK_UseMetabaseRoleService = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RDO_ZipFileStoragePreference3 = New System.Windows.Forms.RadioButton()
        Me.RDO_ZipFileStoragePreference2 = New System.Windows.Forms.RadioButton()
        Me.RDO_ZipFileStoragePreference1 = New System.Windows.Forms.RadioButton()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.CHK_ProcessBAK = New System.Windows.Forms.CheckBox()
        Me.CHK_ProcessDAT = New System.Windows.Forms.CheckBox()
        Me.CHK_ProcessTXT = New System.Windows.Forms.CheckBox()
        Me.CHK_ProcessXML = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CHK_AutoAddOptions = New System.Windows.Forms.CheckBox()
        Me.CHK_SMTPSVC_AutoAddOptions = New System.Windows.Forms.CheckBox()
        Me.CHK_MSFTPSVC_AutoAddOptions = New System.Windows.Forms.CheckBox()
        Me.CHK_W3SVC_AutoAddOptions = New System.Windows.Forms.CheckBox()
        Me.txtDelimiter = New System.Windows.Forms.TextBox()
        Me.TAB_ZipDirectories = New System.Windows.Forms.TabPage()
        Me.PNL_ZipDirectories = New System.Windows.Forms.Panel()
        Me.CHK_EnablePerDirectory = New System.Windows.Forms.CheckBox()
        Me.PNLHeader = New System.Windows.Forms.Panel()
        Me.DG_ZipDirectories = New IISLogsGUI.IISGrid()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.OpenMnuI = New System.Windows.Forms.MenuItem()
        Me.SaveMnuI = New System.Windows.Forms.MenuItem()
        Me.ExitMnuI = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.StartMnuI = New System.Windows.Forms.MenuItem()
        Me.StopMnuI = New System.Windows.Forms.MenuItem()
        Me.SetupService_MnuI = New System.Windows.Forms.MenuItem()
        Me.WizardMnuI = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.HelpMnI = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.AboutMnuI = New System.Windows.Forms.MenuItem()
        Me.ServiceController1 = New System.ServiceProcess.ServiceController()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton3 = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton5 = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton7 = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton6 = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton8 = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton9 = New System.Windows.Forms.ToolBarButton()
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DC_DirectoryName = New System.Data.DataColumn()
        Me.DC_ZipFile = New System.Data.DataColumn()
        Me.DC_ZipRetentionPeriod = New System.Data.DataColumn()
        Me.DeleteOriginalFile = New System.Data.DataColumn()
        Me.DC_DeleteFile = New System.Data.DataColumn()
        Me.DC_DeleteRetentionPeriod = New System.Data.DataColumn()
        Me.DC_Recursive = New System.Data.DataColumn()
        Me.DC_ProcessRootFolderRecursive = New System.Data.DataColumn()
        Me.DC_ZipFilePath = New System.Data.DataColumn()
        Me.DC_IncludeComputerName = New System.Data.DataColumn()
        Me.DC_ProcessUnknownExtensions = New System.Data.DataColumn()
        Me.DC_ProcessTXT = New System.Data.DataColumn()
        Me.DC_ProcessBAK = New System.Data.DataColumn()
        Me.DC_ProcessDAT = New System.Data.DataColumn()
        Me.DC_ProcessXML = New System.Data.DataColumn()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.DataColumn6 = New System.Data.DataColumn()
        Me.DataColumn7 = New System.Data.DataColumn()
        Me.DataColumn8 = New System.Data.DataColumn()
        Me.DataColumn9 = New System.Data.DataColumn()
        Me.DataColumn10 = New System.Data.DataColumn()
        Me.DataColumn11 = New System.Data.DataColumn()
        Me.DataColumn12 = New System.Data.DataColumn()
        Me.DC_LogsDWM = New System.Data.DataColumn()
        Me.DC_PreserveDirPath = New System.Data.DataColumn()
        Me.DataValidator1 = New IISLogsGUI.DataValidator(Me.components)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MailPortNumber_NumUPDOWN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_SMTPConfig.SuspendLayout()
        Me.PNL_SMTPSettings.SuspendLayout()
        CType(Me.SMTPDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_DeleteDIR.SuspendLayout()
        Me.PNL_DeleteDirSettings.SuspendLayout()
        CType(Me.DeleteDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_StandardConfig.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.Tab_SpecificDIR.SuspendLayout()
        Me.PNL_SpecificDirectories.SuspendLayout()
        CType(Me.SpecDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_StandardSettings.SuspendLayout()
        Me.PNL_DeleteSettings.SuspendLayout()
        Me.PNL_ZipSettings.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Tab_LogSettings.SuspendLayout()
        Me.PNL_LogSettings.SuspendLayout()
        CType(Me.SerDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_AdvConfig.SuspendLayout()
        Me.PNL_AdvancedDIR.SuspendLayout()
        CType(Me.DIRDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Tab_MailSettings.SuspendLayout()
        Me.PNL_MailSettings.SuspendLayout()
        Me.Tab_FileNaming.SuspendLayout()
        Me.PNL_FileNamingOptions.SuspendLayout()
        Me.CustomGB.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TAB_AutoAddOptions.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TAB_ZipDirectories.SuspendLayout()
        Me.PNL_ZipDirectories.SuspendLayout()
        CType(Me.DG_ZipDirectories, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ZipFilePath_BTN
        '
        Me.ZipFilePath_BTN.Location = New System.Drawing.Point(184, 72)
        Me.ZipFilePath_BTN.Name = "ZipFilePath_BTN"
        Me.ZipFilePath_BTN.Size = New System.Drawing.Size(24, 23)
        Me.ZipFilePath_BTN.TabIndex = 7
        Me.ZipFilePath_BTN.Text = "...."
        Me.ToolTip1.SetToolTip(Me.ZipFilePath_BTN, "Click to set Path")
        '
        'LogDirBTN
        '
        Me.LogDirBTN.Location = New System.Drawing.Point(416, 24)
        Me.LogDirBTN.Name = "LogDirBTN"
        Me.LogDirBTN.Size = New System.Drawing.Size(24, 23)
        Me.LogDirBTN.TabIndex = 84
        Me.LogDirBTN.Text = "...."
        Me.ToolTip1.SetToolTip(Me.LogDirBTN, "Click to set Path")
        '
        'MailPortNumber_NumUPDOWN
        '
        Me.MailPortNumber_NumUPDOWN.Location = New System.Drawing.Point(216, 120)
        Me.MailPortNumber_NumUPDOWN.Maximum = New Decimal(New Integer() {588, 0, 0, 0})
        Me.MailPortNumber_NumUPDOWN.Name = "MailPortNumber_NumUPDOWN"
        Me.MailPortNumber_NumUPDOWN.Size = New System.Drawing.Size(64, 20)
        Me.MailPortNumber_NumUPDOWN.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.MailPortNumber_NumUPDOWN, "Set to Correct Port")
        '
        'EasyConfig_BTN
        '
        Me.EasyConfig_BTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EasyConfig_BTN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EasyConfig_BTN.Location = New System.Drawing.Point(499, 279)
        Me.EasyConfig_BTN.Name = "EasyConfig_BTN"
        Me.EasyConfig_BTN.Size = New System.Drawing.Size(89, 23)
        Me.EasyConfig_BTN.TabIndex = 85
        Me.EasyConfig_BTN.Text = "&Easy Config"
        Me.ToolTip1.SetToolTip(Me.EasyConfig_BTN, "Click to get directories dynamicly")
        '
        'MailFrom_TXT
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.MailFrom_TXT, True)
        Me.DataValidator1.SetDataType(Me.MailFrom_TXT, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.MailFrom_TXT, "")
        Me.MailFrom_TXT.Location = New System.Drawing.Point(216, 40)
        Me.DataValidator1.SetMaxValue(Me.MailFrom_TXT, "")
        Me.DataValidator1.SetMinValue(Me.MailFrom_TXT, "")
        Me.MailFrom_TXT.Name = "MailFrom_TXT"
        Me.DataValidator1.SetRegularExpression(Me.MailFrom_TXT, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[" & _
        "a-zA-Z]$")
        Me.DataValidator1.SetRequired(Me.MailFrom_TXT, False)
        Me.MailFrom_TXT.Size = New System.Drawing.Size(184, 20)
        Me.MailFrom_TXT.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.MailFrom_TXT, "Set Email Address Here")
        '
        'MailTo_TXT
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.MailTo_TXT, True)
        Me.DataValidator1.SetDataType(Me.MailTo_TXT, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.MailTo_TXT, "")
        Me.MailTo_TXT.Location = New System.Drawing.Point(216, 64)
        Me.DataValidator1.SetMaxValue(Me.MailTo_TXT, "")
        Me.DataValidator1.SetMinValue(Me.MailTo_TXT, "")
        Me.MailTo_TXT.Name = "MailTo_TXT"
        Me.DataValidator1.SetRegularExpression(Me.MailTo_TXT, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[" & _
        "a-zA-Z]$")
        Me.DataValidator1.SetRequired(Me.MailTo_TXT, False)
        Me.MailTo_TXT.Size = New System.Drawing.Size(184, 20)
        Me.MailTo_TXT.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.MailTo_TXT, "Set Email Address Here")
        '
        'MailUID_TXT
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.MailUID_TXT, True)
        Me.DataValidator1.SetDataType(Me.MailUID_TXT, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.MailUID_TXT, "")
        Me.MailUID_TXT.Location = New System.Drawing.Point(216, 200)
        Me.DataValidator1.SetMaxValue(Me.MailUID_TXT, "")
        Me.DataValidator1.SetMinValue(Me.MailUID_TXT, "")
        Me.MailUID_TXT.Name = "MailUID_TXT"
        Me.DataValidator1.SetRegularExpression(Me.MailUID_TXT, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[" & _
        "a-zA-Z]$")
        Me.DataValidator1.SetRequired(Me.MailUID_TXT, False)
        Me.MailUID_TXT.Size = New System.Drawing.Size(184, 20)
        Me.MailUID_TXT.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.MailUID_TXT, "Set Email Address Here")
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(168, 696)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 23)
        Me.Label11.TabIndex = 72
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(214, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(168, 16)
        Me.Label9.TabIndex = 68
        Me.Label9.Text = "Delete Files Older Than"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(240, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(168, 16)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "Zip Files Older Than"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 16)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "Log Directory Path"
        '
        'CHK_EnableDelete
        '
        Me.CHK_EnableDelete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHK_EnableDelete.Location = New System.Drawing.Point(16, 8)
        Me.CHK_EnableDelete.Name = "CHK_EnableDelete"
        Me.CHK_EnableDelete.Size = New System.Drawing.Size(192, 21)
        Me.CHK_EnableDelete.TabIndex = 0
        Me.CHK_EnableDelete.Text = "Enable Delete Feature"
        '
        'CHK_EnableZip
        '
        Me.CHK_EnableZip.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHK_EnableZip.Location = New System.Drawing.Point(16, 8)
        Me.CHK_EnableZip.Name = "CHK_EnableZip"
        Me.CHK_EnableZip.Size = New System.Drawing.Size(208, 24)
        Me.CHK_EnableZip.TabIndex = 0
        Me.CHK_EnableZip.Text = "Enable ZIP Feature"
        '
        'Tab_SMTPConfig
        '
        Me.Tab_SMTPConfig.Controls.Add(Me.PNL_SMTPSettings)
        Me.Tab_SMTPConfig.Location = New System.Drawing.Point(4, 22)
        Me.Tab_SMTPConfig.Name = "Tab_SMTPConfig"
        Me.Tab_SMTPConfig.Size = New System.Drawing.Size(612, 332)
        Me.Tab_SMTPConfig.TabIndex = 1
        Me.Tab_SMTPConfig.Text = "SMTP Config"
        Me.Tab_SMTPConfig.UseVisualStyleBackColor = True
        '
        'PNL_SMTPSettings
        '
        Me.PNL_SMTPSettings.Controls.Add(Me.Label19)
        Me.PNL_SMTPSettings.Controls.Add(Me.CHK_EnableSMTP)
        Me.PNL_SMTPSettings.Controls.Add(Me.SMTPDG)
        Me.PNL_SMTPSettings.Controls.Add(Me.STMPRetentionPeriod_TXT)
        Me.PNL_SMTPSettings.Controls.Add(Me.Label18)
        Me.PNL_SMTPSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNL_SMTPSettings.Location = New System.Drawing.Point(0, 0)
        Me.PNL_SMTPSettings.Name = "PNL_SMTPSettings"
        Me.PNL_SMTPSettings.Size = New System.Drawing.Size(612, 332)
        Me.PNL_SMTPSettings.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(232, 248)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(128, 16)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Delete SMTP files after"
        '
        'CHK_EnableSMTP
        '
        Me.CHK_EnableSMTP.Location = New System.Drawing.Point(16, 248)
        Me.CHK_EnableSMTP.Name = "CHK_EnableSMTP"
        Me.CHK_EnableSMTP.Size = New System.Drawing.Size(152, 16)
        Me.CHK_EnableSMTP.TabIndex = 1
        Me.CHK_EnableSMTP.Text = "Enable SMTP Feature"
        '
        'SMTPDG
        '
        Me.SMTPDG.CaptionText = "SMTP Service Directories"
        Me.SMTPDG.DataMember = ""
        Me.SMTPDG.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.SMTPDG.Location = New System.Drawing.Point(8, 8)
        Me.SMTPDG.Name = "SMTPDG"
        Me.SMTPDG.Size = New System.Drawing.Size(448, 232)
        Me.SMTPDG.TabIndex = 0
        '
        'STMPRetentionPeriod_TXT
        '
        Me.STMPRetentionPeriod_TXT.BackColor = System.Drawing.SystemColors.Window
        Me.DataValidator1.SetCustomValidationEnabled(Me.STMPRetentionPeriod_TXT, True)
        Me.DataValidator1.SetDataType(Me.STMPRetentionPeriod_TXT, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.STMPRetentionPeriod_TXT, "")
        Me.STMPRetentionPeriod_TXT.Location = New System.Drawing.Point(360, 248)
        Me.DataValidator1.SetMaxValue(Me.STMPRetentionPeriod_TXT, "")
        Me.DataValidator1.SetMinValue(Me.STMPRetentionPeriod_TXT, "")
        Me.STMPRetentionPeriod_TXT.Name = "STMPRetentionPeriod_TXT"
        Me.STMPRetentionPeriod_TXT.ReadOnly = True
        Me.DataValidator1.SetRegularExpression(Me.STMPRetentionPeriod_TXT, "")
        Me.DataValidator1.SetRequired(Me.STMPRetentionPeriod_TXT, False)
        Me.STMPRetentionPeriod_TXT.Size = New System.Drawing.Size(40, 20)
        Me.STMPRetentionPeriod_TXT.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(408, 248)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 16)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "(Hours)"
        '
        'Tab_DeleteDIR
        '
        Me.Tab_DeleteDIR.Controls.Add(Me.PNL_DeleteDirSettings)
        Me.Tab_DeleteDIR.Location = New System.Drawing.Point(4, 22)
        Me.Tab_DeleteDIR.Name = "Tab_DeleteDIR"
        Me.Tab_DeleteDIR.Size = New System.Drawing.Size(612, 332)
        Me.Tab_DeleteDIR.TabIndex = 2
        Me.Tab_DeleteDIR.Text = "Delete Directories"
        Me.Tab_DeleteDIR.UseVisualStyleBackColor = True
        '
        'PNL_DeleteDirSettings
        '
        Me.PNL_DeleteDirSettings.Controls.Add(Me.DeleteOnlyRetentionPeriod_TXT)
        Me.PNL_DeleteDirSettings.Controls.Add(Me.DeleteDG)
        Me.PNL_DeleteDirSettings.Controls.Add(Me.Label20)
        Me.PNL_DeleteDirSettings.Controls.Add(Me.CHK_EnableDeleteOnly)
        Me.PNL_DeleteDirSettings.Controls.Add(Me.Label21)
        Me.PNL_DeleteDirSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNL_DeleteDirSettings.Location = New System.Drawing.Point(0, 0)
        Me.PNL_DeleteDirSettings.Name = "PNL_DeleteDirSettings"
        Me.PNL_DeleteDirSettings.Size = New System.Drawing.Size(612, 332)
        Me.PNL_DeleteDirSettings.TabIndex = 10
        '
        'DeleteOnlyRetentionPeriod_TXT
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.DeleteOnlyRetentionPeriod_TXT, True)
        Me.DataValidator1.SetDataType(Me.DeleteOnlyRetentionPeriod_TXT, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.DeleteOnlyRetentionPeriod_TXT, "")
        Me.DeleteOnlyRetentionPeriod_TXT.Location = New System.Drawing.Point(368, 248)
        Me.DataValidator1.SetMaxValue(Me.DeleteOnlyRetentionPeriod_TXT, "")
        Me.DataValidator1.SetMinValue(Me.DeleteOnlyRetentionPeriod_TXT, "")
        Me.DeleteOnlyRetentionPeriod_TXT.Name = "DeleteOnlyRetentionPeriod_TXT"
        Me.DeleteOnlyRetentionPeriod_TXT.ReadOnly = True
        Me.DataValidator1.SetRegularExpression(Me.DeleteOnlyRetentionPeriod_TXT, "")
        Me.DataValidator1.SetRequired(Me.DeleteOnlyRetentionPeriod_TXT, False)
        Me.DeleteOnlyRetentionPeriod_TXT.Size = New System.Drawing.Size(40, 20)
        Me.DeleteOnlyRetentionPeriod_TXT.TabIndex = 3
        '
        'DeleteDG
        '
        Me.DeleteDG.CaptionText = "Delete ONLY Directories"
        Me.DeleteDG.DataMember = ""
        Me.DeleteDG.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DeleteDG.Location = New System.Drawing.Point(8, 8)
        Me.DeleteDG.Name = "DeleteDG"
        Me.DeleteDG.Size = New System.Drawing.Size(448, 224)
        Me.DeleteDG.TabIndex = 6
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(240, 248)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(128, 16)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Delete Files Older Than"
        '
        'CHK_EnableDeleteOnly
        '
        Me.CHK_EnableDeleteOnly.Location = New System.Drawing.Point(8, 248)
        Me.CHK_EnableDeleteOnly.Name = "CHK_EnableDeleteOnly"
        Me.CHK_EnableDeleteOnly.Size = New System.Drawing.Size(168, 16)
        Me.CHK_EnableDeleteOnly.TabIndex = 1
        Me.CHK_EnableDeleteOnly.Text = "Enable Delete Only Feature"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(416, 248)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 16)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "(Hours)"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(64, 728)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 16)
        Me.Label12.TabIndex = 73
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(64, 672)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 16)
        Me.Label10.TabIndex = 70
        '
        'Tab_StandardConfig
        '
        Me.Tab_StandardConfig.Controls.Add(Me.TabControl2)
        Me.Tab_StandardConfig.Controls.Add(Me.Label12)
        Me.Tab_StandardConfig.Controls.Add(Me.Label10)
        Me.Tab_StandardConfig.Controls.Add(Me.TextBox6)
        Me.Tab_StandardConfig.Controls.Add(Me.Label11)
        Me.Tab_StandardConfig.Location = New System.Drawing.Point(4, 22)
        Me.Tab_StandardConfig.Name = "Tab_StandardConfig"
        Me.Tab_StandardConfig.Size = New System.Drawing.Size(612, 332)
        Me.Tab_StandardConfig.TabIndex = 0
        Me.Tab_StandardConfig.Text = "Standard Config"
        Me.Tab_StandardConfig.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl2.Controls.Add(Me.Tab_SpecificDIR)
        Me.TabControl2.Controls.Add(Me.Tab_StandardSettings)
        Me.TabControl2.Controls.Add(Me.Tab_LogSettings)
        Me.TabControl2.Controls.Add(Me.Tab_AdvConfig)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(0, 0)
        Me.TabControl2.Multiline = True
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(612, 332)
        Me.TabControl2.TabIndex = 83
        '
        'Tab_SpecificDIR
        '
        Me.Tab_SpecificDIR.Controls.Add(Me.PNL_SpecificDirectories)
        Me.Tab_SpecificDIR.Location = New System.Drawing.Point(4, 4)
        Me.Tab_SpecificDIR.Name = "Tab_SpecificDIR"
        Me.Tab_SpecificDIR.Size = New System.Drawing.Size(604, 305)
        Me.Tab_SpecificDIR.TabIndex = 3
        Me.Tab_SpecificDIR.Text = "Specific Directories"
        '
        'PNL_SpecificDirectories
        '
        Me.PNL_SpecificDirectories.Controls.Add(Me.SpecDG)
        Me.PNL_SpecificDirectories.Controls.Add(Me.EasyConfig_BTN)
        Me.PNL_SpecificDirectories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNL_SpecificDirectories.Location = New System.Drawing.Point(0, 0)
        Me.PNL_SpecificDirectories.Name = "PNL_SpecificDirectories"
        Me.PNL_SpecificDirectories.Size = New System.Drawing.Size(604, 305)
        Me.PNL_SpecificDirectories.TabIndex = 86
        '
        'SpecDG
        '
        Me.SpecDG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SpecDG.CaptionText = "Monitored Specific Directories"
        Me.SpecDG.DataMember = ""
        Me.SpecDG.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.SpecDG.Location = New System.Drawing.Point(8, 8)
        Me.SpecDG.Name = "SpecDG"
        Me.SpecDG.Size = New System.Drawing.Size(580, 265)
        Me.SpecDG.TabIndex = 82
        '
        'Tab_StandardSettings
        '
        Me.Tab_StandardSettings.Controls.Add(Me.PNL_DeleteSettings)
        Me.Tab_StandardSettings.Controls.Add(Me.PNL_ZipSettings)
        Me.Tab_StandardSettings.Location = New System.Drawing.Point(4, 4)
        Me.Tab_StandardSettings.Name = "Tab_StandardSettings"
        Me.Tab_StandardSettings.Size = New System.Drawing.Size(604, 306)
        Me.Tab_StandardSettings.TabIndex = 1
        Me.Tab_StandardSettings.Text = "Standard Settings"
        '
        'PNL_DeleteSettings
        '
        Me.PNL_DeleteSettings.Controls.Add(Me.Label36)
        Me.PNL_DeleteSettings.Controls.Add(Me.CHK_EnableDelete)
        Me.PNL_DeleteSettings.Controls.Add(Me.Label9)
        Me.PNL_DeleteSettings.Controls.Add(Me.Label17)
        Me.PNL_DeleteSettings.Controls.Add(Me.DeleteRetentionPeriod_TXT)
        Me.PNL_DeleteSettings.Location = New System.Drawing.Point(16, 176)
        Me.PNL_DeleteSettings.Name = "PNL_DeleteSettings"
        Me.PNL_DeleteSettings.Size = New System.Drawing.Size(507, 72)
        Me.PNL_DeleteSettings.TabIndex = 1
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(13, 29)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(403, 42)
        Me.Label36.TabIndex = 91
        Me.Label36.Text = resources.GetString("Label36.Text")
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(430, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 19)
        Me.Label17.TabIndex = 89
        Me.Label17.Text = "(Hours)"
        '
        'DeleteRetentionPeriod_TXT
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.DeleteRetentionPeriod_TXT, True)
        Me.DataValidator1.SetDataType(Me.DeleteRetentionPeriod_TXT, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.DeleteRetentionPeriod_TXT, "")
        Me.DeleteRetentionPeriod_TXT.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.DeleteRetentionPeriod_TXT.Location = New System.Drawing.Point(384, 9)
        Me.DataValidator1.SetMaxValue(Me.DeleteRetentionPeriod_TXT, "")
        Me.DataValidator1.SetMinValue(Me.DeleteRetentionPeriod_TXT, "")
        Me.DeleteRetentionPeriod_TXT.Name = "DeleteRetentionPeriod_TXT"
        Me.DeleteRetentionPeriod_TXT.ReadOnly = True
        Me.DataValidator1.SetRegularExpression(Me.DeleteRetentionPeriod_TXT, "")
        Me.DataValidator1.SetRequired(Me.DeleteRetentionPeriod_TXT, False)
        Me.DeleteRetentionPeriod_TXT.Size = New System.Drawing.Size(40, 20)
        Me.DeleteRetentionPeriod_TXT.TabIndex = 1
        Me.DeleteRetentionPeriod_TXT.Text = "0"
        '
        'PNL_ZipSettings
        '
        Me.PNL_ZipSettings.Controls.Add(Me.GroupBox2)
        Me.PNL_ZipSettings.Controls.Add(Me.Label8)
        Me.PNL_ZipSettings.Controls.Add(Me.CHK_EnableZip)
        Me.PNL_ZipSettings.Controls.Add(Me.Label16)
        Me.PNL_ZipSettings.Controls.Add(Me.DeleteOrginalCHK)
        Me.PNL_ZipSettings.Controls.Add(Me.ZipRetentionPeriod_Txt)
        Me.PNL_ZipSettings.Location = New System.Drawing.Point(16, 8)
        Me.PNL_ZipSettings.Name = "PNL_ZipSettings"
        Me.PNL_ZipSettings.Size = New System.Drawing.Size(424, 160)
        Me.PNL_ZipSettings.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ZipFilePath_BTN)
        Me.GroupBox2.Controls.Add(Me.CHK_MonitorZipDIR)
        Me.GroupBox2.Controls.Add(Me.ZipCompressionCB)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.ZipFilePath_TXT)
        Me.GroupBox2.Controls.Add(Me.ZipPathCustom_RAD)
        Me.GroupBox2.Controls.Add(Me.ZipPathOrg_RAD)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 104)
        Me.GroupBox2.TabIndex = 89
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "*ZipFilePath Section - where archived files are stored."
        '
        'CHK_MonitorZipDIR
        '
        Me.CHK_MonitorZipDIR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHK_MonitorZipDIR.Location = New System.Drawing.Point(8, 16)
        Me.CHK_MonitorZipDIR.Name = "CHK_MonitorZipDIR"
        Me.CHK_MonitorZipDIR.Size = New System.Drawing.Size(208, 24)
        Me.CHK_MonitorZipDIR.TabIndex = 2
        Me.CHK_MonitorZipDIR.Text = "Monitor ZipFilePath Directory"
        '
        'ZipCompressionCB
        '
        Me.ZipCompressionCB.Items.AddRange(New Object() {"None", "Low", "Med", "High"})
        Me.ZipCompressionCB.Location = New System.Drawing.Point(232, 72)
        Me.ZipCompressionCB.Name = "ZipCompressionCB"
        Me.ZipCompressionCB.Size = New System.Drawing.Size(112, 22)
        Me.ZipCompressionCB.TabIndex = 8
        Me.ZipCompressionCB.Text = "Med"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(232, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 16)
        Me.Label14.TabIndex = 84
        Me.Label14.Text = "Zip Compression Level"
        '
        'ZipFilePath_TXT
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.ZipFilePath_TXT, True)
        Me.DataValidator1.SetDataType(Me.ZipFilePath_TXT, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.ZipFilePath_TXT, "")
        Me.ZipFilePath_TXT.Location = New System.Drawing.Point(16, 72)
        Me.DataValidator1.SetMaxValue(Me.ZipFilePath_TXT, "")
        Me.DataValidator1.SetMinValue(Me.ZipFilePath_TXT, "")
        Me.ZipFilePath_TXT.Name = "ZipFilePath_TXT"
        Me.DataValidator1.SetRegularExpression(Me.ZipFilePath_TXT, "")
        Me.DataValidator1.SetRequired(Me.ZipFilePath_TXT, False)
        Me.ZipFilePath_TXT.Size = New System.Drawing.Size(168, 20)
        Me.ZipFilePath_TXT.TabIndex = 6
        '
        'ZipPathCustom_RAD
        '
        Me.ZipPathCustom_RAD.Location = New System.Drawing.Point(8, 56)
        Me.ZipPathCustom_RAD.Name = "ZipPathCustom_RAD"
        Me.ZipPathCustom_RAD.Size = New System.Drawing.Size(224, 16)
        Me.ZipPathCustom_RAD.TabIndex = 5
        Me.ZipPathCustom_RAD.Text = "Archive files to an alternate directory"
        '
        'ZipPathOrg_RAD
        '
        Me.ZipPathOrg_RAD.Location = New System.Drawing.Point(8, 40)
        Me.ZipPathOrg_RAD.Name = "ZipPathOrg_RAD"
        Me.ZipPathOrg_RAD.Size = New System.Drawing.Size(224, 16)
        Me.ZipPathOrg_RAD.TabIndex = 4
        Me.ZipPathOrg_RAD.Text = "Archive files in original log file directory"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(288, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 16)
        Me.Label16.TabIndex = 88
        Me.Label16.Text = "(Hours)"
        '
        'DeleteOrginalCHK
        '
        Me.DeleteOrginalCHK.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DeleteOrginalCHK.Location = New System.Drawing.Point(16, 32)
        Me.DeleteOrginalCHK.Name = "DeleteOrginalCHK"
        Me.DeleteOrginalCHK.Size = New System.Drawing.Size(208, 16)
        Me.DeleteOrginalCHK.TabIndex = 1
        Me.DeleteOrginalCHK.Text = "Delete Original Log File After Zipped"
        '
        'ZipRetentionPeriod_Txt
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.ZipRetentionPeriod_Txt, True)
        Me.DataValidator1.SetDataType(Me.ZipRetentionPeriod_Txt, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.ZipRetentionPeriod_Txt, "")
        Me.ZipRetentionPeriod_Txt.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ZipRetentionPeriod_Txt.Location = New System.Drawing.Point(240, 32)
        Me.DataValidator1.SetMaxValue(Me.ZipRetentionPeriod_Txt, "")
        Me.DataValidator1.SetMinValue(Me.ZipRetentionPeriod_Txt, "")
        Me.ZipRetentionPeriod_Txt.Name = "ZipRetentionPeriod_Txt"
        Me.ZipRetentionPeriod_Txt.ReadOnly = True
        Me.DataValidator1.SetRegularExpression(Me.ZipRetentionPeriod_Txt, "")
        Me.DataValidator1.SetRequired(Me.ZipRetentionPeriod_Txt, False)
        Me.ZipRetentionPeriod_Txt.Size = New System.Drawing.Size(40, 20)
        Me.ZipRetentionPeriod_Txt.TabIndex = 3
        Me.ZipRetentionPeriod_Txt.Text = "0"
        '
        'Tab_LogSettings
        '
        Me.Tab_LogSettings.Controls.Add(Me.PNL_LogSettings)
        Me.Tab_LogSettings.Location = New System.Drawing.Point(4, 4)
        Me.Tab_LogSettings.Name = "Tab_LogSettings"
        Me.Tab_LogSettings.Size = New System.Drawing.Size(604, 306)
        Me.Tab_LogSettings.TabIndex = 2
        Me.Tab_LogSettings.Text = "Log/Service Settings"
        '
        'PNL_LogSettings
        '
        Me.PNL_LogSettings.Controls.Add(Me.Label7)
        Me.PNL_LogSettings.Controls.Add(Me.LogDirPath_TXT)
        Me.PNL_LogSettings.Controls.Add(Me.LogDirBTN)
        Me.PNL_LogSettings.Controls.Add(Me.SerDG)
        Me.PNL_LogSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNL_LogSettings.Location = New System.Drawing.Point(0, 0)
        Me.PNL_LogSettings.Name = "PNL_LogSettings"
        Me.PNL_LogSettings.Size = New System.Drawing.Size(604, 306)
        Me.PNL_LogSettings.TabIndex = 86
        '
        'LogDirPath_TXT
        '
        Me.LogDirPath_TXT.BackColor = System.Drawing.SystemColors.Window
        Me.DataValidator1.SetCustomValidationEnabled(Me.LogDirPath_TXT, True)
        Me.DataValidator1.SetDataType(Me.LogDirPath_TXT, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.LogDirPath_TXT, "")
        Me.LogDirPath_TXT.Location = New System.Drawing.Point(8, 24)
        Me.DataValidator1.SetMaxValue(Me.LogDirPath_TXT, "")
        Me.DataValidator1.SetMinValue(Me.LogDirPath_TXT, "")
        Me.LogDirPath_TXT.Name = "LogDirPath_TXT"
        Me.DataValidator1.SetRegularExpression(Me.LogDirPath_TXT, "")
        Me.DataValidator1.SetRequired(Me.LogDirPath_TXT, False)
        Me.LogDirPath_TXT.Size = New System.Drawing.Size(400, 20)
        Me.LogDirPath_TXT.TabIndex = 76
        '
        'SerDG
        '
        Me.SerDG.CaptionText = "Service Interval"
        Me.SerDG.DataMember = ""
        Me.SerDG.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.SerDG.Location = New System.Drawing.Point(8, 56)
        Me.SerDG.Name = "SerDG"
        Me.SerDG.Size = New System.Drawing.Size(432, 176)
        Me.SerDG.TabIndex = 85
        '
        'Tab_AdvConfig
        '
        Me.Tab_AdvConfig.Controls.Add(Me.PNL_AdvancedDIR)
        Me.Tab_AdvConfig.Location = New System.Drawing.Point(4, 4)
        Me.Tab_AdvConfig.Name = "Tab_AdvConfig"
        Me.Tab_AdvConfig.Size = New System.Drawing.Size(604, 306)
        Me.Tab_AdvConfig.TabIndex = 0
        Me.Tab_AdvConfig.Text = "Advanced Dir Config"
        '
        'PNL_AdvancedDIR
        '
        Me.PNL_AdvancedDIR.Controls.Add(Me.DIRDG)
        Me.PNL_AdvancedDIR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNL_AdvancedDIR.Location = New System.Drawing.Point(0, 0)
        Me.PNL_AdvancedDIR.Name = "PNL_AdvancedDIR"
        Me.PNL_AdvancedDIR.Size = New System.Drawing.Size(604, 306)
        Me.PNL_AdvancedDIR.TabIndex = 82
        '
        'DIRDG
        '
        Me.DIRDG.CaptionText = "Monitored Entire Directory Structures (Recursive)"
        Me.DIRDG.DataMember = ""
        Me.DIRDG.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DIRDG.Location = New System.Drawing.Point(8, 8)
        Me.DIRDG.Name = "DIRDG"
        Me.DIRDG.Size = New System.Drawing.Size(649, 253)
        Me.DIRDG.TabIndex = 81
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.SystemColors.Window
        Me.DataValidator1.SetCustomValidationEnabled(Me.TextBox6, True)
        Me.DataValidator1.SetDataType(Me.TextBox6, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.TextBox6, "")
        Me.TextBox6.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox6.Location = New System.Drawing.Point(64, 760)
        Me.DataValidator1.SetMaxValue(Me.TextBox6, "")
        Me.DataValidator1.SetMinValue(Me.TextBox6, "")
        Me.TextBox6.Name = "TextBox6"
        Me.DataValidator1.SetRegularExpression(Me.TextBox6, "")
        Me.DataValidator1.SetRequired(Me.TextBox6, False)
        Me.TextBox6.Size = New System.Drawing.Size(128, 20)
        Me.TextBox6.TabIndex = 74
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.Tab_StandardConfig)
        Me.TabControl1.Controls.Add(Me.Tab_MailSettings)
        Me.TabControl1.Controls.Add(Me.Tab_SMTPConfig)
        Me.TabControl1.Controls.Add(Me.Tab_DeleteDIR)
        Me.TabControl1.Controls.Add(Me.Tab_FileNaming)
        Me.TabControl1.Controls.Add(Me.TAB_AutoAddOptions)
        Me.TabControl1.Controls.Add(Me.TAB_ZipDirectories)
        Me.TabControl1.ItemSize = New System.Drawing.Size(0, 18)
        Me.TabControl1.Location = New System.Drawing.Point(0, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(620, 358)
        Me.TabControl1.TabIndex = 0
        '
        'Tab_MailSettings
        '
        Me.Tab_MailSettings.Controls.Add(Me.PNL_MailSettings)
        Me.Tab_MailSettings.Location = New System.Drawing.Point(4, 22)
        Me.Tab_MailSettings.Name = "Tab_MailSettings"
        Me.Tab_MailSettings.Size = New System.Drawing.Size(612, 332)
        Me.Tab_MailSettings.TabIndex = 3
        Me.Tab_MailSettings.Text = "Mail Settings"
        Me.Tab_MailSettings.UseVisualStyleBackColor = True
        '
        'PNL_MailSettings
        '
        Me.PNL_MailSettings.Controls.Add(Me.Label33)
        Me.PNL_MailSettings.Controls.Add(Me.PasswordEntryTxt2)
        Me.PNL_MailSettings.Controls.Add(Me.CHK_EnableMailAuth)
        Me.PNL_MailSettings.Controls.Add(Me.MailServer_TXT)
        Me.PNL_MailSettings.Controls.Add(Me.MailPWD_TXT)
        Me.PNL_MailSettings.Controls.Add(Me.MailSubject_TXT)
        Me.PNL_MailSettings.Controls.Add(Me.MailFrom_TXT)
        Me.PNL_MailSettings.Controls.Add(Me.MailPortNumber_NumUPDOWN)
        Me.PNL_MailSettings.Controls.Add(Me.MailTo_TXT)
        Me.PNL_MailSettings.Controls.Add(Me.MailUID_TXT)
        Me.PNL_MailSettings.Controls.Add(Me.Label13)
        Me.PNL_MailSettings.Controls.Add(Me.Label6)
        Me.PNL_MailSettings.Controls.Add(Me.Label5)
        Me.PNL_MailSettings.Controls.Add(Me.Label4)
        Me.PNL_MailSettings.Controls.Add(Me.Label3)
        Me.PNL_MailSettings.Controls.Add(Me.Label2)
        Me.PNL_MailSettings.Controls.Add(Me.Label1)
        Me.PNL_MailSettings.Controls.Add(Me.CHK_SendMailReport)
        Me.PNL_MailSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNL_MailSettings.Location = New System.Drawing.Point(0, 0)
        Me.PNL_MailSettings.Name = "PNL_MailSettings"
        Me.PNL_MailSettings.Size = New System.Drawing.Size(612, 332)
        Me.PNL_MailSettings.TabIndex = 15
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(8, 248)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(100, 16)
        Me.Label33.TabIndex = 17
        Me.Label33.Text = "Retype Password"
        '
        'PasswordEntryTxt2
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.PasswordEntryTxt2, True)
        Me.DataValidator1.SetDataType(Me.PasswordEntryTxt2, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.PasswordEntryTxt2, "")
        Me.PasswordEntryTxt2.Location = New System.Drawing.Point(216, 248)
        Me.DataValidator1.SetMaxValue(Me.PasswordEntryTxt2, "")
        Me.DataValidator1.SetMinValue(Me.PasswordEntryTxt2, "")
        Me.PasswordEntryTxt2.Name = "PasswordEntryTxt2"
        Me.PasswordEntryTxt2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.DataValidator1.SetRegularExpression(Me.PasswordEntryTxt2, "")
        Me.DataValidator1.SetRequired(Me.PasswordEntryTxt2, False)
        Me.PasswordEntryTxt2.Size = New System.Drawing.Size(184, 20)
        Me.PasswordEntryTxt2.TabIndex = 9
        '
        'CHK_EnableMailAuth
        '
        Me.CHK_EnableMailAuth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHK_EnableMailAuth.Location = New System.Drawing.Point(8, 176)
        Me.CHK_EnableMailAuth.Name = "CHK_EnableMailAuth"
        Me.CHK_EnableMailAuth.Size = New System.Drawing.Size(224, 24)
        Me.CHK_EnableMailAuth.TabIndex = 6
        Me.CHK_EnableMailAuth.Text = "Mail Authentication (Optional)"
        '
        'MailServer_TXT
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.MailServer_TXT, True)
        Me.DataValidator1.SetDataType(Me.MailServer_TXT, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.MailServer_TXT, "")
        Me.MailServer_TXT.Location = New System.Drawing.Point(216, 88)
        Me.DataValidator1.SetMaxValue(Me.MailServer_TXT, "")
        Me.DataValidator1.SetMinValue(Me.MailServer_TXT, "")
        Me.MailServer_TXT.Name = "MailServer_TXT"
        Me.DataValidator1.SetRegularExpression(Me.MailServer_TXT, "")
        Me.DataValidator1.SetRequired(Me.MailServer_TXT, False)
        Me.MailServer_TXT.Size = New System.Drawing.Size(184, 20)
        Me.MailServer_TXT.TabIndex = 3
        '
        'MailPWD_TXT
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.MailPWD_TXT, True)
        Me.DataValidator1.SetDataType(Me.MailPWD_TXT, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.MailPWD_TXT, "")
        Me.MailPWD_TXT.Location = New System.Drawing.Point(216, 224)
        Me.DataValidator1.SetMaxValue(Me.MailPWD_TXT, "")
        Me.DataValidator1.SetMinValue(Me.MailPWD_TXT, "")
        Me.MailPWD_TXT.Name = "MailPWD_TXT"
        Me.MailPWD_TXT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.DataValidator1.SetRegularExpression(Me.MailPWD_TXT, "")
        Me.DataValidator1.SetRequired(Me.MailPWD_TXT, False)
        Me.MailPWD_TXT.Size = New System.Drawing.Size(184, 20)
        Me.MailPWD_TXT.TabIndex = 8
        '
        'MailSubject_TXT
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.MailSubject_TXT, True)
        Me.DataValidator1.SetDataType(Me.MailSubject_TXT, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.MailSubject_TXT, "")
        Me.MailSubject_TXT.Location = New System.Drawing.Point(216, 152)
        Me.DataValidator1.SetMaxValue(Me.MailSubject_TXT, "")
        Me.DataValidator1.SetMinValue(Me.MailSubject_TXT, "")
        Me.MailSubject_TXT.Name = "MailSubject_TXT"
        Me.DataValidator1.SetRegularExpression(Me.MailSubject_TXT, "")
        Me.DataValidator1.SetRequired(Me.MailSubject_TXT, False)
        Me.MailSubject_TXT.Size = New System.Drawing.Size(184, 20)
        Me.MailSubject_TXT.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 16)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Port Number"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Mail Subject"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Mail Password"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Mail User ID"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Mail Server"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "To :"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From :"
        '
        'CHK_SendMailReport
        '
        Me.CHK_SendMailReport.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHK_SendMailReport.Location = New System.Drawing.Point(8, 8)
        Me.CHK_SendMailReport.Name = "CHK_SendMailReport"
        Me.CHK_SendMailReport.Size = New System.Drawing.Size(224, 24)
        Me.CHK_SendMailReport.TabIndex = 0
        Me.CHK_SendMailReport.Text = "Send Mail Report"
        '
        'Tab_FileNaming
        '
        Me.Tab_FileNaming.Controls.Add(Me.PNL_FileNamingOptions)
        Me.Tab_FileNaming.Location = New System.Drawing.Point(4, 22)
        Me.Tab_FileNaming.Name = "Tab_FileNaming"
        Me.Tab_FileNaming.Size = New System.Drawing.Size(612, 332)
        Me.Tab_FileNaming.TabIndex = 4
        Me.Tab_FileNaming.Text = "File Naming Options"
        Me.Tab_FileNaming.UseVisualStyleBackColor = True
        '
        'PNL_FileNamingOptions
        '
        Me.PNL_FileNamingOptions.Controls.Add(Me.CustomGB)
        Me.PNL_FileNamingOptions.Controls.Add(Me.GroupBox1)
        Me.PNL_FileNamingOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNL_FileNamingOptions.Location = New System.Drawing.Point(0, 0)
        Me.PNL_FileNamingOptions.Name = "PNL_FileNamingOptions"
        Me.PNL_FileNamingOptions.Size = New System.Drawing.Size(612, 332)
        Me.PNL_FileNamingOptions.TabIndex = 0
        '
        'CustomGB
        '
        Me.CustomGB.Controls.Add(Me.Label32)
        Me.CustomGB.Controls.Add(Me.Label31)
        Me.CustomGB.Controls.Add(Me.Label30)
        Me.CustomGB.Controls.Add(Me.Label29)
        Me.CustomGB.Controls.Add(Me.Label27)
        Me.CustomGB.Controls.Add(Me.Label28)
        Me.CustomGB.Controls.Add(Me.Label25)
        Me.CustomGB.Controls.Add(Me.Label26)
        Me.CustomGB.Controls.Add(Me.TextBox2)
        Me.CustomGB.Controls.Add(Me.ComboBox2)
        Me.CustomGB.Controls.Add(Me.TextBox1)
        Me.CustomGB.Controls.Add(Me.ComboBox1)
        Me.CustomGB.Controls.Add(Me.ComboBox3)
        Me.CustomGB.Controls.Add(Me.Label24)
        Me.CustomGB.Controls.Add(Me.Label23)
        Me.CustomGB.Controls.Add(Me.Label22)
        Me.CustomGB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomGB.Location = New System.Drawing.Point(8, 112)
        Me.CustomGB.Name = "CustomGB"
        Me.CustomGB.Size = New System.Drawing.Size(448, 152)
        Me.CustomGB.TabIndex = 2
        Me.CustomGB.TabStop = False
        Me.CustomGB.Text = "Custom Format"
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(280, 80)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(152, 16)
        Me.Label32.TabIndex = 15
        Me.Label32.Text = "%DDDD% - Day (ie: Sunday)"
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(120, 24)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(208, 16)
        Me.Label31.TabIndex = 14
        Me.Label31.Text = "Date Parts"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(336, 24)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(100, 16)
        Me.Label30.TabIndex = 13
        Me.Label30.Text = "Text"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(8, 24)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(100, 16)
        Me.Label29.TabIndex = 12
        Me.Label29.Text = "Text"
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(224, 128)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(200, 16)
        Me.Label27.TabIndex = 11
        Me.Label27.Text = "%YYYY% - 4-Digit Year (ie: 2011)"
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(8, 128)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(200, 16)
        Me.Label28.TabIndex = 10
        Me.Label28.Text = "%YY% - 2-Digit Year (ie: 11)"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(136, 80)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(152, 16)
        Me.Label25.TabIndex = 9
        Me.Label25.Text = "%DD% - Day (ie: 09)"
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(8, 80)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(136, 16)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "%D% - Day (ie: 9)"
        '
        'TextBox2
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.TextBox2, True)
        Me.DataValidator1.SetDataType(Me.TextBox2, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.TextBox2, "")
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(336, 40)
        Me.DataValidator1.SetMaxValue(Me.TextBox2, "")
        Me.DataValidator1.SetMinValue(Me.TextBox2, "")
        Me.TextBox2.Name = "TextBox2"
        Me.DataValidator1.SetRegularExpression(Me.TextBox2, "[^""*|,\\/:<>{}`';()&#%?]+")
        Me.DataValidator1.SetRequired(Me.TextBox2, False)
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 4
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.Items.AddRange(New Object() {"%D%", "%DD%", "%DDDD%", "%M%", "%MM%", "%MMMM%", "%YY%", "%YYYY%"})
        Me.ComboBox2.Location = New System.Drawing.Point(192, 40)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(68, 22)
        Me.ComboBox2.TabIndex = 2
        '
        'TextBox1
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.TextBox1, True)
        Me.DataValidator1.SetDataType(Me.TextBox1, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.TextBox1, "")
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(8, 40)
        Me.DataValidator1.SetMaxValue(Me.TextBox1, "")
        Me.DataValidator1.SetMinValue(Me.TextBox1, "")
        Me.TextBox1.Name = "TextBox1"
        Me.DataValidator1.SetRegularExpression(Me.TextBox1, "[^""*|,\\/:<>{}`';()&#%?]+")
        Me.DataValidator1.SetRequired(Me.TextBox1, False)
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 0
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.Items.AddRange(New Object() {"%M% ", "%MM%", "%MMMM%", "%D%", "%DD%", "%DDDD%", "%YY%", "%YYYY%"})
        Me.ComboBox1.Location = New System.Drawing.Point(120, 40)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(64, 22)
        Me.ComboBox1.TabIndex = 1
        '
        'ComboBox3
        '
        Me.ComboBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.Items.AddRange(New Object() {"%YY%", "%YYYY%", "%D%", "%DD%", "%DDDD%", "%M%", "%MM%", "%MMMM%"})
        Me.ComboBox3.Location = New System.Drawing.Point(264, 40)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(64, 22)
        Me.ComboBox3.TabIndex = 3
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(280, 104)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(160, 16)
        Me.Label24.TabIndex = 7
        Me.Label24.Text = "%MMMM% - Month (ie: June)"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(136, 104)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(136, 16)
        Me.Label23.TabIndex = 6
        Me.Label23.Text = "%MM%    - Month (ie: 08)"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(8, 104)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(120, 16)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "%M%     - Month (ie: 8)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rad_NameOptDefault)
        Me.GroupBox1.Controls.Add(Me.Rad_NameOptCustom)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(136, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(176, 96)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Naming Options"
        '
        'Rad_NameOptDefault
        '
        Me.Rad_NameOptDefault.Checked = True
        Me.Rad_NameOptDefault.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_NameOptDefault.Location = New System.Drawing.Point(8, 24)
        Me.Rad_NameOptDefault.Name = "Rad_NameOptDefault"
        Me.Rad_NameOptDefault.Size = New System.Drawing.Size(160, 24)
        Me.Rad_NameOptDefault.TabIndex = 0
        Me.Rad_NameOptDefault.TabStop = True
        Me.Rad_NameOptDefault.Text = "Default exYYDDMM.zip"
        '
        'Rad_NameOptCustom
        '
        Me.Rad_NameOptCustom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_NameOptCustom.Location = New System.Drawing.Point(8, 56)
        Me.Rad_NameOptCustom.Name = "Rad_NameOptCustom"
        Me.Rad_NameOptCustom.Size = New System.Drawing.Size(160, 32)
        Me.Rad_NameOptCustom.TabIndex = 1
        Me.Rad_NameOptCustom.Text = "Select this and it would activate the following items to allow for a custom"
        '
        'TAB_AutoAddOptions
        '
        Me.TAB_AutoAddOptions.Controls.Add(Me.Label39)
        Me.TAB_AutoAddOptions.Controls.Add(Me.CHK_UseMetabaseRoleService)
        Me.TAB_AutoAddOptions.Controls.Add(Me.Panel1)
        Me.TAB_AutoAddOptions.Controls.Add(Me.Label38)
        Me.TAB_AutoAddOptions.Controls.Add(Me.Label35)
        Me.TAB_AutoAddOptions.Controls.Add(Me.Label34)
        Me.TAB_AutoAddOptions.Controls.Add(Me.CHK_ProcessBAK)
        Me.TAB_AutoAddOptions.Controls.Add(Me.CHK_ProcessDAT)
        Me.TAB_AutoAddOptions.Controls.Add(Me.CHK_ProcessTXT)
        Me.TAB_AutoAddOptions.Controls.Add(Me.CHK_ProcessXML)
        Me.TAB_AutoAddOptions.Controls.Add(Me.Label15)
        Me.TAB_AutoAddOptions.Controls.Add(Me.CHK_AutoAddOptions)
        Me.TAB_AutoAddOptions.Controls.Add(Me.CHK_SMTPSVC_AutoAddOptions)
        Me.TAB_AutoAddOptions.Controls.Add(Me.CHK_MSFTPSVC_AutoAddOptions)
        Me.TAB_AutoAddOptions.Controls.Add(Me.CHK_W3SVC_AutoAddOptions)
        Me.TAB_AutoAddOptions.Controls.Add(Me.txtDelimiter)
        Me.TAB_AutoAddOptions.Location = New System.Drawing.Point(4, 22)
        Me.TAB_AutoAddOptions.Name = "TAB_AutoAddOptions"
        Me.TAB_AutoAddOptions.Size = New System.Drawing.Size(612, 332)
        Me.TAB_AutoAddOptions.TabIndex = 5
        Me.TAB_AutoAddOptions.Text = "Auto-Add Options"
        Me.TAB_AutoAddOptions.UseVisualStyleBackColor = True
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(61, 172)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(0, 14)
        Me.Label39.TabIndex = 20
        '
        'CHK_UseMetabaseRoleService
        '
        Me.CHK_UseMetabaseRoleService.AutoSize = True
        Me.CHK_UseMetabaseRoleService.Location = New System.Drawing.Point(40, 120)
        Me.CHK_UseMetabaseRoleService.Name = "CHK_UseMetabaseRoleService"
        Me.CHK_UseMetabaseRoleService.Size = New System.Drawing.Size(159, 18)
        Me.CHK_UseMetabaseRoleService.TabIndex = 19
        Me.CHK_UseMetabaseRoleService.Text = "Use Metabase Role Service"
        Me.CHK_UseMetabaseRoleService.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RDO_ZipFileStoragePreference3)
        Me.Panel1.Controls.Add(Me.RDO_ZipFileStoragePreference2)
        Me.Panel1.Controls.Add(Me.RDO_ZipFileStoragePreference1)
        Me.Panel1.Location = New System.Drawing.Point(425, 46)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(151, 68)
        Me.Panel1.TabIndex = 17
        '
        'RDO_ZipFileStoragePreference3
        '
        Me.RDO_ZipFileStoragePreference3.AutoSize = True
        Me.RDO_ZipFileStoragePreference3.Location = New System.Drawing.Point(3, 42)
        Me.RDO_ZipFileStoragePreference3.Name = "RDO_ZipFileStoragePreference3"
        Me.RDO_ZipFileStoragePreference3.Size = New System.Drawing.Size(62, 18)
        Me.RDO_ZipFileStoragePreference3.TabIndex = 4
        Me.RDO_ZipFileStoragePreference3.Text = "Monthly"
        Me.RDO_ZipFileStoragePreference3.UseVisualStyleBackColor = True
        '
        'RDO_ZipFileStoragePreference2
        '
        Me.RDO_ZipFileStoragePreference2.AutoSize = True
        Me.RDO_ZipFileStoragePreference2.Location = New System.Drawing.Point(3, 21)
        Me.RDO_ZipFileStoragePreference2.Name = "RDO_ZipFileStoragePreference2"
        Me.RDO_ZipFileStoragePreference2.Size = New System.Drawing.Size(60, 18)
        Me.RDO_ZipFileStoragePreference2.TabIndex = 2
        Me.RDO_ZipFileStoragePreference2.Text = "Weekly"
        Me.RDO_ZipFileStoragePreference2.UseVisualStyleBackColor = True
        '
        'RDO_ZipFileStoragePreference1
        '
        Me.RDO_ZipFileStoragePreference1.AutoSize = True
        Me.RDO_ZipFileStoragePreference1.Checked = True
        Me.RDO_ZipFileStoragePreference1.Location = New System.Drawing.Point(3, 3)
        Me.RDO_ZipFileStoragePreference1.Name = "RDO_ZipFileStoragePreference1"
        Me.RDO_ZipFileStoragePreference1.Size = New System.Drawing.Size(48, 18)
        Me.RDO_ZipFileStoragePreference1.TabIndex = 0
        Me.RDO_ZipFileStoragePreference1.TabStop = True
        Me.RDO_ZipFileStoragePreference1.Text = "Daily"
        Me.RDO_ZipFileStoragePreference1.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(422, 23)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(154, 14)
        Me.Label38.TabIndex = 16
        Me.Label38.Text = "ZipFile Storage Preference"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(37, 23)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(217, 14)
        Me.Label35.TabIndex = 13
        Me.Label35.Text = "Auto Add IIS Sites to Configuration file"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(259, 23)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(130, 14)
        Me.Label34.TabIndex = 12
        Me.Label34.Text = "Additional File Options"
        '
        'CHK_ProcessBAK
        '
        Me.CHK_ProcessBAK.AutoSize = True
        Me.CHK_ProcessBAK.Location = New System.Drawing.Point(262, 96)
        Me.CHK_ProcessBAK.Name = "CHK_ProcessBAK"
        Me.CHK_ProcessBAK.Size = New System.Drawing.Size(91, 18)
        Me.CHK_ProcessBAK.TabIndex = 11
        Me.CHK_ProcessBAK.Text = "Process BAK"
        Me.CHK_ProcessBAK.UseVisualStyleBackColor = True
        '
        'CHK_ProcessDAT
        '
        Me.CHK_ProcessDAT.AutoSize = True
        Me.CHK_ProcessDAT.Location = New System.Drawing.Point(262, 78)
        Me.CHK_ProcessDAT.Name = "CHK_ProcessDAT"
        Me.CHK_ProcessDAT.Size = New System.Drawing.Size(89, 18)
        Me.CHK_ProcessDAT.TabIndex = 10
        Me.CHK_ProcessDAT.Text = "Process DAT"
        Me.CHK_ProcessDAT.UseVisualStyleBackColor = True
        '
        'CHK_ProcessTXT
        '
        Me.CHK_ProcessTXT.AutoSize = True
        Me.CHK_ProcessTXT.Location = New System.Drawing.Point(262, 62)
        Me.CHK_ProcessTXT.Name = "CHK_ProcessTXT"
        Me.CHK_ProcessTXT.Size = New System.Drawing.Size(88, 18)
        Me.CHK_ProcessTXT.TabIndex = 9
        Me.CHK_ProcessTXT.Text = "Process TXT"
        Me.CHK_ProcessTXT.UseVisualStyleBackColor = True
        '
        'CHK_ProcessXML
        '
        Me.CHK_ProcessXML.AutoSize = True
        Me.CHK_ProcessXML.Location = New System.Drawing.Point(262, 46)
        Me.CHK_ProcessXML.Name = "CHK_ProcessXML"
        Me.CHK_ProcessXML.Size = New System.Drawing.Size(90, 18)
        Me.CHK_ProcessXML.TabIndex = 8
        Me.CHK_ProcessXML.Text = "Process XML"
        Me.CHK_ProcessXML.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(422, 133)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 14)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Delimiter"
        '
        'CHK_AutoAddOptions
        '
        Me.CHK_AutoAddOptions.Location = New System.Drawing.Point(40, 44)
        Me.CHK_AutoAddOptions.Name = "CHK_AutoAddOptions"
        Me.CHK_AutoAddOptions.Size = New System.Drawing.Size(177, 20)
        Me.CHK_AutoAddOptions.TabIndex = 5
        Me.CHK_AutoAddOptions.Text = "Enable Auto-Add Settings"
        '
        'CHK_SMTPSVC_AutoAddOptions
        '
        Me.CHK_SMTPSVC_AutoAddOptions.Enabled = False
        Me.CHK_SMTPSVC_AutoAddOptions.Location = New System.Drawing.Point(40, 96)
        Me.CHK_SMTPSVC_AutoAddOptions.Name = "CHK_SMTPSVC_AutoAddOptions"
        Me.CHK_SMTPSVC_AutoAddOptions.Size = New System.Drawing.Size(141, 18)
        Me.CHK_SMTPSVC_AutoAddOptions.TabIndex = 2
        Me.CHK_SMTPSVC_AutoAddOptions.Text = "SMTP - (SMTPSVC)"
        '
        'CHK_MSFTPSVC_AutoAddOptions
        '
        Me.CHK_MSFTPSVC_AutoAddOptions.Enabled = False
        Me.CHK_MSFTPSVC_AutoAddOptions.Location = New System.Drawing.Point(40, 78)
        Me.CHK_MSFTPSVC_AutoAddOptions.Name = "CHK_MSFTPSVC_AutoAddOptions"
        Me.CHK_MSFTPSVC_AutoAddOptions.Size = New System.Drawing.Size(126, 21)
        Me.CHK_MSFTPSVC_AutoAddOptions.TabIndex = 1
        Me.CHK_MSFTPSVC_AutoAddOptions.Text = "FTP - (MSFTPSVC)"
        '
        'CHK_W3SVC_AutoAddOptions
        '
        Me.CHK_W3SVC_AutoAddOptions.Enabled = False
        Me.CHK_W3SVC_AutoAddOptions.Location = New System.Drawing.Point(40, 62)
        Me.CHK_W3SVC_AutoAddOptions.Name = "CHK_W3SVC_AutoAddOptions"
        Me.CHK_W3SVC_AutoAddOptions.Size = New System.Drawing.Size(141, 18)
        Me.CHK_W3SVC_AutoAddOptions.TabIndex = 0
        Me.CHK_W3SVC_AutoAddOptions.Text = "WWW - (W3SVC)"
        '
        'txtDelimiter
        '
        Me.DataValidator1.SetCustomValidationEnabled(Me.txtDelimiter, True)
        Me.DataValidator1.SetDataType(Me.txtDelimiter, IISLogsGUI.DataTypeConstants.StringType)
        Me.DataValidator1.SetDisplayName(Me.txtDelimiter, "")
        Me.txtDelimiter.Location = New System.Drawing.Point(424, 159)
        Me.DataValidator1.SetMaxValue(Me.txtDelimiter, "")
        Me.DataValidator1.SetMinValue(Me.txtDelimiter, "")
        Me.txtDelimiter.Name = "txtDelimiter"
        Me.txtDelimiter.ReadOnly = True
        Me.DataValidator1.SetRegularExpression(Me.txtDelimiter, "")
        Me.DataValidator1.SetRequired(Me.txtDelimiter, False)
        Me.txtDelimiter.Size = New System.Drawing.Size(40, 20)
        Me.txtDelimiter.TabIndex = 6
        Me.txtDelimiter.Text = "!"
        Me.txtDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TAB_ZipDirectories
        '
        Me.TAB_ZipDirectories.Controls.Add(Me.PNL_ZipDirectories)
        Me.TAB_ZipDirectories.Location = New System.Drawing.Point(4, 22)
        Me.TAB_ZipDirectories.Name = "TAB_ZipDirectories"
        Me.TAB_ZipDirectories.Size = New System.Drawing.Size(612, 332)
        Me.TAB_ZipDirectories.TabIndex = 6
        Me.TAB_ZipDirectories.Text = "Per Directory"
        Me.TAB_ZipDirectories.UseVisualStyleBackColor = True
        '
        'PNL_ZipDirectories
        '
        Me.PNL_ZipDirectories.Controls.Add(Me.CHK_EnablePerDirectory)
        Me.PNL_ZipDirectories.Controls.Add(Me.PNLHeader)
        Me.PNL_ZipDirectories.Controls.Add(Me.DG_ZipDirectories)
        Me.PNL_ZipDirectories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNL_ZipDirectories.Location = New System.Drawing.Point(0, 0)
        Me.PNL_ZipDirectories.Name = "PNL_ZipDirectories"
        Me.PNL_ZipDirectories.Size = New System.Drawing.Size(612, 332)
        Me.PNL_ZipDirectories.TabIndex = 0
        '
        'CHK_EnablePerDirectory
        '
        Me.CHK_EnablePerDirectory.AutoSize = True
        Me.CHK_EnablePerDirectory.Location = New System.Drawing.Point(8, 278)
        Me.CHK_EnablePerDirectory.Name = "CHK_EnablePerDirectory"
        Me.CHK_EnablePerDirectory.Size = New System.Drawing.Size(124, 18)
        Me.CHK_EnablePerDirectory.TabIndex = 16
        Me.CHK_EnablePerDirectory.Text = "Enable Per Directory"
        Me.CHK_EnablePerDirectory.UseVisualStyleBackColor = True
        '
        'PNLHeader
        '
        Me.PNLHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNLHeader.Location = New System.Drawing.Point(8, 3)
        Me.PNLHeader.Name = "PNLHeader"
        Me.PNLHeader.Size = New System.Drawing.Size(608, 23)
        Me.PNLHeader.TabIndex = 8
        '
        'DG_ZipDirectories
        '
        Me.DG_ZipDirectories.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DG_ZipDirectories.CaptionText = "Zip Directories"
        Me.DG_ZipDirectories.CaptionVisible = False
        Me.DG_ZipDirectories.DataMember = ""
        Me.DG_ZipDirectories.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DG_ZipDirectories.Location = New System.Drawing.Point(8, 26)
        Me.DG_ZipDirectories.Name = "DG_ZipDirectories"
        Me.DG_ZipDirectories.Size = New System.Drawing.Size(601, 206)
        Me.DG_ZipDirectories.TabIndex = 7
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.WizardMnuI, Me.MenuItem3})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.OpenMnuI, Me.SaveMnuI, Me.ExitMnuI})
        Me.MenuItem1.Text = "&File"
        '
        'OpenMnuI
        '
        Me.OpenMnuI.Index = 0
        Me.OpenMnuI.Text = "&Open"
        '
        'SaveMnuI
        '
        Me.SaveMnuI.Index = 1
        Me.SaveMnuI.Text = "S&ave"
        '
        'ExitMnuI
        '
        Me.ExitMnuI.Index = 2
        Me.ExitMnuI.Text = "E&xit"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.StartMnuI, Me.StopMnuI, Me.SetupService_MnuI})
        Me.MenuItem2.Text = "&Service"
        '
        'StartMnuI
        '
        Me.StartMnuI.Index = 0
        Me.StartMnuI.Text = "St&art"
        '
        'StopMnuI
        '
        Me.StopMnuI.Index = 1
        Me.StopMnuI.Text = "St&op"
        '
        'SetupService_MnuI
        '
        Me.SetupService_MnuI.Index = 2
        Me.SetupService_MnuI.Text = "S&etup Service"
        Me.SetupService_MnuI.Visible = False
        '
        'WizardMnuI
        '
        Me.WizardMnuI.Index = 2
        Me.WizardMnuI.Text = "&Wizard"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 3
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.HelpMnI, Me.MenuItem8, Me.AboutMnuI})
        Me.MenuItem3.Text = "&Help"
        '
        'HelpMnI
        '
        Me.HelpMnI.Index = 0
        Me.HelpMnI.Text = "&Content"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 1
        Me.MenuItem8.Text = "-"
        '
        'AboutMnuI
        '
        Me.AboutMnuI.Index = 2
        Me.AboutMnuI.Text = "&About IISLogs"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "Config"
        Me.OpenFileDialog1.FileName = "App.Config"
        Me.OpenFileDialog1.Filter = "(*.Config)|*.config"
        Me.OpenFileDialog1.RestoreDirectory = True
        Me.OpenFileDialog1.Title = "Select Config File"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Select Directory"
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "iislogshelp.chm"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "GEARSH.ico")
        Me.ImageList1.Images.SetKeyName(8, "NOTE03.ICO")
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.ToolBarButton1, Me.ToolBarButton2, Me.ToolBarButton3, Me.ToolBarButton4, Me.ToolBarButton5, Me.ToolBarButton7, Me.ToolBarButton6, Me.ToolBarButton8, Me.ToolBarButton9})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(25, 25)
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(620, 28)
        Me.ToolBar1.TabIndex = 1
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.ImageIndex = 0
        Me.ToolBarButton1.Name = "ToolBarButton1"
        Me.ToolBarButton1.ToolTipText = "Open Config File"
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.ImageIndex = 1
        Me.ToolBarButton2.Name = "ToolBarButton2"
        Me.ToolBarButton2.ToolTipText = "Save Config"
        '
        'ToolBarButton3
        '
        Me.ToolBarButton3.ImageIndex = 2
        Me.ToolBarButton3.Name = "ToolBarButton3"
        Me.ToolBarButton3.ToolTipText = "Start Service"
        '
        'ToolBarButton4
        '
        Me.ToolBarButton4.ImageIndex = 3
        Me.ToolBarButton4.Name = "ToolBarButton4"
        Me.ToolBarButton4.ToolTipText = "Stop Service"
        '
        'ToolBarButton5
        '
        Me.ToolBarButton5.ImageIndex = 4
        Me.ToolBarButton5.Name = "ToolBarButton5"
        Me.ToolBarButton5.ToolTipText = "Exit this application"
        '
        'ToolBarButton7
        '
        Me.ToolBarButton7.ImageIndex = 6
        Me.ToolBarButton7.Name = "ToolBarButton7"
        Me.ToolBarButton7.ToolTipText = "Wizard"
        '
        'ToolBarButton6
        '
        Me.ToolBarButton6.ImageIndex = 5
        Me.ToolBarButton6.Name = "ToolBarButton6"
        Me.ToolBarButton6.ToolTipText = "Click for Help"
        '
        'ToolBarButton8
        '
        Me.ToolBarButton8.ImageIndex = 7
        Me.ToolBarButton8.Name = "ToolBarButton8"
        Me.ToolBarButton8.ToolTipText = "Execute IISLogsSVC"
        '
        'ToolBarButton9
        '
        Me.ToolBarButton9.ImageIndex = 8
        Me.ToolBarButton9.Name = "ToolBarButton9"
        Me.ToolBarButton9.ToolTipText = "Execute IISLogsEXE"
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DC_DirectoryName, Me.DC_ZipFile, Me.DC_ZipRetentionPeriod, Me.DeleteOriginalFile, Me.DC_DeleteFile, Me.DC_DeleteRetentionPeriod, Me.DC_Recursive, Me.DC_ProcessRootFolderRecursive, Me.DC_ZipFilePath, Me.DC_IncludeComputerName, Me.DC_ProcessUnknownExtensions, Me.DC_ProcessTXT, Me.DC_ProcessBAK, Me.DC_ProcessDAT, Me.DC_ProcessXML, Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8, Me.DataColumn9, Me.DataColumn10, Me.DataColumn11, Me.DataColumn12})
        Me.DataTable1.TableName = "Table1"
        '
        'DC_DirectoryName
        '
        Me.DC_DirectoryName.AllowDBNull = False
        Me.DC_DirectoryName.ColumnName = "DirectoryName"
        Me.DC_DirectoryName.DefaultValue = ""
        '
        'DC_ZipFile
        '
        Me.DC_ZipFile.AllowDBNull = False
        Me.DC_ZipFile.ColumnName = "ZipFile"
        Me.DC_ZipFile.DataType = GetType(Boolean)
        Me.DC_ZipFile.DefaultValue = False
        '
        'DC_ZipRetentionPeriod
        '
        Me.DC_ZipRetentionPeriod.AllowDBNull = False
        Me.DC_ZipRetentionPeriod.ColumnName = "ZipRetentionPeriod"
        Me.DC_ZipRetentionPeriod.DataType = GetType(Integer)
        Me.DC_ZipRetentionPeriod.DefaultValue = 0
        '
        'DeleteOriginalFile
        '
        Me.DeleteOriginalFile.AllowDBNull = False
        Me.DeleteOriginalFile.ColumnName = "DeleteOriginalFile"
        Me.DeleteOriginalFile.DataType = GetType(Boolean)
        Me.DeleteOriginalFile.DefaultValue = False
        '
        'DC_DeleteFile
        '
        Me.DC_DeleteFile.AllowDBNull = False
        Me.DC_DeleteFile.ColumnName = "DeleteFile"
        Me.DC_DeleteFile.DataType = GetType(Boolean)
        Me.DC_DeleteFile.DefaultValue = False
        '
        'DC_DeleteRetentionPeriod
        '
        Me.DC_DeleteRetentionPeriod.AllowDBNull = False
        Me.DC_DeleteRetentionPeriod.ColumnName = "DeleteRetentionPeriod"
        Me.DC_DeleteRetentionPeriod.DataType = GetType(Integer)
        Me.DC_DeleteRetentionPeriod.DefaultValue = 0
        '
        'DC_Recursive
        '
        Me.DC_Recursive.AllowDBNull = False
        Me.DC_Recursive.ColumnName = "Recursive"
        Me.DC_Recursive.DataType = GetType(Boolean)
        Me.DC_Recursive.DefaultValue = False
        '
        'DC_ProcessRootFolderRecursive
        '
        Me.DC_ProcessRootFolderRecursive.AllowDBNull = False
        Me.DC_ProcessRootFolderRecursive.ColumnName = "ProcessRootFolderRecursive"
        Me.DC_ProcessRootFolderRecursive.DataType = GetType(Boolean)
        Me.DC_ProcessRootFolderRecursive.DefaultValue = False
        '
        'DC_ZipFilePath
        '
        Me.DC_ZipFilePath.AllowDBNull = False
        Me.DC_ZipFilePath.ColumnName = "ZipFilePath"
        Me.DC_ZipFilePath.DefaultValue = "local"
        '
        'DC_IncludeComputerName
        '
        Me.DC_IncludeComputerName.AllowDBNull = False
        Me.DC_IncludeComputerName.ColumnName = "IncludeComputerName"
        Me.DC_IncludeComputerName.DataType = GetType(Boolean)
        Me.DC_IncludeComputerName.DefaultValue = False
        '
        'DC_ProcessUnknownExtensions
        '
        Me.DC_ProcessUnknownExtensions.AllowDBNull = False
        Me.DC_ProcessUnknownExtensions.ColumnName = "ProcessUnknownExtensions"
        Me.DC_ProcessUnknownExtensions.DataType = GetType(Boolean)
        Me.DC_ProcessUnknownExtensions.DefaultValue = False
        '
        'DC_ProcessTXT
        '
        Me.DC_ProcessTXT.AllowDBNull = False
        Me.DC_ProcessTXT.ColumnName = "ProcessTXT"
        Me.DC_ProcessTXT.DataType = GetType(Boolean)
        Me.DC_ProcessTXT.DefaultValue = False
        '
        'DC_ProcessBAK
        '
        Me.DC_ProcessBAK.AllowDBNull = False
        Me.DC_ProcessBAK.ColumnName = "ProcessBAK"
        Me.DC_ProcessBAK.DataType = GetType(Boolean)
        Me.DC_ProcessBAK.DefaultValue = False
        '
        'DC_ProcessDAT
        '
        Me.DC_ProcessDAT.AllowDBNull = False
        Me.DC_ProcessDAT.ColumnName = "ProcessDAT"
        Me.DC_ProcessDAT.DataType = GetType(Boolean)
        Me.DC_ProcessDAT.DefaultValue = False
        '
        'DC_ProcessXML
        '
        Me.DC_ProcessXML.AllowDBNull = False
        Me.DC_ProcessXML.ColumnName = "ProcessXML"
        Me.DC_ProcessXML.DataType = GetType(Boolean)
        Me.DC_ProcessXML.DefaultValue = False
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "Button"
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "Button2"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "NamingConvention"
        Me.DataColumn3.DefaultValue = "Default"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "Delimiter"
        Me.DataColumn4.DefaultValue = "!"
        '
        'DataColumn5
        '
        Me.DataColumn5.AllowDBNull = False
        Me.DataColumn5.ColumnName = "ProcessEXE"
        Me.DataColumn5.DataType = GetType(Boolean)
        Me.DataColumn5.DefaultValue = False
        '
        'DataColumn6
        '
        Me.DataColumn6.AllowDBNull = False
        Me.DataColumn6.ColumnName = "ProcessMSP"
        Me.DataColumn6.DataType = GetType(Boolean)
        Me.DataColumn6.DefaultValue = False
        '
        'DataColumn7
        '
        Me.DataColumn7.AllowDBNull = False
        Me.DataColumn7.ColumnName = "ProcessDLL"
        Me.DataColumn7.DataType = GetType(Boolean)
        Me.DataColumn7.DefaultValue = False
        '
        'DataColumn8
        '
        Me.DataColumn8.AllowDBNull = False
        Me.DataColumn8.ColumnName = "ProcessINI"
        Me.DataColumn8.DataType = GetType(Boolean)
        Me.DataColumn8.DefaultValue = False
        '
        'DataColumn9
        '
        Me.DataColumn9.AllowDBNull = False
        Me.DataColumn9.ColumnName = "ProcessCFG"
        Me.DataColumn9.DataType = GetType(Boolean)
        Me.DataColumn9.DefaultValue = False
        '
        'DataColumn10
        '
        Me.DataColumn10.AllowDBNull = False
        Me.DataColumn10.ColumnName = "ProcessTMP"
        Me.DataColumn10.DataType = GetType(Boolean)
        Me.DataColumn10.DefaultValue = False
        '
        'DataColumn11
        '
        Me.DataColumn11.ColumnName = "LogsDWM"
        Me.DataColumn11.DataType = GetType(Integer)
        Me.DataColumn11.DefaultValue = 1
        '
        'DataColumn12
        '
        Me.DataColumn12.AllowDBNull = False
        Me.DataColumn12.ColumnName = "PreserveDirPath"
        Me.DataColumn12.DataType = GetType(Boolean)
        Me.DataColumn12.DefaultValue = True
        '
        'DataValidator1
        '
        Me.DataValidator1.DisplayControl = Nothing
        Me.DataValidator1.ErrorProvider = Me.ErrorProvider1
        Me.DataValidator1.InvalidBackColor = System.Drawing.Color.Empty
        Me.DataValidator1.TooltipProvider = Me.ToolTip1
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(620, 398)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IISLogs Configuration"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MailPortNumber_NumUPDOWN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_SMTPConfig.ResumeLayout(False)
        Me.PNL_SMTPSettings.ResumeLayout(False)
        Me.PNL_SMTPSettings.PerformLayout()
        CType(Me.SMTPDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_DeleteDIR.ResumeLayout(False)
        Me.PNL_DeleteDirSettings.ResumeLayout(False)
        Me.PNL_DeleteDirSettings.PerformLayout()
        CType(Me.DeleteDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_StandardConfig.ResumeLayout(False)
        Me.Tab_StandardConfig.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.Tab_SpecificDIR.ResumeLayout(False)
        Me.PNL_SpecificDirectories.ResumeLayout(False)
        CType(Me.SpecDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_StandardSettings.ResumeLayout(False)
        Me.PNL_DeleteSettings.ResumeLayout(False)
        Me.PNL_DeleteSettings.PerformLayout()
        Me.PNL_ZipSettings.ResumeLayout(False)
        Me.PNL_ZipSettings.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Tab_LogSettings.ResumeLayout(False)
        Me.PNL_LogSettings.ResumeLayout(False)
        Me.PNL_LogSettings.PerformLayout()
        CType(Me.SerDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_AdvConfig.ResumeLayout(False)
        Me.PNL_AdvancedDIR.ResumeLayout(False)
        CType(Me.DIRDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.Tab_MailSettings.ResumeLayout(False)
        Me.PNL_MailSettings.ResumeLayout(False)
        Me.PNL_MailSettings.PerformLayout()
        Me.Tab_FileNaming.ResumeLayout(False)
        Me.PNL_FileNamingOptions.ResumeLayout(False)
        Me.CustomGB.ResumeLayout(False)
        Me.CustomGB.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TAB_AutoAddOptions.ResumeLayout(False)
        Me.TAB_AutoAddOptions.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TAB_ZipDirectories.ResumeLayout(False)
        Me.PNL_ZipDirectories.ResumeLayout(False)
        Me.PNL_ZipDirectories.PerformLayout()
        CType(Me.DG_ZipDirectories, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim AppRW As New AppConfigReadWriteClass.ReadWrite
    Private DataRecord As New Collection
    Private _Startup As Boolean = True

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_EnableZip.CheckedChanged
        If CHK_EnableZip.Checked = True Then
            RemoveHandler CHK_EnableZip.CheckedChanged, AddressOf CheckBox1_CheckedChanged
            Me.CHK_EnableZip.Checked = Me.ShowPolicy(PolicyType.Zip, Me.CHK_EnableZip.Checked)
            AddHandler CHK_EnableZip.CheckedChanged, AddressOf CheckBox1_CheckedChanged

            If CHK_EnableZip.Checked = True Then
                Me.ZipRetentionPeriod_Txt.ReadOnly = False
                Me.DeleteOrginalCHK.Enabled = True
            Else
                ZipRetentionPeriod_Txt.ReadOnly = True
                Me.ZipRetentionPeriod_Txt.Text = 0
                Me.DeleteOrginalCHK.Checked = False
            End If
        Else
            ZipRetentionPeriod_Txt.ReadOnly = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_EnableDelete.CheckedChanged
        If CHK_EnableDelete.Checked = True Then
            RemoveHandler CHK_EnableDelete.CheckedChanged, AddressOf CheckBox2_CheckedChanged
            Me.CHK_EnableDelete.Checked = ShowPolicy(PolicyType.Delete, Me.CHK_EnableDelete.Checked)
            AddHandler CHK_EnableDelete.CheckedChanged, AddressOf CheckBox2_CheckedChanged
            If Me.CHK_EnableDelete.Checked = True Then
                Me.DeleteRetentionPeriod_TXT.ReadOnly = False
            Else
                DeleteRetentionPeriod_TXT.ReadOnly = True
            End If
        Else
            DeleteRetentionPeriod_TXT.ReadOnly = True
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_EnableSMTP.CheckedChanged
        If CHK_EnableSMTP.Checked = True Then
            RemoveHandler CHK_EnableSMTP.CheckedChanged, AddressOf CheckBox5_CheckedChanged
            Me.CHK_EnableSMTP.Checked = Me.ShowPolicy(PolicyType.Delete, Me.CHK_EnableSMTP.Checked)
            AddHandler CHK_EnableSMTP.CheckedChanged, AddressOf CheckBox5_CheckedChanged

            If CHK_EnableSMTP.Checked = True Then
                Me.STMPRetentionPeriod_TXT.ReadOnly = False
            Else
                STMPRetentionPeriod_TXT.ReadOnly = True
            End If
        Else
            STMPRetentionPeriod_TXT.ReadOnly = True
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_EnableDeleteOnly.CheckedChanged
        If CHK_EnableDeleteOnly.Checked = True Then
            RemoveHandler CHK_EnableDeleteOnly.CheckedChanged, AddressOf CheckBox6_CheckedChanged
            Me.CHK_EnableDeleteOnly.Checked = Me.ShowPolicy(PolicyType.Delete, Me.CHK_EnableDeleteOnly.Checked)
            AddHandler CHK_EnableDeleteOnly.CheckedChanged, AddressOf CheckBox6_CheckedChanged
            If CHK_EnableDeleteOnly.Checked = True Then
                Me.DeleteOnlyRetentionPeriod_TXT.ReadOnly = False
            Else
                DeleteOnlyRetentionPeriod_TXT.ReadOnly = True
            End If
        Else
            DeleteOnlyRetentionPeriod_TXT.ReadOnly = True
        End If
    End Sub

    Private Function ServiceExists() As Boolean
        For Each service As System.ServiceProcess.ServiceController In ServiceProcess.ServiceController.GetServices
            If Me.ServiceController1.ServiceName.ToLower.Trim = service.ServiceName.ToLower.Trim Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub SetServiceStates()
        If ServiceExists() = True Then
            If Not Me.ServiceController1.ServiceName Is Nothing Then
                If ServiceController1.ServiceName.Trim <> "" Then
                    If Me.ServiceController1.Status = ServiceProcess.ServiceControllerStatus.Stopped Then
                        Me.StartMnuI.Enabled = True
                        Me.StopMnuI.Enabled = False
                    Else
                        Me.StartMnuI.Enabled = False
                        Me.StopMnuI.Enabled = True
                    End If
                End If
            End If
        Else
            Me.StartMnuI.Enabled = False
            Me.StopMnuI.Enabled = False
        End If
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TabControl1.Enabled = False
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.HelpProvider1.HelpNamespace = Application.StartupPath & "\iislogshelp.chm"
        Me.HelpProvider1.SetShowHelp(Me, True)

        Dim DT As New DataTable("ValueDT")
        DT.Columns.Add(New DataColumn("Value"))
        DT.Columns.Add(New DataColumn("Button"))

        Me.SerDG.DataSource = DT.Clone
        Me.SpecDG.DataSource = DT.Clone
        Me.SMTPDG.DataSource = DT.Clone
        Me.DIRDG.DataSource = DT.Clone
        Me.DeleteDG.DataSource = DT.Clone

        SetupGrid(Me.SerDG, True)
        SetupGrid(Me.SpecDG)
        SetupGrid(SMTPDG)
        SetupGrid(DIRDG)
        SetupGrid(DeleteDG)

        'Added by Joe 11/26/2006
        Me.SetupZipDirGrid()
        Me.SetupZipDirPnl()

        Me.OpenMnuI_Click(Me, New EventArgs)
        _Startup = False
        'Dim Reg As Microsoft.Win32.RegistryKey
        'Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\IISLOGS")
        'If Reg Is Nothing Then

        Dim Reg As Boolean
        Reg = CheckQuickWizardVerifyFile()
        If Reg = False Then
            Me.WizardMnuI_Click(Me, e)
        End If

        Me.Size = New Size(630, 420)
    End Sub

    Function CheckQuickWizardVerifyFile() As Boolean
        If System.IO.File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) & "\Logs\QS\QuickWizardComplete.txt") = True Then
            Return True
        Else
            Return False
        End If
    End Function

    'Added by Joe 11/26/2006
    Private Sub SetupZipDirPnl()
        Dim TS As DataGridTableStyle = Me.DG_ZipDirectories.TableStyles(0)

        Dim X As Integer = Me.DG_ZipDirectories.RowHeaderWidth
        For Each DC As DataGridColumnStyle In TS.GridColumnStyles
            If Not TypeOf DC Is ShownDataGridButtonColumnStyle Then
                Dim BTN As New Button
                BTN.Text = "Apply All"
                BTN.Tag = DC.MappingName
                BTN.Size = New Size(DC.Width, Me.PNLHeader.Height)
                BTN.Location = New Point(X, 0)
                AddHandler BTN.Click, AddressOf Me.HandleHeaderClick
                Me.PNLHeader.Controls.Add(BTN)
            End If
            X += DC.Width
        Next
    End Sub

    'Added by Joe 11/26/2006
    Private Sub HandleHeaderClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim BTN As Button = CType(sender, Button)
        Dim mapping As String = BTN.Tag.ToString

        Dim CM As CurrencyManager = CType(Me.BindingContext.Item(Me.DataSet1, "Table1"), CurrencyManager)
        If CM.Position > -1 Then
            Dim Val As Object = CType(CM.Current, DataRowView).Item(mapping)
            For X As Integer = 0 To CM.Count - 1
                CM.Position = X
                Dim DRV As DataRowView = CType(CM.Current, DataRowView)
                DRV.Item(mapping) = Val
                DRV.EndEdit()
            Next
        End If
    End Sub

    'Added by Joe 11/26/2006
    Private Sub SetupZipDirGrid()
        Dim TS As New DataGridTableStyle
        TS.MappingName = "Table1"
        Dim DGC1 As New DataGridTextBoxColumn
        DGC1.MappingName = "DirectoryName"
        DGC1.Width = 160
        DGC1.HeaderText = "Directory Name"
        TS.GridColumnStyles.Add(DGC1)

        Dim DGCBttn As New ShownDataGridButtonColumnStyle
        DGCBttn.Button_Text = "...."
        DGCBttn.Data_Grid = Me.DG_ZipDirectories
        DGCBttn.MappingName = "Button"
        DGCBttn.Width = 25
        TS.GridColumnStyles.Add(DGCBttn)
        AddHandler DGCBttn.On_Click, AddressOf ButtonClickedZipDirectory

        DGC1 = New DataGridTextBoxColumn
        DGC1.MappingName = "ZipFilePath"
        DGC1.Width = 160
        DGC1.HeaderText = "Zip File Path"
        TS.GridColumnStyles.Add(DGC1)

        DGCBttn = New ShownDataGridButtonColumnStyle
        DGCBttn.Button_Text = "...."
        DGCBttn.Data_Grid = Me.DG_ZipDirectories
        DGCBttn.MappingName = "Button2"
        DGCBttn.Width = 25
        TS.GridColumnStyles.Add(DGCBttn)
        AddHandler DGCBttn.On_Click, AddressOf ButtonClickedZipPathDirectory

        Dim boolDGC As New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "ZipFile"
        boolDGC.HeaderText = "Zip File"
        boolDGC.Width = 60
        TS.GridColumnStyles.Add(boolDGC)

        Dim intDGC As New DataGridExtensions.NumericUpDownColumnStyle
        intDGC.MappingName = "ZipRetentionPeriod"
        intDGC.HeaderText = "Zip Retention Period"
        intDGC.Width = 115
        intDGC.MaxValue = 87600
        TS.GridColumnStyles.Add(intDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "DeleteOriginalFile"
        boolDGC.HeaderText = "Delete Original File"
        boolDGC.Width = 115
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "DeleteFile"
        boolDGC.HeaderText = "Delete File"
        boolDGC.Width = 70
        TS.GridColumnStyles.Add(boolDGC)

        intDGC = New DataGridExtensions.NumericUpDownColumnStyle
        intDGC.MappingName = "DeleteRetentionPeriod"
        intDGC.HeaderText = "Delete Retention Period"
        intDGC.MaxValue = 87600
        intDGC.Width = 130
        TS.GridColumnStyles.Add(intDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "Recursive"
        boolDGC.HeaderText = "Recursive"
        boolDGC.Width = 60
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "ProcessRootFolderRecursive"
        boolDGC.HeaderText = "Include Sub Folders"
        boolDGC.Width = 120
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "IncludeComputerName"
        boolDGC.HeaderText = "Include ComputerName"
        boolDGC.Width = 125
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "ProcessUnknownExtensions"
        boolDGC.HeaderText = "Process Unknown Exts"
        boolDGC.Width = 130
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "ProcessTXT"
        boolDGC.HeaderText = "Process TXT"
        boolDGC.Width = 75
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "ProcessBAK"
        boolDGC.HeaderText = "Process BAK"
        boolDGC.Width = 75
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "ProcessDAT"
        boolDGC.HeaderText = "Process DAT"
        boolDGC.Width = 75
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "ProcessXML"
        boolDGC.HeaderText = "Process XML"
        boolDGC.Width = 75
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "ProcessEXE"
        boolDGC.HeaderText = "Process EXE"
        boolDGC.Width = 75
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "ProcessDLL"
        boolDGC.HeaderText = "Process DLL"
        boolDGC.Width = 75
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "ProcessINI"
        boolDGC.HeaderText = "Process INI"
        boolDGC.Width = 75
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "ProcessCFG"
        boolDGC.HeaderText = "Process CFG"
        boolDGC.Width = 75
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "ProcessMSP"
        boolDGC.HeaderText = "Process MSP"
        boolDGC.Width = 75
        TS.GridColumnStyles.Add(boolDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "ProcessTMP"
        boolDGC.HeaderText = "Process TMP"
        boolDGC.Width = 75
        TS.GridColumnStyles.Add(boolDGC)

        intDGC = New DataGridExtensions.NumericUpDownColumnStyle
        intDGC.MappingName = "LogsDWM"
        intDGC.HeaderText = "LogsDWM"
        intDGC.MinValue = 1
        intDGC.MaxValue = 3
        intDGC.Width = 60
        TS.GridColumnStyles.Add(intDGC)

        boolDGC = New DataGridBoolColumn
        boolDGC.AllowNull = False
        boolDGC.MappingName = "PreserveDirPath"
        boolDGC.HeaderText = "PreserveDirPath"
        boolDGC.Width = 100
        TS.GridColumnStyles.Add(boolDGC)

        'Dim DGC2 As New DataGridTextBoxColumn
        'DGC2 = New DataGridTextBoxColumn
        'DGC2.MappingName = "Naming"
        'DGC2.Width = 50
        'DGC2.HeaderText = "Naming"
        'DGC2.ReadOnly = True
        'TS.GridColumnStyles.Add(DGC2)

        Me.DG_ZipDirectories.TableStyles.Add(TS)

        Me.DG_ZipDirectories.DataMember = "Table1"
        Me.DG_ZipDirectories.DataSource = Me.DataSet1
    End Sub

    Private Sub SetupGrid(ByVal Grid As DataGrid, Optional ByVal IsTime As Boolean = False)
        Dim TS As New DataGridTableStyle
        TS.MappingName = "ValueDT"
        Dim DGC1 As New DataGridTextBoxColumn
        DGC1.MappingName = "Value"
        DGC1.Width = 325
        DGC1.HeaderText = "Values"
        TS.GridColumnStyles.Add(DGC1)
        Dim DGC2 As New ShownDataGridButtonColumnStyle
        DGC2.Button_Text = "...."
        DGC2.Data_Grid = Grid
        DGC2.MappingName = "Button"
        DGC2.Width = 25
        TS.GridColumnStyles.Add(DGC2)
        Grid.TableStyles.Add(TS)
        If IsTime = False Then
            AddHandler DGC2.On_Click, AddressOf ButtonClickedDirectory
        Else
            AddHandler DGC2.On_Click, AddressOf ButtonClickedTime
        End If
    End Sub

    Private Sub ButtonClickedDirectory(ByVal Button As Object, ByVal row As Integer, ByVal column As Integer, ByRef Value As String, ByRef DRV As DataRowView)
        If IsDBNull(DRV.Item("value")) = False Then
            Me.FolderBrowserDialog1.SelectedPath = DRV.Item("Value").ToString.ToLower
        End If
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            DRV.Item("Value") = Me.FolderBrowserDialog1.SelectedPath.ToLower
            DRV.EndEdit()
        End If
    End Sub

    Private Sub ButtonClickedZipDirectory(ByVal Button As Object, ByVal row As Integer, ByVal column As Integer, ByRef Value As String, ByRef DRV As DataRowView)
        If IsDBNull(DRV.Item("DirectoryName")) = False Then
            Me.FolderBrowserDialog1.SelectedPath = DRV.Item("DirectoryName").ToString.ToLower
        End If
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            DRV.Item("DirectoryName") = Me.FolderBrowserDialog1.SelectedPath.ToLower
            If DRV.Item("DirectoryName").ToString.Chars(DRV.Item("DirectoryName").ToString.Length - 1) <> "\" Then
                DRV.Item("DirectoryName") &= "\"
            End If
            DRV.EndEdit()
        End If
    End Sub

    Private Sub ButtonClickedZipPathDirectory(ByVal Button As Object, ByVal row As Integer, ByVal column As Integer, ByRef Value As String, ByRef DRV As DataRowView)
        If IsDBNull(DRV.Item("ZipFilePath")) = False Then
            Me.FolderBrowserDialog1.SelectedPath = DRV.Item("ZipFilePath").ToString.ToLower
        End If
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            DRV.Item("ZipFilePath") = Me.FolderBrowserDialog1.SelectedPath.ToLower
            If DRV.Item("ZipFilePath").ToString.Chars(DRV.Item("ZipFilePath").ToString.Length - 1) <> "\" Then
                DRV.Item("ZipFilePath") &= "\"
            End If
            DRV.EndEdit()
        End If
    End Sub

    Private Sub ButtonClickedTime(ByVal Button As Object, ByVal row As Integer, ByVal column As Integer, ByRef Value As String, ByRef DRV As DataRowView)
        Dim TD As New TimeDialog
        If IsDBNull(DRV.Item("value")) = False Then
            TD.DateTimePicker1.Text = DRV.Item("Value")
        End If
        If TD.ShowDialog = Windows.Forms.DialogResult.OK Then
            DRV.Item("Value") = TD.DateTimePicker1.Text
            DRV.EndEdit()
        End If
    End Sub

    Private Sub StartMnuI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartMnuI.Click
        Try
            If Not Me.ServiceController1.ServiceName Is Nothing Then
                If Me.ServiceController1.ServiceName.Trim <> "" Then
                    If Me.ServiceController1.Status <> ServiceProcess.ServiceControllerStatus.Running Then
                        Me.ServiceController1.Start()
                        Me.StartMnuI.Enabled = False
                        Me.StopMnuI.Enabled = True
                        Me.ServiceController1.Refresh()
                        MessageBox.Show("Service is started", "Start Service", MessageBoxButtons.OK)
                    ElseIf Me.ServiceController1.Status = ServiceProcess.ServiceControllerStatus.Running Then
                        MessageBox.Show("Service already Started", "Started", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Please setup Service to use First", "Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Please setup Service to use First", "Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub StopMnuI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopMnuI.Click
        Try
            If Not Me.ServiceController1.ServiceName Is Nothing Then
                If Me.ServiceController1.ServiceName.Trim <> "" Then
                    If Me.ServiceController1.Status <> ServiceProcess.ServiceControllerStatus.Stopped Then
                        Me.ServiceController1.Stop()
                        Me.StartMnuI.Enabled = True
                        Me.StopMnuI.Enabled = False
                        Me.ServiceController1.Refresh()
                        MessageBox.Show("Service is stopped", "Stop Service", MessageBoxButtons.OK)
                    ElseIf Me.ServiceController1.Status = ServiceProcess.ServiceControllerStatus.Stopped Then
                        MessageBox.Show("Service already Stopped", "Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Please setup Service to use First", "Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Please setup Service to use First", "Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OpenMnuI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenMnuI.Click
        If GetSetting("IISLOGSGUI", "Main", "LastConfigFile") <> "" Then
            Me.OpenFileDialog1.FileName = GetSetting("IISLOGSGUI", "Main", "LastConfigFile")
        End If
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SaveSetting("IISLOGSGUI", "Main", "LastConfigFile", Me.OpenFileDialog1.FileName)
            Me.TabControl1.Enabled = True
            Me.AppRW.AppConfigFIle = Me.OpenFileDialog1.FileName
            'load file
            Me.AppRW.Close()
            Me.AppRW.LoadConfigSource()
            GetSettings()
        Else
            Me.AppRW.AppConfigFIle = Nothing
        End If
    End Sub

    Friend Sub SaveMnuI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveMnuI.Click
        If TabControl1.Enabled = True Then
            'save settings
            If ValidateData() = True Then
                SetSettings()
                'save
                Me.AppRW.SaveConfigSource()
                'Me.DialogResult = DialogResult.OK
                'Me.Close()
            End If
        End If
    End Sub

    Private Function CheckEndDelimiter(ByVal value As String) As String
        Dim retValue As String = ""

        retValue = Microsoft.VisualBasic.Right(value, 1)

        If retValue = Me.txtDelimiter.Text.ToString() Then
            Return value
        ElseIf value Is Nothing Then
            Return value
        Else
            Return value & Me.txtDelimiter.Text.ToString()
        End If
    End Function

    Private Sub ValidatePathsForZipDir(ByVal colname As String)
        Try
            Dim CM As CurrencyManager = CType(Me.BindingContext.Item(Me.DataSet1, "Table1"), CurrencyManager)
            If CM.Position > -1 Then
                For X As Integer = 0 To CM.Count - 1
                    CM.Position = X
                    Dim DR As DataRow = CType(CM.Current, DataRowView).Row
                    DR.ClearErrors()
                    If DR.IsNull(colname) = False Then
                        If DR.Item(colname).ToString.ToLower <> "local" Then
                            If DR.Item(colname).ToString.Trim <> "" Then
                                If IO.Directory.Exists(DR.Item(colname).ToString) = False Then
                                    DR.SetColumnError(colname, "Invalid Path")
                                    Throw New Exception
                                Else
                                    If DR.Item(colname).ToString.Chars(DR.Item(colname).ToString.Length - 1) <> "\" Then
                                        DR.Item(colname) &= "\"
                                    End If
                                End If
                            Else
                                DR.SetColumnError(colname, "Invalid Path")
                                Throw New Exception
                            End If
                        End If
                    Else
                        DR.SetColumnError(colname, "Invalid Path")
                        Throw New Exception
                    End If
                Next
            End If
        Catch
            Throw New Exception("Per Directory, Column " & colname & " contains an invalid path, please correct and try again")
        End Try
    End Sub

    Private Sub SetSettings()
        'Added by Joe 11/26/2006

        Me.DataSet1.WriteXml(IO.Path.Combine(Application.StartupPath, "IISLogsPerDirectory.xml"), XmlWriteMode.IgnoreSchema)

        Me.AppRW.setSetting("MonitoredEntireDirectories", CheckEndDelimiter(Me.GetGridValues(Me.DIRDG)))
        Me.AppRW.setSetting("MonitoredSpecificDirectories", CheckEndDelimiter(Me.GetGridValues(Me.SpecDG)))
        Me.AppRW.setSetting("ServiceInterval", Me.GetGridValues(Me.SerDG))
        Me.AppRW.setSetting("DelOnlySpecificDirectories", Me.GetGridValues(Me.DeleteDG))
        Me.AppRW.setSetting("SmtpSVCDirectories", Me.GetGridValues(Me.SMTPDG))
        Me.AppRW.setSetting("ZipFile", CType(Me.CHK_EnableZip.Checked, Boolean))
        Me.AppRW.setSetting("DeleteFile", CType(Me.CHK_EnableDelete.Checked, Boolean))
        Me.AppRW.setSetting("MonitorZipFilePath", CType(Me.CHK_MonitorZipDIR.Checked, Boolean))
        Me.AppRW.setSetting("ProcessSmtpSVCDirectories", CType(Me.CHK_EnableSMTP.Checked, Boolean))
        Me.AppRW.setSetting("ProcessDelOnlySpecificDirectories", CType(Me.CHK_EnableDeleteOnly.Checked, Boolean))
        Me.AppRW.setSetting("SendMailReport", CType(Me.CHK_SendMailReport.Checked, Boolean))

        'Added by Steve Schofield - 10/13/2004
        'Insures DeleteOriginalLogFile option is set to NO if ZIP Feature is un-selected.
        If Me.CHK_EnableZip.Checked = True Then
            Me.AppRW.setSetting("DeleteOriginalFile", CType(Me.DeleteOrginalCHK.Checked, Boolean))
        Else
            Me.AppRW.setSetting("DeleteOriginalFile", "false")
        End If

        'Added by Steve Schofield - 8/29/2004
        'put in to insure zipRetentionPeriod if NOT selected to set values to zero
        If Me.CHK_EnableZip.Checked = True Then
            Me.AppRW.setSetting("ZipRetentionPeriod", Me.ZipRetentionPeriod_Txt.Text)
        Else
            Me.AppRW.setSetting("ZipRetentionPeriod", 0)
        End If

        If Me.ZipPathCustom_RAD.Checked = True AndAlso Me.ZipFilePath_TXT.Text <> "local" Then
            If Me.ZipFilePath_TXT.Text.Chars(Me.ZipFilePath_TXT.Text.Length - 1) <> "\" Then
                Me.ZipFilePath_TXT.Text &= "\"
            End If
        End If

        Me.AppRW.setSetting("ZipFilePath", Me.ZipFilePath_TXT.Text)

        'Added by Steve Schofield - 8/29/2004
        'put in to insure deleteRetentionPeriod if NOT selected to set values to zero
        If Me.CHK_EnableDelete.Checked = True Then
            Me.AppRW.setSetting("DeleteRetentionPeriod", Me.DeleteRetentionPeriod_TXT.Text)
        Else
            Me.AppRW.setSetting("DeleteRetentionPeriod", 0)
        End If
        Me.AppRW.setSetting("LogDirectoryPath", Me.LogDirPath_TXT.Text)
        Me.AppRW.setSetting("SmtpDeleteRetentionPeriod", Me.STMPRetentionPeriod_TXT.Text)
        Me.AppRW.setSetting("DelOnlySpecificRetentionPeriod", Me.DeleteOnlyRetentionPeriod_TXT.Text)
        Me.AppRW.setSetting("From", Me.MailFrom_TXT.Text)
        Me.AppRW.setSetting("To", Me.MailTo_TXT.Text)
        Me.AppRW.setSetting("mailServer", Me.MailServer_TXT.Text)
        Me.AppRW.setSetting("mailPort", Me.MailPortNumber_NumUPDOWN.Value)
        Me.AppRW.setSetting("mailSubject", Me.MailSubject_TXT.Text)
        'Added by Steve Schofield 10/17/2004
        'Encrypts Password stored in Configuration File
        Me.AppRW.setSetting("mailPWD", EncryptPWD(Me.MailPWD_TXT.Text))
        Me.AppRW.setSetting("mailUID", EncryptPWD(Me.MailUID_TXT.Text))
        Me.AppRW.setSetting("EnableMailAuth", Me.CHK_EnableMailAuth.Checked)
        Me.AppRW.setSetting("CompressionLevel", Me.ZipCompressionCB.Text)
        Me.AppRW.setSetting("Naming", Me.GetNaming)
        Me.AppRW.setSetting("AutoAddMonitoredSpecificDirectories", Me.CHK_AutoAddOptions.Checked)
        Me.AppRW.setSetting("AutoAddMonitoredSpecificDirectories_w3svc", CHK_W3SVC_AutoAddOptions.Checked)
        Me.AppRW.setSetting("AutoAddMonitoredSpecificDirectories_msftpsvc", CHK_MSFTPSVC_AutoAddOptions.Checked)
        Me.AppRW.setSetting("AutoAddMonitoredSpecificDirectories_smtpsvc", CHK_SMTPSVC_AutoAddOptions.Checked)
        Me.AppRW.setSetting("Delimiter", Me.txtDelimiter.Text.ToString())
        Me.AppRW.setSetting("ProcessXML", CHK_ProcessXML.Checked)
        Me.AppRW.setSetting("ProcessTXT", CHK_ProcessTXT.Checked)
        Me.AppRW.setSetting("ProcessDAT", CHK_ProcessDAT.Checked)
        Me.AppRW.setSetting("ProcessBAK", CHK_ProcessBAK.Checked)

        'Added by Steve Schofield 12/11/2010"
        Me.AppRW.setSetting("ZipPerDirectoryEnable", CHK_EnablePerDirectory.Checked)
        If Me.RDO_ZipFileStoragePreference1.Checked Then
            Me.AppRW.setSetting("LogsDWM", "1")
        ElseIf Me.RDO_ZipFileStoragePreference2.Checked Then
            Me.AppRW.setSetting("LogsDWM", "2")
        ElseIf Me.RDO_ZipFileStoragePreference3.Checked Then
            Me.AppRW.setSetting("LogsDWM", "3")
        End If

        'Added by Steve Schofield 9/14/2012
        Me.AppRW.setSetting("UseMetabaseRoleService", CType(CHK_UseMetabaseRoleService.Checked, Boolean))


    End Sub

    Private Sub GetSettings()
        'Added by Joe 11/26/2006
        If IO.File.Exists(IO.Path.Combine(Application.StartupPath, "IISLogsPerDirectory.xml")) = True Then
            Me.DataSet1.Clear()
            Me.DataSet1.ReadXml(IO.Path.Combine(Application.StartupPath, "IISLogsPerDirectory.xml"), XmlReadMode.IgnoreSchema)
            Me.DataSet1.AcceptChanges()
        End If

        Me.SetNaming(Me.AppRW.GetSetting("Naming"))
        SetGridValues(LCase(Me.AppRW.GetSetting("MonitoredEntireDirectories")), Me.DIRDG)
        SetGridValues(LCase(Me.AppRW.GetSetting("MonitoredSpecificDirectories")), Me.SpecDG)
        SetGridValues(Me.AppRW.GetSetting("ServiceInterval"), Me.SerDG)
        SetGridValues(Me.AppRW.GetSetting("DelOnlySpecificDirectories"), Me.DeleteDG)
        SetGridValues(Me.AppRW.GetSetting("SmtpSVCDirectories"), Me.SMTPDG)
        Me.CHK_EnableZip.Checked = CType(Me.AppRW.GetSetting("ZipFile"), Boolean)
        Me.CHK_EnableDelete.Checked = CType(Me.AppRW.GetSetting("DeleteFile"), Boolean)
        Me.CHK_MonitorZipDIR.Checked = CType(Me.AppRW.GetSetting("MonitorZipFilePath"), Boolean)
        'Changed by Steve Schofield - 12/3/04 - Moved to using True/False for this value
        'SetCHKValue(Me.AppRW.GetSetting("ProcessSmtpSVCDirectories"), Me.CHK_EnableSMTP)
        Me.CHK_EnableSMTP.Checked = CType(Me.AppRW.GetSetting("ProcessSmtpSVCDirectories"), Boolean)
        Me.CHK_EnableDeleteOnly.Checked = CType(Me.AppRW.GetSetting("ProcessDelOnlySpecificDirectories"), Boolean)
        'Changed by Steve Schofield 12/3/2004 - changed to use True/False
        'SetCHKValue(Me.AppRW.GetSetting("SendMailReport"), Me.CHK_SendMailReport)
        Me.CHK_SendMailReport.Checked = CType(Me.AppRW.GetSetting("SendMailReport"), Boolean)
        Me.DeleteOrginalCHK.Checked = CType(Me.AppRW.GetSetting("DeleteOriginalFile"), Boolean)
        Me.ZipRetentionPeriod_Txt.Text = Me.AppRW.GetSetting("ZipRetentionPeriod").ToString
        Me.ZipFilePath_TXT.Text = Me.AppRW.GetSetting("ZipFilePath").ToString
        Me.DeleteRetentionPeriod_TXT.Text = Me.AppRW.GetSetting("DeleteRetentionPeriod").ToString

        'Commented out by Steve Schofield
        'Me.LogDirPath_TXT.Text = Me.AppRW.GetSetting("LogDirectoryPath").ToString

        'Added by Steve Schofield - 10/13/2004
        'Insures the LogDirectoryPath Variable is set.
        If Me.AppRW.GetSetting("LogDirectoryPath").ToString.Trim <> "" Then
            Me.LogDirPath_TXT.Text = Me.AppRW.GetSetting("LogDirectoryPath").ToString
        Else
            Me.LogDirPath_TXT.Text = Application.StartupPath & "\Logs\"
            'Added by Steve Schofield 10/13/2004
            'Refreshs the local variable so other variables can reference the LogDirectoryPath
            Me.AppRW.setSetting("LogDirectoryPath", Application.StartupPath & "\Logs\")

            If IO.Directory.Exists(Me.LogDirPath_TXT.Text) = False Then
                IO.Directory.CreateDirectory(Me.LogDirPath_TXT.Text)
            End If
        End If

        Me.STMPRetentionPeriod_TXT.Text = Me.AppRW.GetSetting("SmtpDeleteRetentionPeriod").ToString
        Me.DeleteOnlyRetentionPeriod_TXT.Text = Me.AppRW.GetSetting("DelOnlySpecificRetentionPeriod").ToString
        Me.MailFrom_TXT.Text = Me.AppRW.GetSetting("From").ToString
        Me.MailPortNumber_NumUPDOWN.Value = Me.AppRW.GetSetting("mailPort")
        'Added by Steve Schofield 10/17/2004
        'Decodes Password stored in Configuration File
        Me.MailPWD_TXT.Text = DecodePWD(Me.AppRW.GetSetting("mailPWD").ToString)
        Me.PasswordEntryTxt2.Text = Me.MailPWD_TXT.Text
        Me.MailServer_TXT.Text = Me.AppRW.GetSetting("mailServer").ToString
        Me.MailSubject_TXT.Text = Me.AppRW.GetSetting("mailSubject").ToString
        Me.MailTo_TXT.Text = Me.AppRW.GetSetting("To").ToString
        Me.MailUID_TXT.Text = DecodePWD(Me.AppRW.GetSetting("mailUID").ToString)
        If Me.AppRW.GetSetting("CompressionLevel").ToString.Trim <> "" Then
            Me.ZipCompressionCB.Text = Me.AppRW.GetSetting("CompressionLevel").ToString
        Else
            Me.ZipCompressionCB.Text = "High"
        End If

        'Added by Steve Schofield - 12/3/04 - Enable Mail Authenication
        Me.CHK_EnableMailAuth.Checked = CType(Me.AppRW.GetSetting("EnableMailAuth"), Boolean)

        If Me.AppRW.GetSetting("ServiceName").ToString.Trim <> "" Then
            Me.ServiceController1.ServiceName = Me.AppRW.GetSetting("ServiceName").ToString
            Me.ServiceController1.Refresh()
            Me.MenuItem2.Visible = True
            Me.ToolBarButton3.Visible = True
            Me.ToolBarButton4.Visible = True
            'Show IISLogsSVC button
            Me.ToolBarButton8.Visible = True
            'Hide IISLogsEXE button
            Me.ToolBarButton9.Visible = False
            Me.SetServiceStates()
        Else
            Me.MenuItem2.Visible = False
            Me.ToolBarButton3.Visible = False
            Me.ToolBarButton4.Visible = False
            'Hide IISLogsSVC button
            Me.ToolBarButton8.Visible = False
            'Show IISLogsEXE button
            Me.ToolBarButton9.Visible = True

            '  Me.SetupMnuI_Click(Me, New EventArgs)
        End If

        Me.CHK_AutoAddOptions.Checked = CType(Me.AppRW.GetSetting("AutoAddMonitoredSpecificDirectories"), Boolean)
        Me.CHK_W3SVC_AutoAddOptions.Checked = CType(Me.AppRW.GetSetting("AutoAddMonitoredSpecificDirectories_w3svc"), Boolean)
        Me.CHK_MSFTPSVC_AutoAddOptions.Checked = CType(Me.AppRW.GetSetting("AutoAddMonitoredSpecificDirectories_msftpsvc"), Boolean)
        Me.CHK_SMTPSVC_AutoAddOptions.Checked = CType(Me.AppRW.GetSetting("AutoAddMonitoredSpecificDirectories_smtpsvc"), Boolean)
        Me.txtDelimiter.Text = Me.AppRW.GetSetting("Delimiter").ToString()

        Me.CHK_ProcessXML.Checked = CType(Me.AppRW.GetSetting("ProcessXML"), Boolean)
        Me.CHK_ProcessTXT.Checked = CType(Me.AppRW.GetSetting("ProcessTXT"), Boolean)
        Me.CHK_ProcessDAT.Checked = CType(Me.AppRW.GetSetting("ProcessDAT"), Boolean)
        Me.CHK_ProcessBAK.Checked = CType(Me.AppRW.GetSetting("ProcessBAK"), Boolean)
        Me.CHK_EnablePerDirectory.Checked = CType(Me.AppRW.GetSetting("ZipPerDirectoryEnable"), Boolean)

        'Added so that things that need to be done are done
        CHK_SendMailReport_CheckedChanged(Me, New EventArgs)

        If Me.AppRW.GetSetting("LogsDWM") = "1" Then
            Me.RDO_ZipFileStoragePreference1.Checked = True
        ElseIf Me.AppRW.GetSetting("LogsDWM") = "2" Then
            Me.RDO_ZipFileStoragePreference2.Checked = True
        ElseIf Me.AppRW.GetSetting("LogsDWM") = "3" Then
            Me.RDO_ZipFileStoragePreference3.Checked = True
        End If

        'Added by Steve Schofield 9/14/2012
        Me.CHK_UseMetabaseRoleService.Checked = CType(Me.AppRW.GetSetting("UseMetabaseRoleService"), Boolean)

    End Sub

    Private Sub SetGridValues(ByVal Values As String, ByVal DG As DataGrid)
        Dim A() As String
        If Not Values Is Nothing Then
            A = Values.Split(Me.AppRW.GetSetting("Delimiter"))
            CType(DG.DataSource, DataTable).Rows.Clear()
            For Each str As String In A
                If str.Trim <> "" Then
                    Dim DR As DataRow = CType(DG.DataSource, DataTable).NewRow
                    DR.Item("Value") = str.ToLower
                    CType(DG.DataSource, DataTable).Rows.Add(DR)
                End If
            Next
        End If
    End Sub

    Private Function GetGridValues(ByVal DG As DataGrid) As String
        Dim A(CType(DG.DataSource, DataTable).Rows.Count - 1) As String
        For x As Int16 = 0 To CType(DG.DataSource, DataTable).Rows.Count - 1
            If IsDBNull(CType(DG.DataSource, DataTable).Rows.Item(x).Item("Value")) = False Then
                If CType(DG.DataSource, DataTable).Rows.Item(x).Item("Value").ToString.Trim <> "" Then
                    A(x) = CType(DG.DataSource, DataTable).Rows.Item(x).Item("Value")
                End If
            End If
        Next
        Return Join(A, Me.AppRW.GetSetting("Delimiter"))
    End Function

    Private Sub ExitMnuI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitMnuI.Click
        Dim DR As DialogResult = MessageBox.Show("Save Changes?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If DR = Windows.Forms.DialogResult.Yes Then
            Me.SaveMnuI_Click(sender, New EventArgs)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        ElseIf DR = Windows.Forms.DialogResult.No Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Me.TabControl1.Enabled = True Then
            If Me.DialogResult <> Windows.Forms.DialogResult.OK Then
                Dim DR As DialogResult = MessageBox.Show("Save Changes?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If DR = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = True
                    Me.SaveMnuI_Click(sender, New EventArgs)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                ElseIf DR = Windows.Forms.DialogResult.Cancel Then
                    RefreshGrid()
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub SetupMnuI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetupService_MnuI.Click
        If Me.TabControl1.Enabled = True Then
            Dim SSFrm As New ServiceSelectFrm
            Dim SC As System.ServiceProcess.ServiceController
            For Each SC In ServiceProcess.ServiceController.GetServices
                SSFrm.ListBox1.Items.Add(SC.ServiceName)
            Next

            If Me.AppRW.GetSetting("ServiceName").ToString.Trim <> "" Then
                SSFrm.ListBox1.SelectedItem = Me.AppRW.GetSetting("ServiceName").ToString
            End If

            If SSFrm.ShowDialog = Windows.Forms.DialogResult.OK Then
                'SaveSetting("IISLOGSGUI", "Main", "ServiceName", SSFrm.ListBox1.SelectedItem.ToString)
                Me.AppRW.setSetting("ServiceName", SSFrm.ListBox1.SelectedItem.ToString)
                Me.ServiceController1.ServiceName = SSFrm.ListBox1.SelectedItem.ToString
            End If
        End If
    End Sub

    Private Sub LogDirBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogDirBTN.Click
        If Me.LogDirPath_TXT.Text.Trim <> "" Then
            If IO.Directory.Exists(Me.LogDirPath_TXT.Text) = True Then
                Me.FolderBrowserDialog1.SelectedPath = Me.LogDirPath_TXT.Text
            Else
                Me.LogDirPath_TXT.Text = ""
            End If
        End If
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Modified by Steve Schofield 10/13/2004
            'Added the end slash "/" so the directory will have the extra slash
            Me.LogDirPath_TXT.Text = Me.FolderBrowserDialog1.SelectedPath & "\"
        End If
    End Sub

    Private Sub ZipFilePath_BTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZipFilePath_BTN.Click
        If Me.ZipFilePath_TXT.Text.Trim <> "" Then
            If IO.Directory.Exists(Me.ZipFilePath_TXT.Text) = True Then
                Me.FolderBrowserDialog1.SelectedPath = Me.ZipFilePath_TXT.Text
            Else
                Me.ZipFilePath_TXT.Text = ""
            End If
        End If
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Modified by Steve Schofield 10/13/2004
            'Added the end slash "/" so the directory will have the extra slash
            Me.ZipFilePath_TXT.Text = Me.FolderBrowserDialog1.SelectedPath & "\"
        End If
    End Sub

    Private Sub AboutMnuI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutMnuI.Click
        Dim ABT As New AboutFrm
        ABT.ShowDialog(Me)
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case e.Button.ImageIndex
            Case 0 'open
                Me.OpenMnuI_Click(sender, New EventArgs)
            Case 1 'save
                Me.SaveMnuI_Click(sender, New EventArgs)
            Case 2 'start
                Me.StartMnuI_Click(sender, New EventArgs)
            Case 3 'stop
                Me.StopMnuI_Click(sender, New EventArgs)
            Case 4 'exit
                Me.ExitMnuI_Click(sender, New EventArgs)
            Case 5 'help
                SendKeys.Send("{F1}")
            Case 6 'wizard
                Me.WizardMnuI_Click(sender, New EventArgs)
            Case 7 'Run Service
                Dim Log As New EventLog
                Log.Source = "Application"

                Try
                    If Me.ServiceController1.Status <> ServiceProcess.ServiceControllerStatus.Running Then
                        If MessageBox.Show("The Service is not started", "Would you like to start the Service?", MessageBoxButtons.YesNoCancel) = Windows.Forms.DialogResult.Yes Then
                            'Start the service if the client wants 
                            Me.ServiceController1.Start()
                            Threading.Thread.Sleep(5000)
                            Me.ServiceController1.Refresh()
                        Else
                            Log.WriteEntry("Run command result was No or Canceled:" & System.DateTime.Now())
                            Exit Sub
                        End If
                    End If


                    For Each service As System.ServiceProcess.ServiceController In ServiceProcess.ServiceController.GetServices
                        If Me.ServiceController1.ServiceName.ToLower.Trim = service.ServiceName.ToLower.Trim Then

                            'Run the Service on-demand
                            Me.ServiceController1.ExecuteCommand(130)
                            Log.WriteEntry("Ran the command:" & System.DateTime.Now())
                        End If
                    Next
                    Me.StartMnuI.Enabled = False
                    Me.StopMnuI.Enabled = True

                Catch ex As Exception
                    Log.WriteEntry("Error Occurred While Running command:" & ex.ToString())
                Finally
                    Log.Close()
                    Log.Dispose()
                End Try

            Case 8 'Run IISLogsEXE
                Dim fn As String = ""
                fn = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) & "\IISLogsEXE.exe"

                If System.IO.File.Exists(fn) = True Then

                    Dim Log As New EventLog
                    Log.Source = "Application"
                    Dim p As New System.Diagnostics.Process
                    p = System.Diagnostics.Process.Start(fn)
                    p.WaitForExit()
                    Log.WriteEntry("Ran the command:" & System.DateTime.Now())
                    Log.Close()
                    Log.Dispose()
                    RefreshGrid()
                End If
        End Select
    End Sub

    Private Sub CHK_SendMailReport_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_SendMailReport.CheckedChanged
        RemoveHandler CHK_SendMailReport.CheckedChanged, AddressOf CHK_SendMailReport_CheckedChanged
        If Me.CHK_SendMailReport.Checked = True Then
            Me.MailFrom_TXT.Enabled = True
            Me.MailPortNumber_NumUPDOWN.Enabled = True
            Me.MailPWD_TXT.Enabled = True
            Me.MailServer_TXT.Enabled = True
            Me.MailSubject_TXT.Enabled = True
            Me.MailTo_TXT.Enabled = True
            Me.MailUID_TXT.Enabled = True
            Me.PasswordEntryTxt2.Enabled = True
            'Added by Steve Schofield - 12/3/04 
            Me.CHK_EnableMailAuth.Enabled = True
        Else
            Me.MailFrom_TXT.Enabled = False
            Me.MailPortNumber_NumUPDOWN.Enabled = False
            Me.MailPWD_TXT.Enabled = False
            Me.MailServer_TXT.Enabled = False
            Me.MailSubject_TXT.Enabled = False
            Me.MailTo_TXT.Enabled = False
            Me.MailUID_TXT.Enabled = False
            Me.PasswordEntryTxt2.Enabled = False
            'Added by Steve Schofield - 12/3/04 
            Me.CHK_EnableMailAuth.Enabled = False
        End If
        AddHandler CHK_SendMailReport.CheckedChanged, AddressOf CHK_SendMailReport_CheckedChanged
    End Sub

    Private Sub HelpMnI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpMnI.Click
        SendKeys.Send("{F1}")
    End Sub

    Friend Function ValidateData() As Boolean
        Try
            'Joe: added 11/30/06
            CType(Me.BindingContext.Item(Me.DG_ZipDirectories.DataSource, Me.DG_ZipDirectories.DataMember), CurrencyManager).EndCurrentEdit()
            Me.DataSet1.AcceptChanges()

            ValidatePathsForZipDir("ZipFilePath")
            ValidatePathsForZipDir("DirectoryName")

            If Me.MailPWD_TXT.Text <> Me.PasswordEntryTxt2.Text Then
                Throw New Exception("Please re-enter the Mail Password, in Mail Settings")
                Me.MailPWD_TXT.Text = ""
                Me.PasswordEntryTxt2.Text = ""
            End If
            If Me.Rad_NameOptCustom.Checked = True Then
                'If Me.TextBox1.Text.Trim = "" Then
                '    Throw New Exception("Please Enter First part of Naming Option")
                'Else
                If ComboBox1.Text.Trim <> "" OrElse ComboBox2.Text.Trim <> "" OrElse ComboBox3.Text.Trim <> "" Then
                    If Me.ComboBox1.Text.Trim = "" Then
                        Throw New Exception("Please Select Monthly Naming Option")
                    ElseIf Me.ComboBox2.Text.Trim = "" Then
                        Throw New Exception("Please Select Daily Naming Option")
                    ElseIf Me.ComboBox3.Text.Trim = "" Then
                        Throw New Exception("Please Select Yearly Naming Option")
                        'ElseIf Me.TextBox2.Text.Trim = "" Then
                        '    Throw New Exception("Please Enter Ending part of Naming Option")
                    End If
                ElseIf TextBox1.Text.Trim = "" Then
                    Throw New Exception("Please enter a name part in the first naming option")
                End If
            End If

            If Me.CHK_EnableDelete.Checked = True Then
                If Me.CHK_EnableZip.Checked = True Then
                    'fixed by steve schofield 8/29/2004 it was checking to see if zip greater than delete
                    'the requirement is DeleteRetentionPeriod has to be greater NOT ZipRetentionPeriod greater than DeleteRetentionPeriod
                    If CInt(Me.ZipRetentionPeriod_Txt.Text) >= CInt(Me.DeleteRetentionPeriod_TXT.Text) Then
                        Throw New Exception("Zip Retention Period should always be 1 hour less then Delete Retention Period")
                    End If
                End If
            End If
            If Not Me.DataValidator1.ValidationSummary Is Nothing Then
                If Me.DataValidator1.ValidationSummary.Trim <> "" Then
                    Throw New Exception(Me.DataValidator1.ValidationSummary)
                End If
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try
    End Function

    Private Function FindDirectoryItem(ByVal Dirstr As String, ByVal DG As DataGrid) As Boolean
        For Each dr As DataRow In CType(DG.DataSource, DataTable).Rows
            If dr.Item("Value").ToString.Trim.ToLower = Dirstr.Trim.ToLower Then
                Return True
            End If
        Next
        Return False
    End Function

    Friend Sub EasyConfig_BTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EasyConfig_BTN.Click
        Dim Easy As New EasyConfigFrm
        Easy.DirectoryListing = Me.GetGridValues(Me.SpecDG)
        If Easy.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            For Each dr As DataRow In CType(Easy.DataGrid1.DataSource, DataTable).Rows
                If CBool(dr.Item("Select")) = True Then
                    If Me.FindDirectoryItem(dr.Item("Directory"), Me.SpecDG) = False Then
                        If Me.FindDirectoryItem(dr.Item("Directory"), Me.SpecDG) = False Then
                            Dim CM As CurrencyManager = CType(Me.BindingContext(Me.SpecDG.DataSource), CurrencyManager)
                            CM.AddNew()
                            CType(CM.Current, DataRowView).Item("Value") = dr.Item("Directory")
                            CM.EndCurrentEdit()
                        End If
                    End If
                Else 'unselected, delete ones in grid
                    For Each dr1 As DataRow In CType(SpecDG.DataSource, DataTable).Rows
                        If dr1.RowState <> DataRowState.Deleted Then
                            If dr1.Item("Value").ToString.Trim.ToLower = dr.Item("Directory").Trim.ToLower Then
                                dr1.Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub DeleteOrginalCHK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteOrginalCHK.CheckedChanged
        If DeleteOrginalCHK.Checked = True Then
            RemoveHandler DeleteOrginalCHK.CheckedChanged, AddressOf DeleteOrginalCHK_CheckedChanged
            Me.DeleteOrginalCHK.Checked = ShowPolicy(PolicyType.Delete, Me.DeleteOrginalCHK.Checked)
            AddHandler DeleteOrginalCHK.CheckedChanged, AddressOf DeleteOrginalCHK_CheckedChanged
        End If
    End Sub

    Public Enum PolicyType
        Zip
        Delete
    End Enum

    Private Function ShowPolicy(ByVal PType As PolicyType, ByVal OrginalValue As Boolean) As Boolean
        If Me._Startup = False Then
            Dim FilePathName As String = ""
            Select Case PType
                Case PolicyType.Delete
                    If System.IO.File.Exists(Me.AppRW.GetSetting("LogDirectoryPath").ToString & "\PolicyAgreements\DeletePolicyAgreement.txt") = True Then
                        Me.SetPolicyProperty(PType, True)
                        Return True
                    End If
                    FilePathName = Application.StartupPath & "\DeletePolicyAgreement.txt"
                Case PolicyType.Zip
                    If System.IO.File.Exists(Me.AppRW.GetSetting("LogDirectoryPath").ToString & "\PolicyAgreements\FileCompressionPolicyAgreement.txt") = True Then
                        Me.SetPolicyProperty(PType, True)
                        Return True
                    End If
                    FilePathName = Application.StartupPath & "\FileCompressionPolicyAgreement.txt"
            End Select

            Dim PR As New PolicyReview
            If IO.File.Exists(FilePathName) = True Then
                PR.TextBox1.Text = System.IO.File.OpenText(FilePathName).ReadToEnd
            Else
                PR.TextBox1.Text = "Policy file not found"
            End If
            PR.ShowDialog(Me)

            If PR.Accepted = True Then
                If System.IO.Directory.Exists(Me.AppRW.GetSetting("LogDirectoryPath").ToString & "\PolicyAgreements\") = False Then
                    System.IO.Directory.CreateDirectory(Me.AppRW.GetSetting("LogDirectoryPath").ToString & "\PolicyAgreements\")
                End If
                If IO.File.Exists(Me.AppRW.GetSetting("LogDirectoryPath").ToString & "\PolicyAgreements\" & FilePathName.Remove(0, FilePathName.LastIndexOf("\") + 1)) = False Then
                    System.IO.File.Copy(FilePathName, Me.AppRW.GetSetting("LogDirectoryPath").ToString & "\PolicyAgreements\" & FilePathName.Remove(0, FilePathName.LastIndexOf("\") + 1))
                End If
            End If
            SetPolicyProperty(PType, PR.Accepted)
            Return PR.Accepted
        End If
        Return OrginalValue
    End Function

    Private Sub SetPolicyProperty(ByVal Ptype As PolicyType, ByVal Accepted As Boolean)
        If Accepted = True Then
            Select Case Ptype
                Case PolicyType.Delete
                    Me.AppRW.setSetting("DeletePolicyAgreementSigned", "True")
                Case PolicyType.Zip
                    Me.AppRW.setSetting("FileCompressionPolicyAgreementSigned", "True")
            End Select
        Else
            Select Case Ptype
                Case PolicyType.Delete
                    Me.AppRW.setSetting("DeletePolicyAgreementSigned", "False")
                Case PolicyType.Zip
                    Me.AppRW.setSetting("FileCompressionPolicyAgreementSigned", "False")
            End Select
        End If
    End Sub

    Private Function EncryptPWD(ByVal strPWD As String) As String
        Dim myByteArray As Byte()
        Dim a As New System.Text.ASCIIEncoding
        Dim retValue As String
        Try
            myByteArray = a.GetBytes(strPWD)
            retValue = System.Convert.ToBase64String(myByteArray, 0, myByteArray.Length)
            Return retValue
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Return Nothing
    End Function

    Private Function DecodePWD(ByVal strPWD As String) As String
        Dim objUTF8 As System.Text.UTF8Encoding
        Dim retValue As String
        Try
            objUTF8 = New System.Text.UTF8Encoding
            retValue = objUTF8.GetString(Convert.FromBase64String(strPWD))
            Return retValue
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Return Nothing
    End Function

    Private Sub WizardMnuI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WizardMnuI.Click
        Dim WF As New WizardForm
        Me.Hide()
        RecordData()
        Dim Dr As DialogResult = WF.ShowDialog(Me)
        Me.Show()
        If Dr = Windows.Forms.DialogResult.Cancel Then
            'need to roll back changes.
            SetData()
        End If
    End Sub

    Private Sub RecordData()
        Me.DataRecord = New Collection
        With Me.DataRecord
            .Add(Me.GetGridValues(Me.DIRDG), "MonitoredEntireDirectories")
            .Add(Me.GetGridValues(Me.SpecDG), "MonitoredSpecificDirectories")
            .Add(Me.GetGridValues(Me.SerDG), "ServiceInterval")
            .Add(Me.GetGridValues(Me.DeleteDG), "DelOnlySpecificDirectories")
            .Add(Me.GetGridValues(Me.SMTPDG), "SmtpSVCDirectories")
            .Add(Me.CHK_EnableZip.Checked, "ZipFile")
            .Add(Me.CHK_EnableDelete.Checked, "DeleteFile")
            .Add(Me.CHK_MonitorZipDIR.Checked, "MonitorZipFilePath")
            .Add(Me.CHK_EnableSMTP.Checked, "ProcessSmtpSVCDirectories")
            .Add(Me.CHK_EnableDeleteOnly.Checked, "ProcessDelOnlySpecificDirectories")
            .Add(Me.CHK_SendMailReport.Checked, "SendMailReport", )
            .Add(Me.DeleteOrginalCHK.Checked, "DeleteOriginalFile")
            .Add(Me.ZipRetentionPeriod_Txt.Text, "ZipRetentionPeriod")
            .Add(Me.ZipFilePath_TXT.Text, "ZipFilePath")
            .Add(Me.DeleteRetentionPeriod_TXT.Text, "DeleteRetentionPeriod")
            .Add(Me.LogDirPath_TXT.Text, "LogDirectoryPath")
            .Add(Me.STMPRetentionPeriod_TXT.Text, "SmtpDeleteRetentionPeriod")
            .Add(Me.DeleteOnlyRetentionPeriod_TXT.Text, "DelOnlySpecificRetentionPeriod")
            .Add(Me.MailFrom_TXT.Text, "From")
            .Add(Me.MailPortNumber_NumUPDOWN.Value, "mailPort")
            .Add(Me.MailPWD_TXT.Text, "mailPWD")
            .Add(Me.MailServer_TXT.Text, "mailServer")
            .Add(Me.MailSubject_TXT.Text, "mailSubject")
            .Add(Me.MailTo_TXT.Text, "To")
            .Add(Me.MailUID_TXT.Text, "mailUID")
            'Added by Steve Schofield 12/3/04 - Mail Authentication
            .Add(Me.CHK_EnableMailAuth.Checked, "EnableMailAuth")
            .Add(Me.ZipCompressionCB.Text, "CompressionLevel")
            .Add(Me.GetNaming, "Naming")
            .Add(Me.CHK_AutoAddOptions, "AutoAddMonitoredSpecificDirectories")
            .Add(Me.CHK_W3SVC_AutoAddOptions, "AutoAddMonitoredSpecificDirectories_w3svc")
            .Add(Me.CHK_MSFTPSVC_AutoAddOptions, "AutoAddMonitoredSpecificDirectories_msftpsvc")
            .Add(Me.CHK_SMTPSVC_AutoAddOptions, "AutoAddMonitoredSpecificDirectories_smtpsvc")
            .Add(Me.CHK_ProcessXML, "ProcessXML")
            .Add(Me.CHK_ProcessTXT, "ProcessTXT")
            .Add(Me.CHK_ProcessDAT, "ProcessDAT")
            .Add(Me.CHK_ProcessBAK, "ProcessBAK")
            .Add(Me.CHK_EnablePerDirectory, "ZipPerDirectoryEnable")
            If Me.RDO_ZipFileStoragePreference1.Checked Then
                .Add("1", "LogsDWM")
            ElseIf Me.RDO_ZipFileStoragePreference2.Checked Then
                .Add("2", "LogsDWM")
            ElseIf Me.RDO_ZipFileStoragePreference3.Checked Then
                .Add("3", "LogsDWM")
            End If
            .Add(Me.CHK_UseMetabaseRoleService.Checked, "UseMetabaseRoleService")
        End With
    End Sub

    Private Sub SetData()
        With Me.DataRecord
            SetGridValues(LCase(.Item("MonitoredEntireDirectories")), Me.DIRDG)
            SetGridValues(LCase(.Item("MonitoredSpecificDirectories")), Me.SpecDG)
            SetGridValues(.Item("ServiceInterval"), Me.SerDG)
            SetGridValues(.Item("DelOnlySpecificDirectories"), Me.DeleteDG)
            SetGridValues(.Item("SmtpSVCDirectories"), Me.SMTPDG)
            Me.CHK_EnableZip.Checked = CType(.Item("ZIPfile"), Boolean)
            Me.CHK_EnableDelete.Checked = CType(.Item("DeleteFile"), Boolean)
            Me.CHK_MonitorZipDIR.Checked = CType(.Item("MonitorZipFilePath"), Boolean)
            Me.CHK_EnableSMTP.Checked = CType(.Item("ProcessSmtpSVCDirectories"), Boolean)
            Me.CHK_EnableDeleteOnly.Checked = CType(.Item("ProcessDelOnlySpecificDirectories"), Boolean)
            Me.CHK_SendMailReport.Checked = CType(.Item("SendMailReport"), Boolean)
            Me.DeleteOrginalCHK.Checked = CType(.Item("DeleteOriginalFile"), Boolean)
            Me.ZipRetentionPeriod_Txt.Text = .Item("ZipRetentionPeriod").ToString

            Me.ZipFilePath_TXT.Text = .Item("ZipFilePath").ToString
            Me.DeleteRetentionPeriod_TXT.Text = .Item("DeleteRetentionPeriod").ToString

            'Added by Steve Schofield - 10/13/2004
            'Insures the LogDirectoryPath Variable is set.
            If .Item("LogDirectoryPath").ToString.Trim <> "" Then
                Me.LogDirPath_TXT.Text = .Item("LogDirectoryPath").ToString
            Else
                Me.LogDirPath_TXT.Text = Application.StartupPath & "\Logs\"
                'Added by Steve Schofield 10/13/2004
                'Refreshs the local variable so other variables can reference the LogDirectoryPath
                Me.AppRW.setSetting("LogDirectoryPath", Application.StartupPath & "\Logs\")

                If IO.Directory.Exists(Me.LogDirPath_TXT.Text) = False Then
                    IO.Directory.CreateDirectory(Me.LogDirPath_TXT.Text)
                End If
            End If

            Me.STMPRetentionPeriod_TXT.Text = .Item("SmtpDeleteRetentionPeriod").ToString
            Me.DeleteOnlyRetentionPeriod_TXT.Text = .Item("DelOnlySpecificRetentionPeriod").ToString
            Me.MailFrom_TXT.Text = .Item("From").ToString
            Me.MailPortNumber_NumUPDOWN.Value = .Item("mailPort")
            Me.MailPWD_TXT.Text = .Item("mailPWD").ToString
            Me.MailServer_TXT.Text = .Item("mailServer").ToString
            Me.MailSubject_TXT.Text = .Item("mailSubject").ToString
            Me.MailTo_TXT.Text = .Item("To").ToString
            Me.MailUID_TXT.Text = .Item("mailUID").ToString
            If .Item("CompressionLevel").ToString.Trim <> "" Then
                Me.ZipCompressionCB.Text = .Item("CompressionLevel").ToString
            Else
                Me.ZipCompressionCB.Text = "Med"
            End If

            Me.SetNaming(.Item("Naming").ToString)

            'Added by Steve Schofield 12/3/04 - Mail Authentication
            Me.CHK_EnableMailAuth.Checked = CType(.Item("EnableMailAuth"), Boolean)

            'Added by Steve Schofield 9/12/2012 - Use Metabase Role Service
            Me.CHK_UseMetabaseRoleService.Checked = CType(.Item("UseMetabaseRoleService"), Boolean)
        End With
    End Sub

    Private Sub Rad_NameOptDefault_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rad_NameOptDefault.CheckedChanged
        If Rad_NameOptDefault.Checked = True Then
            Me.CustomGB.Enabled = False
        Else
            Me.CustomGB.Enabled = True
        End If
    End Sub

    Private Sub Rad_NameOptCustom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rad_NameOptCustom.CheckedChanged
        Rad_NameOptDefault_CheckedChanged(sender, e)
    End Sub

    Private Function GetNaming() As String
        If Me.Rad_NameOptCustom.Checked = True Then
            Return Me.TextBox1.Text & "!" & Me.ComboBox1.Text & "!" & Me.ComboBox2.Text & "!" & Me.ComboBox3.Text & "!" & Me.TextBox2.Text
        Else
            Return "Default"
        End If
    End Function

    Private Sub SetNaming(ByVal Value As String)
        If Value.Trim <> "" AndAlso Value.Trim <> "Default" Then
            Me.Rad_NameOptCustom.Checked = True
            Me.Rad_NameOptDefault.Checked = False
            Dim A() As String = Value.Split(Me.AppRW.GetSetting("Delimiter"))
            Me.TextBox1.Text = A(0)
            Me.ComboBox1.Text = A(1)
            Me.ComboBox2.Text = A(2)
            Me.ComboBox3.Text = A(3)
            Me.TextBox2.Text = A(4)
        Else
            Me.Rad_NameOptCustom.Checked = False
            Me.Rad_NameOptDefault.Checked = True
        End If
    End Sub

    Private Sub ZipFilePath_TXT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZipFilePath_TXT.TextChanged
        If Me.ZipFilePath_TXT.Text.Trim.ToLower = "local" Then
            Me.ZipPathOrg_RAD.Checked = True
            Me.ZipFilePath_TXT.Enabled = False
            Me.ZipFilePath_BTN.Enabled = False
        Else
            Me.ZipPathCustom_RAD.Checked = True
        End If
    End Sub

    Private Sub ZipPathOrg_RAD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZipPathOrg_RAD.CheckedChanged
        If Me.ZipPathOrg_RAD.Checked = True Then
            Me.ZipFilePath_TXT.Enabled = True
            RemoveHandler ZipFilePath_TXT.TextChanged, AddressOf ZipFilePath_TXT_TextChanged
            Me.ZipFilePath_TXT.Text = "local"
            AddHandler ZipFilePath_TXT.TextChanged, AddressOf ZipFilePath_TXT_TextChanged
            Me.ZipFilePath_TXT.Enabled = False
            Me.ZipFilePath_BTN.Enabled = False
            Me.CHK_MonitorZipDIR.Checked = False
            Me.CHK_MonitorZipDIR.Enabled = False
        End If
    End Sub

    Private Sub ZipPathCustom_RAD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZipPathCustom_RAD.CheckedChanged
        If Me.ZipPathCustom_RAD.Checked = True Then
            Me.ZipFilePath_TXT.Enabled = True
            Me.ZipFilePath_BTN.Enabled = True
            Me.CHK_MonitorZipDIR.Enabled = True
            'Changed by Steve Schofield 11/5/2004
            Me.ZipFilePath_TXT.Focus()
        End If
    End Sub

    Private Function GetDateTypePart(ByVal Value As String) As Char
        If Value.IndexOf("M") > -1 Then
            Return "M"
        ElseIf Value.IndexOf("Y") > -1 Then
            Return "Y"
        ElseIf Value.IndexOf("D") > -1 Then
            Return "D"
        End If
    End Function

    Private Sub CheckNameCombos(ByVal CurrentCombo As ComboBox)
        If CurrentCombo.Text.Trim <> "" Then
            Dim DatePart As Char
            DatePart = GetDateTypePart(CurrentCombo.Text)
            Select Case DatePart
                Case "M"
                    If Not ComboBox2 Is CurrentCombo AndAlso Me.GetDateTypePart(Me.ComboBox2.Text) = "M" Then
                        GoTo Problem
                    ElseIf Not ComboBox3 Is CurrentCombo AndAlso Me.GetDateTypePart(Me.ComboBox3.Text) = "M" Then
                        GoTo Problem
                    ElseIf Not ComboBox1 Is CurrentCombo AndAlso Me.GetDateTypePart(Me.ComboBox1.Text) = "M" Then
                        GoTo problem
                    End If
                Case "D"
                    If Not ComboBox2 Is CurrentCombo AndAlso Me.GetDateTypePart(Me.ComboBox2.Text) = "D" Then
                        GoTo Problem
                    ElseIf Not ComboBox3 Is CurrentCombo AndAlso Me.GetDateTypePart(Me.ComboBox3.Text) = "D" Then
                        GoTo Problem
                    ElseIf Not ComboBox1 Is CurrentCombo AndAlso Me.GetDateTypePart(Me.ComboBox1.Text) = "D" Then
                        GoTo problem
                    End If
                Case "Y"
                    If Not ComboBox2 Is CurrentCombo AndAlso Me.GetDateTypePart(Me.ComboBox2.Text) = "Y" Then
                        GoTo Problem
                    ElseIf Not ComboBox3 Is CurrentCombo AndAlso Me.GetDateTypePart(Me.ComboBox3.Text) = "Y" Then
                        GoTo Problem
                    ElseIf Not ComboBox1 Is CurrentCombo AndAlso Me.GetDateTypePart(Me.ComboBox1.Text) = "Y" Then
                        GoTo problem
                    End If
            End Select
            Exit Sub
Problem:
            MessageBox.Show("Date part used in another selection, please select a different date part", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CurrentCombo.Text = ""
            CurrentCombo.SelectedText = ""
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.CheckNameCombos(Me.ComboBox1)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Me.CheckNameCombos(Me.ComboBox2)
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Me.CheckNameCombos(Me.ComboBox3)
    End Sub

    'Added by Steve Schofield - 12/3/04
    'Handles Checkbox for Mail Authentication 
    Private Sub CHK_EnableMailAuth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_EnableMailAuth.CheckedChanged
        If Me.CHK_EnableMailAuth.Checked = True Then
            MailUID_TXT.Enabled = True
            MailPWD_TXT.Enabled = True
        Else
            MailUID_TXT.Enabled = False
            MailPWD_TXT.Enabled = False
        End If
    End Sub

    Private Sub PasswordEntryTxt2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PasswordEntryTxt2.Leave
        If Me.MailPWD_TXT.Text <> Me.PasswordEntryTxt2.Text Then
            MsgBox("Please re-enter passwords, in Mail settings, they do not match")
            Me.MailPWD_TXT.Text = ""
            Me.PasswordEntryTxt2.Text = ""
        End If
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAB_AutoAddOptions.Click
        If CHK_AutoAddOptions.Checked = False Then
            CHK_W3SVC_AutoAddOptions.Enabled = False
            CHK_W3SVC_AutoAddOptions.Checked = False

            CHK_MSFTPSVC_AutoAddOptions.Enabled = False
            CHK_MSFTPSVC_AutoAddOptions.Checked = False

            CHK_SMTPSVC_AutoAddOptions.Enabled = False
            CHK_SMTPSVC_AutoAddOptions.Checked = False
        End If
    End Sub

    Private Sub CHK_AutoAddOptions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_AutoAddOptions.CheckedChanged
        If CHK_AutoAddOptions.Checked = False Then
            CHK_W3SVC_AutoAddOptions.Enabled = False
            CHK_W3SVC_AutoAddOptions.Checked = False

            CHK_MSFTPSVC_AutoAddOptions.Enabled = False
            CHK_MSFTPSVC_AutoAddOptions.Checked = False

            CHK_SMTPSVC_AutoAddOptions.Enabled = False
            CHK_SMTPSVC_AutoAddOptions.Checked = False
        Else
            CHK_W3SVC_AutoAddOptions.Enabled = True
            CHK_MSFTPSVC_AutoAddOptions.Enabled = True
            CHK_SMTPSVC_AutoAddOptions.Enabled = True
        End If
    End Sub

    'Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
    '    Me.AppRW.AppConfigFIle = Me.OpenFileDialog1.FileName

    '    'load file
    '    Me.AppRW.Close()
    '    Me.AppRW.LoadConfigSource()

    '    'GetSettings()
    '    SetGridValues(Me.AppRW.GetSetting("MonitoredSpecificDirectories"), Me.SpecDG)
    '    Me.SpecDG.Refresh()
    'End Sub


    'Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Me.AppRW.AppConfigFIle = Me.OpenFileDialog1.FileName

    '    'load file
    '    Me.AppRW.Close()
    '    Me.AppRW.LoadConfigSource()

    '    'GetSettings()
    '    SetGridValues(Me.AppRW.GetSetting("MonitoredSpecificDirectories"), Me.SpecDG)
    '    Me.SpecDG.Refresh()
    'End Sub

    'Added by Joe 11/26/2006, this will resize the screen when tab 6 is selected
    'Private orgwidth As Integer
    'Private OrgX As Integer
    'Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
    '    If orgwidth = 0 Then
    '        orgwidth = Me.Width
    '        OrgX = Me.Bounds.X
    '    End If

    '    If Me.TabControl1.SelectedIndex = 6 Then
    '        Me.Location = New Point(0, Me.Location.Y)
    '        Me.Width = Screen.PrimaryScreen.Bounds.Width
    '    Else
    '        Me.Location = New Point(OrgX, Me.Location.Y)
    '        Me.Width = orgwidth
    '    End If
    'End Sub

    Private Sub DG_ZipDirectories_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG_ZipDirectories.Scroll
        '  RemoveHandler PNLHeader.Scroll, AddressOf PNLHeader_Scroll
        Me.PNLHeader.HorizontalScroll.Maximum = Me.DG_ZipDirectories.HozScrollBar.Maximum
        Me.PNLHeader.HorizontalScroll.Minimum = Me.DG_ZipDirectories.HozScrollBar.Minimum

        Me.PNLHeader.HorizontalScroll.Value = Me.DG_ZipDirectories.HozScrollBar.Value
        ' AddHandler PNLHeader.Scroll, AddressOf PNLHeader_Scroll
    End Sub

    'Private Sub PNLHeader_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles PNLHeader.Scroll
    '    RemoveHandler DG_ZipDirectories.Scroll, AddressOf DG_ZipDirectories_Scroll
    '    Me.DG_ZipDirectories.HozScrollBar.Value = Me.PNLHeader.HorizontalScroll.Value
    '    AddHandler DG_ZipDirectories.Scroll, AddressOf DG_ZipDirectories_Scroll
    'End Sub

    Sub RefreshGrid()
        Me.AppRW.AppConfigFIle = Me.OpenFileDialog1.FileName

        'load file
        Me.AppRW.Close()
        Me.AppRW.LoadConfigSource()

        'GetSettings()
        SetGridValues(LCase(Me.AppRW.GetSetting("MonitoredSpecificDirectories")), Me.SpecDG)
        Me.SpecDG.Refresh()
    End Sub


End Class