using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Armor
    {

        //frugal / fields

        //people / properties
        public string Name { get; set; }
        public int BonusMaxLife { get; set; }
        public int BonusBlock { get; set; }
        public int Cost { get; set; }

        //collect / constructors (ctors)

        public Armor(string name, int bonusMaxLife, int bonusBlock, int cost)
        {
            Name = name;
            BonusMaxLife = bonusMaxLife;
            BonusBlock = bonusBlock;
            Cost = cost;
        }

        public Armor() { }

        //money / methods

        public override string ToString()
        {
            return $"{Name}\n" +
                $"{BonusMaxLife} Max Life Bonus\n" +
                $"Bonus Block: {BonusBlock}%\n" +
                $"Cost: {Cost}\n";
        }//end ToString() override

    }
}
