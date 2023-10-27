using DrivingSchool.Db;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace DrivingSchool.Windows
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Window
    {
        private User currentUser;
        private List<Lesson> lessons;
        public History(User user)
        {
            InitializeComponent();
            currentUser = user;
            lessons = DbContext.Context.DbContext.Lesson.Where(x => x.idUser == currentUser.id).ToList();
            DataContext = lessons;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            new UserProfile(currentUser).Show();
            Close();
        }
    }
}
