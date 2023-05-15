using System;

using Microsoft.CodeAnalysis;


namespace R5T.E0068.Extensions
{
    public static class SyntaxTokenExtensions
    {
        public static SyntaxToken Annotate(this SyntaxToken token,
            out SyntaxAnnotation annotation)
        {
            return Instances.SyntaxTokenOperator.Annotate(token, out annotation);
        }

        public static bool Is_None(this SyntaxToken token)
        {
            return Instances.SyntaxTokenOperator.Is_None(token);
        }

        public static bool Is_NotNone(this SyntaxToken token)
        {
            return Instances.SyntaxTokenOperator.Is_NotNone(token);
        }

        public static SyntaxToken Without_TrailingTrivia(this SyntaxToken token)
        {
            return Instances.SyntaxTokenOperator.Without_TrailingTrivia(token);
        }
    }
}
