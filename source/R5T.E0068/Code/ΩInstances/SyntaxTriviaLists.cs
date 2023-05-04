using System;


namespace R5T.E0068
{
    public class SyntaxTriviaLists : ISyntaxTriviaLists
    {
        #region Infrastructure

        public static ISyntaxTriviaLists Instance { get; } = new SyntaxTriviaLists();


        private SyntaxTriviaLists()
        {
        }

        #endregion
    }
}
