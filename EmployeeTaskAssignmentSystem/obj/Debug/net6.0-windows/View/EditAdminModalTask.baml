   M S B A M L   `   `   `  ����W  SEmployeeTaskAssignmentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:EmployeeTaskAssignmentSystem.View!EmployeeTaskAssignmentSystem.View  5      _4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel&EmployeeTaskAssignmentSystem.ViewModel  5      :    4EmployeeTaskAssignmentSystem.View.EditAdminModalTask   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:EmployeeTaskAssignmentSystem.View     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      J	viewmodel4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel     5        � Title$  	Edit Task��5	      $	��400��5
      $	��400��5       � Icon$ /Images/Bajra.jpeg��5       � WindowStartupLocation$ CenterScreen=�5       � DataContext 5      C   =EmployeeTaskAssignmentSystem.ViewModel.EditAdminTaskViewModel  5   
   .��5      � .+�5   
   � 
������� � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      .+�5      �� $��0��5      $��5q�5       �� Orientation$ 
Horizontal=�5      .+�5      �� $	��120��5       $
��Left=�5!      $	��Top=�5"      $��Title��5#      �� 5$      $	��200��5%      $��26��5&      $
��Left=�5'      $	��Top=�5(      ��5)      �� *
Task.Title+5+      �� 5-      $��1��5.      $��5q�5/      $ 
Horizontal=�50      .+�51      �� $	��120��52      $
��Left=�53      $	��Top=�54      $��Description��55      �� 56      -   5        $��DescriptionRichTextBox��57      $	��200��58      $	��100��59      $
��Left=�5:      $	��Top=�5;      . �5<      /� .T�5=      J� .*�6$   .*�5>      �� �6"   �� *Task.Description+5?      5@      5A      5B      �� 5E      $��2��5F      $��5q�5G      $ 
Horizontal=�5H      .+�5I      �� $	��120��5J      $
��Left=�5K      $	��Top=�5L      $��Status��5M      $y�Hidden=�5N      �� 5O      -   5        $��StatusComboBox��5P      $	��200��5Q      $��26��5R      $
��Left=�5S      $	��Top=�5T      $y�Hidden=�5V       �� SelectedItem 5U      �� *
TaskStatus+��5W      �� 5X       �� Path$ TaskStatusOptions�6"   5Z      5\      �� 5^      $��3��5_      $��5q�5`      $ 
Horizontal=�5a      .+�5b      �� $	��120��5c      $
��Left=�5d      $	��Top=�5e      $��Assigned to��5f      �� 5h      $	��200��5i      $��26��5j      $
��Left=�5k      $	��Top=�5l      ��5m      �� *EmployeeEmails+ 5n      �� *SelectedEmployee+ �� Mode$ TwoWay=�	 �� Text	 5o      �� *Task.AssignedTo+5p      �� 5r      $��4��5s      $��2��5t      $��2q�5u      $��Center=�5v      $ 
Horizontal=�5w      .+�5x      �� $	��100��5y      $
��10,0q�5z      $��Update��5|         CustomButtonStyle#��[  5}      ��5{      �� *UpdateButton+5}      5      5�      5�      5�      