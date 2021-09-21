using System;
using System.IO;
using Logger.Configs;
using Newtonsoft.Json;

namespace Logger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var starter = new Starter();
            starter.StartApplication();
        }
    }
}
