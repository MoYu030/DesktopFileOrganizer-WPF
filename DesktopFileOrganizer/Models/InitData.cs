using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFileOrganizer.Models
{
    internal class InitData
    {
        private static InitData _InitData = new InitData(); 
        public InitData()
        {
            
            InitSuffixList();
            InitTodoData();
        }
        public static InitData GetInstance()
        {
            return _InitData;
        }
        public string GetTodo()
        {
            string content = "";
            var data = list.Where(t => t.time < DateTime.Now && t.isRemind == false).ToList();
            if (data.Count>0)
            {
                content = data.First().job;
                int id = data.First().Id;
                list.Where(t => t.Id==id).ToList().ForEach(t => t.isRemind = true);
            }
            return content;
        }
        public string[] GetSuffixList(string key) => suffixList[key];

        Dictionary<string, string[]> suffixList;
        private void InitSuffixList()
        {
            suffixList = new Dictionary<string, string[]>
            {
                {"Excel",new string[] { ".xlsx", ".xls" }},
                {"PPT",new string[] { ".ppt", ".pptx" }},
                {"Word",new string[] { ".doc", ".docx" } },
                {"All",new string[] { "null" } }
            };
        }

        struct ToDolnfo
        {
            public int Id;
            public string job;
            public DateTime time;
            public bool isRemind;
        }
        List<ToDolnfo> list;
        private void InitTodoData()
        {
            list = new List<ToDolnfo>();
            list.Add(new ToDolnfo() { Id = 1, isRemind = false, time = DateTime.Now.Date.AddHours(8), job = "待办事项1" });
            list.Add(new ToDolnfo() { Id = 2, isRemind = false, time = DateTime.Now.Date.AddHours(8), job = "待办事项2" });
            list.Add(new ToDolnfo() { Id = 3, isRemind = false, time = DateTime.Now.Date.AddHours(9), job = "待办事项3" });
            list.Add(new ToDolnfo() { Id = 4, isRemind = false, time = DateTime.Now.Date.AddHours(20), job = "待办事项4" });
            list.Add(new ToDolnfo() { Id = 5, isRemind = false, time = DateTime.Now.Date.AddHours(21), job = "待办事项5" });
            list.Add(new ToDolnfo() { Id = 6, isRemind = false, time = DateTime.Now.Date.AddHours(22), job = "待办事项6" });
            list.Add(new ToDolnfo() { Id = 7, isRemind = false, time = DateTime.Now.Date.AddHours(23), job = "待办事项7" });
            list.Add(new ToDolnfo() { Id = 8, isRemind = false, time = DateTime.Now.Date.AddHours(24), job = "待办事项8" });
        }
    }
}
