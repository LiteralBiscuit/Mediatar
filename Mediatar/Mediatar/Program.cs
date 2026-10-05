namespace Mediatar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //init data
            try
            {
                new Book("Egri csillagok", "Gárdonyi Géza", 2018, 520);
                new DVD("A Gyűrűk Ura: A Gyűrű Szövetsége", "Peter Jackson", 2001, 178);
                new Magazine("Élet és Tudomány", null, 2026, "2026/3");
                new Book("A Pál utcai fiúk", "Molnár Ferenc", 2015, 240);
                new Book("Abigél", "Szabó Magda", 2012, 360);
                new Book("Az arany ember", "Jókai Mór", 2010, 400);
            }
            catch
            {
                Console.WriteLine("Something was incorrect.");
            }
            foreach (var e in Entity.Catalouge)
                Console.WriteLine($"{e.Id}\t{e.Category}\t{e.Title}\t{e.Author ?? "–"}\t{e.RelaseYear}");
        }
    }
}
