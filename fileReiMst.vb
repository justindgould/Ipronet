Option Strict Off
Option Explicit On
Module fileReiMst
	
	Public txReiNmbr As String
	Public txReiName As String
	Public txReiAddr1 As String
	Public txReiAddr2 As String
	Public txReiAddr3 As String
	Public txReiPhone As String
	Public txReiFax As String
	Public txReiFein As String
	Public txReiNaic As String
	Public txReiDomiciled As String
	Public txReiLicTX As String
	Public txReiStatus As String
	Public txReiHist As String
	
	'FIELD4 structure pointers -- (ReiMST)
	Public Structure PtrRei
		Dim ReiNmbr As Integer
		Dim ReiName As Integer
		Dim ReiAddr1 As Integer
		Dim ReiAddr2 As Integer
		Dim ReiAddr3 As Integer
		Dim ReiPhone As Integer
		Dim ReiFax As Integer
		Dim ReiFein As Integer
		Dim ReiNaic As Integer
		Dim ReiDomiciled As Integer
		Dim ReiLicTX As Integer
		Dim ReiStatus As Integer
		Dim ReiHist As Integer
	End Structure
	Public Rp As PtrRei
	
	Public Sub GetReiMstPtr()
		Rp.ReiNmbr = d4field(f2, "REINMBR")
		Rp.ReiName = d4field(f2, "NAME")
		Rp.ReiAddr1 = d4field(f2, "ADDR1")
		Rp.ReiAddr2 = d4field(f2, "ADDR2")
		Rp.ReiAddr3 = d4field(f2, "ADDR3")
		Rp.ReiPhone = d4field(f2, "PHONE")
		Rp.ReiFax = d4field(f2, "FAX")
		Rp.ReiFein = d4field(f2, "FEIN")
		Rp.ReiNaic = d4field(f2, "NAIC")
		Rp.ReiDomiciled = d4field(f2, "DOMICLE")
		Rp.ReiLicTX = d4field(f2, "TEXAS LICS")
		Rp.ReiStatus = d4field(f2, "STATUS")
		Rp.ReiHist = d4field(f2, "HIST")
	End Sub
	
	Public Sub GetReiMstVar()
		txReiNmbr = f4str(Rp.ReiNmbr)
		txReiName = f4str(Rp.ReiName)
		txReiAddr1 = f4str(Rp.ReiAddr1)
		txReiAddr2 = f4str(Rp.ReiAddr2)
		txReiAddr3 = f4str(Rp.ReiAddr3)
		txReiPhone = f4str(Rp.ReiPhone)
		txReiFax = f4str(Rp.ReiFax)
		txReiFein = f4str(Rp.ReiFein)
		txReiNaic = f4str(Rp.ReiNaic)
		txReiDomiciled = f4str(Rp.ReiDomiciled)
		txReiLicTX = f4str(Rp.ReiLicTX)
		txReiStatus = f4str(Rp.ReiStatus)
		txReiHist = f4memoStr(Rp.ReiHist)
	End Sub
	
	Public Sub UpReiMstFlds()
		Call f4assign(Rp.ReiNmbr, Trim(txReiNmbr))
		Call f4assign(Rp.ReiName, Trim(txReiName))
		Call f4assign(Rp.ReiAddr1, Trim(txReiAddr1))
		Call f4assign(Rp.ReiAddr2, Trim(txReiAddr2))
		Call f4assign(Rp.ReiAddr3, Trim(txReiAddr3))
		Call f4assign(Rp.ReiPhone, Trim(txReiPhone))
		Call f4assign(Rp.ReiFax, Trim(txReiFax))
		Call f4assign(Rp.ReiFein, Trim(txReiFein))
		Call f4assign(Rp.ReiNaic, Trim(txReiNaic))
		Call f4assign(Rp.ReiDomiciled, Trim(txReiDomiciled))
		Call f4assign(Rp.ReiLicTX, Trim(txReiLicTX))
		Call f4assign(Rp.ReiStatus, Trim(txReiStatus))
		Call f4memoAssign(Rp.ReiHist, Trim(txReiHist))
	End Sub
	
	Public Sub UpReiCommentFrmVar()
		frmReiComments.txtReiHist.Text = txReiHist
	End Sub
	
	Public Sub UpReiCommentVars()
		txReiHist = frmReiComments.txtReiHist.Text
	End Sub

    Public Sub RdReiMstRec()
        Fstat = 0
        Call d4tagSelect(f2, d4tag(f2, "K1"))
        rc = d4seek(f2, ReiKey)
        Fstat = rc
        rc = d4unlock(f2)
    End Sub

    Public Sub AddReiMstRec()
        If Not ValUser() Then Exit Sub
        AddTran = True

        If d4appendStart(f2, 0) <> r4success Then
            AddTran = False
            Exit Sub
        End If

        Call UpReiMstFlds()
        rc = d4append(f2)
        rc = d4unlock(f2)
    End Sub
	
	Public Sub UpReiMstRec()
		If Not ValUser Then Exit Sub
		Call UpReiMstFlds()
		rc = d4unlock(f2)
	End Sub
	
	Public Sub GetReiMstRec()
		UpdateTran = False
		AddTran = False
		Call d4tagSelect(f2, d4tag(f2, "K1"))
		rc = d4seek(f2, ReiKey)
		If rc <> 0 Then
			AddTran = True
			Exit Sub
		End If
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f2, d4recNo(f2))
		If rc = r4locked Then
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetReiMstVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelReiMstRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f2)
		Call d4blank(f2)
	End Sub
End Module