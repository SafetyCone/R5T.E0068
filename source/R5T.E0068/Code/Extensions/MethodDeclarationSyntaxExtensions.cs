using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.E0068.Extensions
{
    public static partial class MethodDeclarationSyntaxExtensions
    {
        public static IMethodSignature ToMethodSignature(this MethodDeclarationSyntax value)
        {
            return Instances.SyntaxOperator_Extensions.ToMethodSignature(value);
        }
    }
}
