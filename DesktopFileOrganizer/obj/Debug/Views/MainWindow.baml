   M S B A M L   `   `   `  ����O  KDesktopFileOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:DesktopFileOrganizer.Views.CustomControl(DesktopFileOrganizer.Views.CustomControl  5   	   [2clr-namespace:DesktopFileOrganizer.Views.Behaviors$DesktopFileOrganizer.Views.Behaviors  5   	   ;"clr-namespace:DesktopFileOrganizerDesktopFileOrganizer  5   	   %    DesktopFileOrganizer.MainWindow   5   	   HCustomControl6clr-namespace:DesktopFileOrganizer.Views.CustomControl  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   ;be2clr-namespace:DesktopFileOrganizer.Views.Behaviors  5   	   .local"clr-namespace:DesktopFileOrganizer  5   	     � WindowStyle$
  None=�5	   	    � WindowState$ 	Maximized=�5   	    � AllowsTransparency . 
������  � Title$ 
MainWindow��5   	   $
��1080��6   $
��1920��6*    � Topmost 5
   	   �� *	IsTopmost+ � DataContext 5   	   ��    Locator �� Source# [   �� Path$
 Main�.��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��8 �6   �� 5      $	��110 �6   �� 5      $��60 �6   .+�5   
   � -   5        	 �Name$	 popup��5      
 � 	StaysOpen
 .  $��Slide=�61    � AllowsTransparency . ��6H   �� *	PopIsOpen+ � PlacementTarget 6e   ��  �� ElementName$ 	searchBar��.��5      �� $	��258��6   $	��335��6!   
������  �� CornerRadius$ 16��6G   ._�5      �� -   5         ��Name$ result_ListBox��5        ResultListStyle#���  63   $��Bottom=�6�     ItemContainerStyle2#���  6�   ��6^   �� *SearchResultList+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ SelectionChanged��6)   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 64   �� *OpenResultDataCommand+   CommandParameter 6^   �� $ result_ListBox��$ SelectedIndex�5       ��5"      �� 5#      .R�5$      �� $	��240��6%   $��44��61   $��0,3,0,3q�6=   ���	#70000000$ 12��6e   ._�5%   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5&   &   �� $��14��6-   $��14��68   ���#0A8BFF$ 7��6Y   $
��12,0q�6j   �� 5'   *   ���#F1F2F3$	��170��6c   $��CharacterEllipsis=�6o   $��Center=�6�   $��14(�6�   $
��Bold"�6�   ��64   �� *
FileName+6�   �� 5(   &    ��Name$
 path��6J   $y�	Collapsed=�6X   ��60   �� *
PathInfo+6X   5)   #   5*      5+      5-      5.      5/      �� 50   
   $��2��6   $��Center=�6#   .+�51      �  52      �� 53      $��40 �6$   �� 55      $��4 �6$   �� 57      $��66 �6$    � ColumnDefinitions 5:      �� 5;      $
��auto �6'   �� 5<      �� 5=      $
��auto �6'   .+�5?      �� -   5         ��Name$ 	searchBar��5?   h   $ 
Horizontal=�6   $
��auto��6[   y�66   �� *SearchFileVis+.+�5@      �� $	��240��6   $��36��6*     DockBoderStyle#���  6U   $
��Left=�6~    J� Opacity$	 0.7Q�6�   ��66   �� *	BgColor+._�5A      �� $ 
Horizontal=�6%   $��8,0,8,0q�6>   .+�5B      �� $ ��/Resources/Fonts/#iconfont)�6I   $	����6q   $��24(�6�   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   ��6(   �� *	FontColor+6�   �� 5C      -   5         ��Name$ 	searchbox��5C   &     TextBoxStyle#���  69   $-��'请输入想要查询的文件名......��6`   $	��184��6�   ��6y   �� *	BgColor+��6�   �� *	FontColor+.��6   5D   "     5E   &   $ TextChanged��65   . 5F   *      6@   �� *TextChangedCommand+ 6g   �� $ 	searchbox��$
 Text�5G   '   .��5H   :   5I      5J      5K      �� 5M      $ 
