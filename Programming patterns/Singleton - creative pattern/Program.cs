using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton___creative_pattern
{
    // The singleton programming pattern is a creational design pattern that ensures a class has only one instance and provides a global point of access to that instance.
    public class Logger
    {
        private static Logger _instance;
        private Logger() { }

        public static Logger Instance => _instance ?? (_instance = new Logger());

        public void Log(string message)
        {
            Console.WriteLine($"LOG: {message}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Instance.Log("Test message");
        }
    }
}
