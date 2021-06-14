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
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace Session_1
{
    /// <summary>
    /// Логика взаимодействия для Authrorization.xaml
    /// </summary>
    public partial class Authrorization : Page
    {
        private string capchastr = "";
        private int countlogin = 0;
        public Authrorization()
        {
            InitializeComponent();
            textBox_login.Text = "Elizor@gmai.com";
            password.Password = "yntiRS";
        }

        private void Authorization_Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (capchastr == CapchaUser.Text)
            {
                Manager.connection.Open();

                string authorization = String.Format("SELECT role, login, password FROM [dbo].[Employees] WHERE [login] = @login_value AND [password] = @passwd_value");
                SqlCommand command = new SqlCommand(authorization, Manager.connection);
                SqlParameter login_param = new SqlParameter("@login_value", textBox_login.Text);
                command.Parameters.Add(login_param);
                SqlParameter passwd_param = new SqlParameter("@passwd_value", password.Password);
                command.Parameters.Add(passwd_param);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Manager.myrole = Convert.ToString(reader.GetValue(0));
                }

                if (reader.HasRows) // если такая запись существует       
                {
                    Manager.MainFrame.Navigate(new Manager_C());
                }
                else
                {
                    if (countlogin != 3)
                    {
                        countlogin += 1;
                    }
                    else
                    {
                        Capcha.Visibility = Visibility.Visible;
                        CapchaUser.Visibility = Visibility.Visible;
                        GenerationCapcha();
                    }
                }
            }
            else
            {
                GenerationCapcha();
                textBox_login.Text = String.Empty;
                password.Password = String.Empty;
                CapchaUser.Text = String.Empty;
            }
            Manager.connection.Close();

        }
        private void GenerationCapcha()
        {
            Random rnd = new Random();
            capchastr = "";
            for (int i = 0; i < 5; i++)
            {
                char newchar = (char)(rnd.Next(48, 57) + rnd.Next(8, 25) + rnd.Next(7, 25));
                capchastr += newchar;
            }
            Capcha.Text = capchastr;
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            GenerationCapcha();
        }
    }
}
