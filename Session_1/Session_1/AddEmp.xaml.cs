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
    /// Логика взаимодействия для AddEmp.xaml
    /// </summary>
    public partial class AddEmp : Page
    {
        public AddEmp()
        {
            InitializeComponent();
        }

        private void Add_Emp_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Patronymic.Text == "" || Role.Text == ""
           || Login.Text == "" || Password.Text == "" || Gender.Text == "" || Phonenumber.Text == "")
            {
                NotifyRectangle.Fill = Brushes.Red;
                Notify.Content = "Пожалуйста, заполните все поля!!!";
            }
            else
            {
                try
                {
                    //Manager.connection.Open();
                    string registration = "insert into Employees VALUES(@Surname_value, @Name_value,@Patronymic_value,@Phone_value," +
                        "@Gender_value,@Login_value,@Password_value,@Role_value, @Image)";
                    SqlCommand cmd = new SqlCommand(registration, Manager.connection);
                    SqlParameter Surname_param = new SqlParameter("@Surname_value", Surname.Text);
                    cmd.Parameters.Add(Surname_param);
                    SqlParameter Name_param = new SqlParameter("@Name_value", Name.Text);
                    cmd.Parameters.Add(Name_param);
                    SqlParameter Patronymic_param = new SqlParameter("@Patronymic_value", Patronymic.Text);
                    cmd.Parameters.Add(Patronymic_param);
                    SqlParameter Role_param = new SqlParameter("@Role_value", Role.Text);
                    cmd.Parameters.Add(Role_param);
                    SqlParameter Login_param = new SqlParameter("@Login_value", Login.Text);
                    cmd.Parameters.Add(Login_param);
                    SqlParameter Password_param = new SqlParameter("@Password_value", Password.Text);
                    cmd.Parameters.Add(Password_param);
                    SqlParameter Gender_param = new SqlParameter("@Gender_value", Gender.Text);
                    cmd.Parameters.Add(Gender_param);
                    SqlParameter Phone_param = new SqlParameter("@Phone_value", Phonenumber.Text);
                    cmd.Parameters.Add(Phone_param);

                    var fileDialog = new OpenFileDialog();
                    fileDialog.Filter = "Image Files | *.BMP;*.JPG;*.PNG";
                    fileDialog.InitialDirectory = @"C:\Users\Lightningnik\Desktop\Учебная практика ТРиЗБД\Image Сотрудники-20210601T054644Z-001\Image Сотрудники";

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
                        Notify.Content = "Сотрудник добавлен!!!";

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
                Manager.MainFrame.Navigate(new EmployessMainPage());
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmployessMainPage());
        }
    }
}
