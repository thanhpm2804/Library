   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5          Library.BorrowRecordsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Library     5        N� Title$  BorrowRecordsPage��5	       � 	Resources 5
      )   #Library.DateOnlyToDateTimeConverter   DateOnlyToDateTimeConverter��%   &	          5   
   6,   5      .��5      � ��5   
   �� 5       �� ImageSource$ /a1.jpg��6   .+�5   
   �� -   5         ��Name$ lbBookTitle_Copy��5      
���   �$��DemiBold"�6=   $��Center=�6S   $��20(�5      $��Borrow records��6   ]� 5   
   $	��Top=�6   $��0,50,0,0q�6,   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $��4* �6$   �� 5      $��* �6$   .+�5      ��  �� Orientation$ Vertical=�6   $��Center=�5      $	��610��6   ��5      �� 5       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5       �  � Color$ Black��6+   � 5!      $ White��6+   	 � Offset$	 0.229Q�69   5"      .+�5$      �� -   5        $��lbBookTitle��5$      ���	#FF00EDFF$��DemiBold"�6F   $��20(�5%      $��Borrow Information��6   $��Center=�6-   �� 5&      -   5        $��lbBookID��5&      $��Book ID��6,   �� 5'      -   5        $��	txtBookID��5'      $��Stretch=�6/   $��25��5(      
 �� 
IsReadOnly$

 True��5,      ��5)      ��  �� Path$ Book.BookId� �� Mode$ OneWay=� � DataContext 5*      ��  �� ElementName$ lvBook��$ SelectedItem�5,      �� 5-      -   5        $��lbTitle��5-      $��Title��6+   �� 5.      -   5        $��txtTitle��5.      $��Stretch=�6.   $

 True��6L   $��25��5/      ��50      �� $ 
Book.Title�$ OneWay=� 51      �� $ lvBook��$ SelectedItem��� 53      -   5        $��lbAuthor��53      $��Author��6,   �� 54      -   5        $��	txtAuthor��54      $��Stretch=�6/   $

 True��6M   $��25��55      ��56      �� $ Book.Author�$ OneWay=� 57      �� $ lvBook��$ SelectedItem��� 59      -	   5        $��lbReturnDate��59      $��Return Date��60   ���	#FFF0B4B46F   (  "System.Windows.Controls.DatePicker  5:      -
   5        $��
txtDueDate��5:   !      SelectedDateFormat$ Short=�5;         SelectedDate 5<      �� $ DueDate�$ OneWay=� �� 	Converter# [   5>      �� $ lvBook��$ SelectedItem�5@      5A      �� 5C      $ 
Horizontal=�6   $
��Left=�5D      $��
30,234,0,5q�6   $��2��61   .+�5E      �� -   5         ��Name$ 	btnReturn��5E      $��10q�60   $��80��6<   $��Return��6G   ���	#FFE3D8705F      �� 5G      -   5        $ 	btnChange��5G      $��10q�60   $��80��6<   $��Change��6G   ���	#FF85ED775H      5I      �� 5K      -   5        $��lvBook��5K   (   $��2��6   $	��610��66   $
��Auto��6B    �� View 5L      �� 5M      .P�5N      �� $��Book ID��6-    �� Width$	 100��6>    �� DisplayMemberBinding 5O      �� $ Book.BookId��� 5P      $��Title��6-   $	 200��6<    5Q      �� $ 
Book.Title��� 5R      $��Author��6-   $	 200��6=    5S   -   �� $ Book.Author��� 5T      $��DueDate��6-   $	 100��6>    5U      �� $ DueDate�5V      5X      5Z      5[      5\      5]      