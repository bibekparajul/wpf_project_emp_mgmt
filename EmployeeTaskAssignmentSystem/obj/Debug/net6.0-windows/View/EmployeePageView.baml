   M S B A M L   `   `   `  ����W  SEmployeeTaskAssignmentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:EmployeeTaskAssignmentSystem.View!EmployeeTaskAssignmentSystem.View  5      _4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel&EmployeeTaskAssignmentSystem.ViewModel  5      8    2EmployeeTaskAssignmentSystem.View.EmployeePageView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:EmployeeTaskAssignmentSystem.View     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Cvm4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel     5        � DataContext  5      B   <EmployeeTaskAssignmentSystem.ViewModel.EmployeePageViewModel  5   
   .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�57   
   �� $��0��6    �� Orientation$ 
Horizontal=�6%   .+�58      �� $��10,0,0,0q�59      $��Bottom=�5:      $��Search��5;      $��Roboto)�5<      $��14(�5=      $��SemiBold"�5>      �� 5?      $��0��5@      $	��200��5A      $��30��5B      $
��Left=�5C      $��Bottom=�5D      ��5E      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5F      �� 5G   
   $��2��5H      $��
10,20,10,0q�5I      $��Add New Employee��5K         CustomButtonStyle#��[  5L      ��5J      �� *OpenEmployeeModelCommand+5L      &   System.Windows.Controls.DataGrid  5M   
   $��1��5N      $��2��5O      $��
10,10,10,0q�5P      $	��Top=�5Q         AutoGenerateColumns$ False��5R         CanUserAddRows$ False��5S      ��5T      �� *FilteredEmployees+ �� SelectedItem 5U      �� *SelectedEmployee+   Columns 5V      0  *System.Windows.Controls.DataGridTextColumn  5W      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 40 5X      
   Header$
 Id��5Z      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5Y      �� *Id+5Z        5[      $		 200 5\      $

 Name��5^       5]      �� *Name+5^        5_      $		 400 5`      $
 Email��5b       5a      �� *Email+5b        5c      $		 100 5d      $
 Address��5f       5e      �� *	Address+5f        5g      $		 200 5h      $
 Contact��5j       5i      �� *	Contact+5j      4  .System.Windows.Controls.DataGridTemplateColumn  5k      $
	 Auto 6)      CellTemplate 5l      �� 5m      .R�5n      �� $ 
Horizontal=�6)   .+�5o   "   �� $��4q�5p   %   $
��10,5q�5q   %   
��� � �
��� � �$
��Edit��5v   %   
���������5t   %   �� *!DataContext.EditEmployeeCommand+ �� RelativeSource ��  �� AncestorType8   2EmployeeTaskAssignmentSystem.View.EmployeePageView"  ��5u   %   �� 5w   %   �� 5x   "   $��4q�5y   %   $
��10,5q�5z   %   
���  ��
���  ��$��Delete��5   %   
���������5}   %   �� *DataContext.DeleteButton+ �� "  ��5~   %   �� 5�   %   5�      5�      5�      5�      5�      5�      