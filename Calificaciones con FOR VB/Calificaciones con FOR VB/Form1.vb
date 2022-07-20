Public Class frmCalificacionesFORVB

    Dim numCantidad As Integer
    Dim numInput As Double
    Dim numProm As Double
    Dim numEntrada As String


    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress

        If txtCantidad.Text = String.Empty Then

            e.Handled = Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." And Not e.KeyChar = "-"

        ElseIf Not txtCantidad.Text.Contains(".") Then

            e.Handled = Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "."

        ElseIf Not txtCantidad.Text.Contains("-") Then

            e.Handled = Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "-"

        ElseIf txtCantidad.Text.Contains(".") And txtCantidad.Text.Contains("-") Then

            e.Handled = Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar)

        End If

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If ((txtCantidad.Text IsNot String.Empty) And (txtCantidad.Text IsNot String.Empty)) Then

            If txtCantidad.Text Like "*.*-*" Or txtCantidad.Text Like "0" Or txtCantidad.Text Like "*-*" Or txtCantidad.Text Like "*.*" Or txtCantidad.Text Like "-" Or txtCantidad.Text Like "-." Then

                MsgBox("Valor invalido")
                Exit Sub

            End If

            numInput = 0
            Dim notas(txtCantidad.Text - 1) As String
            numCantidad = Convert.ToInt32(txtCantidad.Text)





            For Each nota As Integer In notas



                numEntrada = InputBox("Calificacion (base 10)" & ": ")
                numInput = Val(numEntrada)



                If IsNumeric(numEntrada) Then

                    If numEntrada > 10 Then

                        MsgBox("Valores invalidos")
                        Exit Sub
                    End If

                    notas(nota) = numInput



                Else

                    MsgBox("Valores invalidos")
                    Exit Sub

                End If

                numProm += notas(nota)

            Next

            numProm = (numProm / numCantidad)
            MsgBox(numProm)

            Select Case numProm
                Case 10
                    MsgBox("AU")
                Case 9 To 10
                    MsgBox("DE")
                Case 8 To 9
                    MsgBox("SA")
                Case Else
                    MsgBox("NA")
            End Select

        End If

        numProm = 0

    End Sub
End Class
