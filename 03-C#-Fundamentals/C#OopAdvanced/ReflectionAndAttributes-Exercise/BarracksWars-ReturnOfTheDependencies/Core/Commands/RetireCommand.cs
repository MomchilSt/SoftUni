using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) 
            : base(data)
        {
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get => repository;
            set => repository = value;

        }

        public override string Execute()
        {
            try
            {
                this.Repository.RemoveUnit(this.Data[1]);
                return $"{this.Data[1]} retired!";
            }
            catch (InvalidOperationException ex)
            {
                return ex.Message;
            }
        }
    }
}
