using BrokrService.Models;
using BrokrService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrokrService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicySetUpController : ControllerBase
    {
        private readonly ClientService _policyService;
        public PolicySetUpController(ClientService policyService)
        {
            _policyService = policyService;
        }
        [HttpPost("{clientNo}")]
        public async Task<ActionResult<PolicyModel>> PolicySetUpAsync ([FromBody]string clientNo, PolicySetupDto policy)
        {
            PolicyModel newPolicy = await _policyService.PolicySetUpAsync(clientNo, policy);
            return Ok(newPolicy);
        }
        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseModel>> CoinsurePolicy([FromBody] PolicyDto policyDto)
        {
            try
            {
                // Hash policy data
                var hashedPolicyData = HashPolicyData(policyDto);

                // Call endpoint in existing application to set up client
                // Return client ID
                var clientId = await SetupClientAsync(policyDto.ClientDto, hashedPolicyData);

                // Use client ID to set up policy
                // Return policy number
                var policyNumber = await SetupPolicyAsync(clientId, policyDto);

                // Hash policy number
                var hashedPolicyNumber = HashPolicyNumber(policyNumber);

                // Return response object
                var response = new ResponseCoinsurePolicy
                {
                    IsSucceed = true,
                    PolicyID = policyNumber,
                    PolicyUniqueID = hashedPolicyNumber,
                    DataGroup = new List<DataGroup>
            {
                new DataGroup
                {
                    GroupName = "PolicyData",
                    GroupTag = 1,
                    GroupCount = 1,
                    AttArray = new List<Attribute>
                    {
                        new Attribute
                        {
                            Name = "HashedPolicyData",
                            Value = hashedPolicyData
                        },
                        new Attribute
                        {
                            Name = "HashedPolicyNumber",
                            Value = hashedPolicyNumber
                        }
                    }
                }
            },
                    ErrCodes = new List<string>(),
                    ErrMsgs = new List<string>(),
                    WarnCodes = new List<string>(),
                    WarnMsgs = new List<string>()
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exception and return appropriate HTTP status code
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

}
