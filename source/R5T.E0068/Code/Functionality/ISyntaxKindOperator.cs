using System;

using Microsoft.CodeAnalysis.CSharp;

using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxKindOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Better to use one of the <see cref="CSharpExtensions.Kind(Microsoft.CodeAnalysis.SyntaxNode)"/> available when choosing to C#-specific extensions.
        /// </summary>
        public SyntaxKind ToSyntaxKind(int rawKind)
        {
            var output = (SyntaxKind)rawKind;
            return output;
        }

        /// <summary>
        /// Better to use one of the <see cref="CSharpExtensions.Kind(Microsoft.CodeAnalysis.SyntaxNode)"/> available when choosing to C#-specific extensions,
        /// then <see cref="object.ToString()"/> on <see cref="SyntaxKind"/>.
        /// </summary>
        public string ToSyntaxKindName(int rawKind)
        {
            var syntaxKind = this.ToSyntaxKind(rawKind);

            var syntaxKindName = syntaxKind.ToString();
            return syntaxKindName;
        }
    }
}
