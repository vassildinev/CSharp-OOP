namespace Infestation
{
    public class WeaponrySkill : ISupplement
    {
        public WeaponrySkill()
        {

        }

        public int PowerEffect
        {
            get { return 0; }
        }

        public int HealthEffect
        {
            get { return 0; }
        }

        public int AggressionEffect
        {
            get { return 0; }
        }
        public void ReactTo(ISupplement otherSupplement)
        {
           
        }
    }
}
