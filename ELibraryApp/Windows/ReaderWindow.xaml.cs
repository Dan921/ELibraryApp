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

        public ReaderWindow(int readerId)
        {
            InitializeComponent();
            BooksDataGrid.ItemsSource = eLibraryDBEntities.Books.ToList();
            HistoryDataGrid.ItemsSource = eLibraryDBEntities.BookReservationJournals.Where(r => r.ReaderId == readerId).ToList();
            _readerId = readerId;
        }

        private void ToBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksDataGrid.SelectedItems.Count > 0)
            {
                Book book = (Book)BooksDataGrid.SelectedItems[0];
                BookingWindow bookingWindow = new BookingWindow(book.BookId, _readerId);
                bookingWindow.Show();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow mainWindow = new AuthorizationWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
