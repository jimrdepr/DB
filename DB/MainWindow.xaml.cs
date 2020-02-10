using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace DB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;

        /* Description: Main window. Initializes the main window and connects to the employee database
         * 
         * Results: The main window is initializd and connected.
         */
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jrd10\Documents\Database.accdb");
        }

        /* Description: The button implimentation for the assets. Prints out all data from the assets table.
         * 
         * Results: The assets table has been printed out.
         */
        private void SeeAssets_Click(object sender, RoutedEventArgs e)
        {
            string query = "select EmployeeID, AssetID, Description, * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read["EmployeeID"].ToString() + " ";
                data += read["AssetID"].ToString() + " ";
                data += read["Description"].ToString() + "\n";
            }
            TextArea.Text = data;
            cn.Close();
        }

        /* Description: The button implimentation for the employees. Prints out all data from the employees table.
         * 
         * Results: The employees table has been printed out
         */
        private void SeeEmployees_Click(object sender, RoutedEventArgs e)
        {
            string query = "select EmployeeID, LastName, FirstName, * from Employee";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read["EmployeeID"].ToString() + " ";
                data += read["LastName"].ToString() + " ";
                data += read["FirstName"].ToString() + "\n";
            }
            TextArea.Text = data;
            cn.Close();
        }
    }
}
