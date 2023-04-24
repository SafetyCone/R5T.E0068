using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.E0068
{
    /// <summary>
    /// Represents computer code.
    /// </summary>
    [StrongTypeMarker]
    public interface ICode : IStrongTypeMarker,
        ITyped<string>
    {
    }
}
