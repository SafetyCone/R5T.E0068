using System;


namespace R5T.E0068.Basic
{
    public class SyntaxGenerator : ISyntaxGenerator
    {
        #region Infrastructure

        public static ISyntaxGenerator Instance { get; } = new SyntaxGenerator();


        private SyntaxGenerator()
        {
        }

        #endregion
    }
}
