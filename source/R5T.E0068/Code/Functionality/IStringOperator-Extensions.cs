using System;

using R5T.T0132;


namespace R5T.E0068.Extensions
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        public IClassDeclaration ToClassDeclaration(string value)
        {
            var output = new ClassDeclaration(value);
            return output;
        }

        public IMethodDeclaration ToMethodDeclaration(string value)
        {
            var output = new MethodDeclaration(value);
            return output;
        }

        public IXmlDocumentationComment ToXmlDocumentationComment(string value)
        {
            var output = new XmlDocumentationComment(value);
            return output;
        }
    }
}
