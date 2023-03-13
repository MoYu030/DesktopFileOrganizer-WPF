using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFileOrganizer.Models
{
    internal class FileFactory
    {
        public static FileManager CreatCar(string fileType)
        {
            FileManager manager;
            switch (fileType) 
            {
                case "Word":
                    manager = new Word();
                    break;
                case "Excel":
                     manager = new Excel();
                    break;
                case "PPT":
                      manager = new PPT();
                    break;
                case "LNK":
                    manager = new Lnk();
                    break;
                default:
                    manager = new All();
                    break;
            }
            return  manager;
        }
    }

     class Word : FileManager
    {
        public override List<FileInfoModel> Get()
        {

           return GetFiles(InitData.GetInstance().GetSuffixList("Word")) ;
        }
    }

    class PPT : FileManager
    {
        public override List<FileInfoModel> Get()
        {
            return GetFiles(InitData.GetInstance().GetSuffixList("PPT"));
        }
    }

    class Excel : FileManager
    {
        public override List<FileInfoModel> Get()
        {
            return GetFiles(InitData.GetInstance().GetSuffixList("Excel"));
        }
    }

    class Lnk : FileManager
    {
        public override List<FileInfoModel> Get()
        {
            return GetFiles(new string[] {".lnk"});
        }
    }

    class All : FileManager
    {
        public override List<FileInfoModel> Get()
        {
            return GetFiles(InitData.GetInstance().GetSuffixList("All"),true);
        }
    }
}
