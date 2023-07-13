using System;
using System.Net;
using System.Net.Sockets;

namespace GalaxyMap.Utilities
{
    public static class SystemService
    {
        /// <summary>
        /// Gets the IPv4 address of the current user.
        /// </summary>
        public static string GetIPv4Address { get { return GetUserIPAddress(); } }

        /// <summary>
        /// Gets the operating system version of the current system.
        /// </summary>
        public static string GetOSVersion { get { return GetOSType(); } }

        private static string GetUserIPAddress()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostAddresses(hostName);

            foreach (IPAddress address in addresses)
            {
                // Check if the address is IPv4 and not a loopback or multicast address
                if (address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(address) && !IsMulticast(address))
                {
                    return address.ToString();
                }
            }

            return null; // Return null if no IPv4 address found
        }

        private static bool IsMulticast(IPAddress ipAddress)
        {
            byte[] addressBytes = ipAddress.GetAddressBytes();
            return addressBytes[0] >= 224 && addressBytes[0] <= 239;
        }

        private static string GetOSType()
        {
            OperatingSystem os = Environment.OSVersion;

            if (os.Platform == PlatformID.Win32NT)
            {
                return "Windows";
            }
            else if (os.Platform == PlatformID.Unix)
            {
                return "Unix";
            }
            else if (os.Platform == PlatformID.MacOSX)
            {
                return "MacOS";
            }
            else
            {
                return "Unknown";
            }
        }

    }
}

