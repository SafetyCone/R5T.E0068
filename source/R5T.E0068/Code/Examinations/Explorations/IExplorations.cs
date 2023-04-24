using System;
using System.IO;

using R5T.T0141;


namespace R5T.E0068
{
    [ExplorationsMarker]
    public partial interface IExplorations : IExplorationsMarker
    {
        /// <summary>
        /// Use our <see cref="ISyntaxTriviaOperator.Describe_To_Console(Microsoft.CodeAnalysis.SyntaxTrivia)"/> to describe a <see cref="Microsoft.CodeAnalysis.SyntaxTrivia"/>.
        /// </summary>
        public void Describe_Trivia()
        {
            /// Inputs.
            var trivia = Instances.SyntaxTrivias.Whitespace_Empty;


            /// Run.
            Instances.SyntaxTriviaOperator.Describe_To_Console(trivia);
        }

        /// <summary>
        /// We get a basic class declaration, then add open and close brace tokens, and then spacing.
        /// </summary>
        public void Output_FullyFormedClass()
        {
            /// Inputs.
            var codeFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            var classDeclaration = Instances.SyntaxParser.Parse_Class(
                Instances.ClassDeclarations.Class01);

            var initialOpenBraceToken = classDeclaration.OpenBraceToken;

            Instances.SyntaxTokenOperator.Describe_To_Console(initialOpenBraceToken);

            var generatedOpenBraceToken = Instances.SyntaxTokens.OpenBraceToken;

            Instances.SyntaxTokenOperator.Describe_To_Console(generatedOpenBraceToken);

            if(initialOpenBraceToken.IsMissing)
            {
                classDeclaration = classDeclaration.WithOpenBraceToken(
                    generatedOpenBraceToken);
            }

            // Yes, this is the same as the Kind() extension method.
            //Console.WriteLine(Instances.SyntaxKindOperator.ToSyntaxKindName(initialOpenBraceToken.RawKind));

            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                classDeclaration,
                codeFilePath);

            Instances.NotepadPlusPlusOperator.Open(
                codeFilePath.Value);
        }

        /// <summary>
        /// Like, how do you write code to a file?
        /// How do you parse some text into code?
        /// </summary>
        public void Output_FirstCode()
        {
            /// Inputs.
            var codeFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            var classDeclaration = Instances.SyntaxParser.Parse_Class(
                Instances.ClassDeclarations.Class01);

            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                classDeclaration,
                Instances.FilePaths.CSharp_Temp);

            Instances.NotepadPlusPlusOperator.Open(
                codeFilePath.Value);
        }
    }
}
