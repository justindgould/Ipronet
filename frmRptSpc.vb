Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmRptSpc
    Inherits DevExpress.XtraEditors.XtraForm

    Dim Pdlg As New PrintDialog
    Dim P As New Printer

    Dim CatCode As String
	Dim Wperiod As String
	Dim H As Short
	Dim PPrec As Boolean
    Dim Z1str As String = String.Format("{0:MMM d, yyyy HH:mm:ss tt}", DateTime.Now)
    Dim Ystr As String
    Dim J2str As String
	Dim Astr As String
	Dim A1str As String
	Dim A2str As String
	Dim A4str As String
	Dim Dstr As String
    Dim J4str As String
	Dim Kstr As String

	Dim Pcnt As Short
	Dim L0 As Short
	Dim L1 As Integer
	Dim T(16) As Double
	Dim B(15, 24) As Double
	Dim B1(15, 24) As Double
	Dim C(29) As Short
	
    Private Sub cmdPrt_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdPrt.Click
        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        If Trim(txtPeriod.Text) = "" Then Exit Sub

        'Global Initial
        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next
        J2str = Trim(txtPeriod.Text)
        Astr = ""
        A1str = ""
        A2str = ""
        A4str = ""
        Ystr = Trim(Str(Parry(1))) 'Curr Year
        Wperiod = txtPeriod.Text

        If J2str = "01" Then J4str = "January 31"
        If J2str = "02" Then J4str = "February 28"
        If J2str = "03" Then J4str = "March 31"
        If J2str = "04" Then J4str = "April 30"
        If J2str = "05" Then J4str = "May 31"
        If J2str = "06" Then J4str = "June 30"
        If J2str = "07" Then J4str = "July 31"
        If J2str = "08" Then J4str = "August 31"
        If J2str = "09" Then J4str = "September 30"
        If J2str = "10" Then J4str = "October 31"
        If J2str = "11" Then J4str = "November 30"
        If J2str = "12" Then J4str = "December 31"
        J4str = J4str & ", " & Ystr

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 9
        prtobj.FontBold = True
        prtobj.Orientation = 2
        BeginRun = True

        'RPTDIR
        OpenRptDir()
        OpenItdDir()
        RptType = 1
        RptCmplt = False
        PrtMgaRpt()
        If Not RptCmplt Then Exit Sub

        prtobj.EndDoc()
        prtobj.Orientation = 1
        Me.Close()
    End Sub
	
    Private Sub frmRptSpc_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

        OpenMgaMst()
        OpenTrtyMst()
        OpenTrtyPrm()
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
	
	Public Sub PrtMgaRpt()
		Dim X As Short
		Dim C1(2) As Short
		Dim A(24) As Double
		Dim A1 As Double
		Dim n As Double
		Dim T3(15) As Double
		Dim t4 As Double
		Dim t5 As Double
		Dim N0 As Double
		Dim N2 As Double
		Dim N3 As Double
		
		'Initialize
		For X = 0 To 15
			T3(X) = 0
			For n = 0 To 24
				B(X, n) = 0
				B1(X, n) = 0
			Next n
		Next X
		
		For X = 0 To 16 : T(X) = 0 : Next X
		Pcnt = 0 : H = 0 : L0 = 0
		
		'======================================================================================
		'= PROCESS MTD DIRECT
		'======================================================================================
		
		'==================================================================================
		'=Get RPTDIR Current Period
		'==================================================================================
		Call d4tagSelect(f5, d4tag(f5, "K1"))
		rc = d4top(f5)
		
		Do Until rc = r4eof
			DspCount()
			
			'Bypass Private Passenger
			Kstr = Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))
			ChkTreatyMst()
			If PPrec Then GoTo nextrec
			
			GetRptDirVar()
			CatCode = Trim(f4str(RDp.RptCatCode))
			A1 = MLobt
			
			If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec
			
			For X = 11 To 24
				A(X) = MLobp(X)
			Next X
			
			' ACCUMULATE
			n = CDbl(CatCode)
			n = n - 1
			If n = 1 Or n = 10 Or n = 11 Or n = 14 Or n = 15 Or n = 16 Then
				T(n) = T(n) + A1
				GoTo nextrec
			End If
			
			For X = 11 To 24
				B(n, X) = B(n, X) + A(X)
				T(n) = T(n) + A(X)
			Next X
