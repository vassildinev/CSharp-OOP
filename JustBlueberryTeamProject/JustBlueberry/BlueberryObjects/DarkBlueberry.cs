namespace JustBlueberry
{
    using JustBlueberry.Interfaces;
    using JustBlueberry.Extensions;
    using System.Collections.Generic;
    public class DarkBlueberry : DarkMatter
    {
        public DarkBlueberry(IList<IHadron> particles)
            : base(particles)
        {
        }
    }
}
