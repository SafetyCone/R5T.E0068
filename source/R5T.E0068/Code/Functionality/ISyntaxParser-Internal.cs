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
        [Obsolete("See R5T.L0073.F001.Internal.ISyntaxParser.Parse()")]
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

        [Obsolete("See R5T.L0073.F001.Internal.ISyntaxParser.Parse()")]
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

        /// <summary>
        /// Parses the text of any kind of a class declaration.
        /// </summary>
        [Obsolete("See R5T.L0073.F001.Raw.Parse_Class()")]
        public ClassDeclarationSyntax Parse_Class(string text)
        {
            var output = this.Parse_MemberDeclaration(text) as ClassDeclarationSyntax;
            return output;
        }

        /// <summary>
        /// Parse text as if it was a compilation unit (a whole code file).
        /// </summary>
        [Obsolete("See R5T.L0073.F001.Raw.Parse_Compilation()")]
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

        /// <summary>
        /// Parses the text of any kind of member declaration (class, interface, method, namespace).
        /// </summary>
        [Obsolete("See R5T.L0073.F001.Raw.ISyntaxParser.Parse_MemberDeclaration()")]
        public MemberDeclarationSyntax Parse_MemberDeclaration(string text)
        {
            var output = SyntaxFactory.ParseMemberDeclaration(text);
            return output;
        }

        /// <summary>
        /// Parses the text of any kind of a method declaration.
        /// </summary>
        [Obsolete("See R5T.L0073.F001.Raw.ISyntaxParser.Parse_MethodDeclaration()")]
        public MethodDeclarationSyntax Parse_MethodDeclaration(string text)
        {
            var output = SyntaxFactory.ParseMemberDeclaration(text) as MethodDeclarationSyntax;
            return output;
        }
    }
}
