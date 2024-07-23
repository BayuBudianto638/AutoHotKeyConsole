using System;
using System.Timers;
using WindowsInput;

namespace AutoHotKeyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Calculate delay until 8 AM today
            DateTime now = DateTime.Now;
            DateTime targetTime = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);
            if (targetTime < now)
            {
                targetTime = targetTime.AddDays(1); // If it's past 8 AM, target tomorrow's 8 AM
            }

            TimeSpan delay = targetTime - DateTime.Now;
            Timer timer = new Timer(delay.TotalMilliseconds);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = false;
            timer.Start();

            Console.WriteLine("Waiting for 8 AM today...");
            Console.ReadLine();
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var inputSimulator = new InputSimulator();
            inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
        }
    }
}