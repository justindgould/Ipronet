Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmEoyReinallocPrt
    Inherits DevExpress.XtraEditors.XtraForm
	
    Dim Pdlg As New PrintDialog
    Dim P As New Printer

    Dim Wperiod1 As String
    Dim pc As Boolean
	Dim WorkReiNmbr As String
    Dim Wname As String
	Dim ToFile As Boolean
	Dim Fname1 As String
	
    Dim Z1str As String = String.Format("{0:MMM d, yyyy HH:mm:ss tt}", DateTime.Now)
	Dim Ystr As String
	Dim J2str As String
    Dim J4str As String
	Dim Kstr As String
	Dim Kstr1 As String
	Dim Kstr2 As String
	Dim Kstr3 As String

	Dim Pcnt As Short
	Dim L0 As Short
	Dim T(17) As Double
	Dim T1(17) As Double
    Dim T2(17) As Double

    Private Sub cboMga_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboMga.SelectedIndexChanged
        Dim M As Object
        Dim M1 As Short

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
    End Sub
	
    Private Sub cboTrty_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboTrty.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub cmdPrt_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdPrt.Click

        If optByRein.Checked = True Then
            WorkReiNmbr = InputBox("Enter Rein Nmber" & vbCrLf & "Leave Blank For All Reinsurers", "")
        End If

        If Not optSuppa.Checked Then
            If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub
        End If

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then
                prtobj = Me.P
            End If
        Next

        'Global Initial
        J2str = "03"
        Ystr = Trim(Str(Parry(1))) 'Curr Year
        Wperiod1 = "03"

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

        'Print Ceded Reinsurer Allocations
        If optPrtCeded.Checked Then ProcessCededRein()

        'Print Ceded Reinsurer Allocations
        If optPrtReinBals.Checked Then ProcessBalRein()

        'Print Reinsurance Totals
        If optPrtReinRpts.Checked Then ProcessRptRein()

        'Print Aging Totals
        If optPrtAging.Checked Then ProcessAgeRein()

        'Print Suppa Information
        If optSuppa.Checked Then ProcessSuppaRein()

        txtMgaNmbr.Text = ""
        txtTrtyNmbr.Text = ""
        WorkReiNmbr = ""
        txtMgaNmbr.Focus()
    End Sub
	
    Private Sub cmdPrt_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cmdPrt.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub frmEoyReinallocPrt_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

        OpenMgaMst()
        OpenTrtyMst()
        OpenTrtyPrm()
        OpenReiMst()
        OpenReinAlloc()

        'Load Mga Combo Box
        LoadCboMga()

        'Load Trty Combo Box
        TrtyKey = "001" & "06"
        LoadCboTrty()

        ByPassCbo = True
        cboMga.SelectedIndex = 1
        cboTrty.SelectedIndex = 1
        ByPassCbo = False

        optByMga.Checked = True
        optPrtCeded.Checked = True

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
        Dim X As Integer

        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

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
        If Fstat <> 0 And s <> "999" Then
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
                cmdPrt.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then cmdPrt.Focus()

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

        If S1 = "00" Then Tobj.Text = ""
    End Sub
	
    Private Sub LoadCboMga()
        Dim X As Integer = 0

        rc = d4top(f1)
        ReDim MgaArray(d4recCount(f1) + 1)

        Call d4tagSelect(f1, d4tag(f1, "K1"))

        cboMga.Items.Clear()
        cboMga.Items.Add("999 All Companies")
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
		cboTrty.Items.Add("99 All Treaties")
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
	
	Private Sub ProcessCededRein()
		Dim X As Short

		'Initialize
		For X = 0 To 17 : T(X) = 0 : T1(X) = 0 : T2(X) = 0 : Next X
		Kstr = "" : Kstr1 = "" : Kstr2 = "" : Kstr3 = "" : Pcnt = 0
		
		'======================================================================================
		'= Option 1 Print Reinsurance Ceded Allocations
		'======================================================================================
		
		'==================================================================================
		'= Get Reinalloc
		'==================================================================================
		
		If optByMga.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text <> "99" Then
			ReinAllocKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
			Call d4tagSelect(f30, d4tag(f30, "K2"))
		End If
		
		If optByMga.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text = "99" Then
			ReinAllocKey = Trim(txtMgaNmbr.Text)
			Call d4tagSelect(f30, d4tag(f30, "K2"))
		End If
		
		If optByMga.Checked And txtMgaNmbr.Text = "999" Then
			ReinAllocKey = ""
			Call d4tagSelect(f30, d4tag(f30, "K3"))
		End If
		
		If optByRein.Checked Then
			ReinAllocKey = WorkReiNmbr
			Call d4tagSelect(f30, d4tag(f30, "K1"))
		End If
		
		rc = d4top(f30)
		rc = d4seek(f30, ReinAllocKey)
		
		Do Until rc = r4eof
			
			'______________________________________________________________________________
			
			'One MGA Only
			If optByMga.Checked And txtMgaNmbr.Text <> "999" Then
				If ReinAllocKey <> Trim(f4str(RAp.MgaNmbr)) Then GoTo nextrec
			End If
			
			'One MGA and One Treaty Only
			If optByMga.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text <> "99" Then
				If ReinAllocKey <> Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr)) Then
					GoTo nextrec
				End If
			End If
			
			'One Reinsurer
			If optByRein.Checked And WorkReiNmbr <> "" Then
				If ReinAllocKey <> Trim(f4str(RAp.ReiNmbr)) Then GoTo nextrec
			End If
			
			'Rein Option One MGA
			If optByRein.Checked And txtMgaNmbr.Text <> "999" Then
				If txtMgaNmbr.Text <> Trim(f4str(RAp.MgaNmbr)) Then GoTo nextrec
			End If
			
			'Rein Option One MGA and One Treaty Only
			If optByRein.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text <> "99" Then
				If txtMgaNmbr.Text & txTrtyNmbr <> Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr)) Then
					GoTo nextrec
				End If
			End If
			
			'______________________________________________________________________________
			
			If optByMga.Checked Then
				Kstr = Trim(f4str(RAp.MgaNmbr))
				Kstr2 = Trim(f4str(RAp.ReiNmbr))
			End If
			
			If optByMga.Checked And txtTrtyNmbr.Text <> "99" Then
				Kstr = Trim(f4str(RAp.MgaNmbr))
				Kstr2 = Trim(f4str(RAp.TrtyNmbr))
			End If
			
			If optByRein.Checked Then
				Kstr = Trim(f4str(RAp.ReiNmbr))
				Kstr2 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
			End If
			
			If Kstr1 = "" Then
				Kstr1 = Kstr
				Kstr3 = Kstr2
				PrtCedPageHeading()
				pc = True
			End If
			
			'Print
			If Kstr <> Kstr1 Then
				PrtCedSumTotal()
				PrtCedCompTotal()
				If optByMga.Checked Then
					Kstr1 = Trim(f4str(RAp.MgaNmbr))
					Kstr3 = Trim(f4str(RAp.ReiNmbr))
				End If
				
				If optByMga.Checked And txtTrtyNmbr.Text <> "99" Then
					Kstr1 = Trim(f4str(RAp.MgaNmbr))
					Kstr3 = Trim(f4str(RAp.TrtyNmbr))
				End If
				
				If optByRein.Checked Then
					Kstr1 = Trim(f4str(RAp.ReiNmbr))
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
				pc = True
			End If
			
			If Kstr2 <> Kstr3 Then
				PrtCedSumTotal()
				If optByMga.Checked Then
					Kstr3 = Trim(f4str(RAp.ReiNmbr))
				End If
				
				If optByMga.Checked And txtTrtyNmbr.Text <> "99" Then
					Kstr3 = Trim(f4str(RAp.TrtyNmbr))
				End If
				
				If optByRein.Checked Then
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
			End If
			
			'______________________________________________________________________________
			
			GetReinAllocVar()
			
			'Total
			For X = 1 To 17
				T(X) = T(X) + RA(X)
			Next X
			
