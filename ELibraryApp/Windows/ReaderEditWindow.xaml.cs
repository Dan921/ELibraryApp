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

namespace ELibraryApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ReaderEditWindow.xaml
    /// </summary>
    public partial class ReaderEditWindow : Window
    {
        DBQueryHelper dBQueryHelper = new DBQueryHelper();
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();
        Reader _reader = new Reader();

        public void SetData(Reader reader)
        {
            _reader = eLibraryDBEntities.Readers.Find(reader.ReaderId);
        }

        public ReaderEditWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _reader.FIO = FIOTextBox.Text;
                _reader.Phone = PhoneTextBox.Text;
                _reader.Rating = int.Parse(RatingTextBox.Text);
                _reader.BirthDate = BirthDatePicker.SelectedDate;
                _reader.IsCollegeEmployee = IsEmpCheckBox.IsChecked;

                eLibraryDBEntities.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BirthDatePicker.DisplayDate = DateTime.Now;
            if (_reader != null)
            {
                FIOTextBox.Text = _reader.FIO;
                PhoneTextBox.Text = _reader.Phone;
                RatingTextBox.Text = _reader.Rating.ToString();
                BirthDatePicker.SelectedDate = _reader.BirthDate;
                IsEmpCheckBox.IsChecked = _reader.IsCollegeEmployee;
            }
        }

        private bool ModelCheck()
        {
            string errors = "Ошибки:";
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
    }
}
