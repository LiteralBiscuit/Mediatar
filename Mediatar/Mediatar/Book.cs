namespace Mediatar
{
    public class Book: Entity
	{
		private int _pageNumber;
		public int PageNumber
		{
			get { return _pageNumber; }
			set { if (value <= 0) throw new ArgumentException();  _pageNumber = value; }
		}

		public Book(string title, string? author, int relaseYear, int pageNumber): base()
		{
			Title = title;
			Author = author;
			RelaseYear = relaseYear;
			PageNumber = pageNumber;
			LateFeePerDay = 20;
			Catalouge.Add(this);
		}

        public override int CalculateDebt(DateTime expDate, DateTime actualDate, Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
