namespace Mediatar
{
    public abstract class Tag
    {
        private static int IdGenHelper = 2000;
        public int Id { get; private init; }
        public int Debt {  get; protected set; }
        public List<RentingObj> Dues { get; protected init; } = new List<RentingObj>();
        public List<Entity> Inventory { get; protected init; } = new List<Entity>();
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(); _name = value; }
        }

        public void Pay()
        {
            Debt = 0;
        }
        public void Pay(int amount)
        {
            if (amount > Debt || amount <= 0) throw new ArgumentException();
            Debt -= amount;
        }

        public bool ReturnItem(Entity item, DateTime dateOfReturn)
        {
            if (!Inventory.Contains(item)) return false;
            RentingObj currentDue = Dues.First(d => d.Item == item);
            Debt += item.CalculateDebt(currentDue.ExpDate, dateOfReturn, this);
            Dues.Remove(currentDue);
            return true;
        }

        public Tag()
        {
            IdGenHelper++;
            Id = IdGenHelper;
        }
    }
}