Horizontal=�6!   $��2,0,0,0q�6:   .+�5O      $   DesktopFileOrganizer.ImgButton     Source$( "../Resources/Icons/Excel-Color.png��6*      BackgroundColor 6V   �� *	BgColor+   Command 6z   �� *SearchExcelFileCommand+  5Q      $- '../Resources/Icons/Powerpoint-Color.png��6*    6[   �� *	BgColor+ 6   �� *SearchPPtFileCommand+  5S      $' !../Resources/Icons/Word-Color.png��6*    6U   �� *	BgColor+ 6y   �� *SearchWordFileCommand+  5U      $( "../Resources/Icons/File_Folder.png��6*    6V   �� *	BgColor+ 6z   �� *SearchAllFileCommand+5V      5W      �� 5X      $��1��68   $��8,0,8,0q�6H   $ 18��6Y   $	 0.7Q�6k   $��36��6y   $y�	Collapsed=�6�   ��6   �� *	BgColor+6�   �� 5Y      $��温馨提醒��6   $��Center=�6I   $
��32,0q�6d   $
��Bold"�6r   $��16(�6�   $��1��6�   $y�	Collapsed=�6�   ��6(   �� *	FontColor+6�   �� 5Z      $��Right=�6!   $ 
Horizontal=�6=   $��RightToLeft=�6V   $��2��6r   $
��auto��6�   .+�5\      �� $	��160��6   #���  6*   $��Right=�6S   $��36��6�   ��6o   �� *	BgColor+._�5]      �� -   5        $ 	time_Text��5]   $   $��03月11日 21:00��67   $��16(�6K   $��Center=�6Y   $��Center=�6t   $
��Bold"�6�   ��6�   �� *	FontColor+   	Behaviors 5^      =  7DesktopFileOrganizer.Views.Behaviors.UpdateTimeBehavior  5_   "      NowTime 68   �� $ 	time_Text��$
 Text�5a      5b      �� 5d      $��40��6   $��40��6(   $��0q�64   
������ $��2,0,0,0q�6a    5e      D  >DesktopFileOrganizer.Views.Behaviors.BackgroundChangedBehavior  5f          	ForeColor  6;   �� *	FontColor+! �� Mode$! TwoWay=�"   BgColor" 6g   �� *	BgColor+$! TwoWay=�#   	ImgSource# 6�   �� *
BtnImage+$! TwoWay=�.��5h      ��   FileTypeStyle#���  6!   ��6I   �� *	BgColor+._�5i      �� $��20��6A   $��20��6L   $��Center=�6Y   $��Center=�6v   ��6$   �� *
BtnImage+6v   5j      5k      �� 5m      $��36��6   $��36��6(   $	 0.7Q�6S   $ 18��6a   $��4,0,0,0q�6s   ��64   �� *	BgColor+y�6�   �� *
TopmostVis+._�5n      �� $	����6$   $ ��/Resources/Fonts/#iconfont)�64   $��Center=�6}   $��Center=�6�   $��18(�6�   ��6\   �� *	FontColor+6�   5o      �� 5q      $��40��6   $��40��6(   $��0q�64   
������ $��4,0,0,0q�6a    5r      D  >DesktopFileOrganizer.Views.Behaviors.VisibilityChangedBehavior  5s      $   MyVisibility$ 6;   �� *	MenuVis+$! TwoWay=�.��5u      �� #���  6!   ��6I   �� *	BgColor+._�5v      �� $	����6(   $ ��/Resources/Fonts/#iconfont)�6Y   $��20(�6�   $
��Bold"�6�   $��20��6�   $��20��6�   $��Center=�6�   $��Center=�6�   ��68   �� *	FontColor+6�   5w      5x      �� 5y      $ 
Horizontal=�6!   y�6:   �� *	MenuVis+.+�5z      ��   MenuItemStyle#��[ 6"   $	����6I   �� 5{      #��[ 6"   $	����6I   �� 5|      #��[ 6"   $	����6I    5}      =	  7DesktopFileOrganizer.Views.Behaviors.TopmostBtnBehavior	  5~   "   % 	  	IsTopmost% 68   �� *	IsTopmost+$! TwoWay=�& 	  BorderVisibility& 6d   �� *
TopmostVis+$! TwoWay=�5�      �� 5�      #��[ 6"   $	����6I    5�        5�   "   $ 6?   �� *SearchFileVis+$! TwoWay=�5�      5�      5�      �� 5�      $��66��66   #���  6B   $��2��6k   $ 18��6x   $��3��6�   ��6   �� *	DockWidth+��6�   �� *	BgColor+�� 5�      $ 
Horizontal=�6   $��2��66   $��3��6C   .+�5�      �� -   5        $ lnkData_Listbox��5�        DockListStyle#���  6[     ItemContainerStyle1#���  6�   ' �� SelectionMode$' Extended=�6�   ��67   �� *LnkDataList+ 5�        5�      $ SelectionChanged��6-   . 5�   "      68   �� *OpenLnkDataCommand+ 6_   �� $ lnkData_Listbox��$ SelectedIndex�5�      ��5�      �� 5�      .R�5�   "   �� $
��Fill=�6G   $��44��6V   $��44��6a   ��6)   �� *
IconSource+6a   5�      5�      �� 5�      $��26��6   $
��3,20q�6)   $��4��67   $ 2��6b   ��6A   �� *	FontColor+y�6s   �� *SplitDockVis+�� 5�      -   5        $ usualData_ListBox��5�      #���  6_   #���  6�   ��69   �� *UsualDataList+ 5�        5�      $ SelectionChanged��6-   . 5�   "      68   �� *OpenLnkDataCommand+ 6_   �� $ usualData_ListBox��$ SelectedIndex�5�      ��5�      �� 5�      .R�5�   "   �� $
��Fill=�6G   $��44��6V   $��44��6a   ��6)   �� *
IconSource+6a   5�      5�      5�      5�      5�      5�      5�      