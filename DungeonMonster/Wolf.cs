using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;//added

namespace DungeonMonster
{
    public class Wolf : Monster
    {

        //props
        public bool IsReallyAngry { get; set; }

        //ctor

        public Wolf()
        {
            //SET MAX VALUES FIRST!
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Young Wolf";
            Life = 8;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            MonsterScore = 1;
            Description = "It must be the runt of the litter. Hopefully it's father doesn't show up.";
            GoldReward = 5;
            IsReallyAngry = false;

        }//end default ctor

        public Wolf(string name, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, int monsterScore, string description, int goldReward, bool isReallyAngry)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, monsterScore, description, goldReward)
        {
            //just handle the unique ones
            IsReallyAngry = isReallyAngry;
        }//end FQ CTOR

        //methods

        public override string ToString()
        {
            return base.ToString() + (IsReallyAngry ? "Wow it's angry!" : "What a cute doggo");
        }//end ToString()

        //override block : if they are fluffy, they get a bonus 50% to their block value
        public override int CalcDamage()
        {
            //Typically when dealing with a method that has a return type,
            //we create the return type first.
            int calcMinDamage = MinDamage;

            if (IsReallyAngry)
            {
                Random rand = new Random();
                return (rand.Next(MinDamage, MaxDamage + 1) + 2);
            }
            else
            {
                Random rand = new Random();
                return rand.Next(MinDamage, MaxDamage + 1);
            }

        }
    }
