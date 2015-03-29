using System;
namespace JustBlueberry
{
    using JustBlueberry.Interfaces;
    public class BlackElectron : Electron, IRenderable, IMovable
    {
        const char BLACK_PARTICLE_SHAPE = '$';

        private int startR;
        private int startC;

        public BlackElectron(Point position)
            : base(position, new Vector(1, 0))
        {
            this.StartR = position.Row;
            this.StartC = position.Col;
        }

        public int StartR
        {
            get { return this.startR; }
            private set { this.startR = value; }
        }

        public int StartC
        {
            get { return this.startC; }
            private set { this.startC = value; }
        }

        public override char GetShape()
        {
            return BLACK_PARTICLE_SHAPE;
        }

        public override void Move()
        {
            base.Move();
            this.ApplyMovementPattern();
        }

        public override void ApplyMovementPattern()
        {
            if (this.Speed.DeltaR != 0 && this.Speed.DeltaC == 0
                && this.Position.Row > this.StartR + 4 && this.Position.Col == this.StartC)
            {
                this.Speed = new Vector(-1, 4);
            }
            else if (this.Speed.DeltaR != 0 && this.Speed.DeltaC != 0
                && this.Position.Row == this.StartR && this.Position.Col != this.StartC)
            {
                this.Speed = new Vector(1, 0);
            }
            else if (this.Speed.DeltaR != 0 && this.Speed.DeltaC == 0
                && this.Position.Row > this.StartR + 4 && this.Position.Col != this.StartC)
            {
                this.Speed = new Vector(-1, -4);
            }
            else if (this.Speed.DeltaR != 0 && this.Speed.DeltaC != 0
                && this.Position.Row == this.StartR && this.Position.Col == this.StartC)
            {
                this.Speed = new Vector(1, 0);
            }
        }
    }
}
