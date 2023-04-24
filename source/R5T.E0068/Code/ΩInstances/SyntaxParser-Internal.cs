using System;


namespace R5T.E0068.Internal
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
