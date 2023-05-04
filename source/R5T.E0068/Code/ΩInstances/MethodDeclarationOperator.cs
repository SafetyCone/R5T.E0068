using System;


namespace R5T.E0068
{
    public class MethodDeclarationOperator : IMethodDeclarationOperator
    {
        #region Infrastructure

        public static IMethodDeclarationOperator Instance { get; } = new MethodDeclarationOperator();


        private MethodDeclarationOperator()
        {
        }

        #endregion
    }
}
