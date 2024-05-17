using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakladkiRozszerzone
{
    public class Book
    {
        public ObservableCollection<Bookmark> Bookmarks { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverURL { get; set; }
        public DateTime PublishedOn { get; set; }
        public string PublishedOnString { get { return PublishedOn.ToString("dd.MM.yyyy"); } }

        public Book(string title, string description, string author, string coverUrl, DateTime publishedOn)
        {
            Bookmarks = new ObservableCollection<Bookmark>();
            Title = title;
            Description = description;
            Author = author;
            CoverURL = coverUrl;
            PublishedOn = publishedOn;
        }

        public void AddBookmark(Bookmark bookmark)
        {
            Bookmarks.Add(bookmark);
            Database.SaveDataBaseToJsonFile();
        }

        public void RemoveBookmark(Bookmark bookmark)
        {
            Bookmarks.Remove(bookmark);
            Database.SaveDataBaseToJsonFile();
        }
    }
}
