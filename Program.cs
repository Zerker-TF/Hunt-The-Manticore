using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunting_the_Manticore
{
    internal class Program
    {
        /*
         Story:
        A Manticore is out for blood and the city defenses consist of a canon, humans and you.
        This program plays out a 1v1 fight between the Manticore pilot and the city soldier that shoots a cannon to take it down
        Rules go as follow:
        1- how far is monster from city [0-100], clear after input
        2- player tries to guess range and return a hit, overshot or fell short
        3- damage is 1 per regular turn
            if turn nmbr % 3 = 0, damage is 3 fire blast
            if turn nmbr % 5 = 0, damage is 3 electric blast
            if turn nmbr is all the above, damage is 10 electric-fire blast
        4- Manticore survives, 1 damage to city (city hp = 15) (manticore hp = 10)
        5- show status of city an manticore hp at the start of each turn
        */
        

        static void Main(string[] args)
        {
            int ManticoreHP = 10;
            int CityHP = 15;
            int round = 1;

            Console.Title = "Hunting the Manticore v1";

            Console.ForegroundColor= ConsoleColor.DarkRed;
            Console.Write("Player 1, how far away from the city do you want to station the Manticore? range: [0-100] \n");
            int ManticoreLocation = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Player 2, it is your turn.\n");
            Console.Clear();
            
            while (CityHP > 0 && ManticoreHP > 0)
            {
                //Display round info
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("------------------------------");
                RoundStatus(round, CityHP, ManticoreHP);

                //Display round damage results
                int damage = RoundDamage(round);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"The canon will deal {damage} points of damage this round.");

                //insert cannon range from player 2
                Console.ForegroundColor = ConsoleColor.DarkRed;
                int CannonHit = CannonRange("Enter desired cannon range:");

                //Outcome of given range
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                DisplayResult(CannonHit, ManticoreLocation);

                //if Manticore gets hit
                if(CannonHit == ManticoreLocation)
                {
                    ManticoreHP -= damage;
                }
                //if Canon misses or manticore survives
                if(ManticoreHP > 0)
                {
                    CityHP--;
                }
                round++;
            }

            //game outcome
            bool won = CityHP > 0;
            DisplayEnding(won);

        }

        static void DisplayEnding (bool won)
        {
            if (won)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Manticore has been destroyed! The city has been saved!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("The city has been destroyed. The Manticore has killed everyone");
            }
        }
        
        static void RoundStatus (int round, int cityHP, int ManticoreHP)
        {
            //Display current round, city remaining health, manticore remaining health and prints on screen
            Console.WriteLine($"STATUS:     ROUND: {round}  City: {cityHP}/15   Manticore: {ManticoreHP}/10");
        }

        static int RoundDamage (int round)
        {
            /*
             * if round % 3 == 0, damage is 3
             * if round % 5 == 0, damage is 3
             * if both happen, damage is 10
             */
            if (round % 3 == 0 && round % 5 == 0) { return 10; } //fire-electric blast
            if (round % 3 == 0) { return 3; } //fire blast
            if (round % 5 == 0) { return 3; }//electric blast
            return 1; //normal
        }
        
        static int CannonRange (string text)
        {
            Console.Write(text + " ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            int number = Convert.ToInt32(Console.ReadLine());
            if(number < 0 || number > 100)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Insert a valid range [0-100].");
                CannonRange(text); 
            }
            return number;
        }



    }
}
