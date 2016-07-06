Option Strict Off
Option Explicit On
Module fileYtdDir
	
	'FIELD4 structure pointers -- (YTDDIR)
	Public Structure PtrYtdDir
		Dim YtdMgaNmbr As Integer
		Dim YtdTrtyNmbr As Integer
		Dim YtdPeriod As Integer
		Dim YtdCatCode As Integer
		Dim YtdYear As Integer
		Dim YtdTotal As Integer
		Dim YtdPPbi As Integer
		Dim YtdPPpd As Integer
		Dim YtdPPmed As Integer
		Dim YtdPPumbi As Integer
		Dim YtdPPumpd As Integer
		Dim YtdPPpip As Integer
		Dim YtdPPcomp As Integer
		Dim YtdPPcoll As Integer
		Dim YtdPPrent As Integer
		Dim YtdPPtow As Integer
		Dim YtdCMbi As Integer
		Dim YtdCMpd As Integer
		Dim YtdCMmed As Integer
		Dim YtdCMumbi As Integer
		Dim YtdCMumpd As Integer
		Dim YtdCMpip As Integer
		Dim YtdCMcomp As Integer
		Dim YtdCMcoll As Integer
		Dim YtdCMrent As Integer
		Dim YtdCMtow As Integer
		Dim YtdOTim As Integer
		Dim YtdOTallied As Integer
		Dim YtdOTfire As Integer
		Dim YtdOTmulti As Integer
	End Structure
	Public YDp As PtrYtdDir
	
	Public Sub GetYtdDirPtr()
		YDp.YtdMgaNmbr = d4field(f9, "MGANMBR")
		YDp.YtdTrtyNmbr = d4field(f9, "TRTYNMBR")
		YDp.YtdPeriod = d4field(f9, "PERIOD")
		YDp.YtdCatCode = d4field(f9, "CATEGORY")
		YDp.YtdYear = d4field(f9, "YEAR")
		YDp.YtdTotal = d4field(f9, "TOTAL")
		YDp.YtdPPbi = d4field(f9, "PPBI")
		YDp.YtdPPpd = d4field(f9, "PPPD")
		YDp.YtdPPmed = d4field(f9, "PPMED")
		YDp.YtdPPumbi = d4field(f9, "PPUMBI")
		YDp.YtdPPumpd = d4field(f9, "PPUMPD")
		YDp.YtdPPpip = d4field(f9, "PPPIP")
		YDp.YtdPPcomp = d4field(f9, "PPCOMP")
		YDp.YtdPPcoll = d4field(f9, "PPCOLL")
		YDp.YtdPPrent = d4field(f9, "PPRENT")
		YDp.YtdPPtow = d4field(f9, "PPTOW")
		YDp.YtdCMbi = d4field(f9, "CMBI")
		YDp.YtdCMpd = d4field(f9, "CMPD")
		YDp.YtdCMmed = d4field(f9, "CMMED")
		YDp.YtdCMumbi = d4field(f9, "CMUMBI")
		YDp.YtdCMumpd = d4field(f9, "CMUMPD")
		YDp.YtdCMpip = d4field(f9, "CMPIP")
		YDp.YtdCMcomp = d4field(f9, "CMCOMP")
		YDp.YtdCMcoll = d4field(f9, "CMCOLL")
		YDp.YtdCMrent = d4field(f9, "CMRENT")
		YDp.YtdCMtow = d4field(f9, "CMTOW")
		YDp.YtdOTim = d4field(f9, "IM")
		YDp.YtdOTallied = d4field(f9, "ALLIED")
		YDp.YtdOTfire = d4field(f9, "FIRE")
		YDp.YtdOTmulti = d4field(f9, "MULTIPERIL")
	End Sub
	
	Public Sub GetYtdDirVar()
		MLobt = f4double(YDp.YtdTotal)
		MLobp(1) = f4double(YDp.YtdPPbi)
		MLobp(2) = f4double(YDp.YtdPPpd)
		MLobp(3) = f4double(YDp.YtdPPmed)
		MLobp(4) = f4double(YDp.YtdPPumbi)
		MLobp(5) = f4double(YDp.YtdPPumpd)
		MLobp(6) = f4double(YDp.YtdPPpip)
		MLobp(7) = f4double(YDp.YtdPPcomp)
		MLobp(8) = f4double(YDp.YtdPPcoll)
		MLobp(9) = f4double(YDp.YtdPPrent)
		MLobp(10) = f4double(YDp.YtdPPtow)
		MLobp(11) = f4double(YDp.YtdCMbi)
		MLobp(12) = f4double(YDp.YtdCMpd)
		MLobp(13) = f4double(YDp.YtdCMmed)
		MLobp(14) = f4double(YDp.YtdCMumbi)
		MLobp(15) = f4double(YDp.YtdCMumpd)
		MLobp(16) = f4double(YDp.YtdCMpip)
		MLobp(17) = f4double(YDp.YtdCMcomp)
		MLobp(18) = f4double(YDp.YtdCMcoll)
		MLobp(19) = f4double(YDp.YtdCMrent)
		MLobp(20) = f4double(YDp.YtdCMtow)
		MLobp(21) = f4double(YDp.YtdOTim)
		MLobp(22) = f4double(YDp.YtdOTallied)
		MLobp(23) = f4double(YDp.YtdOTfire)
		MLobp(24) = f4double(YDp.YtdOTmulti)
	End Sub
	
	Public Sub GetYtdDirRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f9, d4tag(f9, "K1"))
		rc = d4seek(f9, YtdDirKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f9, d4recNo(f9))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetYtdDirVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
End Module