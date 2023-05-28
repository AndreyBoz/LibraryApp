using Library.Interfaces;

namespace Library.Classes
{
    abstract class Book : IBook
    {
        private string author;
        private string title;
        private string[] keywords;
        private int yearOfPublication;
        private bool electronicVersions;

        public Book(string author, string title, string[] keywords, int yearOfPublication, bool electronicVersions)
        {
            this.author = author;
            this.title = title;
            this.keywords = keywords;
            this.yearOfPublication = yearOfPublication;
            this.electronicVersions = electronicVersions;
        }
        public string getAuthor() { return author; }
        public string getTitle() { return title; }
        public string[] getKeywords() { return keywords; }
        public int getYearOfPublication() { return yearOfPublication; }
        public bool isElectronicVersions() { return electronicVersions; }
    }
}
