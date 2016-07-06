Option Strict Off
Option Explicit On
Module fileStateRef
	
	'FIELD4 structure pointers -- (STATEREF)
	Public Structure PtrState
		Dim StateCode As Integer
		Dim StateName As Integer
	End Structure
	Public STp As PtrState
	
	Public Sub GetStateRefPtr()
		STp.StateCode = d4field(f90, "CODE")
		STp.StateName = d4field(f90, "NAME")
	End Sub
End Module