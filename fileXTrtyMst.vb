Option Strict Off
Option Explicit On
Module fileXTrtyMst
	
	Public txXTrtyCession As String
	Public txXTrtyEffDate As String
	
	'Excess Cessions
	'FIELD4 structure pointers -- (XTRTYMST)
	Public Structure PtrXTrtyMst
		Dim XTrtyDesc As Integer
		Dim XTrtyMgaNmbr As Integer
		Dim XTrtyNmbr As Integer
		Dim XTrtyCession As Integer
		Dim XTrtyEffDate As Integer
		Dim XTrtyFFperc As Integer
		Dim XTrtyPremTaxPerc As Integer
		Dim XDirCommPerc As Integer
		Dim XCedCommPerc As Integer
		Dim XTrtyCedPerc As Integer
		Dim XPPBI As Integer
		Dim XPPPD As Integer
		Dim XPPMED As Integer
		Dim XPPUMBI As Integer
		Dim XPPUMPD As Integer
		Dim XPPPIP As Integer
		Dim XPPCOMP As Integer
		Dim XPPCOLL As Integer
		Dim XPPRENT As Integer
		Dim XPPTOW As Integer
		Dim XCMBI As Integer
		Dim XCMPD As Integer
		Dim XCMMED As Integer
		Dim XCMUMBI As Integer
		Dim XCMUMPD As Integer
		Dim XCMPIP As Integer
		Dim XCMCOMP As Integer
		Dim XCMCOLL As Integer
		Dim XCMRENT As Integer
		Dim XCMTOW As Integer
		Dim XIM As Integer
		Dim XALLIED As Integer
		Dim XFIRE As Integer
		Dim XMULTIP As Integer
		Dim XTrtyReiNmbr1 As Integer
		Dim XTrtyReiNmbr2 As Integer
		Dim XTrtyReiNmbr3 As Integer
		Dim XTrtyReiNmbr4 As Integer
		Dim XTrtyReiNmbr5 As Integer
		Dim XTrtyReiNmbr6 As Integer
		Dim XTrtyReiNmbr7 As Integer
		Dim XTrtyReiNmbr8 As Integer
		Dim XTrtyReiNmbr9 As Integer
		Dim XTrtyReiNmbr10 As Integer
		Dim XTrtyReiPerc1 As Integer
		Dim XTrtyReiPerc2 As Integer
		Dim XTrtyReiPerc3 As Integer
		Dim XTrtyReiPerc4 As Integer
		Dim XTrtyReiPerc5 As Integer
		Dim XTrtyReiPerc6 As Integer
		Dim XTrtyReiPerc7 As Integer
		Dim XTrtyReiPerc8 As Integer
		Dim XTrtyReiPerc9 As Integer
		Dim XTrtyReiPerc10 As Integer
		Dim XTrtyHist As Integer
	End Structure
	Public TXMp As PtrXTrtyMst
	
	Public Sub GetXTrtyMstPtr()
		TXMp.XTrtyDesc = d4field(f3X, "DESC")
		TXMp.XTrtyMgaNmbr = d4field(f3X, "MGANMBR")
		TXMp.XTrtyNmbr = d4field(f3X, "TRTYNMBR")
		TXMp.XTrtyCession = d4field(f3X, "CESSION")
		TXMp.XTrtyEffDate = d4field(f3X, "CEFFDATE")
		TXMp.XTrtyFFperc = d4field(f3X, "FF%")
		TXMp.XTrtyPremTaxPerc = d4field(f3X, "PREMTAX%")
		TXMp.XDirCommPerc = d4field(f3X, "DIRCOMM%")
		TXMp.XCedCommPerc = d4field(f3X, "CEDCOMM%")
		TXMp.XTrtyCedPerc = d4field(f3X, "CEDED%")
		TXMp.XPPBI = d4field(f3X, "PPBI")
		TXMp.XPPPD = d4field(f3X, "PPPD")
		TXMp.XPPMED = d4field(f3X, "PPMED")
		TXMp.XPPUMBI = d4field(f3X, "PPUMBI")
		TXMp.XPPUMPD = d4field(f3X, "PPUMPD")
		TXMp.XPPPIP = d4field(f3X, "PPPIP")
		TXMp.XPPCOMP = d4field(f3X, "PPCOMP")
		TXMp.XPPCOLL = d4field(f3X, "PPCOLL")
		TXMp.XPPRENT = d4field(f3X, "PPRENT")
		TXMp.XPPTOW = d4field(f3X, "PPTOW")
		TXMp.XCMBI = d4field(f3X, "CMBI")
		TXMp.XCMPD = d4field(f3X, "CMPD")
		TXMp.XCMMED = d4field(f3X, "CMMED")
		TXMp.XCMUMBI = d4field(f3X, "CMUMBI")
		TXMp.XCMUMPD = d4field(f3X, "CMUMPD")
		TXMp.XCMPIP = d4field(f3X, "CMPIP")
		TXMp.XCMCOMP = d4field(f3X, "CMCOMP")
		TXMp.XCMCOLL = d4field(f3X, "CMCOLL")
		TXMp.XCMRENT = d4field(f3X, "CMRENT")
		TXMp.XCMTOW = d4field(f3X, "CMTOW")
		TXMp.XIM = d4field(f3X, "IM")
		TXMp.XALLIED = d4field(f3X, "ALLIED")
		TXMp.XFIRE = d4field(f3X, "FIRE")
		TXMp.XMULTIP = d4field(f3X, "MULTIPERIL")
		TXMp.XTrtyReiNmbr1 = d4field(f3X, "REINMBR1")
		TXMp.XTrtyReiNmbr2 = d4field(f3X, "REINMBR2")
		TXMp.XTrtyReiNmbr3 = d4field(f3X, "REINMBR3")
		TXMp.XTrtyReiNmbr4 = d4field(f3X, "REINMBR4")
		TXMp.XTrtyReiNmbr5 = d4field(f3X, "REINMBR5")
		TXMp.XTrtyReiNmbr6 = d4field(f3X, "REINMBR6")
		TXMp.XTrtyReiNmbr7 = d4field(f3X, "REINMBR7")
		TXMp.XTrtyReiNmbr8 = d4field(f3X, "REINMBR8")
		TXMp.XTrtyReiNmbr9 = d4field(f3X, "REINMBR9")
		TXMp.XTrtyReiNmbr10 = d4field(f3X, "REINMBR10")
		TXMp.XTrtyReiPerc1 = d4field(f3X, "REI1%")
		TXMp.XTrtyReiPerc2 = d4field(f3X, "REI2%")
		TXMp.XTrtyReiPerc3 = d4field(f3X, "REI3%")
		TXMp.XTrtyReiPerc4 = d4field(f3X, "REI4%")
		TXMp.XTrtyReiPerc5 = d4field(f3X, "REI5%")
		TXMp.XTrtyReiPerc6 = d4field(f3X, "REI6%")
		TXMp.XTrtyReiPerc7 = d4field(f3X, "REI7%")
		TXMp.XTrtyReiPerc8 = d4field(f3X, "REI8%")
		TXMp.XTrtyReiPerc9 = d4field(f3X, "REI9%")
		TXMp.XTrtyReiPerc10 = d4field(f3X, "REI10%")
		TXMp.XTrtyHist = d4field(f3X, "TRTYHIST")
	End Sub
	
	Public Sub GetXTrtyMstVar()
		txTrtyMgaNmbr = f4str(TXMp.XTrtyMgaNmbr)
		txTrtyNmbr = f4str(TXMp.XTrtyNmbr)
		txTrtyDesc = f4str(TXMp.XTrtyDesc)
		txXTrtyCession = f4str(TXMp.XTrtyCession)
		txXTrtyEffDate = f4str(TXMp.XTrtyEffDate)
        txTrtyFFperc = Format(f4double(TXMp.XTrtyFFperc) * 100, "###.0000")
        txTrtyPremTaxPerc = Format(f4double(TXMp.XTrtyPremTaxPerc) * 100, "###.0000")
        txDirCommPerc = Format(f4double(TXMp.XDirCommPerc) * 100, "###.0000")
        txCedCommPerc = Format(f4double(TXMp.XCedCommPerc) * 100, "###.0000")
        txTrtyCedPerc = Format(f4double(TXMp.XTrtyCedPerc) * 100, "###.0000")
		chPPBI = f4int(TXMp.XPPBI)
		chPPPD = f4int(TXMp.XPPPD)
		chPPMED = f4int(TXMp.XPPMED)
		chPPUMBI = f4int(TXMp.XPPUMBI)
		chPPUMPD = f4int(TXMp.XPPUMPD)
		chPPPIP = f4int(TXMp.XPPPIP)
		chPPCOMP = f4int(TXMp.XPPCOMP)
		chPPCOLL = f4int(TXMp.XPPCOLL)
		chPPRENT = f4int(TXMp.XPPRENT)
		chPPTOW = f4int(TXMp.XPPTOW)
		chCMBI = f4int(TXMp.XCMBI)
		chCMPD = f4int(TXMp.XCMPD)
		chCMMED = f4int(TXMp.XCMMED)
		chCMUMBI = f4int(TXMp.XCMUMBI)
		chCMUMPD = f4int(TXMp.XCMUMPD)
		chCMPIP = f4int(TXMp.XCMPIP)
		chCMCOMP = f4int(TXMp.XCMCOMP)
		chCMCOLL = f4int(TXMp.XCMCOLL)
		chCMRENT = f4int(TXMp.XCMRENT)
		chCMTOW = f4int(TXMp.XCMTOW)
		chIM = f4int(TXMp.XIM)
		chALLIED = f4int(TXMp.XALLIED)
		chFIRE = f4int(TXMp.XFIRE)
		chMULTIP = f4int(TXMp.XMULTIP)
		
		txTrtyHist = f4memoStr(TXMp.XTrtyHist)
	End Sub
	
	Public Sub GetXTrtyReiVar()
		txTrtyHist = f4memoStr(TXMp.XTrtyHist)
		
		txTrtyReiMgaNmbr = f4str(TXMp.XTrtyMgaNmbr)
		txTrtyReiTrtyNmbr = f4str(TXMp.XTrtyNmbr)
        txTrtyReiCedPerc = Format(f4double(TXMp.XTrtyCedPerc) * 100, "###.0000")
		txTrtyReiNmbr1 = Trim(f4str(TXMp.XTrtyReiNmbr1))
		txTrtyReiNmbr2 = Trim(f4str(TXMp.XTrtyReiNmbr2))
		txTrtyReiNmbr3 = Trim(f4str(TXMp.XTrtyReiNmbr3))
		txTrtyReiNmbr4 = Trim(f4str(TXMp.XTrtyReiNmbr4))
		txTrtyReiNmbr5 = Trim(f4str(TXMp.XTrtyReiNmbr5))
		txTrtyReiNmbr6 = Trim(f4str(TXMp.XTrtyReiNmbr6))
		txTrtyReiNmbr7 = Trim(f4str(TXMp.XTrtyReiNmbr7))
		txTrtyReiNmbr8 = Trim(f4str(TXMp.XTrtyReiNmbr8))
		txTrtyReiNmbr9 = Trim(f4str(TXMp.XTrtyReiNmbr9))
		txTrtyReiNmbr10 = Trim(f4str(TXMp.XTrtyReiNmbr10))
		
		If Val(txTrtyReiNmbr1) = 0 Then txTrtyReiNmbr1 = ""
		If Val(txTrtyReiNmbr2) = 0 Then txTrtyReiNmbr2 = ""
		If Val(txTrtyReiNmbr3) = 0 Then txTrtyReiNmbr3 = ""
		If Val(txTrtyReiNmbr4) = 0 Then txTrtyReiNmbr4 = ""
		If Val(txTrtyReiNmbr5) = 0 Then txTrtyReiNmbr5 = ""
		If Val(txTrtyReiNmbr6) = 0 Then txTrtyReiNmbr6 = ""
		If Val(txTrtyReiNmbr7) = 0 Then txTrtyReiNmbr7 = ""
		If Val(txTrtyReiNmbr8) = 0 Then txTrtyReiNmbr8 = ""
		If Val(txTrtyReiNmbr9) = 0 Then txTrtyReiNmbr9 = ""
		If Val(txTrtyReiNmbr10) = 0 Then txTrtyReiNmbr10 = ""
		
        txTrtyReiPerc1 = Format(f4double(TXMp.XTrtyReiPerc1) * 100, "###.0000")
        txTrtyReiPerc2 = Format(f4double(TXMp.XTrtyReiPerc2) * 100, "###.0000")
        txTrtyReiPerc3 = Format(f4double(TXMp.XTrtyReiPerc3) * 100, "###.0000")
        txTrtyReiPerc4 = Format(f4double(TXMp.XTrtyReiPerc4) * 100, "###.0000")
        txTrtyReiPerc5 = Format(f4double(TXMp.XTrtyReiPerc5) * 100, "###.0000")
        txTrtyReiPerc6 = Format(f4double(TXMp.XTrtyReiPerc6) * 100, "###.0000")
        txTrtyReiPerc7 = Format(f4double(TXMp.XTrtyReiPerc7) * 100, "###.0000")
        txTrtyReiPerc8 = Format(f4double(TXMp.XTrtyReiPerc8) * 100, "###.0000")
        txTrtyReiPerc9 = Format(f4double(TXMp.XTrtyReiPerc9) * 100, "###.0000")
        txTrtyReiPerc10 = Format(f4double(TXMp.XTrtyReiPerc10) * 100, "###.0000")
		
		GetXReiNames()
		txTrtyReiName1 = Rname(1)
		txTrtyReiName2 = Rname(2)
		txTrtyReiName3 = Rname(3)
		txTrtyReiName4 = Rname(4)
		txTrtyReiName5 = Rname(5)
		txTrtyReiName6 = Rname(6)
		txTrtyReiName7 = Rname(7)
		txTrtyReiName8 = Rname(8)
		txTrtyReiName9 = Rname(9)
		txTrtyReiName10 = Rname(10)
		
		TotPerc = 0
		TotPerc = Val(txTrtyReiPerc1) + Val(txTrtyReiPerc2) + Val(txTrtyReiPerc3) + Val(txTrtyReiPerc4) + Val(txTrtyReiPerc5) + Val(txTrtyReiPerc6) + Val(txTrtyReiPerc7) + Val(txTrtyReiPerc8) + Val(txTrtyReiPerc9) + Val(txTrtyReiPerc10)
		
        txTrtyReiPercTot = Format(TotPerc, "###.0000")
	End Sub
	
	Public Sub UpXTrtyMstFlds()
		Call f4assign(TXMp.XTrtyDesc, txTrtyDesc)
		Call f4assign(TXMp.XTrtyMgaNmbr, txTrtyMgaNmbr)
		Call f4assign(TXMp.XTrtyNmbr, txTrtyNmbr)
		Call f4assign(TXMp.XTrtyCession, txXTrtyCession)
		Call f4assign(TXMp.XTrtyEffDate, txXTrtyEffDate)
		
		Call f4assignDouble(TXMp.XTrtyFFperc, Val(txTrtyFFperc) / 100)
		Call f4assignDouble(TXMp.XTrtyPremTaxPerc, Val(txTrtyPremTaxPerc) / 100)
		Call f4assignDouble(TXMp.XTrtyCedPerc, Val(txTrtyCedPerc) / 100)
		Call f4assignDouble(TXMp.XDirCommPerc, Val(txDirCommPerc) / 100)
		Call f4assignDouble(TXMp.XCedCommPerc, Val(txCedCommPerc) / 100)
		Call f4assignInt(TXMp.XPPBI, chPPBI)
		Call f4assignInt(TXMp.XPPPD, chPPPD)
		Call f4assignInt(TXMp.XPPMED, chPPMED)
		Call f4assignInt(TXMp.XPPUMBI, chPPUMBI)
		Call f4assignInt(TXMp.XPPUMPD, chPPUMPD)
		Call f4assignInt(TXMp.XPPPIP, chPPPIP)
		Call f4assignInt(TXMp.XPPCOMP, chPPCOMP)
		Call f4assignInt(TXMp.XPPCOLL, chPPCOLL)
		Call f4assignInt(TXMp.XPPRENT, chPPRENT)
		Call f4assignInt(TXMp.XPPTOW, chPPTOW)
		Call f4assignInt(TXMp.XCMBI, chCMBI)
		Call f4assignInt(TXMp.XCMPD, chCMPD)
		Call f4assignInt(TXMp.XCMMED, chCMMED)
		Call f4assignInt(TXMp.XCMUMBI, chCMUMBI)
		Call f4assignInt(TXMp.XCMUMPD, chCMUMPD)
		Call f4assignInt(TXMp.XCMPIP, chCMPIP)
		Call f4assignInt(TXMp.XCMCOMP, chCMCOMP)
		Call f4assignInt(TXMp.XCMCOLL, chCMCOLL)
		Call f4assignInt(TXMp.XCMRENT, chCMRENT)
		Call f4assignInt(TXMp.XCMTOW, chCMTOW)
		Call f4assignInt(TXMp.XIM, chIM)
		Call f4assignInt(TXMp.XALLIED, chALLIED)
		Call f4assignInt(TXMp.XFIRE, chFIRE)
		Call f4assignInt(TXMp.XMULTIP, chMULTIP)
		Call f4memoAssign(TXMp.XTrtyHist, txTrtyHist)
		
	End Sub
	
	Public Sub UpXTrtyMstFlds1()
        Call f4assign(TXMp.XTrtyReiNmbr1, Format(Val(txTrtyReiNmbr1), "000"))
        Call f4assign(TXMp.XTrtyReiNmbr2, Format(Val(txTrtyReiNmbr2), "000"))
        Call f4assign(TXMp.XTrtyReiNmbr3, Format(Val(txTrtyReiNmbr3), "000"))
        Call f4assign(TXMp.XTrtyReiNmbr4, Format(Val(txTrtyReiNmbr4), "000"))
        Call f4assign(TXMp.XTrtyReiNmbr5, Format(Val(txTrtyReiNmbr5), "000"))
        Call f4assign(TXMp.XTrtyReiNmbr6, Format(Val(txTrtyReiNmbr6), "000"))
        Call f4assign(TXMp.XTrtyReiNmbr7, Format(Val(txTrtyReiNmbr7), "000"))
        Call f4assign(TXMp.XTrtyReiNmbr8, Format(Val(txTrtyReiNmbr8), "000"))
        Call f4assign(TXMp.XTrtyReiNmbr9, Format(Val(txTrtyReiNmbr9), "000"))
        Call f4assign(TXMp.XTrtyReiNmbr10, Format(Val(txTrtyReiNmbr10), "000"))
		Call f4assignDouble(TXMp.XTrtyReiPerc1, Val(txTrtyReiPerc1) / 100)
		Call f4assignDouble(TXMp.XTrtyReiPerc2, Val(txTrtyReiPerc2) / 100)
		Call f4assignDouble(TXMp.XTrtyReiPerc3, Val(txTrtyReiPerc3) / 100)
		Call f4assignDouble(TXMp.XTrtyReiPerc4, Val(txTrtyReiPerc4) / 100)
		Call f4assignDouble(TXMp.XTrtyReiPerc5, Val(txTrtyReiPerc5) / 100)
		Call f4assignDouble(TXMp.XTrtyReiPerc6, Val(txTrtyReiPerc6) / 100)
		Call f4assignDouble(TXMp.XTrtyReiPerc7, Val(txTrtyReiPerc7) / 100)
		Call f4assignDouble(TXMp.XTrtyReiPerc8, Val(txTrtyReiPerc8) / 100)
		Call f4assignDouble(TXMp.XTrtyReiPerc9, Val(txTrtyReiPerc9) / 100)
		Call f4assignDouble(TXMp.XTrtyReiPerc10, Val(txTrtyReiPerc10) / 100)
		Call f4memoAssign(TXMp.XTrtyHist, txTrtyHist)
	End Sub
	
	Public Sub UpXTrtyComments()
		Call f4memoAssign(TXMp.XTrtyHist, txTrtyHist)
	End Sub
	
	Public Sub AddXTrtyMstRec()
		If Not ValUser Then Exit Sub
		AddTran = True
		
		If d4appendStart(f3X, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpXTrtyMstFlds()
		Call UpXTrtyMstFlds1()
		rc = d4append(f3X)
		rc = d4unlock(f3X)
	End Sub
	
	Public Sub UpXTrtyMstRec()
		If Not ValUser Then Exit Sub
		Call UpXTrtyMstFlds()
		Call UpXTrtyMstFlds1()
		rc = d4unlock(f3X)
	End Sub
	
	Public Sub GetXTrtyMstRec()
		UpdateTran = False
		AddTran = False
		Call d4tagSelect(f3X, d4tag(f3X, "K1"))
		rc = d4seek(f3X, TrtyXKey)
		If rc <> 0 Then Exit Sub
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f3X, d4recNo(f3X))
		If rc = r4locked Then
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		GetXTrtyMstVar()
		GetXTrtyReiVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelXTrtyMstRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f3X)
		Call d4blank(f3X)
	End Sub
	
	Public Sub GetXReiNames()
		Dim X As Short
		
		For X = 1 To 10
			Rnmbr(X) = ""
			Rname(X) = ""
		Next X
		
        Rnmbr(1) = Format(f4str(TXMp.XTrtyReiNmbr1), "00#")
        Rnmbr(2) = Format(f4str(TXMp.XTrtyReiNmbr2), "00#")
        Rnmbr(3) = Format(f4str(TXMp.XTrtyReiNmbr3), "00#")
        Rnmbr(4) = Format(f4str(TXMp.XTrtyReiNmbr4), "00#")
        Rnmbr(5) = Format(f4str(TXMp.XTrtyReiNmbr5), "00#")
        Rnmbr(6) = Format(f4str(TXMp.XTrtyReiNmbr6), "00#")
        Rnmbr(7) = Format(f4str(TXMp.XTrtyReiNmbr7), "00#")
        Rnmbr(8) = Format(f4str(TXMp.XTrtyReiNmbr8), "00#")
        Rnmbr(9) = Format(f4str(TXMp.XTrtyReiNmbr9), "00#")
        Rnmbr(10) = Format(f4str(TXMp.XTrtyReiNmbr10), "00#")
		
		For X = 1 To 10
			Call d4tagSelect(f2, d4tag(f2, "K1"))
			rc = d4seek(f2, Rnmbr(X))
			If rc = 0 Then Rname(X) = f4str(Rp.ReiName)
		Next X
		
	End Sub
End Module