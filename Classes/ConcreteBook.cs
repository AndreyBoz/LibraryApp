namespace Library.Classes
{
    internal class ConcreteBook : Book
    {
        public ConcreteBook(string author, string title, string[] keywords, int yearOfPublication, bool electronicVersions) : base(author, title, keywords, yearOfPublication, electronicVersions)
        {
        }
    }
}
