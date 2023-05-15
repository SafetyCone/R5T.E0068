using System;


namespace R5T.E0068.Extensions
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
