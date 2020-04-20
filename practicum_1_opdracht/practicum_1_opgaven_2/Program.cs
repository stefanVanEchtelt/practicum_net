using practicum_1_opdracht_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicum_1_opgaven_2
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeEngine tick = new TicTacToeEngine();

            bool running = true;
            while (running) {
                Console.WriteLine("Type a number from 1-9, new or quit");
                Console.WriteLine("Status: " + tick.Status);
                Console.WriteLine(tick.Board());

                var line = Console.ReadLine();
                int number;
                if (line.Equals("quit"))
                {
                    running = false;
                    continue;
                } else if (line.Equals("new"))
                {
                    tick.Reset();
                    continue;
                } else if (int.TryParse(line, out number))
                {
                    bool result = tick.ChooseCell(number);

                    if (result)
                        continue;
                }

                Console.WriteLine("Invalid Choice");
            }

        }
    }
}
