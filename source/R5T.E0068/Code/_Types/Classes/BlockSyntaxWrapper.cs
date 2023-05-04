using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.E0068
{
    public class BlockSyntaxWrapper :
        IHasOpenAndCloseBraces
    {
        public BlockSyntax BlockSyntax { get; set; }
        

        public BlockSyntaxWrapper(BlockSyntax blockSyntax)
        {
            this.BlockSyntax = blockSyntax;
        }


        public SyntaxToken OpenBraceToken
        {
            get => this.BlockSyntax.OpenBraceToken;
            set
            {
                this.BlockSyntax = this.BlockSyntax.WithOpenBraceToken(value);
            }
        }

        public SyntaxToken CloseBraceToken
        {
            get => this.BlockSyntax.CloseBraceToken;
            set
            {
                this.BlockSyntax = this.BlockSyntax.WithCloseBraceToken(value);
            }
        }
    }
}
