namespace JustBlueberry
{
    using JustBlueberry.Interfaces;
    public class WhiteElectron : Electron, IRenderable, IMovable
    {
        const char WHITE_PARTICLE_SHAPE = '¤';

        private int startR;
        private int startC;

        public WhiteElectron(Point position)
            : base(position, new Vector(0, 1))
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
            return WHITE_PARTICLE_SHAPE;
        }

        public override void Move()
        {
            base.Move();
            this.ApplyMovementPattern();
        }

        public override void ApplyMovementPattern()
        {
            if (this.Speed.DeltaR == 0 && this.Speed.DeltaC != 0
                && this.Position.Col > this.StartC + 4 && this.Position.Row == this.StartR)
            {
                this.Speed = new Vector(2, -1);
            }
            else if (this.Speed.DeltaR != 0 && this.Speed.DeltaC != 0
                && this.Position.Row != this.StartR && this.Position.Col == this.StartC)
            {
                this.Speed = new Vector(0, 1);
            }
            else if (this.Speed.DeltaR == 0 && this.Speed.DeltaC != 0
                && this.Position.Col > this.StartC + 4 && this.Position.Row != this.StartR)
            {
                this.Speed = new Vector(-2, -1);
            }
            else if (this.Speed.DeltaR != 0 && this.Speed.DeltaC != 0
                && this.Position.Row == this.StartR && this.Position.Col == this.StartC)
            {
                this.Speed = new Vector(0, 1);
            }
        }
    }
}
