Option Strict Off
Option Explicit On
Module fileWorkDir
	
	'FIELD4 structure pointers -- (WorkDir)
	Public Structure PtrWorkDir
		Dim WorkMgaNmbr As Integer
		Dim WorkTrtyNmbr As Integer
		Dim WorkPeriod As Integer
		Dim WorkCatCode As Integer
		Dim WorkYear As Integer
		Dim WorkTotal As Integer
		Dim WorkPPbi As Integer
		Dim WorkPPpd As Integer
		Dim WorkPPmed As Integer
		Dim WorkPPumbi As Integer
		Dim WorkPPumpd As Integer
		Dim WorkPPpip As Integer
		Dim WorkPPcomp As Integer
		Dim WorkPPcoll As Integer
		Dim WorkPPrent As Integer
		Dim WorkPPtow As Integer
		Dim WorkCMbi As Integer
		Dim WorkCMpd As Integer
		Dim WorkCMmed As Integer
		Dim WorkCMumbi As Integer
		Dim WorkCMumpd As Integer
		Dim WorkCMpip As Integer
		Dim WorkCMcomp As Integer
		Dim WorkCMcoll As Integer
		Dim WorkCMrent As Integer
		Dim WorkCMtow As Integer
		Dim WorkOTim As Integer
		Dim WorkOTallied As Integer
		Dim WorkOTfire As Integer
		Dim WorkOTmulti As Integer
	End Structure
	Public WDp As PtrWorkDir
	
	Public Sub GetWorkDirPtr()
		WDp.WorkMgaNmbr = d4field(f13, "MGANMBR")
		WDp.WorkTrtyNmbr = d4field(f13, "TRTYNMBR")
		WDp.WorkPeriod = d4field(f13, "PERIOD")
		WDp.WorkCatCode = d4field(f13, "CATEGORY")
		WDp.WorkYear = d4field(f13, "YEAR")
		WDp.WorkTotal = d4field(f13, "TOTAL")
		WDp.WorkPPbi = d4field(f13, "PPBI")
		WDp.WorkPPpd = d4field(f13, "PPPD")
		WDp.WorkPPmed = d4field(f13, "PPMED")
		WDp.WorkPPumbi = d4field(f13, "PPUMBI")
		WDp.WorkPPumpd = d4field(f13, "PPUMPD")
		WDp.WorkPPpip = d4field(f13, "PPPIP")
		WDp.WorkPPcomp = d4field(f13, "PPCOMP")
		WDp.WorkPPcoll = d4field(f13, "PPCOLL")
		WDp.WorkPPrent = d4field(f13, "PPRENT")
		WDp.WorkPPtow = d4field(f13, "PPTOW")
		WDp.WorkCMbi = d4field(f13, "CMBI")
		WDp.WorkCMpd = d4field(f13, "CMPD")
		WDp.WorkCMmed = d4field(f13, "CMMED")
		WDp.WorkCMumbi = d4field(f13, "CMUMBI")
		WDp.WorkCMumpd = d4field(f13, "CMUMPD")
		WDp.WorkCMpip = d4field(f13, "CMPIP")
		WDp.WorkCMcomp = d4field(f13, "CMCOMP")
		WDp.WorkCMcoll = d4field(f13, "CMCOLL")
		WDp.WorkCMrent = d4field(f13, "CMRENT")
		WDp.WorkCMtow = d4field(f13, "CMTOW")
		WDp.WorkOTim = d4field(f13, "IM")
		WDp.WorkOTallied = d4field(f13, "ALLIED")
		WDp.WorkOTfire = d4field(f13, "FIRE")
		WDp.WorkOTmulti = d4field(f13, "MULTIPERIL")
	End Sub
	
	Public Sub GetWorkDirVar()
		MLobt = f4double(WDp.WorkTotal)
		MLobp(1) = f4double(WDp.WorkPPbi)
		MLobp(2) = f4double(WDp.WorkPPpd)
		MLobp(3) = f4double(WDp.WorkPPmed)
		MLobp(4) = f4double(WDp.WorkPPumbi)
		MLobp(5) = f4double(WDp.WorkPPumpd)
		MLobp(6) = f4double(WDp.WorkPPpip)
		MLobp(7) = f4double(WDp.WorkPPcomp)
		MLobp(8) = f4double(WDp.WorkPPcoll)
		MLobp(9) = f4double(WDp.WorkPPrent)
		MLobp(10) = f4double(WDp.WorkPPtow)
		MLobp(11) = f4double(WDp.WorkCMbi)
		MLobp(12) = f4double(WDp.WorkCMpd)
		MLobp(13) = f4double(WDp.WorkCMmed)
		MLobp(14) = f4double(WDp.WorkCMumbi)
		MLobp(15) = f4double(WDp.WorkCMumpd)
		MLobp(16) = f4double(WDp.WorkCMpip)
		MLobp(17) = f4double(WDp.WorkCMcomp)
		MLobp(18) = f4double(WDp.WorkCMcoll)
		MLobp(19) = f4double(WDp.WorkCMrent)
		MLobp(20) = f4double(WDp.WorkCMtow)
		MLobp(21) = f4double(WDp.WorkOTim)
		MLobp(22) = f4double(WDp.WorkOTallied)
		MLobp(23) = f4double(WDp.WorkOTfire)
		MLobp(24) = f4double(WDp.WorkOTmulti)
	End Sub
	
	Public Sub GetWorkDirRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f13, d4tag(f13, "K1"))
		rc = d4seek(f13, ItdDirKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f13, d4recNo(f13))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetWorkDirVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
End Module