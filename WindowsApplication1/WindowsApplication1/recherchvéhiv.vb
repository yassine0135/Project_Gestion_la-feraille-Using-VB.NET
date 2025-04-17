Imports System.IO
Public Class recherchvéhiv
    Dim token As String = ""

    Public Sub nouveau()

        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
        TextBox5.Clear()
        TextBox6.Clear()
        ComboBox1.Text = Nothing
        txtdesc.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        acceuil.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text <> "" And TextBox6.Text <> "" Then
            Dim fs As New FileStream("infraction.txt", FileMode.Append, FileAccess.Write)
            Using sw As New StreamWriter(fs)
                sw.WriteLine(TextBox6.Text & "#" & TextBox1.Text & "#" & TextBox3.Text & "#" & TextBox4.Text & "#" & TextBox5.Text & "#" & ComboBox1.Text & "#" & txtdesc.Text)
            End Using
            MessageBox.Show("Les informations ont été enregistrées avec succès.")
            nouveau()

        Else
            MessageBox.Show("Les informations ne sont pas complètes.")
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim st As String()
        Dim fs As New FileStream("Véhicule.txt", FileMode.Open, FileAccess.Read)
        Dim sr As New StreamReader(fs)
        Dim found As Boolean = False
        If TextBox2.Text = "" Then
            MsgBox("Remplire la Zone de texte !!!")
        End If
        While sr.Peek <> -1
            st = Split(sr.ReadLine, "#")
            If TextBox2.Text = st(0) Then
                TextBox6.Text = st(0)
                TextBox1.Text = st(1)
                TextBox3.Text = st(2)
                TextBox4.Text = st(3)
                TextBox5.Text = st(4)

                found = True
                Exit While
            End If
        End While
        If Not found Then
            MessageBox.Show("Aucun résultat ne correspond à votre recherche !!! ", "ID_véhic")
            TextBox2.Text = Nothing
            TextBox2.Focus()
        End If

        sr.Close()
        fs.Close()
    End Sub


    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        listinfrac.Show()
        Me.Hide()

    End Sub
End Class