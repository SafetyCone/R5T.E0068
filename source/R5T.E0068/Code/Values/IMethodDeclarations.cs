using System;

using R5T.F0124.Extensions;
using R5T.T0131;

using R5T.E0068.Extensions;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface IMethodDeclarations : IValuesMarker
    {
        public IMethodDeclaration Main_Synchronous =>
@"
void Main()
{
}
".Trim_NewLines().ToMethodDeclaration();

        public IMethodDeclaration Main_WithSingleTabIndentation =>
@"
    void Main()
    {
    }
".Trim_NewLines().ToMethodDeclaration();

        public IMethodDeclaration Main_WithDocumentation =>
@"
/// <summary>
/// A main method.
/// </summary>
void Main()
{
}
".Trim_NewLines().ToMethodDeclaration();

        public IMethodDeclaration Main_WithDocumentationAndSingleTabIndentation =>
@"
    /// <summary>
    /// A main method.
    /// </summary>
    void Main()
    {
    }
".Trim_NewLines().ToMethodDeclaration();
    }
}
