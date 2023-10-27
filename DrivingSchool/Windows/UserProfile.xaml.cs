using DrivingSchool.Db;
using System.Linq;
using System.Windows;

namespace DrivingSchool.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Window
    {
        private User currentUser;
        public UserProfile(User user)
        {
            InitializeComponent();
            currentUser = user;
            tbId.Text = "id: " + currentUser.id;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnUserData_Click(object sender, RoutedEventArgs e)
        {
            new UserData(currentUser).Show();
            Close();
        }

        private void btnMakeAppointment_Click(object sender, RoutedEventArgs e)
        {
            new Appointment(currentUser).Show();
            Close();
        }

        private void btnAppointmentHistory_Click(object sender, RoutedEventArgs e)
        {
            new History(currentUser).Show();
            Close();
        }
    }
}
