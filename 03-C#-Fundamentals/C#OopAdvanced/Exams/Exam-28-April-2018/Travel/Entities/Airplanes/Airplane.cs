namespace Travel.Entities.Airplanes
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Linq;
	using Entities.Contracts;
    using Travel.Entities.Airplanes.Contracts;

    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;

        public Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;

            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
        }

        public int BaggageCompartments { get; private set; }

        public int Seats { get; private set; }

        public bool IsOverbooked => this.passengers.Count > this.Seats;

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public void AddPassenger(IPassenger passenger) => this.passengers.Add(passenger);

        public IPassenger RemovePassenger(int seat)
        {
            var passenger = this.passengers[seat];

            this.passengers.RemoveAt(seat);

            return passenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var passengerBags = baggageCompartment.Where(b => b.Owner == passenger).ToArray();
            this.baggageCompartment.RemoveAll(x => x.Owner.Username == passenger.Username);

            return passengerBags;
        }

        public void LoadBag(IBag bag)
        {
            if (this.baggageCompartment.Count > BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {GetType().Name}");
            }

            baggageCompartment.Add(bag);
        }
    }
}