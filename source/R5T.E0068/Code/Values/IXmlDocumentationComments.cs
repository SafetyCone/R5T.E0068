using System;

using R5T.T0131;

using R5T.E0068.Extensions;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface IXmlDocumentationComments : IValuesMarker
    {
        public IXmlDocumentationComment Example =>
@"
/// <summary>
/// A main method.
/// </summary>
"
.Trim().ToXmlDocumentationComment();
    }
}
