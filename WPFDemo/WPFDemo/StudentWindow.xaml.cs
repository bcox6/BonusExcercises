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

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        private Student st;
        public Student ST { get { return st; } set { st = value; } }

        public StudentWindow():this(new Student())
        {

        }

        public StudentWindow(Student st)
        {
            InitializeComponent();
            this.st = st;
        }
        

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Instantiate a class object
            //Student st = new Student();

            //Set the values from our controls into the class
            st.FirstName = txbFirstName.Text;
            st.LastName = txbLastName.Text;
            st.StudentNumber = txbStudentNum.Text;
            st.Major = txbMajor.Text;

            List<Assignment> scores = new List<Assignment>();
            foreach (Assignment score in lbScores.Items)
            {
                scores.Add(score);    
            }
            st.Scores = scores;

            //Set the results from the class into a control on the form
            txbResults.Text = st.ToString();

            this.DialogResult = true;
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Assignment assign = new Assignment();
            assign.Title = txbTitle.Text;
            assign.Score = int.Parse(txbScore.Text);
            lbScores.Items.Add(assign);
        }
    }
}
