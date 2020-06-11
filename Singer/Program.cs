using System;
using System.Device.Gpio;
using System.Linq;
using System.Threading;

namespace Singer
{
    class Program
    {
        static int buzzer = 24;
        static GpioController controller = new GpioController();

        static void Buzz(int note, double duration)
        {
            var halveWave = 1 / (note * 2);
            var wave = Convert.ToInt32(duration * note) * 1000;

            foreach (var i in Enumerable.Range(0, wave))
            {
                controller.Write(buzzer, PinValue.High);
                Thread.Sleep(halveWave);
                controller.Write(buzzer, PinValue.Low);
                Thread.Sleep(halveWave);
            }
        }

        static void Play()
        {
            var t = 0;
            var notes = new[] { 262, 294, 330, 262, 262, 294, 330, 262, 330, 349, 392, 330, 349, 392, 392, 440, 392, 349, 330, 262, 392, 440, 392, 349, 330, 262, 262, 196, 262, 262, 196, 262 };
            var duration = new[] { 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 1, 0.5, 0.5, 1, 0.25, 0.25, 0.25, 0.25, 0.5, 0.5, 0.25, 0.25, 0.25, 0.25, 0.5, 0.5, 0.5, 0.5, 1, 0.5, 0.5, 1 };

            for (int i = 0; i < notes.Length; i++)
            {
                Buzz(notes[i], duration[t]);
                Thread.Sleep(Convert.ToInt32(duration[t] * 0.1 * 1000));
                t++;
            }
        }

        static void Main(string[] args)
        {
            controller.OpenPin(buzzer, PinMode.Output);
            Play();
        }
    }
}
