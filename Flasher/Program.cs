using System;
using System.Device.Gpio;
using System.Threading;
using System.Threading.Tasks;


namespace Flasher
{
    class Program
    {
        static void Main(string[] args)
        {
            var ledPin = 21;
            var controller = new GpioController();
            controller.OpenPin(ledPin, PinMode.Output);

            int lightTimeInMs = 500;
            int dimTimeInMs = 200;

            while (true)
            {
                Console.WriteLine($"LED1 on for {lightTimeInMs}ms");

                // turn on the LED
                controller.Write(ledPin, PinValue.Low);
                Thread.Sleep(lightTimeInMs);
                Console.WriteLine($"LED1 off for {dimTimeInMs}ms");

                // turn off the LED
                controller.Write(ledPin, PinValue.High);
                Thread.Sleep(dimTimeInMs);
            }
        }
    }
}
