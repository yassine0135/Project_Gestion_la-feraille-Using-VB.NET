Imports System.IO
Public Class listinfrac
    Dim token As String
    Dim selectedRowIndex As Integer = -1

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        recherchvéhiv.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim fs As New FileStream("infraction.txt", FileMode.Open, FileAccess.Read)
        Dim ps As New StreamReader(fs)
        DataGridView1.Rows.Clear()

        While ps.Peek > -1
            token = ps.ReadLine()
            Dim parts As String() = Split(token, "#")
            DataGridView1.Rows.Add(parts(0), parts(1), parts(2), parts(3), parts(4), parts(5), parts(6))
        End While

        ps.Close()
        fs.Close()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < DataGridView1.Rows.Count Then
            ' Mettre à jour la variable selectedRowIndex lorsque l'utilisateur clique sur une cellule
            selectedRowIndex = e.RowIndex
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If selectedRowIndex >= 0 Then
            ' Supprimer la ligne sélectionnée du DataGridView1
            DataGridView1.Rows.RemoveAt(selectedRowIndex)

            ' Lire toutes les lignes du fichier "infraction.txt"
            Dim lines As New List(Of String)
            Using sr As New StreamReader("infraction.txt")
                While Not sr.EndOfStream
                    lines.Add(sr.ReadLine())
                End While
            End Using

            ' Supprimer la ligne correspondante du fichier en utilisant l'indice
            If selectedRowIndex >= 0 AndAlso selectedRowIndex < lines.Count Then
                lines.RemoveAt(selectedRowIndex)
            End If

            ' Écrire le contenu mis à jour dans "Amende.txt"
            Using sw As New StreamWriter("infraction.txt")
                For Each line In lines
                    sw.WriteLine(line)
                Next
            End Using

            ' Informer l'utilisateur de la suppression réussie
            MsgBox("Les informations ont été supprimées avec succès.")
        Else
            MsgBox("Aucune ligne sélectionnée.")
        End If
    End Sub
End Class