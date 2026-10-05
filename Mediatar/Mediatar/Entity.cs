namespace Mediatar
{
    public abstract class Entity
    {
		public static List<Entity> Catalouge { get; } = new List<Entity>();
        protected static int idGenHelper = 1000;
		public int Id { get; init; }
		private string _title = "";
		public string Title
		{
			get { return _title; }
			set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(); _title = value; }
		}
		public string Category { get; init; } = "";
		public string? Author { get; set; }
		private int _relaseYear;
		public int RelaseYear
		{
			get { return _relaseYear; }
			set { if (value < 1450) throw new ArgumentException(); _relaseYear = value; }
		}
		protected Entity()
		{
			idGenHelper++;
			Id = idGenHelper;
		}
	}

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
			Category = "Book";
			PageNumber = pageNumber;
			Catalouge.Add(this);
		}
	}

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
            Category = "DVD";
            Length = length;
            Catalouge.Add(this);
        }
    }

    public class Magazine : Entity
    {
        private string _issues = "";

		public string Issues
		{
			get { return _issues; }
			set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException();  _issues = value; }
		}

        public Magazine(string title, string? author, int relaseYear, string issues) : base()
        {
            Title = title;
            Author = author;
            RelaseYear = relaseYear;
            Category = "Magazine";
            Issues = issues;
            Catalouge.Add(this);
        }
    }
}
