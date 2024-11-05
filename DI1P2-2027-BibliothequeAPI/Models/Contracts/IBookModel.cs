namespace DI1P2_2027_BibliothequeAPI.Models.Contracts
{
    public interface IBookModel
    {
        public uint isbn { get; set; }
        public string title {  get; set; }
        public string publishdate { get; set; }
        public IAuthorModel author { get; set; }

        public void SetIsbn(uint isbn);
        public uint GetIsbn();
        public void SetTitle(string title);
        public string GetTitle();
        public void SetPublishDate(string publishdate);
        public string GetPublishDate();
        public void SetAuthor(IAuthorModel author);
        public IAuthorModel GetAuthor();
    }
}
