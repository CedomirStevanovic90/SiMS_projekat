   M S B A M L   `   `   `  ����H  DSiMS_projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SiMS_projekat.ViewSiMS_projekat.View  5   	   )    #SiMS_projekat.View.ViewAllUsersPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SiMS_projekat.View     5   	     � 
ResizeMode$  CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ ViewAllUsersPage��5
   	   $	��450��6"   $	��800��6/   .��5      � .+�5   
   �� $��Center=�6   $��366,10,346.6,0q�61   $
��Wrap=�6I   $�� Users��6]   $	��Top=�6k   $��25(�6�   $��81��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ myUsersDataGrid��5         AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6a      
IsReadOnly . $��0,105,-0.4,50q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width$	 25 6L   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *UserId+6L     5      $
 JMBG��6%   
 63   �� *Jmbg+  5      $
 Name��6%   
 63   �� *Name+  5      $ Surname��6%   
 66   �� *	Surname+  5      $ E-mail��6%   
 65   �� *Email+   ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value$
 Wrap=�6G   5      5        5      $ Mobile phone��6%   
 6;   �� *MobilePhone+  5      $ 	User type��6%   
 68   �� *
UserType+  5      $ Blocked��6%   
 66   �� *	Blocked+4  .System.Windows.Controls.DataGridTemplateColumn  5         HeaderTemplate 5      �� 5      .R�5       �� $��Actions��6(   5!         CellTemplate 5#      �� 5$      .R�5%      �� .+�5&   "   ��  ��Name$ 	updateBtn��6)   -   5        $��Update��5&   <   6M   �� 5'   "   $ 	deleteBtn��6)   -   5        $��Delete��5'   <   6M   5(      5)      5+      5-      �� 5.   
   -   5        $ 	createBtn��5.      $��User registration��6$   $
��Left=�6@   $��218,375,0,0q�6[   $	��Top=�6p   $	��365��6�   $��35��6�   6�   �� 5/   
   -   5        $ backBtn��5/      $
��Back��6"   $
��Left=�61   $��	10,24,0,0q�6L   $	��Top=�6_   $	��127��6w   $��33��6�   6�   �� 50   
   $
��Left=�6   $��
190,74,0,0q�6/   $
��Wrap=�6C   $��Select sort mode:��6W   $	��Top=�6p   $��13(�6�   �� 51   
   -   5         ��Name$ comboBoxSorting��51      $
��Left=�6,   $��
294,74,0,0q�6G   $	��Top=�6[   $	��120��6s   @�52      �� 53      .��6   	No sort6(   �� 54      .��6   Sort by name (A-Z)63   �� 55      .��6   Sort by name (Z-A)63   �� 56      .��6   Sort by surname (A-Z)66   �� 57      .��6   Sort by surname (Z-A)66   59      �� 5:   
   $
��Left=�6   $��
533,75,0,0q�6/   $
��Wrap=�6C   $��Filter by user type:��6W   $	��Top=�6s   $��13(�6�   �� 5;   
   -   5        $ comboBoxFiltering��5;      $
��Left=�6.   $��
643,75,0,0q�6I   $	��Top=�6]   $	��120��6u   @�5<      �� 5=      .��6   	No filter6*   �� 5>      .��6   Filter by Manager62   �� 5?      .��6   Filter by Doctor61   �� 5@      .��6   Filter by Pharmacist65   5B      5C      5D      