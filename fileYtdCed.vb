Option Strict Off
Option Explicit On
Module fileYtdCed
	
	'FIELD4 structure pointers -- (YTDCed1)
	Public Structure PtrYtdCed1
		Dim CedMgaNmbr As Integer
		Dim CedTrtyNmbr As Integer
		Dim CedPeriod As Integer
		Dim CedCatCode As Integer
		Dim CedYear As Integer
		Dim CedTotal As Integer
		Dim CedPPbi As Integer
		Dim CedPPpd As Integer
		Dim CedPPmed As Integer
		Dim CedPPumbi As Integer
		Dim CedPPumpd As Integer
		Dim CedPPpip As Integer
		Dim CedPPcomp As Integer
		Dim CedPPcoll As Integer
		Dim CedPPrent As Integer
		Dim CedPPtow As Integer
		Dim CedCMbi As Integer
		Dim CedCMpd As Integer
		Dim CedCMmed As Integer
		Dim CedCMumbi As Integer
		Dim CedCMumpd As Integer
		Dim CedCMpip As Integer
		Dim CedCMcomp As Integer
		Dim CedCMcoll As Integer
		Dim CedCMrent As Integer
		Dim CedCMtow As Integer
		Dim CedOTim As Integer
		Dim CedOTallied As Integer
		Dim CedOTfire As Integer
		Dim CedOTmulti As Integer
	End Structure
	Public YDc1p As PtrYtdCed1
	
	Public Sub GetYtdCedPtr()
		YDc1p.CedMgaNmbr = d4field(f10, "MGANMBR")
		YDc1p.CedTrtyNmbr = d4field(f10, "TRTYNMBR")
		YDc1p.CedPeriod = d4field(f10, "PERIOD")
		YDc1p.CedCatCode = d4field(f10, "CATEGORY")
		YDc1p.CedYear = d4field(f10, "YEAR")
		YDc1p.CedTotal = d4field(f10, "TOTAL")
		YDc1p.CedPPbi = d4field(f10, "PPBI")
		YDc1p.CedPPpd = d4field(f10, "PPPD")
		YDc1p.CedPPmed = d4field(f10, "PPMED")
		YDc1p.CedPPumbi = d4field(f10, "PPUMBI")
		YDc1p.CedPPumpd = d4field(f10, "PPUMPD")
		YDc1p.CedPPpip = d4field(f10, "PPPIP")
		YDc1p.CedPPcomp = d4field(f10, "PPCOMP")
		YDc1p.CedPPcoll = d4field(f10, "PPCOLL")
		YDc1p.CedPPrent = d4field(f10, "PPRENT")
		YDc1p.CedPPtow = d4field(f10, "PPTOW")
		YDc1p.CedCMbi = d4field(f10, "CMBI")
		YDc1p.CedCMpd = d4field(f10, "CMPD")
		YDc1p.CedCMmed = d4field(f10, "CMMED")
		YDc1p.CedCMumbi = d4field(f10, "CMUMBI")
		YDc1p.CedCMumpd = d4field(f10, "CMUMPD")
		YDc1p.CedCMpip = d4field(f10, "CMPIP")
		YDc1p.CedCMcomp = d4field(f10, "CMCOMP")
		YDc1p.CedCMcoll = d4field(f10, "CMCOLL")
		YDc1p.CedCMrent = d4field(f10, "CMRENT")
		YDc1p.CedCMtow = d4field(f10, "CMTOW")
		YDc1p.CedOTim = d4field(f10, "IM")
		YDc1p.CedOTallied = d4field(f10, "ALLIED")
		YDc1p.CedOTfire = d4field(f10, "FIRE")
		YDc1p.CedOTmulti = d4field(f10, "MULTIPERIL")
	End Sub
	
	Public Sub GetYtdCedVar()
		MLobt = f4double(YDc1p.CedTotal)
		MLobp(1) = f4double(YDc1p.CedPPbi)
		MLobp(2) = f4double(YDc1p.CedPPpd)
		MLobp(3) = f4double(YDc1p.CedPPmed)
		MLobp(4) = f4double(YDc1p.CedPPumbi)
		MLobp(5) = f4double(YDc1p.CedPPumpd)
		MLobp(6) = f4double(YDc1p.CedPPpip)
		MLobp(7) = f4double(YDc1p.CedPPcomp)
		MLobp(8) = f4double(YDc1p.CedPPcoll)
		MLobp(9) = f4double(YDc1p.CedPPrent)
		MLobp(10) = f4double(YDc1p.CedPPtow)
		MLobp(11) = f4double(YDc1p.CedCMbi)
		MLobp(12) = f4double(YDc1p.CedCMpd)
		MLobp(13) = f4double(YDc1p.CedCMmed)
		MLobp(14) = f4double(YDc1p.CedCMumbi)
		MLobp(15) = f4double(YDc1p.CedCMumpd)
		MLobp(16) = f4double(YDc1p.CedCMpip)
		MLobp(17) = f4double(YDc1p.CedCMcomp)
		MLobp(18) = f4double(YDc1p.CedCMcoll)
		MLobp(19) = f4double(YDc1p.CedCMrent)
		MLobp(20) = f4double(YDc1p.CedCMtow)
		MLobp(21) = f4double(YDc1p.CedOTim)
		MLobp(22) = f4double(YDc1p.CedOTallied)
		MLobp(23) = f4double(YDc1p.CedOTfire)
		MLobp(24) = f4double(YDc1p.CedOTmulti)
	End Sub
	
	Public Sub GetYtdCedRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f10, d4tag(f10, "K1"))
		rc = d4seek(f10, ItdCedKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f10, d4recNo(f10))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetItdCedVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
End Module