nextrec: 
			rc = d4skip(f30, 1)
		Loop 
		
		PrtCedSumTotal()
		PrtCedCompTotal()
		
		If txtMgaNmbr.Text = "999" Then
            Wname = "Grand Total"
            prtobj.Print()
            prtobj.Print(Wname, TAB(40), RSet(Format(T2(1) + T2(2), "####,###,###.00"), 15),
                                TAB(55), RSet(Format(T2(5) - T2(6) + T2(7), "####,###,###.00"), 15),
                                TAB(70), RSet(Format(T2(8) + T2(9) + T2(10) + T2(11), "####,###,###.00"), 15),
                                TAB(85), RSet(Format(T2(4), "####,###,###.00"), 15))
		End If
		
        prtobj.EndDoc()
	End Sub
	
    Sub PrtCedPageHeading()
        Dim V As String = " "
        Dim V1 As String = " "
        Dim V2 As String = " "

        'Heading
        Pcnt = Pcnt + 1
        If Not BeginRun Then prtobj.NewPage()
        BeginRun = False

        prtobj.Print(C0str, TAB(95), "Page" & Str(Pcnt))

        If optByMga.Checked Then
            V = "YTD Ceded Totals By MGA"
            V1 = "MGA Name"
            V2 = "Reinsurer Name"
        End If

        If optByRein.Checked Then
            V = "YTD Ceded Totals By Rein"
            V1 = "Rein Name"
            V2 = "MGA Name"
        End If

        prtobj.Print(V)
        prtobj.Print("For Period Ending " & J4str)
        prtobj.Print(Z1str)
        prtobj.Print()

        prtobj.Print(V1, TAB(49), "Premium", TAB(60), "Paid Losses", TAB(74), "Loss Reserve", TAB(90), "Unearn Prem")
        prtobj.Print()
        prtobj.Print(V2)

        L0 = 9
    End Sub
	
    Sub PrtCedSumTotal()
        Dim X As Integer
        Dim wtot As Double = 0

        For X = 1 To 11 : wtot = wtot + T(X) : Next X
        If wtot = 0 Then Exit Sub

        MgaKey = txRaMgaNmbr
        GetMgaMstRec()

        TrtyKey = txRaMgaNmbr & txRaTrtyNmbr
        GetTrtyMstRec()
        GetTrtyMstVar()

        ReiKey = txRaReiNmbr
        GetReiMstRec()

        If L0 > 50 Then PrtCedPageHeading()

        If pc = True Then
            If optByMga.Checked Then Wname = Trim(txMgaName) & " " & txRaMgaNmbr
            If optByMga.Checked And txtTrtyNmbr.Text <> "99" Then Wname = Wname & " " & txRaTrtyNmbr
            If optByRein.Checked Then Wname = txReiName & " " & txRaReiNmbr
            prtobj.Print(Wname)
            prtobj.Print("----------------------------------------")
            pc = False
            L0 = L0 + 2
        End If

        If optByMga.Checked Then Wname = txReiName & " " & txRaReiNmbr

        If optByMga.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text = "99" Then
            Wname = Mid(txTrtyDesc, 1, 25) & " " & txRaTrtyNmbr & " " & txRaReiNmbr & " " & RSet(Format(CDbl(txRaReiPerc), "#00.00"), 6)
        End If

        If optByRein.Checked Then
            Wname = Mid(txTrtyDesc, 1, 25) & " " & txRaMgaNmbr & " " & txRaTrtyNmbr & " " & RSet(Format(CDbl(txRaReiPerc), "#00.00"), 6)
        End If

        prtobj.Print(Wname, TAB(40), RSet(Format(T(1) + T(2), "####,###,###.00"), 15),
                            TAB(55), RSet(Format(T(5) - T(6) + T(7), "####,###,###.00"), 15),
                            TAB(70), RSet(Format(T(8) + T(9) + T(10) + T(11), "####,###,###.00"), 15),
                            TAB(85), RSet(Format(T(4), "####,###,###.00"), 15))

        L0 = L0 + 1

        For X = 1 To 11 : T1(X) = T1(X) + T(X) : T(X) = 0 : Next X

    End Sub
	
	Sub PrtCedCompTotal()
        Dim wtot As Double = 0
        Dim X As Integer

        For X = 1 To 11 : wtot = wtot + T1(X) : Next X
		If wtot = 0 Then Exit Sub
		
        If optByMga.Checked Then Wname = "MGA Total "
        If optByRein.Checked Then Wname = "REIN Total "
		
        prtobj.Print()
        prtobj.Print(Wname, TAB(40), RSet(Format(T1(1) + T1(2), "####,###,###.00"), 15),
                            TAB(55), RSet(Format(T1(5) - T1(6) + T1(7), "####,###,###.00"), 15),
                            TAB(70), RSet(Format(T1(8) + T1(9) + T1(10) + T1(11), "####,###,###.00"), 15),
                            TAB(85), RSet(Format(T1(4), "####,###,###.00"), 15))
        prtobj.Print()
		
		For X = 1 To 11 : T2(X) = T2(X) + T1(X) : T1(X) = 0 : Next X
		L0 = L0 + 3
	End Sub
	
	Private Sub ProcessBalRein()
		Dim X As Short

		'Initialize
		For X = 0 To 17 : T(X) = 0 : T1(X) = 0 : T2(X) = 0 : Next X
		Kstr = "" : Kstr1 = "" : Kstr2 = "" : Kstr3 = "" : Pcnt = 0
		
		'======================================================================================
		'= Option 2 Print Reinsurance Balances
		'======================================================================================
		
		'==================================================================================
		'= Get Reinalloc
		'==================================================================================
		
		If optByMga.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text <> "99" Then
			ReinAllocKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
			Call d4tagSelect(f30, d4tag(f30, "K2"))
		End If
		
		If optByMga.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text = "99" Then
			ReinAllocKey = Trim(txtMgaNmbr.Text)
			Call d4tagSelect(f30, d4tag(f30, "K2"))
		End If
		
		If optByMga.Checked And txtMgaNmbr.Text = "999" Then
			ReinAllocKey = ""
			Call d4tagSelect(f30, d4tag(f30, "K2"))
		End If
		
		If optByRein.Checked Then
			ReinAllocKey = WorkReiNmbr
			Call d4tagSelect(f30, d4tag(f30, "K1"))
		End If
		
		rc = d4top(f30)
		rc = d4seek(f30, ReinAllocKey)
		
		Do Until rc = r4eof
            '______________________________________________________________________________
			
			'One MGA Only
			If optByMga.Checked And txtMgaNmbr.Text <> "999" Then
				If Mid(ReinAllocKey, 1, 3) <> Trim(f4str(RAp.MgaNmbr)) Then GoTo nextrec
			End If
			
			'One MGA and One Treaty Only
			If optByMga.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text <> "99" Then
				If ReinAllocKey <> Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr)) Then
					GoTo nextrec
				End If
			End If
			
			'One Reinsurer
			If optByRein.Checked And WorkReiNmbr <> "" Then
				If ReinAllocKey <> Trim(f4str(RAp.ReiNmbr)) Then GoTo nextrec
			End If
			
			'Rein Option One MGA
			If optByRein.Checked And txtMgaNmbr.Text <> "999" Then
				If txtMgaNmbr.Text <> Trim(f4str(RAp.MgaNmbr)) Then GoTo nextrec
			End If
			
			'Rein Option One MGA and One Treaty Only
			If optByRein.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text <> "99" Then
				If txtMgaNmbr.Text & txTrtyNmbr <> Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr)) Then
					GoTo nextrec
				End If
			End If
			
			'______________________________________________________________________________
			
			If optByMga.Checked Then
				Kstr = Trim(f4str(RAp.MgaNmbr))
				Kstr2 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
			End If
			
			If optByRein.Checked Then
				Kstr = Trim(f4str(RAp.ReiNmbr))
				Kstr2 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
			End If
			
			If Kstr1 = "" Then
				Kstr1 = Kstr
				Kstr3 = Kstr2
				PrtBalPageHeading()
				pc = True
			End If
			
			'Print
			If Kstr <> Kstr1 Then
				PrtBalSumTotal()
				PrtBalCompTotal()
				pc = True
				If optByMga.Checked Then
					Kstr1 = Trim(f4str(RAp.MgaNmbr))
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
				
				If optByRein.Checked Then
					Kstr1 = Trim(f4str(RAp.ReiNmbr))
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
			End If
			
			If Kstr2 <> Kstr3 Then
				If optByMga.Checked Then pc = True
				PrtBalSumTotal()
				If optByMga.Checked Then
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
				
				If optByRein.Checked Then
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
			End If
			
			'______________________________________________________________________________
			
			GetReinAllocVar()
			If optByMga.Checked Then PrtBalRec()
			If optByRein.Checked Then For X = 12 To 14 : T(X) = T(X) + RA(X) : Next X
			
