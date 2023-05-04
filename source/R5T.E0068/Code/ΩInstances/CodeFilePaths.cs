using System;


namespace R5T.E0068
{
    public class CodeFilePaths : ICodeFilePaths
    {
        #region Infrastructure

        /// <summary>
        /// The instance.
        /// </summary>
        public static ICodeFilePaths Instance { get; } = new CodeFilePaths();

        private CodeFilePaths()
        {
        }

        #endregion
    }
}
