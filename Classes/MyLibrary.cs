using Library.Interfaces;
using System.Collections.Generic;

namespace Library.Classes
{
    class MyLibrary : ILibrary
    {
        private List<IBook> books;

        private Dictionary<string, List<IBook>> borrowerCards;

        public MyLibrary()
        {
            books = new List<IBook>()
            {
                new ConcreteBook("Иван Иванов", "Основы программирования", new string[] { "программирование", "компьютеры", "алгоритмы" }, 2020, true),
                new ConcreteBook("Анна Сидорова", "Математический анализ", new string[] { "математика", "анализ", "дифференцирование", "интегрирование" }, 2018, false),
                new ConcreteBook("Петр Петров", "История России", new string[] { "история", "Россия", "события", "лидеры" }, 2015, true),
                new ConcreteBook("Елена Иванова", "Физика введение", new string[] { "физика", "наука", "законы", "эксперименты" }, 2019, false),
                new ConcreteBook("Мария Смирнова", "Английский язык", new string[] { "английский", "язык", "грамматика", "словарь" }, 2021, true),
                new ConcreteBook("Алексей Кузнецов", "Философия истории", new string[] { "философия", "история", "теории", "анализ" }, 2017, false),
                new ConcreteBook("Дмитрий Новиков", "Экономика введение", new string[] { "экономика", "финансы", "рынок", "макроэкономика" }, 2020, true),
                new ConcreteBook("Ольга Васильева", "Психология развития", new string[] { "психология", "развитие", "дети", "психологические процессы" }, 2016, true),
                new ConcreteBook("Екатерина Лебедева", "Социология современности", new string[] { "социология", "общество", "социальные процессы", "исследования" }, 2019, true),
                new ConcreteBook("Александр Соколов", "Медицинская биохимия", new string[] { "биохимия", "медицина", "биомолекулы", "метаболизм" }, 2018, false)
            };
            borrowerCards = new Dictionary<string, List<IBook>>();
        }

        public void AddBookToBorrowerCard(string borrowerId, IBook book)
        {
            if (borrowerCards.ContainsKey(borrowerId))
            {
                borrowerCards[borrowerId].Add(book);
            }
            else
            {
                List<IBook> books = new List<IBook> { book };
                borrowerCards.Add(borrowerId, books);
            }
        }

        public void RemoveBookFromBorrowerCard(string borrowerId, IBook book)
        {
            if (borrowerCards.ContainsKey(borrowerId))
            {
                borrowerCards[borrowerId].Remove(book);
            }
        }

        public List<IBook> GetBooksByBorrower(string borrowerId)
        {
            if (borrowerCards.ContainsKey(borrowerId))
            {
                return borrowerCards[borrowerId];
            }
            else
            {
                return new List<IBook>();
            }
        }

        public void AddBook(IBook book)
        {
            books.Add(book);
        }

        public void RemoveBook(IBook book)
        {
            books.Remove(book);
        }

        public List<IBook> GetBooksByAuthor(string author)
        {
            List<IBook> result = new List<IBook>();

            foreach (Book book in books)
            {
                if (book.getAuthor().Equals(author))
                {
                    result.Add(book);
                }
            }

            return result;
        }

        public List<IBook> GetBooksByYear(int year)
        {
            List<IBook> result = new List<IBook>();

            foreach (Book book in books)
            {
                if (book.getYearOfPublication() == year)
                {
                    result.Add(book);
                }
            }

            return result;
        }

        public List<IBook> GetElectronicBooks()
        {
            List<IBook> result = new List<IBook>();

            foreach (Book book in books)
            {
                if (book.isElectronicVersions())
                {
                    result.Add(book);
                }
            }

            return result;
        }

        public List<IBook> GetBooksByParameters(string author, int year, bool electronicOnly)
        {
            List<IBook> result = new List<IBook>();

            foreach (Book book in books)
            {
                if ((string.IsNullOrEmpty(author) || book.getAuthor().Equals(author))
                    && (year == 0 || book.getYearOfPublication() == year)
                    && (!electronicOnly || book.isElectronicVersions()))
                {
                    result.Add(book);
                }
            }

            return result;
        }

        public List<IBook> GetBooksByAuthorAndTitle(string author, string title)
        {
            List<IBook> result = new List<IBook>();
            foreach (IBook book in books)
            {
                if (book.getAuthor() == author && book.getTitle() == title)
                {
                    result.Add(book);
                }
            }
            return result;
        }

    }
}
