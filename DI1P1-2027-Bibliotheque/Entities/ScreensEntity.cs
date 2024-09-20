using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI1P1_2027_Bibliotheque.Entities
{
    public class ScreensEntity
    {
        public void ShowMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Chose an option");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1- Add book");
            Console.WriteLine("2- Add user");
            Console.WriteLine("3- Add author");
            Console.WriteLine("4- Add borrow");
            Console.WriteLine("5- Show books");
            Console.WriteLine("6- Show users");
            Console.WriteLine("7- Show authors");
            Console.WriteLine("8- Show borrows");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nwrite exit to exit");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public LibraryEntity ShowAddBookMenu(LibraryEntity library)
        {
            BookEntity book = new BookEntity();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ISBN book");
            Console.ForegroundColor = ConsoleColor.Green;
            uint isbn;
            string input = Console.ReadLine() ?? "0";

            if (!uint.TryParse(input, out isbn))
            {
                isbn = 0;
            }

            book.SetIsbn(isbn);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Book title");
            Console.ForegroundColor = ConsoleColor.Green;
            book.SetTitle(Console.ReadLine() ?? "No title");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Publish date");
            Console.ForegroundColor = ConsoleColor.Green;
            book.SetPublishDate(Console.ReadLine() ?? "No publish date");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Chose author");
            Console.ForegroundColor = ConsoleColor.White;
            library.GetAllAuthors().ForEach(author =>
            {
                Console.WriteLine(author.GetId()+"- "+author.GetAuthorName()+" "+author.GetAuthorFirstname());
            });
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nWrite No to make book anonymous");
            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine() ?? "1";

            if (!uint.TryParse(input, out isbn))
            {
                isbn = 1;
            }
            book.SetAuthor(library.GetAllAuthors().FirstOrDefault(author => author.GetId() == isbn) ?? new());

            if(library.IsIsbnExist(book.GetIsbn()))
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"{book.GetIsbn()} isbn is already given to other book");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                library.AddBook(book);
            }
            return library;
        }

        public LibraryEntity ShowAddAuthorMenu(LibraryEntity library)
        {
            AuthorEntity author = new();
            
            author.SetId((library.GetAllAuthors().LastOrDefault() ?? new()).GetId() + 1);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Author name");
            Console.ForegroundColor = ConsoleColor.Green;
            author.SetAuthorName(Console.ReadLine() ?? "No name");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Author firstname");
            Console.ForegroundColor = ConsoleColor.Green;
            author.SetAuthorFirstName(Console.ReadLine() ?? "No firstname");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Author description");
            Console.ForegroundColor = ConsoleColor.Green;
            author.SetDescription(Console.ReadLine() ?? "No description");

            library.AddAuthor(author);
            return library;
        }
        public void ShowListBookMenu(LibraryEntity library)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Chose an option");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1- Show All");
            Console.WriteLine("2- Show by author");
            Console.WriteLine("3- Show by date");
            Console.WriteLine("4- Show by ISBN");
            Console.ForegroundColor= ConsoleColor.Green;

            uint num;
            string input = Console.ReadLine() ?? "1";

            if (!uint.TryParse(input, out num))
            {
                num = 1;
            }

            List<BookEntity> books = new List<BookEntity>();
            if (num == 1)
            {
                books = library.GetAllBooks();
            }
            else if (num == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Author name");
                Console.ForegroundColor = ConsoleColor.White;
                library.GetAllAuthors().ForEach(author =>
                {
                    Console.WriteLine(author.GetId() + "- " + author.GetAuthorName() + " " + author.GetAuthorFirstname());
                });
                Console.ForegroundColor = ConsoleColor.Green;
                uint id = 1;
                input = Console.ReadLine() ?? "1";
                if (!uint.TryParse(input, out id))
                {
                    id = 1;
                }
                books = library.GetAllBooksByAuthorId(id);
            }
            else if (num == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Publish date");
                Console.ForegroundColor = ConsoleColor.Green;
                books = library.GetAllBooksByPublishDate(Console.ReadLine() ?? "01-01-2000");
            }
            else if (num == 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ISBN");
                Console.ForegroundColor = ConsoleColor.Green;

                input = Console.ReadLine() ?? "1";

                if (!uint.TryParse(input, out num))
                {
                    num = 1;
                }
                BookEntity havebook = library.GetBookByIsbn(num);
                if (havebook != null && havebook.GetIsbn() != 0)
                {
                    books.Add(havebook);
                }
            }

            if(books.Count > 0)
            {
                books.ForEach(book =>
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\nISBN:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(book.GetIsbn());

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Title:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(book.GetTitle());

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Publish date:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(book.GetPublishDate());

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Author:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("id:"+book.GetAuthor().GetId()+"\tname:"+book.GetAuthor().GetAuthorName()+"\tfirstname:"+book.GetAuthor().GetAuthorFirstname());

                });
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("No book found");
            }
        }

        public void ShowListAuthorsMenu(LibraryEntity library)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Chose an option");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1- Show All");
            Console.WriteLine("2- Show by author name");
            Console.WriteLine("3- Show by author firstname");
            Console.WriteLine("4- Show by ID");
            Console.ForegroundColor = ConsoleColor.Green;

            string input = Console.ReadLine() ?? "1";

            if (!uint.TryParse(input, out uint num))
            {
                num = 1;
            }

            List<AuthorEntity> authors = [];
            if (num == 1)
            {
                authors = library.GetAllAuthors();
            }
            else if (num == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Author name");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine() ?? "";
                authors = library.GetAllAuthorsByName(input);
            }
            else if (num == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Author firstname");
                Console.ForegroundColor = ConsoleColor.Green;
                authors = library.GetAllAuthorsByFirstname(Console.ReadLine() ?? "01-01-2000");
            }
            else if (num == 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ID");
                Console.ForegroundColor = ConsoleColor.Green;

                input = Console.ReadLine() ?? "1";

                if (!uint.TryParse(input, out num))
                {
                    num = 1;
                }
                AuthorEntity haveauthor = library.GetAuthorById(num);
                if (haveauthor != null && haveauthor.GetId() != 0)
                {
                    authors.Add(haveauthor);
                }
            }

            if (authors.Count > 0)
            {
                authors.ForEach(author =>
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\nID:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(author.GetId());

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("name:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(author.GetAuthorName());

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Firstname:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(author.GetAuthorFirstname());

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Description:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(author.GetDescription());

                });
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("No book found");
            }
        }
    }
}
