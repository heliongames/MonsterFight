using System;
using System.Collections.Generic;

namespace MonsterFight
{
    public class Fight
    {
        static Monster firstMoster = new Monster();
        static Monster secondMoster = new Monster();
        static List<string> races = new List<string>();
        static int rounds;
        

        static void Main()
        {
            AddToRacesList();
            Console.WriteLine("Welcome to the Monster fight!\n");
            Console.WriteLine("Please select race of first monster, and press enter: ");
            ShowPossibleRace();
            ReadConsole();
            Console.WriteLine("Please select race of second monster, and press enter: ");
            ShowPossibleRace();
            ReadConsole();
            GenerateMonsterStat();
            Console.WriteLine("Let's the fight begin!");
            Attack();
        }

        private static void AddToRacesList()
        {
            races.Add("Orc");
            races.Add("Goblin");
            races.Add("Troll");
        }

        private static void ShowPossibleRace()
        {
            string textValue = "";
            for (int i = 0; i < races.Count; i++)
            {
                textValue += ((i+1)+ "-" + races[i]+ " ").ToString();
            }

            Console.WriteLine(textValue);
        }

        private static void Attack()
        {
            rounds++;
            if(firstMoster.DidAttack && secondMoster.DidAttack)
            {
                firstMoster.DidAttack = false;
                secondMoster.DidAttack = false;
            }
            Console.WriteLine("\n\nRound "+rounds+ " fight: \n");

            if(firstMoster.Speed > secondMoster.Speed)
            {
                if (!firstMoster.DidAttack)
                {
                    FirstMonsterAttack();

                }
                else
                {
                    SecondMonsterAttack();
                }
            }
            else
            {
                if (!secondMoster.DidAttack)
                {
                    SecondMonsterAttack();
                }
                else
                {
                    FirstMonsterAttack();
                }
            }
        }

        private static void FirstMonsterAttack()
        {
            float _dmg = CalculateDamage(firstMoster, secondMoster);
            Console.WriteLine(IntToRace(firstMoster.Race) + " did attack " + IntToRace(secondMoster.Race) + " and hit him with " + _dmg + " damage points");
            if (secondMoster.HitPoint - _dmg > 0)
            {
                secondMoster.HitPoint = secondMoster.HitPoint - _dmg;
                Console.WriteLine(IntToRace(secondMoster.Race) + " still have " + secondMoster.HitPoint+" hit points left");
                firstMoster.DidAttack = true;
                Attack();
            }
            else
            {
                Console.WriteLine(IntToRace(secondMoster.Race) + " is dead!");
                Console.WriteLine(IntToRace(firstMoster.Race) + " win this fight!");
                Console.WriteLine("It's take " + rounds + " rounds");

            }
        }

        private static void SecondMonsterAttack()
        {
            float _dmg = CalculateDamage(secondMoster, firstMoster);
            Console.WriteLine(IntToRace(secondMoster.Race) + " did attack " + IntToRace(firstMoster.Race) + " and hit him with " + _dmg + " damage points");
            if (firstMoster.HitPoint - _dmg > 0)
            {
                firstMoster.HitPoint = firstMoster.HitPoint - _dmg;
                Console.WriteLine(IntToRace(firstMoster.Race) + " still have " + firstMoster.HitPoint + " hit points left");
                secondMoster.DidAttack = true;
                Attack();
            }
            else
            {
                Console.WriteLine(IntToRace(firstMoster.Race) + " is dead!");
                Console.WriteLine(IntToRace(secondMoster.Race) + " win this fight!");
                Console.WriteLine("It's take " + rounds + " rounds");

            }
        }

        private static float CalculateDamage(Monster _firstMoster, Monster _secondMoster)
        {
            float _damage = 0;
            _damage = _firstMoster.AttackPoint - _secondMoster.DefencePoint;
            return _damage;
        }

        private static void GenerateMonsterStat()
        {
            firstMoster.GenerateMonsterStats();
            secondMoster.GenerateMonsterStats();
        }

        private static void ReadConsole()
        {
            int race = Convert.ToInt32(Console.ReadLine());

            while (race > races.Count) 
            {
                Console.WriteLine("Please select available race!");
                race = Convert.ToInt32(Console.ReadLine());
            }

            if (firstMoster.Race == 0)
            {
                firstMoster.Race = RaceToInt(races[race - 1]);
                Console.WriteLine($"First monter race is: {races[firstMoster.Race - 1]}\n");
                races.RemoveAt(race-1);
            }
            else
            {
                
                secondMoster.Race = RaceToInt(races[race - 1]);
                Console.WriteLine($"Second monter race is: {races[race - 1]}\n");
            }
        }

        private static int RaceToInt(string _race)
        {
            int id = 0;
            string[] _races = { "Orc", "Goblin", "Troll" };
            for (int i = 0; i < _races.Length; i++)
            {
                if(_race == _races[i])
                {
                    id = (i+1);
                    break;
                }
            }
            return id;
        }

        private static string IntToRace(int _id)
        {
            string _race = "";
            string[] _races = { "Orc", "Goblin", "Troll" };
            for (int i = 0; i < _races.Length; i++)
            {
                if ((_id-1) == i)
                {
                    _race = _races[i];
                    break;
                }
            }
            return _race;
        }
    }
}
