using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElit.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        ICollection<IMission> Missions { get; set; }
    }
}
