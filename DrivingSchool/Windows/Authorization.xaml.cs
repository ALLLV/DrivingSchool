using System.Linq;
using System.Windows;

namespace DrivingSchool.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var get = DbContext.Context.DbContext.User
                .FirstOrDefault(x => x.email == tbxEmail.Text && x.password == pbxPassword.Password);

            if (get != null)
            {
                var profile = new UserProfile(get);
                profile.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверно введены данные пользователя!");
            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            new Registration().Show();
            Close();
        }
    }
}