using System;


namespace R5T.E0068
{
    public class SyntaxNodeOperations : ISyntaxNodeOperations
    {
        #region Infrastructure

        public static ISyntaxNodeOperations Instance { get; } = new SyntaxNodeOperations();


        private SyntaxNodeOperations()
        {
        }

        #endregion
    }
}
