using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFight
{
    
    class Tools
    {
        public static List<string> Races = new List<string> { "Orc", "Goblin", "Troll" };
        
        /// <summary>
        /// Convert race name to array id 
        /// </summary>
        /// <param name="_race"></param> Race in text
        /// <returns></returns> Array id
        public static int RaceToInt(string _race)
        {
            int id = 0;
            string[] _races = { "Orc", "Goblin", "Troll" };
            for (int i = 0; i < _races.Length; i++)
            {
                if (_race == _races[i])
                {
                    id = (i + 1);
                    break;
                }
            }
            return id;
        }
        /// <summary>
        /// Convert array id to race name
        /// </summary>
        /// <param name="_id"></param> Array id
        /// <returns></returns> Race name
        public static string IntToRace(int _id)
        {
            string _race = "";
            string[] _races = { "Orc", "Goblin", "Troll" };
            for (int i = 0; i < _races.Length; i++)
            {
                if ((_id - 1) == i)
                {
                    _race = _races[i];
                    break;
                }
            }
            return _race;
        }
    }
}
