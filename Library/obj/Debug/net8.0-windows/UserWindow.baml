   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5   	       Library.UserWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Library     5   	     � Title$  
UserWindow��5   	   $	��830��6   $	��680��6)    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	   .��5      � .+�5   
   �� -   5        $��Borrow books��5      $
��Left=�6(   $��	30,10,0,0q�6C   $	��Top=�5      $��30��6%   $��90��61   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   � 5      $ White��6#    � Offset$ 0.771Q�61   5      5      �� 5   
   -   5        $��Borrow records��5      $
��Left=�6*   $��
140,10,0,0q�6E   $	��Top=�5      $��30��6   $��90��6)   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ Black��6#   � 5      $ White��6#   $ 0.553Q�61   5      5      �� 5    
   -   5        $��Reservation records��5       $
��Left=�6/   $��
250,10,0,0q�6J   $	��Top=�5!      $��30��6   $	��120��6%   ��5#      �� 5$      $ 0.5,1&�6&   $ 0.5,0&�67   .��5%      � $ Black��6#   � 5&      $ White��6#   $ 0.499Q�61   5'      5)      �� 5*   
   -   5        $��Comments��5*      $
��Left=�6$   $��
390,10,0,0q�6?   $	��Top=�5+      $��30��6   $��80��6%   ��5-      �� 5.      $ 0.5,1&�6&   $ 0.5,0&�67   .��5/      � $ Black��6#   � 50      $ White��6#   $
 0.65Q�61   51      53      �� 54   
   -   5        $��Log out��54      $
��Left=�6#   $��
530,10,0,0q�6>   $	��Top=�55      $��30��6   $��50��6%   ��57      �� 58      $ 0.5,1&�6&   $ 0.5,0&�67   .��59      � $ Black��6#   � 5:      $ White��6#   $
 0.65Q�61   5;      5=      �� 5>   
   -   5        $��Close��5>      $
��Left=�6!   $��
600,10,0,0q�6<   $	��Top=�5?      $��30��6   $��50��6%   ��5A      �� 5B      $ 0.5,1&�6&   $ 0.5,0&�67   .��5C      � $ Black��6#   � 5D      $ White��6#   $
 0.65Q�61   5E      5G       � 5H   
   -   5          �Name$ frMain��5H        � NavigationUIVisibility$ Visible=�6    $��0,50,0,0q�6A   5I      5J      