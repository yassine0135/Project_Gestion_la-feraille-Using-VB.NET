Imports System.IO
Public Class Véhicule
    Dim token As String
    Dim selectedRowIndex As Integer = -1
    Sub enregistrer()
        Dim fs As New FileStream("Véhicule.txt", FileMode.Append, FileAccess.Write)
        Dim ps As New StreamWriter(fs)
        ps.WriteLine(TextBox1.Text & "#" & TextBox2.Text & "#" & TextBox3.Text & "#" & TextBox4.Text & "#" & TextBox5.Text)
        MsgBox("Les informations ont été enrégistrées avec succès.")
        ps.Close()
        fs.Close()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox1.Focus()
    End Sub
    Sub lister()
        Dim fs As New FileStream("Véhicule.txt", FileMode.Open, FileAccess.Read)
        Dim ps As New StreamReader(fs)
        DataGridView1.Rows.Clear()

        While ps.Peek > -1
            token = ps.ReadLine()
            Dim parts As String() = Split(token, "#")
            DataGridView1.Rows.Add(parts(0), parts(1), parts(2), parts(3), parts(4))
        End While

        ps.Close()
        fs.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        enregistrer()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        acceuil.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        lister()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End

    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < DataGridView1.Rows.Count Then
            ' Mettre à jour la variable selectedRowIndex lorsque l'utilisateur clique sur une cellule
            selectedRowIndex = e.RowIndex
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        ' Vérifier si une ligne est sélectionnée
        If selectedRowIndex >= 0 Then
            ' Supprimer la ligne sélectionnée du DataGridView1
            DataGridView1.Rows.RemoveAt(selectedRowIndex)

            ' Lire toutes les lignes du fichier "Véhicule.txt"
            Dim lines As New List(Of String)
            Using sr As New StreamReader("Véhicule.txt")
                While Not sr.EndOfStream
                    lines.Add(sr.ReadLine())
                End While
            End Using

            ' Supprimer la ligne correspondante du fichier en utilisant l'indice
            If selectedRowIndex >= 0 AndAlso selectedRowIndex < lines.Count Then
                lines.RemoveAt(selectedRowIndex)
            End If

            ' Écrire le contenu mis à jour dans "Véhicule.txt"
            Using sw As New StreamWriter("Véhicule.txt")
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
   
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim st As String()
        Dim fs As New FileStream("Véhicule.txt", FileMode.Open, FileAccess.Read)
        Dim sr As New StreamReader(fs)
        Dim found As Boolean = False
        If TextBox6.Text = "" Then
            MsgBox("Remplire la Zone de texte !!!")
        End If
        While sr.Peek <> -1
            st = Split(sr.ReadLine, "#")
            If TextBox6.Text = st(1) Then
                TextBox1.Text = st(0)
                TextBox2.Text = st(1)
                TextBox3.Text = st(2)
                TextBox4.Text = st(3)
                TextBox5.Text = st(4)

                found = True
                Exit While
            End If
        End While
        If Not found Then
            MessageBox.Show("Aucun résultat ne correspond à votre recherche !!! ", "ID_Véhic")
            TextBox6.Text = Nothing
            TextBox6.Focus()
        End If

        sr.Close()
        fs.Close()
    End Sub
End Class