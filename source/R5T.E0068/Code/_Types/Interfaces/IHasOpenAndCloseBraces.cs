using System;

using Microsoft.CodeAnalysis;


namespace R5T.E0068
{
    public interface IHasOpenAndCloseBraces
    {
        SyntaxToken OpenBraceToken { get; set; }
        SyntaxToken CloseBraceToken { get; set; }
    }
}
