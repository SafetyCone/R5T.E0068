using System;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface IMethodDeclarationOperations : IValuesMarker
    {
        public Func<MethodDeclarationSyntax, MethodDeclarationSyntax> Ensure_HasBody_Test =>
            syntax => Instances.BaseMethodDeclarationOperations.Ensure_HasBody(syntax);

        public MethodDeclarationSyntax Ensure_HasBody(MethodDeclarationSyntax syntax)
        {
            return Instances.BaseMethodDeclarationOperations.Ensure_HasBody(syntax);
        }

        public MethodDeclarationSyntax Ensure_BodyHasOpenAndCloseBracesOnNewLines(MethodDeclarationSyntax syntax)
        {
            var bodyWrapper = new BlockSyntaxWrapper(syntax.Body);

            Instances.HasOpenAndCloseBracesOperator.Ensure_OpenAndCloseBracesOnNewLines(bodyWrapper);

            return syntax.WithBody(bodyWrapper.BlockSyntax);
        }
    }
}
