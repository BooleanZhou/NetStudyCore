using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdProject
{
    /* ==============================================================================
    * 类名称(Class Name)：                       President
    * 
    * 类描述(Description)：
    * 
    * 创建人(Author)：                           星爵
    *
    * 创建时间（Create Date）：                  2019/7/23 星期二 10:38:25
    * 
    * 修改记录（Revision History）： 
    *       R1:
    *           修改作者：                     
    *           修改日期：              
    *           修改理由：
    *           
    * ==============================================================================*/

    public class President : SingletonExample<President>
    {
        private string name;
        private string country;
        public President()
        {
            Console.WriteLine("类中的构造函数");
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
    }
}
