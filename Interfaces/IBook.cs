namespace Library.Interfaces
{
    public interface IBook
    {
        string getAuthor();
        string getTitle();
        string[] getKeywords();
        int getYearOfPublication();
        bool isElectronicVersions();
    }
}
