   M S B A M L   `   `   `  ����D  @Session_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Session_1	Session_1  5          Session_1.SCMainPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Session_1     5        N� Title$  
SCMainPage��5	       � 	Resources 5
       
  Button �� Property �� Value��%�   &	        �� 5   
   .�5      ��  � ��$	 165��67   �� 5       � ��$ 32��68   �� 5       � ��$ 14(�61   �� 5       � ��$	 Top=�6C   �� 5       � ��$
 Left=�6E   5      5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridView��5      $
��Left=�6)   $	��255��6D   $	��Top=�6Q   $	��800��6i    �� SelectedIndex$ 0��6u   |�.     CanUserReorderColumns .     CanUserAddRows .     CanUserDeleteRows .  	   CanUserResizeRows	 .  
   
IsReadOnly
 . 6  �� 5   
   -   5         ��Name$ List_SC��5      $��Список ТЦ��6"   $
��Left=�66   $��
10,260,0,0q�6Q   $	��Top=�6e   $	��150��6}   $��32��6�   6�   �� 5   
   -   5        $ Add_SC��5      $��Доб./Изм. ТЦ��6!   $
��Left=�68   $��165,260,0,0q�6S   $	��Top=�6h   $	��150��6�   $��32��6�   6�   �� 5   
   -   5        $ 	Remove_SC��5      $��Удаление ТЦ��6$   $
��Left=�6:   $��165,292,0,0q�6U   $	��Top=�6j   $	��150��6�   $��32��6�   6�   �� 5   
   -   5        $
 Exit��5      $��
Выход��6*   $��
10,324,0,0q�6M   #���   6b   $	��150��6�   �� 5   
   -   5         ��Name$ SC_Text��5      $
��Left=�6#   $��23��6>   $��
10,367,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6s   $	��120��6�   �� 5   
   -   5         ��Name$ Notify��5      $
��Left=�6!   $��	0,390,0,0q�6<   $	��Top=�6O   $	��325��6g   $��27��6s   �� 5   
   -   5        $ ViewSC��5      $��Просмотр ТЦ��6!   $
��Left=�67   $��
10,292,0,0q�6R   $	��Top=�6f   $	��150��6~   $��32��6�   6�   �� 5   
   -	   5         ��Name$ 	testImage��5      $
��Left=�6#   $	��157��6>   $��369,260,0,0q�6K   $	��Top=�6`   $	��390��6x   �� 5   
   -
   5        $ 	paybackSC��5      $6��0Процентная окупаемость ТЦ��6/   $��165,324,0,0q�6f   #���   6|   $	��199��6�   6�   5!      5"      