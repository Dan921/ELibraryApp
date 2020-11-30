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
    /// Логика взаимодействия для BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        DBQuery dBQueryHelper = new DBQuery();
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();
        Book _book = new Book();


        public void SetData(Book book)
        {
            _book = eLibraryDBEntities.Books.Find(book.BookId);
        }

        public BookWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                try
                {
                    _book.Name = NameTextBox.Text;
                    _book.AuthorId = eLibraryDBEntities.Authors.FirstOrDefault(a => a.FIO == AuthorComboBox.SelectedItem.ToString()).AuthorId;
                    _book.PublishingYear = int.Parse(YearTextBox.Text);
                    _book.IsPublished = PublCheckBox.IsChecked;
                    _book.Description = DescTextBox.Text;
                    _book.Genre = GenreTextBox.Text;
                    _book.NumberOfCopies = int.Parse(NumOfCopTextBox.Text);
                    _book.PenaltyPoint = int.Parse(PenPointTextBox.Text);
                    _book.Tags = TagsTextBox.Text;

                    if (_book.BookId == 0)
                    {
                        dBQueryHelper.AddBook(_book);
                    }
                    else
                    {
                        eLibraryDBEntities.SaveChanges();
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AuthorComboBox.ItemsSource = eLibraryDBEntities.Authors.Select(a => a.FIO).ToList();
            if(_book != null)
            {
                NameTextBox.Text = _book.Name;
                AuthorComboBox.SelectedItem = eLibraryDBEntities.Authors.FirstOrDefault(a => a.AuthorId == _book.AuthorId).FIO;
                YearTextBox.Text = _book.PublishingYear.ToString();
                PublCheckBox.IsChecked = _book.IsPublished;
                DescTextBox.Text = _book.Description;
                GenreTextBox.Text = _book.Genre;
                NumOfCopTextBox.Text = _book.NumberOfCopies.ToString();
                PenPointTextBox.Text = _book.PenaltyPoint.ToString();
                TagsTextBox.Text = _book.Tags;
            }
        }

        private bool ModelCheck()
        {
            string errors = "Ошибки:";
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                errors += "\nВведите название";
            }
            if (AuthorComboBox.SelectedItem == null)
            {
                errors += "\nВыберите автора";
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
