﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoTest
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        /// <summary>
        /// データベース更新
        /// </summary>
        private void ReadDatabase()
        {
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<ToDo>();
                ToDoDataView.ItemsSource = connection.Table<ToDo>().ToList();
            }
        }



        /// <summary>
        /// 追加処理
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var f = new SaveWindow(null);
            f.ShowDialog();
            ReadDatabase();
        }

        /// <summary>
        /// 編集処理
        /// </summary>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var item = ToDoDataView.SelectedItem as ToDo;
            if (item == null)
            {
                MessageBox.Show("Please Select a Row");
                return;
            }

            var f = new SaveWindow(item);
            f.ShowDialog();
            ReadDatabase();
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var item = ToDoDataView.SelectedItem as ToDo;
            if (item == null)
            {
                MessageBox.Show("Please Select a Row");
                return;
            }

            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<ToDo>();
                connection.Delete(item);
                ReadDatabase();
            }
        }


        /// <summary>
        /// 完了済みタスク消去
        /// </summary>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            var item = ToDoDataView.Items[index] as ToDo;

            while (item != null)
            {

                if (item.Done == true) {

                    using (var connection = new SQLiteConnection(App.DatabasePath))
                    {
                        connection.Delete(item);
                    }
                }

                index += 1;
                item = ToDoDataView.Items[index] as ToDo;

            }

            ReadDatabase();
        }



        #region デバッグ用
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete all ToDo?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Error);

            if (result == MessageBoxResult.Yes)
            {
                using (var connection = new SQLiteConnection(App.DatabasePath))
                {
                    connection.DeleteAll<ToDo>();
                }
                ReadDatabase();
            }

        }

        private void CreateTaskForDebug_Click(object sender, RoutedEventArgs e)
        {
            string testN = "sato";
            string testD = DateTime.Now.ToString();

            for (int i = 0; i < 10; i++) {
                using (var connection = new SQLiteConnection(App.DatabasePath))
                {
                    connection.Insert(new ToDo(testN, testD, testD, testD, i.ToString()));
                }
            }
            ReadDatabase();
        }

        #endregion
    }
}
