using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServer
{
    /* ==============================================================================
    * 类名称(Class Name)：                       SocketServerHelper
    * 
    * 类描述(Description)：
    * 
    * 创建人(Author)：                           星爵
    *
    * 创建时间（Create Date）：                  2019/7/24 星期三 10:02:28
    * 
    * 修改记录（Revision History）： 
    *       R1:
    *           修改作者：                     
    *           修改日期：              
    *           修改理由：
    *           
    * ==============================================================================*/

    public class SocketServerHelper
    {
        private string ip; //绑定的IP地址
        private int port = 0; //端口 
        private Socket _socket = null; //通信实例
        private byte[] buffer = new byte[1024 * 1024 * 2];

        public SocketServerHelper(string ip, int port)
        {
            this.ip = ip;
            this.port = port;

        }
        public SocketServerHelper(int port)
        {
            this.ip = "0.0.0.0";
            this.port = port;
        }
        public void StartListen()
        {
            
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse(ip);
            IPEndPoint point = new IPEndPoint(address, port);
            _socket.Bind(point);
            _socket.Listen(int.MaxValue);
            Console.WriteLine("监听{0}消息成功", _socket.LocalEndPoint.ToString());
            Thread thread = new Thread(ListenClientConnect);

            thread.Start();
        }
        /// <summary>
        /// 监听客户端连接
        /// </summary>
        private void ListenClientConnect()
        {
            Socket clientSocket = null;
            try
            {
                while (true)
                {
                    //Socket创建的新连接
                    clientSocket = _socket.Accept();

                    clientSocket.Send(Encoding.UTF8.GetBytes("服务端发送消息:"));
                    var d = clientSocket.RemoteEndPoint;
                    Thread thread = new Thread(ReceiveMessage);
                    thread.Start(clientSocket);
                }
            }
            catch (Exception)
            {
            }
           
        }
        /// <summary>
        /// 接收客户端消息
        /// </summary>
        /// <param name="socket">来自客户端的socket</param>
        private void ReceiveMessage(object socket)
        {

            Socket clientSocket = (Socket)socket;
            
            //lock (clientSocket)
            //{
            while (true)
            {
                try
                {
                    //获取从客户端发来的数据
                    int length = clientSocket.Receive(buffer);
                    Console.WriteLine("接收客户端{0},消息{1}", clientSocket.RemoteEndPoint.ToString(), Encoding.UTF8.GetString(buffer, 0, length));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    break;
                }
            }
            // }
        }
    }
}
