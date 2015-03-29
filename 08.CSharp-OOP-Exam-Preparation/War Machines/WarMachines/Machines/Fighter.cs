namespace WarMachines.Machines
{
    using WarMachines.Interfaces;
    public class Fighter : Machine, IMachine, IFighter
    {
        private bool stealthMode;
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            :base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = 200;
            this.stealthMode = stealthMode;
        }
        public override void Attack(string target)
        {
        }

        public bool StealthMode
        {
            get { return this.stealthMode; }
        }

        public void ToggleStealthMode()
        {
            this.stealthMode = !this.stealthMode;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\n *Stealth: {0}", this.StealthMode ? "ON" : "OFF");
        }
    }
}
