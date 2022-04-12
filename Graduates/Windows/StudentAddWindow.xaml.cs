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

        private void BtnImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files: *.jpg, *.png| *.jpg;*.png";
            openFile.ShowDialog();
            if (openFile.FileName.Length != 0)
            {
                string namefile = openFile.FileName;
                byte[] image = File.ReadAllBytes(namefile);
                var student = (Student)this.DataContext;
                student.Stydent_photo = image;
                Img.Source = new BitmapImage(new Uri(namefile));
            }
        }
    }
}
