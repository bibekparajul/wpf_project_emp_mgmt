   M S B A M L   `   `   `  ����W  SEmployeeTaskAssignmentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:EmployeeTaskAssignmentSystemEmployeeTaskAssignmentSystem  5      _4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel&EmployeeTaskAssignmentSystem.ViewModel  5      -    'EmployeeTaskAssignmentSystem.MainWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      6local*clr-namespace:EmployeeTaskAssignmentSystem  5      Alocal14clr-namespace:EmployeeTaskAssignmentSystem.ViewModel  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	        � Title$%  Employee Task Assignment System��5
      $
��1382��5      $	��700��5      $
��1382��5      $	��700��5       � Icon$ /Images/BJT.png��5       � WindowState$ 	Maximized=�5       � DataContext 5      :   4EmployeeTaskAssignmentSystem.ViewModel.MainViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $	��200��5      $��10q�5      
�������$��1q�5       �� CornerRadius$ 5��5      ._�5       �� $��0��6   $��0,10,0,0q�6)   .+�5)      �� $��	0,20,0,20q�6   $��/Images/BJT.png��6+   � 5+      $��0��5,      $��10q�5-      $��Center=�5.      $��Center=�5/       � Orientation$ 
Horizontal=�50      .+�51      �� $��Center=�52      $��Welcome Admin!��53      $��Roboto)�54      $��20(�55      $��SemiBold"�56      57      �� 59      $��
10,30,10,0q�5:      $��0q�5;      $
��Home��5=      $��Roboto)�5>      $��20(�5?      
�������   CustomButtonStyle#��[  5A      ��5<      �� *HomeButtonCommand+5A      �� 5B      $��
10,30,10,0q�5C      $��0q�5D      $��Employee��5F      $��Roboto)�5G      $��20(�5H      
�������#��[  5J      ��5E      �� *EmployeeButtonCommand+5J      �� 5K      $��
10,30,10,0q�5L      $��0q�5M      $
��Task��5O      $��Roboto)�5P      $��20(�5Q      
�������#��[  5S      ��5N      �� *TaskButtonCommand+5S      �� 5T      $��35��5U      $��0,40,0,0q�5V      
������� � Cursor$
 Hand��5Z      ��5X      �� *LogoutCommand+��5Y      ��  �� RelativeSource �� 	 �� AncestorType"	 �.��5[      "  FontAwesome.WPF.ImageAwesome  $��30��5\      $��30��5]      
   Icon$
 SignOut=�5^       � ToolTip 5_      _� 5`      $��Logout��6&   5b      5c      5d      5e       � 5g   
   -   5          �Name$ 	MainFrame��5h      $��1��5i      $��10q�5j        � NavigationUIVisibility$ Hidden=�5l      ��5k      �� *CurrentPage+5l      5n      5o      