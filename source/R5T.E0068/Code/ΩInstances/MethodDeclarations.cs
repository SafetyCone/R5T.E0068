using System;


namespace R5T.E0068
{
    public class MethodDeclarations : IMethodDeclarations
    {
        #region Infrastructure

        public static IMethodDeclarations Instance { get; } = new MethodDeclarations();


        private MethodDeclarations()
        {
        }

        #endregion
    }
}
