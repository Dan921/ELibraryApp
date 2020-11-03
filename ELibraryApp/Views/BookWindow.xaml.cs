﻿using System;
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
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();
        Book _book = new Book();

        public BookWindow()
        {
            InitializeComponent();
            AuthorComboBox.ItemsSource = eLibraryDBEntities.Authors.Select(a => a.FIO).ToList();
        }

        public BookWindow(Book book)
        {
            InitializeComponent();
            AuthorComboBox.ItemsSource = eLibraryDBEntities.Authors.Select(a => a.FIO).ToList();

            NameTextBox.Text = book.Name;
            AuthorComboBox.SelectedItem = eLibraryDBEntities.Authors.FirstOrDefault(a => a.AuthorId == book.AuthorId).FIO;
            YearTextBox.Text = book.PublishingYear.ToString();
            PublCheckBox.IsChecked = book.IsPublished;
            DescTextBox.Text = book.Description;
            GenreTextBox.Text = book.Genre;
            NumOfCopTextBox.Text = book.NumberOfCopies.ToString();
            PenPointTextBox.Text = book.PenaltyPoint.ToString();
            TagsTextBox.Text = book.Tags;
            _book = eLibraryDBEntities.Books.Find(book.BookId);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
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

                if(_book.BookId == 0)
                {
                    eLibraryDBEntities.Books.Add(_book);
                    eLibraryDBEntities.SaveChanges();
                    this.Close();
                }
                else
                {
                    eLibraryDBEntities.SaveChanges();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
