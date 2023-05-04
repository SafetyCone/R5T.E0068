using System;

using R5T.T0178;


namespace R5T.E0068
{
    /// <summary>
    /// Strongly-types a string as the code of a method declaration.
    /// </summary>
    [StrongTypeMarker]
    public interface IMethodDeclaration : IStrongTypeMarker,
        IMemberDeclaration
    {
    }
}
