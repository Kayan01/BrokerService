namespace BrokrService.Models
{
    public class PolicySetupDto
    {
        public string ClientId { get; set; }
        public decimal SumInsured { get; set; }
        public decimal Amount { get; set; } 
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.UtcNow;
    }
}