nextrec: 
			rc = d4skip(f5, 1)
		Loop 
		
		'======================================================================================
		'= Print MTD DIRECT
		'======================================================================================
        RptPageHeading()
        prtobj.Print("    Current Month", TAB(24), "Written", TAB(35), "Commission", TAB(56), "Net", TAB(65), "Unearned")
        prtobj.Print()

        'Premium, Commission, Net, Unearned
        For X = 11 To 24
            CovHeading((X))
            prtobj.Print(Dstr, TAB(17), RSet(Format(B(0, X), "###,###,###.00"), 14),
                               TAB(31), RSet(Format(B(2, X), "###,###,###.00"), 14),
                               TAB(45), RSet(Format(B(0, X) - B(2, X), "###,###,###.00"), 14),
                               TAB(59), RSet(Format(B(3, X), "###,###,###.00"), 14))
            t4 = t4 + B(2, X)
            t5 = t5 + (B(0, X) - B(2, X))
        Next X
		
        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(t4, "###,###,###.00"), 14),
                           TAB(45), RSet(Format(t5, "###,###,###.00"), 14),
                           TAB(59), RSet(Format(T(3), "###,###,###.00"), 14))
        prtobj.Print()
        prtobj.Print()

        Dstr = "    Current Month"
        prtobj.Print(Dstr, TAB(27), "Loss", TAB(34), "Sal & Subro", TAB(56), "LAE",
                           TAB(65), "O/S Loss", TAB(80), "O/S LAE",
                           TAB(92), "IBNR Loss", TAB(107), "IBNR LAE")
        prtobj.Print(TAB(27), "Paid", TAB(55), "Paid", TAB(66), "Reserve",
                     TAB(80), "Reserve", TAB(94), "Reserve", TAB(108), "Reserve")
        prtobj.Print()

        'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves 'IBNR Loss Reserves 'IBNR LAE Reserves
        For X = 11 To 24
            CovHeading((X))
                prtobj.Print(Dstr, TAB(17), RSet(Format(B(5, X), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(B(6, X), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(B(7, X), "###,###,###.00"), 14),
                           TAB(59), RSet(Format(B(8, X), "###,###,###.00"), 14),
                           TAB(73), RSet(Format(B(9, X), "###,###,###.00"), 14),
                           TAB(87), RSet(Format(B(12, X), "###,###,###.00"), 14),
                           TAB(101), RSet(Format(B(13, X), "###,###,###.00"), 14))
        Next X
		
		'Total Losses
        prtobj.Print()
        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(5), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T(6), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(T(7), "###,###,###.00"), 14),
                           TAB(59), RSet(Format(T(8), "###,###,###.00"), 14),
                           TAB(73), RSet(Format(T(9), "###,###,###.00"), 14),
                           TAB(87), RSet(Format(T(12), "###,###,###.00"), 14),
                           TAB(101), RSet(Format(T(13), "###,###,###.00"), 14))

        prtobj.Print()
        prtobj.Print()
        prtobj.Print("    Current Month")
        prtobj.Print()
        prtobj.Print("Policy Fee", TAB(17), RSet(Format(T(1), "###,###,###.00"), 14))
        prtobj.Print("Front Fee", TAB(17), RSet(Format(T(10), "###,###,###.00"), 14))
        prtobj.Print("Premium Tax", TAB(17), RSet(Format(T(11), "###,###,###.00"), 14))

		'======================================================================================
		'= PROCESS YTD DIRECT
		'======================================================================================
		
		'==================================================================================
		'=Get ITDDIR PRIOR Periods
		'==================================================================================
		L1 = 0
		Call d4tagSelect(f11, d4tag(f11, "K1"))
		rc = d4top(f11)
		
		Do Until rc = r4eof
			DspCount()
			
			'Bypass Private Passenger
			Kstr = Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr))
			ChkTreatyMst()
			If PPrec Then GoTo nextrec1
			
			GetItdDirVar()
			CatCode = Trim(f4str(IDp.ItdCatCode))
			A1 = MLobt
			
			For X = 11 To 24 : A(X) = MLobp(X) : Next X
			
			' ACCUMULATE
			n = CDbl(CatCode) : n = n - 1
			If n <> 3 And n <> 8 And n <> 9 And n <> 12 And n <> 13 Then GoTo nextrec1
			
			For X = 11 To 24
				B1(n, X) = B1(n, X) + A(X)
				T3(n) = T3(n) + A(X)
			Next X
			
