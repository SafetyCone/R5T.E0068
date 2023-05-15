using System;

using Microsoft.CodeAnalysis;

using R5T.T0178;
using R5T.T0179;


namespace R5T.E0068
{
    /// <summary>
    /// Strongly-types a syntax trivia list as line-leading.
    /// Note: line-leading always starts with a new-line trivia, and is followed by indentation (see <see cref="IIndentation"/>).
    /// </summary>
    [StrongTypeMarker]
    public interface ILineLeading : IStrongTypeMarker,
        ITyped<SyntaxTriviaList>
    {
    }
}
