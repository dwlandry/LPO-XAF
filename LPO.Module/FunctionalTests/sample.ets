;#DropDB lpmt_xafEasyTest

#Application lpmt_xaf.Win
#Application lpmt_xaf.Web
#IfDef lpmt_xaf.Win

*Action About...
 
*Action OK

#EndIf

#IfDef lpmt_xaf.Web
*Action Navigation(My Details)
#EndIf
