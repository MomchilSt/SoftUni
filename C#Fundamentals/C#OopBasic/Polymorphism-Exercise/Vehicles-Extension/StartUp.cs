using System;
using Vehicles_Extension.Core;

namespace Vehicles_Extension
{
    public class StartUp
    {
        static void Main()
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
