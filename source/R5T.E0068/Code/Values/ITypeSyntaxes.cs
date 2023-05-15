using System;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface ITypeSyntaxes : IValuesMarker
    {
        public PredefinedTypeSyntax Void => SyntaxFactory.PredefinedType(
            Instances.SyntaxTokens.Void);
    }
}
