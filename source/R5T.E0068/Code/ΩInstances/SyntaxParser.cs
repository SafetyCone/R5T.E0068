using System;


namespace R5T.E0068
{
    public class SyntaxParser : ISyntaxParser
    {
        #region Infrastructure

        public static ISyntaxParser Instance { get; } = new SyntaxParser();


        private SyntaxParser()
        {
        }

        #endregion
    }
}
