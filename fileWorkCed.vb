Option Strict Off
Option Explicit On
Module fileWorkCed
	
	'FIELD4 structure pointers -- (WorkCed1)
	Public Structure PtrWorkCed1
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
	Public Wc1p As PtrWorkCed1
	
	Public Sub GetWorkCedPtr()
		Wc1p.CedMgaNmbr = d4field(f14, "MGANMBR")
		Wc1p.CedTrtyNmbr = d4field(f14, "TRTYNMBR")
		Wc1p.CedPeriod = d4field(f14, "PERIOD")
		Wc1p.CedCatCode = d4field(f14, "CATEGORY")
		Wc1p.CedYear = d4field(f14, "YEAR")
		Wc1p.CedTotal = d4field(f14, "TOTAL")
		Wc1p.CedPPbi = d4field(f14, "PPBI")
		Wc1p.CedPPpd = d4field(f14, "PPPD")
		Wc1p.CedPPmed = d4field(f14, "PPMED")
		Wc1p.CedPPumbi = d4field(f14, "PPUMBI")
		Wc1p.CedPPumpd = d4field(f14, "PPUMPD")
		Wc1p.CedPPpip = d4field(f14, "PPPIP")
		Wc1p.CedPPcomp = d4field(f14, "PPCOMP")
		Wc1p.CedPPcoll = d4field(f14, "PPCOLL")
		Wc1p.CedPPrent = d4field(f14, "PPRENT")
		Wc1p.CedPPtow = d4field(f14, "PPTOW")
		Wc1p.CedCMbi = d4field(f14, "CMBI")
		Wc1p.CedCMpd = d4field(f14, "CMPD")
		Wc1p.CedCMmed = d4field(f14, "CMMED")
		Wc1p.CedCMumbi = d4field(f14, "CMUMBI")
		Wc1p.CedCMumpd = d4field(f14, "CMUMPD")
		Wc1p.CedCMpip = d4field(f14, "CMPIP")
		Wc1p.CedCMcomp = d4field(f14, "CMCOMP")
		Wc1p.CedCMcoll = d4field(f14, "CMCOLL")
		Wc1p.CedCMrent = d4field(f14, "CMRENT")
		Wc1p.CedCMtow = d4field(f14, "CMTOW")
		Wc1p.CedOTim = d4field(f14, "IM")
		Wc1p.CedOTallied = d4field(f14, "ALLIED")
		Wc1p.CedOTfire = d4field(f14, "FIRE")
		Wc1p.CedOTmulti = d4field(f14, "MULTIPERIL")
	End Sub
	
	Public Sub GetWorkCedVar()
		MLobt = f4double(Wc1p.CedTotal)
		MLobp(1) = f4double(Wc1p.CedPPbi)
		MLobp(2) = f4double(Wc1p.CedPPpd)
		MLobp(3) = f4double(Wc1p.CedPPmed)
		MLobp(4) = f4double(Wc1p.CedPPumbi)
		MLobp(5) = f4double(Wc1p.CedPPumpd)
		MLobp(6) = f4double(Wc1p.CedPPpip)
		MLobp(7) = f4double(Wc1p.CedPPcomp)
		MLobp(8) = f4double(Wc1p.CedPPcoll)
		MLobp(9) = f4double(Wc1p.CedPPrent)
		MLobp(10) = f4double(Wc1p.CedPPtow)
		MLobp(11) = f4double(Wc1p.CedCMbi)
		MLobp(12) = f4double(Wc1p.CedCMpd)
		MLobp(13) = f4double(Wc1p.CedCMmed)
		MLobp(14) = f4double(Wc1p.CedCMumbi)
		MLobp(15) = f4double(Wc1p.CedCMumpd)
		MLobp(16) = f4double(Wc1p.CedCMpip)
		MLobp(17) = f4double(Wc1p.CedCMcomp)
		MLobp(18) = f4double(Wc1p.CedCMcoll)
		MLobp(19) = f4double(Wc1p.CedCMrent)
		MLobp(20) = f4double(Wc1p.CedCMtow)
		MLobp(21) = f4double(Wc1p.CedOTim)
		MLobp(22) = f4double(Wc1p.CedOTallied)
		MLobp(23) = f4double(Wc1p.CedOTfire)
		MLobp(24) = f4double(Wc1p.CedOTmulti)
	End Sub
End Module