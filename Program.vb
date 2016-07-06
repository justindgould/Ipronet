' Developer Express Code Central Example:
' How to change a skin element programmatically
' 
' This example demonstrates how to change a skin element's image programmatically.
' More information can be found in the http://www.devexpress.com/scid=K18374
' Knowledge Base article.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2104

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports DevExpress.UserSkins

Namespace WindowsApplication1
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
            BonusSkins.Register()
			SkinManager.EnableFormSkins()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New frmMain())
		End Sub
	End Class
End Namespace