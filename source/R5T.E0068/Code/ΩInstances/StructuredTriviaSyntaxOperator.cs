using System;


namespace R5T.E0068
{
    public class StructuredTriviaSyntaxOperator : IStructuredTriviaSyntaxOperator
    {
        #region Infrastructure

        public static IStructuredTriviaSyntaxOperator Instance { get; } = new StructuredTriviaSyntaxOperator();


        private StructuredTriviaSyntaxOperator()
        {
        }

        #endregion
    }
}
