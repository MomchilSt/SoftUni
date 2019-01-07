using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Person
    {
        private string name;
        private Company company;
        private Car car;
        private List<Pokemon> pokemons;
        private List<Parents> parents;
        private List<Children> children;

        public Person(string name)
        {
            this.name = name;
            this.car = null;
            this.Pokemons = new List<Pokemon>();
            this.Parents = new List<Parents>();
            this.Children = new List<Children>();
        }

        internal Person Where()
        {
            throw new NotImplementedException();
        }

        public List<Children> Children
        {
            get { return children; }
            set { children = value; }
        }

        public List<Parents> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        public Company Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
