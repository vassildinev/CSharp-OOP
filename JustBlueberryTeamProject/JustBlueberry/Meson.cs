namespace JustBlueberry
{
    public abstract class Meson : Hadron, IHadron
    {
        protected Meson(Point position)
            :base(position)
        { }
    }
}
