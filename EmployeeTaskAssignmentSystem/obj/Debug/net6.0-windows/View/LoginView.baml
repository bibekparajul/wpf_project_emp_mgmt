   M S B A M L   `   `   `  ����W  SEmployeeTaskAssignmentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:EmployeeTaskAssignmentSystem.CustomControls+EmployeeTaskAssignmentSystem.CustomControls  5      _4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel&EmployeeTaskAssignmentSystem.ViewModel  5      [2clr-namespace:EmployeeTaskAssignmentSystem.Utility$EmployeeTaskAssignmentSystem.Utility  5	      1    +EmployeeTaskAssignmentSystem.View.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Tcustomcontrols9clr-namespace:EmployeeTaskAssignmentSystem.CustomControls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal14clr-namespace:EmployeeTaskAssignmentSystem.ViewModel     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Gpassword2clr-namespace:EmployeeTaskAssignmentSystem.Utility     5	        � Title$  Admin Login��5
      $	��800��5      $	��450��5      $	��800��5      $	��450��5       � Icon$ /Images/BJT.png��5       � 
ResizeMode$ CanMinimize=�5       � WindowStartupLocation$ CenterScreen=�5       � DataContext 5      A   ;EmployeeTaskAssignmentSystem.ViewModel.LoginWindowViewModel  5   
    � 	Resources 5         PasswordBoxStyle �� 
TargetType �� Property �� Value��%�  &	        �� 5   
   " G�6)   .�5      ��  � ��$ 28��6'   �� 5       � ��$ 0,5,0,0q�6'   �� 5       � ��$ 10,0,0,0q�6(   �� 5       � ��$ Center=�62   �� 5       � ��$ 0,0,0,0q�60   �� 5       � ��$ Roboto)�6+   �� 5       � ��$ 15(�6)   �� 5        � ��$ Medium"�6+   �� 5!       � ��
 �   �6+   5"      5$      .��5&      � 	 � ColumnDefinitions	 5'   
   �� 5(      �� 5)      .+�5,   
   �� 
�������$��1q�5.      
 �� CornerRadius$
 5��5/      ._�50      �� $��0��6   $��10q�6)   .+�51      �� $��10,20q�52      $
��ETAS��53      $��roboto)�54      $��28(�55      $
��Bold"�56      ���#BE263B  CustomLabelStyle#��[ 58      �� 59      $
��10,5q�5:      $��Email��5;      $��20(�5<      #��[ 5=      �� 5>      $��	10,0,10,0q�5?      
�������$	��1.5q�5A      $
 3��5B      ._�5C      ��   LoginTextBoxStyle#��[ 6   ��6I   �� *
User.Email+5D      �� 5E      $
��10,5q�5F      $��Password��5G      $��20(�5H      #��[ 5I      �� 5J      $��	10,0,10,0q�5K      
�������$	��1.5q�5M      $
 3��5N      ._�5X      G� #��[  6�   ?   9EmployeeTaskAssignmentSystem.Utility.PasswordBoxAssistant   BoundPassword 6"   �� *User.Password+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5Z      �� 5[      $��Login��5]        CustomButtonStyle#��[ 5^      ��5\      �� *LoginButtonCommand+5^      �� 5_      $	��223��5`      $��30��5a      $��5,5,15,0q�5b      $��Right=�5c      
�������
�������$'��!Click here to Proceed As Employee��5g      $��Roboto)�5h      $��14(�5i      $��SemiBold"�5j      
����  ���5f      �� *$"NavigateToEmployeeDashboardCommand+5k      5l      5m      �� 5n   
   $��1��5o      $	��100��5p      $	��100��5q      $��1q�5r      $��Right=�5s      $	��top=�5t      $��\Images\BJT.png��5u      �� 5v   
   -   5         ��Name$ imageControl��5w      $��1��5x      $��50q�5y      $��Center=�5z      $��\Images\ll.png��5{      5}      5~      