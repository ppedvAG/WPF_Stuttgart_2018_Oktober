using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class BookSearchService
    {
        public async static Task<IList<Book>> SucheBücherAsync(string name)
        {
            BookSearchResult result = null;
            try
            {
                HttpClient client = new HttpClient();
                string jsonString = await client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={name}");
                //Sorgt dafür, dass der Klassen-Name mit ins JSON geschrieben wird, wichtig bei polymorphen Listen
                JsonSerializerSettings settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects };
                result = JsonConvert.DeserializeObject<BookSearchResult>(jsonString, settings);
            }
            catch (Exception)
            {
                return new List<Book>();
            }
          


            //if(result.items != null)
            //    return new List<Book>(result.items);

            if(result.items != null) {
                List<Book> multiplayBooks = new List<Book>();
                for (int i = 0; i < 1000; i++)
                {
                    foreach (var item in result.items)
                    {
                        multiplayBooks.Add(item);
                        
                    }
                }
                return multiplayBooks;
            }
           

            return new List<Book>();
        }
    }
}
