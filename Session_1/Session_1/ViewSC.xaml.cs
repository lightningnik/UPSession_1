using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ViewSC.xaml
    /// </summary>
    public partial class ViewSC : Page
    {
        public ViewSC()
        {
            InitializeComponent();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string SearchSC = "SELECT shop_center_name AS [Название тогового центра], status AS Статус, count_pavilions AS [Количество павильонов], " +
                " floor AS Этажи, var_coefficient AS [Коэффициент стоимости], city AS Город, price AS Стоимость, image " +
                " FROM dbo.Shoping_Center WHERE shop_center_id = @id_SC"; // Из какой таблицы нужен вывод 

            SqlCommand command = new SqlCommand(SearchSC, Manager.connection);
            SqlParameter Search_param = new SqlParameter("@id_SC", Search.Text);
            command.Parameters.Add(Search_param);
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[6]);

                data[data.Count - 1][0] = reader.GetString(0);
                data[data.Count - 1][1] = reader.GetString(1);
                reader.GetInt32(2);
                reader.GetInt32(3);
                reader.GetDouble(4);
                data[data.Count - 1][5] = reader.GetString(5);
                reader.GetDecimal(6);
                byte[] imageBytes = (byte[])reader[7];
                MemoryStream ms = new MemoryStream();
                ms.Write(imageBytes, 0, imageBytes.Length);
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = ms;
                bmp.EndInit();


                testImage.Source = bmp;
            }
            reader.Close();
            MessageBox.Show("Вывод картинки");
            Manager.connection.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PavilionMainPage());
        }
    }
}
