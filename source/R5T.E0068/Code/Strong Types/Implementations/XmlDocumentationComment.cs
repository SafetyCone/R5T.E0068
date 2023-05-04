using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.E0068
{
    /// <inheritdoc cref="IXmlDocumentationComment"/>
    [StrongTypeImplementationMarker]
    public class XmlDocumentationComment : TypedBase<string>, IStrongTypeMarker,
        IXmlDocumentationComment
    {
        public XmlDocumentationComment(string value)
            : base(value)
        {
        }
    }
}
