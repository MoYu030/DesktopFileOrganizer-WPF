using DesktopFileOrganizer.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using Brush = System.Drawing.Brush;

namespace DesktopFileOrganizer.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        #region Property
        private List<FileInfoModel> lnkDataList;
        /// <summary>
        /// Dockl栏中的APP
        /// </summary>
        public List<FileInfoModel> LnkDataList
        {
            get 
            {               
                return lnkDataList ;
            }
            set { lnkDataList = value; }
        }

        private List<FileInfoModel> usualDataList;
        /// <summary>
        /// Dock栏中最近使用的app
        /// </summary>
        public List<FileInfoModel> UsualDataList
        {
            get
            {
                return LnkDataList.Where(t=>t.UseCount>0).OrderByDescending(t => t.UseCount).Take(3).ToList(); ;
            }
            set { usualDataList = value;RaisePropertyChanged(); }
        }

        private List<FileInfoModel> searchResultList;
        /// <summary>
        /// 搜索出的文件
        /// </summary>
        public List<FileInfoModel> SearchResultList
        {
            get { return searchResultList; }
            set { searchResultList = value;RaisePropertyChanged(); }
        }

        private int dockWidth;
        /// <summary>
        /// dock栏宽度
        /// </summary>
        public int DockWidth
        {
            get { return dockWidth; }
            set { dockWidth = value;RaisePropertyChanged(); }
        }

        private Visibility menuVis;
        /// <summary>
        /// 控制菜单列表的显示
        /// </summary>
        public Visibility MenuVis
        {
            get { return menuVis; }
            set { menuVis = value; RaisePropertyChanged(); }
        }

        private Visibility searchFileVis;
        /// <summary>
        /// 控制搜索文件栏显示
        /// </summary>
        public Visibility SearchFileVis
        {
            get { return searchFileVis; }
            set { searchFileVis = value;RaisePropertyChanged(); }
        }

        private Visibility splitDockVis;
        /// <summary>
        /// 应用与常用应用分割栏
        /// </summary>
        public Visibility SplitDockVis
        {
            get { return splitDockVis; }
            set { splitDockVis = value; RaisePropertyChanged(); }
        }

        private SolidColorBrush bgColor;
        /// <summary>
        /// 背景颜色（用于切换黑暗模式）
        /// </summary>
        public SolidColorBrush BgColor
        {
            get { return bgColor; }
            set { bgColor = value; RaisePropertyChanged(); }
        }

        private SolidColorBrush fontColor;
        /// <summary>
        /// 字体颜色（用于切换黑暗模式）
        /// </summary>
        public SolidColorBrush FontColor
        {
            get { return fontColor; }
            set { fontColor = value; RaisePropertyChanged(); }
        }

        private ImageSource btnImage;
        /// <summary>
        /// 按钮图片（太阳/月亮）切换
        /// </summary>
        public ImageSource BtnImage
        {
            get { return btnImage; }
            set { btnImage = value; RaisePropertyChanged(); }
        }

        private bool isTopmost;
        /// <summary>
        /// 置顶
        /// </summary>
        public bool IsTopmost
        {
            get { return isTopmost; }
            set { isTopmost = value; RaisePropertyChanged(); }
        }

        private Visibility topmostVis;
        /// <summary>
        /// 置顶标志显示
        /// </summary>
        public Visibility TopmostVis
        {
            get { return topmostVis; }
            set { topmostVis = value;RaisePropertyChanged(); }
        }

        private bool popIsOpen;
        /// <summary>
        /// popup控件显示与否
        /// </summary>
        public bool PopIsOpen
        {
            get { return popIsOpen; }
            set { popIsOpen = value; RaisePropertyChanged(); }
        }

        #endregion

        public MainViewModel()
        {
            SearchResultList = FileFactory.CreatCar("Excel").Get();
            LnkDataList = FileFactory.CreatCar("LNK").Get();
            DockWidth = LnkDataList.Count * 53 + 40;
            SplitDockVis=Visibility.Collapsed;
        }
        //打开选中的快捷方式
        public ICommand OpenLnkDataCommand => new RelayCommand<int>(t => OpenLnkData(t));
        //打开选中的文件
        public ICommand OpenResultDataCommand => new RelayCommand<int>(t => OpenResultData(t));
        //查找文件夹中所有文件
        public ICommand SearchAllFileCommand => new RelayCommand(SearchAllFile);
        //查找~~PPT文件
        public ICommand SearchPPtFileCommand => new RelayCommand(SearchPPTFile);
        //查找~~Word文件
        public ICommand SearchWordFileCommand => new RelayCommand(SearchWordFile);
        //查找~~Excel文件
        public ICommand SearchExcelFileCommand => new RelayCommand(SearchExcelFile);
        //模糊查询文件夹下文件
        public ICommand TextChangedCommand => new RelayCommand<string>(t => TextChanged(t));

        #region 方法
        private void SearchAllFile() => Search("All");
        private void SearchPPTFile() => Search("PPT");
        private void SearchWordFile() => Search("Word");
        private void SearchExcelFile() => Search("Excel");
        private void Search(string fileType)
        {
            //SearchResultList.Clear();
            popIsOpen = false;
            SearchResultList = FileFactory.CreatCar(fileType).Get();
            PopIsOpen = true;
        }
        private void TextChanged(string text)
        {
            if(text!=string.Empty||text!= "请输入想要查询的文件名......")
            {
                SearchResultList = FileFactory.CreatCar("All").Get().Where(t=>t.FileName.Contains(text)).ToList();
                PopIsOpen = true;
            }
        }
        private void OpenLnkData(int select)
        {
            Process.Start(LnkDataList.Skip(select).First().PathInfo);
            LnkDataList.Where(t => t.PathInfo == LnkDataList.Skip(select).First().PathInfo).ToList().ForEach(t => t.UseCount++);
            UsualDataList=LnkDataList.Where(t=>t.UseCount>0).OrderByDescending(t => t.UseCount).Take(3).ToList();
            //DockWidth = 1;
            DockWidth = (LnkDataList.Count+ UsualDataList.Count)* 53 + 50;
            SplitDockVis=Visibility.Visible;
            // UsualDataList = 
        }
        private void OpenResultData(int select)
        {
            Process.Start(searchResultList.Skip(select).First().PathInfo);
            popIsOpen=false;
        }
        #endregion
    }
}