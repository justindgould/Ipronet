Option Strict Off
Option Explicit On
Module fileTrtyMst

    'Form Treaty Mnt Work Vars
    Public txTrtyMgaNmbr As String
    Public txTrtyNmbr As String
    Public txTrtyDesc As String
    Public txTrtyFFperc As String
    Public txTrtyPremTaxPerc As String
    Public txDirCommPerc As String
    Public txCedCommPerc As String
    Public txTrtyCedPerc As String
    Public chPPBI As Short
    Public chPPPD As Short
    Public chPPMED As Short
    Public chPPUMBI As Short
    Public chPPUMPD As Short
    Public chPPPIP As Short
    Public chPPCOMP As Short
    Public chPPCOLL As Short
    Public chPPRENT As Short
    Public chPPTOW As Short
    Public chCMBI As Short
    Public chCMPD As Short
    Public chCMMED As Short
    Public chCMUMBI As Short
    Public chCMUMPD As Short
    Public chCMPIP As Short
    Public chCMCOMP As Short
    Public chCMCOLL As Short
    Public chCMRENT As Short
    Public chCMTOW As Short
    Public chIM As Short
    Public chALLIED As Short
    Public chFIRE As Short
    Public chMULTIP As Short

    'Form Treaty Reinsurer Vars
    Public txTrtyReiMgaNmbr As String
    Public txTrtyReiTrtyNmbr As String
    Public txTrtyReiCedPerc As String

    Public txTrtyReiNmbr1 As String
    Public txTrtyReiNmbr2 As String
    Public txTrtyReiNmbr3 As String
    Public txTrtyReiNmbr4 As String
    Public txTrtyReiNmbr5 As String
    Public txTrtyReiNmbr6 As String
    Public txTrtyReiNmbr7 As String
    Public txTrtyReiNmbr8 As String
    Public txTrtyReiNmbr9 As String
    Public txTrtyReiNmbr10 As String

    Public txTrtyReiName1 As String
    Public txTrtyReiName2 As String
    Public txTrtyReiName3 As String
    Public txTrtyReiName4 As String
    Public txTrtyReiName5 As String
    Public txTrtyReiName6 As String
    Public txTrtyReiName7 As String
    Public txTrtyReiName8 As String
    Public txTrtyReiName9 As String
    Public txTrtyReiName10 As String

    Public txTrtyReiPerc1 As String
    Public txTrtyReiPerc2 As String
    Public txTrtyReiPerc3 As String
    Public txTrtyReiPerc4 As String
    Public txTrtyReiPerc5 As String
    Public txTrtyReiPerc6 As String
    Public txTrtyReiPerc7 As String
    Public txTrtyReiPerc8 As String
    Public txTrtyReiPerc9 As String
    Public txTrtyReiPerc10 As String

    Public txTrtyReiPercTot As String

    'Form Treaty Reinsurer Vars
    Public txTrtyHist As String

    'FIELD4 structure pointers -- (ReiMST)
    Public Structure PtrTrtyMst
        Dim TrtyDesc As Integer
        Dim TrtyMgaNmbr As Integer
        Dim TrtyNmbr As Integer
        Dim TrtyFFperc As Integer
        Dim TrtyPremTaxPerc As Integer
        Dim DirCommPerc As Integer
        Dim CedCommPerc As Integer
        Dim TrtyCedPerc As Integer
        Dim PPBI As Integer
        Dim PPPD As Integer
        Dim PPMED As Integer
        Dim PPUMBI As Integer
        Dim PPUMPD As Integer
        Dim PPPIP As Integer
        Dim PPCOMP As Integer
        Dim PPCOLL As Integer
        Dim PPRENT As Integer
        Dim PPTOW As Integer
        Dim CMBI As Integer
        Dim CMPD As Integer
        Dim CMMED As Integer
        Dim CMUMBI As Integer
        Dim CMUMPD As Integer
        Dim CMPIP As Integer
        Dim CMCOMP As Integer
        Dim CMCOLL As Integer
        Dim CMRENT As Integer
        Dim CMTOW As Integer
        Dim IM As Integer
        Dim ALLIED As Integer
        Dim FIRE As Integer
        Dim MULTIP As Integer
        Dim TrtyReiNmbr1 As Integer
        Dim TrtyReiNmbr2 As Integer
        Dim TrtyReiNmbr3 As Integer
        Dim TrtyReiNmbr4 As Integer
        Dim TrtyReiNmbr5 As Integer
        Dim TrtyReiNmbr6 As Integer
        Dim TrtyReiNmbr7 As Integer
        Dim TrtyReiNmbr8 As Integer
        Dim TrtyReiNmbr9 As Integer
        Dim TrtyReiNmbr10 As Integer
        Dim TrtyReiPerc1 As Integer
        Dim TrtyReiPerc2 As Integer
        Dim TrtyReiPerc3 As Integer
        Dim TrtyReiPerc4 As Integer
        Dim TrtyReiPerc5 As Integer
        Dim TrtyReiPerc6 As Integer
        Dim TrtyReiPerc7 As Integer
        Dim TrtyReiPerc8 As Integer
        Dim TrtyReiPerc9 As Integer
        Dim TrtyReiPerc10 As Integer
        Dim TrtyHist As Integer
    End Structure
    Public TMp As PtrTrtyMst

    Public Rname(10) As String
    Public Rnmbr(10) As String
    Public Rperc(10) As String

    Public Sub GetTrtyMstPtr()
        TMp.TrtyDesc = d4field(f3, "DESC")
        TMp.TrtyMgaNmbr = d4field(f3, "MGANMBR")
        TMp.TrtyNmbr = d4field(f3, "TRTYNMBR")
        TMp.TrtyFFperc = d4field(f3, "FF%")
        TMp.TrtyPremTaxPerc = d4field(f3, "PREMTAX%")
        TMp.DirCommPerc = d4field(f3, "DIRCOMM%")
        TMp.CedCommPerc = d4field(f3, "CEDCOMM%")
        TMp.TrtyCedPerc = d4field(f3, "CEDED%")
        TMp.PPBI = d4field(f3, "PPBI")
        TMp.PPPD = d4field(f3, "PPPD")
        TMp.PPMED = d4field(f3, "PPMED")
        TMp.PPUMBI = d4field(f3, "PPUMBI")
        TMp.PPUMPD = d4field(f3, "PPUMPD")
        TMp.PPPIP = d4field(f3, "PPPIP")
        TMp.PPCOMP = d4field(f3, "PPCOMP")
        TMp.PPCOLL = d4field(f3, "PPCOLL")
        TMp.PPRENT = d4field(f3, "PPRENT")
        TMp.PPTOW = d4field(f3, "PPTOW")
        TMp.CMBI = d4field(f3, "CMBI")
        TMp.CMPD = d4field(f3, "CMPD")
        TMp.CMMED = d4field(f3, "CMMED")
        TMp.CMUMBI = d4field(f3, "CMUMBI")
        TMp.CMUMPD = d4field(f3, "CMUMPD")
        TMp.CMPIP = d4field(f3, "CMPIP")
        TMp.CMCOMP = d4field(f3, "CMCOMP")
        TMp.CMCOLL = d4field(f3, "CMCOLL")
        TMp.CMRENT = d4field(f3, "CMRENT")
        TMp.CMTOW = d4field(f3, "CMTOW")
        TMp.IM = d4field(f3, "IM")
        TMp.ALLIED = d4field(f3, "ALLIED")
        TMp.FIRE = d4field(f3, "FIRE")
        TMp.MULTIP = d4field(f3, "MULTIPERIL")
        TMp.TrtyReiNmbr1 = d4field(f3, "REINMBR1")
        TMp.TrtyReiNmbr2 = d4field(f3, "REINMBR2")
        TMp.TrtyReiNmbr3 = d4field(f3, "REINMBR3")
        TMp.TrtyReiNmbr4 = d4field(f3, "REINMBR4")
        TMp.TrtyReiNmbr5 = d4field(f3, "REINMBR5")
        TMp.TrtyReiNmbr6 = d4field(f3, "REINMBR6")
        TMp.TrtyReiNmbr7 = d4field(f3, "REINMBR7")
        TMp.TrtyReiNmbr8 = d4field(f3, "REINMBR8")
        TMp.TrtyReiNmbr9 = d4field(f3, "REINMBR9")
        TMp.TrtyReiNmbr10 = d4field(f3, "REINMBR10")
        TMp.TrtyReiPerc1 = d4field(f3, "REI1%")
        TMp.TrtyReiPerc2 = d4field(f3, "REI2%")
        TMp.TrtyReiPerc3 = d4field(f3, "REI3%")
        TMp.TrtyReiPerc4 = d4field(f3, "REI4%")
        TMp.TrtyReiPerc5 = d4field(f3, "REI5%")
        TMp.TrtyReiPerc6 = d4field(f3, "REI6%")
        TMp.TrtyReiPerc7 = d4field(f3, "REI7%")
        TMp.TrtyReiPerc8 = d4field(f3, "REI8%")
        TMp.TrtyReiPerc9 = d4field(f3, "REI9%")
        TMp.TrtyReiPerc10 = d4field(f3, "REI10%")
        TMp.TrtyHist = d4field(f3, "TRTYHIST")
    End Sub

    Public Sub GetTrtyMstVar()
        txTrtyMgaNmbr = f4str(TMp.TrtyMgaNmbr)
        txTrtyNmbr = f4str(TMp.TrtyNmbr)
        txTrtyDesc = f4str(TMp.TrtyDesc)
        txTrtyFFperc = Format(f4double(TMp.TrtyFFperc) * 100, "###.0000")
        txTrtyPremTaxPerc = Format(f4double(TMp.TrtyPremTaxPerc) * 100, "###.0000")
        txDirCommPerc = Format(f4double(TMp.DirCommPerc) * 100, "###.0000")
        txCedCommPerc = Format(f4double(TMp.CedCommPerc) * 100, "###.0000")
        txTrtyCedPerc = Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000")
        chPPBI = f4int(TMp.PPBI)
        chPPPD = f4int(TMp.PPPD)
        chPPMED = f4int(TMp.PPMED)
        chPPUMBI = f4int(TMp.PPUMBI)
        chPPUMPD = f4int(TMp.PPUMPD)
        chPPPIP = f4int(TMp.PPPIP)
        chPPCOMP = f4int(TMp.PPCOMP)
        chPPCOLL = f4int(TMp.PPCOLL)
        chPPRENT = f4int(TMp.PPRENT)
        chPPTOW = f4int(TMp.PPTOW)
        chCMBI = f4int(TMp.CMBI)
        chCMPD = f4int(TMp.CMPD)
        chCMMED = f4int(TMp.CMMED)
        chCMUMBI = f4int(TMp.CMUMBI)
        chCMUMPD = f4int(TMp.CMUMPD)
        chCMPIP = f4int(TMp.CMPIP)
        chCMCOMP = f4int(TMp.CMCOMP)
        chCMCOLL = f4int(TMp.CMCOLL)
        chCMRENT = f4int(TMp.CMRENT)
        chCMTOW = f4int(TMp.CMTOW)
        chIM = f4int(TMp.IM)
        chALLIED = f4int(TMp.ALLIED)
        chFIRE = f4int(TMp.FIRE)
        chMULTIP = f4int(TMp.MULTIP)

        txTrtyHist = f4memoStr(TMp.TrtyHist)
    End Sub

    Public Sub GetTrtyReiVar()
        txTrtyHist = f4memoStr(TMp.TrtyHist)

        txTrtyReiMgaNmbr = f4str(TMp.TrtyMgaNmbr)
        txTrtyReiTrtyNmbr = f4str(TMp.TrtyNmbr)
        txTrtyReiCedPerc = Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000")
        txTrtyReiNmbr1 = Trim(f4str(TMp.TrtyReiNmbr1))
        txTrtyReiNmbr2 = Trim(f4str(TMp.TrtyReiNmbr2))
        txTrtyReiNmbr3 = Trim(f4str(TMp.TrtyReiNmbr3))
        txTrtyReiNmbr4 = Trim(f4str(TMp.TrtyReiNmbr4))
        txTrtyReiNmbr5 = Trim(f4str(TMp.TrtyReiNmbr5))
        txTrtyReiNmbr6 = Trim(f4str(TMp.TrtyReiNmbr6))
        txTrtyReiNmbr7 = Trim(f4str(TMp.TrtyReiNmbr7))
        txTrtyReiNmbr8 = Trim(f4str(TMp.TrtyReiNmbr8))
        txTrtyReiNmbr9 = Trim(f4str(TMp.TrtyReiNmbr9))
        txTrtyReiNmbr10 = Trim(f4str(TMp.TrtyReiNmbr10))

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

        txTrtyReiPerc1 = Format(f4double(TMp.TrtyReiPerc1) * 100, "###.0000")
        txTrtyReiPerc2 = Format(f4double(TMp.TrtyReiPerc2) * 100, "###.0000")
        txTrtyReiPerc3 = Format(f4double(TMp.TrtyReiPerc3) * 100, "###.0000")
        txTrtyReiPerc4 = Format(f4double(TMp.TrtyReiPerc4) * 100, "###.0000")
        txTrtyReiPerc5 = Format(f4double(TMp.TrtyReiPerc5) * 100, "###.0000")
        txTrtyReiPerc6 = Format(f4double(TMp.TrtyReiPerc6) * 100, "###.0000")
        txTrtyReiPerc7 = Format(f4double(TMp.TrtyReiPerc7) * 100, "###.0000")
        txTrtyReiPerc8 = Format(f4double(TMp.TrtyReiPerc8) * 100, "###.0000")
        txTrtyReiPerc9 = Format(f4double(TMp.TrtyReiPerc9) * 100, "###.0000")
        txTrtyReiPerc10 = Format(f4double(TMp.TrtyReiPerc10) * 100, "###.0000")

        GetReiNames()
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

    Public Sub UpTrtyMstFlds()
        Call f4assign(TMp.TrtyDesc, txTrtyDesc)
        Call f4assign(TMp.TrtyMgaNmbr, txTrtyMgaNmbr)
        Call f4assign(TMp.TrtyNmbr, txTrtyNmbr)
        Call f4assignDouble(TMp.TrtyFFperc, Val(txTrtyFFperc) / 100)
        Call f4assignDouble(TMp.TrtyPremTaxPerc, Val(txTrtyPremTaxPerc) / 100)
        Call f4assignDouble(TMp.TrtyCedPerc, Val(txTrtyCedPerc) / 100)
        Call f4assignDouble(TMp.DirCommPerc, Val(txDirCommPerc) / 100)
        Call f4assignDouble(TMp.CedCommPerc, Val(txCedCommPerc) / 100)
        Call f4assignInt(TMp.PPBI, chPPBI)
        Call f4assignInt(TMp.PPPD, chPPPD)
        Call f4assignInt(TMp.PPMED, chPPMED)
        Call f4assignInt(TMp.PPUMBI, chPPUMBI)
        Call f4assignInt(TMp.PPUMPD, chPPUMPD)
        Call f4assignInt(TMp.PPPIP, chPPPIP)
        Call f4assignInt(TMp.PPCOMP, chPPCOMP)
        Call f4assignInt(TMp.PPCOLL, chPPCOLL)
        Call f4assignInt(TMp.PPRENT, chPPRENT)
        Call f4assignInt(TMp.PPTOW, chPPTOW)
        Call f4assignInt(TMp.CMBI, chCMBI)
        Call f4assignInt(TMp.CMPD, chCMPD)
        Call f4assignInt(TMp.CMMED, chCMMED)
        Call f4assignInt(TMp.CMUMBI, chCMUMBI)
        Call f4assignInt(TMp.CMUMPD, chCMUMPD)
        Call f4assignInt(TMp.CMPIP, chCMPIP)
        Call f4assignInt(TMp.CMCOMP, chCMCOMP)
        Call f4assignInt(TMp.CMCOLL, chCMCOLL)
        Call f4assignInt(TMp.CMRENT, chCMRENT)
        Call f4assignInt(TMp.CMTOW, chCMTOW)
        Call f4assignInt(TMp.IM, chIM)
        Call f4assignInt(TMp.ALLIED, chALLIED)
        Call f4assignInt(TMp.FIRE, chFIRE)
        Call f4assignInt(TMp.MULTIP, chMULTIP)
        Call f4memoAssign(TMp.TrtyHist, txTrtyHist)

    End Sub

    Public Sub UpTrtyMstFlds1()
        Call f4assign(TMp.TrtyReiNmbr1, Format(Val(txTrtyReiNmbr1), "000"))
        Call f4assign(TMp.TrtyReiNmbr2, Format(Val(txTrtyReiNmbr2), "000"))
        Call f4assign(TMp.TrtyReiNmbr3, Format(Val(txTrtyReiNmbr3), "000"))
        Call f4assign(TMp.TrtyReiNmbr4, Format(Val(txTrtyReiNmbr4), "000"))
        Call f4assign(TMp.TrtyReiNmbr5, Format(Val(txTrtyReiNmbr5), "000"))
        Call f4assign(TMp.TrtyReiNmbr6, Format(Val(txTrtyReiNmbr6), "000"))
        Call f4assign(TMp.TrtyReiNmbr7, Format(Val(txTrtyReiNmbr7), "000"))
        Call f4assign(TMp.TrtyReiNmbr8, Format(Val(txTrtyReiNmbr8), "000"))
        Call f4assign(TMp.TrtyReiNmbr9, Format(Val(txTrtyReiNmbr9), "000"))
        Call f4assign(TMp.TrtyReiNmbr10, Format(Val(txTrtyReiNmbr10), "000"))
        Call f4assignDouble(TMp.TrtyReiPerc1, Val(txTrtyReiPerc1) / 100)
        Call f4assignDouble(TMp.TrtyReiPerc2, Val(txTrtyReiPerc2) / 100)
        Call f4assignDouble(TMp.TrtyReiPerc3, Val(txTrtyReiPerc3) / 100)
        Call f4assignDouble(TMp.TrtyReiPerc4, Val(txTrtyReiPerc4) / 100)
        Call f4assignDouble(TMp.TrtyReiPerc5, Val(txTrtyReiPerc5) / 100)
        Call f4assignDouble(TMp.TrtyReiPerc6, Val(txTrtyReiPerc6) / 100)
        Call f4assignDouble(TMp.TrtyReiPerc7, Val(txTrtyReiPerc7) / 100)
        Call f4assignDouble(TMp.TrtyReiPerc8, Val(txTrtyReiPerc8) / 100)
        Call f4assignDouble(TMp.TrtyReiPerc9, Val(txTrtyReiPerc9) / 100)
        Call f4assignDouble(TMp.TrtyReiPerc10, Val(txTrtyReiPerc10) / 100)
        Call f4memoAssign(TMp.TrtyHist, txTrtyHist)
    End Sub

    Public Sub UpTrtyComments()
        Call f4memoAssign(TMp.TrtyHist, txTrtyHist)
    End Sub

    Public Sub AddTrtyMstRec()
        AddTran = True

        If d4appendStart(f3, 0) <> r4success Then
            AddTran = False
            Exit Sub
        End If

        Call UpTrtyMstFlds()
        Call UpTrtyMstFlds1()
        rc = d4append(f3)
        rc = d4unlock(f3)
    End Sub

    Public Sub UpTrtyMstRec()
        If Utrtymst Then Call UpTrtyMstFlds()
        If Utrtyrei Then Call UpTrtyMstFlds1()
        rc = d4unlock(f3)
    End Sub

    Sub RdTrtyMstRec()
        Fstat = 0
        Call d4tagSelect(f3, d4tag(f3, "K1"))
        rc = d4seek(f3, TrtyKey)
        Fstat = rc
        rc = d4unlock(f3)
    End Sub

    Public Sub GetTrtyMstRec()
        UpdateTran = False
        AddTran = False
        Call d4tagSelect(f3, d4tag(f3, "K1"))
        rc = d4seek(f3, TrtyKey)
        If rc <> 0 Then
            AddTran = True
            Exit Sub
        End If
        rc = code4lockAttempts(cb, 1)
        rc = d4lock(f3, d4recNo(f3))
        If rc = r4locked Then
            MsgBox("Record Locked. Unable to edit")
            rc = code4lockAttempts(cb, 0)
            Exit Sub
        End If
        If Utrtymst Then GetTrtyMstVar()
        If Utrtyrei Then GetTrtyReiVar()
        rc = code4lockAttempts(cb, 0)
        UpdateTran = True
    End Sub

    Sub DelTrtyMstRec()
        rc = d4unlock(f3)
        Call d4blank(f3)
    End Sub

    Public Sub GetReiNames()
        Dim X As Short

        For X = 1 To 10
            Rnmbr(X) = ""
            Rname(X) = ""
        Next X

        Rnmbr(1) = Format("{0,D3}", f4str(TMp.TrtyReiNmbr1))
        Rnmbr(2) = Format("{0,D3}", f4str(TMp.TrtyReiNmbr2))
        Rnmbr(3) = Format("{0,D3}", f4str(TMp.TrtyReiNmbr3))
        Rnmbr(4) = Format("{0,D3}", f4str(TMp.TrtyReiNmbr4))
        Rnmbr(5) = Format("{0,D3}", f4str(TMp.TrtyReiNmbr5))
        Rnmbr(6) = Format("{0,D3}", f4str(TMp.TrtyReiNmbr6))
        Rnmbr(7) = Format("{0,D3}", f4str(TMp.TrtyReiNmbr7))
        Rnmbr(8) = Format("{0,D3}", f4str(TMp.TrtyReiNmbr8))
        Rnmbr(9) = Format("{0,D3}", f4str(TMp.TrtyReiNmbr9))
        Rnmbr(10) = Format("{0,D3}", f4str(TMp.TrtyReiNmbr10))

        For X = 1 To 10
            Call d4tagSelect(f2, d4tag(f2, "K1"))
            rc = d4seek(f2, Rnmbr(X))
            If rc = 0 Then Rname(X) = f4str(Rp.ReiName)
        Next X

    End Sub
End Module