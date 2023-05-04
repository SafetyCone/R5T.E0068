using System;

using Microsoft.CodeAnalysis;

using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface IHasOpenAndCloseBracesOperator : IFunctionalityMarker
    {
        public void Ensure_OpenAndCloseBracesOnNewLines(
            IHasOpenAndCloseBraces hasOpenAndCloseBraces)
        {
            hasOpenAndCloseBraces.OpenBraceToken = hasOpenAndCloseBraces.OpenBraceToken.WithLeadingTrivia(
                Instances.SyntaxTriviaLists.NewLine);

            hasOpenAndCloseBraces.CloseBraceToken = hasOpenAndCloseBraces.CloseBraceToken.WithLeadingTrivia(
                Instances.SyntaxTriviaLists.NewLine);
        }
    }
}