nextrec1: 
			rc = d4skip(f11, 1)
		Loop 
		
		'==================================================================================
		'=Get RPTDIR YTD
		'==================================================================================
		L1 = 0
		Call d4tagSelect(f5, d4tag(f5, "K1"))
		rc = d4top(f5)
		
		Do Until rc = r4eof
			DspCount()
			
			'Bypass Private Passenger
			Kstr = Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))
			ChkTreatyMst()
			If PPrec Then GoTo nextrec2
			
			If Trim(f4str(RDp.RptPeriod)) >= Wperiod Then GoTo nextrec2
			
			GetRptDirVar()
			CatCode = Trim(f4str(RDp.RptCatCode))
			A1 = MLobt
			
			For X = 11 To 24 : A(X) = MLobp(X) : Next X
			
			' ACCUMULATE
			n = CDbl(CatCode) : n = n - 1
			
			If n = 3 Or n = 8 Or n = 9 Or n = 12 Or n = 13 Then GoTo nextrec2
			
			If n = 1 Or n = 10 Or n = 11 Or n = 14 Or n = 15 Or n = 16 Then
				T(n) = T(n) + A1
				GoTo nextrec2
			End If
			
			For X = 11 To 24
				B(n, X) = B(n, X) + A(X)
				T(n) = T(n) + A(X)
			Next X
