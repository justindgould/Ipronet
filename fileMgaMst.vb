Option Strict Off
Option Explicit On
Module fileMgaMst

    Public txMgaNmbr As String
    Public txMgaName As String
    Public txMgaAddr1 As String
    Public txMgaAddr2 As String
    Public txMgaAddr3 As String
    Public txMgaPhone As String
    Public txMgaFax As String
    Public txMgaFein As String
    Public txMgaHist As String

    'FIELD4 structure pointers -- (MGAMST)
    Public Structure PtrMga
        Dim MgaNmbr As Integer
        Dim MgaName As Integer
        Dim MgaAddr1 As Integer
        Dim MgaAddr2 As Integer
        Dim MgaAddr3 As Integer
        Dim MgaPhone As Integer
        Dim MgaFax As Integer
        Dim MgaFein As Integer
        Dim MgaHist As Integer
    End Structure
    Public Mp As PtrMga

    Public Sub GetMgaMstPtr()
        Mp.MgaNmbr = d4field(f1, "MGANMBR")
        Mp.MgaName = d4field(f1, "NAME")
        Mp.MgaAddr1 = d4field(f1, "ADDR1")
        Mp.MgaAddr2 = d4field(f1, "ADDR2")
        Mp.MgaAddr3 = d4field(f1, "ADDR3")
        Mp.MgaPhone = d4field(f1, "PHONE")
        Mp.MgaFax = d4field(f1, "FAX")
        Mp.MgaFein = d4field(f1, "FEIN")
        Mp.MgaHist = d4field(f1, "HIST")
    End Sub

    Public Sub GetMgaMstVar()
        txMgaNmbr = f4str(Mp.MgaNmbr)
        txMgaName = f4str(Mp.MgaName)
        txMgaAddr1 = f4str(Mp.MgaAddr1)
        txMgaAddr2 = f4str(Mp.MgaAddr2)
        txMgaAddr3 = f4str(Mp.MgaAddr3)
        txMgaPhone = f4str(Mp.MgaPhone)
        txMgaFax = f4str(Mp.MgaFax)
        txMgaFein = f4str(Mp.MgaFein)
        txMgaHist = f4memoStr(Mp.MgaHist)
    End Sub

    Public Sub UpMgaMstFlds()
        Call f4assign(Mp.MgaNmbr, Trim(txMgaNmbr))
        Call f4assign(Mp.MgaName, Trim(txMgaName))
        Call f4assign(Mp.MgaAddr1, Trim(txMgaAddr1))
        Call f4assign(Mp.MgaAddr2, Trim(txMgaAddr2))
        Call f4assign(Mp.MgaAddr3, Trim(txMgaAddr3))
        Call f4assign(Mp.MgaPhone, Trim(txMgaPhone))
        Call f4assign(Mp.MgaFax, Trim(txMgaFax))
        Call f4assign(Mp.MgaFein, Trim(txMgaFein))
        Call f4memoAssign(Mp.MgaHist, Trim(txMgaHist))
    End Sub

    Public Sub AddMgaMstRec()
        AddTran = True

        If d4appendStart(f1, 0) <> r4success Then
            AddTran = False
            Exit Sub
        End If

        Call UpMgaMstFlds()
        rc = d4append(f1)
        rc = d4unlock(f1)
    End Sub

    Public Sub UpMgaMstRec()
        Call UpMgaMstFlds()
        rc = d4unlock(f1)
    End Sub

    Sub RdMgaMstRec()
        Fstat = 0
        Call d4tagSelect(f1, d4tag(f1, "K1"))
        rc = d4seek(f1, MgaKey)
        Fstat = rc
        rc = d4unlock(f1)
    End Sub

    Public Sub GetMgaMstRec()
        UpdateTran = False
        AddTran = False
        Call d4tagSelect(f1, d4tag(f1, "K1"))
        rc = d4seek(f1, MgaKey)
        If rc <> 0 Then
            AddTran = True
            Exit Sub
        End If
        rc = code4lockAttempts(cb, 1)
        rc = d4lock(f1, d4recNo(f1))
        If rc = r4locked Then
            MsgBox("Record Locked. Unable to edit")
            rc = code4lockAttempts(cb, 0)
            Exit Sub
        End If
        GetMgaMstVar()
        rc = code4lockAttempts(cb, 0)
        UpdateTran = True
    End Sub

    Sub DelMgaMstRec()
        rc = d4unlock(f1)
        Call d4blank(f1)
    End Sub

End Module
