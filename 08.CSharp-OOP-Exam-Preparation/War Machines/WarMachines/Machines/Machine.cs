namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;
    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        protected double healthPoints;
        protected double attackPoints;
        protected double defensePoints;
        private IList<string> targets;

        protected Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.attackPoints = attackPoints;
            this.defensePoints = defensePoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set { this.pilot = value; }
        }

        public double HealthPoints
        {
            get { return this.healthPoints; }
            set { this.healthPoints = value; }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
        }

        public abstract void Attack(string target);

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("- {0}", this.Name));
            result.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            result.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            result.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            result.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            if (this.Targets.Count==0)
            {
                result.AppendLine(" *Targets: None");
            }
            else
            {
                result.AppendLine(string.Format(" *Targets: {0}", string.Join(", ", this.Targets)));
            }
            return result.ToString().Trim();
        }
    }
}
