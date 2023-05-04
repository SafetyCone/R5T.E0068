using System;


namespace R5T.E0068
{
    public class SyntaxTriviaExplorations : ISyntaxTriviaExplorations
    {
        #region Infrastructure

        public static ISyntaxTriviaExplorations Instance { get; } = new SyntaxTriviaExplorations();


        private SyntaxTriviaExplorations()
        {
        }

        #endregion
    }
}
