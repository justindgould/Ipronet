Option Strict Off
Option Explicit On
Module fileIbnrCed
	
	'FIELD4 structure pointers -- (IBNRCED1)
	Public Structure PtrIbnrCed
		Dim IbcMgaNmbr As Integer
		Dim IbcTrtyNmbr As Integer
		Dim IbcPeriod As Integer
		Dim IbcCatCode As Integer
		Dim IbcYear As Integer
		Dim IbcTotal As Integer
		Dim IbcPPbi As Integer
		Dim IbcPPpd As Integer
		Dim IbcPPmed As Integer
		Dim IbcPPumbi As Integer
		Dim IbcPPumpd As Integer
		Dim IbcPPpip As Integer
		Dim IbcPPcomp As Integer
		Dim IbcPPcoll As Integer
		Dim IbcPPrent As Integer
		Dim IbcPPtow As Integer
		Dim IbcCMbi As Integer
		Dim IbcCMpd As Integer
		Dim IbcCMmed As Integer
		Dim IbcCMumbi As Integer
		Dim IbcCMumpd As Integer
		Dim IbcCMpip As Integer
		Dim IbcCMcomp As Integer
		Dim IbcCMcoll As Integer
		Dim IbcCMrent As Integer
		Dim IbcCMtow As Integer
		Dim IbcOTim As Integer
		Dim IbcOTallied As Integer
		Dim IbcOTfire As Integer
		Dim IbcOTmulti As Integer
	End Structure
	Public ICp As PtrIbnrCed
	
	Public Sub GetIbnrCedPtr()
		ICp.IbcMgaNmbr = d4field(f23, "MGANMBR")
		ICp.IbcTrtyNmbr = d4field(f23, "TRTYNMBR")
		ICp.IbcPeriod = d4field(f23, "PERIOD")
		ICp.IbcCatCode = d4field(f23, "CATEGORY")
		ICp.IbcYear = d4field(f23, "YEAR")
		ICp.IbcTotal = d4field(f23, "TOTAL")
		ICp.IbcPPbi = d4field(f23, "PPBI")
		ICp.IbcPPpd = d4field(f23, "PPPD")
		ICp.IbcPPmed = d4field(f23, "PPMED")
		ICp.IbcPPumbi = d4field(f23, "PPUMBI")
		ICp.IbcPPumpd = d4field(f23, "PPUMPD")
		ICp.IbcPPpip = d4field(f23, "PPPIP")
		ICp.IbcPPcomp = d4field(f23, "PPCOMP")
		ICp.IbcPPcoll = d4field(f23, "PPCOLL")
		ICp.IbcPPrent = d4field(f23, "PPRENT")
		ICp.IbcPPtow = d4field(f23, "PPTOW")
		ICp.IbcCMbi = d4field(f23, "CMBI")
		ICp.IbcCMpd = d4field(f23, "CMPD")
		ICp.IbcCMmed = d4field(f23, "CMMED")
		ICp.IbcCMumbi = d4field(f23, "CMUMBI")
		ICp.IbcCMumpd = d4field(f23, "CMUMPD")
		ICp.IbcCMpip = d4field(f23, "CMPIP")
		ICp.IbcCMcomp = d4field(f23, "CMCOMP")
		ICp.IbcCMcoll = d4field(f23, "CMCOLL")
		ICp.IbcCMrent = d4field(f23, "CMRENT")
		ICp.IbcCMtow = d4field(f23, "CMTOW")
		ICp.IbcOTim = d4field(f23, "IM")
		ICp.IbcOTallied = d4field(f23, "ALLIED")
		ICp.IbcOTfire = d4field(f23, "FIRE")
		ICp.IbcOTmulti = d4field(f23, "MULTIPERIL")
	End Sub
	
	Public Sub GetIbnrCedVar()
		txRptMgaNmbr = Trim(f4str(ICp.IbcMgaNmbr))
		txRptTrtyNmbr = Trim(f4str(ICp.IbcTrtyNmbr))
		txRptPeriod = Trim(f4str(ICp.IbcPeriod))
		txRptCatCode = Trim(f4str(ICp.IbcCatCode))
		txRptYear = Trim(f4str(ICp.IbcYear))
		
		MLobt = f4double(ICp.IbcTotal)
		MLobp(1) = f4double(ICp.IbcPPbi)
		MLobp(2) = f4double(ICp.IbcPPpd)
		MLobp(3) = f4double(ICp.IbcPPmed)
		MLobp(4) = f4double(ICp.IbcPPumbi)
		MLobp(5) = f4double(ICp.IbcPPumpd)
		MLobp(6) = f4double(ICp.IbcPPpip)
		MLobp(7) = f4double(ICp.IbcPPcomp)
		MLobp(8) = f4double(ICp.IbcPPcoll)
		MLobp(9) = f4double(ICp.IbcPPrent)
		MLobp(10) = f4double(ICp.IbcPPtow)
		MLobp(11) = f4double(ICp.IbcCMbi)
		MLobp(12) = f4double(ICp.IbcCMpd)
		MLobp(13) = f4double(ICp.IbcCMmed)
		MLobp(14) = f4double(ICp.IbcCMumbi)
		MLobp(15) = f4double(ICp.IbcCMumpd)
		MLobp(16) = f4double(ICp.IbcCMpip)
		MLobp(17) = f4double(ICp.IbcCMcomp)
		MLobp(18) = f4double(ICp.IbcCMcoll)
		MLobp(19) = f4double(ICp.IbcCMrent)
		MLobp(20) = f4double(ICp.IbcCMtow)
		MLobp(21) = f4double(ICp.IbcOTim)
		MLobp(22) = f4double(ICp.IbcOTallied)
		MLobp(23) = f4double(ICp.IbcOTfire)
		MLobp(24) = f4double(ICp.IbcOTmulti)
	End Sub
	
	Public Sub UpIbnrCedFlds()
		Call f4assign(ICp.IbcMgaNmbr, txRptMgaNmbr)
		Call f4assign(ICp.IbcTrtyNmbr, txRptTrtyNmbr)
		Call f4assign(ICp.IbcPeriod, txRptPeriod)
		Call f4assign(ICp.IbcCatCode, txRptCatCode)
		Call f4assign(ICp.IbcYear, txRptYear)
		Call f4assignDouble(ICp.IbcTotal, MLobt)
		Call f4assignDouble(ICp.IbcPPbi, MLobp(1))
		Call f4assignDouble(ICp.IbcPPpd, MLobp(2))
		Call f4assignDouble(ICp.IbcPPmed, MLobp(3))
		Call f4assignDouble(ICp.IbcPPumbi, MLobp(4))
		Call f4assignDouble(ICp.IbcPPumpd, MLobp(5))
		Call f4assignDouble(ICp.IbcPPpip, MLobp(6))
		Call f4assignDouble(ICp.IbcPPcomp, MLobp(7))
		Call f4assignDouble(ICp.IbcPPcoll, MLobp(8))
		Call f4assignDouble(ICp.IbcPPrent, MLobp(9))
		Call f4assignDouble(ICp.IbcPPtow, MLobp(10))
		Call f4assignDouble(ICp.IbcCMbi, MLobp(11))
		Call f4assignDouble(ICp.IbcCMpd, MLobp(12))
		Call f4assignDouble(ICp.IbcCMmed, MLobp(13))
		Call f4assignDouble(ICp.IbcCMumbi, MLobp(14))
		Call f4assignDouble(ICp.IbcCMumpd, MLobp(15))
		Call f4assignDouble(ICp.IbcCMpip, MLobp(16))
		Call f4assignDouble(ICp.IbcCMcomp, MLobp(17))
		Call f4assignDouble(ICp.IbcCMcoll, MLobp(18))
		Call f4assignDouble(ICp.IbcCMrent, MLobp(19))
		Call f4assignDouble(ICp.IbcCMtow, MLobp(20))
		Call f4assignDouble(ICp.IbcOTim, MLobp(21))
		Call f4assignDouble(ICp.IbcOTallied, MLobp(22))
		Call f4assignDouble(ICp.IbcOTfire, MLobp(23))
		Call f4assignDouble(ICp.IbcOTmulti, MLobp(24))
	End Sub
	
	Public Sub AddIbnrCedRec()
		If Not ValUser Then Exit Sub
		AddTran = True
		
		If d4appendStart(f23, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpAyDirFlds()
		rc = d4append(f23)
		rc = d4unlock(f23)
	End Sub
	
	Public Sub UpIbnrCedRec()
		If Not ValUser Then Exit Sub
		UpIbnrCedFlds()
		rc = d4unlock(f23)
	End Sub
	
	Public Sub GetIbnrCedRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f23, d4tag(f23, "K1"))
		rc = d4seek(f23, RptDirKey)
		
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f23, d4recNo(f23))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetAyDirVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelIbnrCedRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f23)
		Call d4blank(f23)
	End Sub
End Module