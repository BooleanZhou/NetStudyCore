﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketServerHelper helper = new SocketServerHelper(8888);
            helper.StartListen();
            Console.ReadKey();
        }
    }
}
