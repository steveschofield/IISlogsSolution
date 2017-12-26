Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

<ProvideProperty("CustomValidationEnabled", GetType(Control)), _
     ProvideProperty("DataType", GetType(Control)), _
     ProvideProperty("DisplayName", GetType(Control)), _
     ProvideProperty("MinValue", GetType(Control)), _
     ProvideProperty("MaxValue", GetType(Control)), _
     ProvideProperty("Required", GetType(Control)), _
     ProvideProperty("RegularExpression", GetType(Control))> _
    Public Class DataValidator
    Inherits System.ComponentModel.Component
    Implements IExtenderProvider

#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            ' remove all event handlers
            Dim ctrl As Control
            For Each ctrl In htProvidedProperties.Keys
                RemoveHandler ctrl.Validating, AddressOf ValidatingHandler
            Next
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region


    ' This procedure specifies which controls can be extended with this control.
    ' In this case, we only work with TextBoxes. 

    Public Function CanExtend(ByVal extendee As Object) As Boolean Implements IExtenderProvider.CanExtend
        If TypeOf extendee Is TextBox Then
            Return True
        Else
            Return False
        End If
    End Function

    ' this hashtable holds property values for individual controls
    Friend htProvidedProperties As New Hashtable

    '-----------------------------------------------
    ' public properties
    '-----------------------------------------------

    ' the ErrorProvider control where error messages can be shown (with icons, etc.)
    Dim m_ErrorProvider As ErrorProvider

    <Description("The control used to display an icon and a validation error message for invalid controls")> _
    Public Property ErrorProvider() As ErrorProvider
        Get
            Return m_ErrorProvider
        End Get
        Set(ByVal Value As ErrorProvider)
            m_ErrorProvider = Value
        End Set
    End Property


    Dim m_InvalidBackColor As Color = Nothing
    <Description("The background color for controls with invalid data")> _
    Public Property InvalidBackColor() As Color
        Get
            Return m_InvalidBackColor
        End Get
        Set(ByVal Value As Color)
            m_InvalidBackColor = Value
        End Set
    End Property

    ' The control where error messages can be displayed (e.g. label or status bar)
    Dim m_DisplayControl As Control

    ' The tooltip provider control where error messages can be shown as a tooltip.
    Dim m_TooltipProvider As ToolTip

    <Description("The control used to display validation error messages as tooltips")> _
    Public Property TooltipProvider() As ToolTip
        Get
            Return m_TooltipProvider
        End Get
        Set(ByVal Value As ToolTip)
            m_TooltipProvider = Value
        End Set
    End Property

    <Description("The control used to display validation error messages")> _
    Public Property DisplayControl() As Control
        Get
            Return m_DisplayControl
        End Get
        Set(ByVal Value As Control)
            m_DisplayControl = Value
        End Set
    End Property

    ' Set this property to False to disable validation on events.
    Dim m_Enabled As Boolean = True

    <Description("Enable or disable validation"), DefaultValue(True)> _
    Property Enabled() As Boolean
        Get
            Return m_Enabled
        End Get
        Set(ByVal Value As Boolean)
            m_Enabled = Value
        End Set
    End Property

    '-----------------------------------------------
    ' public methods
    '-----------------------------------------------

    ' Return True if a control is valid

    Public Function ValidateControl(ByVal ctrl As Control) As Boolean
        Dim sErrorMessage As String = GetErrorMessage(ctrl)
        If sErrorMessage = String.Empty Then
            Return True
        Else
            ProcessError(ctrl)
            Return False
        End If
    End Function

    <Browsable(False)> Public ReadOnly Property InvalidCount() As Integer
        Get

            ' tells how many controls have a problem
            Dim iInvalidControls As Integer = 0
            Dim ctrl As Control
            For Each ctrl In htProvidedProperties.Keys
                If Not ValidateControl(ctrl) Then
                    iInvalidControls += 1
                End If
            Next
            Return iInvalidControls
        End Get
    End Property

    Public ReadOnly Property InvalidControl(ByVal iIndex As Integer) As Control
        ' Returns an individual invalid control, based on its index
        Get
            Dim iInvalidControls As Integer = 0
            Dim ctrl As Control

            ' Since we don't know on the fly which controls
            ' are valid and which are not, it's necessary to simply
            ' scan through the collection looking for errors and
            ' count until we get the right number of invalid controls.
            For Each ctrl In htProvidedProperties.Keys
                If Not ValidateControl(ctrl) Then
                    If iInvalidControls = iIndex Then
                        Return ctrl
                    End If
                    iInvalidControls += 1
                End If
            Next

            ' If there isn't one, return nothing. 
            Return Nothing
        End Get
    End Property

    <Browsable(False)> _
