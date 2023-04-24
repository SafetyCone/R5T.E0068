using System;

using Microsoft.CodeAnalysis;


namespace R5T.E0068.Extensions
{
    public static class SyntaxTokenExtensions
    {
        public static bool Is_None(this SyntaxToken token)
        {
            return Instances.SyntaxTokenOperator.Is_None(token);
        }
    }
}
