using ELibraryApp.Database;
using ELibraryApp.Logic;
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

namespace ELibraryApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReaderAddWindow.xaml
    /// </summary>
    public partial class ReaderAddWindow : Window
    {
        Password passwordHelper = new Password();
        DBQuery dBQueryHelper = new DBQuery();
        Reader _reader = new Reader();
        User _user = new User();

        public ReaderAddWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                try
                {
                    _user.Login = LoginTextBox.Text;
                    _user.Password = PassTextBox.Text;
                    _user.IsBlocked = false;
                    _user.RoleId = 1;
                    _reader.FIO = FIOTextBox.Text;
                    _reader.BirthDate = BirthDatePicker.SelectedDate;
                    _reader.Phone = PhoneTextBox.Text;
                    _reader.IsCollegeEmployee = IsEmpCheckBox.IsChecked;
                    _reader.Rating = 0;
                    dBQueryHelper.AddUserWithReader(_reader, _user);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private bool ModelCheck()
        {
            string errors = "Ошибки:";
            if (string.IsNullOrEmpty(LoginTextBox.Text))
            {
                errors += "\nЗаполните поле Логин";
            }
            if (string.IsNullOrEmpty(PassTextBox.Text))
            {
                errors += "\nЗаполните поле Логин";
            }
            if (string.IsNullOrEmpty(FIOTextBox.Text))
            {
                errors += "\nЗаполните поле Логин";
            }
            if (string.IsNullOrEmpty(PhoneTextBox.Text))
            {
                errors += "\nЗаполните поле Логин";
            }
            if (errors == "Ошибки:")
            {
                return true;
            }
            else
            {
                MessageBox.Show(errors);
                return false;
            }
        }

        private void PasswordGenerateButton_Click(object sender, RoutedEventArgs e)
        {
            PassTextBox.Text = passwordHelper.GeneratePassword();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BirthDatePicker.DisplayDate = DateTime.Now;
        }
    }
}
