Option Strict Off
Option Explicit On
Module fileAyItd
	
	'FIELD4 structure pointers -- (AYDIRITD)
	Public Structure PtrAyItd
		Dim AyiMgaNmbr As Integer
		Dim AyiTrtyNmbr As Integer
		Dim AyiPeriod As Integer
		Dim AyiCatCode As Integer
		Dim AyiYear As Integer
		Dim AyiTotal As Integer
		Dim AyiPPbi As Integer
		Dim AyiPPpd As Integer
		Dim AyiPPmed As Integer
		Dim AyiPPumbi As Integer
		Dim AyiPPumpd As Integer
		Dim AyiPPpip As Integer
		Dim AyiPPcomp As Integer
		Dim AyiPPcoll As Integer
		Dim AyiPPrent As Integer
		Dim AyiPPtow As Integer
		Dim AyiCMbi As Integer
		Dim AyiCMpd As Integer
		Dim AyiCMmed As Integer
		Dim AyiCMumbi As Integer
		Dim AyiCMumpd As Integer
		Dim AyiCMpip As Integer
		Dim AyiCMcomp As Integer
		Dim AyiCMcoll As Integer
		Dim AyiCMrent As Integer
		Dim AyiCMtow As Integer
		Dim AyiOTim As Integer
		Dim AyiOTallied As Integer
		Dim AyiOTfire As Integer
		Dim AyiOTmulti As Integer
	End Structure
	Public AIp As PtrAyItd
	
	Public Sub GetAyItdPtr()
		AIp.AyiMgaNmbr = d4field(f22, "MGANMBR")
		AIp.AyiTrtyNmbr = d4field(f22, "TRTYNMBR")
		AIp.AyiPeriod = d4field(f22, "PERIOD")
		AIp.AyiCatCode = d4field(f22, "CATEGORY")
		AIp.AyiYear = d4field(f22, "YEAR")
		AIp.AyiTotal = d4field(f22, "TOTAL")
		AIp.AyiPPbi = d4field(f22, "PPBI")
		AIp.AyiPPpd = d4field(f22, "PPPD")
		AIp.AyiPPmed = d4field(f22, "PPMED")
		AIp.AyiPPumbi = d4field(f22, "PPUMBI")
		AIp.AyiPPumpd = d4field(f22, "PPUMPD")
		AIp.AyiPPpip = d4field(f22, "PPPIP")
		AIp.AyiPPcomp = d4field(f22, "PPCOMP")
		AIp.AyiPPcoll = d4field(f22, "PPCOLL")
		AIp.AyiPPrent = d4field(f22, "PPRENT")
		AIp.AyiPPtow = d4field(f22, "PPTOW")
		AIp.AyiCMbi = d4field(f22, "CMBI")
		AIp.AyiCMpd = d4field(f22, "CMPD")
		AIp.AyiCMmed = d4field(f22, "CMMED")
		AIp.AyiCMumbi = d4field(f22, "CMUMBI")
		AIp.AyiCMumpd = d4field(f22, "CMUMPD")
		AIp.AyiCMpip = d4field(f22, "CMPIP")
		AIp.AyiCMcomp = d4field(f22, "CMCOMP")
		AIp.AyiCMcoll = d4field(f22, "CMCOLL")
		AIp.AyiCMrent = d4field(f22, "CMRENT")
		AIp.AyiCMtow = d4field(f22, "CMTOW")
		AIp.AyiOTim = d4field(f22, "IM")
		AIp.AyiOTallied = d4field(f22, "ALLIED")
		AIp.AyiOTfire = d4field(f22, "FIRE")
		AIp.AyiOTmulti = d4field(f22, "MULTIPERIL")
	End Sub
	
	Public Sub GetAyItdVar()
		txRptMgaNmbr = Trim(f4str(AIp.AyiMgaNmbr))
		txRptTrtyNmbr = Trim(f4str(AIp.AyiTrtyNmbr))
		txRptPeriod = Trim(f4str(AIp.AyiPeriod))
		txRptCatCode = Trim(f4str(AIp.AyiCatCode))
		txRptYear = Trim(f4str(AIp.AyiYear))
		
		MLobt = f4double(AIp.AyiTotal)
		MLobp(1) = f4double(AIp.AyiPPbi)
		MLobp(2) = f4double(AIp.AyiPPpd)
		MLobp(3) = f4double(AIp.AyiPPmed)
		MLobp(4) = f4double(AIp.AyiPPumbi)
		MLobp(5) = f4double(AIp.AyiPPumpd)
		MLobp(6) = f4double(AIp.AyiPPpip)
		MLobp(7) = f4double(AIp.AyiPPcomp)
		MLobp(8) = f4double(AIp.AyiPPcoll)
		MLobp(9) = f4double(AIp.AyiPPrent)
		MLobp(10) = f4double(AIp.AyiPPtow)
		MLobp(11) = f4double(AIp.AyiCMbi)
		MLobp(12) = f4double(AIp.AyiCMpd)
		MLobp(13) = f4double(AIp.AyiCMmed)
		MLobp(14) = f4double(AIp.AyiCMumbi)
		MLobp(15) = f4double(AIp.AyiCMumpd)
		MLobp(16) = f4double(AIp.AyiCMpip)
		MLobp(17) = f4double(AIp.AyiCMcomp)
		MLobp(18) = f4double(AIp.AyiCMcoll)
		MLobp(19) = f4double(AIp.AyiCMrent)
		MLobp(20) = f4double(AIp.AyiCMtow)
		MLobp(21) = f4double(AIp.AyiOTim)
		MLobp(22) = f4double(AIp.AyiOTallied)
		MLobp(23) = f4double(AIp.AyiOTfire)
		MLobp(24) = f4double(AIp.AyiOTmulti)
	End Sub
	
	Public Sub UpAyItdFlds()
		Call f4assign(AIp.AyiMgaNmbr, txRptMgaNmbr)
		Call f4assign(AIp.AyiTrtyNmbr, txRptTrtyNmbr)
		Call f4assign(AIp.AyiPeriod, txRptPeriod)
		Call f4assign(AIp.AyiCatCode, txRptCatCode)
		Call f4assign(AIp.AyiYear, txRptYear)
		Call f4assignDouble(AIp.AyiTotal, MLobt)
		Call f4assignDouble(AIp.AyiPPbi, MLobp(1))
		Call f4assignDouble(AIp.AyiPPpd, MLobp(2))
		Call f4assignDouble(AIp.AyiPPmed, MLobp(3))
		Call f4assignDouble(AIp.AyiPPumbi, MLobp(4))
		Call f4assignDouble(AIp.AyiPPumpd, MLobp(5))
		Call f4assignDouble(AIp.AyiPPpip, MLobp(6))
		Call f4assignDouble(AIp.AyiPPcomp, MLobp(7))
		Call f4assignDouble(AIp.AyiPPcoll, MLobp(8))
		Call f4assignDouble(AIp.AyiPPrent, MLobp(9))
		Call f4assignDouble(AIp.AyiPPtow, MLobp(10))
		Call f4assignDouble(AIp.AyiCMbi, MLobp(11))
		Call f4assignDouble(AIp.AyiCMpd, MLobp(12))
		Call f4assignDouble(AIp.AyiCMmed, MLobp(13))
		Call f4assignDouble(AIp.AyiCMumbi, MLobp(14))
		Call f4assignDouble(AIp.AyiCMumpd, MLobp(15))
		Call f4assignDouble(AIp.AyiCMpip, MLobp(16))
		Call f4assignDouble(AIp.AyiCMcomp, MLobp(17))
		Call f4assignDouble(AIp.AyiCMcoll, MLobp(18))
		Call f4assignDouble(AIp.AyiCMrent, MLobp(19))
		Call f4assignDouble(AIp.AyiCMtow, MLobp(20))
		Call f4assignDouble(AIp.AyiOTim, MLobp(21))
		Call f4assignDouble(AIp.AyiOTallied, MLobp(22))
		Call f4assignDouble(AIp.AyiOTfire, MLobp(23))
		Call f4assignDouble(AIp.AyiOTmulti, MLobp(24))
	End Sub
	
	Public Sub AddAyItdRec()
		If Not ValUser Then Exit Sub
		AddTran = True
		
		If d4appendStart(f22, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpAyItdFlds()
		rc = d4append(f22)
		rc = d4unlock(f22)
	End Sub
	
	Public Sub UpAyItdRec()
		If Not ValUser Then Exit Sub
		UpAyDirFlds()
		rc = d4unlock(f22)
	End Sub
	
	Public Sub GetAyItdRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f22, d4tag(f22, "K1"))
		rc = d4seek(f22, RptDirKey)
		
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f22, d4recNo(f22))
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
	
	Sub DelAyItdRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f22)
		Call d4blank(f22)
	End Sub
End Module