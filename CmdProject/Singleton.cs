using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdProject
{
    /* ==============================================================================
    * 类名称(Class Name)：                       Singleton
    * 
    * 类描述(Description)：单例模式
    * 
    * 创建人(Author)：                           星爵
    *
    * 创建时间（Create Date）：                  2019/7/23 星期二 10:10:29
    * 
    * 修改记录（Revision History）： 
    *       R1:
    *           修改作者：                     
    *           修改日期：              
    *           修改理由：
    *           
    * ==============================================================================*/

    public class Singleton
    {
        private static Singleton instance { get; set; }
        private static readonly object locker = new object();


        public string Name { get; set; }
        private Singleton()
        {
            
            Console.WriteLine("进入构造函数");
        }
        public static Singleton GetSingleton()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }

            }
            return instance;
        }
    }
}
