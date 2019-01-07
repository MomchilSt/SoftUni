using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Pokemon
    {
        private string name;
        private string pokemonType;

        public Pokemon(string name, string pokemonType)
        {
            this.Name = name;
            this.PokemonType = pokemonType;
        }

        public string PokemonType
        {
            get { return pokemonType; }
            set { pokemonType = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return this.Name + " " + this.PokemonType;
        }
    }
}
