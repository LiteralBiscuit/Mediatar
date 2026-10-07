namespace Mediatar
{
    public class Student : PerSON
    {
        private int _debt;
        public override int Debt { get => _debt; set => _debt = value / 2; }
        public Student()
        {
            MaxInventorySize = 3;
        }
    }
}
