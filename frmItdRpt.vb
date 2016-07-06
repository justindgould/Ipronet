Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmItdRpt
    Inherits DevExpress.XtraEditors.XtraForm
	
    Dim Pdlg As New PrintDialog
    Dim P As New Printer

    Dim CatCode As String
	Dim Wyear As String
    Dim Wperiod1 As String
	Dim H As Short
	
    Dim Z1str As String = String.Format("{0:MMM d, yyyy HH:mm:ss tt}", DateTime.Now)
	Dim Ystr As String
	Dim J2str As String
	Dim Astr As String
	Dim A1str As String
	Dim A2str As String
	Dim A4str As String
	Dim Dstr As String
	Dim J3str As String
	Dim J4str As String
	Dim Kstr As String
	Dim Kstr1 As String
	Dim Kstr2 As String

	Dim Pcnt As Short
	Dim L0 As Short
	Dim T(16) As Double
	Dim T1(8) As Double
	Dim T2(8) As Double
	Dim A(24) As Double
	Dim B(15, 24) As Double
	Dim C(29) As Short
	
	
    Private Sub cboMga_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboMga.SelectedIndexChanged
        Dim M As String
        Dim M1 As Integer

        If ByPassCbo Then Exit Sub
        TrtyKey = Mid(Trim(cboMga.Text), 1, 3)
        LoadCboTrty()

        ByPassCbo = True
        If cboTrty.Items.Count > 1 Then
            cboTrty.SelectedIndex = 1
        Else
            cboTrty.SelectedIndex = 0
        End If
        ByPassCbo = False

        If ByPassTxt Then Exit Sub

        If Not ByPassTxt Then txtMgaNmbr.Text = Mid(Trim(cboMga.Text), 1, 3)
        txtTrtyNmbr.Text = ""
        M = Mid(Trim(cboMga.Text), 1, 3)
        M1 = cboMga.SelectedIndex
        txtMgaNmbr.Text = M
        cboMga.SelectedIndex = M1
        txtTrtyNmbr.Text = ""
        txtMgaNmbr.Focus()
    End Sub
	
    Private Sub cboMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub cboTrty_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboTrty.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        txtTrtyNmbr.Text = Mid(Trim(cboTrty.Text), 1, 2)
        TrtyKey = Mid(Trim(cboMga.Text), 1, 3) & Mid(Trim(cboTrty.Text), 1, 2)
        RdTrtyPrmRec()
        txtPeriod.Focus()
    End Sub
	
    Private Sub cboTrty_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboTrty.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub cmdPrt_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdPrt.Click
        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        If Trim(txtPeriod.Text) = "" Then Exit Sub

        MgaKey = Trim(txtMgaNmbr.Text)
        RdMgaMstRec()
        GetMgaMstVar()

        TrtyKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        RdTrtyPrmRec()
        GetTrtyPrmVar()

        TrtyKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        RdTrtyMstRec()
        GetTrtyMstVar()

        'Global Initial
        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next
        J2str = Trim(txtPeriod.Text)
        Astr = Trim(txtMgaNmbr.Text)
        A1str = txMgaName
        A2str = txTrtyDesc
        A4str = Trim(txtTrtyNmbr.Text)
        Ystr = Trim(Str(Parry(1))) 'Curr Year
        Wperiod1 = txtPeriod.Text

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
        PrtItdRpt()

        If Not RptCmplt Then Exit Sub

        prtobj.EndDoc()
        prtobj.Orientation = 1

        txtMgaNmbr.Text = ""
        txtTrtyNmbr.Text = ""
        txtPeriod.Text = ""
        optYTD.Checked = 1
        txtMgaNmbr.Focus()
    End Sub
	
    Private Sub cmdPrt_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cmdPrt.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub frmItdRpt_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

        OpenMgaMst()
        OpenTrtyMst()
        OpenTrtyPrm()

        'Load Mga Combo Box
        LoadCboMga()

        'Load Trty Combo Box
        TrtyKey = "001" & "06"
        LoadCboTrty()

        ByPassCbo = True
        cboMga.SelectedIndex = 1
        cboTrty.SelectedIndex = 1
        ByPassCbo = False
        optYTD.Checked = 1
    End Sub
	
    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub
	
    Private Sub txtMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaNmbr.Enter
        Tobj = txtMgaNmbr
    End Sub
	
    Private Sub txtMgaNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtMgaNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtTrtyNmbr.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyNmbr.Focus()

        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub txtMgaNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtMgaNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtMgaNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtMgaNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtMgaNmbr.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim X As Integer

        If Tobj.Text = "000" Then
            Me.Close()
            Exit Sub
        End If

        M = "   "
        M = RSet(Tobj.Text, Len(M))

        For X = 1 To 3
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next

        If (KeyCode > 47 And KeyCode < 58) Or (KeyCode > 96 And KeyCode < 105) Then
            If Len(M) > 0 Then
                For X = 1 To cboMga.Items.Count
                    If MgaArray(X) = M Then
                        ByPassTxt = True
                        cboMga.SelectedIndex = X
                        ByPassTxt = False
                        Exit Sub
                    End If
                Next X
                ByPassTxt = True
                cboMga.SelectedIndex = 0
                ByPassTxt = True
            End If
        End If

    End Sub
	
    Private Sub txtMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaNmbr.Leave
        Dim X As Integer

        Tobj = txtMgaNmbr

        s = "   "
        s = RSet(Tobj.Text, Len(s))

        For X = 1 To 3
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next

        Tobj.Text = s

        MgaKey = s
        RdMgaMstRec()

        If s = "000" Then Tobj.Text = ""
        If Fstat <> 0 Then
            If Tobj.Text <> "" Then MsgBox("MGA Master Record Does Not Exist.")
        End If
    End Sub
	
    Private Sub txtTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyNmbr.Enter
        Dim X As Integer

        Tobj = txtTrtyNmbr

        If Len(txtTrtyNmbr.Text) > 0 Then
            For X = 1 To cboMga.Items.Count
                If MgaArray(X) = Trim(txtMgaNmbr.Text) Then
                    ByPassTxt = True
                    cboMga.SelectedIndex = X
                    ByPassTxt = False
                    Exit Sub
                End If
            Next X
            cboMga.SelectedIndex = 0
        End If

    End Sub
	
    Private Sub txtTrtyNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtMgaNmbr.Focus()
            Case Keys.Down
                txtPeriod.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtPeriod.Focus()

        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub txtTrtyNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtTrtyNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyNmbr.KeyUp
        Dim X As Integer
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        If Tobj.Text = "00" Then
            Me.Close()
            Exit Sub
        End If

        M = "  "
        M = RSet(Tobj.Text, Len(M))

        For X = 1 To 2
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next

        If M = "00" Then M = ""
        If (KeyCode > 47 And KeyCode < 58) Or (KeyCode > 96 And KeyCode < 105) Then
            If Len(M) > 0 Then
                For X = 0 To cboTrty.Items.Count
                    If TrtyArray(X) = M Then
                        ByPassCbo = True
                        cboTrty.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboTrty.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If
    End Sub
	
    Private Sub txtTrtyNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyNmbr.Leave
        Dim X As Integer
        Tobj = txtTrtyNmbr

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))

        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = UCase(S1)

        If S1 = "00" Then
            Tobj.Text = ""
        End If

    End Sub
	
    Private Sub txtPeriod_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPeriod.Enter
        Dim X As Integer
        Tobj = txtPeriod

        If Len(txtMgaNmbr.Text) > 0 Then
            For X = 0 To cboTrty.Items.Count
                If TrtyArray(X) = Trim(txtTrtyNmbr.Text) Then
                    ByPassCbo = True
                    cboTrty.SelectedIndex = X
                    ByPassCbo = False
                    If Trim(txtPeriod.Text) = "" Then txtPeriod.Text = CurrPeriod
                    Exit Sub
                End If
            Next X
            ByPassCbo = True
            cboTrty.SelectedIndex = 0
            ByPassCbo = False
        End If
    End Sub
	
    Private Sub txtPeriod_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPeriod.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyNmbr.Focus()
            Case Keys.Down
                cmdPrt.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then cmdPrt.Focus()

        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
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

        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & Trim(txtPeriod.Text)
    End Sub
	
    Private Sub LoadCboMga()
        Dim X As Integer
        X = 0
        rc = d4top(f1)
        ReDim MgaArray(d4recCount(f1) + 1)

        Call d4tagSelect(f1, d4tag(f1, "K1"))

        cboMga.Items.Clear()
        cboMga.Items.Add("MGA Not Setup")
        Do Until rc = r4eof
            cboMga.Items.Add(Trim(f4str(Mp.MgaNmbr)) & "   " & Trim(f4str(Mp.MgaName)))
            X = X + 1
            MgaArray(X) = Trim(f4str(Mp.MgaNmbr))
            rc = d4skip(f1, 1)
        Loop

        rc = d4bottom(f1)
        rc = d4unlock(f1)
    End Sub
	
	Private Sub LoadCboTrty()
		Dim X1 As Short
		X = 0
		ReDim TrtyArray(d4recCount(f4) + 1)
		rc = d4top(f4)
		
		Call d4tagSelect(f4, d4tag(f4, "K1"))
		rc = d4seek(f4, TrtyKey)
		
		cboTrty.Items.Clear()
		cboTrty.Items.Add("Treaty Inactive or Not Setup")
		For X1 = 0 To d4recCount(f4)
			If Mid(TrtyKey, 1, 3) <> Mid(Trim(f4str(TPp.PrmMgaNmbr)), 1, 3) Then
				Exit For
			End If
			If Val(Trim(f4str(TPp.PrmStatus))) = 1 Then GoTo nextrec
			X = X + 1
			TrtyArray(X) = Trim(f4str(TPp.PrmTrtyNmbr))
			cboTrty.Items.Add(Trim(f4str(TPp.PrmTrtyNmbr)) & "   " & Trim(f4str(TPp.PrmDesc)))
