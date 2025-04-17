Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (TextBox1.Text = "admin" And TextBox2.Text = "admin") Then
            acceuil.Show()
            Me.Hide()
        Else
            MsgBox(" utilisateur ou le mot de passe est incorrect , essayer à nouveau ", MsgBoxStyle.Exclamation, "attention")
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged

        If CheckBox2.Checked = False Then
            TextBox2.PasswordChar = "*"
        ElseIf CheckBox2.Checked = True Then
            TextBox2.PasswordChar = ""
        End If

    End Sub
    Public Sub nauveau()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox1.Focus()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        nauveau()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End

    End Sub

    
End Class
