using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for SqlWindow.xaml
    /// </summary>
    public partial class SqlWindow : Window
    {
        public SqlWindow()
        {
            InitializeComponent();
        }
        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //string connectionString = "Trusted_Connection=True;";
                string connectionString = "user id = PxlUser_03;";
                connectionString += "Password = DDE1Zb2!;";
                connectionString += $@"Server={serverTextBox.Text};";
                connectionString += $"Database={dataBaseTextBox.Text}";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
                MessageBox.Show("connection ok!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Wordt momenteel niet opgeroepen, moet deze bovenstaande buttonclick vervangen?
        private SqlConnection GetConnection()
        {
            SqlConnection conn;
            try
            {
                //string connectionString = "Trusted_Connection=True;";
                string connectionString = "user id = PxlUser_03;";
                connectionString += "Password = DDE1Zb2!;";
                connectionString += $@"Server={serverTextBox.Text};";
                connectionString += $"Database={dataBaseTextBox.Text}";
                conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void getDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cmd = $"Select * from {tableTextBox.Text}";
                SqlCommand sql = new SqlCommand(cmd, GetConnection());
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataTable dt = new DataTable();
                da.Fill(dt);
                sqlDataGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuStudent_Click(object sender, RoutedEventArgs e)
        {
            var studentWindow = new StudentWindow();
            studentWindow.Show();
        }
    }
}
