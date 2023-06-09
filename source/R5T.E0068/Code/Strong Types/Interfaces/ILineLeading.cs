using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0178;
using R5T.T0179;


namespace R5T.E0068
{
    /// <summary>
    /// Strongly-types a method declaration syntax as being just the signature of the declaration.
    /// Note: line-leading always starts with a new-line trivia, and is followed by indentation (see <see cref="IIndentation"/>).
    /// </summary>
    [StrongTypeMarker]
    public interface IMethodSignature : IStrongTypeMarker,
        ITyped<MethodDeclarationSyntax>
    {
    }
}
