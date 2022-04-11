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
    /// Логика взаимодействия для GroupAddWindow.xaml
    /// </summary>
    public partial class GroupAddWindow : Window
    {
        GraduatesEntities1 context;
        public GroupAddWindow(GraduatesEntities1 context, Group newgroup)
        {
            InitializeComponent();
            this.context = context;
            CmbDep.ItemsSource = context.Type_storage_object.ToList();
            this.DataContext = newgroup;
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Данные добавлены");
            this.Close();
        }

        private void BtnImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