Public ReadOnly Property InvalidMessages() As ArrayList
        Get
            Dim sMessage As String
            Dim ctrl As Control
            Dim colInvalidMessages As New SortedList(Me.InvalidCount)


            ' Loop through controls and find which ones are invalid.
            ' Get the invalid message for each.
            ' Stuff the messages into a SortedList 
            ' using the TabOrder for the control to 
            ' establish the correct order.
            For Each ctrl In htProvidedProperties.Keys
                sMessage = GetErrorMessage(ctrl)
                If Not sMessage = String.Empty Then
                    colInvalidMessages.Add(ctrl.TabIndex, sMessage)
                End If
            Next

            Dim colErrorsByIndex As New ArrayList
            Dim obj As Object
            For Each obj In colInvalidMessages.Values
                sMessage = CType(obj, String)
                colErrorsByIndex.Add(sMessage)

            Next
            Return colErrorsByIndex
        End Get
    End Property



    ' validate all the controls in the hashtable

    Public Function ValidateAll() As Boolean
        Dim ctrl As Control
        Dim bError As Boolean = True
        For Each ctrl In htProvidedProperties.Keys
            If Not ValidateControl(ctrl) Then
                bError = False
            End If
        Next
        Return bError

    End Function

    <Browsable(False)> Public ReadOnly Property ValidationSummary() As String
        Get
            Dim sMessage As String = ""
            Dim colInvalidMessages As ArrayList

            ' Get invalid messages ordered by TabOrder of controls
            colInvalidMessages = Me.InvalidMessages

            ' Append together to get a complete summary. 
            ' Messages are separated by carriage return - line feeds.
            Dim ctlIndex As Object
            For Each ctlIndex In colInvalidMessages
                Dim sThisMessage As String

                sThisMessage = CType(ctlIndex, String)

                If Len(sThisMessage) > 0 Then
                    If Len(sMessage) > 0 Then
                        sMessage &= vbCrLf
                    End If
                    sMessage &= " - " & sThisMessage
                End If
            Next
            Return sMessage

        End Get
    End Property

    ' we need two MethodInfo initialized variables
    Dim wmCloseMethod As Reflection.MethodInfo = GetType(Form).GetMethod("WmClose", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
    Dim wndProcMethod As Reflection.MethodInfo = GetType(Form).GetMethod("WndProc", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)

    ' this helper procedure tests whether the form is being closed

    Friend Function FormIsClosing() As Boolean
        ' we use reflection to walk up the stack and search
        ' for a procedure
        Dim st As New System.Diagnostics.StackTrace
        Dim i As Integer
        ' we can ignore this procedure and its caller
        For i = 2 To st.FrameCount - 1
            Dim sf As System.Diagnostics.StackFrame = st.GetFrame(i)
            Dim mi As Reflection.MethodInfo = CType(sf.GetMethod, Reflection.MethodInfo)

            If mi Is wmCloseMethod Then Return True
            If mi Is wndProcMethod Then Exit For
        Next
    End Function

    '-----------------------------------------------
    ' public methods
    '-----------------------------------------------

    ' return the error message for a control, or "" if no error

    Public Function GetErrorMessage(ByVal ctrl As Control) As String
        ' this array is used to speed up validation against the DataType property
        ' IMPORTANT: its elements must match the ordering of DataTypeConstants
        Static types() As Type = {GetType(String), GetType(Byte), GetType(Int16), GetType(Int32), GetType(Int64), GetType(Single), GetType(Double), GetType(Decimal), GetType(DateTime)}

        ' get the corresponding set of provided properties
        Dim ProvidedProperties As TextboxValidatorProvidedProperties = DirectCast(htProvidedProperties(ctrl), TextboxValidatorProvidedProperties)
        Dim sDisplayName As String
        If ProvidedProperties.DisplayName = String.Empty Then
            sDisplayName = ctrl.Name
        Else
            sDisplayName = ProvidedProperties.DisplayName
        End If

        Dim value As String = ctrl.Text

        ' If Required is true and TextBox is empty, 
        ' then return validation error. If not required,
        ' it's OK to be empty, and don't check anything else.
        If value.Length = 0 Then
            If ProvidedProperties.Required Then
                Return sDisplayName & " is required."
            Else
                ' if not required, return OK
                Return String.Empty
            End If
        End If

        Dim valueType As Type = types(CInt(ProvidedProperties.DataType))

        ' Validate against the DataType property.
        Try
            'Attempt the conversion, return False if any exception.
            Dim o As Object = Convert.ChangeType(value, valueType)

            ' Additional validation for integer types. This should not normally
            ' happen because we are checking keystrokes, but it could happen
            ' if the user does a paste with invalid data. 
            Select Case ProvidedProperties.DataType
                Case DataTypeConstants.ByteType, DataTypeConstants.Int16Type, DataTypeConstants.Int32Type, DataTypeConstants.Int64Type
                    If CDec(value) <> CLng(value) Then
                        Return "**No fractional part is allowed in textbox " & sDisplayName & "**"
                    End If
            End Select

        Catch ex As Exception
            Return "**Entry in textbox " & sDisplayName & " can't be converted to type " & valueType.Name & "**"
        End Try

        ' validate against the RegularExpression property
        If ProvidedProperties.RegularExpression.Length > 0 Then
            ' note that we must enclose the regex between ^ and $
            If Not System.Text.RegularExpressions.Regex.IsMatch(value, "^" & ProvidedProperties.RegularExpression & "$") Then
                Return "**Entry in textbox " & sDisplayName & " doesn't match expected format**"
            End If
        End If

        ' validate against the MinValue and MaxValue property
        If ProvidedProperties.MinValue.Length > 0 Then
            ' perform type-agnostic comparison
            If CDbl(Convert.ChangeType(value, valueType)) < CDbl(Convert.ChangeType(ProvidedProperties.MinValue, valueType)) Then
                Return "**Entry in textbox " & sDisplayName & " is too low**"
            End If
        End If
        If ProvidedProperties.MaxValue.Length > 0 Then
            ' perform type-agnostic comparison
            If CDbl(Convert.ChangeType(value, valueType)) > CDbl(Convert.ChangeType(ProvidedProperties.MaxValue, valueType)) Then
                Return sDisplayName & " is greater than the maximum value of " & ProvidedProperties.MaxValue
            End If
        End If

        ' all tests passed
        Return String.Empty
    End Function

    '-----------------------------------------------
    ' provided properties
    '-----------------------------------------------

    ' This procedure ensures that the hashtable collection
    ' contains an element for the control, and adds it if necessary.

    Private Function GetAddControl(ByVal ctrl As Control) As TextboxValidatorProvidedProperties
        If htProvidedProperties.Contains(ctrl) Then
            Return DirectCast(htProvidedProperties(ctrl), TextboxValidatorProvidedProperties)
        Else
            ' add an element to the hashtable
            Dim ProvidedProperties As New TextboxValidatorProvidedProperties
            htProvidedProperties.Add(ctrl, ProvidedProperties)

            ' Trap the Validating event and KeyUp events
            AddHandler ctrl.Validating, AddressOf ValidatingHandler
            AddHandler ctrl.KeyUp, AddressOf CheckOnKeystrokeHandler
            Return ProvidedProperties
        End If
    End Function

    ' The CustomValidationEnabled property

    Function GetCustomValidationEnabled(ByVal ctrl As Control) As Boolean
        If htProvidedProperties.Contains(ctrl) Then
            Return DirectCast(htProvidedProperties(ctrl), TextboxValidatorProvidedProperties).CustomValidationEnabled
        Else
            Return True
        End If
    End Function

    Sub SetCustomValidationEnabled(ByVal ctrl As Control, ByVal value As Boolean)
        GetAddControl(ctrl).CustomValidationEnabled = value
    End Sub

    ' the DataType property

    Function GetDataType(ByVal ctrl As Control) As DataTypeConstants
        If htProvidedProperties.Contains(ctrl) Then
            Return DirectCast(htProvidedProperties(ctrl), TextboxValidatorProvidedProperties).DataType
        Else
            Return DataTypeConstants.StringType
        End If
    End Function

    Sub SetDataType(ByVal ctrl As Control, ByVal value As DataTypeConstants)
        GetAddControl(ctrl).DataType = value
        Select Case value
            Case DataTypeConstants.DecimalType, DataTypeConstants.DoubleType, DataTypeConstants.SingleType
                AddHandler ctrl.KeyPress, AddressOf DecimalKeyPressHandler
            Case DataTypeConstants.Int16Type, DataTypeConstants.Int32Type, DataTypeConstants.Int64Type
                AddHandler ctrl.KeyPress, AddressOf IntegerKeyPressHandler
        End Select
    End Sub

    ' the RegularExpression property

    Function GetRegularExpression(ByVal ctrl As Control) As String
        If htProvidedProperties.Contains(ctrl) Then
            Return DirectCast(htProvidedProperties(ctrl), TextboxValidatorProvidedProperties).RegularExpression
        Else
            Return String.Empty
        End If
    End Function

    Sub SetRegularExpression(ByVal ctrl As Control, ByVal value As String)
        If value Is Nothing Then value = ""
        GetAddControl(ctrl).RegularExpression = value
    End Sub

    ' the MinValue property

    Function GetMinValue(ByVal ctrl As Control) As String
        If htProvidedProperties.Contains(ctrl) Then
            Return DirectCast(htProvidedProperties(ctrl), TextboxValidatorProvidedProperties).MinValue
        Else
            Return String.Empty
        End If
    End Function

    Sub SetMinValue(ByVal ctrl As Control, ByVal value As String)
        If value Is Nothing Then value = String.Empty
        GetAddControl(ctrl).MinValue = value
    End Sub

    ' the MaxValue property

    Function GetMaxValue(ByVal ctrl As Object) As String
        If htProvidedProperties.Contains(ctrl) Then
            Return DirectCast(htProvidedProperties(ctrl), TextboxValidatorProvidedProperties).MaxValue
        Else
            Return String.Empty
        End If
    End Function

    Sub SetMaxValue(ByVal ctrl As Control, ByVal value As String)
        If value Is Nothing Then value = String.Empty
        GetAddControl(ctrl).MaxValue = value
    End Sub

    ' the Required property

    Function GetRequired(ByVal ctrl As Control) As Boolean
        If htProvidedProperties.Contains(ctrl) Then
            Return DirectCast(htProvidedProperties(ctrl), TextboxValidatorProvidedProperties).Required
        Else
            Return False
        End If
    End Function

    Sub SetRequired(ByVal ctrl As Control, ByVal value As Boolean)
        GetAddControl(ctrl).Required = value
    End Sub

    ' the DisplayName property

    Function GetDisplayName(ByVal ctrl As Control) As String
        If htProvidedProperties.Contains(ctrl) Then
            Return DirectCast(htProvidedProperties(ctrl), TextboxValidatorProvidedProperties).DisplayName
        Else
            Return String.Empty
        End If
    End Function

    Sub SetDisplayName(ByVal ctrl As Control, ByVal value As String)
        If value Is Nothing Then value = String.Empty
        GetAddControl(ctrl).DisplayName = value
    End Sub

    ' the Validating event handler

    Private Sub ValidatingHandler(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        ' ignore the event if the control is disabled
        If Not Me.Enabled Then Exit Sub

        ' ignore if the form is closing
        If FormIsClosing() Then Exit Sub

        ' Get the control to work with and the collection item associated
        ' with the control
        Dim ctrl As Control
        ctrl = CType(sender, Control)
        ProcessError(ctrl)
    End Sub

    Private Sub CheckOnKeystrokeHandler(ByVal sender As Object, ByVal e As KeyEventArgs)
        ' ignore the event if the control is disabled
        If Not Me.Enabled Then Exit Sub

        ' ignore if the form is closing
        If FormIsClosing() Then Exit Sub

        ' Get the control to work with and the collection item associated
        ' with the control
        Dim ctrl As Control
        ctrl = CType(sender, Control)
        ProcessError(ctrl)
    End Sub

    ' This handler checks keystrokes as they are entered, dropping any
    ' that would result in invalid data.
    Private Sub IntegerKeyPressHandler(ByVal sender As Object, ByVal e As KeyPressEventArgs)

        ' First check for a digit. It's OK, so exit if found.
        If Char.IsDigit(e.KeyChar) Then
            Exit Sub
        End If

        ' Now have to check stuff relative to what else
        ' is in the textbox already, so get a ref to the textbox.
        Dim ctrl As TextBox
        ctrl = CType(sender, TextBox)

        ' Convert the char to a string because otherwise the select case
        ' doesn't work well. 
        Select Case e.KeyChar.ToString

            ' For minus sign, make sure just one and at
            ' beginning of text box.
        Case "-"
                If ctrl.SelectionStart = 0 Then
                    If InStr(ctrl.Text, "-") = 0 Then
                        Exit Sub
                    End If
                End If

                ' These characters are all OK
            Case vbCr, vbLf, vbTab, Chr(8), Chr(22), Chr(24), Chr(3)
                ' Carriage return, Line feed, tab, Backspace, Paste, cut, copy
                Exit Sub

        End Select

        e.Handled = True

    End Sub

    ' This handler checks keystrokes as they are entered, dropping any
    ' that would result in invalid data.
    Private Sub DecimalKeyPressHandler(ByVal sender As Object, ByVal e As KeyPressEventArgs)

        ' First check for a digit. It's OK, so exit if found.
        If Char.IsDigit(e.KeyChar) Then
            Exit Sub
        End If

        ' Now have to check stuff relative to what else
        ' is in the textbox already, so get a ref to the textbox.
        Dim ctrl As TextBox
        ctrl = CType(sender, TextBox)

        ' Convert the char to a string because otherwise the select case
        ' doesn't work well. 
        Select Case e.KeyChar.ToString

            ' For minus sign, make sure just one and at
            ' beginning of text box.
        Case "-"
                If ctrl.SelectionStart = 0 Then
                    If InStr(ctrl.Text, "-") = 0 Then
                        Exit Sub
                    End If
                End If

                ' For period, need to make sure just one.
            Case "."
                If InStr(ctrl.Text, ".") = 0 Then
                    Exit Sub
                End If

                ' These characters are all OK
            Case vbCr, vbLf, vbTab, Chr(8), Chr(22), Chr(24), Chr(3)
                ' Carriage return, Line feed, tab, Backspace, Paste, cut, copy
                Exit Sub

        End Select

        ' If we got here, the keypress is not valid. 
        ' Dump it by marking the event as handled. 
        ' That way the base class never gets a shot at it.
        e.Handled = True

    End Sub

    Public Sub ProcessError(ByVal ctrl As Control)
        Dim ctrlProperties As TextboxValidatorProvidedProperties
        ctrlProperties = CType(htProvidedProperties(ctrl), TextboxValidatorProvidedProperties)


        ' Fetch the error message - it may be empty, which means no error.
        Dim msg As String = GetErrorMessage(ctrl)

        ' Fix the background color and tooltip if any error.
        If msg.Length > 0 Then

            ' See if we've got a color. If not, skip this part.
            If Not Me.InvalidBackColor.Equals(System.Drawing.Color.Empty) Then

                ' Store the old background color first.
                If Not ctrl.BackColor.Equals(Me.InvalidBackColor) Then
                    ctrlProperties.NormalBackColor = ctrl.BackColor
                End If
                ctrl.BackColor = Me.InvalidBackColor
            End If

            ' Store existing tooltip and set new one if necessary.
            If Not Me.TooltipProvider Is Nothing Then

                ' It's not an invalid message unless it starts with two asterisks.
                If Not Left(Me.TooltipProvider.GetToolTip(ctrl), 2) = "**" Then
                    ctrlProperties.ExistingToolTip = Me.TooltipProvider.GetToolTip(ctrl)

                End If
                Me.TooltipProvider.SetToolTip(ctrl, msg)

            End If

        Else
            ctrl.BackColor = ctrlProperties.NormalBackColor
            If Not Me.TooltipProvider Is Nothing Then
                Me.TooltipProvider.SetToolTip(ctrl, ctrlProperties.ExistingToolTip)
            End If

        End If

        ' Display validation message in the associated display control, if any.
        ' This will clear previous error message if this control is now ok.
        If Not Me.DisplayControl Is Nothing Then
            Me.DisplayControl.Text = msg
        End If

        ' Unconditionally set the Error message in the ErrorProvider.
        ' Unlike the tooltip, there's no possible existing error 
        ' that needs to be saved.
        If Not Me.ErrorProvider Is Nothing Then
            Me.ErrorProvider.SetError(ctrl, msg)
        End If

    End Sub

    ' A Friend class that defines all the provided properties. It also stores
    ' some information needed to restore previous states in a control.

    Private Class TextboxValidatorProvidedProperties
        Public DataType As DataTypeConstants
        Public RegularExpression As String = String.Empty
        Public MinValue As String = String.Empty
        Public MaxValue As String = String.Empty
        Public Required As Boolean = False
        Public ExistingToolTip As String
        Public NormalBackColor As Color = SystemColors.Window
        Public DisplayName As String
        Public CustomValidationEnabled As Boolean = True
    End Class
End Class



' A public Enum with all possible values for DataType property. Note that
' if this is changed, there is logic in GetErrorMessage that will also
' need to be changed.

Public Enum DataTypeConstants
    StringType
    ByteType
    Int16Type
    Int32Type
    Int64Type
    SingleType
    DoubleType
    DecimalType
    DateTimeType
End Enum
