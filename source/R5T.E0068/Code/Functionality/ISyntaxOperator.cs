using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.F0000;
using R5T.T0132;
using R5T.T0172;
using R5T.T0193.Extensions;

using R5T.E0068.Extensions;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Recurses through all descendant nodes to determine which (if any) contain trailing trivia.
        /// Optionally, include the last node (the node whose last token's next token is none) if it has trailing trivia.
        /// </summary>
        /// <remarks>
        /// This method is useful for checking that the all trailing trivia was moved to be leading trivia on the next node.
        /// </remarks>
        public WasFound<SyntaxNode[]> Has_NodesWithTrailingTrivia(
            SyntaxNode node,
            bool includeLastIfHasTrailingTrivia = false)
        {
            var nodes = Instances.SyntaxNodeOperator.Get_DescendantNodes(node);

            var nodesWithTrailingTriviaOrEmpty = nodes
                .Where(node => node.HasTrailingTrivia)
                .Where(node =>
                {
                    var lastTokensNextTokenIsNone = node
                        .GetLastToken(
                            includeZeroWidth: true,
                            // Do not include skipped.
                            includeDirectives: true,
                            includeDocumentationComments: true)
                        .GetNextToken()
                        .Is_None();

                    var includeNode = !lastTokensNextTokenIsNone || includeLastIfHasTrailingTrivia;
                    return includeNode;
                })
                .Now();

            var output = WasFound.FromArray(nodesWithTrailingTriviaOrEmpty);
            return output;
        }

        /// <summary>
        /// Recurses through all descendant tokens to determine which (if any) contain trailing trivia.
        /// Optionally, include the last token (the token whose next token is none) if it has trailing trivia.
        /// </summary>
        /// <remarks>
        /// This method is useful for checking that the all trailing trivia was moved to be leading trivia on the next token.
        /// </remarks>
        public WasFound<SyntaxToken[]> Has_TokensWithTrailingTrivia(
            SyntaxNode node,
            bool includeLastIfHasTrailingTrivia = false)
        {
            var tokens = Instances.SyntaxNodeOperator.Get_DescendantTokens(node);

            var tokensWithTrailingTriviaOrEmpty = tokens
                .Where(token => token.HasTrailingTrivia)
                .Where(token =>
                {
                    var nextTokenIsNone = token.GetNextToken().Is_None();

                    var includeToken = !nextTokenIsNone || includeLastIfHasTrailingTrivia;
                    return includeToken;
                })
                .Now();

            var output = WasFound.FromArray(tokensWithTrailingTriviaOrEmpty);
            return output;
        }

        public CompilationUnitSyntax Load_Synchronous(ICodeFilePath codeFilePath)
        {
            var code = Instances.FileOperator.ReadText_Synchronous(codeFilePath.Value);

            var compilationUnit = Instances.SyntaxParser.Parse_CompilationUnitSyntax(code);
            return compilationUnit;
        }

        public DocumentationCommentTriviaSyntax Parse_DocumentationComment(
            IXmlDocumentationComment xmlDocumentationComment)
        {
            var syntaxTrivia = SyntaxFactory.ParseLeadingTrivia(xmlDocumentationComment.Value).First();

            var structuredTrivia = syntaxTrivia.GetStructure();

            var output = structuredTrivia as DocumentationCommentTriviaSyntax;
            return output;
        }
    }
}
