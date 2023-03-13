using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesktopFileOrganizer.Models
{
    public class FileInfoModel
    {
        private string fileName;
        /// <summary>
        /// 程序名称
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private ImageSource iconSource;

        public ImageSource IconSource
        {
            get { return iconSource; }
            set { iconSource = value; }
        }

        private string pathsInfo;
        /// <summary>
        /// 文件路径
        /// </summary>
        public string PathInfo
        {
            get { return pathsInfo; }
            set { pathsInfo = value; }
        }

        private int useCount;
        /// <summary>
        /// 使用次数
        /// </summary>
        public int UseCount
        {
            get { return useCount; }
            set { useCount = value; }
        }

    }
}
