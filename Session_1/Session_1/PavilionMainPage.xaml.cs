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

namespace Session_1
{
    /// <summary>
    /// Логика взаимодействия для PavilionMainPage.xaml
    /// </summary>
    public partial class PavilionMainPage : Page
    {
        public PavilionMainPage()
        {
            InitializeComponent();
        }

        private void View_Pavilion_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string cmd = "SELECT dbo.Shoping_Center.shop_center_name AS [Название торгового центра], dbo.Shoping_Center.status AS [Статус торгового центра], dbo.Pavilions.floor AS Этаж, " +
                "dbo.Pavilions.area AS [Площадь павильона], dbo.Pavilions.status AS [Статус павильона], dbo.Pavilions.var_coefficient AS [кдс], " +
                "dbo.Pavilions.price_metr AS [Цена за метр] FROM Pavilions INNER JOIN " +
                "dbo.Shoping_Center ON id_shop_center = Shoping_Center.shop_center_id"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Pavilions"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGridView.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        private void Add_Pavilion_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Add_Pavilion());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Manager_C());
        }

       
        private void Remove_Pavilion_Click(object sender, RoutedEventArgs e)
        {
            if (Remove_Pavilion_Text.Text == "")
            {
                Notify.Content = "Пожалуйста, заполните поле для удаления!!!";
            }
            else
            {
                try
                {
                    Manager.connection.Open();
                    string Delete = "DELETE FROM Pavilions WHERE id_pavilion = (@id_pavilion)";
                    SqlCommand cmd = new SqlCommand(Delete, Manager.connection);
                    SqlParameter Delete_param = new SqlParameter("@id_pavilion", Remove_Pavilion_Text.Text);
                    cmd.Parameters.Add(Delete_param);
                    cmd.ExecuteNonQuery();
                    Notify.Content = "Павильон удален!!!";
                }
                catch 
                {

                    Notify.Content = "Невозможно удалить павильон";
                }
                Manager.connection.Close();
            }
        }

        private void status_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Status_Search.Text != "")
                {
                    Manager.connection.Open();
                    string Search = "SELECT floor, status, area, price_metr, var_coefficient " +
                    "FROM Pavilions WHERE status = @status_value";
                    SqlCommand cmd = new SqlCommand(Search, Manager.connection);
                    SqlParameter Search_param = new SqlParameter("@status_value", Status_Search.Text);
                    cmd.Parameters.Add(Search_param);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Pavilions"); // В скобках указываем название таблицы
                    dataAdp.Fill(dt);
                    DataGridView.ItemsSource = dt.DefaultView; // Сам вывод 
                }
                else Notify.Content = "Заполните поле поиска по статусу!!!";
            }
            catch (SqlException er)
            {

                MessageBox.Show(er.Number + " " + er.Message);
            }
            Manager.connection.Close();
        }

        private void Price_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MinPrice.Text != "" && MaxPrice.Text != "")
                {
                    Manager.connection.Open();
                    string Search = "SELECT floor, status, area, price_metr, var_coefficient " +
                    "FROM Pavilions WHERE price_metr BETWEEN @MinPrice_value AND @MaxPrice_value";
                    SqlCommand cmd = new SqlCommand(Search, Manager.connection);
                    SqlParameter MinPrice_param = new SqlParameter("@MinPrice_value", MinPrice.Text);
                    cmd.Parameters.Add(MinPrice_param);
                    SqlParameter MaxPrice_param = new SqlParameter("@MaxPrice_value", MaxPrice.Text);
                    cmd.Parameters.Add(MaxPrice_param);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Pavilions"); // В скобках указываем название таблицы
                    dataAdp.Fill(dt);
                    DataGridView.ItemsSource = dt.DefaultView; // Сам вывод 
                }
                else Notify.Content = "Заполните поле поиска по статусу!!!";
            }
            catch (SqlException er)
            {

                MessageBox.Show(er.Number + " " + er.Message);
            }
            Manager.connection.Close();
        }

        private void Floor_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Floor.Text != "")
                {
                    Manager.connection.Open();
                    string Search = "SELECT floor, status, area, price_metr, var_coefficient " +
                    "FROM Pavilions WHERE floor = @floor_value";
                    SqlCommand cmd = new SqlCommand(Search, Manager.connection);
                    SqlParameter Floor_param = new SqlParameter("@floor_value", Floor.Text);
                    cmd.Parameters.Add(Floor_param);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Pavilions"); // В скобках указываем название таблицы
                    dataAdp.Fill(dt);
                    DataGridView.ItemsSource = dt.DefaultView; // Сам вывод 
                }
                else Notify.Content = "Заполните поле поиска по статусу!!!";
            }
            catch (SqlException er)
            {

                MessageBox.Show(er.Number + " " + er.Message);
            }
            Manager.connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Status_Search.Text != "" && MinPrice.Text != "" && MaxPrice.Text != "" && Floor.Text != "")
                {
                    Manager.connection.Open();
                    string Search = "SELECT floor, status, area, price_metr, var_coefficient " +
                    "FROM Pavilions WHERE status = @status_value AND price_metr BETWEEN @MinPrice_value AND @MaxPrice_value AND floor = @floor_value";
                    SqlCommand cmd = new SqlCommand(Search, Manager.connection);
                    SqlParameter Search_param = new SqlParameter("@status_value", Status_Search.Text);
                    cmd.Parameters.Add(Search_param);
                    SqlParameter MinPrice_param = new SqlParameter("@MinPrice_value", MinPrice.Text);
                    cmd.Parameters.Add(MinPrice_param);
                    SqlParameter MaxPrice_param = new SqlParameter("@MaxPrice_value", MaxPrice.Text);
                    SqlParameter Floor_param = new SqlParameter("@floor_value", Floor.Text);
                    cmd.Parameters.Add(Floor_param);
                    cmd.Parameters.Add(MaxPrice_param);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Pavilions"); // В скобках указываем название таблицы
                    dataAdp.Fill(dt);
                    DataGridView.ItemsSource = dt.DefaultView; // Сам вывод 
                }
            }
            catch (SqlException er)
            {

                MessageBox.Show(er.Number + " " + er.Message);
            }
            Manager.connection.Close();
        }

        private void Rent_Pavilion_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RentPavilion());
        }
    }
    }
