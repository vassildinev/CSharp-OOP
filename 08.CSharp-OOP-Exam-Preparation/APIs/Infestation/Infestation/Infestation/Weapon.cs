namespace Infestation
{
    public class Weapon : ISupplement
    {
        private int powerEffect;
        private int healthEffect;
        private int aggressionEffect;

        public Weapon()
        {
            this.powerEffect = 0;
            this.healthEffect = 0;
            this.aggressionEffect = 0;
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
        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement as WeaponrySkill != null)
            {
                this.powerEffect = 10;
                this.aggressionEffect = 3;
            }
        }
    }
}
