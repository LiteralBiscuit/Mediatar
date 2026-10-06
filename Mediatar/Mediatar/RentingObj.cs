namespace Mediatar
{
    public class RentingObj
    {
        public Entity Item { get; init; }
        public Tag Tag { get; init; }
        public DateTime DateOfRent {  get; init; }
        public DateTime ExpDate {  get; init; }

        public RentingObj(Entity item, Tag tag, DateTime dateOfRent)
        {
            Item = item;
            Tag = tag;
            DateOfRent = dateOfRent;
            switch (item)
            {
                case Book:
                    ExpDate = DateOfRent.AddDays(28);
                    break;

                case DVD:
                    ExpDate = DateOfRent.AddDays(7);
                    break;
                case Magazine:
                    ExpDate = DateOfRent.AddDays(7);
                    break;
            }
        }
    }
}
