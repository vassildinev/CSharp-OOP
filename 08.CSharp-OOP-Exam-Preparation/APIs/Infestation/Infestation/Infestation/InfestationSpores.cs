namespace Infestation
{
    public class InfestationSpores : ISupplement
    {
        private int powerEfect;
        private int healthEffect;
        private int aggressionEffect;

        public InfestationSpores()
        {
            this.powerEfect = -1;
            this.healthEffect = 0;
            this.aggressionEffect = 20;
        }

        public int PowerEffect
        {
            get { return this.powerEfect; }
        }

        public int HealthEffect
        {
            get { return this.healthEffect; }
        }

        public int AggressionEffect
        {
            get { return this.aggressionEffect; }
        }
        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.powerEfect = 0;
                this.healthEffect = 0;
                this.aggressionEffect = 0;
            }
        }
    }
}