nextrec2: 
			rc = d4skip(f5, 1)
		Loop 
		
		'======================================================================================
		'= Print YTD DIRECT
		'======================================================================================
		t4 = 0 : t5 = 0
        RptPageHeading()
        prtobj.Print("    Year To Date", TAB(24), "Written", TAB(35), "Commission", TAB(57), "Net", TAB(69), "Earned")
        prtobj.Print()

        For X = 11 To 24
            CovHeading((X))
                prtobj.Print(Dstr, TAB(17), RSet(Format(B(0, X), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(B(2, X), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(B(0, X) - B(2, X), "####,###,###.00"), 15),
                           TAB(60), RSet(Format(B(0, X) + B1(3, X) - B(3, X), "####,###,###.00"), 15))
            t4 = t4 + B(2, X)
            t5 = t5 + (B(0, X) - B(2, X))
        Next X
		
        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(t4, "###,###,###.00"), 14),
                           TAB(45), RSet(Format(t5, "####,###,###.00"), 15),
                           TAB(60), RSet(Format(T(0) + T3(3) - T(3), "####,###,###.00"), 15))
        prtobj.Print()
        prtobj.Print()
        prtobj.Print()

        Dstr = "    Year To Date"
        prtobj.Print(Dstr, TAB(27), "Loss", TAB(34), "Sal & Subro", TAB(57), "LAE",
                           TAB(67), "O/S Loss", TAB(82), "O/S LAE",
                           TAB(94), "IBNR Loss", TAB(109), "IBNR LAE")

        prtobj.Print(TAB(27), "Paid", TAB(56), "Paid", TAB(67), "Incurred",
                     TAB(81), "Incurred", TAB(95), "Incurred", TAB(109), "Incurred")

        prtobj.Print()

        'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves 'IBNR Loss Reserves 'IBNR LAE Reserves
        For X = 11 To 24
            CovHeading((X))
            prtobj.Print(Dstr, TAB(17), RSet(Format(B(5, X), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(B(6, X), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(B(7, X), "####,###,###.00"), 15),
                           TAB(60), RSet(Format(B(8, X) - B1(8, X), "####,###,###.00"), 15),
                           TAB(75), RSet(Format(B(9, X) - B1(9, X), "###,###,###.00"), 14),
                           TAB(89), RSet(Format(B(12, X) - B1(12, X), "###,###,###.00"), 14),
                           TAB(103), RSet(Format(B(13, X) - B1(13, X), "###,###,###.00"), 14))
        Next X
		
		'Total Losses
        prtobj.Print()
        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(5), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T(6), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(T(7), "####,###,###.00"), 15),
                           TAB(60), RSet(Format(T(8) - T3(8), "####,###,###.00"), 15),
                           TAB(75), RSet(Format(T(9) - T3(9), "###,###,###.00"), 14),
                           TAB(89), RSet(Format(T(12) - T3(12), "###,###,###.00"), 14),
                           TAB(103), RSet(Format(T(13) - T3(13), "###,###,###.00"), 14))

        prtobj.Print()
        prtobj.Print()
        prtobj.Print("    Year To Date")
        prtobj.Print()
        prtobj.Print("Policy Fee", TAB(17), RSet(Format(T(1), "###,###,###.00"), 14))
        prtobj.Print("Front Fee", TAB(17), RSet(Format(T(10), "###,###,###.00"), 14))
        prtobj.Print("Premium Tax", TAB(17), RSet(Format(T(11), "###,###,###.00"), 14))

		'======================================================================================
		'= PROCESS ITD DIRECT
		'======================================================================================
		
		'==================================================================================
		'= Get ITDDIR
		'==================================================================================
		L1 = 0
		Call d4tagSelect(f11, d4tag(f11, "K1"))
		rc = d4top(f11)
		
		Do Until rc = r4eof
			DspCount()
			
			'Bypass Private Passenger
			Kstr = Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr))
			ChkTreatyMst()
			If PPrec Then GoTo nextrec3
			
			GetItdDirVar()
			CatCode = Trim(f4str(IDp.ItdCatCode))
			A1 = MLobt
			
			For X = 11 To 24 : A(X) = MLobp(X) : Next X
			
			' ACCUMULATE
			n = CDbl(CatCode) : n = n - 1
			
			If n = 3 Or n = 8 Or n = 9 Or n = 12 Or n = 13 Then GoTo nextrec3
			
			If n = 1 Or n = 10 Or n = 11 Or n = 14 Or n = 15 Or n = 16 Then
				T(n) = T(n) + A1
				GoTo nextrec3
			End If
			
			For X = 11 To 24
				B(n, X) = B(n, X) + A(X)
				T(n) = T(n) + A(X)
			Next X
			
