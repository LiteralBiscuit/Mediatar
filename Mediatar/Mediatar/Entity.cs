namespace Mediatar
{
    public abstract class Entity
    {
		public static List<Entity> Catalouge { get; } = new List<Entity>();
        protected static int idGenHelper = 1000;
		public int Id { get; private init; }
		protected int LateFeePerDay { get; init; }
		private string _title = "";
		public string Title
		{
			get { return _title; }
			set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(); _title = value; }
		}
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

        public bool RentItem(Tag tag, DateTime dateOfRent)
		{
			if (tag.Debt > 0)
            {
				Console.WriteLine("Can't rent, has debt!");
				return false;
			}
			tag.Inventory.Add(this);
			tag.Dues.Add(new RentingObj(this, tag, dateOfRent));
			Catalouge.Remove(this);
			return true;
		}
		public abstract int CalculateDebt(DateTime expDate, DateTime actualDate, Tag tag);
	}
}
