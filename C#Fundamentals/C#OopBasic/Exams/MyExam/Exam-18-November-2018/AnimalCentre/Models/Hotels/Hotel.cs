using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Hotels
{
    public class Hotel : IHotel
    {
        private const int Capacity = 10;

        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get { return animals; }
        }

        public void Accommodate(IAnimal animal)
        {
            if (animals.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (animals.ContainsKey(animalName) == false)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            var animal = animals[animalName];
            animal.Owner = owner;
            animal.IsAdopt = true;
            animals.Remove(animalName);
        }
    }
}
