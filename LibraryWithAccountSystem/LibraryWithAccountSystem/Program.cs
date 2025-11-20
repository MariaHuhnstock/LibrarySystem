using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new Library object
            Library library = new Library();
            // Create a new Book object
            Book HarryPotter = new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling", "978-0747532699");
            Book LordOfTheRings = new Book("The Lord of the Rings", "J.R.R. Tolkien", "978-0618640157");
            Book TheHobbit = new Book("The Hobbit", "J.R.R. Tolkien", "978-0547928227");
            Book ToKillAMockingbird = new Book("To Kill a Mockingbird", "Harper Lee", "978-0061120084");
            Book PrideAndPrejudice = new Book("Pride and Prejudice", "Jane Austen", "978-1503290563");
            Book TheGreatGatsby = new Book("The Great Gatsby", "F. Scott Fitzgerald", "978-0743273565");
            Book Eislotus = new Book("Eislotus - Wasser findet seinen Weg", "Liza Grimm", "978-3426561546");
            Book Feuerlilie = new Book("Feuerlilie - Asche spendet Leben", "Liza Grimm", "978-3426561560");
            Book Steingladiole = new Book("Steingladiole - Erde vergisst nie", "Liza Grimm", "978-3426568613");
            Book Talus_DieHexenVonEdinburgh = new Book("Talus - Die Hexen von Edinburgh", "Liza Grimm", "978-3426526286");
            Book Talus_DieMagieDesWürfels = new Book("Talus - Die Magie des Würfels", "Liza Grimm", "978-3426526293");
            Book Talus_DieRunenDerMacht = new Book("Talus - Die Runen der Macht", "Liza Grimm", "978-3426-530184");
            Book EternityOnline = new Book("Eternity Online", "Mikkel Robrahn", "978-3596708741");
            Book EternityOnline2 = new Book("Eternity Online 2", "Mikkel Robrahn", "978-3596711659");
            Book EternityOnline3 = new Book("Eternity Online 3", "Mikkel Robrahn", "978-3596712403");

            // Add the book to the library
            library.AddBook(HarryPotter);
            library.AddBook(LordOfTheRings);
            library.AddBook(TheHobbit);
            library.AddBook(ToKillAMockingbird);
            library.AddBook(PrideAndPrejudice);
            library.AddBook(TheGreatGatsby);
            library.AddBook(Eislotus);
            library.AddBook(Feuerlilie);
            library.AddBook(Steingladiole);
            library.AddBook(Talus_DieHexenVonEdinburgh);
            library.AddBook(Talus_DieMagieDesWürfels);
            library.AddBook(Talus_DieRunenDerMacht);
            library.AddBook(EternityOnline);
            library.AddBook(EternityOnline2);
            library.AddBook(EternityOnline3);

            // Simple menu loop
            string input = "";

            while (input != "exit")
            {
                Console.WriteLine("\n--- Library Menu ---");
                Console.WriteLine("1 - Search by ISBN");
                Console.WriteLine("2 - Search by Title");
                Console.WriteLine("3 - Search by Author");
                Console.WriteLine("4 - Show available books");
                Console.WriteLine("5 - Borrow a book (by ISBN)");
                Console.WriteLine("6 - Return a book (by ISBN)");
                Console.WriteLine("7 - Borrow a book (by Title)");
                Console.WriteLine("8 - Return a book (by Title)");
                Console.WriteLine("9 - Show borrowed books");


                Console.WriteLine("exit - Quit");
                Console.Write("Choose an option: ");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Enter ISBN: ");
                        string isbnSearch = Console.ReadLine();
                        Book bookISBN = library.FindBookByISBN(isbnSearch);
                        bookISBN?.PrintInfo();
                        break;

                    case "2":
                        Console.Write("Enter title keyword: ");
                        string titleSearch = Console.ReadLine();
                        library.ShowResults(library.FindBooksByTitle(titleSearch));
                        break;

                    case "3":
                        Console.Write("Enter author keyword: ");
                        string authorSearch = Console.ReadLine();
                        library.ShowResults(library.FindBooksByAuthor(authorSearch));
                        break;

                    case "4":
                        library.ShowAvailableBooks();
                        break;

                    case "5":
                        Console.Write("Enter ISBN to borrow: ");
                        string borrowISBN = Console.ReadLine();
                        Book borrowBook = library.FindBookByISBN(borrowISBN);
                        if (borrowBook != null) borrowBook.Borrow();
                        break;

                    case "6":
                        Console.Write("Enter ISBN to return: ");
                        string returnISBN = Console.ReadLine();
                        Book returnBook = library.FindBookByISBN(returnISBN);
                        if (returnBook != null) returnBook.ReturnBook();
                        break;
                    case "7":
                        Console.Write("Enter title keyword: ");
                        string titleBorrow = Console.ReadLine();
                        var booksByTitle = library.FindBooksByTitle(titleBorrow);

                        if (booksByTitle.Count == 0)
                        {
                            Console.WriteLine("No matching books found!");
                            break;
                        }

                        if (booksByTitle.Count == 1)
                        {
                            booksByTitle[0].Borrow();
                            break;
                        }

                        Console.WriteLine("Multiple books found. Choose one by number:");
                        for (int i = 0; i < booksByTitle.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}: {booksByTitle[i].Titel}");
                        }

                        Console.Write("Enter number: ");
                        if (int.TryParse(Console.ReadLine(), out int index) &&
                            index > 0 && index <= booksByTitle.Count)
                        {
                            booksByTitle[index - 1].Borrow();
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection!");
                        }
                        break;
                    case "8":
                        Console.Write("Enter title keyword: ");
                        string titleReturn = Console.ReadLine();
                        var returnMatches = library.FindBooksByTitle(titleReturn);

                        if (returnMatches.Count == 0)
                        {
                            Console.WriteLine("No matching books found!");
                            break;
                        }

                        if (returnMatches.Count == 1)
                        {
                            returnMatches[0].ReturnBook();
                            break;
                        }

                        Console.WriteLine("Multiple books found. Choose one by number:");
                        for (int i = 0; i < returnMatches.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}: {returnMatches[i].Titel}");
                        }

                        Console.Write("Enter number: ");
                        if (int.TryParse(Console.ReadLine(), out int rIndex) &&
                            rIndex > 0 && rIndex <= returnMatches.Count)
                        {
                            returnMatches[rIndex - 1].ReturnBook();
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection!");
                        }
                        break;
                    case "9":
                        library.ShowBorrowedBooks();
                        break;

                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option! Try again.");
                        break;
                }
            }


        }
    }
    // Define a class to represent a Book in a library
    public class Book
    {
        // Attributes
        public string Titel;
        public string Author;
        public string ISBN;
        public bool IsBorrowed;
        // Constructor
        public Book(string titel, string author, string isbn)
        {
            Titel = titel;
            Author = author;
            ISBN = isbn;
            IsBorrowed = false;
        }
        // Method to borrow the book
        public void Borrow()
        {
            if (!IsBorrowed)
            {
                IsBorrowed = true;
                Console.WriteLine($"{Titel} has been borrowed.");
            }
            else
            {
                Console.WriteLine($"{Titel} is already borrowed.");
            }
        }
        // Method to return the book
        public void ReturnBook()
        {
            if (IsBorrowed)
            {
                IsBorrowed = false;
                Console.WriteLine($"{Titel} has been returned.");
            }
            else
            {
                Console.WriteLine($"{Titel} was not borrowed.");
            }

        }
        // Method to display book information
        public void PrintInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Titel}");
            Console.ResetColor();

            Console.WriteLine($" Author: {Author}");
            Console.WriteLine($" ISBN:   {ISBN}");

            // Console.WriteLine($"IsBorrowed: {IsBorrowed}");
        }
    }
    public class Library
    {
        // Attributes
        private List<Book> books;

        // Constructor
        public Library()
        {
            books = new List<Book>();
        }
        // Method to add a book to the library
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        // Method to show all available books
        public void ShowAvailableBooks()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Available Books:");
            Console.ResetColor();
            foreach (Book book in books)
            {
                if (!book.IsBorrowed)
                {
                    book.PrintInfo();
                    Console.WriteLine(" ");
                }
            }
            Console.WriteLine("-------------------------------------------------------------");
        }
        // Method to show all borrowed books
        public void ShowBorrowedBooks()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Borrowed Books:");
            Console.ResetColor();
            foreach (Book book in books)
            {
                if (book.IsBorrowed)
                {
                    book.PrintInfo();
                    Console.WriteLine(" ");
                }
            }
            Console.WriteLine("-------------------------------------------------------------");
        }
        // Method to find a book by ISBN
        public Book FindBookByISBN(string isbn)
        {
            foreach (Book book in books)
            {
                if (book.ISBN == isbn)
                {
                    return book;
                }
            }

            Console.WriteLine("No book with this ISBN found!");
            return null;
        }
        // Method to find books by title
        public List<Book> FindBooksByTitle(string title)
        {
            List<Book> results = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Titel.ToLower().Contains(title.ToLower()))
                {
                    results.Add(book);
                }
            }

            return results;
        }
        // Method to find books by author
        public List<Book> FindBooksByAuthor(string author)
        {
            List<Book> results = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Author.ToLower().Contains(author.ToLower()))
                {
                    results.Add(book);
                }
            }

            return results;
        }
        // Method to display search results
        public void ShowResults(List<Book> books)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books found!");
            }
            else
            {
                foreach (var b in books)
                {
                    b.PrintInfo();
                    Console.WriteLine("----------------------------------");
                }
            }
        }
    }
}
