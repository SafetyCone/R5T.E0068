using System;


namespace R5T.E0068
{
    public class SyntaxTriviaOperator : ISyntaxTriviaOperator
    {
        #region Infrastructure

        public static ISyntaxTriviaOperator Instance { get; } = new SyntaxTriviaOperator();


        private SyntaxTriviaOperator()
        {
        }

        #endregion
    }
}
