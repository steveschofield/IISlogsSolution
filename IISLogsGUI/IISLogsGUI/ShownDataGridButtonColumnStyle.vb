Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design

'Namespace DataGridExtensions

Public Class ShownDataGridButtonColumnStyle
    Inherits System.Windows.Forms.DataGridTextBoxColumn

    Public Sub New()
        Dim Asm As Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim BM1 As New Bitmap(Asm.GetManifestResourceStream("IISLogsGUI.fullbuttonface.bmp"))
        _buttonFace = BM1

        Dim BM2 As New Bitmap(Asm.GetManifestResourceStream("IISLogsGUI.fullbuttonfacepressed.bmp"))
        _buttonFacePressed = BM2
    End Sub

    '  Public Event CellButtonClicked As DataGridCellButtonClickEventHandler

    Private _buttonFace As Bitmap
    Private _buttonFacePressed As Bitmap
    ' Private _columnNum As Integer
    Private _pressedRow As Integer = -1
    Private _buttonText As String
    Private _Grid As DataGrid '= Me.DataGridTableStyle.datagrid
    Private _SetEvents As Boolean


    Delegate Sub OnClick(ByVal Button As Object, ByVal Row As Integer, ByVal Column As Integer, ByRef Value As String, ByRef DRV As DataRowView) ', ByVal MappingName As String, ByVal DR As DataRowView) 'ByVal MappingName As String, ByVal CM As System.Windows.Forms.CurrencyManager)
    Public Event On_Click As OnClick

    Public Property Data_Grid() As DataGrid
        Get
            Data_Grid = _Grid
        End Get
        Set(ByVal Value As DataGrid)
            If Not Value Is Nothing Then
                _Grid = Value
            Else
                Dim Temp As New DataGrid
                Temp = Me.DataGridTableStyle.DataGrid
                _Grid = Temp
            End If
            AddHandler _Grid.MouseDown, AddressOf HandleMouseDown
            AddHandler _Grid.MouseUp, AddressOf HandleMouseUp
        End Set
    End Property

    <Browsable(False)> Public Property Column_Number() As Integer
        Get

        End Get
        Set(ByVal Value As Integer)

        End Set
    End Property
    '    Get
    '        Column_Number = _columnNum
    '    End Get
    '    Set(ByVal Value As Integer)
    '        _columnNum = Value
    '    End Set
    'End Property

    Public Property Button_Text() As String
        Get
            Button_Text = _buttonText
        End Get
        Set(ByVal Value As String)
            _buttonText = Value
        End Set
    End Property

    Public Property Button_Face_Up() As Bitmap
        Get
            If IsNothing(_buttonFace) = True Then
                Dim Asm As Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
                Dim BM1 As New Bitmap(Asm.GetManifestResourceStream("IISLogsGUI.fullbuttonface.bmp"))
                _buttonFace = BM1
            End If
            Return _buttonFace
        End Get
        Set(ByVal Value As Bitmap)
            If Value Is Nothing Then
                Dim Asm As Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
                Dim BM1 As New Bitmap(Asm.GetManifestResourceStream("IISLogsGUI.fullbuttonface.bmp"))
                _buttonFace = BM1
            Else
                _buttonFace = Value
            End If
        End Set
    End Property

    Public Property Button_Face_Down() As Bitmap
        Get
            If IsNothing(_buttonFacePressed) = True Then
                Dim Asm As Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
                Dim BM2 As New Bitmap(Asm.GetManifestResourceStream("IISLogsGUI.fullbuttonfacepressed.bmp"))
                _buttonFacePressed = BM2
            End If
            Return _buttonFacePressed
        End Get
        Set(ByVal Value As Bitmap)
            If Value Is Nothing Then
                Dim Asm As Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
                Dim BM2 As New Bitmap(Asm.GetManifestResourceStream("IISLogsGUI.fullbuttonfacepressed.bmp"))
                _buttonFacePressed = BM2
            Else
                _buttonFacePressed = Value
            End If
        End Set
    End Property

    Private Sub DrawButton(ByVal g As Graphics, ByVal bm As Bitmap, ByVal bounds As Rectangle, ByVal row As Integer)

        Dim dg As DataGrid = Me.DataGridTableStyle.DataGrid
        Dim s As String
        If Me.Button_Text Is Nothing Then
            Dim CM As CurrencyManager = CType(dg.BindingContext(dg.DataSource, dg.DataMember), CurrencyManager)
            s = Me.GetColumnValueAtRow(CM, row)
            ' s = dg(row, dg.CurrentCell.ColumnNumber).ToString()
        Else
            s = Me.Button_Text
        End If

        Dim sz As SizeF = g.MeasureString(s, dg.Font, bounds.Width - 4, StringFormat.GenericTypographic)

        Dim x As Integer = bounds.Left + Math.Max(0, (bounds.Width - sz.Width) / 2)
        g.DrawImage(bm, bounds, 0, 0, bm.Width, bm.Height, GraphicsUnit.Pixel)

        If (sz.Height < bounds.Height) Then

            Dim y As Integer = bounds.Top + (bounds.Height - sz.Height) / 2
            If (_buttonFacePressed Is bm) Then
                x = x + 1
            End If
            g.DrawString(s, dg.Font, New SolidBrush(dg.ForeColor), x, y)
        End If

    End Sub

    Protected Overloads Overrides Sub Edit(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
    End Sub 'Edit

    ' dont call the baseclass so no editing done...
    '	base.Edit(source, rowNum, bounds, readOnly, instantText, cellIsVisible); 

    Public Sub HandleMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim dg As DataGrid = Me.DataGridTableStyle.DataGrid
        Dim hti As DataGrid.HitTestInfo = dg.HitTest(New Point(e.X, e.Y))

        Dim TL As New Tools
        If TL.ColumnStyleInUse(Me.MappingName, dg) = False Then
            Exit Sub
        End If

        Dim isClickInCell As Boolean
        If hti.Column > -1 Then
            Try
                isClickInCell = (Me.DataGridTableStyle.GridColumnStyles(hti.Column) Is Me AndAlso hti.Row > -1)
            Catch
                Exit Sub
            End Try
        End If
        _pressedRow = -1

        Dim rect As New Rectangle(0, 0, 0, 0)

        If isClickInCell Then
            rect = dg.GetCellBounds(hti.Row, hti.Column)
            isClickInCell = e.X > rect.Right - Me._buttonFace.Width
        End If
        If isClickInCell Then
            Dim g As Graphics = Graphics.FromHwnd(dg.Handle)
            ' g.DrawImage(Me._buttonFace, rect.Right - Me._buttonFace.Width, rect.Y)
            DrawButton(g, Me._buttonFace, rect, hti.Row)
            g.Dispose()
            'If Not (CellButtonClicked Is Nothing) Then
            Dim CM As CurrencyManager = CType(dg.BindingContext(dg.DataSource, dg.DataMember), CurrencyManager)
            If CM.Position > -1 Then
                Dim DRV As DataRowView = CType(CM.Current, DataRowView)
                If IsDBNull(DRV.Item(Me.MappingName)) = True Then
                    RaiseEvent On_Click(Me, hti.Row, hti.Column, "", DRV)
                    Me.SetColumnValueAtRow(CM, hti.Row, DRV.Item(Me.MappingName))
                Else
                    Dim ReadOnlyValue As Boolean
                    Try
                        DRV.Item(Me.MappingName) = 1
                    Catch
                        ReadOnlyValue = True
                    End Try
                    If ReadOnlyValue = False Then
                        RaiseEvent On_Click(Me, hti.Row, hti.Column, DRV.Item(Me.MappingName), DRV)
                        Me.SetColumnValueAtRow(CM, hti.Row, DRV.Item(Me.MappingName))
                    Else
                        RaiseEvent On_Click(Me, hti.Row, hti.Column, "", DRV)
                        Me.SetColumnValueAtRow(CM, hti.Row, DRV.Item(Me.MappingName))
                    End If
                End If
                Me.Invalidate()
            End If

            ' RaiseEvent CellButtonClicked(Me, New DataGridCellButtonClickEventArgs(hti.Row, hti.Column))
            'End If
        End If
    End Sub 'HandleMouseUp

    Public Sub HandleMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim dg As DataGrid = Me.DataGridTableStyle.DataGrid
        Dim hti As DataGrid.HitTestInfo = dg.HitTest(New Point(e.X, e.Y))
        Dim isClickInCell As Boolean
        If hti.Column > -1 Then
            Try
                isClickInCell = (Me.DataGridTableStyle.GridColumnStyles(hti.Column) Is Me AndAlso hti.Row > -1)
            Catch
                Exit Sub
            End Try
        End If
        Dim rect As New Rectangle(0, 0, 0, 0)
        If isClickInCell Then
            rect = dg.GetCellBounds(hti.Row, hti.Column)
            isClickInCell = e.X > rect.Right - Me._buttonFace.Width
        End If

        If isClickInCell Then
            'Console.WriteLine("HandleMouseDown " + hti.Row.ToString());
            Dim g As Graphics = Graphics.FromHwnd(dg.Handle)
            'g.DrawImage(Me._buttonFacePressed, rect.Right - Me._buttonFacePressed.Width, rect.Y)
            DrawButton(g, Me._buttonFacePressed, rect, hti.Row)
            g.Dispose()
            _pressedRow = hti.Row
        End If
    End Sub 'HandleMouseDown


    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
        'base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        Dim parent As DataGrid = Me.DataGridTableStyle.DataGrid
        Dim current As Boolean = parent.IsSelected(rowNum) Or (parent.CurrentRowIndex = rowNum AndAlso Me.DataGridTableStyle.GridColumnStyles(parent.CurrentCell.ColumnNumber) Is Me)

        Dim BackColor As Color
        If current Then BackColor = parent.SelectionBackColor Else BackColor = parent.BackColor
        Dim ForeColor As Color
        If current Then ForeColor = parent.SelectionForeColor Else ForeColor = parent.ForeColor

        'clear the cell
        g.FillRectangle(New SolidBrush(BackColor), bounds)

        'draw the value
        '  Dim s As String = Me.GetColumnValueAtRow([source], rowNum).ToString() 'parent[rowNum, 0].ToString() + ((parent[rowNum, 1].ToString())+ "  ").Substring(0,2);
        'Font font = new Font("Arial", 8.25f);
        'g.DrawString(s, font, new SolidBrush(Color.Black), bounds);
        'g.DrawString(s, parent.Font, New SolidBrush(ForeColor), bounds.X, bounds.Y)

        'draw the button
        Dim bm As Bitmap
        If _pressedRow = rowNum Then bm = Me._buttonFacePressed Else bm = Me._buttonFace
        'g.DrawImage(bm, bounds.Right - bm.Width, bounds.Y)
        DrawButton(g, bm, bounds, rowNum)
    End Sub 'Paint 'font.Dispose();

    Protected Overrides Sub Abort(ByVal rowNum As Integer)

    End Sub

    Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean
        Return True
    End Function
End Class 'DataGridButtonColumn
'End Namespace