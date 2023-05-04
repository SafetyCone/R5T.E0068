using System;

using R5T.T0131;
using R5T.T0161;
using R5T.T0161.Extensions;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface IMethodNames : IValuesMarker
    {
        public ISimplestMethodName Main => "Main".ToSimplestMethodName();
    }
}
