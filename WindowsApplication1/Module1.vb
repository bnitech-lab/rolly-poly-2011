Module Module1
    Public i, j As Integer
    Structure player_earth_info
        Dim earth_name As String
        Dim earth_build1 As String
        Dim earth_build2 As String
        Dim earth_build3 As String
        Dim earth_price As Integer
    End Structure
    Structure info
        Dim earth() As player_earth_info
        Dim earth_count As Integer
        Dim money As Integer
        Dim escape As Boolean
        Dim pass As Boolean
        Dim muindo_turn As Integer
        Dim space As Boolean
        Public Sub initialize()
            ReDim earth(28)
            escape = False
            pass = False
            muindo_turn = 0
            money = 5000000
        End Sub
    End Structure
    Structure earth_info
        Public price As Integer
        Dim sum_price As Integer    '걸렸을때 낼 돈
        Dim juin As String  '주인 표시 // 없으면 ""
    End Structure
    Public goldkey(12) As String
    Public buy As Boolean
    Public player1, player2 As info
    Public earth(40) As earth_info
End Module
