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
    /// Логика взаимодействия для StudentAddWindow.xaml
    /// </summary>
    public partial class StudentAddWindow : Window
    {
        GraduatesEntities1 context;
        public StudentAddWindow(GraduatesEntities1 context, Student newstudent)
        {
            InitializeComponent();
            this.context = context;
            CmbGroup.ItemsSource = context.Groups.ToList();
            this.DataContext = newstudent;
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Данные добавлены");
            this.Close();
        }
    }
}
