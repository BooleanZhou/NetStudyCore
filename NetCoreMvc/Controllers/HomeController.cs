using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreMvc.Models;

namespace NetCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        static ref int GetByIndex(int[] arr, int ix) => ref arr[ix];
        public IActionResult Main()
        {
            (string a, string b, string c) = GetFullName();
            object d = 1;
            int f = 0;
            if (d is int e)
            {
                f = e + 10;
            }
            int[] arr = { 1, 2, 3, 4, 5 };
            ref int x = ref GetByIndex(arr, 2); //调用刚才的方法
            x = 99;

            ViewBag.A = a;
            ViewBag.F = f;
            ViewBag.T = x;
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }
        private static (string a, string b, string c) GetFullName()
        {
            return ("a", "b", "c");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
