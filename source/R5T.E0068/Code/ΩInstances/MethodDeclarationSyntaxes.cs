using System;


namespace R5T.E0068
{
    public class MethodDeclarationSyntaxes : IMethodDeclarationSyntaxes
    {
        #region Infrastructure

        public static IMethodDeclarationSyntaxes Instance { get; } = new MethodDeclarationSyntaxes();


        private MethodDeclarationSyntaxes()
        {
        }

        #endregion
    }
}