nextrec: 
			rc = d4skip(f4, 1)
		Next X1
		
		rc = d4bottom(f4)
		rc = d4unlock(f4)
	End Sub
	
	Private Sub PrtItdRpt()
		Dim X As Short
		Dim n As Double
		
		'Initialize
		For X = 0 To 16 : T(X) = 0 : Next X
		For X = 0 To 8 : T1(X) = 0 : T2(X) = 0 : Next X
		
		For n = 1 To 13
			For X = 1 To 24
				B(n, X) = 0
			Next X
		Next n
		
		
		Kstr1 = "" : Kstr2 = "" : Pcnt = 0
		
		H = 1
		L0 = 45
		
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
		
		For X = 1 To 24 : C(X) = CovArry(X) : Next X
		
		'======================================================================================
		'= PROCESS ITD DIRECT
		'======================================================================================
		
		'==================================================================================
		'= Get ITDDIR
		'==================================================================================
		Call d4tagSelect(f11, d4tag(f11, "K4"))
		rc = d4top(f11)
		ItdDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
		rc = d4seek(f11, ItdDirKey)
		
		Do Until rc = r4eof Or (ItdDirKey <> (Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr))))
			
			CatCode = Trim(f4str(IDp.ItdCatCode))
			If CatCode <= "05" Or CatCode >= "11" Then GoTo nextirec
			If CatCode = "09" Or CatCode = "10" Then GoTo nextirec
			
			J3str = Trim(f4str(IDp.ItdPeriod))
			
			Kstr = Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr)) & Trim(f4str(IDp.ItdYear))
			
			If Kstr1 = "" Then Kstr1 = Kstr
			
			If Kstr <> Kstr1 Then
				If Trim(Mid(Kstr1, 6, 4)) <> "" Then
					GetYTD()
				Else
					Kstr1 = Kstr
				End If
			End If
			
			If optYTD.Checked = True Then GoTo nextirec
			
			Wyear = Trim(f4str(IDp.ItdYear))
			GetItdDirVar()
			
			For X = 1 To 24
				A(X) = MLobp(X)
			Next X
			CatCode = Trim(f4str(IDp.ItdCatCode))
			n = Val(CatCode)
			n = n - 1
			
			'Accumulate
			For X = 1 To 24
				B(n, X) = B(n, X) + A(X)
				T1(n - 5) = T1(n - 5) + A(X)
			Next X
			
