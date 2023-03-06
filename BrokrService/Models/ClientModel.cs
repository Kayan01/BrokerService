namespace BrokrService.Models
{
    public class StandardResponse <T> where T : class
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
    public class CreateClientModelResponse
    {
        public string ClientNo { get; set; }
    }
    public class ClientModel
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }    
        public string InsuredName { get; set; }   
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set;}
        public string TypeOfInsured { get; set; }
        public string BVN { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string StateOfBusisness { get; set; }
        public string LgaBusinessLocation { get; set; }
        public string CountryBusinessLocation { get; set;}
        public string IsCustomerPEP { get; set; }
        public string Justification { get; set; }
        public double RiskScale { get; set; }
    }
}
