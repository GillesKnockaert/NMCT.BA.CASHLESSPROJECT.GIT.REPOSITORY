   M S B A M L   `   `   `  ����[  Wnmct.ba.cashlessproject.uimanage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:nmct.ba.cashlessproject.uimanage.ViewModel*nmct.ba.cashlessproject.uimanage.ViewModel  5      7    1nmct.ba.cashlessproject.uimanage.View.Medewerkers   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Gvm8clr-namespace:nmct.ba.cashlessproject.uimanage.ViewModel     5        � DataContext  5	      >   8nmct.ba.cashlessproject.uimanage.ViewModel.MedewerkersVM  5
   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��400* �6   �� 5      $
��400* �6   �� 5      $
��100* �6    � RowDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $	��77* �6   �� 5      $	��77* �6   �� 5      $	��77* �6   .+�5   
   ��  	  Title#��[  6   $��
82,10,88,0q�63   $��Medewerkers��6G   $��1��6Z   $	��310��6j   �� 5   
    �� DisplayMemberPath$ EmployeeName��66     ListBox#��[ 6y   $��1��6�   $��20,20,20,13q�6�   $��1��6�   $��6��6�   ��6   �� *Medewerkers+ �� SelectedItem 6W   �� *
Selected+6�   �� 5   
    	 Label#��[ 6   $��
34,10,0,27q�6/   $
��Naam��6C   $��2��6R   $��63��6b   �� 5    
     TextBox#��[ 69   $��34,44,21,10q�6Z   $��2��6o   ��6   �� *Selected.EmployeeName+6o   �� 5!   
   #��[ 6   $��
34,10,0,16q�6/   $��Adres��6C   $��2��6S   $��63��6c   $��1��6n   �� 5"   
   #��[ 64   $��34,48,21,10q�6U   $��2��6j   $��1��6z   ��6   �� *Selected.Address+6z   �� 5#   
   #��[ 6   $��
34,10,0,40q�6/   $��Email��6C   $��2��6S   $��78��6c   $��2��6n   �� 5$   
   #��[ 62   $��34,45,21,10q�6S   $��2��6h   $��2��6x   ��6   �� *Selected.Email+6x   �� 5%   
   #��[ 6   $��
34,10,0,40q�6/   $��Telefoon Nummer��6C   $��2��6]   $	��181��6m   $��3��6y   �� 5&   
   #��[ 62   $��34,45,21,10q�6S   $��2��6h   $��3��6x   ��6   �� *Selected.Phone+6x   �� 5(   
    
 Button#��[ 63   $��34,10,21,13q�6S   $��Nieuw��6h   $��2��6x   $��4��6�   ��6   �� *InsertCommand+6�   �� 5)   
   #��[ 63   $��34,10,21,13q�6S   $��Opslaan��6h   $��2��6z   $��5��6�   ��6   �� *UpdateCommand+6�   �� 5*   
   #��[ 63   $��34,10,21,13q�6S   $��Verwijderen��6h   $��2��6~   $��6��6�   ��6   �� *DeleteCommand+6�   5+      5,      