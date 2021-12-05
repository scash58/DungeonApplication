using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //frugal / fields
        private int _minDamage;

        //people / properties
        //properties with business should go last
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int BonusHitChance { get; set; }
        public bool IsTwoHanded { get; set; }
        public int Cost { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //value can't be more than the MaxDamage
                //and cannot be less than 1
                _minDamage = (value > 0 && value <= MaxDamage) ? value : 1;
            }//end set
        }// MinDamage

        //collect / constructors (ctors)

        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance, bool isTwoHanded, int cost)
        {
            //If you have ANY properties that have business rules
            //that are based off of any OTHER properties,
            //set the "OTHER" properties first.
            MaxDamage = maxDamage;//Since MinDamage depends on Max, set Max First!
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            Cost = cost;
        }//fully qualified ctor (FQ CTOR)

        public Weapon() { }

        //no default ctor

        //money / methods
        public override string ToString()
        {
            return $"{Name}\t{MinDamage} - {MaxDamage} Damage\n" +
                $"Bonus Hit: {BonusHitChance}%\t" +
                $"{(IsTwoHanded ? "Two-Handed" : "One-Handed")}\n" +
                $"Cost: {Cost}";
        }//end ToString() override

    }
}
