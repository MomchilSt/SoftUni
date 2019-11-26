using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters.Interfaces
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}
