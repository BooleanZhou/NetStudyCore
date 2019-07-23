using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdProject
{
    /* ==============================================================================
    * 类名称(Class Name)：                       TestOpreation
    * 
    * 类描述(Description)：
    * 
    * 创建人(Author)：                           星爵
    *
    * 创建时间（Create Date）：                  2019/7/23 星期二 14:53:21
    * 
    * 修改记录（Revision History）： 
    *       R1:
    *           修改作者：                     
    *           修改日期：              
    *           修改理由：
    *           
    * ==============================================================================*/

    public class TestOpreation : SingletonExample<TestOpreation>
    {
       

        public string GetString(string name)
        {
            return "方法调用结果:" + name;
        }
    }
}
