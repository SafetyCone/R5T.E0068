using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0178;


namespace R5T.E0068
{
    /// <inheritdoc cref="IMethodSignature"/>
    [StrongTypeImplementationMarker]
    public class MethodSignature : T0179.N001.TypedBase<MethodDeclarationSyntax>, IStrongTypeMarker,
        IMethodSignature
    {
        public MethodSignature(MethodDeclarationSyntax value)
            : base(value)
        {
        }

        protected override int Value_CompareTo(MethodDeclarationSyntax a, MethodDeclarationSyntax b)
        {
            throw new NotImplementedException();
        }

        protected override bool Value_Equals(MethodDeclarationSyntax a, MethodDeclarationSyntax b)
        {
            throw new NotImplementedException();
        }
    }
}
