namespace JustBlueberry
{
    using JustBlueberry.Interfaces;

    public abstract class Meson : Hadron, IHadron
    {
        protected Meson(Point position)
            :base(position)
        { }
    }
}
