Public Class Monopoly

    Dim jusawi1, jusawi2, jusawi_hap As Integer '주사위'
    Dim turn_double As Boolean = False ' 주사위의 눈이 같을때
    Dim temp_turn_double As Boolean '더블일때 황금열쇠로 이동후 다시 자기턴으로 만들기 위한 변수
    Dim turn As Boolean = True  '턴알려주는 변수 (true일때 1p, false일때 2p)
    Dim player As PictureBox    '캐릭터 picturebox
    Dim pl_x, pl_y As Integer   '캐릭터 움직일때 사용
    Dim pl1_locate, pl2_locate As Integer   '캐릭터가 어디있는지
    Dim gibu As Integer '기부금 액수

    Private Sub PictureBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover, PictureBox8.MouseHover, PictureBox7.MouseHover, PictureBox5.MouseHover, PictureBox4.MouseHover, PictureBox3.MouseHover, PictureBox6.MouseHover, PictureBox2.MouseHover, PictureBox12.MouseHover, PictureBox11.MouseHover, PictureBox13.MouseHover, PictureBox14.MouseHover, PictureBox15.MouseHover, PictureBox16.MouseHover, PictureBox18.MouseHover, PictureBox19.MouseHover, PictureBox17.MouseHover, PictureBox20.MouseHover, PictureBox21.MouseHover, PictureBox10.MouseHover, PictureBox31.MouseHover, PictureBox22.MouseHover, PictureBox23.MouseHover, PictureBox24.MouseHover, PictureBox27.MouseHover, PictureBox28.MouseHover, PictureBox26.MouseHover, PictureBox29.MouseHover, PictureBox25.MouseHover, PictureBox40.MouseHover, PictureBox39.MouseHover, PictureBox38.MouseHover, PictureBox37.MouseHover, PictureBox36.MouseHover, PictureBox34.MouseHover, PictureBox33.MouseHover, PictureBox35.MouseHover, PictureBox32.MouseHover, PictureBox9.MouseHover, PictureBox30.MouseHover
        Label1.Visible = True
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave, PictureBox8.MouseLeave, PictureBox7.MouseLeave, PictureBox5.MouseLeave, PictureBox4.MouseLeave, PictureBox3.MouseLeave, PictureBox6.MouseLeave, PictureBox2.MouseLeave, PictureBox12.MouseLeave, PictureBox11.MouseLeave, PictureBox13.MouseLeave, PictureBox14.MouseLeave, PictureBox15.MouseLeave, PictureBox16.MouseLeave, PictureBox18.MouseLeave, PictureBox19.MouseLeave, PictureBox17.MouseLeave, PictureBox20.MouseLeave, PictureBox21.MouseLeave, PictureBox10.MouseLeave, PictureBox31.MouseLeave, PictureBox22.MouseLeave, PictureBox23.MouseLeave, PictureBox24.MouseLeave, PictureBox27.MouseLeave, PictureBox28.MouseLeave, PictureBox26.MouseLeave, PictureBox29.MouseLeave, PictureBox25.MouseLeave, PictureBox40.MouseLeave, PictureBox39.MouseLeave, PictureBox38.MouseLeave, PictureBox37.MouseLeave, PictureBox36.MouseLeave, PictureBox34.MouseLeave, PictureBox33.MouseLeave, PictureBox35.MouseLeave, PictureBox32.MouseLeave, PictureBox9.MouseLeave, PictureBox30.MouseLeave
        Label1.Visible = False
    End Sub

    Private Sub PictureBox19_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove, PictureBox8.MouseMove, PictureBox7.MouseMove, PictureBox5.MouseMove, PictureBox4.MouseMove, PictureBox3.MouseMove, PictureBox6.MouseMove, PictureBox2.MouseMove, PictureBox12.MouseMove, PictureBox11.MouseMove, PictureBox13.MouseMove, PictureBox14.MouseMove, PictureBox15.MouseMove, PictureBox16.MouseMove, PictureBox18.MouseMove, PictureBox19.MouseMove, PictureBox17.MouseMove, PictureBox20.MouseMove, PictureBox21.MouseMove, PictureBox10.MouseMove, PictureBox31.MouseMove, PictureBox22.MouseMove, PictureBox23.MouseMove, PictureBox24.MouseMove, PictureBox27.MouseMove, PictureBox28.MouseMove, PictureBox26.MouseMove, PictureBox29.MouseMove, PictureBox25.MouseMove, PictureBox40.MouseMove, PictureBox39.MouseMove, PictureBox38.MouseMove, PictureBox37.MouseMove, PictureBox36.MouseMove, PictureBox34.MouseMove, PictureBox33.MouseMove, PictureBox35.MouseMove, PictureBox32.MouseMove, PictureBox9.MouseMove, PictureBox30.MouseMove
        Dim i As Integer = 1
        Dim x, y As Integer

        Do While 1
            If sender.GetHashCode = Controls("PictureBox" & i).GetHashCode Then
                Exit Do
            End If
            i = i + 1
        Loop

        x = Controls("PictureBox" & i).Location.X
        y = Controls("PictureBox" & i).Location.Y
        Label1.Location = New Point(x, y)
        Label1.Text = Controls("PictureBox" & i).Tag
    End Sub

    Private Sub Monopoly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Controls("Panel" & 5).Controls("PictureBox" & 5 & "_build1").BackColor = Color.Red
        Controls("Panel" & 5).Controls("PictureBox" & 5 & "_build1").Visible = True
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        'i = e.X
        'j = e.Y
        'Label1.Text = i & " , " & j
        'Label1.Location = New Point(i, j)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim player_struct As info
        Randomize()
        jusawi1 = Int(Rnd() * 6) + 1
        jusawi2 = Int(Rnd() * 6) + 1
        'player_info()
        If turn Then
            player_struct = player1
        Else
            player_struct = player2
        End If

        If player_struct.space Then
            MessageBox.Show("이동하실 위치를 클릭해주세요")
            Exit Sub
        End If

        Select Case jusawi1
            Case 1
                pic_jusawi1.Image = My.Resources._1
            Case 2
                pic_jusawi1.Image = My.Resources._2
            Case 3
                pic_jusawi1.Image = My.Resources._3
            Case 4
                pic_jusawi1.Image = My.Resources._4
            Case 5
                pic_jusawi1.Image = My.Resources._5
            Case 6
                pic_jusawi1.Image = My.Resources._6
        End Select
        Select Case jusawi2
            Case 1
                pic_jusawi2.Image = My.Resources._1
            Case 2
                pic_jusawi2.Image = My.Resources._2
            Case 3
                pic_jusawi2.Image = My.Resources._3
            Case 4
                pic_jusawi2.Image = My.Resources._4
            Case 5
                pic_jusawi2.Image = My.Resources._5
            Case 6
                pic_jusawi2.Image = My.Resources._6
        End Select

        If jusawi1 = jusawi2 Then
            turn_double = True
            MessageBox.Show("더블!!!!!")
        End If

        If player_struct.muindo_turn <= 0 Then
            jusawi_hap = jusawi1 + jusawi2
            MessageBox.Show(jusawi_hap)
            pl_x = player.Location.X
            pl_y = player.Location.Y
            Button1.Enabled = False
            Timer1.Enabled = True
        Else
            move_charther()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static Dim i As Integer = 1     '이동한 칸수
        Static Dim mv_count As Integer = 0  '이동하는 모션 만드는데 필요
        Static Dim start_pass As Boolean = False

        move_player(mv_count)
        mv_count += 1

        player.Location = New Point(pl_x, pl_y)

        If move_end(mv_count) Then
            i += 1
            mv_count = 0

            If turn Then
                player_new_point(pl1_locate)
                If pl1_locate = 40 Then
                    pl1_locate = 0
                    start_pass = True
                End If
                pl1_locate += 1
            Else
                player_new_point(pl2_locate)
                If pl2_locate = 40 Then
                    pl2_locate = 0
                    start_pass = True
                End If
                pl2_locate += 1
            End If
        End If

        If i > jusawi_hap Then  '이동이 끝났을떄

            Timer1.Enabled = False
            If turn Then
                If start_pass Then
                    start_pass = False
                    start(player1)
                End If
            Else
                If start_pass Then
                    start_pass = False
                    start(player2)
                End If
            End If
            move_charther()
            Button1.Enabled = True
            i = 1
        End If
    End Sub
    Private Sub move_player(ByVal mv_count)

        pl_x = player.Location.X
        pl_y = player.Location.Y

        Dim player_locate As Integer
        If turn Then
            player_locate = pl1_locate
        Else
            player_locate = pl2_locate
        End If

        If player_locate >= 1 And player_locate <= 10 Then
            pl_x = pl_x - 19
            If mv_count < 2 Then
                pl_y = pl_y - 10
            Else
                pl_y = pl_y + 10
            End If
        ElseIf player_locate >= 11 And player_locate <= 20 Then
            pl_y = pl_y - 19
            If mv_count < 2 Then
                pl_x = pl_x + 10
            Else
                pl_x = pl_x - 10
            End If
        ElseIf player_locate >= 21 And player_locate <= 30 Then
            pl_x = pl_x + 19
            If mv_count < 2 Then
                pl_y = pl_y + 10
            Else
                pl_y = pl_y - 10
            End If
        ElseIf player_locate >= 31 And player_locate <= 40 Then
            pl_y = pl_y + 19
            If mv_count < 2 Then
                pl_x = pl_x - 10
            Else
                pl_x = pl_x + 10
            End If
        End If
    End Sub
    Private Function move_end(ByVal mv_count)
        Dim mv_end As Boolean

        If mv_count >= 4 Then
            mv_end = True
        Else
            mv_end = False
        End If

        Return mv_end
    End Function
    Private Sub player_new_point(ByRef player_locate)
        If player_locate = 10 Then
            If turn Then
                player.Location = New Point(58, 870)
            Else
                player.Location = New Point(12, 870)
            End If
        ElseIf player_locate = 20 Then
            If turn Then
                player.Location = New Point(70, 95)
            Else
                player.Location = New Point(70, 55)
            End If
        ElseIf player_locate = 30 Then
            If turn Then
                player.Location = New Point(845, 115)
            Else
                player.Location = New Point(891, 115)
            End If
        ElseIf player_locate = 40 Then
            If turn Then
                player.Location = New Point(830, 890)
            Else
                player.Location = New Point(830, 930)
            End If
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        pl1_locate = 1
        pl2_locate = 1

        player = character1

        player1.initialize()
        player1.earth_count = 0
        player2.initialize()
        player2.earth_count = 0

        goldkey(0) = "우대권 당첨"
        goldkey(1) = "무인도 탈출 이용권"
        goldkey(2) = "기부하러 가세요"
        goldkey(3) = "재산세를 내세요 : 땅 1개당 5만원씩"
        goldkey(4) = "건물 관리비를 내세요 : 주택 1만원, 빌딩 3만원, 호텔 7만원"
        goldkey(5) = "k-pop열풍 아이돌을 만나러 서울로 가세요"
        goldkey(6) = "무인도로 가세요"
        goldkey(7) = "기부금을 받으러 가세요."
        goldkey(8) = "우주정거장으로 가세요"
        goldkey(9) = "은행에서 불우이웃돕기를 하는중입니다. 200만원 받으세요"
        goldkey(10) = "똥 밟았습니다. 신발세척비 : 5만원"
        goldkey(11) = "최고가액 땅을 은행에 반값에 매각하세요"
        goldkey(12) = "정부가 당신을 불쌍하게 여깁니다. 은행에서 지원금 200만원을 받으세요"

        Label2.Text = "player1  -  돈 : " & player1.money & ",  땅 갯수 : " & player1.earth_count
        Label3.Text = "player2  -  돈 : " & player2.money & ",  땅 갯수 : " & player2.earth_count

        For i = 1 To 40
            If Controls("PictureBox" & i).Tag = "황금열쇠" Or Controls("PictureBox" & i).Tag = "무인도" _
                    Or Controls("PictureBox" & i).Tag = "기부함" Or Controls("PictureBox" & i).Tag = "우주정거장" _
                    Or Controls("PictureBox" & i).Tag = "기부" Or Controls("PictureBox" & i).Tag = "출발" Then
                earth(i).juin = Controls("PictureBox" & i).Tag.ToString
            Else
                earth(i).juin = ""
            End If
        Next

        For i = 1 To 40
            If earth(i).juin = "" Then
                earth(i).price = 20000 + i * 20000
                earth(i).sum_price = earth(i).price * 1.5
            End If
        Next i
    End Sub

    Private Sub buy_show()
        Form2.ShowDialog()
        If buy Then
            If turn Then
                If player1.money >= earth(pl1_locate).price Then
                    player1.earth_count += 1
                    player1.money -= earth(pl1_locate).price
                    player1.earth(player1.earth_count).earth_name = Controls("PictureBox" & pl1_locate).Tag
                    player1.earth(player1.earth_count).earth_price = earth(pl1_locate).sum_price
                    MessageBox.Show("땅 " & player1.earth(player1.earth_count).earth_name & "을 샀습니다. 가격은 " & earth(pl1_locate).price & "원 입니다.")
                    earth(pl1_locate).juin = "1p"
                    Controls("color" & pl1_locate).BackColor = Color.Yellow
                    Controls("color" & pl1_locate).Visible = True
                Else
                    MessageBox.Show("돈이 부족합니다.")
                    buy = False
                End If
            Else
                If player1.money >= earth(pl1_locate).price Then
                    player2.earth_count += 1
                    player2.money -= earth(pl2_locate).price
                    player2.earth(player2.earth_count).earth_name = Controls("PictureBox" & pl2_locate).Tag
                    player2.earth(player2.earth_count).earth_price = earth(pl2_locate).sum_price
                    MessageBox.Show("땅 " & player2.earth(player2.earth_count).earth_name & "을 샀습니다. 가격은 " & earth(pl2_locate).price & "원 입니다.")
                    earth(pl2_locate).juin = "2p"
                    Controls("color" & pl2_locate).BackColor = Color.Orange
                    Controls("color" & pl2_locate).Visible = True
                Else
                    MessageBox.Show("돈이 부족합니다.")
                    buy = False
                End If
            End If
        End If
    End Sub

    Private Sub gold_key(ByRef player_struct As info)
        Dim i As Integer
        Dim j, max, point As Integer
        If turn Then
            player_struct = player1
        Else
            player_struct = player2
        End If
        Do
            Randomize()
            i = Int(Rnd() * 12)

            If i = 0 And (player1.pass Or player2.pass) Then
                Continue Do
            End If

            If i = 1 And (player1.escape Or player2.escape) Then
                Continue Do
            End If

            MessageBox.Show(goldkey(i))

            Select Case i
                Case 0
                    '우대권
                    player_struct.pass = True
                Case 1
                    '무인도탈출권
                    player_struct.escape = True
                Case 2
                    '기부 ㄱㄱ
                    If turn Then
                        player.Location = New Point(845, 115 + (8 * 76))
                    Else
                        player.Location = New Point(891, 115 + (8 * 76))
                    End If
                    gold_move(39)
                    temp_turn_double = True
                    move_charther()
                Case 3
                    '땅 개당 5만원
                    player_struct.money -= player_struct.earth_count * 50000
                Case 4
                    ''건물 관리비 주택1만 빌딩 3만 호텔 7만
                    Dim give_money As Integer = 0
                    Dim cnt As Integer
                    If player_struct.earth_count <> 0 Then
                        For cnt = 1 To player_struct.earth_count
                            If player_struct.earth(cnt).earth_build1 = "주택" Then
                                give_money += 10000
                            ElseIf player_struct.earth(cnt).earth_build1 = "빌딩" Then
                                give_money += 30000
                            ElseIf player_struct.earth(cnt).earth_build1 = "호텔" Then
                                give_money += 70000
                            End If
                            If player_struct.earth(cnt).earth_build2 = "주택" Then
                                give_money += 10000
                            ElseIf player_struct.earth(cnt).earth_build2 = "빌딩" Then
                                give_money += 30000
                            ElseIf player_struct.earth(cnt).earth_build2 = "호텔" Then
                                give_money += 70000
                            End If
                            If player_struct.earth(cnt).earth_build3 = "주택" Then
                                give_money += 10000
                            ElseIf player_struct.earth(cnt).earth_build3 = "빌딩" Then
                                give_money += 30000
                            ElseIf player_struct.earth(cnt).earth_build3 = "호텔" Then
                                give_money += 70000
                            End If
                        Next cnt
                        player_struct.money -= give_money
                    End If
                Case 5
                    '서울 ㄱ
                    If turn Then
                        player.Location = New Point(845, 799)
                    Else
                        player.Location = New Point(891, 799)
                    End If
                    gold_move(40)
                    temp_turn_double = True
                    move_charther()
                Case 6
                    '무인도 ㄱ
                    If turn Then
                        player.Location = New Point(58, 870)
                    Else
                        player.Location = New Point(12, 870)
                    End If
                    gold_move(11)
                    temp_turn_double = True
                    move_charther()
                Case 7
                    '기부함 ㄱ
                    If turn Then
                        player.Location = New Point(70, 95)
                    Else
                        player.Location = New Point(70, 55)
                    End If
                    gold_move(21)
                    temp_turn_double = True
                    move_charther()
                Case 8
                    '우주정거장 ㄱ
                    If turn Then
                        player.Location = New Point(845, 115)
                    Else
                        player.Location = New Point(891, 115)
                    End If
                    gold_move(31)
                    temp_turn_double = True
                    move_charther()
                Case 9
                    '200만원 받기
                    player_struct.money += 2000000
                Case 10
                    '5만원 지불
                    player_struct.money -= 50000
                Case 11
                    '최고가 땅 반값 판매
                    max = 0
                    point = 0
                    For j = 1 To player_struct.earth_count
                        If max <= player_struct.earth(j).earth_price Then
                            max = player_struct.earth(j).earth_price
                            point = j
                        End If
                    Next
                    For j = 1 To 40
                        If player_struct.earth(point).earth_name = Controls("PictureBox" & j).Tag Then
                            Controls("color" & j).Visible = False
                            Exit For
                        End If
                    Next
                    If max <> 0 Then
                        MessageBox.Show("가장 비싼 땅 " & player_struct.earth(point).earth_name & "을 " & player_struct.earth(point).earth_price / 2 & "원에 팔았습니다")
                        player_struct.money += max / 2
                        player_struct.earth(point).earth_name = ""
                        player_struct.earth_count -= 1
                        For j = 1 To player_struct.earth_count
                            If player_struct.earth(j).earth_name = "" Then
                                player_struct.earth(j).earth_name = player_struct.earth(j + 1).earth_name
                                player_struct.earth(j).earth_build1 = player_struct.earth(j + 1).earth_build1
                                player_struct.earth(j).earth_build2 = player_struct.earth(j + 1).earth_build2
                                player_struct.earth(j).earth_build3 = player_struct.earth(j + 1).earth_build3
                                player_struct.earth(j).earth_price = player_struct.earth(j + 1).earth_price
                                player_struct.earth(j + 1).earth_name = ""
                                player_struct.earth(j + 1).earth_build1 = ""
                                player_struct.earth(j + 1).earth_build2 = ""
                                player_struct.earth(j + 1).earth_build3 = ""
                                player_struct.earth(j + 1).earth_price = 0
                            End If
                        Next
                    Else
                        MessageBox.Show("다행히 땅이 없습니다.")
                    End If
                Case 12
                    '200만 받기
                    player_struct.money += 2000000
            End Select

            Exit Do
        Loop
    End Sub
    Private Sub give_money(ByRef player_struct As info)
        player_struct.money -= 200000
        gibu += 200000
        MessageBox.Show("기분이 좋아서 20만원을 기부합니다.")
    End Sub
    Private Sub take_money(ByRef player_struct As info)
        If gibu <> 0 Then
            MessageBox.Show("누군가가 기부한 돈(" & gibu & "원)을 훔쳤습니다.")
            player_struct.money += gibu
            gibu = 0
        Else
            MessageBox.Show("기부함이 비었습니다.")
        End If
    End Sub
    Private Sub start(ByRef player_struct As info)
        player_struct.money += 200000
        MessageBox.Show("출발점을 지나셨습니다.")
    End Sub
    Private Sub upgrade(ByRef player_struct As info, ByVal player_locate As Integer)
        Dim i As Integer
        Dim j As Integer
        Dim p As Integer
        Dim build As String
        For i = 1 To player_struct.earth_count
            If player_struct.earth(i).earth_name = Controls("PictureBox" & player_locate).Tag Then
                Exit For
            End If
        Next i

        If player_struct.earth(i).earth_build1 = "" Or player_struct.earth(i).earth_build2 = "" Or player_struct.earth(i).earth_build3 = "" Then
            j = MessageBox.Show("건물을 구입하시겠습니까??", "건물구입", MessageBoxButtons.YesNo)
            If j = 6 Then
                Do While 1
                    build = InputBox("구입할 건물을 적어주세요('주택', '빌딩', '호텔') 아무것도 입력 안하면 취소됩니다.", "감사합니다 땡큐")
                    If build = "주택" Or build = "빌딩" Or build = "호텔" Then
                        If player_struct.earth(i).earth_build1 = "" Then
                            player_struct.earth(i).earth_build1 = build
                            p = 1
                        ElseIf player_struct.earth(i).earth_build2 = "" Then
                            player_struct.earth(i).earth_build2 = build
                            p = 2
                        ElseIf player_struct.earth(i).earth_build3 = "" Then
                            player_struct.earth(i).earth_build3 = build
                            p = 3
                        Else
                            MessageBox.Show("구입할 수 없습니다.")
                            Exit Do
                        End If
                        MessageBox.Show(build & "을/를 구입하셨습니다.")
                        Select Case build
                            Case "주택"
                                player_struct.money -= 100000
                                Controls("Panel" & player_locate).Controls("PictureBox" & player_locate & "_build" & p).BackColor = Color.Black
                                Controls("Panel" & player_locate).Controls("PictureBox" & player_locate & "_build" & p).Visible = True
                            Case "빌딩"
                                player_struct.money -= 200000
                                Controls("Panel" & player_locate).Controls("PictureBox" & player_locate & "_build" & p).BackColor = Color.HotPink
                                Controls("Panel" & player_locate).Controls("PictureBox" & player_locate & "_build" & p).Visible = True
                            Case "호텔"
                                player_struct.money -= 300000
                                Controls("Panel" & player_locate).Controls("PictureBox" & player_locate & "_build" & p).BackColor = Color.Aqua
                                Controls("Panel" & player_locate).Controls("PictureBox" & player_locate & "_build" & p).Visible = True
                        End Select
                        Exit Do
                    ElseIf build = "" Then
                        MessageBox.Show("취소됐습니다.")
                        Exit Sub
                    Else
                        MessageBox.Show("다시 입력해주세요.")
                    End If
                Loop
            End If
        End If

        If turn Then
            upgrade_price(player_struct, i, pl1_locate)
        Else
            upgrade_price(player_struct, i, pl2_locate)
        End If
    End Sub
    Private Sub upgrade_price(ByRef player_struct As info, ByVal i As Integer, ByVal player_locate As Integer)
        If player_struct.earth(i).earth_build1 = "주택" Then
            player_struct.earth(i).earth_price = earth(player_locate).sum_price + 100000
        ElseIf player_struct.earth(i).earth_build1 = "빌딩" Then
            player_struct.earth(i).earth_price = earth(player_locate).sum_price + 200000
        ElseIf player_struct.earth(i).earth_build1 = "호텔" Then
            player_struct.earth(i).earth_price = earth(player_locate).sum_price + 300000
        Else
            player_struct.earth(i).earth_price = earth(player_locate).sum_price
            Exit Sub
        End If

        If player_struct.earth(i).earth_build2 = "주택" Then
            player_struct.earth(i).earth_price += 100000
        ElseIf player_struct.earth(i).earth_build2 = "빌딩" Then
            player_struct.earth(i).earth_price += 200000
        ElseIf player_struct.earth(i).earth_build2 = "호텔" Then
            player_struct.earth(i).earth_price += 300000
        End If

        If player_struct.earth(i).earth_build3 = "주택" Then
            player_struct.earth(i).earth_price += 100000
        ElseIf player_struct.earth(i).earth_build3 = "빌딩" Then
            player_struct.earth(i).earth_price += 200000
        ElseIf player_struct.earth(i).earth_build3 = "호텔" Then
            player_struct.earth(i).earth_price += 300000
        End If
    End Sub
    Private Sub move_charther()
        Dim i As Integer
        If turn Then
            If earth(pl1_locate).juin = "황금열쇠" Then
                gold_key(player1)
            ElseIf earth(pl1_locate).juin = "기부함" Then
                take_money(player1)
            ElseIf earth(pl1_locate).juin = "기부" Then
                give_money(player1)
            ElseIf earth(pl1_locate).juin = "우주정거장" Then
                MessageBox.Show("우주정거장을 이용하려면 소유자에게 40만원을 내야합니다.")
                If earth(33).juin <> "1p" Then
                    player1.money -= 400000
                    If earth(33).juin = "2p" Then
                        player2.money += 400000
                    End If
                Else
                    MessageBox.Show("아, 돈낼필요는 없네요")
                End If
                player1.space = True
            ElseIf earth(pl1_locate).juin = "무인도" Then
                i = 7
                If player1.escape Then
                    i = MessageBox.Show("무인도 탈출권을 사용하시겠습니까??", "무인도탈출", MessageBoxButtons.YesNo)
                Else
                    If i = 6 Then
                        MessageBox.Show("무인도를 탈출합니다.")
                        player1.escape = False
                    Else
                        If player1.muindo_turn <= 0 Then
                            MessageBox.Show("무인도에 갇혔습니다. 2턴동안 쉬세요")
                            player1.muindo_turn = 2
                        Else
                            If turn_double Then
                                MessageBox.Show("축하합니다. 무인도를 탈출하셨습니다.")
                                player1.muindo_turn = 0
                            Else
                                player1.muindo_turn -= 1
                                MessageBox.Show("아쉽네요. 남은 턴은 " & player1.muindo_turn & "입니다.")
                            End If
                        End If
                    End If
                End If
            ElseIf earth(pl1_locate).juin = "" Then
                buy_show()
            ElseIf earth(pl1_locate).juin = "2p" Then
                If player1.pass Then
                    i = MessageBox.Show("우대권을 사용하시겠습니까??", "우대권", MessageBoxButtons.YesNo)
                End If
                If i = 6 Then
                    player1.pass = False
                    MessageBox.Show("우대권을 사용하셨습니다.")
                Else
                    For i = 1 To player2.earth_count
                        If player2.earth(i).earth_name = Controls("PictureBox" & pl1_locate).Tag Then
                            Exit For
                        End If
                    Next
                    player1.money -= player2.earth(i).earth_price
                    player2.money += player2.earth(i).earth_price
                    MessageBox.Show("지불해야하는 돈은 " & player2.earth(i).earth_price & "입니다.")
                End If
            ElseIf earth(pl1_locate).juin = "1p" Then
                upgrade(player1, pl1_locate)
            End If
        Else

            If earth(pl2_locate).juin = "황금열쇠" Then
                gold_key(player2)
            ElseIf earth(pl2_locate).juin = "기부함" Then
                take_money(player2)
            ElseIf earth(pl2_locate).juin = "기부" Then
                give_money(player2)
            ElseIf earth(pl2_locate).juin = "우주정거장" Then
                MessageBox.Show("우주정거장을 이용하려면 소유자에게 40만원을 내야합니다.(소유자가 없더라도 은행에 지불)")
                If earth(33).juin <> "2p" Then
                    player2.money -= 400000
                    If earth(33).juin = "1p" Then
                        player1.money += 400000
                    End If
                Else
                    MessageBox.Show("아, 돈낼필요는 없네요")
                End If
                player2.space = True
            ElseIf earth(pl2_locate).juin = "무인도" Then
                i = 7
                If player2.escape Then
                    i = MessageBox.Show("무인도 탈출권을 사용하시겠습니까??", "무인도탈출", MessageBoxButtons.YesNo)
                Else
                    If i = 6 Then
                        MessageBox.Show("무인도를 탈출합니다.")
                        player2.escape = False
                    Else
                        If player2.muindo_turn <= 0 Then
                            MessageBox.Show("무인도에 갇혔습니다. 2턴동안 쉬세요")
                            player2.muindo_turn = 2
                        Else
                            If turn_double Then
                                MessageBox.Show("축하합니다. 무인도를 탈출하셨습니다.")
                                player2.muindo_turn = 0
                            Else
                                player2.muindo_turn -= 1
                                MessageBox.Show("아쉽네요. 남은 턴은 " & player2.muindo_turn & "입니다.")
                            End If
                        End If
                    End If
                End If
            ElseIf earth(pl2_locate).juin = "" Then
                buy_show()
            ElseIf earth(pl2_locate).juin = "1p" Then

                If player2.pass Then
                    i = MessageBox.Show("우대권을 사용하시겠습니까??", "우대권", MessageBoxButtons.YesNo)
                End If
                If i = 6 Then
                    player2.pass = False
                    MessageBox.Show("우대권을 사용하셨습니다.")
                Else
                    For i = 1 To player1.earth_count
                        If player1.earth(i).earth_name = Controls("PictureBox" & pl2_locate).Tag Then
                            Exit For
                        End If
                    Next
                    player2.money -= player1.earth(i).earth_price
                    player1.money += player1.earth(i).earth_price
                    MessageBox.Show("지불해야하는 돈은 " & player1.earth(i).earth_price & "입니다.")
                End If
            ElseIf earth(pl2_locate).juin = "2p" Then
                upgrade(player2, pl2_locate)
            End If
        End If

        If turn Then
            If player1.money <= 0 Then
                game_over(player2)
            End If
        Else
            If player2.money <= 0 Then
                game_over(player1)
            End If
        End If
        Label2.Text = "player1  -  돈 : " & player1.money & ",  땅 갯수 : " & player1.earth_count
        Label3.Text = "player2  -  돈 : " & player2.money & ",  땅 갯수 : " & player2.earth_count

        If temp_turn_double Then
            temp_turn_double = False
        ElseIf turn_double Then
            turn_double = False
        Else
            If turn Then
                turn = False
                player = character2
            Else
                turn = True
                player = character1
            End If
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click, PictureBox2.Click, PictureBox3.Click, PictureBox4.Click, PictureBox5.Click, PictureBox6.Click, PictureBox7.Click, PictureBox8.Click, PictureBox9.Click, PictureBox10.Click, PictureBox11.Click, PictureBox12.Click, PictureBox13.Click, PictureBox14.Click, PictureBox15.Click, PictureBox16.Click, PictureBox17.Click, PictureBox18.Click, PictureBox19.Click, PictureBox20.Click, PictureBox21.Click, PictureBox22.Click, PictureBox23.Click, PictureBox24.Click, PictureBox25.Click, PictureBox26.Click, PictureBox27.Click, PictureBox28.Click, PictureBox29.Click, PictureBox30.Click, PictureBox31.Click, PictureBox32.Click, PictureBox33.Click, PictureBox34.Click, PictureBox35.Click, PictureBox36.Click, PictureBox37.Click, PictureBox38.Click, PictureBox39.Click, PictureBox40.Click
        Dim i As Integer = 1
        Dim j As Integer
        Dim x, y As Integer

        Do While 1
            If sender.GetHashCode = Controls("PictureBox" & i).GetHashCode Then
                Exit Do
            End If
            i = i + 1
        Loop

        If turn Then
            If True Then
                If i > 30 Then
                    j = i - 30
                    y = 115 - 76
                    y += 76 * j
                    player.Location = New Point(845, y)
                ElseIf i > 20 Then
                    j = i - 20
                    x = 70 - 76
                    x += 76 * j
                    player.Location = New Point(x, 95)
                ElseIf i > 10 Then
                    j = i - 10
                    y = 870 + 76
                    y -= 76 * j
                    player.Location = New Point(58, y)
                Else
                    j = i
                    x = 830 + 76
                    x -= 76 * j
                    player.Location = New Point(x, 890)
                End If
                gold_move(i)
                player1.space = False
                move_charther()
            End If
        Else
            If True Then
                If i > 30 Then
                    j = i - 30
                    y = 115 - 76
                    y += 76 * j
                    player.Location = New Point(891, y)
                ElseIf i > 20 Then
                    j = i - 20
                    x = 70 - 76
                    x += 76 * j
                    player.Location = New Point(x, 55)
                ElseIf i > 10 Then
                    j = i - 10
                    y = 870 + 76
                    y -= 76 * j
                    player.Location = New Point(12, y)
                Else
                    j = i
                    x = 830 + 76
                    x -= 76 * j
                    player.Location = New Point(x, 930)
                End If
                gold_move(i)
                player2.space = False
                move_charther()
            End If
        End If
    End Sub
    Private Sub gold_move(ByVal locate As Integer)
        If turn Then
            change_locate(locate, pl1_locate)
            pl1_locate = locate
        Else
            change_locate(locate, pl2_locate)
            pl2_locate = locate
        End If
    End Sub
    Private Sub change_locate(ByVal pl_locate As Integer, ByVal pre_locate As Integer)
        If pre_locate >= pl_locate Then
            If turn Then
                start(player1)
            Else
                start(player2)
            End If
        End If
    End Sub
    Private Sub game_over(ByVal win_player As info)
        Dim i As Integer
        Dim test As Boolean = False
        Dim r_m As Integer
        Dim r_e As Integer
        Dim asdf As String = ""
        Try
            FileOpen(1, "rank.txt", OpenMode.Input)
            For i = 1 To 10
                r_m = LineInput(1)
                r_e = LineInput(1)
                asdf = LineInput(1)
                If win_player.money > r_m Then
                    test = True
                    Exit For
                End If
                If r_m = 0 Then
                    Exit For
                End If
            Next i
            FileClose(1)
        Catch ex As Exception
            test = True
            FileClose(1)
        Finally
            If test Then
                FileOpen(1, "rank.txt", OpenMode.Append)
                PrintLine(1, win_player.money)
                PrintLine(1, win_player.earth_count)
                While 1
                    asdf = InputBox("이름을 입력하세요")
                    If asdf = "" Then
                        MessageBox.Show("다시 입력하세요")
                    Else
                        Exit While
                    End If
                End While
                PrintLine(1, asdf)
                FileClose(1)
            End If
        End Try
    End Sub

    Private Sub 랭킹ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 랭킹ToolStripMenuItem.Click
        Form1.ShowDialog ()
    End Sub
End Class
