   M S B A M L   `   `   `  ����W  SEmployeeTaskAssignmentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:EmployeeTaskAssignmentSystem.View!EmployeeTaskAssignmentSystem.View  5      _4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel&EmployeeTaskAssignmentSystem.ViewModel  5
      8    2EmployeeTaskAssignmentSystem.View.EmployeeHomePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      ;local/clr-namespace:EmployeeTaskAssignmentSystem.View  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      _ [Syncfusion.SfChart.WPF, Version=22.2.12.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c892
syncfusion!http://schemas.syncfusion.com/wpf  5	      =vm4clr-namespace:EmployeeTaskAssignmentSystem.ViewModel  5
        N� Title$  EmployeeHomePage��5       � DataContext 5      L   FEmployeeTaskAssignmentSystem.ViewModel.EmployeeDashBoardLoginViewModel  5   
   .��5      � $��0q�6   
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      .+�5   
   � $��	10,10,0,5q�6   .+�5      �� 
������ 
������ ��5      �� *HomeButtonCommand+.��5      �� $	��200��5       $��10q�5!      
�������$��1q�5#       �� CornerRadius$ 5��5$      ._�5%      �� $��10q�6!    �� Orientation$ Vertical=�6-   .+�5&      "  FontAwesome.WPF.ImageAwesome  -   5        $
��Task��5'      $��80��5(      $��80��5)      $��Center=�5*      $��Center=�5+         Icon$ Tasks=�5,      �� 5-      $��Center=�5.      $��Roboto)�5/      $��20(�50      $��SemiBold"�51      $��Total Tasks��52      �� 53      $��Center=�54      $��24(�55      $
��Bold"�56      ��57      �� *
TotalTasks+58      59      5:      �� 5;      
������ 
������ ��5>      �� *NavigateToPendingTasksCommand+.��5?      �� $	��200��5@      $��10q�5A      
�������$��1q�5C      $ 5��5D      ._�5E      �� $��10q�6!   $ Vertical=�6-   .+�5F        $��80��5G      $��80��5H      $��Center=�5I      $��Center=�5J      $ CircleOutlineNotch=�5K         Spin$
 True��5L      �� 5M      $��Center=�5N      $��Roboto)�5O      $��20(�5P      $��SemiBold"�5Q      $��Pending Task��5R      �� 5S      $��Center=�5T      $��24(�5U      $
��Bold"�5V      ��5W      �� *PendingTasks+ �� Mode$ OneWay=�5X      5Y      5Z      �� 5[      
������ 
������ ��5^      �� *NavigateDoneTasksCommand+.��5_      �� $	��200��5`      $��10q�5a      
�������$��1q�5c      $ 5��5d      ._�5e      �� $��10q�6!   $ Vertical=�6-   .+�5f        -   5        $��TaskCompleted��5g      $��80��5h      $��80��5i      $��Center=�5j      $��Center=�5k      $ Check=�5l      �� 5m      $��Center=�5n      $��Roboto)�5o      $��20(�5p      $��SemiBold"�5q      $��Task Completed��5r      �� 5s      $��Center=�5t      $��24(�5u      $
��Bold"�5v      ��5w      �� *	DoneTasks+$ OneWay=�5x      5y      5z      �� 5{      
������ 
������ ��5~      �� * NavigateInProgressTasksCommand+.��5      �� $	��200��5�      $��10q�5�      
�������$��1q�5�      $ 5��5�      ._�5�      �� $��10q�6!   $ Vertical=�6-   .+�5�        -   5        $��TaskInprogress��5�      $��80��5�      $��80��5�      $��Center=�5�      $��Center=�5�      $ Spinner=�5�      �� 5�      $��Center=�5�      $��Roboto)�5�      $��20(�5�      $��SemiBold"�5�      $��Task Inprogress��5�      �� 5�      $��Center=�5�      $��24(�5�      $
��Bold"�5�      ��5�      �� *InProgressTasks+5�      5�      5�      5�      �� 5�      
������ 
������ ��5�      �� * NavigateNotStartedTasksCommand+.��5�      �� $	��200��5�      $��10q�5�      
�������$��1q�5�      $ 5��5�      ._�5�      �� $��10q�6!   $ Vertical=�6-   .+�5�        -   5        $��TaskNotStarted��5�      $��80��5�      $��80��5�      $��Center=�5�      $��Center=�5�      $ Spinner=�5�      �� 5�      $��Center=�5�      $��Roboto)�5�      $��20(�5�      $��SemiBold"�5�      $��Task Not Started��5�      �� 5�      $��Center=�5�      $��24(�5�      $
��Bold"�5�      ��5�      �� *NotStartedTasks+5�      5�      5�      5�      5�      '  !Syncfusion.UI.Xaml.Charts.SfChart  5�   
   $��2��6      PrimaryAxis 5�      ,  &Syncfusion.UI.Xaml.Charts.CategoryAxis  5�      )  #Syncfusion.UI.Xaml.Charts.ChartAxis	   Header$	 Task Status��6*   
   SecondaryAxis
 5�      -  'Syncfusion.UI.Xaml.Charts.NumericalAxis  5�      $	 
Task Count��6+      Interval 26?      Series. 5�      )  #Syncfusion.UI.Xaml.Charts.BarSeries  /  )Syncfusion.UI.Xaml.Charts.ChartSeriesBase   Label$ 
Task Count��5�         ShowTooltip$
 True��5�         XBindingPath$ Label��5�      ,	  &Syncfusion.UI.Xaml.Charts.XyDataSeries 	  YBindingPath$ Value��5�         ItemsSource 5�      �� *	ChartData+5�      5�      5�      5�      