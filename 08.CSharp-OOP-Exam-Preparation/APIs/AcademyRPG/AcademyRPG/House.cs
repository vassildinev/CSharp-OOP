using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class House : StaticObject, IWorldObject
    {
        public House(Point position, int owner)
            : base(position, owner)
        {
            this.HitPoints = 500;
        }
    }
}
