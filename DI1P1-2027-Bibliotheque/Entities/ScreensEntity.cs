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
            Console.WriteLine("9- Add status");
            Console.WriteLine("10- Show status");
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

        public LibraryEntity ShowAddUserMenu(LibraryEntity library)
        {
            UserEntity user = new();

            user.SetId((library.GetAllUsers().LastOrDefault() ?? new()).GetId() + 1);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("User name");
            Console.ForegroundColor = ConsoleColor.Green;
            user.SetName(Console.ReadLine() ?? "No name");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("User firstname");
            Console.ForegroundColor = ConsoleColor.Green;
            user.SetFirstname(Console.ReadLine() ?? "No firstname");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("User status");
            Console.ForegroundColor = ConsoleColor.Green;
            user.SetStatus(new());

            library.AddUser(user);
            return library;
        }
        public LibraryEntity ShowAddAuthorMenu(LibraryEntity library)
        {
            AuthorEntity author = new();
            
            author.SetId((library.GetAllStatuses().LastOrDefault() ?? new()).GetId() + 1);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Author name");
            Console.ForegroundColor = ConsoleColor.Green;
            author.SetAuthorName(Console.ReadLine() ?? "No name");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Author firstname");
            Console.ForegroundColor = ConsoleColor.Green;
            author.SetAuthorFirstname(Console.ReadLine() ?? "No firstname");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Author description");
            Console.ForegroundColor = ConsoleColor.Green;
            author.SetDescription(Console.ReadLine() ?? "No description");

            library.AddAuthor(author);
            return library;
        }
        public LibraryEntity ShowAddStatusMenu(LibraryEntity library)
        {
            StatusEntity status = new();

            status.SetId((library.GetAllStatuses().LastOrDefault() ?? new()).GetId() + 1);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Status name");
            Console.ForegroundColor = ConsoleColor.Green;
            status.SetName(Console.ReadLine() ?? "No name");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Status maxbook");
            Console.ForegroundColor = ConsoleColor.Green;
            
            string input = Console.ReadLine() ?? "1";

            if (!uint.TryParse(input, out uint maxbook))
            {
                maxbook = 1;
            }
            status.SetMaxBooks(maxbook);

            library.AddStatus(status);
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
        public void ShowListUsersMenu(LibraryEntity library)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Chose an option");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1- Show All");
            Console.WriteLine("2- Show by user name");
            Console.WriteLine("3- Show by user firstname");
            Console.WriteLine("4- Show by status");
            Console.WriteLine("5- Show by ID");
            Console.ForegroundColor = ConsoleColor.Green;

            string input = Console.ReadLine() ?? "1";

            if (!uint.TryParse(input, out uint num))
            {
                num = 1;
            }

            List<UserEntity> users = [];
            if (num == 1)
            {
                users = library.GetAllUsers();
            }
            else if (num == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("User name");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine() ?? "";
                users = library.GetAllUsersByName(input);
            }
            else if (num == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("User firstname");
                Console.ForegroundColor = ConsoleColor.Green;
                users = library.GetAllUsersByFirstname(Console.ReadLine() ?? "");
            }
            else if (num == 4)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Not implemented");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (num == 5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ID");
                Console.ForegroundColor = ConsoleColor.Green;

                input = Console.ReadLine() ?? "1";

                if (!uint.TryParse(input, out num))
                {
                    num = 1;
                }
                UserEntity haveuser = library.GetUserById(num);
                if (haveuser != null && haveuser.GetId() != 0)
                {
                    users.Add(haveuser);
                }
            }

            if (users.Count > 0)
            {
                users.ForEach(user =>
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\nID:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(user.GetId());

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("name:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(user.GetName());

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Firstname:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(user.GetFirstname());

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Status:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("id:"+user.GetStatus().GetId()+"\tname:"+user.GetStatus().GetName()+"\tmax-book:"+user.GetStatus().GetMaxBooks());

                });
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("No user found");
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
                Console.WriteLine("No author found");
            }
        }
        public void ShowListStatusMenu(LibraryEntity library)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Chose an option");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1- Show All");
            Console.WriteLine("2- Show by status name");
            Console.WriteLine("3- Show where max book is greater than");
            Console.WriteLine("4- Show where max book is less than");
            Console.WriteLine("5- Show by maxbook");
            Console.WriteLine("6- Show by ID");
            Console.ForegroundColor = ConsoleColor.Green;

            string input = Console.ReadLine() ?? "1";

            if (!uint.TryParse(input, out uint num))
            {
                num = 1;
            }

            List<StatusEntity> statuses = [];
            if (num == 1)
            {
                statuses = library.GetAllStatuses();
            }
            else if (num == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Status name");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine() ?? "";
                statuses = library.GetAllStatusesByName(input);
            }
            else if (num == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Status Maxbook");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine() ?? "1";
                if (!uint.TryParse(input, out uint maxbook))
                {
                    num = 1;
                }
                statuses = library.GetAllStatusesWhereMaxBookIsGreaterThan(maxbook);
            }
            else if (num == 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Status Maxbook");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine() ?? "1";
                if (!uint.TryParse(input, out uint maxbook))
                {
                    num = 1;
                }
                statuses = library.GetAllStatusesWhereMaxBookIsLessThan(maxbook);
            }
            else if (num == 5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Status Maxbook");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine() ?? "1";
                if (!uint.TryParse(input, out uint maxbook))
                {
                    num = 1;
                }
                statuses = library.GetAllStatusesByMaxBook(maxbook);
            }
            else if (num == 6)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ID");
                Console.ForegroundColor = ConsoleColor.Green;

                input = Console.ReadLine() ?? "1";

                if (!uint.TryParse(input, out num))
                {
                    num = 1;
                }
                StatusEntity havestatus = library.GetStatusById(num);
                if (havestatus != null && havestatus.GetId() != 0)
                {
                    statuses.Add(havestatus);
                }
            }

            if (statuses.Count > 0)
            {
                statuses.ForEach(status =>
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\nID:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(status.GetId());

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("name:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(status.GetName());

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Maxbook:\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(status.GetMaxBooks());

                });
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("No status found");
            }
        }
    }
}
