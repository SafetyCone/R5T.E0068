using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface IBaseMethodDeclarationSyntaxOperator : IFunctionalityMarker
    {
        public bool Has_Body(BaseMethodDeclarationSyntax baseMethodDeclarationSyntax)
        {
            var output = baseMethodDeclarationSyntax.Body is not null;
            return output;
        }
    }
}
