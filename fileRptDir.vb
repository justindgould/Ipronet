Option Strict Off
Option Explicit On
Module fileRptDir
	
	'Form RPT Dir Rpt Work Vars
	Public txRptMgaNmbr As String
	Public txRptTrtyNmbr As String
	Public txRptPeriod As String
	Public txRptCatCode As String
	Public txRptYear As String
	
	'FIELD4 structure pointers -- (RptDir)
	Public Structure PtrRptDir
		Dim RptMgaNmbr As Integer
		Dim RptTrtyNmbr As Integer
		Dim RptPeriod As Integer
		Dim RptCatCode As Integer
		Dim RptYear As Integer
		Dim RptTotal As Integer
		Dim RptPPbi As Integer
		Dim RptPPpd As Integer
		Dim RptPPmed As Integer
		Dim RptPPumbi As Integer
		Dim RptPPumpd As Integer
		Dim RptPPpip As Integer
		Dim RptPPcomp As Integer
		Dim RptPPcoll As Integer
		Dim RptPPrent As Integer
		Dim RptPPtow As Integer
		Dim RptCMbi As Integer
		Dim RptCMpd As Integer
		Dim RptCMmed As Integer
		Dim RptCMumbi As Integer
		Dim RptCMumpd As Integer
		Dim RptCMpip As Integer
		Dim RptCMcomp As Integer
		Dim RptCMcoll As Integer
		Dim RptCMrent As Integer
		Dim RptCMtow As Integer
		Dim RptOTim As Integer
		Dim RptOTallied As Integer
		Dim RptOTfire As Integer
		Dim RptOTmulti As Integer
	End Structure
	Public RDp As PtrRptDir
	
	Public Sub GetRptDirPtr()
		RDp.RptMgaNmbr = d4field(f5, "MGANMBR")
		RDp.RptTrtyNmbr = d4field(f5, "TRTYNMBR")
		RDp.RptPeriod = d4field(f5, "PERIOD")
		RDp.RptCatCode = d4field(f5, "CATEGORY")
		RDp.RptYear = d4field(f5, "YEAR")
		RDp.RptTotal = d4field(f5, "TOTAL")
		RDp.RptPPbi = d4field(f5, "PPBI")
		RDp.RptPPpd = d4field(f5, "PPPD")
		RDp.RptPPmed = d4field(f5, "PPMED")
		RDp.RptPPumbi = d4field(f5, "PPUMBI")
		RDp.RptPPumpd = d4field(f5, "PPUMPD")
		RDp.RptPPpip = d4field(f5, "PPPIP")
		RDp.RptPPcomp = d4field(f5, "PPCOMP")
		RDp.RptPPcoll = d4field(f5, "PPCOLL")
		RDp.RptPPrent = d4field(f5, "PPRENT")
		RDp.RptPPtow = d4field(f5, "PPTOW")
		RDp.RptCMbi = d4field(f5, "CMBI")
		RDp.RptCMpd = d4field(f5, "CMPD")
		RDp.RptCMmed = d4field(f5, "CMMED")
		RDp.RptCMumbi = d4field(f5, "CMUMBI")
		RDp.RptCMumpd = d4field(f5, "CMUMPD")
		RDp.RptCMpip = d4field(f5, "CMPIP")
		RDp.RptCMcomp = d4field(f5, "CMCOMP")
		RDp.RptCMcoll = d4field(f5, "CMCOLL")
		RDp.RptCMrent = d4field(f5, "CMRENT")
		RDp.RptCMtow = d4field(f5, "CMTOW")
		RDp.RptOTim = d4field(f5, "IM")
		RDp.RptOTallied = d4field(f5, "ALLIED")
		RDp.RptOTfire = d4field(f5, "FIRE")
		RDp.RptOTmulti = d4field(f5, "MULTIPERIL")
	End Sub
	
	Public Sub GetRptDirVar()
		txRptMgaNmbr = Trim(f4str(RDp.RptMgaNmbr))
		txRptTrtyNmbr = Trim(f4str(RDp.RptTrtyNmbr))
		txRptPeriod = Trim(f4str(RDp.RptPeriod))
		txRptCatCode = Trim(f4str(RDp.RptCatCode))
		txRptYear = Trim(f4str(RDp.RptYear))
		
		MLobt = f4double(RDp.RptTotal)
		MLobp(1) = f4double(RDp.RptPPbi)
		MLobp(2) = f4double(RDp.RptPPpd)
		MLobp(3) = f4double(RDp.RptPPmed)
		MLobp(4) = f4double(RDp.RptPPumbi)
		MLobp(5) = f4double(RDp.RptPPumpd)
		MLobp(6) = f4double(RDp.RptPPpip)
		MLobp(7) = f4double(RDp.RptPPcomp)
		MLobp(8) = f4double(RDp.RptPPcoll)
		MLobp(9) = f4double(RDp.RptPPrent)
		MLobp(10) = f4double(RDp.RptPPtow)
		MLobp(11) = f4double(RDp.RptCMbi)
		MLobp(12) = f4double(RDp.RptCMpd)
		MLobp(13) = f4double(RDp.RptCMmed)
		MLobp(14) = f4double(RDp.RptCMumbi)
		MLobp(15) = f4double(RDp.RptCMumpd)
		MLobp(16) = f4double(RDp.RptCMpip)
		MLobp(17) = f4double(RDp.RptCMcomp)
		MLobp(18) = f4double(RDp.RptCMcoll)
		MLobp(19) = f4double(RDp.RptCMrent)
		MLobp(20) = f4double(RDp.RptCMtow)
		MLobp(21) = f4double(RDp.RptOTim)
		MLobp(22) = f4double(RDp.RptOTallied)
		MLobp(23) = f4double(RDp.RptOTfire)
		MLobp(24) = f4double(RDp.RptOTmulti)
	End Sub
	
	Public Sub UpRptDirFlds()
		Call f4assign(RDp.RptMgaNmbr, txRptMgaNmbr)
		Call f4assign(RDp.RptTrtyNmbr, txRptTrtyNmbr)
		Call f4assign(RDp.RptPeriod, txRptPeriod)
		Call f4assign(RDp.RptCatCode, txRptCatCode)
		Call f4assign(RDp.RptYear, txRptYear)
		Call f4assignDouble(RDp.RptTotal, MLobt)
		Call f4assignDouble(RDp.RptPPbi, MLobp(1))
		Call f4assignDouble(RDp.RptPPpd, MLobp(2))
		Call f4assignDouble(RDp.RptPPmed, MLobp(3))
		Call f4assignDouble(RDp.RptPPumbi, MLobp(4))
		Call f4assignDouble(RDp.RptPPumpd, MLobp(5))
		Call f4assignDouble(RDp.RptPPpip, MLobp(6))
		Call f4assignDouble(RDp.RptPPcomp, MLobp(7))
		Call f4assignDouble(RDp.RptPPcoll, MLobp(8))
		Call f4assignDouble(RDp.RptPPrent, MLobp(9))
		Call f4assignDouble(RDp.RptPPtow, MLobp(10))
		Call f4assignDouble(RDp.RptCMbi, MLobp(11))
		Call f4assignDouble(RDp.RptCMpd, MLobp(12))
		Call f4assignDouble(RDp.RptCMmed, MLobp(13))
		Call f4assignDouble(RDp.RptCMumbi, MLobp(14))
		Call f4assignDouble(RDp.RptCMumpd, MLobp(15))
		Call f4assignDouble(RDp.RptCMpip, MLobp(16))
		Call f4assignDouble(RDp.RptCMcomp, MLobp(17))
		Call f4assignDouble(RDp.RptCMcoll, MLobp(18))
		Call f4assignDouble(RDp.RptCMrent, MLobp(19))
		Call f4assignDouble(RDp.RptCMtow, MLobp(20))
		Call f4assignDouble(RDp.RptOTim, MLobp(21))
		Call f4assignDouble(RDp.RptOTallied, MLobp(22))
		Call f4assignDouble(RDp.RptOTfire, MLobp(23))
		Call f4assignDouble(RDp.RptOTmulti, MLobp(24))
	End Sub
	
	Public Sub AddRptDirRec()
		AddTran = True
		
		If d4appendStart(f5, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpRptDirFlds()
		rc = d4append(f5)
		rc = d4unlock(f5)
	End Sub
	
	Public Sub UpRptDirRec()
		UpRptDirFlds()
		rc = d4unlock(f5)
	End Sub
	
	Public Sub GetRptDirRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f5, d4tag(f5, "K1"))
		rc = d4seek(f5, RptDirKey)
		
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f5, d4recNo(f5))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetRptDirVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelRptDirRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f5)
		Call d4blank(f5)
	End Sub
End Module