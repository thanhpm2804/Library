   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5      U QSystem.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 5
          Library.BorrowPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Library     5      ?System,clr-namespace:System;assembly=System.Runtime     5
        N� Title$  
BorrowPage��5	       � 	Resources 5         GradientStopOffset1��%#   &	        X�5   
   0Q�67   5      .��5      � ��5   
   �� 5       �� ImageSource$ /a1.jpg��6   .+�5   
   �� -   5         ��Name$ lbBookTitle_Copy��5      
���   �$��DemiBold"�6=   $��Center=�6S   $��20(�5      $��Borrow book��6   $��
0,-10,0,10q�6)   ]� 5   
   $	��Top=�6   $��0,50,0,0q�6,   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $��4* �6$   �� 5      $��* �6$   .+�5      ��  �� Orientation$ Vertical=�6   $��Center=�5      $	��610��6   ��5       �� 5!       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5"      �  � Offset# �   6+   	 � Color$	 Black��6Z   � 5#      $	 White��6+   $ 1Q�69   � 5$      $	 	#FFCFCFCF��6+   $ 0.208Q�6=   5%      .+�5'      �� -   5        $��lbBookTitle��5'      ���	#FF9FE5CC$��DemiBold"�6F   $��20(�5(      $��Book Information��6   $��Center=�6+   �� 5)      -   5        $��lbBookID��5)      $��Book ID��6,   $	��610��6>   �� 5*      -   5        $��	txtBookID��5*      $��Stretch=�6/   $��25��5+      
 �� 
IsReadOnly$

 True��5/      ��5,      ��  �� Path$ BookId� �� Mode$ OneWay=� � DataContext 5-      ��  �� ElementName$ lvBook��$ SelectedItem�5/      �� 50      -   5        $��lbTitle��50      $��Title��6+   �� 51      -   5        $��txtTitle��51      $��Stretch=�6.   $

 True��6L   $��25��52      ��53      �� $ Title�$ OneWay=� 54      �� $ lvBook��$ SelectedItem��� 56      -   5        $��lbAuthor��56      $��Author��6,   �� 57      -   5        $��	txtAuthor��57      $��Stretch=�6/   $

 True��6M   $��25��58      ��59      �� $ Author�$ OneWay=� 5:      �� $ lvBook��$ SelectedItem��� 5<      -	   5        $��lbReturnDate��5<      $��Return Date��60   ���	#FFE9C0C06F   (  "System.Windows.Controls.DatePicker  5=      -
   5        $��
txtDueDate��5=   !      SelectedDateFormat$ Short=�5>      5@      5A      �� 5C      $ 
Horizontal=�6   $
��Left=�5D      $��
30,234,0,5q�6   $��2��61   .+�5E      �� -   5         ��Name$ 	btnBorrow��5E      $��10q�60   $��80��6<   $��Borrow��6G   ���	#FF8DEE9D5F      �� 5G      -   5        $ 
btnReserve��5G      $��10q�61   $��80��6=   $��Reserve��6H   ���	#FF73E8DB5H      5I      �� 5K      -   5        $��lvBook��5K   (   $��2��6   $	��610��66   $
��Auto��6B    �� View 5L      �� 5M      .P�5N      �� $��Book ID��6-    �� Width$	 100��6>    �� DisplayMemberBinding 5O      �� $ BookId��� 5P      $��Title��6-   $	 200��6<    5Q      �� $ Title��� 5R      $��Author��6-   $	 200��6=    5S   -   �� $ Author�5T      5V      5X      5Y      5Z      5[      