using System;

using R5T.T0131;

using R5T.E0068.Extensions;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface IClassDeclarations : IValuesMarker
    {
        /// <summary>
        /// A class declaration without a scope.
        /// </summary>
        public IClassDeclaration Class01 => "public class Class01".ToClassDeclaration();
    }
}
