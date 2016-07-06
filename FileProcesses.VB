Option Strict Off
Option Explicit On

Module FileProcesses
    Public Sub OpenMgaMst()
        If f1 <> 0 Then Exit Sub
        f1 = d4open(cb, Nmgamst) 'MGAMST
        GetMgaMstPtr()
    End Sub

    Public Sub ClsMgaMst()
        If UpdateTran Then rc = d4unlock(f1)
        rc = d4close(f1) 'MGAMST
    End Sub

    Public Sub OpenReiMst()
        If f2 <> 0 Then Exit Sub
        f2 = d4open(cb, Nreimst) 'REIMST
        GetReiMstPtr()
    End Sub

    Public Sub ClsReiMst()
        If UpdateTran Then rc = d4unlock(f2)
        rc = d4close(f2) 'REIMST
    End Sub

    Public Sub OpenTrtyMst()
        If f3 <> 0 Then Exit Sub
        f3 = d4open(cb, Ntrtymst) 'TREATY MST
        GetTrtyMstPtr()
    End Sub

    Public Sub ClsTrtyMst()
        If UpdateTran Then rc = d4unlock(f3)
        rc = d4close(f3) 'TREATY MST
    End Sub

    Public Sub OpenTrtyPrm()
        If f4 <> 0 Then Exit Sub
        f4 = d4open(cb, Ntrtyprm) 'TREATY PARM
        GetTrtyPrmPtr()
    End Sub

    Public Sub ClsTrtyPrm()
        If UpdateTran Then rc = d4unlock(f4)
        rc = d4close(f4) 'TREATY PARM
    End Sub

    Public Sub OpenReinAlloc()
        If f30 <> 0 Then Exit Sub
        f30 = d4open(cb, Nreinalloc) 'REINALLOC
        GetReinAllocPtr()
    End Sub

    Public Sub ClsReinAlloc()
        rc = d4unlock(f30)
        rc = d4close(f30) 'REINALLOC
    End Sub

    Public Sub ClearReinalloc()
        Call d4tagSelect(f30, 0)
        rc = d4top(f30)
        d4lockFile(f30)

        Do While rc = r4success
            Call d4delete(f30)
            rc = d4skip(f30, 1)
        Loop

        d4pack(f30)
        d4unlock(f30)
    End Sub

    Public Sub OpenBrkMst()
        If f35 <> 0 Then Exit Sub
        f35 = d4open(cb, Nbrkmst) 'BRKMST
        GetBrkMstPtr()
    End Sub

    Sub ClsBrkMst()
        rc = d4unlock(f35)
        rc = d4close(f35) 'BRKMST
    End Sub

    Public Sub OpenBrkTrty()
        If f36 <> 0 Then Exit Sub
        f36 = d4open(cb, Nbrktrty) 'BRKTRTY
        GetBrkTrtyPtr()
    End Sub

    Sub ClsBrkTrty()
        rc = d4unlock(f36)
        rc = d4close(f36) 'BRKTRTY
    End Sub

    Public Sub OpenGlMgaRef()
        If f50 <> 0 Then Exit Sub
        f50 = d4open(cb, Nglmgaref) 'GLMGAREF
        GetGlMgaRefPtr()
    End Sub

    Public Sub ClsGlMgaRef()
        If UpdateTran Then rc = d4unlock(f50)
        rc = d4close(f50) 'GLMGAREF
    End Sub

    Public Sub OpenXTrtyMst()
        If f3X <> 0 Then Exit Sub
        f3X = d4open(cb, Nxtrtymst) 'EXCESS TREATY MST
        GetXTrtyMstPtr()
    End Sub

    Public Sub ClsXTrtyMst()
        If UpdateTran Then rc = d4unlock(f3X)
        rc = d4close(f3X) 'EXCESS TREATY MST
    End Sub

    Public Sub OpenRptDir()
        If f5 <> 0 Then Exit Sub
        f5 = d4open(cb, Nrptdir) 'RPTDIR
        GetRptDirPtr()
    End Sub

    Sub ClsRptDir()
        If UpdateTran Then rc = d4unlock(f5)
        rc = d4close(f5) 'RPTDIR
    End Sub

    Public Sub OpenRptCed1()
        If f6 <> 0 Then Exit Sub
        f6 = d4open(cb, Nrptced1) 'RPTCED1
        GetRptCedPtr()
    End Sub

    Sub ClsRptCed1()
        If UpdateTran Then rc = d4unlock(f6)
        rc = d4close(f6) 'RPTCED1
    End Sub

    Public Sub OpenRptCed2()
        If f6 <> 0 Then Exit Sub
        f6 = d4open(cb, Nrptced2) 'RPTCED2
        GetRptCedPtr()
    End Sub

    Sub ClsRptCed2()
        If UpdateTran Then rc = d4unlock(f6)
        rc = d4close(f6) 'RPTCED2
    End Sub

    Public Sub OpenRptCed3()
        If f6 <> 0 Then Exit Sub
        f6 = d4open(cb, Nrptced3) 'RPTCED3
        GetRptCedPtr()
    End Sub

    Sub ClsRptCed3()
        If UpdateTran Then rc = d4unlock(f6)
        rc = d4close(f6) 'RPTCED3
    End Sub

    Public Sub OpenRptCed4()
        If f6 <> 0 Then Exit Sub
        f6 = d4open(cb, Nrptced4) 'RPTCED4
        GetRptCedPtr()
    End Sub

    Sub ClsRptCed4()
        If UpdateTran Then rc = d4unlock(f6)
        rc = d4close(f6) 'RPTCED4
    End Sub

    Public Sub OpenRptCed5()
        If f6 <> 0 Then Exit Sub
        f6 = d4open(cb, Nrptced5) 'RPTCED5
        GetRptCedPtr()
    End Sub

    Sub ClsRptCed5()
        If UpdateTran Then rc = d4unlock(f6)
        rc = d4close(f6) 'RPTCED5
    End Sub

    Public Sub OpenUepDir()
        If f7 <> 0 Then Exit Sub
        f7 = d4open(cb, Nuepdir) 'UEPDIR
        GetUepDirPtr()
    End Sub

    Sub ClsUepDir()
        If UpdateTran Then rc = d4unlock(f7)
        rc = d4close(f7) 'UEPDIR
    End Sub

    Public Sub OpenUepCed1()
        If f8 <> 0 Then Exit Sub
        f8 = d4open(cb, Nuepced1) 'UEPCED1
        GetUepCedPtr()
    End Sub

    Sub ClsUepCed1()
        If UpdateTran Then rc = d4unlock(f8)
        rc = d4close(f8) 'UEPCED1
    End Sub

    Public Sub OpenUepCed2()
        If f8 <> 0 Then Exit Sub
        f8 = d4open(cb, Nuepced2) 'UEPCED2
        GetUepCedPtr()
    End Sub

    Sub ClsUepCed2()
        If UpdateTran Then rc = d4unlock(f8)
        rc = d4close(f8) 'UEPCED2
    End Sub

    Public Sub OpenUepCed3()
        If f8 <> 0 Then Exit Sub
        f8 = d4open(cb, Nuepced3) 'UEPCED3
        GetUepCedPtr()
    End Sub

    Sub ClsUepCed3()
        If UpdateTran Then rc = d4unlock(f8)
        rc = d4close(f8) 'UEPCED3
    End Sub

    Public Sub OpenUepCed4()
        If f8 <> 0 Then Exit Sub
        f8 = d4open(cb, Nuepced4) 'UEPCED4
        GetUepCedPtr()
    End Sub

    Sub ClsUepCed4()
        If UpdateTran Then rc = d4unlock(f8)
        rc = d4close(f8) 'UEPCED4
    End Sub

    Public Sub OpenUepCed5()
        If f8 <> 0 Then Exit Sub
        f8 = d4open(cb, Nuepced5) 'UEPCED5
        GetUepCedPtr()
    End Sub

    Sub ClsUepCed5()
        If UpdateTran Then rc = d4unlock(f8)
        rc = d4close(f8) 'UEPCED5
    End Sub

    Public Sub OpenYtdDir()
        If f9 <> 0 Then Exit Sub
        f9 = d4open(cb, Nytddir) 'YTDDIR
        GetYtdDirPtr()
    End Sub

    Sub ClsYtdDir()
        If UpdateTran Then rc = d4unlock(f9)
        rc = d4close(f9) 'YTDDIR
    End Sub

    Public Sub OpenYtdCed1()
        If f10 <> 0 Then Exit Sub
        f10 = d4open(cb, Nytdced1) 'YTDCED1
        GetYtdCedPtr()
    End Sub

    Sub ClsYtdCed1()
        If UpdateTran Then rc = d4unlock(f10)
        rc = d4close(f10) 'YTDCED1
    End Sub

    Public Sub OpenYtdCed2()
        If f10 <> 0 Then Exit Sub
        f10 = d4open(cb, Nytdced2) 'YTDCED2
        GetYtdCedPtr()
    End Sub

    Sub ClsYtdCed2()
        If UpdateTran Then rc = d4unlock(f10)
        rc = d4close(f10) 'YTDCED2
    End Sub

    Public Sub OpenYtdCed3()
        If f10 <> 0 Then Exit Sub
        f10 = d4open(cb, Nytdced3) 'YTDCED3
        GetYtdCedPtr()
    End Sub

    Sub ClsYtdCed3()
        If UpdateTran Then rc = d4unlock(f10)
        rc = d4close(f10) 'YTDCED3
    End Sub

    Public Sub OpenYtdCed4()
        If f10 <> 0 Then Exit Sub
        f10 = d4open(cb, Nytdced4) 'YTDCED4
        GetYtdCedPtr()
    End Sub

    Sub ClsYtdCed4()
        If UpdateTran Then rc = d4unlock(f10)
        rc = d4close(f10) 'YTDCED4
    End Sub

    Public Sub OpenYtdCed5()
        If f10 <> 0 Then Exit Sub
        f10 = d4open(cb, Nytdced5) 'YTDCED5
        GetYtdCedPtr()
    End Sub

    Sub ClsYtdCed5()
        If UpdateTran Then rc = d4unlock(f10)
        rc = d4close(f10) 'YTDCED5
    End Sub

    Public Sub OpenItdDir()
        If f11 <> 0 Then Exit Sub
        f11 = d4open(cb, Nitddir) 'ITDDIR
        GetItdDirPtr()
    End Sub

    Sub ClsItdDir()
        If UpdateTran Then rc = d4unlock(f11)
        rc = d4close(f11) 'ITDDIR
    End Sub

    Public Sub OpenItdCed1()
        If f12 <> 0 Then Exit Sub
        f12 = d4open(cb, Nitdced1) 'ITDCED1
        GetItdCedPtr()
    End Sub

    Sub ClsItdCed1()
        If UpdateTran Then rc = d4unlock(f12)
        rc = d4close(f12) 'ITDCED1
    End Sub

    Public Sub OpenItdCed2()
        If f12 <> 0 Then Exit Sub
        f12 = d4open(cb, Nitdced2) 'ITDCED2
        GetItdCedPtr()
    End Sub

    Sub ClsItdCed2()
        If UpdateTran Then rc = d4unlock(f12)
        rc = d4close(f12) 'ITDCED2
    End Sub

    Public Sub OpenItdCed3()
        If f12 <> 0 Then Exit Sub
        f12 = d4open(cb, Nitdced3) 'ITDCED3
        GetItdCedPtr()
    End Sub

    Sub ClsItdCed3()
        If UpdateTran Then rc = d4unlock(f12)
        rc = d4close(f12) 'ITDCED3
    End Sub

    Public Sub OpenItdCed4()
        If f12 <> 0 Then Exit Sub
        f12 = d4open(cb, Nitdced4) 'ITDCED4
        GetItdCedPtr()
    End Sub

    Sub ClsItdCed4()
        If UpdateTran Then rc = d4unlock(f12)
        rc = d4close(f12) 'ITDCED4
    End Sub

    Public Sub OpenItdCed5()
        If f12 <> 0 Then Exit Sub
        f12 = d4open(cb, Nitdced5) 'ITDCED5
        GetItdCedPtr()
    End Sub

    Sub ClsItdCed5()
        If UpdateTran Then rc = d4unlock(f12)
        rc = d4close(f12) 'ITDCED5
    End Sub

    Public Sub OpenWorkDir()
        If f13 <> 0 Then Exit Sub
        f13 = d4open(cb, Nwdir) 'WORKDIR
        GetWorkDirPtr()
    End Sub

    Sub ClsWorkDir()
        If UpdateTran Then rc = d4unlock(f13)
        rc = d4close(f13) 'WORKDIR
    End Sub

    Public Sub OpenWorkCed1()
        If f14 <> 0 Then Exit Sub
        f14 = d4open(cb, Nwced1) 'WORKCED1
        GetWorkCedPtr()
    End Sub

    Sub ClsWorkCed1()
        If UpdateTran Then rc = d4unlock(f14)
        rc = d4close(f14) 'WORKCED1
    End Sub

    Public Sub OpenWorkCed2()
        If f14 <> 0 Then Exit Sub
        f14 = d4open(cb, Nwced2) 'WORKCED2
        GetWorkCedPtr()
    End Sub

    Sub ClsWorkCed2()
        If UpdateTran Then rc = d4unlock(f14)
        rc = d4close(f14) 'WORKCED2
    End Sub

    Public Sub OpenWorkCed3()
        If f14 <> 0 Then Exit Sub
        f14 = d4open(cb, Nwced3) 'WORKCED3
        GetWorkCedPtr()
    End Sub

    Sub ClsWorkCed3()
        If UpdateTran Then rc = d4unlock(f14)
        rc = d4close(f14) 'WORKCED3
    End Sub

    Public Sub OpenWorkCed4()
        If f14 <> 0 Then Exit Sub
        f14 = d4open(cb, Nwced4) 'WORKCED4
        GetWorkCedPtr()
    End Sub

    Sub ClsWorkCed4()
        If UpdateTran Then rc = d4unlock(f14)
        rc = d4close(f14) 'WORKCED4
    End Sub

    Public Sub OpenWorkCed5()
        If f14 <> 0 Then Exit Sub
        f14 = d4open(cb, Nwced5) 'WORKCED5
        GetWorkCedPtr()
    End Sub

    Sub ClsWorkCed5()
        If UpdateTran Then rc = d4unlock(f14)
        rc = d4close(f14) 'WORKCED5
    End Sub

    Public Sub OpenAyCed()
        If f20 <> 0 Then Exit Sub
        f20 = d4open(cb, Naydirced) 'AYDIRCED
        GetAyCedPtr()
    End Sub

    Sub ClsAyCed()
        rc = d4unlock(f20)
        rc = d4close(f20) 'AYDIRCED
    End Sub

    Public Sub OpenAyDir()
        If f21 <> 0 Then Exit Sub
        f21 = d4open(cb, Naydirytd) 'AYDIRYTD
        GetAyDirPtr()
    End Sub

    Sub ClsAyDir()
        rc = d4unlock(f21)
        rc = d4close(f21) 'AYDIRYTD
    End Sub

    Public Sub OpenAyItd()
        If f22 <> 0 Then Exit Sub
        f22 = d4open(cb, Naydiritd) 'AYDIRITD
        GetAyItdPtr()
    End Sub

    Sub ClsAyItd()
        rc = d4unlock(f22)
        rc = d4close(f22) 'AYDIRITD
    End Sub

    Public Sub OpenIbnrCed()
        If f23 <> 0 Then Exit Sub
        f23 = d4open(cb, Nibnrced1) 'IBNRCED1
        GetIbnrCedPtr()
    End Sub

    Sub ClsIbnrCed()
        rc = d4unlock(f23)
        rc = d4close(f23) 'IBNRCED1
    End Sub

    Public Sub OpenIbnrDir()
        If f24 <> 0 Then Exit Sub
        f24 = d4open(cb, Nibnrdir) 'IBNRDIR
        GetIbnrDirPtr()
    End Sub

    Sub ClsIbnrDir()
        rc = d4unlock(f24)
        rc = d4close(f24) 'IBNRDIR
    End Sub

    Public Sub OpenIbnrPrm()
        If f25 <> 0 Then Exit Sub
        f25 = d4open(cb, Nibnrprm) 'IBNRPRM
        GetIbnrPrmPtr()
    End Sub

    Sub ClsIbnrPrm()
        rc = d4unlock(f25)
        rc = d4close(f25) 'IBNRPRM
    End Sub

    Public Sub OpenItdAccyr()
        If f26 <> 0 Then Exit Sub
        f26 = d4open(cb, Nitdaccyr) 'ITDACCYR
        GetItdAccyrPtr()
    End Sub

    Sub ClsItdAccyr()
        rc = d4unlock(f26)
        rc = d4close(f26) 'ITDACCYR
    End Sub

    Sub OpenChkLst()
        If f40 <> 0 Then Exit Sub
        f40 = d4open(cb, Nmgachklst) 'MGACHECKLIST
        GetChkLstPtr()
    End Sub

    Sub ClsChkLst()
        If UpdateTran Then rc = d4unlock(f40)
        rc = d4close(f40) 'MGACHECKLIST
    End Sub

    Sub OpenStateRef()
        If f90 <> 0 Then Exit Sub
        f90 = d4open(cb, Nstateref) 'State Reference File
        GetStateRefPtr()
    End Sub

    Sub ClsStateRef()
        If UpdateTran Then rc = d4unlock(f90)
        rc = d4close(f90) 'State Reference File
    End Sub

    Public Sub RdCatMstRec()
        Fstat = 0
        Call d4tagSelect(f91, d4tag(f91, "K1"))
        rc = d4seek(f91, CatKey)
        Fstat = rc
        rc = d4unlock(f91)
    End Sub

    Sub OpenCatMst()
        If f91 <> 0 Then Exit Sub
        f91 = d4open(cb, Ncatmst) 'Category Master
        GetCatMstPtr()
    End Sub

    Sub ClsCatMst()
        If UpdateTran Then rc = d4unlock(f91)
        rc = d4close(f91) 'Category Master
    End Sub

    Sub OpenPeriod()
        If f92 <> 0 Then Exit Sub
        f92 = d4open(cb, Nperiod) 'PERIOD
        GetPeriodPtr()
    End Sub

    Sub ClsPeriod()
        If UpdateTran Then rc = d4unlock(f92)
        rc = d4close(f92) 'PERIOD
    End Sub

    Sub GetPeriodData()
        'Get Period
        Dim X As Integer

        Call d4tagSelect(f92, d4tag(f92, "K1"))
        rc = d4top(f92)
        If rc <> 0 Then
            MsgBox("Period Parm Rec Error Unable to Continue")
            Exit Sub
        End If

        GetPeriodVar()

        For X = 12 To 1 Step -1
            If Warry(X) = 1 Then
                CurrPeriod = Format(X, "00")
                Exit For
            End If
        Next X

        rc = d4unlock(f92)
        rc = d4bottom(f92)
    End Sub

    Function ValUser() As Boolean
        ValUser = True
        If txUserId <> "leeann" And txUserId <> "kim" And txUserId <> "crb" Then
            MsgBox("User Not Authorzied To Perform This Function")
            ValUser = False
        End If
    End Function

    Public Sub GetFilePaths()
        Dpath = "\\waconas003\Waco\InsPro\Data\HSIG\"
        Nmgamst = Dpath + "MGAMST.DBF"
        Nreimst = Dpath + "REIMST.DBF"
        Ntrtymst = Dpath + "TRTYMST.DBF"
        Nxtrtymst = Dpath + "XTRTYMST.DBF"
        Ntrtyprm = Dpath + "TRTYPRM.DBF"
        Nstateref = Dpath + "STATEREF.DBF"
        Ncatmst = Dpath + "CATMST.DBF"
        Nperiod = Dpath + "PERIOD.DBF"
        Nmgachklst = Dpath + "MGACHKLIST.DBF"
        Nrptdir = Dpath + "RPTDIR.DBF"
        Nrptced1 = Dpath + "RPTCED1.DBF"
        Nrptced2 = Dpath + "RPTCED2.DBF"
        Nrptced3 = Dpath + "RPTCED3.DBF"
        Nrptced4 = Dpath + "RPTCED4.DBF"
        Nrptced5 = Dpath + "RPTCED5.DBF"
        Nitddir = Dpath + "ITDDIR.DBF"
        Nitdced1 = Dpath + "ITDCED1.DBF"
        Nitdced2 = Dpath + "ITDCED2.DBF"
        Nitdced3 = Dpath + "ITDCED3.DBF"
        Nitdced4 = Dpath + "ITDCED4.DBF"
        Nitdced5 = Dpath + "ITDCED5.DBF"
        Nglmgaref = Dpath + "GLMGAREF.DBF"
        Naydirced = Dpath + "AYDIRCED.DBF"
        Naydirytd = Dpath + "AYDIRYTD.DBF"
        Naydiritd = Dpath + "AYDIRITD.DBF"
        Nibnrced1 = Dpath + "IBNRCED1.DBF"
        Nibnrdir = Dpath + "IBNRDIR.DBF"
        Nibnrprm = Dpath + "IBNRPRM.DBF"
        Nitdaccyr = Dpath + "ITDACCYR.DBF"
        Nuepdir = Dpath + "UEPDIR.DBF"
        Nuepced1 = Dpath + "UEPCED1.DBF"
        Nuepced2 = Dpath + "UEPCED2.DBF"
        Nuepced3 = Dpath + "UEPCED3.DBF"
        Nuepced4 = Dpath + "UEPCED4.DBF"
        Nuepced5 = Dpath + "UEPCED5.DBF"
        Nytddir = Dpath + "YTDDIR.DBF"
        Nytdced1 = Dpath + "YTDCED1.DBF"
        Nytdced2 = Dpath + "YTDCED2.DBF"
        Nytdced3 = Dpath + "YTDCED3.DBF"
        Nytdced4 = Dpath + "YTDCED4.DBF"
        Nytdced5 = Dpath + "YTDCED5.DBF"
        Nreinalloc = Dpath + "REINALLOC.DBF"
        Nbrkmst = Dpath + "BRKMST.DBF"
        Nbrktrty = Dpath + "BRKTRTY.DBF"
    End Sub

End Module
