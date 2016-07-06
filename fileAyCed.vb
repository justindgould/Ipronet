Option Strict Off
Option Explicit On
Module fileAyCed
	
	'FIELD4 structure pointers -- (AYDIRCED)
	Public Structure PtrAyCed
		Dim AycMgaNmbr As Integer
		Dim AycTrtyNmbr As Integer
		Dim AycPeriod As Integer
		Dim AycCatCode As Integer
		Dim AycYear As Integer
		Dim AycTotal As Integer
		Dim AycPPbi As Integer
		Dim AycPPpd As Integer
		Dim AycPPmed As Integer
		Dim AycPPumbi As Integer
		Dim AycPPumpd As Integer
		Dim AycPPpip As Integer
		Dim AycPPcomp As Integer
		Dim AycPPcoll As Integer
		Dim AycPPrent As Integer
		Dim AycPPtow As Integer
		Dim AycCMbi As Integer
		Dim AycCMpd As Integer
		Dim AycCMmed As Integer
		Dim AycCMumbi As Integer
		Dim AycCMumpd As Integer
		Dim AycCMpip As Integer
		Dim AycCMcomp As Integer
		Dim AycCMcoll As Integer
		Dim AycCMrent As Integer
		Dim AycCMtow As Integer
		Dim AycOTim As Integer
		Dim AycOTallied As Integer
		Dim AycOTfire As Integer
		Dim AycOTmulti As Integer
	End Structure
	Public ACp As PtrAyCed
	
	Public Sub GetAyCedPtr()
		ACp.AycMgaNmbr = d4field(f20, "MGANMBR")
		ACp.AycTrtyNmbr = d4field(f20, "TRTYNMBR")
		ACp.AycPeriod = d4field(f20, "PERIOD")
		ACp.AycCatCode = d4field(f20, "CATEGORY")
		ACp.AycYear = d4field(f20, "YEAR")
		ACp.AycTotal = d4field(f20, "TOTAL")
		ACp.AycPPbi = d4field(f20, "PPBI")
		ACp.AycPPpd = d4field(f20, "PPPD")
		ACp.AycPPmed = d4field(f20, "PPMED")
		ACp.AycPPumbi = d4field(f20, "PPUMBI")
		ACp.AycPPumpd = d4field(f20, "PPUMPD")
		ACp.AycPPpip = d4field(f20, "PPPIP")
		ACp.AycPPcomp = d4field(f20, "PPCOMP")
		ACp.AycPPcoll = d4field(f20, "PPCOLL")
		ACp.AycPPrent = d4field(f20, "PPRENT")
		ACp.AycPPtow = d4field(f20, "PPTOW")
		ACp.AycCMbi = d4field(f20, "CMBI")
		ACp.AycCMpd = d4field(f20, "CMPD")
		ACp.AycCMmed = d4field(f20, "CMMED")
		ACp.AycCMumbi = d4field(f20, "CMUMBI")
		ACp.AycCMumpd = d4field(f20, "CMUMPD")
		ACp.AycCMpip = d4field(f20, "CMPIP")
		ACp.AycCMcomp = d4field(f20, "CMCOMP")
		ACp.AycCMcoll = d4field(f20, "CMCOLL")
		ACp.AycCMrent = d4field(f20, "CMRENT")
		ACp.AycCMtow = d4field(f20, "CMTOW")
		ACp.AycOTim = d4field(f20, "IM")
		ACp.AycOTallied = d4field(f20, "ALLIED")
		ACp.AycOTfire = d4field(f20, "FIRE")
		ACp.AycOTmulti = d4field(f20, "MULTIPERIL")
	End Sub
	
	Public Sub GetAyCedVar()
		txRptMgaNmbr = Trim(f4str(ACp.AycMgaNmbr))
		txRptTrtyNmbr = Trim(f4str(ACp.AycTrtyNmbr))
		txRptPeriod = Trim(f4str(ACp.AycPeriod))
		txRptCatCode = Trim(f4str(ACp.AycCatCode))
		txRptYear = Trim(f4str(ACp.AycYear))
		
		MLobt = f4double(ACp.AycTotal)
		MLobp(1) = f4double(ACp.AycPPbi)
		MLobp(2) = f4double(ACp.AycPPpd)
		MLobp(3) = f4double(ACp.AycPPmed)
		MLobp(4) = f4double(ACp.AycPPumbi)
		MLobp(5) = f4double(ACp.AycPPumpd)
		MLobp(6) = f4double(ACp.AycPPpip)
		MLobp(7) = f4double(ACp.AycPPcomp)
		MLobp(8) = f4double(ACp.AycPPcoll)
		MLobp(9) = f4double(ACp.AycPPrent)
		MLobp(10) = f4double(ACp.AycPPtow)
		MLobp(11) = f4double(ACp.AycCMbi)
		MLobp(12) = f4double(ACp.AycCMpd)
		MLobp(13) = f4double(ACp.AycCMmed)
		MLobp(14) = f4double(ACp.AycCMumbi)
		MLobp(15) = f4double(ACp.AycCMumpd)
		MLobp(16) = f4double(ACp.AycCMpip)
		MLobp(17) = f4double(ACp.AycCMcomp)
		MLobp(18) = f4double(ACp.AycCMcoll)
		MLobp(19) = f4double(ACp.AycCMrent)
		MLobp(20) = f4double(ACp.AycCMtow)
		MLobp(21) = f4double(ACp.AycOTim)
		MLobp(22) = f4double(ACp.AycOTallied)
		MLobp(23) = f4double(ACp.AycOTfire)
		MLobp(24) = f4double(ACp.AycOTmulti)
	End Sub
	
	Public Sub UpAyCedFlds()
		Call f4assign(ACp.AycMgaNmbr, txRptMgaNmbr)
		Call f4assign(ACp.AycTrtyNmbr, txRptTrtyNmbr)
		Call f4assign(ACp.AycPeriod, txRptPeriod)
		Call f4assign(ACp.AycCatCode, txRptCatCode)
		Call f4assign(ACp.AycYear, txRptYear)
		Call f4assignDouble(ACp.AycTotal, MLobt)
		Call f4assignDouble(ACp.AycPPbi, MLobp(1))
		Call f4assignDouble(ACp.AycPPpd, MLobp(2))
		Call f4assignDouble(ACp.AycPPmed, MLobp(3))
		Call f4assignDouble(ACp.AycPPumbi, MLobp(4))
		Call f4assignDouble(ACp.AycPPumpd, MLobp(5))
		Call f4assignDouble(ACp.AycPPpip, MLobp(6))
		Call f4assignDouble(ACp.AycPPcomp, MLobp(7))
		Call f4assignDouble(ACp.AycPPcoll, MLobp(8))
		Call f4assignDouble(ACp.AycPPrent, MLobp(9))
		Call f4assignDouble(ACp.AycPPtow, MLobp(10))
		Call f4assignDouble(ACp.AycCMbi, MLobp(11))
		Call f4assignDouble(ACp.AycCMpd, MLobp(12))
		Call f4assignDouble(ACp.AycCMmed, MLobp(13))
		Call f4assignDouble(ACp.AycCMumbi, MLobp(14))
		Call f4assignDouble(ACp.AycCMumpd, MLobp(15))
		Call f4assignDouble(ACp.AycCMpip, MLobp(16))
		Call f4assignDouble(ACp.AycCMcomp, MLobp(17))
		Call f4assignDouble(ACp.AycCMcoll, MLobp(18))
		Call f4assignDouble(ACp.AycCMrent, MLobp(19))
		Call f4assignDouble(ACp.AycCMtow, MLobp(20))
		Call f4assignDouble(ACp.AycOTim, MLobp(21))
		Call f4assignDouble(ACp.AycOTallied, MLobp(22))
		Call f4assignDouble(ACp.AycOTfire, MLobp(23))
		Call f4assignDouble(ACp.AycOTmulti, MLobp(24))
	End Sub
	
	Public Sub AddAyCedRec()
		If Not ValUser Then Exit Sub
		AddTran = True
		
		If d4appendStart(f20, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpAyCedFlds()
		rc = d4append(f20)
		rc = d4unlock(f20)
	End Sub
	
	Public Sub UpAyCedRec()
		If Not ValUser Then Exit Sub
		UpAyCedFlds()
		rc = d4unlock(f20)
	End Sub
	
	Public Sub GetAyCedRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f20, d4tag(f20, "K1"))
		rc = d4seek(f20, RptDirKey)
		
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f20, d4recNo(f20))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetAyCedVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelAyCedRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f20)
		Call d4blank(f20)
	End Sub
End Module