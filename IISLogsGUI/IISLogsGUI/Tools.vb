Public Class Tools
    Public Function ColumnStyleInUse(ByVal ColumnName As String, ByVal DG As System.Windows.Forms.DataGrid) As Boolean
        If TypeOf DG.DataSource Is DataSet Then
            If DG.DataMember.IndexOf(".") > -1 Then
                Dim Temp As String = DG.DataMember.Remove(0, DG.DataMember.LastIndexOf(".") + 1)
                If CType(DG.DataSource, DataSet).Relations.Contains(Temp) = True Then
                    If CType(DG.DataSource, DataSet).Relations(Temp).ChildTable.Columns.Contains(ColumnName) = True Then
                        Return True
                    End If
                End If
        Else
            If CType(DG.DataSource, DataSet).Tables(DG.DataMember).Columns.Contains(ColumnName) = True Then
                Return True
                End If
            End If
        ElseIf TypeOf DG.DataSource Is DataTable Then
            If CType(DG.DataSource, DataTable).Columns.Contains(ColumnName) = True Then
                Return True
            End If
        ElseIf TypeOf DG.DataSource Is DataView Then
            If CType(DG.DataSource, DataView).Table.Columns.Contains(ColumnName) = True Then
                Return True
            End If
        End If
    End Function
End Class
