﻿using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            var setType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(s => s.Name == type);

            var set = (ISet)Activator.CreateInstance(setType, name);

            return set;
		}
	}
}
