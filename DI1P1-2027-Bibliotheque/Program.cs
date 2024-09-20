using DI1P1_2027_Bibliotheque.Entities;

namespace DI1P1_2027_Bibliotheque
{
    public class Program()
    {
        public static void Main(string[] args)
        {
            string eventstring = "";
            ScreensEntity screensEntity = new ScreensEntity();
            LibraryEntity libraryEntity = new LibraryEntity();
            while (eventstring != "exit")
            {
                screensEntity.ShowMainMenu();
                eventstring = Console.ReadLine() ?? "";
                Console.WriteLine("\n\n");
                if(eventstring == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                if (eventstring == "1")
                {
                    libraryEntity = screensEntity.ShowAddBookMenu(libraryEntity);
                }
                else if (eventstring == "2")
                {
                    libraryEntity = screensEntity.ShowAddUserMenu(libraryEntity);
                }
                else if (eventstring == "3")
                {
                    libraryEntity = screensEntity.ShowAddAuthorMenu(libraryEntity);
                }
                else if (eventstring == "4")
                {

                }
                else if (eventstring == "5")
                {
                    screensEntity.ShowListBookMenu(libraryEntity);
                }
                else if (eventstring == "6")
                {
                    screensEntity.ShowListUsersMenu(libraryEntity);
                }
                else if (eventstring == "7")
                {
                    screensEntity.ShowListAuthorsMenu(libraryEntity);
                }
                else if (eventstring == "8")
                {

                }

                if (eventstring != "exit")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.WriteLine("\n===============\n");
            }
        }
    }
}