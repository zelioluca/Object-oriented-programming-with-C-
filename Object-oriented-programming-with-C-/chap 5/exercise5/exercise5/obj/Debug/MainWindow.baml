   M S B A M L   `   `   `  ����  	exercise5    exercise5.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Monthly Temperatures��5      $��623.478��6%   $��1594.718��66    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$	 New��5      6N     5   
   -   5        $
 Open��5      6O     5   
   -   5        $
 Save��5      6O     5	   
   -   5        $ SaveAs��5	      6Q     5
   
   -   5        $ Close��5
      6P   .��5      �  � RowDefinitions 5   
   �� 5      $
��243* �6   �� 5      $
��220* �6   .+�5   
   ]� $��0,0,-0.2,174.3q�6   .+�5      o� $	��Top=�6   $��29��6(   .@�5      m� $��_File��6   .@�5      m�  m� Command$	 New��6   m� 5      $
 Open��6   m� 5      $
 Save��6   m� 5      $ SaveAs��6   �� 5      m� 5      $ Close��6   5      5      `� 5      $��Bottom=�6   $��33��62   .�5      c� .@�5      �� $	��New��6   $	��New��6+   �� 5      �� 5       $
��Open��6   $
��Open��6,   �� 5!      �� 5"      $
��Save��6   $
��Save��6,   �� 5#      5$      5%      5&      &   System.Windows.Controls.DataGrid  5'   
   -   5        $��	dataGrid1��5'      $��0,176,721,67.6q�6$   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5(   F      AutoGenerateColumns .     HeadersVisibility$ Column=�5)      }�. $��Right=�6B   $	��349��6^   $��2��6j      Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn	   Header$	  Date ��6<   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *X+6N     5,      $	  Temperature ��6;   
 6%   �� *Y+6T     5-      $	  Meter - location ��6?   
 6%   �� *Meter+6]   5/      �� 51   
   -   5         ��Name$ canvas��51      ���	#FFEBE2E2}�.  $��
10,176,0,0q�6�   $
��Left=�6�   $	��451��6�   $	��350��6�   $	��Top=�6�   $��2��6�   �� 52   
   -	   5         ��Name$ point��52   Q   $��34��6   $
��Left=�6    $��10,214.8,0,0q�6;   $�� ��6`   $	��Top=�6h   $	��451��6�   $��1��6�   �� 53   
   -
   5         ��Name$ button2��53   Q   $	��New��6   $
��Left=�6   $��532,229.8,0,0q�6:   $��70��6b   $��27��6   $	��Top=�6�   $��1��6�   �� 54   
   -   5        $
��Read��54      $
��Left=�6    $��27��6;   $��621,229.8,0,0q�6G   $	��Top=�6^   $��70��6v   $��1��6�   �� 55   
   -   5         ��Name$ richTextBox��55      $
��Left=�6+   $	��350��6F   $��1156,176,0,0q�6S   $	��Top=�6i   $	��400��6�   $��2��6�   . �56      /� .T�57      J� .*�6   .*�58      �� $�RichTextBox��6   59      5:      5;      �� 5<   
   -   5        $ 	textBlock��5<      $
��Left=�6'   $��888,181,0,0q�6B   $
��Wrap=�6W   $��	TextBlock��6k   $	��Top=�6|   $��37��6�   $	��246��6�   �� 5=   
   -   5        $ 
textBlock1��5=      $
��Left=�6(   $��888,223,0,0q�6C   $
��Wrap=�6X   $��	TextBlock��6l   $	��Top=�6}   $��38��6�   $	��246��6�   5>      5@      