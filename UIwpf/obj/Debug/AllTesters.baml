   M S B A M L   `   `   `  ����@  <UIwpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIwpfUIwpf  5          UIwpf.AllTesters   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:UIwpf     5      .��5	      � 
�������  � RowDefinitions  5
   
   �� 5      $	��10* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $
��data��5         AutoGenerateColumns .     
IsReadOnly . 
���������6   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Id+  5      $ 
First name��6%    69   �� *
First_name+  5      $ 	Last name��6%    68   �� *	Last_name+  5      $ 	Birthdate��6%    69   �� *	Birthdate+  5      $ Gender��6%    65   �� *	_Gender+  5      $ Phone number��6%    6<   �� *Phone_number+  5      $
 City��6%    63   �� *_Address.City+  5      $ Street��6%    65   �� *_Address.Street+  5      $ Building��6%    67   �� *_Address.Building_number+  5      $ Experience(years)��6%    6A   �� *
Experience+  5      $ Max weekly tests��6%    6?   �� *Max_tests_per_week+  5      $ Max distance��6%    6;   �� *	Max_range+  5      $ 
Speciality��6%    69   �� *
Speciality+5      �� 5   
   -   5        $��
Speciality��5      $��1��6#   $��goup by speciality��60   $
��Left=�6M   6h   �� 5    
   -   5        $��Location��5       $��1��6!   $��goup by location��6.   $��Right=�6I   6e   5!      5"      