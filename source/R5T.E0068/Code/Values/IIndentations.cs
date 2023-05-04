using System;

using R5T.T0131;

using R5T.E0068.Extensions;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface IIndentations : IValuesMarker
    {
        /// <inheritdoc cref="ISyntaxTriviaLists.Tab"/>
        public IIndentation Tab => Instances.SyntaxTriviaLists.Tab.ToIndentation();

        /// <summary>
        /// Two tabs (as spaces).
        /// </summary>
        public IIndentation Tab_Double => Instances.SyntaxTriviaListOperator.New(
            Instances.SyntaxTrivias.Whitespace_Tab,
            Instances.SyntaxTrivias.Whitespace_Tab).ToIndentation();

        /// <inheritdoc cref="ISyntaxTriviaLists.Empty"/>
        public IIndentation None => Instances.SyntaxTriviaLists.Empty.ToIndentation();
    }
}
