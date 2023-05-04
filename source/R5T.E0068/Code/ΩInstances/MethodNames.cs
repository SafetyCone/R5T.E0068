using System;


namespace R5T.E0068
{
    public class MethodNames : IMethodNames
    {
        #region Infrastructure

        public static IMethodNames Instance { get; } = new MethodNames();


        private MethodNames()
        {
        }

        #endregion
    }
}
