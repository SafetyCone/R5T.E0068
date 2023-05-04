using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis;


namespace R5T.E0068.Extensions
{
    public static class SyntaxNodeExtensions
    {
        /// <inheritdoc cref="ISyntaxNodeOperator.Replace_Tokens{TNode}(TNode, IEnumerable{SyntaxToken}, Func{SyntaxToken, SyntaxToken, SyntaxToken})"/>
        public static TNode Replace_Tokens<TNode>(this TNode node,
            IEnumerable<SyntaxToken> oldTokens,
            Func<SyntaxToken, SyntaxToken, SyntaxToken> computeReplacementToken)
            where TNode : SyntaxNode
        {
            return Instances.SyntaxNodeOperator.Replace_Tokens(
                node,
                oldTokens,
                computeReplacementToken);
        }

        /// <inheritdoc cref="ISyntaxNodeOperator.Replace_Tokens{TNode}(TNode, IDictionary{SyntaxToken, SyntaxToken})"/>
        public static TNode Replace_Tokens<TNode>(this TNode node,
            IDictionary<SyntaxToken, SyntaxToken> replacements)
            where TNode : SyntaxNode
        {
            return Instances.SyntaxNodeOperator.Replace_Tokens(
                node,
                replacements);
        }

        public static TNode Replace_Tokens<TNode>(this TNode node,
            IEnumerable<(SyntaxToken, SyntaxToken)> replacements)
            where TNode : SyntaxNode
        {
            return Instances.SyntaxNodeOperator.Replace_Tokens(
                node,
                replacements);
        }


        /// <inheritdoc cref="ISyntaxNodeOperator.Replace_Trivias{TNode}(TNode, IEnumerable{SyntaxTrivia}, Func{SyntaxTrivia, SyntaxTrivia, SyntaxTrivia})"/>
        public static TNode Replace_Trivias<TNode>(this TNode node,
            IEnumerable<SyntaxTrivia> oldTrivias,
            Func<SyntaxTrivia, SyntaxTrivia, SyntaxTrivia> computeReplacementTrivias)
            where TNode : SyntaxNode
        {
            return Instances.SyntaxNodeOperator.Replace_Trivias(
                node,
                oldTrivias,
                computeReplacementTrivias);
        }

        /// <inheritdoc cref="ISyntaxNodeOperator.Replace_Trivias{TNode}(TNode, IDictionary{SyntaxTrivia, SyntaxTrivia})"/>
        public static TNode Replace_Trivias<TNode>(this TNode node,
            IDictionary<SyntaxTrivia, SyntaxTrivia> replacements)
            where TNode : SyntaxNode
        {
            return Instances.SyntaxNodeOperator.Replace_Trivias(
                node,
                replacements);
        }

        public static TNode Replace_Trivias<TNode>(this TNode node,
            IEnumerable<(SyntaxTrivia, SyntaxTrivia)> replacements)
            where TNode : SyntaxNode
        {
            return Instances.SyntaxNodeOperator.Replace_Trivias(
                node,
                replacements);
        }
    }
}
