Option Strict Off
Option Explicit On
Module fileMgaChkLst
	
	'Form Treaty PRM Work Vars
	Public txChkMgaNmbr As String
	Public txChkTrtyNmbr As String
	Public txChkPeriod As String
	Public txChkDate As String
	Public chChkFinal As Short
	Public chChkReiRpt As Short
	
	'FIELD4 structure pointers -- (ReiMST)
	Public Structure PtrChkLst
		Dim ChkMgaNmbr As Integer
		Dim ChkTrtyNmbr As Integer
		Dim ChkPeriod As Integer
		Dim ChkDate As Integer
		Dim CkFinal As Integer
		Dim CkReiRpt As Integer
	End Structure
	Public CKp As PtrChkLst
	
	Public Sub GetChkLstPtr()
		CKp.ChkMgaNmbr = d4field(f40, "MGANMBR")
		CKp.ChkTrtyNmbr = d4field(f40, "TRTYNMBR")
		CKp.ChkPeriod = d4field(f40, "PERIOD")
		CKp.ChkDate = d4field(f40, "RECV DATE")
		CKp.CkFinal = d4field(f40, "FINAL CHK")
		CKp.CkReiRpt = d4field(f40, "REI RPT")
	End Sub
	
	Public Sub GetChkLstVar()
		txChkMgaNmbr = Trim(f4str(CKp.ChkMgaNmbr))
		txChkTrtyNmbr = Trim(f4str(CKp.ChkTrtyNmbr))
		txChkPeriod = Trim(f4str(CKp.ChkPeriod))
        txChkDate = Pdate(f4str(CKp.ChkDate))
		chChkFinal = f4int(CKp.CkFinal)
		chChkReiRpt = f4int(CKp.CkReiRpt)
	End Sub
	
	Public Sub UpChkLstFlds()
		Call f4assign(CKp.ChkMgaNmbr, txChkMgaNmbr)
		Call f4assign(CKp.ChkTrtyNmbr, txChkTrtyNmbr)
		Call f4assign(CKp.ChkPeriod, txChkPeriod)
		Call f4assign(CKp.ChkDate, Mid(txChkDate, 1, 2) & Mid(txChkDate, 4, 2) & Mid(txChkDate, 7, 4))
		Call f4assignInt(CKp.CkFinal, chChkFinal)
		Call f4assignInt(CKp.CkReiRpt, chChkReiRpt)
	End Sub
	
	Public Sub AddChkLstRec()
		AddTran = True
		
		If d4appendStart(f40, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpChkLstFlds()
		rc = d4append(f40)
		rc = d4unlock(f40)
	End Sub
	
	Public Sub UpChkLstRec()
		UpChkLstFlds()
		rc = d4unlock(f40)
		rc = d4bottom(f40)
	End Sub
	
	Public Sub GetChkLstRec()
		UpdateTran = False
		AddTran = False
		Call d4tagSelect(f40, d4tag(f40, "K1"))
		rc = d4seek(f40, ChkLstKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f40, d4recNo(f40))
		If rc = r4locked Then
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetChkLstVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelChkLstRec()
		rc = d4unlock(f40)
		Call d4blank(f40)
	End Sub
End Module