namespace Mediatar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inventory (IDs 1001-1006)
            var items = new Item[]
            {
                new Book("Egri csillagok", "Gárdonyi Géza", 2018, 520),
                new DVD("A Gyűrűk Ura: A Gyűrű Szövetsége", "Peter Jackson", 2001, 178),
                new Magazine("Élet és Tudomány", null, 2026, "2026/3"),
                new Book("A Pál utcai fiúk", "Molnár Ferenc", 2015, 240),
                new Book("Abigél", "Szabó Magda", 2012, 360),
                new Book("Az arany ember", "Jókai Mór", 2010, 400),
            };

            Item I(int id) => items.First(i => i.Id == id);
            DateTime D(int month, int day) => new DateTime(2026, month, day);

            void Try(string label, Action a)
            {
                try { a(); Console.WriteLine($"  {label}: OK"); }
                catch (Exception ex) { Console.WriteLine($"  {label}: Error ({ex.GetType().Name})"); }
            }
            void Rent(PerSON p, int id, DateTime d)
            {
                bool ok = p.RentItem(I(id), d);
                var due = p.Dues.FirstOrDefault(x => x.Item.Id == id);
                Console.WriteLine($"  {p.Name} rents {id}: {(ok ? $"success, due {due!.ExpDate:MMMM d}" : "rejected")}");
            }
            void Return(PerSON p, int id, DateTime d)
            {
                var due = p.Dues.First(x => x.Item.Id == id);
                int late = Math.Max(0, (d - due.ExpDate).Days);
                int before = p.Debt;
                p.ReturnItem(I(id), d);
                Console.WriteLine($"  {p.Name} returns {id}: {late} days late, {p.Debt - before} Ft fee");
            }

            // 1. Members
            Console.WriteLine("1.");
            var anna = new Student("Anna");
            var bela = new Adult("Béla");
            var cecilia = new Eldar("Cecília");
            Console.WriteLine($"  IDs: {anna.Id}, {bela.Id}, {cecilia.Id}");      // 2001, 2002, 2003

            // 2. March 2
            Console.WriteLine("2.");
            Rent(anna, 1001, D(3, 2));      // due March 30
            Rent(bela, 1002, D(3, 2));      // due March 9
            Rent(cecilia, 1003, D(3, 2));   // due March 9

            // 3. Béla returns 1002
            Console.WriteLine("3.");
            Return(bela, 1002, D(3, 14));   // 5 days, 500 Ft

            // 4. Béla tries 1004 -> rejected (debt)
            Console.WriteLine("4.");
            Rent(bela, 1004, D(3, 14));

            // 5. Payments
            Console.WriteLine("5.");
            Try("Pay(200)", () => bela.Pay(200));
            Console.WriteLine($"  Debt: {bela.Debt} Ft");                        // 300
            Try("Pay(0)", () => bela.Pay(0));                                    // error
            Try("Pay(1000)", () => bela.Pay(1000));                              // error
            Try("Pay()", () => bela.Pay());
            Console.WriteLine($"  Debt: {bela.Debt} Ft");                        // 0
            Try("Pay()", () => bela.Pay());                                      // error (no debt)

            // 6. Béla rents 1004
            Console.WriteLine("6.");
            Rent(bela, 1004, D(3, 14));     // due April 11

            // 7. Cecília returns 1003
            Console.WriteLine("7.");
            Return(cecilia, 1003, D(3, 20)); // 11 days, 0 Ft

            // 8. Anna returns 1001
            Console.WriteLine("8.");
            Return(anna, 1001, D(4, 9));    // 10 days, 100 Ft

            // 9. Anna tries to rent, then pays everything
            Console.WriteLine("9.");
            Rent(anna, 1002, D(4, 9));      // rejected (debt)
            anna.Pay();
            Console.WriteLine($"  Anna's debt: {anna.Debt} Ft");                 // 0

            // 10. April 10
            Console.WriteLine("10.");
            Rent(anna, 1001, D(4, 10));
            Rent(anna, 1005, D(4, 10));
            Rent(anna, 1006, D(4, 10));     // all due May 8

            // 11. Anna's rejected attempts
            Console.WriteLine("11.");
            Rent(anna, 1004, D(4, 10));     // Béla has it
            Rent(anna, 1002, D(4, 10));     // limit of 3

            // 12. Béla returns 1004
            Console.WriteLine("12.");
            Return(bela, 1004, D(4, 11));   // 0 days, 0 Ft

            // 13. Anna's items
            Console.WriteLine("13.");
            foreach (var d in anna.Dues)
            Console.WriteLine($"  {d.Item.Id} {d.Item.Title}, due {d.ExpDate:MMMM d}");
        }
    }
}
