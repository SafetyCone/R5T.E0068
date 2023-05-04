using System;

using Microsoft.CodeAnalysis;

using R5T.T0178;


namespace R5T.E0068
{
    /// <inheritdoc cref="IIndentation"/>
    [StrongTypeImplementationMarker]
    public class Indentation : T0179.N001.TypedBase<SyntaxTriviaList>, IStrongTypeMarker,
        IIndentation
    {
        public Indentation(SyntaxTriviaList value)
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