nextrec: 
			rc = d4skip(f30, 1)
		Loop 
		
		'PrtBalRec
		If optByRein.Checked Then pc = False
		PrtBalSumTotal()
		PrtBalCompTotal()
		
		If txtMgaNmbr.Text = "999" Then
            Wname = "Grand Total"
            prtobj.Print()
            prtobj.Print(Wname, TAB(40), RSet(Format(T2(12), "####,###,###.00"), 15),
                                TAB(55), RSet(Format(T2(13), "####,###,###.00"), 15),
                                TAB(70), RSet(Format(T2(14), "####,###,###.00"), 15))
		End If
		
        prtobj.EndDoc()
	End Sub
	
	Sub PrtBalPageHeading()
        Dim V As String = " "
        Dim V1 As String = " "
        Dim V2 As String = " "

		'Heading
		Pcnt = Pcnt + 1
        If Not BeginRun Then prtobj.NewPage()
        BeginRun = False
		
        prtobj.Print(C0str, TAB(95), "Page" & Str(Pcnt))
		
        If optByMga.Checked Then
            V = "YTD Payable Totals By MGA"
            V1 = "MGA Name"
            V2 = "Reinsurer Name"
        End If

        If optByRein.Checked Then
            V = "YTD Payable Totals By Rein"
            V1 = "Rein Name"
            V2 = "MGA Name"
        End If

        prtobj.Print(V)
        prtobj.Print("For Period Ending " & J4str)
        prtobj.Print(Z1str)
        prtobj.Print()
		
        prtobj.Print(V1, TAB(45), "Reinsurance", TAB(67), "Loss", TAB(83), "LAE")
        prtobj.Print(V2, TAB(49), "Payable", TAB(60), "Recoverable", TAB(75), "Recoverable")
        prtobj.Print()
        prtobj.Print()
		
		L0 = 10
	End Sub
	
	Sub PrtBalRec()
        Dim wtot As Double = 0
		
        wtot = RA(12) + RA(13) + RA(14)
		If wtot = 0 Then Exit Sub
		
		MgaKey = txRaMgaNmbr
		GetMgaMstRec()
		
		TrtyKey = txRaMgaNmbr & txRaTrtyNmbr
		GetTrtyMstRec()
		GetTrtyMstVar()
		
		ReiKey = txRaReiNmbr
		GetReiMstRec()
		
		If L0 > 50 Then PrtBalPageHeading()
		
		If pc = True Then
            If optByMga.Checked Then Wname = Trim(txMgaName) & " " & txRaMgaNmbr & "-" & txRaTrtyNmbr
            If optByRein.Checked Then Wname = txReiName & " " & txRaReiNmbr
            prtobj.Print(Wname)
            prtobj.Print("----------------------------------------")
			pc = False
			L0 = L0 + 2
		End If
		
        Wname = Mid(txReiName, 1, 25) & " " & txRaReiNmbr & " " & RSet(Format(CDbl(txRaReiPerc), "#00.00"), 6)
        prtobj.Print(Wname, TAB(40), RSet(Format(RA(12), "####,###,###.00"), 15),
                            TAB(55), RSet(Format(RA(13), "####,###,###.00"), 15),
                            TAB(70), RSet(Format(RA(14), "####,###,###.00"), 15))
		
		L0 = L0 + 1
		
		T(12) = T(12) + RA(12)
		T(13) = T(13) + RA(13)
		T(14) = T(14) + RA(14)
    End Sub
	
	Sub PrtBalSumTotal()
        Dim wtot As Double = 0
        Dim X As Integer

        wtot = T(12) + T(13) + T(14)
		If wtot = 0 Then Exit Sub
		
		MgaKey = txRaMgaNmbr
		GetMgaMstRec()
		
		TrtyKey = txRaMgaNmbr & txRaTrtyNmbr
		GetTrtyMstRec()
		GetTrtyMstVar()
		
		ReiKey = txRaReiNmbr
		GetReiMstRec()
		
		If L0 > 50 Then PrtBalPageHeading()
		
		If optByRein.Checked Then
			If pc = True Then
                If optByRein.Checked Then Wname = txReiName & " " & txRaReiNmbr
                prtobj.Print(Wname)
                prtobj.Print("----------------------------------------")
				pc = False
				L0 = L0 + 2
			End If
		End If
		
		If optByRein.Checked Then
            Wname = Mid(txTrtyDesc, 1, 25) & " " & txRaMgaNmbr & " " & txRaTrtyNmbr & " " & RSet(Format(CDbl(txRaReiPerc), "#00.00"), 6)
		End If
		
		If optByMga.Checked Then
            prtobj.Print()
            Wname = "Treaty Total"
		End If
		
        prtobj.Print(Wname, TAB(40), RSet(Format(T(12), "####,###,###.00"), 15),
                            TAB(55), RSet(Format(T(13), "####,###,###.00"), 15),
                            TAB(70), RSet(Format(T(14), "####,###,###.00"), 15))

        If optByMga.Checked Then
            prtobj.Print()
            L0 = L0 + 3
        Else
            L0 = L0 + 1
        End If
		
		For X = 12 To 14 : T1(X) = T1(X) + T(X) : T(X) = 0 : Next X
		
	End Sub
	
	Sub PrtBalCompTotal()
        Dim wtot As Double = 0
        Dim X As Integer

        wtot = T1(12) + T1(13) + T1(14)
		If wtot = 0 Then Exit Sub
		
        If optByMga.Checked Then Wname = "MGA Total "
		
		If optByRein.Checked Then
            prtobj.Print()
            Wname = "REIN Total "
		End If
		
        prtobj.Print(Wname, TAB(40), RSet(Format(T1(12), "####,###,###.00"), 15),
                            TAB(55), RSet(Format(T1(13), "####,###,###.00"), 15),
                            TAB(70), RSet(Format(T1(14), "####,###,###.00"), 15))

        prtobj.Print()
		
		For X = 12 To 14 : T2(X) = T2(X) + T1(X) : T1(X) = 0 : Next X
		L0 = L0 + 3
	End Sub
	
	Private Sub ProcessRptRein()
		Dim response As Object
		Dim X As Short

		ToFile = False
        response = MsgBox("Send Output To File?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "")
		If response = MsgBoxResult.Yes Then ToFile = True
		
		If ToFile Then
			Fname1 = My.Application.Info.DirectoryPath & "\REINRPT.txt"
			FileOpen(1, Fname1, OpenMode.Output)
		End If
		
		'Initialize
		For X = 0 To 17 : T(X) = 0 : T1(X) = 0 : T2(X) = 0 : Next X
		Kstr = "" : Kstr1 = "" : Kstr2 = "" : Kstr3 = "" : Pcnt = 0
		
		'======================================================================================
		'= Option 3 Print Reinsurance Report Totals
		'======================================================================================
		
		'==================================================================================
		'= Get Reinalloc
		'==================================================================================
		
		If optByMga.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text <> "99" Then
			ReinAllocKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
			Call d4tagSelect(f30, d4tag(f30, "K2"))
		End If
		
		If optByMga.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text = "99" Then
			ReinAllocKey = Trim(txtMgaNmbr.Text)
			Call d4tagSelect(f30, d4tag(f30, "K2"))
		End If
		
		If optByMga.Checked And txtMgaNmbr.Text = "999" Then
			ReinAllocKey = ""
			Call d4tagSelect(f30, d4tag(f30, "K2"))
		End If
		
		If optByRein.Checked Then
			ReinAllocKey = WorkReiNmbr
			Call d4tagSelect(f30, d4tag(f30, "K1"))
		End If
		
		rc = d4top(f30)
		rc = d4seek(f30, ReinAllocKey)
		
		Do Until rc = r4eof
			
			'______________________________________________________________________________
			
			'One MGA Only
			If optByMga.Checked And txtMgaNmbr.Text <> "999" Then
				If ReinAllocKey <> Trim(f4str(RAp.MgaNmbr)) Then GoTo nextrec
			End If
			
			'One MGA and One Treaty Only
			If optByMga.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text <> "99" Then
				If ReinAllocKey <> Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr)) Then
					GoTo nextrec
				End If
			End If
			
			'One Reinsurer
			If optByRein.Checked And WorkReiNmbr <> "" Then
				If ReinAllocKey <> Trim(f4str(RAp.ReiNmbr)) Then GoTo nextrec
			End If
			
			'Rein Option One MGA
			If optByRein.Checked And txtMgaNmbr.Text <> "999" Then
				If txtMgaNmbr.Text <> Trim(f4str(RAp.MgaNmbr)) Then GoTo nextrec
			End If
			
			'Rein Option One MGA and One Treaty Only
			If optByRein.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text <> "99" Then
				If txtMgaNmbr.Text & txTrtyNmbr <> Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr)) Then
					GoTo nextrec
				End If
			End If
			
			'______________________________________________________________________________
			
			If optByMga.Checked Then
				Kstr = Trim(f4str(RAp.MgaNmbr))
				Kstr2 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
			End If
			
			If optByRein.Checked Then
				Kstr = Trim(f4str(RAp.ReiNmbr))
				Kstr2 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
			End If
			
			If Kstr1 = "" Then
				Kstr1 = Kstr
				Kstr3 = Kstr2
				If Not ToFile Then PrtRptPageHeading()
				If ToFile Then WriteRptPageHeading()
				pc = True
			End If
			
			'Print
			If Kstr <> Kstr1 Then
				If Not ToFile Then PrtRptSumTotal()
				If Not ToFile Then PrtRptCompTotal()
				If ToFile Then WriteRptSumTotal()
				If ToFile Then WriteRptCompTotal()
				If Not optPrtSumYes.Checked Then L0 = 60
				pc = True
				If optByMga.Checked Then
					Kstr1 = Trim(f4str(RAp.MgaNmbr))
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
				
				If optByRein.Checked Then
					Kstr1 = Trim(f4str(RAp.ReiNmbr))
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
			End If
			
			If Kstr2 <> Kstr3 Then
				If optByMga.Checked Then pc = True
				If Not ToFile Then PrtRptSumTotal()
				If ToFile Then WriteRptSumTotal()
				If optByMga.Checked Then
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
				
				If optByRein.Checked Then
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
			End If
			
			'______________________________________________________________________________
			
			GetReinAllocVar()
			
			If optByMga.Checked Then
				If Not ToFile Then PrtRptRec()
				If ToFile Then WriteRptRec()
			End If
			
			If optByRein.Checked Then For X = 1 To 14 : T(X) = T(X) + RA(X) : Next X
			
