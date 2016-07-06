Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ribbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.appMenu = New DevExpress.XtraBars.Ribbon.ApplicationMenu(Me.components)
        Me.iExit = New DevExpress.XtraBars.BarButtonItem()
        Me.iReset = New DevExpress.XtraBars.BarButtonItem()
        Me.iNavMenu = New DevExpress.XtraBars.BarButtonItem()
        Me.iClearDesktop = New DevExpress.XtraBars.BarButtonItem()
        Me.ribbonImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.iClose = New DevExpress.XtraBars.BarButtonItem()
        Me.iFind = New DevExpress.XtraBars.BarButtonItem()
        Me.iAbout = New DevExpress.XtraBars.BarButtonItem()
        Me.alignButtonGroup = New DevExpress.XtraBars.BarButtonGroup()
        Me.iBoldFontStyle = New DevExpress.XtraBars.BarButtonItem()
        Me.iItalicFontStyle = New DevExpress.XtraBars.BarButtonItem()
        Me.iUnderlinedFontStyle = New DevExpress.XtraBars.BarButtonItem()
        Me.fontStyleButtonGroup = New DevExpress.XtraBars.BarButtonGroup()
        Me.iLeftTextAlign = New DevExpress.XtraBars.BarButtonItem()
        Me.iCenterTextAlign = New DevExpress.XtraBars.BarButtonItem()
        Me.iRightTextAlign = New DevExpress.XtraBars.BarButtonItem()
        Me.rgbiSkins = New DevExpress.XtraBars.RibbonGalleryBarItem()
        Me.ribbonImageCollectionLarge = New DevExpress.Utils.ImageCollection(Me.components)
        Me.homeRibbonPage = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.exitRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.UtilRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.skinsRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.NavBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
        Me.NavBarGroup1 = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarItem1 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem2 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem3 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem4 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem5 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem6 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem7 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem8 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem51 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarGroup2 = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarItem9 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarGroup3 = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarItem10 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem11 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem12 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem13 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem14 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem15 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem16 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem17 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem18 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarGroup4 = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarItem19 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem20 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem52 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarGroup5 = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarItem21 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem22 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem23 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem24 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem25 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem26 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem27 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem28 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarGroup6 = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarItem29 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem30 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem31 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem32 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem33 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem34 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem35 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem36 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem37 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem38 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem39 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarGroup7 = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarItem40 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem41 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem42 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem43 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem44 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem45 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem46 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem47 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem48 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarGroup8 = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarItem49 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem50 = New DevExpress.XtraNavBar.NavBarItem()
        Me.EoyCloseout = New DevExpress.XtraNavBar.NavBarItem()
        CType(Me.ribbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.appMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ribbonImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ribbonImageCollectionLarge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ribbonControl
        '
        Me.ribbonControl.ApplicationButtonDropDownControl = Me.appMenu
        Me.ribbonControl.ApplicationButtonText = Nothing
        Me.ribbonControl.ExpandCollapseItem.Id = 0
        Me.ribbonControl.Images = Me.ribbonImageCollection
        Me.ribbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl.ExpandCollapseItem, Me.iClose, Me.iFind, Me.iExit, Me.iAbout, Me.alignButtonGroup, Me.iBoldFontStyle, Me.iItalicFontStyle, Me.iUnderlinedFontStyle, Me.fontStyleButtonGroup, Me.iLeftTextAlign, Me.iCenterTextAlign, Me.iRightTextAlign, Me.rgbiSkins, Me.iReset, Me.iNavMenu, Me.iClearDesktop})
        Me.ribbonControl.LargeImages = Me.ribbonImageCollectionLarge
        Me.ribbonControl.Location = New System.Drawing.Point(0, 0)
        Me.ribbonControl.MaxItemId = 65
        Me.ribbonControl.Name = "ribbonControl"
        Me.ribbonControl.PageHeaderItemLinks.Add(Me.iAbout)
        Me.ribbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.homeRibbonPage, Me.RibbonPage1})
        Me.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010
        Me.ribbonControl.Size = New System.Drawing.Size(1251, 144)
        '
        'appMenu
        '
        Me.appMenu.ItemLinks.Add(Me.iExit)
        Me.appMenu.ItemLinks.Add(Me.iReset)
        Me.appMenu.ItemLinks.Add(Me.iNavMenu)
        Me.appMenu.ItemLinks.Add(Me.iClearDesktop)
        Me.appMenu.Name = "appMenu"
        Me.appMenu.Ribbon = Me.ribbonControl
        Me.appMenu.ShowRightPane = True
        '
        'iExit
        '
        Me.iExit.Caption = "Exit"
        Me.iExit.Description = "Closes this program after prompting you to save unsaved data."
        Me.iExit.Hint = "Closes this program after prompting you to save unsaved data"
        Me.iExit.Id = 20
        Me.iExit.ImageIndex = 6
        Me.iExit.LargeImageIndex = 6
        Me.iExit.Name = "iExit"
        '
        'iReset
        '
        Me.iReset.Caption = "Reset Desktop"
        Me.iReset.Hint = "Closes All Windows and Restores The Original Desktop"
        Me.iReset.Id = 62
        Me.iReset.LargeImageIndex = 9
        Me.iReset.Name = "iReset"
        '
        'iNavMenu
        '
        Me.iNavMenu.Caption = "Hide Nav Menu"
        Me.iNavMenu.Hint = "Hide Or Show Nav Menu"
        Me.iNavMenu.Id = 63
        Me.iNavMenu.LargeImageIndex = 10
        Me.iNavMenu.Name = "iNavMenu"
        '
        'iClearDesktop
        '
        Me.iClearDesktop.Caption = "Clear Desktop"
        Me.iClearDesktop.Hint = "Clear Main Desktop Workspace"
        Me.iClearDesktop.Id = 64
        Me.iClearDesktop.LargeImageIndex = 12
        Me.iClearDesktop.Name = "iClearDesktop"
        '
        'ribbonImageCollection
        '
        Me.ribbonImageCollection.ImageStream = CType(resources.GetObject("ribbonImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ribbonImageCollection.Images.SetKeyName(0, "Ribbon_New_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(1, "Ribbon_Open_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(2, "Ribbon_Close_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(3, "Ribbon_Find_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(4, "Ribbon_Save_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(5, "Ribbon_SaveAs_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(6, "Ribbon_Exit_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(7, "Ribbon_Content_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(8, "Ribbon_Info_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(9, "Ribbon_Bold_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(10, "Ribbon_Italic_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(11, "Ribbon_Underline_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(12, "Ribbon_AlignLeft_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(13, "Ribbon_AlignCenter_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(14, "Ribbon_AlignRight_16x16.png")
        '
        'iClose
        '
        Me.iClose.Caption = "&Close"
        Me.iClose.Description = "Closes the active document."
        Me.iClose.Hint = "Closes the active document"
        Me.iClose.Id = 3
        Me.iClose.ImageIndex = 2
        Me.iClose.LargeImageIndex = 2
        Me.iClose.Name = "iClose"
        Me.iClose.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'iFind
        '
        Me.iFind.Caption = "Find"
        Me.iFind.Description = "Searches for the specified info."
        Me.iFind.Hint = "Searches for the specified info"
        Me.iFind.Id = 15
        Me.iFind.ImageIndex = 3
        Me.iFind.LargeImageIndex = 3
        Me.iFind.Name = "iFind"
        Me.iFind.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'iAbout
        '
        Me.iAbout.Caption = "About"
        Me.iAbout.Description = "Home State MGA and Reinsurance Management System"
        Me.iAbout.Hint = "Home State MGA and Reinsurance Management System"
        Me.iAbout.Id = 24
        Me.iAbout.ImageIndex = 8
        Me.iAbout.LargeImageIndex = 8
        Me.iAbout.Name = "iAbout"
        '
        'alignButtonGroup
        '
        Me.alignButtonGroup.Caption = "Align Commands"
        Me.alignButtonGroup.Id = 52
        Me.alignButtonGroup.ItemLinks.Add(Me.iBoldFontStyle)
        Me.alignButtonGroup.ItemLinks.Add(Me.iItalicFontStyle)
        Me.alignButtonGroup.ItemLinks.Add(Me.iUnderlinedFontStyle)
        Me.alignButtonGroup.Name = "alignButtonGroup"
        '
        'iBoldFontStyle
        '
        Me.iBoldFontStyle.Caption = "Bold"
        Me.iBoldFontStyle.Id = 53
        Me.iBoldFontStyle.ImageIndex = 9
        Me.iBoldFontStyle.Name = "iBoldFontStyle"
        '
        'iItalicFontStyle
        '
        Me.iItalicFontStyle.Caption = "Italic"
        Me.iItalicFontStyle.Id = 54
        Me.iItalicFontStyle.ImageIndex = 10
        Me.iItalicFontStyle.Name = "iItalicFontStyle"
        '
        'iUnderlinedFontStyle
        '
        Me.iUnderlinedFontStyle.Caption = "Underlined"
        Me.iUnderlinedFontStyle.Id = 55
        Me.iUnderlinedFontStyle.ImageIndex = 11
        Me.iUnderlinedFontStyle.Name = "iUnderlinedFontStyle"
        '
        'fontStyleButtonGroup
        '
        Me.fontStyleButtonGroup.Caption = "Font Style"
        Me.fontStyleButtonGroup.Hint = "Restores Original Desktop"
        Me.fontStyleButtonGroup.Id = 56
        Me.fontStyleButtonGroup.ItemLinks.Add(Me.iLeftTextAlign)
        Me.fontStyleButtonGroup.ItemLinks.Add(Me.iCenterTextAlign)
        Me.fontStyleButtonGroup.ItemLinks.Add(Me.iRightTextAlign)
        Me.fontStyleButtonGroup.Name = "fontStyleButtonGroup"
        '
        'iLeftTextAlign
        '
        Me.iLeftTextAlign.Caption = "Left"
        Me.iLeftTextAlign.Id = 57
        Me.iLeftTextAlign.ImageIndex = 12
        Me.iLeftTextAlign.Name = "iLeftTextAlign"
        '
        'iCenterTextAlign
        '
        Me.iCenterTextAlign.Caption = "Center"
        Me.iCenterTextAlign.Id = 58
        Me.iCenterTextAlign.ImageIndex = 13
        Me.iCenterTextAlign.Name = "iCenterTextAlign"
        '
        'iRightTextAlign
        '
        Me.iRightTextAlign.Caption = "Right"
        Me.iRightTextAlign.Id = 59
        Me.iRightTextAlign.ImageIndex = 14
        Me.iRightTextAlign.Name = "iRightTextAlign"
        '
        'rgbiSkins
        '
        Me.rgbiSkins.Caption = "Skins"
        '
        '
        '
        Me.rgbiSkins.Gallery.AllowHoverImages = True
        Me.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = True
        Me.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = True
        Me.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.rgbiSkins.Gallery.ColumnCount = 4
        Me.rgbiSkins.Gallery.FixedHoverImageSize = False
        Me.rgbiSkins.Gallery.ImageSize = New System.Drawing.Size(32, 17)
        Me.rgbiSkins.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Top
        Me.rgbiSkins.Gallery.RowCount = 4
        Me.rgbiSkins.Id = 60
        Me.rgbiSkins.Name = "rgbiSkins"
        '
        'ribbonImageCollectionLarge
        '
        Me.ribbonImageCollectionLarge.ImageSize = New System.Drawing.Size(32, 32)
        Me.ribbonImageCollectionLarge.ImageStream = CType(resources.GetObject("ribbonImageCollectionLarge.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ribbonImageCollectionLarge.Images.SetKeyName(0, "Ribbon_New_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(1, "Ribbon_Open_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(2, "Ribbon_Close_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(3, "Ribbon_Find_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(4, "Ribbon_Save_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(5, "Ribbon_SaveAs_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(6, "Ribbon_Exit_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(7, "Ribbon_Content_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(8, "Ribbon_Info_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(9, "SCREEN.BMP")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(10, "NavigationPaneGroup.bmp")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(11, "rtfClear.bmp")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(12, "clear.png")
        '
        'homeRibbonPage
        '
        Me.homeRibbonPage.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.exitRibbonPageGroup, Me.UtilRibbonPageGroup})
        Me.homeRibbonPage.Name = "homeRibbonPage"
        Me.homeRibbonPage.Text = "Main"
        '
        'exitRibbonPageGroup
        '
        Me.exitRibbonPageGroup.ItemLinks.Add(Me.iExit)
        Me.exitRibbonPageGroup.Name = "exitRibbonPageGroup"
        Me.exitRibbonPageGroup.Text = "Exit"
        '
        'UtilRibbonPageGroup
        '
        Me.UtilRibbonPageGroup.ItemLinks.Add(Me.iReset)
        Me.UtilRibbonPageGroup.ItemLinks.Add(Me.iNavMenu)
        Me.UtilRibbonPageGroup.ItemLinks.Add(Me.iClearDesktop)
        Me.UtilRibbonPageGroup.Name = "UtilRibbonPageGroup"
        Me.UtilRibbonPageGroup.Text = "Utilities"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.skinsRibbonPageGroup})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Apperance"
        '
        'skinsRibbonPageGroup
        '
        Me.skinsRibbonPageGroup.ItemLinks.Add(Me.rgbiSkins)
        Me.skinsRibbonPageGroup.Name = "skinsRibbonPageGroup"
        Me.skinsRibbonPageGroup.ShowCaptionButton = False
        Me.skinsRibbonPageGroup.Text = "Customize"
        '
        'NavBarControl1
        '
        Me.NavBarControl1.ActiveGroup = Me.NavBarGroup1
        Me.NavBarControl1.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavBarGroup1, Me.NavBarGroup2, Me.NavBarGroup3, Me.NavBarGroup4, Me.NavBarGroup5, Me.NavBarGroup6, Me.NavBarGroup7, Me.NavBarGroup8})
        Me.NavBarControl1.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.NavBarItem1, Me.NavBarItem2, Me.NavBarItem3, Me.NavBarItem4, Me.NavBarItem5, Me.NavBarItem6, Me.NavBarItem7, Me.NavBarItem8, Me.NavBarItem9, Me.NavBarItem10, Me.NavBarItem11, Me.NavBarItem12, Me.NavBarItem13, Me.NavBarItem14, Me.NavBarItem15, Me.NavBarItem16, Me.NavBarItem17, Me.NavBarItem18, Me.NavBarItem19, Me.NavBarItem20, Me.NavBarItem21, Me.NavBarItem22, Me.NavBarItem23, Me.NavBarItem24, Me.NavBarItem25, Me.NavBarItem26, Me.NavBarItem27, Me.NavBarItem28, Me.NavBarItem29, Me.NavBarItem30, Me.NavBarItem31, Me.NavBarItem32, Me.NavBarItem33, Me.NavBarItem34, Me.NavBarItem35, Me.NavBarItem36, Me.NavBarItem37, Me.NavBarItem38, Me.NavBarItem39, Me.NavBarItem40, Me.NavBarItem41, Me.NavBarItem42, Me.NavBarItem43, Me.NavBarItem44, Me.NavBarItem45, Me.NavBarItem46, Me.NavBarItem47, Me.NavBarItem48, Me.NavBarItem49, Me.NavBarItem50, Me.NavBarItem51, Me.NavBarItem52, Me.EoyCloseout})
        Me.NavBarControl1.Location = New System.Drawing.Point(13, 152)
        Me.NavBarControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NavBarControl1.Name = "NavBarControl1"
        Me.NavBarControl1.OptionsNavPane.ExpandedWidth = 325
        Me.NavBarControl1.Size = New System.Drawing.Size(325, 663)
        Me.NavBarControl1.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.ScrollBar
        Me.NavBarControl1.StoreDefaultPaintStyleName = True
        Me.NavBarControl1.TabIndex = 3
        Me.NavBarControl1.Text = "NavBarControl1"
        '
        'NavBarGroup1
        '
        Me.NavBarGroup1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarGroup1.Appearance.Options.UseFont = True
        Me.NavBarGroup1.Caption = "MGA Maintenance"
        Me.NavBarGroup1.Expanded = True
        Me.NavBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText
        Me.NavBarGroup1.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem1), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem2), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem3), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem4), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem5), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem6), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem7), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem8), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem51)})
        Me.NavBarGroup1.Name = "NavBarGroup1"
        '
        'NavBarItem1
        '
        Me.NavBarItem1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem1.Appearance.Options.UseFont = True
        Me.NavBarItem1.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem1.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem1.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem1.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem1.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem1.AppearancePressed.Options.UseFont = True
        Me.NavBarItem1.CanDrag = False
        Me.NavBarItem1.Caption = "Managing General Agents"
        Me.NavBarItem1.Name = "NavBarItem1"
        '
        'NavBarItem2
        '
        Me.NavBarItem2.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem2.Appearance.Options.UseFont = True
        Me.NavBarItem2.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem2.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem2.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem2.AppearancePressed.Options.UseFont = True
        Me.NavBarItem2.CanDrag = False
        Me.NavBarItem2.Caption = "MGA GL Ref Codes"
        Me.NavBarItem2.Name = "NavBarItem2"
        '
        'NavBarItem3
        '
        Me.NavBarItem3.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem3.Appearance.Options.UseFont = True
        Me.NavBarItem3.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem3.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem3.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem3.AppearancePressed.Options.UseFont = True
        Me.NavBarItem3.CanDrag = False
        Me.NavBarItem3.Caption = "Treaty Parameters"
        Me.NavBarItem3.Name = "NavBarItem3"
        '
        'NavBarItem4
        '
        Me.NavBarItem4.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem4.Appearance.Options.UseFont = True
        Me.NavBarItem4.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem4.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem4.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem4.AppearancePressed.Options.UseFont = True
        Me.NavBarItem4.CanDrag = False
        Me.NavBarItem4.Caption = "Treaty Reinsurers"
        Me.NavBarItem4.Name = "NavBarItem4"
        '
        'NavBarItem5
        '
        Me.NavBarItem5.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem5.Appearance.Options.UseFont = True
        Me.NavBarItem5.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem5.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem5.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem5.AppearancePressed.Options.UseFont = True
        Me.NavBarItem5.Caption = "Treaty Report & G/L Parameters"
        Me.NavBarItem5.Name = "NavBarItem5"
        '
        'NavBarItem6
        '
        Me.NavBarItem6.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem6.Appearance.Options.UseFont = True
        Me.NavBarItem6.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem6.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem6.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem6.AppearancePressed.Options.UseFont = True
        Me.NavBarItem6.Caption = "MGA Check List"
        Me.NavBarItem6.Name = "NavBarItem6"
        '
        'NavBarItem7
        '
        Me.NavBarItem7.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem7.Appearance.Options.UseFont = True
        Me.NavBarItem7.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem7.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem7.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem7.AppearancePressed.Options.UseFont = True
        Me.NavBarItem7.Caption = "Period Parameter"
        Me.NavBarItem7.Name = "NavBarItem7"
        '
        'NavBarItem8
        '
        Me.NavBarItem8.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem8.Appearance.Options.UseFont = True
        Me.NavBarItem8.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem8.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem8.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem8.AppearancePressed.Options.UseFont = True
        Me.NavBarItem8.Caption = "Print Treaty Information"
        Me.NavBarItem8.Name = "NavBarItem8"
        '
        'NavBarItem51
        '
        Me.NavBarItem51.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem51.Appearance.Options.UseFont = True
        Me.NavBarItem51.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem51.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem51.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem51.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem51.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem51.AppearancePressed.Options.UseFont = True
        Me.NavBarItem51.Caption = "Catagories"
        Me.NavBarItem51.Name = "NavBarItem51"
        '
        'NavBarGroup2
        '
        Me.NavBarGroup2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarGroup2.Appearance.Options.UseFont = True
        Me.NavBarGroup2.Caption = "Reinsurer Maintenance"
        Me.NavBarGroup2.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem9)})
        Me.NavBarGroup2.Name = "NavBarGroup2"
        '
        'NavBarItem9
        '
        Me.NavBarItem9.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem9.Appearance.Options.UseFont = True
        Me.NavBarItem9.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem9.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem9.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem9.AppearancePressed.Options.UseFont = True
        Me.NavBarItem9.Caption = "Reinsurer Maintenance"
        Me.NavBarItem9.Name = "NavBarItem9"
        '
        'NavBarGroup3
        '
        Me.NavBarGroup3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarGroup3.Appearance.Options.UseFont = True
        Me.NavBarGroup3.Caption = "MGA Reporting"
        Me.NavBarGroup3.Expanded = True
        Me.NavBarGroup3.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText
        Me.NavBarGroup3.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem10), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem11), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem12), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem13), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem14), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem15), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem16), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem17), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem18)})
        Me.NavBarGroup3.Name = "NavBarGroup3"
        '
        'NavBarItem10
        '
        Me.NavBarItem10.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem10.Appearance.Options.UseFont = True
        Me.NavBarItem10.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem10.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem10.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem10.AppearancePressed.Options.UseFont = True
        Me.NavBarItem10.Caption = "Report Maintenance (Direct)"
        Me.NavBarItem10.Name = "NavBarItem10"
        '
        'NavBarItem11
        '
        Me.NavBarItem11.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem11.Appearance.Options.UseFont = True
        Me.NavBarItem11.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem11.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem11.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem11.AppearancePressed.Options.UseFont = True
        Me.NavBarItem11.Caption = "Audit List"
        Me.NavBarItem11.Name = "NavBarItem11"
        '
        'NavBarItem12
        '
        Me.NavBarItem12.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem12.Appearance.Options.UseFont = True
        Me.NavBarItem12.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem12.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem12.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem12.AppearancePressed.Options.UseFont = True
        Me.NavBarItem12.Caption = "Generate Ceding"
        Me.NavBarItem12.Name = "NavBarItem12"
        '
        'NavBarItem13
        '
        Me.NavBarItem13.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem13.Appearance.Options.UseFont = True
        Me.NavBarItem13.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem13.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem13.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem13.AppearancePressed.Options.UseFont = True
        Me.NavBarItem13.Caption = "Print Reports"
        Me.NavBarItem13.Name = "NavBarItem13"
        '
        'NavBarItem14
        '
        Me.NavBarItem14.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem14.Appearance.Options.UseFont = True
        Me.NavBarItem14.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem14.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem14.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem14.AppearancePressed.Options.UseFont = True
        Me.NavBarItem14.Caption = "Print Coding Sheet"
        Me.NavBarItem14.Name = "NavBarItem14"
        '
        'NavBarItem15
        '
        Me.NavBarItem15.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem15.Appearance.Options.UseFont = True
        Me.NavBarItem15.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem15.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem15.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem15.AppearancePressed.Options.UseFont = True
        Me.NavBarItem15.Caption = "Report Maintenance (Ceding)"
        Me.NavBarItem15.Name = "NavBarItem15"
        '
        'NavBarItem16
        '
        Me.NavBarItem16.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem16.Appearance.Options.UseFont = True
        Me.NavBarItem16.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem16.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem16.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem16.AppearancePressed.Options.UseFont = True
        Me.NavBarItem16.Caption = "Excess 1 Ceding Maintenance"
        Me.NavBarItem16.Name = "NavBarItem16"
        '
        'NavBarItem17
        '
        Me.NavBarItem17.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem17.Appearance.Options.UseFont = True
        Me.NavBarItem17.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem17.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem17.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem17.AppearancePressed.Options.UseFont = True
        Me.NavBarItem17.Caption = "Excess 2 Ceding Maintenance"
        Me.NavBarItem17.Name = "NavBarItem17"
        '
        'NavBarItem18
        '
        Me.NavBarItem18.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem18.Appearance.Options.UseFont = True
        Me.NavBarItem18.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem18.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem18.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem18.AppearancePressed.Options.UseFont = True
        Me.NavBarItem18.Caption = "Excess 3 Ceding Maintenance"
        Me.NavBarItem18.Name = "NavBarItem18"
        '
        'NavBarGroup4
        '
        Me.NavBarGroup4.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarGroup4.Appearance.Options.UseFont = True
        Me.NavBarGroup4.Caption = "Quarterly Processing"
        Me.NavBarGroup4.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem19), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem20), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem52)})
        Me.NavBarGroup4.Name = "NavBarGroup4"
        '
        'NavBarItem19
        '
        Me.NavBarItem19.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem19.Appearance.Options.UseFont = True
        Me.NavBarItem19.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem19.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem19.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem19.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem19.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem19.AppearancePressed.Options.UseFont = True
        Me.NavBarItem19.Caption = "Create TOTBYMGA Dir Text File"
        Me.NavBarItem19.Name = "NavBarItem19"
        '
        'NavBarItem20
        '
        Me.NavBarItem20.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem20.Appearance.Options.UseFont = True
        Me.NavBarItem20.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem20.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem20.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem20.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem20.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem20.AppearancePressed.Options.UseFont = True
        Me.NavBarItem20.Caption = "Create TOTBYMGA Ced Text File"
        Me.NavBarItem20.Name = "NavBarItem20"
        '
        'NavBarItem52
        '
        Me.NavBarItem52.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem52.Appearance.Options.UseFont = True
        Me.NavBarItem52.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem52.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem52.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem52.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem52.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem52.AppearancePressed.Options.UseFont = True
        Me.NavBarItem52.Caption = "Create TOTEXPMGA Text File"
        Me.NavBarItem52.Name = "NavBarItem52"
        '
        'NavBarGroup5
        '
        Me.NavBarGroup5.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarGroup5.Appearance.Options.UseFont = True
        Me.NavBarGroup5.Caption = "IBNR Processing"
        Me.NavBarGroup5.Expanded = True
        Me.NavBarGroup5.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem21), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem22), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem23), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem24), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem25), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem26), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem27), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem28)})
        Me.NavBarGroup5.Name = "NavBarGroup5"
        '
        'NavBarItem21
        '
        Me.NavBarItem21.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem21.Appearance.Options.UseFont = True
        Me.NavBarItem21.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem21.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem21.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem21.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem21.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem21.AppearancePressed.Options.UseFont = True
        Me.NavBarItem21.Caption = "IBNR Parmameter Maintenance"
        Me.NavBarItem21.Name = "NavBarItem21"
        '
        'NavBarItem22
        '
        Me.NavBarItem22.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem22.Appearance.Options.UseFont = True
        Me.NavBarItem22.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem22.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem22.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem22.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem22.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem22.AppearancePressed.Options.UseFont = True
        Me.NavBarItem22.Caption = "IBNR Accident Year Accumulation"
        Me.NavBarItem22.Name = "NavBarItem22"
        '
        'NavBarItem23
        '
        Me.NavBarItem23.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem23.Appearance.Options.UseFont = True
        Me.NavBarItem23.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem23.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem23.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem23.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem23.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem23.AppearancePressed.Options.UseFont = True
        Me.NavBarItem23.Caption = "Calc and Print IBNR "
        Me.NavBarItem23.Name = "NavBarItem23"
        '
        'NavBarItem24
        '
        Me.NavBarItem24.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem24.Appearance.Options.UseFont = True
        Me.NavBarItem24.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem24.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem24.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItem24.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem24.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem24.AppearancePressed.Options.UseFont = True
        Me.NavBarItem24.Caption = "Ced IBNR"
        Me.NavBarItem24.Name = "NavBarItem24"
        '
        'NavBarItem25
        '
        Me.NavBarItem25.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem25.Appearance.Options.UseFont = True
        Me.NavBarItem25.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem25.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem25.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem25.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem25.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem25.AppearancePressed.Options.UseFont = True
        Me.NavBarItem25.Caption = "Print IBNR Totals"
        Me.NavBarItem25.Name = "NavBarItem25"
        '
        'NavBarItem26
        '
        Me.NavBarItem26.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem26.Appearance.Options.UseFont = True
        Me.NavBarItem26.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem26.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem26.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem26.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem26.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem26.AppearancePressed.Options.UseFont = True
        Me.NavBarItem26.Caption = "Build Accident Year Net File"
        Me.NavBarItem26.Name = "NavBarItem26"
        '
        'NavBarItem27
        '
        Me.NavBarItem27.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem27.Appearance.Options.UseFont = True
        Me.NavBarItem27.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem27.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem27.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem27.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem27.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem27.AppearancePressed.Options.UseFont = True
        Me.NavBarItem27.Caption = "Print Accident Year Net (Run 306 First)"
        Me.NavBarItem27.Name = "NavBarItem27"
        '
        'NavBarItem28
        '
        Me.NavBarItem28.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem28.Appearance.Options.UseFont = True
        Me.NavBarItem28.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem28.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem28.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem28.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem28.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem28.AppearancePressed.Options.UseFont = True
        Me.NavBarItem28.Caption = "Merge IBNR Dir and Ceded File"
        Me.NavBarItem28.Name = "NavBarItem28"
        '
        'NavBarGroup6
        '
        Me.NavBarGroup6.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarGroup6.Appearance.Options.UseFont = True
        Me.NavBarGroup6.Caption = "Reports"
        Me.NavBarGroup6.Expanded = True
        Me.NavBarGroup6.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem29), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem30), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem31), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem32), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem33), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem34), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem35), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem36), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem37), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem38), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem39)})
        Me.NavBarGroup6.Name = "NavBarGroup6"
        '
        'NavBarItem29
        '
        Me.NavBarItem29.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem29.Appearance.Options.UseFont = True
        Me.NavBarItem29.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem29.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem29.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem29.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem29.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem29.AppearancePressed.Options.UseFont = True
        Me.NavBarItem29.Caption = "Print YTD Accum Direct Totals"
        Me.NavBarItem29.Name = "NavBarItem29"
        '
        'NavBarItem30
        '
        Me.NavBarItem30.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem30.Appearance.Options.UseFont = True
        Me.NavBarItem30.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem30.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem30.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem30.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem30.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem30.AppearancePressed.Options.UseFont = True
        Me.NavBarItem30.Caption = "Print YTD Accum Ceded Totals"
        Me.NavBarItem30.Name = "NavBarItem30"
        '
        'NavBarItem31
        '
        Me.NavBarItem31.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem31.Appearance.Options.UseFont = True
        Me.NavBarItem31.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem31.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem31.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem31.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem31.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem31.AppearancePressed.Options.UseFont = True
        Me.NavBarItem31.Caption = "Print YTD Pfee Direct Allocation"
        Me.NavBarItem31.Name = "NavBarItem31"
        '
        'NavBarItem32
        '
        Me.NavBarItem32.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem32.Appearance.Options.UseFont = True
        Me.NavBarItem32.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem32.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem32.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem32.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem32.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem32.AppearancePressed.Options.UseFont = True
        Me.NavBarItem32.Caption = "Print YTD Pfee Ceded Allocation"
        Me.NavBarItem32.Name = "NavBarItem32"
        '
        'NavBarItem33
        '
        Me.NavBarItem33.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem33.Appearance.Options.UseFont = True
        Me.NavBarItem33.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem33.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem33.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem33.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem33.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem33.AppearancePressed.Options.UseFont = True
        Me.NavBarItem33.Caption = "Print ITD Accident Year Totals"
        Me.NavBarItem33.Name = "NavBarItem33"
        '
        'NavBarItem34
        '
        Me.NavBarItem34.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem34.Appearance.Options.UseFont = True
        Me.NavBarItem34.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem34.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem34.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem34.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem34.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem34.AppearancePressed.Options.UseFont = True
        Me.NavBarItem34.Caption = "Print YTD MGA Breakdown Net/Retained"
        Me.NavBarItem34.Name = "NavBarItem34"
        '
        'NavBarItem35
        '
        Me.NavBarItem35.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem35.Appearance.Options.UseFont = True
        Me.NavBarItem35.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem35.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem35.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem35.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem35.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem35.AppearancePressed.Options.UseFont = True
        Me.NavBarItem35.Caption = "Print Quarterly Commericial Totals"
        Me.NavBarItem35.Name = "NavBarItem35"
        '
        'NavBarItem36
        '
        Me.NavBarItem36.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem36.Appearance.Options.UseFont = True
        Me.NavBarItem36.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem36.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem36.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem36.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem36.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem36.AppearancePressed.Options.UseFont = True
        Me.NavBarItem36.Caption = "Print Quarterly Private Passenger Totals"
        Me.NavBarItem36.Name = "NavBarItem36"
        '
        'NavBarItem37
        '
        Me.NavBarItem37.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem37.Appearance.Options.UseFont = True
        Me.NavBarItem37.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem37.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem37.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem37.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem37.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem37.AppearancePressed.Options.UseFont = True
        Me.NavBarItem37.Caption = "Print PP Summary"
        Me.NavBarItem37.Name = "NavBarItem37"
        '
        'NavBarItem38
        '
        Me.NavBarItem38.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem38.Appearance.Options.UseFont = True
        Me.NavBarItem38.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem38.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem38.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem38.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem38.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem38.AppearancePressed.Options.UseFont = True
        Me.NavBarItem38.Caption = "Print Comm Summary"
        Me.NavBarItem38.Name = "NavBarItem38"
        '
        'NavBarItem39
        '
        Me.NavBarItem39.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem39.Appearance.Options.UseFont = True
        Me.NavBarItem39.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem39.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem39.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem39.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem39.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem39.AppearancePressed.Options.UseFont = True
        Me.NavBarItem39.Caption = "Create YTD Comm Liab Loss Data File"
        Me.NavBarItem39.Name = "NavBarItem39"
        '
        'NavBarGroup7
        '
        Me.NavBarGroup7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarGroup7.Appearance.Options.UseFont = True
        Me.NavBarGroup7.Caption = "Year End Programs"
        Me.NavBarGroup7.Expanded = True
        Me.NavBarGroup7.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem40), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem41), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem42), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem43), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem44), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem45), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem46), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem47), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem48), New DevExpress.XtraNavBar.NavBarItemLink(Me.EoyCloseout)})
        Me.NavBarGroup7.Name = "NavBarGroup7"
        '
        'NavBarItem40
        '
        Me.NavBarItem40.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem40.Appearance.Options.UseFont = True
        Me.NavBarItem40.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem40.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem40.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem40.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem40.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem40.AppearancePressed.Options.UseFont = True
        Me.NavBarItem40.Caption = "Schedp Processing"
        Me.NavBarItem40.Name = "NavBarItem40"
        '
        'NavBarItem41
        '
        Me.NavBarItem41.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem41.Appearance.Options.UseFont = True
        Me.NavBarItem41.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem41.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem41.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem41.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem41.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem41.AppearancePressed.Options.UseFont = True
        Me.NavBarItem41.Caption = "Schedp Processing All MGAs Only"
        Me.NavBarItem41.Name = "NavBarItem41"
        '
        'NavBarItem42
        '
        Me.NavBarItem42.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem42.Appearance.Options.UseFont = True
        Me.NavBarItem42.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem42.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem42.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem42.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem42.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem42.AppearancePressed.Options.UseFont = True
        Me.NavBarItem42.Caption = "Step 1 YTD Accumulation Totals "
        Me.NavBarItem42.Name = "NavBarItem42"
        '
        'NavBarItem43
        '
        Me.NavBarItem43.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem43.Appearance.Options.UseFont = True
        Me.NavBarItem43.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem43.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem43.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem43.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem43.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem43.AppearancePressed.Options.UseFont = True
        Me.NavBarItem43.Caption = "Step 2 ITD Accumulation Totals"
        Me.NavBarItem43.Name = "NavBarItem43"
        '
        'NavBarItem44
        '
        Me.NavBarItem44.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem44.Appearance.Options.UseFont = True
        Me.NavBarItem44.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem44.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem44.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem44.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem44.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem44.AppearancePressed.Options.UseFont = True
        Me.NavBarItem44.Caption = "Step 3 Unearned Premium Update"
        Me.NavBarItem44.Name = "NavBarItem44"
        '
        'NavBarItem45
        '
        Me.NavBarItem45.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem45.Appearance.Options.UseFont = True
        Me.NavBarItem45.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem45.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem45.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem45.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem45.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem45.AppearancePressed.Options.UseFont = True
        Me.NavBarItem45.Caption = "Eoy Reinsurer Ceded Allocation"
        Me.NavBarItem45.Name = "NavBarItem45"
        '
        'NavBarItem46
        '
        Me.NavBarItem46.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem46.Appearance.Options.UseFont = True
        Me.NavBarItem46.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem46.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem46.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem46.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem46.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem46.AppearancePressed.Options.UseFont = True
        Me.NavBarItem46.Caption = "Eoy Reinsurer Payable Allocation"
        Me.NavBarItem46.Name = "NavBarItem46"
        '
        'NavBarItem47
        '
        Me.NavBarItem47.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem47.Appearance.Options.UseFont = True
        Me.NavBarItem47.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem47.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem47.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem47.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem47.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem47.AppearancePressed.Options.UseFont = True
        Me.NavBarItem47.Caption = "Eoy Reinsurer Aging Allocation"
        Me.NavBarItem47.Name = "NavBarItem47"
        '
        'NavBarItem48
        '
        Me.NavBarItem48.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem48.Appearance.Options.UseFont = True
        Me.NavBarItem48.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem48.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem48.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem48.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem48.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem48.AppearancePressed.Options.UseFont = True
        Me.NavBarItem48.Caption = "Eoy Print  Reinsurance Reports"
        Me.NavBarItem48.Name = "NavBarItem48"
        '
        'NavBarGroup8
        '
        Me.NavBarGroup8.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarGroup8.Appearance.Options.UseFont = True
        Me.NavBarGroup8.Caption = "Broker Maintenance"
        Me.NavBarGroup8.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem49), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem50)})
        Me.NavBarGroup8.Name = "NavBarGroup8"
        '
        'NavBarItem49
        '
        Me.NavBarItem49.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem49.Appearance.Options.UseFont = True
        Me.NavBarItem49.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem49.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem49.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem49.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem49.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem49.AppearancePressed.Options.UseFont = True
        Me.NavBarItem49.Caption = "Broker Maintenance"
        Me.NavBarItem49.Name = "NavBarItem49"
        '
        'NavBarItem50
        '
        Me.NavBarItem50.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem50.Appearance.Options.UseFont = True
        Me.NavBarItem50.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem50.AppearanceDisabled.Options.UseFont = True
        Me.NavBarItem50.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.NavBarItem50.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem50.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.NavBarItem50.AppearancePressed.Options.UseFont = True
        Me.NavBarItem50.Caption = "Broker Treaty Assignment Maintenance"
        Me.NavBarItem50.Name = "NavBarItem50"
        '
        'EoyCloseout
        '
        Me.EoyCloseout.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EoyCloseout.Appearance.Options.UseFont = True
        Me.EoyCloseout.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EoyCloseout.AppearanceDisabled.Options.UseFont = True
        Me.EoyCloseout.AppearanceHotTracked.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EoyCloseout.AppearanceHotTracked.Options.UseFont = True
        Me.EoyCloseout.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EoyCloseout.AppearancePressed.Options.UseFont = True
        Me.EoyCloseout.Caption = "Eoy Closeout"
        Me.EoyCloseout.Name = "EoyCloseout"
        '
        'frmMain
        '
        Me.AllowFormGlass = DevExpress.Utils.DefaultBoolean.[False]
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1251, 835)
        Me.Controls.Add(Me.NavBarControl1)
        Me.Controls.Add(Me.ribbonControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Ribbon = Me.ribbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home State Insurance Company"
        CType(Me.ribbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.appMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ribbonImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ribbonImageCollectionLarge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ribbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Private WithEvents homeRibbonPage As DevExpress.XtraBars.Ribbon.RibbonPage
    Private WithEvents iClose As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iFind As DevExpress.XtraBars.BarButtonItem
    Private WithEvents alignButtonGroup As DevExpress.XtraBars.BarButtonGroup
    Private WithEvents iBoldFontStyle As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iItalicFontStyle As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iUnderlinedFontStyle As DevExpress.XtraBars.BarButtonItem
    Private WithEvents fontStyleButtonGroup As DevExpress.XtraBars.BarButtonGroup
    Private WithEvents iLeftTextAlign As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iCenterTextAlign As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iRightTextAlign As DevExpress.XtraBars.BarButtonItem
    Private WithEvents skinsRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Private WithEvents rgbiSkins As DevExpress.XtraBars.RibbonGalleryBarItem
    Private WithEvents exitRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Private WithEvents iExit As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iAbout As DevExpress.XtraBars.BarButtonItem
    Private WithEvents appMenu As DevExpress.XtraBars.Ribbon.ApplicationMenu
    Private WithEvents ribbonImageCollection As DevExpress.Utils.ImageCollection
    Private WithEvents ribbonImageCollectionLarge As DevExpress.Utils.ImageCollection
    Friend WithEvents NavBarControl1 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavBarGroup1 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem1 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem2 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem3 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem4 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem5 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem6 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem7 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem8 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem51 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarGroup2 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem9 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarGroup3 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem10 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem11 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem12 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem13 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem14 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem15 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem16 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem17 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem18 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarGroup4 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem19 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem20 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem52 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarGroup5 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem21 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem22 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem23 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem24 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem25 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem26 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem27 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem28 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarGroup6 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem29 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem30 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem31 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem32 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem33 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem34 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem35 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem36 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem37 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem38 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem39 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarGroup7 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem40 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem41 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem42 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem43 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem44 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem45 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem46 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem47 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem48 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarGroup8 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem49 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem50 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents iReset As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UtilRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents iNavMenu As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents iClearDesktop As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents EoyCloseout As DevExpress.XtraNavBar.NavBarItem

End Class
