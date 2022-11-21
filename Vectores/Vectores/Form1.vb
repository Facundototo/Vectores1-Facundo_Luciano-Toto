Public Class Form1
    Dim division As Integer = 0
    Dim notas As Integer = 0
    Dim alumno As Integer = 0
    Dim numeronota As Integer = 0
    Dim maximo As Integer = 0
    Dim maximo2 As Integer = 0
    Dim maximo3 As Integer = 0

    Dim notasguardadas As Integer = 0
    Dim cursoscreados As Integer = 0
    Dim alumnoscreados As Integer = 0

    Dim SeUso(10) As Boolean
    Dim SeUso2(10, 1) As Boolean
    Dim SeUso3(10, 255, 255) As Boolean
    Dim div(10) As Integer
    Dim Nombre(10, 1) As String
    Dim Nota(10, 255, 255) As Integer
    Dim cantnotas(10, 100) As Integer

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        division = NumericUpDown1.Value

        If SeUso(division) = False Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False
        End If
        NumericUpDown5.Maximum = div(division)
    End Sub
    Private Sub NumericUpDown5_ValueChanged(sender As Object, e As EventArgs)
        alumno = NumericUpDown5.Value
        If SeUso2(division, alumno) = False Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
        NumericUpDown6.Maximum = cantnotas(division, alumno)
    End Sub
    Private Sub NumericUpDown6_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown6.ValueChanged
        numeronota = NumericUpDown6.Value
        If SeUso3(division, alumno, numeronota) = True Then
            Button1.Text = "Cambiar"
        Else
            Button1.Text = "Guardar"
        End If

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        division = NumericUpDown1.Value
        Label3.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        NumericUpDown4.Visible = True
        NumericUpDown5.Visible = True
        TextBox1.Visible = True
        Button2.Visible = True
        div(division) = NumericUpDown2.Value
        cursoscreados = cursoscreados + 1

        SeUso(NumericUpDown1.Value) = True

        If maximo = 0 Or div(division) > maximo Then
            ReDim Preserve Nombre(10, div(division))
            ReDim Preserve SeUso2(10, div(division))
            maximo = div(division)
        End If

        If SeUso(division) = False Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False
        End If
        NumericUpDown5.Maximum = div(division)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        alumno = NumericUpDown5.Value
        Nombre(division, alumno) = TextBox1.Text
        alumnoscreados = alumnoscreados + 1

        If maximo3 = 0 Or cantnotas(division, alumno) > maximo3 Then
            ReDim Preserve cantnotas(10, alumno)
            maximo3 = cantnotas(division, alumno)
        End If

        cantnotas(division, alumno) = NumericUpDown4.Value

        Label4.Visible = True
        NumericUpDown3.Visible = True
        Button1.Visible = True
        SeUso2(division, alumno) = True

        If SeUso2(division, alumno) = False Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Nota(division, alumno, numeronota) = NumericUpDown3.Value

        SeUso3(division, alumno, numeronota) = True

        If Button1.Text = "Guardar" Then
            notasguardadas = notasguardadas + 1
        End If

        If SeUso3(division, alumno, numeronota) = True Then
            Button1.Text = "Cambiar"
        Else
            Button1.Text = "Guardar"
        End If
    End Sub
    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click
        ListView1.Items.Clear()
        For i As Integer = 1 To cursoscreados
            For j As Integer = 1 To alumnoscreados
                Dim suma_notas, prom As Double
                Dim NoEv As Boolean = False
                For k As Integer = 1 To cantnotas(i, j)
                    If Nota(i, j, k) = 0 Then
                        NoEv = True
                    Else
                        suma_notas = suma_notas + Nota(i, j, k)
                    End If
                Next
                prom = suma_notas / cantnotas(i, j)
                If NoEv = True Then
                    ListView1.Items.Add(Nombre(i, j) + " No esta evaluado")
                ElseIf prom >= 6 Then
                    ListView1.Items.Add(Nombre(i, j) + " " & prom & " Aprobo")
                Else
                    ListView1.Items.Add(Nombre(i, j) + " " & prom & " Desaprobo")
                End If
            Next
        Next
    End Sub

End Class
