using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Models
{
    public static class FavoriteBooksManager
    {
        public static List<Book> FavoriteBooks { get; set; }
        public const string Favorite_List_Filename = "favoritebooks.fb";



        //Der statische Konstruktor wird beim ersten Zugriff auf einen Member der Klasse aufgerufen
        static FavoriteBooksManager()
        {
            //Schaue nach ob es eine gespeicherte FavoritenListe gibt
            try
            {
                using (StreamReader reader = new StreamReader(Favorite_List_Filename))
                {
                    string jsonString = reader.ReadToEnd(); 
                    FavoriteBooks = JsonConvert.DeserializeObject<List<Book>>(jsonString);
                    FavoriteBooks.ForEach(b => b.IsFavorite = true);
                }
            }
            catch (Exception)
            {
                FavoriteBooks = new List<Book>();
            }
        }

        public static (bool, string) SaveFavorites()
        {
            try
            {
                //Speichern
                using (StreamWriter writer = new StreamWriter(Favorite_List_Filename, false))
                {
                    string jsonString = JsonConvert.SerializeObject(FavoriteBooks);
                    writer.Write(jsonString);
                }
            }
            catch (Exception exp)
            {
                return (false, exp.Message);
            }
            return (true, "");
        }

        public static (bool success, string errorString) AddFavoriteBook(Book newBook)
        {
            newBook.IsFavorite = true;
            //Prüfen ob das Buch bereits als Favorit hinzugefügt wurde
            if(FavoriteBooks.Exists(b => b.id == newBook.id))
            {
                return (false, "Buch existiert bereits");
            }
            newBook.IsFavorite = true;
            FavoriteBooks.Add(newBook);

            SaveFavorites();

            return SaveFavorites();
        }

        public static (bool success, string errorString) RemoveFavoriteBook(Book newBook)
        {
            newBook.IsFavorite = false;
            if (!FavoriteBooks.Exists(b => b.id == newBook.id))
            {
                return (false, "Buch existiert nicht!");
            }
            newBook.IsFavorite = false;
            FavoriteBooks.Remove(newBook);

            return SaveFavorites();
        }

        /// <summary>
        /// Prüfe alle Bücher darauf, ob sie bereits in der FavoritenListe enthalten sind
        /// und setze dann ihr IsFavorite-Eigenschaft auf true
        /// </summary>
        /// <param name="books">Zu prüfende Bücher</param>
        public static void MarkiereFavoriteBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                if(FavoriteBooks.Exists(b => b.id == book.id))
                {
                    book.IsFavorite = true;
                }
            }
        }
    }
}