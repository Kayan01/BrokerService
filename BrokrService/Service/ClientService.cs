using BrokrService.Models;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BrokrService.Service
{
    public class ClientService
    {
        private readonly HttpClient _httpClient;
        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> ClientSetUp(ClientModel client)
        {
            var insured = "http://192.168.10.59:8080/insured";
            string clientNo = null;
            var json = JsonConvert.SerializeObject(client);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(insured, content);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    clientNo = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return ("There is an error while creating the profile please trry again.");
                }     
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("An error occured: " + ex.Message);
            }
            return clientNo;
        }
        
    }
}
