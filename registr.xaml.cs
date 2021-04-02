using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Media;

namespace autorizazia_wpf
{
  
    public partial class registr : Window
    {
        public registr()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            String login = box_login.Text;
            String password = box_pass.Password;
            String password2 = box_pass_2.Password;

            

            if (password == password2)
            {
                db db = new db();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("  INSERT INTO `Users` (`id`, `login`, `password`) VALUES(NULL, @uL, @uP)", db.GetConn());
                
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                MessageBox.Show("Регистрация прошла успешно");
            }
            else
            {
                box_pass.ToolTip = "Поле введено не верно";
                box_pass_2.Background = Brushes.Red;
                MessageBox.Show("Пароли не совпадают");
            }

            if (login.Length < 5)
            {
                box_login.ToolTip = "Поле введено не верно";
                box_login.Background = Brushes.Red;
            }
            else if (password.Length < 1)
            {
                box_pass.ToolTip = "Поле введено не верно";
                box_pass.Background = Brushes.Red;
            }
            else
            {
                box_login.ToolTip = "";
                box_login.Background = Brushes.Transparent;
                box_pass.ToolTip = "";
                box_pass.Background = Brushes.Transparent;

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();


            window.Show();
            this.Close();


        }

       
    } 
}

