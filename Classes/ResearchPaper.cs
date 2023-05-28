namespace Library.Classes
{
    class ResearchPaper : Book
    {
        private string journal;
        private int journalQuartile;

        public ResearchPaper(string author, string title, string[] keywords, int yearOfPublication, bool electronicVersions, string journal, int journalQuartile)
            : base(author, title, keywords, yearOfPublication, electronicVersions)
        {
            this.journal = journal;
            this.journalQuartile = journalQuartile;
        }

        public string getJournal() { return journal; }
        public int getJournalQuartile() { return journalQuartile; }
    }
}