nextrec3: 
			rc = d4skip(f11, 1)
		Loop 
		
		For n = 0 To 13
			For X = 11 To 24
				B1(n, X) = 0
			Next X
			T3(n) = 0
		Next n
		
		'======================================================================================
		'= Print ITD DIRECT
		'======================================================================================
        t4 = 0
        t5 = 0
        RptPageHeading()
        prtobj.Print("    Incept. To Date", TAB(25), "Written", TAB(37), "Commission", TAB(60), "Net", TAB(73), "Earned",
                                            TAB(83), "Loss Ratio", TAB(97), "Loss Ratio")
        prtobj.Print(TAB(85), "W/O IBNR", TAB(100), "W/ IBNR")
        prtobj.Print()

        prtobj.Print()
		For X = 11 To 24
            N0 = B(0, X) + B1(3, X) - B(3, X)
            N2 = B1(5, X) + B(5, X) - B1(6, X) - B(6, X) + B1(7, X) + B(7, X) + B(8, X) - B1(8, X) + B(9, X) - B1(9, X)
            N3 = N2 + B(12, X) - B1(12, X) + B(13, X) - B1(13, X)
            If CDec(N0) = 0 Then
                N0 = 1 : N2 = 0 : N3 = 0
            End If
            CovHeading((X))
            prtobj.Print(Dstr, TAB(18), RSet(Format(B(0, X), "####,###,###.00"), 14),
                               TAB(33), RSet(Format(B(2, X), "###,###,###.00"), 14),
                               TAB(48), RSet(Format(B(0, X) - B(2, X), "####,###,###.00"), 15),
                               TAB(64), RSet(Format(B(0, X) + B1(3, X) - B(3, X), "####,###,###.00"), 15),
                               TAB(79), RSet(Format(CInt((N2 / N0) * 10000) / 100, "###,###,###.00"), 14),
                               TAB(93), RSet(Format(CInt((N3 / N0) * 10000) / 100, "###,###,###.00"), 14))
            t4 = t4 + B(2, X)
            t5 = t5 + (B(0, X) - B(2, X))
        Next X
		
        Dstr = "   Totals"
        N0 = T(0) + T3(3) - T(3)
        N2 = T3(5) + T(5) - T3(6) - T(6) + T3(7) + T(7) + T(8) - T3(8) + T(9) - T3(9)
        N3 = N2 + T(12) - T3(12) + T(13) - T3(13)
        If CDec(N0) = 0 Then
            N0 = 1 : N2 = 0 : N3 = 0
        End If
        prtobj.Print()
        prtobj.Print(Dstr, TAB(18), RSet(Format(T(0), "####,###,###.00"), 14),
                           TAB(33), RSet(Format(t4, "###,###,###.00"), 14),
                           TAB(48), RSet(Format(t5, "####,###,###.00"), 15),
                           TAB(64), RSet(Format(T(0) + T3(3) - T(3), "####,###,###.00"), 15),
                           TAB(79), RSet(Format(CInt((N2 / N0) * 10000) / 100, "###,###,###.00"), 14),
                           TAB(93), RSet(Format(CInt((N3 / N0) * 10000) / 100, "###,###,###.00"), 14))
        prtobj.Print()
        prtobj.Print()


        Dstr = "    Incept. To Date"
        prtobj.Print(Dstr, TAB(28), "Loss", TAB(36), "Sal & Subro", TAB(60), "LAE",
                           TAB(71), "O/S Loss", TAB(86), "O/S LAE",
                           TAB(98), "IBNR Loss", TAB(113), "IBNR LAE")

        prtobj.Print(TAB(28), "Paid", TAB(59), "Paid", TAB(72), "Incurred",
                     TAB(86), "Incurred", TAB(100), "Incurred", TAB(114), "Incurred")

        prtobj.Print()

        'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves 'IBNR Loss Reserves 'IBNR LAE Reserves
        For X = 11 To 24
            CovHeading((X))
            prtobj.Print(Dstr, TAB(18), RSet(Format(B(5, X), "###,###,###.00"), 14),
                           TAB(33), RSet(Format(B(6, X), "###,###,###.00"), 14),
                           TAB(48), RSet(Format(B(7, X), "####,###,###.00"), 15),
                           TAB(64), RSet(Format(B(8, X), "####,###,###.00"), 15),
                           TAB(79), RSet(Format(B(9, X), "###,###,###.00"), 14),
                           TAB(93), RSet(Format(B(12, X), "###,###,###.00"), 14),
                           TAB(107), RSet(Format(B(13, X), "###,###,###.00"), 14))
        Next X
		
		'Total Losses
        prtobj.Print()
        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(18), RSet(Format(T(5), "###,###,###.00"), 14),
                           TAB(33), RSet(Format(T(6), "###,###,###.00"), 14),
                           TAB(47), RSet(Format(T(7), "####,###,###.00"), 15),
                           TAB(64), RSet(Format(T(8), "####,###,###.00"), 15),
                           TAB(79), RSet(Format(T(9), "###,###,###.00"), 14),
                           TAB(93), RSet(Format(T(12), "###,###,###.00"), 14),
                           TAB(107), RSet(Format(T(13), "###,###,###.00"), 14))

        prtobj.Print()
        prtobj.Print()
        prtobj.Print("    Incept. To Date")
        prtobj.Print()
        prtobj.Print("Policy Fee", TAB(18), RSet(Format(T(1), "###,###,###.00"), 14))
        prtobj.Print("Front Fee", TAB(18), RSet(Format(T(10), "###,###,###.00"), 14))
        prtobj.Print("Premium Tax", TAB(18), RSet(Format(T(11), "###,###,###.00"), 14))

		RptCmplt = True
	End Sub
	
	Sub RptPageHeading()
		Dim H1 As String
		Dim H2 As String
		Dim H3 As String
        Dim H5 As String
		
		'Heading
		Pcnt = Pcnt + 1
		If Not toScreen Then
            If Not BeginRun Then prtobj.NewPage()
		End If
		BeginRun = False
		
        prtobj.Print(TAB(102), "MGA BINDER" & " - Direct")
		
		H1 = Trim(txPrmRptName)
		H2 = "Commercial Premium & Loss Report To"
		H3 = "Home State County Mutual Insurance Company"
		H5 = "For Period Ending " & J4str
        prtobj.Print(TAB(40 - Len(H1) / 2), H1, TAB(95), "Page " & Str(Pcnt) & " " & Z1str)
        prtobj.Print(TAB(40 - Len(H2) / 2), H2, TAB(102), Astr & " - " & A4str)
        prtobj.Print(TAB(40 - Len(H3) / 2), H3, TAB(102), A2str)
        prtobj.Print(TAB(40 - Len(H5) / 2), H5)
        prtobj.Print()
		
		L0 = 9
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
	
    Sub DspCount()
        L1 = L1 + 1
        txtRecCnt.Text = Format(L1, "######")
        Application.DoEvents()
    End Sub
	
    Sub ChkTreatyMst()
        Dim X As Integer

        PPrec = False
        TrtyKey = Kstr
        RdTrtyMstRec()
        CovArry(1) = f4int(TMp.PPBI)
        CovArry(2) = f4int(TMp.PPPD)
        CovArry(3) = f4int(TMp.PPMED)
        CovArry(4) = f4int(TMp.PPUMBI)
        CovArry(5) = f4int(TMp.PPUMPD)
        CovArry(6) = f4int(TMp.PPPIP)
        CovArry(7) = f4int(TMp.PPCOMP)
        CovArry(8) = f4int(TMp.PPCOLL)
        CovArry(9) = f4int(TMp.PPRENT)
        CovArry(10) = f4int(TMp.PPTOW)
        CovArry(11) = f4int(TMp.CMBI)
        CovArry(12) = f4int(TMp.CMPD)
        CovArry(13) = f4int(TMp.CMMED)
        CovArry(14) = f4int(TMp.CMUMBI)
        CovArry(15) = f4int(TMp.CMUMPD)
        CovArry(16) = f4int(TMp.CMPIP)
        CovArry(17) = f4int(TMp.CMCOMP)
        CovArry(18) = f4int(TMp.CMCOLL)
        CovArry(19) = f4int(TMp.CMRENT)
        CovArry(20) = f4int(TMp.CMTOW)
        CovArry(21) = f4int(TMp.IM)
        CovArry(22) = f4int(TMp.ALLIED)
        CovArry(23) = f4int(TMp.FIRE)
        CovArry(24) = f4int(TMp.MULTIP)

        For X = 1 To 10
            If CovArry(X) = 1 Then PPrec = True
        Next X

    End Sub
End Class