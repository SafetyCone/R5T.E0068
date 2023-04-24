using System;
using System.IO;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.F0000.Extensions;
using R5T.F0124;
using R5T.F0124.Extensions;
using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxTokenOperator : IFunctionalityMarker
    {
        public string Describe_To_String(
            SyntaxToken token,
            ILineSeparator lineSeparator)
        {
            var lines = Instances.EnumerableOperator.From($"{token.Text}: SyntaxToken")
                .Append(Instances.EnumerableOperator.New<string>()
                    .Append(
                        $"{token.Kind()} ({token.RawKind}): kind (raw kind)",
                        $"{token.Text}: text",
                        $"{token.ValueText}: value text",
                        $"{token.IsMissing}: is missing")
                    .AppendIf(
                        token.Value is not null,
                        // Use an expression to avoid execution if the value is actually null!
                        () => $"{token.Value}, ({token.Value.GetType().FullName}): value, (type)")
                    .AppendIf(
                        token.Value is null,
                        $"{Instances.Strings.Null_TextRepresentation}: value")
                    .Append($"{token.HasLeadingTrivia}: has leading trivia")
                    .AppendIf(
                        token.HasLeadingTrivia,
                        () =>
                        {
                            var triviaDecription = token.LeadingTrivia.Any() && token.LeadingTrivia.First().Span.Length > 0
                                ? token.LeadingTrivia.ToFullString()
                                : Instances.Strings.Empty_TextRepresentation
                                ;

                            var output = $"{triviaDecription}: leading trivia";
                            return output;
                        })
                    .Append($"{token.HasTrailingTrivia}: has trailing trivia")
                    .AppendIf(
                        token.HasTrailingTrivia,
                        () =>
                        {
                            var triviaDecription = token.LeadingTrivia.Any() && token.LeadingTrivia.First().Span.Length > 0
                                ? token.LeadingTrivia.ToFullString()
                                : Instances.Strings.Empty_TextRepresentation
                                ;

                            var output = $"{triviaDecription}: trailing trivia";
                            return output;
                        })
                    .Tabinate())
                ;

            var line = Instances.TextOperator.Join_Lines(
                lines,
                lineSeparator);

            return line;
        }

        public void Describe_To(
            SyntaxToken token,
            TextWriter writer)
        {
            var line = this.Describe_To_String(
                token,
                writer.NewLine.ToLineSeparator());

            writer.WriteLine(line);
        }

        public void Describe_To_Console(SyntaxToken token)
        {
            this.Describe_To(
                token,
                Console.Out);
        }

        public bool Is_None(SyntaxToken token)
        {
            var output = token.IsKind(SyntaxKind.None);
            return output;
        }

        //public bool Is_Empty(SyntaxToken token)
        //{
        //    token.
        //}
    }
}
