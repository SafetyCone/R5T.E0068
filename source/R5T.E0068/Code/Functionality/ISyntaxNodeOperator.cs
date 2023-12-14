using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.N0000;

using R5T.T0132;

using R5T.E0068.Extensions;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxNodeOperator : IFunctionalityMarker
    {
        public TNode AnnotateTokens<TNode>(
            TNode node,
            IEnumerable<SyntaxToken> tokens,
            out Dictionary<SyntaxToken, SyntaxAnnotation> annotationsByInputTokens)
            where TNode : SyntaxNode
        {
            // Temporary variable is required for use in anonymous method below.
            var tempAnotationsByInputTokens = new Dictionary<SyntaxToken, SyntaxAnnotation>();

            var outputSyntaxNode = node.Replace_Tokens(
                tokens,
                (originalToken, possiblyRewrittenToken) =>
                {
                    var outputToken = possiblyRewrittenToken.Annotate(out var annotation);

                    tempAnotationsByInputTokens.Add(originalToken, annotation);

                    return outputToken;
                });

            annotationsByInputTokens = tempAnotationsByInputTokens;

            return outputSyntaxNode;
        }

        public TNode AnnotateTrivias<TNode>(
            TNode node,
            IEnumerable<SyntaxTrivia> trivias,
            out Dictionary<SyntaxTrivia, SyntaxAnnotation> annotationsByInputTrivias)
            where TNode : SyntaxNode
        {
            // Temporary variable is required for use in anonymous method below.
            var tempAnotationsByInputTrivias = new Dictionary<SyntaxTrivia, SyntaxAnnotation>();

            var outputSyntaxNode = node.Replace_Trivias(
                trivias,
                (originalTrivia, possiblyRewrittenTrivia) =>
                {
                    var outputToken = possiblyRewrittenTrivia.Annotate(out var annotation);

                    tempAnotationsByInputTrivias.Add(originalTrivia, annotation);

                    return outputToken;
                });

            annotationsByInputTrivias = tempAnotationsByInputTrivias;

            return outputSyntaxNode;
        }

        public StructuredTriviaSyntax Get_AncestorStructuredTriviaSyntax(SyntaxNode node)
        {
            this.Verify_IsPartOfStructuredTrivia(node);

            // Base case: return this node if it is structured trivia.
            if(node is StructuredTriviaSyntax structuredTrivia)
            {
                return structuredTrivia;
            }

            // Else, recurse on parent.
            var parentNode = this.Verify_HasParent(node);

            var output = this.Get_AncestorStructuredTriviaSyntax(parentNode);
            return output;
        }

        public SyntaxTrivia Get_AncestorStructuredTrivia(SyntaxNode node)
        {
            var syntax = this.Get_AncestorStructuredTriviaSyntax(node);

            var parentTrivia = Instances.StructuredTriviaSyntaxOperator.Verify_HasParentTrivia(syntax);
            return parentTrivia;
        }

        public SyntaxToken Get_AnnotatedDescendantToken(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            var hasAnnotatedToken = this.Has_AnnotatedToken(
                node,
                annotation);

            var output = Instances.WasFoundOperator.ResultOrExceptionIfNotFound(
                hasAnnotatedToken,
                "No token with annotation found.");

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_AnnotatedDescendantToken(SyntaxNode, SyntaxAnnotation)"/> as the default.
        /// </summary>
        public SyntaxToken Get_AnnotatedToken(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            return this.Get_AnnotatedDescendantToken(node, annotation);
        }

        public SyntaxTrivia Get_AnnotatedDescendantTrivia(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            var hasAnnotatedToken = this.Has_AnnotatedTrivia(
                node,
                annotation);

            var output = Instances.WasFoundOperator.ResultOrExceptionIfNotFound(
                hasAnnotatedToken,
                "No trivia with annotation found.");

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_AnnotatedDescendantTrivia(SyntaxNode, SyntaxAnnotation)"/> as the default.
        /// </summary>
        public SyntaxTrivia Get_AnnotatedTrivia(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            return this.Get_AnnotatedDescendantTrivia(node, annotation);
        }

        /// <summary>
        /// Gets all descendant nodes in the node.
        /// </summary>
        /// <remarks>
        /// Includes nodes in trivia.
        /// </remarks>
        public IEnumerable<SyntaxNode> Get_DescendantNodes(SyntaxNode node)
        {
            var nodes = node.DescendantNodes(descendIntoTrivia: true);
            return nodes;
        }

        /// <summary>
        /// Gets all descendant tokens in the node.
        /// </summary>
        /// <remarks>
        /// Includes tokens inside of structured trivias.
        /// </remarks>
        public IEnumerable<SyntaxToken> Get_DescendantTokens(SyntaxNode node)
        {
            var output = node.DescendantTokens(descendIntoTrivia: true);
            return output;
        }

        /// <summary>
        /// Gets all descendant trivias in the node.
        /// </summary>
        /// <remarks>
        /// Includes trivias inside of structured trivias.
        /// </remarks>
        public IEnumerable<SyntaxTrivia> Get_DescendantTrivias(SyntaxNode node)
        {
            var output = node.DescendantTrivia(descendIntoTrivia: true);
            return output;
        }

        public SyntaxTrivia[] Get_NewLineTrivias(SyntaxNode node)
        {
            var output = Instances.SyntaxNodeOperator.Get_DescendantTrivias(node)
                .Where(trivia => Instances.SyntaxTriviaOperator.Is_EndOfLine(trivia))
                .Now();

            return output;
        }

        public SyntaxToken Get_Token(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            var token = node.GetAnnotatedTokens(annotation)
                // Use first instead of single, for speed.
                .First();

            return token;
        }

        /// <summary>
        /// Chooses <see cref="Has_AnnotatedToken_Single(SyntaxNode, SyntaxAnnotation)"/> as the default.
        /// </summary>
        public WasFound<SyntaxToken> Has_AnnotatedToken(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            var output = this.Has_AnnotatedToken_Single(
                node,
                annotation);

            return output;
        }

        public WasFound<SyntaxToken> Has_AnnotatedToken_Single(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            var annotatedTokenOrDefault = node
                .GetAnnotatedTokens(annotation)
                .SingleOrDefault();

            var output = WasFound.From(annotatedTokenOrDefault);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Has_AnnotatedToken_Single(SyntaxNode, SyntaxAnnotation)"/> as the default.
        /// </summary>
        public WasFound<SyntaxTrivia> Has_AnnotatedTrivia(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            var output = this.Has_AnnotatedTrivia_Single(
                node,
                annotation);

            return output;
        }

        public WasFound<SyntaxTrivia> Has_AnnotatedTrivia_Single(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            var annotatedTriviaOrDefault = node
                .GetAnnotatedTrivia(annotation)
                .SingleOrDefault();

            var output = WasFound.From(annotatedTriviaOrDefault);
            return output;
        }

        public WasFound<SyntaxNode> Has_Parent(SyntaxNode node)
        {
            var output = WasFound.From(node.Parent);
            return output;
        }

        public TNode Modify_Token<TNode>(
            TNode node,
            SyntaxAnnotation tokenAnnotation,
            Func<SyntaxToken, SyntaxToken> tokenModifier)
            where TNode : SyntaxNode
        {
            var token = node.GetAnnotatedTokens(tokenAnnotation).First();

            var modifiedToken = tokenModifier(token);

            var output = node.ReplaceToken(
                token,
                modifiedToken);

            return output;
        }

        public TNode Move_DescendantTrailingTriviaToLeadingTrivia<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            var descendantTokensWithTrailingTrivia = this.Get_DescendantTokens(node)
                .Where(token => token.HasTrailingTrivia)
                //.Where(token => token.IsKind(SyntaxKind.EndOfDirectiveToken))
                //.Where(token => token.IsKind(SyntaxKind.EndOfDirectiveToken) || token.IsKind(SyntaxKind.RegionKeyword))
                //.Where(token => token.IsKind(SyntaxKind.OpenBraceToken))
                // Evaluate now, so that tokens are not found as they are being annotated.
                .ToArray();

            node = this.AnnotateTokens(
                node,
                descendantTokensWithTrailingTrivia,
                out var annotationsByToken);

            // Iterate over pairs to have access to the syntax node information while debugging.
            foreach (var pair in annotationsByToken)
            {
                var tokenAnnotation = pair.Value;

                // Token.
                var originalToken = this.Get_AnnotatedToken(
                    node,
                    tokenAnnotation);

                var tokenTrailingTrivia = originalToken.TrailingTrivia;

                var token = originalToken.Without_TrailingTrivia();

                node = this.Replace_Token(
                    node,
                    originalToken,
                    token);

                var newToken = this.Get_AnnotatedToken(
                    node,
                    tokenAnnotation);


                // Next token.
                // Getting the next token is simple (we do not need to consider directives or documentation comments, i.e. structured trivia).
                // The initial get-descendant-tokens found tokens everywhere (including in any structured trivia), so if our token is inside of a directive or documentation comment, it will be inside of a structured trivia syntax.
                // Assuming that any structured trivia *cannot* itself contain structured trivia (a good assumption), this means we are inside a non-trivia context and will not move into a trivia context,
                // so getting the next token without considering structured trivia is safe.
                // We *do* however, want to get zero-width tokens (like end-of-trivia directives) since those can still have leading trivia (the zero-width criterion applies to just the span, not the full-span).
                var originalNextToken = newToken.GetNextToken(
                    includeZeroWidth: true);

                if (originalNextToken.Is_None())
                {
                    // Unable to move trailing trivia of last token to leading trivia of next token, since no next token exists!
                    continue;
                }
                
                var nextTokenLeadingTrivia = originalNextToken.LeadingTrivia;

                // There is complexity surrounding where to place the prior node's trailing trivia:
                //  * If the token is within a structured trivia:
                //      => Insert prior node trailing trivia after the trivia containing the token in the leading trivia of the next node.
                //  * Else, prepend prior node trailing trivia to the leading trivia of the next node.
                var tokenIsWithinStructuredTrivia = Instances.SyntaxTokenOperator.Is_InStructuredTrivia(newToken);

                var newNextTokenLeadingTrivia = tokenIsWithinStructuredTrivia
                    ? Instances.SyntaxTriviaListOperator.Insert_After(
                        nextTokenLeadingTrivia,
                        tokenIsWithinStructuredTrivia.Result,
                        tokenTrailingTrivia)
                    : nextTokenLeadingTrivia.Prepend(tokenTrailingTrivia)
                    ;

                var nextToken = originalNextToken.WithLeadingTrivia(newNextTokenLeadingTrivia);

                node = this.Replace_Token(
                    node,
                    originalNextToken,
                    nextToken);
            }

            return node;
        }

        /// <summary>
        /// A better version that will throw if the given token is not found.
        /// </summary>
        public TNode Replace_Token<TNode>(
            TNode node,
            SyntaxToken oldDescendantToken,
            SyntaxToken newDescendantToken)
            where TNode : SyntaxNode
        {
            var tokenWasFound = false;

            var output = node.ReplaceTokens(
                Instances.EnumerableOperator.From(oldDescendantToken),
                (originalToken, possiblyRewrittenToken) =>
                {
                    if (originalToken == oldDescendantToken)
                    {
                        tokenWasFound = true;
                    }

                    return newDescendantToken;
                });

            if (!tokenWasFound)
            {
                throw new Exception("Token was not found in call to replace Token.");
            }

            return output;
        }

        /// <summary>
        /// A better version that will throw if any of the given tokens are not found.
        /// </summary>
        public TNode Replace_Tokens<TNode>(
            TNode node,
            IEnumerable<SyntaxToken> oldTokens,
            Func<SyntaxToken, SyntaxToken, SyntaxToken> computeReplacementToken)
            where TNode : SyntaxNode
        {
            var tokensHash = new HashSet<SyntaxToken>(oldTokens);

            var output = node.ReplaceTokens(
                oldTokens,
                (originalToken, possiblyRewrittenToken) =>
                {
                    tokensHash.Remove(originalToken);

                    var outputToken = computeReplacementToken(originalToken, possiblyRewrittenToken);
                    return outputToken;
                });

            if (tokensHash.Any())
            {
                throw new Exception("Some tokens to replace were not found.");
            }

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Replace_Tokens{TNode}(TNode, IEnumerable{SyntaxToken}, Func{SyntaxToken, SyntaxToken, SyntaxToken})" path="/summary"/>
        /// </summary>
        public TNode Replace_Tokens<TNode>(
            TNode node,
            IDictionary<SyntaxToken, SyntaxToken> replacements)
            where TNode : SyntaxNode
        {
            var output = this.Replace_Tokens(
                node,
                replacements.Keys,
                (originalToken, _) => replacements[originalToken]);

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Replace_Tokens{TNode}(TNode, IEnumerable{SyntaxToken}, Func{SyntaxToken, SyntaxToken, SyntaxToken})" path="/summary"/>
        /// </summary>
        public TNode Replace_Tokens<TNode>(
            TNode node,
            IEnumerable<(SyntaxToken, SyntaxToken)> replacements)
            where TNode : SyntaxNode
        {
            var replacementsDictionary = replacements
                .ToDictionary(
                    x => x.Item1,
                    x => x.Item2);

            var output = this.Replace_Tokens(
                node,
                replacementsDictionary);

            return output;
        }


        /// <summary>
        /// A better version that will throw if any of the given tokens are not found.
        /// </summary>
        public TNode Replace_Trivias<TNode>(
            TNode node,
            IEnumerable<SyntaxTrivia> oldTrivias,
            Func<SyntaxTrivia, SyntaxTrivia, SyntaxTrivia> computeReplacementTrivia)
            where TNode : SyntaxNode
        {
            var triviasHash = new HashSet<SyntaxTrivia>(oldTrivias);

            var output = node.ReplaceTrivia(
                oldTrivias,
                (originalTrivia, possiblyRewrittenTrivia) =>
                {
                    triviasHash.Remove(originalTrivia);

                    var outputToken = computeReplacementTrivia(originalTrivia, possiblyRewrittenTrivia);
                    return outputToken;
                });

            if (triviasHash.Any())
            {
                throw new Exception("Some trivias to replace were not found.");
            }

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Replace_Trivias{TNode}(TNode, IEnumerable{SyntaxTrivia}, Func{SyntaxTrivia, SyntaxTrivia, SyntaxTrivia})" path="/summary"/>
        /// </summary>
        public TNode Replace_Trivias<TNode>(
            TNode node,
            IDictionary<SyntaxTrivia, SyntaxTrivia> replacements)
            where TNode : SyntaxNode
        {
            var output = this.Replace_Trivias(
                node,
                replacements.Keys,
                (originalToken, _) => replacements[originalToken]);

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Replace_Trivias{TNode}(TNode, IEnumerable{SyntaxTrivia}, Func{SyntaxTrivia, SyntaxTrivia, SyntaxTrivia})" path="/summary"/>
        /// </summary>
        public TNode Replace_Trivias<TNode>(
            TNode node,
            IEnumerable<(SyntaxTrivia, SyntaxTrivia)> replacements)
            where TNode : SyntaxNode
        {
            var replacementsDictionary = replacements
                .ToDictionary(
                    x => x.Item1,
                    x => x.Item2);

            var output = this.Replace_Trivias(
                node,
                replacementsDictionary);

            return output;
        }


        public TNode Set_SeparatingTrivia<TNode>(
            TNode root,
            SyntaxToken token,
            SyntaxTriviaList separatingTrivia)
            where TNode : SyntaxNode
        {
            // Annotate the token.
            root = Instances.SyntaxAnnotationOperator.AnnotateToken(
                root,
                token,
                out var tokenAnnotation);

            root = this.Modify_Token(
                root,
                tokenAnnotation,
                token => token.WithLeadingTrivia(separatingTrivia));

            // Change previous token if required.
            var annotatedToken = this.Get_Token(
                root,
                tokenAnnotation);

            var previousToken = annotatedToken.GetPreviousToken();

            if (previousToken.HasTrailingTrivia)
            {
                var previousToken_WithoutTrailingTrivia = previousToken.Without_TrailingTrivia();

                root = this.Replace_Token(
                    root,
                    previousToken,
                    previousToken_WithoutTrailingTrivia);
            }

            return root;
        }

        public TNode New<TNode>(
            TNode node,
            params Func<TNode, TNode>[] operations)
            where TNode : SyntaxNode
        {
            foreach (var operation in operations)
            {
                node = operation(node);
            }

            return node;
        }

        public TNode New<TNode>(
            Func<TNode> nodeConstructor,
            params Func<TNode, TNode>[] operations)
            where TNode : SyntaxNode
        {
            var node = nodeConstructor();

            var output = this.New(
                node,
                operations);

            return output;
        }

        public SyntaxNode Verify_HasParent(SyntaxNode node)
        {
            var hasParent = this.Has_Parent(node);

            return hasParent.ResultOrExceptionIfNotFound(
                "Node had no parent node.");
        }

        public void Verify_IsPartOfStructuredTrivia(SyntaxNode node)
        {
            var isPartOfStructuredTrivia = node.IsPartOfStructuredTrivia();
            if (!isPartOfStructuredTrivia)
            {
                throw new Exception("Node was not part of a structured trivia.");
            }
        }

        public void Verify_NoTokenTrailingTriviaAfterMove(SyntaxNode node)
        {
            var hasTokensWithTrailingTrivia = Instances.SyntaxOperator.Has_TokensWithTrailingTrivia(node);
            if (hasTokensWithTrailingTrivia.Exists)
            {
                foreach (var token in hasTokensWithTrailingTrivia.Result)
                {
                    Instances.SyntaxTokenOperator.Describe_To_Console(token);
                }

                throw new Exception("Some tokens still had trailing trivia.");
            }
        }

        public void Verify_NoNodeTrailingTriviaAfterMove(SyntaxNode node)
        {
            var hasNodesWithTrailingTrivia = Instances.SyntaxOperator.Has_NodesWithTrailingTrivia(node);
            if (hasNodesWithTrailingTrivia.Exists)
            {
                foreach (var descendantNode in hasNodesWithTrailingTrivia.Result)
                {
                    Console.WriteLine(descendantNode);
                }

                throw new Exception("Some nodes still had trailing trivia.");
            }
        }

        /// <summary>
        /// Chooses <see cref="Verify_NoTokenTrailingTriviaAfterMove(SyntaxNode)"/> as the default.
        /// </summary>
        public void Verify_NoTrailingTriviaAfterMove(SyntaxNode node)
        {
            this.Verify_NoTokenTrailingTriviaAfterMove(node);
        }
    }
}
