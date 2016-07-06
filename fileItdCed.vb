Option Strict Off
Option Explicit On
Module fileItdCed
	
	'FIELD4 structure pointers -- (ItdCed1)
	Public Structure PtrItdCed1
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
	Public Ic1p As PtrItdCed1
	
	Public Sub GetItdCedPtr()
		Ic1p.CedMgaNmbr = d4field(f12, "MGANMBR")
		Ic1p.CedTrtyNmbr = d4field(f12, "TRTYNMBR")
		Ic1p.CedPeriod = d4field(f12, "PERIOD")
		Ic1p.CedCatCode = d4field(f12, "CATEGORY")
		Ic1p.CedYear = d4field(f12, "YEAR")
		Ic1p.CedTotal = d4field(f12, "TOTAL")
		Ic1p.CedPPbi = d4field(f12, "PPBI")
		Ic1p.CedPPpd = d4field(f12, "PPPD")
		Ic1p.CedPPmed = d4field(f12, "PPMED")
		Ic1p.CedPPumbi = d4field(f12, "PPUMBI")
		Ic1p.CedPPumpd = d4field(f12, "PPUMPD")
		Ic1p.CedPPpip = d4field(f12, "PPPIP")
		Ic1p.CedPPcomp = d4field(f12, "PPCOMP")
		Ic1p.CedPPcoll = d4field(f12, "PPCOLL")
		Ic1p.CedPPrent = d4field(f12, "PPRENT")
		Ic1p.CedPPtow = d4field(f12, "PPTOW")
		Ic1p.CedCMbi = d4field(f12, "CMBI")
		Ic1p.CedCMpd = d4field(f12, "CMPD")
		Ic1p.CedCMmed = d4field(f12, "CMMED")
		Ic1p.CedCMumbi = d4field(f12, "CMUMBI")
		Ic1p.CedCMumpd = d4field(f12, "CMUMPD")
		Ic1p.CedCMpip = d4field(f12, "CMPIP")
		Ic1p.CedCMcomp = d4field(f12, "CMCOMP")
		Ic1p.CedCMcoll = d4field(f12, "CMCOLL")
		Ic1p.CedCMrent = d4field(f12, "CMRENT")
		Ic1p.CedCMtow = d4field(f12, "CMTOW")
		Ic1p.CedOTim = d4field(f12, "IM")
		Ic1p.CedOTallied = d4field(f12, "ALLIED")
		Ic1p.CedOTfire = d4field(f12, "FIRE")
		Ic1p.CedOTmulti = d4field(f12, "MULTIPERIL")
	End Sub
	
	Public Sub GetItdCedVar()
		MLobt = f4double(Ic1p.CedTotal)
		MLobp(1) = f4double(Ic1p.CedPPbi)
		MLobp(2) = f4double(Ic1p.CedPPpd)
		MLobp(3) = f4double(Ic1p.CedPPmed)
		MLobp(4) = f4double(Ic1p.CedPPumbi)
		MLobp(5) = f4double(Ic1p.CedPPumpd)
		MLobp(6) = f4double(Ic1p.CedPPpip)
		MLobp(7) = f4double(Ic1p.CedPPcomp)
		MLobp(8) = f4double(Ic1p.CedPPcoll)
		MLobp(9) = f4double(Ic1p.CedPPrent)
		MLobp(10) = f4double(Ic1p.CedPPtow)
		MLobp(11) = f4double(Ic1p.CedCMbi)
		MLobp(12) = f4double(Ic1p.CedCMpd)
		MLobp(13) = f4double(Ic1p.CedCMmed)
		MLobp(14) = f4double(Ic1p.CedCMumbi)
		MLobp(15) = f4double(Ic1p.CedCMumpd)
		MLobp(16) = f4double(Ic1p.CedCMpip)
		MLobp(17) = f4double(Ic1p.CedCMcomp)
		MLobp(18) = f4double(Ic1p.CedCMcoll)
		MLobp(19) = f4double(Ic1p.CedCMrent)
		MLobp(20) = f4double(Ic1p.CedCMtow)
		MLobp(21) = f4double(Ic1p.CedOTim)
		MLobp(22) = f4double(Ic1p.CedOTallied)
		MLobp(23) = f4double(Ic1p.CedOTfire)
		MLobp(24) = f4double(Ic1p.CedOTmulti)
	End Sub
	
	Public Sub GetItdCedRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f12, d4tag(f12, "K1"))
		rc = d4seek(f12, ItdCedKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f12, d4recNo(f12))
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