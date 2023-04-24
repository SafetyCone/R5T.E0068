using System;


namespace R5T.E0068
{
    public class ClassDeclarations : IClassDeclarations
    {
        #region Infrastructure

        public static IClassDeclarations Instance { get; } = new ClassDeclarations();


        private ClassDeclarations()
        {
        }

        #endregion
    }
}
