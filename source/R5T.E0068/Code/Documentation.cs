using System;

using Microsoft.CodeAnalysis.CSharp;


namespace R5T.E0068
{
	/// <summary>
	/// A rebooted Roslyn experiments project.
	/// </summary>
	public static class Documentation
	{
        /// <summary>
        /// <inheritdoc cref="ForSyntaxTriviaAllowedKinds" path="/definition"/>
        /// </summary>
        /// <definition>
        /// <list type="bullet">
        /// <item><see cref="SyntaxKind.WhitespaceTrivia"/></item>
        /// <item><see cref="SyntaxKind.EndOfLineTrivia"/></item>
        /// <item><see cref="SyntaxKind.SingleLineCommentTrivia"/></item>
        /// <item><see cref="SyntaxKind.MultiLineCommentTrivia"/></item>
        /// <item><see cref="SyntaxKind.DocumentationCommentExteriorTrivia"/></item>
        /// <item><see cref="SyntaxKind.DisabledTextTrivia"/></item>
        /// </list>
        /// </definition>
        /// <name><i>SyntaxTrivia allowed kinds</i></name>
        /// <remarks>
        /// Note: the allowed 6 syntax kinds was confirmed by <see cref="ITriviaExperiments.Discover_AllowedSyntaxTriviaSyntaxKinds"/>.
        /// </remarks>
        public static readonly object ForSyntaxTriviaAllowedKinds;
	}
}