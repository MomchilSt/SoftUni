using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        public List<IAnimal> ProcedureHistory
        {
            get { return procedureHistory; }
            set { this.procedureHistory = value; }
        }

        public virtual string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{GetType().Name}\n");

            foreach (var animal in ProcedureHistory)
            {
                sb.Append(animal.ToString() + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);
        
    }
}
