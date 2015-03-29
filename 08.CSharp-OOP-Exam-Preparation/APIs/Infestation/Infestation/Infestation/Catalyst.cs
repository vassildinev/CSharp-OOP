namespace Infestation
{
    public abstract class Catalyst : ISupplement
    {
        protected int powerEffect;
        protected int healthEffect;
        protected int aggressionEffect;

        protected Catalyst(int powerEffect, int healthEffect, int aggressionEffect)
        {
            this.powerEffect = powerEffect;
            this.healthEffect = healthEffect;
            this.aggressionEffect = aggressionEffect;
        }

        public int PowerEffect
        {
            get { return this.powerEffect; }
        }

        public int HealthEffect
        {
            get { return this.healthEffect; }
        }

        public int AggressionEffect
        {
            get { return this.aggressionEffect; }
        }

        public abstract void ReactTo(ISupplement otherSupplement);
    }
}
