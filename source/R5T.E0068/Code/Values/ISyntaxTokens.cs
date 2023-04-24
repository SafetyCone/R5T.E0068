using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0131;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface ISyntaxTokens : IValuesMarker
    {
        public SyntaxToken OpenBraceToken => SyntaxFactory.Token(SyntaxKind.OpenBraceToken);
    }
}
