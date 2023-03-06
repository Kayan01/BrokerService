using BrokrService.Models;
using BrokrService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrokrService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSetUpController : ControllerBase
    {
        private readonly ClientService _policyService;
        public ClientSetUpController(ClientService policyService)
        {
            _policyService = policyService;
        }
        [HttpPost]
        public async Task<ActionResult<string>> ClientSetUpAsync(ClientModel client)
        {
            string clientNo =  await _policyService.ClientSetUp(client);
            return Ok(clientNo);
        }
    }
}
