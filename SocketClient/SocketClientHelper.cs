using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketClient
{
    /* ==============================================================================
    * 类名称(Class Name)：                       SocketClientHelper
    * 
    * 类描述(Description)：
    * 
    * 创建人(Author)：                           星爵
    *
    * 创建时间（Create Date）：                  2019/7/24 星期三 10:31:36
    * 
    * 修改记录（Revision History）： 
    *       R1:
    *           修改作者：                     
    *           修改日期：              
    *           修改理由：
    *           
    * ==============================================================================*/

    public class SocketClientHelper
    {
        private string ip; //绑定的IP地址
        private int port = 0; //端口 
        private Socket _socket = null; //通信实例
        private byte[] buffer = new byte[1024 * 1024 * 2];
        public SocketClientHelper(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }
        public SocketClientHelper(int port)
        {
            this.ip = "127.0.0.1";
            this.port = port;
        }
        class UserInfo
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Descrption { get; set; }
        }
        public void StartClient()
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress iPAddress = IPAddress.Parse(ip);
                IPEndPoint point = new IPEndPoint(iPAddress, port);
                _socket.Connect(point);

                Console.WriteLine("连接成功...");
                int length = _socket.Receive(buffer);
                
                Console.WriteLine("接收服务器{0},消息:{1}", _socket.RemoteEndPoint.ToString(), Encoding.UTF8.GetString(buffer, 0, length));
                //6.0 像服务器发送消息
                List<UserInfo> list = new List<UserInfo>();

                for (int i = 0; i < 3; i++)
                {
                    list.Add(new UserInfo() { Name = "姓名" + i.ToString(), Age = i, Descrption = "介绍" + i.ToString() });
                }

                string sendMessage = JsonConvert.SerializeObject(list); ;
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);

                    //string.Format("客户端发送的消息{1},当前时间{0}", DateTime.Now.ToString(), i.ToString());
                    _socket.Send(Encoding.UTF8.GetBytes(sendMessage));

                    Console.WriteLine("向服务发送的消息:{0}", sendMessage);
                }
            }
            catch (Exception)
            {

                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();

            }
            Console.WriteLine("消息发送完毕");
            Console.ReadKey();

        }
    }
}