nextrec: 
			rc = d4skip(f30, 1)
		Loop 
		
		'PrtRptRec
        'If optByRein.Checked Then pc = True
		If Not ToFile Then PrtRptSumTotal()
		If Not ToFile Then PrtRptCompTotal()
		If ToFile Then WriteRptSumTotal()
		If ToFile Then WriteRptCompTotal()
		If ToFile Then WriteRptFinalTotal()

		If ToFile Then
			FileClose(1)
			Exit Sub
		End If
		
		If txtMgaNmbr.Text = "999" Then
            Wname = "Grand Total"
            prtobj.Print()

            prtobj.Print(Wname, TAB(35), RSet(Format(T2(1), "####,###,###.00"), 15),
                                TAB(50), RSet(Format(T2(3), "####,###,###.00"), 15),
                                TAB(65), RSet(Format(T2(5), "####,###,###.00"), 15),
                                TAB(80), RSet(Format(T2(8), "####,###,###.00"), 15),
                                TAB(95), RSet(Format(T2(9), "####,###,###.00"), 15),
                                TAB(110), RSet(Format(T2(12), "####,###,###.00"), 15),
                                TAB(125), RSet(Format(T2(5) - T2(6), "####,###,###.00"), 15))
			
            prtobj.Print(TAB(35), RSet(Format(T2(2), "####,###,###.00"), 15),
                         TAB(50), RSet(Format(T2(4), "####,###,###.00"), 15),
                         TAB(65), RSet(Format(T2(6), "####,###,###.00"), 15),
                         TAB(80), RSet(Format(T2(10), "####,###,###.00"), 15),
                         TAB(95), RSet(Format(T2(11), "####,###,###.00"), 15),
                         TAB(110), RSet(Format(T2(13), "####,###,###.00"), 15),
                         TAB(125), RSet(Format(T2(13) + T2(14), "####,###,###.00"), 15))
			
            prtobj.Print(TAB(65), RSet(Format(T2(7), "####,###,###.00"), 15),
                         TAB(110), RSet(Format(T2(14), "####,###,###.00"), 15),
                         TAB(125), RSet(Format(T2(4) + T2(8) + T2(9) + T2(10) + T2(11) + T2(13) + T2(14), "####,###,###.00"), 15))
		End If
		
        prtobj.Print()
        prtobj.Print()
        prtobj.Print()
        prtobj.Print()
        prtobj.Print(TAB(10), "Net Paid Losses", TAB(35), RSet(Format(T2(5) - T2(6), "####,###,###.00"), 15))
        prtobj.Print()
        prtobj.Print(TAB(10), "Recoverables", TAB(35), RSet(Format(T2(13) + T2(14), "####,###,###.00"), 15))
        prtobj.Print()
        prtobj.Print(TAB(10), "Reserves and Recoverables", TAB(35), RSet(Format(T2(4) + T2(8) + T2(9) + T2(10) + T2(11) + T2(13) + T2(14), "####,###,###.00"), 15))
		
        prtobj.EndDoc()
	End Sub
	
	Sub PrtRptPageHeading()
        Dim V As String = " "
        Dim V1 As String = " "
        Dim V2 As String = " "

		'Heading
		Pcnt = Pcnt + 1
        If Not BeginRun Then prtobj.NewPage()
        BeginRun = False
		
        If optByMga.Checked Then
            V = "YTD Reinsurance Totals By MGA"
            V1 = "MGA Name"
            V2 = "Reinsurer Name"
        End If

        If optByRein.Checked Then
            V = "YTD Reinsurance Totals By Rein"
            V1 = "Rein Name"
            V2 = "MGA Name"
        End If

        prtobj.Print(C0str, TAB(130), "Page " & Str(Pcnt))
        prtobj.Print(V)
        prtobj.Print("For Period Ending " & J4str)
        prtobj.Print(Z1str)
        prtobj.Print()
		
        prtobj.Print(V1, TAB(43), "Premium", TAB(55), "Commission", TAB(76), "Paid",
                         TAB(83), "O/S Loss Res", TAB(99), "O/S LAE Res",
                         TAB(113), "Rein Payable", TAB(127), "Net PD Losses")
		
        prtobj.Print(V2, TAB(40), "Policy Fee", TAB(54), "Unearn Prem", TAB(71), "Sal/Subro",
                         TAB(82), "IBNR Loss Res", TAB(98), "IBNR LAE Res",
                         TAB(117), "Loss Rec", TAB(129), "Recoverable")
		
        prtobj.Print(TAB(72), "Paid LAE", TAB(118), "LAE Rec", TAB(126), "Reserves & Rec")
        prtobj.Print()
		
		L0 = 10
	End Sub
	
	Sub PrtRptRec()
        Dim wtot As Double = 0
        Dim X As Integer

        For X = 1 To 14
            If RA(X) <> 0 Then wtot = 1
        Next X
		If wtot = 0 Then Exit Sub
		
		MgaKey = txRaMgaNmbr
		GetMgaMstRec()
		
		TrtyKey = txRaMgaNmbr & txRaTrtyNmbr
		GetTrtyMstRec()
		GetTrtyMstVar()
		
		ReiKey = txRaReiNmbr
		GetReiMstRec()
		
        If Not optPrtSumYes.Checked Then
            If L0 > 50 Then PrtRptPageHeading()

            If pc = True Then
                Wname = Trim(Mid(txMgaName, 1, 25)) & " " & txRaMgaNmbr & "-" & txRaTrtyNmbr
                prtobj.Print(Wname)
                prtobj.Print("------------------------")
                pc = False
                L0 = L0 + 2
            End If

            prtobj.Print(Mid(txReiName, 1, 25),
                         TAB(35), RSet(Format(RA(1), "####,###,###.00"), 15),
                         TAB(50), RSet(Format(RA(3), "####,###,###.00"), 15),
                         TAB(65), RSet(Format(RA(5), "####,###,###.00"), 15),
                         TAB(80), RSet(Format(RA(8), "####,###,###.00"), 15),
                         TAB(95), RSet(Format(RA(9), "####,###,###.00"), 15),
                         TAB(110), RSet(Format(RA(12), "####,###,###.00"), 15),
                         TAB(125), RSet(Format(RA(5) - RA(6), "####,###,###.00"), 15))

            prtobj.Print(txRaReiNmbr & " " & RSet(Format(CDbl(txRaReiPerc), "#00.00"), 6),
                         TAB(35), RSet(Format(RA(2), "####,###,###.00"), 15),
                         TAB(50), RSet(Format(RA(4), "####,###,###.00"), 15),
                         TAB(65), RSet(Format(RA(6), "####,###,###.00"), 15),
                         TAB(80), RSet(Format(RA(10), "####,###,###.00"), 15),
                         TAB(95), RSet(Format(RA(11), "####,###,###.00"), 15),
                         TAB(110), RSet(Format(RA(13), "####,###,###.00"), 15),
                         TAB(125), RSet(Format(RA(13) + RA(14), "####,###,###.00"), 15))

            prtobj.Print(TAB(65), RSet(Format(RA(7), "####,###,###.00"), 15),
                         TAB(110), RSet(Format(RA(14), "####,###,###.00"), 15),
                         TAB(125), RSet(Format(RA(4) + RA(8) + RA(9) + RA(10) + RA(11) + RA(13) + RA(14), "####,###,###.00"), 15))

            prtobj.Print()

            L0 = L0 + 4
        End If
		
		For X = 1 To 14 : T(X) = T(X) + RA(X) : Next X
		
	End Sub
	
	Sub PrtRptSumTotal()
        Dim wtot As Double = 0
        Dim X As Integer
        Dim V As String = " "

        For X = 1 To 14 : wtot = wtot + T(X) : Next X
		If wtot = 0 Then Exit Sub
		
		MgaKey = txRaMgaNmbr
		GetMgaMstRec()
		
		TrtyKey = txRaMgaNmbr & txRaTrtyNmbr
		GetTrtyMstRec()
		GetTrtyMstVar()
		
		ReiKey = txRaReiNmbr
		GetReiMstRec()
		
		If L0 > 50 Then PrtRptPageHeading()
		
		If optByRein.Checked Then
			If pc = True Then
                If optByRein.Checked Then Wname = Trim(txReiName) & " " & txRaReiNmbr
                prtobj.Print(Wname)
                prtobj.Print("------------------------")
				pc = False
				L0 = L0 + 2
			End If
		End If
		
		If Not optPrtSumYes.Checked Then
			If optByMga.Checked Then
                prtobj.Print("Treaty Totals")
			End If
			
            If optByRein.Checked Then V = Mid(txTrtyDesc, 1, 25)

            prtobj.Print(V, TAB(35), RSet(Format(T(1), "####,###,###.00"), 15),
                            TAB(50), RSet(Format(T(3), "####,###,###.00"), 15),
                            TAB(65), RSet(Format(T(5), "####,###,###.00"), 15),
                            TAB(80), RSet(Format(T(8), "####,###,###.00"), 15),
                            TAB(95), RSet(Format(T(9), "####,###,###.00"), 15),
                            TAB(110), RSet(Format(T(12), "####,###,###.00"), 15),
                            TAB(125), RSet(Format(T(5) - T(6), "####,###,###.00"), 15))

            V = " "
            If optByRein.Checked Then V = txRaMgaNmbr & " " & txRaTrtyNmbr & " " & RSet(Format(CDbl(txRaReiPerc), "#00.00"), 6)
            prtobj.Print(V, TAB(35), RSet(Format(T(2), "####,###,###.00"), 15),
                            TAB(50), RSet(Format(T(4), "####,###,###.00"), 15),
                            TAB(65), RSet(Format(T(6), "####,###,###.00"), 15),
                            TAB(80), RSet(Format(T(10), "####,###,###.00"), 15),
                            TAB(95), RSet(Format(T(11), "####,###,###.00"), 15),
                            TAB(110), RSet(Format(T(13), "####,###,###.00"), 15),
                            TAB(125), RSet(Format(T(13) + T(14), "####,###,###.00"), 15))

            prtobj.Print(TAB(65), RSet(Format(T(7), "####,###,###.00"), 15),
                         TAB(110), RSet(Format(T(14), "####,###,###.00"), 15),
                         TAB(125), RSet(Format(T(4) + T(8) + T(9) + T(10) + T(11) + T(13) + T(14), "####,###,###.00"), 15))

            prtobj.Print()
			
			If optByMga.Checked Then
                prtobj.Print()
				L0 = L0 + 4
			Else
				L0 = L0 + 4
			End If
		End If
		
		For X = 1 To 14 : T1(X) = T1(X) + T(X) : T(X) = 0 : Next X
		
	End Sub
	
	Sub PrtRptCompTotal()
        Dim wtot As Double = 0
        Dim X As Integer

        For X = 1 To 14 : wtot = wtot + T1(X) : Next X
		If wtot = 0 Then Exit Sub
		
        If optByMga.Checked Then Wname = "MGA Totals "
		
		If optByRein.Checked Then
            prtobj.Print()
            Wname = "REIN Totals "
		End If
		
        prtobj.Print(TAB(10), Trim(Wname),
                     TAB(35), RSet(Format(T1(1), "####,###,###.00"), 15),
                     TAB(50), RSet(Format(T1(3), "####,###,###.00"), 15),
                     TAB(65), RSet(Format(T1(5), "####,###,###.00"), 15),
                     TAB(80), RSet(Format(T1(8), "####,###,###.00"), 15),
                     TAB(95), RSet(Format(T1(9), "####,###,###.00"), 15),
                     TAB(110), RSet(Format(T1(12), "####,###,###.00"), 15),
                     TAB(125), RSet(Format(T1(5) - T1(6), "####,###,###.00"), 15))

        prtobj.Print(TAB(35), RSet(Format(T1(2), "####,###,###.00"), 15),
                     TAB(50), RSet(Format(T1(4), "####,###,###.00"), 15),
                     TAB(65), RSet(Format(T1(6), "####,###,###.00"), 15),
                     TAB(80), RSet(Format(T1(10), "####,###,###.00"), 15),
                     TAB(95), RSet(Format(T1(11), "####,###,###.00"), 15),
                     TAB(110), RSet(Format(T1(13), "####,###,###.00"), 15),
                     TAB(125), RSet(Format(T1(13) + T1(14), "####,###,###.00"), 15))


        prtobj.Print(TAB(65), RSet(Format(T1(7), "####,###,###.00"), 15),
                     TAB(110), RSet(Format(T1(14), "####,###,###.00"), 15),
                     TAB(125), RSet(Format(T1(4) + T1(8) + T1(9) + T1(10) + T1(11) + T1(13) + T1(14), "####,###,###.00"), 15))

        prtobj.Print()
		
		For X = 1 To 14 : T2(X) = T2(X) + T1(X) : T1(X) = 0 : Next X
		L0 = L0 + 5
	End Sub
	
	Sub WriteRptPageHeading()
        Dim V As String = " "
        Dim V1 As String = " "
        Dim V2 As String = " "

        'Heading
		Pcnt = Pcnt + 1
		BeginRun = False
		
        If optByMga.Checked Then
            V = "YTD Reinsurance Totals By MGA"
            V1 = "MGA Name"
            V2 = "Reinsurer Name"
        End If

        If optByRein.Checked Then
            V = "YTD Reinsurance Totals By Rein"
            V1 = "Rein Name"
            V2 = "MGA Name"
        End If

        PrintLine(1, C0str, TAB(130), "Page " & Str(Pcnt))
        PrintLine(1, V)
        PrintLine(1, "For Period Ending " & J4str)
        PrintLine(1, Z1str)
        PrintLine(1)
		
        PrintLine(1, V1, TAB(43), "Premium", TAB(55), "Commission", TAB(76), "Paid",
                     TAB(83), "O/S Loss Res", TAB(99), "O/S LAE Res",
                     TAB(113), "Rein Payable", TAB(127), "Net PD Losses")
		
        PrintLine(1, V2, TAB(40), "Policy Fee", TAB(54), "Unearn Prem", TAB(71), "Sal/Subro",
                     TAB(82), "IBNR Loss Res", TAB(98), "IBNR LAE Res",
                     TAB(117), "Loss Rec", TAB(129), "Recoverable")
		
        PrintLine(1, TAB(72), "Paid LAE", TAB(118), "LAE Rec", TAB(126), "Reserves & Rec")
        PrintLine(1)
		
		L0 = 10
	End Sub
	
	Sub WriteRptRec()
        Dim wtot As Double = 0
        Dim X As Integer

        For X = 1 To 14
            If RA(X) <> 0 Then wtot = 1
        Next X
		
		If wtot = 0 Then Exit Sub
		
		MgaKey = txRaMgaNmbr
		GetMgaMstRec()
		
		TrtyKey = txRaMgaNmbr & txRaTrtyNmbr
		GetTrtyMstRec()
		GetTrtyMstVar()
		
		ReiKey = txRaReiNmbr
		GetReiMstRec()
		
		If Not optPrtSumYes.Checked Then
			If pc = True Then
                Wname = Trim(Mid(txMgaName, 1, 25)) & " " & txRaMgaNmbr & "-" & txRaTrtyNmbr
                PrintLine(1, Wname)
				PrintLine(1, "------------------------")
				pc = False
				L0 = L0 + 2
			End If
			
            PrintLine(1, Mid(txReiName, 1, 25),
                  TAB(35), RSet(Format(RA(1), "####,###,###.00"), 15),
                  TAB(50), RSet(Format(RA(3), "####,###,###.00"), 15),
                  TAB(65), RSet(Format(RA(5), "####,###,###.00"), 15),
                  TAB(80), RSet(Format(RA(8), "####,###,###.00"), 15),
                  TAB(95), RSet(Format(RA(9), "####,###,###.00"), 15),
                  TAB(110), RSet(Format(RA(12), "####,###,###.00"), 15),
                  TAB(125), RSet(Format(RA(5) - RA(6), "####,###,###.00"), 15))
			
            PrintLine(1, txRaReiNmbr & " " & RSet(Format(CDbl(txRaReiPerc), "#00.00"), 6),
                  TAB(35), RSet(Format(RA(2), "####,###,###.00"), 15),
                  TAB(50), RSet(Format(RA(4), "####,###,###.00"), 15),
                  TAB(65), RSet(Format(RA(6), "####,###,###.00"), 15),
                  TAB(80), RSet(Format(RA(10), "####,###,###.00"), 15),
                  TAB(95), RSet(Format(RA(11), "####,###,###.00"), 15),
                  TAB(110), RSet(Format(RA(13), "####,###,###.00"), 15),
                  TAB(125), RSet(Format(RA(13) + RA(14), "####,###,###.00"), 15))
			
            PrintLine(1, TAB(65), RSet(Format(RA(7), "####,###,###.00"), 15),
                     TAB(110), RSet(Format(RA(14), "####,###,###.00"), 15),
                     TAB(125), RSet(Format(RA(4) + RA(8) + RA(9) + RA(10) + RA(11) + RA(13) + RA(14), "####,###,###.00"), 15))
            PrintLine(1)

            L0 = L0 + 4
		End If
		
		For X = 1 To 14 : T(X) = T(X) + RA(X) : Next X
	End Sub
	
	Sub WriteRptSumTotal()
        Dim wtot As Double = 0
        Dim X As Integer
        Dim V As String = " "

        For X = 1 To 14 : wtot = wtot + T(X) : Next X
		If wtot = 0 Then Exit Sub
		
		MgaKey = txRaMgaNmbr
		GetMgaMstRec()
		
		TrtyKey = txRaMgaNmbr & txRaTrtyNmbr
		GetTrtyMstRec()
		GetTrtyMstVar()
		
		ReiKey = txRaReiNmbr
		GetReiMstRec()
		
		If optByRein.Checked Then
			If pc = True Then
                If optByRein.Checked Then Wname = Trim(txReiName) & " " & txRaReiNmbr
                PrintLine(1, Wname)
                PrintLine(1, "------------------------")
				pc = False
				L0 = L0 + 2
			End If
		End If
		
		If Not optPrtSumYes.Checked Then
			If optByMga.Checked Then
				Print(1, "Treaty Totals")
			End If
			
            V = " "
            If optByRein.Checked Then V = Mid(txTrtyDesc, 1, 25)
            PrintLine(1, V, TAB(35), RSet(Format(T(1), "####,###,###.00"), 15),
                        TAB(50), RSet(Format(T(3), "####,###,###.00"), 15),
                        TAB(65), RSet(Format(T(5), "####,###,###.00"), 15),
                        TAB(80), RSet(Format(T(8), "####,###,###.00"), 15),
                        TAB(95), RSet(Format(T(9), "####,###,###.00"), 15),
                        TAB(110), RSet(Format(T(12), "####,###,###.00"), 15),
                        TAB(125), RSet(Format(T(5) - T(6), "####,###,###.00"), 15))
			
            V = " "
            If optByRein.Checked Then V = txRaMgaNmbr & " " & txRaTrtyNmbr & " " & RSet(Format(CDbl(txRaReiPerc), "#00.00"), 6)
            PrintLine(1, V, TAB(35), RSet(Format(T(2), "####,###,###.00"), 15),
                        TAB(50), RSet(Format(T(4), "####,###,###.00"), 15),
                        TAB(65), RSet(Format(T(6), "####,###,###.00"), 15),
                        TAB(80), RSet(Format(T(10), "###,###,###.00"), 15),
                        TAB(95), RSet(Format(T(11), "####,###,###.00"), 15),
                        TAB(110), RSet(Format(T(13), "####,###,###.00"), 15),
                        TAB(125), RSet(Format(T(13) + T(14), "####,###,###.00"), 15))
			
            PrintLine(1, TAB(65), RSet(Format(T(7), "####,###,###.00"), 15),
                     TAB(110), RSet(Format(T(14), "####,###,###.00"), 15),
                     TAB(125), RSet(Format(T(4) + T(8) + T(9) + T(10) + T(11) + T(13) + T(14), "####,###,###.00"), 15))

            PrintLine(1)
			
			If optByMga.Checked Then
                PrintLine(1)
				L0 = L0 + 4
			Else
				L0 = L0 + 4
			End If
		End If
		
		For X = 1 To 14 : T1(X) = T1(X) + T(X) : T(X) = 0 : Next X
		
	End Sub
	
	Sub WriteRptCompTotal()
        Dim wtot As Double = 0
        Dim X As Integer

        For X = 1 To 14 : wtot = wtot + T1(X) : Next X
		If wtot = 0 Then Exit Sub
		
        If optByMga.Checked Then
            Wname = txTrtyDesc
            PrintLine(1)
            PrintLine(1, Wname)
            PrintLine(1, "------------------------")
            PrintLine(1, "MGA Totals")
        End If

		
		If optByRein.Checked Then
            PrintLine(1)
            Wname = "REIN Totals "
		End If

        If optByMga.Checked And Wname = txTrtyDesc Then Wname = ""


        PrintLine(1, TAB(10), Trim(Wname),
                 TAB(35), RSet(Format(T1(1), "####,###,###.00"), 15),
                 TAB(50), RSet(Format(T1(3), "####,###,###.00"), 15),
                 TAB(65), RSet(Format(T1(5), "####,###,###.00"), 15),
                 TAB(80), RSet(Format(T1(8), "####,###,###.00"), 15),
                 TAB(95), RSet(Format(T1(9), "####,###,###.00"), 15),
                 TAB(110), RSet(Format(T1(12), "####,###,###.00"), 15),
                 TAB(125), RSet(Format(T1(5) - T1(6), "####,###,###.00"), 15))

        PrintLine(1, TAB(35), RSet(Format(T1(2), "####,###,###.00"), 15),
                 TAB(50), RSet(Format(T1(4), "####,###,###.00"), 15),
                 TAB(65), RSet(Format(T1(6), "####,###,###.00"), 15),
                 TAB(80), RSet(Format(T1(10), "###,###,###.00"), 15),
                 TAB(95), RSet(Format(T1(11), "####,###,###.00"), 15),
                 TAB(110), RSet(Format(T1(13), "####,###,###.00"), 15),
                 TAB(125), RSet(Format(T1(13) + T1(14), "####,###,###.00"), 15))

        PrintLine(1, TAB(65), RSet(Format(T1(7), "####,###,###.00"), 15),
                 TAB(110), RSet(Format(T1(14), "####,###,###.00"), 15),
                 TAB(125), RSet(Format(T1(4) + T1(8) + T1(9) + T1(10) + T1(11) + T1(13) + T1(14), "####,###,###.00"), 15))

        For X = 1 To 14 : T2(X) = T2(X) + T1(X) : T1(X) = 0 : Next X
        L0 = L0 + 5
    End Sub
	
	Sub WriteRptFinalTotal()
		If txtMgaNmbr.Text = "999" Then
            Wname = "Grand Total"
            PrintLine(1)
            PrintLine(1, TAB(10), Trim(Wname),
                     TAB(35), RSet(Format(T2(1), "####,###,###.00"), 15),
                     TAB(50), RSet(Format(T2(3), "####,###,###.00"), 15),
                     TAB(65), RSet(Format(T2(5), "####,###,###.00"), 15),
                     TAB(80), RSet(Format(T2(8), "####,###,###.00"), 15),
                     TAB(95), RSet(Format(T2(9), "####,###,###.00"), 15),
                     TAB(110), RSet(Format(T2(12), "####,###,###.00"), 15),
                     TAB(125), RSet(Format(T2(5) - T2(6), "####,###,###.00"), 15))

            PrintLine(1, TAB(35), RSet(Format(T2(2), "####,###,###.00"), 15),
                     TAB(50), RSet(Format(T2(4), "####,###,###.00"), 15),
                     TAB(65), RSet(Format(T2(6), "####,###,###.00"), 15),
                     TAB(80), RSet(Format(T2(10), "###,###,###.00"), 15),
                     TAB(95), RSet(Format(T2(11), "####,###,###.00"), 15),
                     TAB(110), RSet(Format(T2(13), "####,###,###.00"), 15),
                     TAB(125), RSet(Format(T2(13) + T2(14), "####,###,###.00"), 15))

            PrintLine(1, TAB(65), RSet(Format(T2(7), "####,###,###.00"), 15),
                     TAB(110), RSet(Format(T2(14), "####,###,###.00"), 15),
                     TAB(125), RSet(Format(T2(4) + T2(8) + T2(9) + T2(10) + T2(11) + T2(13) + T2(14), "####,###,###.00"), 15))
        End If
		
        PrintLine(1)
        PrintLine(1)
        PrintLine(1)
        PrintLine(1)
        PrintLine(1, TAB(10), "Net Paid Losses", TAB(35), RSet(Format(T2(5) - T2(6), "####,###,###.00"), 15))
        PrintLine(1)
        PrintLine(1, TAB(10), "Recoverables", TAB(35), RSet(Format(T2(13) + T2(14), "####,###,###.00"), 15))
        PrintLine(1)
        PrintLine(1, TAB(10), "Reserves and Recoverables", TAB(35), RSet(Format(T2(4) + T2(8) + T2(9) + T2(10) + T2(11) + T2(13) + T2(14), "####,###,###.00"), 15))
	End Sub
	
	Private Sub ProcessAgeRein()
		Dim X As Short

		'Initialize
		For X = 0 To 17 : T(X) = 0 : T1(X) = 0 : T2(X) = 0 : Next X
		Kstr = "" : Kstr1 = "" : Kstr2 = "" : Kstr3 = "" : Pcnt = 0
		
		'======================================================================================
		'= Option 4 Print Aging Balances
		'======================================================================================
		
		'==================================================================================
		'= Get Reinalloc
		'==================================================================================
		
		If optByMga.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text <> "99" Then
			ReinAllocKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
			Call d4tagSelect(f30, d4tag(f30, "K2"))
		End If
		
		If optByMga.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text = "99" Then
			ReinAllocKey = Trim(txtMgaNmbr.Text)
			Call d4tagSelect(f30, d4tag(f30, "K2"))
		End If
		
		If optByMga.Checked And txtMgaNmbr.Text = "999" Then
			ReinAllocKey = ""
			Call d4tagSelect(f30, d4tag(f30, "K2"))
		End If
		
		If optByRein.Checked Then
			ReinAllocKey = WorkReiNmbr
			Call d4tagSelect(f30, d4tag(f30, "K1"))
		End If
		
		rc = d4top(f30)
		rc = d4seek(f30, ReinAllocKey)
		
		Do Until rc = r4eof
			
			'______________________________________________________________________________
			
			'One MGA Only
			If optByMga.Checked And txtMgaNmbr.Text <> "999" Then
				If ReinAllocKey <> Trim(f4str(RAp.MgaNmbr)) Then GoTo nextrec
			End If
			
			'One MGA and One Treaty Only
			If optByMga.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text <> "99" Then
				If ReinAllocKey <> Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr)) Then
					GoTo nextrec
				End If
			End If
			
			'One Reinsurer
			If optByRein.Checked And WorkReiNmbr <> "" Then
				If ReinAllocKey <> Trim(f4str(RAp.ReiNmbr)) Then GoTo nextrec
			End If
			
			'Rein Option One MGA
			If optByRein.Checked And txtMgaNmbr.Text <> "999" Then
				If txtMgaNmbr.Text <> Trim(f4str(RAp.MgaNmbr)) Then GoTo nextrec
			End If
			
			'Rein Option One MGA and One Treaty Only
			If optByRein.Checked And txtMgaNmbr.Text <> "999" And txtTrtyNmbr.Text <> "99" Then
				If txtMgaNmbr.Text & txTrtyNmbr <> Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr)) Then
					GoTo nextrec
				End If
			End If
			
			'______________________________________________________________________________
			
			If optByMga.Checked Then
				Kstr = Trim(f4str(RAp.MgaNmbr))
				Kstr2 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
			End If
			
			If optByRein.Checked Then
				Kstr = Trim(f4str(RAp.ReiNmbr))
				Kstr2 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
			End If
			
			If Kstr1 = "" Then
				Kstr1 = Kstr
				Kstr3 = Kstr2
				PrtAgePageHeading()
				pc = True
			End If
			
			'Print
			If Kstr <> Kstr1 Then
				PrtAgeSumTotal()
				PrtAgeCompTotal()
				pc = True
				If optByMga.Checked Then
					Kstr1 = Trim(f4str(RAp.MgaNmbr))
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
				
				If optByRein.Checked Then
					Kstr1 = Trim(f4str(RAp.ReiNmbr))
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
			End If
			
			If Kstr2 <> Kstr3 Then
				If optByMga.Checked Then pc = True
				PrtAgeSumTotal()
				If optByMga.Checked Then
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
				
				If optByRein.Checked Then
					Kstr3 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.TrtyNmbr))
				End If
			End If
			
			'______________________________________________________________________________
			
			GetReinAllocVar()
			If optByMga.Checked Then PrtAgeRec()
			If optByRein.Checked Then For X = 15 To 17 : T(X) = T(X) + RA(X) : Next X
			
