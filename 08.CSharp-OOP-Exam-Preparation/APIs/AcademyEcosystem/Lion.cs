namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore, IOrganism
    {
        public Lion(string name, Point location)
            : base(name, location, 6)
        {

        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Size <= 2 * this.Size)
                {
                    ++this.Size;
                    return animal.GetMeatFromKillQuantity();
                }
            }
            return 0;
        }
    }
}
