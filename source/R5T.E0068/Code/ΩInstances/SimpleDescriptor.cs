using System;


namespace R5T.E0068
{
    public class SimpleDescriptor : ISimpleDescriptor
    {
        #region Infrastructure

        public static ISimpleDescriptor Instance { get; } = new SimpleDescriptor();


        private SimpleDescriptor()
        {
        }

        #endregion
    }
}
