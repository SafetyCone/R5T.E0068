using System;

using R5T.T0131;
using R5T.T0172;
using R5T.T0172.Extensions;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface IFilePaths : IValuesMarker,
        Z0015.IFilePaths
    {
        public ICSharpFilePath CSharp_Temp => @"C:\Temp\Temp.cs".ToCSharpFilePath();
    }
}
