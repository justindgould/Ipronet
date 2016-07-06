Option Strict Off
Option Explicit On
Module fileIbnrDir
	
	'FIELD4 structure pointers -- (IBNRDIR)
	Public Structure PtrIbnrDir
		Dim IbdMgaNmbr As Integer
		Dim IbdTrtyNmbr As Integer
		Dim IbdPeriod As Integer
		Dim IbdCatCode As Integer
		Dim IbdYear As Integer
		Dim IbdTotal As Integer
		Dim IbdPPbi As Integer
		Dim IbdPPpd As Integer
		Dim IbdPPmed As Integer
		Dim IbdPPumbi As Integer
		Dim IbdPPumpd As Integer
		Dim IbdPPpip As Integer
		Dim IbdPPcomp As Integer
		Dim IbdPPcoll As Integer
		Dim IbdPPrent As Integer
		Dim IbdPPtow As Integer
		Dim IbdCMbi As Integer
		Dim IbdCMpd As Integer
		Dim IbdCMmed As Integer
		Dim IbdCMumbi As Integer
		Dim IbdCMumpd As Integer
		Dim IbdCMpip As Integer
		Dim IbdCMcomp As Integer
		Dim IbdCMcoll As Integer
		Dim IbdCMrent As Integer
		Dim IbdCMtow As Integer
		Dim IbdOTim As Integer
		Dim IbdOTallied As Integer
		Dim IbdOTfire As Integer
		Dim IbdOTmulti As Integer
	End Structure
	Public IBp As PtrIbnrDir
	
	Public Sub GetIbnrDirPtr()
		IBp.IbdMgaNmbr = d4field(f24, "MGANMBR")
		IBp.IbdTrtyNmbr = d4field(f24, "TRTYNMBR")
		IBp.IbdPeriod = d4field(f24, "PERIOD")
		IBp.IbdCatCode = d4field(f24, "CATEGORY")
		IBp.IbdYear = d4field(f24, "YEAR")
		IBp.IbdTotal = d4field(f24, "TOTAL")
		IBp.IbdPPbi = d4field(f24, "PPBI")
		IBp.IbdPPpd = d4field(f24, "PPPD")
		IBp.IbdPPmed = d4field(f24, "PPMED")
		IBp.IbdPPumbi = d4field(f24, "PPUMBI")
		IBp.IbdPPumpd = d4field(f24, "PPUMPD")
		IBp.IbdPPpip = d4field(f24, "PPPIP")
		IBp.IbdPPcomp = d4field(f24, "PPCOMP")
		IBp.IbdPPcoll = d4field(f24, "PPCOLL")
		IBp.IbdPPrent = d4field(f24, "PPRENT")
		IBp.IbdPPtow = d4field(f24, "PPTOW")
		IBp.IbdCMbi = d4field(f24, "CMBI")
		IBp.IbdCMpd = d4field(f24, "CMPD")
		IBp.IbdCMmed = d4field(f24, "CMMED")
		IBp.IbdCMumbi = d4field(f24, "CMUMBI")
		IBp.IbdCMumpd = d4field(f24, "CMUMPD")
		IBp.IbdCMpip = d4field(f24, "CMPIP")
		IBp.IbdCMcomp = d4field(f24, "CMCOMP")
		IBp.IbdCMcoll = d4field(f24, "CMCOLL")
		IBp.IbdCMrent = d4field(f24, "CMRENT")
		IBp.IbdCMtow = d4field(f24, "CMTOW")
		IBp.IbdOTim = d4field(f24, "IM")
		IBp.IbdOTallied = d4field(f24, "ALLIED")
		IBp.IbdOTfire = d4field(f24, "FIRE")
		IBp.IbdOTmulti = d4field(f24, "MULTIPERIL")
	End Sub
	
	Public Sub GetIbnrDirVar()
		txRptMgaNmbr = Trim(f4str(IBp.IbdMgaNmbr))
		txRptTrtyNmbr = Trim(f4str(IBp.IbdTrtyNmbr))
		txRptPeriod = Trim(f4str(IBp.IbdPeriod))
		txRptCatCode = Trim(f4str(IBp.IbdCatCode))
		txRptYear = Trim(f4str(IBp.IbdYear))
		
		MLobt = f4double(IBp.IbdTotal)
		MLobp(1) = f4double(IBp.IbdPPbi)
		MLobp(2) = f4double(IBp.IbdPPpd)
		MLobp(3) = f4double(IBp.IbdPPmed)
		MLobp(4) = f4double(IBp.IbdPPumbi)
		MLobp(5) = f4double(IBp.IbdPPumpd)
		MLobp(6) = f4double(IBp.IbdPPpip)
		MLobp(7) = f4double(IBp.IbdPPcomp)
		MLobp(8) = f4double(IBp.IbdPPcoll)
		MLobp(9) = f4double(IBp.IbdPPrent)
		MLobp(10) = f4double(IBp.IbdPPtow)
		MLobp(11) = f4double(IBp.IbdCMbi)
		MLobp(12) = f4double(IBp.IbdCMpd)
		MLobp(13) = f4double(IBp.IbdCMmed)
		MLobp(14) = f4double(IBp.IbdCMumbi)
		MLobp(15) = f4double(IBp.IbdCMumpd)
		MLobp(16) = f4double(IBp.IbdCMpip)
		MLobp(17) = f4double(IBp.IbdCMcomp)
		MLobp(18) = f4double(IBp.IbdCMcoll)
		MLobp(19) = f4double(IBp.IbdCMrent)
		MLobp(20) = f4double(IBp.IbdCMtow)
		MLobp(21) = f4double(IBp.IbdOTim)
		MLobp(22) = f4double(IBp.IbdOTallied)
		MLobp(23) = f4double(IBp.IbdOTfire)
		MLobp(24) = f4double(IBp.IbdOTmulti)
	End Sub
	
	Public Sub UpIbnrDirFlds()
		Call f4assign(IBp.IbdMgaNmbr, txRptMgaNmbr)
		Call f4assign(IBp.IbdTrtyNmbr, txRptTrtyNmbr)
		Call f4assign(IBp.IbdPeriod, txRptPeriod)
		Call f4assign(IBp.IbdCatCode, txRptCatCode)
		Call f4assign(IBp.IbdYear, txRptYear)
		Call f4assignDouble(IBp.IbdTotal, MLobt)
		Call f4assignDouble(IBp.IbdPPbi, MLobp(1))
		Call f4assignDouble(IBp.IbdPPpd, MLobp(2))
		Call f4assignDouble(IBp.IbdPPmed, MLobp(3))
		Call f4assignDouble(IBp.IbdPPumbi, MLobp(4))
		Call f4assignDouble(IBp.IbdPPumpd, MLobp(5))
		Call f4assignDouble(IBp.IbdPPpip, MLobp(6))
		Call f4assignDouble(IBp.IbdPPcomp, MLobp(7))
		Call f4assignDouble(IBp.IbdPPcoll, MLobp(8))
		Call f4assignDouble(IBp.IbdPPrent, MLobp(9))
		Call f4assignDouble(IBp.IbdPPtow, MLobp(10))
		Call f4assignDouble(IBp.IbdCMbi, MLobp(11))
		Call f4assignDouble(IBp.IbdCMpd, MLobp(12))
		Call f4assignDouble(IBp.IbdCMmed, MLobp(13))
		Call f4assignDouble(IBp.IbdCMumbi, MLobp(14))
		Call f4assignDouble(IBp.IbdCMumpd, MLobp(15))
		Call f4assignDouble(IBp.IbdCMpip, MLobp(16))
		Call f4assignDouble(IBp.IbdCMcomp, MLobp(17))
		Call f4assignDouble(IBp.IbdCMcoll, MLobp(18))
		Call f4assignDouble(IBp.IbdCMrent, MLobp(19))
		Call f4assignDouble(IBp.IbdCMtow, MLobp(20))
		Call f4assignDouble(IBp.IbdOTim, MLobp(21))
		Call f4assignDouble(IBp.IbdOTallied, MLobp(22))
		Call f4assignDouble(IBp.IbdOTfire, MLobp(23))
		Call f4assignDouble(IBp.IbdOTmulti, MLobp(24))
	End Sub
	
	Public Sub AddIbnrDirRec()
		If Not ValUser Then Exit Sub
		AddTran = True
		
		If d4appendStart(f24, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpAyDirFlds()
		rc = d4append(f24)
		rc = d4unlock(f24)
	End Sub
	
	Public Sub UpIbnrDirRec()
		If Not ValUser Then Exit Sub
		UpIbnrCedFlds()
		rc = d4unlock(f24)
	End Sub
	
	Public Sub GetIbnrDirRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f24, d4tag(f24, "K1"))
		rc = d4seek(f24, RptDirKey)
		
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f24, d4recNo(f24))
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
	
	Sub DelIbnrDirRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f24)
		Call d4blank(f24)
	End Sub
End Module