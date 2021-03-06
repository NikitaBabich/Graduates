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

namespace Graduates
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GraduatesEntities1 context;
        public MainWindow()
        {
            InitializeComponent();
            context = new GraduatesEntities1();
            CmbFDiltr.ItemsSource = context.Type_storage_object.ToList();

            var alltypes = context.Type_storage_object.ToList();
            alltypes.Insert(0, new Type_storage_object
            {
                Name = "Всё"
            });
            CmbFDiltr.ItemsSource = alltypes;
            CmbFDiltr.SelectedIndex = 0;

            ShowTable();
        }

        private void ShowTable()
        {
            var filter = context.Storage_objects.ToList();
            if(CmbFDiltr.SelectedIndex > 0)
            {
                filter = filter.Where(x => x.Id_storage_object == (CmbFDiltr.SelectedValue as Type_storage_object).Id).ToList();
            }
            DataGridStorage.ItemsSource = context.Storage_objects.ToList();
            DataGridStorage.ItemsSource = filter.ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewZap = new Storage_objects();
            context.Storage_objects.Add(NewZap);
            var EditWindow = new Windows.ObjectAddWindow(context, NewZap);
            EditWindow.ShowDialog();
            ShowTable();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentZap = DataGridStorage.SelectedItem as Storage_objects;
            if (currentZap == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы хотите удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Storage_objects.Remove(currentZap);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentZap = BtnEdit.DataContext as Storage_objects;
            var EditWindow = new Windows.ObjectAddWindow (context, currentZap);
            EditWindow.ShowDialog();
        }

        private void BtnSelectStudent_Click(object sender, RoutedEventArgs e)
        {
            var StudentsList = new Windows.SudentsListWindow();
            StudentsList.ShowDialog();
        }

        private void BtnSelectTeacher_Click(object sender, RoutedEventArgs e)
        {
            var TeachersList = new Windows.TeachersListWindow();
            TeachersList.ShowDialog();
        }

        private void BtnSelectGGroup_Click(object sender, RoutedEventArgs e)
        {
            var GroupsList = new Windows.GroupsListWindow();
            GroupsList.ShowDialog();
        }

        private void CmbFDiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowTable();
        }
    }
}
