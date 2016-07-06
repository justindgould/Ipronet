Option Strict Off
Option Explicit On
Module fileReinalloc

    'Reinalloc Vars
    Public txRaReiNmbr As String
    Public txRaMgaNmbr As String
    Public txRaTrtyNmbr As String
    Public txRaReiPerc As String
    Public txRaCession As String
    Public RA(17) As Double


    'FIELD4 structure pointers -- (Reinalloc)
    Public Structure PtrReinAlloc
        Dim ReiNmbr As Integer
        Dim MgaNmbr As Integer
        Dim TrtyNmbr As Integer
        Dim Cession As Integer
        Dim Perc As Integer
        Dim Premium As Integer
        Dim PolFee As Integer
        Dim Commision As Integer
        Dim Unearned As Integer
        Dim PaidLoss As Integer
        Dim PaidLae As Integer
        Dim Salvage As Integer
        Dim OsLoss As Integer
        Dim OsLAE As Integer
        Dim IbnrLoss As Integer
        Dim IbnrLAE As Integer
        Dim ReinPay As Integer
        Dim LossRec As Integer
        Dim LaeRec As Integer
        Dim D30 As Integer
        Dim D90 As Integer
        Dim D120 As Integer
    End Structure
    Public RAp As PtrReinAlloc

    Public Sub GetReinAllocPtr()
        RAp.MgaNmbr = d4field(f30, "MGANMBR")
        RAp.TrtyNmbr = d4field(f30, "TRTYNMBR")
        RAp.ReiNmbr = d4field(f30, "REINMBR")
        RAp.Cession = d4field(f30, "CESSION")
        RAp.Perc = d4field(f30, "CED%")
        RAp.Premium = d4field(f30, "PREMIUM")
        RAp.PolFee = d4field(f30, "POLFEE")
        RAp.Commision = d4field(f30, "COMMISSION")
        RAp.Unearned = d4field(f30, "UNEARNED")
        RAp.PaidLoss = d4field(f30, "PAIDLOSS")
        RAp.PaidLae = d4field(f30, "PAIDLAE")
        RAp.Salvage = d4field(f30, "SALVAGE")
        RAp.PaidLae = d4field(f30, "PAIDLAE")
        RAp.OsLoss = d4field(f30, "OSLOSS")
        RAp.OsLAE = d4field(f30, "OSLAE")
        RAp.IbnrLoss = d4field(f30, "IBNRLOSS")
        RAp.IbnrLAE = d4field(f30, "IBNRLAE")
        RAp.ReinPay = d4field(f30, "REINPAY")
        RAp.LossRec = d4field(f30, "LOSSREC")
        RAp.LaeRec = d4field(f30, "LAEREC")
        RAp.D30 = d4field(f30, "D30")
        RAp.D90 = d4field(f30, "D90")
        RAp.D120 = d4field(f30, "D120")
    End Sub

    Public Sub GetReinAllocVar()
        txRaMgaNmbr = Trim(f4str(RAp.MgaNmbr))
        txRaTrtyNmbr = Trim(f4str(RAp.TrtyNmbr))
        txRaReiNmbr = Trim(f4str(RAp.ReiNmbr))
        txRaCession = Trim(f4str(RAp.Cession))

        txRaReiPerc = "      "
        txRaReiPerc = Format("{0,f2}", f4double(RAp.Perc) * 100)

        RA(1) = f4double(RAp.Premium)
        RA(2) = f4double(RAp.PolFee)
        RA(3) = f4double(RAp.Commision)
        RA(4) = f4double(RAp.Unearned)
        RA(5) = f4double(RAp.PaidLoss)
        RA(6) = f4double(RAp.Salvage)
        RA(7) = f4double(RAp.PaidLae)
        RA(8) = f4double(RAp.OsLoss)
        RA(9) = f4double(RAp.OsLAE)
        RA(10) = f4double(RAp.IbnrLoss)
        RA(11) = f4double(RAp.IbnrLAE)
        RA(12) = f4double(RAp.ReinPay)
        RA(13) = f4double(RAp.LossRec)
        RA(14) = f4double(RAp.LaeRec)
        RA(15) = f4double(RAp.D30)
        RA(16) = f4double(RAp.D90)
        RA(17) = f4double(RAp.D120)
    End Sub

    Public Sub GetReinAllocRec()
        UpdateTran = False
        AddTran = False
        Fstat = 0
        Call d4tagSelect(f30, d4tag(f30, "K1"))
        rc = d4seek(f30, ReinAllocKey)

        If rc <> 0 Then
            AddTran = True
            Exit Sub
        End If

        rc = code4lockAttempts(cb, 1)
        rc = d4lock(f30, d4recNo(f30))
        If rc = r4locked Then
            Fstat = rc
            MsgBox("Record Locked. Unable to edit")
            rc = code4lockAttempts(cb, 0)
            Exit Sub
        End If
        GetReinAllocVar()
        rc = code4lockAttempts(cb, 0)
        UpdateTran = True
    End Sub
End Module