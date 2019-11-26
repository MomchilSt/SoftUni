using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private List<Procedure> procedures;
        public Dictionary<string, List<IAnimal>> adopted;

        Hotel hotel = new Hotel();

        Chip chip = new Chip();
        DentalCare dentalCare = new DentalCare();
        Fitness fitness = new Fitness();
        NailTrim nailTrim = new NailTrim();
        Play play = new Play();
        Vaccinate vaccinate = new Vaccinate();
       
        public AnimalCentre()
        {
            this.procedures = new List<Procedure>();
            this.adopted = new Dictionary<string, List<IAnimal>>();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            if (type == "Cat")
            {
                var cat = new Cat(name, energy, happiness, procedureTime);
                this.hotel.Accommodate(cat);

                return $"Animal {name} registered successfully";
            }
            else if (type == "Dog")
            {
                var dog = new Dog(name, energy, happiness, procedureTime);
                this.hotel.Accommodate(dog);

                return $"Animal {name} registered successfully";
            }
            else if (type == "Lion")
            {
                var lion = new Lion(name, energy, happiness, procedureTime);
                this.hotel.Accommodate(lion);

                return $"Animal {name} registered successfully";
            }
            else if (type == "Pig")
            {
                var pig = new Pig(name, energy, happiness, procedureTime);
                this.hotel.Accommodate(pig);

                return $"Animal {name} registered successfully";
            }
            return null;
        }

        public string Chip(string name, int procedureTime)
        {
            if (hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            var animal = hotel.Animals[name];
            chip.DoService(animal, procedureTime);
            chip.ProcedureHistory.Add(animal);
            this.procedures.Add(chip);

            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            if (hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            var animal = hotel.Animals[name];
            vaccinate.DoService(animal, procedureTime);
            vaccinate.ProcedureHistory.Add(animal);
            this.procedures.Add(vaccinate);

            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            if (hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            var animal = hotel.Animals[name];
            fitness.DoService(animal, procedureTime);
            fitness.ProcedureHistory.Add(animal);
            this.procedures.Add(fitness);

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            if (hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            var animal = hotel.Animals[name];
            play.DoService(animal, procedureTime);
            play.ProcedureHistory.Add(animal);
            this.procedures.Add(play);

            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            if (hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            var animal = hotel.Animals[name];
            dentalCare.DoService(animal, procedureTime);
            dentalCare.ProcedureHistory.Add(animal);
            this.procedures.Add(dentalCare);

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            if (hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            var animal = hotel.Animals[name];
            nailTrim.DoService(animal, procedureTime);
            nailTrim.ProcedureHistory.Add(animal);
            this.procedures.Add(nailTrim);

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            if (hotel.Animals.ContainsKey(animalName) == false)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            if (adopted.ContainsKey(owner) == false)
            {
                adopted.Add(owner, new List<IAnimal>());
            }

            var animal = hotel.Animals[animalName];
            adopted[owner].Add(animal);
            hotel.Adopt(animalName, owner);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }

                return $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            //if (type == "Chip")
            //{
            //    return chip.History();
            //}
            //else if (type == "DentalCare")
            //{
            //    return dentalCare.ToString();
            //}
            //else if (type == "Fitness")
            //{
            //    return fitness.ToString();
            //}
            //else if (type == "NailTrim")
            //{
            //    return nailTrim.ToString();
            //}
            //else if (type == "Play")
            //{
            //    return play.ToString();
            //}
            //else if (type == "Vaccinate")
            //{
            //    return vaccinate.ToString();
            //}
            //return null;
            
            return this.procedures.First(x => x.GetType().Name == type).History();
        }

    }
}
