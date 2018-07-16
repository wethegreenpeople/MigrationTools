$cmdRejoin = " Add-Computer -DomainName tmccadmn.tmcc.edu -DomainCredential tmccadmn.tmcc.edu\" & @UserName & " -Force"
RunWait("powershell.exe -NoExit" & $cmdRejoin)