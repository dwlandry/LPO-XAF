;#DropDB LPOEasyTest

#Application LPO.Win
#Application LPO.Web
#IfDef LPO.Win

*Action About...
 
*Action OK

#EndIf

#IfDef LPO.Web
*Action Navigation(My Details)
#EndIf
