using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using R5T.T0132;


namespace R5T.E0068.Extensions
{
    [FunctionalityMarker]
    public partial interface ISyntaxTriviaListOperator : IFunctionalityMarker
    {
        public IIndentation ToIndentation(SyntaxTriviaList value)
        {
            var output = new Indentation(value);
            return output;
        }

        public ILineLeading ToLineLeading(SyntaxTriviaList value)
        {
            var output = new LineLeading(value);
            return output;
        }
    }
}
