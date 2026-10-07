namespace Mediatar
{
    public class RentingObj
    {
        public Item Item { get; init; }
        public PerSON Tag { get; init; }
        public DateTime DateOfRent {  get; init; }
        public DateTime ExpDate {  get; init; }

        public RentingObj(Item item, PerSON tag, DateTime dateOfRent)
        {
            Item = item;
            Tag = tag;
            DateOfRent = dateOfRent;
            ExpDate = dateOfRent.AddDays(item.RentLength);
        }
    }
}
