   M S B A M L   `   `   `  ����W  SEmployeeTaskAssignmentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:EmployeeTaskAssignmentSystem.View!EmployeeTaskAssignmentSystem.View  5      _4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel&EmployeeTaskAssignmentSystem.ViewModel  5      W0clr-namespace:EmployeeTaskAssignmentSystem.Model"EmployeeTaskAssignmentSystem.Model  5      5    /EmployeeTaskAssignmentSystem.View.ModalEmployee   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:EmployeeTaskAssignmentSystem.View     5      Glocal14clr-namespace:EmployeeTaskAssignmentSystem.ViewModel     5      Dlocal110clr-namespace:EmployeeTaskAssignmentSystem.Model     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	        � Title$  Add New Employee��5
      $	��400��5      $	��300��5       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � DataContext 5      B   <EmployeeTaskAssignmentSystem.ViewModel.EmployeePageViewModel  5   
   .��5      � .+�5   
   � 
������� � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      .+�5      �� $��10q�6   .+�5      �� $��0��5      $��5q�5        �� Orientation$ 
Horizontal=�5!      .+�5"      �� $��60��5#      $
��Left=�5$      $	��Top=�5%      $
��Name��5&      �� 5'      -   5        $��NameTextBox��5(      $	��200��5)      $��26��5*      $
��Left=�5+      $	��Top=�5,      ��5-      �� *Employee.Name+5/      �� 51      $��1��52      $��5q�53      $ 
Horizontal=�54      .+�55      �� $��60��56      $
��Left=�57      $	��Top=�58      $��Email��59      �� 5;      -   5        $��EmailTextBox��5<      $	��200��5=      $��26��5>      $
��Left=�5?      $	��Top=�5@      ��5A      �� *Employee.Email+5B      �� 5D      $��2��5E      $��5q�5F      $ 
Horizontal=�5G      .+�5H      �� $��60��5I      $
��Left=�5J      $	��Top=�5K      $��Address��5L      �� 5N      $	��200��5O      $��26��5P      $
��Left=�5Q      $	��Top=�5R      ��5S      �� *Employee.Address+5T      �� 5V      $��3��5W      $��5q�5X      $ 
Horizontal=�5Y      .+�5Z      �� $��60��5[      $
��Left=�5\      $	��Top=�5]      $��Contact��5^      �� 5`      $	��200��5a      $��26��5b      $
��Left=�5c      $	��Top=�5d      ��5e      �� *Employee.Contact+5f      5g      �� 5i      $��4��5j      $��2��5k      $��10q�5l      $��Center=�5m      $ 
Horizontal=�5n      .+�5o      �� $	��100��5p      $
��10,0q�5q      $��Create��5s         CustomButtonStyle#��[  5t      ��5r      �� *CreateButton+5t      �� 5u      $	��100��5v      $
��10,0q�5w      $��Cancel��5y      #��[  5z      ��5x      �� *CancelButtonCommand+5z      5}      5~      5      5�      