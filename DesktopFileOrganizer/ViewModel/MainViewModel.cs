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
        /// Dockl���е�APP
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
        /// Dock�������ʹ�õ�app
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
        /// ���������ļ�
        /// </summary>
        public List<FileInfoModel> SearchResultList
        {
            get { return searchResultList; }
            set { searchResultList = value;RaisePropertyChanged(); }
        }

        private int dockWidth;
        /// <summary>
        /// dock�����
        /// </summary>
        public int DockWidth
        {
            get { return dockWidth; }
            set { dockWidth = value;RaisePropertyChanged(); }
        }

        private Visibility menuVis;
        /// <summary>
        /// ���Ʋ˵��б����ʾ
        /// </summary>
        public Visibility MenuVis
        {
            get { return menuVis; }
            set { menuVis = value; RaisePropertyChanged(); }
        }

        private Visibility searchFileVis;
        /// <summary>
        /// ���������ļ�����ʾ
        /// </summary>
        public Visibility SearchFileVis
        {
            get { return searchFileVis; }
            set { searchFileVis = value;RaisePropertyChanged(); }
        }

        private Visibility splitDockVis;
        /// <summary>
        /// Ӧ���볣��Ӧ�÷ָ���
        /// </summary>
        public Visibility SplitDockVis
        {
            get { return splitDockVis; }
            set { splitDockVis = value; RaisePropertyChanged(); }
        }

        private SolidColorBrush bgColor;
        /// <summary>
        /// ������ɫ�������л��ڰ�ģʽ��
        /// </summary>
        public SolidColorBrush BgColor
        {
            get { return bgColor; }
            set { bgColor = value; RaisePropertyChanged(); }
        }

        private SolidColorBrush fontColor;
        /// <summary>
        /// ������ɫ�������л��ڰ�ģʽ��
        /// </summary>
        public SolidColorBrush FontColor
        {
            get { return fontColor; }
            set { fontColor = value; RaisePropertyChanged(); }
        }

        private ImageSource btnImage;
        /// <summary>
        /// ��ťͼƬ��̫��/�������л�
        /// </summary>
        public ImageSource BtnImage
        {
            get { return btnImage; }
            set { btnImage = value; RaisePropertyChanged(); }
        }

        private bool isTopmost;
        /// <summary>
        /// �ö�
        /// </summary>
        public bool IsTopmost
        {
            get { return isTopmost; }
            set { isTopmost = value; RaisePropertyChanged(); }
        }

        private Visibility topmostVis;
        /// <summary>
        /// �ö���־��ʾ
        /// </summary>
        public Visibility TopmostVis
        {
            get { return topmostVis; }
            set { topmostVis = value;RaisePropertyChanged(); }
        }

        private bool popIsOpen;
        /// <summary>
        /// popup�ؼ���ʾ���
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
        //��ѡ�еĿ�ݷ�ʽ
        public ICommand OpenLnkDataCommand => new RelayCommand<int>(t => OpenLnkData(t));
        //��ѡ�е��ļ�
        public ICommand OpenResultDataCommand => new RelayCommand<int>(t => OpenResultData(t));
        //�����ļ����������ļ�
        public ICommand SearchAllFileCommand => new RelayCommand(SearchAllFile);
        //����~~PPT�ļ�
        public ICommand SearchPPtFileCommand => new RelayCommand(SearchPPTFile);
        //����~~Word�ļ�
        public ICommand SearchWordFileCommand => new RelayCommand(SearchWordFile);
        //����~~Excel�ļ�
        public ICommand SearchExcelFileCommand => new RelayCommand(SearchExcelFile);
        //ģ����ѯ�ļ������ļ�
        public ICommand TextChangedCommand => new RelayCommand<string>(t => TextChanged(t));

        #region ����
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
            if(text!=string.Empty||text!= "��������Ҫ��ѯ���ļ���......")
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