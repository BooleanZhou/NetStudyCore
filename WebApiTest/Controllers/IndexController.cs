using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace WebApiTest.Controllers
{

    public class IndexController : ApiController
    {

        public class UserInfo
        {
            public string usename { get; set; }
            public string age { get; set; }


        }

        private delegate void SetString(UserInfo userinfo);

        public void SetMain(UserInfo userinfo)
        {
            Thread.Sleep(5000);
            Console.WriteLine(userinfo.usename);

            Console.ReadKey();
        }

        public HttpResponseMessage GetString(UserInfo obj)
        {

            HttpResponseMessage message = new HttpResponseMessage();
            message.Content = new StringContent("123");
            // var names = obj.ToObject<UserInfo>();
            //SetString main = new SetString(SetMain);
            //main.BeginInvoke(names, null, null);
            return message;
        }

        [HttpPost]
        public HttpResponseMessage GetPost([FromBody]JObject obj)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            message.Content = new StringContent("123");
            // var names = obj.ToObject<UserInfo>();
            //SetString main = new SetString(SetMain);
            //main.BeginInvoke(names, null, null);
            return message;
        }

        [HttpPost]
        public HttpResponseMessage GetPostA(string obj)
        {

            // var names = obj.ToObject<UserInfo>();
            //SetString main = new SetString(SetMain);
            //main.BeginInvoke(names, null, null);
            HttpResponseMessage message = new HttpResponseMessage();
            message.Content = new StringContent("123");
            // var names = obj.ToObject<UserInfo>();
            //SetString main = new SetString(SetMain);
            //main.BeginInvoke(names, null, null);
            return message;
        }

        [HttpPost]
        public HttpResponseMessage GetPostB(UserInfo obj)
        {

            // var names = obj.ToObject<UserInfo>();
            //SetString main = new SetString(SetMain);
            //main.BeginInvoke(names, null, null);
            HttpResponseMessage message = new HttpResponseMessage();
            message.Content = new StringContent("123");
            // var names = obj.ToObject<UserInfo>();
            //SetString main = new SetString(SetMain);
            //main.BeginInvoke(names, null, null);
            return message;
        }
    }
}
