   M S B A M L   `   `   `  ���� O  KDesktopFileOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:DesktopFileOrganizer.Views.CustomControl(DesktopFileOrganizer.Views.CustomControl  [2clr-namespace:DesktopFileOrganizer.Views.Behaviors$DesktopFileOrganizer.Views.Behaviors  ;"clr-namespace:DesktopFileOrganizerDesktopFileOrganizer  %    DesktopFileOrganizer.MainWindow   HCustomControl6clr-namespace:DesktopFileOrganizer.Views.CustomControl  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  ;be2clr-namespace:DesktopFileOrganizer.Views.Behaviors  .local"clr-namespace:DesktopFileOrganizer    � WindowStyle$
  None=� � WindowState$ 	Maximized=� � AllowsTransparency . 
������  � Title$ 
MainWindow��$
��1080��$
��1920�� � Topmost �� *	IsTopmost+ � DataContext ��    Locator �� Source# [   �� Path$
 Main�.���  � RowDefinitions �� �� $��8 ��� $	��110 ��� $��60 �.+�� -   	 �Name$	 popup��
 � 	StaysOpen
 .  $��Slide=� � AllowsTransparency . ���� *	PopIsOpen+ � PlacementTarget ��  �� ElementName$ 	searchBar��.���� $	��258��$	��335��
������  �� CornerRadius$ 16��._��� -    ��Name$ result_ListBox��  ResultListStyle#���  $��Bottom=�  ItemContainerStyle2#���  ���� *SearchResultList+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ SelectionChanged��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *OpenResultDataCommand+   CommandParameter �� $ result_ListBox��$ SelectedIndex����� .R��� $	��240��$��44��$��0,3,0,3q����	#70000000$ 12��._���  �� Orientation$ 
Horizontal=�.+��� $��14��$��14�����#0A8BFF$ 7��$
��12,0q��� ���#F1F2F3$	��170��$��CharacterEllipsis=�$��Center=�$��14(�$
��Bold"����� *
FileName+��  ��Name$
 path��$y�	Collapsed=����� *
PathInfo+�� $��2��$��Center=�.+��  �� $��40 ��� $��4 ��� $��66 � � ColumnDefinitions �� $
��auto ��� �� $
��auto �.+��� -    ��Name$ 	searchBar��$ 
Horizontal=�$
��auto��y��� *SearchFileVis+.+��� $	��240��$��36��  DockBoderStyle#���  $
��Left=� J� Opacity$	 0.7Q����� *	BgColor+._��� $ 
Horizontal=�$��8,0,8,0q�.+��� $ ��/Resources/Fonts/#iconfont)�$	����$��24(�$��Center=�$��Center=�$
��Bold"����� *	FontColor+�� -    ��Name$ 	searchbox��  TextBoxStyle#���  $-��'请输入想要查询的文件名......��$	��184������ *	BgColor+���� *	FontColor+.��   $ TextChanged��.    �� *TextChangedCommand+ �� $ 	searchbox��$
 Text�.���� $ 
Horizontal=�$��2,0,0,0q�.+�$   DesktopFileOrganizer.ImgButton     Source$( "../Resources/Icons/Excel-Color.png��   BackgroundColor �� *	BgColor+   Command �� *SearchExcelFileCommand+  $- '../Resources/Icons/Powerpoint-Color.png�� �� *	BgColor+ �� *SearchPPtFileCommand+  $' !../Resources/Icons/Word-Color.png�� �� *	BgColor+ �� *SearchWordFileCommand+  $( "../Resources/Icons/File_Folder.png�� �� *	BgColor+ �� *SearchAllFileCommand+�� $��1��$��8,0,8,0q�$ 18��$	 0.7Q�$��36��$y�	Collapsed=����� *	BgColor+�� $��温馨提醒��$��Center=�$
��32,0q�$
��Bold"�$��16(�$��1��$y�	Collapsed=����� *	FontColor+�� $��Right=�$ 
Horizontal=�$��RightToLeft=�$��2��$
��auto��.+��� $	��160��#���  $��Right=�$��36������ *	BgColor+._��� -   $ 	time_Text��$��03月11日 21:00��$��16(�$��Center=�$��Center=�$
��Bold"����� *	FontColor+   	Behaviors =  7DesktopFileOrganizer.Views.Behaviors.UpdateTimeBehavior     NowTime �� $ 	time_Text��$
 Text��� $��40��$��40��$��0q�
������ $��2,0,0,0q� D  >DesktopFileOrganizer.Views.Behaviors.BackgroundChangedBehavior      	ForeColor  �� *	FontColor+! �� Mode$! TwoWay=�"   BgColor" �� *	BgColor+$! TwoWay=�#   	ImgSource# �� *
BtnImage+$! TwoWay=�.����   FileTypeStyle#���  ���� *	BgColor+._��� $��20��$��20��$��Center=�$��Center=����� *
BtnImage+�� $��36��$��36��$	 0.7Q�$ 18��$��4,0,0,0q����� *	BgColor+y��� *
TopmostVis+._��� $	����$ ��/Resources/Fonts/#iconfont)�$��Center=�$��Center=�$��18(����� *	FontColor+�� $��40��$��40��$��0q�
������ $��4,0,0,0q� D  >DesktopFileOrganizer.Views.Behaviors.VisibilityChangedBehavior  $   MyVisibility$ �� *	MenuVis+$! TwoWay=�.���� #���  ���� *	BgColor+._��� $	����$ ��/Resources/Fonts/#iconfont)�$��20(�$
��Bold"�$��20��$��20��$��Center=�$��Center=����� *	FontColor+�� $ 
Horizontal=�y��� *	MenuVis+.+��� -     MenuItemStyle#��[ $	������ #��[ $	������ #��[ $	���� =	  7DesktopFileOrganizer.Views.Behaviors.TopmostBtnBehavior	  % 	  	IsTopmost% �� *	IsTopmost+$! TwoWay=�& 	  BorderVisibility& �� *
TopmostVis+$! TwoWay=��� #��[ $	����   $ �� *SearchFileVis+$! TwoWay=��� $��66��#���  $��2��$ 18��$��3������ *	DockWidth+���� *	BgColor+�� $ 
Horizontal=�$��2��$��3��.+��� -   $ lnkData_Listbox��  DockListStyle#���    ItemContainerStyle1#���  ' �� SelectionMode$' Extended=����� *LnkDataList+   $ SelectionChanged��.    �� *OpenLnkDataCommand+ �� $ lnkData_Listbox��$ SelectedIndex����� .R��� $
��Fill=�$��44��$��44������ *
IconSource+�� $��26��$
��3,20q�$��4��$ 2������ *	FontColor+y��� *SplitDockVis+�� -   $ usualData_ListBox��#���  #���  ���� *UsualDataList+   $ SelectionChanged��.    �� *OpenLnkDataCommand+ �� $ usualData_ListBox��$ SelectedIndex����� .R��� $
��Fill=�$��44��$��44������ *
IconSource+