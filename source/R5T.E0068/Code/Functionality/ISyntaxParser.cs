using System;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;
using R5T.T0193;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxParser : IFunctionalityMarker
    {
        private static Internal.ISyntaxParser Internal => E0068.Internal.SyntaxParser.Instance;


        //[Obsolete("See R5T.L0073.F001.ISyntaxParser.Parse_Node()")]
        public TNode Parse_Node<TNode>(
            string text,
            Func<string, TNode> parser,
            params Func<TNode, TNode>[] postParseOperations)
            where TNode : SyntaxNode
        {
            return Internal.Parse(
                text,
                parser,
                postParseOperations
                    .Prepend(
                        // Always move decendant trailing trivia to leading trivia.
                        Instances.SyntaxNodeOperations.Move_DescendantTrailingTriviaToLeadingTrivia));
        }

        //[Obsolete("See R5T.L0073.F001.Internal.ISyntaxParser.Parse_Node()")]
        public TNode Parse_Node<TNode>(
            ICode code,
            Func<string, TNode> parser,
            params Func<TNode, TNode>[] postParseOperations)
            where TNode : SyntaxNode
        {
            return this.Parse_Node(
                code.Value,
                parser,
                postParseOperations);
        }

        public ClassDeclarationSyntax Parse_Class(ICode code)
        {
            var output = this.Parse_Node(
                code.Value,
                Internal.Parse_Class);

            return output;
        }

        public CompilationUnitSyntax Parse_CompilationUnitSyntax(string code)
        {
            var output = this.Parse_Node(
                code,
                Internal.Parse_CompilationUnit);

            return output;
        }

        public CompilationUnitSyntax Parse_CompilationUnitSyntax(ICode code)
        {
            return this.Parse_CompilationUnitSyntax(code.Value);
        }

        public DocumentationCommentTriviaSyntax Parse_DocumentationComment(ICode code)
        {
            var output = this.Parse_Node(
                code,
                Internal.Parse_DocumentationComment);

            return output;
        }

        public MemberDeclarationSyntax Parse_MemberDeclaration(ICode code)
        {
            var output = this.Parse_Node(
                code,
                Internal.Parse_MemberDeclaration);

            return output;
        }

        public MethodDeclarationSyntax Parse_MethodDeclaration(ICode code)
        {
            var output = this.Parse_Node(
                code,
                Internal.Parse_MethodDeclaration);

            return output;
        }
    }
}
