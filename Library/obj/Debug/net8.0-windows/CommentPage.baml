   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5          Library.CommentPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Library     5        N� Title$  CommentPage��5	      .��5      � ��5   
   �� 5       �� ImageSource$ /a1.jpg��6   .+�5   
   �� -   5         ��Name$ lbBookTitle_Copy��5      
���   �$��DemiBold"�6=   $��Center=�6S   $��20(�5      $��Comments��6   ]� 5   
   $	��Top=�6   $��0,50,0,0q�6,   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $��4* �6$   �� 5      $��* �6$   .+�5      ��  �� Orientation$ Vertical=�6   $��Center=�5      $	��610��6   ��5      �� 5       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5      �  � Color$ Black��6+   � 5      $ White��6+    � Offset$ 0.149Q�69   5       .+�5"      �� -   5        $��lbBookTitle��5"      $��DemiBold"�6/   $��20(�5#      $��Comments��6   $��Center=�6#   ���	#FF00F6FF��5$      �� 5%      $ 0.5,1&�62   $ 0.5,0&�6C   .��5&   "   � $ Black��6/   � 5'   "   $ White��6/   $ 1Q�6=   5(      5*      �� 5+      -   5        $��lbBookID��5+      $��Book ID��6,   �� 5,      -   5        $��	txtBookID��5,      $��Stretch=�6/   $��25��5-      	 �� 
IsReadOnly$
	 True��51      ��5.      �� 
 �� Path$
 Book.BookId� �� Mode$ OneWay=� � DataContext 5/      ��  �� ElementName$ lvBook��$
 SelectedItem�51      �� 52      -   5        $��lbTitle��52      $��Title��6+   �� 53      -   5        $��txtTitle��53      $��Stretch=�6.   $
	 True��6L   $��25��54      ��55      �� $
 
Book.Title�$ OneWay=� 56      �� $ lvBook��$
 SelectedItem��� 58      -   5        $��lbAuthor��58      $��Author��6,   �� 59      -   5        $��	txtAuthor��59      $��Stretch=�6/   $
	 True��6M   $��25��5:      ��5;      �� $
 Book.Author�$ OneWay=� 5<      �� $ lvBook��$
 SelectedItem��� 5>      -	   5        $��	lbComment��5>      $��Comment��6-   �� 5?      -
   5        $��
txtComment��5?      $��Stretch=�60   $��25��5@      ��5A      �� $
 Comments�$ OneWay=� 5B      �� $ lvBook��$
 SelectedItem��� 5D      -   5        $��lbRating��5D      $��Rating��6,   �� 5E      -   5        $��	txtRating��5E      $��Stretch=�6/   $��25��5F      ��5G      �� $
 Rating�$ OneWay=� 5H      �� $ lvBook��$
 SelectedItem�5J      �� 5L      $ 
Horizontal=�6   $
��Left=�5M      $��
30,291,0,0q�6   $��2��61   .+�5N      �� -   5         ��Name$ 
btnComment��5N      $��10q�61   $��80��6=   $��Comment��6H   $��20��5O      ���	#FF76D6CF6'   �� 5P      -   5        $ 	btnRemove��5P      $��80��60   $��Remove��6;   $��20��5Q      ���	#FFE871716%   5R      �� 5T      -   5        $��lvBook��5T   (   $��3��6   $	��610��66   $��Center=�6B   $��0,29,0,-281q�6_    �� View 5U      �� 5V      .P�5W      �� $��Book ID��6-    �� Width$	 100��6>    �� DisplayMemberBinding 5X      �� $
 Book.BookId��� 5Y      $��Title��6-   $	 200��6<    5Z      �� $
 
Book.Title��� 5[      $��Author��6-   $	 120��6=    5\   -   �� $
 Book.Author��� 5]      $��Comment��6-   $	 100��6>    5^      �� $
 Comments��� 5_      $��Rating��6-   $	 100��6=    5`      �� $
 Rating�5a      5c      5e      5f      5g      5h      