using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Models
{
    public class BookSearchResult
    {
        public string kind { get; set; }
        public int totalItems { get; set; }
        public Book[] items { get; set; }
    }

    public class Book : INotifyPropertyChanged
    {
        public string id { get; set; }
        public Volumeinfo volumeInfo { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isFavorite = false;
        public bool IsFavorite
        {
            get
            {
                return _isFavorite;
            }
            set {
                _isFavorite = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFavorite)));
            }
        }
    }

    public class Volumeinfo
    {
        public string title { get; set; }
        public string[] authors { get; set; }
        public string publisher { get; set; }
        public string maturityRating { get; set; }
        public Imagelinks imageLinks { get; set; }
        public string previewLink { get; set; }
        public string description { get; set; }
    }

    public class Imagelinks
    {
        public string smallThumbnail { get; set; }
        public string thumbnail { get; set; }
    }
}
