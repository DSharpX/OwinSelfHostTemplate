using OwinSelfHostTemplate.Config;
using System;

namespace OwinSelfHostTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server();
            server.Start();
        }
    }
}
