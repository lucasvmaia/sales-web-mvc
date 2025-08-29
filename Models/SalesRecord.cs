using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SalesStatus SalesStatus { get; set; }
        public Seller? Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(DateTime date, double amount, SalesStatus salesStatus, Seller seller)
        {
            Date = date;
            Amount = amount;
            SalesStatus = salesStatus;
            Seller = seller;
        }
    }
}
