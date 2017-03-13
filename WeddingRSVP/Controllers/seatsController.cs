namespace WeddingRSVP.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using WeddingRSVP.Api;
    
    [RoutePrefix("api/seats")]
    public class seatsController : ApiController
    {
        IApi api;

        public seatsController()
        {
            api = new Api();
        }
     
        public object Get(string id)
        {
            var response = api.GetSeat(id);
            return response;
        }
        
        [HttpGet]
        [Route("{id}/confirm/{seats}")]
        public object Confirm(string id, int seats)
        {
            var response = api.ConfirmSeats(id, seats);
            return response;
        }

        [HttpGet]
        [Route("resetall/{pw}")]
        public object resetAll(string pw)
        {
            if(!string.IsNullOrEmpty(pw))
            {
                var response = api.ResetAll(pw);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }

        }
    }
}
