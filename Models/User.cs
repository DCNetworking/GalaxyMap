using System;
using System.Net;
using System.Net.Sockets;
using GalaxyMap.Utilities;

namespace GalaxyMap.Models
{
    public class User
    {
        /// <summary>
        /// Gets the IPv4 address of the user.
        /// </summary>
        public string IPv4Address { get; private set; }

        /// <summary>
        /// Gets the name of the user's operating system.
        /// </summary>
        public string SystemName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            SystemName = SystemService.GetOSVersion;
            IPv4Address = SystemService.GetIPv4Address;
        }

    }
}

