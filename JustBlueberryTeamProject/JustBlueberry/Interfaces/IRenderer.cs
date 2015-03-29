namespace JustBlueberry.Interfaces
{
    // Interface for rendering objects on an output source.
    public interface IRenderer
    {
        void Push(IRenderable objectToRender);
        void Print();
        void Release();
    }
}
