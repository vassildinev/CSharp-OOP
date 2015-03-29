namespace AcademyEcosystem
{
    public class Zombie : Animal, IOrganism
    {
        private const int ZOMBIE_MEAT_QUANTITY = 10;

        public Zombie(string name, Point location)
            :base(name, location, 0)
        {

        }

        public override int GetMeatFromKillQuantity()
        {
            return ZOMBIE_MEAT_QUANTITY;
        }
    }
}
