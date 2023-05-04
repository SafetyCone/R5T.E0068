using System;


namespace R5T.E0068
{
    public class SyntaxIndentationOperator : ISyntaxIndentationOperator
    {
        #region Infrastructure

        public static ISyntaxIndentationOperator Instance { get; } = new SyntaxIndentationOperator();


        private SyntaxIndentationOperator()
        {
        }

        #endregion
    }
}
