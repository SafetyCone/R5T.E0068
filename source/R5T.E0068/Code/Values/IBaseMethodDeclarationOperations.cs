using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;

using R5T.E0068.Extensions;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface IBaseMethodDeclarationOperations : IValuesMarker
    {
        public TSyntax Ensure_HasBody<TSyntax>(TSyntax syntax)
            where TSyntax : BaseMethodDeclarationSyntax
        {
            var hasBody = syntax.Has_Body();

            var output = hasBody
                ? syntax
                : syntax.WithBody(
                    Instances.SyntaxGenerator_Basic.Block_Empty()) as TSyntax
                ;

            return output;
        }
    }
}
