   M S B A M L   `   `   `  ����[  Wnmct.ba.cashlessproject.uimanage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:nmct.ba.cashlessproject.uimanage.ViewModel*nmct.ba.cashlessproject.uimanage.ViewModel  5      5    /nmct.ba.cashlessproject.uimanage.View.Producten   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Gvm8clr-namespace:nmct.ba.cashlessproject.uimanage.ViewModel     5        � DataContext  5	      <   6nmct.ba.cashlessproject.uimanage.ViewModel.ProductenVM  5
   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��400* �6   �� 5      $
��400* �6   �� 5      $
��100* �6    � RowDefinitions 5   
   �� 5      $	��78* �6   �� 5      $	��88* �6   �� 5      $	��85* �6   �� 5      $	��92* �6   �� 5      $	��98* �6   �� 5      $	��65* �6   �� 5      $	��94* �6   .+�5   
   ��  	  Title#��[  6   $��149,10,152,10q�63   $��
Prijslijst��6J   $��1��6\   �� 5   
    �� DisplayMemberPath$ ProductName��64     ListBox#��[ 6v   $��1��6�   $��
20,7,20,20q�6�   $��1��6�   $��6��6�   ��6   �� *	Producten+ �� SelectedItem 6T   �� *
Selected+6�   �� 5    
   #��[  6   $��197,10,192,10q�63   $
��Info��6J   $��2��6V   �� 5!   
    	 Label#��[ 6   $��	34,0,0,30q�6/   $��Productnaam��6B   $��2��6X   $	��140��6h   $��1��6t   �� 5"   
     TextBox#��[ 68   $��1��6Y   $��34,37,21,10q�6f   $��2��6{   ��6   �� *Selected.ProductName+6{   �� 5#   
   #��[ 6   $��	34,0,0,13q�6/   $��2��6B   $��Prijs (in €)��6O   $��2��6f   $	��106��6v   �� 5$   
   #��[ 62   $��2��6S   $��34,35,21,10q�6`   $��2��6u   ��6   �� *Selected.Price+6u   �� 5%   
    
 Button#��[ 63   $��
34,41,21,7q�6S   $��50��6g   $��4��6s   $��Nieuw��6�   $��2��6�   ��6   �� *InsertCommand+6�   �� 5&   
   #��[ 63   $��	34,8,21,7q�6S   $��50��6f   $��5��6r   $��Opslaan��6   $��2��6�   ��6   �� *UpdateCommand+6�   �� 5'   
   #��[ 63   $��34,10,21,34q�6S   $��50��6h   $��6��6t   $��Verwijderen��6�   $��2��6�   ��6   �� *DeleteCommand+6�   5(      5)      