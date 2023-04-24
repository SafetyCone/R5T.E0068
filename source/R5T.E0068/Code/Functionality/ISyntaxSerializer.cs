using System;
using System.IO;

using Microsoft.CodeAnalysis;

using R5T.T0132;
using R5T.T0180;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxSerializer : IFunctionalityMarker
    {
        public void WriteToFile_Synchronous(
            SyntaxNode node,
            string filePath)
        {
            using var fileWriter = new StreamWriter(filePath);

            node.WriteTo(fileWriter);
        }

        public void WriteToFile_Synchronous(
            SyntaxNode node,
            IFilePath filePath)
        {
            this.WriteToFile_Synchronous(node, filePath.Value);
        }

        public void WriteToFile_Synchronous(
            SyntaxToken token,
            string filePath)
        {
            using var fileWriter = new StreamWriter(filePath);

            token.WriteTo(fileWriter);
        }

        public void WriteToFile_Synchronous(
            SyntaxToken token,
            IFilePath filePath)
        {
            this.WriteToFile_Synchronous(token, filePath.Value);
        }

        public void WriteToFile_Synchronous(
            SyntaxTrivia trivia,
            string filePath)
        {
            using var fileWriter = new StreamWriter(filePath);

            trivia.WriteTo(fileWriter);
        }

        public void WriteToFile_Synchronous(
            SyntaxTrivia trivia,
            IFilePath filePath)
        {
            this.WriteToFile_Synchronous(trivia, filePath.Value);
        }

        public void WriteToFile_Synchronous(
            SyntaxTriviaList triviaList,
            string filePath)
        {
            using var fileWriter = new StreamWriter(filePath);

            var fullString = triviaList.ToFullString();

            fileWriter.Write(fullString);
        }

        public void WriteToFile_Synchronous(
            SyntaxTriviaList triviaList,
            IFilePath filePath)
        {
            this.WriteToFile_Synchronous(triviaList, filePath.Value);
        }
    }
}
