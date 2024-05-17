using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakladkiRozszerzone
{
    public static class Database
    {
        private static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Books", "books.json");
        public static ObservableCollection<Book> Books { get; private set; }

        static Database()
        {
            if(Books == null)
            {
                ReadDataBaseFromJsonFile();
            }
        }

        public static void AddBook(Book book)
        {
            Books.Add(book);
            SaveDataBaseToJsonFile();
            return;
        }

        public static void EditBook(Book selectedBook, Book editedBook)
        {
            foreach (Book entry in Books)
            {
                if(ReferenceEquals(entry, selectedBook))
                {
                    entry.Title = editedBook.Title;
                    entry.Description = editedBook.Description;
                    entry.Author = editedBook.Author;
                    entry.CoverURL = editedBook.CoverURL;
                    entry.PublishedOn = editedBook.PublishedOn;
                    break;
                }
            }
            SaveDataBaseToJsonFile();
            return;
        }

        public static void RemoveBook(Book book)
        {
            foreach(Book entry in Books)
            {
                if(ReferenceEquals(entry, book))
                {
                    Books.Remove(entry);
                    break;
                }
            }
            SaveDataBaseToJsonFile();
            return;
        }

        private static void ReadDataBaseFromJsonFile()
        {
            if(File.Exists(dbPath))
            {
                string serializedDataBase = File.ReadAllText(dbPath);
                ObservableCollection<Book> books = JsonConvert.DeserializeObject<ObservableCollection<Book>>(serializedDataBase);

                Books = books;
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Books"));

                string serializedDataBase = JsonConvert.SerializeObject(new ObservableCollection<Book>());
                File.WriteAllText(dbPath, serializedDataBase);

                Books = new ObservableCollection<Book>();
            }
            return;
        }

        public static void SaveDataBaseToJsonFile()
        {
            if(File.Exists(dbPath))
            {
                string serializedDataBase = JsonConvert.SerializeObject(Books);
                File.Delete(dbPath);
                File.WriteAllText(dbPath, serializedDataBase);
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Books"));

                string serializedDataBase = JsonConvert.SerializeObject(new ObservableCollection<Book>());
                File.WriteAllText(dbPath, serializedDataBase);

                Books = new ObservableCollection<Book>();
            }
            return;
        }
    }
}
