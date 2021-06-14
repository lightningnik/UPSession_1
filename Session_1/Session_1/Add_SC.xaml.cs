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
using Microsoft.Win32;
using System.IO;

namespace Session_1
{
    /// <summary>
    /// Логика взаимодействия для Add_SC.xaml
    /// </summary>
    public partial class Add_SC : Page
    {
        public Add_SC()
        {
            InitializeComponent();
        }

        private void Add_SC_Click(object sender, RoutedEventArgs e)
        {
            if (Number_SC.Text == "" || CP.Text == "" || Status.Text == "" 
            || Status.Text == "" || Ratio.Text == "" || Price.Text == "" || Price.Text == "")
            {
                NotifyRectangle.Fill = Brushes.Red;
                Notify.Content = "Пожалуйста, заполните все поля!!!";
            }
            else
            {
                try
                {
                    //Manager.connection.Open();
                    string registration = "insert into Shoping_Center VALUES(@SC_Name_value, @Status_value,@CP_value,@City_value,@Price_value,@Ratio_value,@Number_floor_value, @Image)";
                    SqlCommand cmd = new SqlCommand(registration, Manager.connection);
                    SqlParameter Name_SC_param = new SqlParameter("@SC_Name_value", Number_SC.Text);
                    cmd.Parameters.Add(Name_SC_param);
                    SqlParameter CP_param = new SqlParameter("@CP_value", CP.Text);
                    cmd.Parameters.Add(CP_param);
                    SqlParameter Status_param = new SqlParameter("@Status_value", Status.Text);
                    cmd.Parameters.Add(Status_param);
                    SqlParameter City_param = new SqlParameter("@City_value", City.Text);
                    cmd.Parameters.Add(City_param);
                    SqlParameter Price_param = new SqlParameter("@Price_value", Price.Text);
                    cmd.Parameters.Add(Price_param);
                    SqlParameter Ratio_param = new SqlParameter("@Ratio_value", Ratio.Text);
                    cmd.Parameters.Add(Ratio_param);
                    SqlParameter Floor_param = new SqlParameter("@Number_floor_value", Number_floor.Text);
                    cmd.Parameters.Add(Floor_param);
                    var fileDialog = new OpenFileDialog();
                    fileDialog.Filter = "Image Files | *.BMP;*.JPG;*.PNG";
                    fileDialog.InitialDirectory = @"C:\Users\Lightningnik\Desktop\Учебная практика ТРиЗБД\Image ТЦ-20210601T054701Z-001\Image ТЦ";

                    fileDialog.Title = "Пример использования OpenFileDialog ";

                    if (fileDialog.ShowDialog() == true)
                    {

                        MessageBox.Show("Выбран файл " + fileDialog.FileName);
                        string fileName = fileDialog.FileName;

                        //ReadAllBytes Открывает двоичный файл, считывает содержимое файла в //массив байтов и затем закрывает файл.

                        Byte[] bytBLOBData = File.ReadAllBytes(fileName);
                        //Create parameter for insert command and add to SqlCommand object.
                        SqlParameter prm = new SqlParameter("@Image", SqlDbType.VarBinary, bytBLOBData.Length, ParameterDirection.Input, false,
                         0, 0, null, DataRowVersion.Current, bytBLOBData);
                        cmd.Parameters.Add(prm);

                        //Open connection, execute query, and close connection.
                        Manager.connection.Open();
                        cmd.ExecuteNonQuery();
                        
                        NotifyRectangle.Fill = Brushes.Green;
                        Notify.Content = "Торговый центр добавлен!!!";
                       
                    }
                    else MessageBox.Show(" Выберите фотографию");
                }
                catch (SqlException err)
                {
                    NotifyRectangle.Fill = Brushes.Red;
                    MessageBox.Show(err.Message);
                    Notify.Content = "Введите корректные данные!!!";
                }
                Manager.connection.Close();
                Manager.MainFrame.Navigate(new SCMainPage());
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SCMainPage());
        }
    }
}
