namespace DI1P2_2027_BibliothequeAPI.Models.Contracts
{
    public interface IBorrowModel
    {
        public uint id { get; set; }
        public IBookModel book { get; set; }
        public IUserModel user { get; set; }
        public DateTime date { get; set; }

        public void SetId(uint id);
        public uint GetId();
        public void SetBook(IBookModel book);
        public IBookModel GetBook();
        public void SetUser(IUserModel user);
        public IUserModel GetUser();
    }
}