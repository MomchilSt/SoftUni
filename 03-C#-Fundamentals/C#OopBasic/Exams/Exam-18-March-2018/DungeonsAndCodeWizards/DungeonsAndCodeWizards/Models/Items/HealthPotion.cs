using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const int defaultWeight = 5;

        public HealthPotion() : base(defaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.IncreaseHealth(20);
        }
    }
}
