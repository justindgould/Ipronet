Option Strict Off
Option Explicit On
Module fileGlMgaRef
	
	'Form GL MGA REF Work Vars
	Public txGlMgaNmbr As String
	Public txAgtRec As String
	Public txReiPay As String
	Public txLossRec As String
	Public txLaeRec As String
	Public txAgtBalNotDue As String
	Public txReiPayNotDue As String
	Public txAgtRecDesc As String
	Public txReiPayDesc As String
	Public txLossRecDesc As String
	Public txLaeRecDesc As String
	Public txAgtBalNotDueDesc As String
	Public txReiPayNotDueDesc As String
	
	'FIELD4 structure pointers -- (RptDir)
	Public Structure PtrGlMga
		Dim GlGlMgaNmbr As Integer
		Dim GlAgtRec As Integer
		Dim GlReiPay As Integer
		Dim GlLossRec As Integer
		Dim GlLaeRec As Integer
		Dim GlAgtBalNotDue As Integer
		Dim GlReiPayNotDue As Integer
		Dim GlAgtRecDesc As Integer
		Dim GlReiPayDesc As Integer
		Dim GlLossRecDesc As Integer
		Dim GlLaeRecDesc As Integer
		Dim GlAgtBalNotDueDesc As Integer
		Dim GlReiPayNotDueDesc As Integer
	End Structure
	Public GMp As PtrGlMga
	
	Public Sub GetGlMgaRefPtr()
		GMp.GlGlMgaNmbr = d4field(f50, "MGANMBR")
		GMp.GlAgtRec = d4field(f50, "GL AR")
		GMp.GlReiPay = d4field(f50, "GL RP")
		GMp.GlLossRec = d4field(f50, "GL LS")
		GMp.GlLaeRec = d4field(f50, "GL LE")
		GMp.GlAgtBalNotDue = d4field(f50, "GL AD")
		GMp.GlReiPayNotDue = d4field(f50, "GL RD")
		GMp.GlAgtRecDesc = d4field(f50, "GL AR DESC")
		GMp.GlReiPayDesc = d4field(f50, "GL RP DESC")
		GMp.GlLossRecDesc = d4field(f50, "GL LS DESC")
		GMp.GlLaeRecDesc = d4field(f50, "GL LE DESC")
		GMp.GlAgtBalNotDueDesc = d4field(f50, "GL AD DESC")
		GMp.GlReiPayNotDueDesc = d4field(f50, "GL RD DESC")
	End Sub
	
	Public Sub GetGlMgaRefVar()
		txGlMgaNmbr = Trim(f4str(GMp.GlGlMgaNmbr))
		txAgtRec = Trim(f4str(GMp.GlAgtRec))
		txReiPay = Trim(f4str(GMp.GlReiPay))
		txLossRec = Trim(f4str(GMp.GlLossRec))
		txLaeRec = Trim(f4str(GMp.GlLaeRec))
		txAgtBalNotDue = Trim(f4str(GMp.GlAgtBalNotDue))
		txReiPayNotDue = Trim(f4str(GMp.GlReiPayNotDue))
		txAgtRecDesc = Trim(f4str(GMp.GlAgtRecDesc))
		txReiPayDesc = Trim(f4str(GMp.GlReiPayDesc))
		txLossRecDesc = Trim(f4str(GMp.GlLossRecDesc))
		txLaeRecDesc = Trim(f4str(GMp.GlLaeRecDesc))
		txAgtBalNotDueDesc = Trim(f4str(GMp.GlAgtBalNotDueDesc))
		txReiPayNotDueDesc = Trim(f4str(GMp.GlReiPayNotDueDesc))
	End Sub
	
	Public Sub UpGlMgaRefFlds()
		Call f4assign(GMp.GlGlMgaNmbr, txGlMgaNmbr)
		Call f4assign(GMp.GlAgtRec, txAgtRec)
		Call f4assign(GMp.GlReiPay, txReiPay)
		Call f4assign(GMp.GlLossRec, txLossRec)
		Call f4assign(GMp.GlLaeRec, txLaeRec)
		Call f4assign(GMp.GlAgtBalNotDue, txAgtBalNotDue)
		Call f4assign(GMp.GlReiPayNotDue, txReiPayNotDue)
		Call f4assign(GMp.GlAgtRecDesc, txAgtRecDesc)
		Call f4assign(GMp.GlReiPayDesc, txReiPayDesc)
		Call f4assign(GMp.GlLossRecDesc, txLossRecDesc)
		Call f4assign(GMp.GlLaeRecDesc, txLaeRecDesc)
		Call f4assign(GMp.GlAgtBalNotDueDesc, txAgtBalNotDueDesc)
		Call f4assign(GMp.GlReiPayNotDueDesc, txReiPayNotDueDesc)
	End Sub
	
	Public Sub AddGlMgaRefRec()
		If Not ValUser Then Exit Sub
		AddTran = True
		
		If d4appendStart(f50, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpGlMgaRefFlds()
		rc = d4append(f50)
		rc = d4unlock(f50)
	End Sub
	
	Public Sub UpGlMgaRefRec()
		If Not ValUser Then Exit Sub
		UpGlMgaRefFlds()
		rc = d4unlock(f50)
	End Sub
	
	Public Sub GetGlMgaRefRec()
		UpdateTran = False
		AddTran = False
		Fstat = 0
		Call d4tagSelect(f50, d4tag(f50, "K1"))
		rc = d4seek(f50, MgaKey)
		
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f50, d4recNo(f50))
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetGlMgaRefVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelGlMgaRefRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f50)
		Call d4blank(f50)
	End Sub
End Module