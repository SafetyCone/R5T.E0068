using System;


namespace R5T.E0068
{
    public class Indentations : IIndentations
    {
        #region Infrastructure

        public static IIndentations Instance { get; } = new Indentations();


        private Indentations()
        {
        }

        #endregion
    }
}
