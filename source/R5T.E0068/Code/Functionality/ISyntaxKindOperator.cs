using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp;

using R5T.F0124.Extensions;
using R5T.T0132;


namespace R5T.E0068
{
    [FunctionalityMarker]
    public partial interface ISyntaxKindOperator : IFunctionalityMarker
    {
        public string Describe_To_String(SyntaxKind syntaxKind)
        {
            var name = this.Get_Name(syntaxKind);
            var number = this.Get_Number(syntaxKind);

            var output = $"{name}: {number}";
            return output;
        }

        public string Format_To_Text(IEnumerable<SyntaxKind> syntaxKinds)
        {
            var allSyntaxKinds_Described = syntaxKinds
                .Select(syntaxKind => Instances.SyntaxKindOperator.Describe_To_String(syntaxKind))
                ;

            var columnSeparator = Instances.Strings.Colon.ToColumnSeparator();

            var text = Instances.StringOperator.Join(
                Instances.Strings.NewLine,
                Instances.TextOperator.Format_IntoColumns(
                    allSyntaxKinds_Described,
                    columnSeparator)
                .OrderAlphabetically());

            return text;
        }

        public string Get_Name(SyntaxKind syntaxKind)
        {
            var output = syntaxKind.ToString();
            return output;
        }

        public int Get_Number(SyntaxKind syntaxKind)
        {
            var output = (int)syntaxKind;
            return output;
        }

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

            var syntaxKindName = this.Get_Name(syntaxKind);
            return syntaxKindName;
        }
    }
}
