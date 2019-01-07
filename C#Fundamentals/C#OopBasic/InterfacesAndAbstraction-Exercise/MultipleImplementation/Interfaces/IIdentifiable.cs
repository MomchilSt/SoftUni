using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IIdentifiable : IPerson
    {
        string Id { get; set; }
    }
}
