using System;

using Microsoft.CodeAnalysis;

using R5T.T0178;


namespace R5T.E0068
{
    /// <inheritdoc cref="ILineLeading"/>
    [StrongTypeImplementationMarker]
    public class LineLeading : T0179.N001.TypedBase<SyntaxTriviaList>, IStrongTypeMarker,
        ILineLeading
    {
        public LineLeading(SyntaxTriviaList value)
            : base(value)
        {
        }

        protected override int Value_CompareTo(SyntaxTriviaList a, SyntaxTriviaList b)
        {
            var output = Instances.SyntaxTriviaListOperator.Compare(a, b);
            return output;
        }

        protected override bool Value_Equals(SyntaxTriviaList a, SyntaxTriviaList b)
        {
            var output = Instances.SyntaxTriviaListOperator.Equals(a, b);
            return output;
        }
    }
}
