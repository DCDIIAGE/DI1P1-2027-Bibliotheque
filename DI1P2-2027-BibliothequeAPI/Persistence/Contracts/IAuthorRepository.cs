namespace DI1P2_2027_BibliothequeAPI.Persistence.Contracts
{
    using DI1P2_2027_BibliothequeAPI.Models;
    public interface IAuthorRepository
    {
        public void SetAuthor(Author author);
        public ICollection<Author> GetAllAuthors();
        public ICollection<Author> GetAllAuthorsByName(string authorname);

        public ICollection<Author> GetAllAuthorsByFirstname(string authorfirstname);
        public Author GetAuthorById(uint id);
        public void AddAuthor(Author author);
    }
}
