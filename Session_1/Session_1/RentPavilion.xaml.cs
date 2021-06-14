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
    /// Логика взаимодействия для RentPavilion.xaml
    /// </summary>
    public partial class RentPavilion : Page
    {
        public RentPavilion()
        {
            InitializeComponent();
        }

        private void Rent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                    string sqlExpression = "EXEC RentProcedure @renter_id, @shop_center_id, @id_employee, @pavilion_id, @status, @rent_start, @rent_end";
                    Manager.connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, Manager.connection);
                    SqlParameter renter_param = new SqlParameter("@renter_id", id_rentor.Text);
                    command.Parameters.Add(renter_param);
                    SqlParameter id_SC_param = new SqlParameter("@shop_center_id", id_SC.Text);
                    command.Parameters.Add(id_SC_param);
                    SqlParameter id_emp_param = new SqlParameter("@id_employee", id_emp.Text);
                    command.Parameters.Add(id_emp_param);
                    SqlParameter id_pav_param = new SqlParameter("@pavilion_id", id_pav.Text);
                    command.Parameters.Add(id_pav_param);
                    SqlParameter Status_param = new SqlParameter("@status", Status.Text);
                    command.Parameters.Add(Status_param);
                    SqlParameter Date_start_param = new SqlParameter("@rent_start", Date_start.SelectedDate);
                    command.Parameters.Add(Date_start_param);
                DateTime thisDay = DateTime.Today;
                if (Date_start.SelectedDate.Value >= thisDay)
                {
                    if (Date_start.SelectedDate.Value > Date_end.SelectedDate.Value)
                    {
                        Notify.Content = "Дата начала аренды не может быть больше даты окончания аренды";
                    }
                    else
                    {
                        SqlParameter Date_end_param = new SqlParameter("@rent_end", Date_end.SelectedDate);
                        command.Parameters.Add(Date_end_param);
                        command.ExecuteNonQuery();

                        Notify.Content = "Аренда зарегистрированна!!!";

                    }
                    
                }
                else Notify.Content = "Дата начала должна быть не меньше сегодняшней!!!";
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
                Notify.Content = "Пожалуйста, проверьте вводимые данные!!!";
            }
            Manager.connection.Close();
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PavilionMainPage());
        }
    }
}
