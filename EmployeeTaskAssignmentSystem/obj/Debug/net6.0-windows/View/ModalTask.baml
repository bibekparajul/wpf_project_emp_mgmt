   M S B A M L   `   `   `  ����W  SEmployeeTaskAssignmentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel&EmployeeTaskAssignmentSystem.ViewModel  5      1    +EmployeeTaskAssignmentSystem.View.ModalTask   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal14clr-namespace:EmployeeTaskAssignmentSystem.ViewModel     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  Add Task��5      $	��400��5	      $	��400��5
       � Icon$ /Images/Bajra.jpeg��5       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � DataContext 5      >   8EmployeeTaskAssignmentSystem.ViewModel.TaskPageViewModel  5   
   .��5      � .+�5   
   � 
������� � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      .+�5      �� $��0��5      $��5q�5       �� Orientation$ 
Horizontal=�5       .+�5!      �� $	��120��5"      $
��Left=�5#      $	��Top=�5$      $��Title��5%      �� 5&      $	��200��5'      $��26��5(      $
��Left=�5)      $	��Top=�5*      ��5+      �� *
Task.Title+5-      �� 5A      $��1��5B      $��5q�5C      $ 
Horizontal=�5D      .+�5E      �� $	��120��5F      $
��Left=�5G      $	��Top=�5H      $��Description��5I      �� 5J      -   5        $��DescriptionRichTextBox��5K      $	��200��5L      $	��100��5M      $
��Left=�5N      $	��Top=�5O      . �5P      /� .T�5Q      J� .*�6$   .*�5R      �� �6"   �� *Task.Description+5S      5T      5U      5V      �� 5Y      $��2��5Z      $��5q�5[      $ 
Horizontal=�5\      .+�5]      �� $	��120��5^      $
��Left=�5_      $	��Top=�5`      $��Status��5a      $y�Hidden=�5b      �� 5d      -   5        $��StatusComboBox��5e      $	��200��5f      $��26��5g      $
��Left=�5h      $	��Top=�5i       �� Text$ Pending��5l      $y�Hidden=�5m       �� SelectedItem 5j      �� *SelectedStatus+��5n      �� 5o      	 �� Path$	 TaskStatusOptions�6"   5q      5s      �� 5u      $��3��5v      $��5q�5w      $ 
Horizontal=�5x      .+�5y      �� $	��120��5z      $
��Left=�5{      $	��Top=�5|      $��Assigned to��5}      �� 5      $	��200��5�      $��26��5�      $
��Left=�5�      $	��Top=�5�      ��5�      �� *EmployeeEmails+ 5�      �� *SelectedEmployee+
 �� Mode$
 TwoWay=� 5�      �� *Task.AssignedTo+5�      �� 5�      $��4��5�      $��2��5�      $��2q�5�      $��Center=�5�      $ 
Horizontal=�5�      .+�5�      �� $	��100��5�      $
��10,0q�5�      $��Create��5�         CustomButtonStyle#��[  5�      ��5�      �� *CreateButton+5�      5�      5�      5�      5�      