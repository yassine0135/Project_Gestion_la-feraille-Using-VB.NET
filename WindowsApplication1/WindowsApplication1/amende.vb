Imports System.IO
Public Class amende
    Dim token As String
    Dim selectedRowIndex As Integer = -1
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        acceuil.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        End
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim st As String()
        Dim fs As New FileStream("Véhicule.txt", FileMode.Open, FileAccess.Read)
        Dim fs1 As New FileStream("Propriétaire.txt", FileMode.Open, FileAccess.Read)
        Dim sr As New StreamReader(fs)
        Dim sr1 As New StreamReader(fs1)
        Dim found As Boolean = False
        If TextBox2.Text = "" And TextBox9.Text = "" Then
            MsgBox("Remplire les Zones de texte !!!")
        End If
        While sr1.Peek <> -1
            st = Split(sr1.ReadLine, "#")
            If TextBox2.Text = st(0) Then
                TextBox1.Text = st(1)
                TextBox6.Text = st(2)

                found = True
                Exit While
            End If
        End While
        While sr.Peek <> -1
            st = Split(sr.ReadLine, "#")
            If TextBox9.Text = st(1) Then
                TextBox3.Text = st(2)
                TextBox4.Text = st(3)
                TextBox5.Text = st(4)
                found = True
                Exit While
            End If
        End While
        If Not found Then
            MessageBox.Show("Aucun résultat ne correspond à votre recherche !!! ")
            TextBox2.Text = Nothing
            TextBox2.Focus()
        End If

        sr.Close()
        fs.Close()
        sr1.Close()
        fs1.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text <> "" And TextBox9.Text <> "" Then
            Dim fs As New FileStream("Amende.txt", FileMode.Append, FileAccess.Write)
            Using sw As New StreamWriter(fs)
                sw.WriteLine(TextBox1.Text & "#" & TextBox6.Text & "#" & TextBox3.Text & "#" & TextBox4.Text & "#" & TextBox5.Text & "#" & ComboBox1.Text & "#" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "#" & TextBox7.Text & "#" & ComboBox2.Text)
            End Using
            MessageBox.Show("Les informations ont été enregistrées avec succès.")

        Else
            MessageBox.Show("Les informations ne sont pas complètes.")
        End If
    End Sub
    Public Sub nouveau()

        TextBox2.Text = Nothing
        TextBox9.Text = Nothing
        TextBox1.Text = Nothing
        TextBox6.Text = Nothing
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox7.Clear()
        ComboBox2.Text = Nothing
        ComboBox1.Text = Nothing
        TextBox2.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        nouveau()
    End Sub
    Sub lister()
        Dim fs As New FileStream("Amende.txt", FileMode.Open, FileAccess.Read)
        Dim ps As New StreamReader(fs)
        DataGridView1.Rows.Clear()

        While ps.Peek > -1
            token = ps.ReadLine()
            Dim parts As String() = Split(token, "#")
            DataGridView1.Rows.Add(parts(0), parts(1), parts(2), parts(3), parts(4), parts(5), parts(6), parts(7), parts(8))
        End While

        ps.Close()
        fs.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        lister()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Conduite sans permis de conduire" Then
            TextBox7.Text = "1500 MAD "
        ElseIf ComboBox1.Text = "Conduite sans assurance automobile" Then
            TextBox7.Text = "500 MAD"
        ElseIf ComboBox1.Text = "Conduite en état d'ivresse" Then
            TextBox7.Text = "2000 MAD"
        ElseIf ComboBox1.Text = "stationement illégal" Then
            TextBox7.Text = "100 MAD"
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < DataGridView1.Rows.Count Then
            ' Mettre à jour la variable selectedRowIndex lorsque l'utilisateur clique sur une cellule
            selectedRowIndex = e.RowIndex
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        ' Vérifier si une ligne est sélectionnée
        If selectedRowIndex >= 0 Then
            ' Supprimer la ligne sélectionnée du DataGridView1
            DataGridView1.Rows.RemoveAt(selectedRowIndex)

            ' Lire toutes les lignes du fichier "Amende.txt"
            Dim lines As New List(Of String)
            Using sr As New StreamReader("Amende.txt")
                While Not sr.EndOfStream
                    lines.Add(sr.ReadLine())
                End While
            End Using

            ' Supprimer la ligne correspondante du fichier en utilisant l'indice
            If selectedRowIndex >= 0 AndAlso selectedRowIndex < lines.Count Then
                lines.RemoveAt(selectedRowIndex)
            End If

            ' Écrire le contenu mis à jour dans "Amende.txt"
            Using sw As New StreamWriter("Amende.txt")
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