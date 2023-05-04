using System;

using R5T.T0178;
using R5T.T0193;


namespace R5T.E0068
{
    /// <summary>
    /// Strongly-types a string as the code of an XML documentation comment.
    /// Note: this includes the XML documentation comment line starts ("///") and line-feeds.
    /// </summary>
    [StrongTypeMarker]
    public interface IXmlDocumentationComment : IStrongTypeMarker,
        ICode
    {
    }
}
