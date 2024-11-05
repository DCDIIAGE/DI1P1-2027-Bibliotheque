namespace DI1P2_2027_BibliothequeAPI.Models
{
    using DI1P2_2027_BibliothequeAPI.Models.Contracts;
    public class Book:IBookModel
    {
        public uint isbn { get; set; } = 0;
        public string title { get; set; } = "No title";
        public string publishdate { get; set; } = "No publish date";
        public IAuthorModel author { get; set; } = new Author();

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
        public void SetAuthor(IAuthorModel author)
        {
            this.author = author;
        }
        public IAuthorModel GetAuthor()
        {
            return this.author;
        }
    }
}
