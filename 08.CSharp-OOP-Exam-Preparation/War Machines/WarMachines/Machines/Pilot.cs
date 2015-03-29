namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;
    public class Pilot : IPilot
    {
        private const string NO_MACHINES = "no machines";

        private string name;
        private IList<IMachine> machines;
        public Pilot(string name)
        {
            this.name = name;
            this.machines = new List<IMachine>();
        }
        public string Name { get { return this.name; } }

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            if (this.machines.Count == 0)
            {
                return string.Format("{0} - {1}", this.Name, NO_MACHINES);
            }
            else
            {
                report.AppendLine(string.Format("{0} - {1} machines", this.Name, this.machines.Count));
                foreach (var machine in this.machines)
                {
                    report.AppendLine(machine.ToString());
                }
                return report.ToString().Trim();
            }
        }
    }
}
