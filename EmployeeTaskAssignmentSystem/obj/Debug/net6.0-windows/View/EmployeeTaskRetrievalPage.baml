   M S B A M L   `   `   `  ����W  SEmployeeTaskAssignmentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:EmployeeTaskAssignmentSystem.View!EmployeeTaskAssignmentSystem.View  5      _4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel&EmployeeTaskAssignmentSystem.ViewModel  5      A    ;EmployeeTaskAssignmentSystem.View.EmployeeTaskRetrievalPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      ;local/clr-namespace:EmployeeTaskAssignmentSystem.View  5      Alocal14clr-namespace:EmployeeTaskAssignmentSystem.ViewModel  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	        N� Title$  EmployeeTaskRetrievalPage��5
       � DataContext 5      L   FEmployeeTaskAssignmentSystem.ViewModel.EmployeeDashBoardLoginViewModel  5   
   .��5      � 
������  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6   $��1��6"   .+�5      �� $��Search task��6      CustomLabelStyle#��[  6*   �� 5      $	��400��5      $��40��5      $��2,5,0,0q�5       $
��Left=�5!      $��Center=�5"      $��14(�5#      ��5$      �� *SearchKeyword+ �� UpdateSourceTrigger$ PropertyChanged=�5%      �� 5&   
   -   5        $��EmployeeItemList��5'      $��1��5(      $��2��5)      $��1��5*      $��2��5+      $
��1080��5,      $��	2,10,0,10q�5-      $��Stretch=�5.      $��Stretch=�5/      ��50      �� *FilteredTasks+ �� SelectedItem 51      �� *SelectedTask+��52      �� 53      .R�54      � $
��1000��6     � Orientation$ 
Horizontal=�6-   55      ��57      �� 58      .R�59      �� $	��300��5:      $��8q�5;       �� Padding$ 10q�5<      
�������
�������$��1q�5?       �� CornerRadius$ 5��5@      ._�5A      � .+�5B      �� .+�5C   "   �� 	 �� Orientation$	 Vertical=�6-   .+�5D   &   �� $
��left=�5E   )   $��16(�5F   )   $
��Bold"�5G   )   ���#BE263B$
��Wrap=�5J   )   ��5I   )   �� *Title+5J   )   �� 5L   &   $��0,5,0,10q�5M   )   $
��left=�5N   )   $
��Bold"�5O   )   ��5P   )   �� *	CreatedOn+
 �� StringFormat$
 
yyyy-MM-dd���� 5Q   &   $��2��5R   )   
�������$��1q�5T   )   5U   #   �� 5V   "   $��	5,15,0,10q�5W   %   $��SemiBold"�5X   %   $
��Wrap=�5Z   %   ��5Y   %   �� *Description+5Z   %   �� 5[   "   $	 
Horizontal=�6-   .+�5\   &   �� $��Status:��6,   $
��Bold"�6>   �� 5]   &   $��5,5,0,10q�5^   )   $��SemiBold"�5_   )   ���#BE263B��5a   )   �� *Status+5b   #   �� 5d   "   $	 
Horizontal=�6-   .+�5e   &   �� $��Updated On:��6,   $
��Bold"�6B   �� 5f   &   $��5,5,0,10q�5g   )   $��SemiBold"�5h   )   ��5i   )   �� *	UpdatedOn+5j   #   �� 5k   "   $
��10,5q�5l   %   $��Center=�5m   %   
��� � �$��Update Status��5q   %   $��14(�5r   %   
���������5o   %   �� *" DataContext.OpenEditModalCommand+ �� RelativeSource ��  �� AncestorTypeA   ;EmployeeTaskAssignmentSystem.View.EmployeeTaskRetrievalPage"  ��5p   %   �� 5s   %   5t      5u      5v      5w      5y      5z      5{      