nextrec: 
			rc = d4skip(f30, 1)
		Loop 
		
		'PrtAgeRec
		If optByRein.Checked Then pc = False
		PrtAgeSumTotal()
		PrtAgeCompTotal()
		
		If txtMgaNmbr.Text = "999" Then
            Wname = "Grand Total"
            prtobj.Print()
            prtobj.Print(Wname, TAB(40), RSet(Format(T2(15), "####,###,###.00"), 15),
                                TAB(55), RSet(Format(T2(16), "####,###,###.00"), 15),
                                TAB(75), RSet(Format(T2(17), "####,###,###.00"), 15))
		End If
		
        prtobj.EndDoc()
	End Sub
	
	Sub PrtAgePageHeading()
        Dim V As String = " "
        Dim V1 As String = " "
        Dim V2 As String = " "

		'Heading
		Pcnt = Pcnt + 1
        If Not BeginRun Then prtobj.NewPage()
        BeginRun = False
		
        If optByMga.Checked Then
            V = "YTD Aging Totals By MGA"
            V1 = "MGA Name"
            V2 = "Reinsurer Name"
        End If

        If optByRein.Checked Then
            V = "YTD Aging Totals By Rein"
            V1 = "Rein Name"
            V2 = "MGA Name"
        End If

        prtobj.Print(C0str, TAB(95), "Page" & Str(Pcnt))
        prtobj.Print(V)
        prtobj.Print("For Period Ending " & J4str)
        prtobj.Print(Z1str)
        prtobj.Print()
		
        prtobj.Print(V1, TAB(49), "0 to 29", TAB(63), "30 to 90", TAB(77), "91 to 120")
        prtobj.Print(V2, TAB(52), "Days", TAB(67), "Days", TAB(82), "Days")
        prtobj.Print()
		
		L0 = 9
	End Sub
	
	Sub PrtAgeRec()
        Dim wtot As Double = 0
		
        wtot = RA(15) + RA(16) + RA(17)
		If wtot = 0 Then Exit Sub
		
		MgaKey = txRaMgaNmbr
		GetMgaMstRec()
		
		TrtyKey = txRaMgaNmbr & txRaTrtyNmbr
		GetTrtyMstRec()
		GetTrtyMstVar()
		
		ReiKey = txRaReiNmbr
		GetReiMstRec()
		
		If L0 > 50 Then PrtAgePageHeading()
		
		If pc = True Then
            If optByMga.Checked Then Wname = Trim(txMgaName) & " " & txRaMgaNmbr & "-" & txRaTrtyNmbr
            If optByRein.Checked Then Wname = txReiName & " " & txRaReiNmbr
            prtobj.Print(Wname)
            prtobj.Print("----------------------------------------")
			pc = False
			L0 = L0 + 2
		End If
		
        Wname = Mid(txReiName, 1, 25) & " " & txRaReiNmbr & " " & RSet(Format(CDbl(txRaReiPerc), "#00.00"), 6)
        prtobj.Print(Wname, TAB(40), RSet(Format(RA(15), "####,###,###.00"), 15),
                            TAB(55), RSet(Format(RA(16), "####,###,###.00"), 15),
                            TAB(70), RSet(Format(RA(17), "####,###,###.00"), 15))

		L0 = L0 + 1
		
		T(15) = T(15) + RA(15)
		T(16) = T(16) + RA(16)
		T(17) = T(17) + RA(17)
		
	End Sub
	
	Sub PrtAgeSumTotal()
        Dim wtot As Double = 0
        Dim X As Integer

        wtot = T(15) + T(16) + T(17)
		If wtot = 0 Then Exit Sub
		
		MgaKey = txRaMgaNmbr
		GetMgaMstRec()
		
		TrtyKey = txRaMgaNmbr & txRaTrtyNmbr
		GetTrtyMstRec()
		GetTrtyMstVar()
		
		ReiKey = txRaReiNmbr
		GetReiMstRec()
		
		If L0 > 50 Then PrtAgePageHeading()
		
		If optByRein.Checked Then
			If pc = True Then
                If optByRein.Checked Then Wname = txReiName & " " & txRaReiNmbr
                prtobj.Print(Wname)
                prtobj.Print("----------------------------------------")
				pc = False
				L0 = L0 + 2
			End If
		End If
		
		If optByRein.Checked Then
            Wname = Mid(txTrtyDesc, 1, 25) & " " & txRaMgaNmbr & " " & txRaTrtyNmbr & " " & RSet(Format(CDbl(txRaReiPerc), "#00.00"), 6)
		End If
		
		If optByMga.Checked Then
            prtobj.Print()
            Wname = "Treaty Total"
		End If
		
        prtobj.Print(Wname, TAB(40), RSet(Format(T(15), "####,###,###.00"), 15),
                            TAB(55), RSet(Format(T(16), "####,###,###.00"), 15),
                            TAB(70), RSet(Format(T(17), "####,###,###.00"), 15))

		If optByMga.Checked Then
            prtobj.Print()
			L0 = L0 + 3
		Else
			L0 = L0 + 1
		End If
		
		For X = 15 To 17 : T1(X) = T1(X) + T(X) : T(X) = 0 : Next X
		
	End Sub
	
	Sub PrtAgeCompTotal()
        Dim wtot As Double = 0
        Dim X As Integer

        wtot = T1(15) + T1(16) + T1(17)
		If wtot = 0 Then Exit Sub
		
        If optByMga.Checked Then Wname = "MGA Total "
		
		If optByRein.Checked Then
            prtobj.Print()
            Wname = "REIN Total "
		End If
		
        prtobj.Print(Wname, TAB(40), RSet(Format(T1(15), "####,###,###.00"), 15),
                            TAB(55), RSet(Format(T1(16), "####,###,###.00"), 15),
                            TAB(70), RSet(Format(T1(17), "####,###,###.00"), 15))


		For X = 15 To 17 : T2(X) = T2(X) + T1(X) : T1(X) = 0 : Next X
		L0 = L0 + 3
	End Sub
	
	Private Sub ProcessSuppaRein()
		Dim response As Object
		Dim X As Short

		ToFile = False
        response = MsgBox("Create Suppa Text File", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Rein Suppa Info")
		If response = MsgBoxResult.Yes Then ToFile = True
		
		If ToFile Then
			Fname1 = My.Application.Info.DirectoryPath & "\smga.txt"
			FileOpen(1, Fname1, OpenMode.Output)
		Else
			Exit Sub
		End If
		
		'Initialize
		For X = 0 To 17 : T(X) = 0 : T1(X) = 0 : T2(X) = 0 : Next X
		Kstr = "" : Kstr1 = "" : Kstr2 = "" : Kstr3 = "" : Pcnt = 0
		
		'======================================================================================
		'= Option 5 Print or Create Suppa Data
		'======================================================================================
		
		'==================================================================================
		'= Get Reinalloc
		'==================================================================================
		
		If optByMga.Checked Then
			ReinAllocKey = ""
			Call d4tagSelect(f30, d4tag(f30, "K3"))
		End If
		
		If optByRein.Checked Then
			ReinAllocKey = WorkReiNmbr
			Call d4tagSelect(f30, d4tag(f30, "K1"))
		End If
		
		rc = d4top(f30)
		rc = d4seek(f30, ReinAllocKey)
		
		Do Until rc = r4eof
			
			'______________________________________________________________________________
			
			Kstr = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.ReiNmbr))
			
			If Kstr1 = "" Then Kstr1 = Kstr
			
			'Print
			If Kstr <> Kstr1 Then
				WriteSuppaRec()
				Kstr1 = Trim(f4str(RAp.MgaNmbr)) & Trim(f4str(RAp.ReiNmbr))
			End If
			
			'______________________________________________________________________________
			GetReinAllocVar()
			
			'Total
			For X = 1 To 17
				T(X) = T(X) + RA(X)
			Next X
			
