Option Strict Off
Option Explicit On
Module filePeriod
	
	'Form Period Maintenance Work Vars
	Public lsP1 As Short
	Public lsP2 As Short
	Public lsP3 As Short
	Public lsP4 As Short
	Public lsP5 As Short
	Public lsP6 As Short
	Public lsP7 As Short
	Public lsP8 As Short
	Public lsP9 As Short
	Public lsP10 As Short
	Public lsP11 As Short
	Public lsP12 As Short
	Public txYear As String
	Public txQuarter As String
	
	Public Parry(2) As Short
	
	'FIELD4 structure pointers -- (PERIOD)
	Public Structure PtrPeriod
		Dim P1 As Integer
		Dim P2 As Integer
		Dim P3 As Integer
		Dim P4 As Integer
		Dim P5 As Integer
		Dim P6 As Integer
		Dim P7 As Integer
		Dim P8 As Integer
		Dim P9 As Integer
		Dim P10 As Integer
		Dim P11 As Integer
		Dim P12 As Integer
		Dim PYear As Integer
		Dim PQuarter As Integer
	End Structure
	Public PDp As PtrPeriod
	
	Sub GetPeriodPtr()
		PDp.PYear = d4field(f92, "YEAR")
		PDp.PQuarter = d4field(f92, "QUARTER")
		PDp.P1 = d4field(f92, "P1")
		PDp.P2 = d4field(f92, "P2")
		PDp.P3 = d4field(f92, "P3")
		PDp.P4 = d4field(f92, "P4")
		PDp.P5 = d4field(f92, "P5")
		PDp.P6 = d4field(f92, "P6")
		PDp.P7 = d4field(f92, "P7")
		PDp.P8 = d4field(f92, "P8")
		PDp.P9 = d4field(f92, "P9")
		PDp.P10 = d4field(f92, "P10")
		PDp.P11 = d4field(f92, "P11")
		PDp.P12 = d4field(f92, "P12")
	End Sub
	
	Sub GetPeriodVar()
		lsP1 = f4int(PDp.P1)
		lsP2 = f4int(PDp.P2)
		lsP3 = f4int(PDp.P3)
		lsP4 = f4int(PDp.P4)
		lsP5 = f4int(PDp.P5)
		lsP6 = f4int(PDp.P6)
		lsP7 = f4int(PDp.P7)
		lsP8 = f4int(PDp.P8)
		lsP9 = f4int(PDp.P9)
		lsP10 = f4int(PDp.P10)
		lsP11 = f4int(PDp.P11)
		lsP12 = f4int(PDp.P12)
		Warry(1) = lsP1
		Warry(2) = lsP2
		Warry(3) = lsP3
		Warry(4) = lsP4
		Warry(5) = lsP5
		Warry(6) = lsP6
		Warry(7) = lsP7
		Warry(8) = lsP8
		Warry(9) = lsP9
		Warry(10) = lsP10
		Warry(11) = lsP11
		Warry(12) = lsP12
		Parry(1) = f4int(PDp.PYear)
		Parry(2) = f4int(PDp.PQuarter)
	End Sub
	
	Sub UpPeriodFlds()
		Call f4assignInt(PDp.P1, lsP1)
		Call f4assignInt(PDp.P2, lsP2)
		Call f4assignInt(PDp.P3, lsP3)
		Call f4assignInt(PDp.P4, lsP4)
		Call f4assignInt(PDp.P5, lsP5)
		Call f4assignInt(PDp.P6, lsP6)
		Call f4assignInt(PDp.P7, lsP7)
		Call f4assignInt(PDp.P8, lsP8)
		Call f4assignInt(PDp.P9, lsP9)
		Call f4assignInt(PDp.P10, lsP10)
		Call f4assignInt(PDp.P11, lsP11)
		Call f4assignInt(PDp.P12, lsP12)
		Call f4assignInt(PDp.PYear, Parry(1))
		Call f4assignInt(PDp.PQuarter, Parry(2))
	End Sub
	
	Sub AddPeriodRec()
		If Not ValUser Then Exit Sub
		AddTran = True
		
		If d4appendStart(f92, 0) <> r4success Then
			AddTran = False
			Exit Sub
		End If
		
		Call UpPeriodFlds()
		rc = d4append(f92)
		rc = d4unlock(f92)
	End Sub
	
	Sub UpPeriodRec()
		If Not ValUser Then Exit Sub
		UpPeriodFlds()
		rc = d4unlock(f92)
	End Sub
	
	Sub GetPeriodRec()
		Fstat = 0
		UpdateTran = False
		AddTran = False
		Call d4tagSelect(f92, d4tag(f92, "K1"))
		rc = d4top(f92)
		
		If rc <> 0 Then
			MsgBox("Period Parm Rec Error Unable to edit")
			Exit Sub
		End If
		
		rc = code4lockAttempts(cb, 1)
		rc = d4lock(f92, d4recNo(f92))
		
		If rc = r4locked Then
			Fstat = rc
			MsgBox("Record Locked. Unable to edit")
			rc = code4lockAttempts(cb, 0)
			Exit Sub
		End If
		
		GetPeriodVar()
		rc = code4lockAttempts(cb, 0)
		UpdateTran = True
	End Sub
	
	Sub DelPeriodRec()
		If Not ValUser Then Exit Sub
		rc = d4unlock(f92)
		Call d4blank(f92)
	End Sub
End Module