   M S B A M L   `   `   `  ����W  SEmployeeTaskAssignmentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:EmployeeTaskAssignmentSystem.View!EmployeeTaskAssignmentSystem.View  5      _4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel&EmployeeTaskAssignmentSystem.ViewModel  5      4    .EmployeeTaskAssignmentSystem.View.TaskPageView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:EmployeeTaskAssignmentSystem.View     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Cvm4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel     5        N� Title$  TaskPageView��5	       � DataContext 5      >   8EmployeeTaskAssignmentSystem.ViewModel.TaskPageViewModel  5   
   .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�59   
   �� $��0��6    �� Orientation$ Vertical=�6%   .+�5:      �� $��10,0,0,0q�5;      $��Bottom=�5<      $��Search Task by Email��5=      $��Roboto)�5>      $��14(�5?      $��SemiBold"�5@      �� 5A      $��0��5B      $	��200��5C      $��30��5D      $��10,0,0,0q�5E      $
��Left=�5F      $��Bottom=�5G      ��5H      �� *AssignedToSearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5I      �� 5J   
   $��1��5K      $��
10,20,10,0q�5L      $��Add New Task��5N         CustomButtonStyle#��[  5O      ��5M      �� *OpenTaskModalCommand+5O      &   System.Windows.Controls.DataGrid  5�   
   $��1��5�      $��2��5�      $��10q�5�      $	��Top=�5�         AutoGenerateColumns$ False��5�         CanUserAddRows$ False��5�      ��5�      �� *FilteredTasks+ �� SelectedItem 5�      �� *SelectedTask+	   Columns	 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 40 5�         Header$ Id��5�      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�      �� *Id+5�        5�      $	
 100 5�      $ Title��5�       5�      �� *Title+5�        5�      $	
 300 5�      $ Description��5�       5�      �� *Description+5�        5�      $	
 120 5�      $ 
Created On��5�       5�      �� *	CreatedOn+ �� StringFormat$ yyyy-MM-dd HH:mm��5�        5�      $	
 120 5�      $ 
Updated On��5�       5�      �� *	UpdatedOn+$ yyyy-MM-dd HH:mm��5�        5�      $	
 100 5�      $ Status��5�       5�      �� *Status+5�        5�      $	
 200 5�      $ 
AssignedTo��5�       5�      �� *
AssignedTo+5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      $

 Auto 6)      CellTemplate 5�      �� 5�      .R�5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $��4q�5�   %   $
��10,5q�5�   %   
��� � �
��� � �$
��Edit��5�   %   
���������5�   %   �� *DataContext.EditTaskCommand+ �� RelativeSource ��  �� AncestorType4   .EmployeeTaskAssignmentSystem.View.TaskPageView"  ��5�   %   �� 5�   %   �� 5�   "   $��4q�5�   %   $
��10,5q�5�   %   
���  ��
���  ��$��Delete��5�   %   
���������5�   %   �� *DataContext.DeleteButton+ �� "  ��5�   %   �� 5�   %   5�      5�      5�      5�      5�      5�      