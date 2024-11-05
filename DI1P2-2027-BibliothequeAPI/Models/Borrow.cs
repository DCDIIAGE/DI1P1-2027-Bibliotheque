namespace DI1P2_2027_BibliothequeAPI.Models
{
    using DI1P2_2027_BibliothequeAPI.Models.Contracts;
    public class Borrow:IBorrowModel
    {
        public uint id { get; set; } = 0;
        public uint bookIsbn { get; set; }
        public Book bookCast { get; set; } = new Book();
        public uint userId { get; set; }
        public User userCast { get; set; } = new User();
        public DateTime date { get; set; } = DateTime.Now;

        IBookModel IBorrowModel.book { get => bookCast; set => bookCast = (Book)value; }
        IUserModel IBorrowModel.user { get => userCast; set => userCast = (User)value; }

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
            this.bookCast = (Book)book;
        }
        public IBookModel GetBook()
        {
            return this.bookCast;
        }
        public void SetUser(IUserModel user)
        {
            this.userCast = (User)user;
        }
        public IUserModel GetUser()
        {
            return this.userCast;
        }
    }
}
