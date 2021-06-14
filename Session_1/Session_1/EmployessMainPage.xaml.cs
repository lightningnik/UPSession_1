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
using System.IO;

namespace Session_1
{
    /// <summary>
    /// Логика взаимодействия для SCMainPage.xaml
    /// </summary>
    public partial class EmployessMainPage : Page
    {
        public EmployessMainPage()
        {
            InitializeComponent();
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string cmd = "SELECT surname_employee AS Фамилия, name_employee AS Имя, " +
                "mid_name_employee AS Отчество, " +
                "phone AS [Номер телефона], gender AS Пол," +
                "role AS Роль " +
                "FROM dbo.Employees WHERE role != 'Удален'"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Employees"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGridView.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        private void Add_Emp_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEmp());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmployessMainPage());
        }

        private void Remove_Emp_Click(object sender, RoutedEventArgs e)
        {
            if (Remove_Emp_Text.Text == "")
            {
                Notify.Content = "Пожалуйста, заполните поле для удаления!!!";
            }
            else
            {
                try
                {
                    Manager.connection.Open();
                    string Delete = "DELETE FROM Employees WHERE surname_employee = (@surname_employee)";
                    SqlCommand cmd = new SqlCommand(Delete, Manager.connection);
                    SqlParameter Delete_param = new SqlParameter("@surname_employee", Remove_Emp_Text.Text);
                    cmd.Parameters.Add(Delete_param);
                    cmd.ExecuteNonQuery();
                    Notify.Content = "Пользователь удален!!!";
                }
                catch
                {

                    Notify.Content = "Невозможно удалить Пользователя";
                }
                Manager.connection.Close();
            }
        }

        private void ViewEmp_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string SearchSC = "SELECT surname_employee, photo " +
                " FROM dbo.Employees WHERE surname_employee = @surname_employee"; // Из какой таблицы нужен вывод 

            SqlCommand command = new SqlCommand(SearchSC, Manager.connection);
            SqlParameter Search_param = new SqlParameter("@surname_employee", Search.Text);
            command.Parameters.Add(Search_param);
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                byte[] imageBytes = (byte[])reader[1];
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    testImage.Source = image;
                }
            }
            reader.Close();
            Manager.connection.Close();
        }


    }
}
