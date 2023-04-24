using System;


namespace R5T.E0068
{
    public class SyntaxTokens : ISyntaxTokens
    {
        #region Infrastructure

        public static ISyntaxTokens Instance { get; } = new SyntaxTokens();


        private SyntaxTokens()
        {
        }

        #endregion
    }
}
