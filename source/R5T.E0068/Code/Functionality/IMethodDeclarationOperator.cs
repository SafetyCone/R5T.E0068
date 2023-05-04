using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface IMethodDeclarationOperator : IFunctionalityMarker
    {
        public bool Has_Body(MethodDeclarationSyntax methodDeclaration)
        {
            var output = methodDeclaration.Body is not null;
            return output;
        }
    }
}
