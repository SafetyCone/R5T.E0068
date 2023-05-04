using System;


namespace R5T.E0068
{
    public class SyntaxOperator : ISyntaxOperator
    {
        #region Infrastructure

        public static ISyntaxOperator Instance { get; } = new SyntaxOperator();


        private SyntaxOperator()
        {
        }

        #endregion
    }
}
