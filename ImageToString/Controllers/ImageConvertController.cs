using Emgu.CV.OCR;
using ImageToString.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ImageToString.Controllers
{

    public class ImageConvertController : Controller
    {
        class UserInfo
        {
            public string usename { get; set; }
            public string age { get; set; }
        }
        // GET: ImageConvert
        public async Task<ActionResult> Index()
        {
            UserInfo userinfo = new UserInfo();
            userinfo.usename = "dddd";
            userinfo.age = "12";
            string json = JsonConvert.SerializeObject(userinfo);
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(json);
            try
            {
               
              
                new HttpClient().DefaultRequestHeaders.Accept.Clear();
                new HttpClient().DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync("http://localhost:8035/api/Index/GetPost", content);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {

                client.Dispose();
                content.Dispose();
            }
            client.Dispose();
            content.Dispose();
            return View();
        }
        class Test
        {
            public int total { get; set; }
            public List<rows> rows { get; set; }
            public string searchString { get; set; }
            public string meeting { get; set; }
        }
        class rows
        {
            public string id { get; set; }
            public string link { get; set; }
            public string zwmc { get; set; }
            public string gsmc { get; set; }
            public string zwyx { get; set; }
            public string gzdd { get; set; }
            public string gxsj { get; set; }
        }
        private delegate string GreetingDelegate(string name);

        public string EnglishGreeting(string name)
        {
            return $"Good Morning" + name;
        }
        public string ChineseGreeting(string name)
        {
            return $"早上好" + name;
        }


        private string GetGreeting(string name, GreetingDelegate greetingDelegate)
        {
            return greetingDelegate(name);
        }
        class GreetingManager
        {
            public string GetGreeting(string name, GreetingDelegate greetingDelegate)
            {
                return greetingDelegate(name);
            }

        }
        class GreetingEventManager
        {
            private event GreetingDelegate greetingEvent;
            public string GetGreeting(string name, GreetingDelegate greetingDelegate)
            {
                return greetingEvent(name);
            }
        }
        [HttpGet]
        public JsonResult GetTest(int pageSize, int pageNumber, string searchString)
        {
            string resultMeeting = string.Empty;
            //string resultMeeting = GetGreeting("小强", ChineseGreeting);
            //GreetingManager greetingManager = new GreetingManager();
            //resultMeeting = greetingManager.GetGreeting("John", EnglishGreeting);
            //resultMeeting += greetingManager.GetGreeting("强", ChineseGreeting);
            GreetingDelegate greetingDelegate;
            greetingDelegate = EnglishGreeting;
            greetingDelegate += ChineseGreeting;
            resultMeeting = greetingDelegate("Jon");
            resultMeeting = greetingDelegate("强");

            //resultMeeting += greetingManager.GetGreeting("John", EnglishGreeting);
            List<rows> list = new List<rows>();
            for (int i = 0 + (pageSize - 10); i < pageSize * pageNumber; i++)
            {
                rows r = new rows();
                r.id = "TEST" + i.ToString();
                r.link = "www.baidu.com";
                r.zwmc = "ZWMC" + i.ToString();
                r.gsmc = "GSMC" + i.ToString();
                r.zwyx = "ZWYX" + i.ToString();
                r.gzdd = "GZDD" + i.ToString();
                r.gxsj = "GXSJ" + i.ToString();
                list.Add(r);

            }

            Test t = new Test();
            t.total = pageSize * 2;
            t.rows = list;
            t.searchString = searchString;
            t.meeting = resultMeeting;


            return Json(t, JsonRequestBehavior.AllowGet);
        }
    }
}