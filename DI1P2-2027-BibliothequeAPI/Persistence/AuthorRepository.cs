namespace DI1P2_2027_BibliothequeAPI.Persistence
{
    using DI1P2_2027_BibliothequeAPI.Persistence.Contracts;
    using DI1P2_2027_BibliothequeAPI.Models;
    public class AuthorRepository(BibliothequeDbContext context) : IAuthorRepository
    {
        public void SetAuthor(Author author)
        {
            var existingAuthor = context.Authors.FirstOrDefault(b => b.id == author.id);
            if (existingAuthor != null)
            {
                existingAuthor.name = author.name;
                existingAuthor.firstname = author.firstname;
                existingAuthor.description = author.description;

                context.SaveChanges();
            }
        }
        public ICollection<Author> GetAllAuthors()
        {
            return context.Authors.AsQueryable().ToList();
        }
        public ICollection<Author> GetAllAuthorsByName(string authorname)
        {
            return context.Authors.AsQueryable().ToList().Where(author => author.GetAuthorName() == authorname).ToList();
        }

        public ICollection<Author> GetAllAuthorsByFirstname(string authorfirstname)
        {
            return context.Authors.AsQueryable().ToList().Where(author => author.GetAuthorFirstname() == authorfirstname).ToList();
        }
        public Author GetAuthorById(uint id)
        {
            return context.Authors.FirstOrDefault(author => author.GetId() == id) ?? new();
        }
        public void AddAuthor(Author author)
        {
            try
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
