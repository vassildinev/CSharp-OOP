namespace JustBlueberry
{
    using System;
    using JustBlueberry.Interfaces;

    public abstract class Hadron : IHadron
    {
        protected Hadron(Point position)
        {
            this.Position = position;
        }

        public Point Position { get; protected set; }

        public Point GetPosition()
        {
            return this.Position;
        }
    }
}
