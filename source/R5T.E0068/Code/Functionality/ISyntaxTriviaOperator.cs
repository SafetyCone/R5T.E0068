using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.F0000.Extensions;
using R5T.F0124;
using R5T.F0124.Extensions;
using R5T.L0089.T000;
using R5T.T0132;

using R5T.E0068.Extensions;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxTriviaOperator : IFunctionalityMarker
    {
        public SyntaxTrivia Annotate(
            SyntaxTrivia trivia,
            out SyntaxAnnotation annotation)
        {
            return Instances.SyntaxAnnotationOperator.Annotate(
                trivia,
                out annotation);
        }

        public string Describe_To_String(
            SyntaxTrivia trivia,
            ILineSeparator lineSeparator)
        {
            var lines = Instances.EnumerableOperator.From($"{trivia}: SyntaxTrivia")
                .Append(Instances.EnumerableOperator.New<string>()
                    .Append(
                        $"{trivia.Kind()} ({trivia.RawKind}): kind (raw kind)",
                        $"{trivia.FullSpan.Length} ({trivia.Span.Length}): full length (length)",
                        $"{trivia.IsDirective}: is directive")
                    .Append(() =>
                    {
                        var parentIsNone = trivia.Token.Is_None();

                        var textRepresentation = parentIsNone
                            ? Instances.Strings.None_TextRepresentation
                            : trivia.Token.ToFullString()
                            ;

                        var output = $"{textRepresentation}: parent token";
                        return output;
                    })
                    .Append($"{trivia.HasStructure}: has structure")
                    .AppendIf(
                        trivia.HasStructure,
                        () =>
                        {
                            var structuredTrivia = trivia.GetStructure();

                            return $"{structuredTrivia.ToFullString()}: structured trivia";
                        })
                    .Tabinate())
                ;

            var line = Instances.TextOperator.Join_Lines(
                lines,
                lineSeparator);

            return line;
        }

        public void Describe_To(
            SyntaxTrivia trivia,
            TextWriter writer)
        {
            var line = this.Describe_To_String(
                trivia,
                writer.NewLine.ToLineSeparator());

            writer.WriteLine(line);
        }

        public void Describe_To_Console(SyntaxTrivia trivia)
        {
            this.Describe_To(
                trivia,
                Console.Out);
        }

        public string Display_To_String(SyntaxTrivia trivia)
        {
            var isEndOfLine = this.Is_EndOfLine(trivia);
            if (isEndOfLine)
            {
                var text = trivia.ToString();

                text = text
                    .Replace(
                        Instances.Strings.NewLine_Windows,
                        Instances.Strings.NewLine_TextRepresentation)
                    .Replace(
                        Instances.Strings.NewLine_NonWindows,
                        Instances.Strings.NewLine_TextRepresentation)
                    ;

                return text;
            }

            var isWhitespace = this.Is_Whitespace(trivia);
            if (isWhitespace)
            {
                var isEmpty = this.Is_Empty(trivia);
                if (isEmpty)
                {

                    var whitespaceToken = isWhitespace
                        // Include leading space.
                        ? " whitespace"
                        : Instances.Strings.Empty
                        ;

                    var emptyWhitespaceOutput = $"{Instances.Strings.Empty_TextRepresentation}{whitespaceToken}";
                    return emptyWhitespaceOutput;
                }
                else
                {
                    var text = trivia.ToString();

                    text = text
                        .Replace(
                            Instances.Strings.Tab_AsSpaces,
                            Instances.Strings.Tab_AsSpaces_TextRepresentation)
                        .Replace(
                            Instances.Strings.Tab,
                            Instances.Strings.Tab_TextRepresentation)
                        .Replace(
                            Instances.Strings.Space,
                            Instances.Strings.Interpunct)
                        ;

                    return text;
                }
            }

            if (trivia.IsDirective)
            {
                return "<directive>";
            }

            if (trivia.HasStructure)
            {
                return "<structured>";
            }

            var output = $"\"{trivia}\"";
            return output;
        }

        public void Display_To(
            SyntaxTrivia trivia,
            TextWriter writer)
        {
            var text = this.Display_To_String(trivia);

            writer.WriteLine(text);
        }

        public void Display_To_Console(
            SyntaxTrivia trivia)
        {
            this.Display_To(
                trivia,
                Console.Out);
        }

        [Obsolete("See R5T.L0073.F001.Utilities.ISyntaxNodeOperations.Modify_NewLineContainingTriviaLists()")]
        public TNode Modify_NewLineContainingTriviaLists<TNode>(
            TNode node,
            Func<SyntaxTriviaList, SyntaxTrivia, SyntaxTriviaList> modifier)
            where TNode : SyntaxNode
        {
            var newLineTrivias = Instances.SyntaxNodeOperator.Get_NewLineTrivias(node);

            node = Instances.SyntaxNodeOperator.AnnotateTrivias(
                node,
                newLineTrivias,
                out var annotationsByTrivias);

            foreach (var newLineTriviaAnnotation in annotationsByTrivias.Values)
            {
                var newLineTrivia = Instances.SyntaxNodeOperator.Get_AnnotatedTrivia(
                    node,
                    newLineTriviaAnnotation);

                node = Instances.SyntaxTriviaOperator.Modify_ContainingTriviaList(
                    node,
                    newLineTrivia,
                    trivias => modifier(trivias, newLineTrivia));
            }

            return node;
        }

        [Obsolete("See R5T.L0073.F001.ISyntaxTriviaOperator.Modify_ContainingTriviaList()")]
        public TNode Modify_ContainingTriviaList<TNode>(
            TNode node,
            SyntaxTrivia trivia,
            Func<SyntaxTriviaList, SyntaxTriviaList> modifier)
            where TNode : SyntaxNode
        {
            var token = trivia.Token;

            var newToken = token;

            var triviaIsInLeadingTrivia = token.LeadingTrivia.Contains(trivia);
            if(triviaIsInLeadingTrivia)
            {
                var newLeadingTrivia = modifier(token.LeadingTrivia);

                newToken = newToken.WithLeadingTrivia(newLeadingTrivia);
            }

            var triviaIsInTrailingTrivia = token.TrailingTrivia.Contains(trivia);
            if (triviaIsInTrailingTrivia)
            {
                var newTrailingTrivia = modifier(token.LeadingTrivia);

                newToken = newToken.WithTrailingTrivia(newTrailingTrivia);
            }

            node = Instances.SyntaxNodeOperator.Replace_Token(
                node,
                token,
                newToken);

            return node;
        }

        /// <summary>
        /// It's possible to create a syntax trivia in its initial (zero) state, just like any other value type.
        /// Use the parameterless constructor present on all value types.
        /// </summary>
        public SyntaxTrivia New()
        {
            var output = new SyntaxTrivia();
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="SyntaxFactory.SyntaxTrivia(SyntaxKind, string)"/>
        /// </summary>
        /// <remarks>
        /// The kind can be one of:
        /// <inheritdoc cref="Documentation.ForSyntaxTriviaAllowedKinds" path="/definition"/>
        /// </remarks>
        [Obsolete("See R5T.L0073.F001.ISyntaxTriviaOperator.New()")]
        public SyntaxTrivia New(
            SyntaxKind kind,
            string text)
        {
            var output = SyntaxFactory.SyntaxTrivia(kind, text);
            return output;
        }

        [Obsolete("See R5T.L0073.F001.ISyntaxTriviaOperator.New_Whitespace()")]
        public SyntaxTrivia New_Whitespace(string text)
        {
            var output = this.New(
                SyntaxKind.WhitespaceTrivia,
                text);

            return output;
        }

        public StructuredTriviaSyntax Get_AncestorStructuredTriviaSyntax(SyntaxTrivia trivia)
        {
            this.Verify_IsPartOfStructuredTrivia(trivia);

            var parentToken = this.Verify_HasParent(trivia);

            var output = Instances.SyntaxTokenOperator.Get_AncestorStructuredTriviaSyntax(parentToken);
            return output;
        }

        public SyntaxTrivia Get_AncestorStructuredTrivia(SyntaxTrivia trivia)
        {
            var syntax = this.Get_AncestorStructuredTriviaSyntax(trivia);

            var parentTrivia = Instances.StructuredTriviaSyntaxOperator.Verify_HasParentTrivia(syntax);
            return parentTrivia;
        }

        /// <summary>
        /// Gets the token containing the ancestor structured trivia.
        /// The ancestor structured trivia is returned as well, to aid in determining whether the structured trivia is in the token's leading or trailing trivia.
        /// </summary>
        public (SyntaxToken token, SyntaxTrivia structuredTrivia) Get_AncestorStructuredTriviaToken(SyntaxTrivia trivia)
        {
            var structuredTrivia = this.Get_AncestorStructuredTrivia(trivia);

            var parentToken = this.Verify_HasParent(structuredTrivia);
            return (parentToken, structuredTrivia);
        }

        public IEnumerable<SyntaxTrivia> Get_PriorLeadingTrivias(SyntaxTrivia trivia)
        {
            var (parentToken, indexInLeadingTrivia) = this.Verify_IsInLeadingTrivia(trivia);

            for (int i = 0; i < indexInLeadingTrivia; i++)
            {
                yield return parentToken.LeadingTrivia[i];
            }
        }

        /// <summary>
        /// Gets all trivias separating the given trivia from the token prior to the trivia (.
        /// </summary>
        /// <remarks>
        /// Useful when querying indentation in order to set indentation.
        /// </remarks>
        public IEnumerable<SyntaxTrivia> Get_SeparatingTrivias(SyntaxTrivia trivia)
        {
            // There is some confusion regarding getting separating trivias when the boundary might cross a structured trivia line.

            var (parentToken, indexInLeadingTrivia) = this.Verify_IsInLeadingTrivia(trivia);
            
            var isInStructuredTrivia = this.Is_InStructuredTrivia(trivia);
            if(isInStructuredTrivia)
            {
                // Determine if the parent token is the first token inside of the structured trivia.

                // Get the token previous to the parent token, but do not consider any forms of structured trivia.
                // We are in structured trivia, and so will either get a prior token within the same structured trivia,
                // or a token outside (and previous to) the structured trivia.
                var previousToken = parentToken.GetPreviousToken(
                    includeZeroWidth: false,
                    includeSkipped: false,
                    includeDirectives: false,
                    includeDocumentationComments: false);

                var previousTokenIsInStructuredTrivia = Instances.SyntaxTokenOperator.Is_InStructuredTrivia(previousToken);

                var parentTokenIsFirstInStructuredTrivia = !previousTokenIsInStructuredTrivia;
                if(parentTokenIsFirstInStructuredTrivia)
                {
                    // If the parent token is the first token in its structured trivia, then we need to consider both:
                    //  1. Trailing trivia on the token previous to the token containing the structured trivia.
                    //  2. Leading trivia before the structured trivia on the token containg the structured trivia.

                    // Get the token containing the ancestor structured trivia.
                    var (ancestorStructuredTriviaToken, structuredTrivia) = this.Get_AncestorStructuredTriviaToken(trivia);

                    // Should be true for separating trivia, and we will need the index.
                    (_, int indexOfStructuredTriviaInAncestorLeadingTrivia) = this.Verify_IsInLeadingTrivia(structuredTrivia);

                    // Consider everything since the prior token could be in structured trivia.
                    var previousAncestorStructuredTriviaToken = ancestorStructuredTriviaToken.GetPreviousToken(
                        includeZeroWidth: true,
                        // Assume trivia is in valid C# code.
                        includeSkipped: false,
                        includeDirectives: true,
                        includeDocumentationComments: true);

                    // Get all trailing trivias of the previous node.
                    foreach (var previousTokenTrailingTrivia in previousAncestorStructuredTriviaToken.TrailingTrivia)
                    {
                        yield return previousTokenTrailingTrivia;
                    }

                    // Get all leading trivias up to, but not including, the trivia in the 
                    for (int iTrivia = 0; iTrivia < indexOfStructuredTriviaInAncestorLeadingTrivia; iTrivia++)
                    {
                        yield return ancestorStructuredTriviaToken.LeadingTrivia[iTrivia];
                    }
                }
                else
                {
                    // Just a regular operation because both tokens are inside of the same structured trivia context.
                    // Get the trailing trivia of previous token, and the leading trivia of the current token prior to the given trivia.
                    foreach (var previousTokenTrailingTrivia in previousToken.TrailingTrivia)
                    {
                        yield return previousTokenTrailingTrivia;
                    }
                }
            }
            else
            {
                // Get all the previous token's trailing trivia.

                // Consider everything since the prior token could be in structured trivia.
                var previousToken = parentToken.GetPreviousToken(
                    includeZeroWidth: true,
                    // Assume trivia is in valid C# code.
                    includeSkipped: false,
                    includeDirectives: true,
                    includeDocumentationComments: true);

                foreach (var previousTokenTrailingTrivia in previousToken.TrailingTrivia)
                {
                    yield return previousTokenTrailingTrivia;
                }
            }

            // Return tokens in the parent's leading trivia that come before the given triva.
            for (int i = 0; i < indexInLeadingTrivia; i++)
            {
                yield return parentToken.LeadingTrivia[i];
            }
        }

        /// <summary>
        /// Get all whitespace trivias separating the given trivia from the token prior to the trivia.
        /// </summary>
        /// <remarks>
        /// Useful when querying indentation in order to set indentation.
        /// </remarks>
        public IEnumerable<SyntaxTrivia> Get_SeparatingTextTrivias(SyntaxTrivia trivia)
        {
            var separatingTrivias = this.Get_SeparatingTrivias(trivia);

            // Return all trivias after the last new-line or structured trivia.
            var output = separatingTrivias.Reverse()
                .TakeWhile(trivia => !trivia.Is_NewLine() && !trivia.Is_Structured())
                .Reverse();

            return output;
        }

        public string Get_SeparatingText(SyntaxTrivia trivia)
        {
            var separatingWhitespaceTrivias = this.Get_SeparatingTextTrivias(trivia);

            var stringBuilder = new StringBuilder();
            foreach (var separatingWhitespaceTrivia in separatingWhitespaceTrivias)
            {
                stringBuilder.Append(separatingWhitespaceTrivia.ToFullString());
            }

            var output = stringBuilder.ToString();
            return output;
        }

        public WasFound<SyntaxToken> Has_Parent(SyntaxTrivia trivia)
        {
            // If no parent, the parent token will be the token default.
            var output = WasFound.From(trivia.Token);
            return output;
        }

        public bool Is_Empty(SyntaxTrivia trivia)
        {
            var output = trivia.FullSpan.Length < 1;
            return output;
        }

        public bool Is_EmptyWhitespace(SyntaxTrivia trivia)
        {
            var output = this.Is_Empty(trivia) && this.Is_Whitespace(trivia);
            return output;
        }

        [Obsolete("See R5T.L0073.F001.ISyntaxTriviaOperator.Is_EndOfLine()")]
        public bool Is_EndOfLine(SyntaxTrivia trivia)
        {
            var output = trivia.IsKind(SyntaxKind.EndOfLineTrivia);
            return output;
        }

        public WasFound<(SyntaxToken parentToken, int indexInLeadingTrivia)> Is_InLeadingTrivia(SyntaxTrivia trivia)
        {
            var parentToken = this.Verify_HasParent(trivia);

            var indexInLeadingTrivia = parentToken.LeadingTrivia.IndexOf(trivia);

            var exists = Instances.IndexOperator.Is_Found(indexInLeadingTrivia);

            var output = WasFound.From(exists, (parentToken, indexInLeadingTrivia));
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="SyntaxTrivia.IsPartOfStructuredTrivia()"/>.
        /// </summary>
        public bool Is_InStructuredTrivia(SyntaxTrivia trivia)
        {
            var output = trivia.IsPartOfStructuredTrivia();
            return output;
        }

        public bool Is_InTrailingTrivia(SyntaxTrivia trivia)
        {
            this.Verify_HasParent(trivia);

            var output = trivia.Token.TrailingTrivia.Contains(trivia);
            return output;
        }

        /// <summary>
        /// It's better to think of line separators as new-line tokens (instead of end-of-line tokens) since trivia should all be leading trivia.
        /// Quality-of-life overload for <see cref="Is_EndOfLine(SyntaxTrivia)"/>.
        /// </summary>
        public bool Is_NewLine(SyntaxTrivia trivia)
        {
            return this.Is_EndOfLine(trivia);
        }

        /// <summary>
        /// Quality-of-life overload from <see cref="SyntaxTrivia.HasStructure"/>.
        /// </summary>
        public bool Is_Structured(SyntaxTrivia trivia)
        {
            return trivia.HasStructure;
        }

        public bool Is_Whitespace(SyntaxTrivia trivia)
        {
            var output = trivia.IsKind(SyntaxKind.WhitespaceTrivia);
            return output;
        }

        public string ToString_TextRepresentation(SyntaxTrivia trivia)
        {
            var isEmptyWhitespace = this.Is_EmptyWhitespace(trivia);

            var textRepresentation = isEmptyWhitespace
                ? $"{Instances.Strings.Empty_TextRepresentation} whitespace"
                : trivia.ToFullString()
                ;

            return textRepresentation;
        }

        public SyntaxToken Verify_HasParent(SyntaxTrivia trivia)
        {
            var hasParent = this.Has_Parent(trivia);

            return hasParent.Get_Result_OrExceptionIfNotFound(
                "Trivia had no parent token (parent token has kind 'none').");
        }

        public (SyntaxToken parentToken, int indexInLeadingTrivia) Verify_IsInLeadingTrivia(SyntaxTrivia trivia)
        {
            var isInLeadingTrivia = this.Is_InLeadingTrivia(trivia);

            return isInLeadingTrivia.Get_Result_OrExceptionIfNotFound(
                "Trivia was not in the leading trivia of its parent token.");
        }

        public void Verify_IsPartOfStructuredTrivia(SyntaxTrivia trivia)
        {
            var isPartOfStructuredTrivia = trivia.IsPartOfStructuredTrivia();
            if (!isPartOfStructuredTrivia)
            {
                throw new Exception("Trivia was not part of a structured trivia.");
            }
        }
    }
}
