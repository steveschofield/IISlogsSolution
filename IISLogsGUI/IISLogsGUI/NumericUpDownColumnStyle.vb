Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Diagnostics



Namespace DataGridExtensions

    Public Class NumericUpDownColumnStyle
        Inherits DataGridColumnStyle


        Private NUD As New DataGridExtensions.NumericUpDown

        ' These variables track the editing state.
        Private OrginalValue As Integer
        Private inEdit As Boolean = False

        Private xMargin As Integer = 2
        Private yMargin As Integer = 1



        Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
            If Not DesignMode Then
                Try
                    RemoveHandler NUD.ValueChanged, AddressOf ValueChanged
                    '  AddHandler NUD.ValueChanged, AddressOf ValueChanged

                    'Store the real bounds
                    Dim originalBounds As Rectangle = bounds

                    'Set the selected value for the Combobox
                    'This attempts to deal with null values
                    'and fails
                    Dim value As Object
                    If source.Position <> -1 Then
                        Try
                            value = GetColumnValueAtRow([source], rowNum)
                        Catch
                            value = DBNull.Value
                        End Try
                    Else
                        source.AddNew()
                        value = DBNull.Value
                    End If

                    'If CType(source.Current, DataRowView).IsNew = True Then
                    '    CType(source.Current, DataRowView).BeginEdit()
                    '    CType(source.Current, DataRowView).EndEdit()
                    'End If

                    If Not value.Equals(DBNull.Value) Then
                        NUD.Value = value
                    Else
                        NUD.Value = 0

                    End If

                    ' If we have instanceText push this into the Combobox
                    ' I'm unclear on when this happens also very inefficient
                    ' because it causes a scan across the combobox values
                    'If Not (instantText Is Nothing) Then
                    '    combo.Text = instantText
                    'End If

                    ' Store the old value in case of a rollback
                    ' Store the index because index based lookups are more efficient
                    OrginalValue = NUD.Value

                    'If the cell is visible then adjust the size of the
                    'combobox otherwise leave it as is
                    If cellIsVisible Then
                        bounds.Offset(xMargin, yMargin)
                        bounds.Width -= xMargin * 2
                        bounds.Height -= yMargin
                        NUD.Bounds = bounds
                        NUD.Visible = True
                    Else
                        NUD.Bounds = originalBounds
                        NUD.Visible = False
                    End If

                    'If the cell is readonly don't allow editing of the value
                    'this.ReadOnly only reflects readonly on the Column not on the Grid 
                    'or the TableStyle. The readonly parameter also reflects 
                    'IBindingList.AllowEdit 
                    'RealReadOnly takes all of these things into account and so I ignore 
                    'the readonly param passed into this method
                    NUD.Enabled = Not Me.ReadOnly

                    NUD.RightToLeft = Me.DataGridTableStyle.DataGrid.RightToLeft

                    'Set the selection
                    'If instantText Is Nothing Then
                    '    combo.SelectAll()
                    'Else
                    '    Dim [end] As Integer = combo.Text.Length
                    '    combo.Select([end], 0)
                    'End If

                    'If necessary repaint the grid
                    If NUD.Visible Then
                        DataGridTableStyle.DataGrid.Invalidate(originalBounds)
                    End If

                    'Hook up the change events to determine when the user 
                    'starts to edit the value either by typing or by 
                    'changing the selected value
                    '   RemoveHandler NUD.ValueChanged, AddressOf ValueChanged
                    AddHandler NUD.ValueChanged, AddressOf ValueChanged

                    'Finally make sure the combobox has focus
                    NUD.Focus()
                Catch Err As Exception
                    MsgBox(Err.Message & " " & Err.StackTrace)
                End Try
            End If
        End Sub

        Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean
            If Not DesignMode Then
                HideDTP()

                'If dataSource.Position > -1 Then
                '    If CType(dataSource.Current, DataRowView).IsNew = True Then

                '        If NUD.Checked = True Then
                '            CType(dataSource.Current, DataRowView).EndEdit()
                '        Else
                '            'SetColumnValueAtRow(dataSource, rowNum, DBNull.Value)
                '            CType(dataSource.Current, DataRowView).CancelEdit()
                '            'EndEdit()

                '            ''If necessary repaint the grid
                '            'If NUD.Visible Then
                '            '    DataGridTableStyle.DataGrid.Invalidate(NUD.Bounds)
                '            'End If
                '            Return False
                '        End If
                '    End If
                'End If
                ' If we are not in an edit, simply return.
                If Not inEdit Then
                    Return True
                End If
                'Now get the value out of the ComboBox and push it back
                'into the datamodel
                Try
                    Dim DTPValue As Integer = NUD.Value
                    Dim value As Object = Nothing

                    ' If the Combo Text is equal to the NullText, then set the value 
                    ' to DBNull otherwise set the selected value back into the grid
                    ' Done like this because the selected value may not be a string
                  

                    value = NUD.Value

                    'If the user types in a value we don't automatically pick it up 
                    ' as the selected value so force the best fit value
                    


                    'Push the value back into the DataGrid 
                    If dataSource.Position = rowNum Then
                        ' If dataSource.Position <> -1 Then
                        SetColumnValueAtRow(dataSource, rowNum, value)
                    End If
                Catch Err As Exception
                    MsgBox(Err.Message & " " & Err.StackTrace)
                End Try
                'Should possibly EndEdit here
                EndEdit()
            End If
            Return True
        End Function

        Protected Overrides Function GetPreferredSize(ByVal g As System.Drawing.Graphics, ByVal value As Object) As System.Drawing.Size
            'Debug.WriteLine("Start GetPreferredSize " + value);
            Try
                Dim [text] As String = value
                Dim textFont As Font = Me.DataGridTableStyle.DataGrid.Font
                Dim dataGridLineWidth As Integer
                If Me.DataGridTableStyle.GridLineStyle = DataGridLineStyle.Solid Then
                    dataGridLineWidth = 1
                Else
                    dataGridLineWidth = 0
                End If 'ToDo: Unsupported feature: conditional (?) operator.

                Dim preferredSize As Size = Size.Ceiling(g.MeasureString([text], textFont))
                preferredSize.Width += xMargin * 2 + dataGridLineWidth
                preferredSize.Height += yMargin
                Return preferredSize
            Catch Err As Exception
                MsgBox(Err.Message & " " & Err.StackTrace)
            End Try
        End Function

        Protected Overrides Function GetMinimumHeight() As Integer
            Return NUD.PreferredHeight + yMargin
        End Function

        Protected Overrides Function GetPreferredHeight(ByVal g As System.Drawing.Graphics, ByVal value As Object) As Integer
            Return Math.Min(Me.GetPreferredSize(g, value).Height, Me.GetMinimumHeight())
        End Function



        Protected Overrides Sub Abort(ByVal rowNum As Integer)
            RollBack()
            HideDTP()
            EndEdit()
        End Sub


        Private Sub ValueChanged(ByVal Sender As Object, ByVal E As EventArgs)
            InEditMode = True
        End Sub


        '     Called when we stop editing a value 
        Private Sub EndEdit()
            InEditMode = False
            Invalidate()
        End Sub 'EndEdit

        Private Sub HideDTP()
            If NUD.Focused Then
                Me.DataGridTableStyle.DataGrid.Focus()
            End If
            NUD.Visible = False
            NUD.Visible = False
        End Sub 'Hide dtp

        Private Sub RollBack()
            Try
                NUD.Value = OrginalValue
            Catch Err As Exception
                MsgBox(Err.Message & " " & Err.StackTrace)
            End Try
        End Sub 'RollBack

        Private Property InEditMode() As Boolean
            Get
                Return inEdit
            End Get
            Set(ByVal Value As Boolean)
                If Value = inEdit Then
                    Return
                End If
                inEdit = Value
                If inEdit Then
                    Me.ColumnStartedEditing(NUD)
                End If
            End Set
        End Property

        Protected Overrides Sub SetDataGridInColumn(ByVal value As System.Windows.Forms.DataGrid)
            Try
                MyBase.SetDataGridInColumn(value)
                If Not NUD.Parent Is value Then
                    If Not (NUD.Parent Is Nothing) Then
                        NUD.Parent.Controls.Remove(NUD)
                        NUD.Parent = Nothing
                    End If
                End If
                If Not (value Is Nothing) Then
                    NUD.Visible = False
                    value.Controls.Add(NUD)
                End If
            Catch Err As Exception
                MsgBox(Err.Message & " " & Err.StackTrace)
            End Try
        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal alignToRight As Boolean)
            Dim backBrush As Brush = New SolidBrush(Me.DataGridTableStyle.BackColor)
            Try
                Dim foreBrush As Brush = New SolidBrush(Me.DataGridTableStyle.ForeColor)
                Try
                    Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
                Finally
                    foreBrush.Dispose()
                End Try
            Finally
                backBrush.Dispose()
            End Try
        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer)
            Paint(g, bounds, source, rowNum, False)
        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
            Dim rect As Rectangle = bounds

            If Not DesignMode Then
                Dim format As New StringFormat
                Try
                    Dim ValueINT As String = Nothing
                    Try
                        If source.Position <> -1 Then
                            If IsDBNull(GetColumnValueAtRow(source, rowNum)) = False Then
                                ValueINT = GetColumnValueAtRow(source, rowNum)
                            Else
                                ValueINT = Nothing
                            End If
                        Else
                            ValueINT = Nothing
                        End If
                    Catch
                        '     valuedate = dbnull.Value 
                    End Try



                    If alignToRight Then
                        format.FormatFlags = format.FormatFlags Or StringFormatFlags.DirectionRightToLeft
                    End If

                    If Me.Alignment = HorizontalAlignment.Left Then
                        format.Alignment = StringAlignment.Near
                    Else
                        If Me.Alignment = HorizontalAlignment.Center Then
                            format.Alignment = StringAlignment.Center
                        Else
                            format.Alignment = StringAlignment.Far
                        End If
                    End If
                    format.FormatFlags = format.FormatFlags Or StringFormatFlags.NoWrap

                    g.FillRectangle(backBrush, rect)

                    ' We want painting to leave a little padding around the rectangle,
                    ' so reduce the size of rectangle by the margin
                    rect.Offset(0, yMargin)
                    rect.Height -= yMargin

        

                    g.DrawString(ValueINT, Me.DataGridTableStyle.DataGrid.Font, foreBrush, rect.X, rect.Y, format)

                Catch Err As Exception
                    MsgBox(Err.Message & " " & Err.StackTrace)
                Finally
                    format.Dispose()
                End Try
            Else
                g.FillRectangle(Brushes.White, rect)
                g.DrawRectangle(New Pen(Color.Black, 2), rect)
            End If
        End Sub

        Protected Overrides Sub EnterNullValue()
            Try
                'Tell the combo its in Edit Mode
                inEdit = True

                'Set the combo box value to the null text value
                NUD.Value = 0
                
            Catch Err As Exception
                MsgBox(Err.Message & " " & Err.StackTrace)
            End Try
        End Sub

        Protected Overrides Sub ConcedeFocus()
            NUD.Visible = False
        End Sub

        Public Overrides Property NullText() As String
            Get
                NullText = NUD.Value
            End Get
            Set(ByVal Value As String)
                If IsDate(Value) = True Then
                    NUD.Value = Value
                Else
                    MsgBox("Default Null Value is Not a Date")
                End If
            End Set
        End Property

        Public Property MaxValue() As Decimal
            Get
                Return NUD.Maximum
            End Get
            Set(ByVal value As Decimal)
                NUD.Maximum = value
            End Set
        End Property

        Public Property MinValue() As Decimal
            Get
                Return NUD.Minimum
            End Get
            Set(ByVal value As Decimal)
                NUD.Minimum = value
            End Set
        End Property
    End Class
End Namespace 'DataGridExtensions
