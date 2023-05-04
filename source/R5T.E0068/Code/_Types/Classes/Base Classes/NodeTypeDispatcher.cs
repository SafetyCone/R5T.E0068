using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.E0068
{
    public abstract class NodeTypeDispatcher<TOutput>
    {
        public TOutput DispatchOnType(SyntaxNode node)
        {
            var output = node switch
            {
                IdentifierNameSyntax identifierName => this.If_IdentifierName(identifierName),
                ClassDeclarationSyntax classDeclaration => this.If_ClassDeclaration(classDeclaration),
                TypeDeclarationSyntax typeDeclaration => this.If_TypeDeclaration(typeDeclaration),
                BaseTypeDeclarationSyntax baseTypeDeclaration => this.If_BaseTypeDeclaration(baseTypeDeclaration),
                MethodDeclarationSyntax methodDeclaration => this.If_MethodDeclaration(methodDeclaration),
                ConstructorDeclarationSyntax constructorDeclaration => this.If_ConstructorDeclaration(constructorDeclaration),
                MemberDeclarationSyntax memberDeclaration => this.If_MemberDeclaration(memberDeclaration),
                _ => this.If_Node(node)
            };

            return output;
        }

        protected abstract TOutput If_Node(SyntaxNode node);

        protected virtual TOutput If_BaseTypeDeclaration(BaseTypeDeclarationSyntax baseTypeDeclaration)
        {
            return this.If_Node(baseTypeDeclaration);
        }

        protected virtual TOutput If_ClassDeclaration(ClassDeclarationSyntax classDeclaration)
        {
            return this.If_Node(classDeclaration);
        }

        protected virtual TOutput If_ConstructorDeclaration(ConstructorDeclarationSyntax constructorDeclaration)
        {
            return this.If_Node(constructorDeclaration);
        }

        protected virtual TOutput If_IdentifierName(IdentifierNameSyntax identifierName)
        {
            return this.If_Node(identifierName);
        }

        protected virtual TOutput If_MemberDeclaration(MemberDeclarationSyntax memberDeclaration)
        {
            return this.If_Node(memberDeclaration);
        }

        protected virtual TOutput If_MethodDeclaration(MethodDeclarationSyntax methodDeclaration)
        {
            return this.If_Node(methodDeclaration);
        }

        protected virtual TOutput If_TypeDeclaration(TypeDeclarationSyntax typeDeclaration)
        {
            return this.If_Node(typeDeclaration);
        }
    }
}
