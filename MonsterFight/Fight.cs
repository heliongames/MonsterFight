using System;
using System.Collections.Generic;

namespace MonsterFight
{
    public class Fight
    {
        static Monster firstMoster = new Monster();
        static Monster secondMoster = new Monster();
        static int rounds;

        static void Main()
        {
            Console.Title = "Monster Fight";
            Console.WriteLine("Welcome to the Monster fight!\n");
            Console.WriteLine("Please select race of first monster, and press enter: ");
            ShowPossibleRace();
            ReadConsole();
            Console.WriteLine("Please select race of second monster, and press enter: ");
            ShowPossibleRace();
            ReadConsole();
            GenerateMonsterStat();
            Console.WriteLine("Let's the fight begin!");
            DoFight();
        }

        private static void ShowPossibleRace()
        {
            string textValue = "";
            for (int i = 0; i < Tools.Races.Count; i++)
            {
                textValue += ((i+1)+ "-" + Tools.Races[i]+ " ").ToString();
            }
            Console.WriteLine(textValue);
        }

        private static void GenerateMonsterStat()
        {
            firstMoster.GenerateMonsterStats();
            secondMoster.GenerateMonsterStats();
        }

        private static void DoFight()
        {
            rounds++;
            if(firstMoster.DidAttack && secondMoster.DidAttack)
            {
                firstMoster.DidAttack = false;
                secondMoster.DidAttack = false;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nROUND "+rounds+ ":");
            Console.ResetColor();
            if(firstMoster.Speed > secondMoster.Speed)
            {
                if (!firstMoster.DidAttack)
                {
                    firstMoster.Attack(secondMoster);
                }
                else
                {
                    secondMoster.Attack(firstMoster);
                }
            }
            else
            {
                if (!secondMoster.DidAttack)
                {
                    secondMoster.Attack(firstMoster);
                }
                else
                {
                    firstMoster.Attack(secondMoster);
                }
            }
            if(firstMoster.HitPoint > 0 && secondMoster.HitPoint > 0)
            {
                System.Threading.Thread.Sleep(500);
                DoFight();
            } 
            else
            {
                Console.Write(" It's took " + rounds + " rounds\n\n");
                Console.Beep(1000, 1000);
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        private static void ReadConsole()
        {
            do
            {
                string _consoleInput = Console.ReadLine();
                int _race;
                if (Int32.TryParse(_consoleInput, out _race))
                {
                    if (_race <= Tools.Races.Count)
                    {
                        if (firstMoster.Race == 0)
                        {
                            firstMoster.Race = Tools.RaceToInt(Tools.Races[_race - 1]);
                            Console.WriteLine($"First monster race is: {Tools.Races[firstMoster.Race - 1]}\n");
                            Tools.Races.RemoveAt(_race - 1);
                            break;
                        }
                        else
                        {
                            secondMoster.Race = Tools.RaceToInt(Tools.Races[_race - 1]);
                            Console.WriteLine($"Second monster race is: {Tools.Races[_race - 1]}\n");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please select available race!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter only number");
                }
            } while (true);
        }
    }
}
