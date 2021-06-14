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

namespace Session_1
{
    /// <summary>
    /// Логика взаимодействия для RentorsPage.xaml
    /// </summary>
    public partial class RentorsPage : Page
    {
        public RentorsPage()
        {
            InitializeComponent();
        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            if (Name.Text == "" || Phone.Text == "" || City.Text == "" || Street.Text == "" || Field_Of_activity.Text == "" || License.Text == "")
            {
                NotifyRectangle.Fill = Brushes.Red;
                Notify.Content = "Пожалуйста, заполните все поля!!!";
            }
            else
            {
                try
                {
                    Manager.connection.Open();
                    string registration = "insert into Rentors VALUES(@Name_value, @Phone_value, @City_value, @Street_value, @Field_Of_activity_value, @License_value)";
                    SqlCommand cmd = new SqlCommand(registration, Manager.connection);
                    SqlParameter Name_param = new SqlParameter("@Name_value", Name.Text);
                    cmd.Parameters.Add(Name_param);
                    SqlParameter Phone_param = new SqlParameter("@Phone_value", Phone.Text);
                    cmd.Parameters.Add(Phone_param);
                    SqlParameter City_param = new SqlParameter("@City_value", City.Text);
                    cmd.Parameters.Add(City_param);
                    SqlParameter Street_param = new SqlParameter("@Street_value", Street.Text);
                    cmd.Parameters.Add(Street_param);
                    SqlParameter Field_Of_activity_param = new SqlParameter("@Field_Of_activity_value", Field_Of_activity.Text);
                    cmd.Parameters.Add(Field_Of_activity_param);
                    SqlParameter License_param = new SqlParameter("@License_value", License.Text);
                    cmd.Parameters.Add(License_param);
                    cmd.ExecuteNonQuery();
                    NotifyRectangle.Fill = Brushes.Green;
                    Notify.Content = "Арендатор добавлен!!!";
                }
                catch (SqlException err)
                {
                    NotifyRectangle.Fill = Brushes.Red;
                    MessageBox.Show(err.Message);
                    Notify.Content = "Введите корректные данные!!!";
                }
                Manager.connection.Close();
            }
        }

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string cmd = "SELECT Name AS Название, Phone AS [Номер телефона], City AS [Город], Street AS Улица, " +
                "Field_Of_activity AS [Область деятельности], License AS Лицензия FROM dbo.Rentors"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Rentors"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGridView.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Manager_C());
        }
    }
}
