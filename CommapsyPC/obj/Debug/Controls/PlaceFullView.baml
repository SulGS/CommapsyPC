   M S B A M L   `   `   `  ����E  ACommapsyPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CommapsyPC.ControlsCommapsyPC.Controls  5      '    !CommapsyPC.Controls.PlaceFullView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CommapsyPC.Controls     5      .��5	      � -   5        $
��grid��5	        � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $
��1.5* �6   �� 5      $
��0.5* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��	placeName��5      $��Center=�6!   $��Center=�6C   $��40(�6g   $��2��6u   $��Nombre del lugar��6�   �� 5   
   -   5        $��placeDescription��5      $��1��6,   $��3��69   $��1��6J   $��Descripcion de ejemplo��6Z   
�������$��WrapWithOverflow=�6�   �� 5   
   -   5        $��placeGPS��5      $��Center=�6    $��Center=�6B   $��16(�6f   $��2��6t   $��Coordenadas��6�   �� 5   
   $��3��6   $��2��6$   $��Disabled=�68   $
��Auto=�5   	   .��5      �� -   5        $��comments��5       �� Orientation$ 
Horizontal=�6)   5      5      5!      5"      