using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0131;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface ISyntaxTrivias : IValuesMarker
    {
        /// <summary>
        /// A trivia in its initial (zero) state.
        /// </summary>
        public SyntaxTrivia Initial => Instances.SyntaxTriviaOperator.New();

        [Obsolete("See R5T.L0073.F001.ISyntaxTrivias.Whitespace_Empty")]
        public SyntaxTrivia Whitespace_Empty => Instances.SyntaxTriviaOperator.New_Whitespace(
            Instances.Strings.Empty);

        [Obsolete("See R5T.L0073.F001.ISyntaxTrivias.Whitespace_Space")]
        public SyntaxTrivia Whitespace_Space => Instances.SyntaxTriviaOperator.New_Whitespace(
            Instances.Strings.Space);

        /// <summary>
        /// Get a whitespace tab character.
        /// <inheritdoc cref="Z0000.IStrings.Tab"/>
        /// </summary>
        [Obsolete("See R5T.L0073.F001.ISyntaxTrivias.Whitespace_Tab_Character")]
        public SyntaxTrivia Whitespace_Tab_Character => Instances.SyntaxTriviaOperator.New_Whitespace(
            Instances.Strings.Tab);

        /// <summary>
        /// Get a whitespace tab as spaces.
        /// <inheritdoc cref="F0000.IStrings.Tab_AsSpaces" path="/summary"/>
        /// </summary>
        [Obsolete("See R5T.L0073.F001.ISyntaxTrivias.Whitespace_Tab_Spaces")]
        public SyntaxTrivia Whitespace_Tab_Spaces => Instances.SyntaxTriviaOperator.New_Whitespace(
            Instances.Strings.Tab_AsSpaces);

        /// <inheritdoc cref="Whitespace_Tab_Spaces"/>
        [Obsolete("See R5T.L0073.F001.ISyntaxTrivias.Whitespace_Tab")]
        public SyntaxTrivia Whitespace_Tab => this.Whitespace_Tab_Spaces;

        /// <summary>
        /// Uses <see cref="Z0000.IStrings.NewLine_ForEnvironment"/> (which is <inheritdoc cref="Z0000.IStrings.NewLine_ForEnvironment" path="/summary"/>).
        /// </summary>
        [Obsolete("See R5T.L0073.F001.ISyntaxTrivias.Whitespace_EndOfLine")]
        public SyntaxTrivia Whitespace_EndOfLine => Instances.SyntaxTriviaOperator.New(
            SyntaxKind.EndOfLineTrivia,
            Instances.Strings.NewLine_ForEnvironment);


        private static readonly Lazy<SyntaxTrivia[]> zWhitespaces = new Lazy<SyntaxTrivia[]>(() => new[]
        {
            SyntaxTrivias.Instance.Whitespace_Empty,
            SyntaxTrivias.Instance.Whitespace_EndOfLine,
            SyntaxTrivias.Instance.Whitespace_Space,
            SyntaxTrivias.Instance.Whitespace_Tab_Character,
            SyntaxTrivias.Instance.Whitespace_Tab_Spaces,
        });
        public SyntaxTrivia[] Whitespaces => ISyntaxTrivias.zWhitespaces.Value;
    }
}
