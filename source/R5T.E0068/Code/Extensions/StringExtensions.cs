using System;


namespace R5T.E0068.Extensions
{
    public static class StringExtensions
    {
        public static IClassDeclaration ToClassDeclaration(this string value)
        {
            return Instances.StringOperator.ToClassDeclaration(value);
        }
    }
}
