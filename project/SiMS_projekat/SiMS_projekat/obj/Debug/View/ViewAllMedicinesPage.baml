   M S B A M L   `   `   `  ����H  DSiMS_projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SiMS_projekat.ViewSiMS_projekat.View  5   	   -    'SiMS_projekat.View.ViewAllMedicinesPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SiMS_projekat.View     5   	     � 
ResizeMode$  CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ ViewAllMedicinesPage��5
   	   $	��450��6&   $	��800��63   .��5      � .+�5   
   �� $��Center=�6   $��366,10,305,0q�61   $
��Wrap=�6G   $��
 Medicines��6[   $	��Top=�6m   $��25(�6�   $	��123��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ myMedicinesDataGrid��5         AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6e      
IsReadOnly . $��0,105,-0.4,50q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Code��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 63   �� *MedicineCode+  5      $ Medicine name��6%   
   Width$
 92 6U   	 6<   �� *Name+6U     5      $ Producer��6%   	 67   �� *
Producer+  5      $ Quantity��6%   	 67   �� *
Quantity+  5      $ Price��6%   	 64   �� *Price+  5      $ RejectedDetails��6%   $
 92 6b   	 6>   �� *RejectedDetails+   ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value$
 Wrap=�6G   5      5        5      $ Accepted��6%   	 67   �� *
Accepted+  5      $ Rejected��6%   	 67   �� *
Rejected+4  .System.Windows.Controls.DataGridTemplateColumn  5         HeaderTemplate 5      �� 5      .R�5       �� $��Actions��6(   5!         CellTemplate 5#      �� 5$      .R�5%      �� .+�5&   "   ��  ��Name$ 	updateBtn��6)   -   5        $��Update��5&   <   6M   �� 5'   "   $ 	deleteBtn��6)   -   5        $��Delete��5'   <   6M   5(      5)      5+        5,       5-      �� 5.      .R�5/      �� $��Details��6(   50       52      �� 53      .R�54      �� .+�55   "   �� $ ingredientsBtn��6)   -   5        $��Ingredients��55   A   $��40��6W   6c   56      57      59        5:       5;      �� 5<      .R�5=      �� $��Purchase��6(   5>       5@      �� 5A      .R�5B      �� .+�5C   "   �� $ purchaseBtn��6)   -   5        $��Purchase��5C   >   $��40��6Q   6]   5D      5E      5G      5I      �� 5J   
   -   5        $ 	createBtn��5J      $��Create new medicine��6$   $
��Left=�6B   $��
73,375,0,0q�6]   $	��Top=�6q   $	��365��6�   $��35��6�   6�   �� 5K   
   -   5        $ backBtn��5K      $
��Back��6"   $
��Left=�61   $��	10,24,0,0q�6L   $	��Top=�6_   $	��127��6w   $��33��6�   6�   �� 5L   
   $
��Left=�6   $��	10,77,0,0q�6/   $
��Wrap=�6B   $��Select sort mode:��6V   $	��Top=�6o   $��13(�6�   �� 5M   
   -   5         ��Name$ comboBoxSorting��5M      $
��Left=�6,   $��
114,74,0,0q�6G   $	��Top=�6[   $	��180��6s   @�5N      �� 5O      .��6   	No sort6(   �� 5P      .��6   Sort by name (A-Z)63   �� 5Q      .��6   Sort by name (Z-A)63   �� 5R      .��6   Sort by price (Low - High)6;   �� 5S      .��6   Sort by price (High - Low)6;   �� 5T      .��6   Sort by quantity (Low - High)6>   �� 5U      .��6   Sort by quantity (High - Low)6>   5W      �� 5X   
   $
��Left=�6   $��
308,77,0,0q�6/   $
��Wrap=�6C   $��Select search mode:��6W   $	��Top=�6r   $��13(�6�   �� 5Y   
   -	   5         ��Name$ searchTextBox��5Y      $
��Left=�6)   $��23��6D   $��
574,77,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��130��6�   �� 5Z   
   -
   5        $ searchComboBox��5Z      $
��Left=�6+   $��
427,77,0,0q�6F   $	��Top=�6Z   $	��142��6r   @�5[      �� 5\      .��6   	No search6*   �� 5]      .��6   Search by Medicine Code68   �� 5^      .��6   Search by Name6/   �� 5_      .��6   Search by Producer63   �� 5`      .��6   Search by Price range66   �� 5a      .��6   Search by Quantity63   �� 5b      .��6   Search by Ingredients66   5d      �� 5e   
   -   5        $ 	searchBtn��5e      $��Search��6$   $
��Left=�65   $��
709,78,0,0q�6P   $	��Top=�6d   $��75��6|   $��22��6�   $��13(�6�   �� 5f   
   $
��Left=�6   $��
568,33,0,0q�6/   $
��Wrap=�6C   $!��Price range(example: 12-14)��6W   $	��Top=�6z   �� 5g   
   $
��Left=�6   $��
466,51,0,0q�6/   $
��Wrap=�6C   $;��5Ingredients(example: Silicijum&(Magnezijum|Kalcijum))��6W   $	��Top=�6�   $	��302��6�   �� 5h   
   -   5        $ acceptedAndRejectedBtn��5h      $#��Display accepted and rejected��61   $
��Left=�6Y   $��498,375,0,0q�6t   $	��Top=�6�   $	��170��6�   $��35��6�   6�   5i      5j      