using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IControllable, IFighter, IGatherer
    {
        private bool hasGatheredOnce;
        private int attackPoints;

        public Giant(string name, Point position)
            : base(name, position, 0) // 0 means neutral
        {
            this.AttackPoints = 150;
            this.HitPoints = 200;
            this.HasGatheredOnce = false;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            private set { this.attackPoints = value; }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public bool HasGatheredOnce
        {
            get { return this.hasGatheredOnce; }
            set { this.hasGatheredOnce = value; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (!this.HasGatheredOnce)
                {
                    this.AttackPoints += 100;
                    this.HasGatheredOnce = true;
                }
                return true;
            }

            return false;
        }
    }
}
