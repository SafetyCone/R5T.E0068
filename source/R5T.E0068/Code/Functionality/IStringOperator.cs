using System;
using System.Net.Http.Headers;
using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        public IClassDeclaration ToClassDeclaration(string value)
        {
            var output = new ClassDeclaration(value);
            return output;
        }
    }
}
