namespace BrokrService.Models
{
    public class PolicyModel
    {
        public decimal SumInsured { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PolicyNumber { get; set; } 
       public string InsuredNumber { get; set; }
        public string Branch { get; set; }
    }
}
