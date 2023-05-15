using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.E0068.Extensions
{
    public static class BaseMethodDeclarationSyntaxExtensions
    {
        public static bool Has_Body(this BaseMethodDeclarationSyntax baseMethodDeclarationSyntax)
        {
            return Instances.BaseMethodDeclarationSyntaxOperator.Has_Body(baseMethodDeclarationSyntax);
        }
    }
}
