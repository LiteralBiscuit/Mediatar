namespace Mediatar
{
    public abstract class PerSON
    {
        protected static int IdGenHelper = 2000;
        public int Id { get; protected init; }
        public abstract int Debt { get; set; }
        public int MaxInventorySize { get; init; }
        public List<RentingObj> Dues { get; protected init; } = new List<RentingObj>();
        public List<Item> Inventory { get; protected init; } = new List<Item>();
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { if (string.IsNullOrWhiteSpace(value)) { IdGenHelper--; throw new ArgumentException(); } _name = value; }
        }

        public void Pay()
        {
            if (Debt == 0) throw new Exception();
            Debt = 0;
        }
        public void Pay(int amount)
        {
            if (amount > Debt || amount <= 0) throw new ArgumentException();
            Debt -= amount;
        }

        public bool ReturnItem(Item item, DateTime dateOfReturn)
        {
            if (!Inventory.Contains(item)) return false;
            RentingObj currentDue = Dues.First(d => d.Item == item);
            Debt += item.CalculateDebt(currentDue.ExpDate, dateOfReturn, this);
            Dues.Remove(currentDue);
            Inventory.Remove(item);
            Item.Catalouge.Add(item);
            return true;
        }

        public bool RentItem(Item item, DateTime dateOfRent)
        {
            if (this.Debt > 0)
            {
                Console.WriteLine("Can't rent, has debt!");
                return false;
            }
            if (!Item.Catalouge.Contains(item))
            {
                Console.WriteLine("Can't rent, someonw has it");
                return false;
            }
            if(Inventory.Count >= MaxInventorySize)
            {
                Console.WriteLine("Can't rent, too many items");
                return false;
            }
            this.Inventory.Add(item);
            this.Dues.Add(new RentingObj(item, this, dateOfRent));
            Item.Catalouge.Remove(item);
            return true;
        }

        public PerSON()
        {
            IdGenHelper++;
            Id = IdGenHelper;
        }
    }
}
