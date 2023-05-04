using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.E0068
{
    public class SimpleDescriptionNodeTypeDispatcher : NodeTypeDispatcher<string>
    {
        private string AppendType(string text, SyntaxNode node)
        {
            var output = $"{text} ({node.GetType().Name})";
            return output;
        }

        protected override string If_Node(SyntaxNode node)
        {
            var output = this.AppendType("<node>", node);
            return output;
        }

        protected override string If_BaseTypeDeclaration(BaseTypeDeclarationSyntax baseTypeDeclaration)
        {
            var output = this.AppendType($"{baseTypeDeclaration.Identifier}, base-type", baseTypeDeclaration);
            return output;
        }

        protected override string If_ClassDeclaration(ClassDeclarationSyntax classDeclaration)
        {
            var output = this.AppendType($"{classDeclaration.Identifier}, class", classDeclaration);
            return output;
        }

        protected override string If_ConstructorDeclaration(ConstructorDeclarationSyntax constructorDeclaration)
        {
            var output = this.AppendType($"{constructorDeclaration.Identifier}, constructor", constructorDeclaration);
            return output;
        }

        protected override string If_IdentifierName(IdentifierNameSyntax identifierName)
        {
            var output = this.AppendType($"{identifierName.Identifier}", identifierName);
            return output;
        }

        protected override string If_MethodDeclaration(MethodDeclarationSyntax methodDeclaration)
        {
            var output = this.AppendType($"{methodDeclaration.Identifier}, method", methodDeclaration);
            return output;
        }
    }
}
