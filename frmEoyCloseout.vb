Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmEoyCloseout
    Inherits DevExpress.XtraEditors.XtraForm

    'Dim currentYearDate As Date = DateTime.Today.AddYears(-1)
    Dim currentYearDate As Date = DateTime.Today()
    Dim currentYear = Format(currentYearDate, "yyyy")
    Dim lastYear = Format(currentYearDate.AddYears(-1), "yyyy")
    Dim closeYear As String
    Dim J4str As String = "December 31," & currentYear
    Dim Fileold As String
    Dim Filenew As String
    Dim Period As String = "12"
    Dim CatCode As String
    Dim Wyear As String
    Dim Wperiod As String
    Dim A(24) As Double
    Private db As Integer
    Private dbname As String


    Private Sub Stage1_Click(sender As Object, e As EventArgs) Handles Stage1.Click
        closeYear = txtYear.Text.Substring(txtYear.Text.Length - 2)
        MessageBox.Show("Click OK to start the Closeout Process. This will take a few minutes.")
        GetFilePaths()
        RunEoyYtdAccum()
        RunEoyItdAccum()
        RunEoyUepUpdate()
        RunEoyRptUpdate()
        MessageBox.Show("Closeout Process Ended. Have Lee Ann check the output.")
    End Sub

    Private Sub YtdCopy()
    End Sub

    Private Sub RunEoyYtdAccum()

        ' Copy YTDDIR to YTDDIR## for previous year
        Fileold = InsVars.Dpath & "YTDDIR.dbf"
        Filenew = InsVars.Dpath & "YTDDIR" & CStr(CInt(closeYear) - 1) & ".dbf"
        If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
        System.IO.File.Copy(Fileold, Filenew)

        Fileold = InsVars.Dpath & "YTDDIR.cdx"
        Filenew = InsVars.Dpath & "YTDDIR" & CStr(CInt(closeYear) - 1) & ".cdx"
        If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
        System.IO.File.Copy(Fileold, Filenew)

        ' Clear current YTDDIR
        dbname = InsVars.Dpath & "YTDDIR.dbf"
        ClearDatabase()

        ' Copy YTDCED# to new YTDCED### for previous year
        For index As Integer = 1 To 5
            Fileold = InsVars.Dpath & "YTDCED" & CStr(index) & ".dbf"
            Filenew = InsVars.Dpath & "YTDCED" & CStr(index) & CStr(CInt(closeYear) - 1) & ".dbf"
            If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
            System.IO.File.Copy(Fileold, Filenew)

            Fileold = InsVars.Dpath & "YTDCED" & CStr(index) & ".cdx"
            Filenew = InsVars.Dpath & "YTDCED" & CStr(index) & CStr(CInt(closeYear) - 1) & ".cdx"
            If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
            System.IO.File.Copy(Fileold, Filenew)
        Next

        ' Clear current YTDCED#
        For index As Integer = 1 To 5
            dbname = InsVars.Dpath & "YTDCED" & CStr(index) & ".dbf"
            ClearDatabase()
        Next

        'RPT Dir
        OpenRptDir()
        OpenYtdDir()
        TotalYtdDir()
        ClsRptDir() : f5 = 0
        ClsYtdDir() : f9 = 0

        'RPT Ced1
        OpenRptCed1()
        OpenYtdCed1()
        TotalYtdCed()
        ClsRptCed1() : f6 = 0
        ClsYtdCed1() : f10 = 0

        'RPT Ced2
        OpenRptCed2()
        OpenYtdCed2()
        TotalYtdCed()
        ClsRptCed2() : f6 = 0
        ClsYtdCed2() : f10 = 0

        'RPT Ced3
        OpenRptCed3()
        OpenYtdCed3()
        TotalYtdCed()
        ClsRptCed3() : f6 = 0
        ClsYtdCed3() : f10 = 0

        'RPT Ced4
        OpenRptCed4()
        OpenYtdCed4()
        TotalYtdCed()
        ClsRptCed4() : f6 = 0
        ClsYtdCed4() : f10 = 0

        'RPT Ced5
        OpenRptCed5()
        OpenYtdCed5()
        TotalYtdCed()
        ClsRptCed5() : f6 = 0
        ClsYtdCed5() : f10 = 0
    End Sub

    Private Sub RunEoyItdAccum()
        ' Copy ITDDIR# to ITDDIR### 
        Fileold = InsVars.Dpath & "ITDDIR.dbf"
        Filenew = InsVars.Dpath & "ITDDIR" & closeYear & ".dbf"
        If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
        System.IO.File.Copy(Fileold, Filenew)

        Fileold = InsVars.Dpath & "ITDDIR.cdx"
        Filenew = InsVars.Dpath & "ITDDIR" & closeYear & ".cdx"
        If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
        System.IO.File.Copy(Fileold, Filenew)

        ' Copy ITDCED# to ITDCED###
        For index As Integer = 1 To 5
            Fileold = InsVars.Dpath & "ITDCED" & CStr(index) & ".dbf"
            Filenew = InsVars.Dpath & "ITDCED" & CStr(index) & closeYear & ".dbf"
            If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
            System.IO.File.Copy(Fileold, Filenew)

            Fileold = InsVars.Dpath & "ITDCED" & CStr(index) & ".cdx"
            Filenew = InsVars.Dpath & "ITDCED" & CStr(index) & closeYear & ".cdx"
            If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
            System.IO.File.Copy(Fileold, Filenew)
        Next

        ' Clear ITDDIR##
        dbname = InsVars.Dpath & "ITDDIR" & closeYear & ".dbf"
        ClearDatabase()

        ' Clear ITDCED###
        For index As Integer = 1 To 5
            dbname = InsVars.Dpath & "ITDCED" & CStr(index) & closeYear & ".dbf"
            ClearDatabase()
        Next

        Nwdir = InsVars.Dpath & "ITDDIR" & closeYear & ".dbf"
        Nwced1 = InsVars.Dpath & "ITDCED1" & closeYear & ".dbf"
        Nwced2 = InsVars.Dpath & "ITDCED2" & closeYear & ".dbf"
        Nwced3 = InsVars.Dpath & "ITDCED3" & closeYear & ".dbf"
        Nwced4 = InsVars.Dpath & "ITDCED4" & closeYear & ".dbf"
        Nwced5 = InsVars.Dpath & "ITDCED5" & closeYear & ".dbf"

        'Write ITD Dir
        OpenWorkDir()
        OpenItdDir()
        OpenYtdDir()
        TotalItdDir()
        TotalItdYtdDir()
        ClsYtdDir() : f9 = 0
        ClsItdDir() : f11 = 0
        ClsWorkDir() : f13 = 0

        'Write ITD Ced1
        OpenWorkCed1()
        OpenItdCed1()
        OpenYtdCed1()
        TotalItdCed()
        TotalItdYtdCed()
        ClsYtdCed1() : f10 = 0
        ClsItdCed1() : f12 = 0
        ClsWorkCed1() : f14 = 0

        'Write ITD Ced2
        OpenWorkCed2()
        OpenItdCed2()
        OpenYtdCed2()
        TotalItdCed()
        TotalItdYtdCed()
        ClsYtdCed2() : f10 = 0
        ClsItdCed2() : f12 = 0
        ClsWorkCed2() : f14 = 0

        'Write ITD Ced3
        OpenWorkCed3()
        OpenItdCed3()
        OpenYtdCed3()
        TotalItdCed()
        TotalItdYtdCed()
        ClsYtdCed3() : f10 = 0
        ClsItdCed3() : f12 = 0
        ClsWorkCed3() : f14 = 0

        'Write ITD Ced4
        OpenWorkCed4()
        OpenItdCed4()
        OpenYtdCed4()
        TotalItdCed()
        TotalItdYtdCed()
        ClsYtdCed4() : f10 = 0
        ClsItdCed4() : f12 = 0
        ClsWorkCed4() : f14 = 0

        'Write ITD Ced5
        OpenWorkCed5()
        OpenItdCed5()
        OpenYtdCed5()
        TotalItdCed()
        TotalItdYtdCed()
        ClsYtdCed5() : f10 = 0
        ClsItdCed5() : f12 = 0
        ClsWorkCed5() : f14 = 0

        ' Copy ITDDIR files
        Fileold = InsVars.Dpath & "ITDDIR.dbf"
        Filenew = InsVars.Dpath & "ITDDIR" & CStr(CInt(closeYear) - 1) & ".dbf"
        If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
        System.IO.File.Move(Fileold, Filenew)

        Fileold = InsVars.Dpath & "ITDDIR.cdx"
        Filenew = InsVars.Dpath & "ITDDIR" & CStr(CInt(closeYear) - 1) & ".cdx"
        If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
        System.IO.File.Move(Fileold, Filenew)

        Fileold = InsVars.Dpath & "ITDDIR" & closeYear & ".dbf"
        Filenew = InsVars.Dpath & "ITDDIR.dbf"
        If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
        System.IO.File.Move(Fileold, Filenew)

        Fileold = InsVars.Dpath & "ITDDIR" & closeYear & ".cdx"
        Filenew = InsVars.Dpath & "ITDDIR.cdx"
        If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
        System.IO.File.Move(Fileold, Filenew)


        For index As Integer = 1 To 5
            Fileold = InsVars.Dpath & "ITDCED" & CStr(index) & ".dbf"
            Filenew = InsVars.Dpath & "ITDCED" & CStr(index) & CStr(CInt(closeYear) - 1) & ".dbf"
            If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
            System.IO.File.Move(Fileold, Filenew)

            Fileold = InsVars.Dpath & "ITDCED" & CStr(index) & ".cdx"
            Filenew = InsVars.Dpath & "ITDCED" & CStr(index) & CStr(CInt(closeYear) - 1) & ".cdx"
            If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
            System.IO.File.Move(Fileold, Filenew)
        Next

        For index As Integer = 1 To 5
            Fileold = InsVars.Dpath & "ITDCED" & CStr(index) & closeYear & ".dbf"
            Filenew = InsVars.Dpath & "ITDCED" & CStr(index) & ".dbf"
            If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
            System.IO.File.Move(Fileold, Filenew)

            Fileold = InsVars.Dpath & "ITDCED" & CStr(index) & closeYear & ".cdx"
            Filenew = InsVars.Dpath & "ITDCED" & CStr(index) & ".cdx"
            If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
            System.IO.File.Move(Fileold, Filenew)
        Next

    End Sub

    Private Sub RunEoyUepUpdate()
        'Increment year before running
        Nwdir = InsVars.Dpath & "YTDDIR" & CStr(CInt(closeYear) - 1) & ".dbf"
        Nwced1 = InsVars.Dpath & "YTDCED1" & CStr(CInt(closeYear) - 1) & ".dbf"
        Nwced2 = InsVars.Dpath & "YTDCED2" & CStr(CInt(closeYear) - 1) & ".dbf"
        Nwced3 = InsVars.Dpath & "YTDCED3" & CStr(CInt(closeYear) - 1) & ".dbf"
        Nwced4 = InsVars.Dpath & "YTDCED4" & CStr(CInt(closeYear) - 1) & ".dbf"
        Nwced5 = InsVars.Dpath & "YTDCED5" & CStr(CInt(closeYear) - 1) & ".dbf"

        'Write UEP Dir
        OpenUepDir()
        OpenWorkDir()
        TotalUepDir()
        ClsWorkDir() : f13 = 0
        ClsUepDir() : f7 = 0

        'Write UEP Ced1
        OpenUepCed1()
        OpenWorkCed1()
        TotalUepCed()
        ClsWorkCed1() : f14 = 0
        ClsUepCed1() : f8 = 0

        'Write UEP Ced2
        OpenUepCed2()
        OpenWorkCed2()
        TotalUepCed()
        ClsWorkCed2() : f14 = 0
        ClsUepCed2() : f8 = 0

        'Write UEP Ced3
        OpenUepCed3()
        OpenWorkCed3()
        TotalUepCed()
        ClsWorkCed3() : f14 = 0
        ClsUepCed3() : f8 = 0

        'Write UEP Ced4
        OpenUepCed4()
        OpenWorkCed4()
        TotalUepCed()
        ClsWorkCed4() : f14 = 0
        ClsUepCed4() : f8 = 0

        'Write UEP Ced5
        OpenUepCed5()
        OpenWorkCed5()
        TotalUepCed()
        ClsWorkCed5() : f14 = 0
        ClsUepCed5() : f8 = 0

    End Sub

    Private Sub TotalUepDir()
        Dim X As Integer

        Call d4tagSelect(f13, d4tag(f13, "K1"))
        rc = d4top(f13)
        WorkDirKey = ""
        rc = d4seek(f13, WorkDirKey)

        Do Until rc = r4eof
            If Trim(f4str(WDp.WorkMgaNmbr)) = "016" Then
                If Trim(f4str(WDp.WorkPeriod)) <> Period Then GoTo nextrec
            End If

            CatCode = Trim(f4str(WDp.WorkCatCode))
            Wyear = Trim(f4str(WDp.WorkYear))
            Wperiod = Trim(f4str(WDp.WorkPeriod))

            If CDbl(CatCode) <> 4 Then GoTo nextrec
            If Period <> Wperiod Then GoTo nextrec


            'Write To UEP Dir File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetWorkDirVar()

            UepDirKey = Trim(f4str(WDp.WorkMgaNmbr)) & Trim(f4str(WDp.WorkTrtyNmbr)) & "12" & Trim(f4str(WDp.WorkCatCode)) & Trim(f4str(WDp.WorkYear))

            Call d4tagSelect(f7, d4tag(f7, "K1"))
            rc = d4top(f7)
            rc = d4seek(f7, UepDirKey)

            AddTran = False
            If UepDirKey <> Trim(f4str(UEp.UepMgaNmbr)) & Trim(f4str(UEp.UepTrtyNmbr)) & "12" & Trim(f4str(UEp.UepCatCode)) & Trim(f4str(UEp.UepYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f7, 0) <> r4success Then Exit Sub
                Call f4assign(UEp.UepMgaNmbr, Trim(f4str(WDp.WorkMgaNmbr)))
                Call f4assign(UEp.UepTrtyNmbr, Trim(f4str(WDp.WorkTrtyNmbr)))
                Call f4assign(UEp.UepPeriod, "12")
                Call f4assign(UEp.UepCatCode, Trim(f4str(WDp.WorkCatCode)))
                Call f4assign(UEp.UepYear, Trim(f4str(WDp.WorkYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(UEp.UepTotal) : A(1) = f4double(UEp.UepPPbi)
                A(2) = f4double(UEp.UepPPpd) : A(3) = f4double(UEp.UepPPmed)
                A(4) = f4double(UEp.UepPPumbi) : A(5) = f4double(UEp.UepPPumpd)
                A(6) = f4double(UEp.UepPPpip) : A(7) = f4double(UEp.UepPPcomp)
                A(8) = f4double(UEp.UepPPcoll) : A(9) = f4double(UEp.UepPPrent)
                A(10) = f4double(UEp.UepPPtow) : A(11) = f4double(UEp.UepCMbi)
                A(12) = f4double(UEp.UepCMpd) : A(13) = f4double(UEp.UepCMmed)
                A(14) = f4double(UEp.UepCMumbi) : A(15) = f4double(UEp.UepCMumpd)
                A(16) = f4double(UEp.UepCMpip) : A(17) = f4double(UEp.UepCMcomp)
                A(18) = f4double(UEp.UepCMcoll) : A(19) = f4double(UEp.UepCMrent)
                A(20) = f4double(UEp.UepCMtow) : A(21) = f4double(UEp.UepOTim)
                A(22) = f4double(UEp.UepOTallied) : A(23) = f4double(UEp.UepOTfire)
                A(24) = f4double(UEp.UepOTmulti)
            End If

            Call f4assignDouble(UEp.UepTotal, A(0) + MLobt)
            Call f4assignDouble(UEp.UepPPbi, A(1) + MLobp(1))
            Call f4assignDouble(UEp.UepPPpd, A(2) + MLobp(2))
            Call f4assignDouble(UEp.UepPPmed, A(3) + MLobp(3))
            Call f4assignDouble(UEp.UepPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(UEp.UepPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(UEp.UepPPpip, A(6) + MLobp(6))
            Call f4assignDouble(UEp.UepPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(UEp.UepPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(UEp.UepPPrent, A(9) + MLobp(9))
            Call f4assignDouble(UEp.UepPPtow, A(10) + MLobp(10))
            Call f4assignDouble(UEp.UepCMbi, A(11) + MLobp(11))
            Call f4assignDouble(UEp.UepCMpd, A(12) + MLobp(12))
            Call f4assignDouble(UEp.UepCMmed, A(13) + MLobp(13))
            Call f4assignDouble(UEp.UepCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(UEp.UepCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(UEp.UepCMpip, A(16) + MLobp(16))
            Call f4assignDouble(UEp.UepCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(UEp.UepCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(UEp.UepCMrent, A(19) + MLobp(19))
            Call f4assignDouble(UEp.UepCMtow, A(20) + MLobp(20))
            Call f4assignDouble(UEp.UepOTim, A(21) + MLobp(21))
            Call f4assignDouble(UEp.UepOTallied, A(22) + MLobp(22))
            Call f4assignDouble(UEp.UepOTfire, A(23) + MLobp(23))
            Call f4assignDouble(UEp.UepOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f7)
                rc = d4unlock(f7)
            End If

nextrec:
            rc = d4skip(f13, 1)
        Loop
    End Sub

    Private Sub TotalUepCed()
        Dim X As Integer

        Call d4tagSelect(f14, d4tag(f14, "K1"))
        rc = d4top(f14)
        WorkCedKey = ""
        rc = d4seek(f14, WorkCedKey)

        Do Until rc = r4eof

            If Trim(f4str(Wc1p.CedMgaNmbr)) = "016" Then
                If Trim(f4str(Wc1p.CedPeriod)) <> Period Then GoTo nextrec
            End If

            CatCode = Trim(f4str(Wc1p.CedCatCode))
            Wyear = Trim(f4str(Wc1p.CedYear))
            Wperiod = Trim(f4str(Wc1p.CedPeriod))

            If CDbl(CatCode) <> 4 Then GoTo nextrec
            If Period <> Wperiod Then GoTo nextrec

            'Write To UEP Ced File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetWorkCedVar()

            UepCedKey = Trim(f4str(Wc1p.CedMgaNmbr)) & Trim(f4str(Wc1p.CedTrtyNmbr)) & "12" & Trim(f4str(Wc1p.CedCatCode)) & Trim(f4str(Wc1p.CedYear))

            Call d4tagSelect(f8, d4tag(f8, "K1"))
            rc = d4top(f8)
            rc = d4seek(f8, UepCedKey)

            AddTran = False
            If UepCedKey <> Trim(f4str(Uc1p.CedMgaNmbr)) & Trim(f4str(Uc1p.CedTrtyNmbr)) & "12" & Trim(f4str(Uc1p.CedCatCode)) & Trim(f4str(Uc1p.CedYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f8, 0) <> r4success Then Exit Sub
                Call f4assign(Uc1p.CedMgaNmbr, Trim(f4str(Wc1p.CedMgaNmbr)))
                Call f4assign(Uc1p.CedTrtyNmbr, Trim(f4str(Wc1p.CedTrtyNmbr)))
                Call f4assign(Uc1p.CedPeriod, "12")
                Call f4assign(Uc1p.CedCatCode, Trim(f4str(Wc1p.CedCatCode)))
                Call f4assign(Uc1p.CedYear, Trim(f4str(Wc1p.CedYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(Uc1p.CedTotal) : A(1) = f4double(Uc1p.CedPPbi)
                A(2) = f4double(Uc1p.CedPPpd) : A(3) = f4double(Uc1p.CedPPmed)
                A(4) = f4double(Uc1p.CedPPumbi) : A(5) = f4double(Uc1p.CedPPumpd)
                A(6) = f4double(Uc1p.CedPPpip) : A(7) = f4double(Uc1p.CedPPcomp)
                A(8) = f4double(Uc1p.CedPPcoll) : A(9) = f4double(Uc1p.CedPPrent)
                A(10) = f4double(Uc1p.CedPPtow) : A(11) = f4double(Uc1p.CedCMbi)
                A(12) = f4double(Uc1p.CedCMpd) : A(13) = f4double(Uc1p.CedCMmed)
                A(14) = f4double(Uc1p.CedCMumbi) : A(15) = f4double(Uc1p.CedCMumpd)
                A(16) = f4double(Uc1p.CedCMpip) : A(17) = f4double(Uc1p.CedCMcomp)
                A(18) = f4double(Uc1p.CedCMcoll) : A(19) = f4double(Uc1p.CedCMrent)
                A(20) = f4double(Uc1p.CedCMtow) : A(21) = f4double(Uc1p.CedOTim)
                A(22) = f4double(Uc1p.CedOTallied) : A(23) = f4double(Uc1p.CedOTfire)
                A(24) = f4double(Uc1p.CedOTmulti)
            End If

            Call f4assignDouble(Uc1p.CedTotal, A(0) + MLobt)
            Call f4assignDouble(Uc1p.CedPPbi, A(1) + MLobp(1))
            Call f4assignDouble(Uc1p.CedPPpd, A(2) + MLobp(2))
            Call f4assignDouble(Uc1p.CedPPmed, A(3) + MLobp(3))
            Call f4assignDouble(Uc1p.CedPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(Uc1p.CedPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(Uc1p.CedPPpip, A(6) + MLobp(6))
            Call f4assignDouble(Uc1p.CedPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(Uc1p.CedPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(Uc1p.CedPPrent, A(9) + MLobp(9))
            Call f4assignDouble(Uc1p.CedPPtow, A(10) + MLobp(10))
            Call f4assignDouble(Uc1p.CedCMbi, A(11) + MLobp(11))
            Call f4assignDouble(Uc1p.CedCMpd, A(12) + MLobp(12))
            Call f4assignDouble(Uc1p.CedCMmed, A(13) + MLobp(13))
            Call f4assignDouble(Uc1p.CedCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(Uc1p.CedCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(Uc1p.CedCMpip, A(16) + MLobp(16))
            Call f4assignDouble(Uc1p.CedCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(Uc1p.CedCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(Uc1p.CedCMrent, A(19) + MLobp(19))
            Call f4assignDouble(Uc1p.CedCMtow, A(20) + MLobp(20))
            Call f4assignDouble(Uc1p.CedOTim, A(21) + MLobp(21))
            Call f4assignDouble(Uc1p.CedOTallied, A(22) + MLobp(22))
            Call f4assignDouble(Uc1p.CedOTfire, A(23) + MLobp(23))
            Call f4assignDouble(Uc1p.CedOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f8)
                rc = d4unlock(f8)
            End If

nextrec:
            rc = d4skip(f14, 1)
        Loop

    End Sub

    Private Sub TotalYtdDir()
        Dim X As Integer

        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)
        RptDirKey = ""
        rc = d4seek(f5, RptDirKey)

        Do Until rc = r4eof
            If Trim(f4str(RDp.RptMgaNmbr)) = "016" Then
                If Trim(f4str(RDp.RptPeriod)) <> Period Then GoTo nextrec
            End If

            CatCode = Trim(f4str(RDp.RptCatCode))
            Wyear = Trim(f4str(RDp.RptYear))
            Wperiod = Trim(f4str(RDp.RptPeriod))

            If CDbl(CatCode) = 4 Or CDbl(CatCode) = 9 Or CDbl(CatCode) = 10 Or CDbl(CatCode) = 13 Or CDbl(CatCode) = 14 Or CDbl(CatCode) = 15 Or CDbl(CatCode) = 16 Or CDbl(CatCode) = 17 Then
                If Period <> Wperiod Then GoTo nextrec
            End If

            'Write To YTD Dir File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetRptDirVar()

            YtdDirKey = txRptMgaNmbr & txRptTrtyNmbr & "12" & txRptCatCode & txRptYear
            Call d4tagSelect(f9, d4tag(f9, "K1"))
            rc = d4top(f9)
            rc = d4seek(f9, YtdDirKey)

            AddTran = False
            If YtdDirKey <> Trim(f4str(YDp.YtdMgaNmbr)) & Trim(f4str(YDp.YtdTrtyNmbr)) & "12" & Trim(f4str(YDp.YtdCatCode)) & Trim(f4str(YDp.YtdYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f9, 0) <> r4success Then Exit Sub
                Call f4assign(YDp.YtdMgaNmbr, txRptMgaNmbr)
                Call f4assign(YDp.YtdTrtyNmbr, txRptTrtyNmbr)
                Call f4assign(YDp.YtdPeriod, "12")
                Call f4assign(YDp.YtdCatCode, txRptCatCode)
                Call f4assign(YDp.YtdYear, txRptYear)
            End If

            If Not AddTran Then
                A(0) = f4double(YDp.YtdTotal) : A(1) = f4double(YDp.YtdPPbi)
                A(2) = f4double(YDp.YtdPPpd) : A(3) = f4double(YDp.YtdPPmed)
                A(4) = f4double(YDp.YtdPPumbi) : A(5) = f4double(YDp.YtdPPumpd)
                A(6) = f4double(YDp.YtdPPpip) : A(7) = f4double(YDp.YtdPPcomp)
                A(8) = f4double(YDp.YtdPPcoll) : A(9) = f4double(YDp.YtdPPrent)
                A(10) = f4double(YDp.YtdPPtow) : A(11) = f4double(YDp.YtdCMbi)
                A(12) = f4double(YDp.YtdCMpd) : A(13) = f4double(YDp.YtdCMmed)
                A(14) = f4double(YDp.YtdCMumbi) : A(15) = f4double(YDp.YtdCMumpd)
                A(16) = f4double(YDp.YtdCMpip) : A(17) = f4double(YDp.YtdCMcomp)
                A(18) = f4double(YDp.YtdCMcoll) : A(19) = f4double(YDp.YtdCMrent)
                A(20) = f4double(YDp.YtdCMtow) : A(21) = f4double(YDp.YtdOTim)
                A(22) = f4double(YDp.YtdOTallied) : A(23) = f4double(YDp.YtdOTfire)
                A(24) = f4double(YDp.YtdOTmulti)
            End If

            Call f4assignDouble(YDp.YtdTotal, A(0) + MLobt)
            Call f4assignDouble(YDp.YtdPPbi, A(1) + MLobp(1))
            Call f4assignDouble(YDp.YtdPPpd, A(2) + MLobp(2))
            Call f4assignDouble(YDp.YtdPPmed, A(3) + MLobp(3))
            Call f4assignDouble(YDp.YtdPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(YDp.YtdPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(YDp.YtdPPpip, A(6) + MLobp(6))
            Call f4assignDouble(YDp.YtdPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(YDp.YtdPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(YDp.YtdPPrent, A(9) + MLobp(9))
            Call f4assignDouble(YDp.YtdPPtow, A(10) + MLobp(10))
            Call f4assignDouble(YDp.YtdCMbi, A(11) + MLobp(11))
            Call f4assignDouble(YDp.YtdCMpd, A(12) + MLobp(12))
            Call f4assignDouble(YDp.YtdCMmed, A(13) + MLobp(13))
            Call f4assignDouble(YDp.YtdCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(YDp.YtdCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(YDp.YtdCMpip, A(16) + MLobp(16))
            Call f4assignDouble(YDp.YtdCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(YDp.YtdCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(YDp.YtdCMrent, A(19) + MLobp(19))
            Call f4assignDouble(YDp.YtdCMtow, A(20) + MLobp(20))
            Call f4assignDouble(YDp.YtdOTim, A(21) + MLobp(21))
            Call f4assignDouble(YDp.YtdOTallied, A(22) + MLobp(22))
            Call f4assignDouble(YDp.YtdOTfire, A(23) + MLobp(23))
            Call f4assignDouble(YDp.YtdOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f9)
                rc = d4unlock(f9)
            End If

nextrec:
            rc = d4skip(f5, 1)
        Loop

    End Sub

    Private Sub TotalYtdCed()
        Dim X As Integer

        Call d4tagSelect(f6, d4tag(f6, "K1"))
        rc = d4top(f6)
        RptCedKey = ""
        rc = d4seek(f6, RptCedKey)

        Do Until rc = r4eof
            If Trim(f4str(Rc1p.CedMgaNmbr)) = "016" Then
                If Trim(f4str(Rc1p.CedPeriod)) <> Period Then GoTo nextrec
            End If

            CatCode = Trim(f4str(Rc1p.CedCatCode))
            Wyear = Trim(f4str(Rc1p.CedYear))
            Wperiod = Trim(f4str(Rc1p.CedPeriod))

            If CDbl(CatCode) = 4 Or CDbl(CatCode) = 9 Or CDbl(CatCode) = 10 Or CDbl(CatCode) = 13 Or CDbl(CatCode) = 14 Or CDbl(CatCode) = 15 Or CDbl(CatCode) = 16 Or CDbl(CatCode) = 17 Then
                If Period <> Wperiod Then GoTo nextrec
            End If

            'Write To YTD Dir File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetRptCedVar()

            YtdCedKey = Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) & "12" & Trim(f4str(Rc1p.CedCatCode)) & Trim(f4str(Rc1p.CedYear))
            Call d4tagSelect(f10, d4tag(f10, "K1"))
            rc = d4top(f10)
            rc = d4seek(f10, YtdCedKey)

            AddTran = False
            If YtdCedKey <> Trim(f4str(YDc1p.CedMgaNmbr)) & Trim(f4str(YDc1p.CedTrtyNmbr)) & "12" & Trim(f4str(YDc1p.CedCatCode)) & Trim(f4str(YDc1p.CedYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f10, 0) <> r4success Then Exit Sub
                Call f4assign(YDc1p.CedMgaNmbr, Trim(f4str(Rc1p.CedMgaNmbr)))
                Call f4assign(YDc1p.CedTrtyNmbr, Trim(f4str(Rc1p.CedTrtyNmbr)))
                Call f4assign(YDc1p.CedPeriod, "12")
                Call f4assign(YDc1p.CedCatCode, Trim(f4str(Rc1p.CedCatCode)))
                Call f4assign(YDc1p.CedYear, Trim(f4str(Rc1p.CedYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(YDc1p.CedTotal) : A(1) = f4double(YDc1p.CedPPbi)
                A(2) = f4double(YDc1p.CedPPpd) : A(3) = f4double(YDc1p.CedPPmed)
                A(4) = f4double(YDc1p.CedPPumbi) : A(5) = f4double(YDc1p.CedPPumpd)
                A(6) = f4double(YDc1p.CedPPpip) : A(7) = f4double(YDc1p.CedPPcomp)
                A(8) = f4double(YDc1p.CedPPcoll) : A(9) = f4double(YDc1p.CedPPrent)
                A(10) = f4double(YDc1p.CedPPtow) : A(11) = f4double(YDc1p.CedCMbi)
                A(12) = f4double(YDc1p.CedCMpd) : A(13) = f4double(YDc1p.CedCMmed)
                A(14) = f4double(YDc1p.CedCMumbi) : A(15) = f4double(YDc1p.CedCMumpd)
                A(16) = f4double(YDc1p.CedCMpip) : A(17) = f4double(YDc1p.CedCMcomp)
                A(18) = f4double(YDc1p.CedCMcoll) : A(19) = f4double(YDc1p.CedCMrent)
                A(20) = f4double(YDc1p.CedCMtow) : A(21) = f4double(YDc1p.CedOTim)
                A(22) = f4double(YDc1p.CedOTallied) : A(23) = f4double(YDc1p.CedOTfire)
                A(24) = f4double(YDc1p.CedOTmulti)
            End If

            Call f4assignDouble(YDc1p.CedTotal, A(0) + MLobt)
            Call f4assignDouble(YDc1p.CedPPbi, A(1) + MLobp(1))
            Call f4assignDouble(YDc1p.CedPPpd, A(2) + MLobp(2))
            Call f4assignDouble(YDc1p.CedPPmed, A(3) + MLobp(3))
            Call f4assignDouble(YDc1p.CedPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(YDc1p.CedPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(YDc1p.CedPPpip, A(6) + MLobp(6))
            Call f4assignDouble(YDc1p.CedPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(YDc1p.CedPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(YDc1p.CedPPrent, A(9) + MLobp(9))
            Call f4assignDouble(YDc1p.CedPPtow, A(10) + MLobp(10))
            Call f4assignDouble(YDc1p.CedCMbi, A(11) + MLobp(11))
            Call f4assignDouble(YDc1p.CedCMpd, A(12) + MLobp(12))
            Call f4assignDouble(YDc1p.CedCMmed, A(13) + MLobp(13))
            Call f4assignDouble(YDc1p.CedCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(YDc1p.CedCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(YDc1p.CedCMpip, A(16) + MLobp(16))
            Call f4assignDouble(YDc1p.CedCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(YDc1p.CedCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(YDc1p.CedCMrent, A(19) + MLobp(19))
            Call f4assignDouble(YDc1p.CedCMtow, A(20) + MLobp(20))
            Call f4assignDouble(YDc1p.CedOTim, A(21) + MLobp(21))
            Call f4assignDouble(YDc1p.CedOTallied, A(22) + MLobp(22))
            Call f4assignDouble(YDc1p.CedOTfire, A(23) + MLobp(23))
            Call f4assignDouble(YDc1p.CedOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f10)
                rc = d4unlock(f10)
            End If

nextrec:
            rc = d4skip(f6, 1)
        Loop

    End Sub

    Private Sub TotalItdDir()
        Dim X As Integer

        Call d4tagSelect(f11, d4tag(f11, "K1"))
        rc = d4top(f11)
        ItdDirKey = ""
        rc = d4seek(f11, ItdDirKey)

        Do Until rc = r4eof
            If Trim(f4str(IDp.ItdMgaNmbr)) = "016" Then
                If Trim(f4str(IDp.ItdPeriod)) <> Period Then GoTo nextrec
            End If

            CatCode = Trim(f4str(IDp.ItdCatCode))
            Wyear = Trim(f4str(IDp.ItdYear))
            Wperiod = Trim(f4str(IDp.ItdPeriod))

            If CDbl(CatCode) = 4 Then GoTo nextrec
            If CDbl(CatCode) = 9 Then GoTo nextrec
            If CDbl(CatCode) = 10 Then GoTo nextrec
            If CDbl(CatCode) = 13 Then GoTo nextrec
            If CDbl(CatCode) = 14 Then GoTo nextrec
            If CDbl(CatCode) = 15 Then GoTo nextrec
            If CDbl(CatCode) = 16 Then GoTo nextrec
            If CDbl(CatCode) = 17 Then GoTo nextrec

            'Write To ITD Dir File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetItdDirVar()

            WorkDirKey = Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr)) & "12" & Trim(f4str(IDp.ItdCatCode)) & Trim(f4str(IDp.ItdYear))

            Call d4tagSelect(f13, d4tag(f13, "K1"))
            rc = d4top(f13)
            rc = d4seek(f13, WorkDirKey)

            AddTran = False
            If WorkDirKey <> Trim(f4str(WDp.WorkMgaNmbr)) & Trim(f4str(WDp.WorkTrtyNmbr)) & "12" & Trim(f4str(WDp.WorkCatCode)) & Trim(f4str(WDp.WorkYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f13, 0) <> r4success Then Exit Sub
                Call f4assign(WDp.WorkMgaNmbr, Trim(f4str(IDp.ItdMgaNmbr)))
                Call f4assign(WDp.WorkTrtyNmbr, Trim(f4str(IDp.ItdTrtyNmbr)))
                Call f4assign(WDp.WorkPeriod, "12")
                Call f4assign(WDp.WorkCatCode, Trim(f4str(IDp.ItdCatCode)))
                Call f4assign(WDp.WorkYear, Trim(f4str(IDp.ItdYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(WDp.WorkTotal) : A(1) = f4double(WDp.WorkPPbi)
                A(2) = f4double(WDp.WorkPPpd) : A(3) = f4double(WDp.WorkPPmed)
                A(4) = f4double(WDp.WorkPPumbi) : A(5) = f4double(WDp.WorkPPumpd)
                A(6) = f4double(WDp.WorkPPpip) : A(7) = f4double(WDp.WorkPPcomp)
                A(8) = f4double(WDp.WorkPPcoll) : A(9) = f4double(WDp.WorkPPrent)
                A(10) = f4double(WDp.WorkPPtow) : A(11) = f4double(WDp.WorkCMbi)
                A(12) = f4double(WDp.WorkCMpd) : A(13) = f4double(WDp.WorkCMmed)
                A(14) = f4double(WDp.WorkCMumbi) : A(15) = f4double(WDp.WorkCMumpd)
                A(16) = f4double(WDp.WorkCMpip) : A(17) = f4double(WDp.WorkCMcomp)
                A(18) = f4double(WDp.WorkCMcoll) : A(19) = f4double(WDp.WorkCMrent)
                A(20) = f4double(WDp.WorkCMtow) : A(21) = f4double(WDp.WorkOTim)
                A(22) = f4double(WDp.WorkOTallied) : A(23) = f4double(WDp.WorkOTfire)
                A(24) = f4double(WDp.WorkOTmulti)
            End If

            Call f4assignDouble(WDp.WorkTotal, A(0) + MLobt)
            Call f4assignDouble(WDp.WorkPPbi, A(1) + MLobp(1))
            Call f4assignDouble(WDp.WorkPPpd, A(2) + MLobp(2))
            Call f4assignDouble(WDp.WorkPPmed, A(3) + MLobp(3))
            Call f4assignDouble(WDp.WorkPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(WDp.WorkPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(WDp.WorkPPpip, A(6) + MLobp(6))
            Call f4assignDouble(WDp.WorkPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(WDp.WorkPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(WDp.WorkPPrent, A(9) + MLobp(9))
            Call f4assignDouble(WDp.WorkPPtow, A(10) + MLobp(10))
            Call f4assignDouble(WDp.WorkCMbi, A(11) + MLobp(11))
            Call f4assignDouble(WDp.WorkCMpd, A(12) + MLobp(12))
            Call f4assignDouble(WDp.WorkCMmed, A(13) + MLobp(13))
            Call f4assignDouble(WDp.WorkCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(WDp.WorkCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(WDp.WorkCMpip, A(16) + MLobp(16))
            Call f4assignDouble(WDp.WorkCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(WDp.WorkCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(WDp.WorkCMrent, A(19) + MLobp(19))
            Call f4assignDouble(WDp.WorkCMtow, A(20) + MLobp(20))
            Call f4assignDouble(WDp.WorkOTim, A(21) + MLobp(21))
            Call f4assignDouble(WDp.WorkOTallied, A(22) + MLobp(22))
            Call f4assignDouble(WDp.WorkOTfire, A(23) + MLobp(23))
            Call f4assignDouble(WDp.WorkOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f13)
                rc = d4unlock(f13)
            End If

nextrec:
            rc = d4skip(f11, 1)
        Loop

    End Sub

    Private Sub TotalItdYtdDir()
        Dim X As Integer

        Call d4tagSelect(f9, d4tag(f9, "K1"))
        rc = d4top(f9)
        YtdDirKey = ""
        rc = d4seek(f9, YtdDirKey)

        Do Until rc = r4eof
            If Trim(f4str(YDp.YtdMgaNmbr)) = "016" Then
                If Trim(f4str(YDp.YtdPeriod)) <> Period Then GoTo nextrec
            End If

            CatCode = Trim(f4str(YDp.YtdCatCode))
            Wyear = Trim(f4str(YDp.YtdYear))
            Wperiod = Trim(f4str(YDp.YtdPeriod))

            If CDbl(CatCode) = 4 Or CDbl(CatCode) = 9 Or CDbl(CatCode) = 10 Or CDbl(CatCode) = 13 Or CDbl(CatCode) = 14 Or CDbl(CatCode) = 15 Or CDbl(CatCode) = 16 Or CDbl(CatCode) = 17 Then
                If Period <> Wperiod Then GoTo nextrec
            End If

            'Write To ITD Dir File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetYtdDirVar()

            WorkDirKey = Trim(f4str(YDp.YtdMgaNmbr)) & Trim(f4str(YDp.YtdTrtyNmbr)) & "12" & Trim(f4str(YDp.YtdCatCode)) & Trim(f4str(YDp.YtdYear))

            Call d4tagSelect(f13, d4tag(f13, "K1"))
            rc = d4top(f13)
            rc = d4seek(f13, WorkDirKey)

            AddTran = False
            If WorkDirKey <> Trim(f4str(WDp.WorkMgaNmbr)) & Trim(f4str(WDp.WorkTrtyNmbr)) & "12" & Trim(f4str(WDp.WorkCatCode)) & Trim(f4str(WDp.WorkYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f13, 0) <> r4success Then Exit Sub
                Call f4assign(WDp.WorkMgaNmbr, Trim(f4str(YDp.YtdMgaNmbr)))
                Call f4assign(WDp.WorkTrtyNmbr, Trim(f4str(YDp.YtdTrtyNmbr)))
                Call f4assign(WDp.WorkPeriod, "12")
                Call f4assign(WDp.WorkCatCode, Trim(f4str(YDp.YtdCatCode)))
                Call f4assign(WDp.WorkYear, Trim(f4str(YDp.YtdYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(WDp.WorkTotal) : A(1) = f4double(WDp.WorkPPbi)
                A(2) = f4double(WDp.WorkPPpd) : A(3) = f4double(WDp.WorkPPmed)
                A(4) = f4double(WDp.WorkPPumbi) : A(5) = f4double(WDp.WorkPPumpd)
                A(6) = f4double(WDp.WorkPPpip) : A(7) = f4double(WDp.WorkPPcomp)
                A(8) = f4double(WDp.WorkPPcoll) : A(9) = f4double(WDp.WorkPPrent)
                A(10) = f4double(WDp.WorkPPtow) : A(11) = f4double(WDp.WorkCMbi)
                A(12) = f4double(WDp.WorkCMpd) : A(13) = f4double(WDp.WorkCMmed)
                A(14) = f4double(WDp.WorkCMumbi) : A(15) = f4double(WDp.WorkCMumpd)
                A(16) = f4double(WDp.WorkCMpip) : A(17) = f4double(WDp.WorkCMcomp)
                A(18) = f4double(WDp.WorkCMcoll) : A(19) = f4double(WDp.WorkCMrent)
                A(20) = f4double(WDp.WorkCMtow) : A(21) = f4double(WDp.WorkOTim)
                A(22) = f4double(WDp.WorkOTallied) : A(23) = f4double(WDp.WorkOTfire)
                A(24) = f4double(WDp.WorkOTmulti)
            End If

            Call f4assignDouble(WDp.WorkTotal, A(0) + MLobt)
            Call f4assignDouble(WDp.WorkPPbi, A(1) + MLobp(1))
            Call f4assignDouble(WDp.WorkPPpd, A(2) + MLobp(2))
            Call f4assignDouble(WDp.WorkPPmed, A(3) + MLobp(3))
            Call f4assignDouble(WDp.WorkPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(WDp.WorkPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(WDp.WorkPPpip, A(6) + MLobp(6))
            Call f4assignDouble(WDp.WorkPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(WDp.WorkPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(WDp.WorkPPrent, A(9) + MLobp(9))
            Call f4assignDouble(WDp.WorkPPtow, A(10) + MLobp(10))
            Call f4assignDouble(WDp.WorkCMbi, A(11) + MLobp(11))
            Call f4assignDouble(WDp.WorkCMpd, A(12) + MLobp(12))
            Call f4assignDouble(WDp.WorkCMmed, A(13) + MLobp(13))
            Call f4assignDouble(WDp.WorkCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(WDp.WorkCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(WDp.WorkCMpip, A(16) + MLobp(16))
            Call f4assignDouble(WDp.WorkCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(WDp.WorkCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(WDp.WorkCMrent, A(19) + MLobp(19))
            Call f4assignDouble(WDp.WorkCMtow, A(20) + MLobp(20))
            Call f4assignDouble(WDp.WorkOTim, A(21) + MLobp(21))
            Call f4assignDouble(WDp.WorkOTallied, A(22) + MLobp(22))
            Call f4assignDouble(WDp.WorkOTfire, A(23) + MLobp(23))
            Call f4assignDouble(WDp.WorkOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f13)
                rc = d4unlock(f13)
            End If

nextrec:
            rc = d4skip(f9, 1)
        Loop
    End Sub

    Private Sub TotalItdCed()
        Dim X As Integer

        Call d4tagSelect(f12, d4tag(f12, "K1"))
        rc = d4top(f12)
        ItdCedKey = ""
        rc = d4seek(f12, ItdCedKey)

        Do Until rc = r4eof
            If Trim(f4str(Ic1p.CedMgaNmbr)) = "016" Then
                If Trim(f4str(Ic1p.CedPeriod)) <> Period Then GoTo nextrec
            End If

            CatCode = Trim(f4str(Ic1p.CedCatCode))
            Wyear = Trim(f4str(Ic1p.CedYear))
            Wperiod = Trim(f4str(Ic1p.CedPeriod))

            If CDbl(CatCode) = 4 Then GoTo nextrec
            If CDbl(CatCode) = 9 Then GoTo nextrec
            If CDbl(CatCode) = 10 Then GoTo nextrec
            If CDbl(CatCode) = 13 Then GoTo nextrec
            If CDbl(CatCode) = 14 Then GoTo nextrec
            If CDbl(CatCode) = 15 Then GoTo nextrec
            If CDbl(CatCode) = 16 Then GoTo nextrec
            If CDbl(CatCode) = 17 Then GoTo nextrec

            'Write To ITD Ced File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetItdCedVar()

            WorkCedKey = Trim(f4str(Ic1p.CedMgaNmbr)) & Trim(f4str(Ic1p.CedTrtyNmbr)) & "12" & Trim(f4str(Ic1p.CedCatCode)) & Trim(f4str(Ic1p.CedYear))

            Call d4tagSelect(f14, d4tag(f14, "K1"))
            rc = d4top(f14)
            rc = d4seek(f14, WorkCedKey)

            AddTran = False
            If WorkCedKey <> Trim(f4str(Wc1p.CedMgaNmbr)) & Trim(f4str(Wc1p.CedTrtyNmbr)) & "12" & Trim(f4str(Wc1p.CedCatCode)) & Trim(f4str(Wc1p.CedYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f14, 0) <> r4success Then Exit Sub
                Call f4assign(Wc1p.CedMgaNmbr, Trim(f4str(Ic1p.CedMgaNmbr)))
                Call f4assign(Wc1p.CedTrtyNmbr, Trim(f4str(Ic1p.CedTrtyNmbr)))
                Call f4assign(Wc1p.CedPeriod, "12")
                Call f4assign(Wc1p.CedCatCode, Trim(f4str(Ic1p.CedCatCode)))
                Call f4assign(Wc1p.CedYear, Trim(f4str(Ic1p.CedYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(Wc1p.CedTotal) : A(1) = f4double(Wc1p.CedPPbi)
                A(2) = f4double(Wc1p.CedPPpd) : A(3) = f4double(Wc1p.CedPPmed)
                A(4) = f4double(Wc1p.CedPPumbi) : A(5) = f4double(Wc1p.CedPPumpd)
                A(6) = f4double(Wc1p.CedPPpip) : A(7) = f4double(Wc1p.CedPPcomp)
                A(8) = f4double(Wc1p.CedPPcoll) : A(9) = f4double(Wc1p.CedPPrent)
                A(10) = f4double(Wc1p.CedPPtow) : A(11) = f4double(Wc1p.CedCMbi)
                A(12) = f4double(Wc1p.CedCMpd) : A(13) = f4double(Wc1p.CedCMmed)
                A(14) = f4double(Wc1p.CedCMumbi) : A(15) = f4double(Wc1p.CedCMumpd)
                A(16) = f4double(Wc1p.CedCMpip) : A(17) = f4double(Wc1p.CedCMcomp)
                A(18) = f4double(Wc1p.CedCMcoll) : A(19) = f4double(Wc1p.CedCMrent)
                A(20) = f4double(Wc1p.CedCMtow) : A(21) = f4double(Wc1p.CedOTim)
                A(22) = f4double(Wc1p.CedOTallied) : A(23) = f4double(Wc1p.CedOTfire)
                A(24) = f4double(Wc1p.CedOTmulti)
            End If

            Call f4assignDouble(Wc1p.CedTotal, A(0) + MLobt)
            Call f4assignDouble(Wc1p.CedPPbi, A(1) + MLobp(1))
            Call f4assignDouble(Wc1p.CedPPpd, A(2) + MLobp(2))
            Call f4assignDouble(Wc1p.CedPPmed, A(3) + MLobp(3))
            Call f4assignDouble(Wc1p.CedPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(Wc1p.CedPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(Wc1p.CedPPpip, A(6) + MLobp(6))
            Call f4assignDouble(Wc1p.CedPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(Wc1p.CedPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(Wc1p.CedPPrent, A(9) + MLobp(9))
            Call f4assignDouble(Wc1p.CedPPtow, A(10) + MLobp(10))
            Call f4assignDouble(Wc1p.CedCMbi, A(11) + MLobp(11))
            Call f4assignDouble(Wc1p.CedCMpd, A(12) + MLobp(12))
            Call f4assignDouble(Wc1p.CedCMmed, A(13) + MLobp(13))
            Call f4assignDouble(Wc1p.CedCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(Wc1p.CedCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(Wc1p.CedCMpip, A(16) + MLobp(16))
            Call f4assignDouble(Wc1p.CedCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(Wc1p.CedCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(Wc1p.CedCMrent, A(19) + MLobp(19))
            Call f4assignDouble(Wc1p.CedCMtow, A(20) + MLobp(20))
            Call f4assignDouble(Wc1p.CedOTim, A(21) + MLobp(21))
            Call f4assignDouble(Wc1p.CedOTallied, A(22) + MLobp(22))
            Call f4assignDouble(Wc1p.CedOTfire, A(23) + MLobp(23))
            Call f4assignDouble(Wc1p.CedOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f14)
                rc = d4unlock(f14)
            End If

nextrec:
            rc = d4skip(f12, 1)
        Loop

    End Sub

    Private Sub TotalItdYtdCed()
        Dim X As Integer

        Call d4tagSelect(f10, d4tag(f10, "K1"))
        rc = d4top(f10)
        YtdCedKey = ""
        rc = d4seek(f10, YtdCedKey)

        Do Until rc = r4eof
            If Trim(f4str(YDc1p.CedMgaNmbr)) = "016" Then
                If Trim(f4str(YDc1p.CedPeriod)) <> Period Then GoTo nextrec
            End If

            CatCode = Trim(f4str(YDc1p.CedCatCode))
            Wyear = Trim(f4str(YDc1p.CedYear))
            Wperiod = Trim(f4str(YDc1p.CedPeriod))

            If CDbl(CatCode) = 4 Or CDbl(CatCode) = 9 Or CDbl(CatCode) = 10 Or CDbl(CatCode) = 13 Or CDbl(CatCode) = 14 Or CDbl(CatCode) = 15 Or CDbl(CatCode) = 16 Or CDbl(CatCode) = 17 Then
                If Period <> Wperiod Then GoTo nextrec
            End If

            'Write To ITD Ced File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetYtdCedVar()

            WorkCedKey = Trim(f4str(YDc1p.CedMgaNmbr)) & Trim(f4str(YDc1p.CedTrtyNmbr)) & "12" & Trim(f4str(YDc1p.CedCatCode)) & Trim(f4str(YDc1p.CedYear))

            Call d4tagSelect(f14, d4tag(f14, "K1"))
            rc = d4top(f14)
            rc = d4seek(f14, WorkCedKey)

            AddTran = False
            If WorkCedKey <> Trim(f4str(Wc1p.CedMgaNmbr)) & Trim(f4str(Wc1p.CedTrtyNmbr)) & "12" & Trim(f4str(Wc1p.CedCatCode)) & Trim(f4str(Wc1p.CedYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f14, 0) <> r4success Then Exit Sub
                Call f4assign(Wc1p.CedMgaNmbr, Trim(f4str(YDc1p.CedMgaNmbr)))
                Call f4assign(Wc1p.CedTrtyNmbr, Trim(f4str(YDc1p.CedTrtyNmbr)))
                Call f4assign(Wc1p.CedPeriod, "12")
                Call f4assign(Wc1p.CedCatCode, Trim(f4str(YDc1p.CedCatCode)))
                Call f4assign(Wc1p.CedYear, Trim(f4str(YDc1p.CedYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(Wc1p.CedTotal) : A(1) = f4double(Wc1p.CedPPbi)
                A(2) = f4double(Wc1p.CedPPpd) : A(3) = f4double(Wc1p.CedPPmed)
                A(4) = f4double(Wc1p.CedPPumbi) : A(5) = f4double(Wc1p.CedPPumpd)
                A(6) = f4double(Wc1p.CedPPpip) : A(7) = f4double(Wc1p.CedPPcomp)
                A(8) = f4double(Wc1p.CedPPcoll) : A(9) = f4double(Wc1p.CedPPrent)
                A(10) = f4double(Wc1p.CedPPtow) : A(11) = f4double(Wc1p.CedCMbi)
                A(12) = f4double(Wc1p.CedCMpd) : A(13) = f4double(Wc1p.CedCMmed)
                A(14) = f4double(Wc1p.CedCMumbi) : A(15) = f4double(Wc1p.CedCMumpd)
                A(16) = f4double(Wc1p.CedCMpip) : A(17) = f4double(Wc1p.CedCMcomp)
                A(18) = f4double(Wc1p.CedCMcoll) : A(19) = f4double(Wc1p.CedCMrent)
                A(20) = f4double(Wc1p.CedCMtow) : A(21) = f4double(Wc1p.CedOTim)
                A(22) = f4double(Wc1p.CedOTallied) : A(23) = f4double(Wc1p.CedOTfire)
                A(24) = f4double(Wc1p.CedOTmulti)
            End If

            Call f4assignDouble(Wc1p.CedTotal, A(0) + MLobt)
            Call f4assignDouble(Wc1p.CedPPbi, A(1) + MLobp(1))
            Call f4assignDouble(Wc1p.CedPPpd, A(2) + MLobp(2))
            Call f4assignDouble(Wc1p.CedPPmed, A(3) + MLobp(3))
            Call f4assignDouble(Wc1p.CedPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(Wc1p.CedPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(Wc1p.CedPPpip, A(6) + MLobp(6))
            Call f4assignDouble(Wc1p.CedPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(Wc1p.CedPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(Wc1p.CedPPrent, A(9) + MLobp(9))
            Call f4assignDouble(Wc1p.CedPPtow, A(10) + MLobp(10))
            Call f4assignDouble(Wc1p.CedCMbi, A(11) + MLobp(11))
            Call f4assignDouble(Wc1p.CedCMpd, A(12) + MLobp(12))
            Call f4assignDouble(Wc1p.CedCMmed, A(13) + MLobp(13))
            Call f4assignDouble(Wc1p.CedCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(Wc1p.CedCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(Wc1p.CedCMpip, A(16) + MLobp(16))
            Call f4assignDouble(Wc1p.CedCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(Wc1p.CedCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(Wc1p.CedCMrent, A(19) + MLobp(19))
            Call f4assignDouble(Wc1p.CedCMtow, A(20) + MLobp(20))
            Call f4assignDouble(Wc1p.CedOTim, A(21) + MLobp(21))
            Call f4assignDouble(Wc1p.CedOTallied, A(22) + MLobp(22))
            Call f4assignDouble(Wc1p.CedOTfire, A(23) + MLobp(23))
            Call f4assignDouble(Wc1p.CedOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f14)
                rc = d4unlock(f14)
            End If

nextrec:
            rc = d4skip(f10, 1)
        Loop

    End Sub

    Private Sub RunEoyRptUpdate()
        ' Copy RPTDIR to RPTDIR## for close year
        Fileold = InsVars.Dpath & "RPTDIR.dbf"
        Filenew = InsVars.Dpath & "RPTDIR" & closeYear & ".dbf"
        If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
        System.IO.File.Copy(Fileold, Filenew)

        Fileold = InsVars.Dpath & "RPTDIR.cdx"
        Filenew = InsVars.Dpath & "RPTDIR" & closeYear & ".cdx"
        If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
        System.IO.File.Copy(Fileold, Filenew)

        ' Clear current RPTDIR
        dbname = InsVars.Dpath & "RPTDIR.dbf"
        ClearDatabase()

        ' Copy RPTCED# to new RPTCED### for previous year
        For index As Integer = 1 To 5
            Fileold = InsVars.Dpath & "RPTCED" & CStr(index) & ".dbf"
            Filenew = InsVars.Dpath & "RPTCED" & CStr(index) & closeYear & ".dbf"
            If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
            System.IO.File.Copy(Fileold, Filenew)

            Fileold = InsVars.Dpath & "RPTCED" & CStr(index) & ".cdx"
            Filenew = InsVars.Dpath & "RPTCED" & CStr(index) & closeYear & ".cdx"
            If System.IO.File.Exists(Filenew) Then System.IO.File.Delete(Filenew)
            System.IO.File.Copy(Fileold, Filenew)
        Next

        ' Clear current RPTCED#
        For index As Integer = 1 To 5
            dbname = InsVars.Dpath & "RPTCED" & CStr(index) & ".dbf"
            ClearDatabase()
        Next

        ' Clear current MGACHKLST
        dbname = InsVars.Dpath & "MGACHKLIST.dbf"
        ClearDatabase()

    End Sub

    Private Sub ClearDatabase()
        db = d4open(cb, dbname)
        Call d4tagSelect(db, 0)
        rc = d4top(db)
        d4lockFile(db)

        Do While rc = r4success
            Call d4delete(db)
            rc = d4skip(db, 1)
        Loop

        d4pack(db)
        d4unlock(db)
        d4close(db)
    End Sub

    Private Sub frmEoyCloseout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtYear.Text = lastYear
    End Sub
End Class
