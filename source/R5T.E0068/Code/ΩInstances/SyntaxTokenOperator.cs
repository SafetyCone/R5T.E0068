using System;


namespace R5T.E0068
{
    public class SyntaxTokenOperator : ISyntaxTokenOperator
    {
        #region Infrastructure

        public static ISyntaxTokenOperator Instance { get; } = new SyntaxTokenOperator();


        private SyntaxTokenOperator()
        {
        }

        #endregion
    }
}
