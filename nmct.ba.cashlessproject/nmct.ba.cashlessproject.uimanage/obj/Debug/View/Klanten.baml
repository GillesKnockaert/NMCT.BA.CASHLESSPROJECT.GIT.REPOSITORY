   M S B A M L   `   `   `  ����[  Wnmct.ba.cashlessproject.uimanage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:nmct.ba.cashlessproject.uimanage.ViewModel*nmct.ba.cashlessproject.uimanage.ViewModel  5      s>clr-namespace:nmct.ba.cashlessproject.uimanage.View.converters0nmct.ba.cashlessproject.uimanage.View.converters  5      3    -nmct.ba.cashlessproject.uimanage.View.Klanten   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Gvm8clr-namespace:nmct.ba.cashlessproject.uimanage.ViewModel     5      Lc>clr-namespace:nmct.ba.cashlessproject.uimanage.View.converters     5        � DataContext  5
      :   4nmct.ba.cashlessproject.uimanage.ViewModel.KlantenVM  5   
    � 	Resources 5      M   Gnmct.ba.cashlessproject.uimanage.View.converters.StringToImageConverter   StringToImageConverter��%   &	          5   
   6#   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��400* �6   �� 5      $
��400* �6   �� 5      $
��100* �6    � RowDefinitions 5   
   �� 5      $	��102 �6   �� 5      $	��102 �6   �� 5      $	��243 �6   �� 5      $	��102 �6   �� 5      $��70 �6   .+�5   
   ��  	 Title#��[ 6   $��152,10,151,0q�63   $��Klanten��6I   $��1��6X   �� 5   
    �� DisplayMemberPath$ CustomerName��62     ListBox#��[ 6u   $��1��6�   $��20,21,20,13q�6�   $��1��6�   $��4��6�   ��6   �� *	Klanten+ �� SelectedItem 6S   �� *
Selected+6�   �� 5    
    	 Label#��[ 6   $��
33,10,0,30q�6/   $
��Naam��6C   $��2��6R   $��63��6b   �� 5!   
     TextBox#��[ 69   $��33,49,34,10q�6Z   $��2��6o   ��6   �� *Selected.CustomerName+6o   �� 5"   
   #��[ 6   $��
33,10,0,29q�6/   $��Adres��6C   $��2��6S   $��1��6c   $��63��6p   �� 5#   
   #��[ 64   $��33,50,34,10q�6U   $��2��6j   $��1��6z   ��6   �� *Selected.Address+6z   �� 5$   
   $��2��65   $��104,10,119,38q�6E   $��2��6\   ��6   �� *AddImageCommand+��5%      �� 5&      .R�5'      �� $��0,8,0,0q�6   $	��170��6.   $	��170��6:   $��2q�6G    �� CornerRadius$ 2��6[   
����� �._�5(      �� $��UniformToFill=�6�   ��6    �� *Selected.Picture+ �� 	Converter# [   �� UpdateSourceTrigger$ PropertyChanged=�6�   5)      5*      5,      �� 5.   
   #��[ 6   $��	33,10,0,7q�6/   $��Saldo (in €)��6B   $��2��6Y   $��3��6i   $	��110��6v   �� 5/   
   #��[ 64   $��33,51,34,10q�6U   $��2��6j   $��3��6z   ��6   �� *Selected.Balance+6z   �� 50   
    
 Button#��[ 63   $��33,10,34,16q�6S   $��Opslaan��6h   $��2��6z   $��4��6�   ��6   �� *UpdateCommand+6�   51      52      