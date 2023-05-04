using System;


namespace R5T.E0068
{
    public class SyntaxTypes : ISyntaxTypes
    {
        #region Infrastructure

        public static ISyntaxTypes Instance { get; } = new SyntaxTypes();


        private SyntaxTypes()
        {
        }

        #endregion
    }
}
