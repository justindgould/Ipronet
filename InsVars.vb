Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6

Module InsVars

    ' Code Base Variables
    Public lf As String 'Line Feed
    Public fpath As String 'Full path name to data files

    Public Const MB_OK As Short = 0
    Public Const MB_YESNO As Short = 4
    Public Const MB_ICONQUESTION As Short = 32
    Public Const IDYES As Short = 6

    Public rc As Short
    Public rc4 As Short
    Public rc5 As Short
    Public rc6 As Short
    Public cb As Integer

    Public mopt As String

    'Printer Variables
    Public PrtRpt As Boolean
    Public PgCt As Short
    Public LnCt As Short


    Public Const BACK_KEY As Short = &H8S 'Used to turn overwrite mode on
    Public Hcol As Object

    ' Object Cntrl
    Public Vobj As Control
    Public Chkobj As CheckBox
    Public Mobj As ComboBox
    Public Tobj As TextBox

    ' Cursor Control Variable
    Public CtrlDown As Object

    'Record/Form Actions
    Public AddTran As Boolean
    Public UpdateTran As Boolean
    Public DelTran As Boolean
    Public InqTran As Boolean
    Public RecChanged As Boolean
    Public RecStatus As Integer
    Public ByPassCbo As Boolean
    Public ByPassTxt As Boolean
    Public Utrtymst As Boolean
    Public Utrtyrei As Boolean
    Public PremRec As Boolean

    'Prog Vars
    Public X As Integer
    Public s As String
    Public S1 As String
    Public M As String
    Public M1 As String
    Public Fstat As Integer
    Public Ostat As Short
    Public Warry(12) As Short
    Public CurrPeriod As String
    Public DspStat As Short
    Public Pname As String
    Public CovCnt As Short
    Public Wtotal As Double
    Public CedFileNmbr As Short
    Public Cmga As String
    Public Ctrty As String
    Public toScreen As Boolean
    Public RptCode As Short
    Public BeginRun As Boolean
    Public RptType As Short
    Public RptCmplt As Boolean
    Public C0str As String = "Home State County Mutual Ins. Co."
    Public Fopen As Integer
    Public prtobj As Printer
    Public FrmCnt As Integer


    Public TotPerc As Single

    Public MgaArray() As String
    Public ReiArray() As String
    Public TrtyArray() As String
    Public StateArray() As String
    Public CatArray() As String
    Public BrkArray() As String
    Public CovArry(24) As Short
    Public WLobp(29) As Double
    Public Wlobt As Double
    Public Wcomm(29) As Boolean

    Public MLobp(29) As Double
    Public MLobt As Double

    Public txPword As String
    Public txUserId As String

    ' Index Keys
    Public MgaKey As String
    Public ReiKey As String
    Public TrtyKey As String
    Public TrtyXKey As String
    Public CatKey As String
    Public ChkLstKey As String
    Public RptDirKey As String
    Public ItdDirKey As String
    Public RptCedKey As String
    Public ItdCedKey As String
    Public GlMgaKey As String
    Public UepDirKey As String
    Public UepCedKey As String
    Public YtdDirKey As String
    Public YtdCedKey As String
    Public WorkDirKey As String
    Public WorkCedKey As String
    Public ReinAllocKey As String
    Public BrkKey As String
    Public BrkTrtyKey As String


    'File Name Pointers
    Public f1 As Integer 'MGAMST
    Public f2 As Integer 'REIMST
    Public f3 As Integer 'TREATYMST
    Public f3X As Integer 'XTREATYMST EXCESS TREATY CESSIONS
    Public f4 As Integer 'TREATYPRM
    Public f5 As Integer 'RPTDIR
    Public f6 As Integer 'RPTCED1 thru RPTCED5
    Public f7 As Integer 'UEPDIR
    Public f8 As Integer 'UEPCED1 thru RPTCED5
    Public f9 As Integer 'YTDDIR
    Public f10 As Integer 'YTDCED1 thru YTDCED5
    Public f11 As Integer 'ITDDIR
    Public f12 As Integer 'ITDCED1 thru ITDCED5
    Public f13 As Integer 'WORKDIR
    Public f14 As Integer 'WORKCED1 thru WORKCED5

    Public f20 As Integer 'AYDIRCED
    Public f21 As Integer 'AYDIRYTD
    Public f22 As Integer 'AYDIRITD
    Public f23 As Integer 'IBNRCED1
    Public f24 As Integer 'IBNRDIR
    Public f25 As Integer 'IBNRPRM
    Public f26 As Integer 'ITDACCYR
    Public wkf As Integer 'Work file

    Public f30 As Integer 'Reinalloc
    Public f35 As Long 'BRKMST
    Public f36 As Long 'BRKTRTY

    Public f40 As Integer 'MGACHKLIST
    Public f50 As Integer 'GLMGAREF
    Public f90 As Integer 'STATE
    Public f91 As Integer 'CATMST
    Public f92 As Integer 'PERIOD

    'File Paths
    Public Dpath As String

    'File Names
    Public Nmgamst As String
    Public Nreimst As String
    Public Ntrtymst As String
    Public Ntrtyprm As String
    Public Nstateref As String
    Public Ncatmst As String
    Public Nperiod As String
    Public Nmgachklst As String
    Public Nrptdir As String
    Public Nrptced1 As String
    Public Nrptced2 As String
    Public Nrptced3 As String
    Public Nrptced4 As String
    Public Nrptced5 As String
    Public Nitddir As String
    Public Nitdced1 As String
    Public Nitdced2 As String
    Public Nitdced3 As String
    Public Nitdced4 As String
    Public Nitdced5 As String
    Public Nglmgaref As String
    Public Naydirced As String
    Public Naydirytd As String
    Public Naydiritd As String
    Public Nibnrced1 As String
    Public Nibnrdir As String
    Public Nibnrprm As String
    Public Nitdaccyr As String
    Public Nuepdir As String
    Public Nuepced1 As String
    Public Nuepced2 As String
    Public Nuepced3 As String
    Public Nuepced4 As String
    Public Nuepced5 As String
    Public Nytddir As String
    Public Nytdced1 As String
    Public Nytdced2 As String
    Public Nytdced3 As String
    Public Nytdced4 As String
    Public Nytdced5 As String
    Public Nwdir As String
    Public Nwced1 As String
    Public Nwced2 As String
    Public Nwced3 As String
    Public Nwced4 As String
    Public Nwced5 As String
    Public Nreinalloc As String
    Public Nxtrtymst As String
    Public Nbrkmst As String
    Public Nbrktrty As String

    Public Sub SetPrtPos(ByVal C As Single, ByVal R As Single)
        C = C * 120
        R = R * 240
        prtobj.CurrentX = C
        prtobj.CurrentY = R
    End Sub

    Public Function Pdate(ByVal dstr As String)
        dstr = Mid(dstr, 1, 2) & "/" & Mid(dstr, 3, 2) & "/" & Mid(dstr, 5, 4)
        Return dstr
    End Function

    Public Function CheckPerms(ByVal menu As String) As Boolean
        ' Pass origin menu to check against permission table
        Select Case txUserId
            Case "mike", "brandt", "equityit"
                CheckPerms = True
            Case "leeann"
                If menu = "frmGlMgaRef" Or menu = "frmCatMnt" Or menu = "frmBrkEntry" Or menu = "frmTrtyBrkAssignment" Then
                    CheckPerms = False
                Else
                    CheckPerms = True
                End If
            Case "holli", "lina"
                CheckPerms = False
                If menu = "frmMgaChkLst" Or menu = "frmRptTrtyInfo" Or
                    menu = "frmRptEntry" Or menu = "frmRptAudLst" Or menu = "frmRptCedGen" Or
                    menu = "frmMgaRpt" Or menu = "frmCodPrt" Then
                    CheckPerms = True
                End If
            Case "jackie"
                CheckPerms = False
                If menu = "frmGlMgaRef" Or menu = "frmRptTrtyInfo" Then
                    CheckPerms = True
                End If
            Case "kim"
                CheckPerms = False
                If menu = "frmTrtyPrm" Or menu = "frmMgaChkLst" Or menu = "frmPeriod" Or menu = "frmRptTrtyInfo" Or
                    menu = "frmRptEntry" Or menu = "frmRptAudLst" Or menu = "frmRptCedGen" Or menu = "frmMgaRpt" Or
                    menu = "frmCodPrt" Or menu = "frmCedEntry" Or menu = "frmTotByMgaDir" Or menu = "frmTotByMgaDirPd" Or
                    menu = "frmTotExpMga" Or menu = "frmQdirtot" Or menu = "frmQcedtot" Or menu = "frmQdirState" Or
                    menu = "frmQcedState" Or menu = "frmRptStatCommQtr" Or menu = "frmRptStatPpQtr" Then
                    CheckPerms = True
                End If
            Case "rudy", "stu"
                CheckPerms = False
                If menu = "frmRptTrtyInfo" Or menu = "frmQdirtot" Or menu = "frmQcedtot" Or menu = "frmQdirState" Or
                    menu = "frmQcedState" Or menu = "frmQpfallocdir" Or menu = "frmQpfallocced" Or menu = "frmItdRpt" Or
                    menu = "frmRptYtdMgaBrkDown" Or menu = "frmRptStatCommQtr" Or menu = "frmRptStatPpQtr" Or
                    menu = "frmRptSpc2" Or menu = "frmRptSpc" Or menu = "frmRptSpc1" Or menu = "frmEoySchedp" Or
                    menu = "frmEoySchedpTot" Or menu = "frmEoySchedpState" Then
                    CheckPerms = True
                End If
            Case Else
                CheckPerms = False
        End Select
    End Function

    Public Function CheckPassword(ByVal id As String, ByVal pw As String) As Boolean
        ' Pass password for checking
        CheckPassword = False
        Select Case id
            Case "mike"
                If pw = "bears" Then CheckPassword = True
            Case "brandt"
                If pw = "wakens" Then CheckPassword = True
            Case "equityit"
                If pw = "66accobra" Then CheckPassword = True
            Case "leeann"
                If pw = "icebox" Then CheckPassword = True
            Case "holli"
                If pw = "snazzy" Then CheckPassword = True
            Case "jackie"
                If pw = "hominy" Then CheckPassword = True
            Case "kim"
                If pw = "sunset" Then CheckPassword = True
            Case "rudy"
                If pw = "starry" Then CheckPassword = True
            Case "stu"
                If pw = "sponge" Then CheckPassword = True
            Case "lina"
                If pw = "lilacs" Then CheckPassword = True
        End Select
    End Function

End Module
