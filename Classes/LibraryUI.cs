using Library.Interfaces;
using System;
using System.Collections.Generic;

namespace Library.Classes
{
    class LibraryUI
    {
        private MyLibrary library;
        private string currentBorrowerId;

        public LibraryUI()
        {
            library = new MyLibrary();
            currentBorrowerId = "";
        }

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== Университетская библиотека ===");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу");
                Console.WriteLine("3. Поиск книги");
                Console.WriteLine("4. Читательская карта");
                Console.WriteLine("5. Выйти");

                Console.Write("Выберите действие (1-5): ");
                string input = Console.ReadLine();

                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        RemoveBook();
                        break;
                    case "3":
                        SearchBooks();
                        break;
                    case "4":
                        BorrowerCardMenu();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private void BorrowerCardMenu()
        {
            Console.WriteLine("=== Читательская карта ===");
            Console.WriteLine("1. Создать новую карту");
            Console.WriteLine("2. Просмотреть книги на карте");
            Console.WriteLine("3. Добавить книгу на карту");
            Console.WriteLine("4. Удалить книгу с карты");
            Console.WriteLine("5. Вернуться в основное меню");

            Console.Write("Выберите действие (1-5): ");
            string input = Console.ReadLine();

            Console.WriteLine();

            switch (input)
            {
                case "1":
                    CreateBorrowerCard();
                    break;
                case "2":
                    ViewBorrowerCard();
                    break;
                case "3":
                    AddBookToBorrowerCard();
                    break;
                case "4":
                    RemoveBookFromBorrowerCard();
                    break;
                case "5":
                    currentBorrowerId = "";
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    Console.WriteLine();
                    break;
            }
        }
        private void CreateBorrowerCard()
        {
            Console.Write("Введите ID читателя: ");
            string borrowerId = Console.ReadLine();

            if (!string.IsNullOrEmpty(borrowerId))
            {
                currentBorrowerId = borrowerId;
                Console.WriteLine("Читательская карта успешно создана.");
            }
            else
            {
                Console.WriteLine("ID читателя не может быть пустым.");
            }

            Console.WriteLine();
        }

