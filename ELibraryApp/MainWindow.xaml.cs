using ELibraryApp.Views;
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

namespace ELibraryApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = eLibraryDBEntities.Users.ToList();
            User user = users.FirstOrDefault(u => u.Login == LoginTextBox.Text && u.Password == UserPassPasswordBox.Password);
            if (user == null)
            {
                MessageBox.Show("Такого пользователя не существует");
            }
            else if (user.IsBlocked == true)
            {
                MessageBox.Show("Вы заблокированны");
            }
            else
            {
                switch (user.Role)
                {
                    case "Читатель":
                        ReaderWindow readerWindow = new ReaderWindow();
                        readerWindow.Show();
                        this.Close();
                        break;
                    case "Библиотекарь":
                        LibrarianWindow librarianWindow = new LibrarianWindow();
                        librarianWindow.Show();
                        this.Close();
                        break;
                    case "Администратор":
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                        break;
                }
            }
        }
    }
}