nextrec: 
			rc = d4skip(f30, 1)
		Loop 
		WriteSuppaRec()
		FileClose(1)
	End Sub
	
	Sub WriteSuppaRec()
        Dim wtot As Double = 0
        Dim X As Integer

        Dim f0 As String
        Dim f1 As String
        Dim f2 As String
        Dim f3 As String
        Dim f4 As String
        Dim f5 As String
        Dim f6 As String
        Dim f7 As String
        Dim f8 As String
		
        wtot = wtot + T(1) + T(2) + T(13) + T(14) + T(8) + T(9) + T(10) + T(11) + T(4) + T(12)
		If wtot = 0 Then Exit Sub
		
		MgaKey = txRaMgaNmbr
		GetMgaMstRec()
		
		TrtyKey = txRaMgaNmbr & txRaTrtyNmbr
		GetTrtyMstRec()
		GetTrtyMstVar()
		
		ReiKey = txRaReiNmbr
		GetReiMstRec()
		
        f0 = txMgaName
        f1 = txReiName
        f2 = txReiNaic
        f3 = RSet(Format(T(1), "####,###,###.00"), 15)
        f4 = RSet(Format(T(2), "####,###,###.00"), 15)
        f5 = RSet(Format(T(13) + T(14), "####,###,###.00"), 15)
        f6 = RSet(Format(T(8) + T(9) + T(10) + T(11), "####,###,###.00"), 15)
        f7 = RSet(Format(T(4), "####,###,###.00"), 15)
        f8 = RSet(Format(T(12) * -1, "####,###,###.00"), 15)
		
        PrintLine(1, f0 & f1 & f2 & f3 & f4 & f5 & f6 & f7 & f8)
		
		For X = 1 To 14 : T(X) = 0 : Next X
	End Sub
End Class