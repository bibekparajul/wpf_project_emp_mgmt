   M S B A M L   `   `   `  ����W  SEmployeeTaskAssignmentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:EmployeeTaskAssignmentSystem.View!EmployeeTaskAssignmentSystem.View  5      _4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel&EmployeeTaskAssignmentSystem.ViewModel  5      B    <EmployeeTaskAssignmentSystem.View.EmployeeDashBoardLoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:EmployeeTaskAssignmentSystem.View     5      Glocal14clr-namespace:EmployeeTaskAssignmentSystem.ViewModel     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  Employee Login��5	      $	��800��5
      $	��450��5      $	��800��5      $	��450��5       � Icon$ /Images/BJT.png��5       � 
ResizeMode$ CanMinimize=�5       � WindowStartupLocation$ CenterScreen=�5       � DataContext 5      L   FEmployeeTaskAssignmentSystem.ViewModel.EmployeeDashBoardLoginViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� 
�������$��1q�5       �� CornerRadius$ 5��5      ._�5       �� $��0��6   $��10q�6)   .+�5!      �� $��10,20q�5"      $
��ETAS��5#      $��roboto)�5$      $��28(�5%      $
��Bold"�5&      ���#BE263B   CustomLabelStyle#��[  5(      �� 5)      $
��10,5q�5*      $��Task Id��5+      $��20(�5,      #��[  5-      �� 5.      $��	10,0,10,0q�5/      
�������$	��1.5q�51      $ 3��52      ._�53      ��   LoginTextBoxStyle#��[ 6   ��6I   �� *EmpId+54      �� 55      $
��10,5q�56      $��Email��57      $��20(�58      #��[  59      �� 5:      $��	10,0,10,0q�5;      
�������$	��1.5q�5=      $ 3��5>      ._�5?      �� #��[ 6   ��6I   �� *	UserEmail+5B      �� 5C      $��Proceed to view task��5E        CustomButtonStyle#��[ 5F      ��5D      �� *RetrieveTaskCommand+5F      �� 5G      $	��223��5H      $��30��5I      $��5,5,15,0q�5J      $��Right=�5K      
�������
�������$$��Click here to Proceed as Admin��5O      $��Roboto)�5P      $��14(�5Q      $��SemiBold"�5R      
����  ���5N      �� *NavigateToLoginViewCommand+5S      5T      5U      �� 5V   
   $��1��5W      $	��100��5X      $	��100��5Y      $��1q�5Z      $��Right=�5[      $	��top=�5\      $��\Images\BJT.png��5]      �� 5_   
   -   5         ��Name$ imageControl��5`      $��1��5a      $��50q�5b      $��Center=�5c      $��\Images\ll.png��5d      5f      5g      