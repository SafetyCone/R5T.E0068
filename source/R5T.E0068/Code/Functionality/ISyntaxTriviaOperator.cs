using System;
using System.IO;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.F0000.Extensions;
using R5T.F0124;
using R5T.F0124.Extensions;
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
        public SyntaxTrivia New(
            SyntaxKind kind,
            string text)
        {
            var output = SyntaxFactory.SyntaxTrivia(kind, text);
            return output;
        }

        public SyntaxTrivia New_Whitespace(string text)
        {
            var output = this.New(
                SyntaxKind.WhitespaceTrivia,
                text);

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

        public bool Is_EndOfLine(SyntaxTrivia trivia)
        {
            var output = trivia.IsKind(SyntaxKind.EndOfLineTrivia);
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
    }
}
