using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Interfaces;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) 
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.CheckAlive();
            character.CheckAlive();

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.IncreaseHealth(this.AbilityPoints);
        }
    }
}
