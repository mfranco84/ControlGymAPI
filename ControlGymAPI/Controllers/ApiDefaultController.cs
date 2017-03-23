using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlGymAPI.Controllers
{
    public class ApiDefaultController : ApiController
    {

        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            // return null; // HTTP 200 response with empty body
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
