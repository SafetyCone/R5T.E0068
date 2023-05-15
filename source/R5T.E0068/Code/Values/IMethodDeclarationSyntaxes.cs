using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface IMethodDeclarationSyntaxes : IValuesMarker
    {
        public MethodDeclarationSyntax Main_Synchronous => Instances.MethodDeclarationSyntaxes_Constructed.Main_Synchronous;
    }
}
