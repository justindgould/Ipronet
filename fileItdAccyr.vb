Option Strict Off
Option Explicit On
Module fileItdAccyr
	
	'FIELD4 structure pointers -- (ITDACCYR)
	Public Structure PtrItdAccyr
		Dim IayMgaNmbr As Integer
		Dim IayTrtyNmbr As Integer
		Dim IayPeriod As Integer
		Dim IayCatCode As Integer
		Dim IayYear As Integer
		Dim IayTotal As Integer
		Dim IayPPbi As Integer
		Dim IayPPpd As Integer
		Dim IayPPmed As Integer
		Dim IayPPumbi As Integer
		Dim IayPPumpd As Integer
		Dim IayPPpip As Integer
		Dim IayPPcomp As Integer
		Dim IayPPcoll As Integer
		Dim IayPPrent As Integer
		Dim IayPPtow As Integer
		Dim IayCMbi As Integer
		Dim IayCMpd As Integer
		Dim IayCMmed As Integer
		Dim IayCMumbi As Integer
		Dim IayCMumpd As Integer
		Dim IayCMpip As Integer
		Dim IayCMcomp As Integer
		Dim IayCMcoll As Integer
		Dim IayCMrent As Integer
		Dim IayCMtow As Integer
		Dim IayOTim As Integer
		Dim IayOTallied As Integer
		Dim IayOTfire As Integer
		Dim IayOTmulti As Integer
	End Structure
	Public IAp As PtrItdAccyr
	
	Public Sub GetItdAccyrPtr()
		IAp.IayMgaNmbr = d4field(f26, "MGANMBR")
		IAp.IayTrtyNmbr = d4field(f26, "TRTYNMBR")
		IAp.IayPeriod = d4field(f26, "PERIOD")
		IAp.IayCatCode = d4field(f26, "CATEGORY")
		IAp.IayYear = d4field(f26, "YEAR")
		IAp.IayTotal = d4field(f26, "TOTAL")
		IAp.IayPPbi = d4field(f26, "PPBI")
		IAp.IayPPpd = d4field(f26, "PPPD")
		IAp.IayPPmed = d4field(f26, "PPMED")
		IAp.IayPPumbi = d4field(f26, "PPUMBI")
		IAp.IayPPumpd = d4field(f26, "PPUMPD")
		IAp.IayPPpip = d4field(f26, "PPPIP")
		IAp.IayPPcomp = d4field(f26, "PPCOMP")
		IAp.IayPPcoll = d4field(f26, "PPCOLL")
		IAp.IayPPrent = d4field(f26, "PPRENT")
		IAp.IayPPtow = d4field(f26, "PPTOW")
		IAp.IayCMbi = d4field(f26, "CMBI")
		IAp.IayCMpd = d4field(f26, "CMPD")
		IAp.IayCMmed = d4field(f26, "CMMED")
		IAp.IayCMumbi = d4field(f26, "CMUMBI")
		IAp.IayCMumpd = d4field(f26, "CMUMPD")
		IAp.IayCMpip = d4field(f26, "CMPIP")
		IAp.IayCMcomp = d4field(f26, "CMCOMP")
		IAp.IayCMcoll = d4field(f26, "CMCOLL")
		IAp.IayCMrent = d4field(f26, "CMRENT")
		IAp.IayCMtow = d4field(f26, "CMTOW")
		IAp.IayOTim = d4field(f26, "IM")
		IAp.IayOTallied = d4field(f26, "ALLIED")
		IAp.IayOTfire = d4field(f26, "FIRE")
		IAp.IayOTmulti = d4field(f26, "MULTIPERIL")
	End Sub
	
	Public Sub GetItdAccyrVar()
		txRptMgaNmbr = Trim(f4str(IAp.IayMgaNmbr))
		txRptTrtyNmbr = Trim(f4str(IAp.IayTrtyNmbr))
		txRptPeriod = Trim(f4str(IAp.IayPeriod))
		txRptCatCode = Trim(f4str(IAp.IayCatCode))
		txRptYear = Trim(f4str(IAp.IayYear))
		
		MLobt = f4double(IAp.IayTotal)
		MLobp(1) = f4double(IAp.IayPPbi)
		MLobp(2) = f4double(IAp.IayPPpd)
		MLobp(3) = f4double(IAp.IayPPmed)
		MLobp(4) = f4double(IAp.IayPPumbi)
		MLobp(5) = f4double(IAp.IayPPumpd)
		MLobp(6) = f4double(IAp.IayPPpip)
		MLobp(7) = f4double(IAp.IayPPcomp)
		MLobp(8) = f4double(IAp.IayPPcoll)
		MLobp(9) = f4double(IAp.IayPPrent)
		MLobp(10) = f4double(IAp.IayPPtow)
		MLobp(11) = f4double(IAp.IayCMbi)
		MLobp(12) = f4double(IAp.IayCMpd)
		MLobp(13) = f4double(IAp.IayCMmed)
		MLobp(14) = f4double(IAp.IayCMumbi)
		MLobp(15) = f4double(IAp.IayCMumpd)
		MLobp(16) = f4double(IAp.IayCMpip)
		MLobp(17) = f4double(IAp.IayCMcomp)
		MLobp(18) = f4double(IAp.IayCMcoll)
		MLobp(19) = f4double(IAp.IayCMrent)
		MLobp(20) = f4double(IAp.IayCMtow)
		MLobp(21) = f4double(IAp.IayOTim)
		MLobp(22) = f4double(IAp.IayOTallied)
		MLobp(23) = f4double(IAp.IayOTfire)
		MLobp(24) = f4double(IAp.IayOTmulti)
	End Sub
	
	Public Sub UpItdAccyrFlds()
		Call f4assign(IAp.IayMgaNmbr, txRptMgaNmbr)
		Call f4assign(IAp.IayTrtyNmbr, txRptTrtyNmbr)
		Call f4assign(IAp.IayPeriod, txRptPeriod)
		Call f4assign(IAp.IayCatCode, txRptCatCode)
		Call f4assign(IAp.IayYear, txRptYear)
		Call f4assignDouble(IAp.IayTotal, MLobt)
		Call f4assignDouble(IAp.IayPPbi, MLobp(1))
		Call f4assignDouble(IAp.IayPPpd, MLobp(2))
		Call f4assignDouble(IAp.IayPPmed, MLobp(3))
		Call f4assignDouble(IAp.IayPPumbi, MLobp(4))
		Call f4assignDouble(IAp.IayPPumpd, MLobp(5))
		Call f4assignDouble(IAp.IayPPpip, MLobp(6))
		Call f4assignDouble(IAp.IayPPcomp, MLobp(7))
		Call f4assignDouble(IAp.IayPPcoll, MLobp(8))
		Call f4assignDouble(IAp.IayPPrent, MLobp(9))
		Call f4assignDouble(IAp.IayPPtow, MLobp(10))
		Call f4assignDouble(IAp.IayCMbi, MLobp(11))
		Call f4assignDouble(IAp.IayCMpd, MLobp(12))
		Call f4assignDouble(IAp.IayCMmed, MLobp(13))
		Call f4assignDouble(IAp.IayCMumbi, MLobp(14))
		Call f4assignDouble(IAp.IayCMumpd, MLobp(15))
		Call f4assignDouble(IAp.IayCMpip, MLobp(16))
		Call f4assignDouble(IAp.IayCMcomp, MLobp(17))
		Call f4assignDouble(IAp.IayCMcoll, MLobp(18))
		Call f4assignDouble(IAp.IayCMrent, MLobp(19))
		Call f4assignDouble(IAp.IayCMtow, MLobp(20))
		Call f4assignDouble(IAp.IayOTim, MLobp(21))
		Call f4assignDouble(IAp.IayOTallied, MLobp(22))
		Call f4assignDouble(IAp.IayOTfire, MLobp(23))
		Call f4assignDouble(IAp.IayOTmulti, MLobp(24))
	End Sub
	
	Public Sub AddItdAccyrRec()
		If Not ValUser Then Exit Sub
		AddTran = True
		
		If d4appendStart(f26, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpItdAccyrFlds()
		rc = d4append(f26)
		rc = d4unlock(f26)
	End Sub
	
	Public Sub UpItdAccyrRec()
		If Not ValUser Then Exit Sub
		UpItdAccyrFlds()
		rc = d4unlock(f26)
	End Sub
	
	Public Sub GetItdAccyrRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f26, d4tag(f26, "K1"))
		rc = d4seek(f26, RptDirKey)
		
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f26, d4recNo(f26))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetItdAccyrVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelItdAccyrRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f26)
		Call d4blank(f26)
	End Sub
End Module