   M S B A M L   `   `   `  ����H  DSiMS_projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SiMS_projekat.ViewSiMS_projekat.View  5   	   +    %SiMS_projekat.View.MedicineOnHoldPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SiMS_projekat.View     5   	     � 
ResizeMode$  CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ MedicineOnHoldPage��5
   	   $	��450��6$   $	��800��61   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ myMedicinesOnHoldDataGrid��5         AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6k      
IsReadOnly . $��	0,105,0,0q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Code��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 63   �� *MedicineCode+  5      $ Medicine name��6%   	 6<   �� *Name+  5      $ Producer��6%   	 67   �� *
Producer+  5      $ Quantity��6%   	 67   �� *
Quantity+  5      $ Price��6%   	 64   �� *Price+  5      $ Accepted��6%   	 67   �� *
Accepted+  5      $ Rejected��6%   	 67   �� *
Rejected+4  .System.Windows.Controls.DataGridTemplateColumn  5      
   HeaderTemplate
 5      �� 5      .R�5      �� $��Actions��6(   5         CellTemplate 5      �� 5      .R�5      �� .+�5   "   ��  ��Name$ 	acceptBtn��6)   -   5        $��Accept��5   <   $��20��6M   6Y   �� 5   "   $ 	rejectBtn��6)   -   5        $��Reject��5   <   $��20��6M   6Y   5       5!      5#      5%      �� 5&   
   -   5        $ backBtn��5&      $
��Back��6"   $
��Left=�61   $��	10,24,0,0q�6L   $	��Top=�6_   $	��127��6w   $��33��6�   6�   �� 5'   
   $��Center=�6   $��309,10,258.6,0q�61   $
��Wrap=�6I   $�� Medicines on hold��6]   $	��Top=�6w   $��25(�6�   $	��226��6�   5(      5)      