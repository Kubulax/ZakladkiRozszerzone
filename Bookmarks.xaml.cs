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
    /// Logika interakcji dla klasy Bookmarks.xaml
    /// </summary>
    public partial class Bookmarks : Window
    {
        public Bookmarks(Book book)
        {
            InitializeComponent();

            ListView_Bookmarks.ItemsSource = book.Bookmarks;
        }

        private void ListView_ShowBookmarkDetailsOnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Bookmark bookmark = ListView_Bookmarks.SelectedItem as Bookmark;
            string message = "Opis: " + bookmark.Description;
            MessageBox.Show(message);
        }

        private void AddBookmark(object sender, RoutedEventArgs e)
        {
            string pageNumberString = TextBox_PageNumber.Text;
            string description = TextBox_Description.Text;

            int pageNumber;
            if (!int.TryParse(pageNumberString, out pageNumber))
            {
                MessageBox.Show("Wprowadzono nieprawidłowy numer strony.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Bookmark bookmark = new Bookmark(pageNumber, description);
            (DataContext as Book).AddBookmark(bookmark);
            ListView_Bookmarks.ItemsSource = (DataContext as Book).Bookmarks;

            TextBox_PageNumber.Text = "";
            TextBox_Description.Text = "";
        }

        private void RemoveBookmark(object sender, RoutedEventArgs e)
        {
            Bookmark selectedBookmark = (sender as Button).CommandParameter as Bookmark;
            (DataContext as Book).RemoveBookmark(selectedBookmark);
            ListView_Bookmarks.ItemsSource = (DataContext as Book).Bookmarks;
        }
    }
}
