using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElit.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        ICollection<IRepair> Repairs { get; set; }
    }
}
