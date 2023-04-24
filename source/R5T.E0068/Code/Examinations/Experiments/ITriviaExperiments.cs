using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0141;


namespace R5T.E0068
{
    [ExperimentsMarker]
    public partial interface ITriviaExperiments : IExperimentsMarker
    {
        /// <summary>
        /// When creating a new <see cref="SyntaxTrivia"/>, the documentation of <see cref="SyntaxFactory.SyntaxTrivia(SyntaxKind, string)"/> says the <see cref="SyntaxKind"/> should be one of:
        /// <list type="bullet">
        /// <item><see cref="SyntaxKind.WhitespaceTrivia"/></item>
        /// <item><see cref="SyntaxKind.EndOfLineTrivia"/></item>
        /// <item><see cref="SyntaxKind.SingleLineCommentTrivia"/></item>
        /// <item><see cref="SyntaxKind.MultiLineCommentTrivia"/></item>
        /// <item><see cref="SyntaxKind.DocumentationCommentExteriorTrivia"/></item>
        /// <item><see cref="SyntaxKind.DisabledTextTrivia"/></item>
        /// </list>
        /// What happens if you try to create a trivia with a different type?
        /// <para>Result: you get a System.ArgumentException, kind</para>
        /// </summary>
        public void WhatIf_WrongKind()
        {
            // System.ArgumentException, kind
            SyntaxFactory.SyntaxTrivia(
                SyntaxKind.MultiLineDocumentationCommentTrivia,
                " ");
        }
    }
}
