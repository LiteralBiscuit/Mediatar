namespace Mediatar
{
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
            Issues = issues;
            LateFeePerDay = 50;
            Catalouge.Add(this);
        }

        public override int CalculateDebt(DateTime expDate, DateTime actualDate, Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
