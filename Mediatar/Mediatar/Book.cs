namespace Mediatar
{
    public class Book: Item
	{
		private int _pageNumber;
		public int PageNumber
		{
			get { return _pageNumber; }
			set { if (value <= 0) { idGenHelper--; throw new ArgumentException(); } _pageNumber = value; }
		}

		public Book(string title, string? author, int relaseYear, int pageNumber): base()
		{
			Title = title;
			Author = author;
			RelaseYear = relaseYear;
			PageNumber = pageNumber;
			LateFeePerDay = 20;
			RentLength = 28;
			Catalouge.Add(this);
		}
    }
}
