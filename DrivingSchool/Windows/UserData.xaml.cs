using DrivingSchool.Db;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DrivingSchool.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserData.xaml
    /// </summary>
    public partial class UserData : Window
    {
        private User currentUser;
        public UserData(User user)
        {
            InitializeComponent();
            currentUser = user;
            tbId.Text = "id: " + currentUser.id;
            tbFIO.Text = currentUser.lastName + " " + currentUser.firstName + " " + currentUser.middleName;
            tbPhone.Text = currentUser.phone;
            tbEmail.Text = currentUser.email;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            new UserProfile(currentUser).Show();
            Close();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            foreach (FrameworkElement item in spMain.Children)
            {
                if (item is TextBox)
                {
                    var tbx = (item as TextBox);
                    tbx.IsEnabled = true;
                    tbx.Background = new SolidColorBrush(Colors.White);
                }
            }

            btnChange.Content = "Подтвердить";
            btnChange.Click -= btnChange_Click;
            btnChange.Click += btnChange_Confirm;
        }

        private void btnChange_Confirm(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] FIO = tbFIO.Text.Split(' ');
                if (FIO.Count() > 3)
                    throw new Exception("Введены некорректные данные!");
                
                if(tbPhone.Text.Count() > 20 || tbPhone.Text.Any(x => char.IsLetter(x)))
                    throw new Exception("Введены некорректные данные!");

                if(!(tbEmail.Text.Contains('@') && tbEmail.Text.Contains('.')))
                    throw new Exception("Введены некорректные данные!");

                if (FIO.Count() == 2)
                {
                    currentUser.lastName = FIO[0];
                    currentUser.firstName = FIO[1];
                }
                else
                {
                    currentUser.lastName = FIO[0];
                    currentUser.firstName = FIO[1];
                    currentUser.middleName = FIO[2];
                }
                currentUser.email = tbEmail.Text;
                currentUser.phone = tbPhone.Text;

                DbContext.Context.DbContext.SaveChanges();
                MessageBox.Show("Изменено успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                foreach (FrameworkElement item in spMain.Children)
                {
                    if (item is TextBox)
                    {
                        var tbx = (item as TextBox);
                        tbx.IsEnabled = false;
                        tbx.Background = new SolidColorBrush(Colors.Transparent);
                    }
                }

                btnChange.Content = "Изменить";
                btnChange.Click -= btnChange_Confirm;
                btnChange.Click += btnChange_Click;
            }
        }
    }
}
