using System;


namespace R5T.E0068
{
    public class SyntaxConstructor : ISyntaxConstructor
    {
        #region Infrastructure

        public static ISyntaxConstructor Instance { get; } = new SyntaxConstructor();


        private SyntaxConstructor()
        {
        }

        #endregion
    }
}
