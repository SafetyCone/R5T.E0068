using System;


namespace R5T.E0068
{
    public class DocumentationCommentTriviaSyntaxOperator : IDocumentationCommentTriviaSyntaxOperator
    {
        #region Infrastructure

        public static IDocumentationCommentTriviaSyntaxOperator Instance { get; } = new DocumentationCommentTriviaSyntaxOperator();


        private DocumentationCommentTriviaSyntaxOperator()
        {
        }

        #endregion
    }
}
