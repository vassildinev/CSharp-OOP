namespace JustBlueberry.Interfaces
{
    using System.Collections.Generic;

    public interface IMatter
    {
        IEnumerable<IHadron> Particles { get; } // A foreachable collection of particles
    }
}
