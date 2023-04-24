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

        /// <inheritdoc cref="SyntaxFactory.SyntaxTrivia(SyntaxKind, string)"/>
        public SyntaxTrivia New(
            SyntaxKind kind,
            string text)
        {
            var output = SyntaxFactory.SyntaxTrivia(kind, text);
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
