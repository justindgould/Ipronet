Option Strict Off
Option Explicit On
Module fileIbnrPrm
	
	Public txIbnrMgaNmbr As String
	Public txIbnrTrtyNmbr As String
	Public txIbnrPeriod As String
	Public txIbnrYear As String
	Public txIbnrLossPBfact As String
	Public txIbnrLossPMfact As String
	Public txIbnrLossCBfact As String
	Public txIbnrLossCMfact As String
	Public txIbnrLossOTfact As String
	Public txIbnrLaePBfact As String
	Public txIbnrLaePMfact As String
	Public txIbnrLaeCBfact As String
	Public txIbnrLaeCMfact As String
	Public txIbnrLaeOTfact As String
	Public IbnrPrmKey As String
	
	'FIELD4 structure pointers -- (IBNRPRM)
	Public Structure PtrIbnrPrm
		Dim IbnrMgaNmbr As Integer
		Dim IbnrTrtyNmbr As Integer
		Dim IbnrPeriod As Integer
		Dim IbnrYear As Integer
		Dim IbnrLossPBfact As Integer
		Dim IbnrLossPMfact As Integer
		Dim IbnrLossCBfact As Integer
		Dim IbnrLossCMfact As Integer
		Dim IbnrLossOTfact As Integer
		Dim IbnrLaePBfact As Integer
		Dim IbnrLaePMfact As Integer
		Dim IbnrLaeCBfact As Integer
		Dim IbnrLaeCMfact As Integer
		Dim IbnrLaeOTfact As Integer
	End Structure
	Public IFp As PtrIbnrPrm
	
	Public Sub GetIbnrPrmPtr()
		IFp.IbnrMgaNmbr = d4field(f25, "MGANMBR")
		IFp.IbnrTrtyNmbr = d4field(f25, "TRTYNMBR")
		IFp.IbnrPeriod = d4field(f25, "PERIOD")
		IFp.IbnrYear = d4field(f25, "YEAR")
		IFp.IbnrLossPBfact = d4field(f25, "PB LOSS")
		IFp.IbnrLossPMfact = d4field(f25, "PM LOSS")
		IFp.IbnrLossCBfact = d4field(f25, "CB LOSS")
		IFp.IbnrLossCMfact = d4field(f25, "CM LOSS")
		IFp.IbnrLossOTfact = d4field(f25, "OT LOSS")
		IFp.IbnrLaePBfact = d4field(f25, "PB LAE")
		IFp.IbnrLaePMfact = d4field(f25, "PM LAE")
		IFp.IbnrLaeCBfact = d4field(f25, "CB LAE")
		IFp.IbnrLaeCMfact = d4field(f25, "CM LAE")
		IFp.IbnrLaeOTfact = d4field(f25, "OT LAE")
	End Sub
	
	Public Sub GetIbnrPrmVar()
		txIbnrMgaNmbr = Trim(f4str(IFp.IbnrMgaNmbr))
		txIbnrTrtyNmbr = Trim(f4str(IFp.IbnrTrtyNmbr))
		txIbnrPeriod = Trim(f4str(IFp.IbnrPeriod))
		txIbnrYear = Trim(f4str(IFp.IbnrYear))
        txIbnrLossPBfact = Format(f4double(IFp.IbnrLossPBfact), "#.000000")
        txIbnrLossPMfact = Format(f4double(IFp.IbnrLossPMfact), "#.000000")
        txIbnrLossCBfact = Format(f4double(IFp.IbnrLossCBfact), "#.000000")
        txIbnrLossCMfact = Format(f4double(IFp.IbnrLossCMfact), "#.000000")
        txIbnrLossOTfact = Format(f4double(IFp.IbnrLossOTfact), "#.000000")
        txIbnrLaePBfact = Format(f4double(IFp.IbnrLaePBfact), "#.000000")
        txIbnrLaePMfact = Format(f4double(IFp.IbnrLaePMfact), "#.000000")
        txIbnrLaeCBfact = Format(f4double(IFp.IbnrLaeCBfact), "#.000000")
        txIbnrLaeCMfact = Format(f4double(IFp.IbnrLaeCMfact), "#.000000")
        txIbnrLaeOTfact = Format(f4double(IFp.IbnrLaeOTfact), "#.000000")
	End Sub
	
	Public Sub UpIbnrPrmFlds()
		Call f4assign(IFp.IbnrMgaNmbr, txIbnrMgaNmbr)
		Call f4assign(IFp.IbnrTrtyNmbr, txIbnrTrtyNmbr)
		Call f4assign(IFp.IbnrPeriod, txIbnrPeriod)
		Call f4assign(IFp.IbnrYear, txIbnrYear)
		Call f4assignDouble(IFp.IbnrLossPBfact, Val(Trim(txIbnrLossPBfact)))
		Call f4assignDouble(IFp.IbnrLossPMfact, Val(Trim(txIbnrLossPMfact)))
		Call f4assignDouble(IFp.IbnrLossCBfact, Val(Trim(txIbnrLossCBfact)))
		Call f4assignDouble(IFp.IbnrLossCMfact, Val(Trim(txIbnrLossCMfact)))
		Call f4assignDouble(IFp.IbnrLossOTfact, Val(Trim(txIbnrLossOTfact)))
		Call f4assignDouble(IFp.IbnrLaePBfact, Val(Trim(txIbnrLaePBfact)))
		Call f4assignDouble(IFp.IbnrLaePMfact, Val(Trim(txIbnrLaePMfact)))
		Call f4assignDouble(IFp.IbnrLaeCBfact, Val(Trim(txIbnrLaeCBfact)))
		Call f4assignDouble(IFp.IbnrLaeCMfact, Val(Trim(txIbnrLaeCMfact)))
		Call f4assignDouble(IFp.IbnrLaeOTfact, Val(Trim(txIbnrLaeOTfact)))
	End Sub
	
	Public Sub AddIbnrPrmRec()
		If Not ValUser Then Exit Sub
		AddTran = True
		
		If d4appendStart(f25, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpIbnrPrmFlds()
		rc = d4append(f25)
		rc = d4unlock(f25)
	End Sub
	
	Public Sub UpIbnrPrmRec()
		If Not ValUser Then Exit Sub
		UpIbnrPrmFlds()
		rc = d4unlock(f25)
	End Sub
	
	Public Sub GetIbnrPrmRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f25, d4tag(f25, "K1"))
		rc = d4seek(f25, IbnrPrmKey)
		
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f25, d4recNo(f25))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetIbnrPrmVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelIbnrPrmRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f25)
		Call d4blank(f25)
	End Sub
End Module