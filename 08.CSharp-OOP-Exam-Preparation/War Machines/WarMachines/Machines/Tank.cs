namespace WarMachines.Machines
{
    using WarMachines.Interfaces;
    public class Tank : Machine, IMachine, ITank
    {
        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = 100;
            this.defenseMode = true;
            if (this.DefenseMode)
            {
                this.defensePoints += 30;
                this.attackPoints -= 40;
            }
        }
        public override void Attack(string target)
        {
        }

        public bool DefenseMode
        {
            get { return this.defenseMode; }
        }

        public void ToggleDefenseMode()
        {
            if (!this.defenseMode)
            {
                this.defensePoints += 30;
                this.attackPoints -= 40;
            }
            else
            {
                this.defensePoints -= 30;
                this.attackPoints += 40;
            }
            this.defenseMode = !this.defenseMode;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\n *Defense: {0}", this.DefenseMode? "ON":"OFF");
        }
    }
}
