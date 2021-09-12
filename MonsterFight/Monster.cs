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
            AttackPoint = random.Next(6, 10);
            HitPoint = random.Next(25, 50);
            DefencePoint = random.Next(1, 5);
            Speed = random.Next(1, 5);
        }
    }
}
