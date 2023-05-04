using System;
using System.IO;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.F0124;
using R5T.F0124.Extensions;
using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface IDocumentationCommentTriviaSyntaxOperator : IFunctionalityMarker
    {
        public string Describe_To_String(
            DocumentationCommentTriviaSyntax documentationComment,
            ILineSeparator lineSeparator)
        {
            var endOfComment_Description = Instances.SyntaxTokenOperator.Describe_To_String(documentationComment.EndOfComment);

            var lines = Instances.EnumerableOperator.From($"{nameof(DocumentationCommentTriviaSyntax)}:\n{documentationComment.ToFullString()}")
                .Append(
                    $"End of comment:\n{endOfComment_Description}",
                    $"{documentationComment.Content.Count}: content XML node count"
                );

            var line = Instances.TextOperator.Join_Lines(
                lines,
                lineSeparator);

            return line;
        }

        public void Describe_To(
            DocumentationCommentTriviaSyntax documentationComment,
            TextWriter writer)
        {
            var line = this.Describe_To_String(
                documentationComment,
                writer.NewLine.ToLineSeparator());

            writer.WriteLine(line);
        }

        public void Describe_To_Console(DocumentationCommentTriviaSyntax documentationComment)
        {
            this.Describe_To(
                documentationComment,
                Console.Out);
        }
    }
}
