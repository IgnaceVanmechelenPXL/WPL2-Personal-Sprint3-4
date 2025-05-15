using ClassLibTeam03.Business;
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

namespace WpfTeam03
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            studentDataGrid.ItemsSource = null;
            studentDataGrid.ItemsSource = Students.List();
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            stackNewStudent.Visibility = Visibility.Hidden;
        }
        private void mnuNewStudent_Click(object sender, RoutedEventArgs e)
        {
            stackNewStudent.Visibility = Visibility.Visible;
        }
        private void mnuSql_Click(object sender, RoutedEventArgs e)
        {
            var sqlWindow = new SqlWindow();
            sqlWindow.ShowDialog();
        }

        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (firstNameTextBox.Text.Length > 0 && lastNameTextBox.Text.Length > 0)
            {
                Students.Add(firstNameTextBox.Text, lastNameTextBox.Text);
                LoadData();
                stackNewStudent.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Incorrect data!");
            }
        }

    }
}
