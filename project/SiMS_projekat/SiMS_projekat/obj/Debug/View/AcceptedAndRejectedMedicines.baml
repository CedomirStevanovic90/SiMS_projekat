   M S B A M L   `   `   `  ����H  DSiMS_projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SiMS_projekat.ViewSiMS_projekat.View  5   	   5    /SiMS_projekat.View.AcceptedAndRejectedMedicines   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SiMS_projekat.View     5   	     � Title$"  AcceptedAndRejectedMedicines��5   	   $	��450��6.   $	��800��6;   .��5	      � .+�5
   
   �� $��Center=�6   $��234,10,178.6,0q�61   $
��Wrap=�6I   $&��  Accepted and rejected medicines��6]   $	��Top=�6�   $��25(�6�   $	��381��6�   �� 5   
   $
��Left=�6   $��	79,46,0,0q�6/   $
��Wrap=�6B   $��Accepted��6V   $	��Top=�6f   $��15(�6~   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$! myMedicinesAcceptedDataGrid��5         AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6m      
IsReadOnly . $��
0,80,0,200q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Code��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *MedicineCode+  5      $ Medicine name��6%    6<   �� *Name+  5      $ Producer��6%    67   �� *
Producer+  5      $ Quantity��6%    67   �� *
Quantity+  5      $ Price��6%    64   �� *Price+  5      $ Accepted��6%    67   �� *
Accepted+  5      $ Rejected��6%    67   �� *
Rejected+5      �� 5   
   $
��Left=�6   $��
79,230,0,0q�6/   $
��Wrap=�6C   $��Rejected��6W   $	��Top=�6g   $��15(�6     5   
   -   5        $! myMedicinesRejectedDataGrid��5       .  $ * 6m    . $��	0,270,0,0q�6�    5        5      $
 Code��6%    63   �� *MedicineCode+  5      $ Medicine name��6%    6<   �� *Name+  5      $ Producer��6%    67   �� *
Producer+  5      $ Quantity��6%    67   �� *
Quantity+  5      $ Price��6%    64   �� *Price+  5      $ Accepted��6%    67   �� *
Accepted+  5       $ Rejected��6%    67   �� *
Rejected+  5!      $ RejectedDetails��6%    6>   �� *RejectedDetails+   ElementStyle 5"      �� 5#      	 �� 
TargetType"	 ��6    .�5$      �� 
 �� Property
 � �� �� Value$
 Wrap=�6G   5%      5'      5)      5*      5+      