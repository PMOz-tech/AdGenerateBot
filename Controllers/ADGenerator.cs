using AdGenerateBot.ApplicationService.ADProduct;
using AdGenerateBot.ApplicationService.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdGenerateBot.API.Controllers
{
    [Route("api/adgenerator/[action]")]
    [ApiController]
    public class ADGeneratorController : ControllerBase
    {

        private readonly IADProductService _adProduct;
        public ADGeneratorController(IADProductService adProduct)
        {
            _adProduct = adProduct;
        }

        [HttpPost]
        public async Task<ActionResult<ADProductResponseModel>> GenerateAD(CustomerRequestModel aDGenerateRequestModel)
        {
            try
            {
               
                var response = await _adProduct.GenerateAdContent(aDGenerateRequestModel);

                return response;
            }
            catch (System.Exception ex)
            {

                return null;
            }

        }
    }
}
