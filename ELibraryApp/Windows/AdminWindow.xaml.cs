using ELibraryApp.Database;
using ELibraryApp.Logic;
using ELibraryApp.Windows;
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

namespace ELibraryApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        DBQuery dBQueryHelper = new DBQuery();
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();
        private int _userId;

        public void SetData(int userId)
        {
            _userId = userId;
        }

        public AdminWindow()
        {
            InitializeComponent();
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItems.Count > 0)
            {
                Reader user = (Reader)UsersDataGrid.SelectedItems[0];
                EditUserWindow editUserWindow = new EditUserWindow();
                editUserWindow.SetData(user);
                editUserWindow.Show();
            }
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItems.Count > 0)
            {
                Reader user = (Reader)UsersDataGrid.SelectedItems[0];
                dBQueryHelper.DeleteReaderWithUser(user);
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            EditUserWindow editUserWindow = new EditUserWindow();
            editUserWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow mainWindow = new AuthorizationWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UsersDataGrid.ItemsSource = eLibraryDBEntities.Readers.ToList();
        }

        private void ShowOnlyReadersButton_Click(object sender, RoutedEventArgs e)
        {
            UsersDataGrid.ItemsSource = eLibraryDBEntities.Readers.Where(r => r.UserId == eLibraryDBEntities.Users.FirstOrDefault(u => u.RoleId == 1 && u.UserId == r.UserId).UserId).ToList();
        }

        private void ShowOnlyLibrariansButton_Click(object sender, RoutedEventArgs e)
        {
            UsersDataGrid.ItemsSource = eLibraryDBEntities.Readers.Where(r => r.UserId == eLibraryDBEntities.Users.FirstOrDefault(u => u.RoleId == 2 && u.UserId == r.UserId).UserId).ToList();
        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            UsersDataGrid.ItemsSource = eLibraryDBEntities.Readers.ToList();
        }
    }
}
