using System;


namespace R5T.E0068
{
    public class BaseMethodDeclarationOperations : IBaseMethodDeclarationOperations
    {
        #region Infrastructure

        public static IBaseMethodDeclarationOperations Instance { get; } = new BaseMethodDeclarationOperations();


        private BaseMethodDeclarationOperations()
        {
        }

        #endregion
    }
}
