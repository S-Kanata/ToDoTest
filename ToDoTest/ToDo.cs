using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTest
{
    public class ToDo
    {

        #region コンストラクタ
        public ToDo()
        {
        }

        public ToDo(bool done)
        {
            Done = done;
        }

        public ToDo(int id)
        {
            ID = id;
        }
        public ToDo(string name, string date)
        {
            Name = name;
            Date = date;
        }
        public ToDo(string name, string date, string createdTime, string updatedTime, string priority)
        {
            Name = name;
            Date = date;
            CreatedTime = createdTime;
            UpdatedTime = updatedTime;
            Priority = priority;
        }
        public ToDo(int id, string name, string date, string createdTime, string updatedTime, string priority)
        {
            ID = id;
            Name = name;
            Date = date;
            CreatedTime = createdTime;
            UpdatedTime = updatedTime;
            Priority = priority;
        }

        #endregion


        #region プロパティ
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Priority{ get; set; }
        public string UpdatedTime { get; set; }
        public string CreatedTime { get; set; }
        public bool Done { get; set; }
        #endregion
    }
}
