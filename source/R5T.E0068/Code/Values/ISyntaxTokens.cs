using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0131;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface ISyntaxTokens : IValuesMarker
    {
        /// <summary>
        /// The initial zero-state of a syntax token.
        /// </summary>
        public SyntaxToken Initial => Instances.SyntaxTokenOperator.New();

        public SyntaxToken OpenBraceToken => SyntaxFactory.Token(SyntaxKind.OpenBraceToken);
        public SyntaxToken Void => SyntaxFactory.Token(SyntaxKind.VoidKeyword);
    }
}
