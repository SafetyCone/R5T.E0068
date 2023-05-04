using System;

using Microsoft.CodeAnalysis;

using R5T.T0178;
using R5T.T0179;


namespace R5T.E0068
{
    /// <summary>
    /// Strongly-types a syntax trivia list as indentation.
    /// Note: indentation does not include the new-line trivia of line-leading (see <see cref="ILineLeading"/>).
    /// </summary>
    [StrongTypeMarker]
    public interface IIndentation : IStrongTypeMarker,
        ITyped<SyntaxTriviaList>
    {
    }
}
