using System;


namespace R5T.E0068
{
    public class SyntaxTrivias : ISyntaxTrivias
    {
        #region Infrastructure

        public static ISyntaxTrivias Instance { get; } = new SyntaxTrivias();


        private SyntaxTrivias()
        {
        }

        #endregion
    }
}
