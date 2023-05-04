using System;


namespace R5T.E0068
{
    public class SyntaxNodeOperator : ISyntaxNodeOperator
    {
        #region Infrastructure

        public static ISyntaxNodeOperator Instance { get; } = new SyntaxNodeOperator();


        private SyntaxNodeOperator()
        {
        }

        #endregion
    }
}
