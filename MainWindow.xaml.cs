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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZakladkiRozszerzone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListView_Books.ItemsSource = Database.Books;
        }

        private void ShowBookmarks(object sender, RoutedEventArgs e)
        {
            Book selectedbook = (sender as Button).CommandParameter as Book;

            Bookmarks bookmarks = new Bookmarks(selectedbook);
            bookmarks.DataContext = selectedbook;
            bookmarks.ShowDialog();
        }

        private void AddBook(object sender, RoutedEventArgs e)
        {
            new AddOrEditBookWindow().ShowDialog();
            ListView_Books.ItemsSource = Database.Books;
        }

        private void EditBook(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (sender as Button).CommandParameter as Book;
            new AddOrEditBookWindow(selectedBook).ShowDialog();
            ListView_Books.ItemsSource = null;
            ListView_Books.ItemsSource = Database.Books;
        }

        private void RemoveBook(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (sender as Button).CommandParameter as Book;
            Database.RemoveBook(selectedBook);
            ListView_Books.DataContext = Database.Books;
        }
    }
}
