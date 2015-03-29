namespace JustBlueberry
{
    using JustBlueberry.Interfaces;

    public class BlueElectron : Electron, IRenderable, IMovable
    {
        const int BLUE_ELECTRON_SIZE_OF_MOVEMENT_PATTERN = 4;

        private int startR;
        private int startC;

        public BlueElectron(Point position)
            : base(position, new Vector(1,0))
        {
            this.StartR = this.Position.Row;
            this.StartC = this.Position.Col;
        }

        public int StartR
        {
            get { return this.startR; }
            private set
            {
                if(value < 0)
                {
                    throw new InvalidBlueberryException("Can't set start Point to less than 0");
                }
                this.startR = value;
            }
        }

        public int StartC
        {
            get { return this.startC; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidBlueberryException("Can't set start Point to less than 0");
                }
                this.startC = value;
            }
        }

        public override void Move()
        {
            base.Move();
            this.ApplyMovementPattern();
        }

        public override void ApplyMovementPattern()
        {
            if (this.Speed.DeltaR != 0 && this.Speed.DeltaC == 0
                    && this.Position.Row - this.startR > BLUE_ELECTRON_SIZE_OF_MOVEMENT_PATTERN)
            {
                this.Speed = new Vector(0,1);
            }
            else if (this.Speed.DeltaR == 0 && this.Speed.DeltaC != 0
                && this.Position.Col - this.startC > BLUE_ELECTRON_SIZE_OF_MOVEMENT_PATTERN + 2)
            {
                this.Speed = new Vector(-1, 0);
            }
            else if (this.Speed.DeltaR != 0 && this.Speed.DeltaC == 0
                && this.Position.Row - this.startR < -BLUE_ELECTRON_SIZE_OF_MOVEMENT_PATTERN)
            {
                this.Speed = new Vector(0, -1);
            }
            else if (this.Speed.DeltaR == 0 && this.Speed.DeltaC != 0
                && this.Position.Col - this.startC < -BLUE_ELECTRON_SIZE_OF_MOVEMENT_PATTERN - 2)
            {
                this.Speed = new Vector(1, 0);
            }
        }
    }
}
