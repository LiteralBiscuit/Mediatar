namespace Mediatar
{
    public class DVD : Entity
    {
        private int _length;

        public int Length
        {
            get { return _length; }
            set { if (value <= 0) throw new ArgumentException(); _length = value; }
        }

        public DVD(string title, string? author, int relaseYear, int length) : base()
        {
            Title = title;
            Author = author;
            RelaseYear = relaseYear;
            Length = length;
            LateFeePerDay = 100;
            Catalouge.Add(this);
        }

        public override int CalculateDebt(DateTime expDate, DateTime actualDate, Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
