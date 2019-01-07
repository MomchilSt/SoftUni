using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
            this.Owner = "Centre";
        }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated { get; set; }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Happiness
        {
            get { return happiness; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                happiness = value;
            }
        }

        public int Energy
        {
            get { return energy; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }

        public int ProcedureTime
        {
            get { return procedureTime; }
            set { procedureTime = value; }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public override string ToString()
        {
            return $"    Animal type: {this.GetType().Name} - {Name} - Happiness: {Happiness} - Energy: {Energy}";
        }
    }
}
