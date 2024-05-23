namespace ApiLibrary.Models
{
    public class Merchant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int BenefitId { get; set; }
        public Benefit? Benefit { get; set; }
    }
}
