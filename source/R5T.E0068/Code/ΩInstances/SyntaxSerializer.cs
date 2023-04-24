using System;


namespace R5T.E0068
{
    public class SyntaxSerializer : ISyntaxSerializer
    {
        #region Infrastructure

        public static ISyntaxSerializer Instance { get; } = new SyntaxSerializer();


        private SyntaxSerializer()
        {
        }

        #endregion
    }
}
