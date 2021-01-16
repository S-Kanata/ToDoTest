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

        ///<summary>
        ///Raise a PropertyChanged
        ///<summary>


        #region コンストラクタ
        public ToDo()
        {
        }

        public ToDo(string updatedTime)
        {
            UpdatedTime = updatedTime;
        }
        public ToDo(string name, string date)
        {
            Name = name;
            Date = date;
        }
        public ToDo(string name, string date, string createdTime, string updatedTime)
        {
            Name = name;
            Date = date;
            CreatedTime = createdTime;
            UpdatedTime = updatedTime;
        }
        public ToDo(int id, string name, string date, string createdTime, string updatedTime)
        {
            ID = id;
            Name = name;
            Date = date;
            CreatedTime = createdTime;
            UpdatedTime = updatedTime;
        }

        #endregion


        #region プロパティ
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string UpdatedTime { get; set; }
        public string CreatedTime { get; set; }
        #endregion
    }
}
