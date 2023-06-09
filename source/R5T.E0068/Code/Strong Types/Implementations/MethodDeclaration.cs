using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.E0068
{
    /// <inheritdoc cref="IMethodDeclaration"/>
    [StrongTypeImplementationMarker]
    public class MethodDeclaration : TypedBase<string>, IStrongTypeMarker,
        IMethodDeclaration
    {
        public MethodDeclaration(string value)
            : base(value)
        {
        }
    }
}
