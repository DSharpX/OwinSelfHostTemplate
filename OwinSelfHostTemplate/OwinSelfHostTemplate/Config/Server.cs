using Microsoft.Owin.Hosting;
using System;

namespace OwinSelfHostTemplate.Config
{
    public class Server
    {
        public void Start()
        {
            WebApp.Start<StartUp>(url: $"http://{GetLocalIP.GetIP()}:{90}/");
            Console.WriteLine("Server started...");
            Console.WriteLine($"Connected: http://{GetLocalIP.GetIP()}:{90}/");
        }
    }
}
