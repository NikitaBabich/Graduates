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
    /// Логика взаимодействия для ObjectAddWindow.xaml
    /// </summary>
    public partial class ObjectAddWindow : Window
    {
        GraduatesEntities1 context;
        public ObjectAddWindow(GraduatesEntities1 context, Object newobject)
        {
            InitializeComponent();
            this.context = context;
            CmbObject.ItemsSource = context.Type_storage_object.ToList();
            CmbStudent.ItemsSource = context.Students.ToList();
            CmbTeacher.ItemsSource = context.Teachers.ToList();
            this.DataContext = newobject;
        }
        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Данные добавлены");
            this.Close();
        }
    }
}
