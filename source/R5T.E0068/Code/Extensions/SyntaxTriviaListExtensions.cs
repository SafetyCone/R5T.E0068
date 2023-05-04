using System;

using Microsoft.CodeAnalysis;


namespace R5T.E0068.Extensions
{
    public static class SyntaxTriviaListExtensions
    {
        public static SyntaxTriviaList Prepend(this SyntaxTriviaList trivias,
            SyntaxTriviaList prependix)
        {
            return Instances.SyntaxTriviaListOperator.Prepend(
                trivias,
                prependix);
        }

        public static IIndentation ToIndentation(this SyntaxTriviaList value)
        {
            return Instances.SyntaxTriviaListOperator_Extensions.ToIndentation(value);
        }

        public static ILineLeading ToLineLeading(this SyntaxTriviaList value)
        {
            return Instances.SyntaxTriviaListOperator_Extensions.ToLineLeading(value);
        }
    }
}
