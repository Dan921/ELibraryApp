﻿using ELibraryApp.Database;
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
    public partial class AuthorizationWindow : Window
    {
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();

        public AuthorizationWindow()
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
                switch (user.RoleId)
                {
                    case 1:
                        ReaderWindow readerWindow = new ReaderWindow();
                        readerWindow.SetData(eLibraryDBEntities.Readers.FirstOrDefault(r => r.UserId == user.UserId).ReaderId);
                        readerWindow.Show();
                        this.Close();
                        break;
                    case 2:
                        LibrarianWindow librarianWindow = new LibrarianWindow();
                        librarianWindow.SetData(user.UserId);
                        librarianWindow.Show();
                        this.Close();
                        break;
                    case 3:
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.SetData(user.UserId);
                        adminWindow.Show();
                        this.Close();
                        break;
                }
            }
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
