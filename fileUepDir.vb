Option Strict Off
Option Explicit On
Module fileUepDir
	
	'FIELD4 structure pointers -- (UepDir)
	Public Structure PtrUepDir
		Dim UepMgaNmbr As Integer
		Dim UepTrtyNmbr As Integer
		Dim UepPeriod As Integer
		Dim UepCatCode As Integer
		Dim UepYear As Integer
		Dim UepTotal As Integer
		Dim UepPPbi As Integer
		Dim UepPPpd As Integer
		Dim UepPPmed As Integer
		Dim UepPPumbi As Integer
		Dim UepPPumpd As Integer
		Dim UepPPpip As Integer
		Dim UepPPcomp As Integer
		Dim UepPPcoll As Integer
		Dim UepPPrent As Integer
		Dim UepPPtow As Integer
		Dim UepCMbi As Integer
		Dim UepCMpd As Integer
		Dim UepCMmed As Integer
		Dim UepCMumbi As Integer
		Dim UepCMumpd As Integer
		Dim UepCMpip As Integer
		Dim UepCMcomp As Integer
		Dim UepCMcoll As Integer
		Dim UepCMrent As Integer
		Dim UepCMtow As Integer
		Dim UepOTim As Integer
		Dim UepOTallied As Integer
		Dim UepOTfire As Integer
		Dim UepOTmulti As Integer
	End Structure
	Public UEp As PtrUepDir
	
	Public Sub GetUepDirPtr()
		UEp.UepMgaNmbr = d4field(f7, "MGANMBR")
		UEp.UepTrtyNmbr = d4field(f7, "TRTYNMBR")
		UEp.UepPeriod = d4field(f7, "PERIOD")
		UEp.UepCatCode = d4field(f7, "CATEGORY")
		UEp.UepYear = d4field(f7, "YEAR")
		UEp.UepTotal = d4field(f7, "TOTAL")
		UEp.UepPPbi = d4field(f7, "PPBI")
		UEp.UepPPpd = d4field(f7, "PPPD")
		UEp.UepPPmed = d4field(f7, "PPMED")
		UEp.UepPPumbi = d4field(f7, "PPUMBI")
		UEp.UepPPumpd = d4field(f7, "PPUMPD")
		UEp.UepPPpip = d4field(f7, "PPPIP")
		UEp.UepPPcomp = d4field(f7, "PPCOMP")
		UEp.UepPPcoll = d4field(f7, "PPCOLL")
		UEp.UepPPrent = d4field(f7, "PPRENT")
		UEp.UepPPtow = d4field(f7, "PPTOW")
		UEp.UepCMbi = d4field(f7, "CMBI")
		UEp.UepCMpd = d4field(f7, "CMPD")
		UEp.UepCMmed = d4field(f7, "CMMED")
		UEp.UepCMumbi = d4field(f7, "CMUMBI")
		UEp.UepCMumpd = d4field(f7, "CMUMPD")
		UEp.UepCMpip = d4field(f7, "CMPIP")
		UEp.UepCMcomp = d4field(f7, "CMCOMP")
		UEp.UepCMcoll = d4field(f7, "CMCOLL")
		UEp.UepCMrent = d4field(f7, "CMRENT")
		UEp.UepCMtow = d4field(f7, "CMTOW")
		UEp.UepOTim = d4field(f7, "IM")
		UEp.UepOTallied = d4field(f7, "ALLIED")
		UEp.UepOTfire = d4field(f7, "FIRE")
		UEp.UepOTmulti = d4field(f7, "MULTIPERIL")
	End Sub
	
	Public Sub GetUepDirVar()
		MLobt = f4double(UEp.UepTotal)
		MLobp(1) = f4double(UEp.UepPPbi)
		MLobp(2) = f4double(UEp.UepPPpd)
		MLobp(3) = f4double(UEp.UepPPmed)
		MLobp(4) = f4double(UEp.UepPPumbi)
		MLobp(5) = f4double(UEp.UepPPumpd)
		MLobp(6) = f4double(UEp.UepPPpip)
		MLobp(7) = f4double(UEp.UepPPcomp)
		MLobp(8) = f4double(UEp.UepPPcoll)
		MLobp(9) = f4double(UEp.UepPPrent)
		MLobp(10) = f4double(UEp.UepPPtow)
		MLobp(11) = f4double(UEp.UepCMbi)
		MLobp(12) = f4double(UEp.UepCMpd)
		MLobp(13) = f4double(UEp.UepCMmed)
		MLobp(14) = f4double(UEp.UepCMumbi)
		MLobp(15) = f4double(UEp.UepCMumpd)
		MLobp(16) = f4double(UEp.UepCMpip)
		MLobp(17) = f4double(UEp.UepCMcomp)
		MLobp(18) = f4double(UEp.UepCMcoll)
		MLobp(19) = f4double(UEp.UepCMrent)
		MLobp(20) = f4double(UEp.UepCMtow)
		MLobp(21) = f4double(UEp.UepOTim)
		MLobp(22) = f4double(UEp.UepOTallied)
		MLobp(23) = f4double(UEp.UepOTfire)
		MLobp(24) = f4double(UEp.UepOTmulti)
	End Sub
	
	Public Sub GetUepDirRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f7, d4tag(f7, "K1"))
		rc = d4seek(f7, UepDirKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f7, d4recNo(f7))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetUepDirVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
End Module