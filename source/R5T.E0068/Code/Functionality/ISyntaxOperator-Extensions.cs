using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.F0000;
using R5T.T0132;
using R5T.T0172;
using R5T.T0193.Extensions;


namespace R5T.E0068.Extensions
{
    [FunctionalityMarker]
    public partial interface ISyntaxOperator : IFunctionalityMarker
    {
        public IMethodSignature ToMethodSignature(MethodDeclarationSyntax value)
        {
            var output = new MethodSignature(value);
            return output;
        }
    }
}
