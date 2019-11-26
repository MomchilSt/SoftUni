namespace _03BarracksFactory.Models.Units
{
    public class Archer : Unit
    {
        private const int DefaultHealth = 50;
        private const int DefaultDamage = 10;

        public Archer() 
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}
