Public Class IISGrid
    Inherits Windows.Forms.DataGrid

    Public ReadOnly Property HozScrollBar() As ScrollBar
        Get
            Return Me.HorizScrollBar
        End Get
    End Property


End Class
