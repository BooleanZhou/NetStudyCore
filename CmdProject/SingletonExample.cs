using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdProject
{
    /* ==============================================================================
    * 类名称(Class Name)：                       SingletonExample
    * 
    * 类描述(Description)：泛型单例模式
    * 
    * 创建人(Author)：                           星爵
    *
    * 创建时间（Create Date）：                  2019/7/23 星期二 10:45:40
    * 
    * 修改记录（Revision History）： 
    *       R1:
    *           修改作者：                     
    *           修改日期：              
    *           修改理由：
    *           
    * ==============================================================================*/

    public class SingletonExample<T> where T : class, new()
    {
        //public static T Instance { get { return Nested.instance; } }

        //private class Nested
        //{
        //    static Nested() { }
        //    internal static readonly T instance = new T();

        //}
        public static T instance { get; set; }
        private static readonly object locker = new object();
        public SingletonExample()
        {
            Console.WriteLine("进入构造函数");
        }
        public static T GetSingleton()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                }

            }
            return instance;
        }
    }
}
