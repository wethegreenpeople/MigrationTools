#RequireAdmin

Local $parentDir = StringLeft(@scriptDir,StringInStr(@scriptDir,"\",0,-1)-1)
Local $psSpoolDir = " CD $env:windir\System32\Spool\Tools;"
Local $psExportPrinter = ".\PrintBrm.exe -b -f " & "C:\printers.printerExport"
Local $psImportPrinter = ".\PrintBrm.exe -r -f " & $parentDir & "\printers.printerExport"

If $CmdLine[0] > 0 Then
   If $CmdLine[1] == "export" Then
	  RunWait("powershell.exe -NoExit" & $psSpoolDir & $psExportPrinter)
   ElseIf $CmdLine[1] == "import" Then
	  RunWait("powershell.exe -NoExit" & $psSpoolDir & $psImportPrinter)
   EndIf
Else
   MsgBox(0, "Error", "Cannot be run directly")
EndIf