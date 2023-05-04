using System;

using Microsoft.CodeAnalysis;


namespace R5T.E0068.Extensions
{
    public static class SyntaxTriviaExtensions
    {
        public static SyntaxTrivia Annotate(this SyntaxTrivia trivia,
            out SyntaxAnnotation annotation)
        {
            return Instances.SyntaxTriviaOperator.Annotate(trivia, out annotation);
        }

        /// <inheritdoc cref="ISyntaxTriviaOperator.Is_NewLine(SyntaxTrivia)"/>
        public static bool Is_NewLine(this SyntaxTrivia trivia)
        {
            return Instances.SyntaxTriviaOperator.Is_NewLine(trivia);
        }

        /// <inheritdoc cref="ISyntaxTriviaOperator.Is_Structured(SyntaxTrivia)"/>
        public static bool Is_Structured(this SyntaxTrivia trivia)
        {
            return Instances.SyntaxTriviaOperator.Is_Structured(trivia);
        }
    }
}
