using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;//added

namespace DungeonMonster
{
    public class Bear : Monster
    {

        //frugal / fields

        //people / properties
        public bool IsHuge { get; set; }

        //collect / constructors (ctors)
        public Bear()
        {
            //SET MAX VALUES FIRST!
            MaxLife = 10;
            MaxDamage = 8;
            Name = "Black Bear";
            Life = 10;
            HitChance = 20;
            Block = 20;
            MinDamage = 2;
            MonsterScore = 3;
            Description = "That bear is big, not huge.";
            GoldReward = 10;
            IsHuge = false;
        }//end default ctor

        public Bear(string name, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, int monsterScore, string description, int goldReward, bool isHuge)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, monsterScore, description, goldReward)
        {
            //just handle the unique ones
            IsHuge = isHuge;
            if (IsHuge)
            {
                MaxDamage += 5;
            }
        }

        //money / methods

        public override string ToString()
        {
            return base.ToString() + (IsHuge ? "Big Bear chase me!" : "That's a small bear.");
        }//end ToString()

    }
}
