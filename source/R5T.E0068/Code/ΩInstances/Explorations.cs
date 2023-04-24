using System;


namespace R5T.E0068
{
    public class Explorations : IExplorations
    {
        #region Infrastructure

        public static IExplorations Instance { get; } = new Explorations();


        private Explorations()
        {
        }

        #endregion
    }
}
