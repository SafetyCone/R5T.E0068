using System;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxParser : IFunctionalityMarker
    {
        private static Internal.ISyntaxParser Internal => E0068.Internal.SyntaxParser.Instance;


        public MemberDeclarationSyntax Parse_MemberDeclaration(ICode code)
        {
            var output = Internal.Parse_MemberDeclaration(code.Value);
            return output;
        }

        public ClassDeclarationSyntax Parse_Class(ICode text)
        {
            var output = Internal.Parse_Class(text.Value);
            return output;
        }
    }
}
