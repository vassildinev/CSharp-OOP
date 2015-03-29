namespace JustBlueberry
{
    using JustBlueberry.Interfaces;

    using System;
    public class Proton : Baryon, IHadron, IRenderable
    {
        const char PROTON_SHAPE = '+';

        public Proton(Point position)
            : base(position)
        { }

        public override char GetShape()
        {
            return PROTON_SHAPE;
        }
    }
}
