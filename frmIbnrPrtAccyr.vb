Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmIbnrPrtAccyr
    Inherits DevExpress.XtraEditors.XtraForm
	
    Dim Pdlg As New PrintDialog
    Dim P As New Printer

    Dim CatCode As String
	Dim H As Short
	
    Dim Z1str As String = String.Format("{0:MMM d, yyyy HH:mm:ss tt}", DateTime.Now)
	Dim Ystr As String
	Dim J2str As String
	Dim Astr As String
	Dim A1str As String
	Dim A2str As String
	Dim A4str As String
	Dim Dstr As String
	Dim Kstr As String
	Dim Kstr1 As String
	Dim Kstr2 As String

	Dim Pcnt As Short
	Dim L0 As Short
	Dim T(16) As Double
	Dim T1(16) As Double
	Dim T2(16) As Double
	Dim T3(16) As Double
	Dim t4(16) As Double
	Dim t5(16) As Double
	Dim t6(16) As Double
	Dim t7(16) As Double
	Dim t8(16) As Double
	Dim A(24) As Double
	Dim B(16, 24) As Double
	
    Private Sub cmdPrt_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdPrt.Click
        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next

        'Global Initial
        J2str = Trim(txtPeriod.Text)
        Astr = "999"
        A1str = "All MGAs"
        A2str = "All Treaties "
        A4str = "99"

        Ystr = Trim(Str(Parry(1))) 'Curr Year

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 9
        prtobj.FontBold = True
        prtobj.Orientation = 2
        BeginRun = True

        'ITD ACCYR
        OpenItdAccyr()
        PrtAccyrRpt()

        prtobj.EndDoc()
        prtobj.Orientation = 1

        Me.Close()
    End Sub
	
    Private Sub cmdPrt_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cmdPrt.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtPeriod.Focus()
        End If
    End Sub
	
    Private Sub frmIbnrPrtAccyr_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()
    End Sub
	
    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub
	
    Private Sub txtPeriod_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPeriod.Enter
        Tobj = txtPeriod
    End Sub
	
    Private Sub txtPeriod_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPeriod.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                cmdPrt.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then cmdPrt.Focus()
    End Sub
	
    Private Sub txtPeriod_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPeriod.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPeriod.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtPeriod_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPeriod.Leave
        Dim X As Integer

        Tobj = txtPeriod
        S1 = "  "

        S1 = RSet(Tobj.Text, Len(S1))
        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next
        Tobj.Text = S1

        If S1 = "00" Then Tobj.Text = ""
    End Sub
	
	Private Sub PrtAccyrRpt()
		Dim X As Short
		Dim n As Double
		
		'Initialize
		For X = 0 To 16 : T(X) = 0 : Next X
		For X = 0 To 16 : T1(X) = 0 : T2(X) = 0 : Next X
		
		Kstr = "" : Kstr1 = "" : Kstr2 = "" : Pcnt = 0
		
		H = 1
		L0 = 45
		
		'==================================================================================
		'= Get Net Accyr
		'==================================================================================
		Call d4tagSelect(f26, d4tag(f26, "K4"))
		rc = d4top(f26)
		
		Do Until rc = r4eof
			DspCount()
			If Kstr = "" Then Kstr = Trim(f4str(IAp.IayYear))
			Kstr1 = Trim(f4str(IAp.IayYear))
			
			If Kstr <> Kstr1 Then
				PrtAccYr()
				Kstr = Kstr1
			End If
			
			GetItdAccyrVar()
			
			For X = 1 To 24 : A(X) = MLobp(X) : Next X
			
			CatCode = Trim(f4str(IAp.IayCatCode))
			n = Val(CatCode)
			
			'Accumulate
			For X = 1 To 24
				B(n, X) = B(n, X) + A(X)
				T1(n) = T1(n) + A(X)
				If X < 7 Then T3(n) = T3(n) + A(X) : t6(n) = t6(n) + A(X)
				If X > 10 And X < 17 Then T3(n) = T3(n) + A(X) : t6(n) = t6(n) + A(X)
				If X > 6 And X < 11 Then t4(n) = t4(n) + A(X) : t7(n) = t7(n) + A(X)
				If X > 16 And X < 21 Then t4(n) = t4(n) + A(X) : t7(n) = t7(n) + A(X)
				If X = 21 Then t5(n) = t5(n) + A(X) : t8(n) = t8(n) + A(X)
			Next X
			
