using DrivingSchool.Db;
using System;
using System.Linq;
using System.Windows;

namespace DrivingSchool.Windows
{
    /// <summary>
    /// Логика взаимодействия для Appointment.xaml
    /// </summary>
    public partial class Appointment : Window
    {
        private User currentUser;
        public Appointment(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            new UserProfile(currentUser).Show();
            Close();
        }

        private void btnSetAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Lesson lesson = new Lesson();
                lesson.dateLesson = (DateTime)dpDate.SelectedDate;
                lesson.idUser = currentUser.id;

                var teacher = DbContext.Context.DbContext.Teacher.FirstOrDefault(x => string.Concat(x.lastName, " ", x.firstName) == tbxteacher.Text);
                if (teacher is null)
                    throw new Exception("Ошибка!");
                lesson.idTeacher = teacher.id;
                lesson.numberOfHours = Convert.ToInt32(cbxHours.Text);
                lesson.idDepartment = Convert.ToInt32(cbxDepartNo.Text);
                lesson.idStatus = 2; 
                DbContext.Context.DbContext.Lesson.Add(lesson);
                DbContext.Context.DbContext.SaveChanges();
                MessageBox.Show("Успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }
    }
}
