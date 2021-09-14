using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFight
{
    class Monster
    {
        public int Race = 0;
        public float HitPoint = 0f;
        public float AttackPoint = 0f;
        public float DefencePoint = 0f;
        public float Speed = 0f;
        public bool DidAttack;
        static Random random = new Random();

        public void GenerateMonsterStats()
        {
            HitPoint = random.Next(25, 50);
            AttackPoint = random.Next(6, 10);
            DefencePoint = random.Next(1, 5);
            Speed = random.Next(1, 5);
        }

        public void Attack(Monster _enemy)
        {
            float _dmg = CalculateDamage(_enemy);
            Console.WriteLine(Tools.IntToRace(Race) + " did attack " + Tools.IntToRace(_enemy.Race) + " and hit him with " + _dmg + " damage points");
            if ((_enemy.HitPoint - _dmg) > 0)
            {
                _enemy.HitPoint = _enemy.HitPoint - _dmg;
                Console.WriteLine(Tools.IntToRace(_enemy.Race) + " still have " + _enemy.HitPoint + " hit points left\n");
                DidAttack = true;
            }
            else
            {
                _enemy.HitPoint = 0;
                Console.WriteLine(Tools.IntToRace(_enemy.Race) + " is dead!");
                Console.WriteLine("\n" + Tools.IntToRace(Race) + " win this fight!");
            }
        }

        private float CalculateDamage(Monster _enemy)
        {
            float _damage = 0;
            _damage = AttackPoint - _enemy.DefencePoint;
            return _damage;
        }
    }
}
