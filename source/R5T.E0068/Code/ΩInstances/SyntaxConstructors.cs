using System;


namespace R5T.E0068
{
    public class SyntaxConstructors : ISyntaxConstructors
    {
        #region Infrastructure

        public static ISyntaxConstructors Instance { get; } = new SyntaxConstructors();


        private SyntaxConstructors()
        {
        }

        #endregion
    }
}
