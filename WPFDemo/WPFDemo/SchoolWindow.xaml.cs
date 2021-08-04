using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for SchoolWindow.xaml
    /// </summary>
    public partial class SchoolWindow : Window
    {
        School school = new School();
        public SchoolWindow()
        {
            InitializeComponent();
            lbCampuses.ItemsSource = school.Campuses;
            lbCourses.ItemsSource = school.Courses;
            lbMajors.ItemsSource = school.Majors;
            lbStudents.ItemsSource = school.Students;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student newStudent = new Student();
            StudentWindow studentWindow = new StudentWindow(newStudent);
            studentWindow.ShowDialog();
            if (studentWindow.DialogResult == true)
            {
                MessageBox.Show("Student " + newStudent.StudentNumber + " Added!");
                school.Students.Add(newStudent);
                lbStudents.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Dialog Cancelled!");
            }

        }

        private void btnSaveStudent_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == true)
            {
                using (StreamWriter file = new StreamWriter(saveFile.OpenFile()))
                {
                    foreach (var student in school.Students)
                    {
                        file.WriteLine(student.ToString());
                    }
                }
            }
        }

        private void lbStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lbStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Student newStudent = new Student();
            StudentWindow studentWindow = new StudentWindow(newStudent);
            studentWindow.ST = school.Students[lbStudents.SelectedIndex];
            studentWindow.txbFirstName.Text = studentWindow.ST.FirstName;
            studentWindow.txbLastName.Text = studentWindow.ST.LastName;
            studentWindow.txbMajor.Text = studentWindow.ST.Major;
            studentWindow.txbStudentNum.Text = studentWindow.ST.StudentNumber;
            studentWindow.lbScores.ItemsSource = studentWindow.ST.Scores;
            studentWindow.ShowDialog();
            if (studentWindow.DialogResult == true)
            {
                MessageBox.Show("Student " + newStudent.StudentNumber + " Added!");
                school.Students.Add(newStudent);
                lbStudents.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Dialog Cancelled!");
            }
        }
    }
}
