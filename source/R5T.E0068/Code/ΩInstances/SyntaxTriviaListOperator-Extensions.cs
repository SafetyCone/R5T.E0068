using System;


namespace R5T.E0068.Extensions
{
    public class SyntaxTriviaListOperator : ISyntaxTriviaListOperator
    {
        #region Infrastructure

        public static ISyntaxTriviaListOperator Instance { get; } = new SyntaxTriviaListOperator();


        private SyntaxTriviaListOperator()
        {
        }

        #endregion
    }
}
