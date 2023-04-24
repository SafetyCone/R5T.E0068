using System;


namespace R5T.E0068
{
    public class SyntaxKindOperator : ISyntaxKindOperator
    {
        #region Infrastructure

        public static ISyntaxKindOperator Instance { get; } = new SyntaxKindOperator();


        private SyntaxKindOperator()
        {
        }

        #endregion
    }
}
