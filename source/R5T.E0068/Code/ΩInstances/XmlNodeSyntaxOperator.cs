using System;


namespace R5T.E0068
{
    public class XmlNodeSyntaxOperator : IXmlNodeSyntaxOperator
    {
        #region Infrastructure

        public static IXmlNodeSyntaxOperator Instance { get; } = new XmlNodeSyntaxOperator();


        private XmlNodeSyntaxOperator()
        {
        }

        #endregion
    }
}
