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
    /// Логика взаимодействия для JournalRecordEditWindowxaml.xaml
    /// </summary>
    public partial class JournalRecordEditWindow : Window
    {
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();
        BookReservationJournal _bookReservationJournal = new BookReservationJournal();

        public void SetData(BookReservationJournal bookReservationJournal)
        {
            _bookReservationJournal = eLibraryDBEntities.BookReservationJournals.Find(bookReservationJournal.RecordId);
        }
        public JournalRecordEditWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReaderIdLabel.Content += _bookReservationJournal.ReaderId.ToString();
            BookIdLabel.Content += _bookReservationJournal.BookId.ToString();
            StartBookingDateLabel.Content += _bookReservationJournal.BookingStartDate.ToString();
            EndBookingDateLabel.Content += _bookReservationJournal.BookingEndDate.ToString();
            StatusComboBox.ItemsSource = eLibraryDBEntities.BookingStatuses.Select(s => s.Name).ToList();
            StatusComboBox.SelectedIndex = _bookReservationJournal.BookingStatusId - 1;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _bookReservationJournal.BookingStatusId = StatusComboBox.SelectedIndex + 1;

                eLibraryDBEntities.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
