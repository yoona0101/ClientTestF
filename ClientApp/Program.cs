using System;
using TcpAppLibrary;
using Client;

class ClientApp
{
    static void Main(string[] args)
    {
        ClientClass client = new ClientClass();
        client.OpenFlags();
    }
}
