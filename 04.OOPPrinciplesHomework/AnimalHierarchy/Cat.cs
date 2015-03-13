namespace AnimalHierarchy
{
    public abstract class Cat : Animal, ISound
    {
        public abstract string Breed { get; protected set; }
    }
}
