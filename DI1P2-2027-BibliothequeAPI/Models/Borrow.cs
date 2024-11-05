namespace DI1P2_2027_BibliothequeAPI.Models
{
    using DI1P2_2027_BibliothequeAPI.Models.Contracts;
    public class Borrow:IBorrowModel
    {
        public uint id { get; set; } = 0;
        public IBookModel book { get; set; } = new Book();
        public IUserModel user { get; set; } = new User();
        public DateTime date { get; set; } = DateTime.Now;

        public void SetId(uint id)
        {
            this.id = id;
        }
        public uint GetId()
        {
            return this.id;
        }
        public void SetBook(IBookModel book)
        {
            this.book = book;
        }
        public IBookModel GetBook()
        {
            return this.book;
        }
        public void SetUser(IUserModel user)
        {
            this.user = user;
        }
        public IUserModel GetUser()
        {
            return this.user;
        }
    }
}
