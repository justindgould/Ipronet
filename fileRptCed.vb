Option Strict Off
Option Explicit On
Module fileRptCed
	
	Public txCedMgaNmbr As String
	Public txCedTrtyNmbr As String
	Public txCedPeriod As String
	Public txCedCatCode As String
	Public txCedYear As String
	
	'FIELD4 structure pointers -- (RptCed)
	Public Structure PtrRptCed
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
	Public Rc1p As PtrRptCed
	
	Public Sub GetRptCedPtr()
		Rc1p.CedMgaNmbr = d4field(f6, "MGANMBR")
		Rc1p.CedTrtyNmbr = d4field(f6, "TRTYNMBR")
		Rc1p.CedPeriod = d4field(f6, "PERIOD")
		Rc1p.CedCatCode = d4field(f6, "CATEGORY")
		Rc1p.CedYear = d4field(f6, "YEAR")
		Rc1p.CedTotal = d4field(f6, "TOTAL")
		Rc1p.CedPPbi = d4field(f6, "PPBI")
		Rc1p.CedPPpd = d4field(f6, "PPPD")
		Rc1p.CedPPmed = d4field(f6, "PPMED")
		Rc1p.CedPPumbi = d4field(f6, "PPUMBI")
		Rc1p.CedPPumpd = d4field(f6, "PPUMPD")
		Rc1p.CedPPpip = d4field(f6, "PPPIP")
		Rc1p.CedPPcomp = d4field(f6, "PPCOMP")
		Rc1p.CedPPcoll = d4field(f6, "PPCOLL")
		Rc1p.CedPPrent = d4field(f6, "PPRENT")
		Rc1p.CedPPtow = d4field(f6, "PPTOW")
		Rc1p.CedCMbi = d4field(f6, "CMBI")
		Rc1p.CedCMpd = d4field(f6, "CMPD")
		Rc1p.CedCMmed = d4field(f6, "CMMED")
		Rc1p.CedCMumbi = d4field(f6, "CMUMBI")
		Rc1p.CedCMumpd = d4field(f6, "CMUMPD")
		Rc1p.CedCMpip = d4field(f6, "CMPIP")
		Rc1p.CedCMcomp = d4field(f6, "CMCOMP")
		Rc1p.CedCMcoll = d4field(f6, "CMCOLL")
		Rc1p.CedCMrent = d4field(f6, "CMRENT")
		Rc1p.CedCMtow = d4field(f6, "CMTOW")
		Rc1p.CedOTim = d4field(f6, "IM")
		Rc1p.CedOTallied = d4field(f6, "ALLIED")
		Rc1p.CedOTfire = d4field(f6, "FIRE")
		Rc1p.CedOTmulti = d4field(f6, "MULTIPERIL")
	End Sub
	
	Public Sub GetRptCedVar()
        System.Array.Clear(MLobp, 0, MLobp.Length)
		MLobt = f4double(Rc1p.CedTotal)
		MLobp(1) = f4double(Rc1p.CedPPbi)
		MLobp(2) = f4double(Rc1p.CedPPpd)
		MLobp(3) = f4double(Rc1p.CedPPmed)
		MLobp(4) = f4double(Rc1p.CedPPumbi)
		MLobp(5) = f4double(Rc1p.CedPPumpd)
		MLobp(6) = f4double(Rc1p.CedPPpip)
		MLobp(7) = f4double(Rc1p.CedPPcomp)
		MLobp(8) = f4double(Rc1p.CedPPcoll)
		MLobp(9) = f4double(Rc1p.CedPPrent)
		MLobp(10) = f4double(Rc1p.CedPPtow)
		MLobp(11) = f4double(Rc1p.CedCMbi)
		MLobp(12) = f4double(Rc1p.CedCMpd)
		MLobp(13) = f4double(Rc1p.CedCMmed)
		MLobp(14) = f4double(Rc1p.CedCMumbi)
		MLobp(15) = f4double(Rc1p.CedCMumpd)
		MLobp(16) = f4double(Rc1p.CedCMpip)
		MLobp(17) = f4double(Rc1p.CedCMcomp)
		MLobp(18) = f4double(Rc1p.CedCMcoll)
		MLobp(19) = f4double(Rc1p.CedCMrent)
		MLobp(20) = f4double(Rc1p.CedCMtow)
		MLobp(21) = f4double(Rc1p.CedOTim)
		MLobp(22) = f4double(Rc1p.CedOTallied)
		MLobp(23) = f4double(Rc1p.CedOTfire)
		MLobp(24) = f4double(Rc1p.CedOTmulti)
	End Sub
	
	Public Sub UpRptCedFlds()
		Call f4assign(Rc1p.CedMgaNmbr, txCedMgaNmbr)
		Call f4assign(Rc1p.CedTrtyNmbr, txCedTrtyNmbr)
		Call f4assign(Rc1p.CedPeriod, txCedPeriod)
		Call f4assign(Rc1p.CedCatCode, txCedCatCode)
		Call f4assign(Rc1p.CedYear, txCedYear)
		Call f4assignDouble(Rc1p.CedTotal, MLobt)
		Call f4assignDouble(Rc1p.CedPPbi, MLobp(1))
		Call f4assignDouble(Rc1p.CedPPpd, MLobp(2))
		Call f4assignDouble(Rc1p.CedPPmed, MLobp(3))
		Call f4assignDouble(Rc1p.CedPPumbi, MLobp(4))
		Call f4assignDouble(Rc1p.CedPPumpd, MLobp(5))
		Call f4assignDouble(Rc1p.CedPPpip, MLobp(6))
		Call f4assignDouble(Rc1p.CedPPcomp, MLobp(7))
		Call f4assignDouble(Rc1p.CedPPcoll, MLobp(8))
		Call f4assignDouble(Rc1p.CedPPrent, MLobp(9))
		Call f4assignDouble(Rc1p.CedPPtow, MLobp(10))
		Call f4assignDouble(Rc1p.CedCMbi, MLobp(11))
		Call f4assignDouble(Rc1p.CedCMpd, MLobp(12))
		Call f4assignDouble(Rc1p.CedCMmed, MLobp(13))
		Call f4assignDouble(Rc1p.CedCMumbi, MLobp(14))
		Call f4assignDouble(Rc1p.CedCMumpd, MLobp(15))
		Call f4assignDouble(Rc1p.CedCMpip, MLobp(16))
		Call f4assignDouble(Rc1p.CedCMcomp, MLobp(17))
		Call f4assignDouble(Rc1p.CedCMcoll, MLobp(18))
		Call f4assignDouble(Rc1p.CedCMrent, MLobp(19))
		Call f4assignDouble(Rc1p.CedCMtow, MLobp(20))
		Call f4assignDouble(Rc1p.CedOTim, MLobp(21))
		Call f4assignDouble(Rc1p.CedOTallied, MLobp(22))
		Call f4assignDouble(Rc1p.CedOTfire, MLobp(23))
		Call f4assignDouble(Rc1p.CedOTmulti, MLobp(24))
	End Sub
	
	Public Sub GetRptCedRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f6, d4tag(f6, "K1"))
		rc = d4seek(f6, RptCedKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f6, d4recNo(f6))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetRptCedVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelRptCedRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f6)
		Call d4blank(f6)
	End Sub
	
	Public Sub AddRptCedRec()
		AddTran = True
		
		If d4appendStart(f6, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpRptCedFlds()
		rc = d4append(f6)
		rc = d4unlock(f6)
	End Sub
	
	Public Sub UpRptCedRec()
		UpRptCedFlds()
		rc = d4unlock(f6)
	End Sub
End Module