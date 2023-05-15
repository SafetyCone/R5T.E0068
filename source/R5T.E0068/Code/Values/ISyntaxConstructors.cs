using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface ISyntaxConstructors : IValuesMarker
    {
        public Func<MethodDeclarationSyntax> MethodDeclaration(
            string outputTypeName,
            string methodName)
        {
            return () => Instances.SyntaxGenerator_Basic.MethodDeclaration(
                outputTypeName,
                methodName);
        }

        public Func<MethodDeclarationSyntax> MethodDeclaration(
            TypeSyntax outputType,
            string methodName)
        {
            return () => Instances.SyntaxGenerator_Basic.MethodDeclaration(
                outputType,
                methodName);
        }
    }
}
