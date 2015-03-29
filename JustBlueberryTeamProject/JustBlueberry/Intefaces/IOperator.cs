namespace JustBlueberry
{
    using System.Collections.Generic;
    public interface IOperator
    {
        void OperateOn(IHadron particle);
        void EndFrame(); // indicate end of frame - currently no code
    }
}
