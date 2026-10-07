namespace Mediatar
{
    public class Eldar : PerSON
    {
        public override int Debt { get => 0; set { } }   // always 0
        public Eldar(string name) : base() { Name = name; }

        public Eldar()
        {
            MaxInventorySize = 5;
        }
    }
}
