   M S B A M L   `   `   `  ����[  Wnmct.ba.cashlessproject.uimanage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:nmct.ba.cashlessproject.uimanage.ViewModel*nmct.ba.cashlessproject.uimanage.ViewModel  5      1    +nmct.ba.cashlessproject.uimanage.View.Kassa   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Gvm8clr-namespace:nmct.ba.cashlessproject.uimanage.ViewModel     5        � DataContext  5	      8   2nmct.ba.cashlessproject.uimanage.ViewModel.KassaVM  5
   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��200* �6   �� 5      $
��400* �6   �� 5      $
��400* �6   �� 5      $
��200* �6    � RowDefinitions 5   
   �� 5      $	��89* �6   �� 5      $
��561* �6   .+�5   
   ��  	  Title#��[  6   $��117,10,121,0q�63   $��Kassa's��6I   $��1��6X   �� 5   
    �� DisplayMemberPath$ RegisterName��61     ListBox#��[ 6t   $��1��6�   $��20q�6�   $��1��6�   ��6   �� *Kassas+ �� SelectedItem 6R   �� *
Selected+6�   �� 5   
   #��[  6   $��
47,10,43,0q�63   $��
Medewerker��6G   $��2��6Y   �� 5   
   #��[ 6   $��2��63   $��20q�6C   $��1��6O   $ EmployeeName��6~   ��6\   �� *	Employees+6~   5      5      