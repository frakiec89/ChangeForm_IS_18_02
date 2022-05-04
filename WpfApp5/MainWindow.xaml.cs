using Microsoft.EntityFrameworkCore;
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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                dGmyContext.ItemsSource = 
                    myContext.Students.Include(x=>x.MyGroup).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btChange_Click(object sender, RoutedEventArgs e)
        {

            if(dGmyContext.SelectedItem != null)
            {
                DB.Student student = dGmyContext.SelectedItem as DB.Student;

                MyForm.StudentChangeWindows studentChangeWindows = new MyForm.StudentChangeWindows(student.StudentId);

                 if(studentChangeWindows.ShowDialog()== true)
                {
                    MainWindow_Loaded(sender, e); // сново получим контент
                }

            }
         



        }
    }
}
