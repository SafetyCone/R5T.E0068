using System;


namespace R5T.E0068
{
    public class SyntaxAnnotationOperator : ISyntaxAnnotationOperator
    {
        #region Infrastructure

        public static ISyntaxAnnotationOperator Instance { get; } = new SyntaxAnnotationOperator();


        private SyntaxAnnotationOperator()
        {
        }

        #endregion
    }
}
