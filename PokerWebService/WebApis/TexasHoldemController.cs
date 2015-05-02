using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PokerWebService.WebApis
{
    public class TexasHoldemController : ApiController
    {
        public HttpResponseMessage GetTable()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            response.Content = new StringContent("Hello world!");            

            return response;
        }
    }
}
