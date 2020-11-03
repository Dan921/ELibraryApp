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
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();
        BookReservationJournal _bookReservationJournal = new BookReservationJournal();
        int _bookId;
        int _readerId;

        public BookingWindow(int bookId, int readerId)
        {
            InitializeComponent();
            StartDatePicker.SelectedDate = DateTime.Now;
            EndDatePicker.SelectedDate = DateTime.Now;
            _bookId = bookId;
            _readerId = readerId;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                _bookReservationJournal.BookingStartDate = (DateTime)StartDatePicker.SelectedDate;
                _bookReservationJournal.BookingEndDate = (DateTime)EndDatePicker.SelectedDate;
                _bookReservationJournal.BookingStatusId = 1;
                _bookReservationJournal.ReaderId = _readerId;
                _bookReservationJournal.BookId = _bookId;
                eLibraryDBEntities.BookReservationJournals.Add(_bookReservationJournal);
                eLibraryDBEntities.SaveChanges();
                this.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }
    }
}
