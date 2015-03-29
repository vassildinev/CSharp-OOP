using System;
namespace JustBlueberry.Interfaces
{
    // Interface for objects that have to implement rendering.
    public interface IRenderable
    {
        Point GetPosition();

        char GetShape();
    }
}
