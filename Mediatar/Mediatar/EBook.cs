namespace Mediatar
{
    public class EBook : Item
    {
        public static int Downloads { get; private set; }
        public static int LifeTime { get; private set; } = 14;
        public int FileSize { get; init; }
        EBook(string title, string? author, int relaseYear, int fileSize) : base()
        {
            Title = title;
            Author = author;
            RelaseYear = relaseYear;
            FileSize = fileSize;
            Downloads++;
        }
    }
}
