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
            LoadComboBox();
            _ToDo = ToDo;

            if (ToDo != null)
            {
                this.NameTextBox.Text = ToDo.Name;

                DateTime dateTime = DateTime.Parse(ToDo.Date);
                this.DateSelecter.SelectedDate = dateTime;

                this.PriorityBox.SelectedItem = ToDo.Priority;
            }
        }

        private void LoadComboBox()
        {
            PriorityBox.Items.Add("A");
            PriorityBox.Items.Add("B");
            PriorityBox.Items.Add("C");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (NameTextBox.Text.Trim().Length < 1)
            {
                MessageBox.Show("Please enter the name");
                return;
            }

            if (DateSelecter.SelectedDate == null)
            {
                MessageBox.Show("Please select the date");
                return;
            }

            if (PriorityBox.SelectedItem == null)
            {
                MessageBox.Show("Please select the priority");
                return;
            }

            string _datetime = DateSelecter.SelectedDate.ToString();
            string _nowtime = DateTime.Now.ToString();
            string _priority = PriorityBox.SelectedItem.ToString();

            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
               
                if (_ToDo == null)
                {
                    connection.Insert(new ToDo(NameTextBox.Text, _datetime, _nowtime, _nowtime, _priority));
                }
                else
                {
                    connection.Update(new ToDo(_ToDo.ID, NameTextBox.Text, _datetime, _ToDo.CreatedTime, _nowtime, _priority));
                }

                Close();
            }
        }
    }
}
