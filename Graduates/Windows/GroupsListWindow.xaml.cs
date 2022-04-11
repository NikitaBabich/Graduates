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
    /// Логика взаимодействия для GroupsListWindow.xaml
    /// </summary>
    public partial class GroupsListWindow : Window
    {
        GraduatesEntities1 context;
        public GroupsListWindow()
        {
            InitializeComponent();
            context = new GraduatesEntities1();
            ShowTable();
        }
        private void ShowTable()
        {
            DataGridGroups.ItemsSource = context.Groups.ToList();
            DataGridGroups.ItemsSource = context.Groups.Where(x => x.Name.Contains(TxtSearch.Text)).ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewZap = new Group();
            context.Groups.Add(NewZap);
            var EditWindow = new Windows.GroupAddWindow(context, NewZap);
            EditWindow.ShowDialog();
            ShowTable();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentZap = DataGridGroups.SelectedItem as Group;
            if (currentZap == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы хотите удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Groups.Remove(currentZap);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentZap = BtnEdit.DataContext as Group;
            var EditWindow = new Windows.GroupAddWindow(context, currentZap);
            EditWindow.ShowDialog();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }
    }
}
