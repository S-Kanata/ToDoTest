using SQLite;
using System;
using System.Collections.Generic;
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

        public ToDo(string name)
        {
            Name = name;
        }

        public ToDo(int id, string name, string date)
        {
            ID = id;
            Name = name;
            Date = date;
        }
        public ToDo(string name, string date)
        {
            Name = name;
            Date = date;
        }

        #endregion

        /// <summary>
        /// 要素
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
    }
}
