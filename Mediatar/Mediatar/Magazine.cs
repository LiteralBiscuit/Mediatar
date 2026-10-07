namespace Mediatar
{
    public class Magazine : Item
    {
        private string _issues = "";

		public string Issues
		{
			get { return _issues; }
			set { if (string.IsNullOrWhiteSpace(value)) { idGenHelper--; throw new ArgumentException(); } _issues = value; }
		}

        public Magazine(string title, string? author, int relaseYear, string issues) : base()
        {
            Title = title;
            Author = author;
            RelaseYear = relaseYear;
            Issues = issues;
            LateFeePerDay = 50;
            RentLength = 7;
            Catalouge.Add(this);
        }
    }
}
