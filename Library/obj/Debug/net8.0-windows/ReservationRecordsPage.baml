   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5      $    Library.ReservationRecordsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Library     5        N� Title$  ReservationRecordsPage��5	       � 	Resources 5
      )   #Library.DateOnlyToDateTimeConverter   DateOnlyToDateTimeConverter��%   &	          5   
   6,   5      .��5      � ��5   
   �� 5       �� ImageSource$ /a1.jpg��6   .+�5   
   �� -   5         ��Name$ lbBookTitle_Copy��5      
���   �$��DemiBold"�6=   $��Center=�6S   $��20(�5      $��Reservations records��6   ]� 5   
   $	��Top=�6   $��0,50,0,0q�6,   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $��4* �6$   �� 5      $��* �6$   .+�5      ��  �� Orientation$ Vertical=�6   $��Center=�5      $	��610��6   ��5      �� 5       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5       �  � Color$ Black��6+   � 5!      $ White��6+   	 � Offset$	 0.193Q�69   5"      .+�5$      �� -   5        $��lbBookTitle��5$      ���	#FF00FFF6$��DemiBold"�6F   $��20(�5%      $��Reservation Information��6   $��Center=�62   �� 5&      -   5        $��lbBookID��5&      $��Book ID��6,   �� 5'      -   5        $��	txtBookID��5'      $��Stretch=�6/   $��25��5(      
 �� 
IsReadOnly$

 True��5,      ��5)      ��  �� Path$ Book.BookId� �� Mode$ OneWay=� � DataContext 5*      ��  �� ElementName$ lvBook��$ SelectedItem�5,      �� 5-      -   5        $��lbTitle��5-      $��Title��6+   �� 5.      -   5        $��txtTitle��5.      $��Stretch=�6.   $

 True��6L   $��25��5/      ��50      �� $ 
Book.Title�$ OneWay=� 51      �� $ lvBook��$ SelectedItem��� 53      -   5        $��lbAuthor��53      $��Author��6,   �� 54      -   5        $��	txtAuthor��54      $��Stretch=�6/   $

 True��6M   $��25��55      ��56      �� $ Book.Author�$ OneWay=� 57      �� $ lvBook��$ SelectedItem��� 59      -	   5        $��lbReservedDate��59      $��Reserved Date��62   �� 5:      -
   5        $��txtDateReserved��5:      $��Stretch=�65   $

 True��6S   $��25��5;      ��5<      �� $ ReservationDate�$ OneWay=� 5=      �� $ lvBook��$ SelectedItem��� 5?      -   5        $��lbReturnDate��5?      $��Return Date��60   (  "System.Windows.Controls.DatePicker  5@      -   5        $��
txtDueDate��5@   !      SelectedDateFormat$ Short=�5A      5C      5D      �� 5F      $ 
Horizontal=�6   $
��Left=�5G      $��30,286,0,20q�6   $��3��62   .+�5H      �� -   5         ��Name$ 	btnBorrow��5H      $��10q�60   $��80��6<   $��Borrow��6G   ���	#FFB7E090$��20��5I   1   �� 5J      -   5        $ 	btnRemove��5J      $��10q�60   $��80��6<   $��Remove��6G   ���	#FFF7B0B0$��20��5K   0   5L      �� 5N      -   5        $��lvBook��5N   (   $��2��6   $	��610��66   $
��Auto��6B   $��10,14,10,-14q�6P   $��2��6f    �� View 5O      �� 5P      .P�5Q      �� $��Book ID��6-    �� Width$	 100��6>    �� DisplayMemberBinding 5R      �� $ Book.BookId��� 5S      $��Title��6-   $	 200��6<    5T      �� $ 
Book.Title��� 5U      $��Author��6-   $	 200��6=    5V   -   �� $ Book.Author��� 5W      $��Reserved date��6-   $	 100��6D    5X      �� $ ReservationDate�5Y      5[      5]      5^      5_      5`      