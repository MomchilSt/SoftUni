using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElit.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; set; }

    }
}
