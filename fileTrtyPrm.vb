Option Strict Off
Option Explicit On
Module fileTrtyPrm
	
	'Form Treaty PRM Work Vars
	Public txPrmTrtyNmbr As String
	Public txPrmMgaNmbr As String
	Public txPrmConNmbr As String
	Public txPrmIncpDate As String
	Public txPrmReiRptFlag As String
	Public txPrmRptName As String
	Public txPrmStatus As String
	Public txPrmDesc As String
	Public txPrmGrpID As String
	Public txPrmLaeRec As String
	Public txPrmLossRec As String
	Public txPrmReiPay As String
	Public txPrmReiPayNotDue As String
	Public txPrmStateCode As String
	Public txPrmAgtBalNotDue As String
	Public txPrmAgtRec As String
	
	'FIELD4 structure pointers -- (ReiMST)
	Public Structure PtrTrtyPrm
		Dim PrmTrtyNmbr As Integer
		Dim PrmMgaNmbr As Integer
		Dim PrmConNmbr As Integer
		Dim PrmIncpDate As Integer
		Dim PrmReiRptFlag As Integer
		Dim PrmRptName As Integer
		Dim PrmStatus As Integer
		Dim PrmDesc As Integer
		Dim PrmGrpID As Integer
		Dim PrmLaeRec As Integer
		Dim PrmLossRec As Integer
		Dim PrmReiPay As Integer
		Dim PrmReiPayNotDue As Integer
		Dim PrmStateCode As Integer
		Dim PrmAgtBalNotDue As Integer
		Dim PrmAgtRec As Integer
	End Structure
	Public TPp As PtrTrtyPrm
	
	Public Sub GetTrtyPrmPtr()
		TPp.PrmMgaNmbr = d4field(f4, "MGANMBR")
		TPp.PrmTrtyNmbr = d4field(f4, "TRTYNMBR")
		TPp.PrmRptName = d4field(f4, "DESC")
		TPp.PrmConNmbr = d4field(f4, "CON NMBR")
		TPp.PrmReiRptFlag = d4field(f4, "REIN FLAG")
		TPp.PrmDesc = d4field(f4, "GL DESC")
		TPp.PrmAgtRec = d4field(f4, "GL AGT REC")
		TPp.PrmReiPay = d4field(f4, "GL REI PAY")
		TPp.PrmLossRec = d4field(f4, "GL LOS REC")
		TPp.PrmLaeRec = d4field(f4, "GL LAE REC")
		TPp.PrmAgtBalNotDue = d4field(f4, "GL AGT ND")
		TPp.PrmReiPayNotDue = d4field(f4, "GL PAY ND")
		TPp.PrmIncpDate = d4field(f4, "INCEP DATE")
		TPp.PrmStatus = d4field(f4, "STATUS")
		TPp.PrmGrpID = d4field(f4, "GRP ID")
		TPp.PrmStateCode = d4field(f4, "STATE CODE")
	End Sub
	
	Public Sub GetTrtyPrmVar()
		txPrmMgaNmbr = Trim(f4str(TPp.PrmMgaNmbr))
		txPrmTrtyNmbr = Trim(f4str(TPp.PrmTrtyNmbr))
		txPrmRptName = Trim(f4str(TPp.PrmRptName))
		txPrmConNmbr = Trim(f4str(TPp.PrmConNmbr))
		txPrmReiRptFlag = Trim(f4str(TPp.PrmReiRptFlag))
		txPrmDesc = Trim(f4str(TPp.PrmDesc))
		txPrmAgtRec = Trim(f4str(TPp.PrmAgtRec))
		txPrmReiPay = Trim(f4str(TPp.PrmReiPay))
		txPrmLossRec = Trim(f4str(TPp.PrmLossRec))
		txPrmLaeRec = Trim(f4str(TPp.PrmLaeRec))
		txPrmAgtBalNotDue = Trim(f4str(TPp.PrmAgtBalNotDue))
		txPrmReiPayNotDue = Trim(f4str(TPp.PrmReiPayNotDue))
		txPrmIncpDate = Trim(f4str(TPp.PrmIncpDate))
		txPrmStatus = Trim(f4str(TPp.PrmStatus))
		txPrmGrpID = Trim(f4str(TPp.PrmGrpID))
		txPrmStateCode = Trim(f4str(TPp.PrmStateCode))
	End Sub
	
	Public Sub UpTrtyPrmFlds()
		Call f4assign(TPp.PrmMgaNmbr, txPrmMgaNmbr)
		Call f4assign(TPp.PrmTrtyNmbr, txPrmTrtyNmbr)
		Call f4assign(TPp.PrmRptName, txPrmRptName)
		Call f4assign(TPp.PrmConNmbr, txPrmConNmbr)
		Call f4assign(TPp.PrmReiRptFlag, txPrmReiRptFlag)
		Call f4assign(TPp.PrmDesc, txPrmDesc)
		Call f4assign(TPp.PrmAgtRec, txPrmAgtRec)
		Call f4assign(TPp.PrmReiPay, txPrmReiPay)
		Call f4assign(TPp.PrmLossRec, txPrmLossRec)
		Call f4assign(TPp.PrmLaeRec, txPrmLaeRec)
		Call f4assign(TPp.PrmAgtBalNotDue, txPrmAgtBalNotDue)
		Call f4assign(TPp.PrmReiPayNotDue, txPrmReiPayNotDue)
		Call f4assign(TPp.PrmIncpDate, txPrmIncpDate)
		Call f4assign(TPp.PrmStatus, txPrmStatus)
		Call f4assign(TPp.PrmGrpID, txPrmGrpID)
		Call f4assign(TPp.PrmStateCode, txPrmStateCode)
	End Sub
	
    Public Sub RdTrtyPrmRec()
        Fstat = 0
        Call d4tagSelect(f4, d4tag(f4, "K1"))
        rc = d4seek(f4, TrtyKey)
        Fstat = rc
        rc = d4unlock(f4)
    End Sub

    Public Sub AddTrtyPrmRec()
        If Not ValUser() Then Exit Sub
        AddTran = True

        If d4appendStart(f4, 0) <> r4success Then
            AddTran = False
            Exit Sub
        End If

        Call UpTrtyPrmFlds()
        rc = d4append(f4)
        rc = d4unlock(f4)
    End Sub
	
	Public Sub UpTrtyPrmRec()
		If Not ValUser Then Exit Sub
		UpTrtyPrmFlds()
		rc = d4unlock(f4)
	End Sub
	
	Public Sub GetTrtyPrmRec()
		UpdateTran = False
		AddTran = False
		Call d4tagSelect(f4, d4tag(f4, "K1"))
		rc = d4seek(f4, TrtyKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f4, d4recNo(f4))
		If rc = r4locked Then
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetTrtyPrmVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelTrtyPrmRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f4)
		Call d4blank(f4)
	End Sub
End Module