using System;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxIndentationOperator : IFunctionalityMarker
    {
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
