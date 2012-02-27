using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoordRaden
{
    class WoordRaden
    {
        String woord;
        String shuffledWoord;
        int maxLength;
        int pogingen;
        bool geraden;

        public WoordRaden()
        {
            woord = "";
            shuffledWoord = "";
            maxLength = 12;
            pogingen = 0;
            geraden = false;
        }

        public void run()
        {
            displayScreen();

            getWoord(); 

            while(woord.Length >= maxLength)
            {
                getWoord();
            }

            Random r = new Random();
            char[] characters = woord.ToCharArray();

            for (int i = 0; i < 20; i++)
            {
                int a = r.Next(characters.Length);
                char temp = characters[a];
                int b = r.Next(characters.Length);
                characters[a] = characters[b];
                characters[b] = temp;
            }
            shuffledWoord = new string(characters);

            while(geraden == false && pogingen < 3)
            {
                displayScreen();
                Console.WriteLine("Woord: "+shuffledWoord);
                int pogingenOver = 3 - pogingen;
                Console.WriteLine("Pogingen:"+ pogingenOver);

                if (pogingen == 2)
                {
                    Console.WriteLine("Hint: "+woord.Substring(0, 2));
                }

                Console.Write("Raad het woord: ");

                string antwoord = Console.ReadLine();

                if (antwoord == woord)
                {
                    geraden = true;
                }

                pogingen++;
            }

            if (geraden)
            {
                Console.WriteLine("Gewonnen");
            }
            else
            {
                Console.WriteLine("Verloren");
            }

            Console.ReadKey();
        }

        private void getWoord()
        {
            displayScreen();
            Console.Write("Voer een woord in: ");
            woord = Console.ReadLine().ToLower();
        }

        private void displayScreen()
        {
            Console.Clear();
            Console.WriteLine("-- Raad het woord --\n");
            Console.WriteLine("Raad het woord   \"Raad het woord\" is een spel dat je tegen iemand anders speelt door gebruik te maken van een computer. De eerste speler geeft een woord in. De computer zet detters door elkaar\n");
        }
    }
}