nextirec: 
			rc = d4skip(f11, 1)
		Loop 
		
		If Trim(Mid(Kstr1, 6, 4)) <> "" Then GetYTD()
		
		'Current Year
		If Trim(Kstr1) = "" Then Kstr1 = ItdDirKey
		Kstr1 = Mid(Kstr1, 1, 5) & Ystr
		If Trim(Mid(Kstr1, 6, 4)) <> "" Then GetYTD()
		
		'Print TOTALS
		If L0 > 50 Then RptPageHeading()

        prtobj.Print()
        Dstr = "   Grand Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T2(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T2(1), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(T2(2), "###,###,###.00"), 14),
                           TAB(59), RSet(Format(T2(3), "###,###,###.00"), 14),
                           TAB(73), RSet(Format(T2(4), "###,###,###.00"), 14),
                           TAB(87), RSet(Format(T2(7), "###,###,###.00"), 14),
                           TAB(101), RSet(Format(T2(8), "###,###,###.00"), 14))

        RptCmplt = True
	End Sub
	
	Private Sub GetYTD()
		Dim n As Double
        Dim X As Integer

		'=====================================================================================
		'= Get RPTDIR
		'=====================================================================================
		
		Call d4tagSelect(f5, d4tag(f5, "K4"))
		RptDirKey = Kstr1
		rc = d4top(f5)
		rc = d4seek(f5, RptDirKey)
		
		Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) & Trim(f4str(RDp.RptYear))))
			
			CatCode = Trim(f4str(RDp.RptCatCode))
			If CatCode <= "05" Or CatCode >= "15" Then GoTo nextrec
			If CatCode = "11" Or CatCode = "12" Then GoTo nextrec
			
			J3str = Trim(f4str(RDp.RptPeriod))
			
			If CatCode = "09" Or CatCode = "10" Or CatCode = "13" Or CatCode = "14" Then
				If J3str <> J2str Then GoTo nextrec
			End If
			
			If J3str > J2str Then GoTo nextrec
			
			Wyear = Trim(f4str(RDp.RptYear))
			GetRptDirVar()
			
			For X = 1 To 24
				A(X) = MLobp(X)
			Next X
			n = Val(CatCode)
			n = n - 1
			
			'Accumulate
			For X = 1 To 24
				B(n, X) = B(n, X) + A(X)
				T1(n - 5) = T1(n - 5) + A(X)
			Next X
			
