using System;


namespace R5T.E0068
{
    public class TypeSyntaxes : ITypeSyntaxes
    {
        #region Infrastructure

        public static ITypeSyntaxes Instance { get; } = new TypeSyntaxes();


        private TypeSyntaxes()
        {
        }

        #endregion
    }
}
