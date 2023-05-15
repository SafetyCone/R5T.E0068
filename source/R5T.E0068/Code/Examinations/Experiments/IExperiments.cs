using System;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0141;


namespace R5T.E0068
{
    [ExperimentsMarker]
    public partial interface IExperiments : IExperimentsMarker
    {
        public void WhatIs_DocumentationCommentExteriorParentNextNode()
        {
            /// Run.
            var methodDeclaration = Instances.SyntaxParser.Parse_MethodDeclaration(
                Instances.MethodDeclarations.Main_WithDocumentationAndSingleTabIndentation);

            var documentationCommentExteriorTrivias = Instances.SyntaxNodeOperator.Get_DescendantTrivias(methodDeclaration)
                .Where(token => token.IsKind(SyntaxKind.DocumentationCommentExteriorTrivia))
                .Now();

            var first = documentationCommentExteriorTrivias.First();

            var x = Instances.SyntaxTriviaOperator.Get_SeparatingTrivias(first).Now();

            var parentToken = Instances.SyntaxTriviaOperator.Verify_HasParent(first);

            //var isPartOfStructuredTrivia = first.IsPartOfStructuredTrivia();
            //if(isPartOfStructuredTrivia)
            //{
            //    var parentNode = Instances.SyntaxTokenOperator.Verify_HasParent(parentToken);


            //}


            //Instances.SyntaxTokenOperator.Describe_To_Console(parentToken);

            //var previousToken = parentToken.GetPreviousToken(
            //    includeZeroWidth: true,
            //    includeSkipped: false,
            //    includeDirectives: true,
            //    includeDocumentationComments: true);

            //Instances.SyntaxTokenOperator.Describe_To_Console(previousToken);


        }
    }
}
