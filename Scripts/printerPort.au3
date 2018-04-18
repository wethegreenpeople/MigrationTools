#RequireAdmin

Local $parentDir = StringLeft(@scriptDir,StringInStr(@scriptDir,"\",0,-1)-1)
Local $psSpoolDir = " CD $env:windir\System32\Spool\Tools;"
Local $psExportPrinter = ".\PrintBrm.exe -b -f " & "C:\printers.printerExport"
Local $psImportPrinter = ".\PrintBrm.exe -r -f " & $parentDir & "\printers.printerExport"

If $CmdLine[0] > 0 Then
   If $CmdLine[1] == "export" Then
	  If (FileExists($parentDir & "\printers.printerExport")) Then
		 FileDelete($parentDir & "\printers.printerExport")
	  EndIf
	  If (FileExists("C:\printers.printerExport")) Then
		 FileDelete("C:\printers.printerExport")
	  EndIf
	  RunWait("powershell.exe" & $psSpoolDir & $psExportPrinter)
	  FileMove("C:\printers.printerExport", $parentDir & "\printers.printerExport")
   ElseIf $CmdLine[1] == "import" Then
	  RunWait("powershell.exe" & $psSpoolDir & $psImportPrinter)
   EndIf
Else
   MsgBox(0, "Error", "Cannot be run directly")
EndIf