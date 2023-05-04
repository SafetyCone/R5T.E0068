using System;

using R5T.T0141;


namespace R5T.E0068
{
    [ExplorationsMarker]
    public partial interface ISyntaxTokenExplorations : IExplorationsMarker
    {
        /// <summary>
        /// It's possible to create a token in it's initial state (zero-state, just like integer and other value-types).
        /// What does our describe and display machinery think that looks like?
        /// </summary>
        public void WhatDoesInitialTokenLookLike()
        {
            var initialToken = Instances.SyntaxTokens.Initial;

            // Kind: none.
            // Value: null
            // No leading or trailing trivia.
            Instances.SyntaxTokenOperator.Describe_To_Console(initialToken);
        }
    }
}
