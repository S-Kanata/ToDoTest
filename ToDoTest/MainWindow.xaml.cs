using SQLite;
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


        private void ReadDatabase()
        {
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<ToDo>();
                ToDoDataView.ItemsSource = connection.Table<ToDo>().ToList();
            }
        }


        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A function is not set yet.");
        }
    }
}
