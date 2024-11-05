namespace DI1P2_2027_BibliothequeAPI.Models
{
    using DI1P2_2027_BibliothequeAPI.Models.Contracts;
    public class Book:IBookModel
    {
        public uint isbn { get; set; } = 0;
        public string title { get; set; } = "No title";
        public string publishdate { get; set; } = "No publish date";
        public uint authorId { get; set; }
        public Author authorCast { get; set; } = new Author();
        IAuthorModel IBookModel.author
        {
            get => authorCast;
            set => authorCast = (Author)value;
        }

        public void SetIsbn(uint isbn) => this.isbn = isbn;
        public uint GetIsbn() => this.isbn;

        public void SetTitle(string title) => this.title = title;
        public string GetTitle() => this.title;

        public void SetPublishDate(string publishdate) => this.publishdate = publishdate;
        public string GetPublishDate() => this.publishdate;

        public void SetAuthor(IAuthorModel author) => authorCast = (Author)author;
        public IAuthorModel GetAuthor() => authorCast;
    }
}
