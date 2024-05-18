using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;

namespace ServerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServerClass server = new ServerClass();
            server.Load();
        }
    }
}