        private void ViewBorrowerCard()
        {
            if (!string.IsNullOrEmpty(currentBorrowerId))
            {
                List<IBook> books = library.GetBooksByBorrower(currentBorrowerId);

                if (books.Count > 0)
                {
                    Console.WriteLine($"Книги на читательской карте {currentBorrowerId}:");
                    foreach (IBook book in books)
                    {
                        Console.Write($"- {book.getTitle()} by {book.getAuthor()}, {book.getYearOfPublication()}, Electronic: {book.isElectronicVersions()}");
                        if (book is Textbook)
                        {
                            Console.WriteLine($"Subject: {(book as Textbook).getSubject()}, Course: {(book as Textbook).getCourse()}");
                        }
                        else if (book is ResearchPaper)
                        {
                            Console.WriteLine($"Journal name: {(book as ResearchPaper).getJournal()}, Journal quartel: {(book as ResearchPaper).getJournalQuartile()}");
                        }
                        else {
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("На читательской карте нет книг.");
                }
            }
            else
            {
                Console.WriteLine("Читательская карта не создана.");
            }

            Console.WriteLine();
        }

        private void AddBookToBorrowerCard()
        {
            if (!string.IsNullOrEmpty(currentBorrowerId))
            {
                Console.WriteLine("=== Добавление книги на карту ===");

                Console.Write("Автор: ");
                string author = Console.ReadLine();

                Console.Write("Название: ");
                string title = Console.ReadLine();

                List<IBook> books = library.GetBooksByAuthorAndTitle(author, title);

                if (books.Count > 0)
                {
                    Console.WriteLine("Найденные книги:");
                    for (int i = 0; i < books.Count; i++)
                    {                
                        Console.Write($"{i + 1}- {books[i].getTitle()} by {books[i].getAuthor()}, {books[i].getYearOfPublication()}, Electronic: {books[i].isElectronicVersions()}");
                        if (books[i] is Textbook)
                        {
                            Console.WriteLine($"Subject: {(books[i] as Textbook).getSubject()}, Course: {(books[i] as Textbook).getCourse()}");
                        }
                        else if (books[i] is ResearchPaper)
                        {
                            Console.WriteLine($"Journal title: {(books[i] as ResearchPaper).getJournal()}, Journal quartel: {(books[i] as ResearchPaper).getJournalQuartile()}");
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }

                    Console.Write("Выберите номер книги для добавления: ");
                    string bookNumberInput = Console.ReadLine();
                    if (int.TryParse(bookNumberInput, out int bookNumber) && bookNumber >= 1 && bookNumber <= books.Count)
                    {
                        IBook selectedBook = books[bookNumber - 1];
                        library.AddBookToBorrowerCard(currentBorrowerId, selectedBook);
                        Console.WriteLine("Книга успешно добавлена на карту.");
                    }
                    else
                    {
                        Console.WriteLine("Неверный номер книги.");
                    }
                }
                else
                {
                    Console.WriteLine("Книга не найдена в библиотеке.");
                }
            }
            else
            {
                Console.WriteLine("Читательская карта не создана.");
            }

            Console.WriteLine();
        }

        private void RemoveBookFromBorrowerCard()
        {
            if (!string.IsNullOrEmpty(currentBorrowerId))
            {
                Console.WriteLine("=== Удаление книги с карты ===");

                Console.Write("Автор: ");
                string author = Console.ReadLine();

                Console.Write("Название: ");
                string title = Console.ReadLine();

                List<IBook> booksToRemove = library.GetBooksByAuthorAndTitle(author, title);

                if (booksToRemove.Count > 0)
                {
                    Console.WriteLine("Найденные книги:");
                    for (int i = 0; i < booksToRemove.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {booksToRemove[i].getTitle()} by {booksToRemove[i].getAuthor()}, {booksToRemove[i].getYearOfPublication()}, Electronic: {booksToRemove[i].isElectronicVersions()}");
                    }

                    Console.Write("Выберите номер книги для удаления: ");
                    string bookNumberInput = Console.ReadLine();
                    if (int.TryParse(bookNumberInput, out int bookNumber) && bookNumber >= 1 && bookNumber <= booksToRemove.Count)
                    {
                        IBook selectedBook = booksToRemove[bookNumber - 1];
                        library.RemoveBookFromBorrowerCard(currentBorrowerId, selectedBook);
                        Console.WriteLine("Книга успешно удалена с карты.");
                    }
                    else
                    {
                        Console.WriteLine("Неверный номер книги.");
                    }
                }
                else
                {
                    Console.WriteLine("Книга не найдена на карте.");
                }
            }
            else
            {
                Console.WriteLine("Читательская карта не создана.");
            }

            Console.WriteLine();
        }

        private void AddBook()
        {
            Console.WriteLine("=== Добавление книги ===");

            Console.Write("Автор: ");
            string author = Console.ReadLine();

            Console.Write("Название: ");
            string title = Console.ReadLine();

            Console.Write("Ключевые слова (через запятую): ");
            string keywordsInput = Console.ReadLine();
            string[] keywords = keywordsInput.Split(',');

            Console.Write("Год публикации: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Электронная версия (true/false): ");
            bool electronic = bool.Parse(Console.ReadLine());
            Console.WriteLine("Это учебник или научный журнал(н - научный журнал, у - учебная литература, к - книга): ");
            char type = char.Parse(Console.ReadLine());
            if (type == 'н' || type == 'Н')
            {
                Console.Write("Введите квартель журнала: ");
                int journalQuartel = int.Parse((Console.ReadLine()));
                Console.Write("Введите название статьи журнала: ");
                string journal = Console.ReadLine();
                IBook book = new ResearchPaper(author, title, keywords, year, electronic,journal,journalQuartel);
                library.AddBook(book);
            }
            else if (type == 'у' || type == 'У')
            {
                Console.Write("Введите курс: ");
                int course = int.Parse((Console.ReadLine()));
                Console.Write("Введите название предмета: ");
                string subject = Console.ReadLine();
                IBook book = new Textbook(author, title, keywords, year, electronic,subject, course);
                library.AddBook(book);
            }
            else if(type == 'к' || type =='К')
            {
                IBook book = new ConcreteBook(author, title, keywords, year, electronic);
                library.AddBook(book);
            }

            Console.WriteLine("Книга успешно добавлена в библиотеку.");
            Console.WriteLine();
        }

        private void RemoveBook()
        {
            Console.WriteLine("=== Удаление книги ===");

            Console.Write("Автор: ");
            string author = Console.ReadLine();

            Console.Write("Название: ");
            string title = Console.ReadLine();

            List<IBook> booksToRemove = library.GetBooksByAuthorAndTitle(author, title);

            if (booksToRemove.Count > 0)
            {
                foreach (Book book in booksToRemove)
                {
                    library.RemoveBook(book);
                }

                Console.WriteLine("Книга успешно удалена из библиотеки.");
            }
            else
            {
                Console.WriteLine("Книга не найдена в библиотеке.");
            }

            Console.WriteLine();
        }

        private void SearchBooks()
        {
            Console.WriteLine("=== Поиск книги ===");

            Console.Write("Автор (оставьте пустым, чтобы пропустить): ");
            string author = Console.ReadLine();

            Console.Write("Год публикации (оставьте пустым, чтобы пропустить): ");
            string yearInput = Console.ReadLine();
            int year = 0;
            if (!string.IsNullOrEmpty(yearInput))
            {
                year = int.Parse(yearInput);
            }

            Console.Write("Только электронные версии (true/false, оставьте пустым, чтобы пропустить): ");
            string electronicInput = Console.ReadLine();
            bool electronicOnly = false;
            if (!string.IsNullOrEmpty(electronicInput))
            {
                electronicOnly = bool.Parse(electronicInput);
            }

            List<IBook> books = library.GetBooksByParameters(author, year, electronicOnly);

            if (books.Count > 0)
            {
                Console.WriteLine("Найденные книги:");
                foreach (Book book in books)
                {
                    Console.Write($"- {book.getTitle()} by {book.getAuthor()}, {book.getYearOfPublication()}, Electronic: {book.isElectronicVersions()}");
                    if (book is Textbook)
                    {
                        Console.WriteLine($", Subject: {(book as Textbook).getSubject()}, Course: {(book as Textbook).getCourse()}");
                    }
                    else if (book is ResearchPaper)
                    {
                        Console.WriteLine($", Journal title: {(book as ResearchPaper).getJournal()}, Journal quartel: {(book as ResearchPaper).getJournalQuartile()}");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Книги не найдены.");
            }

            Console.WriteLine();
        }
    }
}
