using Emgu.CV.OCR;
using ImageToString.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageToString.Controllers
{

    public class ImageConvertController : Controller
    {
        // GET: ImageConvert
        public ActionResult Index()
        {

            //Tesseract _ocr = new Tesseract();
            //_ocr = new Tesseract(@"D:\Emgu\emgucv-windesktop 4.1.0.3420\bin\tessdata", "eng", OcrEngineMode.LstmOnly);//方法第一个参数可为""表示通过环境变量调用字库，第二个参数表示字库的文件，第三个表示识别方式，可看文档与资料查找。
            //_ocr.SetVariable("tessedit_char_whitelist", "0123456789X");//此方法表示只识别1234567890与x字母
            //string result = "";
            //Bitmap bitmap = new Bitmap(Bitmap.FromFile(@"D:\test.bmp"));
            //bitmap = ImageOpreation.BrightnessP(bitmap, 1);//图片加亮处理
            //bitmap = ImageOpreation.KiContrast(bitmap, 1);//调整对比对

            //result = ImageOpreation.ORC_(bitmap);
            //ViewBag.Result = result;
            //_ocr.Dispose();
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