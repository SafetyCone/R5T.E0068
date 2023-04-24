using System;


namespace R5T.E0068
{
    public static class Instances
    {
        public static IClassDeclarations ClassDeclarations => E0068.ClassDeclarations.Instance;
        public static F0000.IEnumerableOperator EnumerableOperator => F0000.EnumerableOperator.Instance;
        public static IFilePaths FilePaths => E0068.FilePaths.Instance;
        public static F0033.INotepadPlusPlusOperator NotepadPlusPlusOperator => F0033.NotepadPlusPlusOperator.Instance;
        public static IStringOperator StringOperator => E0068.StringOperator.Instance;
        public static Z0000.IStrings Strings => Z0000.Strings.Instance;
        public static ISyntaxKindOperator SyntaxKindOperator => E0068.SyntaxKindOperator.Instance;
        public static ISyntaxParser SyntaxParser => E0068.SyntaxParser.Instance;
        public static ISyntaxSerializer SyntaxSerializer => E0068.SyntaxSerializer.Instance;
        public static ISyntaxTokenOperator SyntaxTokenOperator => E0068.SyntaxTokenOperator.Instance;
        public static ISyntaxTokens SyntaxTokens => E0068.SyntaxTokens.Instance;
        public static F0124.ITextOperator TextOperator => F0124.TextOperator.Instance;
        public static ISyntaxTriviaOperator SyntaxTriviaOperator => E0068.SyntaxTriviaOperator.Instance;
        public static ISyntaxTrivias SyntaxTrivias => E0068.SyntaxTrivias.Instance;
    }
}