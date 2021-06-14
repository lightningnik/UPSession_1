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
    /// Логика взаимодействия для Add_Pavilion.xaml
    /// </summary>
    public partial class Add_Pavilion : Page
    {
        public Add_Pavilion()
        {
            InitializeComponent();
        }

        private void Add_Pavilion_Click(object sender, RoutedEventArgs e)
        {
            if (Number_floor.Text == "" || Number_pavilion.Text == "" || Square.Text == "" || Status.Text == "" || Ratio.Text == "" || Price.Text == "")
            {
                NotifyRectangle.Fill = Brushes.Red;
                Notify.Content = "Пожалуйста, заполните все поля!!!";
            }
            else
            {
                try
                {
                    Manager.connection.Open();
                    string registration = "insert into Pavilions VALUES(@Number_SC_value, @Number_pavilion_value, @Number_floor_value, @Status_value, @Square_value, @Price_value, @Ratio_value)";
                    SqlCommand cmd = new SqlCommand(registration, Manager.connection);
                    SqlParameter Number_SC_param = new SqlParameter("@Number_SC_value", Number_SC.Text);
                    cmd.Parameters.Add(Number_SC_param);
                    SqlParameter Number_pavilion_param = new SqlParameter("@Number_pavilion_value", Number_pavilion.Text);
                    cmd.Parameters.Add(Number_pavilion_param);
                    SqlParameter Number_floor_param = new SqlParameter("@Number_floor_value", Number_floor.Text);
                    cmd.Parameters.Add(Number_floor_param);
                    SqlParameter Status_param = new SqlParameter("@Status_value", Status.Text);
                    cmd.Parameters.Add(Status_param);
                    SqlParameter Square_param = new SqlParameter("@Square_value", Square.Text);
                    cmd.Parameters.Add(Square_param);
                    SqlParameter Price_param = new SqlParameter("@Price_value", Price.Text);
                    cmd.Parameters.Add(Price_param);
                    SqlParameter Ratio_param = new SqlParameter("@Ratio_value", Ratio.Text);
                    cmd.Parameters.Add(Ratio_param);
                    cmd.ExecuteNonQuery();
                    NotifyRectangle.Fill = Brushes.Green;
                    Notify.Content = "Павильон добавлен!!!";
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

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PavilionMainPage());
        }

        private void Update_PavilionButton_Click(object sender, RoutedEventArgs e)
        {
            if (Number_floor.Text == "" || Number_pavilion.Text == "" || Square.Text == "" || Status.Text == "" || Ratio.Text == "" || Price.Text == "")
            {
                NotifyRectangle.Fill = Brushes.Red;
                Notify.Content = "Пожалуйста, заполните все поля!!!";
            }
            else
            {
                try
                {
                    Manager.connection.Open();
                    string registration = "UPDATE Pavilions SET id_shop_center = @Number_SC_value, id_pavilion = @Number_pavilion_value, " +
                        "floor = @Number_floor_value, status = @Status_value, area = @Square_value, price_metr = @Price_value, " +
                        "var_coefficient = @Ratio_value)";
                    SqlCommand cmd = new SqlCommand(registration, Manager.connection);
                    SqlParameter Number_SC_param = new SqlParameter("@Number_SC_value", Number_SC.Text);
                    cmd.Parameters.Add(Number_SC_param);
                    SqlParameter Number_pavilion_param = new SqlParameter("@Number_pavilion_value", Number_pavilion.Text);
                    cmd.Parameters.Add(Number_pavilion_param);
                    SqlParameter Number_floor_param = new SqlParameter("@Number_floor_value", Number_floor.Text);
                    cmd.Parameters.Add(Number_floor_param);
                    SqlParameter Status_param = new SqlParameter("@Status_value", Status.Text);
                    cmd.Parameters.Add(Status_param);
                    SqlParameter Square_param = new SqlParameter("@Square_value", Square.Text);
                    cmd.Parameters.Add(Square_param);
                    SqlParameter Price_param = new SqlParameter("@Price_value", Price.Text);
                    cmd.Parameters.Add(Price_param);
                    SqlParameter Ratio_param = new SqlParameter("@Ratio_value", Ratio.Text);
                    cmd.Parameters.Add(Ratio_param);
                    cmd.ExecuteNonQuery();
                    NotifyRectangle.Fill = Brushes.Green;
                    Notify.Content = "Павильон изменен!!!";
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
    }
    }
