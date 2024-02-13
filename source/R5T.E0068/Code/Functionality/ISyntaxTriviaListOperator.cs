using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.L0089.T000;
using R5T.T0132;

using R5T.E0068.Extensions;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxTriviaListOperator : IFunctionalityMarker
    {
        public SyntaxTriviaList Combine(
            SyntaxTriviaList first,
            SyntaxTriviaList second)
        {
            var output = first.AddRange(second);
            return output;
        }

        public int Compare(SyntaxTriviaList a, SyntaxTriviaList b)
        {
            var aString = a.ToFullString();
            var bString = b.ToFullString();

            var output = aString.CompareTo(bString);
            return output;
        }

        public bool Contains_NewLine(SyntaxTriviaList trivias)
        {
            var output = this.Get_NewLines(trivias)
                .Any();

            return output;
        }

        public string Describe_To_String(
            SyntaxTriviaList triviaList,
            string lineSeparator)
        {
            throw new NotImplementedException();
        }

        public void Describe_To(
            SyntaxTriviaList triviaList,
            TextWriter writer)
        {
            var line = this.Describe_To_String(
                triviaList,
                writer.NewLine);

            writer.WriteLine(line);
        }

        public string Display_To_String(
            SyntaxTriviaList triviaList)
        {
            if(triviaList.Count < 1)
            {
                return Instances.Strings.Empty_TextRepresentation;
            }

            var displayTokens = triviaList
                .Select(trivia => Instances.SyntaxTriviaOperator.Display_To_String(trivia))
                ;

            var content = Instances.StringOperator.Join(
                Instances.Strings.CommaSeparatedListSpacedSeparator,
                displayTokens);

            var output = $"{Instances.Strings.OpenBracket}{content}{Instances.Strings.CloseBracket}";
            return output;
        }

        public void Display_To(
            SyntaxTriviaList triviaList,
            TextWriter writer)
        {
            var text = this.Display_To_String(triviaList);

            writer.WriteLine(text);
        }

        public void Display_To_Console(SyntaxTriviaList triviaList)
        {
            this.Display_To(
                triviaList,
                Console.Out);
        }

        public bool Equals(SyntaxTriviaList a, SyntaxTriviaList b)
        {
            var output = a == b;
            return output;
        }

        /// <summary>
        /// Determine which of the trivias in the last are new-line trivias.
        /// </summary>
        /// <remarks>
        /// Does <strong>not</strong> structured trivias; simply evaluates trivias in the list.
        /// </remarks>
        public IEnumerable<SyntaxTrivia> Get_NewLines(SyntaxTriviaList trivias)
        {
            var output = trivias
                .Where(trivia => trivia.Is_NewLine())
                ;

            return output;
        }

        /// <summary>
        /// Determine which of the trivias in the last are structured.
        /// </summary>
        public IEnumerable<SyntaxTrivia> Get_StructuredTrivias(SyntaxTriviaList trivias)
        {
            var output = trivias
                .Where(trivias => trivias.Is_Structured())
                ;

            return output;
        }

        /// <summary>
        /// Determines if there are any new-line trivias in the list, and if so, returns the last new-line trivia.
        /// </summary>
        /// <inheritdoc cref="Get_NewLines(SyntaxTriviaList)" path="/remarks"/>
        public WasFound<SyntaxTrivia> Has_LastNewLine(SyntaxTriviaList trivias)
        {
            var newLines = this.Get_NewLines(trivias).Now();

            var exists = newLines.Any();

            var lastNewLine = newLines.LastOrDefault();

            var output = WasFound.From(exists, lastNewLine);
            return output;
        }

        /// <summary>
        /// Determines if there are any structured trivias in the list, and if so, returns the last structured trivia.
        /// </summary>
        /// <inheritdoc cref="Get_NewLines(SyntaxTriviaList)" path="/remarks"/>
        public WasFound<SyntaxTrivia> Has_LastStructuredTrivia(SyntaxTriviaList trivias)
        {
            var newLines = this.Get_StructuredTrivias(trivias).Now();

            var exists = newLines.Any();

            var lastNewLine = newLines.LastOrDefault();

            var output = WasFound.From(exists, lastNewLine);
            return output;
        }

        [Obsolete("See R5T.L0073.F001.ISyntaxTriviaListOperator.Insert_After()")]
        public SyntaxTriviaList Insert_After(
            SyntaxTriviaList trivias,
            SyntaxTrivia triviaToInsertAfter,
            SyntaxTriviaList insertion)
        {
            var indexOfInsertAfter = trivias.IndexOf(triviaToInsertAfter);

            var output = trivias.InsertRange(
                indexOfInsertAfter + 1,
                insertion);

            return output;
        }

        public SyntaxTriviaList InsertAfterLastStructuredTrivia(
            SyntaxTriviaList triviasWithStructuredTrivia,
            SyntaxTriviaList insertion)
        {
            IEnumerable<SyntaxTrivia> OutputReversed()
            {
                var enumerator = triviasWithStructuredTrivia.Reverse().GetEnumerator();

                while(enumerator.MoveNext())
                {
                    if(enumerator.Current.HasStructure)
                    {
                        break;
                    }

                    yield return enumerator.Current;
                }

                foreach (var trivia in insertion.Reverse())
                {
                    yield return trivia;
                }

                do
                {
                    yield return enumerator.Current;
                }
                while (enumerator.MoveNext());
            }

            var output = OutputReversed().Reverse().ToSyntaxTriviaList();
            return output;
        }

        /// <summary>
        /// Creates an new, empty syntax trivia list.
        /// </summary>
        public SyntaxTriviaList New()
        {
            var output = new SyntaxTriviaList();
            return output;
        }

        public SyntaxTriviaList New(params SyntaxTrivia[] trivias)
        {
            var output = new SyntaxTriviaList(trivias);
            return output;
        }

        /// <summary>
        /// The default initial trivia list has a single element, which is the initial trivia.
        /// </summary>
        public SyntaxTriviaList Default_Initial()
        {
            var output = new SyntaxTriviaList(
                Instances.SyntaxTrivias.Initial);

            return output;
        }

        /// <summary>
        /// The default trivia list created by the Roslyn machinery has a single element, which is an empty whitespace trivia.
        /// </summary>
        public SyntaxTriviaList Default()
        {
            var output = new SyntaxTriviaList(
                Instances.SyntaxTrivias.Whitespace_Empty);

            return output;
        }

        [Obsolete("See R5T.L0073.F001.ISyntaxTriviaListOperator.Prepend()")]
        public SyntaxTriviaList Prepend(
            SyntaxTriviaList trivias,
            SyntaxTriviaList prependix)
        {
            var output = new SyntaxTriviaList(
                prependix.AsEnumerable()
                    .Concat(trivias));

            return output;
        }

        /// <summary>
        /// Modifies the leading trivia such that it either contains the indentation, or a new-line and then the indentation (if it started with a new line).
        /// </summary>
        /// <remarks>
        /// Does <strong>not</strong> consider structured trivia in the trivia list.
        /// </remarks>
        public SyntaxTriviaList Set_Indentation(
            SyntaxTriviaList leadingTrivia,
            IIndentation indentation)
        {
            // Include everything in the trivia up to the last new-line or structured-trivia, then append the indention.
            var includedTriviaCount = 0;

            var hasLastNewLine = this.Has_LastNewLine(leadingTrivia);
            if(hasLastNewLine)
            {
                var indexOfLastNewLine = leadingTrivia.IndexOf(hasLastNewLine.Result);

                var lastNewLineIncludedTriviaCount = indexOfLastNewLine + 1;

                includedTriviaCount = Math.Max(includedTriviaCount, lastNewLineIncludedTriviaCount);
            }

            var hasStructuredTrivia = this.Has_LastStructuredTrivia(leadingTrivia);
            if(hasStructuredTrivia)
            {
                // Include everything in the trivia up to the last structured new line, then append the indention.
                var indexOfLastStructuredTrivia = leadingTrivia.IndexOf(hasStructuredTrivia.Result);

                var lastStructuredTriviaIncludedTriviaCount = indexOfLastStructuredTrivia + 1;

                includedTriviaCount = Math.Max(includedTriviaCount, lastStructuredTriviaIncludedTriviaCount);
            }

            var output = leadingTrivia.Take(includedTriviaCount)
                   .Append(indentation.Value)
                   .ToSyntaxTriviaList();

            return output;
        }
    }
}
