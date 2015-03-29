namespace JustBlueberry
{
    using JustBlueberry.Interfaces;

    public abstract class Baryon : Hadron, IHadron, IRenderable
    {
        protected Baryon(Point position)
            :base(position)
        {}

        public abstract char GetShape();
    }
}
