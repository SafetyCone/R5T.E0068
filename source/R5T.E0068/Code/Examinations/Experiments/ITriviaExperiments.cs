using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using R5T.F0000;
//using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.F0124.Extensions;
using R5T.T0141;


namespace R5T.E0068
{
    [ExperimentsMarker]
    public partial interface ITriviaExperiments : IExperimentsMarker
    {
        /// <summary>
        /// The <see cref="SyntaxTriviaList"/> type is a value-type (like integer), which means you always have an instance of it if you declare an instance of it.
        /// It's value might be "empty" (like zero for integers), but you still have the empty value.
        /// This leads to the question of how <see cref="SyntaxToken.HasLeadingTrivia"/> works; if a token always has a syntax trivia list instance (due to value-type), what determines
        /// whether the token actually "has" a leading or trailing trivia?
        /// </summary>
        public void Determine_HowHasTriviaIsDetermined()
        {
            var exmapleToken =
                //Instances.SyntaxTokens.Initial
                Instances.SyntaxTokens.Void
                ;

            Instances.SyntaxTokenOperator.Describe_To_Console(exmapleToken);

            // True, this means that the 
            Console.WriteLine($"{exmapleToken.HasLeadingTrivia}: initially");
            // Need to check whether has leading trivia, else accessing the leading trivia is an exception.
            if (exmapleToken.HasLeadingTrivia)
            {
                Instances.SyntaxTriviaOperator.Describe_To_Console(exmapleToken.LeadingTrivia.First());
            }

            exmapleToken = exmapleToken.WithLeadingTrivia(
                Instances.SyntaxTriviaLists.Empty);

            Console.WriteLine($"{exmapleToken.HasLeadingTrivia}: after with empty");
            if (exmapleToken.HasLeadingTrivia)
            {
                Instances.SyntaxTriviaOperator.Describe_To_Console(exmapleToken.LeadingTrivia.First());
            }

            exmapleToken = exmapleToken.WithLeadingTrivia(
                Instances.SyntaxTriviaLists.Default_Initial);

            Console.WriteLine($"{exmapleToken.HasLeadingTrivia}: after with default initial");
            if(exmapleToken.HasLeadingTrivia)
            {
                Instances.SyntaxTriviaOperator.Describe_To_Console(exmapleToken.LeadingTrivia.First());
            }

            exmapleToken = exmapleToken.WithLeadingTrivia(
                Instances.SyntaxTriviaLists.Default);

            Console.WriteLine($"{exmapleToken.HasLeadingTrivia}: after with default");
            if (exmapleToken.HasLeadingTrivia)
            {
                Instances.SyntaxTriviaOperator.Describe_To_Console(exmapleToken.LeadingTrivia.First());
            }

            // Breaks Roslyn to create a
            //exmapleToken = exmapleToken.WithLeadingTrivia(
            //    Instances.SyntaxTriviaLists.DoubleInitial);

            exmapleToken = Instances.SyntaxTokenOperator.Without_LeadingTrivia(exmapleToken);

            Console.WriteLine($"{exmapleToken.HasLeadingTrivia}: after without leading trivia");
            if (exmapleToken.HasLeadingTrivia)
            {
                Instances.SyntaxTriviaListOperator.Display_To_Console(exmapleToken.LeadingTrivia);
            }

            //exmapleToken = exmapleToken.WithLeadingTrivia(
            //    Instances.SyntaxTriviaLists.Default);

            //Console.WriteLine($"{exmapleToken.HasLeadingTrivia}: after with default");
        }

        /// <summary>
        /// What if you specify one of the valid syntax kinds for a syntax triva, but the text of the trivia does not match it's kind.
        /// Does Roslyn care?
        /// <para>Result: Roslyn does not care.</para>
        /// </summary>
        public void WhatIf_MismatchedText()
        {
            var mismatchedText = Instances.SyntaxTriviaOperator.New(
                ///// Works: Try to make an end-of-line kind trivia using a space.
                //SyntaxKind.EndOfLineTrivia,
                //Instances.Strings.Space
                /// Works: Try a whitespace kind trivia
                SyntaxKind.WhitespaceTrivia,
                Instances.Strings.NewLine
                );

            Instances.SyntaxTriviaOperator.Display_To_Console(mismatchedText);
        }

        public void Discover_AllowedSyntaxTriviaSyntaxKinds()
        {
            var allSyntaxKinds = Instances.EnumerationOperator.Get_Values<SyntaxKind>();

            // Assume that the text does not matter (this seems to be true).
            var triviaText = Instances.Strings.Space;

            var allowedSyntaxKinds = new List<SyntaxKind>();

            foreach (var syntaxKind in allSyntaxKinds)
            {
                try
                {
                    Instances.SyntaxTriviaOperator.New(
                        syntaxKind,
                        triviaText);

                    // If success, ok.
                    allowedSyntaxKinds.Add(syntaxKind);
                }
                catch (Exception) { };
            }

            var text = Instances.SyntaxKindOperator.Format_To_Text(allowedSyntaxKinds);

            Instances.NotepadPlusPlusOperator.WriteTextAndOpen(
                Instances.FilePaths.OutputTextFilePath,
                text);
        }

        /// <summary>
        /// When creating a new <see cref="SyntaxTrivia"/>, the documentation of <see cref="SyntaxFactory.SyntaxTrivia(SyntaxKind, string)"/> says the <see cref="SyntaxKind"/> should be one of:
        /// <inheritdoc cref="Documentation.ForSyntaxTriviaAllowedKinds" path="/definition"/>
        /// What happens if you try to create a trivia with a different kind?
        /// <para>Result: you get a System.ArgumentException, kind</para>
        /// </summary>
        public void WhatIf_WrongKind()
        {
            // System.ArgumentException: 'kind'
            SyntaxFactory.SyntaxTrivia(
                // This kind is not one of the allowed kinds for syntax trivia.
                SyntaxKind.MultiLineDocumentationCommentTrivia,
                " ");
        }
    }
}
