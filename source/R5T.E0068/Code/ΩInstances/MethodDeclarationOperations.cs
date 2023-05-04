using System;


namespace R5T.E0068
{
    public class MethodDeclarationOperations : IMethodDeclarationOperations
    {
        #region Infrastructure

        public static IMethodDeclarationOperations Instance { get; } = new MethodDeclarationOperations();


        private MethodDeclarationOperations()
        {
        }

        #endregion
    }
}