nextirec: 
			rc = d4skip(f26, 1)
		Loop 
		
		PrtAccYr()
		
		'Print FINAL TOTALS
		RptPageHeading()

        'Paid Losses 'Salvage 'Paid Lae 'O/S Loss Reserve 'O/S LAE Reserve 'INBR Loss Reserve 'INBR LAE Reserve

        prtobj.Print()
        Dstr = "   Grand Totals"
        prtobj.Print(Dstr, TAB(27), RSet(Format(T2(6), "####,###,###.00"), 15),
                           TAB(42), RSet(Format(T2(7), "####,###,###.00"), 15),
                           TAB(57), RSet(Format(T2(8), "####,###,###.00"), 15),
                           TAB(72), RSet(Format(T2(9), "####,###,###.00"), 15),
                           TAB(87), RSet(Format(T2(10), "####,###,###.00"), 15),
                           TAB(102), RSet(Format(T2(13), "####,###,###.00"), 15),
                           TAB(117), RSet(Format(T2(14), "####,###,###.00"), 15))
        prtobj.Print()
        prtobj.Print()
        prtobj.Print()
		
        'Paid Losses 'Salvage 'Paid Lae 'O/S Loss Reserve 'O/S LAE Reserve 'INBR Loss Reserve 'INBR LAE Reserve
        Dstr = "Total Liab"
        prtobj.Print(Dstr, TAB(27), RSet(Format(t6(6), "####,###,###.00"), 15),
                           TAB(42), RSet(Format(t6(7), "####,###,###.00"), 15),
                           TAB(57), RSet(Format(t6(8), "####,###,###.00"), 15),
                           TAB(72), RSet(Format(t6(9), "####,###,###.00"), 15),
                           TAB(87), RSet(Format(t6(10), "####,###,###.00"), 15),
                           TAB(102), RSet(Format(t6(13), "####,###,###.00"), 15),
                           TAB(117), RSet(Format(t6(14), "####,###,###.00"), 15))

        'Paid Losses 'Salvage 'Paid Lae 'O/S Loss Reserve 'O/S LAE Reserve 'INBR Loss Reserve 'INBR LAE Reserve
        Dstr = "Total Phydam"
        prtobj.Print(Dstr, TAB(27), RSet(Format(t7(6), "####,###,###.00"), 15),
                           TAB(42), RSet(Format(t7(7), "####,###,###.00"), 15),
                           TAB(57), RSet(Format(t7(8), "####,###,###.00"), 15),
                           TAB(72), RSet(Format(t7(9), "####,###,###.00"), 15),
                           TAB(87), RSet(Format(t7(10), "####,###,###.00"), 15),
                           TAB(102), RSet(Format(t7(13), "####,###,###.00"), 15),
                           TAB(117), RSet(Format(t7(14), "####,###,###.00"), 15))

        'Paid Losses 'Salvage 'Paid Lae 'O/S Loss Reserve 'O/S LAE Reserve 'INBR Loss Reserve 'INBR LAE Reserve
        Dstr = "Inland Marine"
        prtobj.Print(Dstr, TAB(27), RSet(Format(t8(6), "####,###,###.00"), 15),
                           TAB(42), RSet(Format(t8(7), "####,###,###.00"), 15),
                           TAB(57), RSet(Format(t8(8), "####,###,###.00"), 15),
                           TAB(72), RSet(Format(t8(9), "####,###,###.00"), 15),
                           TAB(87), RSet(Format(t8(10), "####,###,###.00"), 15),
                           TAB(102), RSet(Format(t8(13), "####,###,###.00"), 15),
                           TAB(117), RSet(Format(t8(14), "####,###,###.00"), 15))
        RptCmplt = True
	End Sub
	
	Sub RptPageHeading()
		'Heading
		Pcnt = Pcnt + 1
        If Not BeginRun Then prtobj.NewPage()
        BeginRun = False
		
        prtobj.Print()
        prtobj.Print()
        prtobj.Print(C0str)
        prtobj.Print("YTD Accident Year Net Activity", TAB(45), Astr & "  " & A1str, TAB(121), "Page " & Pcnt)
        prtobj.Print(Z1str, TAB(45), A4str & "   " & Trim(A2str) & " thru " & J2str)
        prtobj.Print()
		
        prtobj.Print(TAB(27), "           Loss", TAB(42), "        Salvage", TAB(57), "            LAE",
                    TAB(72), "       O/S Loss", TAB(87), "        O/S LAE", TAB(102), "      IBNR LOSS",
                    TAB(117), "       IBNR LAE")
        prtobj.Print(TAB(27), "           Paid", TAB(57), "           Paid",
                     TAB(72), "        Reserve", TAB(87), "        Reserve", TAB(102), "        Reserve",
                     TAB(117), "        Reserve")
	End Sub
	
	Public Sub CovHeading(ByRef X As Short)
		Dstr = "PP "
		If X = 1 Then Dstr = "PP " & "Bodily Inj."
		If X = 2 Then Dstr = "PP " & "Property Dam."
		If X = 3 Then Dstr = "PP " & "Medical"
		If X = 4 Then Dstr = "PP " & "UM/IUM"
		If X = 5 Then Dstr = "PP " & "UMPD"
		If X = 6 Then Dstr = "PP " & "PIP"
		If X = 7 Then Dstr = "PP " & "Comprehensive"
		If X = 8 Then Dstr = "PP " & "Collision"
		If X = 9 Then Dstr = "PP " & "Rental"
		If X = 10 Then Dstr = "PP " & "Towing"
		If X = 11 Then Dstr = "CM " & "Bodily Inj."
		If X = 12 Then Dstr = "CM " & "Property Dam."
		If X = 13 Then Dstr = "CM " & "Medical"
		If X = 14 Then Dstr = "CM " & "UM/IUM"
		If X = 15 Then Dstr = "CM " & "UMPD"
		If X = 16 Then Dstr = "CM " & "PIP"
		If X = 17 Then Dstr = "CM " & "Comprehensive"
		If X = 18 Then Dstr = "CM " & "Collision"
		If X = 19 Then Dstr = "CM " & "Rental"
		If X = 20 Then Dstr = "CM " & "Towing"
		If X = 21 Then Dstr = "Inland Marine"
		If X = 22 Then Dstr = "Allied"
		If X = 23 Then Dstr = "Fire"
		If X = 24 Then Dstr = "CM Multi Peril"
	End Sub
	
	Public Sub PrtAccYr()
        Dim X, n As Short
		
		RptPageHeading()
		
        prtobj.Print("Accident Year " & Kstr)
        prtobj.Print("------------------")
		
        'Paid Losses 'Salvage 'Paid Lae 'O/S Loss Reserve 'O/S LAE Reserve 'INBR Loss Reserve 'INBR LAE Reserve
        For X = 1 To 24
            CovHeading((X))
            prtobj.Print(Dstr, TAB(27), RSet(Format(B(6, X), "####,###,###.00"), 15),
                               TAB(42), RSet(Format(B(7, X), "####,###,###.00"), 15),
                               TAB(57), RSet(Format(B(8, X), "####,###,###.00"), 15),
                               TAB(72), RSet(Format(B(9, X), "####,###,###.00"), 15),
                               TAB(87), RSet(Format(B(10, X), "####,###,###.00"), 15),
                               TAB(102), RSet(Format(B(13, X), "####,###,###.00"), 15),
                               TAB(117), RSet(Format(B(14, X), "####,###,###.00"), 15))
        Next X
		
        'Paid Losses 'Salvage 'Paid Lae 'O/S Loss Reserve 'O/S LAE Reserve 'INBR Loss Reserve 'INBR LAE Reserve
        prtobj.Print()

        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(27), RSet(Format(T1(6), "####,###,###.00"), 15),
                           TAB(42), RSet(Format(T1(7), "####,###,###.00"), 15),
                           TAB(57), RSet(Format(T1(8), "####,###,###.00"), 15),
                           TAB(72), RSet(Format(T1(9), "####,###,###.00"), 15),
                           TAB(87), RSet(Format(T1(10), "####,###,###.00"), 15),
                           TAB(102), RSet(Format(T1(13), "####,###,###.00"), 15),
                           TAB(117), RSet(Format(T1(14), "####,###,###.00"), 15))
        prtobj.Print()
        prtobj.Print()
        prtobj.Print()
		
        'Paid Losses 'Salvage 'Paid Lae 'O/S Loss Reserve 'O/S LAE Reserve 'INBR Loss Reserve 'INBR LAE Reserve
        Dstr = "Total Liab"
        prtobj.Print(Dstr, TAB(27), RSet(Format(T3(6), "####,###,###.00"), 15),
                           TAB(42), RSet(Format(T3(7), "####,###,###.00"), 15),
                           TAB(57), RSet(Format(T3(8), "####,###,###.00"), 15),
                           TAB(72), RSet(Format(T3(9), "####,###,###.00"), 15),
                           TAB(87), RSet(Format(T3(10), "####,###,###.00"), 15),
                           TAB(102), RSet(Format(T3(13), "####,###,###.00"), 15),
                           TAB(117), RSet(Format(T3(14), "####,###,###.00"), 15))


        'Paid Losses 'Salvage 'Paid Lae 'O/S Loss Reserve 'O/S LAE Reserve 'INBR Loss Reserve 'INBR LAE Reserve
        Dstr = "Total Phydam"
        prtobj.Print(Dstr, TAB(27), RSet(Format(t4(6), "####,###,###.00"), 15),
                           TAB(42), RSet(Format(t4(7), "####,###,###.00"), 15),
                           TAB(57), RSet(Format(t4(8), "####,###,###.00"), 15),
                           TAB(72), RSet(Format(t4(9), "####,###,###.00"), 15),
                           TAB(87), RSet(Format(t4(10), "####,###,###.00"), 15),
                           TAB(102), RSet(Format(t4(13), "####,###,###.00"), 15),
                           TAB(117), RSet(Format(t4(14), "####,###,###.00"), 15))

        'Paid Losses 'Salvage 'Paid Lae 'O/S Loss Reserve 'O/S LAE Reserve 'INBR Loss Reserve 'INBR LAE Reserve
        Dstr = "Inland Marine"
        prtobj.Print(Dstr, TAB(27), RSet(Format(t5(6), "####,###,###.00"), 15),
                           TAB(42), RSet(Format(t5(7), "####,###,###.00"), 15),
                           TAB(57), RSet(Format(t5(8), "####,###,###.00"), 15),
                           TAB(72), RSet(Format(t5(9), "####,###,###.00"), 15),
                           TAB(87), RSet(Format(t5(10), "####,###,###.00"), 15),
                           TAB(102), RSet(Format(t5(13), "####,###,###.00"), 15),
                           TAB(117), RSet(Format(t5(14), "####,###,###.00"), 15))

        For X = 0 To 16
            T2(X) = T2(X) + T1(X)
            T1(X) = 0 : T3(X) = 0 : t4(X) = 0 : t5(X) = 0
            For n = 1 To 24 : B(X, n) = 0 : Next n
        Next X
	End Sub
	
    Sub DspCount()
        L0 = L0 + 1
        txtRecCnt.Text = Format(L0, "######")
        Application.DoEvents()
    End Sub
End Class