   M S B A M L   `   `   `  ����W  SEmployeeTaskAssignmentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:EmployeeTaskAssignmentSystem.View!EmployeeTaskAssignmentSystem.View  5      _4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel&EmployeeTaskAssignmentSystem.ViewModel  5      B    <EmployeeTaskAssignmentSystem.View.NotStartedEmployeeTaskPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:EmployeeTaskAssignmentSystem.View     5      Glocal14clr-namespace:EmployeeTaskAssignmentSystem.ViewModel     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$   NotStartedEmployeeTaskPage��5	       � DataContext 5      L   FEmployeeTaskAssignmentSystem.ViewModel.EmployeeDashBoardLoginViewModel  5   
   .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� -   5        $��EmployeeItemList��5      $��1��5      $��2��5      $��1��5      $��2��5       $
��1080��5!      $��	2,10,0,10q�5"      $��Stretch=�5#      $��Stretch=�5$      ��5%      �� *FilteredTasks+ �� SelectedItem 5&      �� *SelectedTask+��5'      �� 5(      .R�5)      � $
��1000��6     � Orientation$ 
Horizontal=�6-   5*      ��5,      �� 5-      .R�5.      �� $	��300��5/      $��8q�50       �� Padding$ 10q�51      
�������
�������$��1q�54       �� CornerRadius$ 5��55      ._�56      � .+�57      �� .+�58   "   ��  �� Orientation$ Vertical=�6-   .+�59   &   �� $
��left=�5:   )   $��16(�5;   )   $
��Bold"�5<   )   ���#BE263B$
��Wrap=�5?   )   ��5>   )   �� *Title+5?   )   �� 5A   &   $��0,5,0,10q�5B   )   $
��left=�5C   )   $
��Bold"�5D   )   ��5E   )   �� *	CreatedOn+	 �� StringFormat$	 
yyyy-MM-dd���� 5F   &   $��2��5G   )   
�������$��1q�5I   )   5J   #   �� 5K   "   $��	5,15,0,10q�5L   %   $��SemiBold"�5M   %   $
��Wrap=�5O   %   ��5N   %   �� *Description+5O   %   �� 5P   "   $ 
Horizontal=�6-   .+�5Q   &   �� $��Status:��6,   $
��Bold"�6>   �� 5R   &   $��5,5,0,10q�5S   )   $��SemiBold"�5T   )   ���#BE263B��5V   )   �� *Status+5W   #   �� 5Y   "   $ 
Horizontal=�6-   .+�5Z   &   �� $��Updated On:��6,   $
��Bold"�6B   �� 5[   &   $��5,5,0,10q�5\   )   $��SemiBold"�5]   )   ��5^   )   �� *	UpdatedOn+5_   #   5a      5b      5c      5d      5f      5g      5h      