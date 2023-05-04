using System;


namespace R5T.E0068.Extensions
{
    public static class StringExtensions
    {
        public static IClassDeclaration ToClassDeclaration(this string value)
        {
            return Instances.StringOperator_Extensions.ToClassDeclaration(value);
        }

        public static IMethodDeclaration ToMethodDeclaration(this string value)
        {
            return Instances.StringOperator_Extensions.ToMethodDeclaration(value);
        }

        public static IXmlDocumentationComment ToXmlDocumentationComment(this string value)
        {
            return Instances.StringOperator_Extensions.ToXmlDocumentationComment(value);
        }
    }
}
