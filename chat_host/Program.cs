﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace chat_host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(chat_cl.ServiceChat)))
            {
                host.Open();
                Console.WriteLine("Host starting!");
                Console.ReadLine();
            }
        }
    }
}
