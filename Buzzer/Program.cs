using System;
using System.Device.Gpio;
using System.Threading;

namespace Buzzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var buzzer = 24;
            var buzzerState = false;
            var controller = new GpioController();

            controller.OpenPin(buzzer, PinMode.Output);

            while (true)
            {
                buzzerState = !buzzerState;
                Console.WriteLine($"Buzzing: {buzzerState}");
                // buzzerState is implicitly converted to PinMode
                controller.Write(buzzer, buzzerState);

                Thread.Sleep(1000);
            }
        }
    }
}
