using System;


namespace R5T.E0068
{
    public class SyntaxTokenExplorations : ISyntaxTokenExplorations
    {
        #region Infrastructure

        public static ISyntaxTokenExplorations Instance { get; } = new SyntaxTokenExplorations();


        private SyntaxTokenExplorations()
        {
        }

        #endregion
    }
}
