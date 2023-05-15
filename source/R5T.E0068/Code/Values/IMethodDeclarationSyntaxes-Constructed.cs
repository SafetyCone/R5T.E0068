using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.E0068.Constructed
{
    [ValuesMarker]
    public partial interface IMethodDeclarationSyntaxes : IValuesMarker
    {
        public MethodDeclarationSyntax Main_Synchronous => Instances.SyntaxNodeOperator.New(
            Instances.MethodSignatures.Main_Synchronous.Value,
            Instances.MethodDeclarationOperations.Ensure_HasBody,
            Instances.MethodDeclarationOperations.Ensure_BodyHasOpenAndCloseBracesOnNewLines);
    }
}
