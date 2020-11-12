using ELibraryApp.Database;
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
    /// Логика взаимодействия для ReaderWindow.xaml
    /// </summary>
    public partial class ReaderWindow : Window
    {
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();
        int _readerId;

        public void SetData(int readerId)
        {
            _readerId = readerId;
        }

        public ReaderWindow()
        {
            InitializeComponent();
        }

        private void ToBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksDataGrid.SelectedItems.Count > 0)
            {
                Book book = (Book)BooksDataGrid.SelectedItems[0];
                BookingWindow bookingWindow = new BookingWindow();
                bookingWindow.SetData(book.BookId, _readerId);
                bookingWindow.Show();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow mainWindow = new AuthorizationWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BooksDataGrid.ItemsSource = eLibraryDBEntities.Books.ToList();
            HistoryDataGrid.ItemsSource = eLibraryDBEntities.BookReservationJournals.Where(r => r.ReaderId == _readerId).ToList();
            AvailableBooksGrid.ItemsSource = eLibraryDBEntities.Books.Where(b => eLibraryDBEntities.BookReservationJournals.Where(r => r.ReaderId == _readerId && r.BookingStatusId == 4).Select(r => r.BookId).Contains(b.BookId)).ToList();
            //AvailableBooksGrid.ItemsSource = eLibraryDBEntities.Books.Where(b => b.BookId == eLibraryDBEntities.BookReservationJournals.FirstOrDefault(r => r.ReaderId == _readerId && r.BookingStatusId == 4 && r.BookId == b.BookId).BookId).ToList();
        }

        private void ReadBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (AvailableBooksGrid.SelectedItems.Count > 0)
            {
                Book book = (Book)AvailableBooksGrid.SelectedItems[0];
                MessageBox.Show("Книга: " + book.Name);
            }
        }

        private void ReturnBookButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
