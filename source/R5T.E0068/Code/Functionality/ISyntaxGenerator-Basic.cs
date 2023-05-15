using System;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.E0068.Basic
{
    /// <summary>
    /// Basic syntax generation.
    /// </summary>
    [FunctionalityMarker]
    public partial interface ISyntaxGenerator : IFunctionalityMarker
    {
        /// <summary>
        /// Creates a new empty block.
        /// </summary>
        public BlockSyntax Block_Empty()
        {
            var output = SyntaxFactory.Block();
            return output;
        }

        public IdentifierNameSyntax IdentifierNameSyntax(string name)
        {
            var output = SyntaxFactory.IdentifierName(name);
            return output;
        }

        public MethodDeclarationSyntax MethodDeclaration(
            string outputTypeName,
            string methodName)
        {
            var outputTypeNameSyntax = this.TypeNameSyntax(outputTypeName);

            var output = this.MethodDeclaration(
                outputTypeNameSyntax,
                methodName);

            return output;
        }

        public MethodDeclarationSyntax MethodDeclaration(
            TypeSyntax outputType,
            string methodName)
        {
            var output = SyntaxFactory.MethodDeclaration(
                outputType,
                methodName);

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="IdentifierNameSyntax(string)"/>.
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public IdentifierNameSyntax TypeNameSyntax(string typeName)
        {
            var output = this.IdentifierNameSyntax(typeName);
            return output;
        }
    }
}
