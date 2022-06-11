using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace COMPortSimulator
{
    class Program
    {
        private const int BaudRate = 9600;
        private static Random r = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Choose your COM-Port:");
            string[] arr = SerialPort.GetPortNames();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("[" + i + "] " + arr[i]);
            }
            int choice = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                Console.Write("Enter value to send: ");
                string input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                {
                    double val = Convert.ToDouble(input);
                    Console.WriteLine("Sending...");

                    SerialPort sp1 = new SerialPort(arr[choice], BaudRate, Parity.None, 8, StopBits.One);

                    sp1.Open();
                    /*
                    for (int i = 0; i < 10; i++)
                    {
                        val += r.NextDouble();
                        sp1.WriteLine(val.ToString());
                        Console.WriteLine(val.ToString() + " sent!");
                        Thread.Sleep(800);
                    }
                    */
                    val += r.NextDouble();
                    string hold = Math.Round(val, 1).ToString();


                    char[] arr1 = new char[42] { 'D', 'a', 't', 'u', 'm', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '0', '7', '.', '0', '7', '.', '0', '8', '\r', '\n' };
                    char[] arr2 = new char[42] { 'U', 'h', 'r', 'z', 'e', 'i', 't', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '1', '3', ':', '5', '8', ':', '1', '8', '\r', '\n' };
                    char[] arr3 = new char[42] { 'W', 'a', 'a', 'g', 'e', ' ', 'N', 'r', '.', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '0', '1', '\r', '\n' };
                    char[] arr4 = new char[42] { '\r', '\n', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                    char[] arr5 = new char[42] { 'B', 'r', 'u', 't', 't', 'o', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'B', ' ', ' ', ' ', ' ', ' ', '1', '5', '0', '0', ',', '0', ' ', 'k', 'g', ' ', '\r', '\n' };
                    char[] arr6 = new char[42] { 'T', 'a', 'r', 'a', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'T', ' ', ' ', ' ', ' ', ' ', ' ', '5', '0', '0', ',', '0', ' ', 'k', 'g', ' ', '\r', '\n' };
                    char[] arr7 = new char[42] { 'N', 'e', 't', 't', 'o', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'N', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'k', 'g', ' ', '\r', '\n' };
                    char[] arr8 = new char[42] { '\r', '\n', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                    char[] arr9 = new char[42] { '\r', '\n', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                    char[] arr10 = new char[42] { '\r', '\n', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                    char[] arr11 = new char[42] { '\r', '\n', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                    char[] arr12 = new char[42] { '\r', '\n', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                    char[] arr13 = new char[42] { '\r', '\n', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

                    for (int i = 0; i < hold.Length; i++)
                    {
                        arr7[35-i] = hold[hold.Length-1 - i];
                    }


                    List<char[]> lWrites = new List<char[]>();
                    lWrites.Add(arr1);
                    lWrites.Add(arr2);
                    lWrites.Add(arr3);
                    lWrites.Add(arr4);
                    lWrites.Add(arr5);
                    lWrites.Add(arr6);
                    lWrites.Add(arr7);
                    lWrites.Add(arr8);
                    lWrites.Add(arr9);
                    lWrites.Add(arr10); 
                    lWrites.Add(arr11);
                    lWrites.Add(arr12);
                    lWrites.Add(arr13);

                    foreach(char[] c in lWrites)
                    {
                        sp1.Write(new String(c));
                        Console.Write(new String(c)+" sent!");
                    }
                    lWrites.Clear();
                    Console.WriteLine("Sent!");
                    Console.ReadKey();
                    sp1.Close();
                }
            }
        }
    }
}
