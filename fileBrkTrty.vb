Option Strict Off
Option Explicit On
Module fileBrkTrty
	
	'Form Broker Treaty Work Vars
	Public txBrkMgaNmbr As String
	Public txBrkTrtyNmbr As String
	Public txBrkNmbrAssigned As String
	Public txBrkTrtyEffDate As String
	Public txBrkCcDueDate As String
	Public txBrkStatus As String
	Public txBrkTrtyDesc As String
	
	'FIELD4 structure pointers -- (BrkTrty)
	Public Structure PtrBrkTrty
		Dim BrkMgaNmbr As Integer
		Dim BrkTrtyNmbr As Integer
		Dim BrkNmbrAssigned As Integer
		Dim BrkTrtyEffDate As Integer
		Dim BrkCcDueDate As Integer
		Dim BrkStatus As Integer
		Dim BrkTrtyDesc As Integer
	End Structure
	Public BTp As PtrBrkTrty
	
	Public Sub GetBrkTrtyPtr()
		BTp.BrkMgaNmbr = d4field(f36, "MGANMBR")
		BTp.BrkTrtyNmbr = d4field(f36, "TRTYNMBR")
		BTp.BrkNmbrAssigned = d4field(f36, "BRKNMBR")
		BTp.BrkTrtyEffDate = d4field(f36, "TRTYEFDT")
		BTp.BrkCcDueDate = d4field(f36, "CCDUEDT")
		BTp.BrkStatus = d4field(f36, "STATUS")
		BTp.BrkTrtyDesc = d4field(f36, "DESC")
	End Sub
	
	Public Sub GetBrkTrtyVar()
		Dim D As String
		
		txBrkMgaNmbr = Trim(f4str(BTp.BrkMgaNmbr))
		txBrkTrtyNmbr = Trim(f4str(BTp.BrkTrtyNmbr))
		txBrkNmbrAssigned = Trim(f4str(BTp.BrkNmbrAssigned))
		D = Trim(f4str(BTp.BrkTrtyEffDate))
		txBrkTrtyEffDate = Mid(D, 5, 2) & Mid(D, 7, 2) & Mid(D, 1, 4)
		D = Trim(f4str(BTp.BrkCcDueDate))
		txBrkCcDueDate = Mid(D, 5, 2) & Mid(D, 7, 2) & Mid(D, 1, 4)
		txBrkStatus = Trim(f4str(BTp.BrkStatus))
		txBrkTrtyDesc = Trim(f4str(BTp.BrkTrtyDesc))
	End Sub
	
	Public Sub UpBrkTrtyFlds()
		Dim D As String
		
		Call f4assign(BTp.BrkMgaNmbr, txBrkMgaNmbr)
		Call f4assign(BTp.BrkTrtyNmbr, txBrkTrtyNmbr)
		Call f4assign(BTp.BrkNmbrAssigned, txBrkNmbrAssigned)
		D = txBrkTrtyEffDate
		Call f4assign(BTp.BrkTrtyEffDate, Mid(D, 5, 4) & Mid(D, 1, 2) & Mid(D, 3, 2))
		D = txBrkCcDueDate
		Call f4assign(BTp.BrkCcDueDate, Mid(D, 5, 4) & Mid(D, 1, 2) & Mid(D, 3, 2))
		Call f4assign(BTp.BrkStatus, txBrkStatus)
		Call f4assign(BTp.BrkTrtyDesc, txBrkTrtyDesc)
	End Sub
	
	Public Sub AddBrkTrtyRec()
		If Not ValUser Then Exit Sub
		AddTran = True
		
		If d4appendStart(f36, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpBrkTrtyFlds()
		rc = d4append(f36)
		rc = d4unlock(f36)
	End Sub
	
	Public Sub UpBrkTrtyRec()
		If Not ValUser Then Exit Sub
		UpBrkTrtyFlds()
		rc = d4unlock(f36)
	End Sub
	
	Public Sub GetBrkTrtyRec()
		UpdateTran = False
		AddTran = False
		Call d4tagSelect(f36, d4tag(f36, "K1"))
		rc = d4seek(f36, BrkTrtyKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f36, d4recNo(f36))
		If rc = r4locked Then
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetBrkTrtyVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelBrkTrtyRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f36)
		Call d4blank(f36)
	End Sub
End Module