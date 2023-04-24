using System;
using System.IO;

using Microsoft.CodeAnalysis;

using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxTriviaListOperator : IFunctionalityMarker
    {
        public string Describe_To_String(
            SyntaxTriviaList triviaList,
            string lineSeparator)
        {
            throw new NotImplementedException();
        }

        public void Describe_To(
            SyntaxTriviaList triviaList,
            TextWriter writer)
        {
            var line = this.Describe_To_String(
                triviaList,
                writer.NewLine);

            writer.WriteLine(line);
        }
    }
}
