using CreditCardValidator.Common.Interfaces;
using CreditCardValidator.API.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CreditCardValidator.API.Controllers
{
    [EnableCors(origins: "https://localhost:44335", headers: "*", methods: "*")]
    public class CardValidatorController : ApiController
    {
        private readonly ICardValidationService _cardValidationService;
        private readonly IValidationLogRepository validationLogRepository;

        public CardValidatorController(ICardValidationService cardValidationService,IValidationLogRepository validationLogRepository)
        {
            _cardValidationService = cardValidationService;
            this.validationLogRepository = validationLogRepository;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public ICardValidationResponse Get(string cardNumber)
        {
            var res = _cardValidationService.ValidateCard(cardNumber);
            return res;
        }


        // POST api/<controller>
        [HttpPost]
        [Route("api/validateCard")]
        public ICardValidationResponse Post(CardValidationRequest request)
        {
            //HttpContext.Current.Request.Form.GetValues("key");
            //dynamic obj = await Request.Content.ReadAsAsync<JObject>();
            var res =  _cardValidationService.ValidateCard(request.CardNumber);
            return res;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}