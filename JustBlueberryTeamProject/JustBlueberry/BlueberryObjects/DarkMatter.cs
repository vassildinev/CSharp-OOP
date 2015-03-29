namespace JustBlueberry
{
    using JustBlueberry.Interfaces;
    using JustBlueberry.Extensions;
    using System.Linq;
    using System.Collections.Generic;

    public class DarkMatter : IMatter
    {
        protected IEnumerable<IHadron> particles;

        public DarkMatter(IEnumerable<IHadron> particles)
        {
            this.Particles = particles;
        }

        public IEnumerable<IHadron> Particles
        {
            get { return this.particles; }
            protected set { this.particles = value; }
        }
    }
}
