using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.E0068
{
    /// <inheritdoc cref="IClassDeclaration"/>
    [StrongTypeImplementationMarker]
    public class ClassDeclaration : TypedBase<string>, IStrongTypeMarker,
        IClassDeclaration
    {
        public ClassDeclaration(string value)
            : base(value)
        {
        }
    }
}
