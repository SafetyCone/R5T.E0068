using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;

using R5T.T0132;

using R5T.E0068.Extensions;

namespace R5T.E0068
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Prior work:
    /// <list type="bullet">
    /// <item>R5T.L0011.X000</item>
    /// </list>
    /// </remarks>
    [FunctionalityMarker]
    public partial interface ISyntaxAnnotationOperator : IFunctionalityMarker
    {
        public SyntaxToken Annotate(
            SyntaxToken token,
            out SyntaxAnnotation annotation)
        {
            annotation = this.New();

            var annotatedToken = token.WithAdditionalAnnotations(
                annotation);

            return annotatedToken;
        }

        public SyntaxTrivia Annotate(
            SyntaxTrivia trivia,
            out SyntaxAnnotation annotation)
        {
            annotation = this.New();

            var annotatedTrivia = trivia.WithAdditionalAnnotations(
                annotation);

            return annotatedTrivia;
        }

        public TNode AnnotateToken<TNode>(
            TNode node,
            SyntaxToken token,
            out SyntaxAnnotation annotation)
            where TNode : SyntaxNode
        {
            var annotatedToken = this.Annotate(token, out annotation);

            node = node.ReplaceToken(
                token,
                annotatedToken);

            return node;
        }

        /// <summary>
        /// Annotates tokens.
        /// </summary>
        public TNode AnnotateTokens<TNode>(
            TNode node,
            IEnumerable<SyntaxToken> syntaxTokens,
            out Dictionary<SyntaxToken, SyntaxAnnotation> annotationsByInputTokens)
            where TNode : SyntaxNode
        {
            // Temporary variable is required for use in anonymous method below.
            var annotationsByInputTokens_Temp = new Dictionary<SyntaxToken, SyntaxAnnotation>();

            var outputSyntaxNode = node.Replace_Tokens(
                syntaxTokens,
                (originalToken, possiblyRewrittenToken) =>
                {
                    var outputToken = possiblyRewrittenToken.Annotate(out var annotation);

                    annotationsByInputTokens_Temp.Add(originalToken, annotation);

                    return outputToken;
                });

            annotationsByInputTokens = annotationsByInputTokens_Temp;

            return outputSyntaxNode;
        }

        public SyntaxAnnotation New()
        {
            var output = new SyntaxAnnotation();
            return output;
        }

        public void Verify_AllAnnotationsExist(
            SyntaxNode node,
            IEnumerable<SyntaxAnnotation> annotations)
        {
            var counter = 0;

            foreach (var annotation in annotations)
            {
                var annotationIsMissing = !Instances.SyntaxNodeOperator.Has_AnnotatedToken(node, annotation);
                if(annotationIsMissing)
                {
                    counter++;
                }
            }

            var anyMissing = counter > 0;

            if(anyMissing)
            {
                throw new Exception("Some annotations were missing.");
            }
        }

        public void Verify_AllAnnotationsExist(
            SyntaxNode node,
            IDictionary<SyntaxToken, SyntaxAnnotation> annotationsByToken)
        {
            var missingCounter = 0;
            var tokenCounter = 0;

            foreach (var pair in annotationsByToken)
            {
                var annotationIsMissing = !Instances.SyntaxNodeOperator.Has_AnnotatedToken(node, pair.Value);
                if (annotationIsMissing)
                {
                    missingCounter++;
                }

                tokenCounter++;
            }

            var anyMissing = missingCounter > 0;

            if (anyMissing)
            {
                throw new Exception("Some annotations were missing.");
            }
        }
    }
}
