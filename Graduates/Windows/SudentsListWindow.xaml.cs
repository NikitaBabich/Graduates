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
    /// Логика взаимодействия для SudentsListWindow.xaml
    /// </summary>
    public partial class SudentsListWindow : Window
    {
        GraduatesEntities1 context;
        public SudentsListWindow()
        {
            InitializeComponent();
            context = new GraduatesEntities1();
            ShowTable();
        }
        private void ShowTable()
        {
            DataGridStudents.ItemsSource = context.Students.ToList();
            DataGridStudents.ItemsSource = context.Students.Where(x => x.Surname.Contains(TxtSearch.Text)).ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewZap = new Student();
            context.Students.Add(NewZap);
            var EditWindow = new Windows.StudentAddWindow(context, NewZap);
            EditWindow.ShowDialog();
            ShowTable();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentZap = DataGridStudents.SelectedItem as Student;
            if (currentZap == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы хотите удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Students.Remove(currentZap);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentZap = BtnEdit.DataContext as Student;
            var EditWindow = new Windows.StudentAddWindow(context, currentZap);
            EditWindow.ShowDialog();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }
    }
}
