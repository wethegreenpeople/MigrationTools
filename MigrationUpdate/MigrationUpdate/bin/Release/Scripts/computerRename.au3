#RequireAdmin

#include <File.au3>

FileOpen("..\computer.txt")
$newComputerName = FileReadLine("../computer.txt", 1)
$cmdRename = " Rename-Computer -NewName " & $newComputerName & " -DomainCredential tmccadmn.tmcc.edu\" & @UserName

RunWait("powershell.exe -NoExit" & $cmdRename)