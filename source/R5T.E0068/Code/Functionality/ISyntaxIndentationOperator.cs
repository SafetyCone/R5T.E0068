using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;

using R5T.E0068.Extensions;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxIndentationOperator : IFunctionalityMarker
    {
        //public IEnumerable<SyntaxTrivia> Get_Indentation_String(SyntaxTrivia trivia)
        //{
        //    // Do not include any of the text of the trivia itself; that will be handle by the user of the trivia.
        //    // Assume the all trivia is leading trivia.

        //    Instances.SyntaxTriviaOperator.Verify_IsInLeadingTrivia(trivia);

        //    var token = trivia.Token;

        //    // In the parent token, find the index of the given trivia.
        //    var indexOfTrivia = token.LeadingTrivia.IndexOf(trivia);


        //    // Find the start index in the parent token's leading trivia; the start index is the index after the last new-line trivia or structured trivia before the given trivia,
        //    //  or the first index if there is none.
        //    var priorTokensCount = indexOfTrivia;
        //    var startTrivia = token.LeadingTrivia.Take(priorTokensCount)
        //        .Where(trivia => trivia.Is_NewLine() || trivia.HasStructure)
        //        .LastOrDefault();

        //    var startIndex = startTrivia == default
        //        ? 0
        //        : token.LeadingTrivia.IndexOf(startTrivia)
        //        ;

        //    // Accumulate all whitespace in trivias from the first index to the last.
            
            
        //}

        /// <summary>
        /// Indents the node by the given indentation.
        /// </summary>
        /// <remarks>
        /// Note: "indent" only applies the indentation to the start of the given node, not all descendants of the node.
        /// To indent the node and all descendants, see <see cref="Indent_Block{TNode}(TNode, IIndentation)"/>
        /// </remarks>
        public TNode Indent<TNode>(
            TNode node,
            IIndentation indentation)
            where TNode : SyntaxNode
        {
            // Append a new-line trivia to the leading trivia of the node.
            node = node.WithLeadingTrivia(
                node.GetLeadingTrivia().Append(
                    indentation.Value));

            return node;
        }

        /// <summary>
        /// Indents a node by a single tab-as-spaces.
        /// </summary>
        public TNode Indent<TNode>(
            TNode node)
            where TNode : SyntaxNode
        {
            return this.Indent(
                node,
                Instances.Indentations.Tab);
        }

        /// <summary>
        /// Indents the node and all of its descendants by the given indentation.
        /// </summary>
        /// <remarks>
        /// To indent only the start of the node, see <see cref="Indent{TNode}(TNode, IIndentation)"/>.
        /// </remarks>
        public TNode Indent_Block<TNode>(
            TNode node,
            IIndentation indentation)
            where TNode : SyntaxNode
        {
            // Modify code.
            node = Instances.SyntaxTriviaOperator.Modify_NewLineContainingTriviaLists(
                node,
                (trivias, newLineTrivia) =>
                {
                    var newTrivias = Instances.SyntaxTriviaListOperator.Insert_After(
                        trivias,
                        newLineTrivia,
                        indentation.Value);

                    return newTrivias;
                });

            // Modify documentation.
            var documentationCommentExteriorTrivias = Instances.SyntaxNodeOperator.Get_DescendantTrivias(node)
                .Where(token => token.IsKind(SyntaxKind.DocumentationCommentExteriorTrivia))
                .Now();

            node = Instances.SyntaxNodeOperator.Replace_Trivias(
                node,
                documentationCommentExteriorTrivias
                    .Select(trivia =>
                    {
                        var newTrivia = Instances.SyntaxTriviaOperator.New(
                            SyntaxKind.DocumentationCommentExteriorTrivia,
                            indentation.Value.ToFullString() + trivia.ToString());

                        return (trivia, newTrivia);
                    }));

            // Now, also indent (just indent) the node itself.
            node = this.Indent(
                node,
                indentation);

            return node;
        }

        /// <summary>
        /// Indents a node and all of its descendants by a single tab-as-spaces.
        /// </summary>
        public TNode Indent_Block<TNode>(
            TNode node)
            where TNode : SyntaxNode
        {
            return this.Indent_Block(
                node,
                Instances.Indentations.Tab);
        }

        public TNode Set_Indentation<TNode>(
            TNode node,
            IIndentation indentation)
            where TNode : SyntaxNode
        {
            // Modify the leading trivia of the node such that it either starts with the indentation, or with a new-line and then the indentation.
            var leadingTrivia = node.GetLeadingTrivia();

            var newLeadingTrivia = Instances.SyntaxTriviaListOperator.Set_Indentation(
                leadingTrivia,
                indentation);

            node = node.WithLeadingTrivia(newLeadingTrivia);
            return node;
        }

        public TNode Set_BlockIndentation<TNode>(
            TNode node,
            IIndentation indentation)
            where TNode : SyntaxNode
        {
            node = Instances.SyntaxTriviaOperator.Modify_NewLineContainingTriviaLists(
                node,
                (trivias, _) =>
                {
                    var newTrivias = Instances.SyntaxTriviaListOperator.Set_Indentation(
                        trivias,
                        indentation);

                    return newTrivias;
                });

            // Now, also indent (just indent) the node itself.
            node = this.Set_Indentation(
                node,
                indentation);

            return node;
        }
    }
}
