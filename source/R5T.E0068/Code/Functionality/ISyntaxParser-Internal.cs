using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.E0068.Internal
{
    [FunctionalityMarker]
    public partial interface ISyntaxParser : IFunctionalityMarker
    {
        public TSyntax Parse<TSyntax>(
            string text,
            Func<string, TSyntax> parser,
            IEnumerable<Func<TSyntax, TSyntax>> postParseOperations)
        {
            var syntax = parser(text);

            foreach (var operation in postParseOperations)
            {
                syntax = operation(syntax);
            }

            return syntax;
        }

        public TSyntax Parse<TSyntax>(
            string text,
            Func<string, TSyntax> parser,
            params Func<TSyntax, TSyntax>[] postParseOperations)
        {
            return this.Parse(
                text,
                parser,
                postParseOperations.AsEnumerable());
        }

        public ClassDeclarationSyntax Parse_Class(string text)
        {
            var output = this.Parse_MemberDeclaration(text) as ClassDeclarationSyntax;
            return output;
        }

        public CompilationUnitSyntax Parse_CompilationUnit(string text)
        {
            var output = SyntaxFactory.ParseCompilationUnit(text);
            return output;
        }

        public DocumentationCommentTriviaSyntax Parse_DocumentationComment(string text)
        {
            var syntaxTrivia = SyntaxFactory.ParseLeadingTrivia(text)
                // Ensure only one trivia was present in the input text.
                .Single();

            var structuredTrivia = syntaxTrivia.GetStructure();

            var output = structuredTrivia as DocumentationCommentTriviaSyntax;
            return output;
        }

        public MemberDeclarationSyntax Parse_MemberDeclaration(string text)
        {
            var output = SyntaxFactory.ParseMemberDeclaration(text);
            return output;
        }

        public MethodDeclarationSyntax Parse_MethodDeclaration(string text)
        {
            var output = SyntaxFactory.ParseMemberDeclaration(text) as MethodDeclarationSyntax;
            return output;
        }
    }
}
