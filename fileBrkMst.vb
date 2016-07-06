Option Strict Off
Option Explicit On
Module fileBrkMst
	
	Public txBrkNmbr As String
	Public chBrkType As Short
	Public txBrkTaxId As String
	Public txBrkName As String
	Public txBrkDesc As String
	Public txBrkContact As String
	Public txBrkPhone As String
	Public txBrkEmail As String
	Public txBrkAddr1 As String
	Public txBrkAddr2 As String
	
	'FIELD4 structure pointers -- (BrkMST)
	Public Structure PtrBrk
		Dim BrkNmbr As Integer
		Dim BrkType As Integer
		Dim BrkTaxId As Integer
		Dim BrkName As Integer
		Dim BrkDesc As Integer
		Dim BrkContact As Integer
		Dim BrkEmail As Integer
		Dim BrkPhone As Integer
		Dim BrkAddr1 As Integer
		Dim BrkAddr2 As Integer
	End Structure
	Public BKp As PtrBrk
	
	Public Sub GetBrkMstPtr()
		BKp.BrkNmbr = d4field(f35, "BNMBR")
		BKp.BrkType = d4field(f35, "TYPE")
		BKp.BrkTaxId = d4field(f35, "TAXID")
		BKp.BrkName = d4field(f35, "NAME")
		BKp.BrkDesc = d4field(f35, "DESC")
		BKp.BrkContact = d4field(f35, "CONTACT")
		BKp.BrkEmail = d4field(f35, "EMAIL")
		BKp.BrkPhone = d4field(f35, "PHONE")
		BKp.BrkAddr1 = d4field(f35, "ADDR1")
		BKp.BrkAddr2 = d4field(f35, "ADDR2")
	End Sub
	
	Public Sub GetBrkMstVar()
		txBrkNmbr = f4str(BKp.BrkNmbr)
		chBrkType = f4int(BKp.BrkType)
		txBrkTaxId = f4str(BKp.BrkTaxId)
		txBrkName = f4str(BKp.BrkName)
		txBrkDesc = f4str(BKp.BrkDesc)
		txBrkContact = f4str(BKp.BrkContact)
		txBrkEmail = f4str(BKp.BrkEmail)
		txBrkPhone = f4str(BKp.BrkPhone)
		txBrkAddr1 = f4str(BKp.BrkAddr1)
		txBrkAddr2 = f4str(BKp.BrkAddr2)
	End Sub
	
	Public Sub UpBrkMstFlds()
		Call f4assign(BKp.BrkNmbr, Trim(txBrkNmbr))
		Call f4assignInt(BKp.BrkType, chBrkType)
		Call f4assign(BKp.BrkTaxId, Trim(txBrkTaxId))
		Call f4assign(BKp.BrkName, Trim(txBrkName))
		Call f4assign(BKp.BrkDesc, Trim(txBrkDesc))
		Call f4assign(BKp.BrkContact, Trim(txBrkContact))
		Call f4assign(BKp.BrkEmail, Trim(txBrkEmail))
		Call f4assign(BKp.BrkPhone, Trim(txBrkPhone))
		Call f4assign(BKp.BrkAddr1, Trim(txBrkAddr1))
		Call f4assign(BKp.BrkAddr2, Trim(txBrkAddr2))
	End Sub
	
	Public Sub AddBrkMstRec()
		If Not ValUser Then Exit Sub
		AddTran = True
		
		If d4appendStart(f35, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpBrkMstFlds()
		rc = d4append(f35)
		rc = d4unlock(f35)
	End Sub
	
	Public Sub UpBrkMstRec()
		If Not ValUser Then Exit Sub
		Call UpBrkMstFlds()
		rc = d4unlock(f35)
	End Sub
	
	Public Sub GetBrkMstRec()
		UpdateTran = False
		AddTran = False
		Call d4tagSelect(f35, d4tag(f35, "K1"))
		rc = d4seek(f35, BrkKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f35, d4recNo(f35))
		If rc = r4locked Then
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetBrkMstVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelBrkMstRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f35)
		Call d4blank(f35)
	End Sub
End Module