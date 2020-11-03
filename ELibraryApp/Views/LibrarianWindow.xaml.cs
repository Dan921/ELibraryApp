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
    /// Логика взаимодействия для LibrarianWindow.xaml
    /// </summary>
    public partial class LibrarianWindow : Window
    {
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();

        public LibrarianWindow(int userId)
        {
            InitializeComponent();
            ReadersDataGrid.ItemsSource = eLibraryDBEntities.Readers.ToList();
            BooksDataGrid.ItemsSource = eLibraryDBEntities.Books.ToList();
            JournalDataGrid.ItemsSource = eLibraryDBEntities.BookReservationJournals.ToList();
        }

        private void EditReaderButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReadersDataGrid.SelectedItems.Count > 0)
            {
                Reader reader = (Reader)ReadersDataGrid.SelectedItems[0];
                ReaderEditWindow readerEditWindow = new ReaderEditWindow(reader);
                readerEditWindow.Show();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksDataGrid.SelectedItems.Count > 0)
            {
                Book book = (Book)BooksDataGrid.SelectedItems[0];
                BookWindow bookWindow = new BookWindow(book);
                bookWindow.Show();
            }
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            BookWindow bookWindow = new BookWindow();
            bookWindow.Show();
        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksDataGrid.SelectedItems.Count > 0)
            {
                Book book = (Book)BooksDataGrid.SelectedItems[0];
                eLibraryDBEntities.Books.Remove(book);
                eLibraryDBEntities.SaveChanges();
            }
        }

        private void ShowNewJournalRecordsButton_Click(object sender, RoutedEventArgs e)
        {
            JournalDataGrid.ItemsSource = eLibraryDBEntities.BookReservationJournals.Where(r => r.BookingStatusId == 1).ToList();
            JournalDataGrid.Items.Refresh();
        }

        private void EditJournalRecordButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteJournalRecordButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
