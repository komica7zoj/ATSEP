Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.OleDb
Imports System.Data
Public Class TableUpdate


    Public Sub update(ByVal cnn As OleDbConnection, ByRef da As OleDbDataAdapter, ByRef ds As DataSet, ByVal tablename As String)
        cnn.Open()
        Try



            Dim builder As OleDbCommandBuilder = New OleDbCommandBuilder(da)

            da.InsertCommand = builder.GetInsertCommand()
            da.DeleteCommand = builder.GetDeleteCommand()
            da.UpdateCommand = builder.GetUpdateCommand()



            da.Update(ds.Tables(tablename).GetChanges())
            ds.Tables(tablename).AcceptChanges()




        Catch ex As Exception

            '     MessageBox.Show(tablename + "[" + ex.Message + "]")

        End Try
        cnn.Close()
    End Sub

End Class
