using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxConstructor : IFunctionalityMarker
    {
        public MethodDeclarationSyntax MethodDeclaration(
            string outputTypeName,
            string methodName)
        {
            return Instances.SyntaxGenerator_Basic.MethodDeclaration(
                outputTypeName,
                methodName);
        }

        public MethodDeclarationSyntax MethodDeclaration(
            TypeSyntax outputType,
            string methodName)
        {
            return Instances.SyntaxGenerator_Basic.MethodDeclaration(
                outputType,
                methodName);
        }
    }
}
