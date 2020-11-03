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
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();
        Reader _reader = new Reader();

        public ReaderEditWindow(Reader reader)
        {
            InitializeComponent();
            FIOTextBox.Text = reader.FIO;
            PhoneTextBox.Text = reader.Phone;
            RatingTextBox.Text = reader.Rating.ToString();
            BirthDatePicker.SelectedDate = reader.BirthDate;
            IsEmpCheckBox.IsChecked = reader.IsCollegeEmployee;
            _reader = eLibraryDBEntities.Readers.Find(reader.ReaderId);
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

                //if (_reader.ReaderId != 0)
                //{
                    eLibraryDBEntities.SaveChanges();
                    this.Close();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
