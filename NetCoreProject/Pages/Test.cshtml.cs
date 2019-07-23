using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetCoreProject.Pages
{
    public class TestModel : PageModel
    {
        public List<string> ListResult { get; set; }
        public void OnGet()
        {
            List<string> Lists = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                Lists.Add("测试数据" + i.ToString());
            }
            ListResult = Lists;
        }
        public void OnPost()
        {

        }
    }
}