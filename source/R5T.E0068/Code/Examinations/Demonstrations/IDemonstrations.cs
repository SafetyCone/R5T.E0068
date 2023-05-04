using System;

using R5T.T0141;


namespace R5T.E0068
{
    [DemonstrationsMarker]
    public partial interface IDemonstrations : IDemonstrationsMarker
    {
        /// <summary>
        /// While moving all trivia from trailing to leading on tokens *should* result in the same being true for nodes
        /// (see <see cref="Verify_NoTokenTrailingTriviaAfterMove"/>), test it.
        /// </summary>
        public void Verify_NoNodeTrailingTriviaAfterMove()
        {
            /// Input.
            var codeFilePath = Instances.CodeFilePaths.ExampleClass;
            var outputFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            var compilationUnit = Instances.SyntaxOperator.Load_Synchronous(codeFilePath);

            // Round-trip serialize to see what formatting changes (if any) wrought as part of loading process (which includes moving all trailing trivia to be leading trivia).
            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                compilationUnit,
                outputFilePath.Value);

            Instances.NotepadPlusPlusOperator.Open(
                outputFilePath.Value);

            // Now check what tokens still have trailing trivia.
            Instances.SyntaxNodeOperator.Verify_NoNodeTrailingTriviaAfterMove(compilationUnit);
        }

        /// <summary>
        /// Verify that after loading (which includes parsing the code file text into a compilation unit, which includes moving all trivia from trailing to leading),
        /// no trailing trivia remains on any tokens.
        /// </summary>
        public void Verify_NoTokenTrailingTriviaAfterMove()
        {
            /// Input.
            var codeFilePath = Instances.CodeFilePaths.ExampleClass;
            var outputFilePath = Instances.FilePaths.CSharp_Temp;

            
            /// Run.
            var compilationUnit = Instances.SyntaxOperator.Load_Synchronous(codeFilePath);

            // Round-trip serialize to see what formatting changes (if any) wrought as part of loading process (which includes moving all trailing trivia to be leading trivia).
            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                compilationUnit,
                outputFilePath.Value);

            Instances.NotepadPlusPlusOperator.Open(
                outputFilePath.Value);

            // Now check what tokens still have trailing trivia.
            Instances.SyntaxNodeOperator.Verify_NoTokenTrailingTriviaAfterMove(compilationUnit);
        }
    }
}
