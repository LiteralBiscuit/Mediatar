namespace Mediatar
{
    public class Adult : PerSON
    {
        private int _debt;
        public override int Debt { get => _debt; set => _debt = value; }
        public Adult(string name) : base() { Name = name; }

        public Adult()
        {
            MaxInventorySize = 5;
        }
    }
}
