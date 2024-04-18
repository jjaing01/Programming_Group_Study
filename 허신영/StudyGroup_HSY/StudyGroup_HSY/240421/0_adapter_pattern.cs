using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_HSY._240421
{
    internal class Program
    {
        // Adaptee: Keyboard
        public class Keyboard
        {
            public void handleInput()
            {
                Console.WriteLine("handle keyboard input");
            }
        }

        // Adaptee: Mouse
        public class Mouse
        {
            public void handleInput()
            {
                Console.WriteLine("handle mouse input");
            }
        }

        // Target Interface
        public interface IInputDevice
        {
            void processInput();
        }

        // Adapter for Keyboard
        public class KeyboardAdapter : IInputDevice
        {
            public KeyboardAdapter()
            {
                keyboard = new Keyboard();
            }

            public void processInput()
            {
                // process keyboard input
                keyboard.handleInput();
            }

            private Keyboard keyboard;
        }

        // Adapter for Mouse
        public class MousedAdapter : IInputDevice
        {
            public MousedAdapter()
            {
                mouse = new Mouse();
            }

            public void processInput()
            {
                // process keyboard input
                mouse.handleInput();
            }

            private Mouse mouse;
        }

        public static void Main(string[] args)
        {
            List<IInputDevice> devices = new List<IInputDevice>
            {
                new KeyboardAdapter()
                , new MousedAdapter()
            };

            foreach (var device in devices) 
            {
                device.processInput();
            }
        }
    }
}
