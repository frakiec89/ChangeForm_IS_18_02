using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;

namespace WpfApp5.MyForm
{
    /// <summary>
    /// Логика взаимодействия для StudentChangeWindows.xaml
    /// </summary>
    public partial class StudentChangeWindows : Window
    {
        public StudentChangeWindows(int studentId)
        {
            InitializeComponent();
            try
            {
                DB.MyContext context = new DB.MyContext();

                var s = context.Students.Include(x=>x.MyGroup).
                    ToList().Find(x=>x.StudentId==   studentId);
                gridStudent.DataContext = s;

                var gr = context.MyGroups.ToList();
                cbGroup.ItemsSource = gr;

                int index = gr.IndexOf(gr.Single(x => x.MyGroupId == s.MyGroupId));
                cbGroup.SelectedIndex = index;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var s = gridStudent.DataContext as DB.Student;
                
                var gr = cbGroup.SelectedItem as DB.MyGroup;
                s.MyGroup= gr;

                DB.MyContext context = new DB.MyContext();
                context.Students.Update(s);
                context.SaveChanges();
                MessageBox.Show("Ура");
                DialogResult = true;
                Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
