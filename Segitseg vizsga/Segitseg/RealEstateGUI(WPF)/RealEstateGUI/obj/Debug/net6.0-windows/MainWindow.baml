   M S B A M L   `   `   `  ����H  DRealEstateGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RealEstateGUIRealEstateGUI  5   	       RealEstateGUI.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:RealEstateGUI     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   .+�5   
   �� -   5        $��lstAds��5      $��5,5,5,0q�6    $��5��61   $	��419��6m   �� 5   
   $��1��6   $��0��6    $��Eladó neve:��6-   $��Center=�6C   �� 5   
   $��1��6   $��1��6    $��Eladó telefon száma:��6-   $��Center=�6L   �� 5   
   $��1��6   $��3��6    $��Hirdetések száma:��6-   $��Center=�6I   �� 5   
   -   5        $��2��5      $��2��6   $��1��62   $��5q�6B   $��Hirdetések betöltése��6M   6l   �� 5   
   -   5        $��lblName��5      $��2��6   $��0��6/   $��Center=�6<   ��6W   �� *Name+�� 5   
   -   5        $��lblPhone��5      $��2��6    $��1��60   $��Center=�6=   ��6X   �� *Phone+�� 5   
   -   5        $��lblCount��5      $��2��6    $��3��60   $��Center=�6=   ��6X   �� *Count+5      5       