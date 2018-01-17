#RequireAdmin

$cmdDisjoin = " Remove-Computer -UnjoinDomaincredential tmccadmn.tmcc.edu\" & @UserName & " -PassThru -Verbose -Force"
RunWait("powershell.exe -NoExit" & $cmdDisjoin)