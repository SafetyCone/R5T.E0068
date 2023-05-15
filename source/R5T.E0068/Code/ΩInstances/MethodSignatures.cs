using System;


namespace R5T.E0068
{
    public class MethodSignatures : IMethodSignatures
    {
        #region Infrastructure

        public static IMethodSignatures Instance { get; } = new MethodSignatures();


        private MethodSignatures()
        {
        }

        #endregion
    }
}
