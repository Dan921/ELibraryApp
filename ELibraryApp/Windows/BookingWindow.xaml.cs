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
    /// Логика взаимодействия для BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        DBQuery dBQueryHelper = new DBQuery();
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();
        BookReservationJournal _bookReservationJournal = new BookReservationJournal();
        int _bookId;
        int _readerId;

        public BookingWindow()
        {
            InitializeComponent();
        }

        public void SetData(int bookId, int readerId)
        {
            _bookId = bookId;
            _readerId = readerId;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _bookReservationJournal.BookingStartDate = (DateTime)StartDatePicker.SelectedDate;
                _bookReservationJournal.BookingEndDate = (DateTime)EndDatePicker.SelectedDate;
                _bookReservationJournal.BookingStatusId = 1;
                _bookReservationJournal.ReaderId = _readerId;
                _bookReservationJournal.BookId = _bookId;
                _bookReservationJournal.ReservationCode = GenerateReservationCode();
                dBQueryHelper.AddJournalRecord(_bookReservationJournal);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartDatePicker.SelectedDate = DateTime.Now;
            EndDatePicker.SelectedDate = DateTime.Now;
        }

        private int GenerateReservationCode()
        {
            return new Random().Next(999, 9999);
        }
    }
}
