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

namespace ZakladkiRozszerzone
{
    /// <summary>
    /// Logika interakcji dla klasy AddOrEditWindow.xaml
    /// </summary>
    public partial class AddOrEditBookWindow : Window
    {
        private Book bookToEdit = null;
        public AddOrEditBookWindow()
        {
            InitializeComponent();

            Title = "Dodaj książkę";
            Button_AddOrEditBook.Content = "Dodaj książkę";
        }
        public AddOrEditBookWindow(Book book)
        {
            InitializeComponent();

            Title = "Edytuj książkę";
            Button_AddOrEditBook.Content = "Edytuj książkę";
            bookToEdit = book;

            TextBox_Title.Text = book.Title;
            TextBox_Description.Text = book.Description;
            TextBox_Author.Text = book.Author;
            TextBox_CoverURL.Text = book.CoverURL;
            DatePicker_PublishedOn.SelectedDate = book.PublishedOn;
        }

        private void AddOrEditBook(object sender, RoutedEventArgs e)
        {
            string title = TextBox_Title.Text;
            string description = TextBox_Description.Text;
            string author = TextBox_Author.Text;
            string coverURL = TextBox_CoverURL.Text;
            DateTime publishedOn = DatePicker_PublishedOn.DisplayDate;

            Book book = new Book(title, description, author, coverURL, publishedOn);

            if (bookToEdit != null)
            {
                Database.EditBook(bookToEdit, book);
                this.Close();
                return;
            }

            Database.AddBook(book);
            this.Close();
            return;
        }
    }
}
