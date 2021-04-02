using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace autorizazia_wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            String login = box_login.Text;
            String password = box_pass.Password;

            db db = new db();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            

            
                MySqlCommand command = new MySqlCommand("SELECT * FROM `Users` WHERE `login` = @uL AND `password` = @uP", db.GetConn());

                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;



                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Вход прошел успешно");
                    box_login.ToolTip = "";
                    box_login.Background = Brushes.Transparent;
                    box_pass.ToolTip = "";
                    box_pass.Background = Brushes.Transparent;
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                
                

                
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            registr window=new registr ();
            window.Show();
            this.Close();
        }
    }
}   
    
