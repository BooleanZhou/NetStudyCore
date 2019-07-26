using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTest.Controllers
{

    public class IndexController : ApiController
    {

        class UserInfo
        {
            public string usename { get; set; }
            public string age { get; set; }


        }


        [HttpGet]
        public string GetString(JObject obj)
        {

            var names = obj.ToObject<UserInfo>();
            return obj.ToString();
        }
    }
}
