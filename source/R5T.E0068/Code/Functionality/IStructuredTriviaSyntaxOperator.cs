using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.N0000;

using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface IStructuredTriviaSyntaxOperator : IFunctionalityMarker
    {
        public WasFound<SyntaxTrivia> Has_ParentTrivia(StructuredTriviaSyntax syntax)
        {
            var output = WasFound.From(syntax.ParentTrivia);
            return output;
        }

        public SyntaxTrivia Verify_HasParentTrivia(StructuredTriviaSyntax syntax)
        {
            var hasParentTrivia = this.Has_ParentTrivia(syntax);

            return hasParentTrivia.ResultOrExceptionIfNotFound(
                "Structured trivia had no parent trivia.");
        }
    }
}
