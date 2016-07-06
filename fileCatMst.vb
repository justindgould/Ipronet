Option Strict Off
Option Explicit On
Module fileCatMst
	
	'Form Cat Maintenance Work Vars
	Public txCatCode As String
	Public txCatDesc As String
	
	
	'FIELD4 structure pointers -- (ReiMST)
	Public Structure PtrCatMst
		Dim CatCode As Integer
		Dim CatDesc As Integer
	End Structure
	Public CMp As PtrCatMst
	
	Sub GetCatMstPtr()
		CMp.CatCode = d4field(f91, "CATCODE")
		CMp.CatDesc = d4field(f91, "DESC")
	End Sub
	
	Sub GetCatMstVar()
		txCatCode = Trim(f4str(CMp.CatCode))
		txCatDesc = Trim(f4str(CMp.CatDesc))
	End Sub
	
	Sub UpCatMstFlds()
		Call f4assign(CMp.CatCode, txCatCode)
		Call f4assign(CMp.CatDesc, txCatDesc)
	End Sub
	
	Sub AddCatMstRec()
		If Not ValUser Then Exit Sub
		
		AddTran = True
		
		If d4appendStart(f91, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpCatMstFlds()
		rc = d4append(f91)
		rc = d4unlock(f91)
	End Sub
	
	Sub UpCatMstRec()
		If Not ValUser Then Exit Sub
		UpCatMstFlds()
		rc = d4unlock(f91)
	End Sub
	
	Sub GetCatMstRec()
		Fstat = 0
		UpdateTran = False
		AddTran = False
		Call d4tagSelect(f91, d4tag(f91, "K1"))
		rc = d4seek(f91, CatKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f91, d4recNo(f91))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetCatMstVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelCatMstRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f91)
		Call d4blank(f91)
	End Sub
End Module