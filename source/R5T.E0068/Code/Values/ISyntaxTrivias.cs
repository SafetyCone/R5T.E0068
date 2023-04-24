using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0131;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface ISyntaxTrivias : IValuesMarker
    {
        public SyntaxTrivia Whitespace_Empty => Instances.SyntaxTriviaOperator.New(
            SyntaxKind.WhitespaceTrivia,
            Instances.Strings.Empty);
    }
}
