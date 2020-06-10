using System;
using System.Device.Gpio;
using System.Threading;

namespace Lighter
{
    class Program
    {
        static void Main(string[] args)
        {
            var lightPin = 23;
            var controller = new GpioController();
            controller.OpenPin(lightPin, PinMode.Input);

            var state = controller.Read(lightPin);

            while (true)
            {
                if (state == controller.Read(lightPin))
                {
                    if (controller.Read(lightPin) == PinValue.High)
                    {
                        Console.WriteLine("\u263e");
                    }
                    else
                    {
                        Console.WriteLine("\u263c");
                    }
                }
                state = controller.Read(lightPin);

                Thread.Sleep(200);
            }
        }
    }
}
