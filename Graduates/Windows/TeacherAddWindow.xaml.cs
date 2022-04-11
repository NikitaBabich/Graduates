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
using System.Windows.Shapes;

namespace Graduates.Windows
{
    /// <summary>
    /// Логика взаимодействия для TeacherAddWindow.xaml
    /// </summary>
    public partial class TeacherAddWindow : Window
    {
        GraduatesEntities1 context;

        public TeacherAddWindow(GraduatesEntities1 context, Teacher newteacher)
        {
            InitializeComponent();
            this.context = context;
            CmbPost.ItemsSource = context.Posts.ToList();
            this.DataContext = newteacher;
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Данные добавлены");
            this.Close();
        }
    }
}
