using BrokrService.Models;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace BrokrService.Service
{
    
    public class PolicyService
    {
        private readonly HttpClient _httpClient;
        public PolicyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
       
       public async Task<string> PolicySetUpAsync(PolicyModel policy)
        {
            var policyUrl = "http://192.168.10.59:8080/insured";
            string policyNumber = null;
            string json = JsonConvert.SerializeObject(policy);
           

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(policyUrl, content);
            try 
            {
                if (response.IsSuccessStatusCode)
                {
                    policyNumber = await response.Content.ReadAsStringAsync();
                   
                }
                else
                {
                     Console.Out.WriteLineAsync("There's an issue getting the policy number");
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("An error occurred: " + ex.Message);
            }
            return policyNumber;

        }
        private string HashPolicyNumber(string policyNumber)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(policyNumber));
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }
            string hashedPolicyNumber = stringBuilder.ToString();
            sha256Hash.Dispose();
            return hashedPolicyNumber;
        }
    }
       
}
