@echo
wmic computersystem where name="%COMPUTERNAME%" call rename name="JSINGHRDMT205" 
wmic os set description="Information_Technologies" 