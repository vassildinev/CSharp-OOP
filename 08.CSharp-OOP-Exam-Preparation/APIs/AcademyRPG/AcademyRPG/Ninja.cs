using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IControllable, IFighter, IGatherer
    {
        private int attackPoints;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.AttackPoints = 0;
            this.HitPoints = 1;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            private set { this.attackPoints = value; }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var sortedAvailableTargets = availableTargets.OrderByDescending(t => t.HitPoints).ToList();
            for (int i = 0; i < sortedAvailableTargets.Count; i++)
            {
                if (sortedAvailableTargets[i].Owner != this.Owner && sortedAvailableTargets[i].Owner != 0)
                {
                    return availableTargets.IndexOf(sortedAvailableTargets[i]);
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber
             || resource.Type == ResourceType.Stone)
            {
                if (resource.Type == ResourceType.Lumber)
                {
                    this.AttackPoints += resource.Quantity;
                }
                else
                {
                    this.AttackPoints += 2 * resource.Quantity;
                }
                return true;
            }

            return false;
        }
    }
}
