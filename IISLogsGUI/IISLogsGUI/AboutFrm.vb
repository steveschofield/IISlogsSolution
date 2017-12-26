Public Class AboutFrm
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
    Friend WithEvents lblAboutForm1 As System.Windows.Forms.Label
    Friend WithEvents lnkLblAboutForm1 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblAboutFrm2 As System.Windows.Forms.Label
    Friend WithEvents lblCopyRight As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblAboutForm1 = New System.Windows.Forms.Label
        Me.lnkLblAboutForm1 = New System.Windows.Forms.LinkLabel
        Me.lblAboutFrm2 = New System.Windows.Forms.Label
        Me.lblCopyRight = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblAboutForm1
        '
        Me.lblAboutForm1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAboutForm1.Location = New System.Drawing.Point(16, 8)
        Me.lblAboutForm1.Name = "lblAboutForm1"
        Me.lblAboutForm1.Size = New System.Drawing.Size(264, 48)
        Me.lblAboutForm1.TabIndex = 0
        Me.lblAboutForm1.Text = "IISLogs file compression and delete utility"
        '
        'lnkLblAboutForm1
        '
        Me.lnkLblAboutForm1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkLblAboutForm1.Location = New System.Drawing.Point(24, 96)
        Me.lnkLblAboutForm1.Name = "lnkLblAboutForm1"
        Me.lnkLblAboutForm1.Size = New System.Drawing.Size(216, 23)
        Me.lnkLblAboutForm1.TabIndex = 1
        Me.lnkLblAboutForm1.TabStop = True
        Me.lnkLblAboutForm1.Text = "http://www.IISLogs.com"
        '
        'lblAboutFrm2
        '
        Me.lblAboutFrm2.Location = New System.Drawing.Point(24, 64)
        Me.lblAboutFrm2.Name = "lblAboutFrm2"
        Me.lblAboutFrm2.Size = New System.Drawing.Size(200, 16)
        Me.lblAboutFrm2.TabIndex = 2
        Me.lblAboutFrm2.Text = "For help, questions or feedback visit"
        '
        'lblCopyRight
        '
        Me.lblCopyRight.Location = New System.Drawing.Point(24, 144)
        Me.lblCopyRight.Name = "lblCopyRight"
        Me.lblCopyRight.Size = New System.Drawing.Size(270, 14)
        Me.lblCopyRight.TabIndex = 3
        Me.lblCopyRight.Text = "© 2004 - 2006 IISLogs, LLC.  All rights reserved."
        '
        'AboutFrm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(306, 167)
        Me.Controls.Add(Me.lblCopyRight)
        Me.Controls.Add(Me.lblAboutFrm2)
        Me.Controls.Add(Me.lnkLblAboutForm1)
        Me.Controls.Add(Me.lblAboutForm1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutFrm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About IISLogs"
        Me.ResumeLayout(False)

    End Sub

#End Region

 
    Private Sub lnkLblAboutForm1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLblAboutForm1.LinkClicked
        lnkLblAboutForm1.LinkVisited = True
        System.Diagnostics.Process.Start("http://www.iislogs.com")
    End Sub
End Class
