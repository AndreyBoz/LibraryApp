using System.Collections.Generic;

namespace Library.Interfaces
{
    public interface ILibrary
    {
        void AddBook(IBook book);
        void RemoveBook(IBook book);
        List<IBook> GetBooksByAuthor(string author);
        List<IBook> GetBooksByYear(int year);
        List<IBook> GetElectronicBooks();
        List<IBook> GetBooksByParameters(string author, int year, bool electronicOnly);
    }
}
