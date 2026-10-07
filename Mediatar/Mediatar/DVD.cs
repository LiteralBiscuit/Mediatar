namespace Mediatar
{
    public class DVD : Item
    {
        private int _length;

        public int Length
        {
            get { return _length; }
            set { if (value <= 0) { idGenHelper--; throw new ArgumentException(); } _length = value; }
        }

        public DVD(string title, string? author, int relaseYear, int length) : base()
        {
            Title = title;
            Author = author;
            RelaseYear = relaseYear;
            Length = length;
            LateFeePerDay = 100;
            RentLength = 7;
            Catalouge.Add(this);
        }
    }
}