nextrec: 
			rc = d4skip(f5, 1)
		Loop 
		
		For X = 0 To 8
			If T1(X) <> 0 Then
				PrtAccYr()
				Exit For
			End If
		Next X
		
		For n = 1 To 13
			For X = 1 To 24
				B(n, X) = 0
			Next X
		Next n
		
		Kstr1 = Kstr
	End Sub
	
	Sub RptPageHeading()
        Dim H1 As String
        Dim H2 As String = " "
		Dim H3 As String
        Dim H5 As String = " "
		
		'Heading
		Pcnt = Pcnt + 1
        If Not BeginRun Then prtobj.NewPage()
        BeginRun = False

        prtobj.Print(TAB(95), "MGA BINDER" & " - Direct")

        H1 = Trim(txPrmRptName)

        If optYTD.Checked = True Then H2 = "YTD Loss Report To"
        If optITD.Checked = True Then H2 = "ITD Loss Report To"

        H3 = C0str

        If optYTD.Checked = True Then H5 = "YTD For Period Ending " & J4str
        If optITD.Checked = True Then H5 = "ITD For Period Ending " & J4str

        prtobj.Print(TAB(40 - Len(H1) / 2), H1, TAB(95), "Page " & Str(Pcnt) & " " & Z1str)
        prtobj.Print(TAB(40 - Len(H2) / 2), H2, TAB(95), Astr & " - " & A4str)
        prtobj.Print(TAB(40 - Len(H3) / 2), H3, TAB(95), A2str)
        prtobj.Print(TAB(40 - Len(H5) / 2), H5)
        prtobj.Print()

        prtobj.Print(TAB(27), "Loss", TAB(38), "Salvage", TAB(56), "LAE",
                                      TAB(65), "O/S Loss", TAB(80), "O/S LAE",
                                      TAB(92), "IBNR Loss", TAB(107), "IBNR LAE")

        prtobj.Print(TAB(27), "Paid", TAB(55), "Paid", TAB(66), "Reserve",
                     TAB(80), "Reserve", TAB(94), "Reserve", TAB(108), "Reserve")

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
	
	Public Sub PrtAccYr()
        Dim X As Short
		
		If L0 >= 42 Then RptPageHeading()
		
        prtobj.Print("Accident Year " & Mid(Kstr1, 6, 4))
        prtobj.Print("------------------")
		
		L0 = L0 + 2
		For X = 1 To 24
			If C(X) <> 0 Then
				CovHeading((X))
                prtobj.Print(Dstr, TAB(17), RSet(Format(B(5, X), "###,###,###.00"), 14),
                                   TAB(31), RSet(Format(B(6, X), "###,###,###.00"), 14),
                                   TAB(45), RSet(Format(B(7, X), "###,###,###.00"), 14),
                                   TAB(59), RSet(Format(B(8, X), "###,###,###.00"), 14),
                                   TAB(73), RSet(Format(B(9, X), "###,###,###.00"), 14),
                                   TAB(87), RSet(Format(B(12, X), "###,###,###.00"), 14),
                                   TAB(101), RSet(Format(B(13, X), "###,###,###.00"), 14))
                L0 = L0 + 1
			End If
		Next X

        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T1(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T1(1), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(T1(2), "###,###,###.00"), 14),
                           TAB(59), RSet(Format(T1(3), "###,###,###.00"), 14),
                           TAB(73), RSet(Format(T1(4), "###,###,###.00"), 14),
                           TAB(87), RSet(Format(T1(7), "###,###,###.00"), 14),
                           TAB(101), RSet(Format(T1(8), "###,###,###.00"), 14))

        For X = 0 To 4
            T2(X) = T2(X) + T1(X)
            T1(X) = 0
        Next X

        For X = 7 To 8
            T2(X) = T2(X) + T1(X)
            T1(X) = 0
        Next X

        prtobj.Print()
        prtobj.Print()
		L0 = L0 + 2
	End Sub
End Class