namespace Mediatar
{
    public abstract class Item
    {
		public static List<Item> Catalouge { get; } = new List<Item>();
        protected static int idGenHelper = 1000;
		public int Id { get; protected init; }
		protected int LateFeePerDay { get; init; }
		public int RentLength { get; protected init; }
		private string _title = "";
		public string Title
		{
			get { return _title; }
			set { if (string.IsNullOrWhiteSpace(value)) { idGenHelper--; throw new ArgumentException(); } _title = value; }
		}
		public string? Author { get; set; }
		private int _relaseYear;
		public int RelaseYear
		{
			get { return _relaseYear; }
			set { if (value < 1450) { idGenHelper--; throw new ArgumentException(); } _relaseYear = value; }
		}
		protected Item()
		{
			idGenHelper++;
			Id = idGenHelper;
		}
        public int CalculateDebt(DateTime expDate, DateTime actualDate, PerSON tag)
        {
            int days = (actualDate - expDate).Days;
			if(days <= 0)
				return 0;
            return days * LateFeePerDay;
        }
    }
}
