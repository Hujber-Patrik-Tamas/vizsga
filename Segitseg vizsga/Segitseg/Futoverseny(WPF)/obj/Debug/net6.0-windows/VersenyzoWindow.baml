   M S B A M L   `   `   `  ����F  BFutoverseny, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:FutoversenyFutoverseny  5   	   !    Futoverseny.VersenyzoWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Futoverseny     5   	     � Title$  Adatok megadása��5   	   $	��300��6!   $	��500��6.   $��16(�6:    � 
ResizeMode$ NoResize=�6H   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $��8 �6   .+�5   
   �� $��
Rajtszám:��6   $��0��6$   $��Center=�61   �� 5   
   $��Név:��6   $��1��6   $��Center=�6,   �� 5   
   $��Távolság:��6   $��2��6$   $��Center=�61   �� 5   
   $��Neme:��6   $��3��6    $��Center=�6-   �� 5   
   $��Korosztály:��6   $��4��6&   $��Center=�63   �� 5   
   $��Születési dátum:��6   $��5��6+   $��Center=�68   �� 5   
   -   5        $��txtRajtszam��5      $��1��6%   $��0��65   $��28��6B   $	��100��6N   $
��Left=�6Z   ��5       �� *
Rajtszam+�� 5!   
   $��1��6   $��1��6"   $��28��6/   ��5"      �� *Nev+�� 5#   
   -   5        $��cboTavolsag��5#      $��1��6&   $��2��66   $��28��6C    �� SelectedValue 5$      �� *
TavolsagId+�� 5%   
   $��1��6   $��3��6"   $��28��6/   $	��100��6;   $
��Left=�6G   ��5&      �� *Neme+�� 5'   
   $��1��6   $��4��6"   $��28��6/   ��5(      �� *
Korosztaly+(  "System.Windows.Controls.DatePicker  5)   
   $��1��6   $��5��6%   $��28��62   $	��130��6>   $
��Left=�6J      SelectedDate 5*      �� *SzuletesiDatum+� 5,   
   $��5q�6   $��6��6   $��3��6,   $��Center=�6@   $��Center=�6]   .+�5-      �� -   5        $��Mentés��5-      $	��120��6&   $��30��62   $��0 0 20 0q�6>   6P   �� 5.      -   5        $��Mégsem��5.      $	��120��6&   $��30��62   $��20 0 0 0q�6>   6P   5/      50      51      