using System;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.E0068.Internal
{
    [FunctionalityMarker]
    public partial interface ISyntaxParser : IFunctionalityMarker
    {
        public MemberDeclarationSyntax Parse_MemberDeclaration(string text)
        {
            var output = SyntaxFactory.ParseMemberDeclaration(text);
            return output;
        }

        public ClassDeclarationSyntax Parse_Class(string text)
        {
            var output = this.Parse_MemberDeclaration(text) as ClassDeclarationSyntax;
            return output;
        }
    }
}
