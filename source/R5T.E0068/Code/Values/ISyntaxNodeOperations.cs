using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface ISyntaxNodeOperations : IValuesMarker
    {
        public TNode Move_DescendantTrailingTriviaToLeadingTrivia<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            return Instances.SyntaxNodeOperator.Move_DescendantTrailingTriviaToLeadingTrivia(node);
        }
    }
}
