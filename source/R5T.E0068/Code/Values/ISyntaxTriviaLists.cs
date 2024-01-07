using System;

using Microsoft.CodeAnalysis;

using R5T.T0131;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface ISyntaxTriviaLists : IValuesMarker
    {
        /// <inheritdoc cref="ISyntaxTriviaListOperator.Default"/>
        public SyntaxTriviaList Default => Instances.SyntaxTriviaListOperator.Default();
        public SyntaxTriviaList Default_Initial => Instances.SyntaxTriviaListOperator.Default_Initial();

        /// <summary>
        /// A new, empty (zero element) syntax trivia list.
        /// </summary>
        [Obsolete("See R5T.L0037.F001.ISyntaxTriviaLists.Empty")]
        public SyntaxTriviaList Empty => Instances.SyntaxTriviaListOperator.New();

        public SyntaxTriviaList For_HasTrivia_False => this.Empty;
        public SyntaxTriviaList For_HasTrivia_True => this.Default;

        /// <summary>
        /// Contains two initial syntax trivias.
        /// </summary>
        [Obsolete("Throws a strange error.")]
        public SyntaxTriviaList DoubleInitial => new(
            Instances.SyntaxTrivias.Initial,
            Instances.SyntaxTrivias.Initial);

        /// <summary>
        /// Contains a new line.
        /// </summary>
        public SyntaxTriviaList NewLine => Instances.SyntaxTriviaListOperator.New(
            Instances.SyntaxTrivias.Whitespace_EndOfLine);

        /// <summary>
        /// Contains a single space.
        /// </summary>
        public SyntaxTriviaList Space => Instances.SyntaxTriviaListOperator.New(
            Instances.SyntaxTrivias.Whitespace_Space);

        /// <summary>
        /// Contains a single tab (as-spaces).
        /// </summary>
        public SyntaxTriviaList Tab => Instances.SyntaxTriviaListOperator.New(
            Instances.SyntaxTrivias.Whitespace_Tab);
    }
}
