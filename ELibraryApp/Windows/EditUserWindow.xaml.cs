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
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        private DBQuery dBQueryHelper = new DBQuery();
        private ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();
        private Reader _reader = new Reader();
        private User _user = new User();

        public void SetData(Reader reader)
        {
            _reader = eLibraryDBEntities.Readers.Find(reader.ReaderId);
            _user = eLibraryDBEntities.Users.Find(reader.UserId);
        }

        public EditUserWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RoleComboBox.ItemsSource = eLibraryDBEntities.Roles.Select(s => s.Name).ToList();
            RoleComboBox.SelectedIndex = 0;
            BirthDatePicker.DisplayDate = DateTime.Now;
            if (_reader.ReaderId != 0 && _user.UserId != 0)
            {
                LoginTextBox.Text = _user.Login;
                PassTextBox.Text = _user.Password;
                FIOTextBox.Text = _reader.FIO;
                PhoneTextBox.Text = _reader.Phone;
                RatingTextBox.Text = _reader.Rating.ToString();
                BirthDatePicker.SelectedDate = _reader.BirthDate;
                RoleComboBox.SelectedIndex = (int)_user.RoleId - 1;
                IsEmpCheckBox.IsChecked = _reader.IsCollegeEmployee;
                IsBlockedCheckBox.IsChecked = _user.IsBlocked;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                try
                {
                    _user.Login = LoginTextBox.Text;
                    _user.Password = PassTextBox.Text;
                    _reader.FIO = FIOTextBox.Text;
                    _reader.Phone = PhoneTextBox.Text;
                    _reader.Rating = int.Parse(RatingTextBox.Text);
                    _reader.BirthDate = BirthDatePicker.SelectedDate;
                    _user.RoleId = RoleComboBox.SelectedIndex + 1;
                    _reader.IsCollegeEmployee = (bool)IsEmpCheckBox.IsChecked;
                    _user.IsBlocked = (bool)IsBlockedCheckBox.IsChecked;

                    if (_reader.ReaderId == 0)
                    {
                        dBQueryHelper.AddUserWithReader(_reader, _user);
                        this.Close();
                    }
                    else
                    {
                        eLibraryDBEntities.SaveChanges();
                        this.Close();
                    }
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
            if(string.IsNullOrEmpty(LoginTextBox.Text))
            {
                errors += "\nПоле Логин должно быть заполнено";
            }
            if(string.IsNullOrEmpty(PassTextBox.Text))
            {
                errors += "\nПоле Пароль должно быть заполнено";
            }
            if (string.IsNullOrEmpty(FIOTextBox.Text))
            {
                errors += "\nПоле ФИО должно быть заполнено";
            }
            if (string.IsNullOrEmpty(RatingTextBox.Text))
            {
                errors += "\nПоле Рейтинг должно быть заполнено";
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
            PassTextBox.Text = new Password().GeneratePassword();
        }
    }
}
