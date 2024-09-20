using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI1P1_2027_Bibliotheque.Entities
{
    public class BookEntity
    {
        private uint isbn = 0;
        private string title = "No title";
        private string publishdate = "No publish date";
        AuthorEntity author = new AuthorEntity();

        public void SetIsbn(uint isbn)
        {
            this.isbn = isbn;
        }
        public uint GetIsbn()
        {
            return this.isbn;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public string GetTitle()
        {
            return this.title;
        }
        public void SetPublishDate(string publishdate)
        {
            this.publishdate = publishdate;
        }
        public string GetPublishDate()
        {
            return this.publishdate;
        }
        public void SetAuthor(AuthorEntity author)
        {
            this.author = author;
        }
        public AuthorEntity GetAuthor()
        {
            return this.author;
        }
    }
}
