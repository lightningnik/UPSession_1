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
    public partial class SCMainPage : Page
    {
        public SCMainPage()
        {
            InitializeComponent();
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string cmd = "SELECT shop_center_name AS [Название тогового центра], status AS Статус, count_pavilions AS [Количество павильонов], " +
                "floor AS Этажи, var_coefficient AS [Коэффициент стоимости], city AS Город, price AS Стоимость " +
                "FROM dbo.Shoping_Center"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Shoping_Center"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGridView.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        private void Add_SC_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Add_SC());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Manager_C());
        }

        private void Remove_SC_Click(object sender, RoutedEventArgs e)
        {
            if (SC_Text.Text == "")
            {
                Notify.Content = "Пожалуйста, заполните поле для удаления!!!";
            }
            else
            {
                try
                {
                    Manager.connection.Open();
                    string Delete = "DELETE FROM Pavilions WHERE shop_center_name = (@shop_center_name)";
                    SqlCommand cmd = new SqlCommand(Delete, Manager.connection);
                    SqlParameter Delete_param = new SqlParameter("@shop_center_name", SC_Text.Text);
                    cmd.Parameters.Add(Delete_param);
                    cmd.ExecuteNonQuery();
                    Notify.Content = "Торговый центр удален!!!";
                }
                catch
                {

                    Notify.Content = "Невозможно удалить торговый центр";
                }
                Manager.connection.Close();
            }
        }

        private void ViewSC_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string SearchSC = "SELECT shop_center_name, image " +
                " FROM dbo.Shoping_Center WHERE shop_center_name = @name_SC"; // Из какой таблицы нужен вывод 

            SqlCommand command = new SqlCommand(SearchSC, Manager.connection);
            SqlParameter Search_param = new SqlParameter("@name_SC", SC_Text.Text);
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

        private void paybackSC_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string sqlExpression = "EXEC PaybackProcedure";
                Manager.connection.Open();
                SqlCommand createCommand = new SqlCommand(sqlExpression, Manager.connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("PaybackProcedure"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                DataGridView.ItemsSource = dt.DefaultView; // Сам вывод 
                Manager.connection.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
                Notify.Content = "Пожалуйста, проверьте вводимые данные!!!";
            }
            Manager.connection.Close();
        }
    }
}
