﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdProject
{
    /* ==============================================================================
    * 类名称(Class Name)：                       CommonModel
    * 
    * 类描述(Description)：
    * 
    * 创建人(Author)：                           星爵
    *
    * 创建时间（Create Date）：                  2019/7/23 星期二 11:21:20
    * 
    * 修改记录（Revision History）： 
    *       R1:
    *           修改作者：                     
    *           修改日期：              
    *           修改理由：
    *           
    * ==============================================================================*/

    public class CommonModel
    {
        private CommonModel()
        {
            Console.WriteLine("进入通用构造函数CommonModel");
        }
        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns></returns>
        public static TestOpreation GetModel()
        {
            return SingletonExample<TestOpreation>.GetSingleton();
        }
    }
}
