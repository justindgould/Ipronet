Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraBars.Docking2010.Views.NativeMdi


Public Class frmMain
    Sub New()
        InitSkins()
        InitializeComponent()
        Me.InitSkinGallery()

        frmPassEntry.ShowDialog()

        If Trim(txUserId) = "" Or Trim(txPword) = "" Then
            End
            Me.Close()
        End If

        If Not CheckPassword(txUserId, txPword) Then
            MsgBox("User Not Authorized")
            End
            Me.Close()
        End If

        cb = code4init()

        GetFilePaths()

    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle("DevExpress Style")

    End Sub
    Private Sub InitSkinGallery()
        SkinHelper.InitSkinGallery(rgbiSkins, True)
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        rc = code4close(cb)
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then
            If Me.MdiChildren.Count > 1 Then
                MessageBox.Show("Save Your Work and Exit Form", "Program Forms Are Open", MessageBoxButtons.OK)
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim dm As New DocumentManager()
        dm.MdiParent = Me
        dm.View = New NativeMdiView()
    End Sub

    Private Sub NavBarItem1_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem1.LinkClicked
        If CheckPerms("frmMgaEntry") Then
            Dim f As Form = frmMgaEntry
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem2_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem2.LinkClicked
        If CheckPerms("frmGlMgaRef") Then
            Dim f As Form = frmGlMgaRef
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub
    Private Sub NavBarItem3_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem3.LinkClicked
        If CheckPerms("frmTrtyMnt") Then
            Dim f As Form = frmTrtyMnt
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem4_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem4.LinkClicked
        If CheckPerms("frmTrtyRei") Then
            Dim f As Form = frmTrtyRei
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem5_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem5.LinkClicked
        If CheckPerms("frmTrtyPrm") Then
            Dim f As Form = frmTrtyPrm
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem6_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem6.LinkClicked
        If CheckPerms("frmMgaChkLst") Then
            Dim f As Form = frmMgaChkLst
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem7_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem7.LinkClicked
        If CheckPerms("frmPeriod") Then
            Dim f As Form = frmPeriod
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem8_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem8.LinkClicked
        If CheckPerms("frmRptTrtyInfo") Then
            Dim f As Form = frmRptTrtyInfo
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem9_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem9.LinkClicked
        If CheckPerms("frmReiEntry") Then
            Dim f As Form = frmReiEntry
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem10_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem10.LinkClicked
        If CheckPerms("frmRptEntry") Then
            Dim f As Form = frmRptEntry
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem11_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem11.LinkClicked
        If CheckPerms("frmRptAudLst") Then
            Dim f As Form = frmRptAudLst
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem12_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem12.LinkClicked
        If CheckPerms("frmRptCedGen") Then
            Dim f As Form = frmRptCedGen
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem13_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem13.LinkClicked
        If CheckPerms("frmMgaRpt") Then
            Dim f As Form = frmMgaRpt
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem14_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem14.LinkClicked
        If CheckPerms("frmCodPrt") Then
            Dim f As Form = frmCodPrt
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem15_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem15.LinkClicked
        If CheckPerms("frmCedEntry") Then
            Dim f As Form = frmCedEntry
            f.MdiParent = Me
            CedFileNmbr = 1
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem16_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem16.LinkClicked
        If CheckPerms("frmCedEntry") Then
            Dim f As Form = frmCedEntry
            f.MdiParent = Me
            CedFileNmbr = 2
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem17_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem17.LinkClicked
        If CheckPerms("frmCedEntry") Then
            Dim f As Form = frmCedEntry
            f.MdiParent = Me
            CedFileNmbr = 3
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem18_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem18.LinkClicked
        If CheckPerms("frmCedEntry") Then
            Dim f As Form = frmCedEntry
            f.MdiParent = Me
            CedFileNmbr = 4
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem19_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem19.LinkClicked
        If CheckPerms("frmTotByMgaDir") Then
            Dim f As Form = frmTotByMgaDir
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem20_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem20.LinkClicked
        If CheckPerms("frmTotByMgaDirPd") Then
            Dim f As Form = frmTotByMgaDirPd
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem21_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem21.LinkClicked
        If CheckPerms("frmIbnrPrmMnt") Then
            Dim f As Form = frmIbnrPrmMnt
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem22_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem22.LinkClicked
        If CheckPerms("frmIbnrAyAccum") Then
            Dim f As Form = frmIbnrAyAccum
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem23_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem23.LinkClicked
        If CheckPerms("frmIbnrCalc") Then
            Dim f As Form = frmIbnrCalc
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem24_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem24.LinkClicked
        If CheckPerms("frmIbnrCed") Then
            Dim f As Form = frmIbnrCed
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem25_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem25.LinkClicked
        If CheckPerms("frmIbnrAccumPrt") Then
            Dim f As Form = frmIbnrAccumPrt
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem26_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem26.LinkClicked
        If CheckPerms("frmIbnrBldAyrNet") Then
            Dim f As Form = frmIbnrBldAyrNet
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem27_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem27.LinkClicked
        If CheckPerms("frmIbnrPrtAccyr") Then
            Dim f As Form = frmIbnrPrtAccyr
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem28_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem28.LinkClicked
        If CheckPerms("frmIbnrMerge") Then
            Dim f As Form = frmIbnrMerge
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem29_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem29.LinkClicked
        If CheckPerms("frmQdirtot") Then
            Dim f As Form = frmQdirtot
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem30_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem30.LinkClicked
        If CheckPerms("frmQcedtot") Then
            Dim f As Form = frmQcedtot
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem31_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem31.LinkClicked
        If CheckPerms("frmQpfallocdir") Then
            Dim f As Form = frmQpfallocdir
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem32_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem32.LinkClicked
        If CheckPerms("frmQpfallocced") Then
            Dim f As Form = frmQpfallocced
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem33_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem33.LinkClicked
        If CheckPerms("frmItdRpt") Then
            Dim f As Form = frmItdRpt
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem34_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem34.LinkClicked
        If CheckPerms("frmRptYtdMgaBrkDown") Then
            Dim f As Form = frmRptYtdMgaBrkDown
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem35_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem35.LinkClicked
        If CheckPerms("frmRptStatCommQtr") Then
            Dim f As Form = frmRptStatCommQtr
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem36_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem36.LinkClicked
        If CheckPerms("frmRptStatPpQtr") Then
            Dim f As Form = frmRptStatPpQtr
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem37_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem37.LinkClicked
        If CheckPerms("frmRptSpc2") Then
            Dim f As Form = frmRptSpc2
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem38_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem38.LinkClicked
        If CheckPerms("frmRptSpc") Then
            Dim f As Form = frmRptSpc
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem39_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem39.LinkClicked
        If CheckPerms("frmRptSpc1") Then
            Dim f As Form = frmRptSpc1
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem40_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem40.LinkClicked
        If CheckPerms("frmEoySchedp") Then
            Dim f As Form = frmEoySchedp
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem41_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem41.LinkClicked
        If CheckPerms("frmEoySchedpTot") Then
            Dim f As Form = frmEoySchedpTot
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem42_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem42.LinkClicked
        If CheckPerms("frmEoyYtdAccum") Then
            Dim f As Form = frmEoyYtdAccum
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem43_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem43.LinkClicked
        If CheckPerms("frmEoyItdAccum") Then
            Dim f As Form = frmEoyItdAccum
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem44_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem44.LinkClicked
        If CheckPerms("frmEoyUepUpdate") Then
            Dim f As Form = frmEoyUepUpdate
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront() Else 
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem45_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem45.LinkClicked
        If CheckPerms("frmEoyReinalloc") Then
            Dim f As Form = frmEoyReinalloc
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem46_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem46.LinkClicked
        If CheckPerms("frmEoyReinalloc2") Then
            Dim f As Form = frmEoyReinalloc2
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem47_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem47.LinkClicked
        If CheckPerms("frmEoyReinalloc3") Then
            Dim f As Form = frmEoyReinalloc3
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem48_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem48.LinkClicked
        If CheckPerms("frmEoyReinallocPrt") Then
            Dim f As Form = frmEoyReinallocPrt
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem49_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem49.LinkClicked
        If CheckPerms("frmBrkEntry") Then
            Dim f As Form = frmBrkEntry
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront() Else 
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem50_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem50.LinkClicked
        If CheckPerms("frmTrtyBrkAssignment") Then
            Dim f As Form = frmTrtyBrkAssignment
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem51_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem51.LinkClicked
        If CheckPerms("frmCatMnt") Then
            Dim f As Form = frmCatMnt
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub

    Private Sub NavBarItem52_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem52.LinkClicked
        If CheckPerms("frmTotExpMga") Then
            Dim f As Form = frmTotExpMga
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub


    Private Sub iExit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles iExit.ItemClick
        Me.Close()
    End Sub

    Private Sub iReset_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles iReset.ItemClick
        Dim response As Short

        If (Me.MdiChildren.Count > 1) Then
            response = MsgBox("Reset program without saving changes", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Reset program")
            If response = MsgBoxResult.No Then Exit Sub
        End If

        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        Me.NavBarControl1.Show()
        Me.iNavMenu.Caption = "Hide Nav Menu"
    End Sub

    Private Sub iNavMenu_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles iNavMenu.ItemClick
        If Me.iNavMenu.Caption = "Hide Nav Menu" Then
            Me.NavBarControl1.Hide()
            Me.iNavMenu.Caption = "Show Nav Menu"
        Else
            Me.NavBarControl1.Show()
            Me.iNavMenu.Caption = "Hide Nav Menu"
        End If
    End Sub

    Private Sub iClearDesktop_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles iClearDesktop.ItemClick

    End Sub

    Private Sub EoyCloseout_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles EoyCloseout.LinkClicked
        If CheckPerms("frmEoyCloseout") Then
            Dim f As Form = frmEoyCloseout
            f.MdiParent = Me
            If Not f.Visible Then f.Show()
            If f.Visible Then f.BringToFront()
        Else
            MsgBox("User Not Authorized")
        End If
    End Sub
End Class
