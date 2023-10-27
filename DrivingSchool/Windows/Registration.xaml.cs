using DrivingSchool.Db;
using DrivingSchool.Pages;
using System.Windows;

namespace DrivingSchool.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        RegistrationPage1 firstPage;
        RegistrationPage2 secondPage;
        public Registration()
        {
            InitializeComponent();

            firstPage = new RegistrationPage1();
            secondPage = new RegistrationPage2();
            frRegistration.Navigate(firstPage);
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            new Authorization().Show();
            Close();
        }

        private void btnGoBackToFirst_Click(object sender, RoutedEventArgs e)
        {
            frRegistration.Navigate(firstPage);
            btnGoBack.Click += btnGoBack_Click;
            btnGoBack.Click -= btnGoBackToFirst_Click;

            btnProceed.Content = "Продолжить";
            btnProceed.Click += btnProceed_Click;
            btnProceed.Click -= btnRegistration_Click;
        }

        private void btnProceed_Click(object sender, RoutedEventArgs e)
        {
            frRegistration.Navigate(secondPage);
            
            btnGoBack.Click -= btnGoBack_Click;
            btnGoBack.Click += btnGoBackToFirst_Click;

            btnProceed.Content = "Регистрация";
            btnProceed.Click -= btnProceed_Click;
            btnProceed.Click += btnRegistration_Click;
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User();

                user.email = firstPage.tbxEmail.Text.Contains("@") 
                    && firstPage.tbxEmail.Text.Contains(".") 
                    ? firstPage.tbxEmail.Text
                    : throw new System.Exception("Проверьте введённые данные");
                user.password = firstPage.pbxPassword == firstPage.pbxPasswordConfirm 
                    ? firstPage.pbxPassword.Password 
                    : throw new System.Exception("Проверьте введённые данные");
                user.phone = firstPage.tbxPhone.Text;
                user.lastName = secondPage.tbxLastName.Text;
                user.lastName = secondPage.tbxFirstName.Text;
                user.middleName = secondPage.tbxMiddleName.Text is null 
                    ? null
                    : secondPage.tbxMiddleName.Text;
                user.Gender.nameGender = secondPage.cbxGender.SelectedItem.ToString().ToLower();

                DbContext.Context.DbContext.User.Add(user);
                DbContext.Context.DbContext.SaveChanges();

                MessageBox.Show("Регистрация успешно завершена!");
                new Authorization().Show();
                Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
