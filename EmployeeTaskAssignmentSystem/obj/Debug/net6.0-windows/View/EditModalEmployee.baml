   M S B A M L   `   `   `  ����W  SEmployeeTaskAssignmentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:EmployeeTaskAssignmentSystem.View!EmployeeTaskAssignmentSystem.View  5      _4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel&EmployeeTaskAssignmentSystem.ViewModel  5      9    3EmployeeTaskAssignmentSystem.View.EditModalEmployee   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:EmployeeTaskAssignmentSystem.View     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      J	viewmodel4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel     5        � Title$  Edit Employee��5	      $	��400��5
      $	��300��5       � Icon$ /Images/Bajra.jpeg��5       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � DataContext 5      B   <EmployeeTaskAssignmentSystem.ViewModel.EditEmployeeViewModel  5   
   .��5      � .+�5   
   � 
������� � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      .+�5      �� $��10q�6   .+�5      �� $��0��5      $��5q�5       �� Orientation$ 
Horizontal=�5       .+�5!      �� $��60��5"      $
��Left=�5#      $	��Top=�5$      $
��Name��5%      �� 5&      -   5        $��NameTextBox��5'      $	��200��5(      $��26��5)      $
��Left=�5*      $	��Top=�5+      ��5,      �� *Employee.Name+5.      �� 50      $��1��51      $��5q�52      $ 
Horizontal=�53      .+�54      �� $��60��55      $
��Left=�56      $	��Top=�57      $��Email��58      �� 5:      -   5        $��EmailTextBox��5;      $	��200��5<      $��26��5=      $
��Left=�5>      $	��Top=�5?      ��5@      �� *Employee.Email+5A      �� 5C      $��2��5D      $��5q�5E      $ 
Horizontal=�5F      .+�5G      �� $��60��5H      $
��Left=�5I      $	��Top=�5J      $��Address��5K      �� 5M      $	��200��5N      $��26��5O      $
��Left=�5P      $	��Top=�5Q      ��5R      �� *Employee.Address+5S      �� 5U      $��3��5V      $��5q�5W      $ 
Horizontal=�5X      .+�5Y      �� $��60��5Z      $
��Left=�5[      $	��Top=�5\      $��Contact��5]      �� 5_      $	��200��5`      $��26��5a      $
��Left=�5b      $	��Top=�5c      ��5d      �� *Employee.Contact+5e      5f      �� 5h      $��4��5i      $��2��5j      $��10q�5k      $��Center=�5l      $ 
Horizontal=�5m      .+�5o      �� $	��100��5p      $
��10,0q�5q      $��Update��5s         CustomButtonStyle#��[  5t      ��5r      �� *UpdateButton+5t      5w      5x      5y      5z      