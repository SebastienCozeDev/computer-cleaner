   M S B A M L   `   `   `  ???? J  FComputerCleaner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ComputerCleanerComputerCleaner       ComputerCleaner.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:ComputerCleaner     -     ?Name$  window?? ? Title$ Computer Cleaner??$	??700??$
??1000?? ? Icon$ /icos/window_ico.png?? ? 
ResizeMode$ CanMinimize=? ? WindowStartupLocation$ CenterScreen=?.???  ? ColumnDefinitions ?? $
??459* ??? $	??41* ?.+??? $
??Left=?$	??175??$	??Top=?$	??990??$??2?????	#FF0077B6?? -    ??Name$ title??$)??#Analyse de l'ordinateur nécessaire??$
??Left=?$??	35,10,0,0q?$	??Top=?
???????$??Arial)?$??40(?$
??Bold"?$??56??$	??669???? $??Espace à nettoyer : ??$
??Left=?$??	80,71,0,0q?$	??Top=?
???????$??Arial)?$??22(?$
??Bold"?$??35??$	??218???? $??Dernière analyse : ??$
??Left=?$??
86,111,0,0q?$	??Top=?
???????$??Arial)?$??22(?$
??Bold"?$??35??$	??206???? -   $
 date??$??Jamais??$
??Left=?$??328,111,0,0q?$	??Top=?
???????$??Arial)?$??22(?$??35??$	??272???? -   $ space??$
??0 Mb??$
??Left=?$??
328,71,0,0q?$	??Top=?
???????$??Arial)?$??22(?$??35??$	??272???? -   $??ANALYSER??$
??Left=?$??
752,48,0,0q?$	??Top=?$??2??$??80??$	??190??$??5,5,5,5q????	#FF0077B6
???????
???????$??Arial)?$
??Bold"??? -    ??Name$ cleanButton??$??NETTOYER??$
??Left=?$??
62,227,0,0q?$	??Top=?$	??100??$	??380??$??5,5,5,5q????	#FF0077B6
???????
???????$??Arial)?$
??Bold"??? -   $??
HISTORIQUE??$??Right=?$??502,227,0,0q?$	??Top=?$	??100??$	??380??$??5,5,5,5q????	#FF0077B6
???????
???????$??Arial)?$
??Bold"??? -   $??MISE À JOUR??$
??Left=?$??
62,381,0,0q?$	??Top=?$	??100??$	??380??$??5,5,5,5q????	#FF0077B6
???????
???????$??Arial)?$
??Bold"??? -	   $??SITE WEB??$??Right=?$??502,381,0,0q?$	??Top=?$	??100??$	??380??$??5,5,5,5q????	#FF0077B6
???????
???????$??Arial)?$
??Bold"??? $??575,406,0,0q?$??/icos/website.png??$
??Fill=?$??50??$??50??$
??Left=?$	??Top=?$??6???? $??100,252,0,0q?$??/icos/cleaner.png??$
??Fill=?$??50??$??50??$
??Left=?$	??Top=?$??6???? $??575,252,0,0q?$??/icos/history.png??$
??Fill=?$??50??$??50??$
??Left=?$	??Top=?$??6???? $??100,406,0,0q?$??/icos/update.png??$
??Fill=?$??50??$??50??$
??Left=?$	??Top=?$??6???? $
??Left=?$	??141??$	??Top=?$	??990??$??2?????	#FF1C1D1F$??	0,533,0,0q??? -
   $ coyrightLabel??$&?? Copyright 2022 - Coze Sébastien??$
??Left=?$??	0,555,0,0q?$	??Top=?
???????$??Arial)?$??Center=?$??2??$	??990??$??24???? -    ??Name$ newsRectangle??$
??Left=?$??70??$	??Top=?$	??990??$??2?????	#FF944242$??	0,604,0,0q?$y?Hidden=??? -   $
 news??$&?? Copyright 2022 - Coze Sébastien??$
??Left=?$??	0,621,0,0q?$	??Top=?
???????$??Arial)?$??Center=?$??2??$	??990??$y?Hidden=?$??24??