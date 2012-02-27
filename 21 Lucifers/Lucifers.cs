using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _21_Lucifers
{
    class Lucifers
    {
        int lucifers;
        string beurt;
        bool einde;
        int laatstGekozen;

        int[] antwoorden;

        public Lucifers()
        {
            Random r = new Random();

            lucifers = 21;
            beurt = "computer";
            einde = false;
            laatstGekozen = 0;

            antwoorden = new int[22];
            antwoorden[2] = 1;
            antwoorden[3] = 2;
            antwoorden[4] = 3;
            antwoorden[5] = r.Next(1, 3);
            antwoorden[6] = 1;
            antwoorden[7] = 2;
            antwoorden[8] = 3;
            antwoorden[9] = r.Next(1, 3);
            antwoorden[10] = 1;
            antwoorden[11] = 2;
            antwoorden[12] = 3;
            antwoorden[13] = r.Next(1, 3);
            antwoorden[14] = 1;
            antwoorden[15] = 2;
            antwoorden[16] = 3;
            antwoorden[17] = r.Next(1, 3);
            antwoorden[18] = 1;
            antwoorden[19] = 2;
            antwoorden[20] = 3;
            antwoorden[21] = r.Next(1, 3);
        }

        public void Run()
        {
            while (!einde)
            {
                Console.Clear();
                writeStand();

                switch (beurt)
                {
                    case "speler":
                        vraagLucifers();
                        break;
                    case "computer":
                        AI();
                        break;
                }
                checkWinnaar();
                beurt = (beurt == "speler") ? "computer" : "speler"; 
            }
            Console.ReadKey();
        }

        void writeStand()
        {
            Console.WriteLine("-- 21 Lucifers --");
            Console.WriteLine("Er zijn  nog " + lucifers + " over.\n");
            Console.WriteLine(beurt + " is aan de beurt.");
        }

        void vraagLucifers()
        {
            bool fouteInvoer = false;

            Console.Write("Pak 1, 2 of 3 lucifers: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    lucifers -= 1;
                    laatstGekozen = 1;
                    break;
                case "2":
                    lucifers -= 2;
                    laatstGekozen = 2;
                    break;
                case "3":
                    lucifers -= 3;
                    laatstGekozen = 3;
                    break;
                default:
                    Console.WriteLine("Onjuiste invoer!");
                    Console.ReadKey();
                    Console.Clear();
                    writeStand();
                    vraagLucifers();
                    fouteInvoer = true;
                    break;
            }

            if (!fouteInvoer)
            {
                Console.Clear();
                writeStand();
                if (input == "1")
                    Console.WriteLine("Je hebt " + input + " lucifer gepakt");
                else
                    Console.WriteLine("Je hebt " + input + " lucifers gepakt");
                Console.ReadKey();
            }
        }

        void AI()
        {
            //switch (laatstGekozen)
            //{
            //    case 1:
            //        lucifers -= 3;
            //        Console.WriteLine("De computer pakt 3 lucifers");
            //        break;
            //    case 2:
            //        lucifers -= 2;
            //        Console.WriteLine("De computer pakt 2 lucifers");
            //        break;
            //    case 3:
            //        lucifers -= 1;
            //        Console.WriteLine("De computer pakt 1 lucifer");
            //        break;
            //}

            Console.WriteLine("De computer pakt " + antwoorden[lucifers] + " lucifers");
            lucifers -= antwoorden[lucifers];

            Console.ReadKey();
        }

        void checkWinnaar()
        {
            switch (lucifers)
            {
                case 0:
                    Console.Clear();
                    if (beurt == "speler")
                        Console.WriteLine("Je hebt verloren.");
                    else
                        Console.WriteLine("Je hebt gewonnen.");
                    einde = true;
                    break;
                case 1:
                    Console.Clear();
                    if (beurt == "speler")
                        Console.WriteLine("Je hebt gewonnen.");
                    else
                        Console.WriteLine("Je hebt verloren.");
                    einde = true;
                    break;
            }
        }
    }
}
