using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface IMethodDeclarationOperations : IValuesMarker
    {
        public MethodDeclarationSyntax Ensure_HasBody(MethodDeclarationSyntax methodDeclaration)
        {
            var hasBody = Instances.MethodDeclarationOperator.Has_Body(methodDeclaration);

            var output = hasBody
                ? methodDeclaration
                : methodDeclaration.WithBody(
                    SyntaxFactory.Block())
                ;

            return output;
        }
    }
}
