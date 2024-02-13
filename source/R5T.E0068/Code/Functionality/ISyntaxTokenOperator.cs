using System;
using System.IO;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0089.T000;
using R5T.F0000.Extensions;
using R5T.F0124;
using R5T.F0124.Extensions;
using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxTokenOperator : IFunctionalityMarker
    {
        public SyntaxToken Annotate(
            SyntaxToken token,
            out SyntaxAnnotation annotation)
        {
            return Instances.SyntaxAnnotationOperator.Annotate(
                token,
                out annotation);
        }

        public string Describe_To_String(
            SyntaxToken token,
            ILineSeparator lineSeparator)
        {
            var textRepresentation = Instances.TextOperator.Get_TextRepresentation(token.Text);

            var lines = Instances.EnumerableOperator.From($"{textRepresentation}: SyntaxToken")
                .Append(Instances.EnumerableOperator.New<string>()
                    .Append(
                        $"{token.Kind()}: kind ({token.RawKind})",
                        $"{token.Text}: text",
                        $"{token.ValueText}: value text",
                        $"{token.IsMissing}: is missing")
                    .AppendIf(
                        token.Value is not null,
                        // Use an expression to avoid execution if the value is actually null!
                        () => $"{token.Value}: value, ({token.Value.GetType().FullName})")
                    .AppendIf(
                        token.Value is null,
                        $"{Instances.Strings.Null_TextRepresentation}: value")
                    .AppendIf(
                        !token.HasLeadingTrivia,
                        () => $"{token.HasLeadingTrivia}: has leading trivia")
                    .AppendIf(
                        token.HasLeadingTrivia,
                        () =>
                        {
                            var leadingTriviaDisplay = Instances.SyntaxTriviaListOperator.Display_To_String(token.LeadingTrivia);

                            var count = token.LeadingTrivia.Count;

                            var output = $"{leadingTriviaDisplay}: leading trivia list (count: {count})";
                            return output;
                        })
                    .AppendIf(
                        !token.HasTrailingTrivia,    
                        () => $"{token.HasTrailingTrivia}: has trailing trivia")
                    .AppendIf(
                        token.HasTrailingTrivia,
                        () =>
                        {
                            var trailingTriviaDisplay = Instances.SyntaxTriviaListOperator.Display_To_String(token.TrailingTrivia);

                            var count = token.TrailingTrivia.Count;

                            var output = $"{trailingTriviaDisplay}: trailing trivia list (count: {count})";
                            return output;
                        })
                    .Tabinate())
                ;

            var line = Instances.TextOperator.Join_Lines(
                lines,
                lineSeparator);

            return line;
        }

        public string Describe_To_String(SyntaxToken token)
        {
            return this.Describe_To_String(
                token,
                Instances.Strings.NewLine_ForEnvironment.ToLineSeparator());
        }

        public void Describe_To(
            SyntaxToken token,
            TextWriter writer)
        {
            var line = this.Describe_To_String(
                token,
                writer.NewLine.ToLineSeparator());

            writer.WriteLine(line);
        }

        public void Describe_To_Console(SyntaxToken token)
        {
            this.Describe_To(
                token,
                Console.Out);
        }

        public StructuredTriviaSyntax Get_AncestorStructuredTriviaSyntax(SyntaxToken token)
        {
            this.Verify_IsPartOfStructuredTrivia(token);

            var parentNode = this.Verify_HasParent(token);

            var output = Instances.SyntaxNodeOperator.Get_AncestorStructuredTriviaSyntax(parentNode);
            return output;
        }

        public SyntaxTrivia Get_AncestorStructuredTrivia(SyntaxToken token)
        {
            var syntax = this.Get_AncestorStructuredTriviaSyntax(token);

            var parentTrivia = Instances.StructuredTriviaSyntaxOperator.Verify_HasParentTrivia(syntax);
            return parentTrivia;
        }

        public SyntaxTriviaList Get_LeadingSeparatingTrivia(SyntaxToken syntaxToken)
        {
            var previousToken = syntaxToken.GetPreviousToken();

            var previousTrailingTrivia = previousToken.TrailingTrivia;
            var leadingTrivia = syntaxToken.LeadingTrivia;

            var leadingSeparatingTrivia = Instances.SyntaxTriviaListOperator.Combine(
                previousTrailingTrivia,
                leadingTrivia);

            return leadingSeparatingTrivia;
        }

        /// <summary>
        /// Chooses <see cref="Get_LeadingSeparatingTrivia(SyntaxToken)"/> as the default.
        /// </summary>
        public SyntaxTriviaList Get_SeparatingTrivia(SyntaxToken syntaxToken)
        {
            return this.Get_LeadingSeparatingTrivia(syntaxToken);
        }

        public WasFound<SyntaxNode> Has_Parent(SyntaxToken token)
        {
            var output = WasFound.From(token.Parent);
            return output;
        }

        [Obsolete("See R5T.L0073.F001.ISyntaxTokenOperator.Is_None()")]
        public bool Is_None(SyntaxToken token)
        {
            var output = token.IsKind(SyntaxKind.None);
            return output;
        }

        [Obsolete("See R5T.L0073.F001.ISyntaxTokenOperator.Is_None()")]
        public bool Is_NotNone(SyntaxToken token)
        {
            var isNone = this.Is_None(token);

            var output = !isNone;
            return output;
        }

        public WasFound<SyntaxTrivia> Is_InStructuredTrivia(SyntaxToken token)
        {
            var isPartOfStructuredTrivia = token.IsPartOfStructuredTrivia();
            if(!isPartOfStructuredTrivia)
            {
                return WasFound.NotFound<SyntaxTrivia>();
            }

            var parent = token.Parent;
            while(parent is not StructuredTriviaSyntax)
            {
                parent = parent.Parent;
            }

            var trivia = (parent as StructuredTriviaSyntax).ParentTrivia;
            return WasFound.Found(trivia);
        }

        /// <summary>
        /// The syntax token type has a parameterless public constructor (like all value-types).
        /// But no other constructors.
        /// Thus it is possible to create a new syntax token in its initial state.
        /// </summary>
        public SyntaxToken New()
        {
            var output = new SyntaxToken();
            return output;
        }

        // No good, since cannot modify syntax tokens one created!
        //public SyntaxToken New(
        //    IEnumerable<Func<SyntaxToken, SyntaxToken>> modifiers)
        //{
        //    var output = this.New();

        //    foreach (var modifier in modifiers)
        //    {
        //        output = modifier(output);
        //    }

        //    return output;
        //}

        // No good, since cannot modify syntax tokens once created!
        //public SyntaxToken New(
        //    params Func<SyntaxToken, SyntaxToken>[] modifiers)
        //{
        //    return this.New(modifiers.AsEnumerable());
        //}

        public SyntaxNode Verify_HasParent(SyntaxToken token)
        {
            var hasParent = this.Has_Parent(token);

            return hasParent.Get_Result_OrExceptionIfNotFound(
                "Token had no parent node.");
        }

        public void Verify_IsPartOfStructuredTrivia(SyntaxToken token)
        {
            var isPartOfStructuredTrivia = token.IsPartOfStructuredTrivia();
            if (!isPartOfStructuredTrivia)
            {
                throw new Exception("Token was not part of a structured trivia.");
            }
        }

        public SyntaxToken Without_LeadingTrivia(SyntaxToken token)
        {
            var output = token.WithLeadingTrivia(
                Instances.SyntaxTriviaLists.For_HasTrivia_False);

            return output;
        }

        public SyntaxToken Without_TrailingTrivia(SyntaxToken token)
        {
            var output = token.WithTrailingTrivia(
                Instances.SyntaxTriviaLists.For_HasTrivia_False);

            return output;
        }
    }
}
