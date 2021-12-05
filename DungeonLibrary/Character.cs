using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Character
    {
        //frugal / fields
        private int _life;

        //people / properties
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }

        //Life can never be higher than MaxLife
        public int Life
        {
            get { return _life; }
            set
            {
                //Life should not be MORE that MaxLife
                if (value <= MaxLife)
                {
                    //good to go
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }//end set
        }//end Life

        //collect / constructors (ctors)
        //no need for a ctor

        //money / methods
        //No ToString override

        public virtual int CalcBlock()
        {
            //To be able to override this in a child class, make it VIRTURAL
            //This basic version just returns block, but this gives us 
            //the option to do something different in child classes
            return Block;
        }//end CalcBlock

        //MINI_LAB
        //Make CalcHitChance method returns HitChance. Make it Overridable
        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance()

        public virtual int CalcDamage()
        {
            return 0;
            //Override this in Monster and Player
        }//end CalcDamage()
    }
}
