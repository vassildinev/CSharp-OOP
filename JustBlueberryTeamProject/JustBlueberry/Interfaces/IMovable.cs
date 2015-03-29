namespace JustBlueberry.Interfaces
{
    using System.Collections.Generic;
    public interface IMovable
    {
        Vector Speed { get; set; }

        void Move();
    }
}
