using System;

namespace ReservationSystem
{
    public class Logger
    {
        private static readonly Lazy<Logger> instance =
            new Lazy<Logger>(() => new Logger());

        private Logger() { }

        public static Logger Instance => instance.Value;

        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
        }
    }
}