Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim money As Integer
        Dim earth_count As Integer
        Dim player_name As String = ""
        Try
            FileOpen(1, "rank.txt", OpenMode.Input)
            For i = 1 To 10
                money = LineInput(1)
                earth_count = LineInput(1)
                player_name = LineInput(1)
                If money = 0 Then
                    Exit For
                End If
                ListBox1.Items.Add(player_name)
                ListBox2.Items.Add("돈 : " & money & ", 땅 갯수 : " & earth_count)
            Next
        Catch ex As Exception

        Finally
            FileClose(1)
        End Try
    End Sub
End Class