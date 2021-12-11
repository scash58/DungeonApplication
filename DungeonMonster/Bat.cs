using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;

namespace DungeonMonster
{
    public class Bat : Monster
    {
        //frugal / fields

        //people / properties
        public bool IsVeryAgile { get; set; }

        //collect / constructors (ctors)
        public Bat()
        {
            //SET MAX VALUES FIRST!
            MaxLife = 4;
            MaxDamage = 2;
            Name = "Small Bat";
            Life = 4;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            MonsterScore = 1;
            Description = "That's one ugly bird.";
            GoldReward = 3;
            IsVeryAgile = false;
        }//end default ctor

        public Bat(string name, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, int monsterScore, string description, int goldReward, bool isVeryAgile) 
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, monsterScore, description, goldReward)
        {
            //just handle the unique ones
            IsVeryAgile = isVeryAgile;
            if (IsVeryAgile)
            {
                Block += 5;
            }
        }

        //money / methods

        public override string ToString()
        {
            return base.ToString() + (IsVeryAgile ? "Wow, it a ugly agile bird!" : "That's a ugly clumsy bird");
        }//end ToString()

    }
}
