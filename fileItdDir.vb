Option Strict Off
Option Explicit On
Module fileItdDir
	
	'FIELD4 structure pointers -- (ItdDir)
	Public Structure PtrItdDir
		Dim ItdMgaNmbr As Integer
		Dim ItdTrtyNmbr As Integer
		Dim ItdPeriod As Integer
		Dim ItdCatCode As Integer
		Dim ItdYear As Integer
		Dim ItdTotal As Integer
		Dim ItdPPbi As Integer
		Dim ItdPPpd As Integer
		Dim ItdPPmed As Integer
		Dim ItdPPumbi As Integer
		Dim ItdPPumpd As Integer
		Dim ItdPPpip As Integer
		Dim ItdPPcomp As Integer
		Dim ItdPPcoll As Integer
		Dim ItdPPrent As Integer
		Dim ItdPPtow As Integer
		Dim ItdCMbi As Integer
		Dim ItdCMpd As Integer
		Dim ItdCMmed As Integer
		Dim ItdCMumbi As Integer
		Dim ItdCMumpd As Integer
		Dim ItdCMpip As Integer
		Dim ItdCMcomp As Integer
		Dim ItdCMcoll As Integer
		Dim ItdCMrent As Integer
		Dim ItdCMtow As Integer
		Dim ItdOTim As Integer
		Dim ItdOTallied As Integer
		Dim ItdOTfire As Integer
		Dim ItdOTmulti As Integer
	End Structure
	Public IDp As PtrItdDir
	
	Public Sub GetItdDirPtr()
		IDp.ItdMgaNmbr = d4field(f11, "MGANMBR")
		IDp.ItdTrtyNmbr = d4field(f11, "TRTYNMBR")
		IDp.ItdPeriod = d4field(f11, "PERIOD")
		IDp.ItdCatCode = d4field(f11, "CATEGORY")
		IDp.ItdYear = d4field(f11, "YEAR")
		IDp.ItdTotal = d4field(f11, "TOTAL")
		IDp.ItdPPbi = d4field(f11, "PPBI")
		IDp.ItdPPpd = d4field(f11, "PPPD")
		IDp.ItdPPmed = d4field(f11, "PPMED")
		IDp.ItdPPumbi = d4field(f11, "PPUMBI")
		IDp.ItdPPumpd = d4field(f11, "PPUMPD")
		IDp.ItdPPpip = d4field(f11, "PPPIP")
		IDp.ItdPPcomp = d4field(f11, "PPCOMP")
		IDp.ItdPPcoll = d4field(f11, "PPCOLL")
		IDp.ItdPPrent = d4field(f11, "PPRENT")
		IDp.ItdPPtow = d4field(f11, "PPTOW")
		IDp.ItdCMbi = d4field(f11, "CMBI")
		IDp.ItdCMpd = d4field(f11, "CMPD")
		IDp.ItdCMmed = d4field(f11, "CMMED")
		IDp.ItdCMumbi = d4field(f11, "CMUMBI")
		IDp.ItdCMumpd = d4field(f11, "CMUMPD")
		IDp.ItdCMpip = d4field(f11, "CMPIP")
		IDp.ItdCMcomp = d4field(f11, "CMCOMP")
		IDp.ItdCMcoll = d4field(f11, "CMCOLL")
		IDp.ItdCMrent = d4field(f11, "CMRENT")
		IDp.ItdCMtow = d4field(f11, "CMTOW")
		IDp.ItdOTim = d4field(f11, "IM")
		IDp.ItdOTallied = d4field(f11, "ALLIED")
		IDp.ItdOTfire = d4field(f11, "FIRE")
		IDp.ItdOTmulti = d4field(f11, "MULTIPERIL")
	End Sub
	
	Public Sub GetItdDirVar()
		MLobt = f4double(IDp.ItdTotal)
		MLobp(1) = f4double(IDp.ItdPPbi)
		MLobp(2) = f4double(IDp.ItdPPpd)
		MLobp(3) = f4double(IDp.ItdPPmed)
		MLobp(4) = f4double(IDp.ItdPPumbi)
		MLobp(5) = f4double(IDp.ItdPPumpd)
		MLobp(6) = f4double(IDp.ItdPPpip)
		MLobp(7) = f4double(IDp.ItdPPcomp)
		MLobp(8) = f4double(IDp.ItdPPcoll)
		MLobp(9) = f4double(IDp.ItdPPrent)
		MLobp(10) = f4double(IDp.ItdPPtow)
		MLobp(11) = f4double(IDp.ItdCMbi)
		MLobp(12) = f4double(IDp.ItdCMpd)
		MLobp(13) = f4double(IDp.ItdCMmed)
		MLobp(14) = f4double(IDp.ItdCMumbi)
		MLobp(15) = f4double(IDp.ItdCMumpd)
		MLobp(16) = f4double(IDp.ItdCMpip)
		MLobp(17) = f4double(IDp.ItdCMcomp)
		MLobp(18) = f4double(IDp.ItdCMcoll)
		MLobp(19) = f4double(IDp.ItdCMrent)
		MLobp(20) = f4double(IDp.ItdCMtow)
		MLobp(21) = f4double(IDp.ItdOTim)
		MLobp(22) = f4double(IDp.ItdOTallied)
		MLobp(23) = f4double(IDp.ItdOTfire)
		MLobp(24) = f4double(IDp.ItdOTmulti)
	End Sub
	
	Public Sub GetItdDirRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f11, d4tag(f11, "K1"))
		rc = d4seek(f11, ItdDirKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f11, d4recNo(f11))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetItdDirVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
End Module