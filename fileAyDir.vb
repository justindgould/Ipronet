Option Strict Off
Option Explicit On
Module fileAyDir
	
	'FIELD4 structure pointers -- (AYDIRYTD)
	Public Structure PtrAyDir
		Dim AydMgaNmbr As Integer
		Dim AydTrtyNmbr As Integer
		Dim AydPeriod As Integer
		Dim AydCatCode As Integer
		Dim AydYear As Integer
		Dim AydTotal As Integer
		Dim AydPPbi As Integer
		Dim AydPPpd As Integer
		Dim AydPPmed As Integer
		Dim AydPPumbi As Integer
		Dim AydPPumpd As Integer
		Dim AydPPpip As Integer
		Dim AydPPcomp As Integer
		Dim AydPPcoll As Integer
		Dim AydPPrent As Integer
		Dim AydPPtow As Integer
		Dim AydCMbi As Integer
		Dim AydCMpd As Integer
		Dim AydCMmed As Integer
		Dim AydCMumbi As Integer
		Dim AydCMumpd As Integer
		Dim AydCMpip As Integer
		Dim AydCMcomp As Integer
		Dim AydCMcoll As Integer
		Dim AydCMrent As Integer
		Dim AydCMtow As Integer
		Dim AydOTim As Integer
		Dim AydOTallied As Integer
		Dim AydOTfire As Integer
		Dim AydOTmulti As Integer
	End Structure
	Public ADp As PtrAyDir
	
	Public Sub GetAyDirPtr()
		ADp.AydMgaNmbr = d4field(f21, "MGANMBR")
		ADp.AydTrtyNmbr = d4field(f21, "TRTYNMBR")
		ADp.AydPeriod = d4field(f21, "PERIOD")
		ADp.AydCatCode = d4field(f21, "CATEGORY")
		ADp.AydYear = d4field(f21, "YEAR")
		ADp.AydTotal = d4field(f21, "TOTAL")
		ADp.AydPPbi = d4field(f21, "PPBI")
		ADp.AydPPpd = d4field(f21, "PPPD")
		ADp.AydPPmed = d4field(f21, "PPMED")
		ADp.AydPPumbi = d4field(f21, "PPUMBI")
		ADp.AydPPumpd = d4field(f21, "PPUMPD")
		ADp.AydPPpip = d4field(f21, "PPPIP")
		ADp.AydPPcomp = d4field(f21, "PPCOMP")
		ADp.AydPPcoll = d4field(f21, "PPCOLL")
		ADp.AydPPrent = d4field(f21, "PPRENT")
		ADp.AydPPtow = d4field(f21, "PPTOW")
		ADp.AydCMbi = d4field(f21, "CMBI")
		ADp.AydCMpd = d4field(f21, "CMPD")
		ADp.AydCMmed = d4field(f21, "CMMED")
		ADp.AydCMumbi = d4field(f21, "CMUMBI")
		ADp.AydCMumpd = d4field(f21, "CMUMPD")
		ADp.AydCMpip = d4field(f21, "CMPIP")
		ADp.AydCMcomp = d4field(f21, "CMCOMP")
		ADp.AydCMcoll = d4field(f21, "CMCOLL")
		ADp.AydCMrent = d4field(f21, "CMRENT")
		ADp.AydCMtow = d4field(f21, "CMTOW")
		ADp.AydOTim = d4field(f21, "IM")
		ADp.AydOTallied = d4field(f21, "ALLIED")
		ADp.AydOTfire = d4field(f21, "FIRE")
		ADp.AydOTmulti = d4field(f21, "MULTIPERIL")
	End Sub
	
	Public Sub GetAyDirVar()
		txRptMgaNmbr = Trim(f4str(ADp.AydMgaNmbr))
		txRptTrtyNmbr = Trim(f4str(ADp.AydTrtyNmbr))
		txRptPeriod = Trim(f4str(ADp.AydPeriod))
		txRptCatCode = Trim(f4str(ADp.AydCatCode))
		txRptYear = Trim(f4str(ADp.AydYear))
		
		MLobt = f4double(ADp.AydTotal)
		MLobp(1) = f4double(ADp.AydPPbi)
		MLobp(2) = f4double(ADp.AydPPpd)
		MLobp(3) = f4double(ADp.AydPPmed)
		MLobp(4) = f4double(ADp.AydPPumbi)
		MLobp(5) = f4double(ADp.AydPPumpd)
		MLobp(6) = f4double(ADp.AydPPpip)
		MLobp(7) = f4double(ADp.AydPPcomp)
		MLobp(8) = f4double(ADp.AydPPcoll)
		MLobp(9) = f4double(ADp.AydPPrent)
		MLobp(10) = f4double(ADp.AydPPtow)
		MLobp(11) = f4double(ADp.AydCMbi)
		MLobp(12) = f4double(ADp.AydCMpd)
		MLobp(13) = f4double(ADp.AydCMmed)
		MLobp(14) = f4double(ADp.AydCMumbi)
		MLobp(15) = f4double(ADp.AydCMumpd)
		MLobp(16) = f4double(ADp.AydCMpip)
		MLobp(17) = f4double(ADp.AydCMcomp)
		MLobp(18) = f4double(ADp.AydCMcoll)
		MLobp(19) = f4double(ADp.AydCMrent)
		MLobp(20) = f4double(ADp.AydCMtow)
		MLobp(21) = f4double(ADp.AydOTim)
		MLobp(22) = f4double(ADp.AydOTallied)
		MLobp(23) = f4double(ADp.AydOTfire)
		MLobp(24) = f4double(ADp.AydOTmulti)
	End Sub
	
	Public Sub UpAyDirFlds()
		Call f4assign(ADp.AydMgaNmbr, txRptMgaNmbr)
		Call f4assign(ADp.AydTrtyNmbr, txRptTrtyNmbr)
		Call f4assign(ADp.AydPeriod, txRptPeriod)
		Call f4assign(ADp.AydCatCode, txRptCatCode)
		Call f4assign(ADp.AydYear, txRptYear)
		Call f4assignDouble(ADp.AydTotal, MLobt)
		Call f4assignDouble(ADp.AydPPbi, MLobp(1))
		Call f4assignDouble(ADp.AydPPpd, MLobp(2))
		Call f4assignDouble(ADp.AydPPmed, MLobp(3))
		Call f4assignDouble(ADp.AydPPumbi, MLobp(4))
		Call f4assignDouble(ADp.AydPPumpd, MLobp(5))
		Call f4assignDouble(ADp.AydPPpip, MLobp(6))
		Call f4assignDouble(ADp.AydPPcomp, MLobp(7))
		Call f4assignDouble(ADp.AydPPcoll, MLobp(8))
		Call f4assignDouble(ADp.AydPPrent, MLobp(9))
		Call f4assignDouble(ADp.AydPPtow, MLobp(10))
		Call f4assignDouble(ADp.AydCMbi, MLobp(11))
		Call f4assignDouble(ADp.AydCMpd, MLobp(12))
		Call f4assignDouble(ADp.AydCMmed, MLobp(13))
		Call f4assignDouble(ADp.AydCMumbi, MLobp(14))
		Call f4assignDouble(ADp.AydCMumpd, MLobp(15))
		Call f4assignDouble(ADp.AydCMpip, MLobp(16))
		Call f4assignDouble(ADp.AydCMcomp, MLobp(17))
		Call f4assignDouble(ADp.AydCMcoll, MLobp(18))
		Call f4assignDouble(ADp.AydCMrent, MLobp(19))
		Call f4assignDouble(ADp.AydCMtow, MLobp(20))
		Call f4assignDouble(ADp.AydOTim, MLobp(21))
		Call f4assignDouble(ADp.AydOTallied, MLobp(22))
		Call f4assignDouble(ADp.AydOTfire, MLobp(23))
		Call f4assignDouble(ADp.AydOTmulti, MLobp(24))
	End Sub
	
	Public Sub AddAyDirRec()
		If Not ValUser Then Exit Sub
		AddTran = True
		
		If d4appendStart(f21, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpAyDirFlds()
		rc = d4append(f21)
		rc = d4unlock(f21)
	End Sub
	
	Public Sub UpAyDirRec()
		If Not ValUser Then Exit Sub
		UpAyDirFlds()
		rc = d4unlock(f21)
	End Sub
	
	Public Sub GetAyDirRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f21, d4tag(f21, "K1"))
		rc = d4seek(f21, RptDirKey)
		
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f21, d4recNo(f21))
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
	
	Sub DelAyDirRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f21)
		Call d4blank(f21)
	End Sub
End Module