   M S B A M L   `   `   `  ����W  SEmployeeTaskAssignmentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel&EmployeeTaskAssignmentSystem.ViewModel  5      5    /EmployeeTaskAssignmentSystem.View.EditModalTask   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      J	viewmodel4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel     5        � Title$  	Edit Task��5      $	��400��5	      $	��400��5
       � Icon$ /Images/Bajra.jpeg��5       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5      .��5      � .+�5   
   � 
������� � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      .+�5      �� $��0��5      $��5q�5       �� Orientation$ 
Horizontal=�5      .+�5      �� $	��120��5      $
��Left=�5      $	��Top=�5       $��Title��5!      �� 5"      $	��200��5#      $��26��5$      $
��Left=�5%      $	��Top=�5&      ${�False��5'      ��5(      �� *TaskToEdit.Title+5*      �� 5.      $��1��5/      $��5q�50      $ 
Horizontal=�51      .+�52      �� $	��120��53      $
��Left=�54      $	��Top=�55      $��Description��56      �� 57      -   5        $��DescriptionRichTextBox��58      $	��200��59      $	��100��5:      $
��Left=�5;      $	��Top=�5<      ${�False��5=      . �5>      /� .T�5?      J� .*�6$   .*�5@      �� �6"   �� *TaskToEdit.Description+5A      5B      5C      5D      �� 5G      $��2��5H      $��5q�5I      $ 
Horizontal=�5J      .+�5K      �� $	��120��5L      $
��Left=�5M      $	��Top=�5N      $��Status��5O      �� 5Q      -   5        $��StatusComboBox��5R      $	��200��5S      $��26��5T      $
��Left=�5U      $	��Top=�5V       �� SelectedItem 5W      �� *SelectedStatus+��5X      �� 5Y       �� Path$ TaskStatusOptions�6"   5[      5i      �� 5j      $��3��5k      $��5q�5l      $ 
Horizontal=�5m      .+�5n      �� $	��120��5o      $
��Left=�5p      $	��Top=�5q      $��
Created On��5r      �� 5s      $	��200��5t      $��26��5u      $
��Left=�5v      $	��Top=�5w      ${�False��5x      ��5y      �� *TaskToEdit.CreatedOn+5z      �� 5{      $��4��5|      $��2��5}      $��2q�5~      $��Center=�5      $ 
Horizontal=�5�      .+�5�      �� $	��100��5�      $��40��5�      $
��10,0q�5�      $��Update��5�         CustomButtonStyle#��[  5�      ��5�      �� *UpdateButton+5�      5�      5�      5�      5�      