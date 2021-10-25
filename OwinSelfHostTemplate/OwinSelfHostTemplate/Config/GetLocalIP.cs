using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace OwinSelfHostTemplate.Config
{
    public class GetLocalIP
    {
        public static string GetIP()
        {
            LocalNetworkProperties(out var localIP);
            if (string.IsNullOrWhiteSpace(localIP))
            {
                throw new Exception("No network adapters with an IPv4 address in the system!");
            }
            else
            {
                return localIP;
            }
        }

        private static void LocalNetworkProperties(out string localIP)
        {
            localIP = string.Empty;

            foreach (NetworkInterface network in NetworkInterface.GetAllNetworkInterfaces().Where(ni => ni.OperationalStatus == OperationalStatus.Up))
            {
                var properties = network.GetIPProperties();

                if (properties.GatewayAddresses.Count > 0 && properties.GatewayAddresses.FirstOrDefault().Address.ToString().Any(a => char.IsDigit(a)))
                {
                    var lIP = properties.UnicastAddresses.FirstOrDefault(ip => ((ip.Address.AddressFamily == AddressFamily.InterNetwork) && (!IPAddress.IsLoopback(ip.Address))));
                    localIP = lIP.Address.ToString();
                    break;
                }
            }
        }
    }
}
