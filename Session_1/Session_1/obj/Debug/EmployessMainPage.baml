   M S B A M L   `   `   `  ����D  @Session_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Session_1	Session_1  5      !    Session_1.EmployessMainPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Session_1     5        N� Title$  EmployessMainPage��5	       � 	Resources 5
       
  Button �� Property �� Value��%�   &	        �� 5   
   .�5      ��  � ��$	 165��67   �� 5       � ��$ 32��68   �� 5       � ��$ 14(�61   �� 5       � ��$	 Top=�6C   �� 5       � ��$
 Left=�6E   5      5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridView��5      $
��Left=�6)   $	��256��6D   $	��Top=�6Q   $	��800��6i    �� SelectedIndex$ 0��6u   |�.     CanUserReorderColumns .     CanUserAddRows .     CanUserDeleteRows .  	   CanUserResizeRows	 .  
   
IsReadOnly
 . 6  �� 5   
   -   5         ��Name$ List_Emp��5      $-��'Список Пользователей��6#   $
��Left=�6B   $��
10,260,0,0q�6]   $	��Top=�6q   $	��150��6�   $��32��6�   6�   �� 5   
   -   5        $ Add_Emp��5      $0��*Доб./Изм. Пользователей��6"   $
��Left=�6D   $��175,260,0,0q�6_   $	��Top=�6t   $	��150��6�   $��32��6�   6�   �� 5   
   -   5        $ 
Remove_Emp��5      $1��+Удаление Пользователей��6%   $
��Left=�6F   $��340,260,0,0q�6a   $	��Top=�6v   $	��150��6�   $��32��6�   6�   �� 5   
   -   5        $
 Exit��5      $��
Выход��6*   $��
10,297,0,0q�6M   #���   6b   $	��150��6�   �� 5   
   -   5         ��Name$ Remove_Emp_Text��5      $
��Left=�6+   $��23��6F   $��340,297,0,0q�6R    �� TextWrapping$
 Wrap=�6g   $	��Top=�6|   $	��120��6�   �� 5   
   -   5         ��Name$ Notify��5      $
��Left=�6!   $��	0,374,0,0q�6<   $	��Top=�6O   $	��325��6g   $��27��6s   �� 5   
   -   5        $ ViewEmp��5      $1��+Просмотр Пользователей��6"   $
��Left=�6C   $��340,327,0,0q�6^   $	��Top=�6s   $	��150��6�   $��32��6�   6�   �� 5   
   -	   5         ��Name$ 	testImage��5      $
��Left=�6#   $	��179��6>   $��495,261,0,0q�6K   $	��Top=�6`   $	��295��6x   �� 5   
   -
   5        $ Search��5      $
��Left=�6"   $��23��6=   $��340,364,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��120��6�   5!      5"      