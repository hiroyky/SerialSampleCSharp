using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace SerialSample {
    class Program {
        string comPort;
        SerialPort serialPort;

        public Program(string comPort) {
            this.comPort = comPort;
            this.serialPort = new SerialPort(comPort);
            this.serialPort.BaudRate = 9600;
            Console.CancelKeyPress += Console_CancelKeyPress;
        }

        public void Run() {
            if (!serialPort.IsOpen) {
                serialPort.Open();
            }

            while (true) {
                string val = System.Console.ReadLine();               
                serialPort.Write(val.Substring(0, 1));
                var readVal = serialPort.ReadLine();
                System.Console.WriteLine(readVal);
            }
        }


        private void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e) {
            serialPort.Close();
        }

        static void Main(string[] args) {
            if (args.Length < 1) {
                System.Console.WriteLine("Usage: SerialSample.exe ComPort");
                Environment.Exit(1);
            }

            String comPort = args[0];
            Program program = new Program(comPort);
            program.Run();
        }        
    }
}
