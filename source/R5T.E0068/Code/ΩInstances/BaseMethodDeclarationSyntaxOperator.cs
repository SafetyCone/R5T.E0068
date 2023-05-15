using System;


namespace R5T.E0068
{
    public class BaseMethodDeclarationSyntaxOperator : IBaseMethodDeclarationSyntaxOperator
    {
        #region Infrastructure

        public static IBaseMethodDeclarationSyntaxOperator Instance { get; } = new BaseMethodDeclarationSyntaxOperator();


        private BaseMethodDeclarationSyntaxOperator()
        {
        }

        #endregion
    }
}
