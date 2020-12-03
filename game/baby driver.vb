
Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    chase(PictureBox1)
End Sub

Private Sub chase(pictureBox1 As PictureBox)
    Throw New NotImplementedException()
End Sub

Private Function PictureBox1() As PictureBox
    Throw New NotImplementedException()
End Function

Sub Move(p As PictureBox, x As Integer, y As Integer)
    p.Location = New Point(p.Location.X + x, p.Location.Y + y)
End Sub

Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

'Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
'    Select Case e.KeyCode
'        Case Keys.J
'            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipX)
'            Me.Refresh()
'        Case Keys.Up
'            MoveTo(PictureBox1, 0, -5)
'        Case Keys.Down
'            MoveTo(PictureBox1, 0, 5)
'        Case Keys.Left
'            MoveTo(PictureBox1, -5, 0)
'        Case Keys.Right
'            MoveTo(PictureBox1, 5, 0)
'Case Keys.Space
'                CreateNew("bullet", PictureBox2, PictureBox1.Location)


'        Case Else

'    End Select
'    End sub
Function getObject(p As String) As PictureBox
    For Each c In Controls
        If c.name.toupper.ToString.Contains(p.ToUpper) Then
            Return c
        End If
    Next
End Function
Function Collision(p As String, t As String, Optional ByRef other As Object = vbNull)
    For Each c In Controls
        If c.name.toupper.ToString.Contains(p.ToUpper) Then
            Return Collision(c, t, other)
        End If
    Next

End Function
Function Collision(p As PictureBox, t As String, Optional ByRef other As Object = vbNull)
    Dim col As Boolean

    For Each c In Controls
        Dim obj As Control
        obj = c
        If obj.Visible AndAlso p.Bounds.IntersectsWith(obj.Bounds) And obj.Name.ToUpper.Contains(t.ToUpper) Then
            col = True
            other = obj
        End If
    Next
    Return col
End Function
'Return true or false if moving to the new location is clear of objects ending with t
Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
    Dim b As Boolean

    p.Location += New Point(distx, disty)
    b = Not Collision(p, t)
    p.Location -= New Point(distx, disty)
    Return b
End Function
'Moves and object (won't move onto objects containing  "wall" and shows green if object ends with "win"
Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)
    If p Is Nothing Then
        Return
    End If
    If IsClear(p, distx, disty, "WALL") Then
        p.Location += New Point(distx, disty)
    End If
    Dim other As Object = Nothing
    If Collision("Picturebox1", "WIN", other) Then
        Me.BackColor = Color.Red
        other.visible = False
        Return

    End If
End Sub

Private Function BackColor() As Color
    Throw New NotImplementedException()
End Function

Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
    MoveTo(PictureBox2, 0, 20)
End Sub

End Class