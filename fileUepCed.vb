Option Strict Off
Option Explicit On
Module fileUepCed
	
	'FIELD4 structure pointers -- (UepCed1)
	Public Structure PtrUepCed1
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
	Public Uc1p As PtrUepCed1
	
	Public Sub GetUepCedPtr()
		Uc1p.CedMgaNmbr = d4field(f8, "MGANMBR")
		Uc1p.CedTrtyNmbr = d4field(f8, "TRTYNMBR")
		Uc1p.CedPeriod = d4field(f8, "PERIOD")
		Uc1p.CedCatCode = d4field(f8, "CATEGORY")
		Uc1p.CedYear = d4field(f8, "YEAR")
		Uc1p.CedTotal = d4field(f8, "TOTAL")
		Uc1p.CedPPbi = d4field(f8, "PPBI")
		Uc1p.CedPPpd = d4field(f8, "PPPD")
		Uc1p.CedPPmed = d4field(f8, "PPMED")
		Uc1p.CedPPumbi = d4field(f8, "PPUMBI")
		Uc1p.CedPPumpd = d4field(f8, "PPUMPD")
		Uc1p.CedPPpip = d4field(f8, "PPPIP")
		Uc1p.CedPPcomp = d4field(f8, "PPCOMP")
		Uc1p.CedPPcoll = d4field(f8, "PPCOLL")
		Uc1p.CedPPrent = d4field(f8, "PPRENT")
		Uc1p.CedPPtow = d4field(f8, "PPTOW")
		Uc1p.CedCMbi = d4field(f8, "CMBI")
		Uc1p.CedCMpd = d4field(f8, "CMPD")
		Uc1p.CedCMmed = d4field(f8, "CMMED")
		Uc1p.CedCMumbi = d4field(f8, "CMUMBI")
		Uc1p.CedCMumpd = d4field(f8, "CMUMPD")
		Uc1p.CedCMpip = d4field(f8, "CMPIP")
		Uc1p.CedCMcomp = d4field(f8, "CMCOMP")
		Uc1p.CedCMcoll = d4field(f8, "CMCOLL")
		Uc1p.CedCMrent = d4field(f8, "CMRENT")
		Uc1p.CedCMtow = d4field(f8, "CMTOW")
		Uc1p.CedOTim = d4field(f8, "IM")
		Uc1p.CedOTallied = d4field(f8, "ALLIED")
		Uc1p.CedOTfire = d4field(f8, "FIRE")
		Uc1p.CedOTmulti = d4field(f8, "MULTIPERIL")
	End Sub
	
	Public Sub GetUepCedVar()
		MLobt = f4double(Uc1p.CedTotal)
		MLobp(1) = f4double(Uc1p.CedPPbi)
		MLobp(2) = f4double(Uc1p.CedPPpd)
		MLobp(3) = f4double(Uc1p.CedPPmed)
		MLobp(4) = f4double(Uc1p.CedPPumbi)
		MLobp(5) = f4double(Uc1p.CedPPumpd)
		MLobp(6) = f4double(Uc1p.CedPPpip)
		MLobp(7) = f4double(Uc1p.CedPPcomp)
		MLobp(8) = f4double(Uc1p.CedPPcoll)
		MLobp(9) = f4double(Uc1p.CedPPrent)
		MLobp(10) = f4double(Uc1p.CedPPtow)
		MLobp(11) = f4double(Uc1p.CedCMbi)
		MLobp(12) = f4double(Uc1p.CedCMpd)
		MLobp(13) = f4double(Uc1p.CedCMmed)
		MLobp(14) = f4double(Uc1p.CedCMumbi)
		MLobp(15) = f4double(Uc1p.CedCMumpd)
		MLobp(16) = f4double(Uc1p.CedCMpip)
		MLobp(17) = f4double(Uc1p.CedCMcomp)
		MLobp(18) = f4double(Uc1p.CedCMcoll)
		MLobp(19) = f4double(Uc1p.CedCMrent)
		MLobp(20) = f4double(Uc1p.CedCMtow)
		MLobp(21) = f4double(Uc1p.CedOTim)
		MLobp(22) = f4double(Uc1p.CedOTallied)
		MLobp(23) = f4double(Uc1p.CedOTfire)
		MLobp(24) = f4double(Uc1p.CedOTmulti)
	End Sub
	
	Public Sub GetUepCedRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f8, d4tag(f8, "K1"))
		rc = d4seek(f8, UepCedKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f8, d4recNo(f8))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetUepCedVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
End Module