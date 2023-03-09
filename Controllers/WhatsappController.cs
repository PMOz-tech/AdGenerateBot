using AdGenerateBot.ApplicationService.ADProduct;
using AdGenerateBot.ApplicationService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Core;
using Twilio.TwiML;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdGenerateBot.API.Controllers
{
    [Route("api/whatsapp/[action]")]
    [ApiController]
    public class WhatsappController : TwilioController
    {
        private readonly IWhatsappIncomingMessageService _whatsappIncomingMessageService;
        public WhatsappController(IWhatsappIncomingMessageService whatsappIncomingMessageService)
        {
            _whatsappIncomingMessageService = whatsappIncomingMessageService;
        }



        [HttpPost]
        public async Task<IActionResult> IncomingMessages()
        {
            try
            {
                var message = new MessagingResponse();
                string messages = Request.Form["Body"];
                var customerResponse = new CustomerRequestModel
                {
                    Message = messages
                };
                var response = await _whatsappIncomingMessageService.IncomingMessage(customerResponse);
                return new MessagingResponse()
                  .Message($"{response}")
                  .ToTwiMLResult();

               
            }

            catch (System.Exception ex)
            {
              
                return BadRequest(ex.Message);
            }

        }
    }
}
