namespace Library.Classes
{
    class Textbook : Book
    {
        private string subject;
        private int course;
        public Textbook(string author, string title, string[] keywords, int yearOfPublication, bool electronicVersions, string subject, int course)
            : base(author, title, keywords, yearOfPublication, electronicVersions)
        {
            this.course = course;
            this.subject = subject;
        }

        public string getSubject() { return subject; }
        public int getCourse() { return course; }
    }
}
