using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {

        //frugal / fields
        //we will have a business rule on MinDamage, we need a full prop and full field

        private int _minDamage;

        //people / properties
        //Auto props go first (no business rules)
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MonsterScore { get; set; }
        public int GoldReward { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            //Can't be more than Maxdamage and can't be less than 1
            set
            {
                //value can't be more than the MaxDamage
                //and cannot be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    //you're good
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
                //_minDamage = (value > 0 && value <= MaxDamage) ? value : 1;
            }//end set
        }//end MinDamage

        //collect / constructors (ctors)
        public Monster() { }

        public Monster(string name, int life, int maxLife, int hitChance,
            int block, int minDamage, int maxDamage, int monsterScore, string description, int goldReward)
        {
            //PascalCase = camelcase
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MonsterScore = monsterScore;
            Description = description;
            MinDamage = minDamage;
            GoldReward = goldReward;
            
        }//end FQ CTOR

        //money / methods
        public override string ToString()
        {
            return $"\n********* MONSTER *********\n" +
                $"{Name}\n" +
                $"Life: {Life} / {MaxLife}\n" +
                $"Damage: {MinDamage} to {MaxDamage}\n" +
                $"Block: {Block}\n" +
                $"Score: {MonsterScore}\n" +
                $"Reward: {GoldReward} gold\n" +
                $"Description: {Description}\n";
        }//end ToString()

        //We are overriding the CalcDamage() to use the props MinDamage and MaxDamage
        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
            //IF we had a monster that had a mindamage of 2 and max of 8...
            //and passed just MinDamage and MaxDamage to the Next(), it would
            //only return a random number between 2 and 7.
        }//end CalcDamage()


    }
}
