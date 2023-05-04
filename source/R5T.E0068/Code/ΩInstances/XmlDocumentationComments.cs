using System;


namespace R5T.E0068
{
    public class XmlDocumentationComments : IXmlDocumentationComments
    {
        #region Infrastructure

        public static IXmlDocumentationComments Instance { get; } = new XmlDocumentationComments();


        private XmlDocumentationComments()
        {
        }

        #endregion
    }
}
