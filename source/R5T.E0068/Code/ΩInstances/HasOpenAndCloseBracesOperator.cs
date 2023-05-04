using System;


namespace R5T.E0068
{
    public class HasOpenAndCloseBracesOperator : IHasOpenAndCloseBracesOperator
    {
        #region Infrastructure

        public static IHasOpenAndCloseBracesOperator Instance { get; } = new HasOpenAndCloseBracesOperator();


        private HasOpenAndCloseBracesOperator()
        {
        }

        #endregion
    }
}
