   M S B A M L   `   `   `  ����[  Wnmct.ba.cashlessproject.uimanage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:nmct.ba.cashlessproject.uimanage.ViewModel*nmct.ba.cashlessproject.uimanage.ViewModel  5      1    +nmct.ba.cashlessproject.uimanage.View.Login   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Gvm8clr-namespace:nmct.ba.cashlessproject.uimanage.ViewModel     5        � DataContext  5	      8   2nmct.ba.cashlessproject.uimanage.ViewModel.LoginVM  5
   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��150* �6   �� 5      $
��100* �6    � RowDefinitions 5   
   �� 5      $	��65* �6   �� 5      $	��93* �6   �� 5      $
��110* �6   �� 5      $
��110* �6   �� 5      $
��105* �6   �� 5      $
��170* �6   .+�5   
   ��  	  Title#��[  6   $��1��63   $��1��6C   $��	Aanmelden��6P   $��128,20,127,10q�6a   �� 5   
    	 Label#��[ 6   $��1��6/   $��
40,10,0,43q�6?   $��2��6S   $��Login��6`   �� 5   
     TextBox#��[ 6,   $��1��6M   $��2��6]   $��40,49,40,10q�6j   ��6   �� *
Username+6j   �� 5   
   #��[ 6   $��1��6/   $��
40,10,0,40q�6?   $��3��6S   $��
Wachtwoord��6`   �� 5   
   #��[ 6,   $��1��6M   $��3��6]   $��40,47,40,10q�6j   ��6   �� *
Password+6j   �� 5   
    
 Button#��[ 62   $��1��6R   $��40,10q�6b   $��4��6q   $��	Aanmelden��6~   ��6   �� *LoginCommand+6~   �� 5    
   
���  ��$��5��6<   $��1��6I   $��128,10,144,44q�6Y   ��6%   �� *Error+6Y   5!      5"      