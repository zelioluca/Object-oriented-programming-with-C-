   M S B A M L   `   `   `  ����	  exm_5    example_5.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Monthly temperatures��5   	   $	��533��6&   $	��777��63   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid1��5      $��499,12,12,110q�6$   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5   F      AutoGenerateColumns .     HeadersVisibility$ Column=�5	      }�.    Columns 5
      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  Date ��6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *X+6N     5      $  Temperature ��6;    6%   �� *Y+6T     5      $  Meter - location ��6?    6%   �� *Meter+6]   5      �� 5   
   -   5         ��Name$ canvas��5      ���	#FFEBE2E2}�.  $��	13,12,0,0q�6�   $
��Left=�6�   $	��451��6�   $	��416��6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ point��5   O   $��34��6   $
��Left=�6    $��
13,446,0,0q�6;   $�� ��6^   $	��Top=�6f   $	��451��6~   �� 5   
   -   5        	 ��Name$	 button2��5   O   $	��NEW��6   $
��Left=�6   $��518,403,0,0q�6:   $��70��6`   $��27��6}   $	��Top=�6�   �� 5   
   -   5        $
��READ��5      $
��Left=�6    $��27��6;   $��597,403,0,0q�6G   $	��Top=�6\   $��70��6t   6   5      5      