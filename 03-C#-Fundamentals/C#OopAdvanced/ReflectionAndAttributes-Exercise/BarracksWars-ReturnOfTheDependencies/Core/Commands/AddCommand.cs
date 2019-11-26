using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Commands;
using BarracksWars_TheCommandsStrikeBack.Core.Commands;
using System;

namespace _03BarracksFactory.Core.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data)
        {
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        protected IRepository Repository
        {
            get => repository;
            set => repository = value;

        }

        protected IUnitFactory UnitFactory
        {
            get => unitFactory;
            set => unitFactory = value;
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }

        public class InjectAttribute : Attribute
        {
        }
    }
}
