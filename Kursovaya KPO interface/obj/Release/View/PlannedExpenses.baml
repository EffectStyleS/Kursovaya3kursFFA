   M S B A M L   `   `   `  ???? R  NKursovaya KPO interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Kursovaya_KPO_interface.ViewModel!Kursovaya_KPO_interface.ViewModel  2    ,Kursovaya_KPO_interface.View.PlannedExpenses   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:Kursovaya_KPO_interface.ViewModel       N? ShowsNavigationUI  .   ? DataContext A   ;Kursovaya_KPO_interface.ViewModel.PlanndexExpensesViewModel  .????  ?? CornerRadius$ 10??????  ?? Color$ #ffffff??._??? .+??? .+??? $??Family Finance Analysis??$??40(?$??Center=?   BaseTextBlockStyle#??[  ?? $/??)Расходы месяца с 29.10.2022??$??36(?$??Center=?#??[  ?? $??250,20,250,20q?&   System.Windows.Controls.DataGrid  $??Center=?$??Center=?$??0 15 0 0q????#e4e4e4$??	0 0 0 275q???Z?    Columns 0  *System.Windows.Controls.DataGridTextColumn     
FontFamily$ 
Montserrat)?   
FontWeight$ Light"?,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    Header$ Тип??  $ 
Montserrat)?$ Light"?$ * $ 
Сумма???? 	 ?? Orientation$	 
Horizontal=????#e4e4e4.+??? $??Всего:??$??	435 0 0 0q?$??Center=?$??Center=?$??32(?#??[  
 ?? Padding$
 6q??? $??10 0 0 0q?$??32(?$??
Montserrat)?$??Light"?
?????? $??1 0 0 0q?$	??560???? $	 
Horizontal=?$??0 33 0 0q?.+??? $ 	0 10 0 10?????? $ #e4e4e4??._??? $??Сохранить??$??30 15 30 14q?  BaseButtonStyle#??[ ?? $??	705 0 0 0q?$ 	10 0 10 0?????? $ #e4e4e4??._??? -   $??
Выйти??$??53 15 50 14q?#??[ 