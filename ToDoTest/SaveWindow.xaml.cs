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
using System.Windows.Shapes;

namespace ToDoTest
{
    /// <summary>
    /// SaveWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SaveWindow : Window
    {
        private ToDo _ToDo;
        public SaveWindow(ToDo ToDo)
        {
            InitializeComponent();

            _ToDo = ToDo;

            if (ToDo != null)
            {
                this.NameTextBox.Text = ToDo.Name;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Trim().Length < 1)
            {
                MessageBox.Show("Please submit the name");
                return;
            }

            if (DateSelecter.SelectedDate == null)
            {
                MessageBox.Show("Please select the date");
                return;
            }

            string _datetime = DateSelecter.SelectedDate.ToString();

            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<ToDo>();
                if (_ToDo == null)
                {
                    connection.Insert(new ToDo(NameTextBox.Text, _datetime));
                }
                else
                {
                    connection.Update(new ToDo(_ToDo.ID, NameTextBox.Text, _datetime));
                }

                Close();
            }
        }
    }
}
