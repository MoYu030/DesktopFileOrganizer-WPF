using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Drawing;
using IWshRuntimeLibrary;
using System.Collections.ObjectModel;

namespace DesktopFileOrganizer.Models
{
    internal abstract class FileManager
    {
        public abstract List<FileInfoModel> Get();
        //文件夹下所有文件
        List<FileInfoModel> foldList = new List<FileInfoModel>();
        //按后缀名筛选过后的文件
        List<FileInfoModel> resultList = new List<FileInfoModel>();
        public List<FileInfoModel> GetFiles(string[] typeArray, bool isAll = false)
        {
            string filePath = @"E:\MyProgram\Applications";
            foldList = SearchFile(filePath);
            if (!isAll)
            {
                resultList.Clear();
                foreach (var type in typeArray)
                {
                    foreach (var file in foldList.Where(t => t.PathInfo.Contains(type)))
                    {
                        resultList.Add(file);
                    }
                }
                foldList = resultList;
            }
            return foldList;
        }
        /// <summary>
        /// 搜索指定文件夹中的所有文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private List<FileInfoModel> SearchFile(string filePath)
        {
            List<FileInfoModel> filesPathList = new List<FileInfoModel>();
            DirectoryInfo folder = new DirectoryInfo(filePath);
            foreach (var file in folder.GetFileSystemInfos())
            {
                if (file.FullName.Contains("."))
                    filesPathList.Add(new FileInfoModel
                    {
                        FileName = file.Name,
                        PathInfo = file.FullName,
                        UseCount = 0,
                        IconSource = file.FullName.EndsWith(".lnk") ? GetIcon(file.FullName) : default
                    }) ; 
                else
                    foreach(var file2 in SearchFile(file.FullName))
                        filesPathList.Add(new FileInfoModel
                        {
                            FileName = file2.FileName,
                            PathInfo = file2.PathInfo,
                            UseCount = 0,
                            IconSource = file2.IconSource
                        });
            }
            return filesPathList;
        }
        /// <summary>
        /// 获取快捷方式图标
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private ImageSource GetIcon(string filePath)
        {
            if (filePath.EndsWith(".lnk"))
            {
                WshShell shell = new WshShell();
                IWshShortcut appShortcut = (IWshShortcut)shell.CreateShortcut(filePath);
                filePath = appShortcut.TargetPath;
            }
            if (System.IO.File.Exists(filePath))
            {
                Icon icon = Icon.ExtractAssociatedIcon(filePath);
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icon.Handle, new Int32Rect(0, 0, icon.Width, icon.Height), BitmapSizeOptions.FromEmptyOptions());
            }
            else if (System.IO.File.Exists(filePath.Replace(" (x86)", "")))
            {
                Icon icon = Icon.ExtractAssociatedIcon(filePath.Replace(" (x86)", ""));
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icon.Handle, new Int32Rect(0, 0, icon.Width, icon.Height), BitmapSizeOptions.FromEmptyOptions());
            }
            else
            {
                return null;
            }
        }
    }
}
