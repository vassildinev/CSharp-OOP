namespace JustBlueberry
{
    using JustBlueberry.Interfaces;

    public class RedElectron : Electron, IRenderable
    {
        const char RED_ELECTRON_SHAPE = '*';
        const int RED_ELECTRON_SIZE_OF_MOVEMENT_PATTERN = 8;

        private int startX;
        private int startY;

        public RedElectron(Point position)
            : base(position, new Vector(-1, -1))
        {
            this.startX = this.Position.Row;
            this.startY = this.Position.Col;
        }

        public override char GetShape()
        {
            return RED_ELECTRON_SHAPE;
        }

        public override void Move()
        {
            base.Move();
            this.ApplyMovementPattern();
        }

        public override void ApplyMovementPattern()
        {
            if (this.Speed.DeltaR == -1 && this.Speed.DeltaC == -1
            && this.Position.Row - this.startX < -0.375 * RED_ELECTRON_SIZE_OF_MOVEMENT_PATTERN)
            {
                this.Speed.DeltaR = 1;
                this.Speed.DeltaC = -1;
            }
            else if (this.Speed.DeltaR == 1 && this.Speed.DeltaC == -1
                && this.Position.Col - this.startY < -RED_ELECTRON_SIZE_OF_MOVEMENT_PATTERN)
            {
                this.Speed.DeltaR = 0;
                this.Speed.DeltaC = 2;
            }
            else if (this.Speed.DeltaR == 0 && this.Speed.DeltaC == 2
                && this.Position.Col > this.startY)
            {
                this.Speed.DeltaR = -1;
                this.Speed.DeltaC = -1;
            }
        }
    }
}
