using System;

using R5T.T0131;
using R5T.T0172;
using R5T.T0172.Extensions;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface ICodeFilePaths : IValuesMarker
    {
        /// <summary>
        /// C:\Code\DEV\Git\GitHub\SafetyCone\R5T.E0068\source\R5T.E0068\Code\ΩInstances\CodeFilePaths.cs
        /// </summary>
        public ICodeFilePath ExampleClass => @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.E0068\source\R5T.E0068\Code\ΩInstances\CodeFilePaths.cs".ToCodeFilePath();
        public ICodeFilePath ExampleInterface => @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.E0068\source\R5T.E0068\Code\Values\ICodeFilePaths.cs".ToCodeFilePath();
    }
}
