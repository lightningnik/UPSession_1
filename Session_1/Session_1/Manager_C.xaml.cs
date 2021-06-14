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
    /// Логика взаимодействия для Manager_C.xaml
    /// </summary>
    public partial class Manager_C : Page
    {
        public Manager_C()
        {
            InitializeComponent();
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Authrorization());
        }

        private void SC_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SCMainPage());
        }

        private void Pavilions_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PavilionMainPage());
        }

        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.myrole == "Администратор")
            {
                Manager.MainFrame.Navigate(new EmployessMainPage());
            }
            else Notify.Content = "Доступ к данной странице имеют только сотрудники с должностью Администратор!!!";
        }

        private void Rentors_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RentorsPage());
        }
    }
}
